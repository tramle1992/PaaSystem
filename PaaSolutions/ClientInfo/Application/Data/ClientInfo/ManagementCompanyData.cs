using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Application.Data.ClientInfo
{
    public class ManagementCompanyData
    {
        public string ManagementCompanyId { get; set; }

        public string Name { get; set; }

        public ManagementCompanyData(string managementCompanyId, string name) {

            this.ManagementCompanyId = managementCompanyId;
            this.Name = name;
        }

        public ManagementCompanyData() { }
    }
}
