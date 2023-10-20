using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace InfoResource.Domain.Model.InfoResource
{
    public class ResourceTypeId : Identity
    {
        public ResourceTypeId() { }

        public ResourceTypeId(string id) : base(id)
        { }
    }
}
