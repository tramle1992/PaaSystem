using Common.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.UserManager
{
    public partial class FormRoleMgmAddNew : Form
    {
        FormRoleMgm _parentForm = new FormRoleMgm();

        public FormRoleMgmAddNew()
        {
            InitializeComponent();
        }

        public string NewRoleName
        {
            get { return this.txtRoleName.Text; }
            set { txtRoleName.Text = value; }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtRoleName_Validating(txtRoleName, null);

            if (errorProvider.GetError(txtRoleName) == "")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }            
        }

        private void txtRoleName_Validating(object sender, CancelEventArgs e)
        {
            string roleName = (sender as TextBox).Text;

            using (new HourGlass())
            {
                if (string.IsNullOrEmpty(roleName))
                {
                    this.btnAddNew.Enabled = false;
                    SetError("Please insert Role Name.");
                }
                    
                else if (!_parentForm.isAvailableRoleName(roleName))
                {
                    this.btnAddNew.Enabled = false;
                    SetError("Role Name already exists.");
                }
                
                else
                {
                    SetError();
                }
            }
        }

        private void SetError(string error = "")
        {
            errorProvider.SetError(this.txtRoleName, error);
        }

        private void txtRoleName_TextChanged(object sender, EventArgs e)
        {
            SetError();
            this.btnAddNew.Enabled = true;
        }
    }
}
