using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace Core.Domain.Model.ExploreApps
{
    public class PriorityApp : Enumeration
    {
        public static readonly PriorityApp None = new PriorityApp(0, "0 - None");

        public static readonly PriorityApp Low = new PriorityApp(1, "1 - Low");

        public static readonly PriorityApp Medium = new PriorityApp(2, "2 - Medium");

        public static readonly PriorityApp High = new PriorityApp(3, "3 - High");

        public static PriorityApp CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return PriorityApp.None;
                case 1:
                    return PriorityApp.Low;
                case 2:
                    return PriorityApp.Medium;
                case 3:
                    return PriorityApp.High;
                default:
                    return null;
            }
        }

        public PriorityApp()
        { }

        private PriorityApp(int value, string displayName)
            : base(value, displayName)
        {}
    }
}
