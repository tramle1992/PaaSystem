using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDocument.Application.Data
{
    public class DailyReportData
    {
        public string Applicant { get; set; }

        public string ClientName { get; set; }

        public DateTime RecievedDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public string TurnAround { get; set; }

        public bool IsFullApp { get; set; }

    }
}
