using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Data
{
    public class StatusData
    {
        public int Value { get; set; }

        public string DisplayName { get; set; }

        public StatusData(int value, string displayName)
        {
            this.Value = value;
            this.DisplayName = displayName;
        }
    }
}
