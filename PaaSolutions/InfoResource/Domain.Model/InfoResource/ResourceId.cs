﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace InfoResource.Domain.Model.InfoResource
{
    public class ResourceId : Identity
    {
        public ResourceId() { }

        public ResourceId(string id) : base(id)
        {

        }
    }
}
