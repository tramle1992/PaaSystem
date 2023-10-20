using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class NewInvoiceItemCommand
    {
        public InvoiceItemData InvoiceItemData { get; set; }

        public NewInvoiceItemCommand(InvoiceItemData data)
        {
            this.InvoiceItemData = data;
        }
    }
}
