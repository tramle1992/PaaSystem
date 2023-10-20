using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Model
{
    public class Status : Enumeration
    {
        public static readonly Status OVER_PAY = new Status(0, "OverPay");

        public static readonly Status PAST_DUE = new Status(1, "Past Due");

        public static readonly Status PAID = new Status(2, "Paid");

        public static readonly Status PD_LATE = new Status(3, "Paid Late");

        public static readonly Status UNPAID = new Status(4, "Unpaid");

        public static Status CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return Status.OVER_PAY;
                case 1:
                    return Status.PAST_DUE;
                case 2:
                    return Status.PAID;
                case 3:
                    return Status.PD_LATE;
                case 4:
                    return Status.UNPAID;
                default:
                    return Status.PAID;
            }
        }

        public Status()
        {
        }

        public Status(int value, string displayName)
            : base(value, displayName)
        {
        }
    }
}
