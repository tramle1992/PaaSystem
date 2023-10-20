using CreditReport.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditReport.Application.Command
{
    public class NewReportCommand
    {
        public Report Report { get; set; }

        public NewReportCommand(Report report)
        {
            this.Report = report;
        }
    }
}
