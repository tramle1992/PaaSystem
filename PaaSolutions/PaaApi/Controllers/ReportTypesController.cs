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
using AttributeRouting.Web.Http;


namespace PaaApi.Controllers
{
    public class ReportTypesController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [GET("api/reporttypes")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                List<ReportTypeData> lstReportType = (List<ReportTypeData>)clientInfoQueryService.GetAllReportType();
                string jsonContent = JsonConvert.SerializeObject(lstReportType);
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
        [GET("api/reporttypes/{id}")]
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                ReportTypeData reportType = clientInfoQueryService.GetReportType(id);
                if (reportType != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(reportType);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = string.Format("Report Type with id {0} was not found", id);
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
        [GET("api/reporttypes/getbytypename/{typeName}")]
        public HttpResponseMessage GetByTypeName(string typeName)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                ReportTypeData reportType = clientInfoQueryService.GetReportTypeByTypeName(typeName);
                if (reportType != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(reportType);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = string.Format("Report Type with type name {0} was not found", typeName);
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

        public HttpResponseMessage Post(NewReportTypeCommand command)
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoApplicationService service = new ClientInfoApplicationService();
                string id = service.NewReportType(command);
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

        public HttpResponseMessage Put(SaveReportTypeCommand command)
        {
            HttpResponseMessage response;
            try
            {                
                ClientInfoApplicationService service = new ClientInfoApplicationService();
                service.SaveReportType(command);
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
                ClientInfoApplicationService service = new ClientInfoApplicationService();
                service.DeleteReportType(id);
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
    }
}
