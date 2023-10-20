using Common.Infrastructure.Repository;
using Core.Application.Command.ClientInfo;
using Core.Application.Data.ClientInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.ClientInfo
{
    public class ReportTypeApiRepository : ApiRepository<ReportTypeData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReportTypeApiRepository()
            : base()
        { }

        public override string Add(ReportTypeData item)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/reporttypes");

                NewReportTypeCommand command = new NewReportTypeCommand(item.TypeName, item.AbsoluteTypeName, item.DefaultPrice);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                newId = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Report Type Add API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return newId;
        }

        public override void Remove(ReportTypeData item)
        {
            try
            {
                string url = string.Format("api/reporttypes/{0}", item.ReportTypeId);

                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Report Type Remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override void Update(ReportTypeData item)
        {
            try
            {
                string url = string.Format("api/reporttypes");

                SaveReportTypeCommand command = new SaveReportTypeCommand(item.ReportTypeId, item.TypeName, item.AbsoluteTypeName, item.DefaultPrice);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Report Type Update API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override ReportTypeData Find(string id)
        {
            ReportTypeData reportType = null;

            if (string.IsNullOrEmpty(id))
            {
                return reportType;
            }

            try
            {
                string url = string.Format("api/reporttypes/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    reportType = JsonConvert.DeserializeObject<ReportTypeData>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Report Type Find API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return reportType;
        }

        public List<ReportTypeData> FindAll()
        {
            List<ReportTypeData> lst = new List<ReportTypeData>();
            try
            {
                string url = string.Format("api/reporttypes");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    lst = JsonConvert.DeserializeObject<List<ReportTypeData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Report Type Find All API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return lst;
        }

        public ReportTypeData FindByTypeName(string typeName)
        {
            ReportTypeData reportType = null;
            try
            {
                string url = string.Format("api/reporttypes/getbytypename/{0}", typeName);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    reportType = JsonConvert.DeserializeObject<ReportTypeData>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Report Type Find By TypeName API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return reportType;
        }
    }
}
