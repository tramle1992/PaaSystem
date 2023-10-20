using Common.Domain.Model;
using Core.Domain.Model.ExploreApps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Model
{
    public class InvoiceItem : EntityWithCompositeId
    {
        public InvoiceItemId InvoiceItemId { get; private set; }

        public InvoiceId InvoiceId { get; private set; }

        public AppId ApplicationId { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public InvoiceItem()
        {
        }

        public InvoiceItem(InvoiceItemId invoiceItemId, InvoiceId invoiceId, AppId applicationId)
            : this()
        {
            this.InvoiceItemId = invoiceItemId;
            this.InvoiceId = invoiceId;
            this.ApplicationId = applicationId;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.InvoiceItemId;
            yield return this.InvoiceId;
        }

        public override string ToString()
        {
            return "InvoiceItem[invoiceItemId=" + this.InvoiceItemId + ", invoiceId=" + this.InvoiceId + "]";
        }
    }
}
