using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Common.Infrastructure.UI
{
    public class BaseForm : Form
    {
        public event EventHandler<EventArgs> LoadCompleted;

        public BaseForm()
        {
            this.Shown += new EventHandler(BaseForm_Shown);
        }

        void BaseForm_Shown(object sender, EventArgs args)
        {
            System.Windows.Forms.Application.DoEvents();
            if (LoadCompleted != null)
                LoadCompleted(this, args);
        }
    }
}
