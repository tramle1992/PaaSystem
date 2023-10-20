using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public class PriorityAppData
    {
        public int Value { get; set; }

        public string DisplayName { get; set; }

        public PriorityAppData()
        {
        }

        public PriorityAppData(int value, string displayName)
        {
            this.Value = value;
            this.DisplayName = displayName;
        }
    }
}
