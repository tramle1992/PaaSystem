using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class MultiRemoveInvoiceItemCommand
    {
        public List<RemoveInvoiceItemCommand> CommandList { get; set; }

        public MultiRemoveInvoiceItemCommand(List<RemoveInvoiceItemCommand> commandList)
        {
            this.CommandList = commandList;
        }
    }
}
