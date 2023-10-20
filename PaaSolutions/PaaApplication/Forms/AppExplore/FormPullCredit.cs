using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Infrastructure.OLV;
using Common.Infrastructure.UI;
using Core.Application.Data.ExploreApps;
using Core.Application.Data.ClientInfo;
using PaaApplication.Helper;
using Core.Infrastructure.ClientInfo;
using CreditReport.Infrastructure;
using CreditReport.Domain.Model;
using CreditReport.Application;
using CreditReport.Application.Command;
using Administration.Infrastructure.Microbilt;
using System.Net;
using PaaApplication.Forms.Common;
using Core.Domain.Model.ClientInfo;
using BrightIdeasSoftware;
using Core.Infrastructure.ExploreApps;
using FastMember;
using System.Xml.Serialization;
using System.IO;
using Core.Application.Command.ExploreApps;
#if PRODUCTION_DEPLOY
using TuStd = MicrobiltPortAdapter.ProductionTuStd;
#else
using TuStd = MicrobiltPortAdapter.StagingTuStd;
#endif

namespace PaaApplication.Forms.AppExplore
{
    public partial class FormPullCredit : BaseForm
    {
        private FormMaster formMaster;
        private FormAppExplore formAppExplore;
        ReportApiRepository reportApiRepository = null;
        private List<AppData> appList = null;
        private AppApiRepository appApiRepository = new AppApiRepository();
        private ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private AccountInfoRepository accountInfoRepository;
        private readonly string stagingHtmlReportUrl = "https://sdkstage.microbilt.com/WebServices/gethtml/gethtml.aspx?guid=";
        private readonly string productionHtmlReportUrl = "https://creditserver.microbilt.com/WebServices/gethtml/gethtml.aspx?guid=";
        private List<AppData> unselectedAppList = new List<AppData>();
        List<Report> pullList = new List<Report>();
        private AppData selectedApp = null;
        List<string> cancelList = new List<string>();
        private DataTable duplicateDataTable = null;

        public FormPullCredit(FormMaster formMaster, FormAppExplore formAppExplore)
        {
            if (formMaster == null || formAppExplore == null)
            {
                throw new ArgumentException("Invaid Form: Main and Application forms need to be openned");
            }
            this.formMaster = formMaster;
            this.formAppExplore = formAppExplore;
            accountInfoRepository = new AccountInfoRepository();
            InitializeComponent();
            InitOLV();
        }

        public void SetApps(List<AppData> apps)
        {
            this.appList = apps;
            RefreshData();
        }

        public void SetSelectdApp(AppData app)
        {
            this.selectedApp = app;
        }

