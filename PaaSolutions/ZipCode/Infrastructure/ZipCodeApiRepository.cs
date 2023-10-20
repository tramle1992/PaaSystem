using Common.Infrastructure.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZipCodeContext.Application.Data;

namespace ZipCodeContext.Infrastructure
{
    class ZipCodeApiRepository : ApiRepository<ZipCodeData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ZipCodeApiRepository()
            : base()
        { }


        public List<ZipCodeData> FindAll()
        {
            List<ZipCodeData> apps = null;
            try
            {
                string url = "api/zipcodes";

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    apps = JsonConvert.DeserializeObject<List<ZipCodeData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return apps;
        }

        public List<ZipCodeData> FindAllByColumn(string column)
        {
            List<ZipCodeData> apps = null;
            try
            {
                string url = string.Format("api/zipcodes?column={0}", column);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    apps = JsonConvert.DeserializeObject<List<ZipCodeData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return apps;
        }

        public override string Add(ZipCodeData item)
        {
            throw new NotImplementedException();
        }

        public override ZipCodeData Find(string id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(ZipCodeData item)
        {
            throw new NotImplementedException();
        }

        public override void Update(ZipCodeData item)
        {
            throw new NotImplementedException();
        }
    }
}
