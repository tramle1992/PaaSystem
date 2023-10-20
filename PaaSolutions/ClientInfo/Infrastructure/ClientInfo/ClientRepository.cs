using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Infrastructure.Repository;
using Core.Domain.Model.ClientInfo;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Common.Infrastructure.Helper;
using Core.Application.Data.ClientInfo;


namespace Core.Infrastructure.ClientInfo
{
    public class ClientRepository : Repository<Client, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ClientRepository()
        { }

        public override void Add(Client item)
        {
            try
            {
                string otherAddressesXml = "";
                string contactsXml = "";
                string invoiceDivisionsXml = "";
                string specialPriceXml = "";
                if (item.OtherAddresses.Count > 0)
                {
                    otherAddressesXml = XmlSerializationHelper.Serialize<HashSet<OtherAddress>>((HashSet<OtherAddress>)item.OtherAddresses);
                }

                if (item.Contacts.Count > 0)
                {
                    contactsXml = XmlSerializationHelper.Serialize<HashSet<Contact>>((HashSet<Contact>)item.Contacts);
                }

                if (item.InvoiceDivisions.Count > 0)
                {
                    invoiceDivisionsXml = XmlSerializationHelper.Serialize<HashSet<InvoiceDivision>>((HashSet<InvoiceDivision>)item.InvoiceDivisions);
                }

                if (item.ClientReportSpecialPrices.Count > 0)
                {
                    specialPriceXml = XmlSerializationHelper.Serialize<HashSet<ClientReportSpecialPrice>>((HashSet<ClientReportSpecialPrice>)item.ClientReportSpecialPrices);
                }

                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert client(client_id, client_name, customer_number, billing_address " +
                        ", other_addresses, phone, fax, email, since, billing_info, misc_comments, contacts " +
                        ", management_company_id, invoice_divisions, client_revoked, declination_letter " +
                        ", invoices_copies_number, credentialed, credit_type, default_deliver_reports_to " +
                        ", default_deliver_confirmation_to, default_deliver_invoices_to, default_verify_confirm_delivery " +
                        ", special_entry_info, special_criteria_info, website_dir, web_pass, summaries, client_report_special_price" +
                        ", created_at, updated_at, default_report_type_id) values (@client_id, @client_name, @customer_number, @billing_address " +
                        ", @other_addresses, @phone, @fax, @email, @since, @billing_info, @misc_comments, @contacts " +
                        ", @management_company_id, @invoice_divisions, @client_revoked, @declination_letter " +
                        ", @invoices_copies_number, @credentialed, @credit_type, @default_deliver_reports_to " +
                        ", @default_deliver_confirmation_to, @default_deliver_invoices_to, @default_verify_confirm_delivery " +
                        ", @special_entry_info, @special_criteria_info, @website_dir, @web_pass, @summaries, @client_report_special_price" +
                        ", @created_at, @updated_at, @default_report_type_id)";

                    var args = new DynamicParameters();
                    args.Add("client_id", item.ClientId.ToString());
                    args.Add("client_name", item.ClientName);
                    args.Add("customer_number", item.CustomerNumber);
                    args.Add("billing_address", item.BillingAddress);
                    args.Add("phone", item.Phone);
                    args.Add("fax", item.Fax);
                    args.Add("email", item.Email);
                    args.Add("default_report_type_id", (item.ReportTypeId == null) ? null : item.ReportTypeId.Id);
                    if (item.Since != null)
                    {
                        args.Add("since", item.Since);
                    }
                    else
                    {
                        args.Add("since", null);
                    }
                    args.Add("billing_info", item.BillingInfo);
                    args.Add("misc_comments", item.MiscComments);
                    if (item.ManagementCompany != null)
                    {
                        args.Add("management_company_id", item.ManagementCompany.ManagementCompanyId.ToString());
                    }
                    else
                    {
                        args.Add("management_company_id", null);
                    }
                    args.Add("client_revoked", item.ClientRevoked);
                    args.Add("declination_letter", item.ClientReceive.DeclinationLetter);
                    args.Add("invoices_copies_number", item.ClientReceive.InvoicesCopiesNumber);
                    args.Add("credentialed", item.ClientReceive.Credentialed);
                    if (item.CreditType != null)
                    {
                        args.Add("credit_type", item.CreditType.Value);
                    }
                    else
                    {
                        args.Add("credit_type", null);
                    }
                    args.Add("default_deliver_reports_to", item.DefaultDeliverReportsTo);
                    args.Add("default_deliver_confirmation_to", item.DefaultDeliverConfirmationsTo);
                    args.Add("default_deliver_invoices_to", item.DefaultDeliverInvoicesTo);
                    args.Add("default_verify_confirm_delivery", item.DefaultVerifyConfirmDelivery);
                    args.Add("special_entry_info", item.SpecialEntryInfo);
                    args.Add("special_criteria_info", item.SpecialCriteriaInfo);
                    args.Add("website_dir", item.WebInfo.WebsiteDir);
                    args.Add("web_pass", item.WebInfo.WebPass);
                    args.Add("summaries", item.Summaries);
                    args.Add("other_addresses", otherAddressesXml);
                    args.Add("contacts", contactsXml);
                    args.Add("invoice_divisions", invoiceDivisionsXml);
                    args.Add("client_report_special_price", specialPriceXml);
                    args.Add("created_at", DateTime.UtcNow);
                    args.Add("updated_at", DateTime.UtcNow);

                    cn.Execute(insertStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Remove(Client item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findAppStatement = @"select * from application where client_id = @client_id";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findAppStatement, new { client_id = item.ClientId });
                    
                    var listAppId = result.Select(a => a.application_id).ToList();
                    string updateStatement = @"update application set client_applied_name = @client_applied_name where application_id in @list_application_id";
                    cn.Execute(updateStatement, new { client_applied_name = item.ClientName, list_application_id = listAppId });

                    string deleteStatement = @"delete from client where client_id = @client_id";

                    cn.Execute(deleteStatement, new { client_id = item.ClientId.ToString() });                    
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(Client item)
        {
            try
            {
                string otherAddressesXml = "";
                string contactsXml = "";
                string invoiceDivisionsXml = "";
                string specialPriceXml = "";

                if (item.OtherAddresses.Count > 0)
                {
                    otherAddressesXml = XmlSerializationHelper.Serialize<HashSet<OtherAddress>>((HashSet<OtherAddress>)item.OtherAddresses);
                }

                if (item.Contacts.Count > 0)
                {
                    contactsXml = XmlSerializationHelper.Serialize<HashSet<Contact>>((HashSet<Contact>)item.Contacts);
                }

                if (item.InvoiceDivisions.Count > 0)
                {
                    invoiceDivisionsXml = XmlSerializationHelper.Serialize<HashSet<InvoiceDivision>>((HashSet<InvoiceDivision>)item.InvoiceDivisions);
                }

                if (item.ClientReportSpecialPrices.Count > 0)
                {
                    specialPriceXml = XmlSerializationHelper.Serialize<HashSet<ClientReportSpecialPrice>>((HashSet<ClientReportSpecialPrice>)item.ClientReportSpecialPrices);
                }


                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update client set client_name=@client_name, customer_number=@customer_number" +
                        ", billing_address=@billing_address, other_addresses=@other_addresses, phone=@phone, fax=@fax" +
                        ", email=@email, since=@since, billing_info=@billing_info, misc_comments=@misc_comments, contacts=@contacts " +
                        ", management_company_id=@management_company_id, invoice_divisions=@invoice_divisions" +
                        ", default_report_type_id=@default_report_type_id, client_revoked=@client_revoked, declination_letter=@declination_letter " +
                        ", invoices_copies_number=@invoices_copies_number" +
                        ", credentialed=@credentialed, credit_type=@credit_type, default_deliver_reports_to=@default_deliver_reports_to " +
                        ", default_deliver_confirmation_to=@default_deliver_confirmation_to, default_deliver_invoices_to=@default_deliver_invoices_to" +
                        ", default_verify_confirm_delivery=@default_verify_confirm_delivery, special_entry_info=@special_entry_info" +
                        ", special_criteria_info=@special_criteria_info, website_dir=@website_dir, web_pass=@web_pass, summaries=@summaries" +
                        ", client_report_special_price=@client_report_special_price, updated_at=@updated_at " +
                        " where client_id=@client_id";

                    var args = new DynamicParameters();
                    args.Add("client_id", item.ClientId.ToString());
                    args.Add("client_name", item.ClientName);
                    args.Add("customer_number", item.CustomerNumber ?? "");
                    args.Add("billing_address", item.BillingAddress ?? "");
                    args.Add("phone", item.Phone ?? "");
                    args.Add("fax", item.Fax ?? "");
                    args.Add("email", item.Email ?? "");
                    args.Add("default_report_type_id", (item.ReportTypeId == null) ? null : item.ReportTypeId.Id);
                    if (item.Since != null)
                    {
                        args.Add("since", item.Since);
                    }
                    else
                    {
                        args.Add("since", null);
                    }
                    args.Add("billing_info", item.BillingInfo ?? "");
                    args.Add("misc_comments", item.MiscComments ?? "");
                    if (item.ManagementCompany != null)
                    {
                        args.Add("management_company_id", item.ManagementCompany.ManagementCompanyId.ToString());
                    }
                    else
                    {
                        args.Add("management_company_id", null);
                    }
                    args.Add("client_revoked", item.ClientRevoked);
                    args.Add("declination_letter", item.ClientReceive.DeclinationLetter);
                    args.Add("invoices_copies_number", item.ClientReceive.InvoicesCopiesNumber);
                    args.Add("credentialed", item.ClientReceive.Credentialed);
                    if (item.CreditType != null)
                    {
                        args.Add("credit_type", item.CreditType.Value);
                    }
                    else
                    {
                        args.Add("credit_type", null);
                    }
                    args.Add("default_deliver_reports_to", item.DefaultDeliverReportsTo ?? "");
                    args.Add("default_deliver_confirmation_to", item.DefaultDeliverConfirmationsTo ?? "");
                    args.Add("default_deliver_invoices_to", item.DefaultDeliverInvoicesTo ?? "");
                    args.Add("default_verify_confirm_delivery", item.DefaultVerifyConfirmDelivery);
                    args.Add("special_entry_info", item.SpecialEntryInfo ?? "");
                    args.Add("special_criteria_info", item.SpecialCriteriaInfo ?? "");
                    args.Add("website_dir", item.WebInfo.WebsiteDir ?? "");
                    args.Add("web_pass", item.WebInfo.WebPass ?? "");
                    args.Add("summaries", item.Summaries);
                    args.Add("other_addresses", otherAddressesXml ?? "");
                    args.Add("contacts", contactsXml ?? "");
                    args.Add("invoice_divisions", invoiceDivisionsXml ?? "");
                    args.Add("client_report_special_price", specialPriceXml ?? "");
                    args.Add("updated_at", DateTime.UtcNow);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override Client Find(string id)
        {
            Client client = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select client_id, client_name, customer_number, billing_address " +
                        ", other_addresses, phone, fax, email, since, billing_info, misc_comments, contacts " +
                        ", c.management_company_id, mc.name as management_company_name, invoice_divisions, client_revoked, declination_letter " +
                        ", invoices_copies_number, credentialed, credit_type, default_deliver_reports_to " +
                        ", default_report_type_id, default_deliver_confirmation_to, default_deliver_invoices_to, default_verify_confirm_delivery " +
                        ", special_entry_info, special_criteria_info, website_dir, web_pass, summaries " +
                        ", client_report_special_price, c.created_at, c.updated_at " +
                        " from client as c left outer join management_company as mc on c.management_company_id = mc.management_company_id " +
                        " where client_id = @client_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { client_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.client_id))
                    {
                        ClientId clientId = new ClientId(id);
                        client = new Client(clientId, item.client_name);
                        client.CustomerNumber = item.customer_number;
                        client.BillingAddress = item.billing_address;
                        client.Phone = item.phone;
                        client.Fax = item.fax;
                        client.Email = item.email;
                        client.Since = Convert.ToDateTime(item.since);
                        client.BillingInfo = item.billing_info;
                        client.MiscComments = item.misc_comments;
                        client.ClientRevoked = item.client_revoked;
                        client.ClientReceive = new ClientReceive(
                            item.declination_letter,
                            item.invoices_copies_number,
                            item.credentialed);

                        if (item.credit_type != null)
                        {
                            client.CreditType = CreditType.CreateInstance(item.credit_type);
                        }
                        client.ReportTypeId = (item.default_report_type_id == null) ? null : new ReportTypeId(item.default_report_type_id);
                        client.DefaultDeliverReportsTo = item.default_deliver_reports_to;
                        client.DefaultDeliverConfirmationsTo = item.default_deliver_confirmation_to;
                        client.DefaultVerifyConfirmDelivery = item.default_verify_confirm_delivery;
                        client.SpecialEntryInfo = item.special_entry_info;
                        client.SpecialCriteriaInfo = item.special_criteria_info;
                        client.WebInfo = new WebInfo(item.website_dir, item.web_pass);
                        client.Summaries = item.summaries;
                        client.CreatedAt = item.created_at;
                        client.UpdatedAt = item.updated_at;

                        if (!string.IsNullOrEmpty(item.management_company_id) && !string.IsNullOrEmpty(item.management_company_name))
                        {
                            ManagementCompanyId managementCompanyId = new ManagementCompanyId(item.management_company_id);
                            ManagementCompany managementCompany = new ManagementCompany(managementCompanyId, item.management_company_name);
                            client.ManagementCompany = managementCompany;
                        }

                        if (!string.IsNullOrEmpty(item.other_addresses))
                        {
                            client.OtherAddresses = XmlSerializationHelper.Deserialize<HashSet<OtherAddress>>(item.other_addresses);
                        }

                        if (!string.IsNullOrEmpty(item.contacts))
                        {
                            client.Contacts = XmlSerializationHelper.Deserialize<HashSet<Contact>>(item.contacts);
                        }

                        if (!string.IsNullOrEmpty(item.invoice_divisions))
                        {
                            client.InvoiceDivisions = XmlSerializationHelper.Deserialize<HashSet<InvoiceDivision>>(item.invoice_divisions);
                        }

                        if (!string.IsNullOrEmpty(item.client_report_special_price))
                        {
                            client.ClientReportSpecialPrices = XmlSerializationHelper.Deserialize<HashSet<ClientReportSpecialPrice>>(item.client_report_special_price);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return client;
        }

        public Client FindByName(string clientName)
        {
            Client client = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select client_id, client_name, customer_number, billing_address " +
                        ", other_addresses, phone, fax, email, since, billing_info, misc_comments, contacts " +
                        ", c.management_company_id, mc.name as management_company_name, invoice_divisions, client_revoked, declination_letter " +
                        ", default_report_type_id, invoices_copies_number, credentialed, credit_type, default_deliver_reports_to " +
                        ", default_deliver_confirmation_to, default_deliver_invoices_to, default_verify_confirm_delivery " +
                        ", special_entry_info, special_criteria_info, website_dir, web_pass, summaries " +
                        ", client_report_special_price, c.created_at, c.updated_at " +
                        " from client as c left outer join management_company as mc on c.management_company_id = mc.management_company_id " +
                        " where client_name = @client_name";


                    dynamic item = cn.Query<dynamic>(findStatement, new { client_name = clientName }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.client_id))
                    {
                        ClientId clientId = new ClientId();
                        clientId.Id = item.client_id;
                        client = new Client(clientId, item.client_name);
                        client.CustomerNumber = item.customer_number;
                        client.BillingAddress = item.billing_address;
                        client.Phone = item.phone;
                        client.Fax = item.fax;
                        client.Email = item.email;
                        client.Since = Convert.ToDateTime(item.since);
                        client.BillingInfo = item.billing_info;
                        client.MiscComments = item.misc_comments;
                        client.ClientRevoked = item.client_revoked;
                        client.ClientReceive = new ClientReceive(
                            item.declination_letter,
                            item.invoices_copies_number,
                            item.credentialed);

                        if (item.credit_type != null)
                        {
                            client.CreditType = CreditType.CreateInstance(item.credit_type);
                        }
                        client.ReportTypeId = (item.default_report_type_id == null) ? null : new ReportTypeId(item.default_report_type_id);
                        client.DefaultDeliverReportsTo = item.default_deliver_reports_to;
                        client.DefaultDeliverConfirmationsTo = item.default_deliver_confirmation_to;
                        client.DefaultVerifyConfirmDelivery = item.default_verify_confirm_delivery;
                        client.DefaultDeliverInvoicesTo = item.default_deliver_invoices_to;
                        client.SpecialEntryInfo = item.special_entry_info;
                        client.SpecialCriteriaInfo = item.special_criteria_info;
                        client.WebInfo = new WebInfo(item.website_dir, item.web_pass);
                        client.Summaries = item.summaries;
                        client.CreatedAt = item.created_at;
                        client.UpdatedAt = item.updated_at;

                        if (!string.IsNullOrEmpty(item.management_company_id) && !string.IsNullOrEmpty(item.management_company_name))
                        {
                            ManagementCompanyId managementCompanyId = new ManagementCompanyId(item.management_company_id);
                            ManagementCompany managementCompany = new ManagementCompany(managementCompanyId, item.management_company_name);
                            client.ManagementCompany = managementCompany;
                        }

                        if (!string.IsNullOrEmpty(item.other_addresses))
                        {
                            client.OtherAddresses = XmlSerializationHelper.Deserialize<HashSet<OtherAddress>>(item.other_addresses);
                        }

                        if (!string.IsNullOrEmpty(item.contacts))
                        {
                            client.Contacts = XmlSerializationHelper.Deserialize<HashSet<Contact>>(item.contacts);
                        }

                        if (!string.IsNullOrEmpty(item.invoice_divisions))
                        {
                            client.InvoiceDivisions = XmlSerializationHelper.Deserialize<HashSet<InvoiceDivision>>(item.invoice_divisions);
                        }

                        if (!string.IsNullOrEmpty(item.client_report_special_price))
                        {
                            client.ClientReportSpecialPrices = XmlSerializationHelper.Deserialize<HashSet<ClientReportSpecialPrice>>(item.client_report_special_price);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return client;
        }

        public List<Client> FindAll()
        {
            List<Client> lstClient = new List<Client>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select client_id, client_name, customer_number, billing_address " +
                        ", other_addresses, phone, fax, email, since, billing_info, misc_comments, contacts " +
                        ", c.management_company_id,  mc.name as management_company_name, invoice_divisions, client_revoked, declination_letter " +
                        ", default_report_type_id, invoices_copies_number, credentialed, credit_type, default_deliver_reports_to " +
                        ", default_deliver_confirmation_to, default_deliver_invoices_to, default_verify_confirm_delivery " +
                        ", special_entry_info, special_criteria_info, website_dir, web_pass, summaries " +
                        ", client_report_special_price, c.created_at, c.updated_at " +
                        " from client as c left outer join management_company as mc on c.management_company_id = mc.management_company_id order by client_name ";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var item in result)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.client_id))
                        {
                            ClientId clientId = new ClientId(item.client_id);
                            Client client = new Client(clientId, item.client_name);
                            client.CustomerNumber = item.customer_number;
                            client.BillingAddress = item.billing_address;
                            client.Phone = item.phone;
                            client.Fax = item.fax;
                            client.Email = item.email;
                            client.Since = Convert.ToDateTime(item.since);
                            client.BillingInfo = item.billing_info;
                            client.MiscComments = item.misc_comments;
                            client.ClientRevoked = item.client_revoked;
                            client.ClientReceive = new ClientReceive(
                                item.declination_letter,
                                item.invoices_copies_number,
                                item.credentialed);
                            client.ReportTypeId = (item.default_report_type_id == null) ? null : new ReportTypeId(item.default_report_type_id);
                            client.DefaultDeliverReportsTo = item.default_deliver_reports_to;
                            client.DefaultDeliverConfirmationsTo = item.default_deliver_confirmation_to;
                            client.DefaultVerifyConfirmDelivery = item.default_verify_confirm_delivery;
                            client.DefaultDeliverInvoicesTo = item.default_deliver_invoices_to;
                            client.SpecialEntryInfo = item.special_entry_info;
                            client.SpecialCriteriaInfo = item.special_criteria_info;
                            client.WebInfo = new WebInfo(item.website_dir, item.web_pass);
                            client.Summaries = item.summaries;
                            client.CreatedAt = item.created_at;
                            client.UpdatedAt = item.updated_at;

                            if (item.credit_type != null)
                            {
                                client.CreditType = CreditType.CreateInstance(item.credit_type);
                            }

                            if (!string.IsNullOrEmpty(item.management_company_id) && !string.IsNullOrEmpty(item.management_company_name))
                            {
                                ManagementCompanyId managementCompanyId = new ManagementCompanyId(item.management_company_id);
                                ManagementCompany managementCompany = new ManagementCompany(managementCompanyId, item.management_company_name);
                                client.ManagementCompany = managementCompany;
                            }

                            if (!string.IsNullOrEmpty(item.other_addresses))
                            {
                                client.OtherAddresses = XmlSerializationHelper.Deserialize<HashSet<OtherAddress>>(item.other_addresses);
                            }

                            if (!string.IsNullOrEmpty(item.contacts))
                            {
                                client.Contacts = XmlSerializationHelper.Deserialize<HashSet<Contact>>(item.contacts);
                            }

                            if (!string.IsNullOrEmpty(item.invoice_divisions))
                            {
                                client.InvoiceDivisions = XmlSerializationHelper.Deserialize<HashSet<InvoiceDivision>>(item.invoice_divisions);
                            }

                            if (!string.IsNullOrEmpty(item.client_report_special_price))
                            {
                                client.ClientReportSpecialPrices = XmlSerializationHelper.Deserialize<HashSet<ClientReportSpecialPrice>>(item.client_report_special_price);
                            }

                            lstClient.Add(client);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }

            return lstClient;
        }

        public void RemoveAll()
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    cn.Execute(@"delete from client");
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    Client item = Find(id);
                    string findAppStatement = @"select * from application where client_id = @client_id";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findAppStatement, new { client_id = item.ClientId.ToString() });

                    var listAppId = result.Select(a => a.application_id).ToList();
                    string updateStatement = @"update application set client_applied_name = @client_applied_name where application_id in @list_application_id";
                    cn.Execute(updateStatement, new { client_applied_name = item.ClientName, list_application_id = listAppId });
                    
                    string deleteStatement = @"delete from client where client_id = @client_id";

                    cn.Execute(deleteStatement, new { client_id = id });                    
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void UpdateWideManagementInfo(ManagementWideInfoUpdates item)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                string statement = string.Format(@"update client set {0} where management_company_id = '{1}'", item.SetClause, item.ManagementCompanyData.ManagementCompanyId);

                cn.Execute(statement);
            }
        }
    }
}
