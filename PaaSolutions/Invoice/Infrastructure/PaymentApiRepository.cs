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
    public class PaymentApiRepository : ApiRepository<PaymentData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PaymentApiRepository()
            : base()
        {
        }

        public override string Add(PaymentData item)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/payments");

                NewPaymentCommand command = new NewPaymentCommand(item);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    newId = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    _logger.Error("Error - Payment Add API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return newId;
        }

        public override void Remove(PaymentData item)
        {
            try
            {
                string url = string.Format("api/payments/remove");

                RemovePaymentCommand command = new RemovePaymentCommand(item.PaymentId);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Payment Remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void RemoveByInvoiceId(PaymentData item)
        {
            try
            {
                string url = string.Format("api/payments/removebyinvoiceid");

                RemovePaymentByInvoiceIdCommand command = new RemovePaymentByInvoiceIdCommand(item.InvoiceId);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Payment Remove By InvoiceId API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void MultiRemoveByInvoiceId(List<InvoiceData> items)
        {
            try
            {
                string url = string.Format("api/payments/multiremovebyinvoiceid");

                List<RemovePaymentByInvoiceIdCommand> commandList = new List<RemovePaymentByInvoiceIdCommand>(items.Count);
                foreach (InvoiceData item in items)
                {
                    if (!string.IsNullOrEmpty(item.InvoiceId))
                    {
                        commandList.Add(new RemovePaymentByInvoiceIdCommand(item.InvoiceId));
                    }
                }

                string content = JsonConvert.SerializeObject(new MultiRemovePaymentByInvoiceIdCommand(commandList));
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Payment Multi Remove By InvoiceId API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override void Update(PaymentData item)
        {
            try
            {
                string url = string.Format("api/payments");

                SavePaymentCommand command = new SavePaymentCommand(item);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Payment Update API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override PaymentData Find(string id)
        {
            PaymentData item = new PaymentData();
            try
            {
                string url = string.Format("api/payments/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<PaymentData>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Payment Find API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return item;
        }

        public List<PaymentData> FindByInvoiceId(string invoiceId)
        {
            List<PaymentData> items = new List<PaymentData>();
            try
            {
                string url = string.Format("api/payments/invoice/{0}", invoiceId);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<PaymentData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Payment Find By Invoice Id API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return items;
        }

        public List<PaymentData> FindAll()
        {
            List<PaymentData> items = new List<PaymentData>();
            try
            {
                string url = string.Format("api/payments");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<PaymentData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Payment Find All API: " + url);
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
