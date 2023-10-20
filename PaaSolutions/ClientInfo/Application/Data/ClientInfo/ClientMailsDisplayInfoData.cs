using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ClientInfo
{
    public class ClientMailsDisplayInfoData
    {
        public List<string> ClientMails { get; set; }

        public string ClientName { get; set; }

        public string ClientId { get; set; }

        //public string ClientContacts { get; set; }

        public ClientMailsDisplayInfoData(List<string> clientMails, string clientName, string clientId)
        {
            this.ClientMails = clientMails;
            this.ClientName = clientName;
            this.ClientId = clientId;
            //this.ClientContacts = contacts;
        }
    }
}


