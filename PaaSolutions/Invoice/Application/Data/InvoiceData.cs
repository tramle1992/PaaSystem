using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Data
{
    public class InvoiceData
    {
        public string InvoiceId { get; set; }

        public string ClientName { get; set; }

        public string SoldToClientName { get; set; }

        public string Address { get; set; }

        public string InvoiceReference { get; set; }

        public string CustomerNumber { get; set; }

        public string InvoiceComments { get; set; }

        public int InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string NoteToClient { get; set; }

        public string PONumber { get; set; }

        public string InvoiceDivision { get; set; }

        public StatusData Status { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }

        public ActionStatusData ActionStatus { get; set; }

        public InvoiceData()
        {
        }
    }
}