        private void RefreshData()
        {
            FillDataOLV();

            if (this.duplicateDataTable != null)
            {
                this.duplicateDataTable.Rows.Clear();
            }

            tabControlPullCredit.SelectedIndex = 0;

            lblDuplicate.Visible = false;
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

        private void InitOLV()
        {
            this.olvcolChecked.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    var unselectApp = this.unselectedAppList.Find(a => a == app);
                    if(unselectApp == null)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
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
            this.olvcolDOB.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    return app.BirthDate;
                }
                return "";
            };
            this.olvcolSSN.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    return app.AppSSN;
                }
                return "";
            };
            this.olvcolEndUser.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    if (!string.IsNullOrEmpty(app.ReportManagement) && !app.ReportManagement.Trim().ToLower().Equals("ind")) return app.ReportManagement;
                    return app.ClientAppliedName;
                }
                return "";
            };
            this.olvcolPermissPurpose.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    return "Tenant Screening";
                }
                return "";
            };
            this.olvcolCreditType.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    ClientData client = ClientCachedApiQuery.Instance.GetClient(app.ClientApplied);
                    return client.CreditType.DisplayName;
                }
                return "";
            };
        }

        private void FormPullCredit_LoadCompleted(object sender, EventArgs e)
        {
            reportApiRepository = new ReportApiRepository();
            CreateDuplicateDataTable();
            if (tabControlPullCredit.SelectedTab.Text == "Applications")
            {
                btnProceed.Visible = true;
                btnCancelPull.Visible = true;
                btnCheckDuplicates.Visible = false;
            }
            else
            {
                btnProceed.Visible = false;
                btnCancelPull.Visible = false;
                btnCheckDuplicates.Visible = true;
            }
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

            for (int i = 0; i < this.tlvDuplicates.Columns.Count; i++)
            {
                this.tlvDuplicates.AllColumns[i].HeaderFont = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void btnCancelPull_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                bool alreadyPulledExisted = false;
                List<AppData> appPullList = new List<AppData>();

                if (this.appList != null && this.appList.Count > 0)
                {
                    foreach (AppData app in appList)
                    {
                        AppData uncheckedApp = this.unselectedAppList.Find(a => a == app);
                        if (uncheckedApp != null) continue;
                        appPullList.Add(app);
                    }

                    foreach (var app in appPullList)
                    {
                        List<Report> lstReport = reportApiRepository.FindByAppId(app.ApplicationId);
                        if (lstReport != null && lstReport.Count(x => x.StatusCode.Trim().Equals("-4")) > 0)
                        {
                            alreadyPulledExisted = true;
                            break;
                        }
                    }
                }

                if (alreadyPulledExisted)
                {
                    DialogResult dialogResult = MessageBox.Show("Credit report(s)  have already existed in some of the applicant(s), are you sure you want to continue proceeding pulling credit?", "Warning Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    DialogResult dialogResultPull = MessageBox.Show("Are you sure you want to proceed pulling credit?", "Information Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResultPull == DialogResult.No)
                    {
                        return;
                    }
                }

                GlobalVars.IsIgnoreAutoSave = true;

                FormProgress formProgress = new FormProgress();
                formProgress.StartPosition = FormStartPosition.CenterScreen;
                formProgress.Argument = appPullList;
                formProgress.Text = "Pulling in progress";
                formProgress.DoWork += new FormProgress.DoWorkEventHandler(pullCredit_DoWork);
                DialogResult result = formProgress.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Pulling report has been cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    FormPullCreditResult formPullCreditResult = new FormPullCreditResult();
                    formPullCreditResult.SetApps(appPullList, pullList, true, this.cancelList);
                    formPullCreditResult.BringToFront();
                    formPullCreditResult.Show();
                    GlobalVars.IsIgnoreAutoSave = false;

                    return;
                }
                if (result == DialogResult.Abort)
                {
                    MessageBox.Show("Exception:" + Environment.NewLine + formProgress.Result.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GlobalVars.IsIgnoreAutoSave = false;
                    return;
                }

                var returnResult = formProgress.Result.Result;
                if (result == DialogResult.OK)
                {
                    using (new HourGlass())
                    {
                        FormPullCreditResult formPullCreditResult = new FormPullCreditResult();
                        formPullCreditResult.SetApps(appPullList, pullList, false, this.cancelList);
                        formPullCreditResult.BringToFront();
                        formPullCreditResult.Show();

                        this.unselectedAppList.Clear();
                        this.Hide();
                        GlobalVars.IsIgnoreAutoSave = false;
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalVars.IsIgnoreAutoSave = false;
                _logger.Error(ex);
            }
        }

        private bool isAbleToPullCredit(AppData app, ClientData client)
        {
            string creditType = client.CreditType.DisplayName;
            // Only proceed pull credit for particular report types
            if (string.IsNullOrEmpty(creditType) ||
                creditType.Equals(CreditType.EnhancePeopleSearch.DisplayName) ||
                creditType.Equals(CreditType.NoCreditReports.DisplayName))
            {
                return false;
            }
            if (app.ReportTypeName == "Res1" ||
                app.ReportTypeName == "Res2" ||
                app.ReportTypeName == "Res3" ||
                app.ReportTypeName == "Res4" ||
                app.ReportTypeName == "Cred1" ||
                app.ReportTypeName == "Cred2" ||
                app.ReportTypeName == "CredCrim" ||
                app.ReportTypeName == "ResECC" ||
                app.ReportTypeName == "ZFreebieCC " ||
                app.ReportTypeName == "ZFreebieCred ")
            {
                return true;
            }
            return false;
        }

        private void pullCredit_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            List<AppData> apps = (List<AppData>)sender.Argument;
            if (apps.Count == 0)
                return;

            this.pullList = new List<Report>();
            
            this.cancelList = new List<string>();
            this.cancelList.AddRange(apps.Select(x => x.ApplicationId).ToArray());

            int numTotal = apps.Count * 2;
            int numProcessed = 0;
            var currentUserName = this.formMaster.CURRENT_USER == null ? "" : this.formMaster.CURRENT_USER.UserName;
            // TODO: Using FormProgress to get the data;
            foreach (AppData app in apps)
            {
                AppData uncheckedApp = this.unselectedAppList.Find(a => a == app);
                if (uncheckedApp != null) continue;

                ClientData client = ClientCachedApiQuery.Instance.GetClient(app.ClientApplied);
                if (!this.isAbleToPullCredit(app, client))
                {
                    var missingTypeReport = new Report(new Guid().ToString(), app.ApplicationId);
                    missingTypeReport.StatusCode = "MT"; // Missing type
                    this.pullList.Add(missingTypeReport);
                    continue;
                }

                var acc = accountInfoRepository.FindByType(client.CreditType.Value);
                if (acc == null)
                    throw new InvalidOperationException("The Microbilt accounts are incorrect");

                GetReportCommand command = CreditReportHelper.BuildGetReportCommand(app, acc);

                if (sender.IsCancellation())
                {
                    e.Cancel = true;
                    return;
                }

                string id = "";
                try
                {
                    TuStd.TuStdRs_Type tuReport = CreditReportApplicationService.GetTuReport(command);
                    /*
                    0 = “OK”
                    -1 = “BUR. ERROR” (Bureau Error)
                    -2 = “INTERNAL ERROR”
                    -3 = “LINE ERROR”
                    -4 = “NO HIT”
                    -5 = “AUTHENTICATION ERROR”
                    -6 = “IN_PROC”
                     */

                    XmlSerializer xmlSerializer = new XmlSerializer(tuReport.GetType());

                    using (StringWriter textWriter = new StringWriter())
                    {
                        xmlSerializer.Serialize(textWriter, tuReport);
                        _logger.Debug("Response object");
                        _logger.Debug(textWriter.ToString());
                    }

                    var status = tuReport.MsgRsHdr.Status.StatusCode;

                    _logger.Debug("The report has been pulled with status is " + status.ToString());


                    numProcessed++;
                    int percentage = (100 * numProcessed) / numTotal;
                    string applicantName = string.IsNullOrEmpty(app.MiddleName) ? string.Format("{0} {1}", app.LastName, app.FirstName) : string.Format("{0} {1}. {2}", app.LastName, app.MiddleName, app.FirstName);
                    string progressStatus = string.Format("Pulling report of {0}", applicantName);
                    sender.SetProgress(percentage, progressStatus);

                    Report report = InitNewReport(command, Guid.NewGuid().ToString().ToUpper(), app, "", status.ToString(), currentUserName);

                    if (status == 0)
                    {
                        var resultApp = CreditReportHelper.MergeReportInfo(app, tuReport, command);
                        id = tuReport.MsgRsHdr.RqUID;

                        // If the app currently be selected then save it the same method as auto save, but need to load to GUI after finish
                        if (this.selectedApp != null && app != null &&
                            app.ApplicationId == this.selectedApp.ApplicationId)
                        {
                            _logger.Info("Save selected app: " + app.ApplicationId);
                            GlobalVars.IsIgnoreAutoSave = true;
                            var saveResult = this.formAppExplore.SaveAppAsync(app, client).GetAwaiter().GetResult();
                            BeginInvoke((MethodInvoker)delegate
                            {
                                this.formAppExplore.UpdateControlsFromApp(app);
                            });

                            GlobalVars.IsIgnoreAutoSave = false;
                        }
                        else if (app != null)
                        {
                            var saveResult = this.formAppExplore.SaveAppAsync(app, client).GetAwaiter().GetResult();
                        }

                        if (sender.IsCancellation())
                        {
                            e.Cancel = true;
                            return;
                        }

                        using (var webclient = new WebClient())
                        {
#if PRODUCTION_DEPLOY
                            var reportUrl = productionHtmlReportUrl + id;
#else
                            var reportUrl = stagingHtmlReportUrl + id;
#endif
                            _logger.Debug("Report url is: " + reportUrl);

                            _logger.Info("Download the report at :" + reportUrl);
                            string htmlString = webclient.DownloadString(reportUrl);
                            byte[] htmlData = Encoding.UTF8.GetBytes(htmlString);

                            report = InitNewReport(command, id.Substring(1, id.Length - 2), app, Convert.ToBase64String(htmlData), status.ToString(), currentUserName);
                            reportApiRepository.Add(report);
                            
                        }
                    }
                    else if (status == -4)
                    {
                        id = tuReport.MsgRsHdr.RqUID;
                        byte[] htmlData = Encoding.UTF8.GetBytes(string.Empty);
                        report = InitNewReport(command, id.Substring(1, id.Length - 2), app, Convert.ToBase64String(htmlData), status.ToString(), currentUserName);
                        reportApiRepository.Add(report);
                    }

                    this.pullList.Add(report);
                    this.cancelList.Remove(app.ApplicationId);

                    numProcessed++;
                    percentage = (100 * numProcessed) / numTotal;
                    applicantName = string.IsNullOrEmpty(app.MiddleName) ? string.Format("{0} {1}", app.LastName, app.FirstName) : string.Format("{0} {1}. {2}", app.LastName, app.MiddleName, app.FirstName);
                    progressStatus = string.Format("Pulling report of {0}", applicantName);
                    sender.SetProgress(percentage, progressStatus);
                    
                    if (sender.IsCancellation())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                catch (System.ServiceModel.CommunicationException ex)
                {
                    // Failed report
                    Report report = new Report();
                    var guid = Guid.NewGuid().ToString().ToUpper();
                    report = InitNewReport(command, guid, app, "", "NW_ERR", currentUserName);
                    this.pullList.Add(report);
                    this.cancelList.Remove(app.ApplicationId);
                    _logger.Error(ex);
                }
                catch(Exception ex)
                {
                    Report report = new Report();
                    var guid = Guid.NewGuid().ToString().ToUpper();
                    report = InitNewReport(command, guid, app, "", "UN_ERR", currentUserName);
                    this.pullList.Add(report);
                    this.cancelList.Remove(app.ApplicationId);
                    _logger.Error(ex);
                }
            }
        }

        public Report InitNewReport(GetReportCommand report, string reportId, AppData app, string dataBlob, string statusCode, string pulledBy)
        {
            Report data = new Report();
            try
            {
                data.ReportId = reportId;
                data.ApplicationId = app.ApplicationId;

                ClientData client = ClientCachedApiQuery.Instance.GetClient(app.ClientApplied);
                
                data.Type = client.CreditType.DisplayName;
                data.DataBlob = dataBlob;
                data.CreatedAt = DateTime.UtcNow;
                data.UpdatedAt = DateTime.UtcNow;
                data.EndUser = report.EndUser;
                data.StatusCode = statusCode;
                data.PulledBy = pulledBy;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message, "Exception");
            }
            return data;
        }

        private void olvApplications_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var item = e.Item as OLVListItem;
            if (item != null)
            {
                if (!item.Checked)
                {
                    this.unselectedAppList.Add((AppData)item.RowObject);
                }
                else if (item.Checked)
                {
                    this.unselectedAppList.Remove((AppData)item.RowObject);
                }
            }
        }

        private void btnCheckDuplicates_Click(object sender, EventArgs e)
        {
            using (new HourGlass())
            {

                // Get ssn list
                List<string> ssnNumbers = new List<string>();
                foreach (var app in this.appList)
                {
                    ssnNumbers.Add(app.AppSSN);
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
                        tabControlPullCredit.SelectedIndex = 1;
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

        private void tabControlPullCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlPullCredit.SelectedTab.Text == "Applications")
            {
                btnProceed.Visible = true;
                btnCancelPull.Visible = true;
                btnCheckDuplicates.Visible = false;
            }
            else
            {
                btnProceed.Visible = false;
                btnCancelPull.Visible = false;
                btnCheckDuplicates.Visible = true;
            }
        }
    }
}
