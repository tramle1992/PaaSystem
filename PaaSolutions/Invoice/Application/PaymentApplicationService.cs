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
    public class PaymentApplicationService
    {
        private readonly PaymentRepository repository;

        public PaymentApplicationService()
        {
            this.repository = new PaymentRepository();
        }

        public string NewPayment(NewPaymentCommand command)
        {
            PaymentData paymentData = command.PaymentData;
            Payment payment = AutoMapper.Mapper.Map<PaymentData, Payment>(paymentData);
            this.repository.Add(payment);
            return payment.PaymentId.Id;
        }

        public void SavePayment(SavePaymentCommand command)
        {
            PaymentData paymentData = command.PaymentData;
            Payment payment = AutoMapper.Mapper.Map<PaymentData, Payment>(paymentData);
            this.repository.Update(payment);
        }

        public void RemovePayment(RemovePaymentCommand command)
        {
            this.repository.Remove(command.PaymentId);
        }

        public void RemovePaymentByInvoiceId(RemovePaymentByInvoiceIdCommand command)
        {
            this.repository.RemoveByInvoiceId(command.InvoiceId);
        }

        public void MultiRemovePaymentByInvoiceId(MultiRemovePaymentByInvoiceIdCommand commandList)
        {
            foreach (RemovePaymentByInvoiceIdCommand command in commandList.CommandList)
            {
                RemovePaymentByInvoiceId(command);
            }
        }
    }
}
