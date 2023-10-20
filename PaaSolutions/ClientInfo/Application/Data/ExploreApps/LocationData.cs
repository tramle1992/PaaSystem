using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model.ExploreApps;

namespace Core.Application.Data.ExploreApps
{
    public class LocationData
    {
        public string LocationId { get; set; }

        public string LocationName { get; set; }

        public LocationData()
        {
        }

        public LocationData(string id, string name)
        {
            LocationId = id;
            LocationName = name;
        }

        public static List<LocationData> PreDefineLocations()
        {
            List<LocationData> locations = new List<LocationData>();
            Location newApps = Location.NewApps;
            Location review1 = Location.Review1;
            Location review2 = Location.Review2;
            Location review3 = Location.Review3;
            Location pickup = Location.Pickup;
            Location archive = Location.Archive;
            locations.Add(new LocationData(newApps.LocationId, newApps.LocationName));
            locations.Add(new LocationData(review1.LocationId, review1.LocationName));
            locations.Add(new LocationData(review2.LocationId, review2.LocationName));
            locations.Add(new LocationData(review3.LocationId, review3.LocationName));
            locations.Add(new LocationData(pickup.LocationId, pickup.LocationName));
            locations.Add(new LocationData(archive.LocationId, archive.LocationName));
            return locations;
        }
    }
}
