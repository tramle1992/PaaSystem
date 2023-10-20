using Administration.Domain.Model.StandardTemplate;
using Common.Infrastructure.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Infrastructure.StandardTemplate
{
    public class StandardTemplateRepository : Repository<TemplateItem, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public StandardTemplateRepository()
        {
        }

        public override void Add(TemplateItem item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert standard_template(id, parent_id, name, caption, [index]) " +
                        "values (@id, @parent_id, @name, @caption, @index)";

                    var args = new DynamicParameters();
                    args.Add("id", item.TemplateItemId.Id);
                    args.Add("parent_id", item.ParentId.Id);
                    args.Add("name", item.Name);
                    args.Add("caption", item.Caption);
                    args.Add("index", item.Index);

                    cn.Execute(insertStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        public override void Remove(TemplateItem item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from standard_template where id = @id";

                    cn.Execute(deleteStatement, new { id = item.TemplateItemId.Id });
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

                    string deleteStatement = @"delete from standard_template where id = @id";

                    cn.Execute(deleteStatement, new { id = id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(TemplateItem item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update standard_template set parent_id = @parent_id, name = @name" +
                        ", caption = @caption, [index] = @index where id = @id";

                    var args = new DynamicParameters();
                    args.Add("id", item.TemplateItemId.Id);
                    args.Add("parent_id", item.ParentId.Id);
                    args.Add("name", item.Name);
                    args.Add("caption", item.Caption);
                    args.Add("index", item.Index);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        public override TemplateItem Find(string id)
        {
            TemplateItem item = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select id, parent_id, name, caption, [index] " +
                        "from standard_template where id = @id";

                    dynamic value = cn.Query<dynamic>(findStatement, new { id = id }).FirstOrDefault();
                    if (value != null && !string.IsNullOrEmpty(value.id))
                    {
                        item = new TemplateItem();
                        TemplateItemId templateItemId = new TemplateItemId(value.id);
                        item.TemplateItemId = templateItemId;
                        TemplateItemId parentId = new TemplateItemId(value.parent_id);
                        item.ParentId = parentId;
                        item.Name = value.name;
                        item.Caption = value.caption;
                        item.Index = value.index;
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

        public List<TemplateItem> FindChildren(string rootId)
        {
            List<TemplateItem> listResult = new List<TemplateItem>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    TemplateItem root = Find(rootId);

                    if (root != null)
                    {
                        listResult.Add(root);

                        cn.Open();

                        string findStatement = @"select id, parent_id, [name], caption, [index] " +
                            "from standard_template where parent_id = @parent_id order by [index], [name]";
                     
                        IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, new { parent_id = rootId });
                        foreach (var value in result)
                        {
                            if (value != null && !string.IsNullOrEmpty(value.id))
                            {
                                TemplateItem item = new TemplateItem();
                                TemplateItemId templateItemId = new TemplateItemId(value.id);
                                item.TemplateItemId = templateItemId;
                                TemplateItemId parentId = new TemplateItemId(value.parent_id);
                                item.ParentId = parentId;
                                item.Name = value.name;
                                item.Caption = value.caption;
                                item.Index = value.index;
                                listResult.Add(item);
                            }
                        }
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return listResult;
        }

        public IList<TemplateItem> FindAll()
        {
            List<TemplateItem> items = new List<TemplateItem>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select id, parent_id, name, caption, [index] " +
                        "from standard_template order by parent_id asc, [index] asc";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var value in result)
                    {
                        if (value != null && !string.IsNullOrEmpty(value.id))
                        {
                            TemplateItem item = new TemplateItem();
                            TemplateItemId templateItemId = new TemplateItemId(value.id);
                            item.TemplateItemId = templateItemId;
                            TemplateItemId parentId = new TemplateItemId(value.parent_id);
                            item.ParentId = parentId;
                            item.Name = value.name;
                            item.Caption = value.caption;
                            item.Index = value.index;
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

        public TemplateItem FindByParentAndName(string parentId, string name)
        {
            TemplateItem item = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select id, parent_id, name, caption, [index] from standard_template " +
                        "where parent_id = @parent_id and name = @name";

                    var args = new DynamicParameters();
                    args.Add("parent_id", parentId);
                    args.Add("name", name);

                    dynamic value = cn.Query<dynamic>(findStatement, args).FirstOrDefault();
                    if (value != null && !string.IsNullOrEmpty(value.id))
                    {
                        item = new TemplateItem();
                        item.TemplateItemId = new TemplateItemId(value.id);
                        item.ParentId = new TemplateItemId(value.parent_id);
                        item.Name = value.name;
                        item.Caption = value.caption;
                        item.Index = value.index;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return item;
        }
    }
}
