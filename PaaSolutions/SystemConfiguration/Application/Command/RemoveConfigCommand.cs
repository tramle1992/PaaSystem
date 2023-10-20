using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemConfiguration.Application.Command
{
    public class RemoveConfigCommand
    {
        public string ConfigId { get; set; }

        public RemoveConfigCommand(string configId)
        {
            this.ConfigId = configId;
        }
    }
}
