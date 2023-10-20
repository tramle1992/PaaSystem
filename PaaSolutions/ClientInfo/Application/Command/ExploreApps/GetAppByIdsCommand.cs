using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ExploreApps
{
    public class GetAppByIdsCommand
    {
        public List<string> Ids { get; set; }

        public GetAppByIdsCommand()
        {
        }

        public GetAppByIdsCommand(List<string> ids)
        {
            this.Ids = ids;
        }
    }
}
