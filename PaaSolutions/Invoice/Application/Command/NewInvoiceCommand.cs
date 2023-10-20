using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class NewInvoiceCommand
    {
        public InvoiceData InvoiceData { get; set; }

        public NewInvoiceCommand(InvoiceData data)
        {
            this.InvoiceData = data;
        }
    }
}
