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

namespace PaaApi.Controllers
{
    public class ManagementCompaniesController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);        

        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                List<ManagementCompanyData> lstManagementCompany = (List<ManagementCompanyData>)clientInfoQueryService.GetAllManagementCompany();
                string jsonContent = JsonConvert.SerializeObject(lstManagementCompany);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
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

        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                ManagementCompanyData managementCompany = clientInfoQueryService.GetManagementCompany(id);
                if (managementCompany == null)
                {
                    string message = string.Format("Management Company with id: was not found", id);
                    HttpError httpError = new HttpError(message);
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
                }
                else
                {
                    string jsonContent = JsonConvert.SerializeObject(managementCompany);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
            }
            catch (Exception ex)
            {                
                HttpError httpError = new HttpError(ex, true);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);                
            }
            return response;
        }

        public HttpResponseMessage Post(NewManagementCompanyCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoApplicationService service = new ClientInfoApplicationService();
                string id = service.NewManagementCompany(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(id)
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

        public HttpResponseMessage Put(SaveManagementCompanyCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoApplicationService service = new ClientInfoApplicationService();
                service.SaveManagementCompany(command);
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
