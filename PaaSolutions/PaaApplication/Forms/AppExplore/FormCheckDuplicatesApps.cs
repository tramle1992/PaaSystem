using Common.Infrastructure.UI;
using Core.Application.Command.ExploreApps;
using Core.Application.Data.ExploreApps;
using Core.Infrastructure.ExploreApps;
using FastMember;
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
    public partial class FormCheckDuplicatesApps : Form
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataTable duplicateDataTable = null;
        private AppApiRepository appApiRepository = new AppApiRepository();
        private List<AppData> appList = null;

        public FormCheckDuplicatesApps()
        {
            InitializeComponent();

            if (this.duplicateDataTable != null)
            {
                this.duplicateDataTable.Rows.Clear();
            }
            CreateDuplicateDataTable();
            
        }

        public void SetApps(List<AppData> apps)
        {
            this.appList = apps;
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
            this.duplicateDataTable.Columns.Add("FullName", typeof(String));

            this.tlvDuplicates.DataSource = this.duplicateDataTable;

            for (int i = 0; i < this.tlvDuplicates.Columns.Count; i++)
            {
                this.tlvDuplicates.AllColumns[i].HeaderFont = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void btnCheckDuplicates_Click(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                // Get ssn list
                List<string> ssnNumbers = new List<string>();
                foreach (var app in this.appList.Where(x=>!string.IsNullOrEmpty(x.AppSSN)))
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
                                dr["ReceivedDate"] = app.ReceivedDate.Value.ToLocalTime();
                                dr["LocationName"] = app.LocationName;
                                dr["FullName"] = GetFullName(app.LastName, app.FirstName);
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
                                child["ReceivedDate"] = DateTime.Parse(dr["ReceivedDate"].ToString()).ToLocalTime();
                                child["LocationName"] = dr["LocationName"].ToString();
                                child["FullName"] = GetFullName(dr["LastName"].ToString(), dr["FirstName"].ToString());
                                this.duplicateDataTable.Rows.Add(child);
                            }
                        }
                    }

                    if (this.duplicateDataTable.Rows.Count > 0)
                    {
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
        private string GetFullName(string lastName, string firstName)
        {
            if (!string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(firstName))
                return string.Format("{0}, {1}", lastName, firstName);

            if (!string.IsNullOrWhiteSpace(lastName))
                return lastName;

            if (!string.IsNullOrWhiteSpace(firstName))
                return firstName;

            return string.Empty;
        }
    }
}
