using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.CreditReports
{
    public class CreditReportData
    {
        public string ReportId { get; set; }

        public string ApplicationId { get; set; }

        public string Type { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string DataBlob { get; set; }
    }
}
