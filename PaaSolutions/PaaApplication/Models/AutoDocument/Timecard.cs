using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models
{
    public class Timecard
    {
        public DateTime Date { get; set; }
        public DateTime TimeIn{ get; set; }
        public DateTime TimeOut{ get; set; }
        public int Bonus { get; set; }
        public int Hours { get; set; }
        public int Type { get; set; }

        public Timecard()
        {

        }

        public Timecard(DateTime Date, DateTime TimeIn, DateTime TimeOut, int Bonus, int Hours, int Type)
        {
            this.Date = Date;
            this.TimeIn = TimeIn;
            this.TimeOut = TimeOut;
            this.Bonus = Bonus;
            this.Hours = Hours;
            this.Type = Type;
        }
    }
}
