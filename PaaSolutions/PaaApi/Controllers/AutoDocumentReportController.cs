using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using AttributeRouting;
using AttributeRouting.Web.Http;
using AutoDocument.Application;
using AutoDocument.Application.Data;

namespace PaaApi.Controllers
{
    public class AutoDocumentReportController : ApiController
    {
        [HttpPost]
        [POST("api/autodocumentreport/{documentReportType}")]
        public HttpResponseMessage Post(int documentReportType)
        {
            HttpResponseMessage response;
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            try
            {
                string jsonResponseContent = "";
                DocumentReportQueryService documentReportQueryService = new DocumentReportQueryService();

                if (documentReportType == DocumentReportType.DailyReportValue)
                {
                    DocumentReportDailyReportOption option = (DocumentReportDailyReportOption)JsonConvert.DeserializeObject<DocumentReportDailyReportOption>(jsonContent);
                    DocumentReportData data = documentReportQueryService.GetDailyReportData(option);
                    jsonResponseContent = JsonConvert.SerializeObject(data);
                }
                else if (documentReportType == DocumentReportType.ReceiptLogValue)
                {
                    DocumentReportReceiptLogOption option = (DocumentReportReceiptLogOption)JsonConvert.DeserializeObject<DocumentReportReceiptLogOption>(jsonContent);
                    DocumentReportData data = documentReportQueryService.GetReceiptLogData(option);
                    jsonResponseContent = JsonConvert.SerializeObject(data);
                }
                else if (documentReportType == DocumentReportType.CalendarValue)
                {
                    DocumentReportCalendarOption option = (DocumentReportCalendarOption)JsonConvert.DeserializeObject<DocumentReportCalendarOption>(jsonContent);
                }
                else if (documentReportType == DocumentReportType.MonthlyScreenerValue)
                {
                    DocumentReportMonthlyScreenerOption option = (DocumentReportMonthlyScreenerOption)JsonConvert.DeserializeObject<DocumentReportMonthlyScreenerOption>(jsonContent);
                    DocumentReportData data = documentReportQueryService.GetMonthlyScreenerData(option);
                    jsonResponseContent = JsonConvert.SerializeObject(data);
                }
                else if (documentReportType == DocumentReportType.ApplicationVolumeValue)
                {
                    DocumentReportApplicationVolumeOption option = (DocumentReportApplicationVolumeOption)JsonConvert.DeserializeObject<DocumentReportApplicationVolumeOption>(jsonContent);
                    DocumentReportData data = documentReportQueryService.GetApplicationVolumeData(option);
                    jsonResponseContent = JsonConvert.SerializeObject(data);
                }
                else if (documentReportType == DocumentReportType.YearlyBusinessValue)
                {
                    DocumentReportYearlyBusinessOption option = (DocumentReportYearlyBusinessOption)JsonConvert.DeserializeObject<DocumentReportYearlyBusinessOption>(jsonContent);
                    DocumentReportData data = documentReportQueryService.GetYearlyBusinessData(option);
                    jsonResponseContent = JsonConvert.SerializeObject(data);
                }

                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonResponseContent)
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
