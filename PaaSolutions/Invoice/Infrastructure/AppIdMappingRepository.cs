using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Common.Infrastructure.Repository;

namespace Invoice.Infrastructure
{
    public class AppIdMappingRepository : Repository<Invoice.Domain.Model.AppIdMapping, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void CreateTable()
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string statement = @"CREATE TABLE appid_mapping(" +
                        "old_appid varchar(36) NOT NULL PRIMARY KEY," +
                        "new_appid varchar(36) NOT NULL)";

                    cn.Execute(statement);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void DropTable()
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string statement = @"DROP TABLE appid_mapping";

                    cn.Execute(statement);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public string GetNewAppIdByOldAppId(string oldAppId)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string statement = @"select new_appid from appid_mapping where old_appid=@old_appid";

                    var args = new DynamicParameters();
                    args.Add("old_appid", oldAppId);

                    dynamic item = cn.Query<dynamic>(statement, args).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.new_appid))
                    {
                        return item.new_appid;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return string.Empty;
        }

        public List<Domain.Model.AppIdMapping> GetAll()
        {
            List<Domain.Model.AppIdMapping> items = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select old_appid, new_appid from appid_mapping";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    if (result != null)
                    {
                        items = new List<Domain.Model.AppIdMapping>();
                        foreach (var item in result)
                        {
                            if (item != null)
                            {
                                string oldAppId = item.old_appid;
                                string newAppId = item.new_appid;
                                items.Add(new Domain.Model.AppIdMapping(oldAppId, newAppId));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return items;
        }

        public override void Add(Domain.Model.AppIdMapping item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string statement = @"insert appid_mapping(old_appid, new_appid)" +
                        " values (@old_appid, @new_appid)";

                    var args = new DynamicParameters();
                    args.Add("old_appid", item.OldAppId);
                    args.Add("new_appid", item.NewAppId);

                    cn.Execute(statement, args);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override void Remove(Domain.Model.AppIdMapping item)
        {
        }

        public override void Update(Domain.Model.AppIdMapping item)
        {
        }

        public override Domain.Model.AppIdMapping Find(string id)
        {
            return null;
        }
    }
}
