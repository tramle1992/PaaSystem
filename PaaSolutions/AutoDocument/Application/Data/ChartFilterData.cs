using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDocument.Application.Data
{
    public class ChartFilterData
    {
        public ChartFilterData()
        {
            ClientIds = new List<string>();
            ReportTypeIds = new List<string>();
            IsFullAppOnly = false;
        }

        public int ChartSubType { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public List<string> ClientIds { get; set; }

        public List<string> ReportTypeIds { get; set; }

        public bool IsAllClients { get; set; }

        public bool IsAllReportTypes { get; set; }

        public bool IsFullAppOnly { get; set; }

        public string LocalTimeZone { get; set; }
    }
}
