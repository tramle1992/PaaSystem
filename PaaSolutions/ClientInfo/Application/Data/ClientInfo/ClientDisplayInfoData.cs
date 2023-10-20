using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ClientInfo
{
    public class ClientDisplayInfoData
    {
        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public ClientDisplayInfoData(string clientId, string clientName)
        {
            this.ClientId = clientId;
            this.ClientName = clientName;
        }
    }
}
