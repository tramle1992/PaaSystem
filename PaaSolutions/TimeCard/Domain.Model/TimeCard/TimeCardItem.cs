using System;

namespace TimeCard.Domain.Model
{
    public class TimeCardItem
    {
        public TimeCardItemId TimeCardItemId { get; private set; }        

        public DateTime LoginTime { get; set; }

        public DateTime? LogoutTime { get; set; }

        public TimeCardDateId TimeCardDateId { get; set; }

        public TimeCardItem()
        { }

        public TimeCardItem(TimeCardItemId timeCardItemId, TimeCardDate timeCardDate, DateTime loginTime, DateTime logoutTime)
        {
            this.TimeCardItemId = timeCardItemId;            
            this.LoginTime = loginTime;
            this.LogoutTime = logoutTime;            
        }

        public TimeCardItem(TimeCardItemId timecardId){
            this.TimeCardItemId = timecardId;
        }
    }
}


