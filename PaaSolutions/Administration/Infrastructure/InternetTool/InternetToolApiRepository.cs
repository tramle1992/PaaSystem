using Administration.Application.Command.InternetTool;
using Administration.Domain.Model.InternetTool;
using Common.Infrastructure.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Infrastructure.InternetTool
{
    public class InternetToolApiRepository : ApiRepository<InternetItem, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public InternetToolApiRepository()
            : base()
        {
        }

        public override string Add(InternetItem item)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/internettools");

                NewInternetItemCommand command = new NewInternetItemCommand(item.Caption, item.Target,
                    item.Image, item.Order);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                newId = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Internet Tool Add API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return newId;
        }

        public override void Remove(InternetItem item)
        {
            try
            {
                string url = string.Format("api/internettools/{0}", item.InternetItemId.Id);

                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Internet Tool Remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override void Update(InternetItem item)
        {
            try
            {
                string url = string.Format("api/internettools");

                SaveInternetItemCommand command = new SaveInternetItemCommand(item.InternetItemId.Id, item.Caption,
                    item.Target, item.Image, item.Order);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Internet Tool Update API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void MultiUpdate(List<InternetItem> itemList)
        {
            try
            {
                string url = string.Format("api/internettools/savemulti");

                List<SaveInternetItemCommand> commandList = new List<SaveInternetItemCommand>(itemList.Count);
                foreach (InternetItem item in itemList)
                {
                    commandList.Add(new SaveInternetItemCommand(item.InternetItemId.Id, item.Caption,
                        item.Target, item.Image, item.Order));
                }

                string content = JsonConvert.SerializeObject(new SaveMultiInternetItemCommand(commandList));
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Internet Tool multi-update API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override InternetItem Find(string id)
        {
            InternetItem item = null;
            try
            {
                string url = string.Format("api/internettools/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<InternetItem>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Internet Tool Find API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return item;
        }

        public IList<InternetItem> FindAll()
        {
            List<InternetItem> items = new List<InternetItem>();
            try
            {
                string url = string.Format("api/internettools");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<InternetItem>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Internet Tool Find All API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return items;
        }

        public int FindMaxOrder()
        {
            int maxOrder = 0;
            try
            {
                string url = string.Format("api/internettoolsquery/maxorder");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    maxOrder = JsonConvert.DeserializeObject<int>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Internet Tool Find 'max-order' API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return maxOrder;
        }

        public int GetItemCount()
        {
            int itemCount = 0;
            try
            {
                string url = string.Format("api/internettoolsquery/itemcount");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    itemCount = JsonConvert.DeserializeObject<int>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Internet Tool 'get item count' API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return itemCount;
        }
    }
}
