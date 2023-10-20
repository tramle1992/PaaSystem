using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoice.Application.Data;
using PaaApplication.Forms.Invoicing;
using Invoice.Infrastructure;
using Common.Infrastructure.UI;
using System.Globalization;
using Invoice.Domain.Model;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using Common.Infrastructure.OLV;
using Core.Infrastructure.ExploreApps;
using Core.Application.Command.ExploreApps;
using Core.Application.Data.ExploreApps;
using PaaApplication.Helper;
using PaaApplication.Models.AppExplore;
using Invoice.Application.Helper;

namespace PaaApplication.UserControls.Invoicing
{
    public partial class InvDetailControl : UserControl
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static InvoiceApiRepository invoiceApiRepository = new InvoiceApiRepository();
        private static InvoiceItemApiRepository invoiceItemApiRepository = new InvoiceItemApiRepository();
        private string[] reportTypeNames;
        private InvoiceData currentInvoice; // Dont have reference to parent form
        private bool inGetAvailableApp = false;

        private const string defaultInvoiceItemApplicationId = "";
        private const string defaultInvoiceItemName = "Res1";
        private const decimal defaultInvoiceItemUnitPrice = 35;

        public InvDetailControl()
        {
            InitializeComponent();
        }

        private void InvoiceDetailControl_Load(object sender, EventArgs e)
        {
            InitObjectListView();
            LoadReportTypes();
        }

        private void InitObjectListView()
        {
            this.olvColUnitPrice.AspectToStringConverter = delegate(object aspect)
            {
                return ((decimal)aspect).ToString("N", CultureInfo.CurrentUICulture);
            };
        }

        private void LoadReportTypes()
        {
            List<ReportTypeData> reportTypes = ReportTypeCachedApiQuery.Instance.GetAllReportTypes();
            if (reportTypes != null && reportTypes.Count > 0)
            {
                this.reportTypeNames = new string[reportTypes.Count];
                for (int i = 0; i < reportTypes.Count; i++)
                {
                    this.reportTypeNames[i] = reportTypes[i].TypeName;
                }
            }
            else
            {
                this.reportTypeNames = new string[0];
            }
        }

        public void SetCurrentInvoice(InvoiceData invoice)
        {
            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
            {
                return;
            }

            this.currentInvoice = AutoMapper.Mapper.Map<InvoiceData, InvoiceData>(invoice);
            SetDataToControls(this.currentInvoice, null);
        }

        private void UpdateInvoice(InvoiceData invoice)
        {
            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
            {
                return;
            }

            using (new HourGlass())
            {
                invoiceApiRepository.Update(invoice);
                FormBillingManager formBillingManager = (FormBillingManager)this.ParentForm;
                formBillingManager.UpdateItemOLVInvoices(invoice);
            }
        }

        public void SetDataToControls(InvoiceData invoice, InvoiceItemData selectedInvoiceItem)
        {
            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
            {
                ClearDataInControls();
                SetEnabledControls(false);
                return;
            }

            SetEnabledControls(true);

            using (new HourGlass())
            {
                DateTime invoiceDateLocal = invoice.InvoiceDate.ToLocalTime();
                DateTime billingFrom = new DateTime(invoiceDateLocal.Year, invoiceDateLocal.Month, 1).Date;
                DateTime billingTo = billingFrom.AddMonths(1).AddSeconds(-5);

                this.txtSoldTo.Text = invoice.SoldToClientName ?? string.Empty;
                this.lblInvNumValue.Text = invoice.InvoiceNumber.ToString();
                this.lblBillingCycleValue.Text = billingFrom.ToString("MM/dd/yyyy") + " - " + billingTo.ToString("MM/dd/yyyy");
                this.txtReference.Text = invoice.InvoiceReference ?? string.Empty;
                this.txtCustID.Text = invoice.CustomerNumber ?? string.Empty;
                this.txtCustPO.Text = invoice.PONumber ?? string.Empty;
                this.txtPaymentTerms.Text = "Upon Receipt";
                this.txtDueDate.Text = InvoiceCalculationHelper.GetDueDate(invoiceDateLocal)
                                        .ToString("MM/dd/yyyy"); // LocalTime
                this.txtInvComment.Text = invoice.InvoiceComments ?? string.Empty;
                this.lblInvTotalValue.Text = invoice.Amount.ToString("N", CultureInfo.CurrentUICulture);
                this.lblPaymentTotalValue.Text = InvoiceCalculationHelper
                    .GetTotalPaidAmount(invoice.InvoiceId).ToString("N", CultureInfo.CurrentUICulture);
                if (invoice.Status != null)
                {
                    this.lblInvInterest.Visible = true;
                    this.lblInvInterestValue.Visible = true;
                    this.lblInvBalance.Visible = true;
                    this.lblInvBalanceValue.Visible = true;
                    if (invoice.Status.Value == Status.PAST_DUE.Value)
                    {
                        decimal interest = InvoiceCalculationHelper.GetInterest(invoice);
                        this.lblInvInterestValue.Text = interest.ToString("N", CultureInfo.CurrentUICulture);
                        //decimal total = invoice.Balance + interest;
                        decimal total = invoice.Balance;
                        this.lblInvBalanceValue.Text = "$" + total.ToString("N", CultureInfo.CurrentUICulture);
                    }
                    else
                    {
                        this.lblInvInterestValue.Text = "0";
                        this.lblInvBalanceValue.Text = "$" + invoice.Balance.ToString("N", CultureInfo.CurrentUICulture);
                    }
                }
                else
                {
                    this.lblInvInterest.Visible = false;
                    this.lblInvInterestValue.Visible = false;
                    this.lblInvBalance.Visible = false;
                    this.lblInvBalanceValue.Visible = false;
                }

                List<InvoiceItemData> invoiceItems = InvoiceItemCachedApiQuery.Instance.GetInvoiceItemsByInvoiceId(invoice.InvoiceId);
                SetOLVInvoiceItems(invoiceItems, selectedInvoiceItem);
            }
        }

