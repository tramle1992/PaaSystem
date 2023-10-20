using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;
using Common.Application;

namespace Common.Infrastructure.ApiClient
{
    public class ApiClientFactory
    {
        public static HttpClient GetHttpClient(string baseAddress)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress ?? GlobalConstants.DefaultApiUri);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}
