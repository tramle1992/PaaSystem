using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using System.ComponentModel;
using Common.Application;
using Core.Infrastructure.ClientInfo;
using Core.Domain.Model.ClientInfo;
using InfoResource.Infrastructure.InfoResource;
using InfoResource.Domain.Model.InfoResource;
using ZipCodeContext.Infrastructure;
using ZipCodeContext.Domain.Model;
using System.Text.RegularExpressions;
using System.IO;
using Core.Infrastructure.ExploreApps;
using Core.Domain.Model.ExploreApps;
using Invoice.Infrastructure;
using Core.Application.Data.ClientInfo;
using Core.Application;
using Dapper;

namespace DataMigrationApp
{
    public class MigrationService
    {

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MigrationService(string sourceConnectionString)
        {
            this.SourceConnectionString = sourceConnectionString;
        }

        public string SourceConnectionString { get; set; }

        public void MigrateClientInfoManagementCompany(BackgroundWorker bw)
        {
            try
            {
                DataTable sourceManagementCompanyTable = new DataTable();

                ManagementCompanyRepository managementCompanyRepository = new ManagementCompanyRepository();

                managementCompanyRepository.RemoveAll();

                using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("select distinct Management from Clients", sourceConnection);
                    sourceAdapter.Fill(sourceManagementCompanyTable);
                }

                foreach (DataRow row in sourceManagementCompanyTable.Rows)
                {
                    ManagementCompanyId managementCompanyId = new ManagementCompanyId(Guid.NewGuid().ToString());
                    if (!string.IsNullOrEmpty(row["Management"].ToString()))
                    {
                        ManagementCompany managementCompany = new ManagementCompany(managementCompanyId, row["Management"].ToString());
                        managementCompanyRepository.Add(managementCompany);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                _logger.Error(ex);
            }
        }

        public void MigrateClientInfoReportType(BackgroundWorker bw)
        {
            try
            {
                DataTable sourceReportTypeTable = new DataTable();

                ReportTypeRepository reportTypeRepository = new ReportTypeRepository();

                reportTypeRepository.RemoveAll();

                using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("select TypeName, AbsoluteTypeName, DefaultPrice  from ReportTypes", sourceConnection);
                    sourceAdapter.Fill(sourceReportTypeTable);
                }

                foreach (DataRow row in sourceReportTypeTable.Rows)
                {
                    string reportTypeId = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(row["TypeName"].ToString()))
                    {
                        string typeName = row["TypeName"].ToString();
                        string absoluteTypeName = row["AbsoluteTypeName"].ToString();
                        decimal defaultPrice = decimal.Parse(row["DefaultPrice"].ToString());
                        ReportType reportType = new ReportType(reportTypeId, typeName, absoluteTypeName, defaultPrice);
                        reportTypeRepository.Add(reportType);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        public void UpdateClientInfoData(BackgroundWorker bw)
        {
            List<ClientData> lstResult = new List<ClientData>();
            ClientRepository clientRepository = new ClientRepository();
            IEnumerable<Client> clients = clientRepository.FindAll();
            foreach (Client client in clients)
            {
                ClientData item = ClientInfoObjectConversionService.ToClientData(client);
                lstResult.Add(item);
            }

            DataTable sourceClientTable = new DataTable();

            ManagementCompanyRepository managementCompanyRepository = new ManagementCompanyRepository();

            List<ManagementCompany> lstManagementCompany = (List<ManagementCompany>)(managementCompanyRepository.FindAll());

            using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
            {
                OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                sourceAdapter.SelectCommand = new OleDbCommand("select * from Clients", sourceConnection);
                sourceAdapter.Fill(sourceClientTable);
            }

            //Loop each row to find what Client Name missed on New PAA to update New PAA bases
            foreach (DataRow row in sourceClientTable.Rows)
            {
                if (!string.IsNullOrEmpty(row["ClientName"].ToString()))
                {
                    string clientName = row["ClientName"].ToString().Trim();
                    if(!lstResult.Any(i=>i.ClientName == clientName))
                    {
                        ClientId clientId = new ClientId(Guid.NewGuid().ToString());
                        Client client = new Client(clientId, row["ClientName"].ToString().Trim());
                        client.CustomerNumber = row.IsNull("CustomerNumber") ? "" : row["CustomerNumber"].ToString();
                        client.BillingAddress = row.IsNull("BillingAddress") ? "" : row["BillingAddress"].ToString();
                        client.Phone = row.IsNull("Phone") ? "" : row["Phone"].ToString();
                        client.Fax = row.IsNull("Fax") ? "" : row["Fax"].ToString();
                        client.Email = row.IsNull("Email") ? "" : row["Email"].ToString();
                        client.Since = (DateTime)row["Since"];
                        client.BillingInfo = row.IsNull("BillingInfo") ? "" : row["BillingInfo"].ToString();
                        client.MiscComments = row.IsNull("MiscComments") ? "" : row["MiscComments"].ToString();
                        client.ClientRevoked = row.IsNull("ClientRevoked") ? false : (bool)(row["ClientRevoked"]);
                        client.ClientReceive = new ClientReceive(
                            row.IsNull("DeclinationLetter") ? false : (bool)(row["DeclinationLetter"]),
                            row.IsNull("InvoiceCopies") ? 0 : (int)(row["InvoiceCopies"]),
                            row.IsNull("Credentialed") ? false : (bool)(row["Credentialed"]));
                        if (!row.IsNull("CreditType"))
                        {
                            int creditType = (int)(row["CreditType"]);
                            switch (creditType)
                            {
                                case 0:
                                    client.CreditType = CreditType.RegularCreditReports;
                                    break;
                                case 1:
                                    client.CreditType = CreditType.EnhancePeopleSearch;
                                    break;
                                case 2:
                                    client.CreditType = CreditType.NoCreditReports;
                                    break;
                                case 3:
                                    client.CreditType = CreditType.CreditAndFICOScore;
                                    break;

                            }
                        }
                        else
                        {
                            client.CreditType = CreditType.RegularCreditReports;
                        }

                        client.DefaultDeliverReportsTo = row.IsNull("DefaultReportDelivery") ? "" : row["DefaultReportDelivery"].ToString();
                        client.DefaultDeliverConfirmationsTo = row.IsNull("DefaultConfDelivery") ? "" : row["DefaultConfDelivery"].ToString();
                        client.DefaultDeliverInvoicesTo = row.IsNull("DefaultInvDelivery") ? "" : row["DefaultInvDelivery"].ToString();
                        client.DefaultVerifyConfirmDelivery = row.IsNull("VerifyConfDelivery") ? false : (bool)(row["VerifyConfDelivery"]);
                        client.SpecialEntryInfo = row.IsNull("SpecialEntryInfo") ? "" : row["SpecialEntryInfo"].ToString();
                        client.SpecialCriteriaInfo = row.IsNull("SpecialCriteriaInfo") ? "" : row["SpecialCriteriaInfo"].ToString();
                        client.WebInfo = new WebInfo(
                            row.IsNull("WebsiteDir") ? "" : row["WebsiteDir"].ToString(),
                            row.IsNull("WebPass") ? "" : row["WebPass"].ToString());
                        client.Summaries = row.IsNull("Summaries") ? false : (bool)(row["Summaries"]);

                        if (!row.IsNull("Management") && !string.IsNullOrEmpty(row["Management"].ToString()))
                        {
                            foreach (ManagementCompany item in lstManagementCompany)
                            {
                                if (item.Name == row["Management"].ToString().Trim())
                                {
                                    client.ManagementCompany = item;
                                    break;
                                }
                            }
                        }

                        ISet<OtherAddress> otherAddresses = new HashSet<OtherAddress>();
                        string otherAddressesString = row["OtherAddresses"].ToString();
                        if (!string.IsNullOrEmpty(otherAddressesString))
                        {
                            string[] addresses = otherAddressesString.Split(GlobalConstants.RecSep);
                            foreach (string addressItem in addresses)
                            {
                                string[] items = addressItem.Split(GlobalConstants.Sep);
                                if (items.Length >= 4)
                                {
                                    string addressKind = items[2];
                                    string address = items[3];
                                    if (!string.IsNullOrEmpty(addressKind) && (!string.IsNullOrEmpty(address)))
                                    {
                                        otherAddresses.Add(new OtherAddress(addressKind, address));
                                    }
                                }
                            }
                        }
                        if (otherAddresses.Count > 0)
                        {
                            client.OtherAddresses = otherAddresses;
                        }


                        ISet<Contact> contacts = new HashSet<Contact>();
                        string contactString = row["Contacts"].ToString();
                        if (!string.IsNullOrEmpty(contactString))
                        {
                            string[] contactsArray = contactString.Split(GlobalConstants.RecSep);
                            foreach (string contactItem in contactsArray)
                            {
                                string[] items = contactItem.Split(GlobalConstants.Sep);
                                string contactType = "";
                                string contactInfo = items[2];
                                if (items.Length >= 4)
                                {
                                    contactType = items[3];
                                }
                                else
                                {
                                    contactType = "Other";
                                }

                                if (contactType == "Email")
                                {
                                    contacts.Add(new Contact(ContactType.Email, contactInfo));
                                }
                                else if (contactType == "Fax")
                                {
                                    contacts.Add(new Contact(ContactType.Fax, contactInfo));
                                }
                                else if (contactType == "Other")
                                {
                                    contacts.Add(new Contact(ContactType.Other, contactInfo));
                                }
                            }
                        }
                        if (contacts.Count > 0)
                        {
                            client.Contacts = contacts;
                        }

                        ISet<InvoiceDivision> invoiceDivisions = new HashSet<InvoiceDivision>();
                        string invoiceDivisionsString = row["InvoiceDivisions"].ToString();
                        if (!string.IsNullOrEmpty(invoiceDivisionsString))
                        {
                            string[] invoiceDivisionsArray = invoiceDivisionsString.Split(GlobalConstants.RecSep);
                            foreach (string invoiceDivisionItem in invoiceDivisionsArray)
                            {
                                string[] items = invoiceDivisionItem.Split(GlobalConstants.Sep);
                                if (items.Length >= 3)
                                {
                                    invoiceDivisions.Add(new InvoiceDivision(items[2]));
                                }
                            }
                        }
                        if (invoiceDivisions.Count > 0)
                        {
                            client.InvoiceDivisions = invoiceDivisions;
                        }

                        if (client != null && !string.IsNullOrEmpty(client.ClientName))
                        {
                            clientRepository.Add(client);
                        }
                    }
                }
            }
        }

        public void FixClientCustomerSince(BackgroundWorker bw)
        {
            List<ClientData> lstResult = new List<ClientData>();
            ClientRepository clientRepository = new ClientRepository();
            IEnumerable<Client> clients = clientRepository.FindAll();

            DataTable sourceClientTable = new DataTable();

            ManagementCompanyRepository managementCompanyRepository = new ManagementCompanyRepository();

            List<ManagementCompany> lstManagementCompany = (List<ManagementCompany>)(managementCompanyRepository.FindAll());

            using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
            {
                OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                sourceAdapter.SelectCommand = new OleDbCommand("select * from Clients", sourceConnection);
                sourceAdapter.Fill(sourceClientTable);
            }

            var newClient = 0;
            var newClientListSb = new StringBuilder();
            foreach(var client in clients)
            {
                var foundClient = false;
                foreach (DataRow row in sourceClientTable.Rows)
                {
                    string sourceClientName = row["ClientName"].ToString().Trim();
                    if (client.ClientName == sourceClientName)
                    {
                        foundClient = true;
                        try
                        {
                            using (IDbConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["PaaSystem"].ConnectionString))
                            {
                                string updateStatement = @"update client set  since=@since where client_id=@client_id";
                                var args = new DynamicParameters();
                                args.Add("client_id", client.ClientId.ToString());
                                args.Add("since", (DateTime)row["Since"]);
                                cn.Execute(updateStatement, args);
                            }
                        }
                        catch(SqlException ex)
                        {
                        }
                    }
                }
                if (!foundClient)
                {
                    newClient++;
                    newClientListSb.Append(client.ClientId.Id + Environment.NewLine);
                }
            }
            // File.WriteAllText(@"C:\client_list.txt", newClientListSb.ToString());

        }

        public void MigrateClientInfoClient(BackgroundWorker bw)
        {
            try
            {
                DataTable sourceClientTable = new DataTable();


                ClientRepository clientRepository = new ClientRepository();
                ManagementCompanyRepository managementCompanyRepository = new ManagementCompanyRepository();

                clientRepository.RemoveAll();
                List<ManagementCompany> lstManagementCompany = (List<ManagementCompany>)(managementCompanyRepository.FindAll());

                using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("select * from Clients", sourceConnection);
                    sourceAdapter.Fill(sourceClientTable);
                }

                foreach (DataRow row in sourceClientTable.Rows)
                {
                    ClientId clientId = new ClientId(Guid.NewGuid().ToString());
                    if (!string.IsNullOrEmpty(row["ClientName"].ToString()))
                    {
                        Client client = new Client(clientId, row["ClientName"].ToString().Trim());
                        client.CustomerNumber = row.IsNull("CustomerNumber") ? "" : row["CustomerNumber"].ToString();
                        client.BillingAddress = row.IsNull("BillingAddress") ? "" : row["BillingAddress"].ToString();
                        client.Phone = row.IsNull("Phone") ? "" : row["Phone"].ToString();
                        client.Fax = row.IsNull("Fax") ? "" : row["Fax"].ToString();
                        client.Email = row.IsNull("Email") ? "" : row["Email"].ToString();
                        client.Since = (DateTime)row["Since"];
                        client.BillingInfo = row.IsNull("BillingInfo") ? "" : row["BillingInfo"].ToString();
                        client.MiscComments = row.IsNull("MiscComments") ? "" : row["MiscComments"].ToString();
                        client.ClientRevoked = row.IsNull("ClientRevoked") ? false : (bool)(row["ClientRevoked"]);
                        client.ClientReceive = new ClientReceive(
                            row.IsNull("DeclinationLetter") ? false : (bool)(row["DeclinationLetter"]),
                            row.IsNull("InvoiceCopies") ? 0 : (int)(row["InvoiceCopies"]),
                            row.IsNull("Credentialed") ? false : (bool)(row["Credentialed"]));
                        if (!row.IsNull("CreditType"))
                        {
                            int creditType = (int)(row["CreditType"]);
                            switch (creditType)
                            {
                                case 0:
                                    client.CreditType = CreditType.RegularCreditReports;
                                    break;
                                case 1:
                                    client.CreditType = CreditType.EnhancePeopleSearch;
                                    break;
                                case 2:
                                    client.CreditType = CreditType.NoCreditReports;
                                    break;
                                case 3:
                                    client.CreditType = CreditType.CreditAndFICOScore;
                                    break;

                            }
                        }
                        else
                        {
                            client.CreditType = CreditType.RegularCreditReports;
                        }

                        client.DefaultDeliverReportsTo = row.IsNull("DefaultReportDelivery") ? "" : row["DefaultReportDelivery"].ToString();
                        client.DefaultDeliverConfirmationsTo = row.IsNull("DefaultConfDelivery") ? "" : row["DefaultConfDelivery"].ToString();
                        client.DefaultDeliverInvoicesTo = row.IsNull("DefaultInvDelivery") ? "" : row["DefaultInvDelivery"].ToString();
                        client.DefaultVerifyConfirmDelivery = row.IsNull("VerifyConfDelivery") ? false : (bool)(row["VerifyConfDelivery"]);
                        client.SpecialEntryInfo = row.IsNull("SpecialEntryInfo") ? "" : row["SpecialEntryInfo"].ToString();
                        client.SpecialCriteriaInfo = row.IsNull("SpecialCriteriaInfo") ? "" : row["SpecialCriteriaInfo"].ToString();
                        client.WebInfo = new WebInfo(
                            row.IsNull("WebsiteDir") ? "" : row["WebsiteDir"].ToString(),
                            row.IsNull("WebPass") ? "" : row["WebPass"].ToString());
                        client.Summaries = row.IsNull("Summaries") ? false : (bool)(row["Summaries"]);

                        if (!row.IsNull("Management") && !string.IsNullOrEmpty(row["Management"].ToString()))
                        {
                            foreach (ManagementCompany item in lstManagementCompany)
                            {
                                if (item.Name == row["Management"].ToString().Trim())
                                {
                                    client.ManagementCompany = item;
                                    break;
                                }
                            }
                        }

                        ISet<OtherAddress> otherAddresses = new HashSet<OtherAddress>();
                        string otherAddressesString = row["OtherAddresses"].ToString();
                        if (!string.IsNullOrEmpty(otherAddressesString))
                        {
                            string[] addresses = otherAddressesString.Split(GlobalConstants.RecSep);
                            foreach (string addressItem in addresses)
                            {
                                string[] items = addressItem.Split(GlobalConstants.Sep);
                                if (items.Length >= 4)
                                {
                                    string addressKind = items[2];
                                    string address = items[3];
                                    if (!string.IsNullOrEmpty(addressKind) && (!string.IsNullOrEmpty(address)))
                                    {
                                        otherAddresses.Add(new OtherAddress(addressKind, address));
                                    }
                                }
                            }
                        }
                        if (otherAddresses.Count > 0)
                        {
                            client.OtherAddresses = otherAddresses;
                        }


                        ISet<Contact> contacts = new HashSet<Contact>();
                        string contactString = row["Contacts"].ToString();
                        if (!string.IsNullOrEmpty(contactString))
                        {
                            string[] contactsArray = contactString.Split(GlobalConstants.RecSep);
                            foreach (string contactItem in contactsArray)
                            {
                                string[] items = contactItem.Split(GlobalConstants.Sep);
                                string contactType = "";
                                string contactInfo = items[2];
                                if (items.Length >= 4)
                                {
                                    contactType = items[3];
                                }
                                else
                                {
                                    contactType = "Other";
                                }

                                if (contactType == "Email")
                                {
                                    contacts.Add(new Contact(ContactType.Email, contactInfo));
                                }
                                else if (contactType == "Fax")
                                {
                                    contacts.Add(new Contact(ContactType.Fax, contactInfo));
                                }
                                else if (contactType == "Other")
                                {
                                    contacts.Add(new Contact(ContactType.Other, contactInfo));
                                }
                            }
                        }
                        if (contacts.Count > 0)
                        {
                            client.Contacts = contacts;
                        }

                        ISet<InvoiceDivision> invoiceDivisions = new HashSet<InvoiceDivision>();
                        string invoiceDivisionsString = row["InvoiceDivisions"].ToString();
                        if (!string.IsNullOrEmpty(invoiceDivisionsString))
                        {
                            string[] invoiceDivisionsArray = invoiceDivisionsString.Split(GlobalConstants.RecSep);
                            foreach (string invoiceDivisionItem in invoiceDivisionsArray)
                            {
                                string[] items = invoiceDivisionItem.Split(GlobalConstants.Sep);
                                if (items.Length >= 3)
                                {
                                    invoiceDivisions.Add(new InvoiceDivision(items[2]));
                                }
                            }
                        }
                        if (invoiceDivisions.Count > 0)
                        {
                            client.InvoiceDivisions = invoiceDivisions;
                        }

                        if (client != null && !string.IsNullOrEmpty(client.ClientName))
                        {
                            clientRepository.Add(client);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        public void InitialCustomerNumberSetting(BackgroundWorker bw)
        {
            try
            {
                CustomerNumberRespository cusNoSettingResository = new CustomerNumberRespository();

                cusNoSettingResository.RemoveAll();

                UpdateCustomerNumber();
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        public void UpdateCustomerNumber()
        {
            try
            {
                ClientRepository clientRepository = new ClientRepository();
                CustomerNumberRespository cusNoRespository = new CustomerNumberRespository();

                List<Client> lstClient = clientRepository.FindAll();

                if (lstClient.Any())
                {
                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        string lastRecord = (from client in lstClient
                                             where client.CustomerNumber.StartsWith(c.ToString())
                                             orderby client.CustomerNumber
                                             select client.CustomerNumber).Last();

                        if (!string.IsNullOrEmpty(lastRecord))
                        {
                            int lastNumber = Int32.Parse(lastRecord.Remove(0, 1));
                            if (lastNumber > 0)
                            {
                                CustomerNumberSetting cusNoSetting = new CustomerNumberSetting(c, lastNumber);
                                cusNoRespository.Add(cusNoSetting);
                            }
                            else
                            {
                                CustomerNumberSetting cusNoSetting = new CustomerNumberSetting(c, 0);
                                cusNoRespository.Add(cusNoSetting);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        public void MigrateClientInfoSpecialPrice(BackgroundWorker bw)
        {
            try
            {
                DataTable sourceReportTypesTable = new DataTable();

                ClientRepository clientRepository = new ClientRepository();
                ReportTypeRepository reportTypeRepository = new ReportTypeRepository();
                List<ReportType> lstReportType = (List<ReportType>)(reportTypeRepository.FindAll());
                List<Client> lstClient = (List<Client>)clientRepository.FindAll();

                // remove all special price
                foreach (Client client in lstClient)
                {
                    client.ClientReportSpecialPrices.Clear();
                }

                using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("select * from ReportTypes", sourceConnection);
                    sourceAdapter.Fill(sourceReportTypesTable);
                }

                foreach (DataRow row in sourceReportTypesTable.Rows)
                {
                    string typeName = row["TypeName"].ToString();
                    ReportType reportType = reportTypeRepository.FindByTypeName(typeName);
                    if (reportType == null)
                        continue;
                    string specialPrices = row.IsNull("SpecialPrices") ? "" : row["SpecialPrices"].ToString();

                    if (!string.IsNullOrEmpty(specialPrices))
                    {
                        string[] clientPrices = specialPrices.Split(GlobalConstants.RecSep);
                        foreach (string clientItem in clientPrices)
                        {
                            string[] items = clientItem.Split(GlobalConstants.Sep);
                            if (items.Length >= 4)
                            {
                                string clientName = items[2].Trim();
                                decimal price = decimal.Parse(items[3]);
                                foreach (Client client in lstClient)
                                {
                                    if (clientName == client.ClientName)
                                    {
                                        ClientReportSpecialPrice clientReportSpecialPrice = new ClientReportSpecialPrice(reportType.ReportTypeId, price);
                                        client.ClientReportSpecialPrices.Add(clientReportSpecialPrice);
                                    }
                                }
                            }
                        }
                    }
                }

                // save back
                foreach (Client client in lstClient)
                {
                    clientRepository.Update(client);
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                throw;
            }
        }

        public void MigrateInfoResource(BackgroundWorker bw)
        {
            try
            {
                DataTable sourceResourceTypeTable = new DataTable();
                DataTable sourceResourceTable = new DataTable();
                ResourceTypeRepository resourceTypeRepository = new ResourceTypeRepository();
                InfoResourceRepository resourceRepository = new InfoResourceRepository();

                resourceRepository.RemoveAll();
                resourceTypeRepository.RemoveAll();

                using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("select distinct ResourceType from InfoResources", sourceConnection);
                    sourceAdapter.Fill(sourceResourceTypeTable);
                }

                foreach (DataRow row in sourceResourceTypeTable.Rows)
                {
                    ResourceTypeId resourceTypeId = new ResourceTypeId(Guid.NewGuid().ToString());
                    ResourceType resourceType = new ResourceType(resourceTypeId, row["ResourceType"].ToString());
                    resourceTypeRepository.Add(resourceType);
                }

                using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("select * from InfoResources", sourceConnection);
                    sourceAdapter.Fill(sourceResourceTable);
                }

                List<ResourceType> lstResourceType = (List<ResourceType>)(resourceTypeRepository.FindAll());
                foreach (DataRow row in sourceResourceTable.Rows)
                {
                    ResourceId resourceId = new ResourceId(Guid.NewGuid().ToString());
                    string resourceTypeName = row["ResourceType"].ToString();
                    ResourceType resourceType = null;
                    foreach (ResourceType item in lstResourceType)
                    {
                        if (item.Name == resourceTypeName)
                        {
                            resourceType = item;
                            break;
                        }
                    }
                    if (resourceType != null && !string.IsNullOrEmpty(row["Name"].ToString()))
                    {
                        Resource resource = new Resource(resourceId, row["Name"].ToString(), row["Target"].ToString(), row["Comments"].ToString(), row["Phone"].ToString(), row["Email"].ToString(), resourceType);
                        resourceRepository.Add(resource);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        public void MigrateInfoResourceFilePath(BackgroundWorker bw)
        {
            try
            {
                ResourceTypeRepository resourceTypeRepository = new ResourceTypeRepository();
                InfoResourceRepository resourceRepository = new InfoResourceRepository();

                List<Resource> lstResources = (List<Resource>)(resourceRepository.FindAll());

                foreach (Resource resource in lstResources)
                {
                    string input = resource.Target;
                    if (!string.IsNullOrEmpty(input) &&
                    Regex.IsMatch(input,
                    @"^(?:[\w]\:|\\)(\\[a-z_\-\s0-9\.]+)+\.(txt|gif|pdf|doc|docx|xls|xlsx|dot)$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    {
                        string fileName = Path.GetFileName(input);
                        resource.Target = fileName;
                        resourceRepository.Update(resource);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        #region ZipCode Migration

        public void MigrateZipCode(BackgroundWorker bw)
        {
            DataTable zipcodeDataTable = new DataTable();

            ZipCodeRepository zipCodeRepository = new ZipCodeRepository();

            try
            {
                zipCodeRepository.RemoveAll();

                using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("select * from zipcodes", sourceConnection);
                    sourceAdapter.Fill(zipcodeDataTable);
                }

                if (zipcodeDataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in zipcodeDataTable.Rows)
                    {
                        ZipCode zc = new ZipCode(Guid.NewGuid().ToString());
                        zc.AreaCode = row["AreaCode"].ToString();
                        zc.City = row["City"].ToString();
                        zc.CityType = row["CityType"].ToString();
                        zc.County = row["County"].ToString();
                        zc.DST = Convert.ToBoolean(row["DST"]);
                        zc.GMTOffset = Convert.ToInt16(row["GMTOffset"]);
                        zc.Latitude = Convert.ToDecimal(row["Latitude"]);
                        zc.Longitude = Convert.ToDecimal(row["Longitude"]);
                        zc.State = row["State"].ToString();
                        zc.StateCode = row["StateCode"].ToString();
                        zc.TimezoneName = row["Timezone"].ToString();
                        zc.ZipCodeName = row["ZIPCode"].ToString();
                        zc.ZipCodeType = row["ZIPCodeType"].ToString();

                        zipCodeRepository.Add(zc);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

        }

        #endregion ZepCode Migration

        public void FixInvoiceDivisionForClient(BackgroundWorker bw)
        {
            try
            {
                ClientRepository clientRepository = new ClientRepository();
                List<Client> clients = clientRepository.FindAll();

                if (clients != null && clients.Count > 0)
                {
                    foreach (Client client in clients)
                    {
                        if (client.InvoiceDivisions == null || client.InvoiceDivisions.Count == 0)
                        {
                            continue;
                        }

                        bool hasChanged = false;
                        List<InvoiceDivision> invoiceDivisionList = client.InvoiceDivisions.ToList<InvoiceDivision>();
                        for (int i = invoiceDivisionList.Count; i >= 1; i--)
                        {
                            if (invoiceDivisionList[i - 1] == null
                                || invoiceDivisionList[i - 1].DivisionName == null)
                            {
                                continue;
                            }
                            if (invoiceDivisionList[i - 1].DivisionName.Trim().Length == 0
                                || invoiceDivisionList[i - 1].DivisionName.Trim().Equals("(None)"))
                            {
                                invoiceDivisionList.RemoveAt(i - 1);
                                hasChanged = true;
                            }
                        }

                        if (hasChanged)
                        {
                            client.InvoiceDivisions = new HashSet<InvoiceDivision>(invoiceDivisionList);
                            clientRepository.Update(client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        public void FixInvoiceDivisionForApplication(BackgroundWorker bw)
        {
            try
            {
                AppRepository appRepository = new AppRepository();
                List<App> apps = appRepository.FindAll();

                if (apps != null && apps.Count > 0)
                {
                    foreach (App app in apps)
                    {
                        if (app.InvoiceDivision == null || app.InvoiceDivision.Trim().Length == 0)
                        {
                            app.InvoiceDivision = "(None)";
                            appRepository.Update(app);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        public void FixInvoiceDivisionForInvoice(BackgroundWorker bw)
        {
            try
            {
                InvoiceRepository invoiceRepository = new InvoiceRepository();
                List<Invoice.Domain.Model.Invoice> invoices = invoiceRepository.FindAll();

                if (invoices != null && invoices.Count > 0)
                {
                    foreach (Invoice.Domain.Model.Invoice invoice in invoices)
                    {
                        if (!string.IsNullOrEmpty(invoice.InvoiceDivision)
                            && invoice.InvoiceDivision.Equals("(None)"))
                        {
                            invoice.InvoiceDivision = string.Empty;
                            invoice.InvoiceReference = string.Empty;
                            invoiceRepository.Update(invoice);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }
    }
}
