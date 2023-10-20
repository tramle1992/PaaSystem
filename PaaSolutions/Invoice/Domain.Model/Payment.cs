using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Model
{
    public class Payment : EntityWithCompositeId
    {
        public PaymentId PaymentId { get; private set; }

        public InvoiceId InvoiceId { get; private set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Check { get; set; }

        public Payment()
        {
        }

        public Payment(PaymentId paymentId, InvoiceId invoiceId)
            : this()
        {
            this.PaymentId = paymentId;
            this.InvoiceId = invoiceId;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.PaymentId;
            yield return this.InvoiceId;
        }

        public override string ToString()
        {
            return "Payment[paymentId=" + this.PaymentId + ", invoiceId=" + this.InvoiceId + "]";
        }
    }
}
