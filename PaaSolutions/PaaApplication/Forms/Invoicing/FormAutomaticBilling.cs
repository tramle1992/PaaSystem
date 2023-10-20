using Common.Infrastructure.UI;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using Core.Infrastructure.ClientInfo;
using Core.Infrastructure.ExploreApps;
using Invoice.Application.Data;
using Invoice.Application.Helper;
using Invoice.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.Invoicing
{
    public partial class FormAutomaticBilling : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private InvoiceItemApiRepository invoiceItemApiRepository = new InvoiceItemApiRepository();

        private FormBillingManager formBillingManager;
        public FormMaster formMaster;

        private List<AppData> listApps = new List<AppData>();
        int lastCreatedInvoiceNumber = -1;

        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        //private ManualResetEvent manualResetEvent = new ManualResetEvent(false);

        private List<InvoiceData> newInvoiceList = new List<InvoiceData>();

        public FormAutomaticBilling(FormBillingManager formBillingManager)
        {
            InitializeComponent();
            this.formBillingManager = formBillingManager;
            this.formMaster = formBillingManager.formMaster;

            // BackgroundWorker
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        private void FormAutomaticBilling_Load(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                try
                {
                    DateTime billingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
                    this.lblMonth.Text = billingMonth.ToString("MM/yyyy");
                    this.btnBillApps.Text = "Bill " + billingMonth.ToString("MM/yyyy") + " Apps";

                    List<InvoiceData> allInvoicesInMonth = InvoiceCachedApiQuery.Instance.
                        GetInvoicesByYearAndMonth(billingMonth.Year, billingMonth.Month);
                    List<InvoiceData> invoices = new List<InvoiceData>();
                    if (allInvoicesInMonth != null && allInvoicesInMonth.Count > 0)
                    {
                        invoices = allInvoicesInMonth.FindAll(r => r.Balance > 0);
                    }

                    if (invoices != null && invoices.Count > 0)
                    {
                        this.chkFoundBalances.Checked = false;
                        this.chkFoundBalances.Visible = true;
                        this.btnBillApps.Enabled = false;
                    }
                    else
                    {
                        this.chkFoundBalances.Visible = false;
                        this.btnBillApps.Enabled = true;
                    }

                    DateTime firstDayOfBillingMonth = new DateTime(billingMonth.Year, billingMonth.Month, 1);
                    DateTime firstDayOfCurrentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    if ((firstDayOfBillingMonth - firstDayOfCurrentMonth).TotalDays >= 0)
                    {
                        this.chkMonthIncomplete.Checked = false;
                        this.chkMonthIncomplete.Visible = true;
                        this.btnBillApps.Enabled = false;
                    }
                    else
                    {
                        this.chkMonthIncomplete.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void FormAutomaticBilling_LoadCompleted(object sender, EventArgs e)
        {
        }

        private void btnBillApps_Click(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    this.formMaster.LoadDataAsync().Wait();
                }

                List<ClientData> clients = this.formMaster.LIST_CLIENTS;
                if (clients == null || clients.Count == 0)
                {
                    this.Close();
                    this.formBillingManager.toolAppBillingValidation_Click(null, null);
                    return;
                }

                this.proBillingPercentage.Value = 0;
                this.proBillingPercentage.Minimum = 0;
                this.proBillingPercentage.Maximum = clients.Count;

                DateTime billingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
                List<InvoiceData> allInvoicesInMonth = InvoiceCachedApiQuery.Instance.
                    GetInvoicesByYearAndMonth(billingMonth.Year, billingMonth.Month);

                if (allInvoicesInMonth != null && allInvoicesInMonth.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        allInvoicesInMonth.Count
                        + " Invoice(s) appear to have already been billed for "
                        + billingMonth.ToString("MM/yyyy") + ".\n\n"
                        + "Continuing with this action will create or append as necessary "
                        + "to bill all applications from this month.\n\n"
                        + "Continue?",
                        "Confirm Auto-Billing for " + billingMonth.ToString("MM/yyyy"),
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                        this.formBillingManager.toolAppBillingValidation_Click(null, null);
                        return;
                    }
                }

                this.tabStep.SelectedTab = this.tabPageInProgress;
                this.formBillingManager.SetOLVInvoices(null, null);

                // Resume progress
                //this.manualResetEvent.Set();
                if (!this.backgroundWorker.IsBusy)
                {
                    lastCreatedInvoiceNumber = -1;
                    this.backgroundWorker.RunWorkerAsync(clients);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            listApps = formBillingManager.formMaster.LIST_APPS_FOR_INVOICE;
            List<ClientData> clients = (List<ClientData>)e.Argument;
            for (int i = 0; i < clients.Count; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                // Pause progress
                //this.manualResetEvent.WaitOne();

                try
                {
                    ISet<InvoiceDivisionData> clientInvoiceDivisions = clients[i].InvoiceDivisions;
                    if (clientInvoiceDivisions != null && clientInvoiceDivisions.Count > 0)
                    {
                        ISet<string> invoiceDivisions = new HashSet<string>();
                        // Fix bug exist in old application
                        invoiceDivisions.Add(string.Empty);
                        foreach (InvoiceDivisionData invoiceDivision in clientInvoiceDivisions)
                        {
                            if (invoiceDivision == null || invoiceDivision.DivisionName == null)
                            {
                                continue;
                            }
                            invoiceDivisions.Add(invoiceDivision.DivisionName.Trim());
                        }

                        foreach (string invoiceDivision in invoiceDivisions)
                        {
                            BillAppsForClient(worker, clients[i], invoiceDivision);
                        }
                    }
                    else
                    {
                        BillAppsForClient(worker, clients[i], string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("backgroundWorker_DoWork: " + ex.ToString());
                }

                worker.ReportProgress(i / clients.Count);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.proBillingPercentage.Value < this.proBillingPercentage.Maximum)
                this.proBillingPercentage.Value += 1;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int numInvoice = this.newInvoiceList.Count;
            lastCreatedInvoiceNumber = -1;
            DateTime billingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
            string message = string.Format("{0} Invoice(s) have been ready to send and print for {1}.\n\n", numInvoice, billingMonth.ToString("MM/yyyy"));
            DialogResult result = MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            this.formBillingManager.toolAppBillingValidation_Click(this, null);
        }

        private void BillAppsForClient(BackgroundWorker worker, ClientData client, string invoiceDivision)
        {
            if (client == null
                || string.IsNullOrEmpty(client.ClientName)
                || invoiceDivision == null)
            {
                return;
            }

            BeginInvoke((MethodInvoker)delegate
            {
                this.lblBillingAppsFor.Text = "Billing Applications for: " + client.ClientName;
                if (invoiceDivision.Length > 0)
                {
                    this.lblBillingAppsFor.Text += "\nBilling Invoice Division: ";
                    this.lblBillingAppsFor.Text += invoiceDivision;
                }
            });

            DateTime billingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime

            List<AvailableAppData> availableApps = null;
            try
            {
                availableApps = this.formBillingManager
                                    .GetAvailableAppData(client.ClientName, invoiceDivision, billingMonth, true, client);
            }
            catch (Exception ex)
            {
                _logger.Error("BillAppsForClient: " + ex.ToString());
                return;
            }

            if (availableApps == null || availableApps.Count == 0)
            {
                return;
            }

            List<InvoiceData> allInvoicesInMonth = null;
            try
            {
                allInvoicesInMonth = InvoiceCachedApiQuery.Instance.
                    GetInvoicesByYearAndMonth(billingMonth.Year, billingMonth.Month);
            }
            catch (Exception ex)
            {
                _logger.Error("BillAppsForClient: " + ex.ToString());
            }

            List<InvoiceData> invoices = null;
            if (allInvoicesInMonth != null && allInvoicesInMonth.Count > 0)
            {
                invoices = allInvoicesInMonth.FindAll(r => (r.ClientName != null &&
                                                            r.ClientName.Equals(client.ClientName)));
            }

            List<InvoiceItemData> invoiceItems = new List<InvoiceItemData>();
            foreach (AvailableAppData availableApp in availableApps)
            {

                var app = listApps.Where(a => a.ApplicationId == availableApp.ApplicationId).FirstOrDefault();

                //Only create Invoice if Client Invoice Division is Empty and App Invoice Division is Empty
                //or if Client Invoice Division is not Empty and App Invoice Division is not Empty and App Invoice Division is not "(None)"
                if(app != null && ((client.InvoiceDivisions.Count == 0 && string.IsNullOrEmpty(app.InvoiceDivision)) 
                    || (!string.IsNullOrEmpty(app.InvoiceDivision) && !app.InvoiceDivision.Equals("(None)") && !string.IsNullOrEmpty(invoiceDivision))))
                {
                    InvoiceItemData invoiceItem = new InvoiceItemData();
                    invoiceItem.InvoiceItemId = Guid.NewGuid().ToString();
                    invoiceItem.InvoiceId = "0"; // Temporary
                    invoiceItem.ApplicationId = availableApp.ApplicationId;
                    invoiceItem.Name = availableApp.ReportTypeName;
                    invoiceItem.Description = availableApp.InvoiceItemDescription;
                    invoiceItem.UnitPrice = availableApp.InvoiceItemUnitPrice;
                    invoiceItems.Add(invoiceItem);
                }
            }

            bool found = false;
            if (invoices != null && invoices.Count > 0)
            {
                foreach (InvoiceData invoice in invoices)
                {
                    if (invoice.InvoiceDivision != null
                        && !invoice.InvoiceDivision.Equals(invoiceDivision))
                    {
                        continue;
                    }
                    foreach (InvoiceItemData invoiceItem in invoiceItems)
                    {
                        invoiceItem.InvoiceId = invoice.InvoiceId;
                    }
                    try
                    {
                        invoiceItemApiRepository.MultiAddInvoiceItems(invoiceItems);
                        InvoiceItemCachedApiQuery.Instance.RemoveInvoiceItemsByInvoiceId(invoice.InvoiceId);
                        bool success = InvoiceCalculationHelper.UpdateInvoiceStatus(invoice);
                        if (success)
                        {
                            this.formBillingManager.UpdateItemOLVInvoices(invoice);
                            this.newInvoiceList.Add(AutoMapper.Mapper.Map<InvoiceData, InvoiceData>(invoice));
                            found = true;
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("BillAppsForClient: " + ex.ToString());
                        invoiceItemApiRepository.MultiRemoveInvoiceItems(invoiceItems);
                        return;
                    }
                }
            }

            if (!found)
            {
                try
                {
                    // Using UTC when create Invoice
                    InvoiceData newInvoice = this.formBillingManager.CreateInvoice(client, invoiceDivision,
                                                            billingMonth, invoiceItems, true, lastCreatedInvoiceNumber);
                    if (newInvoice != null && !string.IsNullOrEmpty(newInvoice.InvoiceId))
                    {
                        lastCreatedInvoiceNumber = newInvoice.InvoiceNumber;
                        foreach (InvoiceItemData invoiceItem in invoiceItems)
                        {
                            invoiceItem.InvoiceId = newInvoice.InvoiceId;
                        }
                        invoiceItemApiRepository.MultiAddInvoiceItems(invoiceItems);
                        InvoiceItemCachedApiQuery.Instance.RemoveInvoiceItemsByInvoiceId(newInvoice.InvoiceId);
                        this.newInvoiceList.Add(AutoMapper.Mapper.Map<InvoiceData, InvoiceData>(newInvoice));
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("BillAppsForClient: " + ex.ToString());
                    return;
                }
            }
        }

        private void chkIncompleteAndFound_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == this.chkMonthIncomplete)
            {
                if (this.chkFoundBalances.Visible)
                {
                    this.btnBillApps.Enabled = cb.Checked && this.chkFoundBalances.Checked;
                }
                else
                {
                    this.btnBillApps.Enabled = cb.Checked;
                }
            }
            else // cb == this.chkFoundBalances
            {
                if (this.chkMonthIncomplete.Visible)
                {
                    this.btnBillApps.Enabled = cb.Checked && this.chkMonthIncomplete.Checked;
                }
                else
                {
                    this.btnBillApps.Enabled = cb.Checked;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker.WorkerSupportsCancellation)
            {
                this.backgroundWorker.CancelAsync();
            }

            this.Close();

        }

        private void btnCancelProgress_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker.WorkerSupportsCancellation)
            {
                this.backgroundWorker.CancelAsync();
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            FormAutomaticBillingDetail formAutomaticBillingDetail = new FormAutomaticBillingDetail();
            formAutomaticBillingDetail.StartPosition = FormStartPosition.CenterParent;
            formAutomaticBillingDetail.ShowDialog();
        }
    }
}
