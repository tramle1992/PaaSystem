using Common.Infrastructure.UI;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using Core.Application.Helper;
using Core.Infrastructure.ClientInfo;
using Invoice.Application.Data;
using Invoice.Domain.Model;
using Invoice.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Helper
{
    public class InvoiceCalculationHelper
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static InvoiceApiRepository invoiceApiRepository = new InvoiceApiRepository();

        private static readonly decimal interestPercent = (decimal)0.015;
        private static readonly DateTime defaultLastPaymentDate = new DateTime(3001, 1, 1);

        public static DateTime GetDueDate(DateTime invoiceDate)
        {
            // For case: Current month = 2 & Invoice date.Month = 1 => Due date = 28-29/2
            if (DateTime.Today.Date.Month == 2 && invoiceDate.Month == 1) return new DateTime(invoiceDate.Year, 2, DateTime.DaysInMonth(invoiceDate.Year, 2));

            // Other cases:
            return new DateTime(invoiceDate.Year, invoiceDate.Month, DateTime.DaysInMonth(invoiceDate.Year, invoiceDate.Month)).Date.AddDays(30);
        }

        public static decimal GetTotalPaidAmount(string invoiceId)
        {
            decimal totalPaidAmount = 0;

            if (string.IsNullOrEmpty(invoiceId))
            {
                return totalPaidAmount;
            }

            List<PaymentData> payments = PaymentCachedApiQuery.Instance.GetPaymentsByInvoiceId(invoiceId);
            if (payments != null && payments.Count > 0)
            {
                foreach (PaymentData payment in payments)
                {
                    totalPaidAmount += payment.Amount;
                }
            }

            //return totalPaidAmount;
            return Decimal.Parse(totalPaidAmount.ToString("N", CultureInfo.CurrentUICulture));
        }

        public static decimal GetTotalInvoiceItemsAmount(string invoiceId)
        {
            decimal totalInvoiceItemsAmount = 0;

            if (string.IsNullOrEmpty(invoiceId))
            {
                return totalInvoiceItemsAmount;
            }

            List<InvoiceItemData> invoiceItems = InvoiceItemCachedApiQuery.Instance.GetInvoiceItemsByInvoiceId(invoiceId);
            if (invoiceItems != null && invoiceItems.Count > 0)
            {
                foreach (InvoiceItemData invoiceItem in invoiceItems)
                {
                    totalInvoiceItemsAmount += invoiceItem.UnitPrice;
                }
            }

            //return totalInvoiceItemsAmount;
            return Decimal.Parse(totalInvoiceItemsAmount.ToString("N", CultureInfo.CurrentUICulture));
        }

        public static decimal GetTotalInvoiceItemsAmount(List<InvoiceItemData> invoiceItems)
        {
            decimal totalInvoiceItemsAmount = 0;

            if (invoiceItems == null || invoiceItems.Count == 0)
            {
                return totalInvoiceItemsAmount;
            }

            foreach (InvoiceItemData invoiceItem in invoiceItems)
            {
                totalInvoiceItemsAmount += invoiceItem.UnitPrice;
            }

            //return totalInvoiceItemsAmount;
            return Decimal.Parse(totalInvoiceItemsAmount.ToString("N", CultureInfo.CurrentUICulture));
        }

        public static int GetTotalInvoiceItems(string invoiceId)
        {
            int totalInvoiceItems = 0;

            if (string.IsNullOrEmpty(invoiceId))
            {
                return totalInvoiceItems;
            }

            List<InvoiceItemData> invoiceItems = InvoiceItemCachedApiQuery.Instance.GetInvoiceItemsByInvoiceId(invoiceId);
            if (invoiceItems != null && invoiceItems.Count > 0)
            {
                totalInvoiceItems = invoiceItems.Count;
            }

            return totalInvoiceItems;
        }

        //public static decimal GetInterest(InvoiceData invoice)
        //{
        //    decimal result = 0;
        //    DateTime dueDate = GetDueDate(invoice.InvoiceDate.ToLocalTime()); // LocalTime

        //    DateTime today = DateTime.Today;

        //    if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId) ||
        //        invoice.Amount == 0 || (today - dueDate).TotalDays <= 0)
        //    {
        //        return result;
        //    }

        //    decimal totalPaidAmount = GetTotalPaidAmount(invoice.InvoiceId);

        //    while ((today - dueDate.Date).TotalDays > 0)
        //    {
        //        result += (invoice.Amount - totalPaidAmount) * interestPercent;
        //        dueDate = dueDate.AddMonths(1);
        //    }

        //    return result;
        //}

        public static decimal GetInterest(InvoiceData invoice)
        {
            decimal result = 0;
            DateTime dueDate = GetDueDate(invoice.InvoiceDate.ToLocalTime()); // LocalTime

            DateTime now = DateTime.Now;

            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId) ||
                invoice.Amount == 0 || (now - dueDate).TotalDays <= 0)
            {
                return result;
            }

            List<PaymentData> allPaymentsInCache = PaymentCachedApiQuery.Instance.GetPaymentsByInvoiceId(invoice.InvoiceId);
            List<PaymentData> allPayments;
            if (allPaymentsInCache != null && allPaymentsInCache.Count > 0)
            {
                allPayments = AutoMapper.Mapper.Map<List<PaymentData>, List<PaymentData>>(allPaymentsInCache);
            }
            else
            {
                allPayments = new List<PaymentData>();
            }

            decimal balance = invoice.Amount;

            // calculate payments before dueDate
            if (allPayments.Count > 0)
            {
                List<PaymentData> paymentsInDueMonth = allPayments.FindAll(r => (r != null && r.Date.ToLocalTime() < dueDate));
                if (paymentsInDueMonth != null && paymentsInDueMonth.Count > 0)
                {
                    foreach (PaymentData payment in paymentsInDueMonth)
                    {
                        balance -= payment.Amount;
                    }
                    // remove that payments
                    allPayments.RemoveAll(r => (r != null && r.Date.ToLocalTime() < dueDate));
                }
            }

            // calculate interest & payments after dueDate
            if (balance > 0 && now > dueDate)
            {
                while (true)
                {
                    DateTime fromDate = dueDate;
                    DateTime toDate = dueDate.AddMonths(1);

                    if (toDate >= now)
                    {
                        toDate = now;
                    }

                    decimal interestThisMonth = balance * interestPercent;
                    result += interestThisMonth;
                    balance += interestThisMonth;

                    if (allPayments.Count > 0)
                    {
                        List<PaymentData> paymentsInDueMonth = allPayments.FindAll(r => (r != null
                                                                                    && r.Date.ToLocalTime() >= fromDate
                                                                                    && r.Date.ToLocalTime() <= toDate));
                        if (paymentsInDueMonth != null && paymentsInDueMonth.Count > 0)
                        {
                            foreach (PaymentData payment in paymentsInDueMonth)
                            {
                                balance -= payment.Amount;
                            }
                            // remove that payments
                            allPayments.RemoveAll(r => (r != null
                                                        && r.Date.ToLocalTime() >= fromDate
                                                        && r.Date.ToLocalTime() <= toDate));
                        }
                    }

                    if (balance <= 0)
                    {
                        break;
                    }

                    dueDate = dueDate.AddMonths(1);

                    if (dueDate > now)
                    {
                        break;
                    }
                }
            }

            //return result;
            return Decimal.Parse(result.ToString("N", CultureInfo.CurrentUICulture));
        }

        public static DateTime GetLastPaymentDate(string invoiceId) // Return LocalTime
        {
            if (string.IsNullOrEmpty(invoiceId))
            {
                return defaultLastPaymentDate;
            }

            DateTime? lastPaymentDate = null;

            List<PaymentData> payments = PaymentCachedApiQuery.Instance.GetPaymentsByInvoiceId(invoiceId);
            if (payments != null && payments.Count > 0)
            {
                if (payments.Count == 1 && payments[0] != null)
                {
                    lastPaymentDate = payments[0].Date;
                }
                else
                {
                    foreach (PaymentData payment in payments)
                    {
                        if (payment == null)
                        {
                            continue;
                        }
                        if (!lastPaymentDate.HasValue)
                        {
                            lastPaymentDate = payment.Date;
                        }
                        else if ((payment.Date - lastPaymentDate.Value).TotalDays >= 0)
                        {
                            lastPaymentDate = payment.Date;
                        }
                    }
                }
            }

            if (lastPaymentDate.HasValue)
            {
                return lastPaymentDate.Value.ToLocalTime();
            }
            else
            {
                return defaultLastPaymentDate;
            }
        }

        public static StatusData GetInvoiceStatus(decimal totalInvoiceItemsAmount, decimal totalPaidAmount, decimal interest,
            DateTime lastPaymentDate, DateTime dueDate) // lastPaymentDate & dueDate are LocalTime
        {
            DateTime today = DateTime.Today;
            Status status = Status.PAID;

            if (totalInvoiceItemsAmount > 0)
            {
                if (totalPaidAmount < totalInvoiceItemsAmount + interest)
                {
                    if ((dueDate - today).TotalDays <= 0)
                    {
                        status = Status.PAST_DUE;
                    }
                    else
                    {
                        status = Status.UNPAID;
                    }
                }
                else // totalPaidAmount >= totalInvoiceItemsAmount + interest
                {
                    if ((dueDate - lastPaymentDate).TotalDays < 0)
                    {
                        status = Status.PD_LATE;
                    }
                    else
                    {
                        status = Status.PAID;
                    }

                    if (totalPaidAmount > totalInvoiceItemsAmount + interest
                        && status != Status.PD_LATE)
                    {
                        status = Status.OVER_PAY;
                    }
                }
            }
            else
            {
                status = Status.PAID;
            }

            return AutoMapper.Mapper.Map<Status, StatusData>(status);
        }

        public static ActionStatusData GetInvoiceActionStatus(ActionStatus actionStatus)
        {
            return AutoMapper.Mapper.Map<ActionStatus, ActionStatusData>(actionStatus);
        }

        public static string GetInvoiceItemDescription(AppData app)
        {
            string applicantName = string.Empty;

            if (app == null || string.IsNullOrEmpty(app.ApplicationId) || string.IsNullOrEmpty(app.ReportTypeId))
            {
                return applicantName;
            }

            try
            {
                ReportTypeData reportType = ReportTypeCachedApiQuery.Instance.GetReportType(app.ReportTypeId);
                applicantName = Utils.GetApplicantName(app, reportType);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }

            if (applicantName.Length > 0 && app.ReceivedDate.HasValue)
            {
                return applicantName + ": " + app.ReceivedDate.Value.ToLocalTime().ToString("MM/dd/yy");
            }
            return string.Empty;
        }

        public static decimal GetInvoiceItemUnitPrice(ReportTypeData reportType, ClientData client)
        {
            decimal defaultPrice = 0;

            if (reportType == null || client == null)
            {
                return defaultPrice;
            }

            defaultPrice = reportType.DefaultPrice;

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

        public static int GetNextInvoiceNumber(int year, int month, string timezone, int maxInvoiceNumberInMonth)
        {
            int invoiceNumber;
            if (maxInvoiceNumberInMonth < 0 ||
                (maxInvoiceNumberInMonth.ToString().Length >= 5
                && maxInvoiceNumberInMonth.ToString().Length < 9))
            {
                int yearNumber = year % 100; // get 2 (or 1) number in the end
                int monthNumber = month;
                StringBuilder invoiceNumberInString = new StringBuilder();

                if (yearNumber < 10)
                {
                    invoiceNumberInString.Append("0");
                }
                invoiceNumberInString.Append(yearNumber);

                if (monthNumber < 10)
                {
                    invoiceNumberInString.Append("0");
                }
                invoiceNumberInString.Append(monthNumber);

                if (maxInvoiceNumberInMonth < 0)
                {
                    invoiceNumberInString.Append("00000");
                }
                else // maxInvoiceNumberInMonth.ToString().Length >= 5
                {
                    int invoiceCount = invoiceApiRepository
                                        .FindInvoiceCountByYearAndMonth(year, month, timezone);
                    if (invoiceCount < 0 || (invoiceCount + 1 >= 99999))
                    {
                        return -1;
                    }
                    invoiceCount += 1;
                    invoiceNumberInString.Append(invoiceCount.ToString().PadLeft(5, '0'));
                }

                if (int.TryParse(invoiceNumberInString.ToString(), out invoiceNumber))
                {
                    return invoiceNumber;
                }
            }
            else if (maxInvoiceNumberInMonth.ToString().Length == 9)
            {
                invoiceNumber = maxInvoiceNumberInMonth + 1;
                if (invoiceNumber % 100000 < 99999)
                {
                    return invoiceNumber;
                }
            }
            // maxInvoiceNumberInMonth.ToString().Length > 9 is not allowed
            return -1;
        }

        public static bool CheckIfAppIsBilled(string applicationId, string applicationName, string clientAppliedName, string clientApplied,
            string appInvoiceDivision, DateTime? receivedDate, out int invoiceNumber) // receivedDate is UniversalTime
        {
            ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
            ClientData client = clientCachedApiQuery.GetClient(clientApplied);

            if (string.IsNullOrEmpty(applicationId) || receivedDate == null || !receivedDate.HasValue
                || (client != null && client.InvoiceDivisions.Count > 0 && string.IsNullOrEmpty(appInvoiceDivision)) //if Client has Invoice Division but App Invoice Division is Empty -> did not create Invoice
                || (appInvoiceDivision.Length > 0 && appInvoiceDivision.Equals("(None)"))
                || string.IsNullOrEmpty(clientAppliedName))
            {
                invoiceNumber = 0;
                return false;
            }
            
            List<InvoiceData> invoices = new List<InvoiceData>();

            try
            {
                List<InvoiceData> allInvoicesInMonth
                = InvoiceCachedApiQuery.Instance.GetInvoicesByYearAndMonth(receivedDate.Value.Year, receivedDate.Value.Month);
                if (allInvoicesInMonth != null && allInvoicesInMonth.Count > 0)
                {
                    allInvoicesInMonth = allInvoicesInMonth.FindAll(r => (r.ClientName != null
                                                                    && r.ClientName.Equals(clientAppliedName)));

                    invoices.AddRange(allInvoicesInMonth);

                    if (invoices.Count > 0)
                    {
                        invoices = invoices.FindAll(r => (r.InvoiceDivision != null
                                                            && r.InvoiceDivision.Equals(appInvoiceDivision)));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("CheckIfAppIsBilled: " + ex.ToString());
                invoiceNumber = 0;
                return false;
            }

            foreach (InvoiceData invoice in invoices)
            {
                if (string.IsNullOrEmpty(invoice.InvoiceId))
                {
                    continue;
                }

                try
                {
                    List<InvoiceItemData> invoiceItems = InvoiceItemCachedApiQuery.Instance.
                                                        GetInvoiceItemsByInvoiceId(invoice.InvoiceId);
                    if (invoiceItems == null || invoiceItems.Count == 0)
                    {
                        continue;
                    }
                    foreach (InvoiceItemData invoiceItem in invoiceItems)
                    {
                        if (string.IsNullOrEmpty(invoiceItem.InvoiceItemId)
                            || string.IsNullOrEmpty(invoiceItem.InvoiceId))
                        {
                            continue;
                        }
                        if ((!string.IsNullOrEmpty(invoiceItem.ApplicationId)
                            && invoiceItem.ApplicationId.Equals(applicationId)))
                        {
                            invoiceNumber = invoice.InvoiceNumber;
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("CheckIfAppIsBilled: " + ex.ToString());
                    continue;
                }
            }

            invoiceNumber = 0;
            return false;
        }

        public static bool UpdateInvoiceStatus(InvoiceData invoice) // Has reference
        {
            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
            {
                return false;
            }

            try
            {
                decimal oldTotalInvoiceItemsAmount = invoice.Amount;
                decimal newTotalInvoiceItemsAmount = InvoiceCalculationHelper.GetTotalInvoiceItemsAmount(invoice.InvoiceId);
                decimal newTotalPaidAmount = InvoiceCalculationHelper.GetTotalPaidAmount(invoice.InvoiceId);
                decimal newInterest = InvoiceCalculationHelper.GetInterest(invoice);
                decimal oldBalance = invoice.Balance;
                decimal newBalance = (newTotalInvoiceItemsAmount + newInterest) - newTotalPaidAmount;
                DateTime lastPaymentDate = InvoiceCalculationHelper.GetLastPaymentDate(invoice.InvoiceId); // LocalTime
                DateTime dueDate = InvoiceCalculationHelper.GetDueDate(invoice.InvoiceDate.ToLocalTime()); // LocalTime
                StatusData oldStatus = invoice.Status;
                StatusData newStatus = InvoiceCalculationHelper.GetInvoiceStatus(newTotalInvoiceItemsAmount, newTotalPaidAmount,
                                                        newInterest, lastPaymentDate, dueDate);

                if (oldStatus.Value == Status.PD_LATE.Value && oldBalance == 0 && newTotalPaidAmount == oldTotalInvoiceItemsAmount)
                {
                    return false;
                }

                bool atLeastOneValueChanged = false;

                if (oldTotalInvoiceItemsAmount != newTotalInvoiceItemsAmount)
                {
                    invoice.Amount = newTotalInvoiceItemsAmount;
                    atLeastOneValueChanged = true;
                }

                if (oldBalance != newBalance)
                {
                    invoice.Balance = newBalance;
                    atLeastOneValueChanged = true;
                }

                if (oldStatus.Value != newStatus.Value)
                {
                    invoice.Status = newStatus;
                    atLeastOneValueChanged = true;
                }

                if (atLeastOneValueChanged)
                {
                    invoiceApiRepository.Update(invoice);
                    InvoiceCachedApiQuery.Instance
                        .RemoveInvoicesByYearAndMonth(invoice.InvoiceDate.Year, invoice.InvoiceDate.Month);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }

            return true;
        }

        public static bool UpdateInvoiceActionStatus(InvoiceData invoice, ActionStatus actionStatus) // Has reference
        {
            if (invoice == null || string.IsNullOrEmpty(invoice.InvoiceId))
            {
                return false;
            }

            try
            {
                
                ActionStatusData oldActionStatus = invoice.ActionStatus;
                ActionStatusData newActionStatus = GetInvoiceActionStatus(actionStatus);

                if (!oldActionStatus.Value.Equals(newActionStatus.Value))
                {
                    invoice.ActionStatus = newActionStatus;
                    invoiceApiRepository.UpdateActionStatus(invoice);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
