using AttributeRouting.Web.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SystemConfiguration.Application;
using SystemConfiguration.Application.Command;
using SystemConfiguration.Application.Data;

namespace PaaApi.Controllers
{
    public class SysConfigsController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [GET("api/sysconfigs/{id}")]
        public HttpResponseMessage GetConfigById(string id)
        {
            HttpResponseMessage response;
            try
            {
                SysConfigQueryService queryService = new SysConfigQueryService();
                ConfigData config = queryService.Get(id);
                if (config != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(config);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = string.Format("Config with id {0} was not found", id);
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
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/sysconfigs")]
        public HttpResponseMessage NewConfig(NewConfigCommand command)
        {
            HttpResponseMessage response;
            try
            {
                SysConfigApplicationService applicationService = new SysConfigApplicationService();
                string id = applicationService.NewConfig(command);
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
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPut]
        [PUT("api/sysconfigs")]
        public HttpResponseMessage SaveConfig(SaveConfigCommand command)
        {
            HttpResponseMessage response;
            try
            {
                SysConfigApplicationService applicationService = new SysConfigApplicationService();
                applicationService.SaveConfig(command);
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
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/sysconfigs/remove")]
        public HttpResponseMessage RemoveConfig(RemoveConfigCommand command)
        {
            HttpResponseMessage response;
            try
            {
                SysConfigApplicationService applicationService = new SysConfigApplicationService();
                applicationService.RemoveConfig(command);
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
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }
    }
}
