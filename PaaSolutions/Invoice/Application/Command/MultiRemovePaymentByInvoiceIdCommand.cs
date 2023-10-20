using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class MultiRemovePaymentByInvoiceIdCommand
    {
        public List<RemovePaymentByInvoiceIdCommand> CommandList { get; set; }

        public MultiRemovePaymentByInvoiceIdCommand(List<RemovePaymentByInvoiceIdCommand> commandList)
        {
            this.CommandList = commandList;
        }
    }
}
