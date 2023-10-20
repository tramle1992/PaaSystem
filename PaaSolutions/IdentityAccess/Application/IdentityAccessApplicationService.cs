using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityAccess.Infrastructure.Identity;
using IdentityAccess.Infrastructure.Access;
using IdentityAccess.Application.Command.Identity;
using IdentityAccess.Application.Command.Access;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.CommonType;

namespace IdentityAccess.Application
{
    public class IdentityAccessApplicationService
    {
        readonly UserRepository userRepository;
        readonly RoleRepository roleRepository;

        public IdentityAccessApplicationService()
        {
            this.userRepository = new UserRepository();
            this.roleRepository = new RoleRepository();
        }

        public string NewUser(NewUserCommand command)
        {
            User user = new User();
            UserId userId = new UserId(Guid.NewGuid().ToString());
            user.UserId = userId;

            user.Address = command.Address;
            user.EmailAddress = command.EmailAddress;
            user.Other = command.Other;
            user.Password = command.Password;
            user.RoleId = command.RoleId;
            user.Status = (UserStatus)command.Status;
            user.UserName = command.UserName;
            user.HiredDate = command.HiredDate;
            user.TerminationDate = command.TerminationDate;
            user.Avatar = command.Avatar;

            userRepository.Add(user);
            return user.UserId.Id;
        }

        public void SaveUser(SaveUserCommand command)
        {
            User user = new User();

            user = userRepository.Find(command.UserId);
            user.UserName = command.UserName;
            user.Password = command.Password;
            user.RoleId = command.RoleId;
            user.Address = command.Address;
            user.EmailAddress = command.EmailAddress;
            user.Other = command.Other;
            user.HiredDate = command.HiredDate;
            user.LastLogIn = command.LastLogIn;
            user.LastLogOut = command.LastLogOut;
            user.TerminationDate = command.TerminationDate;
            user.Status = (UserStatus)command.Status;
            user.Avatar = command.Avatar;

            userRepository.Update(user);
        }

        public void DeleteUser(string id)
        {
            userRepository.Remove(id);
        }

        public string NewRole(NewRoleCommand command)
        {
            RoleId roleId = new RoleId(Guid.NewGuid().ToString());
            Role role = new Role(roleId);
            role.RoleName = command.RoleName;
            role.Remark = command.Remark;
            role.CreateBy = command.CreateBy;
            role.FeaturePermissions = command.FeaturePermissions;
            roleRepository.Add(role);
            return role.RoleId.Id;
        }

        public void SaveRole(SaveRoleCommand command)
        {
            RoleId roleId = new RoleId(command.RoleId);
            Role role = new Role(roleId);
            role.RoleName = command.RoleName;
            role.Remark = command.Remark;
            role.CreateBy = command.CreateBy;
            role.FeaturePermissions = command.FeaturePermissions;
            roleRepository.Update(role);
        }

        public void DeleteRole(string id)
        {
            roleRepository.Remove(id);
        }

        public User VerifyLoginInfo(string username, string password)        
        {
            User user = new User();
            
            user = userRepository.UserFromAuthenticCredentials(username, user.AsEncryptedValue(password));
            
            return user;            
        }

    }
}
