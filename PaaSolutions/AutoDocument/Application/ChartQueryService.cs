using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoDocument.Application.Data;
using Common.Infrastructure.Query;
using Dapper;
using System.Data;
using Common.Application.Helper;
using Invoice.Domain.Model;
using System.Globalization;
using Common.Application;
using System.Data.SqlClient;
using Invoice.Application.Helper;

namespace AutoDocument.Application
{
    public class ChartQueryService : QueryService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region PieChart
        public PieChartData GetPieChartFromCommon(ChartFilterData chartFilterData)
        {
            PieChartData pieChartData = new PieChartData();
            if (chartFilterData.ChartSubType == ChartSubTypeCommon.PercentageAppsReceivedByType.Value)
            {
                return GetAppslicationsReceivedByType(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == ChartSubTypeCommon.PercentageAppsCompletedByUsers.Value)
            {
                return GetAppslicationsCompletedByUsers(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == ChartSubTypeCommon.PercentageAppsCompletedByTurnaround.Value)
            {
                return GetAppslicationsCompletedByTurnaround(chartFilterData);
            }

            return pieChartData;
        }

        public PieChartData GetPieChartFromApplications(ChartFilterData chartFilterData)
        {
            PieChartData pieChartData = new PieChartData();
            if (chartFilterData.ChartSubType == PieChartSubTypeApplications.AppsReceivedByType.Value)
            {
                return GetAppslicationsReceivedByType(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeApplications.AppsCompletedByUsers.Value)
            {
                return GetAppslicationsCompletedByUsers(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeApplications.AppsCompletedByTurnaround.Value)
            {
                return GetAppslicationsCompletedByTurnaround(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeApplications.AppsReceivedByHour.Value)
            {
                return GetApplicationsReceivedByHour(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeApplications.AppsCompletedByHour.Value)
            {
                return GetApplicationsCompletedByHour(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeApplications.AppsReceivedByMonth.Value)
            {
                return GetApplicationsReceivedByMonth(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeApplications.AppsCompletedByRecommendation.Value)
            {
                return GetApplicationsCompletedByRecommendation(chartFilterData);
            }
            return pieChartData;
        }

        public PieChartData GetPieChartFromInvoices(ChartFilterData chartFilterData)
        {
            PieChartData pieChartData = new PieChartData();
            if (chartFilterData.ChartSubType == PieChartSubTypeInvoices.PastDueBalancesByClient.Value)
            {
                return GetPastDueBalancesByClient(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeInvoices.PastDueBalancesByMonth.Value)
            {
                return GetPastDueBalancesByMonth(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeInvoices.ReceiveableBalances.Value)
            {
                return GetReceiveableBalances(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeInvoices.InvoiceCreditByMonth.Value)
            {
                return GetInvoiceCreditByMonth(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeInvoices.InvoiceVolumnByMonth.Value)
            {
                return GetInvoiceVolumeByMonth(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == PieChartSubTypeInvoices.InvoicePaymentHistory.Value)
            {
                return GetInvoicePaymentHistory(chartFilterData);
            }
            return pieChartData;
        }

        // done
        private PieChartData GetAppslicationsCompletedByUsers(ChartFilterData chartFilterData)
        {
            try
            {
                List<string> xValues = new List<string>();
                List<int> yValues = new List<int>();
                var parameters = new DynamicParameters();
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select a.screener_name, count(*) as num from application a inner join dbo.[user] u on " +
                        "a.screener_id = u.user_id " +
                        "where (a.completed_date between @completed_from and @completed_to)";

                    if (chartFilterData.IsFullAppOnly)
                    {
                        findStatement = @"select a.screener_name, count(*) as num from application a inner join dbo.[user] u on " +
                            "a.screener_id = u.user_id inner join report_type r on a.report_type_id = r.report_type_id " +
                            "where (a.completed_date between @completed_from and @completed_to) " +
                            "and r.type_name in ('Comm', 'Cosigner', 'Emp1', 'Res1', 'Res2', 'Res3', 'Res4', 'Roommate', 'ZFreebieEmp', 'ZFreebieRes1') ";
                    }

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by screener_name ";

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);
                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                        {
                            xValues.Add(item.screener_name);
                            yValues.Add(item.num ?? 0);
                        }
                    }
                }
                string title = string.Format("{0}  {1} - {2}", "Applications Completed by Users",
                    chartFilterData.DateFrom.ToLocalTime().ToString("MM/dd/yy"),
                    chartFilterData.DateTo.ToLocalTime().ToString("MM/dd/yy"));
                PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                return pieChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetAppslicationsCompletedByTurnaround(ChartFilterData chartFilterData)
        {
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Applications Completed by Turnaround Time",
                    chartFilterData.DateFrom.ToLocalTime().ToString("MM/dd/yy"),
                    chartFilterData.DateTo.ToLocalTime().ToString("MM/dd/yy"));
            List<string> xValues = new List<string>();
            List<int> yValues = new List<int>();
            Dictionary<string, int> turnaroundValues = new Dictionary<string, int>();
            turnaroundValues.Add("Same Day", 0);
            turnaroundValues.Add("Next Day", 0);
            turnaroundValues.Add("2 Days", 0);
            turnaroundValues.Add("3 Days", 0);
            turnaroundValues.Add("4 Days", 0);
            turnaroundValues.Add("5+ Days", 0);

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select a.received_date, a.completed_date from application a " +
                        "where (a.completed_date between @completed_from and @completed_to) ";

                    if (chartFilterData.IsFullAppOnly)
                    {
                        findStatement = @"select a.received_date, a.completed_date from application a " +
                            "inner join report_type r on a.report_type_id = r.report_type_id " +
                            "where (a.completed_date between @completed_from and @completed_to) " +
                            "and r.type_name in ('Comm', 'Cosigner', 'Emp1', 'Res1', 'Res2', 'Res3', 'Res4', 'Roommate', 'ZFreebieEmp', 'ZFreebieRes1') ";
                    }

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        DateTime start = ((DateTime)(item.received_date)).ToLocalTime();
                        DateTime stop = ((DateTime)(item.completed_date)).ToLocalTime();
                        int businessDaysDiff = DateTimeHelper.GetBusinessDaysDifference(start, stop);
                        if (businessDaysDiff == 0)
                        {
                            turnaroundValues["Same Day"] += 1;
                        }
                        else if (businessDaysDiff == 1)
                        {
                            turnaroundValues["Next Day"] += 1;
                        }
                        else if (businessDaysDiff == 2)
                        {
                            turnaroundValues["2 Days"] += 1;
                        }
                        else if (businessDaysDiff == 3)
                        {
                            turnaroundValues["3 Days"] += 1;
                        }
                        else if (businessDaysDiff == 4)
                        {
                            turnaroundValues["4 Days"] += 1;
                        }
                        else
                        {
                            turnaroundValues["5+ Days"] += 1;
                        }
                    }

                    foreach (var item in turnaroundValues)
                    {
                        xValues.Add(item.Key);
                        yValues.Add(item.Value);
                    }
                    PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                    return pieChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetAppslicationsReceivedByType(ChartFilterData chartFilterData)
        {
            try
            {
                List<string> xValues = new List<string>();
                List<int> yValues = new List<int>();
                var parameters = new DynamicParameters();
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select rp.absolute_type_name, count(*) as num from application a inner join report_type rp " +
                        "on a.report_type_id = rp.report_type_id " +
                        "where (a.received_date between @received_from and @received_to) ";

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by rp.absolute_type_name ";

                    parameters.Add("received_from", chartFilterData.DateFrom);
                    parameters.Add("received_to", chartFilterData.DateTo);
                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                        {
                            xValues.Add(item.absolute_type_name);
                            yValues.Add(item.num ?? 0);
                        }
                    }
                }
                string title = string.Format("{0}  {1} - {2}", "Applications Received by Type",
                    chartFilterData.DateFrom.ToLocalTime().ToString("MM/dd/yy"),
                    chartFilterData.DateTo.ToLocalTime().ToString("MM/dd/yy"));

                PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                return pieChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetApplicationsReceivedByHour(ChartFilterData chartFilterData)
        {
            DateTime start = chartFilterData.DateFrom.ToLocalTime();
            DateTime stop = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("Application Received by Hour  {0} - {1}", start.Date.ToString("MM/dd/yy"), stop.Date.ToString("MM/dd/yy"));
            List<string> xValues = new List<string>() { "Before 8",
                "8:00 AM", "9:00 AM", "10:00 AM", "11:00 AM", "12:00 AM",
                "1:00 PM", "2:00 PM", "3:00 PM", "4:00 PM", "5:00 PM", "After 6"
            };
            List<int> yValues = new List<int>() {
                0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0 };

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select a.received_date from application a " +
                        "where (a.received_date between @received_from and @received_to) ";

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    parameters.Add("received_from", chartFilterData.DateFrom);
                    parameters.Add("received_to", chartFilterData.DateTo);

                    IEnumerable<DateTime> result = cn.Query<DateTime>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        DateTime receivedLocal = item.ToLocalTime();
                        int hourInDay = receivedLocal.Hour;
                        if (hourInDay < 8)
                        {
                            yValues[0] += 1;
                        }
                        else if (hourInDay >= 8 && hourInDay <= 17)
                        {
                            yValues[hourInDay - 8 + 1] += 1;
                        }
                        else
                        {
                            yValues[11] += 1;
                        }
                    }

                    PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                    return pieChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetApplicationsCompletedByHour(ChartFilterData chartFilterData)
        {
            string title = string.Format("{0}  {1} - {2}", "Applications Completed by Hour",
                    chartFilterData.DateFrom.ToLocalTime().ToString("MM/dd/yy"),
                    chartFilterData.DateTo.ToLocalTime().ToString("MM/dd/yy"));
            var parameters = new DynamicParameters();
            List<string> xValues = new List<string>() { "Before 8",
                "8:00 AM", "9:00 AM", "10:00 AM", "11:00 AM", "12:00 AM",
                "1:00 PM", "2:00 PM", "3:00 PM", "4:00 PM", "5:00 PM", "After 6"
            };
            List<int> yValues = new List<int>() {
                0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0 };

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select a.completed_date from application a " +
                        "where (a.completed_date between @completed_from and @completed_to) ";

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);

                    IEnumerable<DateTime> result = cn.Query<DateTime>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        DateTime completedLocal = item.ToLocalTime();
                        int hourInDay = completedLocal.Hour;
                        if (hourInDay < 8)
                        {
                            yValues[0] += 1;
                        }
                        else if (hourInDay >= 8 && hourInDay <= 17)
                        {
                            yValues[hourInDay - 8 + 1] += 1;
                        }
                        else
                        {
                            yValues[11] += 1;
                        }
                    }

                    PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                    return pieChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetApplicationsReceivedByMonth(ChartFilterData chartFilterData)
        {
            try
            {
                List<string> xValues = new List<string>();
                List<int> yValues = new List<int>();
                var parameters = new DynamicParameters();

                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(month, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as month, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as year, " +
                        "count(*) as num from application a " +
                        "where (a.received_date between @received_from and @received_to) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(month, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) ";

                    parameters.Add("received_from", chartFilterData.DateFrom);
                    parameters.Add("received_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);
                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
                    DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        xValues.Add(key);
                        int num = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {
                                num = num + (item.num != null ? item.num : 0);
                            }
                        }
                        yValues.Add(num);
                    }
                }
                string title = string.Format("{0}  {1} - {2}", "Applications Received by Month",
                    chartFilterData.DateFrom.ToLocalTime().ToString("MM/dd/yy"),
                    chartFilterData.DateTo.ToLocalTime().ToString("MM/dd/yy"));
                PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                return pieChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetApplicationsCompletedByRecommendation(ChartFilterData chartFilterData)
        {
            try
            {
                string approval = "%<QualifiedRoommate>False</QualifiedRoommate><Cosigner>False</Cosigner><FirstAndSecurity>False</FirstAndSecurity><AbsPosNO>False</AbsPosNO>%";
                string firstAndSecurity = "%<Cosigner>False</Cosigner><FirstAndSecurity>True</FirstAndSecurity><AbsPosNO>False</AbsPosNO>%";
                string cosigner = "%<Cosigner>True</Cosigner><FirstAndSecurity>False</FirstAndSecurity><AbsPosNO>False</AbsPosNO>%";
                string qualifiedRoomate = "%<QualifiedRoommate>True</QualifiedRoommate><Cosigner>False</Cosigner><FirstAndSecurity>False</FirstAndSecurity><AbsPosNO>False</AbsPosNO>%";
                string denial = "%<Cosigner>False</Cosigner><FirstAndSecurity>False</FirstAndSecurity><AbsPosNO>True</AbsPosNO>%";

                Dictionary<string, string> searchRecommendation = new Dictionary<string, string>();
                searchRecommendation.Add("Approval", approval);
                searchRecommendation.Add("First & Security", firstAndSecurity);
                searchRecommendation.Add("Cosigner", cosigner);
                searchRecommendation.Add("Qualified Roomate", qualifiedRoomate);
                searchRecommendation.Add("Denial", denial);
                List<int> yValues = new List<int>();
                List<string> xValues = new List<string>();
                var parameters = new DynamicParameters();

                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select count(*) from application a " +
                        "where (a.completed_date between @completed_from and @completed_to) " +
                        "and recommendation like @recommendation ";

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);

                    foreach (var item in searchRecommendation)
                    {
                        parameters.Add("recommendation", item.Value);
                        int value = cn.Query<int>(findStatement, parameters).Single();
                        xValues.Add(item.Key);
                        yValues.Add(value);
                    }
                }
                string title = string.Format("{0}  {1} - {2}", "Application Completed by Recommendation",
                    chartFilterData.DateFrom.ToLocalTime().ToString("MM/dd/yy"),
                    chartFilterData.DateTo.ToLocalTime().ToString("MM/dd/yy"));
                PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                return pieChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetPastDueBalancesByClient(ChartFilterData chartFilterData)
        {

            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Past Due Balance by Client", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> xValues = new List<string>();
            List<int> yValues = new List<int>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = "";
                    if (chartFilterData.IsAllClients)
                    {
                        findStatement = @"select sum(i.balance) as balance, i.client_name as client_name " +
                            " from invoice i  " +
                            "where (i.invoice_date between @invoice_date_from and @invoice_date_to " +
                            "and status=@status) group by i.client_name ";
                    }
                    else
                    {
                        findStatement = @"select sum(i.balance) as balance, i.client_name as client_name " +
                            " from invoice i  " +
                            "where (i.invoice_date between @invoice_date_from and @invoice_date_to " +
                            "and status=@status) and i.client_name in (select c.client_name from client c where c.client_id in @client_list) " +
                            "group by i.client_name ";

                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }


                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("status", Status.PAST_DUE.Value);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                        {
                            string xValue = string.Format("{0}", item.client_name);
                            int yValue = (int)item.balance;
                            xValues.Add(xValue);
                            yValues.Add(yValue);
                        }
                    }

                    PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                    return pieChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetPastDueBalancesByMonth(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Past Due Balances by Month", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> xValues = new List<string>();
            List<int> yValues = new List<int>();


            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select sum(i.balance) as balance, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i " +
                        "where i.invoice_date between @invoice_date_from and @invoice_date_to and status=@status ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += "group by datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("status", Status.PAST_DUE.Value);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        xValues.Add(key);
                        decimal balance = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {
                                balance = balance + (item.balance != null ? item.balance : 0);
                            }
                        }
                        yValues.Add((int)balance);
                    }
                }
                PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                return pieChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetReceiveableBalances(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Receiveable Balances", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> xValues = new List<string>();
            List<int> yValues = new List<int>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select sum(i.balance) as balance, status from invoice i " +
                        "where i.invoice_date between @invoice_date_from and @invoice_date_to " +
                        "and status in @status_list ";

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += "group by status ";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    List<int> statusList = new List<int>() { Status.UNPAID.Value, Status.PAST_DUE.Value };
                    parameters.Add("status_list", statusList);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                        {
                            Status status = Status.CreateInstance(item.status);
                            xValues.Add(status.DisplayName);
                            yValues.Add((int)item.balance);
                        }
                    }

                    PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                    return pieChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetInvoiceCreditByMonth(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Invoice Credit by Month", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> xValues = new List<string>();
            List<int> yValues = new List<int>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select sum(p.amount) as amount, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i " +
                        " inner join payment p on i.invoice_id = p.invoice_id " +
                        " where i.invoice_date between @invoice_date_from and @invoice_date_to ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += " group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        xValues.Add(key);
                        decimal amount = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {
                                amount = amount + (item.amount != null ? item.amount : 0);
                            }
                        }
                        yValues.Add((int)amount);
                    }

                    PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                    return pieChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetInvoiceVolumeByMonth(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Invoice Volume by Month", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> xValues = new List<string>();
            List<int> yValues = new List<int>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select sum(ii.unit_price) as volume, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i inner join invoice_item ii on i.invoice_id = ii.invoice_id " +
                        "where i.invoice_date between @invoice_date_from and @invoice_date_to ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += " group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime))," +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        xValues.Add(key);
                        decimal volume = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {
                                volume = volume + (item.volume != null ? item.volume : 0);
                            }
                        }
                        yValues.Add((int)volume);
                    }

                    PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                    return pieChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private PieChartData GetInvoicePaymentHistory(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Invoice Payment History", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> xValues = new List<string>() { 
                "Early", "On Time", "1 Mo. Late", "2 Mo. Late", "3 Mo. Late", "4+ Mo. Late"
            };
            List<int> yValues = new List<int>();
            int numEarly = 0;
            int numOnTime = 0;
            int num1MonthLate = 0;
            int num2MonthLate = 0;
            int num3MonthLate = 0;
            int num4OrMoreMonthLate = 0;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select i1.invoice_id, i2.last_payment_date, i1.balance, i1.invoice_date, status from invoice i1 inner join " +
                        "(select max(date) as last_payment_date, invoice_id from dbo.payment group by invoice_id) i2 " +
                        "on i1.invoice_id = i2.invoice_id " +
                        "where i1.invoice_date between @invoice_date_from and @invoice_date_to and i1.status in @status_list ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i1.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);

                    List<int> statusList = new List<int>() { Status.OVER_PAY.Value, Status.PD_LATE.Value, Status.PAID.Value };
                    parameters.Add("status_list", statusList);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    foreach (var item in result)
                    {
                        if (item.last_payment_date == null || item.balance > 0)
                        {
                            numOnTime++;
                        }
                        else
                        {
                            DateTime lastPaymentDate = ((DateTime)(item.last_payment_date)).ToLocalTime();
                            DateTime dueDate = InvoiceCalculationHelper.GetDueDate(((DateTime)item.invoice_date).ToLocalTime());
                            double dateDiff = (lastPaymentDate - dueDate).TotalDays;
                            if (dateDiff < -10)
                            {
                                numEarly++;
                            }
                            else if (dateDiff < 1)
                            {
                                numOnTime++;
                            }
                            else
                            {
                                DateTime lastPyamentToDiff = lastPaymentDate.AddDays(1 - dueDate.Day);
                                DateTime dueDateToDiff = dueDate.AddDays(1 - dueDate.Day);
                                int monthDiff = (lastPyamentToDiff.Year - dueDateToDiff.Year) * 12 + (lastPyamentToDiff.Month - dueDateToDiff.Month) + 1;

                                if (monthDiff <= 1)
                                {
                                    num1MonthLate++;
                                }
                                else if (monthDiff == 2)
                                {
                                    num2MonthLate++;
                                }
                                else if (monthDiff == 3)
                                {
                                    num3MonthLate++;
                                }
                                else
                                {
                                    num4OrMoreMonthLate++;
                                }
                            }
                        }
                    }

                    yValues.Add(numEarly);
                    yValues.Add(numOnTime);
                    yValues.Add(num1MonthLate);
                    yValues.Add(num2MonthLate);
                    yValues.Add(num3MonthLate);
                    yValues.Add(num4OrMoreMonthLate);

                    PieChartData pieChartData = new PieChartData(title, xValues, yValues);
                    return pieChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        #endregion;

        #region BarChart
        public BarChartData GetBarChartFromApplications(ChartFilterData chartFilterData)
        {
            BarChartData barChartData = new BarChartData();
            if (chartFilterData.ChartSubType == BarChartSubTypeApplications.AppsReceivedByWeek.Value)
            {
                return GetApplicationsReceivedByWeeks(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeApplications.AppReceivedWeeklyByType.Value)
            {
                return GetApplicationsReceivedWeeklyByType(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeApplications.AppsCompletedByUsers.Value)
            {
                return GetApplicationsCompletedByUsers(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeApplications.AppsCompletedByTurnaround.Value)
            {
                return GetApplicationsCompletedByTurnaround(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeApplications.AppsCompletedByHour.Value)
            {
                return GetApplicationsCompletedByHourBarChart(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeApplications.AppsReceivedByClient.Value)
            {
                return GetApplicationsReceivedByClient(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeApplications.AppsReceivedByMonth.Value)
            {
                return GetApplicationsReceivedByMonthBarChart(chartFilterData);
            }
            return barChartData;
        }

        public BarChartData GetBarChartFromInvoices(ChartFilterData chartFilterData)
        {
            BarChartData barChartData = new BarChartData();
            if (chartFilterData.ChartSubType == BarChartSubTypeInvoices.InvoicePastDuesByMonth.Value)
            {
                return GetInvoicePastDuesByMonth(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeInvoices.ReceiveableBalanceByStatus.Value)
            {
                return GetReceiveableBalanceByStatus(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeInvoices.InvoiceVolumeByMonth.Value)
            {
                return GetInvoiceVolumeByMonthBarChart(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeInvoices.AmountCreditsByMonth.Value)
            {
                return GetAmountCreditsByMonth(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeInvoices.InvoiceCountAndItemAverageByMonth.Value)
            {
                return GetInvoiceCountAndItemAverageByMonth(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == BarChartSubTypeInvoices.PaymentHistorybyClient.Value)
            {
                return GetPaymentHistorybyClient(chartFilterData);
            }
            return barChartData;
        }

        // done
        private BarChartData GetApplicationsReceivedByWeeks(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Applications Received by Weeks", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));
            List<string> labels = new List<string>();
            List<string> series = new List<string>() { "Applications Received" };
            List<int> yValues = new List<int>();
            List<List<int>> seriesYValues = new List<List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(week, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as week," +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as year, " +
                        "count(*) as num from application a " +
                        "where (a.received_date between @received_from and @received_to) ";

                    var parameters = new DynamicParameters();

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(week, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime))";

                    string datepartStatement = @"select datepart(year, @input_date) as year, datepart(month, @input_date) as month, datepart(week, @input_date) as week, datepart(day, @input_date) as day ";

                    parameters.Add("received_from", chartFilterData.DateFrom);
                    parameters.Add("received_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);



                    for (DateTime startOfWeek = DateTimeHelper.StartOfWeek(localStart, DayOfWeek.Sunday); startOfWeek < localEnd; startOfWeek = startOfWeek.AddDays(7))
                    {
                        DateTime endOfWeek = startOfWeek.AddDays(7).AddMinutes(-5).Date;
                        dynamic datepart = cn.Query<dynamic>(datepartStatement, new { input_date = endOfWeek }).FirstOrDefault();
                        int currentWeek = datepart.week;
                        int currentYear = datepart.year;
                        string key = string.Format("{0}-{1}", startOfWeek.ToString("MM/dd/yy"), endOfWeek.ToString("MM/dd/yy"));
                        labels.Add(key);
                        int num = 0;

                        foreach (var item in result)
                        {
                            int week = item.week;
                            int year = item.year;

                            if (currentWeek == week && currentYear == year)
                            {
                                num = num + (item.num != null ? item.num : 0);
                            }
                        }
                        yValues.Add(num);
                    }
                    seriesYValues.Add(yValues);
                }
                BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                return barChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        // done
        private BarChartData GetApplicationsReceivedWeeklyByType(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Applications Received Weekly by Type", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));

            List<string> labels = new List<string>();
            List<string> series = new List<string>() { "Residential", "Employment", "Commercial", "Credit/Crimminal", "Other" };
            List<List<int>> seriesYValues = new List<List<int>>();
            List<int> yValuesResidential = new List<int>();
            List<int> yValuesEmployment = new List<int>();
            List<int> yValuesCommercial = new List<int>();
            List<int> yValuesCreditCrimminal = new List<int>();
            List<int> yValuesOther = new List<int>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select rp.absolute_type_name, datepart(week, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as week," +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as year, " +
                        "count(*) as num from application a inner join report_type rp on a.report_type_id = rp.report_type_id " +
                        "where (a.received_date between @received_from and @received_to) ";

                    string datepartStatement = @"select datepart(year, @input_date) as year, datepart(month, @input_date) as month, datepart(week, @input_date) as week, datepart(day, @input_date) as day ";

                    var parameters = new DynamicParameters();

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(week, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)), rp.absolute_type_name";

                    parameters.Add("received_from", chartFilterData.DateFrom);
                    parameters.Add("received_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfWeek = DateTimeHelper.StartOfWeek(localStart, DayOfWeek.Sunday); startOfWeek < localEnd; startOfWeek = startOfWeek.AddDays(7))
                    {
                        DateTime endOfWeek = startOfWeek.AddDays(7).AddMinutes(-5).Date;

                        dynamic datepart = cn.Query<dynamic>(datepartStatement, new { input_date = endOfWeek }).FirstOrDefault();
                        int currentWeek = datepart.week;
                        int currentYear = datepart.year;
                        string key = string.Format("{0}-{1}", startOfWeek.ToString("MM/dd/yy"), endOfWeek.ToString("MM/dd/yy"));
                        labels.Add(key);
                        int numResidential = 0;
                        int numEmployment = 0;
                        int numCommercial = 0;
                        int numCreditCriminal = 0;
                        int numOther = 0;

                        foreach (var item in result)
                        {
                            int week = item.week;
                            int year = item.year;

                            if (currentWeek == week && currentYear == year)
                            {
                                if (item.absolute_type_name == GlobalConstants.Residential)
                                {
                                    numResidential = numResidential + (item.num != null ? item.num : 0);
                                }
                                else if (item.absolute_type_name == GlobalConstants.Employment)
                                {
                                    numEmployment = numEmployment + (item.num != null ? item.num : 0);
                                }
                                else if (item.absolute_type_name == GlobalConstants.Commercial)
                                {
                                    numCommercial = numCommercial + (item.num != null ? item.num : 0);
                                }
                                else if (item.absolute_type_name == GlobalConstants.CreditCrimminal)
                                {
                                    numCreditCriminal = numCreditCriminal + (item.num != null ? item.num : 0);
                                }
                                else
                                {
                                    numOther = numOther + (item.num != null ? item.num : 0);
                                }
                            }
                        }
                        yValuesResidential.Add(numResidential);
                        yValuesEmployment.Add(numEmployment);
                        yValuesCommercial.Add(numCommercial);
                        yValuesCreditCrimminal.Add(numCreditCriminal);
                        yValuesOther.Add(numOther);
                    }

                    seriesYValues.Add(yValuesResidential);
                    seriesYValues.Add(yValuesEmployment);
                    seriesYValues.Add(yValuesCommercial);
                    seriesYValues.Add(yValuesCreditCrimminal);
                    seriesYValues.Add(yValuesOther);
                }
                BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                return barChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        // done
        private BarChartData GetApplicationsCompletedByUsers(ChartFilterData chartFilterData)
        {
            try
            {
                DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
                DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

                string title = string.Format("{0}  {1} - {2}", "Applications Completed by Users", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));

                List<string> labels = new List<string>();
                List<string> series = new List<string>() { "Applications Completed" };
                List<List<int>> seriesYValues = new List<List<int>>();
                List<int> yValues = new List<int>();
                var parameters = new DynamicParameters();
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select a.screener_name, count(*) as num from application a inner join dbo.[user] u on " +
                        "a.screener_id = u.user_id " +
                        "where (a.completed_date between @completed_from and @completed_to) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by screener_name ";

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);
                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                        {
                            labels.Add(item.screener_name);
                            yValues.Add(item.num ?? 0);
                        }
                    }
                }
                seriesYValues.Add(yValues);
                BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                return barChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private BarChartData GetApplicationsCompletedByTurnaround(ChartFilterData chartFilterData)
        {
            var parameters = new DynamicParameters();

            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Applications Completed by Turnaround", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));
            List<string> xValues = new List<string>();
            List<int> yValues = new List<int>();
            List<string> series = new List<string>() { "Applications Completed" };
            List<string> labels = new List<string>();
            List<List<int>> seriesYValues = new List<List<int>>();
            Dictionary<string, int> turnaroundValues = new Dictionary<string, int>();
            turnaroundValues.Add("Same Day", 0);
            turnaroundValues.Add("Next Day", 0);
            turnaroundValues.Add("2 Days", 0);
            turnaroundValues.Add("3 Days", 0);
            turnaroundValues.Add("4 Days", 0);
            turnaroundValues.Add("5+ Days", 0);

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select a.received_date, a.completed_date from application a " +
                        "where (a.completed_date between @completed_from and @completed_to) ";

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        DateTime start = ((DateTime)(item.received_date)).ToLocalTime();
                        DateTime stop = ((DateTime)(item.completed_date)).ToLocalTime();
                        int businessDaysDiff = DateTimeHelper.GetBusinessDaysDifference(start, stop);
                        if (businessDaysDiff == 0)
                        {
                            turnaroundValues["Same Day"] += 1;
                        }
                        else if (businessDaysDiff == 1)
                        {
                            turnaroundValues["Next Day"] += 1;
                        }
                        else if (businessDaysDiff == 2)
                        {
                            turnaroundValues["2 Days"] += 1;
                        }
                        else if (businessDaysDiff == 3)
                        {
                            turnaroundValues["3 Days"] += 1;
                        }
                        else if (businessDaysDiff == 4)
                        {
                            turnaroundValues["4 Days"] += 1;
                        }
                        else
                        {
                            turnaroundValues["5+ Days"] += 1;
                        }
                    }

                    foreach (var item in turnaroundValues)
                    {
                        labels.Add(item.Key);
                        yValues.Add(item.Value);
                    }
                    seriesYValues.Add(yValues);
                    BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                    return barChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private BarChartData GetApplicationsCompletedByHourBarChart(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Applications Completed by Hour", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));

            var parameters = new DynamicParameters();
            List<string> series = new List<string>() { "Applications Completed" };
            List<string> labels = new List<string>() { "Before 8",
                "8:00 AM", "9:00 AM", "10:00 AM", "11:00 AM", "12:00 AM",
                "1:00 PM", "2:00 PM", "3:00 PM", "4:00 PM", "5:00 PM", "After 6"
            };
            List<int> yValues = new List<int>() {
                0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0 };
            List<List<int>> seriesYValues = new List<List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(hour, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as hour," +
                        "count(*) as num from application a " +
                        "where (a.completed_date between @completedd_from and @completed_to) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(hour, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) ";

                    parameters.Add("completedd_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        int hour = item.hour;
                        if (hour < 8)
                        {
                            yValues[0] += 1;

                        }
                        if (hour >= 8 && hour <= 17)
                        {
                            yValues[hour - 8 + 1] += item.num;
                        }
                        else
                        {
                            yValues[11] += item.num;
                        }
                    }

                    for (int i = yValues.Count - 1; i >= 0; i--)
                    {
                        if (yValues[i] == 0)
                        {
                            labels.RemoveAt(i);
                            yValues.Remove(i);
                        }
                    }

                    seriesYValues.Add(yValues);
                    BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                    return barChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private BarChartData GetApplicationsReceivedByClient(ChartFilterData chartFilterData)
        {
            try
            {
                DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
                DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

                string title = string.Format("{0}  {1} - {2}", "Applications Received by Client", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));

                List<string> labels = new List<string>();
                List<int> yValues = new List<int>();
                var parameters = new DynamicParameters();
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select c.client_name , count(*) as num from application a inner join client c " +
                        "on a.client_id = c.client_id " +
                        "where (a.received_date between @received_from and @received_to) ";

                    if (chartFilterData.IsAllClients)
                    {
                        throw new ArgumentException("You cannot select \"All Client\" with this chart type.\n" +
                            "Creating a chart with this request will result in a chart that takes very long to display and is also too small to be legible.");
                    }

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by c.client_name ";

                    parameters.Add("received_from", chartFilterData.DateFrom);
                    parameters.Add("received_to", chartFilterData.DateTo);
                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                        {
                            labels.Add(item.client_name);
                            yValues.Add(item.num ?? 0);
                        }
                    }
                }
                List<string> series = new List<string>() { "Applications Received" };
                List<List<int>> seriesYValues = new List<List<int>>();
                seriesYValues.Add(yValues);
                BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                return barChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private BarChartData GetApplicationsReceivedByMonthBarChart(ChartFilterData chartFilterData)
        {
            try
            {
                DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
                DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

                string title = string.Format("{0}  {1} - {2}", "Applications Received by Month", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));

                List<string> series = new List<string>() { "Applicationss Received" };
                List<List<int>> seriesYValues = new List<List<int>>();
                var parameters = new DynamicParameters();
                List<string> labels = new List<string>() { 
                    "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                    "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
                List<int> yValues = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(month, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as month, " +
                        "count(*) as num from application a " +
                        "where (a.received_date between @received_from and @received_to) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by  datepart(month, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime))";

                    parameters.Add("received_from", chartFilterData.DateFrom);
                    parameters.Add("received_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);
                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    foreach (var item in result)
                    {
                        int month = item.month;
                        yValues[month - 1] += item.num;
                    }
                }

                seriesYValues.Add(yValues);
                BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                return barChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private BarChartData GetInvoicePastDuesByMonth(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Invoice Past Dues by Month", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> labels = new List<string>();
            List<string> series = new List<string>() { "Invoice Past Dues By Month" };
            List<int> yValues = new List<int>();
            List<List<int>> seriesYValues = new List<List<int>>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select sum(i.balance) as balance, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i " +
                        "where (i.invoice_date between @invoice_date_from and @invoice_date_to " +
                        "and status=@status) ";

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += "group by datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("status", Status.PAST_DUE.Value);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);


                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        labels.Add(key);
                        decimal balance = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {
                                balance = balance + (item.balance != null ? item.balance : 0);
                            }
                        }
                        yValues.Add((int)balance);
                    }
                    seriesYValues.Add(yValues);
                    BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                    return barChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private BarChartData GetReceiveableBalanceByStatus(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Receiveable Balances by Status", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> series = new List<string>() { "Receiveable Balances" };
            List<List<int>> seriesYValues = new List<List<int>>();
            List<string> labels = new List<string>();
            List<int> yValues = new List<int>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select sum(i.balance) as balance, status from invoice i " +
                        "where (i.invoice_date between @invoice_date_from and @invoice_date_to " +
                        "and status in @status_list) ";

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += " group by status";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    List<int> statusList = new List<int>() { Status.UNPAID.Value, Status.PAST_DUE.Value };
                    parameters.Add("status_list", statusList);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        if (item != null)
                        {
                            Status status = Status.CreateInstance(item.status);
                            labels.Add(status.DisplayName);
                            yValues.Add((int)item.balance);
                        }
                    }
                    seriesYValues.Add(yValues);
                    BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                    return barChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private BarChartData GetInvoiceVolumeByMonthBarChart(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Invoice Volume by Month", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> labels = new List<string>();
            List<int> yValues = new List<int>();
            List<string> series = new List<string>() { "Invoice Volume" };
            var parameters = new DynamicParameters();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select sum(unit_price) as volume, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i inner join invoice_item ii " +
                        " on i.invoice_id = ii.invoice_id " +
                        "where (i.invoice_date between @invoice_date_from and @invoice_date_to) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += " group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        labels.Add(key);
                        decimal volume = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {
                                volume = volume + (item.volume != null ? item.volume : 0);
                            }
                        }
                        yValues.Add((int)volume);
                    }

                    List<List<int>> seriesYValues = new List<List<int>>();
                    seriesYValues.Add(yValues);
                    BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                    return barChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private BarChartData GetAmountCreditsByMonth(ChartFilterData chartFilterData)
        {

            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Amount Credits by Month", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> labels = new List<string>();
            List<string> series = new List<string>() { "Credits" };
            List<int> yValues = new List<int>();
            var parameters = new DynamicParameters();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select sum(p.amount) as amount, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i " +
                        " inner join payment p on i.invoice_id = p.invoice_id " +
                        " where (i.invoice_date between @invoice_date_from and @invoice_date_to ) ";

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += " group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        labels.Add(key);
                        decimal amount = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {
                                amount = amount + (item.amount != null ? item.amount : 0);
                            }
                        }
                        yValues.Add((int)amount);
                    }

                    List<List<int>> seriesYValues = new List<List<int>>();
                    seriesYValues.Add(yValues);
                    BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                    return barChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private BarChartData GetInvoiceCountAndItemAverageByMonth(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Invoice Count And Item Average by Month", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> series = new List<string>() { "# of Invoices", "Avg. # of Items" };
            List<int> seriesNumInvoicesValues = new List<int>();
            List<int> seriesAvgItemsValues = new List<int>();

            List<string> labels = new List<string>();
            var parameters = new DynamicParameters();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select count(*) as volume, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i " +
                        " where (i.invoice_date between @invoice_date_from and @invoice_date_to ) ";


                    string findItemsStatement = @"select count(*) as item_volume, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i " +
                        " inner join invoice_item ii on i.invoice_id = ii.invoice_id " +
                        " where (i.invoice_date between @invoice_date_from and @invoice_date_to ) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        findItemsStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += " group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ;";

                    findItemsStatement += " group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ;";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> invoiceResults = cn.Query<dynamic>(findStatement, parameters);
                    IEnumerable<dynamic> itemResults = cn.Query<dynamic>(findItemsStatement, parameters);

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        labels.Add(key);
                        int volume = 0;
                        int item_volume = 0;

                        foreach (var item in invoiceResults)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {

                                volume = volume + (item.volume != null ? item.volume : 0);
                            }
                        }
                        seriesNumInvoicesValues.Add(volume);

                        foreach (var item in itemResults)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {

                                item_volume = item_volume + (item.item_volume != null ? item.item_volume : 0);
                            }
                        }

                        if (volume == 0)
                            seriesAvgItemsValues.Add(0);
                        else
                            seriesAvgItemsValues.Add(item_volume / volume);
                    }

                    List<List<int>> seriesYValues = new List<List<int>>();
                    seriesYValues.Add(seriesNumInvoicesValues);
                    seriesYValues.Add(seriesAvgItemsValues);
                    BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                    return barChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private BarChartData GetPaymentHistorybyClient(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Payment History by Client", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> labels = new List<string>() { 
                "Early", "On Time", "1 Mo. Late", "2 Mo. Late", "3 Mo. Late", "4+ Mo. Late"
            };
            List<string> series = new List<string>();
            List<List<int>> seriesYValues = new List<List<int>>();

            Dictionary<string, List<int>> paymentHistoryByClients = new Dictionary<string, List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select i1.invoice_id, i2.last_payment_date, i1.balance, i1.invoice_date, i1.status, i1.client_name from invoice i1 inner join " +
                        "(select max(date) as last_payment_date, invoice_id from dbo.payment group by invoice_id) i2 " +
                        "on i1.invoice_id = i2.invoice_id " +
                        "where i1.invoice_date between @invoice_date_from and @invoice_date_to and i1.status in @status_list ";

                    if (chartFilterData.IsAllClients)
                    {
                        throw new ArgumentException("You cannot select \"All Client\" with this chart type.\n" +
                            "Creating a chart with this request will result in a chart that takes very long to display and is also too small to be legible.");
                    }
                    else if (chartFilterData.ClientIds.Count > 10)
                    {
                        throw new ArgumentException("You cannot select too many clients with this chart type.\n" +
                            "Creating a chart with this request will result in a chart that takes very long to display and is also too small to be legible.");
                    }
                    else
                    {
                        findStatement += "and i1.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);

                    List<int> statusList = new List<int>() { Status.OVER_PAY.Value, Status.PD_LATE.Value, Status.PAID.Value };
                    parameters.Add("status_list", statusList);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    foreach (var item in result)
                    {

                        if (!paymentHistoryByClients.ContainsKey(item.client_name))
                        {
                            List<int> yValues = new List<int>() { 0, 0, 0, 0, 0, 0 };
                            paymentHistoryByClients[item.client_name] = yValues;
                        }

                        if (item.last_payment_date == null || item.balance > 0)
                        {
                            paymentHistoryByClients[item.client_name][0]++;
                        }
                        else
                        {
                            DateTime lastPaymentDate = ((DateTime)(item.last_payment_date)).ToLocalTime();
                            DateTime dueDate = InvoiceCalculationHelper.GetDueDate(((DateTime)item.invoice_date).ToLocalTime());
                            double dateDiff = (lastPaymentDate - dueDate).TotalDays;
                            if (dateDiff < -10)
                            {
                                paymentHistoryByClients[item.client_name][0]++;
                            }
                            else if (dateDiff < 1)
                            {
                                paymentHistoryByClients[item.client_name][1]++;
                            }
                            else
                            {
                                DateTime lastPyamentToDiff = lastPaymentDate.AddDays(1 - dueDate.Day);
                                DateTime dueDateToDiff = dueDate.AddDays(1 - dueDate.Day);
                                int monthDiff = (lastPyamentToDiff.Year - dueDateToDiff.Year) * 12 + (lastPyamentToDiff.Month - dueDateToDiff.Month) + 1;

                                if (monthDiff <= 1)
                                {
                                    paymentHistoryByClients[item.client_name][2]++;
                                }
                                else if (monthDiff == 2)
                                {
                                    paymentHistoryByClients[item.client_name][3]++;
                                }
                                else if (monthDiff == 3)
                                {
                                    paymentHistoryByClients[item.client_name][4]++;
                                }
                                else
                                {
                                    paymentHistoryByClients[item.client_name][5]++;
                                }
                            }
                        }
                    }

                    foreach (var item in paymentHistoryByClients)
                    {
                        series.Add(item.Key);
                        List<int> yValues = (List<int>)item.Value;
                        seriesYValues.Add(yValues);
                    }

                    BarChartData barChartData = new BarChartData(title, series, labels, seriesYValues);
                    return barChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        #endregion;

        #region LineChart

        public LineChartData GetLineChartFromCommon(ChartFilterData chartFilterData)
        {

            if (chartFilterData.ChartSubType == ChartSubTypeCommon.AppsTurnaroundEachUser.Value)
            {
                return GetAppsTurnaroundEachUserLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == ChartSubTypeCommon.AppsCompletedEachUser.Value)
            {
                return GetAppsCompletedEachUserLineChartData(chartFilterData);
            }
            return null;
        }

        public LineChartData GetLineChartFromApplications(ChartFilterData chartFilterData)
        {
            if (chartFilterData.ChartSubType == LineChartSubTypeApplications.AppsReceivedByWeek.Value)
            {
                return GetAppsReceivedByWeekLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeApplications.AppCompletedByWeek.Value)
            {
                return GetAppCompletedByWeekLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeApplications.AppsCompletedDailyByUsers.Value)
            {
                return GetAppsCompletedDailyByUsersLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeApplications.AppsCompletedWeeklyByUsers.Value)
            {
                return GetAppsCompletedWeeklyByUsersLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeApplications.AppsCompletedByTurnaroundTime.Value)
            {
                return GetAppsCompletedByTurnaroundTimeLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeApplications.AppsReceivedByClient.Value)
            {
                return GetAppsReceivedByClientLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeApplications.AppsReceivedByMonth.Value)
            {
                return GetAppsReceivedByMonthLineChartData(chartFilterData);
            }
            return null;
        }

        public LineChartData GetLineChartFromInvoices(ChartFilterData chartFilterData)
        {
            if (chartFilterData.ChartSubType == LineChartSubTypeInvoices.InvoiceStatusByMonth.Value)
            {
                return GetInvoiceStatusByMonthLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeInvoices.InvoiceQuantityEfficiency.Value)
            {
                return GetInvoiceQuantityEfficiencyLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeInvoices.InvoiceVolumeByMonth.Value)
            {
                return GetInvoiceVolumeByMonthLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeInvoices.AmountCreditsByMonth.Value)
            {
                return GetAmountCreditsByMonthLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeInvoices.InvoicePaymentHistory.Value)
            {
                return GetInvoicePaymentHistoryLineChartData(chartFilterData);
            }
            else if (chartFilterData.ChartSubType == LineChartSubTypeInvoices.InvoicePaymentHistoryByClient.Value)
            {
                return GetInvoicePaymentHistoryByClientLineChartData(chartFilterData);
            }
            return null;
        }

        // done
        private LineChartData GetAppsTurnaroundEachUserLineChartData(ChartFilterData chartFilterData)
        {
            var parameters = new DynamicParameters();

            string title = string.Format("{0}  {1} - {2}", "Applications Completed by Turnaround Time",
                chartFilterData.DateFrom.ToLocalTime().ToString("MM/dd/yy"),
                chartFilterData.DateTo.ToLocalTime().ToString("MM/dd/yy"));

            List<string> series = new List<string>();
            List<string> labels = new List<string>() { "Same Day", "Next Day", "2 Days", "3 Days", "4 Days", "5+ Days" };
            List<List<int>> seriesYValues = new List<List<int>>();
            Dictionary<string, List<int>> turnaroundValues = new Dictionary<string, List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select a.received_date, a.completed_date, u.username as name from application a " +
                        "inner join dbo.[user] u on a.screener_id = u.user_id " +
                        "where (a.completed_date between @completed_from and @completed_to) ";

                    if (chartFilterData.IsFullAppOnly)
                    {
                        findStatement = @"select a.received_date, a.completed_date, u.username as name from application a " +
                            "inner join dbo.[user] u on a.screener_id = u.user_id inner join report_type r on a.report_type_id = r.report_type_id " +
                            "where (a.completed_date between @completed_from and @completed_to) " +
                            "and r.type_name in ('Comm', 'Cosigner', 'Emp1', 'Res1', 'Res2', 'Res3', 'Res4', 'Roommate', 'ZFreebieEmp', 'ZFreebieRes1') ";
                    }

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        DateTime start = ((DateTime)(item.received_date)).ToLocalTime();
                        DateTime stop = ((DateTime)(item.completed_date)).ToLocalTime();
                        int businessDaysDiff = DateTimeHelper.GetBusinessDaysDifference(start, stop);
                        string name = item.name;
                        if (!turnaroundValues.ContainsKey(name))
                        {
                            turnaroundValues.Add(name, new List<int>() { 0, 0, 0, 0, 0, 0 });
                        }

                        if (businessDaysDiff < 5 && businessDaysDiff >= 0)
                        {
                            turnaroundValues[name][businessDaysDiff] += 1;
                        }
                        else if (businessDaysDiff >= 5)
                        {
                            turnaroundValues[name][5] += 1;
                        }
                    }

                    foreach (var item in turnaroundValues)
                    {
                        series.Add(item.Key);
                        List<int> yValues = (List<int>)item.Value ?? new List<int>() { 0, 0, 0, 0, 0, 0 };
                        seriesYValues.Add(yValues);
                    }

                    LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                    return lineChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        private LineChartData GetAppsCompletedEachUserLineChartData(ChartFilterData chartFilterData)
        {

            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Applications Completed Weekly by Users", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));
            List<string> labels = new List<string>();
            List<string> series = new List<string>();
            List<List<int>> seriesYValues = new List<List<int>>();
            Dictionary<string, List<int>> completedEachUserValues = new Dictionary<string, List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(week, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as week," +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as year, a.screener_name, " +
                        "count(*) as num from application a left join dbo.[user] u on a.screener_id = u.user_id " +
                        "where (a.completed_date between @completed_from and @completed_to) ";

                    if (chartFilterData.IsFullAppOnly)
                    {
                        findStatement = @"select datepart(week, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as week," +
                            "datepart(year, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as year, a.screener_name, " +
                            "count(*) as num from application a left join dbo.[user] u on a.screener_id = u.user_id " +
                            "left join report_type r on a.report_type_id = r.report_type_id " +
                            "where (a.completed_date between @completed_from and @completed_to) " +
                            "and r.type_name in ('Comm', 'Cosigner', 'Emp1', 'Res1', 'Res2', 'Res3', 'Res4', 'Roommate', 'ZFreebieEmp', 'ZFreebieRes1') ";
                    }

                    var parameters = new DynamicParameters();

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(week, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)), " +
                        "a.screener_name ";

                    string datepartStatement = @"select datepart(year, @input_date) as year, datepart(month, @input_date) as month, datepart(week, @input_date) as week, datepart(day, @input_date) as day ";

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    foreach (var item in result)
                    {
                        if (!completedEachUserValues.ContainsKey(item.screener_name) && !string.IsNullOrEmpty(item.screener_name))
                        {
                            List<int> yValues = new List<int>();
                            completedEachUserValues[item.screener_name] = yValues;
                        }
                    }

                    for (DateTime startOfWeek = DateTimeHelper.StartOfWeek(localStart, DayOfWeek.Sunday); startOfWeek < localEnd; startOfWeek = startOfWeek.AddDays(7))
                    {
                        DateTime endOfWeek = startOfWeek.AddDays(7).AddMinutes(-5).Date;
                        if (endOfWeek > localEnd)
                        {
                            continue;
                        }

                        dynamic datepart = cn.Query<dynamic>(datepartStatement, new { input_date = endOfWeek }).FirstOrDefault();
                        int currentWeek = datepart.week;
                        int currentYear = datepart.year;

                        string key = string.Format("{0}-{1}", startOfWeek.ToString("MM/dd/yy"), endOfWeek.ToString("MM/dd/yy"));
                        labels.Add(key);

                        foreach (var user in completedEachUserValues)
                        {
                            int num = 0;
                            foreach (var item in result)
                            {
                                int week = item.week;
                                int year = item.year;
                                string name = item.screener_name;

                                if (currentWeek == week && currentYear == year && name == user.Key)
                                {
                                    num = num + (item.num != null ? item.num : 0);
                                }
                            }
                            user.Value.Add(num);
                        }
                    }

                    foreach (var item in completedEachUserValues)
                    {
                        series.Add(item.Key);
                        List<int> yValues = (List<int>)item.Value;
                        seriesYValues.Add(yValues);
                    }
                }
                LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                return lineChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        // done
        public LineChartData GetAppsReceivedByWeekLineChartData(ChartFilterData chartFilterData)
        {

            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Applications Received by Week", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));
            List<string> series = new List<string>();
            List<string> labels = new List<string>() { "Mon", "Tue", "Web", "Thu", "Fri", "Sat" };
            List<List<int>> seriesYValues = new List<List<int>>();
            Dictionary<string, List<int>> receivedByWeekValues = new Dictionary<string, List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(week, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as week, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as year, " +
                        "datepart(weekday, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as weekday, " +
                        "count(*) as num from application a " +
                        "where (a.received_date between @received_from and @received_to) ";

                    string datepartStatement = @"select datepart(year, @input_date) as year, datepart(month, @input_date) as month, datepart(week, @input_date) as week, datepart(day, @input_date) as day ";

                    var parameters = new DynamicParameters();

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(week, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)), " +
                        "datepart(weekday, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) ";

                    parameters.Add("received_from", chartFilterData.DateFrom);
                    parameters.Add("received_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfWeek = DateTimeHelper.StartOfWeek(localStart, DayOfWeek.Sunday); startOfWeek < localEnd; startOfWeek = startOfWeek.AddDays(7))
                    {
                        DateTime endOfWeek = startOfWeek.AddDays(7).AddMinutes(-5).Date;
                        dynamic datepart = cn.Query<dynamic>(datepartStatement, new { input_date = endOfWeek }).FirstOrDefault();
                        int currentWeek = datepart.week;
                        int currentYear = datepart.year;
                        string key = string.Format("{0}-{1}", startOfWeek.ToString("MM/dd/yy"), endOfWeek.ToString("MM/dd/yy"));

                        receivedByWeekValues[key] = new List<int>() { 0, 0, 0, 0, 0, 0 };

                        foreach (var item in result)
                        {
                            int week = item.week;
                            int year = item.year;
                            int weekday = item.weekday;
                            int num = (item.num != null ? item.num : 0);

                            if (currentWeek == week && currentYear == year && weekday >= 2)
                            {
                                receivedByWeekValues[key][weekday - 2] = num;
                            }
                        }
                    }

                    foreach (var item in receivedByWeekValues)
                    {
                        series.Add(item.Key);
                        List<int> yValues = (List<int>)item.Value;
                        seriesYValues.Add(yValues);
                    }
                }
                LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                return lineChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        // done
        public LineChartData GetAppCompletedByWeekLineChartData(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Applications Completed by Week", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));
            List<string> series = new List<string>();
            List<string> labels = new List<string>() { "Mon", "Tue", "Web", "Thu", "Fri", "Sat" };
            List<List<int>> seriesYValues = new List<List<int>>();
            Dictionary<string, List<int>> receivedByWeekValues = new Dictionary<string, List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(week, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as week, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as year, " +
                        "datepart(weekday, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as weekday, " +
                        "count(*) as num from application a " +
                        "where (a.completed_date between @completed_from and @completed_to) ";

                    string datepartStatement = @"select datepart(year, @input_date) as year, datepart(month, @input_date) as month, datepart(week, @input_date) as week, datepart(day, @input_date) as day ";

                    var parameters = new DynamicParameters();

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(week, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)), " +
                        "datepart(weekday, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) ";

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfWeek = DateTimeHelper.StartOfWeek(localStart, DayOfWeek.Sunday); startOfWeek < localEnd; startOfWeek = startOfWeek.AddDays(7))
                    {
                        DateTime endOfWeek = startOfWeek.AddDays(7).AddMinutes(-5).Date;
                        dynamic datepart = cn.Query<dynamic>(datepartStatement, new { input_date = endOfWeek }).FirstOrDefault();
                        int currentWeek = datepart.week;
                        int currentYear = datepart.year;
                        string key = string.Format("{0}-{1}", startOfWeek.ToString("MM/dd/yy"), endOfWeek.ToString("MM/dd/yy"));

                        receivedByWeekValues[key] = new List<int>() { 0, 0, 0, 0, 0, 0 };

                        foreach (var item in result)
                        {
                            int week = item.week;
                            int year = item.year;
                            int weekday = item.weekday;
                            int num = (item.num != null ? item.num : 0);

                            if (currentWeek == week && currentYear == year && weekday >= 2)
                            {
                                receivedByWeekValues[key][weekday - 2] = num;
                            }
                        }
                    }

                    foreach (var item in receivedByWeekValues)
                    {
                        series.Add(item.Key);
                        List<int> yValues = (List<int>)item.Value;
                        seriesYValues.Add(yValues);
                    }
                }
                LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                return lineChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        // done
        public LineChartData GetAppsCompletedDailyByUsersLineChartData(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Applications Completed Daily by Users", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));
            List<string> labels = new List<string>();
            List<string> series = new List<string>();
            List<List<int>> seriesYValues = new List<List<int>>();
            Dictionary<string, List<int>> completedEachUserValues = new Dictionary<string, List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(day, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as day," +
                        "datepart(month, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as month, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as year, u.username, " +
                        "count(*) as num from application a inner join dbo.[user] u on a.screener_id = u.user_id " +
                        "where (a.completed_date between @completed_from and @completed_to) ";

                    var parameters = new DynamicParameters();

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(day, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)), " +
                        "datepart(month, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)), " +
                        "u.username ";

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    foreach (var item in result)
                    {
                        if (!completedEachUserValues.ContainsKey(item.username))
                        {
                            List<int> yValues = new List<int>();
                            completedEachUserValues[item.username] = yValues;
                        }
                    }

                    for (DateTime start = localStart.Date; start < localEnd; start = start.AddDays(1))
                    {
                        if (start.DayOfWeek == DayOfWeek.Sunday)
                            continue;

                        string key = start.ToString("MM/dd/yy");
                        labels.Add(key);

                        foreach (var user in completedEachUserValues)
                        {
                            int num = 0;
                            foreach (var item in result)
                            {
                                int day = item.day;
                                int month = item.month;
                                int year = item.year;
                                string name = item.username;

                                if (day == start.Day && month == start.Month && year == start.Year && name == user.Key)
                                {
                                    num = num + (item.num != null ? item.num : 0);
                                }
                            }
                            user.Value.Add(num);
                        }
                    }

                    foreach (var item in completedEachUserValues)
                    {
                        series.Add(item.Key);
                        List<int> yValues = (List<int>)item.Value;
                        seriesYValues.Add(yValues);
                    }
                }
                LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                return lineChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        // done
        public LineChartData GetAppsCompletedWeeklyByUsersLineChartData(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Applications Completed Weekly by Users", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));
            List<string> labels = new List<string>();
            List<string> series = new List<string>();
            List<List<int>> seriesYValues = new List<List<int>>();
            Dictionary<string, List<int>> completedEachUserValues = new Dictionary<string, List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(week, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as week," +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)) as year, u.username, " +
                        "count(*) as num from application a inner join dbo.[user] u on a.screener_id = u.user_id " +
                        "where (a.completed_date between @completed_from and @completed_to) ";

                    var parameters = new DynamicParameters();

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(week, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.completed_date, @dest_tz) as datetime)), " +
                        "u.username ";

                    string datepartStatement = @"select datepart(year, @input_date) as year, datepart(month, @input_date) as month, datepart(week, @input_date) as week, datepart(day, @input_date) as day ";


                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    foreach (var item in result)
                    {
                        if (!completedEachUserValues.ContainsKey(item.username))
                        {
                            List<int> yValues = new List<int>();
                            completedEachUserValues[item.username] = yValues;
                        }
                    }

                    for (DateTime startOfWeek = DateTimeHelper.StartOfWeek(localStart, DayOfWeek.Sunday); startOfWeek < localEnd; startOfWeek = startOfWeek.AddDays(7))
                    {
                        DateTime endOfWeek = startOfWeek.AddDays(7).AddMinutes(-5).Date;
                        dynamic datepart = cn.Query<dynamic>(datepartStatement, new { input_date = endOfWeek }).FirstOrDefault();
                        int currentWeek = datepart.week;
                        int currentYear = datepart.year;

                        string key = string.Format("{0}/{1}", currentWeek, currentYear);
                        labels.Add(key);

                        foreach (var user in completedEachUserValues)
                        {
                            int num = 0;
                            foreach (var item in result)
                            {
                                int week = item.week;
                                int year = item.year;
                                string name = item.username;

                                if (currentWeek == week && currentYear == year && name == user.Key)
                                {
                                    num = num + (item.num != null ? item.num : 0);
                                }
                            }
                            user.Value.Add(num);
                        }
                    }

                    foreach (var item in completedEachUserValues)
                    {
                        series.Add(item.Key);
                        List<int> yValues = (List<int>)item.Value;
                        seriesYValues.Add(yValues);
                    }
                }
                LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                return lineChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        // done
        public LineChartData GetAppsCompletedByTurnaroundTimeLineChartData(ChartFilterData chartFilterData)
        {
            var parameters = new DynamicParameters();

            string title = string.Format("{0}  {1} - {2}", "Applications Completed by Turnaround Time",
                chartFilterData.DateFrom.ToLocalTime().ToString("MM/dd/yy"),
                chartFilterData.DateTo.ToLocalTime().ToString("MM/dd/yy"));

            List<string> series = new List<string>();
            List<string> labels = new List<string>() { "Same Day", "Next Day", "2 Days", "3 Days", "4 Days", "5+ Days" };
            List<List<int>> seriesYValues = new List<List<int>>();
            Dictionary<string, List<int>> turnaroundValues = new Dictionary<string, List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select a.received_date, a.completed_date, u.username as name from application a " +
                        "inner join dbo.[user] u on a.screener_id = u.user_id " +
                        "where (a.completed_date between @completed_from and @completed_to) ";

                    if (chartFilterData.IsFullAppOnly)
                    {
                        findStatement = @"select a.received_date, a.completed_date, u.username as name from application a " +
                            "inner join dbo.[user] u on a.screener_id = u.user_id inner join report_type r on a.report_type_id = r.report_type_id " +
                            "where (a.completed_date between @completed_from and @completed_to) " +
                            "and r.type_name in ('Comm', 'Cosigner', 'Emp1', 'Res1', 'Res2', 'Res3', 'Res4', 'Roommate', 'ZFreebieEmp', 'ZFreebieRes1') ";
                    }

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    parameters.Add("completed_from", chartFilterData.DateFrom);
                    parameters.Add("completed_to", chartFilterData.DateTo);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                    foreach (var item in result)
                    {
                        DateTime start = ((DateTime)(item.received_date)).ToLocalTime();
                        DateTime stop = ((DateTime)(item.completed_date)).ToLocalTime();
                        int businessDaysDiff = DateTimeHelper.GetBusinessDaysDifference(start, stop);
                        string name = item.name;
                        if (!turnaroundValues.ContainsKey(name))
                        {
                            turnaroundValues.Add(name, new List<int>() { 0, 0, 0, 0, 0, 0 });
                        }

                        if (businessDaysDiff < 5 && businessDaysDiff >= 0)
                        {
                            turnaroundValues[name][businessDaysDiff] += 1;
                        }
                        else if (businessDaysDiff >= 5)
                        {
                            turnaroundValues[name][5] += 1;
                        }
                    }

                    foreach (var item in turnaroundValues)
                    {
                        series.Add(item.Key);
                        List<int> yValues = (List<int>)item.Value ?? new List<int>() { 0, 0, 0, 0, 0, 0 };
                        seriesYValues.Add(yValues);
                    }

                    LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                    return lineChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        public LineChartData GetAppsReceivedByClientLineChartData(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Applications Received by Client", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));
            List<string> labels = new List<string>();
            List<string> series = new List<string>();
            List<List<int>> seriesYValues = new List<List<int>>();
            Dictionary<string, List<int>> receivedEachClient = new Dictionary<string, List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(day, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as day," +
                        "datepart(month, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as month, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as year, c.client_name, " +
                        "count(*) as num from application a inner join client c on a.client_id = c.client_id " +
                        "where (a.received_date between @received_from and @received_to) ";

                    var parameters = new DynamicParameters();

                    if (chartFilterData.IsAllClients)
                    {
                        throw new ArgumentException("You cannot select \"All Client\" with this chart type.\n" +
                            "Creating a chart with this request will result in a chart that takes very long to display and is also too small to be legible.");
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(day, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)), " +
                        "datepart(month, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)), " +
                        "c.client_name ";

                    parameters.Add("received_from", chartFilterData.DateFrom);
                    parameters.Add("received_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    foreach (var item in result)
                    {
                        if (!receivedEachClient.ContainsKey(item.client_name))
                        {
                            List<int> yValues = new List<int>();
                            receivedEachClient[item.client_name] = yValues;
                        }
                    }

                    for (DateTime start = localStart.Date; start < localEnd; start = start.AddDays(1))
                    {
                        if (start.DayOfWeek == DayOfWeek.Sunday)
                            continue;

                        string key = start.ToString("MM/dd/yy");
                        labels.Add(key);

                        foreach (var client in receivedEachClient)
                        {
                            int num = 0;
                            foreach (var item in result)
                            {
                                int day = item.day;
                                int month = item.month;
                                int year = item.year;
                                string name = item.client_name;

                                if (day == start.Day && month == start.Month && year == start.Year && name == client.Key)
                                {
                                    num = num + (item.num != null ? item.num : 0);
                                }
                            }
                            client.Value.Add(num);
                        }
                    }

                    foreach (var item in receivedEachClient)
                    {
                        series.Add(item.Key);
                        List<int> yValues = (List<int>)item.Value;
                        seriesYValues.Add(yValues);
                    }
                }
                LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                return lineChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        // done
        public LineChartData GetAppsReceivedByMonthLineChartData(ChartFilterData chartFilterData)
        {
            try
            {
                DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
                DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

                string title = string.Format("{0}  {1} - {2}", "Applications Received by Month", localStart.ToString("MM/dd/yy"), localEnd.ToString("MM/dd/yy"));

                List<string> labels = new List<string>();
                List<string> series = new List<string>() { "Applicationss Received" };
                List<int> yValues = new List<int>();
                List<List<int>> seriesYValues = new List<List<int>>();

                var parameters = new DynamicParameters();
                Dictionary<string, int> receivedByMonthsValues = new Dictionary<string, int>();

                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select datepart(month, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as month, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) as year, " +
                        "count(*) as num from application a " +
                        "where (a.received_date between @received_from and @received_to) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and a.client_id in @client_list ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }
                    if (!chartFilterData.IsAllReportTypes)
                    {
                        findStatement += "and a.report_type_id in @report_list ";
                        parameters.Add("report_list", chartFilterData.ReportTypeIds);
                    }

                    findStatement += "group by datepart(month, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(a.received_date, @dest_tz) as datetime)) ";

                    parameters.Add("received_from", chartFilterData.DateFrom);
                    parameters.Add("received_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);
                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        labels.Add(key);
                        int num = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {
                                num = num + (item.num != null ? item.num : 0);
                            }
                        }
                        yValues.Add(num);
                    }
                }

                seriesYValues.Add(yValues);
                LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                return lineChartData;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        public LineChartData GetInvoiceStatusByMonthLineChartData(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Invoice Status by Month", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> series = Status.GetAll<Status>().Select(s => s.DisplayName).ToList();
            List<string> labels = new List<string>();
            List<List<int>> seriesYValues = new List<List<int>>();

            foreach (string serie in series)
            {
                List<int> seriesYValue = new List<int>();
                seriesYValues.Add(seriesYValue);
            }


            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select count(*) as num, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        "datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year, status  " +
                        "from invoice i " +
                        "where (i.invoice_date between @invoice_date_from and @invoice_date_to) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += "group by status, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        "datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);



                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        labels.Add(key);
                        for (int i = 0; i < seriesYValues.Count; i++)
                        {
                            seriesYValues[i].Add(0);
                        }
                        int num = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;
                            int status = item.status;

                            if (currentMonth == month && currentYear == year)
                            {
                                num = item.num == null ? 0 : item.num;
                                seriesYValues[status][labels.Count - 1] += num;
                            }
                        }
                    }
                    LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                    return lineChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        public LineChartData GetInvoiceQuantityEfficiencyLineChartData(ChartFilterData chartFilterData)
        {

            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            string title = string.Format("{0}  {1} - {2}", "Invoice Quantity Efficiency", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> series = new List<string>() { "# of Invoices", "Avg. # of Items" };
            List<int> seriesNumInvoicesValues = new List<int>();
            List<int> seriesAvgItemsValues = new List<int>();

            List<string> labels = new List<string>();
            var parameters = new DynamicParameters();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select count(*) as volume, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i " +
                        " where (i.invoice_date between @invoice_date_from and @invoice_date_to ) ";


                    string findItemsStatement = @"select count(*) as item_volume, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i " +
                        " inner join invoice_item ii on i.invoice_id = ii.invoice_id " +
                        " where (i.invoice_date between @invoice_date_from and @invoice_date_to ) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        findItemsStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += " group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ;";

                    findItemsStatement += " group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ;";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> invoiceResults = cn.Query<dynamic>(findStatement, parameters);
                    IEnumerable<dynamic> itemResults = cn.Query<dynamic>(findItemsStatement, parameters);



                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        labels.Add(key);
                        int volume = 0;
                        int item_volume = 0;

                        foreach (var item in invoiceResults)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {

                                volume = volume + (item.volume != null ? item.volume : 0);
                            }
                        }
                        seriesNumInvoicesValues.Add(volume);

                        foreach (var item in itemResults)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {

                                item_volume = item_volume + (item.item_volume != null ? item.item_volume : 0);
                            }
                        }

                        if (volume == 0)
                            seriesAvgItemsValues.Add(0);
                        else
                            seriesAvgItemsValues.Add(item_volume / volume);
                    }

                    List<List<int>> seriesYValues = new List<List<int>>();
                    seriesYValues.Add(seriesNumInvoicesValues);
                    seriesYValues.Add(seriesAvgItemsValues);
                    LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                    return lineChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        public LineChartData GetInvoiceVolumeByMonthLineChartData(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Invoices Volume by Month", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> labels = new List<string>();
            List<int> yValues = new List<int>();
            List<string> series = new List<string>() { "Invoices Volume" };
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select sum(unit_price) as volume, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i " +
                        " inner join invoice_item ii on i.invoice_id = ii.invoice_id " +
                        "where (i.invoice_date between @invoice_date_from and @invoice_date_to) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += " group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        labels.Add(key);
                        decimal volume = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {
                                volume = volume + (item.volume != null ? item.volume : 0);
                            }
                        }
                        yValues.Add((int)volume);
                    }

                    List<List<int>> seriesYValues = new List<List<int>>();
                    seriesYValues.Add(yValues);
                    LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                    return lineChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        public LineChartData GetAmountCreditsByMonthLineChartData(ChartFilterData chartFilterData)
        {
            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();

            string title = string.Format("{0}  {1} - {2}", "Amount Credits by Month", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> labels = new List<string>();
            List<string> series = new List<string>() { "Amount Credits" };
            List<int> yValues = new List<int>();
            var parameters = new DynamicParameters();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select sum(p.amount) as amount, datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as month, " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) as year from invoice i " +
                        " inner join payment p on i.invoice_id = p.invoice_id " +
                        " where (i.invoice_date between @invoice_date_from and @invoice_date_to ) ";


                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    findStatement += " group by  datepart(month, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)), " +
                        " datepart(year, cast(Tzdb.UtcToLocal(i.invoice_date, @dest_tz) as datetime)) ";

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);
                    parameters.Add("dest_tz", chartFilterData.LocalTimeZone);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    for (DateTime startOfMonth = new DateTime(localStart.Year, localStart.Month, 1); startOfMonth < localEnd; startOfMonth = startOfMonth.AddMonths(1))
                    {
                        int currentMonth = startOfMonth.Month;
                        int currentYear = startOfMonth.Year;
                        string key = string.Format("{0}/{1}", currentMonth, currentYear);
                        labels.Add(key);
                        decimal amount = 0;

                        foreach (var item in result)
                        {
                            int month = item.month;
                            int year = item.year;

                            if (currentMonth == month && currentYear == year)
                            {
                                amount = amount + (item.amount != null ? item.amount : 0);
                            }
                        }
                        yValues.Add((int)amount);
                    }

                    List<List<int>> seriesYValues = new List<List<int>>();
                    seriesYValues.Add(yValues);
                    LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                    return lineChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        public LineChartData GetInvoicePaymentHistoryLineChartData(ChartFilterData chartFilterData)
        {

            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Invoice Payment History", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> labels = new List<string>() { 
                "Early", "On Time", "1 Mo. Late", "2 Mo. Late", "3 Mo. Late", "4+ Mo. Late"
            };
            List<string> series = new List<string>() { "# of Invoices"};
            List<int> yValues = new List<int>() { 0, 0, 0, 0, 0, 0 };
            List<List<int>> seriesYValues = new List<List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select i1.invoice_id, i2.last_payment_date, i1.balance, i1.invoice_date, i1.status, i1.client_name from invoice i1 inner join " +
                        "(select max(date) as last_payment_date, invoice_id from dbo.payment group by invoice_id) i2 " +
                        "on i1.invoice_id = i2.invoice_id " +
                        "where i1.invoice_date between @invoice_date_from and @invoice_date_to and i1.status in @status_list ";

                    if (!chartFilterData.IsAllClients)
                    {
                        findStatement += "and i1.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);

                    List<int> statusList = new List<int>() { Status.OVER_PAY.Value, Status.PD_LATE.Value, Status.PAID.Value };
                    parameters.Add("status_list", statusList);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    foreach (var item in result)
                    {

                        if (item.last_payment_date == null || item.balance > 0)
                        {
                            yValues[0]++;
                        }
                        else
                        {
                            DateTime lastPaymentDate = ((DateTime)(item.last_payment_date)).ToLocalTime();
                            DateTime dueDate = InvoiceCalculationHelper.GetDueDate(((DateTime)item.invoice_date).ToLocalTime());
                            double dateDiff = (lastPaymentDate - dueDate).TotalDays;
                            if (dateDiff < -10)
                            {
                                yValues[0]++;
                            }
                            else if (dateDiff < 1)
                            {
                                yValues[1]++;
                            }
                            else
                            {
                                DateTime lastPyamentToDiff = lastPaymentDate.AddDays(1 - dueDate.Day);
                                DateTime dueDateToDiff = dueDate.AddDays(1 - dueDate.Day);
                                int monthDiff = (lastPyamentToDiff.Year - dueDateToDiff.Year) * 12 + (lastPyamentToDiff.Month - dueDateToDiff.Month) + 1;

                                if (monthDiff <= 1)
                                {
                                    yValues[2]++;
                                }
                                else if (monthDiff == 2)
                                {
                                    yValues[3]++;
                                }
                                else if (monthDiff == 3)
                                {
                                    yValues[4]++;
                                }
                                else
                                {
                                    yValues[5]++;
                                }
                            }
                        }
                    }
                    seriesYValues.Add(yValues);
                    LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                    return lineChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        // done
        public LineChartData GetInvoicePaymentHistoryByClientLineChartData(ChartFilterData chartFilterData)
        {

            DateTime localStart = chartFilterData.DateFrom.ToLocalTime();
            DateTime localEnd = chartFilterData.DateTo.ToLocalTime();
            var parameters = new DynamicParameters();
            string title = string.Format("{0}  {1} - {2}", "Invoice Payment History by Client", localStart.ToString("MM/yy"), localEnd.ToString("MM/yy"));
            List<string> labels = new List<string>() { 
                "Early", "On Time", "1 Mo. Late", "2 Mo. Late", "3 Mo. Late", "4+ Mo. Late"
            };
            List<string> series = new List<string>();
            List<List<int>> seriesYValues = new List<List<int>>();

            Dictionary<string, List<int>> paymentHistoryByClients = new Dictionary<string, List<int>>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select i1.invoice_id, i2.last_payment_date, i1.balance, i1.invoice_date, i1.status, i1.client_name from invoice i1 inner join " +
                        "(select max(date) as last_payment_date, invoice_id from dbo.payment group by invoice_id) i2 " +
                        "on i1.invoice_id = i2.invoice_id " +
                        "where i1.invoice_date between @invoice_date_from and @invoice_date_to and i1.status in @status_list ";

                    if (chartFilterData.IsAllClients)
                    {
                        throw new ArgumentException("You cannot select \"All Client\" with this chart type.\n" +
                            "Creating a chart with this request will result in a chart that takes very long to display and is also too small to be legible.");
                    }
                    else if (chartFilterData.ClientIds.Count > 10)
                    {
                        throw new ArgumentException("You cannot select too many clients with this chart type.\n" +
                            "Creating a chart with this request will result in a chart that takes very long to display and is also too small to be legible.");
                    }
                    else
                    {
                        findStatement += "and i1.client_name in (select client_name from client where client_id in @client_list) ";
                        parameters.Add("client_list", chartFilterData.ClientIds);
                    }

                    parameters.Add("invoice_date_from", chartFilterData.DateFrom);
                    parameters.Add("invoice_date_to", chartFilterData.DateTo);

                    List<int> statusList = new List<int>() { Status.OVER_PAY.Value, Status.PD_LATE.Value, Status.PAID.Value };
                    parameters.Add("status_list", statusList);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    foreach (var item in result)
                    {

                        if (!paymentHistoryByClients.ContainsKey(item.client_name))
                        {
                            List<int> yValues = new List<int>() { 0, 0, 0, 0, 0, 0 };
                            paymentHistoryByClients[item.client_name] = yValues;
                        }

                        if (item.last_payment_date == null || item.balance > 0)
                        {
                            paymentHistoryByClients[item.client_name][0]++;
                        }
                        else
                        {
                            DateTime lastPaymentDate = ((DateTime)(item.last_payment_date)).ToLocalTime();
                            DateTime dueDate = InvoiceCalculationHelper.GetDueDate(((DateTime)item.invoice_date).ToLocalTime());
                            double dateDiff = (lastPaymentDate - dueDate).TotalDays;
                            if (dateDiff < -10)
                            {
                                paymentHistoryByClients[item.client_name][0]++;
                            }
                            else if (dateDiff < 1)
                            {
                                paymentHistoryByClients[item.client_name][1]++;
                            }
                            else
                            {
                                DateTime lastPyamentToDiff = lastPaymentDate.AddDays(1 - dueDate.Day);
                                DateTime dueDateToDiff = dueDate.AddDays(1 - dueDate.Day);
                                int monthDiff = (lastPyamentToDiff.Year - dueDateToDiff.Year) * 12 + (lastPyamentToDiff.Month - dueDateToDiff.Month) + 1;

                                if (monthDiff <= 1)
                                {
                                    paymentHistoryByClients[item.client_name][2]++;
                                }
                                else if (monthDiff == 2)
                                {
                                    paymentHistoryByClients[item.client_name][3]++;
                                }
                                else if (monthDiff == 3)
                                {
                                    paymentHistoryByClients[item.client_name][4]++;
                                }
                                else
                                {
                                    paymentHistoryByClients[item.client_name][5]++;
                                }
                            }
                        }
                    }

                    foreach (var item in paymentHistoryByClients)
                    {
                        series.Add(item.Key);
                        List<int> yValues = (List<int>)item.Value;
                        seriesYValues.Add(yValues);
                    }

                    LineChartData lineChartData = new LineChartData(title, series, labels, seriesYValues);
                    return lineChartData;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
        #endregion;
    }
}
