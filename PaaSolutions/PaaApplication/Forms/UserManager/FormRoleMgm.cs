using BrightIdeasSoftware;
using Common.Infrastructure.OLV;
using Common.Infrastructure.UI;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Infrastructure.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.UserManager
{
    public partial class FormRoleMgm : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private RoleApiRepository _roleApiRepo = new RoleApiRepository();

        private List<Role> _listAllTRoles = new List<Role>();
        private string _editingRoleName = "";

        FormMaster _formMaster;

        public FormRoleMgm()
        {
        }

        public FormRoleMgm(FormMaster formMaster)
        {
            _formMaster = formMaster;
            InitializeComponent();
        }

        private void FormRoleMgm_Load(object sender, EventArgs e)
        {
            this.treelvFeaturePermission.ChildrenGetter = delegate(object x)
            {
                RootFeaturePermission feature = x as RootFeaturePermission;
                if (feature == null)
                    return null;
                return feature.Children;
            };

            this.treelvFeaturePermission.CanExpandGetter = delegate(object x)
            {
                RootFeaturePermission feature = x as RootFeaturePermission;
                if (feature == null)
                    return false;
                return (feature.Children.Count > 0);
            };
        }

        private void FormRoleMgm_LoadCompleted(object sender, EventArgs e)
        {
            InitObjectListView();
            this.olvRoles.SelectedIndex = 0;
        }

        #region call api

        private List<Role> ListAllRoles()
        {
            _listAllTRoles = _formMaster.LIST_ROLES;

            return _listAllTRoles;
        }

        #endregion

        #region control events

        private void olvRoles_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            int index = olvRoles.Columns.IndexOf(olvColNumRow);
            if (index >= 0)
            {
                e.Item.SubItems[index].Text = (e.DisplayIndex + 1).ToString();
            }
        }

        private void olvRoles_SelectionChanged(object sender, EventArgs e)
        {
            Role selectedRole = (Role)this.olvRoles.SelectedObject;

            if (selectedRole != null && selectedRole.RoleId != null)
            {
                InitListTreeView();
                this.txtRoleName.Text = selectedRole.RoleName;
                this.txtCreatedBy.Text = selectedRole.CreateBy;
                this.txtRemark.Text = selectedRole.Remark;

                _editingRoleName = selectedRole.RoleName;
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            Role newRole = new Role();
            newRole.CreateBy = _formMaster.CURRENT_USER.UserName;
            newRole.Remark = string.Empty;

            this.txtCreatedBy.Text = newRole.CreateBy;

            List<Role> listRole = new List<Role>();

            ResetForm();

            FormRoleMgmAddNew formAddNew = new FormRoleMgmAddNew();
            formAddNew.StartPosition = FormStartPosition.CenterParent;

            if (formAddNew.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!this.isAvailableRoleName(formAddNew.NewRoleName))
                {
                    MessageBox.Show("Role Name is not available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                newRole.RoleName = formAddNew.NewRoleName;
                this.txtRoleName.Text = newRole.RoleName;

                RoleCachedApiQuery roleCachedApiQuery = RoleCachedApiQuery.Instance;

                List<FeaturePermission> featurePermission = roleCachedApiQuery.ListFeaturePermission();
                roleCachedApiQuery.RemoveAllFeaturePermissions();

                newRole.FeaturePermissions = featurePermission;

                string insert_id = _roleApiRepo.Add(newRole);

                RoleId roleId = new RoleId(insert_id);
                newRole.RoleId = roleId;

                listRole.Add(newRole);

                this.olvRoles.InsertObjects(0, listRole);
                this.olvRoles.SelectedIndex = 0;
            }
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            this.DeleteRole();
        }

        private void txtRoleName_Validating(object sender, CancelEventArgs e)
        {
            string roleName = (sender as TextBox).Text;

            using (new HourGlass())
            {
                if (!roleName.Equals(_editingRoleName) && !this.isAvailableRoleName(roleName))
                {
                    SetError("Role Name already exists.");
                }

                else if (string.IsNullOrEmpty(roleName))
                {
                    SetError("Please insert Role Name.");
                }

                else SetError();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string strSearch = (sender as TextBox).Text;
            bool filter = false;

            ObjectListViewService olv_service = new ObjectListViewService();

            if (e.KeyCode == Keys.Back && strSearch.Length == 0)
            {
                strSearch = string.Empty;
                olv_service.FilterOlv(this.olvRoles, strSearch);
                filter = true;
            }
            else if (e.KeyCode == Keys.Enter && strSearch.Length > 0)
            {
                olv_service.FilterOlv(this.olvRoles, strSearch);
                filter = true;
            }

            if (filter)
            {
                if (this.olvRoles.Items.Count > 0)
                {
                    this.olvRoles.SelectedIndex = 0;
                }
                else
                {
                    this.ResetForm();
                }
            }
        }

        #endregion

        private void InitObjectListView()
        {
            List<Role> listRoles = this.ListAllRoles();

            if (listRoles != null)
            {
                this.olvRoles.SetObjects(listRoles);
            }
        }

        private void InitListTreeView()
        {
            try
            {
                Role selectedRole = (Role)this.olvRoles.SelectedObject;
                List<RootFeaturePermission> rootPermissions = selectedRole.GetRootFeaturePermission();

                this.treelvFeaturePermission.Roots = rootPermissions;
                this.treelvFeaturePermission.SetObjects(rootPermissions);
                this.treelvFeaturePermission.CheckedObjects = GetCheckedList(rootPermissions);

                this.treelvFeaturePermission.ExpandAll();

                treelvFeaturePermission.RebuildAll(true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                throw;
            }
        }

        private List<FeaturePermission> GetCheckedList(List<RootFeaturePermission> listFeaturePermissions)
        {
            List<FeaturePermission> list = new List<FeaturePermission>();

            foreach (RootFeaturePermission item in listFeaturePermissions)
            {
                if (!item.Children.Any())
                {
                    if (item.IsAllowed)
                    {
                        list.Add(item);
                    }
                }
                else
                {
                    foreach (FeaturePermission child in item.Children)
                    {
                        if (child.IsAllowed)
                        {
                            list.Add(child);
                        }
                    }
                }
            }

            return list;
        }

        public void UpdateRole()
        {
            try
            {
                Role role = (Role)olvRoles.SelectedObject;

                if (role == null)
                {
                    MessageBox.Show("Please select role to update.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                this.txtRoleName_Validating(txtRoleName, null);

                if (!this.IsValidationOK())
                {
                    MessageBox.Show("Some input are invalid. Please check again.", "Save User Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                List<FeaturePermission> updatedFeature = GetNewTree();

                role.FeaturePermissions = updatedFeature;
                role.RoleName = this.txtRoleName.Text.Trim();
                role.Remark = this.txtRemark.Text.Trim();
                role.CreateBy = _formMaster.CURRENT_USER.UserName;

                using (new HourGlass())
                {
                    _roleApiRepo.Update(role);
                    this.olvRoles.RefreshObject(role);
                    _editingRoleName = role.RoleName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
                throw;
            }
        }

        public void DeleteRole()
        {
            Role selectedRole = (Role)this.olvRoles.SelectedObject;

            if (selectedRole == null)
            {
                MessageBox.Show("Please select role to delete.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show(string.Format("Are you sure to delete role '{0}' ?", selectedRole.RoleName),
                    "Delete Role", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    using (new HourGlass())
                    {
                        try
                        {
                            _roleApiRepo.Remove(selectedRole);
                            olvRoles.RemoveObject(selectedRole);
                            if (olvRoles.Items.Count > 0)
                            {
                                olvRoles.SelectedIndex = 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Format("Can't delete role '{0}'. It is being shared by other features. ", selectedRole.RoleName),
                                "Can't Delete Role", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        public List<FeaturePermission> GetNewTree()
        {
            RoleCachedApiQuery roleCachedApiQuery = RoleCachedApiQuery.Instance;

            List<FeaturePermission> list = roleCachedApiQuery.ListFeaturePermission();
            roleCachedApiQuery.RemoveAllFeaturePermissions();

            foreach (FeaturePermission item in treelvFeaturePermission.CheckedObjects)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    if (item.FeatureId == list[i].FeatureId)
                    {
                        list[i].IsAllowed = true;
                    }
                }
            }

            return list;
        }

        private void ResetForm()
        {
            this.txtRemark.Clear();
            this.txtRoleName.Clear();
            this.txtCreatedBy.Clear();
            this.treelvFeaturePermission.UncheckAll();
        }

        public bool isAvailableRoleName(string roleName)
        {
            if (_roleApiRepo.FindByName(roleName) != null)
            {
                return false;
            }
            return true;
        }

        private void SetError(string error = "")
        {
            errorProvider.SetError(this.txtRoleName, error);
        }

        private bool IsValidationOK()
        {
            if (this.errorProvider.GetError(txtRoleName) == "")
            {
                return true;
            }
            else return false;
        }

        private Role GetSelectedRole()
        {
            if (this.olvRoles.Items.Count > 0 && this.olvRoles.SelectedObjects.Count > 0)
            {
                Role role = (Role)olvRoles.SelectedObjects[olvRoles.SelectedObjects.Count - 1];
                return role;
            }
            return null;
        }

        public void RefreshData()
        {
            try
            {
                Role selectedRole = GetSelectedRole();
                this.RefreshRoleData(selectedRole);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void RefreshRoleData(Role selectedRole)
        {
            List<Role> roles = this.ListAllRoles();

            if (roles == null || roles.Count == 0)
            {
                this.olvRoles.ClearObjects();
                return;
            }
            this.olvRoles.SetObjects(roles);

            if (selectedRole == null || string.IsNullOrEmpty(selectedRole.RoleId.Id))
            {
                this.olvRoles.SelectedIndex = 0;
                this.olvRoles.EnsureVisible(0);
                return;
            }

            for (int i = 0; i < this.olvRoles.Items.Count; i++)
            {
                Role item = (Role)this.olvRoles.GetModelObject(i);
                if (item != null && !string.IsNullOrEmpty(item.RoleId.Id) &&
                    item.RoleId.Id.Equals(selectedRole.RoleId.Id))
                {
                    this.olvRoles.SelectedIndex = i;
                    this.olvRoles.EnsureVisible(i);
                    break;
                }
            }
        }
    }

}
