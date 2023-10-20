using Common.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Command;
using TimeCard.Data;
using TimeCard.Domain.Model;
using TimeCard.Infrastructure.TimeCard;

namespace TimeCard.Application
{
    public class TimecardItemQueryService : QueryService
    {
        public TimecardItemQueryService()
        {
            timecardItemRepository = new TimeCardItemRepository();
            timecardDateRepository = new TimeCardDateRepository();
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        TimeCardItemRepository timecardItemRepository;
        TimeCardDateRepository timecardDateRepository;

        public List<TimeCardDateData> FindTimeCard(FindTimeCardCommand command)
        {
            List<TimeCardDateData> listResult = new List<TimeCardDateData>();
            try
            {
                List<TimeCardDate> listTimeCardDate = timecardItemRepository.FindTimeCard(command);
                List<TimeCardDateData> listTimeCardDateData = null;

                if (listTimeCardDate != null && listTimeCardDate.Count > 0)
                {
                    listTimeCardDateData = new List<TimeCardDateData>(listTimeCardDate.Count);
                    foreach (TimeCardDate item in listTimeCardDate)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.TimeCardDateId.Id))
                        {
                            TimeCardDateData timecardData = AutoMapper.Mapper.Map<TimeCardDate, TimeCardDateData>(item);
                            listResult.Add(timecardData);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return listResult;
        }

        public DateTime GetServerTimeInUtc()
        {
            return timecardDateRepository.GetCurrentServertimeInUtc();
        }
    }
}
