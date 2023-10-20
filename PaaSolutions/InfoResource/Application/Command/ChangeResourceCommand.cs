using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoResource.Application.Command
{
    public class ChangeResourceCommand
    {
        public ChangeResourceCommand()
        {
        }

        public string ResourceId { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public string Comment { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ResourceTypeId { get; set; }
    }
}
