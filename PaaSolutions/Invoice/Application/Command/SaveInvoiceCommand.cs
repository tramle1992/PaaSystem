using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class SaveInvoiceCommand
    {
        public InvoiceData InvoiceData { get; set; }

        public SaveInvoiceCommand(InvoiceData data)
        {
            this.InvoiceData = data;
        }
    }
}
