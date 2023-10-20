using Common.Infrastructure.Repository;
using Core.Application.Data.ExploreApps;
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
    public class InvoiceApiRepository : ApiRepository<InvoiceData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public InvoiceApiRepository()
            : base()
        {
        }

        public override string Add(InvoiceData item)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/invoices");

                NewInvoiceCommand command = new NewInvoiceCommand(item);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    newId = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    _logger.Error("Error - Invoice Add API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return newId;
        }

        public override void Remove(InvoiceData item)
        {
            try
            {
                string url = string.Format("api/invoices/remove");

                RemoveInvoiceCommand command = new RemoveInvoiceCommand(item.InvoiceId);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void MultiRemove(List<InvoiceData> items)
        {
            try
            {
                string url = string.Format("api/invoices/multiremove");

                List<RemoveInvoiceCommand> commandList = new List<RemoveInvoiceCommand>(items.Count);
                foreach (InvoiceData item in items)
                {
                    if (!string.IsNullOrEmpty(item.InvoiceId))
                    {
                        commandList.Add(new RemoveInvoiceCommand(item.InvoiceId));
                    }
                }

                string content = JsonConvert.SerializeObject(new MultiRemoveInvoiceCommand(commandList));
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Multi Remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void UpdateActionStatus(InvoiceData item)
        {
            try
            {
                string url = string.Format("api/invoices/saveactionstatus");

                SaveInvoiceCommand command = new SaveInvoiceCommand(item);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Update Action Status API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override void Update(InvoiceData item)
        {
            try
            {
                string url = string.Format("api/invoices/save");

                SaveInvoiceCommand command = new SaveInvoiceCommand(item);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Update API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void MultiUpdate(List<InvoiceData> items)
        {
            try
            {
                string url = string.Format("api/invoices/multisave");

                List<SaveInvoiceCommand> commandList = new List<SaveInvoiceCommand>(items.Count);
                foreach (InvoiceData item in items)
                {
                    if (!string.IsNullOrEmpty(item.InvoiceId))
                    {
                        commandList.Add(new SaveInvoiceCommand(item));
                    }
                }

                string content = JsonConvert.SerializeObject(new MultiSaveInvoiceCommand(commandList));
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Invoice Multi Update API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override InvoiceData Find(string id)
        {
            InvoiceData item = new InvoiceData();
            try
            {
                string url = string.Format("api/invoices/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<InvoiceData>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Find API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return item;
        }

        public List<InvoiceData> FindAll()
        {
            List<InvoiceData> items = new List<InvoiceData>();
            try
            {
                string url = string.Format("api/invoices");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<InvoiceData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Find All API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return items;
        }

        public List<InvoiceData> FindByYearAndMonth(int year, int month, string timezone)
        {
            List<InvoiceData> items = new List<InvoiceData>();
            try
            {
                timezone = timezone.Replace("/", "!");

                string url = string.Format("api/invoices/query/tz/{2}/year/{0}/month/{1}", year, month, timezone);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<InvoiceData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Find By Year And Month API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return items;
        }

        public DateTime FindMaxInvoiceDate()
        {
            DateTime maxInvoiceDate = DateTime.UtcNow;
            try
            {
                string url = "api/invoices/query/maxinvoicedate";

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    maxInvoiceDate = JsonConvert.DeserializeObject<DateTime>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Find Max Invoice Date API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return maxInvoiceDate;
        }

        public int FindMaxInvoiceNumberByYearAndMonth(int year, int month, string timezone)
        {
            int maxInvoiceNumber = -1;
            try
            {
                timezone = timezone.Replace("/", "!");

                string url = string.Format("api/invoices/query/maxinvoicenumber/tz/{2}/year/{0}/month/{1}", year, month, timezone);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    maxInvoiceNumber = JsonConvert.DeserializeObject<int>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Find Max Invoice Number By Year And Month API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return maxInvoiceNumber;
        }

        public int FindInvoiceCountByYearAndMonth(int year, int month, string timezone)
        {
            int invoiceCount = -1;
            try
            {
                timezone = timezone.Replace("/", "!");

                string url = string.Format("api/invoices/query/invoicecount/tz/{2}/year/{0}/month/{1}", year, month, timezone);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    invoiceCount = JsonConvert.DeserializeObject<int>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Find Invoice Count By Year And Month API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return invoiceCount;
        }

        public BillingValidationStatsData FindBillingValidationStats(int year, int month, string timezone)
        {
            timezone = timezone.Replace("/", "!");

            BillingValidationStatsData data = new BillingValidationStatsData();
            try
            {
                string url = string.Format("api/invoices/query/billingvalidationstats/tz/{2}/year/{0}/month/{1}", year, month, timezone);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<BillingValidationStatsData>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Find Billing Validation Stats API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return data;
        }

        public List<InvoiceData> SearchInvoice(SearchInvoiceCommand command)
        {
            List<InvoiceData> items = new List<InvoiceData>();
            try
            {
                string url = string.Format("api/invoices/search");

                string content = JsonConvert.SerializeObject(command);
                if (content.Contains("'"))
                {
                    content = content.Replace("'", "''");
                }
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<InvoiceData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Search API: " + url);
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
