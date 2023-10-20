using Core.Application;
using Core.Application.Command.ClientInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PaaApi.Controllers
{
    public class WideMgtInfoController : ApiController
    {

        public HttpResponseMessage Post(SaveWideMgtInfoCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoApplicationService service = new ClientInfoApplicationService();
                service.UpdateWideManagementInfo(command);

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
