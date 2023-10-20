using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ExploreApps
{
    public class InvGetAvailAppCommand
    {
        public string ClientAppliedName { get; set; }

        public DateTime ReceivedFrom { get; set; }

        public DateTime ReceivedTo { get; set; }

        public string InvoiceDivision { get; set; }

        public bool OrderByName { get; set; }

        public InvGetAvailAppCommand()
        {
        }

        public InvGetAvailAppCommand(string clientAppliedName,
            DateTime receivedFrom, DateTime receivedTo,
            string invoiceDivision, bool orderByName)
        {
            this.ClientAppliedName = clientAppliedName;
            this.ReceivedFrom = receivedFrom;
            this.ReceivedTo = receivedTo;
            this.InvoiceDivision = invoiceDivision;
            this.OrderByName = orderByName;
        }
    }
}
