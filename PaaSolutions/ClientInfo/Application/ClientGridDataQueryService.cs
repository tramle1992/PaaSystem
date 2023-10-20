using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Query;
using Core.Application;
using Core.Domain.Model.ClientInfo;
using Core.Application.Data.ClientInfo;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using Common.Infrastructure.Helper;
using System.Data;
using Dapper;

namespace Core.Application
{
    public class ClientGridDataQueryService : QueryService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IList<ClientGridData> GetAllClientGridData()
        {
            List<ClientGridData> lstClientGridData = new List<ClientGridData>();
            try 
	        {	        
		        using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select client_id, client_name, billing_address " +
                        ", phone, fax, email, billing_info, misc_comments, contacts " +
                        ", mc.name as management_name " +
                        " from client as c left outer join management_company as mc on c.management_company_id = mc.management_company_id ";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var item in result)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.client_id))
                        {
                            ClientGridData client = new ClientGridData();
                            client.ClientId = item.client_id;
                            client.ClientName = item.client_name;
                            client.ManagementName = item.management_name;
                            client.BillingAddress = item.billing_address;
                            client.Phone = item.phone;
                            client.Fax = item.fax;
                            client.Email = item.email;
                            client.BillingInfo = item.billing_info;
                            client.MiscComments = item.misc_comments;
                            client.LastScreening = DateTime.UtcNow;
                            client.NumOfScreening = 100;
                            if (!string.IsNullOrEmpty(item.contacts))
                            {
                                ISet<Contact> contacts = XmlSerializationHelper.Deserialize<HashSet<Contact>>(item.contacts);
                                foreach (Contact contact in contacts)
                                {
                                    client.Contacts.Add(ClientInfoObjectConversionService.ToContactData(contact));
                                }
                            }
                            lstClientGridData.Add(client);
                        }
                    }
                }
	        }
	        catch (SqlException ex)
	        {
		        _logger.Error(ex);
		        throw;
	        }

            return lstClientGridData;
        }

        public ClientGridData GetClientGridData(string id)
        {
            ClientGridData client = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    string findStatement = @"select client_id, client_name, billing_address " +
                        ", phone, fax, email, billing_info, misc_comments, contacts " +
                        ", mc.name as management_name " +
                        " from client as c left outer join management_company as mc on c.management_company_id = mc.management_company_id " +
                        " where client_id = @client_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { client_id = id }).FirstOrDefault();

                    if (item != null && !string.IsNullOrEmpty(item.client_id))
                    {
                        client = new ClientGridData();
                        client.ClientId = item.client_id;
                        client.ClientName = item.client_name;
                        client.ManagementName = item.management_name;
                        client.BillingAddress = item.billing_address;
                        client.Phone = item.phone;
                        client.Fax = item.fax;
                        client.Email = item.email;
                        client.BillingInfo = item.billing_info;
                        client.MiscComments = item.misc_comments;
                        client.LastScreening = item.updated_at;
                        client.NumOfScreening = 100;
                        if (!string.IsNullOrEmpty(item.contacts))
                        {
                            ISet<Contact> contacts = XmlSerializationHelper.Deserialize<HashSet<Contact>>(item.contacts);
                            foreach (Contact contact in contacts)
                            {
                                client.Contacts.Add(ClientInfoObjectConversionService.ToContactData(contact));
                            }
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
        
    }
}
