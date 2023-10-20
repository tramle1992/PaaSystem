using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDocument.Application.Data
{
    public class CreditReportViewItem
    {
        public CreditReportViewItem(string reportId, string applicationId)
        {
            this.ReportId = reportId;
            this.ApplicationId = applicationId;
        }

        public string ApplicantName { get; set; }

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
