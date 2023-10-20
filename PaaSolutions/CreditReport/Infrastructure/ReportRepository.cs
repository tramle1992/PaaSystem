using Common.Infrastructure.Repository;
using CreditReport.Domain.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditReport.Infrastructure
{
    public class ReportRepository : Repository<Report, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReportRepository() { }

        public override void Add(Report item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    //if (item.ApplicationId == "26170868-25aa-4fc6-99a0-1e5d2dfcb81e")
                    //{
                    //    string insertStatement = @"INSERT credit_report(report_id, application_id, type, data_blob, created_at, updated_at, end_user, status_code, pulled_by) " +
                    //                            "VALUES (N'DC26D2F6-29CB-422D-B724-755D3C1C252C', N'26170868-25aa-4fc6-99a0-1e5d2dfcb81e', N'Regular Credit Reports', " +
                    //"'', CAST(N'2017-09-18 16:55:25.123' AS DateTime), CAST(N'2017-09-18 16:55:25.347' AS DateTime), N'Grand Management Services', N'0', N'Ken')";

                    //    cn.Execute(insertStatement);
                    //}
                    //else
                    //{
                    string insertStatement = @"insert credit_report(report_id, application_id, type, end_user, data_blob, created_at, updated_at, status_code, pulled_by) " +
                        " values (@report_id, @application_id, @type, @end_user, @data_blob, @created_at, @updated_at, @status_code, @pulled_by) ";

                    var args = new DynamicParameters();
                    args.Add("report_id", item.ReportId);
                    args.Add("application_id", item.ApplicationId);
                    args.Add("type", item.Type);
                    args.Add("end_user", item.EndUser);
                    args.Add("data_blob", item.DataBlob);
                    args.Add("created_at", DateTime.UtcNow);
                    args.Add("updated_at", DateTime.UtcNow);
                    args.Add("status_code", item.StatusCode);
                    args.Add("pulled_by", item.PulledBy);

                    cn.Execute(insertStatement, args);
                    //}
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Remove(Report item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from credit_report where report_id = @report_id";

                    cn.Execute(deleteStatement, new { report_id = item.ReportId });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(Report item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update credit_report set report_id=@report_id, application_id=@application_id" +
                        ", type=@type, end_user=@end_user, data_blob=@data_blob, created_at=@created_at, created_at=@created_at, status_code=@status_code, pulled_by=@pulled_by" +
                        " where report_id=@report_id";

                    var args = new DynamicParameters();
                    args.Add("report_id", item.ReportId);
                    args.Add("application_id", item.ApplicationId);
                    args.Add("type", item.Type);
                    args.Add("end_user", item.EndUser);
                    args.Add("data_blob", item.DataBlob);
                    args.Add("updated_at", DateTime.UtcNow);
                    args.Add("status_code", item.StatusCode);
                    args.Add("pulled_by", item.PulledBy);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override Report Find(string id)
        {
            Report creditReport = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select report_id, application_id, type, end_user, data_blob, created_at, updated_at, status_code, pulled_by " +
                        " from credit_report " +
                        " where report_id = @report_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { report_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.report_id))
                    {
                        creditReport = new Report();
                        creditReport.ReportId = item.report_id;
                        creditReport.ApplicationId = item.application_id;
                        creditReport.Type = item.type;
                        creditReport.EndUser = item.end_user;
                        creditReport.DataBlob = item.data_blob;
                        creditReport.CreatedAt = item.created_at;
                        creditReport.UpdatedAt = item.updated_at;
                        creditReport.StatusCode = item.status_code;
                        creditReport.PulledBy = item.pulled_by;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return creditReport;
        }

        public List<Report> FindByAppId(string appId)
        {
            List<Report> listCreditReport = new List<Report>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select report_id, application_id, type, end_user, data_blob, created_at, updated_at, status_code, pulled_by " +
                        " from credit_report " +
                        " where application_id = @application_id";

                     IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, new { application_id = appId });

                    foreach (var item in result)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.report_id))
                        {
                            Report creditReport = new Report();
                            creditReport.ReportId = item.report_id;
                            creditReport.ApplicationId = item.application_id;
                            creditReport.Type = item.type;
                            creditReport.EndUser = item.end_user;
                            creditReport.DataBlob = item.data_blob;
                            creditReport.CreatedAt = item.created_at;
                            creditReport.UpdatedAt = item.updated_at;
                            creditReport.StatusCode = item.status_code;
                            creditReport.PulledBy = item.pulled_by;

                            listCreditReport.Add(creditReport);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return listCreditReport;
        }

        public Report FindByReportAndAppId(string reportId, string appId)
        {
            Report creditReport = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select report_id, application_id, type, end_user, data_blob, created_at, updated_at, status_code, pulled_by " +
                        " from credit_report " +
                        " where report_id = @report_id and application_id = @application_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { report_id = reportId, application_id = appId }).FirstOrDefault();

                    if (item != null && !string.IsNullOrEmpty(item.report_id))
                    {
                        creditReport = new Report();
                        creditReport.ReportId = item.report_id;
                        creditReport.ApplicationId = item.application_id;
                        creditReport.Type = item.type;
                        creditReport.EndUser = item.end_user;
                        creditReport.DataBlob = item.data_blob;
                        creditReport.CreatedAt = item.created_at;
                        creditReport.UpdatedAt = item.updated_at;
                        creditReport.StatusCode = item.status_code;
                        creditReport.PulledBy = item.pulled_by;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return creditReport;
        }

        public List<Report> FindByDate(string date, string timezone)
        {
            List<Report> listCreditReport = new List<Report>();
            int month = DateTime.ParseExact(date, "MM/yyyy", CultureInfo.CurrentCulture).Month;
            int year = DateTime.ParseExact(date, "MM/yyyy", CultureInfo.CurrentCulture).Year;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select report_id, application_id, type, end_user, data_blob, created_at, updated_at, status_code, pulled_by " +
                        " from credit_report " +
                        " where datepart(year, cast(Tzdb.UtcToLocal(updated_at, @dest_tz) as datetime))=@year " + 
                        " and datepart(month, cast(Tzdb.UtcToLocal(updated_at, @dest_tz) as datetime))=@month";

                    var args = new DynamicParameters();
                    args.Add("month", month);
                    args.Add("year", year);
                    args.Add("dest_tz", timezone);


                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, args);

                    foreach (var item in result)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.report_id))
                        {
                            Report creditReport = new Report();
                            creditReport.ReportId = item.report_id;
                            creditReport.ApplicationId = item.application_id;
                            creditReport.Type = item.type;
                            creditReport.EndUser = item.end_user;
                            creditReport.DataBlob = item.data_blob;
                            creditReport.CreatedAt = item.created_at;
                            creditReport.UpdatedAt = item.updated_at;
                            creditReport.StatusCode = item.status_code;
                            creditReport.PulledBy = item.pulled_by;

                            listCreditReport.Add(creditReport);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return listCreditReport;
        }
    }
}
