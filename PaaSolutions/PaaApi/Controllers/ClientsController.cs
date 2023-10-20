using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Core.Application;
using Core.Application.Data.ClientInfo;
using Core.Application.Command.ClientInfo;
using AttributeRouting.Web.Http;

namespace PaaApi.Controllers
{
    public class ClientsController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                List<ClientData> lstClient = (List<ClientData>)clientInfoQueryService.GetAllClient();
                string jsonContent = JsonConvert.SerializeObject(lstClient);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, false);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }

        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                ClientData client = clientInfoQueryService.GetClient(id);
                if (client == null)
                {
                    string message = string.Format("Report Type with id: was not found", id);
                    HttpError httpError = new HttpError(message);
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
                }
                else
                {
                    string jsonContent = JsonConvert.SerializeObject(client);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, false);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }

        public HttpResponseMessage Post(NewClientCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoApplicationService service = new ClientInfoApplicationService();
                string id = service.NewClient(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(id)
                };
            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, false);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }

        [HttpPut]
        [PUT("api/clients")]
        public HttpResponseMessage Put(SaveClientCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoApplicationService service = new ClientInfoApplicationService();
                service.SaveClient(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                };
            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, false);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }

        [HttpPut]
        [PUT("api/clients/savemulti")]
        public HttpResponseMessage MultiPut(SaveMultiClientCommand commandList)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoApplicationService service = new ClientInfoApplicationService();
                service.SaveMultiClient(commandList);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, false);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }

        [HttpGet]
        [GET("api/clientsquery/{query}")]
        public HttpResponseMessage GetByQuery(string query)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                List<ClientData> lstClient = (List<ClientData>)clientInfoQueryService.GetClientsByQuery(query);
                string jsonContent = JsonConvert.SerializeObject(lstClient);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, false);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }

        [HttpGet]
        [GET("api/clients/check/")]
        public HttpResponseMessage GetByClientName(string clientname)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                ClientData client = clientInfoQueryService.GetClientByName(clientname);

                string jsonContent = "";

                if (client != null)
                {
                    jsonContent = JsonConvert.SerializeObject(client);
                }
                else
                {
                    jsonContent = "No client found.";
                }
                
                response = Request.CreateResponse(HttpStatusCode.OK, jsonContent);
            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, false);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }

        [HttpDelete]
        [DELETE("api/clients/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoApplicationService service = new ClientInfoApplicationService();
                service.DeleteClient(id);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                };
            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, true);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }
    }
}
