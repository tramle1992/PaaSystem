using AttributeRouting.Web.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace PaaApi.Controllers
{
    public class TemplatesController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string TemplatePath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["WordTemplate"];

        [HttpPost]
        [POST("api/templates")]
        public HttpResponseMessage DownloadTemplates(HttpRequestMessage request)
        {
            HttpResponseMessage response;
            try
            {
                string templateName = JsonConvert.DeserializeObject<String>(request.Content.ReadAsStringAsync().Result);

                string filePath = TemplatePath + templateName;

                var ms = new MemoryStream();
                ms.Position = 0;
                // processing the stream.

                if (!File.Exists(filePath))
                    throw new ArgumentException("The template file does not exist");

                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    ms.Write(bytes, 0, (int)file.Length);
                }

                response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(ms.GetBuffer())
                };
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = templateName
                };
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
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

        [HttpGet]
        [GET("api/templates")]
        public HttpResponseMessage Get()
        {
            string test = "Test.dot";
            string content = JsonConvert.SerializeObject(test);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content)
            };
            return response;
        }
    }
}
