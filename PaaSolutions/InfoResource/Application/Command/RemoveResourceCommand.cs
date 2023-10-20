using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoResource.Application.Command
{
    public class RemoveResourceCommand
    {
        public RemoveResourceCommand()
        {
        }

        public RemoveResourceCommand(string resourceId)
        {
            this.ResourceId = resourceId;
        }
        
        public string ResourceId { get; set; }        
    }
}
