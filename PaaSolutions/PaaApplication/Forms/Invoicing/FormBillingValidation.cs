using BrightIdeasSoftware;
using Common.Infrastructure.UI;
using Core.Application.Command.ExploreApps;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using Core.Infrastructure.ClientInfo;
using Core.Infrastructure.ExploreApps;
using Invoice.Application.Data;
using Invoice.Application.Helper;
using Invoice.Infrastructure;
using NodaTime;
using PaaApplication.Helper;
using PaaApplication.Models;
using PaaApplication.Models.AppExplore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.Invoicing
{
    public partial class FormBillingValidation : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static InvoiceApiRepository invoiceApiRepository = new InvoiceApiRepository();
        private static InvoiceItemApiRepository invoiceItemApiRepository = new InvoiceItemApiRepository();
        private static AppApiRepository appApiRepository = new AppApiRepository();

        private FormBillingManager formBillingManager;

        private BackgroundWorker backgroundWorker = new BackgroundWorker();

        public FormBillingValidation(FormBillingManager formBillingManager)
        {
            InitializeComponent();
            this.formBillingManager = formBillingManager;

            EventBus.Subscribe(e =>
            {
                if (e is SavedAppEventArgs && e != null && ((SavedAppEventArgs)e).App != null)
                {
                    SavedAppEventHandler(((SavedAppEventArgs)e).App);
                }
            });

            // BackgroundWorker
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        private void FormBillingValidation_Load(object sender, EventArgs e)
        {
            InitObjectListView();

            DateTime billingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
            this.Text = "Application Billing Validation " + billingMonth.ToString("MM/yyyy");
            lblTitle.Text = "Application Billing Validation " + billingMonth.ToString("MM/yyyy");
            AnalyzingBilling(billingMonth);
        }

        private void SavedAppEventHandler(AppData savedApp)
        {
            List<AppData> apps = this.olvApps.Objects.Cast<AppData>().ToList();
            if (apps == null || apps.Count == 0 || savedApp == null)
            {
                return;
            }

            foreach (AppData app in apps)
            {
                if (app.ApplicationId == savedApp.ApplicationId)
                {
                    AutoMapper.Mapper.Map<AppData, AppData>(savedApp, app);
                }
            }

            foreach (AppData app in this.formBillingManager.formMaster.LIST_APPS_FOR_INVOICE)
            {
                if (app.ApplicationId == savedApp.ApplicationId)
                {
                    AutoMapper.Mapper.Map<AppData, AppData>(savedApp, app);
                }
            }
        }

        private void InitObjectListView()
        {
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

            this.olvColStatus.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    return UnbilledReason(app);
                }
                return "";
            };
        }

        public void SetOLVApps(List<AppData> apps, AppData selectedApp)
        {
            if (apps == null || apps.Count == 0)
            {
                this.olvApps.ClearObjects();
                return;
            }

            this.olvApps.SetObjects(apps);

            if (selectedApp == null || string.IsNullOrEmpty(selectedApp.ApplicationId))
            {
                this.olvApps.SelectedIndex = 0;
                this.olvApps.EnsureVisible(0);
                return;
            }

            for (int i = 0; i < this.olvApps.Items.Count; i++)
            {
                AppData item = (AppData)this.olvApps.GetModelObject(i);
                if (item != null && !string.IsNullOrEmpty(item.ApplicationId) &&
                    item.ApplicationId.Equals(selectedApp.ApplicationId))
                {
                    this.olvApps.SelectedIndex = i;
                    this.olvApps.EnsureVisible(i);
                    break;
                }
            }
        }

        public void SetEnabledControls(bool enabled)
        {
            //this.rdoAllAppsAppearToBeBilled.Enabled = enabled;
            //this.rdoSomeAppsAppearNotToBeBilled.Enabled = enabled;
            this.btnBillAllApps.Enabled = enabled;
            this.btnBillSelectedApps.Enabled = enabled;
            this.btnEditApps.Enabled = enabled;
            this.btnViewInvoices.Enabled = enabled;
            this.olvApps.Enabled = enabled;
        }

        private void AnalyzingBilling(DateTime billingMonth) // billingMonth is LocalTime
        {
            this.grpAnalyzingBilling.Visible = true;
            this.grpAnalyzingBilling.BringToFront();
            this.proAnalyzePercentage.Value = 0;
            this.olvApps.ClearObjects();
            SetEnabledControls(false);

            DateTime receivedFrom = new DateTime(billingMonth.Year, billingMonth.Month, 1).Date.ToUniversalTime();
            DateTime receivedTo = new DateTime(billingMonth.Year, billingMonth.Month, 1).Date.AddMonths(1).AddSeconds(-5);

            List<AppData> apps = this.formBillingManager.formMaster.LIST_APPS_FOR_INVOICE.FindAll(r =>
                                    (r != null && !string.IsNullOrEmpty(r.ApplicationId)
                                    && (r.ReceivedDate >= receivedFrom && r.ReceivedDate <= receivedTo)));

            if (apps != null && apps.Count > 0)
            {
                this.proAnalyzePercentage.Maximum = apps.Count;
                if (!this.backgroundWorker.IsBusy)
                {
                    this.backgroundWorker.RunWorkerAsync(apps);
                }
            }
            else
            {
                this.proAnalyzePercentage.Maximum = 1;
                this.proAnalyzePercentage.Value = 1;
                this.backgroundWorker.ReportProgress(1);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            List<AppData> apps = (List<AppData>)e.Argument;
            if (apps == null || apps.Count == 0)
            {
                worker.ReportProgress(1);
                return;
            }

            for (int i = 0; i < apps.Count; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                try
                {
                    ReportTypeData reportType = ReportTypeCachedApiQuery.Instance.GetReportType(apps[i].ReportTypeId);
                    string applicationName = Utils.GetApplicantName(apps[i], reportType);
                    int invoiceNumber = 0;
                    if (!InvoiceCalculationHelper.CheckIfAppIsBilled(apps[i].ApplicationId, applicationName, apps[i].ClientAppliedName, apps[i].ClientApplied,
                        apps[i].InvoiceDivision, apps[i].ReceivedDate, out invoiceNumber))
                    {
                        this.olvApps.AddObject(apps[i]);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("backgroundWorker_DoWork: " + ex.ToString());
                }

                worker.ReportProgress(i / apps.Count);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.proAnalyzePercentage.Value < this.proAnalyzePercentage.Maximum)
            {
                this.proAnalyzePercentage.Value += 1;
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.proAnalyzePercentage.Visible = false;
            this.grpAnalyzingBilling.Visible = false;
            SetEnabledControls(true);

            DateTime billingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
            ShowBillingStats(billingMonth);

            if (this.olvApps.Items.Count > 0)
            {
                this.rdoSomeAppsAppearNotToBeBilled.Checked = true;
            }
            else
            {
                this.rdoAllAppsAppearToBeBilled.Checked = true;
            }
        }

        private string UnbilledReason(AppData app)
        {
            string reason = string.Empty;
            ClientData client = this.formBillingManager.formMaster.LIST_CLIENTS
                                    .Find(r => (r != null
                                                && !string.IsNullOrEmpty(r.ClientName)
                                                && !string.IsNullOrEmpty(app.ClientAppliedName)
                                                && r.ClientName.Equals(app.ClientAppliedName)));
            if (client == null || string.IsNullOrEmpty(client.ClientId))
            {
                reason = "Invalid Client Name";
            }
            else
            {
                // Assume that app.InvoiceDivision is not null
                if (app.InvoiceDivision.Equals("(None)"))
                {
                    reason = "Invalid Inv. Division";
                }
                else
                {
                    if (client.InvoiceDivisions != null && client.InvoiceDivisions.Count > 0)
                    {
                        if (app.InvoiceDivision.Length == 0)
                        {
                            reason = "Missing Inv. Division";
                        }
                        else
                        {
                            bool found = false;
                            foreach (InvoiceDivisionData invoiceDivision in client.InvoiceDivisions)
                            {
                                if (invoiceDivision != null
                                    && !string.IsNullOrEmpty(invoiceDivision.DivisionName)
                                    && app.InvoiceDivision.Equals(invoiceDivision.DivisionName))
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                reason = "Billable";
                            }
                            else
                            {
                                reason = "Invalid Inv. Division";
                            }
                        }
                    }
                    else
                    {
                        if (app.InvoiceDivision.Length > 0)
                        {
                            reason = "Invalid Inv. Division";
                        }
                        else
                        {
                            reason = "Billable";
                        }
                    }
                }
            }

            return reason;
        }

        private void ShowBillingStats(DateTime billingMonth) // billingMonth is LocalTime
        {
            this.txtTotalInvs.Text = string.Empty;
            this.txtTotalVolumn.Text = string.Empty;
            this.txtLargestInv.Text = string.Empty;
            this.txtAvgRevenuePerApp.Text = string.Empty;
            this.txtAvgInvAmount.Text = string.Empty;
            this.txtSmallestInv.Text = string.Empty;

            DateTime receivedFrom = new DateTime(billingMonth.Year, billingMonth.Month, 1).Date.ToUniversalTime();
            DateTime receivedTo = new DateTime(billingMonth.Year, billingMonth.Month, 1).AddMonths(1).AddSeconds(-5).ToUniversalTime();
            InvCountAppByReceivedDateCommand command = new InvCountAppByReceivedDateCommand();
            command.ReceivedFrom = receivedFrom;
            command.ReceivedTo = receivedTo;
            int appCount = appApiRepository.InvCountAppByReceivedDate(command);
            if (appCount < 0)
            {
                appCount = 0;
            }

            DateTimeZone tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();
            BillingValidationStatsData data
                = invoiceApiRepository.FindBillingValidationStats(billingMonth.ToUniversalTime().Year,
                                                                    billingMonth.ToUniversalTime().Month, tz.Id);
            this.txtTotalInvs.Text = data.TotalInvs.ToString();
            this.txtTotalVolumn.Text = "$" + data.TotalVolumn.ToString("N", CultureInfo.CurrentUICulture);
            this.txtLargestInv.Text = "$" + data.LargestInv.ToString("N", CultureInfo.CurrentUICulture);
            this.txtAvgRevenuePerApp.Text = "$" + (data.TotalVolumn / appCount).ToString("N", CultureInfo.CurrentUICulture);
            this.txtAvgInvAmount.Text = "$" + data.AvgInvAmount.ToString("N", CultureInfo.CurrentUICulture);
            this.txtSmallestInv.Text = "$" + data.SmallestInv.ToString("N", CultureInfo.CurrentUICulture);
        }

        private void BillApps(List<AppData> apps)
        {
            if (apps == null || apps.Count == 0)
            {
                return;
            }

            List<AppData> appsWillBeRemoved = new List<AppData>();
            foreach (AppData app in apps)
            {
                if (string.IsNullOrEmpty(app.ApplicationId)
                    || (!string.IsNullOrEmpty(app.InvoiceDivision) && app.InvoiceDivision.Equals("(None)")))
                {
                    continue;
                }

                ClientData client = this.formBillingManager.formMaster.LIST_CLIENTS
                                        .Find(r => (r != null
                                                    && !string.IsNullOrEmpty(r.ClientName)
                                                    && !string.IsNullOrEmpty(app.ClientAppliedName)
                                                    && r.ClientName.Equals(app.ClientAppliedName)));

                if (client == null || string.IsNullOrEmpty(client.ClientId))
                {
                    continue;
                }

                // Assume that app.InvoiceDivision is not null
                if (client.InvoiceDivisions != null && client.InvoiceDivisions.Count > 0)
                {
                    if (app.InvoiceDivision.Length != 0)
                    {
                        foreach (InvoiceDivisionData invoiceDivision in client.InvoiceDivisions)
                        {
                            if (invoiceDivision != null
                                && !string.IsNullOrEmpty(invoiceDivision.DivisionName)
                                && app.InvoiceDivision.Equals(invoiceDivision.DivisionName))
                            {
                                AutoBillApp(app, client);
                                appsWillBeRemoved.Add(app);
                                break;
                            }
                        }
                    }
                }
                else if (app.InvoiceDivision.Length == 0)
                {
                    AutoBillApp(app, client);
                    appsWillBeRemoved.Add(app);
                }
            }

            if (appsWillBeRemoved.Count > 0)
            {
                this.olvApps.RemoveObjects(appsWillBeRemoved);
            }

            if (this.olvApps.Items.Count == 0)
            {
                this.rdoAllAppsAppearToBeBilled.Checked = true;
            }

            DateTime billingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
            ShowBillingStats(billingMonth);
        }

        private void AutoBillApp(AppData app, ClientData client)
        {
            if (app == null
                || string.IsNullOrEmpty(app.ApplicationId)
                || app.ReceivedDate == null || !app.ReceivedDate.HasValue)
            {
                return;
            }

            string appInvoiceDivision = app.InvoiceDivision;
            if (appInvoiceDivision == null || appInvoiceDivision.Equals("(None)"))
            {
                //appInvoiceDivision = string.Empty;
                return;
            }

            InvoiceItemData invoiceItem = new InvoiceItemData();
            invoiceItem.InvoiceItemId = Guid.NewGuid().ToString();
            invoiceItem.InvoiceId = "0"; // Temporary
            invoiceItem.ApplicationId = app.ApplicationId;
            invoiceItem.Name = app.ReportTypeName;
            invoiceItem.Description = InvoiceCalculationHelper.GetInvoiceItemDescription(app);
            invoiceItem.UnitPrice = this.formBillingManager
                                            .GetInvoiceItemUnitPrice(app.ReportTypeName, app.ClientAppliedName);

            List<InvoiceData> allInvoicesInMonth = null;
            try
            {
                allInvoicesInMonth = InvoiceCachedApiQuery.Instance.
                    GetInvoicesByYearAndMonth(app.ReceivedDate.Value.Year, app.ReceivedDate.Value.Month);
            }
            catch (Exception ex)
            {
                _logger.Error("AutoBillApp: " + ex.ToString());
            }

            List<InvoiceData> invoices = null;
            if (allInvoicesInMonth != null && allInvoicesInMonth.Count > 0)
            {
                invoices = allInvoicesInMonth.FindAll(r => (r.ClientName != null &&
                                                            r.ClientName.Equals(app.ClientAppliedName)));
            }

            bool found = false;
            if (invoices != null && invoices.Count > 0)
            {
                foreach (InvoiceData invoice in invoices)
                {
                    if (!invoice.InvoiceDivision.Equals(appInvoiceDivision))
                    {
                        continue;
                    }
                    invoiceItem.InvoiceId = invoice.InvoiceId;
                    try
                    {
                        invoiceItemApiRepository.Add(invoiceItem);
                        InvoiceItemCachedApiQuery.Instance.RemoveInvoiceItemsByInvoiceId(invoice.InvoiceId);
                        bool success = InvoiceCalculationHelper.UpdateInvoiceStatus(invoice);
                        if (success)
                        {
                            this.formBillingManager.UpdateItemOLVInvoices(invoice);
                            found = true;
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex.ToString());
                        invoiceItemApiRepository.Remove(invoiceItem);
                        return;
                    }
                }
            }

            if (!found)
            {
                try
                {
                    List<InvoiceItemData> invoiceItems = new List<InvoiceItemData>(1);
                    invoiceItems.Add(invoiceItem);

                    InvoiceData newInvoice = this.formBillingManager.CreateInvoice(client, appInvoiceDivision,
                                                            app.ReceivedDate.Value, invoiceItems, true);
                    if (newInvoice != null && !string.IsNullOrEmpty(newInvoice.InvoiceId))
                    {
                        invoiceItem.InvoiceId = newInvoice.InvoiceId;
                        invoiceItemApiRepository.Add(invoiceItem);
                        InvoiceItemCachedApiQuery.Instance.RemoveInvoiceItemsByInvoiceId(newInvoice.InvoiceId);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("AutoBillApp: " + ex.ToString());
                    return;
                }
            }
        }

        private void rdoBillApps_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == this.rdoSomeAppsAppearNotToBeBilled && rb.Checked)
            {
                SetEnabledControls(true);
            }
            else
            {
                SetEnabledControls(false);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorker.WorkerSupportsCancellation)
            {
                this.backgroundWorker.CancelAsync();
            }

            this.Close();
        }

        private void btnBillAllApps_Click(object sender, EventArgs e)
        {
            if (this.olvApps.Items.Count == 0)
            {
                return;
            }

            List<AppData> apps = this.olvApps.Objects.Cast<AppData>().ToList();
            if (apps == null || apps.Count == 0)
            {
                return;
            }

            BillApps(apps);
        }

        private void btnBillSelectedApps_Click(object sender, EventArgs e)
        {
            List<AppData> selectedApps = new List<AppData>();
            foreach (AppData item in this.olvApps.SelectedObjects)
            {
                selectedApps.Add(item);
            }

            if (selectedApps == null || selectedApps.Count == 0)
            {
                return;
            }

            BillApps(selectedApps);
        }

        private void btnViewInvoices_Click(object sender, EventArgs e)
        {
            List<AppData> apps = new List<AppData>();
            foreach (AppData app in olvApps.SelectedObjects)
            {
                apps.Add(app);
            }

            var inputCount = apps.Count;
            if (apps == null)
            {
                return;
            }

            DateTime billingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
            List<InvoiceData> allInvoicesInMonth = null;
            try
            {
                allInvoicesInMonth = InvoiceCachedApiQuery.Instance.
                                            GetInvoicesByYearAndMonth(billingMonth.Year,
                                                                        billingMonth.Month);
            }
            catch (Exception ex)
            {
                _logger.Error("btnViewInvoices_Click: " + ex.ToString());
                return;
            }

            List<InvoiceData> viewInvoices = new List<InvoiceData>();

            foreach (AppData app in apps)
            {
                string invoiceDivision = app.InvoiceDivision;
                if (invoiceDivision == null || invoiceDivision.Equals("(None)"))
                {
                    invoiceDivision = string.Empty;
                }

                List<InvoiceData> invoices = null;
                if (allInvoicesInMonth != null && allInvoicesInMonth.Count > 0)
                {
                    invoices = allInvoicesInMonth.FindAll(r => (r.ClientName != null &&
                                                                r.ClientName.Equals(app.ClientAppliedName)));
                }

                if (invoices != null && invoices.Count > 0 && invoiceDivision.Length > 0)
                {
                    invoices = invoices.FindAll(r => (!string.IsNullOrEmpty(r.InvoiceDivision)
                                                        && r.InvoiceDivision.Equals(invoiceDivision)));
                }

                if (invoices == null)
                {
                    invoices = new List<InvoiceData>();
                }



                viewInvoices.AddRange(invoices);
            }

            this.formBillingManager.SetOLVInvoices(viewInvoices, null);

            if (viewInvoices.Count == 0 && inputCount == 1)
            {
                var app = apps[0];
                MessageBox.Show("No Invoices found for " + app.ClientAppliedName +
                                " during " + billingMonth.ToString("MM/yyyy") + ".",
                                "No Invoices Found!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else if (viewInvoices.Count == 1)
            {
                this.formBillingManager.ShowInvoice(viewInvoices[0]);
            }
            else
            {
                this.formBillingManager.Focus();
            }
        }

        private void btnEditApps_Click(object sender, EventArgs e)
        {
            List<AppData> apps = new List<AppData>();
            List<string> appIds = new List<string>();
            foreach (AppData app in olvApps.SelectedObjects)
            {
                apps.Add(app);
                appIds.Add(app.ApplicationId);
            }
            if (apps == null || apps.Count == 0)
            {
                return;
            }

            EventBus.Publish(new EditAppsEventArgs(appIds));
        }
    }
}
