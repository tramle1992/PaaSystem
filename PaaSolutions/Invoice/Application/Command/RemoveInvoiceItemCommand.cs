using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class RemoveInvoiceItemCommand
    {
        public string InvoiceItemId { get; set; }

        public RemoveInvoiceItemCommand(string invoiceItemId)
        {
            this.InvoiceItemId = invoiceItemId;
        }
    }
}
