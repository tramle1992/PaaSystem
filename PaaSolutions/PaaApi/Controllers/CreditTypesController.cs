using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Core.Application;
using Core.Application.Data;
using Core.Application.Data.ClientInfo;

namespace PaaApi.Controllers
{
    public class CreditTypesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                List<CreditTypeData> lstCreditType = (List<CreditTypeData>)clientInfoQueryService.GetAllCreditType();
                string jsonContent = JsonConvert.SerializeObject(lstCreditType);
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
    }
}
