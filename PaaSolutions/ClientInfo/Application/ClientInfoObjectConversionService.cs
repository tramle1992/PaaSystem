using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Application.Data.ClientInfo;
using Core.Domain.Model.ClientInfo;

namespace Core.Application
{
    public class ClientInfoObjectConversionService
    {
        public static ClientData ToClientData(Client client)
        {
            ClientData item = new ClientData();
            item.ClientId = client.ClientId.Id;
            item.ClientName = client.ClientName;
            item.BillingAddress = client.BillingAddress;
            item.CustomerNumber = client.CustomerNumber;

            item.Phone = client.Phone;
            item.Fax = client.Fax;
            item.Email = client.Email;
            item.Since = client.Since;
            item.CreditType = null;
            item.BillingInfo = client.BillingInfo;
            item.MiscComments = client.MiscComments;
            if (client.ManagementCompany != null)
            {
                item.ManagementCompany = ToManagementCompanyData(client.ManagementCompany);
            }
            if(client.ReportTypeId != null)
            {
                item.DefaultReportTypeId = client.ReportTypeId.Id;
            }            
            item.ClientRevoked = client.ClientRevoked;
            item.DeclinationLetter = client.ClientReceive.DeclinationLetter;
            item.InvoicesCopiesNumber = client.ClientReceive.InvoicesCopiesNumber;
            item.Credentialed = client.ClientReceive.Credentialed;
            item.CreditType = ToCreditTypeData(client.CreditType);
            item.DefaultDeliverConfirmationsTo = client.DefaultDeliverConfirmationsTo;
            item.DefaultDeliverInvoicesTo = client.DefaultDeliverInvoicesTo;
            item.DefaultDeliverReportsTo = client.DefaultDeliverReportsTo;
            item.DefaultVerifyConfirmDelivery = client.DefaultVerifyConfirmDelivery;
            item.SpecialEntryInfo = client.SpecialEntryInfo;
            item.SpecialCriteriaInfo = client.SpecialCriteriaInfo;
            item.WebsiteDir = client.WebInfo.WebsiteDir;
            item.WebPass = client.WebInfo.WebPass;
            item.CreatedAt = client.CreatedAt;
            item.UpdatedAt = client.UpdatedAt;
            foreach (OtherAddress address in client.OtherAddresses)
            {
                item.OtherAddresses.Add(ToOtherAddressData(address));
            }
            foreach (Contact contact in client.Contacts)
            {
                item.Contacts.Add(ToContactData(contact));
            }
            foreach (InvoiceDivision invoiceDivision in client.InvoiceDivisions)
            {
                item.InvoiceDivisions.Add(ToInvoiceDivisionData(invoiceDivision));
            }
            foreach (ClientReportSpecialPrice specialPrice in client.ClientReportSpecialPrices)
            {
                item.ClientReportSpecialPrices.Add(ToClientReportSpecialPriceData(specialPrice));
            }

            return item;
        }

        public static ManagementCompanyData ToManagementCompanyData(ManagementCompany managementCompany)
        {
            ManagementCompanyData item = new ManagementCompanyData();
            item.ManagementCompanyId = managementCompany.ManagementCompanyId.Id;
            item.Name = managementCompany.Name;
            return item;
        }

        public static ManagementCompany ToManagementCompany(ManagementCompanyData data)
        {
            ManagementCompanyId id = new ManagementCompanyId(data.ManagementCompanyId);
            ManagementCompany item = new ManagementCompany(id, data.Name);
            return item;
        }

        public static OtherAddressData ToOtherAddressData(OtherAddress data)
        {
            OtherAddressData item = new OtherAddressData();
            item.AddressKind = data.AddressKind;
            item.Address = data.Address;
            return item;
        }

        public static OtherAddress ToOtherAddress(OtherAddressData otherAddress)
        {
            OtherAddress item = new OtherAddress(otherAddress.AddressKind, otherAddress.Address);
            return item;
        }

        public static ContactData ToContactData(Contact contact)
        {
            ContactData item = new ContactData();
            item.ContactType = (int)contact.ContactType;
            item.ContactInfo = contact.ContactInfo;
            switch (contact.ContactType)
            {
                case ContactType.Email:
                    item.ContactTypeName = "Email";
                    break;
                case ContactType.Fax:
                    item.ContactTypeName = "Fax";
                    break;
                case ContactType.Other:
                    item.ContactTypeName = "Other";
                    break;
            }
            return item;
        }

        public static Contact ToContact(ContactData data)
        {
            return new Contact((ContactType)data.ContactType, data.ContactInfo);
        }

        public static InvoiceLineData ToInvoiceLineData(InvoiceLine invoiceLine)
        {
            InvoiceLineData item = new InvoiceLineData();
            item.Value = invoiceLine.Value;
            item.DisplayName = invoiceLine.DisplayName;
            item.DetailMessage = invoiceLine.DetailMessage;
            return item;
        }

        public static InvoiceLine ToInvoiceLine(InvoiceLineData data)
        {
            return InvoiceLine.CreateInstance(data.Value);

        }

        public static InvoiceDivisionData ToInvoiceDivisionData(InvoiceDivision invoiceDivision)
        {
            InvoiceDivisionData item = new InvoiceDivisionData();
            item.DivisionName = invoiceDivision.DivisionName;
            return item;
        }

        public static InvoiceDivision ToInvoiceDivision(InvoiceDivisionData data)
        {
            return new InvoiceDivision(data.DivisionName);
        }

        public static CreditTypeData ToCreditTypeData(CreditType creditType)
        {
            if (creditType == null) return null;
            CreditTypeData item = new CreditTypeData();
            item.Value = creditType.Value;
            item.DisplayName = creditType.DisplayName;
            return item;
        }

        public static CreditType ToCreditType(CreditTypeData data)
        {
            return CreditType.CreateInstance(data.Value);
        }

        public static ReportTypeData ToReportTypeData(ReportType reportType)
        {
            ReportTypeData item = new ReportTypeData();
            item.TypeName = reportType.TypeName;
            item.ReportTypeId = reportType.ReportTypeId;
            item.AbsoluteTypeName = reportType.AbsoluteTypeName;
            item.DefaultPrice = reportType.DefaultPrice;
            return item;
        }

        public static ReportType ToReportType(ReportTypeData data)
        {
            ReportType item = new ReportType(data.ReportTypeId, data.TypeName, data.AbsoluteTypeName, data.DefaultPrice);
            return item;
        }

        public static ClientReportSpecialPriceData ToClientReportSpecialPriceData(ClientReportSpecialPrice specialPrice)
        {
            ClientReportSpecialPriceData item = new ClientReportSpecialPriceData();
            item.ReportTypeId = specialPrice.ReportTypeId;
            item.SpecialPrice = specialPrice.SpecialPrice;
            return item;
        }

        public static ClientReportSpecialPrice ToClientReportSpecialPrice(ClientReportSpecialPriceData data)
        {
            ClientReportSpecialPrice item = new ClientReportSpecialPrice(data.ReportTypeId, data.SpecialPrice);

            return item;
        }
    }
}
