using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Data
{
    public class PaymentData
    {
        public string PaymentId { get; set; }

        public string InvoiceId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string Check { get; set; }

        public PaymentData()
        {
        }
    }
}
