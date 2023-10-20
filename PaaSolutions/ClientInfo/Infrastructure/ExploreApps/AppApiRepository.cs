using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Repository;
using Newtonsoft.Json;
using System.Net.Http;
using Core.Infrastructure.ExploreApps;
using Core.Application.Data.ExploreApps;
using Core.Application.Command.ExploreApps;

namespace Core.Infrastructure.ExploreApps
{
    public class AppApiRepository : ApiRepository<AppData, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AppApiRepository()
            : base()
        { }

        public override string Add(AppData app)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/apps");

                NewAppCommand command = new NewAppCommand(app);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                newId = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not add an app with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            return newId;
        }

        public override void Remove(AppData app)
        {
            try
            {
                string url = string.Format("api/apps/{0}", app.ApplicationId);

                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not remove app using api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Update(AppData app)
        {
            try
            {
                string url = string.Format("api/apps");

                SaveAppCommand command = new SaveAppCommand(app);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update an app with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public List<DuplicateAppData> FindAllForCheckDuplicate()
        {
            List<DuplicateAppData> apps = null;
            try
            {
                string url = "api/apps/appscheckduplicate";

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    apps = JsonConvert.DeserializeObject<List<DuplicateAppData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return apps;
        }

        public override AppData Find(string id)
        {
            AppData app = null;

            if (string.IsNullOrEmpty(id))
                return app;

            try
            {
                string url = string.Format("api/apps/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    app = JsonConvert.DeserializeObject<AppData>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return app;
        }

        public List<AppData> FindByReceivedDate(DateTime receivedDate)
        {
            List<AppData> result = null;
            try
            {
                string url = string.Format("api/apps/receivedDate/{0}", receivedDate.ToString());

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<AppData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }

        public List<AppData> FindByLocation(string locationId)
        {
            List<AppData> result = null;
            try
            {
                string url = string.Format("api/apps/location/{0}", locationId);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<AppData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }

        public int Count(SearchAppCommand command)
        {
            int result = 0;
            try
            {
                string url = string.Format("api/apps/search/count");
                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<int>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }

        public List<AppData> Search(SearchAppCommand command)
        {
            List<AppData> result = null;
            try
            {
                string url = string.Format("api/apps/search");
                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<AppData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }

        public List<AppData> SimpleSearch(SimpleSearchAppCommand command)
        {
            List<AppData> result = null;
            try
            {
                string url = string.Format("api/apps/simplesearch");
                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<AppData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }

        public int SimpleSearchCount(SimpleSearchAppCommand command)
        {
            int result = 0;
            try
            {
                string url = string.Format("api/apps/simplesearch/count");
                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<int>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }

        public List<AppData> InvSearchApp(InvSearchAppCommand command)
        {
            List<AppData> result = new List<AppData>();
            try
            {
                string url = "api/apps/invsearchapp";
                string content = JsonConvert.SerializeObject(command);
                if (content.Contains("'"))
                {
                    content = content.Replace("'", "''");
                }
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<AppData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Search App API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }

        public List<AppData> InvGetAvailApp(InvGetAvailAppCommand command)
        {
            List<AppData> result = new List<AppData>();
            try
            {
                string url = "api/apps/invgetavailapp";
                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<AppData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Get Available App API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }

        public int InvCountAppByReceivedDate(InvCountAppByReceivedDateCommand command)
        {
            int appCount = -1;
            try
            {
                string url = "api/apps/invcountapp/receiveddate";
                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    appCount = JsonConvert.DeserializeObject<int>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Invoice Count App By Received Date API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return appCount;
        }

        public List<AppData> GetAppByIds(GetAppByIdsCommand command)
        {
            List<AppData> result = new List<AppData>();
            try
            {
                string url = "api/apps/ids";
                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<AppData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Get App By Ids API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }

        public List<AppData> GetAppBySSN(GetAppBySSNCommand command)
        {
            List<AppData> result = new List<AppData>();
            try
            {
                string url = "api/apps/ssn";
                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<AppData>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Get App By SSN API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            return result;
        }

        public void MarkAsRoommates(MarkAsRoommatesCommand command)
        {
            try
            {
                string url = string.Format("api/apps/markroommates");
                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    throw new InvalidOperationException(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

    }
}
