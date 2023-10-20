using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using Common.Infrastructure.Encryption;
using IdentityAccess.CommonType;
using IdentityAccess.Domain.Model.Access;

namespace IdentityAccess.Domain.Model.Identity
{
    public class User : EntityWithCompositeId, IAggregateRoot
    {
        public User()
        {
        }
        
        public UserId UserId { get; set; }

        public string RoleId { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string Address { get; set; }

        public string EmailAddress { get; set; }

        public string Other { get; set; }

        public DateTime? HiredDate { get; set; }

        public DateTime? LastLogIn { get; set; }

        public DateTime? LastLogOut { get; set; }

        public DateTime? TerminationDate { get; set; }

        public UserStatus Status { get; set; }

        public byte[] Avatar { get; set; }

        public void ChangePassword(string currentPassword, string changedPassword)
        {
            AssertionConcern.AssertArgumentNotEmpty(
                    currentPassword,
                    "Current and new password must be provided.");

            AssertionConcern.AssertArgumentEquals(
                    this.Password,
                    this.AsEncryptedValue(currentPassword),
                    "Current password not confirmed.");

            AssertionConcern.AssertArgumentNotEquals(currentPassword, changedPassword, "The password is unchanged.");

            this.Password = AsEncryptedValue(changedPassword);

        }

        public void ChangeEmailAddress(string email)
        {
            this.EmailAddress = email;
        }

        public string AsEncryptedValue(string plainTextPassword)
        {
            return new MD5EncryptionService().EncryptedValue(plainTextPassword);
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.UserId;
            yield return this.UserName;
        }

        public override string ToString()
        {
            return "User[userId=" + this.UserId
                + ", userName=" + this.UserName + "]";
        }

        public User(UserId userId, string username, string password, string address, string email, UserStatus status, string roleId, DateTime? hiredDate, DateTime? termDate, DateTime? lastLogin, DateTime? lastLogout, string other)
        {
            this.UserId = userId;
            this.UserName = username;
            this.Password = password;
            this.Address = address;
            this.EmailAddress = email;
            this.Status = status;
            this.RoleId = roleId;
            this.HiredDate = hiredDate;
            this.TerminationDate = termDate;
            this.LastLogIn = lastLogin;
            this.LastLogOut = lastLogout;
            this.Other = other;
        }
    }
}
