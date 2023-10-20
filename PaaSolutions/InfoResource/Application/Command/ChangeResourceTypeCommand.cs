using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoResource.Application.Command
{
    public class ChangeResourceTypeCommand
    {
        public ChangeResourceTypeCommand() { }

        public string ResourceTypeId { get; set; }
        public string Name { get; set; }
    }
}
