using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class NewPaymentCommand
    {
        public PaymentData PaymentData { get; set; }

        public NewPaymentCommand(PaymentData data)
        {
            this.PaymentData = data;
        }
    }
}
