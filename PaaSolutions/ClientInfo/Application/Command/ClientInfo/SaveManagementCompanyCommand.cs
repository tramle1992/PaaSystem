using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ClientInfo
{
    public class SaveManagementCompanyCommand
    {
        public string ManagementCompanyId { get; set; }

        public string ManagementCompanyName { get; set; }

        public SaveManagementCompanyCommand(string id, string name)
        {
            this.ManagementCompanyId = id;
            this.ManagementCompanyName = name;
        }
    }
}
