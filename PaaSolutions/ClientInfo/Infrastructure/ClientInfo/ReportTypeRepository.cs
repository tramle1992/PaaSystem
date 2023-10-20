using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Infrastructure.Repository;
using Core.Domain.Model.ClientInfo;
using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace Core.Infrastructure.ClientInfo
{
    public class ReportTypeRepository : Repository<ReportType, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReportTypeRepository()
        {

        }

        public override void Add(ReportType item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert report_type(report_type_id, type_name, absolute_type_name, default_price, created_at, updated_at) " +
                        "values (@report_type_id, @type_name, @absolute_type_name, @default_price, @created_at, @updated_at) ";

                    cn.Execute(insertStatement,
                        new
                        {
                            report_type_id = item.ReportTypeId.ToString(),
                            type_name = item.TypeName,
                            absolute_type_name = item.AbsoluteTypeName,
                            default_price = item.DefaultPrice,
                            created_at = DateTime.UtcNow,
                            updated_at = DateTime.UtcNow
                        });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Remove(ReportType item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from report_type where report_type_id = @report_type_id";

                    cn.Execute(deleteStatement, new { report_type_id = item.ReportTypeId.ToString() });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(ReportType item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    var updateStatement = @"update report_type set type_name = @type_name" +
                        ", absolute_type_name = @absolute_type_name, default_price = @default_price" +
                        ", updated_at = @updated_at where report_type_id = @report_type_id";

                    cn.Execute(updateStatement,
                        new
                        {
                            type_name = item.TypeName,
                            absolute_type_name = item.AbsoluteTypeName,
                            default_price = item.DefaultPrice,
                            report_type_id = item.ReportTypeId.ToString(),
                            updated_at = DateTime.UtcNow
                        });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override ReportType Find(string id)
        {
            ReportType reportType = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select * from report_type where report_type_id = @report_type_id";
                    dynamic item = cn.Query<dynamic>(findStatement, new { report_type_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.type_name))
                    {
                        reportType = new ReportType(id, item.type_name, item.absolute_type_name, item.default_price);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return reportType;
        }

        public ReportType FindByTypeName(string reportTypeName)
        {
            ReportType reportType = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select * from report_type where type_name = @type_name";
                    dynamic item = cn.Query<dynamic>(findStatement, new { type_name = reportTypeName }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.report_type_id))
                    {
                        reportType = new ReportType(item.report_type_id, item.type_name, item.absolute_type_name, item.default_price);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return reportType;
        }

        public List<ReportType> FindAll()
        {
            List<ReportType> lstReportType = new List<ReportType>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select * from report_type order by type_name asc";
                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var item in result)
                    {
                        ReportType reportType = new ReportType(item.report_type_id, item.type_name, item.absolute_type_name, item.default_price);
                        lstReportType.Add(reportType);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }

            return lstReportType;
        }

        public void RemoveAll()
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    cn.Execute(@"delete from report_type");
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void Remove(string reportTypeId)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from report_type where report_type_id = @report_type_id";

                    cn.Execute(deleteStatement, new { report_type_id = reportTypeId });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }

}
