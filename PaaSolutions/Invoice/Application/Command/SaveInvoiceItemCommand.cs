using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class SaveInvoiceItemCommand
    {
        public InvoiceItemData InvoiceItemData { get; set; }

        public SaveInvoiceItemCommand(InvoiceItemData data)
        {
            this.InvoiceItemData = data;
        }
    }
}
