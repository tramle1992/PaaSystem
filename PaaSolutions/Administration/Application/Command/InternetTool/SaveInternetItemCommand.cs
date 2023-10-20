using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Command.InternetTool
{
    public class SaveInternetItemCommand
    {
        public string InternetItemId { get; set; }
        public string Caption { get; set; }
        public string Target { get; set; }
        public byte[] Image { get; set; }
        public byte Order { get; set; }

        public SaveInternetItemCommand(string internetItemId, string caption, string target, byte[] image, byte order)
        {
            this.InternetItemId = internetItemId;
            this.Caption = caption;
            this.Target = target;
            this.Image = image;
            this.Order = order;
        }
    }
}
