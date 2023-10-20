using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ExploreApps
{
    public class InvSearchAppCommand
    {
        public DateTime ReceivedFrom { get; set; }

        public DateTime ReceivedTo { get; set; }

        public bool ClientsOperator { get; set; }

        public List<string> ClientNames { get; set; }

        public bool ReportTypesOperator { get; set; }

        public List<string> ReportTypeNames { get; set; }

        public string Keyword { get; set; }

        public string SearchIn { get; set; }

        public InvSearchAppCommand()
        {
            this.ClientNames = new List<string>();
            this.ReportTypeNames = new List<string>();
        }

        public InvSearchAppCommand(DateTime receivedFrom, DateTime receivedTo,
            bool clientsOperator, List<string> clientNames, bool reportTypesOperator, List<string> reportTypeNames,
            string keyword, string searchIn)
        {
            this.ReceivedFrom = receivedFrom;
            this.ReceivedTo = receivedTo;
            this.ClientsOperator = clientsOperator;
            this.ClientNames = clientNames;
            this.ReportTypesOperator = reportTypesOperator;
            this.ReportTypeNames = reportTypeNames;
            this.Keyword = keyword;
            this.SearchIn = searchIn;
        }
    }
}
