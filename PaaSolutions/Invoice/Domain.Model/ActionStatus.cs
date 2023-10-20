using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Model
{
    public class ActionStatus : Enumeration
    {
        public static readonly ActionStatus NONE = new ActionStatus(0, "None");

        public static readonly ActionStatus EMAILED = new ActionStatus(1, "Emailed");

        public static readonly ActionStatus PRINTED = new ActionStatus(2, "Printed");

        public static readonly ActionStatus EMAILED_PRINTED = new ActionStatus(3, "Emailed and Printed");

        public static ActionStatus CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return ActionStatus.NONE;
                case 1:
                    return ActionStatus.EMAILED;
                case 2:
                    return ActionStatus.PRINTED;
                case 3:
                    return ActionStatus.EMAILED_PRINTED;
                default:
                    return ActionStatus.NONE;
            }
        }

        public ActionStatus()
        {
        }

        public ActionStatus(int value, string displayName)
            : base(value, displayName)
        {
        }
    }
}
