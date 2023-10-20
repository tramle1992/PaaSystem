using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.ExploreApps
{
    public class AppId : Common.Domain.Model.Identity
    {
        public AppId() { }

        public AppId(string id)
            : base(id)
        {

        }
    }
}
