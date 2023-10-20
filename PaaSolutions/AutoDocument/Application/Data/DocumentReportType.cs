using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using System.Configuration;

namespace AutoDocument.Application.Data
{
    public class DocumentReportType : Enumeration
    {
        public static readonly DocumentReportType DailyReport = new DocumentReportType(0, "Daily Activity for {0} on {1}");

        public static readonly DocumentReportType ReceiptLog = new DocumentReportType(1, "Receipt Record for {0} from {1} to {2}");

        public static readonly DocumentReportType Calendar = new DocumentReportType(2, "Calendar from {0} to {1}");

        public static readonly DocumentReportType MonthlyScreener = new DocumentReportType(3, "{0}'s Completed Applications for {1}");

        public static readonly DocumentReportType ApplicationVolume = new DocumentReportType(4, "Application Volume Report {0}");

        public static readonly DocumentReportType YearlyBusiness = new DocumentReportType(5, "Yearly Report for {0}");

        public static readonly int DailyReportValue = 0;

        public static readonly int ReceiptLogValue = 1;

        public static readonly int CalendarValue = 2;

        public static readonly int MonthlyScreenerValue = 3;

        public static readonly int ApplicationVolumeValue = 4;

        public static readonly int YearlyBusinessValue = 5;

        public DocumentReportType()
        {
        }

        private DocumentReportType(int value, string displayName)
            : base(value, displayName)
        {
        }

        public string ToSaveFilename
        {
            get
            {
                switch (this.Value)
                {
                    case 0:
                        return "Daily Activity For {0} On {1}";
                    case 1:
                        return "Bemrose Consulting";
                    case 2:
                        return "Calendar From {0} To {1}";
                    case 3:
                        return "{0} Completed Applications For {1}";
                    case 4:
                        return "Application Volume Report {0}";
                    case 5:
                        return "Yearly Report For {0}";
                }
                return "";
            }
        }

        public static DocumentReportType CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return DocumentReportType.DailyReport;
                case 1:
                    return DocumentReportType.ReceiptLog;
                case 2:
                    return DocumentReportType.Calendar;
                case 3:
                    return DocumentReportType.MonthlyScreener;
                case 4:
                    return DocumentReportType.ApplicationVolume;
                case 5:
                    return DocumentReportType.YearlyBusiness;
                default:
                    return null;
            }
        }
    }
}
