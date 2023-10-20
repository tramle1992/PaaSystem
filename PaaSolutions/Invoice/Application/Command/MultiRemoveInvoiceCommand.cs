using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class MultiRemoveInvoiceCommand
    {
        public List<RemoveInvoiceCommand> CommandList { get; set; }

        public MultiRemoveInvoiceCommand(List<RemoveInvoiceCommand> commandList)
        {
            this.CommandList = commandList;
        }
    }
}