        public void ClearDataInControls()
        {
            this.currentInvoice = null;

            this.txtSoldTo.Clear();
            this.lblInvNumValue.Text = string.Empty;
            this.lblBillingCycleValue.Text = string.Empty;
            this.txtReference.Clear();
            this.txtCustID.Clear();
            this.txtCustPO.Clear();
            this.txtPaymentTerms.Clear();
            this.txtDueDate.Clear();
            this.txtInvComment.Clear();
            //this.lblInvTotalValue.Text = string.Empty;
            this.lblInvTotalValue.Text = "0.00";
            //this.lblPaymentTotalValue.Text = string.Empty;
            this.lblPaymentTotalValue.Text = "0.00";

            //this.lblInvInterest.Visible = false;
            //this.lblInvInterestValue.Visible = false;
            //this.lblInvInterestValue.Text = string.Empty;
            this.lblInvInterestValue.Text = "0";
            //this.lblInvBalance.Visible = false;
            //this.lblInvBalanceValue.Visible = false;
            //this.lblInvBalanceValue.Text = string.Empty;
            this.lblInvBalanceValue.Text = "$0.00";

            this.txtSearchInvItem.Clear();
            this.olvInvoiceItems.ClearObjects();
        }

        public void SetEnabledControls(bool enabled)
        {
            this.txtSoldTo.Enabled = enabled;
            this.lblInvNumValue.Enabled = enabled;
            this.lblBillingCycleValue.Enabled = enabled;
            this.txtReference.Enabled = enabled;
            this.txtCustID.Enabled = enabled;
            this.txtCustPO.Enabled = enabled;
            this.txtPaymentTerms.Enabled = enabled;
            this.txtDueDate.Enabled = enabled;
            this.txtInvComment.Enabled = enabled;
            this.lblInvTotalValue.Enabled = enabled;
            this.lblPaymentTotalValue.Enabled = enabled;
            this.lblInvInterestValue.Enabled = enabled;
            this.lblInvBalanceValue.Enabled = enabled;
            this.txtSearchInvItem.Enabled = enabled;
            this.olvInvoiceItems.Enabled = enabled;
            this.btnPrintInv.Enabled = enabled;
        }

        #region OLV InvoiceItems
        public void SetOLVInvoiceItems(List<InvoiceItemData> invoiceItems, InvoiceItemData selectedInvoiceItem)
        {
            if (invoiceItems == null || invoiceItems.Count == 0)
            {
                this.olvInvoiceItems.ClearObjects();
                return;
            }

            this.olvInvoiceItems.SetObjects(invoiceItems);

            if (selectedInvoiceItem == null || string.IsNullOrEmpty(selectedInvoiceItem.InvoiceItemId) ||
                string.IsNullOrEmpty(selectedInvoiceItem.InvoiceId))
            {
                this.olvInvoiceItems.SelectedIndex = 0;
                this.olvInvoiceItems.EnsureVisible(0);
                return;
            }

            for (int i = 0; i < this.olvInvoiceItems.Items.Count; i++)
            {
                InvoiceItemData item = (InvoiceItemData)this.olvInvoiceItems.GetModelObject(i);
                if (item != null && !string.IsNullOrEmpty(item.InvoiceItemId) &&
                    !string.IsNullOrEmpty(item.InvoiceId) && item.InvoiceItemId.Equals(selectedInvoiceItem.InvoiceItemId))
                {
                    this.olvInvoiceItems.SelectedIndex = i;
                    this.olvInvoiceItems.EnsureVisible(i);
                    break;
                }
            }
        }

