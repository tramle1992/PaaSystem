using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.Invoicing
{
    public partial class FormInvUpdateClientName : Form
    {
        private string oldClientName;

        public string NewClientName
        {
            get { return this.txtNewClientName.Text.Trim(); }
        }

        public FormInvUpdateClientName(string oldClientName)
        {
            InitializeComponent();
            this.oldClientName = oldClientName;
            this.lblDescription.Text = "Enter the name with which you would like to replace the client name of the selected Invoices which currently have the client name '" + this.oldClientName + "'.";
            this.txtNewClientName.Text = this.oldClientName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("WARNING! This will replace the client name of the selected invoices that are currently for '"
                            + this.oldClientName + "' with the name '"
                            + this.txtNewClientName.Text.Trim() + "'! Do you want to proceed?",
                            "Replace Client Names",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
