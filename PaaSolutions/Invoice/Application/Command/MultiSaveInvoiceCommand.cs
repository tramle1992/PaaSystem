using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class MultiSaveInvoiceCommand
    {
        public List<SaveInvoiceCommand> CommandList { get; set; }

        public MultiSaveInvoiceCommand(List<SaveInvoiceCommand> commandList)
        {
            this.CommandList = commandList;
        }
    }
}
