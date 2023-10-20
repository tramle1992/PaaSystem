using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class MultiRemoveInvoiceItemByInvoiceIdCommand
    {
        public List<RemoveInvoiceItemByInvoiceIdCommand> CommandList { get; set; }

        public MultiRemoveInvoiceItemByInvoiceIdCommand(List<RemoveInvoiceItemByInvoiceIdCommand> commandList)
        {
            this.CommandList = commandList;
        }
    }
}
