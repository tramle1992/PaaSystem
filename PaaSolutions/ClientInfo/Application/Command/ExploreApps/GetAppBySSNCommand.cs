using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ExploreApps
{
    public class GetAppBySSNCommand
    {
        public List<string> SSNNumbers { get; set; }

        public GetAppBySSNCommand()
        {
        }

        public GetAppBySSNCommand(List<string> ssnNumbers)
        {
            this.SSNNumbers = ssnNumbers;
        }
    }
}
