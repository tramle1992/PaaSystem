using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Core.Application;
using AttributeRouting.Web.Http;
using CreditReport.Application;
using CreditReport.Domain.Model;
using CreditReport.Application.Command;
using CreditReport.Application.Data;

namespace PaaApi.Controllers
{
    public class ReportController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [POST("api/reports")]
        public HttpResponseMessage Post(NewReportCommand command)
        {
            HttpResponseMessage response;
            try
            {
                CreditReportApplicationService service = new CreditReportApplicationService();
                string id = service.NewReport(command);
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

        [HttpGet]
        [GET("api/reports/findByAppId/")]
        public HttpResponseMessage GetReportByAppId(string appId)
        {
            HttpResponseMessage response;
            try
            {
                CreditReporQueryService creditReporQueryService = new CreditReporQueryService();
                List<Report> lstReport = creditReporQueryService.GetReportByAppId(appId);

                string jsonContent = "";

                if (lstReport != null)
                {
                    jsonContent = JsonConvert.SerializeObject(lstReport);
                }
                else
                {
                    jsonContent = "No report found.";
                }

                response = Request.CreateResponse(HttpStatusCode.OK, jsonContent);
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
        [GET("api/reports/findByReportAndAppId/reportId/{reportId}/appId/{appId}")]
        public HttpResponseMessage GetReportByAppId(string reportId, string appId)
        {
            HttpResponseMessage response;
            try
            {
                CreditReporQueryService creditReporQueryService = new CreditReporQueryService();
                Report report = creditReporQueryService.GetReportByReportAndAppId(reportId, appId);

                string jsonContent = "";

                if (report != null)
                {
                    jsonContent = JsonConvert.SerializeObject(report);
                }
                else
                {
                    jsonContent = "No report found.";
                }

                response = Request.CreateResponse(HttpStatusCode.OK, jsonContent);
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
        [GET("api/reports/findByDate/tz/{timezone}/date/{date}")]
        public HttpResponseMessage GetReportByDateId(string timezone, string date)
        {
            HttpResponseMessage response;
            try
            {
                timezone = timezone.Replace("!", "/");
                date = date.Replace("!", "/");

                CreditReporQueryService creditReporQueryService = new CreditReporQueryService();
                List<Report> lstReport = creditReporQueryService.GetReportByDate(date, timezone);
                List<ReportLightweightData> lwReports = new List<ReportLightweightData>();
                foreach (var item in lstReport)
                {
                    var lwItem = AutoMapper.Mapper.Map<Report, ReportLightweightData>(item);
                    lwReports.Add(lwItem);
                }

                string jsonContent = "";

                if (lstReport != null)
                {
                    jsonContent = JsonConvert.SerializeObject(lwReports);
                }
                else
                {
                    jsonContent = "No report found.";
                }

                response = Request.CreateResponse(HttpStatusCode.OK, jsonContent);
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
