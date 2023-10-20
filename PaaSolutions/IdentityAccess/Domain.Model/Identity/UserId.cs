using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Domain.Model.Identity
{
    public class UserId : Common.Domain.Model.Identity
    {
        public UserId() { }

        public UserId(string id)
            : base(id)
        {

        }
    }
}