        private void olvInvoiceItems_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            int index = this.olvInvoiceItems.Columns.IndexOf(this.olvColNum);
            if (index >= 0)
            {
                e.Item.SubItems[index].Text = (e.DisplayIndex + 1).ToString();
            }
        }

        private void olvInvoiceItems_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            InvoiceItemData invoiceItem = e.RowObject as InvoiceItemData;
            if (invoiceItem == null)
            {
                e.Cancel = true;
                return;
            }

            if (e.Column == this.olvColItem)
            {
                ComboBox cboControl = new ComboBox();
                cboControl.Bounds = e.CellBounds;
                cboControl.DropDownStyle = ComboBoxStyle.DropDown;
                cboControl.Items.AddRange(this.reportTypeNames);
                int index = Array.IndexOf(this.reportTypeNames, e.Value);
                cboControl.SelectedIndex = index > 0 ? index : 0;
                e.Control = cboControl;
            }
            else if (e.Column == this.olvColDesc && this.inGetAvailableApp)
            {
                using (new HourGlass())
                {
                    FormBillingManager formBillingManager = (FormBillingManager)this.ParentForm;
                    List<AvailableAppData> availableApps =
                        formBillingManager.GetAvailableAppData(this.currentInvoice.ClientName,
                            this.currentInvoice.InvoiceDivision,
                            this.currentInvoice.InvoiceDate.ToLocalTime(), true);
                    ComboBox cboControl = new ComboBox();
                    cboControl.Bounds = e.CellBounds;
                    cboControl.DropDownStyle = ComboBoxStyle.DropDown;
                    cboControl.ValueMember = "ApplicationId";
                    cboControl.DisplayMember = "InvoiceItemDescription";
                    if (availableApps != null && availableApps.Count > 0)
                    {
                        foreach (AvailableAppData availableApp in availableApps)
                        {
                            cboControl.Items.Add(availableApp);
                        }
                    }
                    e.Control = cboControl;
                }
            }
            else if (e.Column == this.olvColUnitPrice)
            {
                NumericUpDown nudControl = new NumericUpDown();
                nudControl.Bounds = e.CellBounds;
                nudControl.Minimum = 0;
                nudControl.Maximum = decimal.MaxValue;
                nudControl.DecimalPlaces = 2;
                nudControl.Increment = decimal.Parse("0.5");
                nudControl.Value = decimal.Parse(e.Value.ToString());
                e.Control = nudControl;
            }
        }

        private void olvInvoiceItems_CellEditValidating(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            InvoiceItemData invoiceItem = e.RowObject as InvoiceItemData;
            if (invoiceItem == null)
            {
                e.Cancel = true;
                return;
            }

            string oldValue;
            string newValue;
            bool updateInvoiceItem = false;
            bool updateInvoice = false;

            if (e.Column == this.olvColItem)
            {
                oldValue = e.Value.ToString();
                newValue = ((ComboBox)e.Control).Text.Trim();
                if (string.IsNullOrEmpty(newValue))
                {
                    MessageBox.Show("Item Name cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                else if (newValue.Length > 255)
                {
                    MessageBox.Show("Item Name cannot be longer than 255 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                else if (!oldValue.Equals(newValue))
                {
                    FormBillingManager formBillingManager = (FormBillingManager)this.ParentForm;
                    invoiceItem.Name = newValue;
                    invoiceItem.UnitPrice = formBillingManager.GetInvoiceItemUnitPrice(invoiceItem.Name, this.currentInvoice.ClientName);

                    updateInvoiceItem = true;
                    updateInvoice = true;
                }
            }
            else if (e.Column == this.olvColDesc)
            {
                if (this.inGetAvailableApp)
                {
                    AvailableAppData selectedAvailableApp = ((ComboBox)e.Control).SelectedItem as AvailableAppData;
                    if (selectedAvailableApp == null)
                    {
                        invoiceItem.Name = defaultInvoiceItemName;
                        invoiceItem.Description = string.Empty;
                        invoiceItem.UnitPrice = defaultInvoiceItemUnitPrice;
                    }
                    else
                    {
                        string applicationId = selectedAvailableApp.ApplicationId;
                        bool isExistedApplicationId = false;
                        List<InvoiceItemData> existedInvoiceItems = InvoiceItemCachedApiQuery.Instance
                                                                .GetInvoiceItemsByInvoiceId(this.currentInvoice.InvoiceId);
                        if (existedInvoiceItems != null && existedInvoiceItems.Count > 0)
                        {
                            foreach (InvoiceItemData existedInvoiceItem in existedInvoiceItems)
                            {
                                if (!string.IsNullOrEmpty(existedInvoiceItem.ApplicationId)
                                    && existedInvoiceItem.ApplicationId.Equals(applicationId))
                                {
                                    isExistedApplicationId = true;
                                    break;
                                }
                            }
                        }

                        if (isExistedApplicationId)
                        {
                            invoiceItem.ApplicationId = defaultInvoiceItemApplicationId;
                        }
                        else
                        {
                            invoiceItem.ApplicationId = applicationId;
                        }
                        invoiceItem.Name = selectedAvailableApp.ReportTypeName;
                        invoiceItem.Description = selectedAvailableApp.InvoiceItemDescription;
                        invoiceItem.UnitPrice = selectedAvailableApp.InvoiceItemUnitPrice;
                    }
                    updateInvoiceItem = true;
                    updateInvoice = true;
                }
                else
                {
                    oldValue = e.Value.ToString();
                    newValue = e.NewValue.ToString().Trim();
                    if (newValue.Length > 600)
                    {
                        MessageBox.Show("Description cannot be longer than 600 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (!oldValue.Equals(newValue))
                    {
                        invoiceItem.Description = newValue;
                        updateInvoiceItem = true;
                    }
                }
            }
            else if (e.Column == this.olvColUnitPrice)
            {
                oldValue = e.Value.ToString();
                newValue = e.NewValue.ToString();
                if (!oldValue.Equals(newValue))
                {
                    invoiceItem.UnitPrice = ((NumericUpDown)e.Control).Value;
                    updateInvoiceItem = true;
                    updateInvoice = true;
                }
            }

            if (updateInvoiceItem)
            {
                using (new HourGlass())
                {
                    invoiceItemApiRepository.Update(invoiceItem);
                    UpdateInvoiceItemCompleted(invoiceItem, updateInvoice);
                }
            }
        }

        private void olvInvoiceItems_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            InvoiceItemData invoiceItem = e.RowObject as InvoiceItemData;
            if (invoiceItem == null)
            {
                return;
            }

            if (!e.Cancel)
            {
                this.olvInvoiceItems.RefreshObject(invoiceItem);
                e.Cancel = true;
            }

            this.inGetAvailableApp = false;
        }

        public void CancelCellEdit()
        {
            this.olvInvoiceItems.CancelCellEdit();
        }
        #endregion

        private void AddNewInvoiceItem(int insertIndex)
        {
            InvoiceItemData invoiceItem = new InvoiceItemData();
            invoiceItem.InvoiceItemId = Guid.NewGuid().ToString();
            invoiceItem.InvoiceId = this.currentInvoice.InvoiceId;
            invoiceItem.ApplicationId = defaultInvoiceItemApplicationId;
            invoiceItem.Name = defaultInvoiceItemName;
            invoiceItem.Description = string.Empty;
            invoiceItem.UnitPrice = defaultInvoiceItemUnitPrice;

            using (new HourGlass())
            {
                string newId = invoiceItemApiRepository.Add(invoiceItem);
                if (!string.IsNullOrEmpty(newId))
                {
                    AddInvoiceItemCompleted(invoiceItem);
                }
                else
                {
                    MessageBox.Show("Error when add new invoice item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddInvoiceItemCompleted(InvoiceItemData invoiceItem)
        {
            if (invoiceItem == null || string.IsNullOrEmpty(invoiceItem.InvoiceItemId)
                || string.IsNullOrEmpty(invoiceItem.InvoiceId))
            {
                return;
            }

            InvoiceItemCachedApiQuery.Instance.RemoveInvoiceItemsByInvoiceId(invoiceItem.InvoiceId);

            FormBillingManager formBillingManager = (FormBillingManager)this.ParentForm;
            bool success = InvoiceCalculationHelper.UpdateInvoiceStatus(this.currentInvoice);
            if (success)
            {
                formBillingManager.UpdateItemOLVInvoices(this.currentInvoice);
            }
            // UpdateInvoiceStatus has reference, so we can use this.currentInvoice to set data to controls
            SetDataToControls(this.currentInvoice, invoiceItem);
        }

        private void UpdateInvoiceItemCompleted(InvoiceItemData invoiceItem, bool updateInvoice)
        {
            if (invoiceItem == null || string.IsNullOrEmpty(invoiceItem.InvoiceItemId)
                || string.IsNullOrEmpty(invoiceItem.InvoiceId))
            {
                return;
            }

            InvoiceItemCachedApiQuery.Instance.RemoveInvoiceItemsByInvoiceId(invoiceItem.InvoiceId);

            if (updateInvoice)
            {
                FormBillingManager formBillingManager = (FormBillingManager)this.ParentForm;
                bool success = InvoiceCalculationHelper.UpdateInvoiceStatus(this.currentInvoice);
                if (success)
                {
                    formBillingManager.UpdateItemOLVInvoices(this.currentInvoice);
                }
            }
            // UpdateInvoiceStatus has reference, so we can use this.currentInvoice to set data to controls
            SetDataToControls(this.currentInvoice, invoiceItem);
        }

        private void RemoveInvoiceItemCompleted(InvoiceItemData invoiceItem)
        {
            if (invoiceItem == null || string.IsNullOrEmpty(invoiceItem.InvoiceItemId)
                || string.IsNullOrEmpty(invoiceItem.InvoiceId))
            {
                return;
            }

            InvoiceItemCachedApiQuery.Instance.RemoveInvoiceItemsByInvoiceId(invoiceItem.InvoiceId);

            FormBillingManager formBillingManager = (FormBillingManager)this.ParentForm;
            bool success = InvoiceCalculationHelper.UpdateInvoiceStatus(this.currentInvoice);
            if (success)
            {
                formBillingManager.UpdateItemOLVInvoices(this.currentInvoice);
            }
            // UpdateInvoiceStatus has reference, so we can use this.currentInvoice to set data to controls
            SetDataToControls(this.currentInvoice, null);
        }

        #region Context Menu
        private void cmnuInvoiceItems_Opening(object sender, CancelEventArgs e)
        {
            InvoiceItemData selectedInvoiceItem = this.olvInvoiceItems.SelectedObject as InvoiceItemData;
            if (selectedInvoiceItem == null || string.IsNullOrEmpty(selectedInvoiceItem.InvoiceItemId)
                || string.IsNullOrEmpty(selectedInvoiceItem.InvoiceId))
            {
                this.toolShowAvailableApps.Enabled = false;
                this.toolDeleteThisItem.Enabled = false;
            }
            else
            {
                this.toolShowAvailableApps.Enabled = true;
                this.toolDeleteThisItem.Enabled = true;
            }
        }

        private void toolShowAvailableApps_Click(object sender, EventArgs e)
        {
            InvoiceItemData selectedInvoiceItem = this.olvInvoiceItems.SelectedObject as InvoiceItemData;
            if (selectedInvoiceItem == null || string.IsNullOrEmpty(selectedInvoiceItem.InvoiceItemId)
                || string.IsNullOrEmpty(selectedInvoiceItem.InvoiceId))
            {
                return;
            }

            this.inGetAvailableApp = true;
            this.olvInvoiceItems.EditSubItem(this.olvInvoiceItems.GetItem(this.olvInvoiceItems.SelectedIndex), 2);
        }

        private void toolInsertItem_Click(object sender, EventArgs e)
        {
            int insertIndex = this.olvInvoiceItems.Items.Count;
            AddNewInvoiceItem(insertIndex);
        }

        private void toolDeleteThisItem_Click(object sender, EventArgs e)
        {
            InvoiceItemData selectedInvoiceItem = this.olvInvoiceItems.SelectedObject as InvoiceItemData;
            if (selectedInvoiceItem == null || string.IsNullOrEmpty(selectedInvoiceItem.InvoiceItemId)
                || string.IsNullOrEmpty(selectedInvoiceItem.InvoiceId))
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete item \"" + selectedInvoiceItem.Name + "\"?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (new HourGlass())
                {
                    invoiceItemApiRepository.Remove(selectedInvoiceItem);
                    RemoveInvoiceItemCompleted(selectedInvoiceItem);
                }
            }
        }
        #endregion

        #region Validating Controls
        private void txtSoldTo_Validating(object sender, CancelEventArgs e)
        {
            this.currentInvoice.SoldToClientName = this.txtSoldTo.Text.Trim();
            UpdateInvoice(this.currentInvoice);
        }

        private void txtReference_Validating(object sender, CancelEventArgs e)
        {
            this.currentInvoice.InvoiceReference = this.txtReference.Text.Trim();
            UpdateInvoice(this.currentInvoice);
        }

        private void txtCustPO_Validating(object sender, CancelEventArgs e)
        {
            this.currentInvoice.PONumber = this.txtCustPO.Text.Trim();
            UpdateInvoice(this.currentInvoice);
        }

        private void txtInvComment_Validating(object sender, CancelEventArgs e)
        {
            this.currentInvoice.InvoiceComments = this.txtInvComment.Text.Trim();
            UpdateInvoice(this.currentInvoice);
        }
        #endregion

        #region Search
        private void txtSearchInvItem_KeyUp(object sender, KeyEventArgs e)
        {
            string strSearch = this.txtSearchInvItem.Text.Trim();
            bool filter = false;

            if (e.KeyCode == Keys.Back && strSearch.Length == 0)
            {
                strSearch = string.Empty;
                new ObjectListViewService().FilterOlv(this.olvInvoiceItems, strSearch);
                filter = true;
            }
            else if (e.KeyCode == Keys.Enter && strSearch.Length > 0)
            {
                new ObjectListViewService().FilterOlv(this.olvInvoiceItems, strSearch);
                filter = true;
            }

            if (filter)
            {
            }
        }
        #endregion

        private void btnPrintInv_Click(object sender, EventArgs e)
        {
            FormBillingManager formBillingManager = (FormBillingManager)this.ParentForm;
            if (formBillingManager != null)
            {
                formBillingManager.PrintOrEmailDialogInvoice(this.currentInvoice, PrintAppEventArgs.MainActionType.Print);
            }
        }

        private void olvInvoiceItems_ModelCanDrop(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        {
            List<AppData> apps = e.SourceModels.Cast<AppData>().ToList();
            if (apps == null)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void olvInvoiceItems_ModelDropped(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        {
            if (e.SourceModels == null)
                return;

            var reportTypeCacheApiQuery = ReportTypeCachedApiQuery.Instance;
            var clientCacheApiQuery = ClientCachedApiQuery.Instance;
            FormBillingManager formBillingManager = (FormBillingManager)this.ParentForm;
            List<InvoiceItemData> invoiceItems = new List<InvoiceItemData>();

            // Change the dropped people plus the target person to be married

            try
            {
                foreach (AppData app in e.SourceModels)
                {
                    AvailableAppData availableApp = new AvailableAppData();
                    availableApp.ApplicationId = app.ApplicationId;
                    availableApp.ReportTypeName = app.ReportTypeName;
                    availableApp.InvoiceItemDescription = InvoiceCalculationHelper.GetInvoiceItemDescription(app);
                    var reportType = reportTypeCacheApiQuery.GetReportType(app.ReportTypeId);
                    var client = clientCacheApiQuery.GetClient(app.ClientApplied);
                    availableApp.InvoiceItemUnitPrice = InvoiceCalculationHelper.GetInvoiceItemUnitPrice(reportType, client);

                    InvoiceItemData invoiceItem = new InvoiceItemData();
                    invoiceItem.InvoiceItemId = Guid.NewGuid().ToString();
                    invoiceItem.InvoiceId = this.currentInvoice.InvoiceId; // Temporary
                    invoiceItem.ApplicationId = availableApp.ApplicationId;
                    invoiceItem.Name = availableApp.ReportTypeName;
                    invoiceItem.Description = availableApp.InvoiceItemDescription;
                    invoiceItem.UnitPrice = availableApp.InvoiceItemUnitPrice;

                    invoiceItems.Add(invoiceItem);
                }

                InvoiceItemApiRepository invoiceItemApiRepository = new InvoiceItemApiRepository();
                invoiceItemApiRepository.MultiAddInvoiceItems(invoiceItems);
                InvoiceItemCachedApiQuery.Instance.RemoveInvoiceItemsByInvoiceId(this.currentInvoice.InvoiceId);
                bool success = InvoiceCalculationHelper.UpdateInvoiceStatus(this.currentInvoice);
                if (success)
                {
                    formBillingManager.UpdateItemOLVInvoices(this.currentInvoice);
                    SetDataToControls(this.currentInvoice, null);
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            // Force them to refresh
            
        }
    }
}
