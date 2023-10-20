using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoResource.Application.Data
{
    public class ResourceTypeResourceData
    {
        public string ResourceTypeId { get; set; }

        public string Name { get; set; }

        public ISet<ResourceData> Resources { get; set; }
    }
}
