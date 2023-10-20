using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public class CreditInfoData
    {
        public bool CreditReportObtained { get; set; }

        public bool CreditMatched { get; set; }

        public bool CreditHistoryBankrupted { get; set; }

        public decimal PastDueAmounts { get; set; }

        public decimal Rent { get; set; }

        public decimal Collections { get; set; }

        public decimal Liens { get; set; }

        public decimal Judgements { get; set; }

        public decimal ChildSupport { get; set; }

        public string Dates { get; set; }

        public bool PositiveCreditSince { get; set; }

        public string CreditPreface { get; set; }
    }
}
