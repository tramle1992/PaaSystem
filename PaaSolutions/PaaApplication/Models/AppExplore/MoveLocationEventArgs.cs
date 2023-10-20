using Core.Application.Data.ExploreApps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.AppExplore
{
    public class MoveLocationEventArgs
    {
        public LocationData NewLocation { get; set; }
        public bool Success { get; set; }
        public bool MoveMultipleApps { get; set; }

        public MoveLocationEventArgs( LocationData newLocation, bool moveMultipleApps = false)
        {
            this.NewLocation = newLocation;
            this.Success = false;
            this.MoveMultipleApps = moveMultipleApps;
        }
    }
}
