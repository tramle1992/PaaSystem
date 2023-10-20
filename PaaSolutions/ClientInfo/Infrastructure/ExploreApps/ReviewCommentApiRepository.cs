using Common.Infrastructure.Repository;
using Core.Domain.Model.ExploreApps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.ExploreApps
{
    public class ReviewCommentApiRepository : ApiRepository<ReviewComment, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReviewCommentApiRepository()
            : base()
        { }

        public override string Add(ReviewComment reviewComment)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/reviewcomments");

                string content = JsonConvert.SerializeObject(reviewComment);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                newId = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not add a review comment with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            return newId;
        }

        public override void Remove(ReviewComment comment)
        {
            try
            {
                string url = string.Format("api/reviewcomments/{0}", comment.ReviewCommentId);

                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not remove review comment using api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Update(ReviewComment comment)
        {
            try
            {
                string url = string.Format("api/reviewcomments");

                string content = JsonConvert.SerializeObject(comment);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Could not update a review comment with api: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override ReviewComment Find(string id)
        {
            ReviewComment comment = null;
            try
            {
                string url = string.Format("api/reviewcomments/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    comment = JsonConvert.DeserializeObject<ReviewComment>(jsonContent);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    comment = null;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return comment;
        }
    }
}
