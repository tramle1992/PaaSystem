using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoResource.Application.Command
{
    public class MoveResourceToResourceTypeCommand
    {
        public string ResourceId { get; set; }

        public string ResourceTypeId { get; set; }
    }
}
