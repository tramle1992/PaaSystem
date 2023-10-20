using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditReport.Application.Data
{
    public class ReportLightweightData
    {
        public ReportLightweightData()
        {
            this.Type = "Microbilt Trans Union";
        }

        public string ReportId { get; set; }

        public string ApplicationId { get; set; }

        public string Type { get; set; }

        public string EndUser { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string StatusCode { get; set; }

        public string PulledBy { get; set; }
    }
}
