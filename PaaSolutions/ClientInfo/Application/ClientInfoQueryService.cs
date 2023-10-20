using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Application.Data;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using Core.Domain.Model.ClientInfo;
using Common.Infrastructure.Query;
using System.Data;
using Dapper;
using Common.Infrastructure.Helper;

namespace Core.Application
{
    public class ClientInfoQueryService : QueryService
    {
        public ClientInfoQueryService()
        {
            this.managementCompanyRepository = new ManagementCompanyRepository();
            this.reportTypeRepository = new ReportTypeRepository();
            this.clientRepository = new ClientRepository();
        }

        readonly ManagementCompanyRepository managementCompanyRepository;
        readonly ReportTypeRepository reportTypeRepository;
        readonly ClientRepository clientRepository;

        public IList<ManagementCompanyData> GetAllManagementCompany()
        {
            List<ManagementCompanyData> lstResult = new List<ManagementCompanyData>();
            IEnumerable<ManagementCompany> managementCompanies = managementCompanyRepository.FindAll();
            foreach (ManagementCompany managementCompany in managementCompanies)
            {
                lstResult.Add(ClientInfoObjectConversionService.ToManagementCompanyData(managementCompany));
            }
            return lstResult;
        }

        public ManagementCompanyData GetManagementCompany(string id)
        {
            ManagementCompany managementCompany = managementCompanyRepository.Find(id);
            if (managementCompany == null)
            {
                return null;
            }
            return ClientInfoObjectConversionService.ToManagementCompanyData(managementCompany);
        }

        public IList<ReportTypeData> GetAllReportType()
        {
            List<ReportTypeData> lstResult = new List<ReportTypeData>();
            IEnumerable<ReportType> reportTypes = reportTypeRepository.FindAll();
            foreach (ReportType reportType in reportTypes)
            {
                lstResult.Add(ClientInfoObjectConversionService.ToReportTypeData(reportType));
            }
            return lstResult;
        }

        public ReportTypeData GetReportType(string id)
        {
            ReportType reportType = reportTypeRepository.Find(id);
            if (reportType == null)
            {
                return null;
            }
            return ClientInfoObjectConversionService.ToReportTypeData(reportType);
        }

        public ReportTypeData GetReportTypeByTypeName(string typeName)
        {
            ReportType reportType = reportTypeRepository.FindByTypeName(typeName);
            if (reportType == null)
            {
                return null;
            }
            return ClientInfoObjectConversionService.ToReportTypeData(reportType);
        }

        public IList<CreditTypeData> GetAllCreditType()
        {
            List<CreditTypeData> lstResult = new List<CreditTypeData>();
            IEnumerable<CreditType> creditTypes = CreditType.GetAll<CreditType>();
            foreach (CreditType creditType in creditTypes)
            {
                lstResult.Add(ClientInfoObjectConversionService.ToCreditTypeData(creditType));
            }
            return lstResult;
        }

        public IList<InvoiceLineData> GetAllInvoiceLine()
        {
            List<InvoiceLineData> lstResult = new List<InvoiceLineData>();
            IEnumerable<InvoiceLine> invoiceLines = InvoiceLine.GetAll<InvoiceLine>();
            foreach (InvoiceLine invoiceLine in invoiceLines)
            {
                InvoiceLineData item = ClientInfoObjectConversionService.ToInvoiceLineData(invoiceLine);
                lstResult.Add(item);
            }
            return lstResult;
        }

        public IList<ClientData> GetAllClient()
        {
            List<ClientData> lstResult = new List<ClientData>();
            IEnumerable<Client> clients = clientRepository.FindAll();
            foreach (Client client in clients)
            {
                ClientData item = ClientInfoObjectConversionService.ToClientData(client);
                lstResult.Add(item);
            }
            return lstResult;
        }

        public ClientData GetClient(string id)
        {
            Client client = clientRepository.Find(id);
            if (client == null)
            {
                return null;
            }
            return ClientInfoObjectConversionService.ToClientData(client);
        }

        public ClientData GetClientByName(string clientname)
        {
            Client client = clientRepository.FindByName(clientname);
            if (client == null)
            {
                return null;
            }
            return ClientInfoObjectConversionService.ToClientData(client);
        }

        public IList<ClientDisplayInfoData> GetAllClientDisplayInfoData()
        {
            List<ClientDisplayInfoData> lstResult = new List<ClientDisplayInfoData>();
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                string queryStatement = @"select client_id, client_name from client order by client_name";
                IEnumerable<dynamic> result = cn.Query<dynamic>(queryStatement);
                foreach (var item in result)
                {
                    lstResult.Add(new ClientDisplayInfoData(item.client_id, item.client_name));
                }
            }
            return lstResult;
        }        

