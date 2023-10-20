using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdentityAccess.CommonType;
using System.Text.RegularExpressions;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Infrastructure.Identity;
using Common.Infrastructure.UI;
using IdentityAccess.Domain.Model.Access;
using System.IO;
using PaaApplication.Forms.UserManager;

namespace PaaApplication.UserControls.UserManager
{
    public partial class UserProfileControl : UserControl
    {
        private UserApiRepository _userApiRepo = new UserApiRepository();
        public List<Role> _listAllRoles = new List<Role>();

        public UserProfileControl()
        {
            InitializeComponent();
            LoadUserStatus();
        }

        #region getter/setter

        public string EditingUserName
        {
            get;
            set;
        }

        public bool IsCheckedUpdatePassword
        {
            get
            {
                if (chkUpdatePassWord.Checked)
                {
                    return true;
                }
                return false;
            }

        }

        public DateTime MinDate
        {
            get
            {
                return dtnTermDate.MinDate;
            }
        }

        public string UserId
        {
            get;
            set;
        }

        public string UserName
        {
            get { return txtUserName.Text; }
            set
            {
                txtUserName.Text = value;
                lblUserName.Text = value;
            }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        public int Status
        {
            get { return this.cboUserStatus.SelectedIndex; }
            set { this.cboUserStatus.SelectedIndex = value; }
        }

        public bool StatusEnabled
        {
            get { return this.cboUserStatus.Enabled; }
            set { this.cboUserStatus.Enabled = value; }
        }

        public DateTime? HiredDate
        {
            get { return this.dtmHiredDate.Value; }
            set
            {
                if (value == null)
                {
                    this.dtmHiredDate.CustomFormat = " ";
                }
                else
                {
                    this.dtmHiredDate.CustomFormat = "MM / dd / yyyy";
                    this.dtmHiredDate.Value = (DateTime)value;
                }
            }
        }

        public DateTime? TermDate
        {
            get { return this.dtnTermDate.Value; }
            set
            {
                if (value == null)
                {
                    this.dtnTermDate.Value = dtnTermDate.MinDate;
                    this.dtnTermDate.CustomFormat = " ";
                }
                else
                {
                    this.dtnTermDate.CustomFormat = "MM / dd / yyyy";
                    this.dtnTermDate.Value = (DateTime)value;
                }
            }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public string Other
        {
            get { return txtOther.Text; }
            set { txtOther.Text = value; }
        }

        public string OfflineDuration
        {
            set { lblOfflineDuration1.Text = value; }
        }

        public string LastLogin
        {
            set { lblOfflineDuration1.Text = value; }
        }

        public Role Role
        {
            get
            {
                if (lboxRoles.CheckedItems.Count > 0)
                {
                    return ((Role)lboxRoles.CheckedItems[0]);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                lboxRoles.Items.Clear();
                LoadRoles();
                int indx = _listAllRoles.IndexOf(value);
                lboxRoles.SetItemChecked(indx, true);
            }
        }

        public List<Role> AllRoles
        {
            get { return _listAllRoles; }
            set { this._listAllRoles = value; }
        }

        public byte[] Avatar
        {
            set
            {
                using (MemoryStream memoryStream = new MemoryStream(value))
                {
                    FormUserProfile frm = new FormUserProfile();
                    Image originalImage = Image.FromStream(memoryStream);
                    Image resizedImage = frm.ResizeImage(originalImage, new Size(89, 89), true);

                    picAvatar.Image = resizedImage;
                }
            }
        }

        #endregion

        private void LoadRoles()
        {
            lboxRoles.ValueMember = "RoleId";
            lboxRoles.DisplayMember = "RoleName";

            foreach (Role item in AllRoles)
            {
                lboxRoles.Items.Add(item);
            }
        }

        private void LoadUserStatus()
        {
            IEnumerable<UserStatus> lstUserStatus = Enum.GetValues(typeof(UserStatus)).Cast<UserStatus>();

            foreach (UserStatus status in lstUserStatus)
            {
                this.cboUserStatus.Items.Add(status);
            }

            this.cboUserStatus.SelectedIndex = 0;
        }

        #region control events

        private void chkUpdatePassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdatePassWord.Checked)
            {
                this.txtPassword.Enabled = true;
                this.txtPassword.Focus();
            }
            else
            {
                this.txtPassword.Enabled = false;
                this.Password = string.Empty;
                errpdUserProfile.SetError(txtPassword, "");
            }
        }

        private void dtnTermDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtnTermDate.CustomFormat = "MM / dd / yyyy";
        }

