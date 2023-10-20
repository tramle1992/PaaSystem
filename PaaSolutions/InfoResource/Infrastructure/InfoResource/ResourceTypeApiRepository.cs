using Common.Infrastructure.Repository;
using InfoResource.Application.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfoResource.Infrastructure.InfoResource
{
    public class ResourceTypeApiRepository : ApiRepository<ResourceTypeData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ResourceTypeApiRepository()
            : base()
        {
        }

        public override string Add(ResourceTypeData item)
        {
            throw new NotImplementedException();
        }

        public override void Remove(ResourceTypeData item)
        {
            throw new NotImplementedException();
        }

        public override void Update(ResourceTypeData item)
        {
            throw new NotImplementedException();
        }

        public override ResourceTypeData Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<ResourceTypeData> FindAll()
        {
            List<ResourceTypeData> items = new List<ResourceTypeData>();
            try
            {
                string url = string.Format("api/resourcetypes");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<ResourceTypeData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Resource Type Find All API: " + url);
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
