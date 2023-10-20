using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.Invoice
{
    public class EmailInvoicesEventArgs
    {
        public List<InvoiceData> Invoices;
        public bool IsPdf;

        public EmailInvoicesEventArgs(List<InvoiceData> invoices, bool isPdf)
        {
            Invoices = invoices;
            IsPdf = isPdf;
        }
    }
}
