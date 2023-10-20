using Administration.Application;
using Administration.Application.Command.StandardTemplate;
using Administration.Domain.Model.StandardTemplate;
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
    public class StandardTemplatesController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [GET("api/standardtemplates")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                StandardTemplateQueryService queryService = new StandardTemplateQueryService();
                List<TemplateItem> items = (List<TemplateItem>)queryService.GetAll();
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
                    string message = "Template Items were not found";
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
        [GET("api/standardtemplates/{id}")]
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response;
            try
            {
                StandardTemplateQueryService queryService = new StandardTemplateQueryService();
                TemplateItem item = queryService.GetById(id);
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
                    string message = string.Format("Template Item with id {0} was not found", id);
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

        [HttpPost]
        [POST("api/standardtemplates")]
        public HttpResponseMessage Post(NewTemplateItemCommand command)
        {
            HttpResponseMessage response;
            try
            {
                StandardTemplateApplicationService applicationService = new StandardTemplateApplicationService();
                string id = applicationService.NewTemplateItem(command);
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
        [PUT("api/standardtemplates")]
        public HttpResponseMessage Put(SaveTemplateItemCommand command)
        {
            HttpResponseMessage response;
            try
            {
                StandardTemplateApplicationService applicationService = new StandardTemplateApplicationService();
                applicationService.SaveTemplateItem(command);
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

        [HttpPost]
        [POST("api/standardtemplates/delete")]
        public HttpResponseMessage Delete(RemoveTemplateItemCommand command)
        {
            HttpResponseMessage response;
            try
            {
                StandardTemplateApplicationService applicationService = new StandardTemplateApplicationService();
                applicationService.RemoveTemplateItem(command);
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

        [HttpPost]
        [POST("api/standardtemplates/deletemulti")]
        public HttpResponseMessage MultiDelete(RemoveMultiTemplateItemCommand commandList)
        {
            HttpResponseMessage response;
            try
            {
                StandardTemplateApplicationService applicationService = new StandardTemplateApplicationService();
                applicationService.RemoveMultiTemplateItem(commandList);
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
        [GET("api/standardtemplates/children/{id}")]
        public HttpResponseMessage GetChildren(string id)
        {
            HttpResponseMessage response;
            try
            {
                StandardTemplateQueryService queryService = new StandardTemplateQueryService();
                List<TemplateItem> items = queryService.GetChildren(id);
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
                    string message = string.Format("Template Items with parent id {0} were not found", id);
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
        [GET("api/standardtemplates/{parentId}/{name}")]
        public HttpResponseMessage Get(string parentId, string name)
        {
            HttpResponseMessage response;
            try
            {
                StandardTemplateQueryService queryService = new StandardTemplateQueryService();
                TemplateItem item = queryService.FindByParentAndName(parentId, name);
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
                    string message = string.Format("Template Item with parentId {0} and name {1} was not found", parentId, name);
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
    }

}
