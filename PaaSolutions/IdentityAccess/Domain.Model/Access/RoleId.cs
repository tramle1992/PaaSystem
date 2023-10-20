using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Domain.Model.Access
{
    public class RoleId : Common.Domain.Model.Identity
    {
        public RoleId() { }

        public RoleId(string id)
            : base(id)
        {

        }
    }
}
