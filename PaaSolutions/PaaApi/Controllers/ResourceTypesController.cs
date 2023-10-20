using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using InfoResource.Application;
using InfoResource.Application.Data;
using InfoResource.Application.Command;


namespace PaaApi.Controllers
{
    public class ResourceTypesController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                InfoResourceQueryService infoResourceQuerySerivce = new InfoResourceQueryService();
                List<ResourceTypeData> lstResourceType = (List<ResourceTypeData>)infoResourceQuerySerivce.GetAllResourceType();
                string jsonContent = JsonConvert.SerializeObject(lstResourceType);
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
                    Content = new StringContent(ex.Message)
                };
            }
            return response;
        }

        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response;
            try
            {
                InfoResourceQueryService infoResourceQuerySerivce = new InfoResourceQueryService();
                ResourceTypeData resourceType = infoResourceQuerySerivce.GetResourceType(id);
                if (resourceType != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(resourceType);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = string.Format("Resource Type with id {0} was not found", id);
                    response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(message)
                    };
                }
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.Message)
                };
            }
            return response;
        }

        public HttpResponseMessage Post(NewResourceTypeCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InfoResourceApplicationService service = new InfoResourceApplicationService();
                string id = service.NewResourceType(command);
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
                    Content = new StringContent(ex.Message)
                };
            }
            return response;
        }

        public HttpResponseMessage Put(SaveResourceTypeCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InfoResourceApplicationService service = new InfoResourceApplicationService();
                service.SaveResourceType(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.Message)
                };
            }
            return response;
        }
    }
}
