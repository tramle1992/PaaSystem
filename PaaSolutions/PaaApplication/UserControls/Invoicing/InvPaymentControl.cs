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
using Common.Infrastructure.UI;
using Invoice.Infrastructure;
using System.Globalization;
using PaaApplication.Forms.Invoicing;
using Invoice.Application.Helper;

namespace PaaApplication.UserControls.Invoicing
{
    public partial class InvPaymentControl : UserControl
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private PaymentApiRepository paymentApiRepository = new PaymentApiRepository();
        private InvoiceData currentInvoice; // Dont have reference to parent form

        public InvPaymentControl()
        {
            InitializeComponent();
            InitObjectListView();
        }

        private void InvPaymentControl_Load(object sender, EventArgs e)
        {
        }

        private void InitObjectListView()
        {
            this.olvColDelete.ImageGetter = delegate(object row)
            {
                return 0;
            };

            this.olvColAmount.AspectToStringConverter = delegate(object aspect)
            {
                return ((decimal)aspect).ToString("N", CultureInfo.CurrentUICulture);
            };

            this.olvColDate.AspectToStringConverter = delegate(object aspect)
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

        private void SetDataToControls(InvoiceData invoice, PaymentData selectedPayment)
        {
            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
            {
                ClearDataInControls();
                return;
            }

            using (new HourGlass())
            {
                List<PaymentData> payments = PaymentCachedApiQuery.Instance.GetPaymentsByInvoiceId(invoice.InvoiceId);
                SetOLVPayments(payments, selectedPayment);
            }
        }

        public void ClearDataInControls()
        {
            this.currentInvoice = null;
            this.olvPayments.ClearObjects();
        }

        #region OLV Payments
        public void SetOLVPayments(List<PaymentData> payments, PaymentData selectedPayment)
        {
            if (payments == null || payments.Count == 0)
            {
                this.olvPayments.ClearObjects();
                return;
            }

            this.olvPayments.SetObjects(payments);

            if (selectedPayment == null || string.IsNullOrEmpty(selectedPayment.PaymentId) ||
                string.IsNullOrEmpty(selectedPayment.InvoiceId))
            {
                this.olvPayments.SelectedIndex = 0;
                this.olvPayments.EnsureVisible(0);
                return;
            }

            for (int i = 0; i < this.olvPayments.Items.Count; i++)
            {
                PaymentData item = (PaymentData)this.olvPayments.GetModelObject(i);
                if (item != null && !string.IsNullOrEmpty(item.PaymentId) &&
                    !string.IsNullOrEmpty(item.InvoiceId) && item.PaymentId.Equals(selectedPayment.PaymentId))
                {
                    this.olvPayments.SelectedIndex = i;
                    this.olvPayments.EnsureVisible(i);
                    break;
                }
            }
        }

        private void olvPayments_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.Column == this.olvColDelete)
            {
                PaymentData payment = this.olvPayments.SelectedObject as PaymentData;
                if (payment == null)
                {
                    return;
                }

                DialogResult dialogResult =
                    MessageBox.Show("Amount: " + payment.Amount.ToString("N", CultureInfo.CurrentUICulture) + "\n"
                    + "Date: " + payment.Date.ToLocalTime().ToString("MM/dd/yyyy") + "\n"
                    + "Check No: " + payment.Check.Trim() + "\n"
                    + "Delete this payment?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    using (new HourGlass())
                    {
                        paymentApiRepository.Remove(payment);
                        RemovePaymentCompleted(payment);
                    }
                }
            }
        }

        private void olvPayments_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            PaymentData payment = e.RowObject as PaymentData;
            if (payment == null)
            {
                e.Cancel = true;
                return;
            }

            if (e.Column == this.olvColAmount)
            {
                NumericUpDown nudControl = new NumericUpDown();
                nudControl.Bounds = e.CellBounds;
                nudControl.Minimum = 0;
                nudControl.Maximum = decimal.MaxValue;
                nudControl.DecimalPlaces = 2;
                nudControl.Increment = decimal.Parse("0.5");
                nudControl.Value = decimal.Parse(e.Value.ToString()); ;
                e.Control = nudControl;
            }
            else if (e.Column == this.olvColDate)
            {
                DateTimePicker dtmControl = new DateTimePicker();
                dtmControl.Bounds = e.CellBounds;
                dtmControl.Format = DateTimePickerFormat.Custom;
                dtmControl.CustomFormat = "MM/dd/yyyy";
                dtmControl.Value = DateTime.Parse(e.Value.ToString()).ToLocalTime();
                dtmControl.MinDate = this.currentInvoice.InvoiceDate.ToLocalTime();
                dtmControl.MaxDate = DateTime.Today;
                e.Control = dtmControl;
            }
        }

        private void olvPayments_CellEditValidating(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            PaymentData payment = e.RowObject as PaymentData;
            if (payment == null)
            {
                e.Cancel = true;
                return;
            }

            string oldValue;
            string newValue;
            bool updatePayment = false;
            bool updateInvoice = false;

            if (e.Column == this.olvColAmount)
            {
                oldValue = e.Value.ToString();
                newValue = e.NewValue.ToString();
                if (!oldValue.Equals(newValue))
                {
                    payment.Amount = ((NumericUpDown)e.Control).Value;
                    updatePayment = true;
                    updateInvoice = true;
                }
            }
            else if (e.Column == this.olvColDate)
            {
                DateTime dtmValue = ((DateTimePicker)e.Control).Value;
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(dtmValue.Year, dtmValue.Month, dtmValue.Day,
                                            now.Hour, now.Minute, now.Second, now.Millisecond);
                payment.Date = date.ToUniversalTime();
                updatePayment = true;
                updateInvoice = true;
            }
            else if (e.Column == this.olvColCheck)
            {
                oldValue = e.Value.ToString();
                newValue = e.NewValue.ToString();
                if (string.IsNullOrEmpty(newValue))
                {
                    MessageBox.Show("Check No cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                else if (newValue.Length > 255)
                {
                    MessageBox.Show("Check No cannot be longer than 255 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                else if (!oldValue.Equals(newValue))
                {
                    payment.Check = newValue;
                    updatePayment = true;
                }
            }

            if (updatePayment)
            {
                using (new HourGlass())
                {
                    paymentApiRepository.Update(payment);
                    UpdatePaymentCompleted(payment, updateInvoice);
                }
            }
        }

        private void olvPayments_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            PaymentData payment = e.RowObject as PaymentData;
            if (payment == null)
            {
                e.Cancel = true;
                return;
            }

            if (!e.Cancel)
            {
                this.olvPayments.RefreshObject(payment);
                e.Cancel = true;
            }
        }

        public void CancelCellEdit()
        {
            this.olvPayments.CancelCellEdit();
        }
        #endregion

        private void btnNewPayment_Click(object sender, EventArgs e)
        {
            if (this.currentInvoice == null || string.IsNullOrEmpty(this.currentInvoice.InvoiceId))
            {
                return;
            }

            using (new HourGlass())
            {
                PaymentData payment = new PaymentData();
                payment.PaymentId = Guid.NewGuid().ToString();
                payment.InvoiceId = this.currentInvoice.InvoiceId;
                payment.Amount = (InvoiceCalculationHelper.GetTotalInvoiceItemsAmount(this.currentInvoice.InvoiceId)
                                    + InvoiceCalculationHelper.GetInterest(this.currentInvoice))
                                    - InvoiceCalculationHelper.GetTotalPaidAmount(this.currentInvoice.InvoiceId);
                payment.Date = DateTime.UtcNow;
                payment.Check = string.Empty;

                string newId = paymentApiRepository.Add(payment);
                if (!string.IsNullOrEmpty(newId))
                {
                    AddPaymentCompleted(payment);
                }
                else
                {
                    MessageBox.Show("Error when add new payment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddPaymentCompleted(PaymentData payment)
        {
            if (this.currentInvoice == null || payment == null
                || string.IsNullOrEmpty(payment.PaymentId) || string.IsNullOrEmpty(payment.InvoiceId))
            {
                return;
            }

            PaymentCachedApiQuery.Instance.RemovePaymentsByInvoiceId(payment.InvoiceId);

            FormBillingManager formBillingManager = (FormBillingManager)this.ParentForm;
            bool success = InvoiceCalculationHelper.UpdateInvoiceStatus(this.currentInvoice);
            if (success)
            {
                formBillingManager.UpdateItemOLVInvoices(this.currentInvoice);
            }
            // UpdateInvoiceStatus has reference, so we can use this.currentInvoice to set data to controls
            SetDataToControls(this.currentInvoice, payment);
        }

        private void UpdatePaymentCompleted(PaymentData payment, bool updateInvoice)
        {
            if (this.currentInvoice == null || payment == null
                || string.IsNullOrEmpty(payment.PaymentId) || string.IsNullOrEmpty(payment.InvoiceId))
            {
                return;
            }

            PaymentCachedApiQuery.Instance.RemovePaymentsByInvoiceId(payment.InvoiceId);

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
            SetDataToControls(this.currentInvoice, payment);
        }

        private void RemovePaymentCompleted(PaymentData payment)
        {
            if (this.currentInvoice == null || payment == null
                || string.IsNullOrEmpty(payment.PaymentId) || string.IsNullOrEmpty(payment.InvoiceId))
            {
                return;
            }

            PaymentCachedApiQuery.Instance.RemovePaymentsByInvoiceId(payment.InvoiceId);

            FormBillingManager formBillingManager = (FormBillingManager)this.ParentForm;
            bool success = InvoiceCalculationHelper.UpdateInvoiceStatus(this.currentInvoice);
            if (success)
            {
                formBillingManager.UpdateItemOLVInvoices(this.currentInvoice);
            }
            // UpdateInvoiceStatus has reference, so we can use this.currentInvoice to set data to controls
            SetDataToControls(this.currentInvoice, null);
        }

    }
}
