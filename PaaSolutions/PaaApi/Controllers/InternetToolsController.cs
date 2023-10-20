using Administration.Application;
using Administration.Application.Command.InternetTool;
using Administration.Domain.Model.InternetTool;
using AttributeRouting.Web.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PaaApi.Controllers
{
    public class InternetToolsController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [GET("api/internettools")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                InternetToolQueryService queryService = new InternetToolQueryService();
                List<InternetItem> items = (List<InternetItem>)queryService.GetAll();
                if (items != null && items.Count > 0)
                {
                    string jsonContent = JsonConvert.SerializeObject(items);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = "Internet Items were not found";
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

        [HttpGet]
        [GET("api/internettools/{id}")]
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response;
            try
            {
                InternetToolQueryService queryService = new InternetToolQueryService();
                InternetItem item = queryService.GetById(id);
                if (item != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(item);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = string.Format("Internet Item with id {0} was not found", id);
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

        public HttpResponseMessage Post(NewInternetItemCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InternetToolApplicationService applicationService = new InternetToolApplicationService();
                string id = applicationService.NewInternetItem(command);
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

        [HttpPut]
        [PUT("api/internettools")]
        public HttpResponseMessage Put(SaveInternetItemCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InternetToolApplicationService applicationService = new InternetToolApplicationService();
                applicationService.SaveInternetItem(command);
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

        [HttpPut]
        [PUT("api/internettools/savemulti")]
        public HttpResponseMessage MultiPut(SaveMultiInternetItemCommand commandList)
        {
            HttpResponseMessage response;
            try
            {
                InternetToolApplicationService applicationService = new InternetToolApplicationService();
                applicationService.SaveMultiInternetItem(commandList);
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
                InternetToolApplicationService applicationService = new InternetToolApplicationService();
                applicationService.RemoveInternetItem(id);
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

        [HttpGet]
        [GET("api/internettoolsquery/maxorder")]
        public HttpResponseMessage GetMaxOrder()
        {
            HttpResponseMessage response;
            try
            {
                InternetToolQueryService queryService = new InternetToolQueryService();
                int maxOrder = queryService.GetMaxOrder();
                string jsonContent = JsonConvert.SerializeObject(maxOrder);
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

        [HttpGet]
        [GET("api/internettoolsquery/itemcount")]
        public HttpResponseMessage GetItemCount()
        {
            HttpResponseMessage response;
            try
            {
                InternetToolQueryService queryService = new InternetToolQueryService();
                int itemCount = queryService.GetItemCount();
                string jsonContent = JsonConvert.SerializeObject(itemCount);
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
    }
}
