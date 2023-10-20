using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard.Data
{
    public class TimeCardTypeData
    {
        public int Value { get; set; }
        public string DisplayName { get; set; }

        public TimeCardTypeData(int value, string displayName)
        {
            this.Value = value;
            this.DisplayName = displayName;
        }
    }
}
