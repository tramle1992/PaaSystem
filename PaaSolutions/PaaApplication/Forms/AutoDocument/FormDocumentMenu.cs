using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Core.Application.Data.ClientInfo;
using System.Configuration;
using Common.Infrastructure.ApiClient;
using System.Collections.Generic;
using PaaApplication.Models.AutoDocument;
using AutoDocument.Application.Data;
using PaaApplication.Forms.ClientInfo;
using PaaApplication.Models.Common;
using Common.Infrastructure.UI;
using Common.Infrastructure.ComboBoxCustom;
using NodaTime;

namespace PaaApplication.Forms
{
    public partial class FormDocumentsMenu : Form
    {
        enum ReportTypeTab
        {
            DailyReportTab,
            ReceiptLogTab,
            CalendarTab
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ReportTypeTab SelectedTab = ReportTypeTab.DailyReportTab;

        private HttpClient httpClient;

        public FormDocumentsMenu()
        {
            InitializeComponent();
            InitializeSettings();
        }

        private void frmDocumentsMenu_Load(object sender, EventArgs e)
        {
            DateTime curDate = DateTime.Now;
            dtmDailyReport.Value = curDate;
            dtmDailyReport.MaxDate = curDate;
            dtmReceiptLogFrom.Value = curDate.AddDays(-7);
            dtmReceiptLogTo.Value = curDate;
            dtmReceiptLogTo.MaxDate = curDate;
            dtmCalendarFrom.Value = curDate;
            dtmCalendarTo.Value = curDate;
        }

        public void InitializeSettings()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUri"];
            httpClient = ApiClientFactory.GetHttpClient(baseAddress);

            LoadComboboxDailyReportUsers();
            LoadComboboxReceiptLogClients();
        }

        public void LoadComboboxDailyReportUsers()
        {
            cboUsername.Items.Clear();
            cboUsername.ValueMember = "UserId";
            cboUsername.DisplayMember = "UserName";
            UserDisplayInfoData everyoneDisplayInfo = new UserDisplayInfoData("", "Everyone");
            cboUsername.Items.Add(everyoneDisplayInfo);

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

        public void LoadComboboxReceiptLogClients()
        {
            cboClientName.Items.Clear();
            cboClientName.ValueMember = "ClientId";
            cboClientName.DisplayMember = "ClientName";

            string url = "api/displayinfo/clients";
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                List<ClientDisplayInfoData> clientDisplayInfoData = JsonConvert.DeserializeObject<List<ClientDisplayInfoData>>(jsonContent);
                foreach (ClientDisplayInfoData item in clientDisplayInfoData)
                {
                    cboClientName.Items.Add(item);
                }
                if (cboClientName.Items.Count > 0)
                {
                    cboClientName.SelectedIndex = 0;
                }
            }
        }

        #region Radio events
        private void rdoDailyReport_CheckedChanged(object sender, EventArgs e)
        {
            tabDocuments.SelectTab((int)ReportTypeTab.DailyReportTab);
            SelectedTab = ReportTypeTab.DailyReportTab;
        }

        private void rdoReceiptLog_CheckedChanged(object sender, EventArgs e)
        {
            tabDocuments.SelectTab((int)ReportTypeTab.ReceiptLogTab);
            SelectedTab = ReportTypeTab.ReceiptLogTab;
        }

        private void rdoCalendar_CheckedChanged(object sender, EventArgs e)
        {
            tabDocuments.SelectTab((int)ReportTypeTab.CalendarTab);
            SelectedTab = ReportTypeTab.CalendarTab;
        }
        #endregion

        #region Make Document event
        private void btnMakeDocument_Click(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    DateTimeZone tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();

                    DocumentCompleteResult documentReportResult = null;
                    DocumentReportOption documentReportOption = null;
                    switch (SelectedTab)
                    {
                        case ReportTypeTab.DailyReportTab:
                            UserDisplayInfoData userDisplayInfo = (UserDisplayInfoData)cboUsername.SelectedItem;
                            bool isEveryone = string.IsNullOrEmpty(userDisplayInfo.UserId) ? true : false;
                            string userName = userDisplayInfo.UserName;
                            string userId = userDisplayInfo.UserId;
                            DateTime reportDate = dtmDailyReport.Value;
                            documentReportOption = new DocumentReportDailyReportOption(userId, userName, reportDate, isEveryone, tz.Id);
                            if (documentReportOption != null)
                            {
                                documentReportResult = GetDocumentCompleteResult.DailyReport((DocumentReportDailyReportOption)documentReportOption);
                            }
                            break;
                        case ReportTypeTab.ReceiptLogTab:
                            ClientDisplayInfoData clientDisplayInfo = (ClientDisplayInfoData)cboClientName.SelectedItem;
                            DateTime reportFrom = dtmReceiptLogFrom.Value;
                            DateTime reportTo = dtmReceiptLogTo.Value;
                            string clientId = clientDisplayInfo.ClientId;
                            string clientName = clientDisplayInfo.ClientName;
                            documentReportOption = new DocumentReportReceiptLogOption(clientId, clientName, reportFrom, reportTo, tz.Id);
                            if (documentReportOption != null)
                            {
                                documentReportResult = GetDocumentCompleteResult.ReceiptLog((DocumentReportReceiptLogOption)documentReportOption);
                            }
                            break;
                        case ReportTypeTab.CalendarTab:
                            DateTime calendarFrom = dtmCalendarFrom.Value;
                            DateTime calendarTo = dtmCalendarTo.Value;
                            documentReportOption = new DocumentReportCalendarOption(calendarFrom, calendarTo);
                            if (documentReportOption != null)
                            {
                                documentReportResult = GetDocumentCompleteResult.Calendar((DocumentReportCalendarOption)documentReportOption);
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
                    // Need to handle popup message to inform User if NO RECORD FOUND.
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show("Could not create document!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Validate Daily Report tab
        #endregion

        #region Validate Receipt Log tab
        private void dtmReceiptLogFrom_ValueChanged(object sender, EventArgs e)
        {
            dtmReceiptLogTo.MinDate = dtmReceiptLogFrom.Value;
            dtmReceiptLogFrom.MaxDate = dtmReceiptLogTo.Value;
        }

        private void dtmReceiptLogTo_ValueChanged(object sender, EventArgs e)
        {
            dtmReceiptLogFrom.MaxDate = dtmReceiptLogTo.Value;
            dtmReceiptLogTo.MinDate = dtmReceiptLogFrom.Value;
        }
        #endregion

        #region Validate Calendar tab
        private void dtmCalendarFrom_ValueChanged(object sender, EventArgs e)
        {
            dtmCalendarTo.MinDate = dtmCalendarFrom.Value;
            dtmCalendarFrom.MaxDate = dtmCalendarTo.Value;
        }

        private void dtmCalendarTo_ValueChanged(object sender, EventArgs e)
        {
            dtmCalendarFrom.MaxDate = dtmCalendarTo.Value;
            dtmCalendarTo.MinDate = dtmCalendarFrom.Value;
        }
        #endregion

        private void cboUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(this.cboUsername, e, false);
        }

        private void cboClientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(this.cboClientName, e, false);
        }
    }
}
