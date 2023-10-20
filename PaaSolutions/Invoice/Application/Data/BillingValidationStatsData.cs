using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Data
{
    public class BillingValidationStatsData
    {
        public int TotalInvs { get; set; }

        public decimal TotalVolumn { get; set; }

        public decimal LargestInv { get; set; }

        public decimal AvgInvAmount { get; set; }

        public decimal SmallestInv { get; set; }

        public BillingValidationStatsData()
        {
            this.TotalInvs = 0;
            this.TotalVolumn = 0;
            this.LargestInv = 0;
            this.AvgInvAmount = 0;
            this.SmallestInv = 0;
        }
    }
}
