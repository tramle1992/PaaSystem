using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ClientInfo
{
    public class SearchClientSpecialBillingData
    {
        public string InvoiceDivisions { get; set; }
        public string PrimaryKey { get; set; }
        public string ReportTypeName { get; set; }
        public decimal? SpecialPrices { get; set; }
    }
}
