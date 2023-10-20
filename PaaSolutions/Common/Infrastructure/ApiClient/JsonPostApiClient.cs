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
    public class JsonPostApiClient<T, K>
    {
        private HttpClient httpClient;
        private string url;
        K input;

        public JsonPostApiClient(HttpClient client, string url, K input)
        {
            this.httpClient = client;
            this.url = url;
            this.input = input;
        }

        public T Execute()
        {
            T data;

            if (httpClient == null || string.IsNullOrEmpty(url) || input == null)
            {
                throw new ArgumentException("Invalid HttpClient or Url or Input");
            }

            string content = JsonConvert.SerializeObject(input);
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<T>(jsonContent);

                return data;
            }

            return default(T);
        }

        public byte[] ExcuteByteArray()
        {
            if (httpClient == null || string.IsNullOrEmpty(url) || input == null)
            {
                throw new ArgumentException("Invalid HttpClient or Url or Input");
            }

            string content = JsonConvert.SerializeObject(input);
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                byte[] bytedata = response.Content.ReadAsByteArrayAsync().Result;
                return bytedata;

            }

            return null;
        }
    }
}
