using Core.Application.Data.ExploreApps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.AppExplore
{
    public class MoveScreenerEventArgs
    {
        public ScreenerData CurrentScreener { get; set; }
        public ScreenerData NewScreener { get; set; }
        public bool Success { get; set; }

        public MoveScreenerEventArgs(ScreenerData currentScreener, ScreenerData newScreener)
        {
            CurrentScreener = currentScreener;
            NewScreener = newScreener;
            Success = false;
        }
    }
}
