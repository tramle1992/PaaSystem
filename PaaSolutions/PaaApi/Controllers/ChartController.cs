using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using AutoDocument.Application.Data;
using Newtonsoft.Json;
using AutoDocument.Application;
using AttributeRouting;

namespace PaaApi.Controllers
{
    public class ChartController : ApiController
    {
        [HttpPost]
        [POST("api/chart/{chartTypeId}/from/{fromId}")]
        public HttpResponseMessage Post(int chartTypeId, int fromId)
        {
            HttpResponseMessage response;
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            try
            {
                string jsonResponseContent = "";
                ChartQueryService chartQueryService = new ChartQueryService();
                ChartFilterData chartFilterData = (ChartFilterData)JsonConvert.DeserializeObject< ChartFilterData>(jsonContent);
                
                if (chartTypeId == (int)ChartType.PieChartType)
                {
                    if (fromId == (int)ChartFrom.FromCommon)
                    {
                        PieChartData pieChartData = (PieChartData)chartQueryService.GetPieChartFromCommon(chartFilterData);
                        jsonResponseContent = JsonConvert.SerializeObject(pieChartData);
                    }
                    else if (fromId == (int)ChartFrom.FromApplications)
                    {
                        PieChartData pieChartData = (PieChartData)chartQueryService.GetPieChartFromApplications(chartFilterData);
                        jsonResponseContent = JsonConvert.SerializeObject(pieChartData);
                    }
                    else if (fromId == (int)ChartFrom.FromInvoices)
                    {
                        PieChartData pieChartData = (PieChartData)chartQueryService.GetPieChartFromInvoices(chartFilterData);
                        jsonResponseContent = JsonConvert.SerializeObject(pieChartData);
                    }
                }
                else if (chartTypeId == (int)ChartType.BarChartType)
                {
                    if (fromId == (int)ChartFrom.FromApplications)
                    {
                        BarChartData barChartData = (BarChartData)chartQueryService.GetBarChartFromApplications(chartFilterData);
                        jsonResponseContent = JsonConvert.SerializeObject(barChartData);
                    }
                    else if (fromId == (int)ChartFrom.FromInvoices)
                    {
                        BarChartData barChartData = (BarChartData)chartQueryService.GetBarChartFromInvoices(chartFilterData);
                        jsonResponseContent = JsonConvert.SerializeObject(barChartData);
                    }
                }
                else if (chartTypeId == (int)ChartType.LineChartType)
                {
                    if (fromId == (int)ChartFrom.FromApplications)
                    {
                        LineChartData lineChartData = (LineChartData)chartQueryService.GetLineChartFromApplications(chartFilterData);
                        jsonResponseContent = JsonConvert.SerializeObject(lineChartData);
                    }
                    else if (fromId == (int)ChartFrom.FromInvoices)
                    {
                        LineChartData lineChartData = (LineChartData)chartQueryService.GetLineChartFromInvoices(chartFilterData);
                        jsonResponseContent = JsonConvert.SerializeObject(lineChartData);
                    }
                    else if (fromId == (int)ChartFrom.FromCommon)
                    {
                        LineChartData lineChartData = (LineChartData)chartQueryService.GetLineChartFromCommon(chartFilterData);
                        jsonResponseContent = JsonConvert.SerializeObject(lineChartData);
                    }
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
