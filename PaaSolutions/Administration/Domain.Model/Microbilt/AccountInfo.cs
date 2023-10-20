using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Domain.Model.Microbilt
{
    public class AccountInfo : EntityWithCompositeId, IAggregateRoot
    {
        private char p1;
        private char p2;
        private char p3;
        private char p4;

        public string AccountInfoId { get; set; }
        public string MemberId { get; set; }
        public string Password { get; set; }
        public string AccountInfoType { get; set; }
        public int CreditType { get; set; }

        public AccountInfo()
        {
        }

        public AccountInfo(string  id, string memberId, string password, string type, int creditType) : this()
        {
            this.AccountInfoId = id;
            this.MemberId = memberId;
            this.Password = password;
            this.AccountInfoType = type;
            this.CreditType = creditType;
        }

        public AccountInfo(char p1, char p2, char p3, char p4)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.AccountInfoId;
        }

        public override string ToString()
        {
            return "AccountInfo[accountInfoId=" + this.AccountInfoId + "]";
        }
    }
}
