using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Query;
using AutoDocument.Application.Data;
using System.Data;
using AutoDocument.Infrastructure;
using Core.Application;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using Core.Application.Command.ExploreApps;
using Core.Application.Helper;
using Dapper;
using Common.Application;

namespace AutoDocument.Application
{
    public class DocumentReportQueryService : QueryService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IList<UserDisplayInfoData> GetAllUsers()
        {
            List<UserDisplayInfoData> lstResult = new List<UserDisplayInfoData>();

            AutoDocumentRepository repository = new AutoDocumentRepository();
            lstResult = repository.GetListUsers();

            return lstResult;
        }

        public DocumentReportData GetDailyReportData(DocumentReportDailyReportOption option)
        {
            Dictionary<string, string> bookmarkData = new Dictionary<string, string>();
            Dictionary<int, DataTable> tableData = new Dictionary<int, DataTable>();
            AutoDocumentRepository repository = new AutoDocumentRepository();

            bool isEveryone = option.IsEveryone;

            bookmarkData.Add("Date", option.ReportDate.ToString("M/d/yy"));
            bookmarkData.Add("Username", option.UserName);
            bookmarkData.Add("STB", "");
            

            DataTable table = new DataTable();
            table.Columns.Add("Num", typeof(string));
            table.Columns.Add("Applicant", typeof(string));
            table.Columns.Add("Client", typeof(string));
            table.Columns.Add("Received", typeof(string));
            table.Columns.Add("Completed", typeof(string));
            table.Columns.Add("Turnaround", typeof(string));

            List<DailyReportData> dailyData = new List<DailyReportData>();
            dailyData = repository.GetDailyReport(option.UserName, option.ReportDate, option.IsEveryone);

            bookmarkData.Add("TotalFulls", dailyData.Count(x => x.IsFullApp == true).ToString());
            bookmarkData.Add("TotalOtherApps", dailyData.Count(x => x.IsFullApp == false).ToString());

            if (dailyData.Count > 0)
            {
                int colIndx = 1;
                foreach (var data in dailyData)
                {
                    table.Rows.Add(colIndx, data.Applicant, data.ClientName, data.RecievedDate, data.CompletedDate, data.TurnAround);
                    colIndx++;
                }
            }

            tableData.Add(1, table);

            return new DocumentReportData(bookmarkData, tableData);
        }

