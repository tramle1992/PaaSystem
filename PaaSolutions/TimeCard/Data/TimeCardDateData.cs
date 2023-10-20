using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Domain.Model;

namespace TimeCard.Data
{
    public class TimeCardDateData
    {
        public string TimeCardDateId { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public decimal Bonus { get; set; }

        public DateTime FirstLogin { get; set; }

        public DateTime? LastLogout { get; set; }

        public TimeCardTypeData TimeCardType { get; set; }

        public List<TimeCardItemData> ListTimeCardItems { get; set; }

        public TimeCardDateData(string timecardDateId)
        {
            this.TimeCardDateId = timecardDateId;
        }
    }
}
