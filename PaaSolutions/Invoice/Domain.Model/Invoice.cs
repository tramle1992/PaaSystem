using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Model
{
    public class Invoice : EntityWithCompositeId
    {
        public InvoiceId InvoiceId { get; private set; }

        public string ClientName { get; set; }

        public string SoldToClientName { get; set; }

        public string Address { get; set; }

        public string InvoiceReference { get; set; }

        public string CustomerNumber { get; set; }

        public string InvoiceComments { get; set; }

        public int InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string NoteToClient { get; set; }

        public string PONumber { get; set; }

        public string InvoiceDivision { get; set; }

        public Status Status { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }

        public ActionStatus ActionStatus { get; set; }

        public Invoice()
        {
        }

        public Invoice(InvoiceId invoiceId)
            : this()
        {
            this.InvoiceId = invoiceId;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.InvoiceId;
        }

        public override string ToString()
        {
            return "Invoice[invoiceId=" + this.InvoiceId + "]";
        }
    }
}
