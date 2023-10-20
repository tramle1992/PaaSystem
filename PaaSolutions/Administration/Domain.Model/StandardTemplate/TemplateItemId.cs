using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Domain.Model.StandardTemplate
{
    public class TemplateItemId : Common.Domain.Model.Identity
    {
        public TemplateItemId() { }

        public TemplateItemId(string id)
            : base(id)
        {
        }
    }
}
