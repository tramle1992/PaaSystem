using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Application.Command.Identity
{
    public class SaveUserCommand
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public string EmailAddress { get; set; }

        public string Other { get; set; }

        public DateTime? HiredDate { get; private set; }

        public DateTime? LastLogIn { get; private set; }

        public DateTime? LastLogOut { get; private set; }

        public DateTime? TerminationDate { get; set; }

        public byte[] Avatar { get; set; }


        public int Status { get; set; }

        public SaveUserCommand(string userId, string roleId, string username,
            string password, string address, string emailAddress, string other,
            DateTime? hiredDate, DateTime? lastLogin, DateTime? lastLogout, DateTime? termDate, int status, byte[]avatar)
        {
            this.UserId = userId;
            this.RoleId = roleId;
            this.UserName = username;
            this.Password = password;
            this.Address = address;
            this.EmailAddress = emailAddress;
            this.Other = other;
            this.TerminationDate = termDate;
            this.HiredDate = hiredDate;
            this.LastLogIn = lastLogin;
            this.LastLogOut = lastLogout;            
            this.Status = status;
            this.Avatar = avatar;
        }        
    }
}
