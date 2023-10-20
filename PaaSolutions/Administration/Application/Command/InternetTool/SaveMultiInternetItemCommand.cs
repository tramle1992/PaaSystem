using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Command.InternetTool
{
    public class SaveMultiInternetItemCommand
    {
        public List<SaveInternetItemCommand> CommandList { get; set; }

        public SaveMultiInternetItemCommand(List<SaveInternetItemCommand> commandList)
        {
            this.CommandList = commandList;
        }
    }
}
