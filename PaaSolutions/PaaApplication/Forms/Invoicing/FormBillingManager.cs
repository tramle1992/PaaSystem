using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = NetOffice.WordApi;
using PaaApplication.Forms.Invoicing;
using Common.Infrastructure.UI;
using Common.Infrastructure.OLV;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using Invoice.Application.Data;
using Invoice.Infrastructure;
using Core.Application.Data.ExploreApps;
using PaaApplication.Helper;
using System.Globalization;
using Invoice.Domain.Model;
using Core.Application.Command.ExploreApps;
using Core.Infrastructure.ExploreApps;
using BrightIdeasSoftware;
using PaaApplication.Forms.ClientInfo;
using PaaApplication.Forms.AppExplore;
using PaaApplication.Models.Common;
using OpenXmlPowerTools;
using PaaApplication.Models.Invoice;
using System.IO;
using Common.Infrastructure.Office;
using Common.Infrastructure.Helper;
using PaaApplication.Models.AppExplore;
using Invoice.Application.Helper;
using Invoice.Application.Command;
using PaaApplication.Forms.Common;
using NodaTime;

namespace PaaApplication.Forms.Invoicing
{
    public partial class FormBillingManager : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private InvoiceApiRepository invoiceApiRepository = new InvoiceApiRepository();
        private InvoiceItemApiRepository invoiceItemApiRepository = new InvoiceItemApiRepository();
        InvoiceItemCachedApiQuery invoiceItemCachedApiQuery = InvoiceItemCachedApiQuery.Instance;
        private PaymentApiRepository paymentApiRepository = new PaymentApiRepository();
        private AppApiRepository appApiRepository = new AppApiRepository();
        private OLVColumnFormat olvFormat = new OLVColumnFormat();
        private InvoiceData CurrentLoadedInvoice = null;
        private static List<Form> formList = new List<Form>();
        private Dictionary<string, string> invoiceWordPaths = new Dictionary<string, string>();
        private Dictionary<string, string> invoicePdfPaths = new Dictionary<string, string>();
        private Dictionary<string, bool> emailedList = new Dictionary<string, bool>();
        private List<ClientData> allClients = new List<ClientData>();

        public FormMaster formMaster;
        private FormBillingValidation formBillingValidation;
        private FormSearchInvs formSearchInvs;
        private FormInvSearchApps formInvSearchApp;
        FormAutomaticBilling formAutoBilling;
        FormAppDataGrid _frmAppDataGrid;
        FormInvShipping formInvShipping;

        private static int _currentIndex;

        private Timer timer = new Timer();

        private DateTime currentBillingMonth; // LocalTime

        private readonly DateTime defaultLastPaymentDate = new DateTime(3001, 1, 1);

        public event EventHandler<AppData> EditApplication;
        public event EventHandler<EmailInvoicesEventArgs> EmailInvoicesEventHandler;

        private string currentSubject;

        private List<AppData> selectedApps = new List<AppData>();
        private List<ClientData> selectedClients = new List<ClientData>();
        private List<InvoiceData> selectedInvoices = new List<InvoiceData>();

        public BaseForm FormBillingValidation
        {
            get { return this.formBillingValidation; }
        }

        public string EmailBody { get; set; }

        public FormBillingManager(FormMaster formMaster)
        {
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            InitializeComponent();
            this.formMaster = formMaster;
            _frmAppDataGrid = new FormAppDataGrid();
            this.EditApplication += EditApplicationHandler;
            this.EmailBody = EmailHelper.BuildSignature(null);

            this.uInvoicingRibbon.SearchInvoicesClick += SearchInvoicesClickHandler;
            this.uInvoicingRibbon.SearchApplicationsClick += SearchApplicationsClickHandler;
            this.uInvoicingRibbon.BillingMonthDoubleClick += BillingMonthDoubleClickHandler;
            this.uInvoicingRibbon.DgAllClientsClick += DgAllClientsClickHandler;
            this.uInvoicingRibbon.DgSelectedClientsClick += DgSelectedClientsClickHandler;
            this.uInvoicingRibbon.DgAllShownInvoicesClick += DgAllShownInvoicesClickHandler;
            this.uInvoicingRibbon.DgSelectedInvoicesClick += DgSelectedInvoicesClickHandler;
            this.uInvoicingRibbon.DgAllShownAppsClick += DgAllShownAppsClickHandler;
            this.uInvoicingRibbon.DgSelectedAppsClick += DgSelectedAppsClickHandler;
            this.uInvoicingRibbon.InvoicePrintMenuDoubleClick += InvoicePrintMenuDoubleClickHandler;
            this.uInvoicingRibbon.PrtClientCommonClick += PrtClientCommonClickHandler;
            this.uInvoicingRibbon.PrtSelectedInvoicesClick += PrtSelectedInvoicesClickHandler;
            this.uInvoicingRibbon.PrtAllInvoicesClick += PrtAllInvoicesClickHandler;
            this.uInvoicingRibbon.PrtAllShownInvsClick += PrtAllShownInvsClickHandler;
            this.uInvoicingRibbon.PrtSelectedInvsClick += PrtSelectedInvsClickHandler;
            this.uInvoicingRibbon.RefreshInvoiceClick += RefreshInvoiceClickHandler;
        }

        public FormBillingManager() { }

        private void EditApplicationHandler(object sender, AppData e)
        {
            formMaster.EditApplicationFromInvoicing(e);
        }