        private void dtmHiredDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtmHiredDate.CustomFormat = "MM / dd / yyyy";
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string inputUsername = (sender as TextBox).Text;

            this.UserName = inputUsername;
        }

        private void cboUserStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int selectedIndex = (sender as ComboBox).SelectedIndex;

            if (selectedIndex == 0)
            {
                this.TermDate = null;
            }
            else
            {
                this.TermDate = DateTime.Now;
            }
        }

        public void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            string inputUserName = (sender as TextBox).Text;
            string error = null;

            if (string.IsNullOrEmpty(inputUserName))
            {
                error = "Please insert UserName.";
            }

            if (!IsExistingUserName(inputUserName))
            {
                error = "Username already exists.";
            }

            if (!IsValidUserName(inputUserName))
            {
                error = "Username is invalid.";
            }

            errpdUserProfile.SetError((Control)sender, error);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string inputEmail = (sender as TextBox).Text;
            string error = null;

            if (!IsValidEmail(inputEmail))
            {
                error = "Please insert valid Email.";
            }

            errpdUserProfile.SetError((Control)sender, error);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (this.chkUpdatePassWord.Checked && this.txtPassword.Enabled)
            {
                string inputPassword = (sender as TextBox).Text;
                string error = "";
                if (string.IsNullOrEmpty(inputPassword))
                {
                    error = "Please insert new password.";
                }
                errpdUserProfile.SetError(txtPassword, error);
            }
        }

        private void lblInfo_MouseHover(object sender, EventArgs e)
        {
            string caption = "Username conditions: \n" +
                          "- Must be 1 to 24 character(s) in length \n" +
                          "- Must not contain special characters (`,!,@,#,$,%,^,&,*,(,),-) \n";

            ToolTip tooltip = new ToolTip();

            tooltip.SetToolTip(lblInfo, caption);
        }

        private void lboxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lboxRoles.Items.Count; i++)
            {
                lboxRoles.SetItemChecked(i, false);
            }

            Role selected = (Role)lboxRoles.SelectedItem;

            int indx = _listAllRoles.IndexOf(selected);
            lboxRoles.SetItemChecked(indx, true);
        }

        #endregion

        private bool IsValidEmail(string input)
        {
            if (!string.IsNullOrEmpty(input.Trim()) &&
                !Regex.IsMatch(input.Trim(),
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                return false;
            }
            return true;
        }

        public bool IsExistingUserName(string username)
        {
            bool isValid = true;

            if (username.ToLower() != EditingUserName.ToLower())
            {
                using (new HourGlass())
                {
                    User returnedUser = _userApiRepo.Check(username);
                    if (returnedUser != null)
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        public bool IsValidUserName(string username)
        {
            bool isValid = true;

            if (!string.IsNullOrEmpty(username.Trim()) &&
                !Regex.IsMatch(username.Trim(),
                @"^([a-zA-Z0-9_.]){0,23}$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                isValid = false;
            }

            return isValid;
        }

        public void SetError(object sender, EventArgs e, string error)
        {
            errpdUserProfile.SetError(txtUserName, error);
        }

        public void SetErrorForPassword(object sender, EventArgs e, string error)
        {
            errpdUserProfile.SetError(txtPassword, error);
        }

        public void ResetForm()
        {
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.UserId = string.Empty;
            this.Address = string.Empty;
            this.Other = string.Empty;
            this.TermDate = null;
            this.HiredDate = DateTime.Now;
            this.Email = string.Empty;

            errpdUserProfile.Clear();
            this.chkUpdatePassWord.Checked = false;
            this.txtPassword.Clear();
        }

        public bool IsValidationOK()
        {
            bool isValid = true;

            if (errpdUserProfile.GetError(this.txtUserName) != string.Empty)
            {
                isValid = false;
            }
            if (errpdUserProfile.GetError(this.txtEmail) != string.Empty)
            {
                isValid = false;
            }
            if (errpdUserProfile.GetError(this.txtPassword) != string.Empty)
            {
                isValid = false;
            }

            return isValid;
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {

        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            string caption = "Last time user logged in.";

            ToolTip tooltip = new ToolTip();

            tooltip.SetToolTip(label2, caption);
        }
    }
}
