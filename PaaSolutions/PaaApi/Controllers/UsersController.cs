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
    public class UsersController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [GET("api/users")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try  
            {
                IdentityAccessQueryService identityAccessQueryService = new IdentityAccessQueryService();
                List<User> lstUser = (List<User>)identityAccessQueryService.GetAllUser();
                string jsonContent = JsonConvert.SerializeObject(lstUser);
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
                IdentityAccessQueryService identityAccessQueryService = new IdentityAccessQueryService();
                User user = identityAccessQueryService.GetUser(id);
                if (user == null)
                {
                    string message = string.Format("User with id:{0} was not found", id);
                    HttpError httpError = new HttpError(message);
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
                }
                else
                {
                    string jsonContent = JsonConvert.SerializeObject(user);
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

        public HttpResponseMessage Post(NewUserCommand command)
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessApplicationService service = new IdentityAccessApplicationService();
                string id = service.NewUser(command);
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

        public HttpResponseMessage Put(SaveUserCommand command)
        {           
            HttpResponseMessage response;
            try
            {
                IdentityAccessApplicationService service = new IdentityAccessApplicationService();
                service.SaveUser(command);
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
       

        [HttpGet]
        [GET("api/users/check/")]
        public HttpResponseMessage CheckUserName(string username)
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessQueryService identityAccessQueryService = new IdentityAccessQueryService();
                IdentityAccessApplicationService service = new IdentityAccessApplicationService();

                User user = identityAccessQueryService.GetUserByUsername(username);

                string jsonContent= "";

                if (user == null)
                {
                    jsonContent = "Username is empty or doesn't exist.";
                }
                else
                {
                    jsonContent = JsonConvert.SerializeObject(user);
                }                

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

        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessApplicationService service = new IdentityAccessApplicationService();
                service.DeleteUser(id);
               
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, true);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }

        [GET("api/users/active")]
        public HttpResponseMessage GetActiveUsers()
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessQueryService identityAccessQueryService = new IdentityAccessQueryService();
                List<User> lstUser = (List<User>)identityAccessQueryService.GetAllActiveUsers();
                string jsonContent = JsonConvert.SerializeObject(lstUser);
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
