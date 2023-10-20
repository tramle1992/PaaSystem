using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Application.Data.ClientInfo;
using Invoice.Application.Command;
using Invoice.Application.Data;
using Invoice.Infrastructure;
using System.Globalization;
using PaaApplication.Forms.Invoicing;
using Invoice.Domain.Model;
using Common.Infrastructure.UI;
using PaaApplication.Models.Invoice;
using Invoice.Application.Helper;

namespace PaaApplication.UserControls.Invoicing
{
    public partial class InvStatsControl : UserControl
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static InvoiceApiRepository invoiceApiRepository = new InvoiceApiRepository();

        public InvStatsControl()
        {
            InitializeComponent();
        }

        public void SetClients(List<ClientData> clients)
        {
            using (new HourGlass())
            {
                List<InvoiceData> invoices = new List<InvoiceData>();

                if (clients != null && clients.Count > 0)
                {
                    SearchInvoiceCommand command = new SearchInvoiceCommand();
                    HashSet<string> clientNames = new HashSet<string>();
                    foreach (ClientData client in clients)
                    {
                        if (!string.IsNullOrEmpty(client.ClientName))
                        {
                            clientNames.Add(client.ClientName);
                        }
                    }
                    command.ClientNames = clientNames.ToList<string>();

                    try
                    {
                        invoices = invoiceApiRepository.SearchInvoice(command);

                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex.ToString());
                    }
                }

                ShowData(invoices);
            }
        }

        public void SetInvoices(List<InvoiceData> invoices)
        {
            ShowData(invoices);
        }

        private void ShowData(List<InvoiceData> invoices)
        {
            int totalInvs = 0;
            int totalPastDueInvs = 0;
            int totalPaidInvs = 0;
            int totalUnpaidInvs = 0;
            decimal largestInv = 0;
            decimal totalPastDueAmount = 0;
            decimal totalPaidAmount = 0;
            decimal totalUnpaidAmount = 0;
            int totalDaysLate = 0;
            int totalInvItems = 0;

            foreach (InvoiceData invoice in invoices)
            {
                if (string.IsNullOrEmpty(invoice.InvoiceId))
                {
                    continue;
                }

                // prefix "for" to declare variables in foreach
                int forTotalInvoiceItems = InvoiceCalculationHelper.GetTotalInvoiceItems(invoice.InvoiceId);
                decimal forTotalInvoiceItemsAmount = InvoiceCalculationHelper.GetTotalInvoiceItemsAmount(invoice.InvoiceId);
                decimal forTotalPaidAmount = InvoiceCalculationHelper.GetTotalPaidAmount(invoice.InvoiceId);
                decimal forInterest = InvoiceCalculationHelper.GetInterest(invoice);
                decimal forBalance = (forTotalInvoiceItemsAmount + forInterest) - forTotalPaidAmount;
                DateTime forLastPaymentDate = InvoiceCalculationHelper.GetLastPaymentDate(invoice.InvoiceId); // LocalTime
                DateTime forDueDate = InvoiceCalculationHelper.GetDueDate(invoice.InvoiceDate.ToLocalTime()); // LocalTime
                StatusData forStatus = InvoiceCalculationHelper
                                        .GetInvoiceStatus(forTotalInvoiceItemsAmount, forTotalPaidAmount, forInterest,
                                                            forLastPaymentDate, forDueDate);
                if (forBalance < 0)
                {
                    forBalance = 0;
                }

                totalInvs += 1;
                totalInvItems += forTotalInvoiceItems;
                totalPaidAmount += forTotalPaidAmount;

                if (forStatus.Value == Status.OVER_PAY.Value
                    || invoice.Status.Value == Status.PAID.Value
                    || invoice.Status.Value == Status.PD_LATE.Value)
                {
                    //totalPaidAmount += forTotalInvoiceItemsAmount;
                    totalPaidInvs += 1;
                }
                else if (forStatus.Value == Status.PAST_DUE.Value)
                {
                    totalPastDueAmount += forBalance;
                    totalPastDueInvs += 1;
                }
                else if (forStatus.Value == Status.UNPAID.Value)
                {
                    totalUnpaidAmount += forBalance;
                    totalUnpaidInvs += 1;
                }

                if (forTotalInvoiceItemsAmount > largestInv)
                {
                    largestInv = forTotalInvoiceItemsAmount;
                }

                if (forStatus.Value != Status.PAST_DUE.Value
                    && forStatus.Value != Status.UNPAID.Value
                    && forTotalPaidAmount > 0)
                {
                    totalDaysLate += (int)(forDueDate - forLastPaymentDate).TotalDays;
                }
            }

            this.txtTotalInvs.Text = totalInvs.ToString();
            this.txtTotalPastDueInvs.Text = totalPastDueInvs.ToString();
            this.txtTotalPaidInvs.Text = totalPaidInvs.ToString();
            this.txtTotalUnpaidInvs.Text = totalUnpaidInvs.ToString();
            this.txtLargestInv.Text = "$" + largestInv.ToString("N", CultureInfo.CurrentUICulture);
            this.txtTotalPastDueAmount.Text = "$" + totalPastDueAmount.ToString("N", CultureInfo.CurrentUICulture);
            this.txtTotalPaidAmount.Text = "$" + totalPaidAmount.ToString("N", CultureInfo.CurrentUICulture);
            this.txtTotalUnpaidAmount.Text = "$" + totalUnpaidAmount.ToString("N", CultureInfo.CurrentUICulture);
            if (totalInvs == 0)
            {
                this.txtAvgItems.Text = "(No Invs)";
            }
            else
            {
                this.txtAvgItems.Text = (totalInvItems / totalInvs).ToString();
            }
            if (totalPaidInvs == 0)
            {
                this.txtAvgPayment.Text = "(No Paid Invoices)";
            }
            else
            {
                string txtAvgPaymentText = Math.Abs(totalDaysLate / totalPaidInvs).ToString();
                if (totalDaysLate < 0)
                {
                    txtAvgPaymentText += " Days Late";
                }
                else
                {
                    txtAvgPaymentText += " Days Early";
                }
                this.txtAvgPayment.Text = txtAvgPaymentText;
            }
        }

        public void ClearDataInControls()
        {
            this.txtTotalInvs.Clear();
            this.txtTotalPastDueInvs.Clear();
            this.txtTotalPaidInvs.Clear();
            this.txtTotalUnpaidInvs.Clear();
            this.txtLargestInv.Clear();
            this.txtAvgItems.Clear();
            this.txtTotalPastDueAmount.Clear();
            this.txtTotalPaidAmount.Clear();
            this.txtTotalUnpaidAmount.Clear();
            this.txtAvgPayment.Clear();
        }

        public string GetPaymentStatus(InvoiceData invoice)
        {
            string result = string.Empty;

            int totalInvs = 0;
            int totalPastDueInvs = 0;
            int totalPaidInvs = 0;
            int totalUnpaidInvs = 0;
            decimal largestInv = 0;
            decimal totalPastDueAmount = 0;
            decimal totalPaidAmount = 0;
            decimal totalUnpaidAmount = 0;
            int totalDaysLate = 0;
            int totalInvItems = 0;

            if (string.IsNullOrEmpty(invoice.InvoiceId))
            {
                return result;
            }

            // prefix "for" to declare variables in foreach
            int forTotalInvoiceItems = InvoiceCalculationHelper.GetTotalInvoiceItems(invoice.InvoiceId);
            decimal forTotalInvoiceItemsAmount = InvoiceCalculationHelper.GetTotalInvoiceItemsAmount(invoice.InvoiceId);
            decimal forTotalPaidAmount = InvoiceCalculationHelper.GetTotalPaidAmount(invoice.InvoiceId);
            decimal forInterest = InvoiceCalculationHelper.GetInterest(invoice);
            decimal forBalance = (forTotalInvoiceItemsAmount + forInterest) - forTotalPaidAmount;
            DateTime forLastPaymentDate = InvoiceCalculationHelper.GetLastPaymentDate(invoice.InvoiceId); // LocalTime
            DateTime forDueDate = InvoiceCalculationHelper.GetDueDate(invoice.InvoiceDate.ToLocalTime()); // LocalTime
            StatusData forStatus = InvoiceCalculationHelper
                                    .GetInvoiceStatus(forTotalInvoiceItemsAmount, forTotalPaidAmount, forInterest,
                                                        forLastPaymentDate, forDueDate);
            if (forBalance < 0)
            {
                forBalance = 0;
            }

            totalInvs += 1;
            totalInvItems += forTotalInvoiceItems;
            totalPaidAmount += forTotalPaidAmount;

            if (forStatus.Value == Status.OVER_PAY.Value
                || invoice.Status.Value == Status.PAID.Value
                || invoice.Status.Value == Status.PD_LATE.Value)
            {
                //totalPaidAmount += forTotalInvoiceItemsAmount;
                totalPaidInvs += 1;
            }
            else if (forStatus.Value == Status.PAST_DUE.Value)
            {
                totalPastDueAmount += forBalance;
                totalPastDueInvs += 1;
            }
            else if (forStatus.Value == Status.UNPAID.Value)
            {
                totalUnpaidAmount += forBalance;
                totalUnpaidInvs += 1;
            }

            if (forTotalInvoiceItemsAmount > largestInv)
            {
                largestInv = forTotalInvoiceItemsAmount;
            }

            if (forStatus.Value != Status.PAST_DUE.Value
                && forStatus.Value != Status.UNPAID.Value
                && forTotalPaidAmount > 0)
            {
                totalDaysLate += (int)(forDueDate - forLastPaymentDate).TotalDays;
            }

            if (totalInvs == 0)
            {
                result = "(No Invs)";
            }
            else
            {
                this.txtAvgItems.Text = (totalInvItems / totalInvs).ToString();
            }
            if (totalPaidInvs == 0)
            {
                result = "(No Paid Invoices)";
            }
            else
            {
                string txtAvgPaymentText = Math.Abs(totalDaysLate / totalPaidInvs).ToString();
                if (totalDaysLate < 0)
                {
                    result = string.Format("{0} ({1} Days)", "Late", txtAvgPaymentText);
                }
                else
                {
                    result = string.Format("{0} ({1} Days)", "Early", txtAvgPaymentText);
                }
            }
            return result;
        }
    }
}
