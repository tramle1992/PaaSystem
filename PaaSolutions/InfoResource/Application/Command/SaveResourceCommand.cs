using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoResource.Application.Data;

namespace InfoResource.Application.Command
{
    public class SaveResourceCommand
    {
        public string ResourceId { get; set; }

        public ResourceData ResourceData { get; set; }

        public SaveResourceCommand(string id, ResourceData data)
        {
            this.ResourceId = id;
            this.ResourceData = data;
        }
    }
}
