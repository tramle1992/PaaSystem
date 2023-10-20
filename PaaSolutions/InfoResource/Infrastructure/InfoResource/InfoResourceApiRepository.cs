
using Common.Infrastructure.Repository;
using InfoResource.Application.Command;
using InfoResource.Application.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoResource.Infrastructure.InfoResource;
using System.Net.Http;

namespace InfoResource.Infrastructure.InfoResource
{
    // Test Git
    public class InfoResourceApiRepository : ApiRepository<ResourceData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public InfoResourceApiRepository()
            : base()
        {
        }

        public override string Add(ResourceData item)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/resources");

                NewResourceCommand command = new NewResourceCommand(item.ResourceTypeData.ResourceTypeId, item.Name, item.Target, item.Comment, item.Phone, item.Email);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                newId = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Info Resource Add API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return newId;
        }

        public override void Remove(ResourceData item)
        {
            try
            {
                string url = string.Format("api/resources/{0}", item.ResourceId);

                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Info Resource Remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override void Update(ResourceData item)
        {
            try
            {
                string url = string.Format("api/resources");

                SaveResourceCommand command = new SaveResourceCommand(item.ResourceId, item);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Info Resource Update API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override ResourceData Find(string id)
        {
            ResourceData item = null;
            try
            {
                string url = string.Format("api/resources/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<ResourceData>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Info Resource Find API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return item;
        }

        public IList<ResourceData> FindAll()
        {
            List<ResourceData> items = new List<ResourceData>();
            try
            {
                string url = string.Format("api/resources");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<ResourceData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Info Resource Find All API: " + url);
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
