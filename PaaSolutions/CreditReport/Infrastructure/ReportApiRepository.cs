using Common.Infrastructure.Repository;
using CreditReport.Application.Command;
using CreditReport.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CreditReport.Infrastructure
{
    public class ReportApiRepository : ApiRepository<Report, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReportApiRepository()
            : base()
        { }

        public override string Add(Report report)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/reports");

                NewReportCommand command = new NewReportCommand(report);

                string content = JsonConvert.SerializeObject(command);

                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
                newId = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not add a report with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return newId;
        }

        public override void Remove(Report report)
        {
            try
            {
                string url = string.Format("api/reports/{0}", report.ReportId);

                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not remove a report with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Update(Report report)
        {
            try
            {
                string url = string.Format("api/reports");

                //SaveClientCommand command = new SaveClientCommand(client.ClientId, client);

                //string content = JsonConvert.SerializeObject(command);
                //HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                //if (!response.IsSuccessStatusCode)
                //{
                //    throw new Exception("Could not update a client with api: " + url);
                //}
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override Report Find(string id)
        {
            Report report = null;
            try
            {
                string url = string.Format("api/reports/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    report = JsonConvert.DeserializeObject<Report>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return report;
        }

        public List<Report> FindByAppId(string appId)
        {
            List<Report> lstReport = null;
            try
            {
                string url = string.Format("api/reports/findByAppId/?appId={0}", appId);

                System.Net.Http.HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var result = JsonConvert.DeserializeObject<dynamic>(jsonContent.ToString());
                        lstReport = JsonConvert.DeserializeObject<List<Report>>(result);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return lstReport;
        }

        public Report FindByReportAndAppId(string reportId, string appId)
        {
            Report lstReport = null;
            try
            {
                string url = string.Format("api/reports/findByReportAndAppId/reportId/{0}/appId/{1}", reportId, appId);

                System.Net.Http.HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var result = JsonConvert.DeserializeObject<dynamic>(jsonContent.ToString());
                        lstReport = JsonConvert.DeserializeObject<Report>(result);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return lstReport;
        }

        public List<Report> FindByDate(string date, string timezone)
        {
            List<Report> lstReport = null;
            try
            {
                timezone = timezone.Replace("/", "!");
                date = date.Replace("/", "!");

                string url = string.Format("api/reports/findByDate/tz/{0}/date/{1}", timezone, date);

                System.Net.Http.HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var result = JsonConvert.DeserializeObject<dynamic>(jsonContent.ToString());
                        lstReport = JsonConvert.DeserializeObject<List<Report>>(result);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return lstReport;
        }
    }
}