        public IList<ClientMailsDisplayInfoData> GetAllClientMailInfoData()
        {
            List<ClientMailsDisplayInfoData> lstResult = new List<ClientMailsDisplayInfoData>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string queryStatement = @"select client_id, client_name, email, contacts from client order by client_name";
                    IEnumerable<dynamic> result = cn.Query<dynamic>(queryStatement);

                    ISet<Contact> Contacts;

                    foreach (var item in result)
                    {
                        List<string> lstEmails = new List<string>();
                        string email = item.email;
                        lstEmails.Add(email);

                        if (!string.IsNullOrEmpty(item.contacts))
                        {
                            Contacts = XmlSerializationHelper.Deserialize<HashSet<Contact>>(item.contacts);
                            if (Contacts.Count > 0)
                            {
                                foreach (Contact c in Contacts)
                                {
                                    if (c.ContactType == ContactType.Email)
                                    {
                                        string cMail = c.ContactInfo;
                                        if (!email.Equals(cMail))
                                        {
                                            lstEmails.Add(cMail);
                                        }
                                    }
                                }
                            }
                        }
                        lstResult.Add(new ClientMailsDisplayInfoData(lstEmails, item.client_name, item.client_id));
                    }
                }
            }
            catch (Exception ex)
            {
                string exeption = ex.ToString();
            }

            return lstResult;
        }

        public IList<string> GetAllCustomerNumber()
        {
            List<string> lstResult = new List<string>();
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                string queryStatement = @"select distinct customer_number from client where customer_number <> '' order by customer_number";
                IEnumerable<dynamic> result = cn.Query<dynamic>(queryStatement);
                foreach (var item in result)
                {
                    if (!string.IsNullOrEmpty(item.customer_number))
                    {
                        lstResult.Add(item.customer_number);
                    }
                }
            }
            return lstResult;
        }

        public IList<string> GetAllInvoiceDivision()
        {
            List<string> lstResult = new List<string>();
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                string queryStatement = @"select distinct invoice_divisions from client where invoice_divisions <> '' order by invoice_divisions";
                IEnumerable<dynamic> result = cn.Query<dynamic>(queryStatement);
                foreach (var item in result)
                {
                    if (!string.IsNullOrEmpty(item.invoice_divisions))
                    {
                        ISet<InvoiceDivision> invoiceDivisions = XmlSerializationHelper.Deserialize<HashSet<InvoiceDivision>>(item.invoice_divisions);
                        foreach (InvoiceDivision invoiceDivision in invoiceDivisions)
                        {
                            string divisionName = ClientInfoObjectConversionService.ToInvoiceDivisionData(invoiceDivision).DivisionName;
                            if (!string.IsNullOrEmpty(divisionName))
                            {
                                lstResult.Add(divisionName);
                            }
                        }
                    }
                }
            }
            return lstResult;
        }

        public IList<ClientData> GetClientsByQuery(string query)
        {
            List<ClientData> lstResult = new List<ClientData>();
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                IEnumerable<dynamic> result = cn.Query<dynamic>(query);
                foreach (var item in result)
                {
                    if (item != null && !string.IsNullOrEmpty(item.client_id))
                    {
                        ClientData client = new ClientData();
                        client.ClientId = item.client_id;
                        client.ClientName = item.client_name;
                        client.BillingAddress = item.billing_address;
                        client.OtherAddresses = item.other_addresses;
                        client.Phone = item.phone;
                        client.Fax = item.fax;
                        client.Email = item.email;
                        client.Since = Convert.ToDateTime(item.since);
                        client.BillingInfo = item.billing_info;
                        client.MiscComments = item.misc_comments;
                        client.ClientRevoked = item.client_revoked;
                        client.DeclinationLetter = item.declination_letter;
                        client.InvoicesCopiesNumber = item.invoices_copies_number;
                        client.Credentialed = item.credentialed;
                        client.DefaultDeliverReportsTo = item.default_deliver_reports_to;
                        client.DefaultDeliverConfirmationsTo = item.default_deliver_confirmation_to;
                        client.DefaultDeliverInvoicesTo = item.default_deliver_invoices_to;
                        client.DefaultVerifyConfirmDelivery = item.default_verify_confirm_delivery;
                        client.SpecialEntryInfo = item.special_entry_info;
                        client.SpecialCriteriaInfo = item.special_criteria_info;
                        client.WebsiteDir = item.website_dir;
                        client.WebPass = item.web_pass;
                        client.Summaries = item.summaries;
                        client.CreatedAt = item.created_at;
                        client.UpdatedAt = item.updated_at;
                        client.CustomerNumber = item.customer_number;

                        if (!string.IsNullOrEmpty(item.other_addresses))
                        {
                            ISet<OtherAddress> otherAddresses = XmlSerializationHelper.Deserialize<HashSet<OtherAddress>>(item.other_addresses);
                            foreach (OtherAddress otherAddress in otherAddresses)
                            {
                                client.OtherAddresses.Add(ClientInfoObjectConversionService.ToOtherAddressData(otherAddress));
                            }
                        }

                        if (!string.IsNullOrEmpty(item.contacts))
                        {
                            ISet<Contact> contacts = XmlSerializationHelper.Deserialize<HashSet<Contact>>(item.contacts);
                            foreach (Contact contact in contacts)
                            {
                                client.Contacts.Add(ClientInfoObjectConversionService.ToContactData(contact));
                            }
                        }

                        if (!string.IsNullOrEmpty(item.management_company_id) && !string.IsNullOrEmpty(item.management_company_name))
                        {
                            ManagementCompanyData managementCompany = new ManagementCompanyData(item.management_company_id, item.management_company_name);
                            client.ManagementCompany = managementCompany;
                        }

                        if (!string.IsNullOrEmpty(item.invoice_divisions))
                        {
                            ISet<InvoiceDivision> invoiceDivisions = XmlSerializationHelper.Deserialize<HashSet<InvoiceDivision>>(item.invoice_divisions);
                            foreach (InvoiceDivision invoiceDivision in invoiceDivisions)
                            {
                                client.InvoiceDivisions.Add(ClientInfoObjectConversionService.ToInvoiceDivisionData(invoiceDivision));
                            }
                        }

                        if (!string.IsNullOrEmpty(item.client_report_special_price))
                        {
                            ISet<ClientReportSpecialPrice> specialPrices = XmlSerializationHelper.Deserialize<HashSet<ClientReportSpecialPrice>>(item.client_report_special_price);
                            foreach (ClientReportSpecialPrice specialPrice in specialPrices)
                            {
                                client.ClientReportSpecialPrices.Add(ClientInfoObjectConversionService.ToClientReportSpecialPriceData(specialPrice));
                            }
                        }

                        lstResult.Add(client);
                    }
                }
            }
            return lstResult;
        }

    }
}
