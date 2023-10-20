using Common.Infrastructure.Repository;
using Invoice.Application.Command;
using Invoice.Application.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure
{
    public class InvoiceItemApiRepository : ApiRepository<InvoiceItemData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public InvoiceItemApiRepository()
            : base()
        {
        }

        public override string Add(InvoiceItemData item)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/invoiceitems/new");

                NewInvoiceItemCommand command = new NewInvoiceItemCommand(item);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    newId = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    _logger.Error("Error - Invoice Item Add API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return newId;
        }

        public void MultiAddInvoiceItems(List<InvoiceItemData> items)
        {
            try
            {
                string url = string.Format("api/invoiceitems/multinew");

                List<NewInvoiceItemCommand> commandList = new List<NewInvoiceItemCommand>(items.Count);
                foreach (InvoiceItemData item in items)
                {
                    if (!string.IsNullOrEmpty(item.InvoiceItemId)
                        && !string.IsNullOrEmpty(item.InvoiceId))
                    {
                        commandList.Add(new NewInvoiceItemCommand(item));
                    }
                }

                string content = JsonConvert.SerializeObject(new MultiNewInvoiceItemCommand(commandList));
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Item Multi Add API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override void Remove(InvoiceItemData item)
        {
            try
            {
                string url = string.Format("api/invoiceitems/remove");

                RemoveInvoiceItemCommand command = new RemoveInvoiceItemCommand(item.InvoiceItemId);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Item Remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void MultiRemoveInvoiceItems(List<InvoiceItemData> items)
        {
            try
            {
                string url = string.Format("api/invoiceitems/multiremove");

                List<RemoveInvoiceItemCommand> commandList = new List<RemoveInvoiceItemCommand>(items.Count);
                foreach (InvoiceItemData item in items)
                {
                    if (!string.IsNullOrEmpty(item.InvoiceItemId)
                        && !string.IsNullOrEmpty(item.InvoiceId))
                    {
                        commandList.Add(new RemoveInvoiceItemCommand(item.InvoiceItemId));
                    }
                }

                string content = JsonConvert.SerializeObject(new MultiRemoveInvoiceItemCommand(commandList));
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Item Multi Remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void RemoveByInvoiceId(string invoiceId)
        {
            try
            {
                string url = string.Format("api/invoiceitems/removebyinvoiceid");

                RemoveInvoiceItemByInvoiceIdCommand command = new RemoveInvoiceItemByInvoiceIdCommand(invoiceId);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Item Remove By InvoiceId API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void MultiRemoveByInvoiceId(List<string> invoiceIdList)
        {
            try
            {
                string url = string.Format("api/invoiceitems/multiremovebyinvoiceid");

                List<RemoveInvoiceItemByInvoiceIdCommand> commandList = new List<RemoveInvoiceItemByInvoiceIdCommand>(invoiceIdList.Count);
                foreach (string invoiceId in invoiceIdList)
                {
                    if (!string.IsNullOrEmpty(invoiceId))
                    {
                        commandList.Add(new RemoveInvoiceItemByInvoiceIdCommand(invoiceId));
                    }
                }

                string content = JsonConvert.SerializeObject(new MultiRemoveInvoiceItemByInvoiceIdCommand(commandList));
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Item Multi Remove By InvoiceId API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override void Update(InvoiceItemData item)
        {
            try
            {
                string url = string.Format("api/invoiceitems/save");

                SaveInvoiceItemCommand command = new SaveInvoiceItemCommand(item);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Item Update API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override InvoiceItemData Find(string id)
        {
            InvoiceItemData item = new InvoiceItemData();
            try
            {
                string url = string.Format("api/invoiceitems/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<InvoiceItemData>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Item Find API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return item;
        }

        public List<InvoiceItemData> FindByInvoiceId(string invoiceId)
        {
            List<InvoiceItemData> items = new List<InvoiceItemData>();
            try
            {
                string url = string.Format("api/invoiceitems/invoice/{0}", invoiceId);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<InvoiceItemData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Item Find By Invoice Id API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return items;
        }

        public List<InvoiceItemData> FindAll()
        {
            List<InvoiceItemData> items = new List<InvoiceItemData>();
            try
            {
                string url = string.Format("api/invoiceitems");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<InvoiceItemData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Item Find All API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return items;
        }
    }
}
