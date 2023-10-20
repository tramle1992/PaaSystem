using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using AttributeRouting.Web.Http;
using System.Net.Http;
using ZipCodeContext.Application;
using ZipCodeContext.Application.Data;
using Newtonsoft.Json;
using System.Net;

namespace PaaApi.Controllers
{
    public class ZipCodeController : ApiController
    {
        //
        // GET: /ZipCode/
        [GET("api/zipcodes")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                ZipCodeQueryService zcQueryService = new ZipCodeQueryService();
                List<ZipCodeData> zipCodeDataList = new List<ZipCodeData>();
                zipCodeDataList = zcQueryService.GetAll();

                string jsonContent = JsonConvert.SerializeObject(zipCodeDataList);
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

        //
        // GET: /ZipCode/
        [GET("api/zipcodes")]
        public HttpResponseMessage Get(string column)
        {
            HttpResponseMessage response;
            try
            {
                ZipCodeQueryService zcQueryService = new ZipCodeQueryService();
                List<ZipCodeData> zipCodeDataList = new List<ZipCodeData>();
                zipCodeDataList = zcQueryService.GetAllByColumn(column);

                string jsonContent = JsonConvert.SerializeObject(zipCodeDataList);
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
