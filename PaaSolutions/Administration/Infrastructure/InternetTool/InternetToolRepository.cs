using Administration.Domain.Model.InternetTool;
using Common.Infrastructure.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Infrastructure.InternetTool
{
    public class InternetToolRepository : Repository<InternetItem, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public InternetToolRepository()
        {
        }

        public override void Add(InternetItem item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert internet_tool(id, caption, target, image, [order]) " +
                        "values (@id, @caption, @target, @image, @order)";

                    var args = new DynamicParameters();
                    args.Add("id", item.InternetItemId.Id);
                    args.Add("caption", item.Caption);
                    args.Add("target", item.Target);
                    args.Add("image", item.Image);
                    args.Add("order", item.Order);

                    cn.Execute(insertStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        public override void Remove(InternetItem item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from internet_tool where id = @id";

                    cn.Execute(deleteStatement, new { id = item.InternetItemId.Id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void Remove(string id)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from internet_tool where id = @id";

                    cn.Execute(deleteStatement, new { id = id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(InternetItem item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update internet_tool set caption = @caption, target = @target" +
                        ", image = @image, [order] = @order where id = @id";

                    var args = new DynamicParameters();
                    args.Add("id", item.InternetItemId.Id);
                    args.Add("caption", item.Caption);
                    args.Add("target", item.Target);
                    args.Add("image", item.Image);
                    args.Add("order", item.Order);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        public override InternetItem Find(string id)
        {
            InternetItem item = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select id, caption, target, image, [order] " +
                        "from internet_tool where id = @id";

                    dynamic value = cn.Query<dynamic>(findStatement, new { id = id }).FirstOrDefault();
                    if (value != null && !string.IsNullOrEmpty(value.id))
                    {
                        item = new InternetItem();
                        InternetItemId internetItemId = new InternetItemId(value.id);
                        item.InternetItemId = internetItemId;
                        item.Caption = value.caption;
                        item.Target = value.target;
                        item.Image = value.image;
                        item.Order = value.order;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return item;
        }

        public IList<InternetItem> FindAll()
        {
            List<InternetItem> items = new List<InternetItem>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select id, caption, target, image, [order] " +
                        "from internet_tool order by [order] asc";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var value in result)
                    {
                        if (value != null && !string.IsNullOrEmpty(value.id))
                        {
                            InternetItem item = new InternetItem();
                            InternetItemId internetItemId = new InternetItemId(value.id);
                            item.InternetItemId = internetItemId;
                            item.Caption = value.caption;
                            item.Target = value.target;
                            item.Image = value.image;
                            item.Order = value.order;
                            items.Add(item);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return items;
        }

        public int FindMaxOrder()
        {
            int maxOrder = 0;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select MAX([order]) as maxorder from internet_tool";

                    dynamic value = cn.Query<dynamic>(findStatement).FirstOrDefault();
                    if (value != null)
                    {
                        maxOrder = value.maxorder;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return maxOrder;
        }

        public int GetItemCount()
        {
            int itemCount = 0;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select COUNT(*) as itemcount from internet_tool";

                    dynamic value = cn.Query<dynamic>(findStatement).FirstOrDefault();
                    if (value != null)
                    {
                        itemCount = value.itemcount;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return itemCount;
        }
    }
}
