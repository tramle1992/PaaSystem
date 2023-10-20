using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ClientInfo
{
    public class SaveReportTypeCommand
    {

        public string ReportTypeId { get; set; }

        public string TypeName { get; set; }

        public string AbsoluteTypeName { get; set; }

        public decimal DefaultPrice { get; set; }

        public SaveReportTypeCommand()
        {
        }

        public SaveReportTypeCommand(string id, string typeName, string absoluteTypeName, decimal defaultPrice)
        {
            this.ReportTypeId = id;
            this.TypeName = typeName;
            this.AbsoluteTypeName = absoluteTypeName;
            this.DefaultPrice = defaultPrice;
        }
    }
}
