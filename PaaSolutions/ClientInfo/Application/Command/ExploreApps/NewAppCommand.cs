using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Data.ExploreApps;

namespace Core.Application.Command.ExploreApps
{
    public class NewAppCommand
    {
        public AppData App { get; set; }

        public NewAppCommand(AppData app)
        {
            this.App = app;
        }
    }
}
