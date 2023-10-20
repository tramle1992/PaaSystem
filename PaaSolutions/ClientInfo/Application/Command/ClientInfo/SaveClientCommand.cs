using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Data.ClientInfo;

namespace Core.Application.Command.ClientInfo
{
    public class SaveClientCommand
    {
        public string ClientId { get; set; }

        public ClientData ClientData { get; set; }

        public SaveClientCommand(string id, ClientData data)
        {
            this.ClientId = id;
            this.ClientData = data;
        }
    }
}
