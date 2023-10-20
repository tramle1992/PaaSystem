using Common.Infrastructure.UI;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Infrastructure.Access;
using IdentityAccess.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.UserManager
{
    public partial class FormUserProfile : Form
    {
        FormMaster _formMaster;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormUserProfile()
        { }

        public FormUserProfile(FormMaster formMaster)
        {
            InitializeComponent();
            this._formMaster = formMaster;
        }

        private const int MAXIMUM_IMAGE_SIZE = 1048576; // 1MB
        private const int MAXIMUM_IMAGE_WIDTH = 100;
        private const int MAXIMUM_IMAGE_HEIGHT = 100;

        UserApiRepository apiRepository = new UserApiRepository();

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            User user = _formMaster.CURRENT_USER;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = GetImageFilter();
            dialog.Title = "Select an image";

            dialog.FileOk += delegate(object delegateSender, CancelEventArgs delegateArgs)
            {
                long fileSize = new FileInfo(dialog.FileName).Length;
                if (fileSize > MAXIMUM_IMAGE_SIZE)
                {
                    MessageBox.Show("Sorry, file has exceeded 1MB!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    delegateArgs.Cancel = true;
                }
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (new HourGlass())
                {
                    Image originalImage = Image.FromFile(dialog.FileName);
                    Image resizedImage = ResizeImage(originalImage,
                        new Size(MAXIMUM_IMAGE_WIDTH, MAXIMUM_IMAGE_HEIGHT), true);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        resizedImage.Save(memoryStream, ImageFormat.Png);
                        byte[] imageData = memoryStream.ToArray();
                        if (imageData.Length > 0)
                        {
                            picAvatar.Image = resizedImage;
                            if (user != null)
                            {
                                user.Avatar = imageData;

                                using (new HourGlass())
                                {
                                    Image masterAvatar = ResizeImage(originalImage, new Size(80, 53), true);
                                    _formMaster.UserAvatar = masterAvatar;

                                    apiRepository.Update(user);
                                }
                            }
                        }
                    }
                }
            }
        }

        #region Image handles

        public Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            if (image.Width < size.Width && image.Height < size.Height)
            {
                return image;
            }

            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }

            Image newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        public string GetImageFilter()
        {
            StringBuilder allImageExtensions = new StringBuilder();
            string separator = "";
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            Dictionary<string, string> images = new Dictionary<string, string>();
            foreach (ImageCodecInfo codec in codecs)
            {
                allImageExtensions.Append(separator);
                allImageExtensions.Append(codec.FilenameExtension);
                separator = ";";
                images.Add(string.Format("{0} Files: ({1})", codec.FormatDescription, codec.FilenameExtension),
                           codec.FilenameExtension);
            }
            StringBuilder sb = new StringBuilder();
            if (allImageExtensions.Length > 0)
            {
                sb.AppendFormat("{0}|{1}", "All Images", allImageExtensions.ToString());
            }
            foreach (KeyValuePair<string, string> image in images)
            {
                sb.AppendFormat("|{0}|{1}", image.Key, image.Value);
            }
            return sb.ToString();
        }

        #endregion

        private void FormUserProfile_Load(object sender, EventArgs e)
        {
        }
       
        private void LoadData(User user)
        {
            ResetForm();
            chkUpdatePassWord.Checked = false;
            try
            {
                if (user.Avatar != null)
                {
                    if (user.Avatar.Length > 0)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(user.Avatar))
                        {
                            picAvatar.Image = Image.FromStream(memoryStream);
                        }
                    }
                }

                this.lblUserName.Text = user.UserName;
                this.txtUserName.Text = user.UserName;
                this.txtStatus.Text = user.Status.ToString();

                this.dtmHiredDate.Value = ((DateTime)user.HiredDate).ToLocalTime();

                if (user.TerminationDate == null || user.TerminationDate == dtnTermDate.MinDate)
                {
                    this.dtnTermDate.CustomFormat = " ";
                }
                else
                {
                    this.dtnTermDate.Value = (DateTime)user.TerminationDate;
                }

                this.txtEmail.Text = user.EmailAddress;
                this.txtOther.Text = user.Other;
                this.txtAddress.Text = user.Address;

                List<Role> listRoles = this.GetListRole();

                lboxRoles.ValueMember = "RoleId";
                lboxRoles.DisplayMember = "RoleName";
                lboxRoles.Enabled = false;

                if (listRoles != null)
                {
                    if (listRoles.Count > 0)
                    {
                        foreach (Role item in listRoles)
                        {
                            lboxRoles.Items.Add(item);
                        }
                    }
                }

                if (user.LastLogIn != null)
                {
                    lblLastLogin.Text = ((DateTime)user.LastLogIn).ToLocalTime().ToString("MM/dd/yyyy hh:mm tt");
                }
                else
                {
                    lblLastLogin.Text = "---";
                }

                Role role_query = (from r in listRoles
                                   where r.RoleId.Id == user.RoleId
                                   select r).First();

                int indx = listRoles.IndexOf(role_query);
                lboxRoles.SetItemChecked(indx, true);
                lboxRoles.TopIndex = indx;

            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private List<Role> GetListRole()
        {
            List<Role> list = new List<Role>();

            RoleApiRepository roleApi = new RoleApiRepository();

            list = roleApi.FindAll();

            return list;
        }

        public void UpdateUser()
        {
            try
            {
                ValidatePassword();

                if (!ValidationOK())
                {
                    MessageBox.Show("Some input are invalid. Please check again.", "Update failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                User user = _formMaster.CURRENT_USER;

                user.Address = txtAddress.Text;
                user.EmailAddress = txtEmail.Text;
                user.Other = txtOther.Text;

                if (chkUpdatePassWord.Checked)
                {
                    string new_encrypted_pass = user.AsEncryptedValue(txtPassword.Text);
                    user.Password = new_encrypted_pass;
                }

                _formMaster.CURRENT_USER = user;

                using (new HourGlass())
                {
                    apiRepository.Update(user);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                using (new HourGlass())
                {
                    UpdateUser();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void chkUpdatePassWord_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;

            if (checkbox.Checked)
            {
                this.txtPassword.Enabled = true;
                txtPassword.Focus();
                txtPassword.Clear();
            }
            else
            {
                User user = _formMaster.CURRENT_USER;
                this.txtPassword.Enabled = false;
                this.errpdUserProfile.SetError(txtPassword, "");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string emailInput = (sender as TextBox).Text;
            string err = "";

            if (!string.IsNullOrEmpty(emailInput) && !IsValidEmail(emailInput))
            {
                err = "Please enter valid email.";
            }

            errpdUserProfile.SetError(txtEmail, err);
        }

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

        private void ValidatePassword()
        {
            if (this.chkUpdatePassWord.Checked && string.IsNullOrEmpty(txtPassword.Text))
            {
                errpdUserProfile.SetError(txtPassword, "Please enter new Password. Otherwise, please uncheck the checkbox.");
            }
            else
            {
                errpdUserProfile.SetError(txtPassword, "");
            }
        }

        private bool ValidationOK()
        {
            if (errpdUserProfile.GetError(txtEmail) != "")
            {
                return false;
            }

            if (errpdUserProfile.GetError(txtPassword) != "")
            {
                return false;
            }
            return true;
        }

        private void FormUserProfile_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                User user = _formMaster.CURRENT_USER;

                if (user != null)
                {
                    LoadData(user);
                }
            }
        }

        private void ResetForm()
        {
            txtAddress.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtOther.Clear();
            lboxRoles.Items.Clear();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            string caption = "Time you've just logged in.";

            ToolTip tooltip = new ToolTip();

            tooltip.SetToolTip(label2, caption);
        }

    }
}
