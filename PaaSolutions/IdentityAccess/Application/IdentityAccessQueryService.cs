using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityAccess.Infrastructure.Identity;
using IdentityAccess.Infrastructure.Access;
using IdentityAccess.Application.Command.Identity;
//using IdentityAccess.Application.Command.Access;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Domain.Model.Access;

namespace IdentityAccess.Application
{
    public class IdentityAccessQueryService
    {
        readonly UserRepository userRepository;
        readonly RoleRepository roleRepository;

        public IdentityAccessQueryService()
        {
            this.userRepository = new UserRepository();
            this.roleRepository = new RoleRepository();
        }

        public IList<User> GetAllUser()
        {
            List<User> lstResult = new List<User>();
            IEnumerable<User> users = userRepository.FindAll();
            foreach (User user in users)
            {
                lstResult.Add(user);
            }
            return lstResult;
        }

        public User GetUser(string id)
        {
            User user = userRepository.Find(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = userRepository.FindByUsername(username);
            if (user.UserId == null)
            {
                return null;
            }
            return user;
        }

        public IList<Role> GetAllRole()
        {
            List<Role> lstResult = new List<Role>();
            IEnumerable<Role> roles = roleRepository.FindAll();
            foreach (Role role in roles)
            {
                lstResult.Add(role);
            }
            return lstResult;
        }

        public Role GetRole(string id)
        {
            Role role = roleRepository.Find(id);
            if (role == null)
            {
                return null;
            }
            return role;
        }

        public Role GetRoleByName(string roleName)
        {
            Role role = roleRepository.FindByName(roleName);
            if (role == null)
            {
                return null;
            }
            return role;
        }

        public List<FeaturePermission> GetFeaturePermissions()
        {
            List<FeaturePermission> list = roleRepository.ListFeaturePermission();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public IList<User> GetAllActiveUsers()
        {
            List<User> lstResult = new List<User>();
            IEnumerable<User> users = userRepository.FindActiveUsers();
            foreach (User user in users)
            {
                lstResult.Add(user);
            }
            return lstResult;
        }
    }
}
