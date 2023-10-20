using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class SavePaymentCommand
    {
        public PaymentData PaymentData { get; set; }

        public SavePaymentCommand(PaymentData data)
        {
            this.PaymentData = data;
        }
    }
}
