using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace Core.Domain.Model.ClientInfo
{
    public class Client : EntityWithCompositeId, IAggregateRoot
    {

        public Client(ClientId clientId, string clientName)
            : this()
        {
            ClientId = clientId;
            ClientName = clientName;
        }

        public Client()
        {
            OtherAddresses = new HashSet<OtherAddress>();
            Contacts = new HashSet<Contact>();
            InvoiceDivisions = new HashSet<InvoiceDivision>();
            ClientReportSpecialPrices = new HashSet<ClientReportSpecialPrice>();
        }

        public ClientId ClientId { get; private set; }

        public string ClientName { get; private set; }

        public CreditType CreditType { get; set; }

        public string BillingAddress { get; set; }

        public ISet<OtherAddress> OtherAddresses { get; set; }

        public string CustomerNumber { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public DateTime Since { get; set; }

        public string Email { get; set; }

        public string BillingInfo { get; set; }

        public string MiscComments { get; set; }

        public ISet<Contact> Contacts { get; set; }

        public ManagementCompany ManagementCompany { get; set; }

        public ISet<InvoiceDivision> InvoiceDivisions { get; set; }

        public bool ClientRevoked { get; set; }

        public ClientReceive ClientReceive { get; set; }

        public string DefaultDeliverReportsTo { get; set; }

        public string DefaultDeliverConfirmationsTo { get; set; }

        public string DefaultDeliverInvoicesTo { get; set; }

        public bool DefaultVerifyConfirmDelivery { get; set; }

        public ISet<ClientReportSpecialPrice> ClientReportSpecialPrices { get; set; }

        public string SpecialEntryInfo { get; set; }

        public string SpecialCriteriaInfo { get; set; }

        public WebInfo WebInfo { get; set; }

        public bool Summaries { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ReportTypeId ReportTypeId { get; set; }

        public void ChangeName(string name)
        {
            this.ClientName = name;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.ClientId;
            yield return this.ClientName;
        }

        public override string ToString()
        {
            return "Client[clientId=" + this.ClientId
                + ", name=" + this.ClientName + "]";
        }
    }
}
