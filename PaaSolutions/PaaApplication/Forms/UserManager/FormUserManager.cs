using BrightIdeasSoftware;
using Common.Infrastructure.ApiClient;
using Common.Infrastructure.OLV;
using Common.Infrastructure.UI;
using IdentityAccess.CommonType;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Infrastructure.Access;
using IdentityAccess.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.UserManager
{
    public partial class FormUserManager : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private OLVColumnFormat _olvFormat = new OLVColumnFormat();
        private UserApiRepository _userApiRepo = new UserApiRepository();
        private RoleApiRepository _roleApiRepo = new RoleApiRepository();
        private List<Role> _listAllRoles = new List<Role>();
        private FormMaster formMaster;

        public User CurrentLoadedUser = null;

        private bool loadCompleted = false;

        public FormUserManager(FormMaster formMaster)
        {
            this.formMaster = formMaster;
            InitializeComponent();
            InitializeSettings();
        }

        public void InitializeSettings()
        {
            this.ListAllRoles();
        }

        public string NewUserName
        {
            get;
            set;
        }

        private void FormUserManager_LoadCompleted(object sender, EventArgs e)
        {
            InitUserObjectListView();
            this.loadCompleted = true;
        }

        private void InitUserObjectListView()
        {
            _olvFormat.FormatDateString(olvColHire);
            _olvFormat.FormatDateString(olvColTerm);

            this.olvColTerm.AspectGetter = delegate(object row)
            {
                User data = (User)row;

                if (data.TerminationDate == ucUserProfile.MinDate || data.TerminationDate == null)
                {
                    return " ";
                }
                else
                {
                    return ((DateTime)data.TerminationDate).ToLocalTime();
                }
            };

            this.olvColHire.AspectGetter = delegate(object row)
            {
                User data = (User)row;

                if (data.HiredDate == ucUserProfile.MinDate || data.HiredDate == null)
                {
                    return " ";
                }
                else
                {
                    return ((DateTime)data.HiredDate).ToLocalTime();
                }
            };

            this.olvColRole.AspectGetter = delegate(object row)
            {
                User data = (User)row;

                return GetRole(data.RoleId).RoleName;
            };

            List<User> listAllUsers = this.ListAllUsers();

            this.olvUsers.SetObjects(listAllUsers);
            this.olvUsers.SelectedIndex = 0;
        }

        #region Users

        public void SetUserControlDataValue(User user)
        {
            try
            {
                this.ucUserProfile.UserName = user.UserName;
                this.ucUserProfile.EditingUserName = user.UserName;
                this.ucUserProfile.Address = user.Address;
                this.ucUserProfile.Email = user.EmailAddress;
                this.ucUserProfile.Other = user.Other;
                this.ucUserProfile.Role = GetRole(user.RoleId);

                if (user.TerminationDate > ucUserProfile.MinDate)
                {
                    this.ucUserProfile.TermDate = ((DateTime)user.TerminationDate).ToLocalTime();
                }
                else
                {
                    this.ucUserProfile.TermDate = null;
                }

                if (user.HiredDate > ucUserProfile.MinDate)
                {
                    this.ucUserProfile.HiredDate = ((DateTime)user.HiredDate).ToLocalTime();
                }
                else
                {
                    this.ucUserProfile.HiredDate = null;
                }

                if (user.LastLogOut == null)
                {
                    this.ucUserProfile.OfflineDuration = "";
                }
                else
                {
                    this.ucUserProfile.OfflineDuration = SetOfflineStatus((DateTime)user.LastLogOut);
                }

                this.ucUserProfile.Avatar = user.Avatar;

                this.ucUserProfile.Status = (int)user.Status;

                if (formMaster != null && formMaster.CURRENT_USER.UserName == user.UserName)
                {
                    this.ucUserProfile.StatusEnabled = false;
                }
                else
                {
                    this.ucUserProfile.StatusEnabled = true;
                }

                if (user.LastLogIn != null)
                {
                    this.ucUserProfile.LastLogin = ((DateTime)user.LastLogIn).ToLocalTime().ToString("MM/dd/yyyy hh:mm tt");
                }
                else
                {
                    this.ucUserProfile.LastLogin = "---";
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void SetUserValueFromControls(User user)
        {
            if (user == null)
                return;

            user.RoleId = ucUserProfile.Role.RoleId.Id;
            user.UserName = this.ucUserProfile.UserName;

            if (!string.IsNullOrEmpty(this.ucUserProfile.Password))
            {
                string password = new User().AsEncryptedValue(this.ucUserProfile.Password);
                user.Password = password;
            }

            user.Address = this.ucUserProfile.Address;
            user.EmailAddress = this.ucUserProfile.Email;
            user.Other = this.ucUserProfile.Other;
            user.HiredDate = this.ucUserProfile.HiredDate;
            user.TerminationDate = this.ucUserProfile.TermDate;
            user.Status = (UserStatus)this.ucUserProfile.Status;
        }
        #endregion Users

        #region control events

        private void olvUsers_SelectionChanged(object sender, EventArgs e)
        {
            this.ReloadForm();
        }

        private void olvUsers_FormatRow(object sender, FormatRowEventArgs e)
        {
            int index = olvUsers.Columns.IndexOf(olvColNumRow);
            if (index >= 0)
            {
                e.Item.SubItems[index].Text = (e.DisplayIndex + 1).ToString();
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            try
            {
                FormUserMgmAddNew formAddNew = new FormUserMgmAddNew();
                formAddNew.StartPosition = FormStartPosition.CenterParent;
                DialogResult dialogResult = formAddNew.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    this.NewUserName = formAddNew.NewUserName;

                    User newUser = new User();
                    newUser.UserName = this.NewUserName;
                    newUser.Status = UserStatus.Active;
                    newUser.HiredDate = DateTime.Now.ToUniversalTime();
                    newUser.RoleId = GetDedaultRole().RoleId.Id;
                    newUser.Password = newUser.AsEncryptedValue(formAddNew.Password);
                    newUser.Address = string.Empty;
                    newUser.EmailAddress = string.Empty;
                    newUser.Other = string.Empty;

                    //default avatar

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        (Properties.Resources.admin).Save(memoryStream, ImageFormat.Png);
                        byte[] imageData = memoryStream.ToArray();
                        newUser.Avatar = imageData;
                    }
                    //
                    ResetForm();
                    SetUserControlDataValue(newUser);
                    
                    UserId userId = new UserId(_userApiRepo.Add(newUser));
                    CurrentLoadedUser = newUser;
                    newUser.UserId = userId;
                    if (newUser.HiredDate != null)
                    {
                        newUser.HiredDate = ((DateTime)newUser.HiredDate).ToLocalTime();
                    }

                    if (newUser.TerminationDate != null)
                    {
                        newUser.TerminationDate = ((DateTime)newUser.TerminationDate).ToLocalTime();
                    }

                    List<User> list = new List<User>();
                    list.Add(newUser);

                    this.olvUsers.InsertObjects(0, list);
                    this.olvUsers.SelectedIndex = 0;

                    UserCachedApiQuery.Instance.RefreshCacheActiveUsers();
                    formMaster.InitializeChangeLocation();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string strSearch = (sender as TextBox).Text;
            bool filter = false;

            ObjectListViewService olv_service = new ObjectListViewService();

            if (e.KeyCode == Keys.Back && strSearch.Length == 0)
            {
                strSearch = string.Empty;
                olv_service.FilterOlv(this.olvUsers, strSearch);
                filter = true;
            }
            else if (e.KeyCode == Keys.Enter && strSearch.Length > 0)
            {
                olv_service.FilterOlv(this.olvUsers, strSearch);
                filter = true;
            }

            if (filter)
            {
                if (this.olvUsers.Items.Count > 0)
                {
                    this.olvUsers.SelectedIndex = 0;
                }
                else
                {
                    this.ucUserProfile.ResetForm();
                    ucUserProfile.Role = GetDedaultRole();
                }
            }
        }

        #endregion control events

        #region Calculations

        private string SetOfflineStatus(DateTime lastOnlineUtc)
        {
            if (lastOnlineUtc == null)
            {
                return "";
            }

            double offlineInMinutes = GetOfflineDurationInMinutes(lastOnlineUtc);

            string status = string.Format("{0} {1} ago", offlineInMinutes, "minutes");

            if (lastOnlineUtc == ucUserProfile.MinDate)
            {
                return status = "---";
            }

            if (offlineInMinutes >= 60)
            {
                decimal offlineInHours = (decimal)offlineInMinutes / 60;
                decimal roundedValue = RoundNumber(offlineInHours);

                status = string.Format("{0} {1} ago", roundedValue, "hours");
            }
            if (offlineInMinutes >= 1440)
            {
                decimal offlineInDays = (decimal)offlineInMinutes / 1440;
                decimal roundedValue = RoundNumber(offlineInDays);

                string unit = "day";

                if (roundedValue > 1)
                {
                    unit = "days";
                }

                status = string.Format("{0} {1} ago", roundedValue, unit);
            }
            if (offlineInMinutes >= 43200)
            {
                decimal offlineInMonths = (decimal)offlineInMinutes / 43200;
                decimal roundedValue = Math.Round(offlineInMonths, MidpointRounding.AwayFromZero);

                string unit = "month";

                if (roundedValue > 1)
                {
                    unit = "months";
                }

                status = string.Format("{0} {1} ago", roundedValue, unit);
            }
            if (offlineInMinutes >= 518400)
            {
                decimal offlineInYear = (decimal)offlineInMinutes / 518400;
                decimal roundedValue = Math.Round(offlineInYear, MidpointRounding.AwayFromZero);

                string unit = "year";

                if (roundedValue > 1)
                {
                    unit = "years";
                }

                status = string.Format("{0} {1} ago", roundedValue, unit);
            }

            return status;
        }

        private decimal RoundNumber(decimal number)
        {
            decimal result = number * 2;

            result = Math.Round(result, MidpointRounding.AwayFromZero) / 2;

            return result;
        }

        private double GetOfflineDurationInMinutes(DateTime lastOnlineUtc)
        {
            double minutes = 0;

            DateTime localLastOnline = lastOnlineUtc.ToLocalTime();
            DateTime currentTime = DateTime.Now;

            minutes = (currentTime - localLastOnline).TotalMinutes;

            return minutes;
        }

        #endregion Calculations

        #region others

        private void ResetForm()
        {
            this.ucUserProfile.UserName = string.Empty;
            this.ucUserProfile.Password = string.Empty;
            this.ucUserProfile.Email = string.Empty;
            this.ucUserProfile.Status = 0;
            this.ucUserProfile.HiredDate = DateTime.Now;
            this.ucUserProfile.TermDate = DateTime.Now;
            this.ucUserProfile.Address = string.Empty;
            this.ucUserProfile.Other = string.Empty;
            this.ucUserProfile.OfflineDuration = string.Empty;
            this.ucUserProfile.EditingUserName = string.Empty;
        }

        private void UpdateRowObjectListView()
        {
            User selectedUser = (User)this.olvUsers.SelectedObject;
            SetUserValueFromControls(selectedUser);
            this.olvUsers.RefreshObject(selectedUser);
        }

        public User GetSelectedUser()
        {
            if (this.olvUsers.Items.Count > 0 && this.olvUsers.SelectedObjects.Count > 0)
            {
                User user = olvUsers.SelectedObjects[olvUsers.SelectedObjects.Count - 1] as User;
                return user;
            }
            return null;
        }

        #endregion others

        #region call api

        public List<User> ListAllUsers()
        {            
            return formMaster.LIST_USERS;
        }

        public Task<bool> SaveUserAsync(User user)
        {
            return Task.Run(() => 
            {
                try
                {
                    if (user == null)
                        return false;
                    _userApiRepo.Update(user);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return false;
                }
            });
        }

        public void UpdateUser()
        {
            try
            {
                if (string.IsNullOrEmpty(ucUserProfile.Password) && ucUserProfile.IsCheckedUpdatePassword)
                {
                    ucUserProfile.SetErrorForPassword(new object(), null, "Please insert new password. Otherwise, please uncheck the checkbox.");
                }

                if (!ucUserProfile.IsExistingUserName(ucUserProfile.UserName) && ucUserProfile.UserName != ucUserProfile.EditingUserName)
                {
                    ucUserProfile.SetError(new object(), null, "UserName already exists.");
                }
                else
                {
                    ucUserProfile.SetError(new object(), null, "");
                }

                if (!ucUserProfile.IsValidUserName(ucUserProfile.UserName))
                {
                    ucUserProfile.SetError(new object(), null, "UserName is invalid.");
                }

                if (!ucUserProfile.IsValidationOK())
                {
                    MessageBox.Show("Some input are invalid. Please check again.", "Save User Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                olvUsers.Invoke((Action)(() =>
                {
                    User selectedUser = this.olvUsers.SelectedObject as User;

                    if (selectedUser == null)
                    {
                        return;
                    }

                    if (selectedUser.UserId != null)
                    {
                        string password = selectedUser.Password;

                        if (!string.IsNullOrEmpty(this.ucUserProfile.Password))
                        {
                            password = new User().AsEncryptedValue(this.ucUserProfile.Password);
                        }

                        DateTime? terminationDate = ucUserProfile.TermDate;

                        if (ucUserProfile.TermDate == ucUserProfile.MinDate)
                        {
                            terminationDate = null;
                        }

                        UserStatus userStatus = (UserStatus)ucUserProfile.Status;

                        User toUpdateUser = new User();
                        toUpdateUser.UserId = selectedUser.UserId;
                        toUpdateUser.UserName = ucUserProfile.UserName;
                        toUpdateUser.Password = password;
                        toUpdateUser.Address = ucUserProfile.Address;
                        toUpdateUser.EmailAddress = ucUserProfile.Email;
                        toUpdateUser.Status = userStatus;

                        Role selectedRole = ucUserProfile.Role;

                        if (selectedRole == null)
                        {
                            MessageBox.Show("Please select role for user.", "Save User Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            return;
                        }
                        else
                        {
                            toUpdateUser.RoleId = ucUserProfile.Role.RoleId.Id;
                        }

                        toUpdateUser.HiredDate = ((DateTime)ucUserProfile.HiredDate).ToUniversalTime();

                        if (terminationDate != null)
                        {
                            toUpdateUser.TerminationDate = ((DateTime)terminationDate).ToUniversalTime();
                        }
                        else
                        {
                            toUpdateUser.TerminationDate = terminationDate;
                        }

                        toUpdateUser.LastLogIn = selectedUser.LastLogIn;
                        toUpdateUser.LastLogOut = selectedUser.LastLogOut;
                        toUpdateUser.Other = ucUserProfile.Other;
                        toUpdateUser.Avatar = selectedUser.Avatar;

                        _userApiRepo.Update(toUpdateUser);
                        this.UpdateRowObjectListView();
                        ucUserProfile.EditingUserName = ucUserProfile.UserName;
                    }
                }));
                UserCachedApiQuery.Instance.RefreshCacheActiveUsers();
                formMaster.InitializeChangeLocation();
                if (!formMaster.LIST_USERS.Contains(CurrentLoadedUser))
                {
                    formMaster.LIST_USERS.Add(CurrentLoadedUser);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Unable to update!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                throw;
            }
        }

        public void DeleteUser()
        {
            User selectedUser = (User)this.olvUsers.SelectedObject;

            if (selectedUser != null)
            {
                if (formMaster != null && formMaster.CURRENT_USER.UserName == selectedUser.UserName)
                {
                    MessageBox.Show("You can't delete your own data.", "Can't delete user", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure to delete user '" + selectedUser.UserName + "'?", "Delete User",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                {
                    _userApiRepo.Remove(selectedUser);
                    this.olvUsers.RemoveObject(selectedUser);

                    if (olvUsers.Items.Count > 0)
                    {
                        this.olvUsers.SelectedIndex = 0;
                    }
                    else
                    {
                        ucUserProfile.ResetForm();
                    }
                }

                formMaster.RefreshCacheActiveUsers();
            }
            else
            {
                MessageBox.Show("Please select user to delete.", "No User selected", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        public List<Role> ListAllRoles()
        {
            _listAllRoles = _roleApiRepo.FindAll();
            ucUserProfile.AllRoles = _listAllRoles;

            return _listAllRoles;
        }

        private Role GetRole(string id)
        {
            Role role = new Role();

            role = (from r in _listAllRoles
                    where r.RoleId.Id == id
                    select r).First();

            return role;
        }

        private Role GetDedaultRole()
        {
            Role role = new Role();

            role = (from r in _listAllRoles
                    where r.RoleName == "Screener"
                    select r).First();

            return role;
        }

        #endregion call api

        public void ReloadForm()
        {
            ucUserProfile.ResetForm();
            User selectedUser = (User)olvUsers.SelectedObject;

            if (selectedUser != null)
            {
                SetUserControlDataValue(selectedUser);
            }
            CurrentLoadedUser = selectedUser;
        }

        public void RefreshUserData(User selectedUser)
        {
            List<User> users = this.ListAllUsers();

            if (users == null || users.Count == 0)
            {
                this.olvUsers.ClearObjects();
                return;
            }
            this.olvUsers.SetObjects(users);

            if (selectedUser == null || string.IsNullOrEmpty(selectedUser.UserId.Id))
            {
                this.olvUsers.SelectedIndex = 0;
                this.olvUsers.EnsureVisible(0);
                return;
            }

            for (int i = 0; i < this.olvUsers.Items.Count; i++)
            {
                User item = (User)this.olvUsers.GetModelObject(i);
                if (item != null && !string.IsNullOrEmpty(item.UserId.Id) &&
                    item.UserId.Id.Equals(selectedUser.UserId.Id))
                {
                    this.olvUsers.SelectedIndex = i;
                    this.olvUsers.EnsureVisible(i);
                    break;
                }
            }
        }

        public void RefreshData()
        {
            try
            {
                User selectedUser = this.olvUsers.SelectedObject as User;
                this.RefreshUserData(selectedUser);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        private void FormUserManager_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && this.loadCompleted)
            {
                this.ReloadForm();
            }
        }
    }
}