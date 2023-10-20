using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDocument.Domain.Model
{
    public class DocumentReportMessage : Enumeration
    {
        public static readonly DocumentReportMessage DailyReport = new DocumentReportMessage(0, "Daily Activity for {0} on {1}");

        public static readonly DocumentReportMessage ReceiptLog = new DocumentReportMessage(1, "Receipt Record for {0} from {1} to {2}");

        public static readonly DocumentReportMessage Calendar = new DocumentReportMessage(2, "Calendar from {0} to {1}");

        public static readonly DocumentReportMessage MonthlyScreener = new DocumentReportMessage(3, "{0}'s Completed Applications for {1}");

        public static readonly DocumentReportMessage ApplicationVolume = new DocumentReportMessage(4, "Application Volume Report {0}");

        public static readonly DocumentReportMessage YearlyBusiness = new DocumentReportMessage(5, "Yearly Report for {0}");

        public DocumentReportMessage()
        {
        }

        private DocumentReportMessage(int value, string displayName)
            : base(value, displayName)
        {
        }

        public static DocumentReportMessage CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return DocumentReportMessage.DailyReport;
                case 1:
                    return DocumentReportMessage.ReceiptLog;
                case 2:
                    return DocumentReportMessage.Calendar;
                case 3:
                    return DocumentReportMessage.MonthlyScreener;
                case 4:
                    return DocumentReportMessage.ApplicationVolume;
                case 5:
                    return DocumentReportMessage.YearlyBusiness;
                default:
                    return null;
            }
        }
    }
}
