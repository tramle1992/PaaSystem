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
    public class ManagementCompanyRepository : Repository<ManagementCompany, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ManagementCompanyRepository()
        { }       

        public override void Add(ManagementCompany item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert management_company(management_company_id, name, created_at, updated_at) " +
                        "values (@management_company_id, @name, @created_at, @updated_at) ";

                    cn.Execute(insertStatement,
                        new { 
                            management_company_id = item.ManagementCompanyId.ToString(),
                            name = item.Name,
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

        public override void Remove(ManagementCompany item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from management_company where management_company_id=@management_company_id";

                    cn.Execute(deleteStatement, new { management_company_id = item.ManagementCompanyId.ToString() });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
        
        public override void Update(ManagementCompany item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    var updateStatement = @"update management_company set name = @name, updated_at = @updated_at where management_company_id = @management_company_id";

                    cn.Execute(updateStatement,
                        new
                        {
                            name = item.Name,
                            management_company_id = item.ManagementCompanyId.ToString(),
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

        public override ManagementCompany Find(string id)
        {
            ManagementCompany managementCompany = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select * from management_company where management_company_id = @management_company_id";
                    dynamic item = cn.Query<dynamic>(findStatement, new { management_company_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.name))
                    {
                        ManagementCompanyId managementCompanyId = new ManagementCompanyId(id);
                        managementCompany = new ManagementCompany(managementCompanyId, item.name);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return managementCompany;
        }

        public IEnumerable<ManagementCompany> FindAll()
        {
            List<ManagementCompany> lstManagementCompany = new List<ManagementCompany>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select * from management_company order by name ";
                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var item in result)
                    {
                        ManagementCompanyId managementCompanyId = new ManagementCompanyId(item.management_company_id);
                        ManagementCompany managementCompany = new ManagementCompany(managementCompanyId, item.name);
                        lstManagementCompany.Add(managementCompany);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }

            return lstManagementCompany;
        }

        public void RemoveAll()
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    cn.Execute(@"delete from management_company");
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
