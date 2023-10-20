using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;


namespace AutoDocument.Application.Data
{
    public interface IChartSubType
    {
        int SubTypeValue { get; }
        string SubTypeName { get; }
        int From { get; }
        int Type { get; }
        string ChartDescription { get; }
    }

    public class PieChartSubTypeApplications : Enumeration, IChartSubType
    {
        public PieChartSubTypeApplications()
        {

        }

        private PieChartSubTypeApplications(int value, string displayName)
            : base(value, displayName)
        {

        }

        public int From
        {
            get { return (int)ChartFrom.FromApplications; }
        }

        public int SubTypeValue
        {
            get { return this.Value; }
        }

        public string SubTypeName
        {
            get { return this.DisplayName; }
        }

        public int Type
        {
            get { return (int)ChartType.PieChartType; }
        }

        public string ChartDescription
        {
            get
            {
                string description = "";
                switch(this.Value)
                {
                    case 0:
                        description = "This chart shows the number of residential, employment, and other types of applications as a percentage of all that were received during the two dates provided.";
                        break;
                    case 1:
                        description = "This chart shows the percentage of applications that are completed by each user.  You may find it useful to select only residential, employment, and commercial application types to chart only the full reports.";
                        break;
                    case 2:
                        description = "With this chart you can see the percentage of applications that are completed on each successive day in process.  Only days Monday-Friday are counted.  It is best used by selecting specific report types to provide a meaningful comparison.";
                        break;
                    case 3:
                        description = "This is a comparison of the number of applications that are entered during specific hours of the day.  It is useful for monitoring scheduling weaknesses or daily slow times.";
                        break;
                    case 4:
                        description = "This is a comparison of the number of applications that are entered during specific hours of the day. You can view the daily consistency of the overall screening and review process.";
                        break;
                    case 5:
                        description = "This chart shows the percentage of applications that were received during each month between the dates that you provided.";
                        break;
                    case 6:
                        description = "This chart shows the percentage of applications that were given each recommendation.";
                        break;
                }
                return description;
            }
        }

        public static readonly PieChartSubTypeApplications AppsReceivedByType = new PieChartSubTypeApplications(0, "Applications Received by Type");

        public static readonly PieChartSubTypeApplications AppsCompletedByUsers = new PieChartSubTypeApplications(1, "Applications Completed by Users");

        public static readonly PieChartSubTypeApplications AppsCompletedByTurnaround = new PieChartSubTypeApplications(2, "Applications Completed by Turnaround");

        public static readonly PieChartSubTypeApplications AppsReceivedByHour = new PieChartSubTypeApplications(3, "Applications Received by Hour");

        public static readonly PieChartSubTypeApplications AppsCompletedByHour = new PieChartSubTypeApplications(4, "Applications Completed by Hour");

        public static readonly PieChartSubTypeApplications AppsReceivedByMonth = new PieChartSubTypeApplications(5, "Applications Received by Month");

        public static readonly PieChartSubTypeApplications AppsCompletedByRecommendation = new PieChartSubTypeApplications(6, "Applications Completed by Recommendation");

