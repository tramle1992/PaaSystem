using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class RemovePaymentCommand
    {
        public string PaymentId { get; set; }

        public RemovePaymentCommand(string paymentId)
        {
            this.PaymentId = paymentId;
        }
    }
}
