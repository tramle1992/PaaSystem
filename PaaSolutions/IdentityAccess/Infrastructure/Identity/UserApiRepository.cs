using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.CommonType;
using IdentityAccess.Domain.Model.Access;
using Common.Infrastructure.Repository;
using Newtonsoft.Json;
using System.Net.Http;
using IdentityAccess.Application.Command.Identity;

namespace IdentityAccess.Infrastructure.Identity
{
    public class UserApiRepository : ApiRepository<User, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserApiRepository()
            : base()
        {
        }

        public override string Add(User user)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/users");

                NewUserCommand command = new NewUserCommand(user.RoleId, user.UserName,
                    user.Password, user.Address, user.EmailAddress, user.Other, (int)user.Status, user.HiredDate, user.TerminationDate, user.Avatar);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                newId = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not add an user with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return newId;
        }

        public override void Remove(User user)
        {
            try
            {
                string url = string.Format("api/users/{0}", user.UserId.Id);

                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not remove user using api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Update(User user)
        {
            try
            {
                string url = string.Format("api/users");

                SaveUserCommand command = new SaveUserCommand(user.UserId.Id, user.RoleId, user.UserName,
                    user.Password, user.Address, user.EmailAddress, user.Other,
                    user.HiredDate, user.LastLogIn, user.LastLogOut, user.TerminationDate, (int)user.Status, user.Avatar);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update an user with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override User Find(string id)
        {
            User user = null;
            try
            {
                string url = string.Format("api/users/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return user;
        }

        public List<User> FindAll()
        {
            List<User> lstUser = new List<User>();
            try
            {
                string url = string.Format("api/users");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    lstUser = JsonConvert.DeserializeObject<List<User>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return lstUser;
        }


        public User Login(string username, string password)
        {
            try
            {
                User user = new User();
                string url = string.Format("api/auth");

                LoginCommand command = new LoginCommand();
                command.UserName = username;
                command.Password = password;

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                    throw new Exception("Could not add an role with api: " + url);
                }
                else
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(jsonContent);
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public User Check(string username)
        {
            User user = new User();
            try
            {
                string url = string.Format("api/users/check/?username={0}", username);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        user = JsonConvert.DeserializeObject<User>(jsonContent);
                    }
                    catch (Exception ex)
                    {
                        user = null;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return user;
        }

        public List<User> GetActiveUsers()
        {
            List<User> lstUser = new List<User>();
            try
            {
                string url = string.Format("api/users/active");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    lstUser = JsonConvert.DeserializeObject<List<User>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return lstUser;
        }
    }
}
