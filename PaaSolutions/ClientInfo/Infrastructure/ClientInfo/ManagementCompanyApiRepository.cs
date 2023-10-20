using Common.Infrastructure.Repository;
using Core.Application.Command.ClientInfo;
using Core.Application.Data.ClientInfo;
using Core.Domain.Model.ClientInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.ClientInfo
{
    public class ManagementCompanyApiRepository : ApiRepository<ManagementCompanyData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ManagementCompanyApiRepository()
            : base()
        { }

        public override string Add(ManagementCompanyData item)
        {
            string returnedId = "";
            try
            {
                NewManagementCompanyCommand command = new NewManagementCompanyCommand(item.Name);

                string url = string.Format("api/managementcompanies");               

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;               

                if (response.IsSuccessStatusCode)
                {
                    returnedId = response.Content.ReadAsStringAsync().Result;                    
                }
            }
            catch (Exception ex)
            {                
                _logger.Error(ex.ToString());
                throw;
            }
            return returnedId;
        }

        public override void Remove(ManagementCompanyData item)
        {
            throw new NotImplementedException();
        }

        public override ManagementCompanyData Find(string id)
        {
            throw new NotImplementedException();
        }

        public override void Update(ManagementCompanyData data)
        {
            try
            {
                SaveManagementCompanyCommand command = new SaveManagementCompanyCommand(data.ManagementCompanyId, data.Name);

                string url = string.Format("api/ManagementCompanies");

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update Management Company Name with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public List<ManagementCompanyData> FindAll()
        {
            List<ManagementCompanyData> lst = new List<ManagementCompanyData>();
            try
            {
                string url = string.Format("api/mgtcompany/clients");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = response.Content.ReadAsStringAsync().Result;

                    lst = JsonConvert.DeserializeObject<List<ManagementCompanyData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return lst;
        }
    }
}
