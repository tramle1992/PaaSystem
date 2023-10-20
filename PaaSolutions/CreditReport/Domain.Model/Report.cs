using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditReport.Domain.Model
{
    public class Report : EntityWithCompositeId, IAggregateRoot
    {
        public Report(Report creditReport) : this(creditReport.ReportId, creditReport.ApplicationId)
        {
            this.Type = creditReport.Type;
            this.DataBlob = creditReport.DataBlob;
            this.CreatedAt = creditReport.CreatedAt;
            this.UpdatedAt = creditReport.UpdatedAt;
            this.StatusCode = creditReport.StatusCode;
            this.PulledBy = creditReport.PulledBy;
        }

        public Report(string reportId, string applicationId): this()
        {
            this.ReportId = reportId;
            this.ApplicationId = applicationId;
        }

        public Report()
        {
            this.Type = "Microbilt Trans Union";
        }

        public string ReportId { get; set; }

        public string ApplicationId { get; set; }

        public string Type { get; set; }

        public string EndUser { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string DataBlob { get; set; }

        public string StatusCode { get; set; }

        public string PulledBy { get; set; }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.ReportId;
            yield return this.ApplicationId;
            yield return this.Type;
            yield return this.EndUser;
            yield return this.StatusCode;
            yield return this.PulledBy;
        }

        public override string ToString()
        {
            return "Report[reportId=" + this.ReportId
                + ", applicationId=" + this.ApplicationId
                + ", type=" + this.Type 
                + ", endUser=" + this.EndUser
                + ", statusCode=" + this.StatusCode
                + ", pulledBy=" + this.PulledBy + "]";
        }
    }
}
