using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Application;
using Core.Domain.Model.ExploreApps;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using AttributeRouting.Web.Http;
using Core.Application.Command.ExploreApps;
using Core.Application.Data.ExploreApps;

namespace PaaApi.Controllers
{
    public class AppsController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService appQueryService = new ExploreAppsQueryService();
                AppData app = appQueryService.GetApp(id);
                if (app == null)
                {
                    string message = string.Format("App with id:{0} was not found", id);
                    HttpError httpError = new HttpError(message);
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
                }
                else
                {
                    string jsonContent = JsonConvert.SerializeObject(app);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpGet]
        [GET("api/apps/location/{locationId}")]
        public HttpResponseMessage GetByLocation(string locationId)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService appQueryService = new ExploreAppsQueryService();
                List<AppData> lstApp = appQueryService.GetAppByLocation(locationId);
                string jsonContent = JsonConvert.SerializeObject(lstApp);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpDelete]
        [DELETE("api/apps/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsApplicationService service = new ExploreAppsApplicationService();
                service.DeleteApp(id);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps")]
        public HttpResponseMessage Post(NewAppCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsApplicationService service = new ExploreAppsApplicationService();
                string id = service.NewApp(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(id)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPut]
        [PUT("api/apps")]
        public HttpResponseMessage Put(SaveAppCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsApplicationService service = new ExploreAppsApplicationService();
                service.SaveApp(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps/search")]
        public HttpResponseMessage SearchApp(SearchAppCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService service = new ExploreAppsQueryService();
                List<AppData> apps = service.SearchApp(command);
                string jsonContent = JsonConvert.SerializeObject(apps);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps/search/count")]
        public HttpResponseMessage CountApp(SearchAppCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService service = new ExploreAppsQueryService();
                int count = service.CountApp(command);
                string jsonContent = JsonConvert.SerializeObject(count);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps/simplesearch")]
        public HttpResponseMessage SimpleSearchApp(SimpleSearchAppCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService service = new ExploreAppsQueryService();
                List<AppData> apps = service.SimpleSearchApp(command);
                string jsonContent = JsonConvert.SerializeObject(apps);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps/simplesearch/count")]
        public HttpResponseMessage SimpleSearchCountApp(SimpleSearchAppCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService service = new ExploreAppsQueryService();
                int count = service.SimpleSearchCountApp(command);
                string jsonContent = JsonConvert.SerializeObject(count);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps/invsearchapp")]
        public HttpResponseMessage InvSearchApp(InvSearchAppCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService service = new ExploreAppsQueryService();
                List<AppData> apps = service.InvSearchApp(command);
                string jsonContent = JsonConvert.SerializeObject(apps);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps/invgetavailapp")]
        public HttpResponseMessage InvGetAvailApp(InvGetAvailAppCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService service = new ExploreAppsQueryService();
                List<AppData> apps = service.InvGetAvailApp(command);
                string jsonContent = JsonConvert.SerializeObject(apps);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps/invcountapp/receiveddate")]
        public HttpResponseMessage InvCountAppByReceivedDate(InvCountAppByReceivedDateCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService service = new ExploreAppsQueryService();
                int appCount = service.InvCountAppByReceivedDate(command.ReceivedFrom, command.ReceivedTo);
                string jsonContent = JsonConvert.SerializeObject(appCount);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps/ids")]
        public HttpResponseMessage GetAppByIds(GetAppByIdsCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService service = new ExploreAppsQueryService();
                List<AppData> apps = service.GetAppByIds(command.Ids);
                string jsonContent = JsonConvert.SerializeObject(apps);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps/ssn")]
        public HttpResponseMessage GetAppBySSN(GetAppBySSNCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsQueryService service = new ExploreAppsQueryService();
                List<AppData> apps = service.GetAppBySSN(command.SSNNumbers);
                string jsonContent = JsonConvert.SerializeObject(apps);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/apps/markroommates")]
        public HttpResponseMessage MarkRoommates(MarkAsRoommatesCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ExploreAppsApplicationService service = new ExploreAppsApplicationService();
                service.MarkAsRoommates(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.Message)
                };
            }
            return response;
        }

    }
}
