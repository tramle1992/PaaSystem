using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Data
{
    public class InvoiceItemData
    {
        public string InvoiceItemId { get; set; }

        public string InvoiceId { get; set; }

        public string ApplicationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public InvoiceItemData()
        {
            this.ApplicationId = string.Empty;
        }
    }
}
