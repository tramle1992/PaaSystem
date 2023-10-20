using Common.Infrastructure.OLV;
using Common.Infrastructure.UI;
using Core.Application.Command.ExploreApps;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using Core.Infrastructure.ClientInfo;
using Core.Infrastructure.ExploreApps;
using FastMember;
using PaaApplication.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.AppExplore
{
    public partial class FormEportCredit : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private AppApiRepository appApiRepository = new AppApiRepository();
        private ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
        private AppCachedApiQuery appCachedApiQuery = AppCachedApiQuery.Instance;

        private FormAppExplore formAppExplore;
        private DataTable duplicateDataTable = null;
        private List<AppData> appList = null;

        private OLVColumnFormat olvFormat = new OLVColumnFormat();

        public FormEportCredit(FormAppExplore formAppExplore)
        {
            InitializeComponent();
            InitOLV();
            InitTLV();
            this.formAppExplore = formAppExplore;
        }

        public void SetApps(List<AppData> apps)
        {
            this.appList = apps;
            RefreshData();
        }

        private void RefreshData()
        {
            FillDataOLV();

            if (this.duplicateDataTable != null)
            {
                this.duplicateDataTable.Rows.Clear();
            }

            tabDisplay.SelectedIndex = 0;

            lblDuplicate.Visible = false;
        }

        private void FormEportCredit_LoadCompleted(object sender, EventArgs e)
        {
            CreateDuplicateDataTable();
        }

        private void InitOLV()
        {
            this.olvcolAppReceived.AspectGetter = delegate(object row)
            {
                AppData appplication = row as AppData;
                if (appplication != null)
                {
                    if (appplication.ReceivedDate != null)
                    {
                        return ((DateTime)appplication.ReceivedDate).ToLocalTime();
                    }
                }
                return "";
            };

            this.olvcolAppName.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                    return Utils.GetApplicantName(app, reportType);
                }
                return "";
            };
        }

        private void FillDataOLV()
        {
            if (this.appList != null && this.appList.Count > 0)
            {
                this.olvApplications.SetObjects(this.appList);
            }
            else
            {
                this.olvApplications.ClearObjects();
            }
        }

        private void InitTLV()
        {
            this.olvcolDupReceived.AspectGetter = delegate(object row)
            {
                var data = row as DataRowView;
                if(data != null)
                {
                    if(data.Row["ReceivedDate"] != null)
                    {
                        return ((DateTime)data.Row["ReceivedDate"]).ToLocalTime();
                    }
                }
                return "";
            };

            this.olvcolDupName.AspectGetter = delegate(object row)
            {
                DataRowView drv = row as DataRowView;
                if (drv != null && drv.DataView.Count > 0)
                {
                    string bufferName = "";
                    if (drv["ReportTypeName"].ToString() == "Comm")
                    {
                        bufferName = drv["Company"].ToString();
                    }
                    else
                    {
                        bufferName = drv["LastName"].ToString().Trim();
                        string firstName = drv["FirstName"].ToString().Trim();
                        if (!string.IsNullOrEmpty(firstName))
                        {
                            if (!string.IsNullOrEmpty(bufferName))
                            {
                                bufferName += ", " + firstName;
                            }
                            else
                            {
                                bufferName = firstName;
                            }
                        }
                    }
                    return bufferName;
                }
                return "";
            };
        }

        private void CreateDuplicateDataTable()
        {
            if (this.duplicateDataTable != null)
            {
                return;
            }

            this.duplicateDataTable = new DataTable();
            this.duplicateDataTable.Columns.Add("Id", typeof(String));
            this.duplicateDataTable.Columns.Add("ParentId", typeof(String));
            this.duplicateDataTable.Columns.Add("LastName", typeof(String));
            this.duplicateDataTable.Columns.Add("FirstName", typeof(String));
            this.duplicateDataTable.Columns.Add("ClientAppliedName", typeof(String));
            this.duplicateDataTable.Columns.Add("Company", typeof(String));
            this.duplicateDataTable.Columns.Add("ReportTypeName", typeof(String));
            this.duplicateDataTable.Columns.Add("ReceivedDate", typeof(DateTime));
            this.duplicateDataTable.Columns.Add("LocationName", typeof(String));

            this.tlvDuplicates.DataSource = this.duplicateDataTable;
        }

        private void btnCheckForDuplicates_Click(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                // Get ssn list
                List<string> ssnNumbers = new List<string>();
                foreach(var app in this.appList.Where(x=>!string.IsNullOrEmpty(x.AppSSN)))
                {
                    ssnNumbers.Add(app.AppSSN);
                }

                // No need to check duplicate if SSN number is empty
                if (!ssnNumbers.Any())
                {
                    lblDuplicate.Text = "No duplicate applications were found.";
                    lblDuplicate.BackColor = Color.Green;
                    lblDuplicate.ForeColor = Color.White;
                    lblDuplicate.Visible = true;
                    return;
                }

                var command = new GetAppBySSNCommand();
                command.SSNNumbers = ssnNumbers;
                List<AppData> allApps = appApiRepository.GetAppBySSN(command);
                if (allApps != null && allApps.Count > 0)
                {
                    // convert to data table & filter
                    DataTable dtAllApps = new DataTable();
                    using (var reader = ObjectReader.Create(allApps))
                    {
                        dtAllApps.Load(reader);
                    }

                    DataView dvFilter = new DataView(dtAllApps);
                    dtAllApps = dvFilter.ToTable();

                    // process for tlvDuplicates
                    if (dtAllApps.Rows.Count > 0)
                    {
                        Dictionary<string, DataRow> parentItems = new Dictionary<string, DataRow>(); // key is AppSSN
                        Dictionary<string, bool> parentsAdded = new Dictionary<string, bool>(); // key is AppSSN

                        // add parents
                        foreach (AppData app in this.appList)
                        {
                            if (string.IsNullOrWhiteSpace(app.AppSSN))
                            {
                                continue;
                            }
                            DataRow dr = null;
                            if (!parentItems.TryGetValue(app.AppSSN, out dr))
                            {
                                dr = this.duplicateDataTable.NewRow();
                                dr["Id"] = app.ApplicationId;
                                dr["ParentId"] = "0";
                                dr["LastName"] = app.LastName;
                                dr["FirstName"] = app.FirstName;
                                dr["ClientAppliedName"] = app.ClientAppliedName;
                                dr["Company"] = app.Company;
                                dr["ReportTypeName"] = app.ReportTypeName;
                                dr["ReceivedDate"] = app.ReceivedDate;
                                dr["LocationName"] = app.LocationName;
                                parentItems.Add(app.AppSSN, dr);
                            }
                        }

                        foreach (DataRow dr in dtAllApps.Rows)
                        {
                            string appSSN = dr["AppSSN"].ToString();
                            if (string.IsNullOrWhiteSpace(appSSN))
                            {
                                continue;
                            }
                            DataRow parent = null;
                            if (parentItems.TryGetValue(appSSN, out parent))
                            {
                                if (dr["ApplicationId"].ToString().Equals(parent["Id"].ToString()))
                                {
                                    continue;
                                }

                                bool added = false;
                                if (!parentsAdded.TryGetValue(appSSN, out added))
                                {
                                    this.duplicateDataTable.Rows.Add(parent);
                                    parentsAdded.Add(appSSN, true);
                                }

                                DataRow child = this.duplicateDataTable.NewRow();
                                child["Id"] = dr["ApplicationId"].ToString();
                                child["ParentId"] = parent["Id"].ToString();
                                child["LastName"] = dr["LastName"].ToString();
                                child["FirstName"] = dr["FirstName"].ToString();
                                child["ClientAppliedName"] = dr["ClientAppliedName"].ToString();
                                child["Company"] = dr["Company"].ToString();
                                child["ReportTypeName"] = dr["ReportTypeName"].ToString();
                                child["ReceivedDate"] = DateTime.Parse(dr["ReceivedDate"].ToString());
                                child["LocationName"] = dr["LocationName"].ToString();
                                this.duplicateDataTable.Rows.Add(child);
                            }
                        }
                    }

                    if (this.duplicateDataTable.Rows.Count > 0)
                    {
                        tabDisplay.SelectedIndex = 1;
                        lblDuplicate.Text = "Duplicate applications were found.";
                        lblDuplicate.BackColor = System.Drawing.Color.Red;
                        lblDuplicate.ForeColor = System.Drawing.Color.White;
                        lblDuplicate.Visible = true;
                    }
                    else
                    {
                        lblDuplicate.Text = "No duplicate applications were found.";
                        lblDuplicate.BackColor = System.Drawing.Color.Green;
                        lblDuplicate.ForeColor = System.Drawing.Color.White;
                        lblDuplicate.Visible = true;
                    }
                }
            }
        }

        private void olvApplications_DoubleClick(object sender, EventArgs e)
        {
            AppData selectedRow = this.olvApplications.SelectedObject as AppData;
            if (selectedRow == null)
            {
                return;
            }

            if (this.formAppExplore != null)
            {
                using (new HourGlass())
                {
                    this.formAppExplore.SetItemsOLVAppExplore(this.appList);
                    this.formAppExplore.SelectItemOLVAppExplore(selectedRow.ApplicationId);
                    this.formAppExplore.Focus();
                }
            }
        }

        private void tlvDuplicates_DoubleClick(object sender, EventArgs e)
        {
            DataRowView selectedRow = this.tlvDuplicates.SelectedObject as DataRowView;
            if (selectedRow == null)
            {
                return;
            }

            if (this.formAppExplore != null)
            {
                using (new HourGlass())
                {
                    AppData selectedApp = this.appList.Find(item => item.ApplicationId.Equals(selectedRow["Id"].ToString()));
                    if (selectedApp != null)
                    {
                        this.formAppExplore.SetItemsOLVAppExplore(this.appList);
                    }
                    else
                    {
                        AppData app = appCachedApiQuery.GetApp(selectedRow["Id"].ToString());
                        List<AppData> apps = new List<AppData>();
                        apps.Add(app);
                        this.formAppExplore.SetItemsOLVAppExplore(apps);
                    }
                    this.formAppExplore.SelectItemOLVAppExplore(selectedRow["Id"].ToString());
                    this.formAppExplore.Focus();
                }
            }
        }

    }
}
