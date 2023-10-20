using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class MultiNewInvoiceItemCommand
    {
        public List<NewInvoiceItemCommand> CommandList { get; set; }

        public MultiNewInvoiceItemCommand(List<NewInvoiceItemCommand> commandList)
        {
            this.CommandList = commandList;
        }
    }
}
