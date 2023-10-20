using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Http;
using PaaApplication.Forms;
using InfoResource.Application.Command;
using InfoResource.Application.Data;

using Newtonsoft.Json;
using InfoResource.Infrastructure.InfoResource;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace PaaApplication.Forms
{
    public partial class FormEditInfoResources : Form
    {
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private InfoResourceApiRepository apiRepository = new InfoResourceApiRepository();
        private InfoResourceCachedApiQuery cachedApiQuery = InfoResourceCachedApiQuery.Instance;

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

        public string Other
        {
            get { return txtOther.Text; }
            set { this.txtOther.Text = value; }
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

        public FormEditInfoResources()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ResourceData data = new ResourceData(this.ResourceId, this.ResourceType, this.ResourceName, this.Target, this.Other, this.Phone, this.Email);
                apiRepository.Update(data);
                cachedApiQuery.RemoveResourceItem(data.ResourceId);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Unable to update!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                throw;
            }
        }

        private void txtUpdate_ItemName_Validating(object sender, CancelEventArgs e)
        {
            string error = null;
            if (txtName.Text.Length == 0)
            {
                error = "Please enter Item Name";
                btnUpdate.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
            }
            errpdEditInfoRs.SetError((Control)sender, error);
        }

        private void FormEditInfoResources_Shown(object sender, EventArgs e)
        {
            this.txtName.Focus();
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

        private void txtUpdate_ItemPhone_Validating(object sender, CancelEventArgs e)
        {
            string error = null;

            if (!string.IsNullOrEmpty(txtPhone.Text) &&
                !Helper.Utils.IsValidPhoneNumer(txtPhone.Text))
            {
                error = "Phone is invalid";
                errpdEditInfoRs.SetError((Control)sender, error);
                btnUpdate.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
            }

            errpdEditInfoRs.SetError((Control)sender, error);           
        }

        private void txtUpdate_ItemEmail_Validating(object sender, CancelEventArgs e)
        {
            string error = null;

            if (!string.IsNullOrEmpty(txtEmail.Text) &&
                !Helper.Utils.IsValidEmail(txtEmail.Text))
            {
                error = "Email is invalid";
                errpdEditInfoRs.SetError((Control)sender, error);
                btnUpdate.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
            }

            errpdEditInfoRs.SetError((Control)sender, error);
        }
       
        private void btnCopyFax_MouseLeave(object sender, EventArgs e)
        {   
            this.btnCopyFax.Image = global::PaaApplication.Properties.Resources.copy3;
            btnCopyFax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void btnCopyFax_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtTarget.Text);
            btnCopyFax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void btnCopyFax_MouseEnter(object sender, EventArgs e)
        {   
            this.btnCopyFax.Image = global::PaaApplication.Properties.Resources.copy_red;
            btnCopyFax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void btnCopyName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtName.Text);            
        }

        private void btnCopyName_MouseEnter(object sender, EventArgs e)
        {
            this.btnCopyName.Image = global::PaaApplication.Properties.Resources.copy_red;
            btnCopyName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void btnCopyName_MouseLeave(object sender, EventArgs e)
        {
            this.btnCopyName.Image = global::PaaApplication.Properties.Resources.copy3;
            btnCopyName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }     

        private void btnCopyPhone_MouseEnter(object sender, EventArgs e)
        {
            this.btnCopyPhone.Image = global::PaaApplication.Properties.Resources.copy_red;
            btnCopyPhone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void btnCopyPhone_MouseLeave(object sender, EventArgs e)
        {
            this.btnCopyPhone.Image = global::PaaApplication.Properties.Resources.copy3;
            btnCopyPhone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void btnCopyPhone_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPhone.Text);
        }

        private void btnCopyEmail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtEmail.Text);
        }

        private void btnCopyEmail_MouseEnter(object sender, EventArgs e)
        {
            this.btnCopyEmail.Image = global::PaaApplication.Properties.Resources.copy_red;
            btnCopyEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void btnCopyEmail_MouseLeave(object sender, EventArgs e)
        {
            this.btnCopyEmail.Image = global::PaaApplication.Properties.Resources.copy3;
            btnCopyEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }      

        private void btnCopyOther_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtOther.Text);
        }

        private void btnCopyOther_MouseEnter(object sender, EventArgs e)
        {
            this.btnCopyOther.Image = global::PaaApplication.Properties.Resources.copy_red;
            btnCopyOther.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }

        private void btnCopyOther_MouseLeave(object sender, EventArgs e)
        {
            this.btnCopyOther.Image = global::PaaApplication.Properties.Resources.copy3;
            btnCopyOther.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        }
    }
}
