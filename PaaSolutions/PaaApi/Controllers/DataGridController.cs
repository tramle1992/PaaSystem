using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Application;
using Core.Application.Data.ClientInfo;
using AttributeRouting.Web.Http;
using Newtonsoft.Json;
using AttributeRouting;
using Core.Application;

namespace PaaApi.Controllers
{
    public class DataGridController : ApiController
    {
        [HttpGet]
        [GET("api/datagrid/clients")]
        public HttpResponseMessage GetClientGridData()
        {
            HttpResponseMessage response;
            try
            {
                ClientGridDataQueryService clientGridDataQueryService = new ClientGridDataQueryService();
                List<ClientGridData> lstClient = (List<ClientGridData>)clientGridDataQueryService.GetAllClientGridData();
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
        [GET("api/datagrid/clients/{clientId}")]
        public HttpResponseMessage GetUserDisplayInfo(string clientId)
        {
            HttpResponseMessage response;
            try
            {
                ClientGridDataQueryService clientGridDataQueryService = new ClientGridDataQueryService();
                ClientGridData client = (ClientGridData)clientGridDataQueryService.GetClientGridData(clientId);
                string jsonContent = JsonConvert.SerializeObject(client);
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
    }
}