        public DocumentReportData GetReceiptLogData(DocumentReportReceiptLogOption option)
        {
            Dictionary<string, string> bookmarkData = new Dictionary<string, string>();
            Dictionary<int, DataTable> tableData = new Dictionary<int, DataTable>();
            DataTable table = new DataTable();
            table.Columns.Add("Num", typeof(string));
            table.Columns.Add("Applicant Name", typeof(string));
            table.Columns.Add("Check No", typeof(string));
            table.Columns.Add("Amount", typeof(string));

            ClientInfoQueryService clientQueryService = new ClientInfoQueryService();
            ExploreAppsQueryService exploreAppQueryService = new ExploreAppsQueryService();
            ClientData client = clientQueryService.GetClient(option.ClientId);

            DateTime fromDate = new DateTime(option.ReportFrom.Year, option.ReportFrom.Month, option.ReportFrom.Day, 0, 0, 0).ToUniversalTime();
            DateTime toDate = new DateTime(option.ReportTo.Year, option.ReportTo.Month, option.ReportTo.Day, 23, 59, 59).ToUniversalTime();
            SearchAppCommand command = new SearchAppCommand();
            command.ClientIds = new List<string> { option.ClientId };
            command.ReceivedDateFrom = fromDate;
            command.ReceivedDateTo = toDate;

            decimal total = 0m;
            List<ReportTypeData> reportTypes = (List<ReportTypeData>)clientQueryService.GetAllReportType();
            List<AppData> result = new List<AppData>();
            try
            {
                result = exploreAppQueryService.SearchApp(command);
                result = result.OrderBy(x => x.ReceivedDate).ToList();
                int index = 0;
                foreach (AppData app in result)
                {
                    ReportTypeData reportType = reportTypes.FirstOrDefault(x => x.ReportTypeId == app.ReportTypeId);
                    string appName = Utils.GetApplicantName(app, reportType);
                    decimal price = Utils.GetPrice(reportType, client);
                    string receivedLocalTime = app.ReceivedDate.HasValue ? app.ReceivedDate.Value.ToLocalTime().ToString("M/d/yy") : "";
                    total += price;
                    table.Rows.Add(string.Format("{0}.", index + 1), string.Format("{0}  ({1})",
                        appName, receivedLocalTime), "", price.ToString("$#,###,###,##0.00"));
                    index++;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

            bookmarkData.Add("ClientName", client.ClientName);
            bookmarkData.Add("ClientAddress", client.BillingAddress);
            bookmarkData.Add("ClientPhone", client.Phone);
            bookmarkData.Add("ClientFax", client.Fax);
            bookmarkData.Add("Date", "");
            bookmarkData.Add("Total", total.ToString("$#,###,###,##0.00"));
            bookmarkData.Add("BCIncRep", "");


            tableData.Add(1, table);

            return new DocumentReportData(bookmarkData, tableData);
        }

        public DocumentReportData GetMonthlyScreenerData(DocumentReportMonthlyScreenerOption option)
        {
            Dictionary<string, string> bookmarkData = new Dictionary<string, string>();
            Dictionary<int, DataTable> tableData = new Dictionary<int, DataTable>();

            var parameters = new DynamicParameters();
            List<int> lstAppsCompleted = new List<int>();
            List<int> lstFullAppsCompleted = new List<int>();
            List<string> fullApps = new List<string> { GlobalConstants.Residential, GlobalConstants.Employment, GlobalConstants.Commercial };
            int totalCompleted = 0;
            int totalFullAppsCompleted = 0;



            int numberOfDaysInMonth = DateTime.DaysInMonth(option.ReportDate.Year, option.ReportDate.Month);
            DateTime fullDateToUse = new DateTime(option.ReportDate.Year, option.ReportDate.Month, 1);
            int dayOfWeek = (int)fullDateToUse.DayOfWeek;
            DateTime curDate = DateTime.Now;
            int curYear = curDate.Year;
            int curMonth = curDate.Month;
            int curDay = curDate.Day;

            if (option.ReportDate.Year == curYear && option.ReportDate.Month == curMonth)
            {
                numberOfDaysInMonth = curDay;
            }

            DateTime fromDateLocal = new DateTime(option.ReportDate.Year, option.ReportDate.Month, 1, 0, 0, 0);
            DateTime toDateLocal = fromDateLocal.AddMonths(1);

            for (int i = 0; i < numberOfDaysInMonth; i++)
            {
                lstAppsCompleted.Add(0);
                lstFullAppsCompleted.Add(0);
            }

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findCompletedStatement = @"select datepart(day, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as day, " +
                        "count(*) as num from application a ";
                    string whereCompletedStatement = "where (a.completed_date between @completed_from and @completed_to) and a.screener_id = @screener_id ";
                    string fullAppStatement = " and a.report_type_id in (select r.report_type_id from report_type r where r.absolute_type_name in @full_apps) ";
                    string groupByCompletedStatement = " group by datepart(day, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) ";

                    parameters.Add("completed_from", fromDateLocal.ToUniversalTime());
                    parameters.Add("completed_to", toDateLocal.ToUniversalTime());
                    parameters.Add("full_apps", fullApps);
                    parameters.Add("screener_id", option.UserId);
                    parameters.Add("dest_tz", option.LocalTimeZone);

                    IEnumerable<dynamic>  result = cn.Query<dynamic>(findCompletedStatement + whereCompletedStatement + groupByCompletedStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            lstAppsCompleted[item.day - 1] = item.num;
                    }

                    result = cn.Query<dynamic>(findCompletedStatement + whereCompletedStatement + fullAppStatement + groupByCompletedStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            lstFullAppsCompleted[item.day - 1] = item.num;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

            DataTable table = new DataTable();
            table.Columns.Add("Fulls Compl.", typeof(string));
            table.Columns.Add("Total Compl.", typeof(string));
            int curCol = dayOfWeek + 1;
            int weekCompleted = 0;
            int weekFullAppsCompleted = 0;
            for (int i = 1; i <= numberOfDaysInMonth; i++)
            {

                totalCompleted += lstAppsCompleted[i - 1];
                totalFullAppsCompleted += lstFullAppsCompleted[i - 1];
                weekCompleted += lstAppsCompleted[i - 1];
                weekFullAppsCompleted += lstFullAppsCompleted[i - 1];
                if (curCol == 1)
                {
                    table.Rows.Add(weekFullAppsCompleted.ToString(),
                        weekCompleted.ToString());
                }
                else
                {
                    table.Rows.Add(lstFullAppsCompleted[i - 1].ToString(), 
                        lstAppsCompleted[i - 1].ToString());
                }
                curCol += 1;
                if (curCol > 7)
                {
                    curCol = 1;
                    weekCompleted = 0;
                    weekFullAppsCompleted = 0;
                }
            }

            tableData.Add(1, table);
            bookmarkData.Add("Username", option.UserName);
            bookmarkData.Add("Date", option.ReportDate.ToString("MM/yyyy"));
            bookmarkData.Add("TotalApps", totalCompleted.ToString());
            bookmarkData.Add("TotalFullApps", totalFullAppsCompleted.ToString());
            bookmarkData.Add("TotalOtherApps", (totalCompleted - totalFullAppsCompleted).ToString());

            return new DocumentReportData(bookmarkData, tableData);
        }

        public DocumentReportData GetApplicationVolumeData(DocumentReportApplicationVolumeOption option)
        {
            Dictionary<string, string> bookmarkData = new Dictionary<string, string>();
            Dictionary<int, DataTable> tableData = new Dictionary<int, DataTable>();

            var parameters = new DynamicParameters();
            List<int> lstAppsReceived = new List<int>();
            List<int> lstFullAppsReceived = new List<int>();
            List<int> lstAppsCompleted = new List<int>();
            List<int> lstFullAppsCompleted = new List<int>();
            List<string> fullApps = new List<string> { GlobalConstants.Residential, GlobalConstants.Employment, GlobalConstants.Commercial };
            int totalReceived = 0;
            int totalFullAppsReceived = 0;
            int totalCompleted = 0;
            int totalFullAppsCompleted = 0;

            int numberOfDaysInMonth = DateTime.DaysInMonth(option.ReportDate.Year, option.ReportDate.Month);
            DateTime fullDateToUse = new DateTime(option.ReportDate.Year, option.ReportDate.Month, 1);
            int dayOfWeek = (int)fullDateToUse.DayOfWeek;
            DateTime curDate = DateTime.Now;
            int curYear = curDate.Year;
            int curMonth = curDate.Month;
            int curDay = curDate.Day;

            if (option.ReportDate.Year == curYear && option.ReportDate.Month == curMonth)
            {
                numberOfDaysInMonth = curDay;
            }

            DateTime fromDateLocal = new DateTime(option.ReportDate.Year, option.ReportDate.Month, 1, 0, 0, 0);
            DateTime toDateLocal = fromDateLocal.AddMonths(1);

            for (int i = 0; i < numberOfDaysInMonth; i++)
            {
                lstAppsReceived.Add(0);
                lstFullAppsReceived.Add(0);
                lstAppsCompleted.Add(0);
                lstFullAppsCompleted.Add(0);
            }

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findReceivedStatement = @"select datepart(day, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as day, " +
                        "count(*) as num from application a ";
                    string findCompletedStatement = @"select datepart(day, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as day, " +
                        "count(*) as num from application a ";
                    string whereReceivedStatement = "where (a.received_date between @received_from and @received_to) ";
                    string whereCompletedStatement = "where (a.completed_date between @completed_from and @completed_to) ";
                    string fullAppStatement = " and a.report_type_id in (select r.report_type_id from report_type r where r.absolute_type_name in @full_apps) ";
                    string groupByReceivedStatement = " group by datepart(day, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) ";
                    string groupByCompletedStatement = " group by datepart(day, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) ";

                    parameters.Add("received_from", fromDateLocal.ToUniversalTime());
                    parameters.Add("received_to", toDateLocal.ToUniversalTime());
                    parameters.Add("completed_from", fromDateLocal.ToUniversalTime());
                    parameters.Add("completed_to", toDateLocal.ToUniversalTime());
                    parameters.Add("full_apps", fullApps);
                    parameters.Add("dest_tz", option.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findReceivedStatement + whereReceivedStatement + groupByReceivedStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            lstAppsReceived[item.day - 1] = item.num;
                    }

                    result = cn.Query<dynamic>(findReceivedStatement + whereReceivedStatement + fullAppStatement + groupByReceivedStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            lstFullAppsReceived[item.day - 1] = item.num;
                    }

                    result = cn.Query<dynamic>(findCompletedStatement + whereCompletedStatement + groupByCompletedStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            lstAppsCompleted[item.day - 1] = item.num;
                    }

                    result = cn.Query<dynamic>(findCompletedStatement + whereCompletedStatement + fullAppStatement + groupByCompletedStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            lstFullAppsCompleted[item.day - 1] = item.num;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

            DataTable table = new DataTable();
            table.Columns.Add("Rec'd", typeof(string));
            table.Columns.Add("Fulls Rec'd", typeof(string));
            table.Columns.Add("Compl.", typeof(string));
            table.Columns.Add("Fulls Compl.", typeof(string));
            int curCol = dayOfWeek + 1;
            int weekReceived = 0;
            int weekFullAppsReceived = 0;
            int weekCompleted = 0;
            int weekFullAppsCompleted = 0;
            for (int i = 1; i <= numberOfDaysInMonth; i++)
            {
                totalReceived += lstAppsReceived[i - 1];
                totalFullAppsReceived += lstFullAppsReceived[i - 1];
                totalCompleted += lstAppsCompleted[i - 1];
                totalFullAppsCompleted += lstFullAppsCompleted[i - 1];
                weekReceived += lstAppsReceived[i - 1];
                weekFullAppsReceived += lstFullAppsReceived[i - 1];
                weekCompleted += lstAppsCompleted[i - 1];
                weekFullAppsCompleted += lstFullAppsCompleted[i - 1];
                if (curCol == 1)
                {
                    table.Rows.Add(weekReceived.ToString(),
                        weekFullAppsReceived.ToString(),
                        weekCompleted.ToString(),
                        weekFullAppsCompleted.ToString());
                }
                else
                {
                    table.Rows.Add(lstAppsReceived[i - 1].ToString(),
                        lstFullAppsReceived[i - 1].ToString(),
                        lstAppsCompleted[i - 1].ToString(),
                        lstFullAppsCompleted[i - 1].ToString());
                }
                curCol += 1;
                if (curCol > 7)
                {
                    curCol = 1;
                    weekReceived = 0;
                    weekFullAppsReceived = 0;
                    weekCompleted = 0;
                    weekFullAppsCompleted = 0;
                }
            }

            tableData.Add(1, table);
            bookmarkData.Add("Date", option.ReportDate.ToString("MM/yyyy"));
            bookmarkData.Add("TotalRec", totalReceived.ToString());
            bookmarkData.Add("TotalFullRec", totalFullAppsReceived.ToString());
            bookmarkData.Add("TotalOtherRec", (totalReceived - totalFullAppsReceived).ToString());
            bookmarkData.Add("TotalCom", totalCompleted.ToString());
            bookmarkData.Add("TotalFullCom", totalFullAppsCompleted.ToString());
            bookmarkData.Add("TotalOtherCom", (totalCompleted - totalFullAppsCompleted).ToString());

            return new DocumentReportData(bookmarkData, tableData);
        }

        public DocumentReportData GetYearlyBusinessData(DocumentReportYearlyBusinessOption option)
        {
            int year = option.ReportYear;
            DateTime fromDateLocal = new DateTime(year, 1, 1, 0, 0, 0);
            DateTime toDateLocal = fromDateLocal.AddYears(1);

            var parameters = new DynamicParameters();
            List<string> fullApps = new List<string> { GlobalConstants.Residential, GlobalConstants.Employment, GlobalConstants.Commercial };
            Dictionary<string, string> bookmarkData = new Dictionary<string, string>();
            Dictionary<int, DataTable> tableData = new Dictionary<int, DataTable>();

            List<int> totalAppsReceived = new List<int>();
            List<int> totalFullAppsReceived = new List<int>();
            List<int> totalOtherAppsReceived = new List<int>();
            List<int> totalAppsCompleted = new List<int>();
            List<int> totalFullAppsCompleted = new List<int>();
            List<int> totalOtherAppsCompleted = new List<int>();
            List<decimal> totalBillingVolume = new List<decimal>();
            List<decimal> totalCreditEntered = new List<decimal>();
            for (int i = 0; i < 12; i++)
            {
                totalAppsReceived.Add(0);
                totalFullAppsReceived.Add(0);
                totalAppsCompleted.Add(0);
                totalFullAppsCompleted.Add(0);
                totalBillingVolume.Add(0m);
                totalCreditEntered.Add(0m);
            }

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findReceivedStatement = @"select datepart(month, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as month, " +
                        "count(*) as num from application a ";

                    string findCompletedStatement = @"select datepart(month, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as month, " +
                        "count(*) as num from application a ";

                    string whereReceivedStatement = "where (a.received_date between @received_from and @received_to) ";
                    string whereCompletedStatement = "where (a.completed_date between @completed_from and @completed_to) ";
                    string fullAppStatement = " and a.report_type_id in (select r.report_type_id from report_type r where r.absolute_type_name in @full_apps) ";
                    string groupByReceivedStatement = " group by datepart(month, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) ";
                    string groupByCompletedStatement = " group by datepart(month, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) ";

                    parameters.Add("received_from", fromDateLocal.ToUniversalTime());
                    parameters.Add("received_to", toDateLocal.ToUniversalTime());
                    parameters.Add("completed_from", fromDateLocal.ToUniversalTime());
                    parameters.Add("completed_to", toDateLocal.ToUniversalTime());
                    parameters.Add("full_apps", fullApps);
                    parameters.Add("dest_tz", option.LocalTimeZone);


                    IEnumerable<dynamic> result = cn.Query<dynamic>(findReceivedStatement + whereReceivedStatement + groupByReceivedStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            totalAppsReceived[item.month - 1] = item.num;
                    }


                    result = cn.Query<dynamic>(findReceivedStatement + whereReceivedStatement + fullAppStatement + groupByReceivedStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            totalFullAppsReceived[item.month - 1] = item.num;
                    }


                    result = cn.Query<dynamic>(findCompletedStatement + whereCompletedStatement + groupByCompletedStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            totalAppsCompleted[item.month - 1] = item.num;
                    }

                    result = cn.Query<dynamic>(findCompletedStatement + whereCompletedStatement + fullAppStatement + groupByCompletedStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            totalFullAppsCompleted[item.month - 1] = item.num;
                    }


                    string findStatement = @"select sum(i.amount) as volume, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month " +
                        "from invoice i where datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) = @year ";
                    string groupByStatement = "group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";
                    parameters.Add("invoice_date_from", fromDateLocal.ToUniversalTime());
                    parameters.Add("invoice_date_to", toDateLocal.ToUniversalTime());
                    parameters.Add("year", year);
                    result = cn.Query<dynamic>(findStatement + groupByStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            totalBillingVolume[item.month - 1] = item.volume;
                    }

                    findStatement = @"select sum(p.amount) as amount, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month " +
                        " from invoice i inner join payment p on i.invoice_id = p.invoice_id " +
                        "where datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) = @year ";
                    groupByStatement = "group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";
                    result = cn.Query<dynamic>(findStatement + groupByStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                            totalCreditEntered[item.month - 1] = item.amount;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

            DateTime curDate = DateTime.Now;
            int curYear = curDate.Year;
            int maxMonth;
            if (option.ReportYear == curYear)
            {
                maxMonth = curDate.Month;
            }
            else
            {
                maxMonth = 12;
            }

            DataTable table = new DataTable();
            table.Columns.Add("Total Apps Received", typeof(string));
            table.Columns.Add("Total Full Apps Received", typeof(string));
            table.Columns.Add("Total Other Apps Received", typeof(string));
            table.Columns.Add("Total Apps Completed", typeof(string));
            table.Columns.Add("Total Full Apps Completed", typeof(string));
            table.Columns.Add("Total Other Apps Completed", typeof(string));
            table.Columns.Add("Total Billing Volume", typeof(string));
            table.Columns.Add("Total Credits Entered", typeof(string));
            for (int i = 0; i < maxMonth; i++)
            {
                table.Rows.Add(totalAppsReceived[i], totalFullAppsReceived[i], totalAppsReceived[i] - totalFullAppsReceived[i],
                    totalAppsCompleted[i], totalFullAppsCompleted[i], totalAppsCompleted[i] - totalFullAppsCompleted[i],
                    totalBillingVolume[i].ToString("$#,###,###,##0.00"), totalCreditEntered[i].ToString("$#,###,###,##0.00"));
            }

            tableData.Add(1, table);

            bookmarkData.Add("Year", option.ReportYear.ToString());
            bookmarkData.Add("CreatedDate", DateTime.Now.ToString("MM/dd/yyyy"));

            return new DocumentReportData(bookmarkData, tableData);
        }
    }
}
