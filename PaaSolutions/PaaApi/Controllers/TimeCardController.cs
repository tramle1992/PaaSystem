using AttributeRouting.Web.Http;
using Newtonsoft.Json;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Application;
using Core.Domain.Model.ExploreApps;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using TimeCard.Application;
using TimeCard.Domain.Model;
using TimeCard.Infrastructure.TimeCard;
using TimeCard.Data;
using TimeCard.Command;
using TimeCard.Domain.Model.TimeCard;

namespace PaaApi.Controllers
{
    public class TimeCardController : ApiController
    {
        [HttpPost]
        [POST("api/timecarddate")]
        public HttpResponseMessage GetTimeCardByUser(FindTimeCardCommand command)
        {
            HttpResponseMessage response;
            TimecardItemQueryService timecardItemService = new TimecardItemQueryService();

            List<TimeCardDateData> listTimeCard = timecardItemService.FindTimeCard(command);

            if (listTimeCard.Count > 0)
            {
                string jsonContent = JsonConvert.SerializeObject(listTimeCard);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            else
            {
                string message = "Time Card data were not found";
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(message)
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/timecarddate/login")]
        public HttpResponseMessage AddTimeCardDate(NewTimeCardCommand command)
        {
            HttpResponseMessage response;
            TimeCardDateRepository tcDateRepository = new TimeCardDateRepository();

            TimeCardDate tcDate = new TimeCardDate();            
            tcDate.ListTimeCardItems = new List<TimeCardItem>();

            TimeCardItemId tcItemId = new TimeCardItemId(Guid.NewGuid().ToString());
            TimeCardItem item = new TimeCardItem(tcItemId);           
            
            tcDate.UserId = command.UserId;

            tcDate.ListTimeCardItems.Add(item);

            tcDateRepository.Add(tcDate);

            tcDateRepository.UpdateLastLoginInTableUser(tcDate);

            response = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                RequestMessage = Request,
                Content = new StringContent("OK")
            };

            return response;
        }

        [HttpPost]
        [POST("api/timecarddate/logout")]
        public HttpResponseMessage UpdateTimeCardWhenLogOut(UpdateTimeCardLogOutCommand command)
        {
            HttpResponseMessage response;
            TimeCardDateRepository tcDateRepository = new TimeCardDateRepository();

            TimeCardDate tcDate = new TimeCardDate();
            
            tcDate.UserId = command.UserId;

            tcDateRepository.UpdateWhenLogOut(tcDate);

            response = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                RequestMessage = Request,
                Content = new StringContent("OK")
            };
            return response;
        }

        [HttpPut]
        [PUT("api/timecarddate")]
        public HttpResponseMessage UpdateTimeCard(SaveTimeCardCommand command)
        {
            HttpResponseMessage response;
            TimeCardDateRepository tcDateRepository = new TimeCardDateRepository();

            if (command.ListTimeCardDateToUpdate.Count > 0)
            {
                foreach (UpdateTimeCardDate item in command.ListTimeCardDateToUpdate)
                {
                    TimeCardDate tcDate = new TimeCardDate();
                    tcDate.TimeCardDateId = new TimeCardDateId();
                    tcDate.TimeCardDateId.Id = item.TimeCardDateId;
                    tcDate.TimeCardType = TimeCardType.CreateInstance(item.TimeCardType);

                    tcDateRepository.Update(tcDate);
                }
            }           

            response = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                RequestMessage = Request,
                Content = new StringContent("OK")
            };
            return response;
        }

        [HttpGet]
        [GET("api/timecarddate/serverutctime")]
        public HttpResponseMessage GetServerTimeInUtc()
        {
            HttpResponseMessage response;
            try
            {
                TimecardItemQueryService timecardItemService = new TimecardItemQueryService();
                DateTime serverTime = timecardItemService.GetServerTimeInUtc();

                string jsonContent = JsonConvert.SerializeObject(serverTime);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
                
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
    }
}
