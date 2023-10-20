using Common.Infrastructure.UI;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.UserManager
{
    public partial class FormUserMgmAddNew : Form
    {
        private UserApiRepository _userApiRepo = new UserApiRepository();

        public FormUserMgmAddNew()
        {
            InitializeComponent();
        }

        public string NewUserName
        {
            get { return txtUserName.Text; }
            set { txtUserName.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void SetToolTip()
        {
            string caption = "Username conditions: \n" +
                          "- Must be 1 to 24 character(s) in length \n" +
                          "- Must not contain special characters (`,!,@,#,$,%,^,&,*,(,),-) \n";

            toolTip1.SetToolTip(lblInfo, caption);
        }

        private void lblInfo_MouseHover(object sender, EventArgs e)
        {
            SetToolTip();
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            DoValidation(sender, txtPassword, "Password");
            if (IsValidationOK())
            {
                this.btnAddNew.Enabled = true;
            }
            else
            {
                this.btnAddNew.Enabled = false;
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            DoValidation(sender, txtUserName, "UserName");

            if (!IsValidUserName(txtUserName.Text))
            {
                errpdAddUser.SetError(txtUserName, "UserName is invalid.");   
            }

            using (new HourGlass())
            {
                User user = _userApiRepo.Check(txtUserName.Text);

                if (user != null)
                {
                    errpdAddUser.SetError(txtUserName, "UserName already exists.");
                }
            }
           
            if (IsValidationOK())
            {
                this.btnAddNew.Enabled = true;
            }
            else
            {
                this.btnAddNew.Enabled = false;
            }
        }

        private void DoValidation(object sender, Control control, string value)
        {
            string input = (sender as TextBox).Text;
            string err = "";

            if (string.IsNullOrEmpty(input))
            {
                err = "Please insert " + value + ".";
            }            

            errpdAddUser.SetError(control, err);   
        }        

        private bool IsValidationOK()
        {
            bool isValid = true;          

            if (errpdAddUser.GetError(txtUserName) != "")
            {
                isValid = false;
            }

            if (errpdAddUser.GetError(txtPassword) != "" || txtPassword.Text == "")
            {
                isValid = false;
            }
            return isValid;
        }

        public bool IsValidUserName(string username)
        {
            bool isValid = true;

            if (!string.IsNullOrEmpty(username.Trim()) &&
                !Regex.IsMatch(username.Trim(),
                @"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                isValid = false;
            }

            return isValid;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword_Validating(sender, null);
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            DoValidation(sender, txtUserName, "UserName");

            if (!IsValidUserName(txtUserName.Text))
            {
                errpdAddUser.SetError(txtUserName, "UserName is invalid.");
            }

            if (IsValidationOK())
            {
                this.btnAddNew.Enabled = true;
            }
            else
            {
                this.btnAddNew.Enabled = false;
            }

        }


    }
}
