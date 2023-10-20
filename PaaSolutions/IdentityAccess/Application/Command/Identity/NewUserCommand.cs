using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Application.Command.Identity
{
    public class NewUserCommand
    {
        public string RoleId { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public string EmailAddress { get; set; }

        public string Other { get; set; }

        public int Status { get; set; }

        public DateTime? HiredDate { get; set; }

        public DateTime? TerminationDate { get; set; }

        public byte[] Avatar { get; set; }

        public NewUserCommand(string roleId, string username,
            string password, string address, string emailAddress, string other, int status, DateTime? hiredDate, DateTime? termDate, byte[] avatar)
        {
            this.RoleId = roleId;
            this.UserName = username;
            this.Password = password;
            this.Address = address;
            this.EmailAddress = emailAddress;
            this.Other = other;
            this.Status = status;
            this.TerminationDate = termDate;
            this.HiredDate = hiredDate;
            this.Avatar = avatar;
        }
    }
}
