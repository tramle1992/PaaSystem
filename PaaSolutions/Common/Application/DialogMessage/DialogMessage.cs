using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Application.DialogMessage
{
    public class DialogMessage
    {
        public string MessageCaption { get; set; }
        public string MessageContent { get; set; }
        public MessageBoxButtons MessageButton { get; set; }
        public MessageBoxIcon MessageIcon { get; set; }
        public MessageBoxDefaultButton MessageDefaultButton { get; set; }

        public DialogMessage()
        {

        }

        public DialogResult Show()
        {
            return MessageBox.Show(MessageContent, MessageCaption, MessageButton, MessageIcon, MessageDefaultButton);
        }
    }
}
