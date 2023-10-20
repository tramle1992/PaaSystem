using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Domain.Model
{
    public class AppIdMapping
    {
        public string OldAppId { get; set; }

        public string NewAppId { get; set; }

        public AppIdMapping()
        {
        }

        public AppIdMapping(string oldAppId, string newAppId)
        {
            this.OldAppId = oldAppId;
            this.NewAppId = newAppId;
        }
    }
}
