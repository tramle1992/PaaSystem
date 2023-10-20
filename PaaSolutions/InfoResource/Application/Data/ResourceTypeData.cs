using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoResource.Application.Data
{
    public class ResourceTypeData
    {
        public string ResourceTypeId { get; set; }

        public string Name { get; set; }

        public ResourceTypeData()
        {

        }

        public ResourceTypeData(string resourceTypeId, string name)
        {
            this.ResourceTypeId = resourceTypeId;
            this.Name = name;
        }

    }
}
