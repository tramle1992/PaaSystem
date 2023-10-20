using Common.Infrastructure.UI;
using Core.Application.Command.ClientInfo;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using PaaApplication.Models.ClientInfo;
using PaaApplication.UserControls.ClientInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms
{
    public partial class FormClientAddNew : Form
    {
        private ClientApiRepository _clientRepo = new ClientApiRepository();

        #region Form Initial

        public FormClientAddNew()
        {
            InitializeComponent();
            this.btnOK.Enabled = false;
        }

        #endregion

        //fields

        public string ClientName
        {
            get { return this.txtClientName.Text; }
            set { this.txtClientName.Text = value; }
        }

        public string CustNo
        {
            get;
            set;
        }

        #region Control Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.txtClientName.Clear();
            this.errProdNewClient.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            string clientName = txtClientName.Text;

            if (!string.IsNullOrEmpty(clientName))
            {
                using (new HourGlass())
                {
                    ClientData client = _clientRepo.FindByName(clientName);

                    if (client != null)
                    {
                        this.errProdNewClient.SetError(txtClientName, "Client name already exists.");
                        this.btnOK.Enabled = false;
                        return;
                    }
                    this.btnOK.Enabled = true;

                    string custNo = _clientRepo.GetNewCustomerNumber(clientName[0].ToString());
                    this.CustNo = custNo;
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;

            }
        }

        private void FormClientAddNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnOK_Click(this, e);
            }

        }

        private void txtClientName_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtClientName = sender as TextBox;

            string error = null;
            if (txtClientName.TextLength == 0)
            {
                error = "Please enter Client Name";
                this.btnOK.Enabled = false;
            }
            else
            {
                this.btnOK.Enabled = true;
            }
            errProdNewClient.SetError((Control)sender, error);
        }

        private void txtClientName_TextChanged(object sender, EventArgs e)
        {
            string txtClientName = (sender as TextBox).Text;

            string error = null;

            if (txtClientName.Length > 0)
            {
                char firstChar = txtClientName[0];

                if (txtClientName.Length > 2)
                {
                    this.btnOK.Enabled = true;
                }
                else
                {
                    this.btnOK.Enabled = false;
                }

                if (firstChar == '#' || firstChar == '&')
                {
                    error = "Client Name must not begin with special characters";
                    this.btnOK.Enabled = false;
                }
            }
            else
            {
                this.btnOK.Enabled = false;
            }

            errProdNewClient.SetError((Control)sender, error);
        }

        private void FormClientAddNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.btnOK.Enabled = false;
        }

        private void FormClientAddNew_Shown(object sender, EventArgs e)
        {
            this.txtClientName.Focus();
        }

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.A:
                    this.btnOK_Click(this, null);
                    return true;
                case Keys.Alt | Keys.C:
                    this.btnCancel_Click(this, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
