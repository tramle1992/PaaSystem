using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDocument.Application.Data
{
    public abstract class DocumentReportOption
    {
        public DocumentReportType DocumentReportType { get; set; }

        public abstract string GetReportMessage();
        public abstract string GetToSaveFilename();
    }

    public class DocumentReportDailyReportOption : DocumentReportOption
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime ReportDate { get; set; }

        public bool IsEveryone { get; set; }

        public string LocalTimeZone { get; set; }

        public DocumentReportDailyReportOption(string userId, string userName, DateTime reportDate, bool isEveryone, string localTimeZone)
        {
            this.DocumentReportType = DocumentReportType.DailyReport;
            this.UserId = userId;
            this.UserName = userName;
            this.ReportDate = reportDate;
            this.IsEveryone = isEveryone;
            this.LocalTimeZone = localTimeZone;
        }

        public override string GetReportMessage()
        {
            string message = this.DocumentReportType.DisplayName;
            return string.Format(message, this.UserName, this.ReportDate.ToString("MM/dd/yyyy"));
        }

        public override string GetToSaveFilename()
        {
            string filename = this.DocumentReportType.ToSaveFilename;
            return string.Format(filename, this.UserName, this.ReportDate.ToString("MMddyyyy"));
        }
    }

    public class DocumentReportReceiptLogOption : DocumentReportOption
    {
        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public DateTime ReportFrom { get; set; }

        public DateTime ReportTo { get; set; }

        public string LocalTimeZone { get; set; }

        public DocumentReportReceiptLogOption(string clientId, string clientName, DateTime reportFrom, DateTime reportTo, string localTimeZone)
        {
            this.DocumentReportType = DocumentReportType.ReceiptLog;
            this.ClientId = clientId;
            this.ClientName = clientName;
            this.ReportFrom = reportFrom;
            this.ReportTo = reportTo;
            this.LocalTimeZone = localTimeZone;
        }

        public override string GetReportMessage()
        {
            string message = this.DocumentReportType.DisplayName;
            return string.Format(message, ClientName, ReportFrom.ToString("MM/dd/yyyy"), ReportTo.ToString("MM/dd/yyyy"));
        }

        public override string GetToSaveFilename()
        {
            string filename = this.DocumentReportType.ToSaveFilename;
            return string.Format(filename, ClientName, ReportFrom.ToString("MMddyyyy"), ReportTo.ToString("MMddyyyy"));
        }
    }

    public class DocumentReportCalendarOption : DocumentReportOption
    {
        public DateTime CalendarFrom { get; set; }

        public DateTime CalendarTo { get; set; }

        public DocumentReportCalendarOption(DateTime calendarFrom, DateTime calendarTo)
        {
            this.DocumentReportType = DocumentReportType.Calendar;
            this.CalendarFrom = calendarFrom;
            this.CalendarTo = calendarTo;
        }

        public override string GetReportMessage()
        {
            string message = this.DocumentReportType.DisplayName;
            return string.Format(message, CalendarFrom.ToString("MM/yyyy"), CalendarTo.ToString("MM/yyyy"));
        }

        public override string GetToSaveFilename()
        {
            string filename = this.DocumentReportType.ToSaveFilename;
            return string.Format(filename, CalendarFrom.ToString("MMyyyy"), CalendarTo.ToString("MMyyyy"));
        }
    }

    public class DocumentReportMonthlyScreenerOption : DocumentReportOption
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime ReportDate { get; set; }

        public string LocalTimeZone { get; set; }

        public DocumentReportMonthlyScreenerOption(string userId, string userName, DateTime reportDate, string localTimeZone)
        {
            this.DocumentReportType = DocumentReportType.MonthlyScreener;
            this.UserId = userId;
            this.UserName = userName;
            this.ReportDate = reportDate;
            LocalTimeZone = localTimeZone;
        }

        public override string GetReportMessage()
        {
            string message = this.DocumentReportType.DisplayName;
            return string.Format(message, this.UserName, this.ReportDate.ToString("MM/yyyy"));
        }

        public override string GetToSaveFilename()
        {
            string filename = this.DocumentReportType.ToSaveFilename;
            return string.Format(filename, this.UserName, this.ReportDate.ToString("MMyyyy"));
        }
    }

    public class DocumentReportApplicationVolumeOption : DocumentReportOption
    {
        public DateTime ReportDate { get; set; }
        public string LocalTimeZone { get; set; }

        public DocumentReportApplicationVolumeOption(DateTime reportDate, string localTimeZone)
        {
            this.DocumentReportType = DocumentReportType.ApplicationVolume;
            this.ReportDate = reportDate;
            LocalTimeZone = localTimeZone;
        }

        public override string GetReportMessage()
        {
            string message = this.DocumentReportType.DisplayName;
            return string.Format(message, this.ReportDate.ToString("MM/yyyy"));
        }

        public override string GetToSaveFilename()
        {
            string filename = this.DocumentReportType.ToSaveFilename;
            return string.Format(filename, this.ReportDate.ToString("MMyyyy"));
        }
    }

    public class DocumentReportYearlyBusinessOption : DocumentReportOption
    {
        public int ReportYear { get; set; }

        public string LocalTimeZone { get; set; }

        public DocumentReportYearlyBusinessOption(int reportYear, string localTimeZone)
        {
            this.DocumentReportType = DocumentReportType.YearlyBusiness;
            this.ReportYear = reportYear;
            LocalTimeZone = localTimeZone;
        }

        public override string GetReportMessage()
        {
            string message = this.DocumentReportType.DisplayName;
            return string.Format(message, this.ReportYear);
        }

        public override string GetToSaveFilename()
        {
            string filename = this.DocumentReportType.ToSaveFilename;
            return string.Format(filename, ReportYear);
        }
    }
}
