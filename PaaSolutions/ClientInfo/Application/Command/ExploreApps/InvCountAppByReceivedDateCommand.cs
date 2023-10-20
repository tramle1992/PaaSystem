using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ExploreApps
{
    public class InvCountAppByReceivedDateCommand
    {
        public DateTime ReceivedFrom { get; set; }

        public DateTime ReceivedTo { get; set; }

        public InvCountAppByReceivedDateCommand()
        {
        }

        public InvCountAppByReceivedDateCommand(DateTime receivedFrom, DateTime receivedTo)
        {
            this.ReceivedFrom = receivedFrom;
            this.ReceivedTo = receivedTo;
        }
    }
}
