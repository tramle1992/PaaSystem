using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ExploreApps
{
    public class SimpleSearchAppCommand
    {
        public DateTime ReceivedFrom { get; set; }

        public DateTime ReceivedTo { get; set; }

        public bool IncludeInProcess { get; set; }

        public bool IncludeArchived { get; set; }

        public string Keyword { get; set; }

        public string SearchIn { get; set; }

        public SimpleSearchAppCommand()
        {
        }

        public SimpleSearchAppCommand(DateTime receivedFrom, DateTime receivedTo,
            bool includeInProcess, bool includeArchived,
            string keyword, string searchIn)
        {
            this.ReceivedFrom = receivedFrom;
            this.ReceivedTo = receivedTo;
            this.IncludeInProcess = includeInProcess;
            this.IncludeArchived = includeArchived;
            this.Keyword = keyword;
            this.SearchIn = searchIn;
        }
    }
}
