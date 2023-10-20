using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoResource.Domain.Model.InfoResource;
using Common.Infrastructure.Repository;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using InfoResource.Application.Data;

namespace InfoResource.Infrastructure.InfoResource
{
    public class InfoResourceRepository : Repository<Resource, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public InfoResourceRepository()
        {
        }

        public override void Add(Resource item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    var insertStatement = @"insert resource(resource_id, resource_type_id, name, target, comment, phone, email, created_at, updated_at) " +
                        "values (@resource_id, @resource_type_id, @name, @target, @comment, @phone, @email, @created_at, @updated_at)";

                    cn.Execute(insertStatement,
                        new
                        {
                            resource_id = item.ResourceId.ToString(),
                            resource_type_id = item.ResourceType.ResourceTypeId.ToString(),
                            name = item.Name,
                            target = item.Target,
                            comment = item.Comment,
                            phone = item.Phone,
                            email = item.Email,
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

        public override void Remove(Resource item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    var deleteStatement = @"delete from resource where resource_id = @resource_id";

                    cn.Execute(deleteStatement, new { resource_id = item.ResourceId.ToString() });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(Resource item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    var updateStatement = @"update resource set name = @name, target = @target, " +
                        "comment = @comment, phone=@phone, email=@email, updated_at = @updated_at where resource_id = @resource_id";

                    cn.Execute(updateStatement, new
                    {
                        name = item.Name,
                        target = item.Target,
                        comment = item.Comment,
                        phone = item.Phone,
                        email = item.Email,
                        updated_at = DateTime.UtcNow,
                        resource_id = item.ResourceId.ToString()
                    });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override Resource Find(string id)
        {
            Resource resource = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string sql = "select [resource].*, resource_type.name as resource_type_name from resource inner " +
                                 "join resource_type on resource.resource_type_id = resource_type.resource_type_id " +
                                 "where resource.resource_id = @resource_id";

                    dynamic item = cn.Query<dynamic>(sql,
                        new { resource_id = id }).FirstOrDefault();

                    if (item != null)
                    {
                        ResourceTypeId resourceTypeId = new ResourceTypeId(item.resource_type_id);
                        ResourceId resourceId = new ResourceId(item.resource_id);
                        ResourceType resourceType = new ResourceType(resourceTypeId, item.resource_type_name);
                        resource = new Resource(resourceId, item.name, item.target, item.comment, item.phone, item.email, resourceType);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }

            return resource;
        }

        public IEnumerable<Resource> FindAll()
        {
            List<Resource> lst = new List<Resource>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    var sql = "select [resource].*, resource_type.name as resource_type_name " +
                        "FROM resource inner join resource_type on resource.resource_type_id = resource_type.resource_type_id";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(sql);

                    foreach (var item in result)
                    {
                        ResourceTypeId resourceTypeId = new ResourceTypeId(item.resource_type_id);
                        ResourceId resourceId = new ResourceId(item.resource_id);
                        ResourceType resourceType = new ResourceType(resourceTypeId, item.resource_type_name);
                        Resource resource = new Resource(resourceId, item.name, item.target, item.comment, item.phone, item.email, resourceType);
                        lst.Add(resource);
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

                    var deleteStatement = @"delete from resource";

                    cn.Execute(deleteStatement);
                }

            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void Remove(string resourceId)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    var deleteStatement = @"delete from resource where resource_id = @resource_id";

                    cn.Execute(deleteStatement, new
                    {
                        resource_id = resourceId
                    });
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
