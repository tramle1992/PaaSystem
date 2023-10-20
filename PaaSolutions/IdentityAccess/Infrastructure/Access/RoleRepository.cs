using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Repository;
using IdentityAccess.Domain.Model.Access;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Common.Infrastructure.Helper;

namespace IdentityAccess.Infrastructure.Access
{
    public class RoleRepository : Repository<Role, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RoleRepository()
        { }

        public override void Add(Role role)
        {
            try
            {
                role.FeaturePermissions.Clear();
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert role(role_id, role_name, remark, create_by)" +
                        " values (@role_id, @role_name, @remark, @create_by)";
                    var args = new DynamicParameters();
                    args.Add("role_id", role.RoleId.Id);
                    args.Add("role_name", role.RoleName);
                    args.Add("remark", role.Remark);
                    args.Add("create_by", role.CreateBy);

                    cn.Execute(insertStatement, args);

                    string findFeaturePermission = @"select feature_id, feature_name, parent_feature_id from feature_permission ";

                    string insertRolePermissionStatement = @"insert role_feature_permission(role_id, feature_id, is_allowed)" +
                        " values(@role_id, @feature_id, @is_allowed)";

                    IEnumerable<dynamic> features = cn.Query<dynamic>(findFeaturePermission);
                    foreach (var item in features)
                    {
                        if (item != null)
                        {
                            FeaturePermission feature = new FeaturePermission(item.feature_id, item.feature_name, item.parent_feature_id);
                            args = new DynamicParameters();
                            args.Add("role_id", role.RoleId.Id);
                            args.Add("feature_id", feature.FeatureId);
                            args.Add("is_allowed", feature.IsAllowed);
                            cn.Execute(insertRolePermissionStatement, args);
                            role.FeaturePermissions.Add(feature);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }
        public override void Remove(Role role)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from role_feature_permission where role_id = @role_id";

                    cn.Execute(deleteStatement, new { role_id = role.RoleId.Id });

                    deleteStatement = @"delete from role where role_id = @role_id";

                    cn.Execute(deleteStatement, new { role_id = role.RoleId.Id });
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

                    string selectUser = @"select * from [user] where role_id = @role_id";

                    var args = new DynamicParameters();
                    args.Add("role_id", id);

                    IEnumerable<dynamic> features = cn.Query<dynamic>(selectUser, args);

                    if (features.Count() == 0)
                    {
                        string deleteStatement = @"delete from role_feature_permission where role_id = @role_id";

                        cn.Execute(deleteStatement, new { role_id = id });

                        deleteStatement = @"delete from role where role_id = @role_id";

                        cn.Execute(deleteStatement, new { role_id = id });                       
                    }
                    else
                    {
                        throw new Exception("Role is referenced to user");
                    }            
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void RemoveAll()
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from role_feature_permission";

                    cn.Execute(deleteStatement);

                    deleteStatement = @"delete from role ";

                    cn.Execute(deleteStatement);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(Role role)
        {
            try
            {

                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from role_feature_permission where role_id = @role_id";

                    cn.Execute(deleteStatement, new { role_id = role.RoleId.Id });

                    string updateStatement = @"update role set role_name=@role_name" +
                        ", remark=@remark, create_by=@create_by where role_id=@role_id";

                    var args = new DynamicParameters();
                    args.Add("role_id", role.RoleId.Id);
                    args.Add("role_name", role.RoleName);
                    args.Add("remark", role.Remark);
                    args.Add("create_by", role.CreateBy);

                    cn.Execute(updateStatement, args);

                    string insertRolePermissionStatement = @"insert role_feature_permission(role_id, feature_id, is_allowed)" +
                        " values(@role_id, @feature_id, @is_allowed)";
                    foreach(FeaturePermission feature in role.FeaturePermissions)
                    {
                        args = new DynamicParameters();
                        args.Add("role_id", role.RoleId.Id);
                        args.Add("feature_id", feature.FeatureId);
                        args.Add("is_allowed", feature.IsAllowed);
                        cn.Execute(insertRolePermissionStatement, args);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }
        public override Role Find(string id)
        {
            Role role = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select role_id, role_name, remark, create_by " +
                        " from role where role_id=@role_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { role_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.role_id))
                    {
                        RoleId roleId = new RoleId(id);
                        role = new Role(roleId);
                        role.RoleName = item.role_name;
                        role.Remark = item.remark;
                        role.CreateBy = item.create_by;
                    }
                    else
                    {
                        return role;
                    }

                    string findFeatureStatement = @"select fp.feature_id, fp.feature_name, fp.parent_feature_id, rfp.is_allowed " +
                        " from feature_permission as fp inner join role_feature_permission as rfp on fp.feature_id = rfp.feature_id" +
                        " where rfp.role_id=@role_id";
                    IEnumerable<dynamic> features = cn.Query<dynamic>(findFeatureStatement, new { role_id = role.RoleId.Id });
                    foreach (var featureItem in features)
                    {
                        FeaturePermission feature = new FeaturePermission(featureItem.feature_id, featureItem.feature_name, featureItem.parent_feature_id, featureItem.is_allowed);
                        role.FeaturePermissions.Add(feature);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return role;
        }

        public List<Role> FindAll()
        {
            List<Role> lstRole = new List<Role>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select role_id, role_name, remark, create_by from role order by role_name ";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var item in result)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.role_id))
                        {
                            RoleId roleId = new RoleId(item.role_id);
                            Role role = new Role(roleId);
                            role.RoleName = item.role_name;
                            role.Remark = item.remark;
                            role.CreateBy = item.create_by;

                            string findFeatureStatement = @"select fp.feature_id, fp.feature_name, fp.parent_feature_id, rfp.is_allowed " +
                                " from feature_permission fp inner join role_feature_permission rfp on fp.feature_id = rfp.feature_id " +
                                " where rfp.role_id=@role_id";
                            IEnumerable<dynamic> features = cn.Query<dynamic>(findFeatureStatement, new { role_id = role.RoleId.Id });
                            foreach (var featureItem in features)
                            {
                                FeaturePermission feature = new FeaturePermission(featureItem.feature_id, featureItem.feature_name, featureItem.parent_feature_id, featureItem.is_allowed);
                                role.FeaturePermissions.Add(feature);
                            }
                            lstRole.Add(role);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return lstRole;
        }

        public Role FindByName(string roleName)
        {
            Role role = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select role_id, role_name, remark, create_by " +
                        " from role where role_name=@role_name";

                    dynamic item = cn.Query<dynamic>(findStatement, new { role_name = roleName }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.role_id))
                    {
                        RoleId roleId = new RoleId(item.role_id);
                        role = new Role(roleId);
                        role.RoleName = item.role_name;
                        role.Remark = item.remark;
                        role.CreateBy = item.create_by;
                    }
                    else
                    {
                        return role;
                    }

                    string findFeatureStatement = @"select fp.feature_id, fp.feature_name, fp.parent_feature_id, rfp.is_allowed " +
                        " from feature_permission as fp inner join role_feature_permission as rfp on fp.feature_id = rfp.feature_id" +
                        " where rfp.role_id=@role_id";
                    IEnumerable<dynamic> features = cn.Query<dynamic>(findFeatureStatement, new { role_id = role.RoleId.Id });
                    foreach (var featureItem in features)
                    {
                        FeaturePermission feature = new FeaturePermission(featureItem.feature_id, featureItem.feature_name, featureItem.parent_feature_id, featureItem.is_allowed);
                        role.FeaturePermissions.Add(feature);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return role;
        }

        public List<FeaturePermission> ListFeaturePermission()
        {
            List<FeaturePermission> list = new List<FeaturePermission>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select fp.feature_id, fp.feature_name, fp.parent_feature_id " +
                        " from feature_permission as fp";

                    IEnumerable<dynamic> features = cn.Query<dynamic>(findStatement);
                    foreach (var item in features)
                    {
                        FeaturePermission feature = new FeaturePermission();
                        feature.FeatureId = item.feature_id;
                        feature.FeatureName = item.feature_name;
                        feature.ParentFeatureId = item.parent_feature_id;
                        feature.IsAllowed = false;

                        list.Add(feature);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return list;
        }
    }
}
