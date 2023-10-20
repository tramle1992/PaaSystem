using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Domain.Model.InternetTool
{
    public class InternetItem : EntityWithCompositeId, IAggregateRoot
    {
        public InternetItemId InternetItemId { get; set; }
        public string Caption { get; set; }
        public string Target { get; set; }
        public byte[] Image { get; set; }
        public byte Order { get; set; }

        public InternetItem()
        {
        }

        public InternetItem(InternetItemId internetItemId, string caption, string target, byte[] image, byte order)
        {
            this.InternetItemId = internetItemId;
            this.Caption = caption;
            this.Target = target;
            this.Image = image;
            this.Order = order;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.InternetItemId;
        }

        public override string ToString()
        {
            return "InternetItem[internetItemId=" + this.InternetItemId + "]";
        }
    }
}
