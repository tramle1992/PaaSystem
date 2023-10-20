using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.AppExplore
{
    public partial class FormImportantInformation : Form
    {
        public FormImportantInformation()
        {
            InitializeComponent();
        }

        public string ClientName
        {
            set
            {
                this.lblClientName.Text = value;
            }
        }

        public string BillingInfo
        {
            set
            {
                this.txtBillingInfo.Text = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
