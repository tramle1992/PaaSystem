using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard.Command
{
    public class FindTimeCardCommand
    {
        public string userId { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }

        public FindTimeCardCommand(string userId, DateTime fromDate, DateTime toDate)
        {
            this.userId = userId;
            this.fromDate = fromDate;
            this.toDate = toDate;
        }
    }
}
