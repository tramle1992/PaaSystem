using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public class ScreenerData
    {
        public string ScreenerId { get; set; }

        public string ScreenerName { get; set; }

        public ScreenerData()
        {
        }

        public ScreenerData(string screenerId, string screenerName)
        {
            this.ScreenerId = screenerId;
            this.ScreenerName = screenerName;
        }
    }
}
