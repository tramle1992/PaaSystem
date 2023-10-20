using Common.Infrastructure.ComboBoxCustom;
using Common.Infrastructure.UI;
using Core.Application.Command.ExploreApps;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using Core.Domain.Model.ExploreApps;
using Core.Infrastructure.ClientInfo;
using Core.Infrastructure.ExploreApps;
using Dapper;
using IdentityAccess.CommonType;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Infrastructure.Identity;
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
    public partial class FormSearchApplication : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private FormMaster formMaster;

        // SIMPLE SEARCH
        private bool simpleSearch_OneWeek = false;
        private bool simpleSearch_OneMonth = false;

        public int ActiveTab
        {
            get { return tabControlSearchApp.SelectedIndex; }
        }

        public FormSearchApplication(FormMaster formMaster)
        {
            InitializeComponent();
            InitializeSettings();
            this.formMaster = formMaster;
        }

        public void InitializeSettings()
        {
            // COMMON SEARCH
            rdoCommonReceivedOn.Checked = true;

            // SIMPLE SEARCH
            btnSimpleOneWeek.FlatStyle = FlatStyle.Flat;
            btnSimpleOneWeek.BackColor = System.Drawing.Color.LightGray;
            simpleSearch_OneWeek = true;
            chkSimpleIncludeInProcessApp.Checked = true;
            chkSimpleIncludeArchivedApp.Checked = true;
            nudSimpleBack.Value = 6;
            dtmSimpleReceivedFrom.Value = DateTime.Now.AddMonths(-6).Date;

            // CUSTOM SEARCH
            rdoCustomBetween.Checked = true;
        }

        private void FormSearchApplication_LoadCompleted(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    // COMMON SEARCH
                    cboCommonScreener.DataSource = null;
                    List<ScreenerData> allScreeners = this.GetAllScreeners();
                    if (allScreeners != null && allScreeners.Count > 0)
                    {
                        ScreenerData everyoneOption = new ScreenerData();
                        everyoneOption.ScreenerName = "Everyone";
                        allScreeners.Insert(0, everyoneOption);
                    }
                    List<ClientData> allClients = this.GetAllClients();
                    List<ReportTypeData> allReportTypes = this.GetAllReportTypes();

                    cboCommonScreener.DataSource = allScreeners;
                    cboCommonScreener.DisplayMember = "ScreenerName";
                    cboCommonScreener.ValueMember = "ScreenerId";

                    cboCommonClient.DataSource = null;
                    cboCommonClient.DataSource = allClients;
                    cboCommonClient.DisplayMember = "ClientName";
                    cboCommonClient.ValueMember = "ClientId";

                    DisableControlsCommonSearch();

                    // SIMPLE SEARCH
                    cboSimpleSearchIn.Items.Clear();
                    cboSimpleSearchIn.Items.AddRange(SimpleSearchAppData.GetAllFields().ToArray());
                    cboSimpleSearchIn.SelectedIndex = 11;

                    // CUSTOM SEARCH
                    cboCustomSearchField1.Items.Clear();
                    cboCustomSearchField2.Items.Clear();
                    cboCustomComparison1.Items.Clear();
                    cboCustomComparison2.Items.Clear();
                    lboxCustomClients.Items.Clear();
                    lboxCustomClients.ValueMember = "ClientId";
                    lboxCustomClients.DisplayMember = "ClientName";
                    ClientDisplayInfoData allClientDisplayInfo = new ClientDisplayInfoData("", "All Clients");
                    lboxCustomClients.Items.Add(allClientDisplayInfo);
                    foreach (ClientData client in allClients)
                    {
                        ClientDisplayInfoData clientInfo = new ClientDisplayInfoData(client.ClientId, client.ClientName);
                        lboxCustomClients.Items.Add(clientInfo);
                    }

                    lboxCustomReportTypes.Items.Clear();
                    lboxCustomReportTypes.ValueMember = "ReportTypeId";
                    lboxCustomReportTypes.DisplayMember = "TypeName";
                    ReportTypeData allReportTypeItem = new ReportTypeData();
                    allReportTypeItem.ReportTypeId = "";
                    allReportTypeItem.TypeName = "All Reports";
                    lboxCustomReportTypes.Items.Add(allReportTypeItem);
                    foreach (ReportTypeData rt in allReportTypes)
                    {
                        lboxCustomReportTypes.Items.Add(rt);
                    }

                    lboxCustomClients.SelectedIndex = 0;
                    lboxCustomClients.SetItemChecked(0, true);
                    lboxCustomReportTypes.SelectedIndex = 0;
                    lboxCustomReportTypes.SetItemChecked(0, true);
                    cboCustomSearchField1.Items.AddRange(SimpleSearchAppData.GetAllFields().ToArray());
                    cboCustomSearchField2.Items.AddRange(SimpleSearchAppData.GetAllFields().ToArray());
                    cboCustomSearchField1.SelectedIndex = 11; // Name
                    cboCustomSearchField2.SelectedIndex = 11; // Name

                    cboCustomComparison1.Items.Clear();
                    cboCustomComparison1.Items.AddRange(new string[] { "Contains", "Equals", "Begins With", "Ends With" });
                    cboCustomComparison1.SelectedIndex = 0;
                    cboCustomComparison1.SelectedIndex = 0;

                    cboCustomComparison2.Items.Clear();
                    cboCustomComparison2.Items.AddRange(new string[] { "Contains", "Equals", "Begins With", "Ends With" });
                    cboCustomComparison2.SelectedIndex = 0;
                    cboCustomComparison2.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        #region GENERAL
        private List<ClientData> GetAllClients()
        {
            ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
            return clientCachedApiQuery.GetAllClients();
        }

        private List<ReportTypeData> GetAllReportTypes()
        {
            ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
            return reportTypeCachedApiQuery.GetAllReportTypes();
        }
        #endregion

        #region COMMON SEARCH
        private List<ScreenerData> GetAllScreeners()
        {
            UserCachedApiQuery userCachedApiQuery = UserCachedApiQuery.Instance;
            List<ScreenerData> _screeners = new List<ScreenerData>();
            List<User> _users = userCachedApiQuery.GetAllUsers().FindAll(u => u.Status == UserStatus.Active);
            foreach (User user in _users)
            {
                ScreenerData screener = new ScreenerData();
                screener.ScreenerId = user.UserId.Id;
                screener.ScreenerName = user.UserName;
                _screeners.Add(screener);
            }
            return _screeners;
        }

        private List<string> GetWestLandInvestmentsOptions()
        {
            return new List<string>() { "Residential", "Employment" };
        }

        private void CommonSearchRadioButtons_CheckedChange(Object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                DisableControlsCommonSearch();
            }
            if (rb == rdoCommonReceivedOn && rb.Checked == true)
            {
                dtmCommonReceivedOn.Enabled = true;
                chkCommonFullAppsReceivedOn.Enabled = true;
            }
            else if (rb == rdoCommonCompletedOn && rb.Checked == true)
            {
                dtmCommonCompletedOn.Enabled = true;
                cboCommonScreener.Enabled = true;
            }
            //else if (rb == rdoCommonWestlandInvestment && rb.Checked == true)
            //{
            //    cboCommonWestland.Enabled = true;
            //}
            else if (rb == rdoCommonReceivedPastWeek && rb.Checked == true)
            {
                chkCommonFullAppsReceivedPastWeek.Enabled = true;
            }
            else if (rb == rdoCommonReceivedDuring && rb.Checked == true)
            {
                dtmCommonDuringMonth.Enabled = true;
                chkCommonFullAppsReceivedDuring.Enabled = true;
            }
            else if (rb == rdoCommonPending && rb.Checked == true)
            {
                chkCommonHighPriorities.Enabled = true;
            }
            else if (rb == rdoCommonAppFor && rdoCommonAppFor.Checked == true)
            {
                cboCommonClient.Enabled = true;
                dtmCommonReceivedFrom.Enabled = true;
                dtmCommonReceivedTo.Enabled = true;
            }
        }

        private void DisableControlsCommonSearch()
        {
            dtmCommonReceivedOn.Enabled = false;
            chkCommonFullAppsReceivedOn.Enabled = false;
            dtmCommonCompletedOn.Enabled = false;
            cboCommonScreener.Enabled = false;
            //cboCommonWestland.Enabled = false;
            chkCommonFullAppsReceivedPastWeek.Enabled = false;
            dtmCommonDuringMonth.Enabled = false;
            chkCommonFullAppsReceivedDuring.Enabled = false;
            chkCommonHighPriorities.Enabled = false;
            cboCommonClient.Enabled = false;
            dtmCommonReceivedFrom.Enabled = false;
            dtmCommonReceivedTo.Enabled = false;

            if (rdoCommonReceivedOn.Checked)
            {
                dtmCommonReceivedOn.Enabled = true;
                chkCommonFullAppsReceivedOn.Enabled = true;
            }
            else if (rdoCommonCompletedOn.Checked)
            {
                dtmCommonCompletedOn.Enabled = true;
                cboCommonScreener.Enabled = true;
            }
            //else if (rdoCommonWestlandInvestment.Checked)
            //{
            //    cboCommonWestland.Enabled = true;
            //}
            else if (rdoCommonReceivedPastWeek.Checked)
            {
                chkCommonFullAppsReceivedPastWeek.Enabled = true;
            }
            else if (rdoCommonReceivedDuring.Checked)
            {
                dtmCommonDuringMonth.Enabled = true;
                chkCommonFullAppsReceivedDuring.Enabled = true;
            }
            else if (rdoCommonPending.Checked)
            {
                chkCommonHighPriorities.Enabled = true;
            }
            else if (rdoCommonAppFor.Checked)
            {
                cboCommonClient.Enabled = true;
                dtmCommonReceivedFrom.Enabled = true;
                dtmCommonReceivedTo.Enabled = true;
            }
        }

        private void cboCommonClient_DropDown(object sender, EventArgs e)
        {
            //ComboBox cmb = sender as ComboBox;
            //cmb.AutoCompleteMode = AutoCompleteMode.None;
            //cmb.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cboCommonClient_DropDownClosed(object sender, EventArgs e)
        {
            //ComboBox cmb = sender as ComboBox;
            //cmb.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public SearchAppCommand GetSearchCommand()
        {
            ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
            ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;

            SearchAppCommand command = new SearchAppCommand();
            RadioButton rb = tabPageCommon.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (rb == null)
            {
                return null;
            }
            if (rb == rdoCommonReceivedOn && rb.Checked == true)
            {
                DateTime startOfDate = dtmCommonReceivedOn.Value.Date;
                DateTime endOfDate = dtmCommonReceivedOn.Value.Date.AddDays(1).AddSeconds(-5);
                command.ReceivedDateFrom = startOfDate.ToUniversalTime();
                command.ReceivedDateTo = endOfDate.ToUniversalTime();
                command.IsFullAppOnly = chkCommonFullAppsReceivedOn.Checked;
            }
            else if (rb == rdoCommonCompletedOn && rb.Checked == true)
            {
                DateTime startOfDate = dtmCommonCompletedOn.Value.Date;
                DateTime endOfDate = dtmCommonCompletedOn.Value.Date.AddDays(1).AddSeconds(-5);
                command.CompletedDateFrom = startOfDate.ToUniversalTime();
                command.CompletedDateTo = endOfDate.ToUniversalTime();
                command.ScreenerId = (cboCommonScreener.SelectedItem as ScreenerData).ScreenerId;
            }
            //else if (rb == rdoCommonWestlandInvestment && rb.Checked == true)
            //{
            //    ClientData client = clientCachedApiQuery.GetAllClients().Find(c => c.ClientName.Contains("Westland"));
            //    if (client == null)
            //    {
            //        return command;
            //    }
            //    string westlandClientId = client.ClientId;
            //    if (!string.IsNullOrEmpty(westlandClientId))
            //    {
            //        command.ClientIds.Add(westlandClientId);
            //    }
            //    DateTime now = DateTime.Now;
            //    int delta = now.DayOfWeek - DayOfWeek.Sunday;
            //    if (delta < 0)
            //    {
            //        delta += 7;
            //    }
            //    DateTime startOfPastWeek = now.AddDays(-1 * delta).Date;
            //    command.ReceivedDateFrom = startOfPastWeek.ToUniversalTime();
            //    command.ReceivedDateTo = now.ToUniversalTime();
            //}
            else if (rb == rdoCommonReceivedPastWeek && rb.Checked == true)
            {
                DateTime now = DateTime.Now;
                int delta = now.DayOfWeek - DayOfWeek.Sunday;
                if (delta < 0)
                {
                    delta += 7;
                }
                DateTime startOfPastWeek = now.AddDays(-1 * delta).Date;
                command.ReceivedDateFrom = startOfPastWeek.ToUniversalTime();
                command.ReceivedDateTo = now.ToUniversalTime();
                command.IsFullAppOnly = chkCommonFullAppsReceivedPastWeek.Checked;
            }
            else if (rb == rdoCommonReceivedDuring && rb.Checked == true)
            {
                DateTime selectedMonth = dtmCommonDuringMonth.Value;
                DateTime firstDayOfMonth = new DateTime(selectedMonth.Year, selectedMonth.Month, 1).Date;
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1).Date.AddDays(1).AddSeconds(-5);
                command.ReceivedDateFrom = firstDayOfMonth.ToUniversalTime();
                command.ReceivedDateTo = lastDayOfMonth.ToUniversalTime();
                command.IsFullAppOnly = chkCommonFullAppsReceivedDuring.Checked;
            }
            else if (rb == rdoCommonPending && rb.Checked == true)
            {
                command.Status = SearchAppCommand.AppStatus.InProcess;
                if (chkCommonHighPriorities.Checked)
                {
                    command.Priorities.AddRange(new List<int>() { 2, 3 });
                }
            }
            else if (rb == rdoCommonAppFor && rdoCommonAppFor.Checked == true)
            {
                if (!string.IsNullOrWhiteSpace(cboCommonClient.Text))
                {
                    ClientData client = cboCommonClient.SelectedItem as ClientData;
                    if (client != null && !string.IsNullOrEmpty(client.ClientId))
                    {
                        command.ClientIds.Add(client.ClientId);
                    }
                }
                command.ReceivedDateFrom = dtmCommonReceivedFrom.Value.Date.ToUniversalTime();
                command.ReceivedDateTo = dtmCommonReceivedTo.Value.Date.AddDays(1).AddSeconds(-5).ToUniversalTime();
            }
            return command;
        }

        private void cboCommonClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(cboCommonClient, e, false);
        }
        #endregion

        #region SIMPLE SEARCH
        private void btnSimpleOneWeekAndOneMonth_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                btnSimpleOneWeek.FlatStyle = FlatStyle.Standard;
                btnSimpleOneWeek.BackColor = System.Drawing.Color.White;
                btnSimpleOneMonth.FlatStyle = FlatStyle.Standard;
                btnSimpleOneMonth.BackColor = System.Drawing.Color.White;
                this.simpleSearch_OneWeek = false;
                this.simpleSearch_OneMonth = false;
                rdoSimpleBack.Checked = false;
                rdoSimpleReceivedBetween.Checked = false;
                nudSimpleBack.Enabled = false;
                dtmSimpleReceivedFrom.Enabled = false;
                dtmSimpleReceivedTo.Enabled = false;
            }
            if (button == btnSimpleOneWeek)
            {
                btnSimpleOneWeek.FlatStyle = FlatStyle.Flat;
                btnSimpleOneWeek.BackColor = System.Drawing.Color.LightGray;
                this.simpleSearch_OneWeek = true;
            }
            else if (button == btnSimpleOneMonth)
            {
                btnSimpleOneMonth.FlatStyle = FlatStyle.Flat;
                btnSimpleOneMonth.BackColor = System.Drawing.Color.LightGray;
                this.simpleSearch_OneMonth = true;
            }
        }

        private void rdoSimpleBackAndReceivedBetween_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                btnSimpleOneWeek.FlatStyle = FlatStyle.Standard;
                btnSimpleOneWeek.BackColor = System.Drawing.Color.White;
                btnSimpleOneMonth.FlatStyle = FlatStyle.Standard;
                btnSimpleOneMonth.BackColor = System.Drawing.Color.White;
                this.simpleSearch_OneWeek = false;
                this.simpleSearch_OneMonth = false;
                nudSimpleBack.Enabled = false;
                dtmSimpleReceivedFrom.Enabled = false;
                dtmSimpleReceivedTo.Enabled = false;
            }
            if (radioButton == rdoSimpleBack)
            {
                nudSimpleBack.Enabled = true;
            }
            else if (radioButton == rdoSimpleReceivedBetween)
            {
                dtmSimpleReceivedFrom.Enabled = true;
                dtmSimpleReceivedTo.Enabled = true;
            }
        }

        public SimpleSearchAppCommand GetSimpleSearchCommand()
        {
            SimpleSearchAppCommand command = new SimpleSearchAppCommand();

            DateTime now = DateTime.Now;
            DateTime receivedFrom;
            DateTime receivedTo;
            if (this.simpleSearch_OneWeek)
            {
                //int delta = now.DayOfWeek - DayOfWeek.Sunday;
                //if (delta < 0)
                //{
                //    delta += 7;
                //}
                //DateTime startOfPastWeek = now.AddDays(-1 * delta).Date;
                //receivedFrom = startOfPastWeek.ToUniversalTime();
                //receivedTo = now.ToUniversalTime();
                receivedFrom = now.AddDays(-7).ToUniversalTime();
                receivedTo = now.ToUniversalTime();
            }
            else if (this.simpleSearch_OneMonth)
            {
                //receivedFrom = now.AddMonths(-1).ToUniversalTime();
                receivedFrom = now.AddDays(-31).ToUniversalTime();
                receivedTo = now.ToUniversalTime();
            }
            else if (rdoSimpleBack.Checked)
            {
                int months = int.Parse(nudSimpleBack.Value.ToString());
                receivedFrom = now.AddMonths(-months).ToUniversalTime();
                receivedTo = now.ToUniversalTime();
            }
            else // rdoSimpleReceivedBetween.Checked
            {
                receivedFrom = dtmSimpleReceivedFrom.Value.Date.ToUniversalTime();
                receivedTo = dtmSimpleReceivedTo.Value.Date.AddDays(1).AddSeconds(-5).ToUniversalTime();
            }
            command.ReceivedFrom = receivedFrom;
            command.ReceivedTo = receivedTo;

            command.IncludeInProcess = chkSimpleIncludeInProcessApp.Checked;
            command.IncludeArchived = chkSimpleIncludeArchivedApp.Checked;

            command.SearchIn = cboSimpleSearchIn.Text.Trim();
            if (command.SearchIn.Equals("Priority"))
            {
                PriorityAppData priority = this.cboSimpleKeyword.SelectedItem as PriorityAppData;
                if (priority != null)
                {
                    command.Keyword = priority.Value.ToString();
                }
                else
                {
                    command.Keyword = txtSimpleKeyword.Text.Trim();
                }
            }
            else
            {
                command.Keyword = txtSimpleKeyword.Text.Trim();
            }

            return command;
        }

        private void cboSimpleSearchIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboSimpleKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(cboSimpleKeyword, e, false);
        }

        private void cboSimpleKeyword_TextChanged(object sender, EventArgs e)
        {
            txtSimpleKeyword.Text = cboSimpleKeyword.Text;
        }

        private void cboSimpleSearchIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboSimpleSearchIn.Text)
                {
                    case "Client Name":
                        using (new HourGlass())
                        {
                            cboSimpleKeyword.Items.Clear();
                            List<ClientData> clients = this.GetAllClients();
                            cboSimpleKeyword.ValueMember = "ClientId";
                            cboSimpleKeyword.DisplayMember = "ClientName";
                            foreach (ClientData client in clients)
                            {
                                cboSimpleKeyword.Items.Add(client);
                            }
                            cboSimpleKeyword.BringToFront();
                        }
                        break;
                    case "Priority":
                        using (new HourGlass())
                        {
                            cboSimpleKeyword.Items.Clear();
                            IEnumerable<PriorityApp> priorities = PriorityApp.GetAll<PriorityApp>();
                            cboSimpleKeyword.ValueMember = "Value";
                            cboSimpleKeyword.DisplayMember = "DisplayName";
                            foreach (PriorityApp priorityApp in priorities)
                            {
                                cboSimpleKeyword.Items.Add(new PriorityAppData(priorityApp.Value, priorityApp.DisplayName));
                            }
                            cboSimpleKeyword.BringToFront();
                        }
                        break;
                    case "Report Type":
                        using (new HourGlass())
                        {
                            cboSimpleKeyword.Items.Clear();
                            List<ReportTypeData> reportTypes = this.GetAllReportTypes();
                            cboSimpleKeyword.ValueMember = "ReportTypeId";
                            cboSimpleKeyword.DisplayMember = "TypeName";
                            foreach (ReportTypeData reportType in reportTypes)
                            {
                                cboSimpleKeyword.Items.Add(reportType);
                            }
                            cboSimpleKeyword.BringToFront();
                        }
                        break;
                    case "Screener":
                        using (new HourGlass())
                        {
                            cboSimpleKeyword.Items.Clear();
                            List<ScreenerData> screeners = this.GetAllScreeners();
                            cboSimpleKeyword.ValueMember = "ScreenerId";
                            cboSimpleKeyword.DisplayMember = "ScreenerName";
                            foreach (ScreenerData screener in screeners)
                            {
                                cboSimpleKeyword.Items.Add(screener);
                            }
                            cboSimpleKeyword.BringToFront();
                        }
                        break;
                    default:
                        txtSimpleKeyword.BringToFront();
                        break;
                }
                cboSimpleKeyword.Text = txtSimpleKeyword.Text;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region CUSTOM SEARCH
        private void rdoCustomFromAllDates_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (sender) as RadioButton;
            if (button.Checked == true)
            {
                rdoCustomReceived.Enabled = false;
                rdoCustomCompleted.Enabled = false;
                dtmCustomFrom.Enabled = false;
                dtmCustomTo.Enabled = false;
            }
        }

        private void rdoCustomBetween_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (sender) as RadioButton;
            if (button.Checked == true)
            {
                rdoCustomReceived.Enabled = true;
                rdoCustomCompleted.Enabled = true;
                dtmCustomFrom.Enabled = true;
                dtmCustomTo.Enabled = true;
            }
        }

        public SearchAppCommand GetCustomSearchCommand()
        {
            SearchAppCommand command = new SearchAppCommand();

            if (rdoCustomFromAllDates.Checked == true)
            {
                command.ReceivedDateFrom = null;
                command.ReceivedDateTo = null;
                command.CompletedDateFrom = null;
                command.CompletedDateTo = null;
            }
            else
            {
                DateTime startOfDate = dtmCustomFrom.Value.Date.ToUniversalTime();
                DateTime endOfDate = dtmCustomTo.Value.Date.AddDays(1).AddSeconds(-50).ToUniversalTime();

                if (rdoCustomReceived.Checked == true)
                {
                    command.ReceivedDateFrom = startOfDate;
                    command.ReceivedDateTo = endOfDate;
                }
                else
                {
                    command.CompletedDateFrom = startOfDate;
                    command.CompletedDateTo = endOfDate;
                }
            }

            if (lboxCustomClients.GetItemCheckState(0) == CheckState.Unchecked)
            {
                foreach (int indexChecked in lboxCustomClients.CheckedIndices)
                {
                    if (indexChecked == 0)
                        continue;
                    ClientDisplayInfoData client = lboxCustomClients.Items[indexChecked] as ClientDisplayInfoData;
                    if (client != null)
                    {
                        command.ClientIds.Add(client.ClientId);
                    }
                }
            }

            if (lboxCustomReportTypes.GetItemCheckState(0) == CheckState.Unchecked)
            {
                foreach (int indexChecked in lboxCustomReportTypes.CheckedIndices)
                {
                    if (indexChecked == 0)
                        continue;
                    ReportTypeData rt = lboxCustomReportTypes.Items[indexChecked] as ReportTypeData;
                    if (rt != null)
                    {
                        command.ReportIds.Add(rt.ReportTypeId);
                    }
                }
            }

            if (chkCustomInProcess.Checked == true && chkCustomArchive.Checked == true)
            {
                command.Status = SearchAppCommand.AppStatus.All;
            }
            else if (chkCustomInProcess.Checked == true)
            {
                command.Status = SearchAppCommand.AppStatus.InProcess;
            }
            else if (chkCustomArchive.Checked == true)
            {
                command.Status = SearchAppCommand.AppStatus.Archive;
            }
            else
            {
                command.Status = SearchAppCommand.AppStatus.SpecificLocations;
            }

            if (!string.IsNullOrEmpty(txtCustomKeyword1.Text) && !string.IsNullOrEmpty(cboCustomSearchField1.Text))
            {
                command.KeywordOption1 = new SearchKeywordOptionData(txtCustomKeyword1.Text, cboCustomSearchField1.Text, cboCustomComparison1.Text);
            }

            if (!string.IsNullOrEmpty(txtCustomKeyword2.Text) && !string.IsNullOrEmpty(cboCustomSearchField2.Text))
            {
                command.KeywordOption2 = new SearchKeywordOptionData(txtCustomKeyword2.Text, cboCustomSearchField2.Text, cboCustomComparison2.Text);
            }

            if (rdoCustomAND.Checked == true)
            {
                command.JoinBetweenKeywords = "and";
            }
            else
            {
                command.JoinBetweenKeywords = "or";
            }

            command.IsFullAppOnly = false;

            return command;
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lboxCustomClients_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHandlerHelper.CheckedListBoxSearch_KeyPress(sender, e);
        }
    }
}
