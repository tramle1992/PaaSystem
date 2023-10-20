using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using AttributeRouting.Web.Http;
using IdentityAccess.Application.Command;
using IdentityAccess.Application;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Application.Command.Identity;

namespace PaaApi.Controllers
{
    public class AuthController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);        
                
        [HttpPost]
        public HttpResponseMessage Post(LoginCommand command)
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessApplicationService service = new IdentityAccessApplicationService();
                User user = service.VerifyLoginInfo(command.UserName, command.Password);

                string jsonContent = JsonConvert.SerializeObject(user);

                if (user != null)
                {
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        RequestMessage = Request,
                        Content = new StringContent("Login failed")
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
    }
}
