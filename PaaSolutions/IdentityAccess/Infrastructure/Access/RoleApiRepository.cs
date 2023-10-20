using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Repository;
using Newtonsoft.Json;
using System.Net.Http;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Application.Command.Access;

namespace IdentityAccess.Infrastructure.Access
{
    public class RoleApiRepository : ApiRepository<Role, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RoleApiRepository()
            : base()
        {
        }

        public override string Add(Role role)
        {
            string insert_id = "";
            try
            {
                string url = string.Format("api/roles");

                NewRoleCommand command = new NewRoleCommand(role.RoleName, role.Remark,
                    role.CreateBy, role.FeaturePermissions);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                insert_id = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not add an role with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return insert_id;
        }

        public override void Remove(Role role)
        {
            try
            {
                string url = string.Format("api/roles/{0}", role.RoleId.Id);

                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not remove role using api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Update(Role role)
        {
            try
            {
                string url = string.Format("api/roles");

                SaveRoleCommand command = new SaveRoleCommand(role.RoleId.Id, role.RoleName, role.Remark,
                    role.CreateBy, role.FeaturePermissions);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update an role with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override Role Find(string id)
        {
            Role role = null;
            try
            {
                string url = string.Format("api/roles/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    role = JsonConvert.DeserializeObject<Role>(jsonContent);
                }
            }
            catch (Exception ex)
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
                string url = string.Format("api/roles");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    lstRole = JsonConvert.DeserializeObject<List<Role>>(jsonContent);
                }
            }
            catch (Exception ex)
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
                string url = string.Format("api/roles/check?rolename={0}", roleName);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    try
                    { 
                        role = JsonConvert.DeserializeObject<Role>(jsonContent);
                    }
                    catch(Exception ex)
                    {
                        return role;
                    }                    
                }
            }
            catch (Exception ex)
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
                string url = string.Format("api/roles/featurepermission/");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        list = JsonConvert.DeserializeObject<List<FeaturePermission>>(jsonContent);
                        if (list != null && list.Count > 0)
                        {
                            foreach (FeaturePermission item in list)
                            {
                                item.IsAllowed = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return list;
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
