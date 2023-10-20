using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Common.Infrastructure.ApiClient;
using System.Configuration;
using System.Net.Http.Headers;
using Common.Application;

namespace Common.Infrastructure.Repository
{
    public abstract class ApiRepository<TEntity, TID>
    {
        protected HttpClient httpClient;

        public ApiRepository()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUri"] ?? GlobalConstants.DefaultApiUri;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public abstract string Add(TEntity item);
        public abstract void Remove(TEntity item);
        public abstract void Update(TEntity item);
        public abstract TEntity Find(TID id);
    }
}
