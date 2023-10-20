using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public class RentalRefData
    {
        public RentalRefFactInfoData Written { get; set; }

        public RentalRefFactInfoData KickedOut { get; set; }

        public RentalRefFactInfoData PrprNotice { get; set; }

        public RentalRefFactInfoData LateNSF { get; set; }

        public RentalRefFactInfoData Complaints { get; set; }

        public RentalRefFactInfoData Damages { get; set; }

        public RentalRefFactInfoData Owing { get; set; }

        public RentalRefFactInfoData Roommates { get; set; }

        public RentalRefFactInfoData AddressMatch { get; set; }

        public RentalRefFactInfoData Pets { get; set; }

        public RentalRefFactInfoData RltveFrnd { get; set; }

        public RentalRefFactInfoData ReRent { get; set; }

        public RentalRefFactInfoData BedBugs { get; set; }

        public string MoveIn { get; set; }

        public string MoveOut { get; set; }

        public string Amount { get; set; }

        public string SW { get; set; }

        public string Comp { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }

        public RentalRefData()
        {
            Written = ExploreApps.RentalRefFactInfoData.NotAvailable;
            KickedOut = ExploreApps.RentalRefFactInfoData.NotAvailable;
            PrprNotice = ExploreApps.RentalRefFactInfoData.NotAvailable;
            LateNSF = ExploreApps.RentalRefFactInfoData.NotAvailable;
            Complaints = ExploreApps.RentalRefFactInfoData.NotAvailable;
            Damages = ExploreApps.RentalRefFactInfoData.NotAvailable;
            Owing = ExploreApps.RentalRefFactInfoData.NotAvailable;
            Roommates = ExploreApps.RentalRefFactInfoData.NotAvailable;
            AddressMatch = ExploreApps.RentalRefFactInfoData.NotAvailable;
            Pets = ExploreApps.RentalRefFactInfoData.NotAvailable;
            RltveFrnd = ExploreApps.RentalRefFactInfoData.NotAvailable;
            ReRent = ExploreApps.RentalRefFactInfoData.NotAvailable;
            BedBugs = ExploreApps.RentalRefFactInfoData.NotAvailable;
            MoveIn = "";
            MoveOut = "";
            Amount = "";
            SW = "";
            Comp = "";
            Phone = "";
            Comment = "";
        }
    }
}
