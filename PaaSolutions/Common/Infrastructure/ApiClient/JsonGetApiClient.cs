using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Configuration;
using Common.Application;
using System.Net.Http.Headers;

namespace Common.Infrastructure.ApiClient
{
    public class JsonGetApiClient<T>
    {

        private HttpClient httpClient;
        private string url;

        public JsonGetApiClient(HttpClient client, string url)
        {
            this.httpClient = client;
            this.url = url;
        }

        public T Execute()
        {
            T data;

            if (httpClient == null || string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Invalid HttpClient or Url");
            }

            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<T>(jsonContent);
                return data;
            }

            return default(T);
        }
    }
}
