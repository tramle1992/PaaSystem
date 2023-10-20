using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public class ReferenceItem
    {
        public bool YesValue { get; set; }

        public bool NoValue { get; set; }

        public bool NAValue { get; set; }

        public string DisplayName { get; set; }

        public ReferenceItem(
            string displayName, bool yesValue, bool noValue, bool naValue)
        {
            this.DisplayName = displayName;
            this.YesValue = yesValue;
            this.NoValue = noValue;
            this.NAValue = naValue;
        }

    }
}
