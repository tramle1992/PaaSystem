using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoResource.Application.Data;

namespace InfoResource.Application.Command
{
    public class SaveResourceTypeCommand
    {
        public string ResourceTypeId { get; set; }

        public string ResourceTypeName { get; set; }

        public SaveResourceTypeCommand(string id, string name)
        {
            this.ResourceTypeId = id;
            this.ResourceTypeName = name;
        }
    }
}
