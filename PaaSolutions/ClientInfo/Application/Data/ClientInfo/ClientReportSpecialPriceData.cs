using Core.Domain.Model.ClientInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Application.Data.ClientInfo
{
    public class ClientReportSpecialPriceData
    {
        public string ReportTypeId { get; set; }

        public decimal SpecialPrice { get; set; }

        public ClientReportSpecialPriceData()
        {
        }

        public ClientReportSpecialPriceData(string reportTypeId, decimal specialPrice)
        {
            this.ReportTypeId = reportTypeId;
            this.SpecialPrice = specialPrice;
        }
    }
}
