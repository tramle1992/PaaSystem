using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using IdentityAccess.Domain.Model.Identity;

namespace Core.Domain.Model.ExploreApps
{
    public class Location : ValueObject
    {
        public string LocationId { get; set; }

        public string LocationName { get; set; }

        private Location()
        { }

        public static readonly Location Review1 = new Location("32b57c26-bece-4a85-9f32-c4f46e1dafca", "Review 1");
        public static readonly Location Review2 = new Location("b36af186-bbda-4a5d-9df5-18369d7295e9", "Review 2");
        public static readonly Location Review3 = new Location("b1af4c22-073f-48c0-9f69-6baa7a913ba4", "Review 3");
        public static readonly Location Pickup = new Location("cdbb6837-e165-477e-88aa-fdffcabc7dea", "Pickup");
        public static readonly Location NewApps = new Location("97ede89a-cad3-4125-a8ad-be7a3097aca1", "New Apps");
        public static readonly Location Archive = new Location("c9781c70-9fc2-4e3c-9eda-b98f5293a0d6", "Archive");
        public static readonly Location Search = new Location("89a204e5-a2cb-46e9-843c-75d35f31af90", "Search");

        public static Location GetPreDefinedLocation(string id)
        {
            if (id == "32b57c26-bece-4a85-9f32-c4f46e1dafca")
                return Location.Review1;
            else if (id == "b36af186-bbda-4a5d-9df5-18369d7295e9")
                return Location.Review2;
            else if (id == "b1af4c22-073f-48c0-9f69-6baa7a913ba4")
                return Location.Review3;
            else if (id == "cdbb6837-e165-477e-88aa-fdffcabc7dea")
                return Location.Pickup;
            else if (id == "97ede89a-cad3-4125-a8ad-be7a3097aca1")
                return Location.NewApps;
            else if (id == "c9781c70-9fc2-4e3c-9eda-b98f5293a0d6")
                return Location.Archive;
            else if (id == "89a204e5-a2cb-46e9-843c-75d35f31af90")
                return Location.Search;
            else
                return null;
        }

        public static Location FromUser(User user)
        {
            return new Location(user.UserId.Id, user.UserName);
        }

        public Location(string id, string name)
        {
            this.LocationId = id;
            this.LocationName = name;
        }

        public Location(Location location)
        {
            this.LocationId = location.LocationId;
            this.LocationName = location.LocationName;
        }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return this.LocationId;
            yield return this.LocationName;
        }

        public override string ToString()
        {
            return "Location[locationId=" + this.LocationId
                + ", locationName=" + this.LocationName + "]";
        }
    }
}
