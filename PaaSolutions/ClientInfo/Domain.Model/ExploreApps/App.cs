using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using Core.Domain.Model.ClientInfo;

namespace Core.Domain.Model.ExploreApps
{
    public class App : EntityWithCompositeId, IAggregateRoot
    {

        public App(AppId applicationId)
            : this()
        {
            ApplicationId = applicationId;
        }

        public App()
        {
            EmpRefs = new List<EmpRef>();
            RentalRefs = new List<RentalRef>();
            Charges = new List<ChargeRef>();
            Evictions = new List<EvictionRef>();
            CreditRefs = new List<CreditRef>();
            Recommendation = new RecommendationFactInfo();
            InvoiceDivision = string.Empty;
        }

        public AppId ApplicationId { get; set; }

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

        public ClientId ClientApplied { get; set; }

        public string ClientName { get; set; }

        public ReportTypeId ReportTypeId { get; set; }

        public string ReportCommunity { get; set; }

        public string ReportManagement { get; set; }

        public string UnitNumber { get; set; }

        public string RentAmount { get; set; }

        public string MoveInDate { get; set; }

        public bool PdxIndicator { get; set; }

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

        // Roommates
        public string ReportSpecialField { get; set; }

        public int PagesReceived { get; set; }

        public Location Location { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public Screener Screener { get; set; }

        public string PositionApplied { get; set; }

        public string CompanyApplied { get; set; }

        public CreditInfo CreditInfo { get; set; }

        public List<CreditRef> CreditRefs { get; set; }

        public EmpVer EmpVer { get; set; }

        public List<EmpRef> EmpRefs { get; set; }

        public List<RentalRef> RentalRefs { get; set; }

        public List<ChargeRef> Charges { get; set; }

        public List<EvictionRef> Evictions { get; set; }

        // App. Comments
        public string StaffComments { get; set; }

        public string FinalComments { get; set; }

        public RecommendationFactInfo Recommendation { get; set; }

        public PriorityApp Priority { get; set; }

        // Callouts
        public List<ContactAttempt> ContactAttempts { get; set; }

        public string InvoiceDivision { get; set; }

        public string CreditPulled { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.ApplicationId;
            yield return this.LastName;
            yield return this.FirstName;
            yield return this.ReceivedDate;
            yield return this.ClientApplied;
        }

        public override string ToString()
        {
            return "App[appId=" + this.ApplicationId.Id
                + ", firstName=" + this.FirstName
                + ", lastName=" + this.LastName + "]";
        }

    }
}
