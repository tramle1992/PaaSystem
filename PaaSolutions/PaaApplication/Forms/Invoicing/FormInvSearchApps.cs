using Common.Infrastructure.ComboBoxCustom;
using Common.Infrastructure.UI;
using Core.Application.Command.ExploreApps;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using Core.Domain.Model.ExploreApps;
using Core.Infrastructure.ClientInfo;
using Core.Infrastructure.ExploreApps;
using IdentityAccess.CommonType;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Infrastructure.Identity;
using Invoice.Application.Command;
using Invoice.Application.Data;
using Invoice.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaaApplication.Helper;

namespace PaaApplication.Forms.Invoicing
{
    public partial class FormInvSearchApps : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private InvoiceApiRepository invoiceApiRepository = new InvoiceApiRepository();
        private AppApiRepository appApiRepository = new AppApiRepository();

        private FormBillingManager formBillingManager;

        public event EventHandler<List<AppData>> OnSearchApps;

        public FormInvSearchApps(FormBillingManager formBillingManager)
        {
            InitializeComponent();
            this.formBillingManager = formBillingManager;
        }

        private void FormSearchApps_LoadCompleted(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                try
                {
                    LoadControlValues();

                    LoadClientsCheckedListBox();
                    LoadReportTypesCheckedListBox();
                    LoadComboBoxSearchIn();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void LoadControlValues()
        {
            try
            {
                DateTime currentBillingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
                this.rdoAppsReceivedMonth.Text = currentBillingMonth.ToString("MM/yyyy");
                DateTime minDate = new DateTime(currentBillingMonth.Year, currentBillingMonth.Month, 1).Date;
                DateTime maxDate = minDate.AddMonths(1).AddSeconds(-5);
                if (minDate > this.dtmAppsReceivedFrom.MaxDate)
                {
                    this.dtmAppsReceivedFrom.MaxDate = maxDate;
                    this.dtmAppsReceivedFrom.MinDate = minDate;
                    this.dtmAppsReceivedTo.MaxDate = maxDate;
                    this.dtmAppsReceivedTo.MinDate = minDate;
                }
                else
                {
                    this.dtmAppsReceivedFrom.MinDate = minDate;
                    this.dtmAppsReceivedFrom.MaxDate = maxDate;
                    this.dtmAppsReceivedTo.MinDate = minDate;
                    this.dtmAppsReceivedTo.MaxDate = maxDate;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void LoadClientsCheckedListBox()
        {
            try
            {
                this.lboxClients.Items.Clear();
                this.lboxClients.ValueMember = "ClientId";
                this.lboxClients.DisplayMember = "ClientName";

                List<ClientData> clients = this.formBillingManager.formMaster.LIST_CLIENTS;
                if (clients != null && clients.Count > 0)
                {
                    ClientData allClients = new ClientData();
                    allClients.ClientId = "-1";
                    allClients.ClientName = "All Clients";
                    this.lboxClients.Items.Add(allClients);

                    foreach (ClientData client in clients)
                    {
                        this.lboxClients.Items.Add(client, false);
                    }

                    this.lboxClients.SetItemChecked(0, true);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void LoadReportTypesCheckedListBox()
        {
            try
            {
                this.lboxReportTypes.Items.Clear();
                this.lboxReportTypes.ValueMember = "ReportTypeId";
                this.lboxReportTypes.DisplayMember = "TypeName";

                List<ReportTypeData> reportTypes = this.formBillingManager.formMaster.LIST_REPORT_TYPES;
                if (reportTypes != null && reportTypes.Count > 0)
                {
                    ReportTypeData allTypes = new ReportTypeData();
                    allTypes.ReportTypeId = "-1";
                    allTypes.TypeName = "All Types";
                    this.lboxReportTypes.Items.Add(allTypes);

                    foreach (ReportTypeData reportType in reportTypes)
                    {
                        this.lboxReportTypes.Items.Add(reportType, false);
                    }

                    this.lboxReportTypes.SetItemChecked(0, true);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void LoadComboBoxSearchIn()
        {
            this.cboSearchIn.Items.Clear();
            this.cboSearchIn.Items.AddRange(InvSearchAppData.GetAllFields().ToArray());
            this.cboSearchIn.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                InvSearchAppCommand command = GetSearchAppCommand();
                List<AppData> apps = appApiRepository.InvSearchApp(command);
                List<AppData> exactApps = GetExact(command, apps);
                if (this.OnSearchApps != null)
                {
                    this.OnSearchApps(this, exactApps);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rdoAppsReceived_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == this.rdoAppsReceivedMonth && rb.Checked)
            {
                this.dtmAppsReceivedFrom.Enabled = false;
                this.dtmAppsReceivedTo.Enabled = false;
            }
            else if (rb == this.rdoAppsReceivedBetween && rb.Checked)
            {
                this.dtmAppsReceivedFrom.Enabled = true;
                this.dtmAppsReceivedTo.Enabled = true;
            }
        }

        private InvSearchAppCommand GetSearchAppCommand()
        {
            InvSearchAppCommand command = new InvSearchAppCommand();
            DateTime receivedFrom;
            DateTime receivedTo;
            if (this.rdoAppsReceivedMonth.Checked)
            {
                DateTime date;
                if (DateTime.TryParse(this.rdoAppsReceivedMonth.Text, out date))
                {
                    receivedFrom = new DateTime(date.Year, date.Month, 1).Date;
                    receivedTo = receivedFrom.AddMonths(1).AddSeconds(-5);
                }
                else
                {
                    DateTime currentBillingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
                    receivedFrom = new DateTime(currentBillingMonth.Year, currentBillingMonth.Month, 1).Date;
                    receivedTo = receivedFrom.AddMonths(1).AddSeconds(-5);
                }
            }
            else // rdoAppsReceivedBetween.Checked
            {
                DateTime dateFrom = this.dtmAppsReceivedFrom.Value;
                DateTime dateTo = this.dtmAppsReceivedTo.Value;
                receivedFrom = dateFrom.Date;
                receivedTo = dateTo.Date.AddDays(1).AddSeconds(-5);
            }
            command.ReceivedFrom = receivedFrom.ToUniversalTime();
            command.ReceivedTo = receivedTo.ToUniversalTime();

            if (this.rdoClientsAND.Checked)
            {
                command.ClientsOperator = true;
            }
            else
            {
                command.ClientsOperator = false;
            }

            HashSet<string> clientNames = new HashSet<string>();
            if (this.lboxClients.Items.Count > 0 &&
                this.lboxClients.CheckedItems.Count > 0 && !this.lboxClients.GetItemChecked(0))
            {
                foreach (ClientData client in this.lboxClients.CheckedItems)
                {
                    if (!string.IsNullOrEmpty(client.ClientName))
                    {
                        clientNames.Add(client.ClientName);
                    }
                }
            }
            command.ClientNames = clientNames.ToList<string>();

            if (this.rdoReportTypesAND.Checked)
            {
                command.ReportTypesOperator = true;
            }
            else
            {
                command.ReportTypesOperator = false;
            }

            HashSet<string> reportTypeNames = new HashSet<string>();
            if (this.lboxReportTypes.Items.Count > 0 &&
                this.lboxReportTypes.CheckedItems.Count > 0 && !this.lboxReportTypes.GetItemChecked(0))
            {
                foreach (ReportTypeData reportType in this.lboxReportTypes.CheckedItems)
                {
                    if (!string.IsNullOrEmpty(reportType.TypeName))
                    {
                        reportTypeNames.Add(reportType.TypeName);
                    }
                }
            }
            command.ReportTypeNames = reportTypeNames.ToList<string>();

            command.SearchIn = this.cboSearchIn.Text.Trim();
            if (command.SearchIn.Equals("Priority"))
            {
                PriorityAppData priority = this.cboKeyword.SelectedItem as PriorityAppData;
                if (priority != null)
                {
                    command.Keyword = priority.Value.ToString();
                }
                else
                {
                    command.Keyword = this.txtKeyword.Text.Trim();
                }
            }
            else
            {
                command.Keyword = this.txtKeyword.Text.Trim();
            }

            return command;
        }

        private List<AppData> GetExact(InvSearchAppCommand command, List<AppData> apps)
        {
            if (apps == null || apps.Count == 0)
            {
                return null;
            }

            string keyword = command.Keyword;
            if (string.IsNullOrEmpty(keyword))
            {
                return apps;
            }

            List<AppData> exactApps = new List<AppData>(apps.Count);
            string columnName = SimpleSearchAppData.GetColumnNameByFieldName(command.SearchIn);

            try
            {
                if (columnName.Equals("all_fields"))
                {
                    exactApps = (from application in apps
                                 where application != null &&
                                        ((application.StreetAddress ?? string.Empty).Contains(keyword) ||
                                            (application.ClientAppliedName ?? string.Empty).Contains(keyword) ||
                                            ((application.FinalComments ?? string.Empty).Contains(keyword) ||
                                                (application.StaffComments ?? string.Empty).Contains(keyword)) ||
                                            ((application.LastName ?? string.Empty).Contains(keyword) ||
                                                (application.FirstName ?? string.Empty).Contains(keyword) ||
                                                (application.MiddleName ?? string.Empty).Contains(keyword)) ||
                                            (application.Priority != null && application.Priority.Value.ToString().Equals(keyword)) ||
                                            (application.ReportManagement ?? string.Empty).Contains(keyword) ||
                                            (application.ReportTypeName ?? string.Empty).Contains(keyword) ||
                                            (application.ScreenerName ?? string.Empty).Contains(keyword) ||
                                            ((application.AppSSN ?? string.Empty).Contains(keyword) ||
                                                (application.BirthDate.HasValue &&
                                                    application.BirthDate.Value.ToString("MM/dd/yyyy").Contains(keyword))) ||
                                            (application.ReportSpecialField ?? string.Empty).ToLower().Contains(keyword) ||
                                            (application.ContactAttempts != null &&
                                             application.ContactAttempts.Any(contactAttempt => (contactAttempt != null) &&
                                                                                                ((contactAttempt.ContactAttemptType != null &&
                                                                                                    (contactAttempt.ContactAttemptType.DisplayName ?? string.Empty).Contains(keyword)) ||
                                                                                                    (contactAttempt.Note ?? string.Empty).Contains(keyword) ||
                                                                                                    (contactAttempt.PhoneFaxEmail ?? string.Empty).Contains(keyword) ||
                                                                                                    (contactAttempt.Recipient ?? string.Empty).Contains(keyword)))) ||
                                            (application.CreditInfo != null &&
                                             (application.CreditInfo.ChildSupport.ToString().Equals(keyword) ||
                                                    application.CreditInfo.Collections.ToString().Equals(keyword) ||
                                                    application.CreditInfo.CreditHistoryBankrupted.ToString().Equals(keyword) ||
                                                    application.CreditInfo.CreditMatched.ToString().Equals(keyword) ||
                                                    (application.CreditInfo.CreditPreface ?? string.Empty).Contains(keyword) ||
                                                    application.CreditInfo.CreditReportObtained.ToString().Equals(keyword) ||
                                                    (application.CreditInfo.Dates ?? string.Empty).Contains(keyword) ||
                                                    application.CreditInfo.Judgements.ToString().Equals(keyword) ||
                                                    application.CreditInfo.Liens.ToString().Equals(keyword) ||
                                                    application.CreditInfo.PastDueAmounts.ToString().Equals(keyword) ||
                                                    application.CreditInfo.PositiveCreditSince.ToString().Equals(keyword) ||
                                                    application.CreditInfo.Rent.ToString().Equals(keyword))) ||
                                            (application.CreditRefs != null &&
                                             application.CreditRefs.Any(creditRef => (creditRef != null) &&
                                                                                        ((creditRef.Balance ?? string.Empty).Contains(keyword) ||
                                                                                            (creditRef.Company ?? string.Empty).Contains(keyword) ||
                                                                                            (creditRef.HighBalance ?? string.Empty).Contains(keyword) ||
                                                                                            (creditRef.Opened ?? string.Empty).Contains(keyword) ||
                                                                                            (creditRef.PayHabits ?? string.Empty).Contains(keyword) ||
                                                                                            (creditRef.Phone ?? string.Empty).Contains(keyword) ||
                                                                                            (creditRef.Rating ?? string.Empty).Contains(keyword) ||
                                                                                            (creditRef.SW ?? string.Empty).Contains(keyword) ||
                                                                                            (creditRef.Terms ?? string.Empty).Contains(keyword)))) ||
                                            (application.Charges != null &&
                                             application.Charges.Any(charge => (charge != null) &&
                                                                                ((charge.Charge ?? string.Empty).Contains(keyword) ||
                                                                                    (charge.County ?? string.Empty).Contains(keyword) ||
                                                                                    (charge.Date ?? string.Empty).Contains(keyword) ||
                                                                                    (charge.Heading ?? string.Empty).Contains(keyword) ||
                                                                                    (charge.Sentence ?? string.Empty).Contains(keyword) ||
                                                                                    (charge.State ?? string.Empty).Contains(keyword)))) ||
                                            (application.EmpRefs != null &&
                                             application.EmpRefs.Any(empRef => (empRef != null) &&
                                                                                ((empRef.Comment ?? string.Empty).Contains(keyword) ||
                                                                                    (empRef.FullTime ?? string.Empty).Contains(keyword) ||
                                                                                    (empRef.Hired ?? string.Empty).Contains(keyword) ||
                                                                                    (empRef.Info ?? string.Empty).Contains(keyword) ||
                                                                                    (empRef.Pos ?? string.Empty).Contains(keyword) ||
                                                                                    (empRef.RH ?? string.Empty).Contains(keyword) ||
                                                                                    (empRef.Salary ?? string.Empty).Contains(keyword) ||
                                                                                    (empRef.SW ?? string.Empty).Contains(keyword) ||
                                                                                    (empRef.Termination ?? string.Empty).Contains(keyword)))) ||
                                            (application.EmpVer != null &&
                                             ((application.EmpVer.Co ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Co2 ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.FullTime ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.FullTime2 ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Heading ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Heading2 ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Hire ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Hire2 ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.MiscComment ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Pos ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Pos2 ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Salary ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Salary2 ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.SW ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.SW2 ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Tele ?? string.Empty).Contains(keyword) ||
                                                    (application.EmpVer.Tele2 ?? string.Empty).Contains(keyword))) ||
                                            (application.Evictions != null &&
                                             application.Evictions.Any(eviction => (eviction != null) &&
                                                                                    ((eviction.County ?? string.Empty).Contains(keyword) ||
                                                                                        (eviction.Date ?? string.Empty).Contains(keyword) ||
                                                                                        (eviction.Heading ?? string.Empty).Contains(keyword) ||
                                                                                        (eviction.Owners ?? string.Empty).Contains(keyword) ||
                                                                                        (eviction.State ?? string.Empty).Contains(keyword)))) ||
                                            (application.RentalRefs != null &&
                                             application.RentalRefs.Any(rentalRef => (rentalRef != null) &&
                                                                                        (rentalRef.AddressMatch.ToString().Contains(keyword) ||
                                                                                            rentalRef.Complaints.ToString().Contains(keyword) ||
                                                                                            rentalRef.Damages.ToString().Contains(keyword) ||
                                                                                            rentalRef.KickedOut.ToString().Contains(keyword) ||
                                                                                            rentalRef.LateNSF.ToString().Contains(keyword) ||
                                                                                            rentalRef.Owing.ToString().Contains(keyword) ||
                                                                                            rentalRef.Pets.ToString().Contains(keyword) ||
                                                                                            rentalRef.PrprNotice.ToString().Contains(keyword) ||
                                                                                            rentalRef.ReRent.ToString().Contains(keyword) ||
                                                                                            rentalRef.RltveFrnd.ToString().Contains(keyword) ||
                                                                                            rentalRef.Roommates.ToString().Contains(keyword) ||
                                                                                            rentalRef.Written.ToString().Contains(keyword) ||
                                                                                            (rentalRef.MoveIn ?? string.Empty).Contains(keyword) ||
                                                                                            (rentalRef.MoveOut ?? string.Empty).Contains(keyword) ||
                                                                                            (rentalRef.Amount ?? string.Empty).Contains(keyword) ||
                                                                                            (rentalRef.SW ?? string.Empty).Contains(keyword) ||
                                                                                            (rentalRef.Comp ?? string.Empty).Contains(keyword) ||
                                                                                            (rentalRef.Phone ?? string.Empty).Contains(keyword) ||
                                                                                            (rentalRef.Comment ?? string.Empty).Contains(keyword)))))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("contact_attempt"))
                {
                    exactApps = (from application in apps
                                 where application.ContactAttempts != null &&
                                 application.ContactAttempts.Any(contactAttempt => (contactAttempt != null) &&
                                                                                    ((contactAttempt.ContactAttemptType != null &&
                                                                                        (contactAttempt.ContactAttemptType.DisplayName ?? string.Empty).Contains(keyword)) ||
                                                                                        (contactAttempt.Note ?? string.Empty).Contains(keyword) ||
                                                                                        (contactAttempt.PhoneFaxEmail ?? string.Empty).Contains(keyword) ||
                                                                                        (contactAttempt.Recipient ?? string.Empty).Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("credit_info"))
                {
                    exactApps = (from application in apps
                                 where application.CreditInfo != null &&
                                 (application.CreditInfo.ChildSupport.ToString().Equals(keyword) ||
                                        application.CreditInfo.Collections.ToString().Equals(keyword) ||
                                        application.CreditInfo.CreditHistoryBankrupted.ToString().Equals(keyword) ||
                                        application.CreditInfo.CreditMatched.ToString().Equals(keyword) ||
                                        (application.CreditInfo.CreditPreface ?? string.Empty).Contains(keyword) ||
                                        application.CreditInfo.CreditReportObtained.ToString().Equals(keyword) ||
                                        (application.CreditInfo.Dates ?? string.Empty).Contains(keyword) ||
                                        application.CreditInfo.Judgements.ToString().Equals(keyword) ||
                                        application.CreditInfo.Liens.ToString().Equals(keyword) ||
                                        application.CreditInfo.PastDueAmounts.ToString().Equals(keyword) ||
                                        application.CreditInfo.PositiveCreditSince.ToString().Equals(keyword) ||
                                        application.CreditInfo.Rent.ToString().Equals(keyword))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("credit_refs"))
                {
                    exactApps = (from application in apps
                                 where application.CreditRefs != null &&
                                 application.CreditRefs.Any(creditRef => (creditRef != null) &&
                                                                            ((creditRef.Balance ?? string.Empty).Contains(keyword) ||
                                                                                (creditRef.Company ?? string.Empty).Contains(keyword) ||
                                                                                (creditRef.HighBalance ?? string.Empty).Contains(keyword) ||
                                                                                (creditRef.Opened ?? string.Empty).Contains(keyword) ||
                                                                                (creditRef.PayHabits ?? string.Empty).Contains(keyword) ||
                                                                                (creditRef.Phone ?? string.Empty).Contains(keyword) ||
                                                                                (creditRef.Rating ?? string.Empty).Contains(keyword) ||
                                                                                (creditRef.SW ?? string.Empty).Contains(keyword) ||
                                                                                (creditRef.Terms ?? string.Empty).Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("charges"))
                {
                    exactApps = (from application in apps
                                 where application.Charges != null &&
                                 application.Charges.Any(charge => (charge != null) &&
                                                                    ((charge.Charge ?? string.Empty).Contains(keyword) ||
                                                                        (charge.County ?? string.Empty).Contains(keyword) ||
                                                                        (charge.Date ?? string.Empty).Contains(keyword) ||
                                                                        (charge.Heading ?? string.Empty).Contains(keyword) ||
                                                                        (charge.Sentence ?? string.Empty).Contains(keyword) ||
                                                                        (charge.State ?? string.Empty).Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("emp_refs"))
                {
                    exactApps = (from application in apps
                                 where application.EmpRefs != null &&
                                 application.EmpRefs.Any(empRef => (empRef != null) &&
                                                                    ((empRef.Comment ?? string.Empty).Contains(keyword) ||
                                                                        (empRef.FullTime ?? string.Empty).Contains(keyword) ||
                                                                        (empRef.Hired ?? string.Empty).Contains(keyword) ||
                                                                        (empRef.Info ?? string.Empty).Contains(keyword) ||
                                                                        (empRef.Pos ?? string.Empty).Contains(keyword) ||
                                                                        (empRef.RH ?? string.Empty).Contains(keyword) ||
                                                                        (empRef.Salary ?? string.Empty).Contains(keyword) ||
                                                                        (empRef.SW ?? string.Empty).Contains(keyword) ||
                                                                        (empRef.Termination ?? string.Empty).Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("emp_ver"))
                {
                    exactApps = (from application in apps
                                 where application.EmpVer != null &&
                                 ((application.EmpVer.Co ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Co2 ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.FullTime ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.FullTime2 ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Heading ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Heading2 ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Hire ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Hire2 ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.MiscComment ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Pos ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Pos2 ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Salary ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Salary2 ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.SW ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.SW2 ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Tele ?? string.Empty).Contains(keyword) ||
                                        (application.EmpVer.Tele2 ?? string.Empty).Contains(keyword))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("evictions"))
                {
                    exactApps = (from application in apps
                                 where application.Evictions != null &&
                                 application.Evictions.Any(eviction => (eviction != null) &&
                                                                        ((eviction.County ?? string.Empty).Contains(keyword) ||
                                                                            (eviction.Date ?? string.Empty).Contains(keyword) ||
                                                                            (eviction.Heading ?? string.Empty).Contains(keyword) ||
                                                                            (eviction.Owners ?? string.Empty).Contains(keyword) ||
                                                                            (eviction.State ?? string.Empty).Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else if (columnName.Equals("rental_refs"))
                {
                    exactApps = (from application in apps
                                 where application.RentalRefs != null &&
                                 application.RentalRefs.Any(rentalRef => (rentalRef != null) &&
                                                                            (rentalRef.AddressMatch.ToString().Contains(keyword) ||
                                                                                rentalRef.Complaints.ToString().Contains(keyword) ||
                                                                                rentalRef.Damages.ToString().Contains(keyword) ||
                                                                                rentalRef.KickedOut.ToString().Contains(keyword) ||
                                                                                rentalRef.LateNSF.ToString().Contains(keyword) ||
                                                                                rentalRef.Owing.ToString().Contains(keyword) ||
                                                                                rentalRef.Pets.ToString().Contains(keyword) ||
                                                                                rentalRef.PrprNotice.ToString().Contains(keyword) ||
                                                                                rentalRef.ReRent.ToString().Contains(keyword) ||
                                                                                rentalRef.RltveFrnd.ToString().Contains(keyword) ||
                                                                                rentalRef.Roommates.ToString().Contains(keyword) ||
                                                                                rentalRef.Written.ToString().Contains(keyword) ||
                                                                                (rentalRef.MoveIn ?? string.Empty).Contains(keyword) ||
                                                                                (rentalRef.MoveOut ?? string.Empty).Contains(keyword) ||
                                                                                (rentalRef.Amount ?? string.Empty).Contains(keyword) ||
                                                                                (rentalRef.SW ?? string.Empty).Contains(keyword) ||
                                                                                (rentalRef.Comp ?? string.Empty).Contains(keyword) ||
                                                                                (rentalRef.Phone ?? string.Empty).Contains(keyword) ||
                                                                                (rentalRef.Comment ?? string.Empty).Contains(keyword)))
                                 select application).ToList<AppData>();
                }
                else
                {
                    return apps;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return apps;
            }

            return exactApps;
        }

        private void cboSearchIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(this.cboKeyword, e, false);
        }

        private void cboKeyword_TextChanged(object sender, EventArgs e)
        {
            this.txtKeyword.Text = this.cboKeyword.Text;
        }

        private void cboSearchIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                try
                {
                    switch (this.cboSearchIn.Text)
                    {
                        case "Client Name":
                            this.cboKeyword.Items.Clear();
                            this.cboKeyword.ValueMember = "ClientId";
                            this.cboKeyword.DisplayMember = "ClientName";
                            List<ClientData> clients = this.formBillingManager.formMaster.LIST_CLIENTS;
                            if (clients != null && clients.Count > 0)
                            {
                                foreach (ClientData client in clients)
                                {
                                    this.cboKeyword.Items.Add(client);
                                }
                            }
                            this.cboKeyword.BringToFront();
                            break;
                        case "Priority":
                            this.cboKeyword.Items.Clear();
                            this.cboKeyword.ValueMember = "Value";
                            this.cboKeyword.DisplayMember = "DisplayName";
                            foreach (PriorityApp priorityApp in PriorityApp.GetAll<PriorityApp>())
                            {
                                this.cboKeyword.Items.Add(new PriorityAppData(priorityApp.Value, priorityApp.DisplayName));
                            }
                            this.cboKeyword.BringToFront();
                            break;
                        case "Report Type":
                            this.cboKeyword.Items.Clear();
                            this.cboKeyword.ValueMember = "ReportTypeId";
                            this.cboKeyword.DisplayMember = "TypeName";
                            List<ReportTypeData> reportTypes = this.formBillingManager.formMaster.LIST_REPORT_TYPES;
                            if (reportTypes != null && reportTypes.Count > 0)
                            {
                                foreach (ReportTypeData reportType in reportTypes)
                                {
                                    this.cboKeyword.Items.Add(reportType);
                                }
                            }
                            this.cboKeyword.BringToFront();
                            break;
                        case "Screener":
                            this.cboKeyword.Items.Clear();
                            this.cboKeyword.ValueMember = "ScreenerId";
                            this.cboKeyword.DisplayMember = "ScreenerName";
                            List<User> users = this.formBillingManager.formMaster.LIST_USERS
                                .FindAll(u => u.Status == UserStatus.Active);
                            if (users != null && users.Count > 0)
                            {
                                foreach (User user in users)
                                {
                                    this.cboKeyword.Items.Add(new ScreenerData(user.UserId.Id, user.UserName));
                                }
                            }
                            this.cboKeyword.BringToFront();
                            break;
                        default:
                            this.txtKeyword.BringToFront();
                            break;
                    }
                    this.cboKeyword.Text = this.txtKeyword.Text;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                }
            }
        }

        private void FormInvSearchApps_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadControlValues();
            }
        }

        #region Handle KeyPress Event of CheckedListBox
        string text;
        int lastTick;

        private void lboxClients_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHandlerHelper.CheckedListBoxSearch_KeyPress(sender, e);
        }

        #endregion
    }
}
