using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.ExtendControls
{
    public class NumericEditBox : NumericUpDown
    {
        public NumericEditBox()
        {
            Controls[0].Enabled = false;
        }

        protected override void UpdateEditText()
        {
            if (this.Value != 0)
            {
                base.UpdateEditText();
            }
            else
            {
                base.Controls[1].Text = "";
            }
        }

    }
}
