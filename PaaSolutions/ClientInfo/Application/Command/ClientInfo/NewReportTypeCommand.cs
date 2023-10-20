using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ClientInfo
{
    public class NewReportTypeCommand
    {
        public string TypeName { get; set; }

        public string AbsoluteTypeName { get; set; }

        public decimal DefaultPrice { get; set; }

        public NewReportTypeCommand()
        {
        }

        public NewReportTypeCommand(string typeName, string absoluteTypeName, decimal defaultPrice)
        {
            this.TypeName = typeName;
            this.AbsoluteTypeName = absoluteTypeName;
            this.DefaultPrice = defaultPrice;
        }
    }
}
