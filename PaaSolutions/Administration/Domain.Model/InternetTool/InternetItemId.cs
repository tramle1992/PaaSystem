using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Domain.Model.InternetTool
{
    public class InternetItemId : Common.Domain.Model.Identity
    {
        public InternetItemId() { }

        public InternetItemId(string id)
            : base(id)
        {
        }
    }
}
