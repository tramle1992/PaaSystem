using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Command.StandardTemplate
{
    public class SaveTemplateItemCommand
    {
        public string TemplateItemId { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public short Index { get; set; }

        public SaveTemplateItemCommand(string templateItemId, string parentId, string name, string caption, short index)
        {
            this.TemplateItemId = templateItemId;
            this.ParentId = parentId;
            this.Name = name;
            this.Caption = caption;
            this.Index = index;
        }
    }
}
