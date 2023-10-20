using Common.Infrastructure.Query;
using CreditReport.Domain.Model;
using CreditReport.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditReport.Application
{
    public class CreditReporQueryService : QueryService
    {
        public CreditReporQueryService()
        {
            this.reportRepository = new ReportRepository();
        }

        readonly ReportRepository reportRepository;

        public List<Report> GetReportByAppId(string appId)
        {
            return reportRepository.FindByAppId(appId);
        }

        public Report GetReportByReportAndAppId(string reportId, string appId)
        {
            return reportRepository.FindByReportAndAppId(reportId, appId);
        }

        public List<Report> GetReportByDate(string date, string timezone)
        {
            return reportRepository.FindByDate(date, timezone);
        }
    }
}
