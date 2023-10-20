using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaaApplication.Views;
using PaaApplication.Presenters;
using IdentityAccess.Infrastructure.Identity;
using Common.Infrastructure.UI;
using System.Text.RegularExpressions;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.CommonType;
using IdentityAccess.Infrastructure.Access;
using TimeCard.Infrastructure.TimeCard;
using TimeCard.Command;
using System.Net;
using System.IO;

namespace PaaApplication.Forms
{
    public partial class FormLogin : Form
    {
        FormMaster formMaster;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public FormLogin()
        {
            InitializeComponent();

            formMaster = new FormMaster();
            formMaster.FormClosing += formMaster_FormClosing;
        }

        void formMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                formMaster.Hide();

                if (e.CloseReason == CloseReason.None)
                {
                    this.txtPassword.Clear();
                    formMaster.Owner.Show();
                }
                else
                {
                    formMaster.FormClosing -= formMaster_FormClosing;
                    formMaster.Owner.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        #region control events

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserApiRepository api = new UserApiRepository();
                RoleApiRepository role_api = new RoleApiRepository();

                string username = txtUsername.Text;
                string password = txtPassword.Text;

                User user = null;

                using (new HourGlass())
                {
                    user = api.Login(username, password);                    
                }

                if (user != null)
                {
                    if (user.Status == UserStatus.Blocked || user.Status == UserStatus.Disabled)
                    {
                        lblLoginError.Visible = true;
                        lblLoginError.Text = "User has been blocked or disabled.";
                        return;
                    }
                    else
                    {
                        lblLoginError.Visible = false;

                        TimeCardApiRepository timecardApiRepository = new TimeCardApiRepository();
                        NewTimeCardCommand command = new NewTimeCardCommand(user.UserId.Id);

                        timecardApiRepository.UpdateTimeCardWhenLogin(command);

                        using (new HourGlass())
                        {
                            this.Hide();
                            formMaster.CURRENT_USER = user;
                            formMaster.CURRENT_ROLE = role_api.Find(user.RoleId);
                            formMaster.CurrentLocation = new Core.Application.Data.ExploreApps.LocationData(user.UserId.Id, user.UserName);
                            formMaster.InitializeButtonLocations();
                            formMaster.Show(this);
                        }
                    }
                }
                else
                {
                    lblLoginError.Text = "Username / Password is invalid";
                    lblLoginError.Visible = true;
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Login failed!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            string input = (sender as TextBox).Text;
            string error = "";

            if (string.IsNullOrEmpty(input))
            {
                error = "Username is required!";
            }

            if (!IsValidUserName(input))
            {
                error = "Invalid username!";
            }

            errorProvider.SetError(txtUsername, error);

            if (ValidInputValidation())
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            string input = (sender as TextBox).Text;
            string error = "";

            if (string.IsNullOrEmpty(input))
            {
                error = "Password is required!";
            }
            errorProvider.SetError(txtPassword, error);
            if (ValidInputValidation())
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string input = (sender as TextBox).Text;

            if (!string.IsNullOrEmpty(input))
            {
                errorProvider.SetError(txtPassword, "");
            }
            if (ValidInputValidation())
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            string input = (sender as TextBox).Text;

            if (!string.IsNullOrEmpty(input))
            {
                errorProvider.SetError(txtUsername, "");
            }

            if (!IsValidUserName(input))
            {
                errorProvider.SetError(txtUsername, "Invalid username!");
            }
            else
            {
                errorProvider.SetError(txtUsername, "");
            }

            if (ValidInputValidation())
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        #endregion

        private bool ValidInputValidation()
        {
            if (errorProvider.GetError(txtUsername) != "" || txtUsername.Text == "")
            {
                return false;
            }

            if (errorProvider.GetError(txtPassword) != "" || txtPassword.Text == "")
            {
                return false;
            }

            return true;
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
    }
}
