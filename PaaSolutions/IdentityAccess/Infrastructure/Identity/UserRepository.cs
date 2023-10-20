using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Common.Infrastructure.Helper;
using Common.Infrastructure.Repository;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.CommonType;
using IdentityAccess.Domain.Model.Access;

namespace IdentityAccess.Infrastructure.Identity
{
    public class UserRepository : Repository<User, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserRepository()
        { }

        public override void Add(User user)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert [user](user_id, role_id, password, username, address, email_address, other, status" +
                        ", hired_date, avatar) values (@user_id, @role_id, @password, @username, @address " + 
                        ", @email_address, @other, @status, @hired_date, @avatar)";

                    var args = new DynamicParameters();
                    args.Add("user_id", user.UserId.Id);
                    args.Add("role_id", user.RoleId);
                    args.Add("password", user.Password);
                    args.Add("username", user.UserName);
                    args.Add("address", user.Address);
                    args.Add("email_address", user.EmailAddress);
                    args.Add("other", user.Other);
                    args.Add("status", (int)user.Status);
                    args.Add("hired_date", user.HiredDate);
                    args.Add("avatar", user.Avatar);

                    cn.Execute(insertStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        public override void Remove(User user)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from [user] where user_id = @user_id";

                    cn.Execute(deleteStatement, new { user_id = user.UserId });
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

                    string deleteStatement = @"delete from [user] where user_id = @user_id";

                    cn.Execute(deleteStatement, new { user_id = id });
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

                    cn.Execute(@"delete from [user]");
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(User user)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update [user] set password=@password, role_id=@role_id" +
                        ", username=@username, address=@address, email_address=@email_address, other=@other" +
                        ", status=@status, last_login=@last_login, last_logout=@last_logout, term_date=@term_date" +
                        ", hired_date=@hired_date, avatar=@avatar where user_id=@user_id";

                    var args = new DynamicParameters();
                    args.Add("user_id", user.UserId.Id);
                    args.Add("role_id", user.RoleId);
                    args.Add("password", user.Password);
                    args.Add("username", user.UserName);
                    args.Add("address", user.Address);
                    args.Add("email_address", user.EmailAddress);
                    args.Add("other", user.Other);

                    int status = (int)user.Status;

                    args.Add("status", status);
                    args.Add("hired_date", user.HiredDate);
                    args.Add("last_login", user.LastLogIn);
                    args.Add("last_logout", user.LastLogOut);                    
                    args.Add("term_date", user.TerminationDate);
                    args.Add("avatar", user.Avatar);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        public override User Find(string id)
        {
            User user = new User();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select user_id, role_id, password, username, address, email_address, other" +
                        ", status, last_login, last_logout, term_date " +
                        ", hired_date, avatar from [user] where user_id=@user_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { user_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.user_id))
                    {
                        UserId userId = new UserId(id.ToString());
                        user.UserId = userId;
                        user.RoleId = item.role_id;
                        user.Password = item.password;
                        user.UserName = item.username;
                        user.EmailAddress = item.email_address;
                        user.Other = item.other;
                        user.Status = (UserStatus)item.status;
                        user.HiredDate = item.hired_date;
                        user.LastLogIn =  item.last_login;
                        user.LastLogOut =  item.last_logout;
                        user.TerminationDate =  item.term_date;
                        user.Avatar = item.avatar;
                        user.Address = item.address;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return user;
        }

        public User FindByUsername(string username)
        {
            User user = new User();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select user_id, role_id, password, username, address, email_address, other" +
                        ", status, last_login, last_logout, term_date " +
                        ", hired_date from [user] where username=@username";

                    dynamic item = cn.Query<dynamic>(findStatement, new { username = username }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.user_id))
                    {                        
                        UserId userId = new UserId(item.user_id.ToString());
                        user.UserId = userId;
                        user.RoleId = item.role_id;
                        user.Password = item.password;
                        user.UserName = item.username;
                        user.EmailAddress = item.email_address;
                        user.Other = item.other;
                        user.Status = (UserStatus)item.status;
                        user.HiredDate = item.hired_date;
                        user.LastLogIn = item.last_login;
                        user.LastLogOut = item.last_logout;
                        user.TerminationDate = item.term_date;
                    }
                }
            }
            catch (SqlException ex)
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
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select user_id, role_id, password, username, address, email_address, other" +
                        ", status, last_login, last_logout, term_date, avatar " +
                        ", hired_date from [user] order by username";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var item in result)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.user_id))
                        {
                            User user = new User();
                            UserId userId = new UserId(item.user_id);
                            user.UserId = userId;
                            user.RoleId = item.role_id;
                            user.Password = item.password;
                            user.Address = item.address;
                            user.UserName = item.username;
                            user.EmailAddress = item.email_address;
                            user.Other = item.other;
                            user.Status = (UserStatus)item.status;
                            user.HiredDate = item.hired_date;
                            user.LastLogIn = item.last_login;
                            user.LastLogOut = item.last_logout;
                            user.TerminationDate = item.term_date;
                            user.Avatar = item.avatar;                            
                            lstUser.Add(user);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return lstUser;
        }

        public User UserFromAuthenticCredentials(string username, string encryptedPassword)
        {
            User user = new User();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select user_id, role_id, password, username, address, email_address, other" +
                        ", status, last_login, last_logout, term_date, hired_date, avatar " +
                        " from [user] where username=@username and password=@password";

                    dynamic item = cn.Query<dynamic>(findStatement, new { username = username, password = encryptedPassword }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.user_id))
                    {
                        UserId userId = new UserId(item.user_id);
                        user.UserId = userId;
                        user.RoleId = item.role_id;
                        user.Password = item.password;
                        user.UserName = item.username;
                        user.EmailAddress = item.email_address;
                        user.Address = item.address;
                        user.Other = item.other;
                        user.Status = (UserStatus)item.status;
                        user.HiredDate = (item.hired_date == null) ? null : item.hired_date;
                        user.LastLogIn = (item.last_login == null) ? null : item.last_login;
                        user.LastLogOut = (item.last_logout == null) ? null : item.last_logout;
                        user.TerminationDate = (item.term_date == null) ? null : item.term_date;
                        user.Avatar = item.avatar;
                        return user;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return null;
        }

        public User UserWithUsername(string username)
        {
            User user = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select user_id, role_id, password, username, address, email_address, other" +
                        ", status, last_login, last_logout, term_date " +
                        ", hired_date from [user] where username=@username";

                    dynamic item = cn.Query<dynamic>(findStatement, new { username = username }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.user_id))
                    {
                        user.UserId = item.user_id;
                        user.RoleId = item.role_id;
                        user.Password = item.password;
                        user.UserName = item.username;
                        user.EmailAddress = item.email_address;
                        user.Other = item.other;
                        user.Status = (UserStatus)item.status;
                        user.HiredDate = (item.hired_date == null) ? DateTime.MinValue : item.hired_date;
                        user.LastLogIn = (item.last_login == null) ? DateTime.MinValue : item.last_login;
                        user.LastLogOut = (item.last_logout == null) ? DateTime.MinValue : item.last_logout;
                        user.TerminationDate = (item.term_date == null) ? DateTime.MinValue : item.term_date;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return user;
        }

        public List<User> FindActiveUsers()
        {
            List<User> lstUser = new List<User>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select user_id, role_id, password, username, address, email_address, other" +
                        ", status, last_login, last_logout, term_date, avatar " +
                        ", hired_date from [user] where status = '0' order by username";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var item in result)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.user_id))
                        {
                            User user = new User();
                            UserId userId = new UserId(item.user_id);
                            user.UserId = userId;
                            user.RoleId = item.role_id;
                            user.Password = item.password;
                            user.Address = item.address;
                            user.UserName = item.username;
                            user.EmailAddress = item.email_address;
                            user.Other = item.other;
                            user.Status = (UserStatus)item.status;
                            user.HiredDate = item.hired_date;
                            user.LastLogIn = item.last_login;
                            user.LastLogOut = item.last_logout;
                            user.TerminationDate = item.term_date;
                            user.Avatar = item.avatar;
                            lstUser.Add(user);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return lstUser;
        }
    }
}
