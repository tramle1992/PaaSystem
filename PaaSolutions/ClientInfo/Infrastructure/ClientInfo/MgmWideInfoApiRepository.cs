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
    public class MgmWideInfoApiRepository : ApiRepository<ManagementWideInfoUpdates, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MgmWideInfoApiRepository() : base()
        { }

        public override string Add(ManagementWideInfoUpdates item)
        {
            throw new NotImplementedException();
        }

        public override void Remove(ManagementWideInfoUpdates item)
        {
            throw new NotImplementedException();
        }

        public override ManagementWideInfoUpdates Find(string id)
        {
            throw new NotImplementedException();
        }        

        public override void Update(ManagementWideInfoUpdates data)
        {
            try
            {
                string url = string.Format("api/WideMgtInfo");

                SaveWideMgtInfoCommand command = new SaveWideMgtInfoCommand();
                command.ManagementCompanyData = data.ManagementCompanyData;
                command.SetClause = data.SetClause;

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update Wide Management Company Info with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        //public void UpdateMgtCompanyName(ManagementCompany data)
        //{
        //    try
        //    {
        //        SaveManagementCompanyCommand command = new SaveManagementCompanyCommand(data.ManagementCompanyId.Id, data.Name);

        //        string url = string.Format("api/ManagementCompanies");

        //        string content = JsonConvert.SerializeObject(command);
        //        HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            throw new Exception("Could not update Management Company Name with api: " + url);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error(ex.ToString());
        //        throw;
        //    }
        //}
    }
}
