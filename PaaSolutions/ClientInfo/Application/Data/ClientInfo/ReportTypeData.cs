using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Application.Data.ClientInfo
{
    public class ReportTypeData
    {
        public string ReportTypeId { get; set; }

        public string TypeName { get; set; }

        public string AbsoluteTypeName { get; set; }

        public decimal DefaultPrice { get; set; }
    }
}
