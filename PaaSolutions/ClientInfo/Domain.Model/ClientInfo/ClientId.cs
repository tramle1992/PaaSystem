using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Model.ClientInfo
{
    public class ClientId : Common.Domain.Model.Identity
    {
        public ClientId() { }

        public ClientId(string id) : base(id)
        {

        }
    }
}
