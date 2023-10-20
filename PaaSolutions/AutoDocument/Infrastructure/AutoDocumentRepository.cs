using AutoDocument.Application.Data;
using Common.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Common.Application;
using Common.Application.Helper;

namespace AutoDocument.Infrastructure
{
    public class AutoDocumentRepository : Repository<DailyReportData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly int MAX_DAYS_ELAPSED = 5;

        public override DailyReportData Find(string id)
        {
            throw new NotImplementedException();
        }

        public override void Add(DailyReportData item)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(DailyReportData item)
        {
            throw new NotImplementedException();
        }

        public override void Remove(DailyReportData item)
        {
            throw new NotImplementedException();
        }

        public List<DailyReportData> GetDailyReport(string username, DateTime date, bool isEveryone = false)
        {
            List<DailyReportData> result = new List<DailyReportData>();
            try
            {
                List<string> fullApps = new List<string> { GlobalConstants.Residential, GlobalConstants.Employment, GlobalConstants.Commercial };

                DateTime fromDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0).ToUniversalTime();

                DateTime toDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59).ToUniversalTime();

                var args = new DynamicParameters();
                args.Add("fromDate", fromDate);
                args.Add("toDate", toDate);
                args.Add("full_apps", fullApps);

                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = "";
                    string whereStatement = "";

                    IEnumerable<dynamic> data = null;

                    if (isEveryone)
                    {
                        findStatement = @"select last_name, first_name, c.client_name, a.received_date, a.completed_date, r.absolute_type_name from [application] a left join client c on c.client_id = a.client_id " +
                            "left join report_type r on a.report_type_id = r.report_type_id ";
                        whereStatement = "where completed_date between @fromDate and @toDate order by completed_date";
                    }
                    else
                    {
                        findStatement = @"select last_name, first_name, c.client_name, a.received_date, a.completed_date, r.absolute_type_name from [application] a left join client c on c.client_id = a.client_id " +
                            "left join report_type r on a.report_type_id = r.report_type_id ";
                        whereStatement = "where screener_name = @username and completed_date between @fromDate and @toDate order by completed_date";
                        args.Add("username", username);
                    }
                    data = cn.Query<dynamic>(findStatement + whereStatement, args);

                    if (data != null)
                    {
                        foreach (var item in data)
                        {
                            if (item != null)
                            {
                                DailyReportData rp = new DailyReportData();
                                rp.Applicant = string.Format("{0}, {1}", item.last_name, item.first_name);
                                rp.ClientName = item.client_name;

                                DateTime receivedDate = Convert.ToDateTime(item.received_date);
                                DateTime receivedDateLocal = receivedDate.ToLocalTime();
                                rp.RecievedDate = receivedDate;
                                if (item.completed_date != null)
                                {
                                    DateTime completedDate = Convert.ToDateTime(item.completed_date);
                                    DateTime completedDateLocal = completedDate.ToLocalTime();
                                    rp.CompletedDate = completedDate;
                                    int workingDate = DateTimeHelper.GetBusinessDaysDifference(receivedDateLocal, completedDateLocal);

                                    switch (workingDate)
                                    {
                                        case 0:
                                            rp.TurnAround = "Same Day";
                                            break;
                                        case 1:
                                            rp.TurnAround = "Next Day";
                                            break;
                                        default:
                                            rp.TurnAround = string.Format("{0} {1}", workingDate, "Days");
                                            break;
                                    }
                                }
                                else
                                {
                                    rp.TurnAround = "In-Process";
                                }
                                if (fullApps.Contains(item.absolute_type_name))
                                {
                                    rp.IsFullApp = true;
                                }
                                else
                                {
                                    rp.IsFullApp = false;
                                }
                                result.Add(rp);
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return result;
        }

        private int GetBusinessWorkingDays(DateTime receivedDate, DateTime completedDate)
        {
            int count = 1;
            try
            {
                var diff = completedDate - receivedDate;
                while ((completedDate - receivedDate).TotalDays > 0)
                {
                    receivedDate = receivedDate.AddDays(1);
                    if (receivedDate.DayOfWeek != DayOfWeek.Sunday && receivedDate.DayOfWeek != DayOfWeek.Saturday)
                    {
                        count += 1;
                    }
                }

                if (count > MAX_DAYS_ELAPSED)
                {
                    count = MAX_DAYS_ELAPSED + 1;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return count;
        }

        public List<UserDisplayInfoData> GetListUsers()
        {
            List<UserDisplayInfoData> listResult = new List<UserDisplayInfoData>();
            try
            {
                string findStatement = @"select user_id, username from [user] where [status] = 0 order by username";

                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    IEnumerable<dynamic> data = cn.Query<dynamic>(findStatement);

                    if (data != null && data.Count() > 0)
                    {
                        foreach (var item in data)
                        {
                            if (item != null)
                            {
                                UserDisplayInfoData user = new UserDisplayInfoData(item.user_id, item.username);

                                listResult.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return listResult;
        }
    }
}
