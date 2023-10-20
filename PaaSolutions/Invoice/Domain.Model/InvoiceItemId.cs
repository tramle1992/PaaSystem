using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Model
{
    public class InvoiceItemId : Identity
    {
        public InvoiceItemId() { }

        public InvoiceItemId(string id)
            : base(id)
        {
        }
    }
}