        private void FormBillingManager_LoadCompleted(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                try
                {
                    this.appTabsControl.Hide();
                    this.invStatsControl.Hide();
                    this.txtTitle.Hide();
                    this.invDetailControl.Hide();
                    this.invPaymentControl.Hide();

                    InitObjectListView();

                    LoadClients();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void InitObjectListView()
        {
            // olvClients
            this.olvColClientSince.AspectToStringConverter = delegate(object aspect)
            {
                DateTime dateTime;
                if (aspect != null && DateTime.TryParse(aspect.ToString(), out dateTime))
                {
                    return dateTime.ToLocalTime().ToString("MM/dd/yyyy");
                }
                else
                {
                    return "";
                }
            };

            this.olvColClientManagement.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    ClientData client = row as ClientData;
                    if (client != null && client.ManagementCompany != null && !string.IsNullOrEmpty(client.ManagementCompany.Name))
                    {
                        return client.ManagementCompany.Name;
                    }
                }
                return "";
            };

            // olvInvoices
            this.olvColInvStatus.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    InvoiceData invoice = row as InvoiceData;
                    if (invoice != null && invoice.Status != null && !string.IsNullOrEmpty(invoice.Status.DisplayName))
                    {
                        return invoice.Status.DisplayName.ToUpper();
                    }
                }
                return Status.PAID.DisplayName.ToUpper();
            };

            this.olvColInvMonth.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    InvoiceData invoice = row as InvoiceData;
                    if (invoice != null)
                    {
                        return invoice.InvoiceDate.ToLocalTime();
                    }
                }
                return DateTime.Now;
            };

            this.olvColInvAmount.AspectToStringConverter = delegate(object aspect)
            {
                if (aspect != null)
                {
                    return "$" + ((decimal)aspect).ToString("N", CultureInfo.CurrentUICulture);
                }
                return "$0.00";
            };

            this.olvColInvBalance.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    InvoiceData invoice = row as InvoiceData;
                    if (invoice != null && invoice.Status != null)
                    {
                        return "$" + invoice.Balance.ToString("N", CultureInfo.CurrentUICulture);
                    }
                }
                return "$0.00";
            };

            this.olvColInvActionStatus.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    InvoiceData invoice = row as InvoiceData;
                    if (invoice != null && invoice.ActionStatus != null && !string.IsNullOrEmpty(invoice.ActionStatus.DisplayName))
                    {
                        return invoice.ActionStatus.DisplayName.ToUpper();
                    }
                }
                return ActionStatus.NONE.DisplayName.ToUpper();
            };

            // olvApplications
            this.olvColAppName.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    ReportTypeData reportType = ReportTypeCachedApiQuery.Instance.GetReportType(app.ReportTypeId);
                    return Utils.GetApplicantName(app, reportType);
                }
                return "";
            };

            this.olvColAppReceivedDate.AspectToStringConverter = delegate(object aspect)
            {
                DateTime dateTime;
                if (aspect != null && DateTime.TryParse(aspect.ToString(), out dateTime))
                {
                    return dateTime.ToLocalTime().ToString("MM/dd/yyyy hh:mm tt");
                }
                else
                {
                    return "";
                }
            };
        }

        public DateTime GetCurrentBillingMonth()
        {
            return this.currentBillingMonth; // LocalTime
        }

        public void SetCurrentBillingMonth(DateTime currentBillingMonth)
        {
            this.currentBillingMonth = currentBillingMonth; // LocalTime
        }

        public void LoadClients()
        {
            List<ClientData> clients = this.formMaster.LIST_CLIENTS;
            if (clients != null && clients.Count > 0)
            {
                this.allClients = clients;
                this.olvClients.SetObjects(clients);
                if(olvClients.SelectedIndex < 0 && _currentIndex == 0)
                {
                    this.olvClients.SelectedIndex = 0;
                }
                else
                {
                    this.olvClients.SelectedIndex = _currentIndex;
                    this.olvClients.EnsureVisible(_currentIndex);
                }
            }
            else
            {
                allClients = ClientCachedApiQuery.Instance.GetAllClients();
                if (allClients != null && allClients.Count > 0)
                {
                    this.olvClients.SetObjects(allClients);
                    if (olvClients.SelectedIndex < 0 && _currentIndex == 0)
                    {
                        this.olvClients.SelectedIndex = 0;
                    }
                    else
                    {
                        this.olvClients.SelectedIndex = _currentIndex;
                        this.olvClients.EnsureVisible(_currentIndex);
                    }
                }
                else
                {
                    this.olvClients.ClearObjects();
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            string date = t.ToLongDateString();
            string time = t.ToLongTimeString();
            sttlblClock.Text = string.Format("{0} | {1}", date, time);
        }

        public void SetAppCount(int clientCount, int invCount, int appCount)
        {
            string message = (clientCount > 0) ? string.Format("{0} Clients", clientCount) : "No Clients";
            message += (invCount > 0) ? string.Format(", {0} Invoices", invCount) : ", No Invoices";
            message += (appCount > 0) ? string.Format(", {0} Apps.", appCount) : ", No Apps.";

            sttlblCount.Text = message + " In View";
        }

        #region Client Context Menu
        private void cmnuClient_Opening(object sender, CancelEventArgs e)
        {
            if (this.olvClients.Items.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void toolClientPaymentHistory_Click(object sender, EventArgs e)
        {
            List<ClientData> selectedClients = new List<ClientData>();
            foreach (ClientData item in this.olvClients.SelectedObjects)
            {
                selectedClients.Add(item);
            }

            if (selectedClients == null || selectedClients.Count == 0)
            {
                return;
            }

            this.appTabsControl.Hide();
            this.invDetailControl.Hide();
            this.invPaymentControl.Hide();

            if (selectedClients.Count == 1)
            {
                this.txtTitle.Text = "Client Information: " + selectedClients[0].ClientName;
            }
            else
            {
                this.txtTitle.Text = "Client Information: Multiple Clients";
            }
            this.txtTitle.Show();
            this.invStatsControl.ClearDataInControls();
            this.invStatsControl.SetClients(selectedClients);
            this.invStatsControl.Show();
        }
        #endregion

        #region Invoice Context Menu
        private void cmnuInvoice_Opening(object sender, CancelEventArgs e)
        {
            if (this.olvInvoices.Items.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void toolInvoiceShow_Click(object sender, EventArgs e)
        {
            InvoiceData selectedInvoice = this.olvInvoices.SelectedObject as InvoiceData;
            if (selectedInvoice == null || string.IsNullOrEmpty(selectedInvoice.InvoiceId))
            {
                this.invDetailControl.ClearDataInControls();
                this.invDetailControl.SetEnabledControls(false);
                this.invDetailControl.Show();
                this.invPaymentControl.ClearDataInControls();
                this.invPaymentControl.Hide();
                this.txtTitle.Hide();

                this.invDetailControl.CancelCellEdit();
                this.invPaymentControl.CancelCellEdit();
                return;
            }

            ShowInvoice(selectedInvoice);
        }

        private void toolInvoiceEditPayments_Click(object sender, EventArgs e)
        {
            List<InvoiceData> selectedInvoices = new List<InvoiceData>();
            foreach (InvoiceData item in this.olvInvoices.SelectedObjects)
            {
                selectedInvoices.Add(item);
            }

            if (selectedInvoices == null || selectedInvoices.Count == 0)
            {
                return;
            }

            this.appTabsControl.Hide();
            this.invDetailControl.Hide();
            this.invStatsControl.Hide();

            InvoiceData invoice = selectedInvoices[0];
            this.txtTitle.Text = "Inv #" + invoice.InvoiceNumber + " FOR: " + invoice.ClientName.Trim();
            this.txtTitle.Show();
            this.invPaymentControl.ClearDataInControls();
            this.invPaymentControl.SetCurrentInvoice(invoice);
            this.invPaymentControl.Show();
        }

        private void toolInvoiceSearch_Click(object sender, EventArgs e)
        {
            this.formMaster.rbtnSearchInvoices_Click(sender, e);
        }

        private void toolInvoiceStats_Click(object sender, EventArgs e)
        {
            List<InvoiceData> selectedInvoices = new List<InvoiceData>();
            foreach (InvoiceData item in this.olvInvoices.SelectedObjects)
            {
                selectedInvoices.Add(item);
            }

            if (selectedInvoices == null || selectedInvoices.Count == 0)
            {
                return;
            }

            this.appTabsControl.Hide();
            this.invDetailControl.Hide();
            this.invPaymentControl.Hide();

            this.txtTitle.Text = "Invoice Statistics";
            this.txtTitle.Show();
            this.invStatsControl.ClearDataInControls();
            this.invStatsControl.SetInvoices(selectedInvoices);
            this.invStatsControl.Show();
        }

        private void toolInvoiceUpdateClientName_Click(object sender, EventArgs e)
        {
            List<InvoiceData> selectedInvoices = new List<InvoiceData>();
            foreach (InvoiceData item in this.olvInvoices.SelectedObjects)
            {
                selectedInvoices.Add(item);
            }

            if (selectedInvoices == null || selectedInvoices.Count == 0)
            {
                MessageBox.Show("No invoice(s) to update client names!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string oldClientName = selectedInvoices[0].ClientName;
            FormInvUpdateClientName formInvUpdateClientName = new FormInvUpdateClientName(oldClientName);
            formInvUpdateClientName.StartPosition = FormStartPosition.CenterParent;
            DialogResult dialogResult = formInvUpdateClientName.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                using (new HourGlass())
                {
                    List<InvoiceData> invoices = new List<InvoiceData>(selectedInvoices.Count);
                    foreach (InvoiceData invoice in selectedInvoices)
                    {
                        if (invoice.ClientName.Equals(oldClientName))
                        {
                            invoices.Add(invoice);
                        }
                    }

                    foreach (InvoiceData invoice in invoices)
                    {
                        invoice.ClientName = formInvUpdateClientName.NewClientName;
                        invoice.SoldToClientName = formInvUpdateClientName.NewClientName;
                    }

                    try
                    {
                        invoiceApiRepository.MultiUpdate(invoices);
                        InvoiceCachedApiQuery.Instance
                            .RemoveInvoicesByYearAndMonth(invoices[0].InvoiceDate.Year, invoices[0].InvoiceDate.Month);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex.ToString());
                        return;
                    }

                    this.olvInvoices.RefreshObjects(selectedInvoices);
                }
            }
        }

        private void toolInvoiceDelete_Click(object sender, EventArgs e)
        {
            List<InvoiceData> selectedInvoices = new List<InvoiceData>();
            foreach (InvoiceData item in this.olvInvoices.SelectedObjects)
            {
                selectedInvoices.Add(item);
            }

            if (selectedInvoices == null || selectedInvoices.Count == 0)
            {
                MessageBox.Show("No invoice(s) to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + selectedInvoices.Count + " invoice(s)?\n"
                + "This action will delete all invoice items and payments!",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                RemoveInvoices(this.currentBillingMonth, selectedInvoices);
            }
        }
        #endregion

        #region Application Context Menu
        private void cmnuApplication_Opening(object sender, CancelEventArgs e)
        {
            if (this.olvApplications.Items.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void toolAppEdit_Click(object sender, EventArgs e)
        {
            AppData app = (AppData)olvApplications.SelectedObject;
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            if (this.EditApplication != null)
            {
                this.EditApplication(this, app);
            }
        }

        private void toolAppShowBilledStatus_Click(object sender, EventArgs e)
        {
            List<AppData> selectedApps = new List<AppData>();
            foreach (AppData item in this.olvApplications.SelectedObjects)
            {
                selectedApps.Add(item);
            }

            if (selectedApps == null || selectedApps.Count == 0)
            {
                return;
            }

            this.olvColAppBilledStatus.IsVisible = true;
            this.olvApplications.RebuildColumns();

            foreach (AppData app in selectedApps)
            {
                try
                {
                    ReportTypeData reportType = ReportTypeCachedApiQuery.Instance.GetReportType(app.ReportTypeId);
                    string applicationName = Utils.GetApplicantName(app, reportType);
                    int invoiceNumber = 0;
                    if (InvoiceCalculationHelper.CheckIfAppIsBilled(app.ApplicationId, applicationName, app.ClientAppliedName,app.ClientApplied,
                        app.InvoiceDivision, app.ReceivedDate, out invoiceNumber))
                    {
                        app.BilledStatus = "Yes";
                    }
                    else
                    {
                        app.BilledStatus = "No";
                    }
                    this.olvApplications.RefreshObject(app);
                }
                catch (Exception ex)
                {
                    _logger.Error("Show Billed Status: " + ex.ToString());
                }
            }
        }

        private void toolAppFindOnInvoice_Click(object sender, EventArgs e)
        {
            AppData selectedApp = this.olvApplications.SelectedObject as AppData;
            if (selectedApp == null || string.IsNullOrEmpty(selectedApp.ApplicationId))
            {
                return;
            }

            try
            {
                ReportTypeData reportType = ReportTypeCachedApiQuery.Instance.GetReportType(selectedApp.ReportTypeId);
                string applicationName = Utils.GetApplicantName(selectedApp, reportType);
                int invoiceNumber = 0;
                if (!InvoiceCalculationHelper.CheckIfAppIsBilled(selectedApp.ApplicationId, applicationName, selectedApp.ClientAppliedName, selectedApp.ClientApplied,
                    selectedApp.InvoiceDivision, selectedApp.ReceivedDate, out invoiceNumber))
                {
                    return;
                }

                List<InvoiceData> allInvoicesInMonth = InvoiceCachedApiQuery.Instance.
                        GetInvoicesByYearAndMonth(currentBillingMonth.Year, currentBillingMonth.Month);
                if (allInvoicesInMonth == null || allInvoicesInMonth.Count == 0)
                {
                    return;
                }

                InvoiceData invoice = allInvoicesInMonth.Find(r => (r.InvoiceNumber == invoiceNumber));
                if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
                {
                    return;
                }

                ShowInvoice(invoice);
            }
            catch (Exception ex)
            {
                _logger.Error("Find App On Invoice: " + ex.ToString());
            }
        }

        public void toolAppBillingValidation_Click(object sender, EventArgs e)
        {
            if (this.formBillingValidation == null
                || this.formBillingValidation.IsDisposed)
            {
                this.formBillingValidation = new FormBillingValidation(this);
            }
            if (sender != null && sender as FormAutomaticBilling != null)
            {
                this.formBillingValidation.FormClosed += (s, args) => ((FormAutomaticBilling)sender).Close();
            }

            this.formBillingValidation.StartPosition = FormStartPosition.CenterScreen;
            this.formBillingValidation.Show();
            this.formBillingValidation.BringToFront();
        }
        #endregion

        #region OLV Clients
        private void olvClients_DoubleClick(object sender, EventArgs e)
        {
            ClientData selectedClient = this.olvClients.SelectedObject as ClientData;
            if (selectedClient == null || string.IsNullOrEmpty(selectedClient.ClientName))
            {
                return;
            }

            // Query input should be in local time since we use local time on all of UI
            // except when 
            FormNewInvoice formNewInvoice = new FormNewInvoice(selectedClient, this.currentBillingMonth);
            formNewInvoice.StartPosition = FormStartPosition.CenterParent;
            if (formNewInvoice.ShowDialog() == DialogResult.OK)
            {
                using (new HourGlass())
                {
                    if (formNewInvoice.FormAction == FormNewInvoice.Action.NewInvoice)
                    {
                        CreateInvoice(selectedClient, formNewInvoice.SelectedInvoiceDivision,
                                        currentBillingMonth, null, false);
                    }
                    else if (formNewInvoice.FormAction == FormNewInvoice.Action.ViewInvoices)
                    {
                        List<InvoiceData> invoices = new List<InvoiceData>();
                        List<InvoiceData> allInvoicesInMonth = InvoiceCachedApiQuery.Instance.
                            GetInvoicesByYearAndMonth(currentBillingMonth.Year, currentBillingMonth.Month);
                        if (allInvoicesInMonth != null && allInvoicesInMonth.Count > 0)
                        {
                            invoices = allInvoicesInMonth.FindAll(r => (!string.IsNullOrEmpty(r.ClientName) &&
                                                                    r.ClientName.Equals(selectedClient.ClientName)));
                        }
                        SetOLVInvoices(invoices, null);
                    }
                }
                formNewInvoice.Close();
            }
        }

        private void olvClients_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                olvClients_DoubleClick(null, null);
            }
        }

        public ClientData GetSelectedClient()
        {
            if (this.olvClients.Items.Count > 0 && this.olvClients.SelectedObjects.Count > 0)
            {
                ClientData client = (ClientData)olvClients.SelectedObjects[olvClients.SelectedObjects.Count - 1];
                return client;
            }
            return null;
        }

        public List<ClientData> GetListSelectedClients()
        {
            List<ClientData> clients = new List<ClientData>();
            foreach (var clientData in olvClients.SelectedObjects)
            {
                ClientData data = (ClientData)clientData;
                clients.Add(data);
            }
            return clients;
        }

        public List<ClientData> GetListAllClients()
        {
            List<ClientData> clients = new List<ClientData>();

            if (this.olvClients.Objects == null || this.olvClients.GetItemCount() == 0)
            {
                return clients;
            }

            foreach (ClientData client in this.olvClients.Objects)
            {
                if (client != null && !string.IsNullOrEmpty(client.ClientId))
                {
                    clients.Add(client);
                }
            }

            return clients;
        }
        #endregion

        #region OLV Invoices
        public List<InvoiceData> GetOLVInvoices()
        {
            List<InvoiceData> invoices = new List<InvoiceData>();

            if (this.olvInvoices.Objects == null)
            {
                return invoices;
            }

            foreach (InvoiceData invoice in this.olvInvoices.Objects)
            {
                invoices.Add(invoice);
            }

            return invoices;
        }

        public void SetOLVInvoices(List<InvoiceData> invoices, InvoiceData selectedInvoice)
        {
            if (invoices == null || invoices.Count == 0)
            {
                this.olvInvoices.ClearObjects();
                this.invDetailControl.ClearDataInControls();
                this.invDetailControl.SetEnabledControls(false);
                this.invPaymentControl.ClearDataInControls();
                return;
            }

            this.olvInvoices.SetObjects(invoices);

            if (selectedInvoice == null || string.IsNullOrEmpty(selectedInvoice.InvoiceId))
            {
                this.olvInvoices.SelectedIndex = 0;
                this.olvInvoices.EnsureVisible(0);
                return;
            }

            for (int i = 0; i < this.olvInvoices.Items.Count; i++)
            {
                InvoiceData item = (InvoiceData)this.olvInvoices.GetModelObject(i);
                if (item != null && !string.IsNullOrEmpty(item.InvoiceId) &&
                    item.InvoiceId.Equals(selectedInvoice.InvoiceId))
                {
                    this.olvInvoices.SelectedIndex = i;
                    this.olvInvoices.EnsureVisible(i);
                    break;
                }
            }
        }

        public void UpdateItemOLVInvoices(InvoiceData invoice)
        {
            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
            {
                return;
            }

            for (int i = 0; i < this.olvInvoices.Items.Count; i++)
            {
                InvoiceData item = (InvoiceData)this.olvInvoices.GetModelObject(i);
                if (item != null && !string.IsNullOrEmpty(item.InvoiceId) &&
                    item.InvoiceId.Equals(invoice.InvoiceId))
                {
                    item.ClientName = invoice.ClientName;
                    item.SoldToClientName = invoice.SoldToClientName;
                    item.Address = invoice.Address;
                    item.InvoiceReference = invoice.InvoiceReference;
                    item.CustomerNumber = invoice.CustomerNumber;
                    item.InvoiceComments = invoice.InvoiceComments;
                    //item.InvoiceNumber = invoice.InvoiceNumber;
                    //item.InvoiceDate = invoice.InvoiceDate;
                    item.NoteToClient = invoice.NoteToClient;
                    item.PONumber = invoice.PONumber;
                    item.InvoiceDivision = invoice.InvoiceDivision;
                    item.Status = invoice.Status;
                    item.Amount = invoice.Amount;
                    item.Balance = invoice.Balance;
                    item.ActionStatus = invoice.ActionStatus;

                    this.olvInvoices.RefreshObject(item);
                    break;
                }
            }
        }

        private void olvApplications_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                AppData selectedApp = this.olvApplications.SelectedObject as AppData;

                if (selectedApp != null)
                {
                    if (selectedApps.Count > 0)
                        selectedApps.Clear();
                    selectedApps.Add(selectedApp);
                }
                else if (selectedApp == null && olvApplications.Items.Count > 0 && olvApplications.MultiSelect && olvApplications.SelectedObjects.Count > 1)
                {
                    if (selectedApps.Count > 0)
                        selectedApps.Clear();

                    foreach (AppData appData in olvApplications.SelectedObjects)
                    {
                        selectedApps.Add(appData);
                    }
                }
                else if (selectedApp == null)
                {
                    if (selectedApps.Count == 1)
                        olvApplications.SelectedObject = selectedApps.FirstOrDefault();
                    else if (selectedApps.Count > 1)
                        olvApplications.SelectedObjects = selectedApps;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void olvInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            InvoiceData selectedInvoice = this.olvInvoices.SelectedObject as InvoiceData;
            if (selectedInvoice == null || string.IsNullOrEmpty(selectedInvoice.InvoiceId))
            {
                this.invDetailControl.ClearDataInControls();
                this.invDetailControl.SetEnabledControls(false);
                this.invDetailControl.Show();
                this.invPaymentControl.ClearDataInControls();
                this.invPaymentControl.Hide();
                this.txtTitle.Hide();

                this.invDetailControl.CancelCellEdit();
                this.invPaymentControl.CancelCellEdit();
                return;
            }

            ShowInvoice(selectedInvoice);
        }

        private void olvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                InvoiceData selectedInvoice = this.olvInvoices.SelectedObject as InvoiceData;

                if (selectedInvoice != null)
                {
                    if (selectedInvoices.Count > 0)
                        selectedInvoices.Clear();
                    selectedInvoices.Add(selectedInvoice);
                }
                else if (selectedInvoice == null && olvInvoices.Items.Count > 0 && olvInvoices.MultiSelect && olvInvoices.SelectedObjects.Count > 1)
                {
                    if (selectedInvoices.Count > 0)
                        selectedInvoices.Clear();

                    foreach (InvoiceData invoiceData in olvInvoices.SelectedObjects)
                    {
                        selectedInvoices.Add(invoiceData);
                    }
                }
                else if (selectedInvoice == null)
                {
                    if (selectedInvoices.Count == 1)
                        olvInvoices.SelectedObject = selectedInvoices.FirstOrDefault();
                    else if (selectedInvoices.Count > 1)
                        olvInvoices.SelectedObjects = selectedInvoices;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void objectListView_ItemsChanged(object sender, EventArgs args)
        {
            SetAppCount(olvClients.Items.Count, olvInvoices.Items.Count, olvApplications.Items.Count);
        }

        private void olvClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentIndex = olvClients.SelectedIndex;            
        }

        private void olvClients_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ClientData selectedClient = this.olvClients.SelectedObject as ClientData;

                if (selectedClient != null)
                {
                    if (selectedClients.Count > 0)
                        selectedClients.Clear();
                    selectedClients.Add(selectedClient);
                }
                else if (selectedClient == null && olvClients.Items.Count > 0 && olvClients.MultiSelect && olvClients.SelectedObjects.Count > 1)
                {
                    if (selectedClients.Count > 0)
                        selectedClients.Clear();

                    foreach (ClientData clientData in olvClients.SelectedObjects)
                    {
                        selectedClients.Add(clientData);
                    }
                }
                else if (selectedClient == null)
                {
                    if (selectedClients.Count == 1)
                        olvClients.SelectedObject = selectedClients.FirstOrDefault();
                    else if (selectedClients.Count > 1)
                        olvClients.SelectedObjects = selectedClients;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }
        #endregion

        #region OLV Applications
        public void SetOLVApplications(List<AppData> apps, AppData selectedApp)
        {
            if (apps == null || apps.Count == 0)
            {
                this.olvApplications.ClearObjects();
                return;
            }

            this.olvColAppBilledStatus.IsVisible = false;
            this.olvApplications.RebuildColumns();

            this.olvApplications.SetObjects(apps);

            if (selectedApp == null || string.IsNullOrEmpty(selectedApp.ApplicationId))
            {
                this.olvApplications.SelectedIndex = 0;
                this.olvApplications.EnsureVisible(0);
                return;
            }

            for (int i = 0; i < this.olvApplications.Items.Count; i++)
            {
                AppData item = (AppData)this.olvApplications.GetModelObject(i);
                if (item != null && !string.IsNullOrEmpty(item.ApplicationId) &&
                    item.ApplicationId.Equals(selectedApp.ApplicationId))
                {
                    this.olvApplications.SelectedIndex = i;
                    this.olvApplications.EnsureVisible(i);
                    break;
                }
            }
        }
        #endregion

        #region Business logics
        public List<AvailableAppData> GetAvailableAppData(string clientName, string invoiceDivision,
            DateTime currentBillingMonth, bool orderByName, ClientData client = null) // currentBillingMonth is LocalTime
        {
            List<AvailableAppData> availableApps = new List<AvailableAppData>();

            if (string.IsNullOrEmpty(clientName))
            {
                return availableApps;
            }

            DateTime receivedFrom = new DateTime(currentBillingMonth.Year, currentBillingMonth.Month, 1).Date.ToUniversalTime();
            DateTime receivedTo = receivedFrom.AddMonths(1).AddSeconds(-5);

            List<AppData> apps = this.formMaster.LIST_APPS_FOR_INVOICE.FindAll(r =>
                                    (r != null && !string.IsNullOrEmpty(r.ApplicationId)
                                    && (r.ReceivedDate >= receivedFrom && r.ReceivedDate <= receivedTo)
                                    && (!string.IsNullOrEmpty(r.ClientAppliedName)
                                        && r.ClientAppliedName.Equals(clientName))
                                    && (invoiceDivision != null
                                        &&((client != null && client.InvoiceDivisions.Count == 0 && string.IsNullOrEmpty(r.InvoiceDivision)) //if client Invoice Division is empty and App Invoice Division is valid case to create Invoice
                                        //else if App Invoice Division is not empty and App Invoice Division is not "(None)" and Client Invoice Division is equal App Invoice Division -> valid to create Invoice
                                        || (!string.IsNullOrEmpty(r.InvoiceDivision)
                                        && !r.InvoiceDivision.Equals("(None)") // Special case, always "Invalid"
                                        && r.InvoiceDivision.Equals(invoiceDivision))))));

            if (apps != null && apps.Count > 0)
            {
                if (orderByName)
                {
                    apps.OrderBy(r => r.LastName);
                }
                else
                {
                    apps.OrderBy(r => r.ReceivedDate);
                }
            }
            else
            {
                return availableApps;
            }

            foreach (AppData app in apps)
            {
                AvailableAppData availableApp = new AvailableAppData();
                availableApp.ApplicationId = app.ApplicationId;
                availableApp.ReportTypeName = app.ReportTypeName;
                availableApp.InvoiceItemDescription = InvoiceCalculationHelper.GetInvoiceItemDescription(app);
                availableApp.InvoiceItemUnitPrice =
                    GetInvoiceItemUnitPrice(app.ReportTypeName, clientName);
                availableApps.Add(availableApp);
            }

            return availableApps;
        }

        public decimal GetInvoiceItemUnitPrice(string reportTypeName, string clientName)
        {
            decimal defaultPrice = 0;

            if (string.IsNullOrEmpty(reportTypeName) || string.IsNullOrEmpty(clientName))
            {
                return defaultPrice;
            }

            ReportTypeData reportType = this.formMaster.LIST_REPORT_TYPES
                .Find(r => (!string.IsNullOrEmpty(r.TypeName) && r.TypeName.Equals(reportTypeName)));
            if (reportType == null || string.IsNullOrEmpty(reportType.ReportTypeId))
            {
                return defaultPrice;
            }

            defaultPrice = reportType.DefaultPrice;

            ClientData client = this.formMaster.LIST_CLIENTS
                                    .Find(r => (r != null
                                                && !string.IsNullOrEmpty(r.ClientName)
                                                && r.ClientName.Equals(clientName)));
            if (client == null || string.IsNullOrEmpty(client.ClientId)
                || client.ClientReportSpecialPrices == null || client.ClientReportSpecialPrices.Count == 0)
            {
                return defaultPrice;
            }

            foreach (ClientReportSpecialPriceData specialPriceData in client.ClientReportSpecialPrices)
            {
                if (specialPriceData.ReportTypeId.Equals(reportType.ReportTypeId))
                {
                    return specialPriceData.SpecialPrice;
                }
            }

            return defaultPrice;
        }
        #endregion

        #region Generate invoice document
        public DocumentCompleteResult BuildInvoiceOpenXML(ClientData client, InvoiceData invoice, List<InvoiceItemData> invoiceItems, List<InvoiceData> pastDueInvoices)
        {
            string workingFilePath = GenerateDocumentInvoiceOpenXML(client, invoice, invoiceItems, pastDueInvoices);
            if (!string.IsNullOrEmpty(workingFilePath))
            {
                string toSaveFileName = string.Format("{0} - {1}", invoice.SoldToClientName, invoice.InvoiceDate.ToString("MMddyy"));
                WordService word = new WordService(workingFilePath, toSaveFileName, false, false);
                string emailSubject = string.Format("Bemrose Invoice for {0}", invoice.InvoiceDate.ToString("MM/yy"));
                return new DocumentCompleteResult(workingFilePath, word, emailSubject);
            }
            return null;
        }

        public string GenerateDocumentInvoiceOpenXML(ClientData client, InvoiceData invoice, List<InvoiceItemData> invoiceItems, List<InvoiceData> pastDueInvoices)
        {
            // Get past due invoice of same client
            List<InvoiceData> outstandingInvoices = new List<InvoiceData>();
            foreach (var pastDueInvoice in pastDueInvoices)
            {
                if (pastDueInvoice.Status.Value == Status.PAST_DUE.Value &&
                    pastDueInvoice.ClientName == invoice.ClientName &&
                    pastDueInvoice.InvoiceId != invoice.InvoiceId &&
                    pastDueInvoice.InvoiceDivision == invoice.InvoiceDivision)
                {
                    outstandingInvoices.Add(pastDueInvoice);
                }
            }

            WordDocumentType docType = WordDocumentType.Invoice;
            List<Source> documentBuilderSources = new List<Source>();

            InvoiceBuilderOpenXML.InvoicePage(documentBuilderSources, client, invoice, invoiceItems, outstandingInvoices);

            WmlDocument mergedDocument = DocumentBuilder.BuildDocument(documentBuilderSources);

            string filename = WordTemplatePathResolver.GetTemplateFileName(docType);

            string toSaveFileName = string.Format("{0} - {1}", invoice.SoldToClientName, invoice.InvoiceNumber);

            byte[] byteArray = mergedDocument.DocumentByteArray;

            string workingFilePath = string.Empty;
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                workingFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, "docx");

                using (FileStream fileStream = new FileStream(workingFilePath,
                    System.IO.FileMode.CreateNew, FileAccess.Write))
                {
                    mem.WriteTo(fileStream);
                }
            }
            return workingFilePath;
        }

        public string GenerateDocumentInvoicesByClientPastDueOpenXML(ClientData client, List<InvoiceData> invoices)
        {
            WordDocumentType docType = WordDocumentType.InvoicesClientPastDue;
            List<Source> documentBuilderSources = new List<Source>();

            InvoiceBuilderOpenXML.InvoicesPastDueByClientPage(documentBuilderSources, client, invoices);

            WmlDocument mergedDocument = DocumentBuilder.BuildDocument(documentBuilderSources);

            string filename = WordTemplatePathResolver.GetTemplateFileName(docType);

            string toSaveFileName = string.Format("{0} - Past Dues", client.ClientName);

            byte[] byteArray = mergedDocument.DocumentByteArray;

            string workingFilePath = string.Empty;
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                workingFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, "docx");

                using (FileStream fileStream = new FileStream(workingFilePath,
                    System.IO.FileMode.CreateNew, FileAccess.Write))
                {
                    mem.WriteTo(fileStream);
                }
            }
            return workingFilePath;
        }
        #endregion

        #region Invoice UI interact
        public void ShowInvoice(InvoiceData invoice)
        {
            using (new HourGlass())
            {
                this.appTabsControl.Hide();
                this.invStatsControl.Hide();
                this.txtTitle.Hide();
                this.invPaymentControl.Hide();

                bool success = InvoiceCalculationHelper.UpdateInvoiceStatus(invoice);
                if (success)
                {
                    UpdateItemOLVInvoices(invoice);
                }
                CurrentLoadedInvoice = invoice;
                this.invDetailControl.SetCurrentInvoice(invoice);
                this.invDetailControl.Show();
            }
        }

        public InvoiceData CreateInvoice(ClientData client, string invoiceDivision,
            DateTime currentBillingMonth, List<InvoiceItemData> invoiceItems,
            bool silent, int maxInvoiceNumberInMonth = -1)
        {
            DateTime firstDayOfBillingMonth = new DateTime(currentBillingMonth.Year, currentBillingMonth.Month, 1);
            DateTimeZone tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();
            try
            {
                if (maxInvoiceNumberInMonth == -1)
                {
                    maxInvoiceNumberInMonth = invoiceApiRepository
                    .FindMaxInvoiceNumberByYearAndMonth(firstDayOfBillingMonth.Year,
                                                        firstDayOfBillingMonth.Month, tz.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }

            int invoiceNumber = InvoiceCalculationHelper.GetNextInvoiceNumber(firstDayOfBillingMonth.Year,
                                                                                firstDayOfBillingMonth.Month,
                                                                                tz.Id,
                                                                                maxInvoiceNumberInMonth);
            if (invoiceNumber < 0)
            {
                MessageBox.Show("Creating new invoice failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            InvoiceData invoice = new InvoiceData();
            invoice.InvoiceId = Guid.NewGuid().ToString();
            invoice.ClientName = client.ClientName;
            invoice.SoldToClientName = client.ClientName;
            invoice.Address = client.BillingAddress;
            invoice.InvoiceReference = invoiceDivision;
            invoice.CustomerNumber = client.CustomerNumber;
            invoice.InvoiceComments = string.Empty;
            invoice.InvoiceNumber = invoiceNumber;
            invoice.InvoiceDate = currentBillingMonth.ToUniversalTime();
            invoice.NoteToClient = string.Empty;
            invoice.PONumber = invoiceNumber.ToString();
            invoice.InvoiceDivision = invoiceDivision;
            if (invoiceItems == null || invoiceItems.Count == 0)
            {
                invoice.Amount = 0;
                invoice.Balance = 0;
                invoice.Status = AutoMapper.Mapper.Map<Status, StatusData>(Status.PAID);
                invoice.ActionStatus = AutoMapper.Mapper.Map<ActionStatus, ActionStatusData>(ActionStatus.NONE);
            }
            else
            {
                decimal totalInvoiceItemsAmount = InvoiceCalculationHelper.GetTotalInvoiceItemsAmount(invoiceItems);
                DateTime lastPaymentDate = defaultLastPaymentDate;
                DateTime dueDate = InvoiceCalculationHelper.GetDueDate(invoice.InvoiceDate.ToLocalTime()); // LocalTime
                decimal interest = InvoiceCalculationHelper.GetInterest(invoice);
                StatusData status = InvoiceCalculationHelper.GetInvoiceStatus(totalInvoiceItemsAmount, 0, interest,
                                        lastPaymentDate, dueDate);
                ActionStatusData actionStatus = InvoiceCalculationHelper.GetInvoiceActionStatus(ActionStatus.NONE);
                
                invoice.Amount = totalInvoiceItemsAmount;
                invoice.Balance = totalInvoiceItemsAmount + interest;
                invoice.Status = status;
                invoice.ActionStatus = actionStatus;
            }

            string newId = invoiceApiRepository.Add(invoice);
            if (!string.IsNullOrEmpty(newId))
            {
                CreateInvoiceCompleted(currentBillingMonth, invoice, silent);
                return invoice;
            }
            else
            {
                MessageBox.Show("Creating new invoice failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void RemoveInvoices(DateTime currentBillingMonth, List<InvoiceData> invoices)
        {
            if (invoices == null || invoices.Count == 0)
            {
                MessageBox.Show("No invoice(s) to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (new HourGlass())
            {
                List<string> invoiceIdList = new List<string>();
                foreach (InvoiceData invoice in invoices)
                {
                    invoiceIdList.Add(invoice.InvoiceId);
                }
                invoiceItemApiRepository.MultiRemoveByInvoiceId(invoiceIdList);
                paymentApiRepository.MultiRemoveByInvoiceId(invoices);
                invoiceApiRepository.MultiRemove(invoices);
                RemoveInvoicesCompleted(currentBillingMonth, invoices);
            }
        }

        private void CreateInvoiceCompleted(DateTime currentBillingMonth,
            InvoiceData invoice, bool silent)
        {
            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
            {
                return;
            }

            InvoiceCachedApiQuery.Instance.RemoveInvoicesByYearAndMonth(currentBillingMonth.Year, currentBillingMonth.Month);

            if (!silent)
            {
                List<InvoiceData> invoices = new List<InvoiceData>();
                List<InvoiceData> allInvoicesInMonth = InvoiceCachedApiQuery.Instance.
                                GetInvoicesByYearAndMonth(currentBillingMonth.Year, currentBillingMonth.Month);
                if (allInvoicesInMonth != null && allInvoicesInMonth.Count > 0)
                {
                    invoices = allInvoicesInMonth.FindAll(r => (!string.IsNullOrEmpty(r.ClientName) &&
                                                            r.ClientName.Equals(invoice.ClientName)));
                }

                SetOLVInvoices(invoices, invoice);
                ShowInvoice(invoice);
            }
        }

        private void RemoveInvoicesCompleted(DateTime currentBillingMonth, List<InvoiceData> invoices)
        {
            if (invoices == null || invoices.Count == 0)
            {
                MessageBox.Show("No invoice(s) to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (InvoiceData invoice in invoices)
            {
                if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
                {
                    continue;
                }
                InvoiceItemCachedApiQuery.Instance.RemoveInvoiceItemsByInvoiceId(invoice.InvoiceId);
                PaymentCachedApiQuery.Instance.RemovePaymentsByInvoiceId(invoice.InvoiceId);
            }

            InvoiceCachedApiQuery.Instance.RemoveInvoicesByYearAndMonth(currentBillingMonth.Year, currentBillingMonth.Month);
            this.olvInvoices.RemoveObjects(invoices);
        }
        #endregion

        #region Print or Email invoices
        private string GenerateDocument(InvoiceData invoice, List<InvoiceData> pastDueInvoices, bool alsoGeneratePdf = false)
        {
            // Always return word path (not return pdf path)
            if (alsoGeneratePdf == true)
            {
                var pdfPath = GeneratePdfDocument(invoice, pastDueInvoices);
                return Path.ChangeExtension(pdfPath, "docx");
            }

            return GenerateWordDocument(invoice, pastDueInvoices);
        }
        private string GenerateWordDocument(InvoiceData invoice, List<InvoiceData> pastDueInvoices)
        {
            try
            {
                ClientData client = allClients.Find(x => x.ClientName == invoice.ClientName);

                List<InvoiceItemData> invoiceItems = InvoiceItemCachedApiQuery.Instance.GetInvoiceItemsByInvoiceId(invoice.InvoiceId);
                return GenerateDocumentInvoiceOpenXML(client, invoice, invoiceItems, pastDueInvoices);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
                return string.Empty;
            }
        }

        private string GeneratePdfDocument(InvoiceData invoice, List<InvoiceData> pastDueInvoices)
        {
            try
            {
                ClientData client = allClients.Find(x => x.ClientName == invoice.ClientName);

                List<InvoiceItemData> invoiceItems = InvoiceItemCachedApiQuery.Instance.GetInvoiceItemsByInvoiceId(invoice.InvoiceId);
                var wordFilePath = GenerateDocumentInvoiceOpenXML(client, invoice, invoiceItems, pastDueInvoices);
                var pdfFilePath = Path.ChangeExtension(wordFilePath, "pdf");
                Word.Application oApplication = null;
                Word.Document oDocument = null;

                oApplication = new Word.Application();
                oApplication.Visible = false;
                oDocument = oApplication.Documents.Open(wordFilePath);
                if (oDocument != null)
                {
                    oDocument.ExportAsFixedFormat(pdfFilePath, Word.Enums.WdExportFormat.wdExportFormatPDF, false);
                    oDocument.Close();
                }
                oApplication.Quit();
                return pdfFilePath;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return string.Empty;
            }
        }

        private void EmailInvoice(InvoiceData invoice, string invoicePath, string subject, bool isAutoSend = false)
        {
            OutlookService outlook = null;

            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
                return;
            try
            {
                ClientData client = allClients.Find(x => x.ClientName == invoice.ClientName);

                if (!string.IsNullOrEmpty(invoicePath))
                {

                    string defaultEmailTo = string.Empty;
                    string defaultClientName = string.Empty;
                    int numPrint = client == null ? 1 : client.InvoicesCopiesNumber;
                    if (client != null)
                    {
                        defaultEmailTo = client.DefaultDeliverInvoicesTo;
                        if (string.IsNullOrEmpty(client.DefaultDeliverInvoicesTo))
                            defaultEmailTo = client.Email ?? string.Empty;
                        defaultClientName = client.ClientName;
                    }

                    string emailSubject = string.Format("Bemrose Invoice for {0}", invoice.InvoiceDate.ToString("MM/yy"));
                    if (!string.IsNullOrEmpty(subject))
                        emailSubject = subject;

                    if (isAutoSend)
                    {
                        try
                        {
                            if (client != null && !string.IsNullOrEmpty(client.DefaultDeliverInvoicesTo) &&
                                Utils.ValidEmailAddresses(client.DefaultDeliverInvoicesTo))
                            {
                                outlook = new OutlookService(emailSubject, defaultEmailTo, string.Empty, this.EmailBody, invoicePath, false);
                                outlook.Send();
                                InvoiceCalculationHelper.UpdateInvoiceActionStatus(invoice, ActionStatus.EMAILED);
                                if (!emailedList.ContainsKey(invoice.InvoiceId))
                                {
                                    emailedList.Add(invoice.InvoiceId, true);
                                }
                                else
                                {
                                    emailedList[invoice.InvoiceId] = true;
                                }
                                _logger.Debug("outlook sent mail successfully");
                                //outlook.Quit();
                                outlook.SetNull();
                                //outlook = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _logger.ErrorFormat("Error on EmailInvoice: {0}",ex);
                        }

                    }
                    else
                    {
                        outlook = new OutlookService(emailSubject, defaultEmailTo, string.Empty, this.EmailBody, invoicePath);
                        outlook.Display();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (outlook != null)
                    outlook.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (outlook != null)
                    outlook.Quit();
            }
        }

        private void PrintInvoice(InvoiceData invoice, string invoicePath, bool isAutoSend = false)
        {
            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
                return;
            try
            {
                ClientData client = allClients.Find(x => x.ClientName == invoice.ClientName);

                if (!string.IsNullOrEmpty(invoicePath))
                {

                    int numPrint = (client == null) ? 1 : client.InvoicesCopiesNumber;

                    if (isAutoSend)
                    {
                        WordService word = null;
                        try
                        {
                            if (client != null && !string.IsNullOrEmpty(client.DefaultDeliverInvoicesTo) &&
                                Utils.ValidEmailAddresses(client.DefaultDeliverInvoicesTo))
                            {
                                numPrint = numPrint > 1 ? numPrint : 1;
                            }
                            else
                            {
                                numPrint = numPrint > 2 ? numPrint : 2;
                            }

                            string toSaveFileName = string.Format("{0} - {1}", invoice.SoldToClientName, invoice.InvoiceNumber);
                            word = new WordService(invoicePath, toSaveFileName, false, false);
                            word.Print(numPrint);
                            bool isEmailed = emailedList.ContainsKey(invoice.InvoiceId);
                            if (isEmailed)
                            {
                                InvoiceCalculationHelper.UpdateInvoiceActionStatus(invoice, ActionStatus.EMAILED_PRINTED);
                            }
                            else
                            {
                                InvoiceCalculationHelper.UpdateInvoiceActionStatus(invoice, ActionStatus.PRINTED);
                            }
                            word.Quit();
                            word = null;

                        }
                        catch (Exception ex)
                        {
                            if (word != null)
                                word.Quit();
                        }

                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        public void EmailAndPrintInvoices(List<InvoiceData> invoices, string subject, bool isAutoSend = false, bool alsoGeneratePdf = false)
        {
            if (invoices == null || invoices.Count == 0)
                return;

            this.currentSubject = subject;

            TemplateHelper templateHelper = new TemplateHelper();
            string filename = WordTemplatePathResolver.GetTemplateFileName(WordDocumentType.Invoice);
            if (!string.IsNullOrEmpty(filename))
            {
                string url = string.Format("api/templates");
                string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.Invoice);
                templateHelper.DownloadTemplate(templatePath, filename);
            }


            if (invoices.Count == 1)
            {
                using (new HourGlass())
                {
                    InvoiceData invoice = invoices.FirstOrDefault();
                    // Search Past Due Invoice
                    SearchInvoiceCommand command = new SearchInvoiceCommand();
                    command.CreatedFrom = null;
                    command.CreatedTo = null;
                    command.ClientNames = new List<string> { invoice.ClientName };
                    command.StatusOperator = true;
                    command.ClientsOperator = true;
                    command.StatusValues = new List<int>() { Status.PAST_DUE.Value };
                    List<InvoiceData> pastDueInvoices = invoiceApiRepository.SearchInvoice(command);

                    try
                    {
                        string invoiceWordPath = GenerateDocument(invoice, pastDueInvoices, alsoGeneratePdf);

                        if (string.IsNullOrEmpty(invoiceWordPath))
                            return;

                        string invoicePdfPath = Path.ChangeExtension(invoiceWordPath, "pdf");
                        string invoicePath = alsoGeneratePdf ? invoicePdfPath : invoiceWordPath;
                        EmailInvoice(invoice, invoicePath, subject, isAutoSend);
                        PrintInvoice(invoice, invoiceWordPath, isAutoSend);
                        return;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex);
                    }
                    
                }
            }

            FormProgress formProgress = new FormProgress();
            formProgress.StartPosition = FormStartPosition.CenterScreen;
            List<object> arguments = new List<object>();
            arguments.Add(invoices);
            arguments.Add(alsoGeneratePdf);
            formProgress.Argument = arguments;

            if (isAutoSend)
            {
                formProgress.DoWork += new FormProgress.DoWorkEventHandler(autoEmailInvoices_DoWork);
            }
            else
            {
                formProgress.DoWork += new FormProgress.DoWorkEventHandler(emailInvoices_DoWork);
            }
            
            DialogResult result = formProgress.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Operation has been cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Abort)
            {
                MessageBox.Show("Exception:" + Environment.NewLine + formProgress.Result.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            formProgress = new FormProgress();
            formProgress.StartPosition = FormStartPosition.CenterScreen;
            formProgress.Argument = invoices;
            if (isAutoSend)
            {
                formProgress.DoWork += new FormProgress.DoWorkEventHandler(autoPrintInvoices_DoWork);
            }
            else
            {
                formProgress.DoWork += new FormProgress.DoWorkEventHandler(printInvoices_DoWork);
            }
            result = formProgress.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Operation has been cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (result == DialogResult.Abort)
            {
                MessageBox.Show("Exception:" + Environment.NewLine + formProgress.Result.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            olvInvoices.SetObjects(invoices);
        }

        private void emailInvoices_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;
            List<InvoiceData> invoices = (List<InvoiceData>)genericlist[0];
            var alsoGeneratePdf = (bool)genericlist[1];

            if (invoices.Count == 0)
                return;
            int numTotal = invoices.Count;
            int numProcessed = 0;

            // Search Past Due Invoice
            SearchInvoiceCommand command = new SearchInvoiceCommand();
            command.CreatedFrom = null;
            command.CreatedTo = null;
            command.ClientNames = invoices.Select(x => x.ClientName).ToList();
            command.StatusOperator = true;
            command.ClientsOperator = true;
            command.StatusValues = new List<int>() { Status.PAST_DUE.Value };
            List<InvoiceData> pastDueInvoices = invoiceApiRepository.SearchInvoice(command);

            invoices.OrderBy(x => x.ClientName).ThenBy(x => x.InvoiceNumber);

            foreach (InvoiceData invoice in invoices)
            {
                string invoiceWordPath = GenerateDocument(invoice, pastDueInvoices, alsoGeneratePdf);
                string invoicePdfPath = Path.ChangeExtension(invoiceWordPath, "pdf");
                string invoicePath = alsoGeneratePdf ? invoicePdfPath : invoiceWordPath;
                invoiceWordPaths[invoice.InvoiceId] = invoiceWordPath;
                invoicePdfPaths[invoice.InvoiceId] = invoicePdfPath;
                EmailInvoice(invoice, invoicePath, currentSubject);
                int percentage = (100 * numProcessed) / numTotal;
                string status = string.Format("Create email {0} of {1}", numProcessed, numTotal);
                sender.SetProgress(percentage, status);
                numProcessed++;
                if (sender.IsCancellation())
                    return;
            }
        }

        private void autoEmailInvoices_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;
            List<InvoiceData> invoices = (List<InvoiceData>)genericlist[0];
            var alsoGeneratePdf = (bool)genericlist[1];
            if (invoices.Count == 0)
                return;
            int numTotal = invoices.Count;
            int numProcessed = 0;

            // Search Past Due Invoice
            SearchInvoiceCommand command = new SearchInvoiceCommand();
            command.CreatedFrom = null;
            command.CreatedTo = null;
            command.ClientNames = invoices.Select(x => x.ClientName).ToList();
            command.StatusOperator = true;
            command.ClientsOperator = true;
            command.StatusValues = new List<int>() { Status.PAST_DUE.Value };
            List<InvoiceData> pastDueInvoices = invoiceApiRepository.SearchInvoice(command);

            invoices.OrderBy(x => x.ClientName).ThenBy(x => x.InvoiceNumber);

            foreach (InvoiceData invoice in invoices)
            {
                string invoiceWordPath = GenerateDocument(invoice, pastDueInvoices, alsoGeneratePdf);
                string invoicePdfPath = Path.ChangeExtension(invoiceWordPath, "pdf");
                string invoicePath = alsoGeneratePdf ? invoicePdfPath : invoiceWordPath;

                invoiceWordPaths[invoice.InvoiceId] = invoiceWordPath;
                invoicePdfPaths[invoice.InvoiceId] = invoicePdfPath;

                EmailInvoice(invoice, invoicePath, currentSubject, true);
                int percentage = (100 * numProcessed) / numTotal;
                string status = string.Format("Send Invoice Email {0} of {1}", numProcessed, numTotal);
                sender.SetProgress(percentage, status);
                numProcessed++;
                if (sender.IsCancellation())
                    return;
            }
        }

        private void printInvoices_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            List<InvoiceData> invoices = (List<InvoiceData>)sender.Argument;
            if (invoices.Count == 0)
                return;
            int numTotal = invoices.Count;
            int numProcessed = 0;

            // Search Past Due Invoice
            SearchInvoiceCommand command = new SearchInvoiceCommand();
            command.CreatedFrom = null;
            command.CreatedTo = null;
            command.ClientNames = invoices.Select(x => x.ClientName).ToList();
            command.StatusOperator = true;
            command.ClientsOperator = true;
            command.StatusValues = new List<int>() { Status.PAST_DUE.Value };
            List<InvoiceData> pastDueInvoices = invoiceApiRepository.SearchInvoice(command);

            invoices.OrderBy(x => x.ClientName).ThenBy(x => x.InvoiceNumber);

            foreach (InvoiceData invoice in invoices)
            {
                if (invoiceWordPaths.ContainsKey(invoice.InvoiceId))
                {
                    PrintInvoice(invoice, invoiceWordPaths[invoice.InvoiceId], true);
                }
                else
                {
                    string invoiceWordPath = GenerateDocument(invoice, pastDueInvoices, false);
                    PrintInvoice(invoice, invoiceWordPath, true);
                }
                int percentage = (100 * numProcessed) / numTotal;
                string status = string.Format("Create print {0} of {1}", numProcessed, numTotal);
                sender.SetProgress(percentage, status);
                numProcessed++;
                if (sender.IsCancellation())
                    return;
            }
        }

        private void autoPrintInvoices_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            List<InvoiceData> invoices = (List<InvoiceData>)sender.Argument;
            if (invoices.Count == 0)
                return;
            int numTotal = invoices.Count;
            int numProcessed = 0;

            // Search Past Due Invoice
            SearchInvoiceCommand command = new SearchInvoiceCommand();
            command.CreatedFrom = null;
            command.CreatedTo = null;
            command.ClientNames = invoices.Select(x => x.ClientName).ToList();
            command.StatusOperator = true;
            command.ClientsOperator = true;
            command.StatusValues = new List<int>() { Status.PAST_DUE.Value };
            List<InvoiceData> pastDueInvoices = invoiceApiRepository.SearchInvoice(command);

            invoices.OrderBy(x => x.ClientName).ThenBy(x => x.InvoiceNumber);

            foreach (InvoiceData invoice in invoices)
            {
                if(invoiceWordPaths.ContainsKey(invoice.InvoiceId))
                {
                    PrintInvoice(invoice, invoiceWordPaths[invoice.InvoiceId], true);
                }
                else
                {
                    string invoiceWordPath = GenerateDocument(invoice, pastDueInvoices, false);
                    PrintInvoice(invoice, invoiceWordPath, true);
                }               
                
                int percentage = (100 * numProcessed) / numTotal;
                string status = string.Format("Print Invoice {0} of {1}", numProcessed, numTotal);
                sender.SetProgress(percentage, status);
                numProcessed++;
                if (sender.IsCancellation())
                    return;
            }
        }

        private void FormBillingManager_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                SetAppCount(olvClients.Items.Count, olvInvoices.Items.Count, olvApplications.Items.Count);                
            }
        }

        public void PrintOrEmailDialogInvoice(InvoiceData invoice, PrintAppEventArgs.MainActionType actionType)
        {
            DocumentCompleteResult result = null;
            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
                return;
            try
            {
                using (new HourGlass())
                {
                    TemplateHelper templateHelper = new TemplateHelper();
                    string filename = WordTemplatePathResolver.GetTemplateFileName(WordDocumentType.Invoice);
                    if (!string.IsNullOrEmpty(filename))
                    {
                        string url = string.Format("api/templates");
                        string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.Invoice);
                        templateHelper.DownloadTemplate(templatePath, filename);
                    }

                    List<InvoiceItemData> invoiceItems = InvoiceItemCachedApiQuery.Instance.GetInvoiceItemsByInvoiceId(invoice.InvoiceId);
                    ClientApiRepository clientApiRepository = new ClientApiRepository();
                    ClientData client = clientApiRepository.FindByName(invoice.ClientName);

                    // Search Past Due Invoice
                    SearchInvoiceCommand command = new SearchInvoiceCommand();
                    command.CreatedFrom = null;
                    command.CreatedTo = null;
                    command.ClientNames = new List<string> { invoice.ClientName };
                    command.StatusOperator = true;
                    command.ClientsOperator = true;
                    command.StatusValues = new List<int>() { Status.PAST_DUE.Value };
                    List<InvoiceData> pastDueInvoices = invoiceApiRepository.SearchInvoice(command);

                    result = BuildInvoiceOpenXML(client, invoice, invoiceItems, pastDueInvoices);

                    if (result != null)
                    {

                        string defaultEmailTo = string.Empty;
                        string defaultClientName = string.Empty;
                        if (client != null)
                        {
                            defaultEmailTo = client.DefaultDeliverInvoicesTo;
                            defaultClientName = client.ClientName;
                        }

                        FormDocumentComplete dialog = new FormDocumentComplete("Invoice", result);
                        dialog.ConfirmEdit = false;
                        dialog.SetMainAction(actionType);
                        dialog.DefaultEmailTo = defaultEmailTo;
                        dialog.DefaultClientName = defaultClientName;
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result != null)
                    result.QuitWordDocument(false);
            }
        }

        public void PrintInvoicesByClientsPastDue(List<ClientData> clients)
        {
            try
            {
                List<ClientData> allClients = ClientCachedApiQuery.Instance.GetAllClients();
                TemplateHelper templateHelper = new TemplateHelper();
                string filename = WordTemplatePathResolver.GetTemplateFileName(WordDocumentType.InvoicesClientPastDue);
                if (!string.IsNullOrEmpty(filename))
                {
                    string url = string.Format("api/templates");
                    string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.InvoicesClientPastDue);
                    templateHelper.DownloadTemplate(templatePath, filename);
                }

                // search invoices
                SearchInvoiceCommand command = new SearchInvoiceCommand();
                command.CreatedFrom = null;
                command.CreatedTo = null;
                command.ClientNames = clients == null ? null : clients.Select(x => x.ClientName).ToList();
                command.StatusOperator = true;
                command.ClientsOperator = true;
                command.StatusValues = new List<int>() { Status.PAST_DUE.Value };
                List<InvoiceData> invoices = invoiceApiRepository.SearchInvoice(command);
                Dictionary<ClientData, List<InvoiceData>> invoicesByClient = new Dictionary<ClientData, List<InvoiceData>>();
                foreach (var invoice in invoices)
                {
                    ClientData client = allClients.Find(x => x.ClientName == invoice.ClientName);
                    if (client == null)
                        continue;

                    if (!invoicesByClient.ContainsKey(client))
                    {
                        invoicesByClient.Add(client, new List<InvoiceData>());
                        invoicesByClient[client].Add(invoice);
                    }
                    else
                    {
                        invoicesByClient[client].Add(invoice);
                    }
                }

                FormInvPrint formInvPrint = new FormInvPrint();
                formInvPrint.SetupPrinting(FormInvPrint.InvPrintType.ByClientPastDue, clients == null ? allClients : clients, null);
                formInvPrint.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                formInvPrint.Argument = invoicesByClient;
                formInvPrint.DoWork += new FormInvPrint.DoWorkEventHandler(PrintInvoicesByClientPastDue_DoWork);
                DialogResult result = formInvPrint.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Operation has been cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (result == DialogResult.Abort)
                {
                    MessageBox.Show("Exception:" + Environment.NewLine + formInvPrint.Result.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
            if (clients == null || clients.Count == 0)
                return;
        }

        private void printInvoices_DoWork(FormInvPrint sender, DoWorkEventArgs e)
        {
            List<InvoiceData> invoices = (List<InvoiceData>)sender.Argument;
            int numInvoice = invoices.Count;
            int numPrintedInvoice = 0;
            WordService word = null;

            if (invoices == null || invoices.Count == 0)
                return;

            // Search Past Due Invoice
            SearchInvoiceCommand command = new SearchInvoiceCommand();
            command.CreatedFrom = null;
            command.CreatedTo = null;
            command.ClientNames = invoices.Select(x => x.ClientName).ToList();
            command.StatusOperator = true;
            command.ClientsOperator = true;
            command.StatusValues = new List<int>() { Status.PAST_DUE.Value };
            List<InvoiceData> pastDueInvoices = invoiceApiRepository.SearchInvoice(command);
            List<ClientData> allClients = ClientCachedApiQuery.Instance.GetAllClients();

            foreach (InvoiceData invoice in invoices)
            {
                try
                {
                    int pecentage = (100 * numPrintedInvoice) / numInvoice;
                    string status = string.Format("Printing Invoice {0} of {1}: {2}", numPrintedInvoice, numInvoice, invoice.InvoiceNumber);
                    sender.SetProgress(pecentage, status);

                    List<InvoiceItemData> invoiceItems = InvoiceItemCachedApiQuery.Instance.GetInvoiceItemsByInvoiceId(invoice.InvoiceId);
                    ClientData client = allClients.Find(x => x.ClientName == invoice.ClientName);
                    string documentFile = GenerateDocumentInvoiceOpenXML(client, invoice, invoiceItems, pastDueInvoices);
                    word = new WordService(documentFile, "Invoice", false);
                    word.Print(sender.NumCopies);
                    InvoiceCalculationHelper.UpdateInvoiceActionStatus(invoice, ActionStatus.PRINTED);
                    word.Quit();
                    word = null;
                    numPrintedInvoice++;

                    if (sender.IsCancellation())
                        return;
                }
                catch (Exception ex)
                {
                    if (word != null)
                        word.Quit();
                    throw new Exception("There were errors when printing invoices");
                }
            }
        }

        private void PrintInvoicesByClientPastDue_DoWork(FormInvPrint sender, DoWorkEventArgs e)
        {
            Dictionary<ClientData, List<InvoiceData>> invoicesByClient = (Dictionary<ClientData, List<InvoiceData>>)sender.Argument;
            List<ClientData> clients = invoicesByClient.Keys.ToList();
            int numTotal = clients.Count;
            int numProcessed = 0;
            WordService word = null;
            foreach (var client in clients)
            {
                try
                {
                    List<InvoiceData> invoices = null;
                    if (invoicesByClient.TryGetValue(client, out invoices))
                    {
                        if (invoices == null)
                            continue;

                        int percentage = (100 * numProcessed) / numTotal;
                        string status = string.Format("Printing P/D Invoice For: {0}", client.ClientName);
                        sender.SetProgress(percentage, status);
                        string documentFile = GenerateDocumentInvoicesByClientPastDueOpenXML(client, invoices);
                        word = new WordService(documentFile, "P/D Invoice", false);
                        word.Print(sender.NumCopies);
                        word.Quit();
                        word = null;
                        numProcessed++;
                        if (sender.IsCancellation())
                            return;
                    }
                }
                catch (Exception ex)
                {
                    if (word != null)
                        word.Quit();
                    throw new Exception("There were errors when printing past due invoices");
                }
            }
        }

        public void PrintInvoices(List<InvoiceData> invoices)
        {
            try
            {
                TemplateHelper templateHelper = new TemplateHelper();
                string filename = WordTemplatePathResolver.GetTemplateFileName(WordDocumentType.Invoice);
                if (!string.IsNullOrEmpty(filename))
                {
                    string url = string.Format("api/templates");
                    string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.Invoice);
                    templateHelper.DownloadTemplate(templatePath, filename);
                }

                FormInvPrint formInvPrint = new FormInvPrint();
                formInvPrint.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                formInvPrint.SetupPrinting(FormInvPrint.InvPrintType.ByInvoice, null, invoices);
                formInvPrint.Argument = invoices;
                formInvPrint.DoWork += new FormInvPrint.DoWorkEventHandler(printInvoices_DoWork);
                DialogResult result = formInvPrint.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Operation has been cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (result == DialogResult.Abort)
                {
                    MessageBox.Show("Exception:" + Environment.NewLine + formInvPrint.Result.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
            if (invoices == null || invoices.Count == 0)
                return;
        }

        public void PrintOrEmailDialogInvoices(List<InvoiceData> invoices, PrintAppEventArgs.MainActionType actionType)
        {
            if (invoices == null || invoices.Count == 0)
                return;

            if (invoices.Count == 1)
            {
                PrintOrEmailDialogInvoice(invoices.FirstOrDefault(), actionType);
                return;
            }

            try
            {
                using (new HourGlass())
                {
                    ClientApiRepository clientApiRepository = new ClientApiRepository();
                    TemplateHelper templateHelper = new TemplateHelper();
                    string filename = WordTemplatePathResolver.GetTemplateFileName(WordDocumentType.Invoice);
                    if (!string.IsNullOrEmpty(filename))
                    {
                        string url = string.Format("api/templates");
                        string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.Invoice);
                        templateHelper.DownloadTemplate(templatePath, filename);
                    }

                    List<string> documents = new List<string>();

                    string defaultEmailTo = string.Empty;
                    string defaultClientName = string.Empty;
                    string defaultEmailTitle = string.Empty;

                    if (invoices.Count > 1)
                        defaultEmailTitle = "Bemrose Invoices";

                    // Search Past Due Invoice
                    SearchInvoiceCommand command = new SearchInvoiceCommand();
                    command.CreatedFrom = null;
                    command.CreatedTo = null;
                    command.ClientNames = invoices.Select(x => x.ClientName).ToList();
                    command.StatusOperator = true;
                    command.ClientsOperator = true;
                    command.StatusValues = new List<int>() { Status.PAST_DUE.Value };
                    List<InvoiceData> pastDueInvoices = invoiceApiRepository.SearchInvoice(command);

                    foreach (InvoiceData invoice in invoices)
                    {
                        List<InvoiceItemData> invoiceItems = InvoiceItemCachedApiQuery.Instance.GetInvoiceItemsByInvoiceId(invoice.InvoiceId);
                        ClientData client = clientApiRepository.FindByName(invoice.ClientName);
                        string documentFile = GenerateDocumentInvoiceOpenXML(client, invoice, invoiceItems, pastDueInvoices);
                        if (!string.IsNullOrEmpty(documentFile))
                        {
                            documents.Add(documentFile);
                        }
                        if (string.IsNullOrEmpty(defaultEmailTo))
                        {
                            if (client != null)
                            {
                                defaultEmailTo = client.DefaultDeliverInvoicesTo;
                                defaultClientName = client.ClientName;
                            }

                        }
                        if (string.IsNullOrEmpty(defaultEmailTitle))
                        {
                            defaultEmailTitle = "Bemrose Invoices for " + invoice.InvoiceDate.ToString("MM/yy");
                        }
                    }

                    if (documents.Count > 0)
                    {
                        FormMultipleDocumentComplete dialog = new FormMultipleDocumentComplete(defaultEmailTitle, documents, defaultEmailTo);
                        dialog.SetMainAction(actionType);
                        dialog.DefaultClientName = defaultClientName;
                        dialog.StartPosition = FormStartPosition.CenterScreen;
                        dialog.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Get selected data
        public List<string> GetListSelectedClient()
        {
            List<string> result = new List<string>();
            try
            {
                foreach (var clientData in olvClients.SelectedObjects)
                {
                    ClientData data = (ClientData)clientData;
                    result.Add(data.ClientId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _logger.Error(ex);
            }
            return result;
        }

        public List<AppData> GetListSelectedApps()
        {
            List<AppData> apps = new List<AppData>();
            foreach (AppData app in this.olvApplications.SelectedObjects)
            {
                if (!string.IsNullOrEmpty(app.ApplicationId))
                {
                    apps.Add(app);
                }
            }
            return apps;
        }

        public List<InvoiceData> GetListAllInvoices()
        {
            List<InvoiceData> invs = new List<InvoiceData>();

            if (this.olvInvoices.Objects == null || this.olvInvoices.GetItemCount() == 0)
            {
                return invs;
            }

            foreach (InvoiceData inv in this.olvInvoices.Objects)
            {
                if (inv != null && !string.IsNullOrEmpty(inv.InvoiceId))
                {
                    invs.Add(inv);
                }
            }

            return invs;
        }

        public List<InvoiceData> GetListSelectedInvs()
        {
            List<InvoiceData> invs = new List<InvoiceData>();
            foreach (InvoiceData inv in this.olvInvoices.SelectedObjects)
            {
                if (!string.IsNullOrEmpty(inv.InvoiceId))
                {
                    invs.Add(inv);
                }
            }
            return invs;
        }

        public List<AppData> GetListAllApps()
        {
            List<AppData> apps = new List<AppData>();

            if (this.olvApplications.Objects == null || this.olvApplications.GetItemCount() == 0)
            {
                return apps;
            }

            foreach (AppData app in this.olvApplications.Objects)
            {
                if (app != null && !string.IsNullOrEmpty(app.ApplicationId))
                {
                    apps.Add(app);
                }
            }

            return apps;
        }
        #endregion

        #region Context Menu
        private void toolAppDatagridSelectedApps_Click(object sender, EventArgs e)
        {
            FormAppDataGrid form = new FormAppDataGrid();

            if (form != null)
            {
                List<AppData> apps = this.GetListSelectedApps();

                form.SetApps(apps);
                form.BringToFront();
                form.Show();
            }
        }

        private void toolAppDatagridAllShownApps_Click(object sender, EventArgs e)
        {
            try
            {
                var frmAppDataGrid = new FormAppDataGrid();

                List<AppData> apps = this.GetListAllApps();

                frmAppDataGrid.SetApps(apps);
                frmAppDataGrid.BringToFront();
                frmAppDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void toolInvoiceDatagridSelectedInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                var frmDataGrid = new FormInvDatagrid();

                List<InvoiceData> invs = this.GetListSelectedInvs();

                frmDataGrid.SetInvs(invs);
                frmDataGrid.BringToFront();
                frmDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void toolInvoiceDatagridAllShownInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                var frmDataGrid = new FormInvDatagrid();

                List<InvoiceData> invs = this.GetListAllInvoices();

                frmDataGrid.SetInvs(invs);
                frmDataGrid.BringToFront();
                frmDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }


        private void toolInvoicePrint_Click(object sender, EventArgs e)
        {
            List<InvoiceData> invoices = GetListSelectedInvs();
            PrintInvoices(invoices);
        }

        private void toolAppDelete_Click(object sender, EventArgs e)
        {
            AppData app = (AppData)olvApplications.SelectedObject;

            if (app != null)
            {
                formMaster.RemoveAppFromInvoicing(app);
                this.olvApplications.RemoveObject(app);
            }
        }

        private void toolClientDatagridAllClients_Click(object sender, EventArgs e)
        {
            try
            {
                FormClientDataGrid formClientDataGrid = new FormClientDataGrid();
                formClientDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void toolClientDatagridSelectedClients_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lstClientIds = this.GetListSelectedClient();
                FormClientDataGrid formClientDataGrid = new FormClientDataGrid(lstClientIds);
                formClientDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void toolClientPrintInvOfPastDues_Click(object sender, EventArgs e)
        {
            List<ClientData> clients = this.GetListSelectedClients();
            PrintInvoicesByClientsPastDue(clients);
        }
        #endregion

        #region Click Handler
        private void SearchInvoicesClickHandler(object sender, EventArgs e)
        {

            if (formSearchInvs == null)
            {
                if (this == null)
                {
                    return;
                }

                formSearchInvs = new FormSearchInvs(this);
                formSearchInvs.TopLevel = false;
                this.Controls.Add(formSearchInvs);
                formList.Add(formSearchInvs);

                formSearchInvs.OnSearchInvoices += new EventHandler<List<InvoiceData>>(delegate(object delegateSender, List<InvoiceData> data)
                {
                    SetOLVInvoices(data, null);
                });
            }
            if (!formSearchInvs.Visible)
            {
                uInvoicingRibbon.InitializeSearchForm(formSearchInvs);
                formSearchInvs.Show();
            }
            else
            {
                formSearchInvs.Hide();
            }
        }
        private void SearchApplicationsClickHandler(object sender, EventArgs e)
        {
            if (formInvSearchApp == null)
            {
                if (this == null)
                {
                    return;
                }

                formInvSearchApp = new FormInvSearchApps(this);
                formInvSearchApp.TopLevel = false;
                this.Controls.Add(formInvSearchApp);
                formList.Add(formInvSearchApp);

                formInvSearchApp.OnSearchApps += new EventHandler<List<AppData>>(delegate(object delegateSender, List<AppData> data)
                {
                    SetOLVApplications(data, null);
                });
            }
            if (!formInvSearchApp.Visible)
            {
                uInvoicingRibbon.InitializeSearchForm(formInvSearchApp);
                formInvSearchApp.Show();
            }
            else
            {
                formInvSearchApp.Hide();
            }
        }
        private void BillingMonthDoubleClickHandler(object sender, EventArgs e)
        {
            uInvoicingRibbon.CloseBillingMonthDropDown();

            if (this == null)
            {
                return;
            }

            formAutoBilling = new FormAutomaticBilling(this);
            formAutoBilling.StartPosition = FormStartPosition.CenterParent;
            formAutoBilling.BringToFront();
            formAutoBilling.ShowDialog();            
        }
        private void DgAllClientsClickHandler(object sender, EventArgs e)
        {
            try
            {
                FormClientDataGrid formClientDataGrid = new FormClientDataGrid();
                formClientDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }
        private void DgSelectedClientsClickHandler(object sender, EventArgs e)
        {
            if (this != null)
            {
                List<string> selectClients = GetListSelectedClient();
                FormClientDataGrid formClientDataGrid = new FormClientDataGrid(selectClients);
                formClientDataGrid.Show();
            }
        }
        private void DgAllShownInvoicesClickHandler(object sender, EventArgs e)
        {
            try
            {
                FormInvDatagrid formDatagrid = new FormInvDatagrid();

                if (this != null)
                {
                    List<InvoiceData> invs = GetListAllInvoices();

                    formDatagrid.SetInvs(invs);
                    formDatagrid.BringToFront();
                    formDatagrid.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }
        private void DgSelectedInvoicesClickHandler(object sender, EventArgs e)
        {
            try
            {
                FormInvDatagrid formDatagrid = new FormInvDatagrid();

                if (this != null)
                {
                    List<InvoiceData> invs = GetListSelectedInvs();

                    formDatagrid.SetInvs(invs);
                    formDatagrid.BringToFront();
                    formDatagrid.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }
        private void DgAllShownAppsClickHandler(object sender, EventArgs e)
        {
            try
            {
                if (this != null)
                {
                    List<AppData> apps = GetListAllApps();
                    if (_frmAppDataGrid.IsDisposed)
                    {
                        _frmAppDataGrid = new FormAppDataGrid();
                    }
                    _frmAppDataGrid.SetApps(apps);
                    _frmAppDataGrid.BringToFront();
                    _frmAppDataGrid.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }
        private void DgSelectedAppsClickHandler(object sender, EventArgs e)
        {
            if (this != null)
            {
                List<AppData> apps = GetListSelectedApps();

                if (_frmAppDataGrid.IsDisposed)
                {
                    _frmAppDataGrid = new FormAppDataGrid();
                }
                _frmAppDataGrid.SetApps(apps);
                _frmAppDataGrid.BringToFront();
                _frmAppDataGrid.Show();
            }
        }
        private async void InvoicePrintMenuDoubleClickHandler(object sender, EventArgs e)
        {
            OutlookService outlook = new OutlookService();
            uInvoicingRibbon.CloseInvPrintMenuDropDown();

            if (this != null)
            {
                formInvShipping = new FormInvShipping(this);
                formInvShipping.StartPosition = FormStartPosition.CenterParent;
                formInvShipping.BringToFront();
                formInvShipping.ShowDialog();
            }

            await Task.Delay(4000);
            outlook.SetNull();
        }
        private void PrtClientCommonClickHandler(object sender, EventArgs e)
        {
            RibbonButton button = sender as System.Windows.Forms.RibbonButton;
            WordDocumentType documentType = uInvoicingRibbon.GetDocType(button);
            try
            {
                if (this != null)
                {
                    List<ClientData> clients = GetListSelectedClients();
                    using (new HourGlass())
                    {
                        foreach (ClientData client in clients)
                        {
                            formMaster.CommonPrintDocument(documentType, client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PrtSelectedInvoicesClickHandler(object sender, EventArgs e)
        {
            if (this != null)
            {
                List<ClientData> clients = GetListSelectedClients();
                PrintInvoicesByClientsPastDue(clients);
            }
        }
        private void PrtAllInvoicesClickHandler(object sender, EventArgs e)
        {
            if (this != null)
            {
                PrintInvoicesByClientsPastDue(null);
            }
        }
        private void PrtAllShownInvsClickHandler(object sender, EventArgs e)
        {
            if (this != null)
            {
                List<InvoiceData> invoices = GetListAllInvoices();
                PrintInvoices(invoices);
            }
        }

        private void PrtSelectedInvsClickHandler(object sender, EventArgs e)
        {
            if (this != null)
            {
                List<InvoiceData> invoices = GetListSelectedInvs();
                PrintInvoices(invoices);
            }
        }

        private void RefreshInvoiceClickHandler(object sender, EventArgs e)
        {
            if (this != null)
            {
                using (new HourGlass())
                {
                    formMaster.RefreshData();
                    LoadClients();
                }
            }
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    using (new HourGlass())
                    {
                        formMaster.RefreshData();
                        this.LoadClients();
                    }
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void FormBillingManager_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            try
            {
                // Hide it instead.
                this.Hide();
                // Prevent the form from closing.
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        private void pdfToolEmailInvoice_Click(object sender, EventArgs e)
        {
            List<InvoiceData> invoices = GetListSelectedInvs();
            EmailAndPrintInvoices(invoices, "", false, true);
        }

        private void wordToolEmailInvoice_Click(object sender, EventArgs e)
        {
            List<InvoiceData> invoices = GetListSelectedInvs();
            EmailAndPrintInvoices(invoices, "", false, false);
        }
    }
}
