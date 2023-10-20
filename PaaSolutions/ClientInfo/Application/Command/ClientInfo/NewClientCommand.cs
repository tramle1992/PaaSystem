using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Data.ClientInfo;

namespace Core.Application.Command.ClientInfo
{
    public class NewClientCommand    
    {
        public ClientData ClientData { get; set; }

        public NewClientCommand(ClientData data)
        {            
            this.ClientData = data;
        }
    }
}
