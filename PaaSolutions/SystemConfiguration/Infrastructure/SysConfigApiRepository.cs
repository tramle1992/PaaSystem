using Common.Infrastructure.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SystemConfiguration.Application.Command;
using SystemConfiguration.Application.Data;

namespace SystemConfiguration.Infrastructure
{
    public class SysConfigApiRepository : ApiRepository<ConfigData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SysConfigApiRepository()
            : base()
        {
        }

        public override string Add(ConfigData item)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/sysconfigs");

                NewConfigCommand command = new NewConfigCommand(item);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    newId = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    _logger.Error("Error - System Configuration Add API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return newId;
        }

        public override void Remove(ConfigData item)
        {
            try
            {
                string url = string.Format("api/sysconfigs/remove");

                RemoveConfigCommand command = new RemoveConfigCommand(item.ConfigId);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - System Configuration Remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override void Update(ConfigData item)
        {
            try
            {
                string url = string.Format("api/sysconfigs");

                SaveConfigCommand command = new SaveConfigCommand(item);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - System Configuration Update API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override ConfigData Find(string id)
        {
            ConfigData item = new ConfigData();
            try
            {
                string url = string.Format("api/sysconfigs/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<ConfigData>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - System Configuration Find API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return item;
        }
    }
}
