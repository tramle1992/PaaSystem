using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public class AppData
    {
        public string ApplicationId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string AppSSN { get; set; }

        public DateTime? BirthDate { get; set; }

        public string HouseNumber { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string ClientApplied { get; set; }

        public string ClientAppliedName { get; set; }

        public string ClientName { get; set; }

        public string ReportTypeId { get; set; }

        public string ReportTypeName { get; set; }

        public string ReportCommunity { get; set; }

        public string ReportManagement { get; set; }

        public string UnitNumber { get; set; }

        public string RentAmount { get; set; }

        public string MoveInDate { get; set; }

        public bool PdxIndicator { get; set; }

        // Roommates
        public string ReportSpecialField { get; set; }

        public int PagesReceived { get; set; }

        public string LocationId { get; set; }

        public string LocationName { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public string ScreenerId { get; set; }

        public string ScreenerName { get; set; }

        public string PositionApplied { get; set; }

        public string CompanyApplied { get; set; }

        public CreditInfoData CreditInfo { get; set; }

        public List<CreditRefData> CreditRefs { get; set; }

        public EmpVerData EmpVer { get; set; }

        public List<EmpRefData> EmpRefs { get; set; }

        public List<RentalRefData> RentalRefs { get; set; }

        public List<ChargeRefData> Charges { get; set; }

        public List<EvictionRefData> Evictions { get; set; }

        // Comm
        public string Company { get; set; }

        public string Phone { get; set; }

        public string RegAgent { get; set; }

        public string DateActive { get; set; }

        public string StateActive { get; set; }

        public string BankComm { get; set; }

        public string OpenedComm { get; set; }

        public string BalanceComm { get; set; }

        public string AcctComm { get; set; }

        public string NSFODComm { get; set; }

        public string SWComm { get; set; }

        // App. Comments
        public string StaffComments { get; set; }

        public string FinalComments { get; set; }

        public RecommendationFactInfoData Recommendation { get; set; }

        public PriorityAppData Priority { get; set; }

        // Callouts
        public List<ContactAttemptData> ContactAttempts { get; set; }

        public string InvoiceDivision { get; set; }

        public string CreditPulled { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string BilledStatus { get; set; }

        public AppData()
        {
            EmpRefs = new List<EmpRefData>();
            RentalRefs = new List<RentalRefData>();
            Charges = new List<ChargeRefData>();
            Evictions = new List<EvictionRefData>();
            CreditRefs = new List<CreditRefData>();
            Recommendation = new RecommendationFactInfoData();
            InvoiceDivision = string.Empty;
        }

    }
}
