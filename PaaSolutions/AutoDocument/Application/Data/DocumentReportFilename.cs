using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDocument.Application.Data
{
    public class DocumentReportFilename : Enumeration
    {
        public static readonly DocumentReportFilename DailyReport = new DocumentReportFilename(0, "Daily_Activity_for_{0}_on_{1}");

        public static readonly DocumentReportFilename ReceiptLog = new DocumentReportFilename(1, "BEMROSE CONSULTING");

        public static readonly DocumentReportFilename Calendar = new DocumentReportFilename(2, "Calendar_from_{0}_to_{1}");

        public static readonly DocumentReportFilename MonthlyScreener = new DocumentReportFilename(3, "{0}_Completed_Applications_for_{1}");

        public static readonly DocumentReportFilename ApplicationVolume = new DocumentReportFilename(4, "Application_Volume_Report_{0}");

        public static readonly DocumentReportFilename YearlyBusiness = new DocumentReportFilename(5, "Yearly_Report_for_{0}");

        public DocumentReportFilename()
        {
        }

        private DocumentReportFilename(int value, string displayName)
            : base(value, displayName)
        {
        }

        public static DocumentReportFilename CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return DocumentReportFilename.DailyReport;
                case 1:
                    return DocumentReportFilename.ReceiptLog;
                case 2:
                    return DocumentReportFilename.Calendar;
                case 3:
                    return DocumentReportFilename.MonthlyScreener;
                case 4:
                    return DocumentReportFilename.ApplicationVolume;
                case 5:
                    return DocumentReportFilename.YearlyBusiness;
                default:
                    return null;
            }
        }
    }
}
