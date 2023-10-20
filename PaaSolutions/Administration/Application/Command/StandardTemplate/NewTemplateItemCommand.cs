using Administration.Domain.Model.StandardTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Command.StandardTemplate
{
    public class NewTemplateItemCommand
    {
        public TemplateItemId ParentId { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public short Index { get; set; }

        public NewTemplateItemCommand(TemplateItemId parentId, string name, string caption, short index)
        {
            this.ParentId = parentId;
            this.Name = name;
            this.Caption = caption;
            this.Index = index;
        }
    }
}
