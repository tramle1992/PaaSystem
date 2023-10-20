using Common.Infrastructure.Repository;
using Core.Application.Command.ClientInfo;
using Core.Application.Data.ClientInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.ClientInfo
{
    public class ClientApiRepository : ApiRepository<ClientData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ClientApiRepository()
            : base()
        { }

        public override string Add(ClientData client)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/clients");

                NewClientCommand command = new NewClientCommand(client);

                string content = JsonConvert.SerializeObject(command);

                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
                newId = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not add a client with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return newId;
        }

        public override void Remove(ClientData client)
        {
            try
            {
                string url = string.Format("api/clients/{0}", client.ClientId);

                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not remove a client with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Update(ClientData client)
        {
            try
            {
                string url = string.Format("api/clients");

                SaveClientCommand command = new SaveClientCommand(client.ClientId, client);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update a client with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void UpdateMulti(List<ClientData> clientList)
        {
            try
            {
                string url = string.Format("api/clients/savemulti");

                List<SaveClientCommand> commandList = new List<SaveClientCommand>();

                foreach (ClientData client in clientList)
                {
                    commandList.Add(new SaveClientCommand(
                            client.ClientId,
                            client
                        ));
                }

                string content = JsonConvert.SerializeObject(new SaveMultiClientCommand(commandList));
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update list client with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override ClientData Find(string id)
        {
            ClientData client = null;
            try
            {
                string url = string.Format("api/clients/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    client = JsonConvert.DeserializeObject<ClientData>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return client;
        }

        public List<ClientData> FindAll()
        {
            List<ClientData> lstClient = new List<ClientData>();
            try
            {
                string url = string.Format("api/clients");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    lstClient = JsonConvert.DeserializeObject<List<ClientData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return lstClient;
        }

        public ClientData FindByName(string clientName)
        {
            ClientData client = null;
            try
            {
                string url = string.Format("api/clients/check/?clientname={0}", WebUtility.UrlEncode(clientName));

                System.Net.Http.HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var result = JsonConvert.DeserializeObject<dynamic>(jsonContent.ToString());
                        client = JsonConvert.DeserializeObject<ClientData>(result);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return client;
        }

        public string GetNewCustomerNumber(string letter)
        {
            string result = "";
            try
            {
                if (letter.Length > 1)
                {
                    letter = letter[0].ToString();
                }

                string url = string.Format("api/displayinfo/newcustno/{0}", letter);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;

                    result = jsonContent;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return result;
        }

        public void UpdateCustomerNumber(string letter, int number)
        {
            try
            {
                string url = string.Format("api/displayinfo/newcustno/" + letter);

                SaveCustomerNumerCommand command = new SaveCustomerNumerCommand();
                command.LastNumber = number;
                command.Letter = letter;

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public List<ClientMailsDisplayInfoData> GetClientMails()
        {
            List<ClientMailsDisplayInfoData> lstClientMails = new List<ClientMailsDisplayInfoData>();
            try
            {
                string url = string.Format("api/displaymailinfo/clients");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    lstClientMails = JsonConvert.DeserializeObject<List<ClientMailsDisplayInfoData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return lstClientMails;
        }

        public List<string> GetCustomerNumbers()
        {
            List<string> lstCustomerNumbers = new List<string>();
            try
            {
                string url = string.Format("api/displayinfo/customernumber");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    lstCustomerNumbers = JsonConvert.DeserializeObject<List<string>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return lstCustomerNumbers;
        }

        public List<string> GetInvoiceDivisions()
        {
            List<string> lstInvoiceDivisions = new List<string>();
            try
            {
                string url = string.Format("api/displayinfo/invoicedivision");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    lstInvoiceDivisions = JsonConvert.DeserializeObject<List<string>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return lstInvoiceDivisions;
        }
    }
}
