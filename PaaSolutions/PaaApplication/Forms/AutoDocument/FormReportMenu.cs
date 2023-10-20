using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoDocument.Application.Data;
using System.Net.Http;
using Newtonsoft.Json;
using Core.Application.Data.ClientInfo;
using System.Configuration;
using Common.Infrastructure.ApiClient;
using PaaApplication.Models.Common;
using PaaApplication.Models.AutoDocument;
using Common.Infrastructure.UI;
using Common.Infrastructure.ComboBoxCustom;
using NodaTime;

namespace PaaApplication.Forms
{
    public partial class FormReportsMenu : Form
    {

        enum DocumentTypeTab
        {
            MonthlyScreenerTab,
            ApplicationVolumeTab,
            YearlyBusinessTab
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        DocumentTypeTab SelectedTab = DocumentTypeTab.MonthlyScreenerTab;

        private HttpClient httpClient;

        public FormReportsMenu()
        {
            InitializeComponent();
            InitializeSettings();
        }

        private void FormReportsMenu_Load(object sender, EventArgs e)
        {
            DateTime curDate = DateTime.Now;
            dtmMonthlyScreener.Value = curDate.AddMonths(-1);
            dtmApplicationVolume.Value = curDate.AddMonths(-1);
            dtmYearlyBusiness.Value = curDate.AddYears(-1);
            dtmMonthlyScreener.MaxDate = curDate;
            dtmApplicationVolume.MaxDate = curDate;
            dtmYearlyBusiness.MaxDate = curDate;
        }

        public void InitializeSettings()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUri"];
            httpClient = ApiClientFactory.GetHttpClient(baseAddress);

            LoadComboboxMonthlyScreenerUsers();
        }

        public void LoadComboboxMonthlyScreenerUsers()
        {
            cboUsername.Items.Clear();
            cboUsername.ValueMember = "UserId";
            cboUsername.DisplayMember = "UserName";

            string url = "api/displayinfo/users";
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                List<UserDisplayInfoData> userDisplayInfoData = JsonConvert.DeserializeObject<List<UserDisplayInfoData>>(jsonContent);
                foreach (UserDisplayInfoData item in userDisplayInfoData)
                {
                    cboUsername.Items.Add(item);
                }
                if (cboUsername.Items.Count > 0)
                {
                    cboUsername.SelectedIndex = 0;
                }
            }
        }

        #region Radio events
        private void rdoMonthlyScreener_CheckedChanged(object sender, EventArgs e)
        {
            tabReports.SelectTab((int)DocumentTypeTab.MonthlyScreenerTab);
            SelectedTab = DocumentTypeTab.MonthlyScreenerTab;
        }

        private void rdoApplicationVolume_CheckedChanged(object sender, EventArgs e)
        {
            tabReports.SelectTab((int)DocumentTypeTab.ApplicationVolumeTab);
            SelectedTab = DocumentTypeTab.ApplicationVolumeTab;
        }

        private void rdoYearlyBusiness_CheckedChanged(object sender, EventArgs e)
        {
            tabReports.SelectTab((int)DocumentTypeTab.YearlyBusinessTab);
            SelectedTab = DocumentTypeTab.YearlyBusinessTab;
        }
        #endregion

        #region Make Report event
        private void btnMakeReport_Click(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    DocumentCompleteResult documentReportResult = null;
                    DocumentReportOption documentReportOption = null;
                    DateTimeZone tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();
                    switch (SelectedTab)
                    {
                        case DocumentTypeTab.MonthlyScreenerTab:
                            UserDisplayInfoData userDisplayInfo = (UserDisplayInfoData)cboUsername.SelectedItem;
                            string userName = userDisplayInfo.UserName;
                            string userId = userDisplayInfo.UserId;
                            DateTime reportDate = dtmMonthlyScreener.Value;
                            documentReportOption = new DocumentReportMonthlyScreenerOption(userId, userName, reportDate, tz.Id);
                            if (documentReportOption != null)
                            {
                                documentReportResult = GetDocumentCompleteResult.MonthlyScreener((DocumentReportMonthlyScreenerOption)documentReportOption);
                            }
                            break;
                        case DocumentTypeTab.ApplicationVolumeTab:
                            reportDate = dtmApplicationVolume.Value;
                            documentReportOption = new DocumentReportApplicationVolumeOption(reportDate, tz.Id);
                            if (documentReportOption != null)
                            {
                                documentReportResult = GetDocumentCompleteResult.ApplicationVolume((DocumentReportApplicationVolumeOption)documentReportOption);
                            }
                            break;
                        case DocumentTypeTab.YearlyBusinessTab:
                            int reportYear = dtmYearlyBusiness.Value.Year;
                            
                            documentReportOption = new DocumentReportYearlyBusinessOption(reportYear, tz.Id);
                            if (documentReportOption != null)
                            {
                                documentReportResult = GetDocumentCompleteResult.YearlyBusiness((DocumentReportYearlyBusinessOption)documentReportOption);
                            }
                            break;
                    }
                    if (documentReportResult != null)
                    {
                        FormDocumentComplete dialog = new FormDocumentComplete(documentReportOption.GetReportMessage(), documentReportResult);
                        this.Hide();
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.Show();
                    }
                    // Need to handle and inform User if NO RECORD FOUND.
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show("Could not create document!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Validate Monthly Screener tab
        private void dtmMonthlyScreener_ValueChanged(object sender, EventArgs e)
        {
            /*
            if (dtmMonthlyScreener.Value.Month > currentMonth ||
                dtmMonthlyScreener.Value.Year > currentYear)
            {
                dtmMonthlyScreener.Value = lastMonthlyScreenerDate;
                MessageBox.Show("The date is not valid!");
                return;
            }
            lastMonthlyScreenerDate = dtmMonthlyScreener.Value;
             */
        }
        #endregion

        #region Validate Application Volume tab
        private void dtmApplicationVolume_ValueChanged(object sender, EventArgs e)
        {
            /*
            if (dtmApplicationVolume.Value.Month > currentMonth ||
                dtmApplicationVolume.Value.Year > currentYear)
            {
                dtmApplicationVolume.Value = lastApplicationVolumeDate;
                MessageBox.Show("The date is not valid!");
                return;
            }
            lastApplicationVolumeDate = dtmApplicationVolume.Value;
             */
        }
        #endregion

        #region Validate Yearly Business tab
        private void dtmYearlyBusiness_ValueChanged(object sender, EventArgs e)
        {
            /*
            if (dtmYearlyBusiness.Value.Year > currentYear)
            {
                dtmYearlyBusiness.Value = lastYearlyBusinessDate;
                MessageBox.Show("The date is not valid!");
                return;
            }
            lastYearlyBusinessDate = dtmYearlyBusiness.Value;
             */
        }
        #endregion

        private void cboUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(this.cboUsername, e, false);
        }
    }
}
