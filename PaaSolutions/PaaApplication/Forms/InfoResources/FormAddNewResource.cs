using Common.Infrastructure.ApiClient;
using InfoResource.Application.Command;
using InfoResource.Application.Data;
using InfoResource.Infrastructure.InfoResource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms
{
    public partial class FormAddNewResource : Form
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private InfoResourceApiRepository infoResourceApiRepository = new InfoResourceApiRepository();
        private InfoResourceCachedApiQuery infoResourceCachedApiQuery = InfoResourceCachedApiQuery.Instance;
        private ResourceTypeCachedApiQuery resourceTypeCachedApiQuery = ResourceTypeCachedApiQuery.Instance;
        private FormEditInfoResources formEditInforResources;

        private ResourceTypeData resourceType;
        private InfoResourceType currentType;

        public string ResourceId;

        public string ResourceName
        {
            get { return txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public string Target
        {
            get { return txtTarget.Text; }
            set { this.txtTarget.Text = value; }
        }

        public string Phone
        {
            get { return txtPhone.Text; }
            set { this.txtPhone.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { this.txtEmail.Text = value; }
        }

        public string Other
        {
            get { return txtOther.Text; }
            set { this.txtOther.Text = value; }
        }        

        public ResourceTypeData ResourceType
        {
            get { return resourceType; }
            set { this.resourceType = value; }
        }

        public InfoResourceType CurrentType
        {
            get { return currentType; }
            set { this.currentType = value; }
        }

        public FormAddNewResource()
        {
            InitializeComponent();
        }

        private string AddNewResource(ResourceData item)
        {
            string newId = "";
            try
            {
                newId = infoResourceApiRepository.Add(item);
                if (!string.IsNullOrEmpty(newId))
                {
                    ResourceData newData = infoResourceCachedApiQuery.GetResourceItem(newId);
                    this.ResourceId = newData.ResourceId;
                    this.ResourceName = newData.Name;
                    this.Target = newData.Target;
                    this.Other = newData.Comment;
                    this.Phone = newData.Phone;
                    this.Email = newData.Email;
                    this.ResourceType = newData.ResourceTypeData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
            return newId;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                bool hasError = true;
                List<ResourceTypeData> listResourceTypeData = resourceTypeCachedApiQuery.GetAllItems();

                if (listResourceTypeData != null && listResourceTypeData.Count > 0)
                {
                    ResourceTypeData resourceType = (from rsType in listResourceTypeData
                                                     where rsType.Name == CurrentType.ToString()
                                                     select rsType).FirstOrDefault();

                    if (resourceType != null)
                    {
                        ResourceData data = new ResourceData();
                        data.Name = this.ResourceName;
                        data.Target = this.Target;
                        data.Comment = this.Other;
                        this.Phone = this.Phone;
                        this.Email = this.Email;
                        data.ResourceTypeData = resourceType;
                        string newId = AddNewResource(data);
                        if (!string.IsNullOrEmpty(newId))
                        {
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                            hasError = false;
                        }
                    }
                }

                if (hasError)
                {
                    MessageBox.Show("Some errors occur! Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            if (txtName.Text.Length == 0)
            {
                error = "Please enter Item Name";
                btnAddNew.Enabled = false;
            }
            else
            {
                btnAddNew.Enabled = true;
            }
            errpdNewInfoRs.SetError((Control)sender, error);
        }

        private void FormAddNewResource_Shown(object sender, EventArgs e)
        {
            this.txtName.Focus();
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string error = null;

            if (string.IsNullOrEmpty(txtPhone.Text)) return;

            if (!Helper.Utils.IsValidPhoneNumer(txtPhone.Text))
            {
                error = "Phone is invalid";
                errpdNewInfoRs.SetError((Control)sender, error);
                btnAddNew.Enabled = false;
            }
            else
            {
                btnAddNew.Enabled = true;
            }

            errpdNewInfoRs.SetError((Control)sender, error);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string error = null;

            if (string.IsNullOrEmpty(txtEmail.Text)) return;

            if (!Helper.Utils.IsValidEmail(txtEmail.Text))
            {
                error = "Email is invalid";
                errpdNewInfoRs.SetError((Control)sender, error);
                btnAddNew.Enabled = false;
            }
            else
            {
                btnAddNew.Enabled = true;
            }
            errpdNewInfoRs.SetError((Control)sender, error);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prevent from user inputing characters out of scope of phone numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && (e.KeyChar != '(') && (e.KeyChar != ')') && (e.KeyChar != '+') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }
    }
}
