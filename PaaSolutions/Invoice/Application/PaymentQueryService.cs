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
    public class PaymentQueryService
    {
        private readonly PaymentRepository repository;

        public PaymentQueryService()
        {
            this.repository = new PaymentRepository();
        }

        public PaymentData Get(string id)
        {
            Payment payment = this.repository.Find(id);
            PaymentData paymentData = null;
            if (payment != null && !string.IsNullOrEmpty(payment.PaymentId.Id))
            {
                paymentData = AutoMapper.Mapper.Map<Payment, PaymentData>(payment);
            }
            return paymentData;
        }

        public List<PaymentData> GetByInvoiceId(string invoiceId)
        {
            List<Payment> paymentList = this.repository.FindByInvoiceId(invoiceId);
            List<PaymentData> paymentDataList = new List<PaymentData>();
            if (paymentList != null && paymentList.Count > 0)
            {
                foreach (Payment payment in paymentList)
                {
                    if (payment != null && !string.IsNullOrEmpty(payment.PaymentId.Id))
                    {
                        PaymentData paymentData = AutoMapper.Mapper.Map<Payment, PaymentData>(payment);
                        paymentDataList.Add(paymentData);
                    }
                }
            }
            return paymentDataList;
        }

        public List<PaymentData> GetAll()
        {
            List<Payment> paymentList = this.repository.FindAll();
            List<PaymentData> paymentDataList = null;
            if (paymentList != null && paymentList.Count > 0)
            {
                paymentDataList = new List<PaymentData>(paymentList.Count);
                foreach (Payment payment in paymentList)
                {
                    if (payment != null && !string.IsNullOrEmpty(payment.PaymentId.Id))
                    {
                        PaymentData paymentData = AutoMapper.Mapper.Map<Payment, PaymentData>(payment);
                        paymentDataList.Add(paymentData);
                    }
                }
            }
            return paymentDataList;
        }
    }
}
