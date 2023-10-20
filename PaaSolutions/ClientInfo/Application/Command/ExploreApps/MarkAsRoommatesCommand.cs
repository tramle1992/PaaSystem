using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ExploreApps
{
    public class MarkAsRoommatesCommand
    {
        public List<string> RoommateIds { get; set; }

        public MarkAsRoommatesCommand(List<string> roommateIds)
        {
            this.RoommateIds = roommateIds;
        }
    }
}
