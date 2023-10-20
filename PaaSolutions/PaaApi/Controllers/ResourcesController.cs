using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InfoResource.Application;
using System.Configuration;
using Newtonsoft.Json;
using System.Web;
using InfoResource.Infrastructure.InfoResource;
using InfoResource.Domain.Model.InfoResource;
using InfoResource.Application.Data;
using InfoResource.Application.Command;


namespace PaaApi.Controllers
{
    public class ResourcesController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                InfoResourceQueryService infoResourceQuerySerivce = new InfoResourceQueryService();
                List<ResourceData> lstResource = (List<ResourceData>)infoResourceQuerySerivce.GetAllResource();
                string jsonContent = JsonConvert.SerializeObject(lstResource);
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
                ResourceData resource = infoResourceQuerySerivce.GetResource(id);
                if (resource != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(resource);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = string.Format("Info Resource with id {0} was not found", id);
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

        public HttpResponseMessage Post(NewResourceCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InfoResourceApplicationService service = new InfoResourceApplicationService();
                string id = service.NewResource(command);
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

        public HttpResponseMessage Put(SaveResourceCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InfoResourceApplicationService service = new InfoResourceApplicationService();
                service.SaveResource(command);
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

        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage response;
            try
            {
                InfoResourceApplicationService service = new InfoResourceApplicationService();
                service.DeleteResource(id);
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