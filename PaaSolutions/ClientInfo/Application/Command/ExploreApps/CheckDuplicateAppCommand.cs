using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ExploreApps
{
    public class CheckDuplicateAppCommand
    {
        public List<string> AppSSNs { get; set; }

        public CheckDuplicateAppCommand()
        {
        }

        public CheckDuplicateAppCommand(List<string> appSSNs)
        {
            this.AppSSNs = appSSNs;
        }
    }
}
