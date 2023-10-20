using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class RemoveInvoiceCommand
    {
        public string InvoiceId { get; set; }

        public RemoveInvoiceCommand(string invoiceId)
        {
            this.InvoiceId = invoiceId;
        }
    }
}
