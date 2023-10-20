using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class RemovePaymentByInvoiceIdCommand
    {
        public string InvoiceId { get; set; }

        public RemovePaymentByInvoiceIdCommand(string invoiceId)
        {
            this.InvoiceId = invoiceId;
        }
    }
}
