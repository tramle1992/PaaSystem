using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Domain.Model.StandardTemplate
{
    public class TemplateItem : EntityWithCompositeId, IAggregateRoot
    {
        public TemplateItemId TemplateItemId { get; set; }
        public TemplateItemId ParentId { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public short Index { get; set; }

        public TemplateItem()
        {
        }

        public TemplateItem(TemplateItemId templateItemId, TemplateItemId parentId, string name, string caption, short index)
        {
            this.TemplateItemId = templateItemId;
            this.ParentId = parentId;
            this.Name = name;
            this.Caption = caption;
            this.Index = index;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.TemplateItemId;
        }

        public override string ToString()
        {
            return "TemplateItem[templateItemId=" + this.TemplateItemId + "]";
        }
    }
}
