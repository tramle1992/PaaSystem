using Common.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Application;
using TimeCard.Command;
using TimeCard.Data;

namespace TimeCard.Infrastructure.TimeCard
{
    public class TimeCardCachedApiQuery
    {
        TimeCardApiRepository timeCardRepository = new TimeCardApiRepository();

        private static readonly TimeCardCachedApiQuery instance = new TimeCardCachedApiQuery();

        private const string KEY_ALL_TIME_CARD = "KEY_ALL_TIME_CARD";

        static TimeCardCachedApiQuery()
        {
        }

        public static TimeCardCachedApiQuery Instance
        {
            get { return instance; }
        }

        public List<TimeCardDateData> GetAllTimeCardDate(string userId, DateTime fromDate, DateTime toDate)
        {

            TypedObjectCache<List<TimeCardDateData>> cacheList = TypedObjectCache<List<TimeCardDateData>>.Instance;

            List<TimeCardDateData> cacheTimeCards = null;

            if (cacheList.TryGet(KEY_ALL_TIME_CARD, out cacheTimeCards))
            {
                return cacheTimeCards;
            }

            FindTimeCardCommand command = new FindTimeCardCommand(userId, fromDate, toDate);

            TimecardItemQueryService service = new TimecardItemQueryService();
            cacheTimeCards = timeCardRepository.FindTimeCard(command);

            cacheList.Set(KEY_ALL_TIME_CARD, cacheTimeCards);
            return cacheTimeCards;
        }


        public void RemoveAllTimeCards()
        {
            TypedObjectCache<List<TimeCardDateData>> cacheList = TypedObjectCache<List<TimeCardDateData>>.Instance;
            cacheList.Remove(KEY_ALL_TIME_CARD);
        }

    }
}
