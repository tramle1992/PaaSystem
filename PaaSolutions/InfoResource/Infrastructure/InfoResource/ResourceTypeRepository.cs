using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Infrastructure.Repository;
using InfoResource.Domain.Model.InfoResource;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace InfoResource.Infrastructure.InfoResource
{
    public class ResourceTypeRepository : Repository<ResourceType, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ResourceTypeRepository()
        {
        }

        public override void Add(ResourceType item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    var insertStatement = @"insert resource_type(resource_type_id, name, created_at, updated_at) " +
                        "values (@resource_type_id, @name, @created_at, @updated_at)";

                    cn.Execute(insertStatement,
                        new
                        {
                            resource_type_id = item.ResourceTypeId.ToString(),
                            name = item.Name,
                            created_at = DateTime.Now,
                            updated_at = DateTime.Now
                        });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }

        }
        public override void Remove(ResourceType item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    var deleteStatement = @"delete from resource_type where resource_type_id = @resource_type_id";

                    int resouceCountByResourceType = cn.ExecuteScalar<int>("select count(*) from resource where resource_type_id=@resource_type_id", new { resource_type_id = item.ResourceTypeId.ToString() });
                    if (resouceCountByResourceType > 0)
                        throw new InvalidOperationException("Cannot remove resource type because it associated with other resouces.");

                    cn.Execute(deleteStatement,
                        new { resource_type_id = item.ResourceTypeId.ToString() });

                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(ResourceType item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    var updateStatement = @"update resource_type set name = @name, updated_at = @updated_at where resource_type_id = @resource_type_id";

                    cn.Execute(updateStatement,
                        new
                        {
                            name = item.Name,
                            resource_type_id = item.ResourceTypeId.ToString()
                        });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override ResourceType Find(string id)
        {
            ResourceType item = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    dynamic resourceType = cn.Query<dynamic>(@"select * from resource_type where resource_type_id = @resource_type_id",
                        new { resource_type_id = id }).FirstOrDefault();

                    if (resourceType != null)
                    {
                        ResourceTypeId resourceTypeId = new ResourceTypeId(resourceType.resource_type_id);
                        item = new ResourceType(resourceTypeId, resourceType.name);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return item;
        }

        public IEnumerable<ResourceType> FindAll()
        {
            List<ResourceType> lst = new List<ResourceType>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    IEnumerable<dynamic> result = cn.Query<dynamic>(@"select * from resource_type");
                    foreach (var item in result)
                    {
                        ResourceTypeId resourceTypeId = new ResourceTypeId(item.resource_type_id);
                        ResourceType resourceType = new ResourceType(resourceTypeId, item.name);
                        lst.Add(resourceType);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }

            return lst;
        }

        public void RemoveAll()
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    var deleteStatement = @"delete from resource_type";

                    cn.Execute(deleteStatement);
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
