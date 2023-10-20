using Core.Application.Data.ExploreApps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.AppExplore
{
    public class SavedAppEventArgs
    {
        public AppData App { get; set; }

        public SavedAppEventArgs(AppData app)
        {
            this.App = app;
        }
    }
}
