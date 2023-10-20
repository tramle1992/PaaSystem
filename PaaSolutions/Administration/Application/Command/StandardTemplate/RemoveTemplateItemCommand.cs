using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Command.StandardTemplate
{
    public class RemoveTemplateItemCommand
    {
        public string TemplateItemId { get; set; }

        public RemoveTemplateItemCommand(string templateItemId)
        {
            this.TemplateItemId = templateItemId;
        }
    }
}
