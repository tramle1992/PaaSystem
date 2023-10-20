using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard.Domain.Model.TimeCard
{
    public class UpdateTimeCardDate
    {
        public string TimeCardDateId { get; set; }
        public int TimeCardType { get; set; }
        public decimal Bonus { get; set; }

        public UpdateTimeCardDate(string timeCardDateId, int timeCardType, decimal bonus)
        {
            this.TimeCardDateId = timeCardDateId;
            this.TimeCardType = timeCardType;
            this.Bonus = bonus;
        }
    }
}