        public static PieChartSubTypeApplications CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return PieChartSubTypeApplications.AppsReceivedByType;
                case 1:
                    return PieChartSubTypeApplications.AppsCompletedByUsers;
                case 2:
                    return PieChartSubTypeApplications.AppsCompletedByTurnaround;
                case 3:
                    return PieChartSubTypeApplications.AppsReceivedByHour;
                case 4:
                    return PieChartSubTypeApplications.AppsCompletedByHour;
                case 5:
                    return PieChartSubTypeApplications.AppsReceivedByMonth;
                case 6:
                    return PieChartSubTypeApplications.AppsCompletedByRecommendation;
                default:
                    return null;
            }
        }
    }

    public class PieChartSubTypeInvoices : Enumeration, IChartSubType
    {
        public PieChartSubTypeInvoices()
        {

        }

        private PieChartSubTypeInvoices(int value, string displayName)
            : base(value, displayName)
        {

        }

        public int SubTypeValue
        {
            get { return this.Value; }
        }

        public string SubTypeName
        {
            get { return this.DisplayName; }
        }

        public int From
        {
            get { return (int)ChartFrom.FromInvoices; }
        }

        public int Type
        {
            get { return (int)ChartType.PieChartType; }
        }

        public string ChartDescription
        {
            get
            {
                string description = "";
                switch (this.Value)
                {
                    case 0:
                        description = "This chart shows you the percentage of past due balances that is owed by each client.";
                        break;
                    case 1:
                        description = "This chart shows you the percentage of past due balances that are from invoices during each month.";
                        break;
                    case 2:
                        description = "This chart shows the unpaid balances in relation to the past due balances.";
                        break;
                    case 3:
                        description = "This chart shows you the amount of money that has been credited to invoices during the months selected.";
                        break;
                    case 4:
                        description = "This chart shows you the total invoice amount for all invoices during each month.";
                        break;
                    case 5:
                        description = "This chart shows the percentage of invoices that are paid in full by a certain length of time.";
                        break;
                }
                return description;
            }
        }


        public static readonly PieChartSubTypeInvoices PastDueBalancesByClient = new PieChartSubTypeInvoices(0, "Past Due Balances by Client");

        public static readonly PieChartSubTypeInvoices PastDueBalancesByMonth = new PieChartSubTypeInvoices(1, "Past Due Balances by Month");

        public static readonly PieChartSubTypeInvoices ReceiveableBalances = new PieChartSubTypeInvoices(2, "Receiveable Balances");

        public static readonly PieChartSubTypeInvoices InvoiceCreditByMonth = new PieChartSubTypeInvoices(3, "Invoice Credit by Month");

        public static readonly PieChartSubTypeInvoices InvoiceVolumnByMonth = new PieChartSubTypeInvoices(4, "Invoice Volumn by Month");

        public static readonly PieChartSubTypeInvoices InvoicePaymentHistory = new PieChartSubTypeInvoices(5, "Invoice Payment History");

        public static PieChartSubTypeInvoices CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return PieChartSubTypeInvoices.PastDueBalancesByClient;
                case 1:
                    return PieChartSubTypeInvoices.PastDueBalancesByMonth;
                case 2:
                    return PieChartSubTypeInvoices.ReceiveableBalances;
                case 3:
                    return PieChartSubTypeInvoices.InvoiceCreditByMonth;
                case 4:
                    return PieChartSubTypeInvoices.InvoiceVolumnByMonth;
                case 5:
                    return PieChartSubTypeInvoices.InvoicePaymentHistory;
                default:
                    return null;
            }
        }
    }

    public class ChartSubTypeCommon : Enumeration
    {
        public ChartSubTypeCommon()
        {

        }

        private ChartSubTypeCommon(int value, string displayName)
            : base(value, displayName)
        {

        }

        public int SubTypeValue
        {
            get { return this.Value; }
        }

        public string SubTypeName
        {
            get { return this.DisplayName; }
        }

        public int From
        {
            get { return (int)ChartFrom.FromCommon; }
        }

        public int Type
        {

            get
            {
                if (this.Value == 3 || this.Value == 4)
                {
                    return (int)ChartType.LineChartType;
                }
                return (int)ChartType.PieChartType;
            }
        }

        public string ChartDescription { get { return ""; } }

        public static readonly ChartSubTypeCommon PercentageAppsReceivedByType = new ChartSubTypeCommon(0, "Percentage of Apps. Received By Type");

        public static readonly ChartSubTypeCommon PercentageAppsCompletedByUsers = new ChartSubTypeCommon(1, "Percentage of Apps. Completed By Users");

        public static readonly ChartSubTypeCommon PercentageAppsCompletedByTurnaround = new ChartSubTypeCommon(2, "Percentage of Apps. Completed By Turnaround");

        public static readonly ChartSubTypeCommon AppsTurnaroundEachUser = new ChartSubTypeCommon(3, "Applications Turnaround for each User");

        public static readonly ChartSubTypeCommon AppsCompletedEachUser = new ChartSubTypeCommon(4, "Applications Completed by each User");

        public static ChartSubTypeCommon CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return ChartSubTypeCommon.PercentageAppsReceivedByType;
                case 1:
                    return ChartSubTypeCommon.PercentageAppsCompletedByUsers;
                case 2:
                    return ChartSubTypeCommon.PercentageAppsCompletedByTurnaround;
                case 3:
                    return ChartSubTypeCommon.AppsTurnaroundEachUser;
                case 4:
                    return ChartSubTypeCommon.AppsCompletedEachUser;
                default:
                    return null;
            }
        }
    }

    public class BarChartSubTypeApplications : Enumeration, IChartSubType
    {
        public BarChartSubTypeApplications()
        {

        }

        private BarChartSubTypeApplications(int value, string displayName)
            : base(value, displayName)
        {

        }

        public int From
        {
            get { return (int)ChartFrom.FromApplications; }
        }

        public int SubTypeValue
        {
            get { return this.Value; }
        }

        public string SubTypeName
        {
            get { return this.DisplayName; }
        }

        public int Type
        {
            get { return (int)ChartType.BarChartType; }
        }

        public string ChartDescription
        {
            get
            {
                string description = "";
                switch(this.Value)
                {
                    case 0:
                        description = "This chart is a visual, side by side comparison of weekly application volume.";
                        break;
                    case 1:
                        description = "This chart shows the weekly volume of each major report type. It is very useful for monitoring the weekly, relative number of all of the types at once.";
                        break;
                    case 2:
                        description = "This chart will show you the number of applications that were completed by each user.  It is best used with specific report types to provide a meaningful comparison.";
                        break;
                    case 3:
                        description = "With this chart you can see the number of applications that were completed listed by the number of business days that they were in-process.";
                        break;
                    case 4:
                        description = "With this chart you can monitor the most efficient times of day in terms of application output.  It is often used with only full report types.";
                        break;
                    case 5:
                        description = "This is a comparison of the number of applications received for each client that was selected during the dates used to create the chart.";
                        break;
                    case 6:
                        description = "With this chart you can take a look at the volume of applications during each month over a longer period of time.";
                        break;
                }
                return description;
            }
        }

        public static readonly BarChartSubTypeApplications AppsReceivedByWeek = new BarChartSubTypeApplications(0, "Applications Received by Week");

        public static readonly BarChartSubTypeApplications AppReceivedWeeklyByType = new BarChartSubTypeApplications(1, "Applications Received Weekly by Type");

        public static readonly BarChartSubTypeApplications AppsCompletedByUsers = new BarChartSubTypeApplications(2, "Applications Completed by Users");

        public static readonly BarChartSubTypeApplications AppsCompletedByTurnaround = new BarChartSubTypeApplications(3, "Applications Completed by Turnaround");

        public static readonly BarChartSubTypeApplications AppsCompletedByHour = new BarChartSubTypeApplications(4, "Applications Completed by Hour");

        public static readonly BarChartSubTypeApplications AppsReceivedByClient = new BarChartSubTypeApplications(5, "Applications Received by Client");

        public static readonly BarChartSubTypeApplications AppsReceivedByMonth = new BarChartSubTypeApplications(6, "Applications Received by Month");

        public static BarChartSubTypeApplications CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return BarChartSubTypeApplications.AppsReceivedByWeek;
                case 1:
                    return BarChartSubTypeApplications.AppReceivedWeeklyByType;
                case 2:
                    return BarChartSubTypeApplications.AppsCompletedByUsers;
                case 3:
                    return BarChartSubTypeApplications.AppsCompletedByTurnaround;
                case 4:
                    return BarChartSubTypeApplications.AppsCompletedByHour;
                case 5:
                    return BarChartSubTypeApplications.AppsReceivedByClient;
                case 6:
                    return BarChartSubTypeApplications.AppsReceivedByMonth;
                default:
                    return null;
            }
        }
    }

    public class BarChartSubTypeInvoices : Enumeration, IChartSubType
    {
        public BarChartSubTypeInvoices()
        {

        }

        private BarChartSubTypeInvoices(int value, string displayName)
            : base(value, displayName)
        {

        }

        public int SubTypeValue
        {
            get { return this.Value; }
        }

        public string SubTypeName
        {
            get { return this.DisplayName; }
        }

        public int From
        {
            get { return (int)ChartFrom.FromInvoices; }
        }

        public int Type
        {
            get { return (int)ChartType.BarChartType; }
        }

        public string ChartDescription
        {
            get
            {
                string description = "";
                switch(this.Value)
                {
                    case 0:
                        description = "This chart shows the current past due balances for each month.";
                        break;
                    case 1:
                        description = "This chart shows the past due and unpaid balances for the months that were selected.";
                        break;
                    case 2:
                        description = "This chart shows the total invoice volume for each month.";
                        break;
                    case 3:
                        description = "This chart shows the total account credits for each month.";
                        break;
                    case 4:
                        description = "This chart shows the number of invoices and the average number of items for each month.";
                        break;
                    case 5:
                        description = "This chart shows the number of invoices that the selected clients have paid early, on time, or late.";
                        break;
                }
                return description;
            }
        }

        public static readonly BarChartSubTypeInvoices InvoicePastDuesByMonth = new BarChartSubTypeInvoices(0, "Invoice Past Dues by Month");

        public static readonly BarChartSubTypeInvoices ReceiveableBalanceByStatus = new BarChartSubTypeInvoices(1, "Receiveable Balance by Status");

        public static readonly BarChartSubTypeInvoices InvoiceVolumeByMonth = new BarChartSubTypeInvoices(2, "Invoice Volume by Month");

        public static readonly BarChartSubTypeInvoices AmountCreditsByMonth = new BarChartSubTypeInvoices(3, "Amount Credits by Month");

        public static readonly BarChartSubTypeInvoices InvoiceCountAndItemAverageByMonth = new BarChartSubTypeInvoices(4, "Invoice Count and Item Average by Month");

        public static readonly BarChartSubTypeInvoices PaymentHistorybyClient = new BarChartSubTypeInvoices(5, "Payment History by Client");

        public static BarChartSubTypeInvoices CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return BarChartSubTypeInvoices.InvoicePastDuesByMonth;
                case 1:
                    return BarChartSubTypeInvoices.ReceiveableBalanceByStatus;
                case 2:
                    return BarChartSubTypeInvoices.InvoiceVolumeByMonth;
                case 3:
                    return BarChartSubTypeInvoices.AmountCreditsByMonth;
                case 4:
                    return BarChartSubTypeInvoices.InvoiceCountAndItemAverageByMonth;
                case 5:
                    return BarChartSubTypeInvoices.PaymentHistorybyClient;
                default:
                    return null;
            }
        }
    }

    public class LineChartSubTypeApplications : Enumeration, IChartSubType
    {
        public LineChartSubTypeApplications()
        {

        }

        private LineChartSubTypeApplications(int value, string displayName)
            : base(value, displayName)
        {

        }

        public int From
        {
            get { return (int)ChartFrom.FromApplications; }
        }

        public int SubTypeValue
        {
            get { return this.Value; }
        }

        public string SubTypeName
        {
            get { return this.DisplayName; }
        }

        public int Type
        {
            get { return (int)ChartType.LineChartType; }
        }

        public string ChartDescription
        {
            get
            {
                string description = "";
                switch (this.Value)
                {
                    case 0:
                        description = "With this chart you can examine weekly trends in volume in contrast to the other weeks between the chart dates.";
                        break;
                    case 1:
                        description = "With this chart you can examine weekly trends in application completion in contrast to the other weeks between the chart dates.";
                        break;
                    case 2:
                        description = "This is a chart of the number of applications that were completed by each user relative to the applications completed by others.  It is best used by selecting specific report types.";
                        break;
                    case 3:
                        description = "This is a chart of the weekly output of each user, in relation to the output of others.  It is often helpful to limit the report type when using this chart.";
                        break;
                    case 4:
                        description = "This is a chart showing the number if business days taken to process applications by each user. For a meaningful comparison, limit the report type when using this chart.";
                        break;
                    case 5:
                        description = "This chart shows you the number of applications that have been completed for each client you select.  It is best used with less than 20 clients.";
                        break;
                    case 6:
                        description = "This chart shows you the number of applications received for each month, and how each relates to the other months selected.";
                        break;
                }
                return description;
            }
        }

        public static readonly LineChartSubTypeApplications AppsReceivedByWeek = new LineChartSubTypeApplications(0, "Applications Received by Week");

        public static readonly LineChartSubTypeApplications AppCompletedByWeek = new LineChartSubTypeApplications(1, "Applications Completed by Week");

        public static readonly LineChartSubTypeApplications AppsCompletedDailyByUsers = new LineChartSubTypeApplications(2, "Applications Completed Daily by Users");

        public static readonly LineChartSubTypeApplications AppsCompletedWeeklyByUsers = new LineChartSubTypeApplications(3, "Applications Completed Weekly by Users");

        public static readonly LineChartSubTypeApplications AppsCompletedByTurnaroundTime = new LineChartSubTypeApplications(4, "Applications Completed by Turnaround Time");

        public static readonly LineChartSubTypeApplications AppsReceivedByClient = new LineChartSubTypeApplications(5, "Applications Received by Client Name");

        public static readonly LineChartSubTypeApplications AppsReceivedByMonth = new LineChartSubTypeApplications(6, "Applications Received by Month");

        public static LineChartSubTypeApplications CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return LineChartSubTypeApplications.AppsReceivedByWeek;
                case 1:
                    return LineChartSubTypeApplications.AppCompletedByWeek;
                case 2:
                    return LineChartSubTypeApplications.AppsCompletedDailyByUsers;
                case 3:
                    return LineChartSubTypeApplications.AppsCompletedWeeklyByUsers;
                case 4:
                    return LineChartSubTypeApplications.AppsCompletedByTurnaroundTime;
                case 5:
                    return LineChartSubTypeApplications.AppsReceivedByClient;
                case 6:
                    return LineChartSubTypeApplications.AppsReceivedByMonth;
                default:
                    return null;
            }
        }
    }

    public class LineChartSubTypeInvoices : Enumeration, IChartSubType
    {
        public LineChartSubTypeInvoices()
        {

        }

        private LineChartSubTypeInvoices(int value, string displayName)
            : base(value, displayName)
        {

        }

        public int From
        {
            get { return (int)ChartFrom.FromInvoices; }
        }

        public int SubTypeValue
        {
            get { return this.Value; }
        }

        public string SubTypeName
        {
            get { return this.DisplayName; }
        }

        public int Type
        {
            get { return (int)ChartType.LineChartType; }
        }

        public string ChartDescription
        {
            get
            {
                string description = "";
                switch (this.Value)
                {
                    case 0:
                        description = "This chart shows the number of invoices that are in each payment status during the chart dates.";
                        break;
                    case 1:
                        description = "This chart shows the number of invoices generated and the average number of items per month.";
                        break;
                    case 2:
                        description = "This chart shows the total billing volume for each month selected.";
                        break;
                    case 3:
                        description = "This chart shows the total amount of money credited to invoices for each month";
                        break;
                    case 4:
                        description = "This chart shows the number of invoices that were paid early, on time, or late between the months selected.";
                        break;
                    case 5:
                        description = "This chart shows the number of invoices that each client has paid on early, time, or late.";
                        break;
                }
                return description;
            }
        }

        public static readonly LineChartSubTypeInvoices InvoiceStatusByMonth = new LineChartSubTypeInvoices(0, "Invoice Satus by Month");

        public static readonly LineChartSubTypeInvoices InvoiceQuantityEfficiency = new LineChartSubTypeInvoices(1, "Invoice Quantity and Efficiency");

        public static readonly LineChartSubTypeInvoices InvoiceVolumeByMonth = new LineChartSubTypeInvoices(2, "Invoice Volume by Month");

        public static readonly LineChartSubTypeInvoices AmountCreditsByMonth = new LineChartSubTypeInvoices(3, "Amount Credits by Month");

        public static readonly LineChartSubTypeInvoices InvoicePaymentHistory = new LineChartSubTypeInvoices(4, "Invoice Payment History");

        public static readonly LineChartSubTypeInvoices InvoicePaymentHistoryByClient = new LineChartSubTypeInvoices(5, "Invoice Payment History by Client");

        public static LineChartSubTypeInvoices CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return LineChartSubTypeInvoices.InvoiceStatusByMonth;
                case 1:
                    return LineChartSubTypeInvoices.InvoiceQuantityEfficiency;
                case 2:
                    return LineChartSubTypeInvoices.InvoiceVolumeByMonth;
                case 3:
                    return LineChartSubTypeInvoices.AmountCreditsByMonth;
                case 4:
                    return LineChartSubTypeInvoices.InvoicePaymentHistory;
                case 5:
                    return LineChartSubTypeInvoices.InvoicePaymentHistoryByClient;
                default:
                    return null;
            }
        }
    }
}
