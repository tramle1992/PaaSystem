using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Application.Command.Identity
{
    public class LoginCommand
    {
        public string Password { get; set; }

        public string UserName { get; set; }
    }
}
