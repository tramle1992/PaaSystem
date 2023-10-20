using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemConfiguration.Application.Data;

namespace SystemConfiguration.Application.Command
{
    public class SaveConfigCommand
    {
        public ConfigData ConfigData { get; set; }

        public SaveConfigCommand(ConfigData data)
        {
            this.ConfigData = data;
        }
    }
}
