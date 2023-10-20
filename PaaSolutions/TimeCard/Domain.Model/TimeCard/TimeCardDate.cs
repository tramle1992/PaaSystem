using System;
using System.Collections.Generic;

namespace TimeCard.Domain.Model
{
    public class TimeCardDate
    {
        public TimeCardDate()
        {
        }

        public TimeCardDateId TimeCardDateId { get; set; }

        public List<TimeCardItem> ListTimeCardItems { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public decimal Bonus { get; set; }

        public DateTime FirstLogin { get; set; }

        public DateTime? LastLogout { get; set; }

        public TimeCardType TimeCardType { get; set; }

        public TimeCardDate(TimeCardDateId TimeCardDateId)
        {
            this.TimeCardDateId = TimeCardDateId;
            this.ListTimeCardItems = new List<TimeCardItem>();
        }
    }

}


