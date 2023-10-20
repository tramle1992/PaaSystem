using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Application
{
    public class GlobalConstants
    {
        public const char Sep = '¥';
        public const char RecSep = '£';
        public const char UserSep = '§';
        public const char Hyphen = '-';

        public const string DefaultReportTypeName = "Res1";

        public static readonly List<string> FullApps = new List<string>() { "Commercial", "Employment", "Residential" };

        public static readonly string Residential = "Residential";
        public static readonly string Employment = "Employment";
        public static readonly string Commercial = "Commercial";
        public static readonly string CrimminalOnly = "Criminal";
        public static readonly string CreditCrimminal = "Credit/Criminal";
        public static readonly string CreditOnly = "Credit";

        public static readonly string Roommate = "Roommate";

        public static readonly string DefaultApiUri = "http://localhost:56714";
        public static readonly string MoneyFormat = "#,###,###,##0.00";

        public static readonly string SYS_CONFIG_ID = "0";
        public static readonly string DEFAULT_BACKUP_LOCATION = "E:\\PAA-Prj\\GIT";
        public static readonly TimeSpan DEFAULT_BACKUP_TIME = new TimeSpan(22, 0, 0);
        public static readonly TimeSpan DEFAULT_WORKING_HOUR_FROM = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan DEFAULT_WORKING_HOUR_TO = new TimeSpan(18, 0, 0);
        public static readonly int DEFAULT_NUMBER_APPS_BONUS = 22;
        public static readonly string DEFAULT_BILLING_EMAIL_CONFIRMATION = "bill@bemroseconsulting.com";
        public static readonly string DEFAULT_FTP_URI = "ftp://127.0.0.1";
        public static readonly string DEFAULT_FTP_USERNAME = "jadele";
        public static readonly string DEFAULT_FTP_PASSWORD = "123456";
        public static readonly int DEFAULT_AUTO_SAVE_TIME_INTERVAL = 60; // second
        public static readonly int DEFAULT_CHECKING_LOGOUT_TIME_INTERVAL = 120; // second
        public static readonly int DEFAULT_FORCE_EXIT_AFTER_TIME = 900; // second
        
    }
}
