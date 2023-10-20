using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Command.StandardTemplate
{
    public class RemoveMultiTemplateItemCommand
    {
        public List<RemoveTemplateItemCommand> CommandList { get; set; }

        public RemoveMultiTemplateItemCommand(List<RemoveTemplateItemCommand> commandList)
        {
            this.CommandList = commandList;
        }
    }
}
