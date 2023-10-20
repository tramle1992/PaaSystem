using AttributeRouting.Web.Http;
using Core.Domain.Model.ExploreApps;
using Core.Infrastructure.ExploreApps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PaaApi.Controllers
{
    public class ReviewCommentController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [GET("api/reviewcomments/{id}")]
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response;
            try
            {
                ReviewCommentRepository repository = new ReviewCommentRepository();
                ReviewComment reviewComment = repository.Find(id);
                if (reviewComment == null)
                {
                    string message = string.Format("Review Comment with id:{0} was not found", id);
                    HttpError httpError = new HttpError(message);
                    response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        RequestMessage = Request,
                    };
                }
                else
                {
                    string jsonContent = JsonConvert.SerializeObject(reviewComment);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.Message)
                };
            }
            return response;
        }

        [HttpDelete]
        [DELETE("api/reviewcomments")]
        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage response;
            try
            {
                ReviewCommentRepository repository = new ReviewCommentRepository();
                repository.Remove(id);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.Message)
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/reviewcomments")]
        public HttpResponseMessage Post(ReviewComment comment)
        {

            HttpResponseMessage response;
            try
            {
                ReviewCommentRepository repository = new ReviewCommentRepository();
                repository.Add(comment);
                string id = comment.ReviewCommentId;
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(id)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.Message)
                };
            }
            return response;
        }

        [HttpPut]
        [PUT("api/reviewcomments")]
        public HttpResponseMessage Put(ReviewComment comment)
        {
            HttpResponseMessage response;
            try
            {
                ReviewCommentRepository repository = new ReviewCommentRepository();
                repository.Update(comment);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.Message)
                };
            }
            return response;
        }
    }
}
