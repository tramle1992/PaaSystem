using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard.Application.Data
{
    public class TimeCardItemData
    {
        public string TimeCardItemId { get; private set; }

        public TimeCardDateData TimeCardDate { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime? LogoutTime { get; set; }

        public TimeCardItemData(string timecardItemId)
        {
            this.TimeCardItemId = timecardItemId;
        }


    }
}
