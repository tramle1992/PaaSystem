using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Data
{
    public class AvailableAppData
    {
        public string ApplicationId { get; set; }

        public string ReportTypeName { get; set; }

        public string InvoiceItemDescription { get; set; }

        public decimal InvoiceItemUnitPrice { get; set; }

        public AvailableAppData()
        {
        }
    }
}
