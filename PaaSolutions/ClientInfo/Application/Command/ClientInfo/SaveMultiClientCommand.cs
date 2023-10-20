using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ClientInfo
{
    public class SaveMultiClientCommand
    {
        public List<SaveClientCommand> CommandList { get; set; }

        public SaveMultiClientCommand(List<SaveClientCommand> commandList)
        {
            this.CommandList = commandList;
        }
    }
}
