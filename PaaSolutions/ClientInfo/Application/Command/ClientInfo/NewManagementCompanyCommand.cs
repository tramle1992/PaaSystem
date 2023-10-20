using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ClientInfo
{
    public class NewManagementCompanyCommand
    {
        public string Name { get; set; }

        public NewManagementCompanyCommand(string name)
        {
            this.Name = name;
        }
    }
}
