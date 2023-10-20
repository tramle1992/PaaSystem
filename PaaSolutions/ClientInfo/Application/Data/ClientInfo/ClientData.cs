using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Application.Data.ClientInfo
{
    public class ClientData
    {
        public ClientData()
        {
            OtherAddresses = new HashSet<OtherAddressData>();
            Contacts = new HashSet<ContactData>();
            InvoiceDivisions = new HashSet<InvoiceDivisionData>();
            ClientReportSpecialPrices = new HashSet<ClientReportSpecialPriceData>();
        }

        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public string BillingAddress { get; set; }

        public ISet<OtherAddressData> OtherAddresses { get; set; }

        public string CustomerNumber { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public DateTime Since { get; set; }

        public string BillingInfo { get; set; }

        public string MiscComments { get; set; }

        public ISet<ContactData> Contacts { get; set; }

        public ManagementCompanyData ManagementCompany { get; set; }

        public ISet<InvoiceDivisionData> InvoiceDivisions { get; set; }

        public bool ClientRevoked { get; set; }

        public bool DeclinationLetter { get; set; }

        public int InvoicesCopiesNumber { get; set; }

        public bool Credentialed { get; set; }

        public CreditTypeData CreditType { get; set; }

        public string DefaultDeliverReportsTo { get; set; }

        public string DefaultDeliverConfirmationsTo { get; set; }

        public string DefaultDeliverInvoicesTo { get; set; }

        public bool DefaultVerifyConfirmDelivery { get; set; }

        public ISet<ClientReportSpecialPriceData> ClientReportSpecialPrices { get; set; }

        public string SpecialEntryInfo { get; set; }

        public string SpecialCriteriaInfo { get; set; }

        public string WebsiteDir { get; set; }

        public string WebPass { get; set; }

        public bool Summaries { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string DefaultReportTypeId { get; set; }

        public string DefaultReportTypeName { get; set; }
    }
}
