using Common.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Domain.Model;
using System.Net.Http;
using Newtonsoft.Json;
using TimeCard.Data;
using TimeCard.Command;

namespace TimeCard.Infrastructure.TimeCard
{
    public class TimeCardApiRepository : ApiRepository<TimeCardItemData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TimeCardApiRepository()
            : base()
        { }

        public override string Add(TimeCardItemData item)
        {
            throw new NotImplementedException();
        }

        public override void Remove(TimeCardItemData item)
        {
            throw new NotImplementedException();
        }

        public override void Update(TimeCardItemData item)
        {
            throw new NotImplementedException();
        }

        public override TimeCardItemData Find(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTimeCardWhenLogin(NewTimeCardCommand command)
        {
            try
            {
                string url = string.Format("api/timecarddate/login");

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update timecard with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void UpdateDateCardWhenLogOut(UpdateTimeCardLogOutCommand command)
        {
            try
            {
                string url = string.Format("api/timecarddate/logout");

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update timecard with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public List<TimeCardDateData> FindTimeCard(FindTimeCardCommand command)
        {
            List<TimeCardDateData> list = new List<TimeCardDateData>();
            try
            {
                string url = string.Format("api/timecarddate");
                string content = JsonConvert.SerializeObject(command);

                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<TimeCardDateData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return list;
        }

        public void UpdateTimeCard(SaveTimeCardCommand command)
        {
            try
            {
                string url = string.Format("api/timecarddate");

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update Time Card with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public DateTime? GetServerUtcTime()
        {
            DateTime? result = null;
            try
            {
                string url = string.Format("api/timecarddate/serverutctime");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<DateTime>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }
    }
}
