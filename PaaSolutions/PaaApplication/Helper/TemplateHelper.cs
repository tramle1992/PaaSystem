using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Net.Http;
using Common.Application;
using System.Net.Http.Headers;
using Common.Infrastructure.ApiClient;

namespace PaaApplication.Helper
{
    public class TemplateHelper
    {
        private static string baseAddress = ConfigurationManager.AppSettings["ApiUri"] ?? GlobalConstants.DefaultApiUri;
        private HttpClient httpClient;

        public TemplateHelper()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void DownloadTemplate(String savePath, String templateName)
        {
            try
            {
                JsonPostApiClient<byte[], String> apiClient = new JsonPostApiClient<byte[], string>(httpClient, "api/templates", templateName);
                byte[] data = apiClient.ExcuteByteArray();
                FileInfo file = new FileInfo(savePath);
                file.Directory.Create();
                File.WriteAllBytes(savePath, data);
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}