using Invoice.Application.Command;
using Invoice.Application.Data;
using Invoice.Domain.Model;
using Invoice.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application
{
    public class InvoiceApplicationService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly InvoiceRepository invoiceRepository;
        private readonly InvoiceItemRepository invoiceItemRepository;
        private readonly PaymentRepository paymentRepository;

        private readonly DateTime defaultLastPaymentDate = new DateTime(3001, 1, 1);

        public InvoiceApplicationService()
        {
            this.invoiceRepository = new InvoiceRepository();
            this.invoiceItemRepository = new InvoiceItemRepository();
            this.paymentRepository = new PaymentRepository();
        }

        public string NewInvoice(NewInvoiceCommand command)
        {
            InvoiceData invoiceData = command.InvoiceData;
            Invoice.Domain.Model.Invoice invoice = AutoMapper.Mapper.Map<InvoiceData, Invoice.Domain.Model.Invoice>(invoiceData);
            this.invoiceRepository.Add(invoice);
            return invoice.InvoiceId.Id;
        }

        public void SaveInvoice(SaveInvoiceCommand command)
        {
            InvoiceData invoiceData = command.InvoiceData;
            Invoice.Domain.Model.Invoice invoice = AutoMapper.Mapper.Map<InvoiceData, Invoice.Domain.Model.Invoice>(invoiceData);
            this.invoiceRepository.Update(invoice);
        }

        public void MultiSaveInvoice(MultiSaveInvoiceCommand commandList)
        {
            foreach (SaveInvoiceCommand command in commandList.CommandList)
            {
                SaveInvoice(command);
            }
        }

        public void RemoveInvoice(RemoveInvoiceCommand command)
        {
            this.invoiceRepository.Remove(command.InvoiceId);
        }

        public void MultiRemoveInvoice(MultiRemoveInvoiceCommand commandList)
        {
            List<string> invoiceIds = new List<string>();
            foreach (RemoveInvoiceCommand command in commandList.CommandList)
            {
                invoiceIds.Add(command.InvoiceId);
            }
            this.invoiceRepository.Remove(invoiceIds);
        }

        public void SaveInvoiceActionStatus(SaveInvoiceCommand command)
        {
            InvoiceData invoiceData = command.InvoiceData;
            Invoice.Domain.Model.Invoice invoice = AutoMapper.Mapper.Map<InvoiceData, Invoice.Domain.Model.Invoice>(invoiceData);
            this.invoiceRepository.UpdateActionStatus(invoice.InvoiceId.Id, invoice.ActionStatus.Value);
        }

        public void ScheduleUpdateInvoiceStatusDaily()
        {
            _logger.Info("Query invoice list by " + DateTime.UtcNow.Date + "(UTC)...");

            List<Invoice.Domain.Model.Invoice> invoiceList
                = this.invoiceRepository.FindByDate(DateTime.UtcNow.Date);
            if (invoiceList == null || invoiceList.Count == 0)
            {
                _logger.Info("No matched invoices found.");
                return;
            }

            _logger.Info($"There're {invoiceList.Count()} invoices matched.");           

            List<InvoiceData> invoiceDataList
                = AutoMapper.Mapper.Map<List<Invoice.Domain.Model.Invoice>, List<InvoiceData>>(invoiceList);
            foreach (InvoiceData invoiceData in invoiceDataList)
            {
                _logger.Info("==========================================");
                _logger.Info("Updating invoice ID = " + invoiceData.InvoiceId + " ...");

                if (invoiceData == null || string.IsNullOrEmpty(invoiceData.InvoiceId))
                {
                    continue;
                }

                try
                {
                    decimal oldTotalInvoiceItemsAmount = invoiceData.Amount;
                    decimal newTotalInvoiceItemsAmount = GetTotalInvoiceItemsAmount(invoiceData.InvoiceId);
                    decimal newTotalPaidAmount = GetTotalPaidAmount(invoiceData.InvoiceId);
                    decimal oldBalance = invoiceData.Balance;
                    decimal newBalance = newTotalInvoiceItemsAmount - newTotalPaidAmount;
                    DateTime lastPaymentDate = GetLastPaymentDate(invoiceData.InvoiceId); // LocalTime
                    DateTime dueDate = GetDueDate(invoiceData.InvoiceDate.ToLocalTime()); // LocalTime
                    StatusData oldStatus = invoiceData.Status;
                    StatusData newStatus = GetInvoiceStatus(newTotalInvoiceItemsAmount, newTotalPaidAmount,
                                                            lastPaymentDate, dueDate);

                    bool atLeastOneValueChanged = false;

                    if (oldTotalInvoiceItemsAmount != newTotalInvoiceItemsAmount)
                    {
                        invoiceData.Amount = newTotalInvoiceItemsAmount;
                        atLeastOneValueChanged = true;
                    }

                    if (oldBalance != newBalance)
                    {
                        invoiceData.Balance = newBalance;
                        atLeastOneValueChanged = true;
                    }

                    if (oldStatus.Value != newStatus.Value)
                    {
                        invoiceData.Status = newStatus;
                        atLeastOneValueChanged = true;
                    }

                    if (atLeastOneValueChanged)
                    {
                        Invoice.Domain.Model.Invoice invoice = AutoMapper.Mapper.Map<InvoiceData, Invoice.Domain.Model.Invoice>(invoiceData);
                        this.invoiceRepository.Update(invoice);

                        _logger.Info("Invoice ID = " + invoiceData.InvoiceId + " updated successfully.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                }
            }
        }

        private decimal GetTotalInvoiceItemsAmount(string invoiceId)
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

            return totalInvoiceItemsAmount;
        }

        private decimal GetTotalPaidAmount(string invoiceId)
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

            return totalPaidAmount;
        }

        private DateTime GetLastPaymentDate(string invoiceId) // Return LocalTime
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

        private DateTime GetDueDate(DateTime invoiceDate)
        {
            return new DateTime(invoiceDate.Year, invoiceDate.Month,
                DateTime.DaysInMonth(invoiceDate.Year, invoiceDate.Month)).Date.AddDays(30);
        }

        private StatusData GetInvoiceStatus(decimal totalInvoiceItemsAmount, decimal totalPaidAmount,
            DateTime lastPaymentDate, DateTime dueDate) // lastPaymentDate & dueDate are LocalTime
        {
            DateTime today = DateTime.Today;
            Status status = Status.PAID;

            if (totalInvoiceItemsAmount > 0)
            {
                if (totalPaidAmount < totalInvoiceItemsAmount)
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
                else // totalPaidAmount >= totalInvoiceItemsAmount
                {
                    if ((dueDate - lastPaymentDate).TotalDays < 0)
                    {
                        status = Status.PD_LATE;
                    }
                    else
                    {
                        status = Status.PAID;
                    }

                    if (totalPaidAmount > totalInvoiceItemsAmount &&
                        status != Status.PD_LATE)
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
    }
}
