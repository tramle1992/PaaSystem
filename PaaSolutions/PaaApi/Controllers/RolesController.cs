using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using IdentityAccess.Application.Command;
using IdentityAccess.Application;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Application.Command.Access;
using AttributeRouting.Web.Http;

namespace PaaApi.Controllers
{
    public class RolesController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [GET("api/roles")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessQueryService identityAccessQueryService = new IdentityAccessQueryService();
                List<Role> lstRole = (List<Role>)identityAccessQueryService.GetAllRole();
                string jsonContent = JsonConvert.SerializeObject(lstRole);
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
                Role role = identityAccessQueryService.GetRole(id);
                if (role == null)
                {
                    string message = string.Format("Role with id:{0} was not found", id);
                    HttpError httpError = new HttpError(message);
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
                }
                else
                {
                    string jsonContent = JsonConvert.SerializeObject(role);
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

        public HttpResponseMessage Post(NewRoleCommand command)
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessApplicationService service = new IdentityAccessApplicationService();
                string id = service.NewRole(command);
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

        public HttpResponseMessage Put(SaveRoleCommand command)
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessApplicationService service = new IdentityAccessApplicationService();
                service.SaveRole(command);
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

        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessApplicationService service = new IdentityAccessApplicationService();
                service.DeleteRole(id);
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
        [GET("api/roles/check/")]
        public HttpResponseMessage CheckRoleName(string rolename)
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessQueryService identityAccessQueryService = new IdentityAccessQueryService();
                Role role = identityAccessQueryService.GetRoleByName(rolename);                

                string jsonContent = "";

                if (role == null)
                {
                    jsonContent = "Role is empty or doesn't exist.";
                }
                else
                {
                    jsonContent = JsonConvert.SerializeObject(role);
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

        [HttpGet]
        [GET("api/roles/featurepermission/")]
        public HttpResponseMessage GetFeaturePermission()
        {
            HttpResponseMessage response;
            try
            {
                IdentityAccessQueryService identityAccessQueryService = new IdentityAccessQueryService();
                List<FeaturePermission> lst = (List<FeaturePermission>)identityAccessQueryService.GetFeaturePermissions();
                string jsonContent = JsonConvert.SerializeObject(lst);
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
