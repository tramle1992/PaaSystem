using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Model.ClientInfo
{
    public class ReportTypeId : Common.Domain.Model.Identity
    {
        public ReportTypeId() { }

        public ReportTypeId(string id) : base(id)
        { }
    }
}
