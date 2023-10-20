using Common.Infrastructure.ApiClient;
using Core.Application.Command.ClientInfo;
using Core.Application.Data.ClientInfo;
using Core.Domain.Model.ClientInfo;
using PaaApplication.Models.ClientInfo;
using PaaApplication.UserControls.ClientInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Infrastructure.UI;
using Core.Infrastructure.ClientInfo;

namespace PaaApplication.Forms.ClientInfo
{

    public partial class FormMgmWideUpdates : Form
    {
        Color ActiveTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region params

        public ManagementCompanyData CurrentManagementCompany
        {
            get;
            set;
        }

        public string ManagementCompanyName
        {
            get { return txtMgmName.Text; }
            set { txtMgmName.Text = value; }
        }

        public string ManagementCompanyId
        {
            get;
            set;
        }

        public string BillingAddress
        {
            get { return this.txtBillingAddr.Text; }
            set { this.txtBillingAddr.Text = value; }
        }

        public string DefaultDeliverReportsTo
        {
            get { return this.cboDeliverReports.Text; }
            set { this.cboDeliverReports.Text = value; }
        }

        public string DefaultDeliverConfirmationsTo
        {
            get { return this.cboDeliverConfirm.Text; }
            set { this.cboDeliverConfirm.Text = value; }
        }

        public string DefaultDeliverInvoicesTo
        {
            get { return this.cboDeliverInvoices.Text; }
            set { this.cboDeliverInvoices.Text = value; }
        }

        public bool ConfirmVerification
        {
            get { return chkConfVerification.Checked ? true : false; }
            set { this.chkConfVerification.Checked = value; }
        }

        public bool DeclinationLetter
        {
            get { return chkDecLetter.Checked ? true : false; }
            set { this.chkDecLetter.Checked = value; }
        }

        public int InvoicesCopiesNumber
        {
            get { return Convert.ToInt16(this.nudPrintInvs.Value); }
            set { this.nudPrintInvs.Value = value; }
        }

        public CreditTypeData CreditType
        {
            get { return (CreditTypeData)this.cboCreditReports.SelectedItem; }
            set
            {
                List<CreditTypeData> lstCreditTypes = CreditTypeData.GetListCreditTypes();

                this.cboCreditReports.ValueMember = "Value";
                this.cboCreditReports.DisplayMember = "DisplayName";

                foreach (CreditTypeData credit in lstCreditTypes)
                {
                    this.cboCreditReports.Items.Add(credit);
                }

                this.cboCreditReports.SelectedIndex = value.Value;
            }
        }

        public List<string> ListEmails
        {
            set
            {
                if (value.Any())
                {
                    foreach (string item in value)
                    {
                        this.cboDeliverReports.Items.Add(item);
                        this.cboDeliverConfirm.Items.Add(item);
                        this.cboDeliverInvoices.Items.Add(item);
                    }
                }
            }
        }

        #endregion params

        public FormMgmWideUpdates()
        {
            InitializeComponent();            
        }

        #region Control Events

        private void chboxUpdateConfVerification_CheckedChanged(object sender, EventArgs e)
        {
            if (!chboxUpdateConfVerification.Checked)
            {
                chkConfVerification.Enabled = false;
                lblConfDelivery.ForeColor = Color.Gray;
            }
            else
            {
                chkConfVerification.Enabled = true;
                chkConfVerification.Focus();
                this.lblConfDelivery.ForeColor = ActiveTextColor;
            }
        }

        private void chboxUpdateDecLetter_CheckedChanged(object sender, EventArgs e)
        {
            if (!chboxUpdateDecLetter.Checked)
            {
                chkDecLetter.Enabled = false;
                lblDecLetters.ForeColor = Color.Gray;
            }
            else
            {
                chkDecLetter.Enabled = true;
                this.lblDecLetters.ForeColor = ActiveTextColor;
                chkDecLetter.Focus();
            }
        }

        private void chboxUpdatePrintInvs_CheckedChanged(object sender, EventArgs e)
        {
            if (!chboxUpdatePrintInvs.Checked)
            {
                nudPrintInvs.Enabled = false;
                lblInvs.ForeColor = Color.Gray;
            }
            else
            {
                nudPrintInvs.Enabled = true;
                this.lblInvs.ForeColor = ActiveTextColor;
                nudPrintInvs.Focus();
            }
        }

        private void chboxUpdateMgmName_CheckedChanged(object sender, EventArgs e)
        {
            txtMgmName.Enabled = (chboxUpdateMgmName.Checked) ? true : false;

            if (!txtMgmName.Enabled)
            {
                this.errpdEmail.SetError(txtMgmName, "");
            }
            if (txtMgmName.Enabled)
            {
                txtMgmName_TextChanged(txtMgmName, null);
                txtMgmName.Focus();
            }

            if (IsValidInput())
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void chboxBillingAddr_CheckedChanged(object sender, EventArgs e)
        {
            txtBillingAddr.Enabled = (chboxBillingAddr.Checked) ? true : false;

            if (chboxBillingAddr.Checked)
            {
                txtBillingAddr.Focus();
            }
        }

        private void chboxDeliverReports_CheckedChanged(object sender, EventArgs e)
        {
            cboDeliverReports.Enabled = (chboxDeliverReports.Checked) ? true : false;

            if (chboxDeliverReports.Checked)
            {
                cboDeliverReports.Focus();
                ValidateEmailInputHandle(cboDeliverReports, null);
            }
            else
            {
                errpdEmail.SetError(cboDeliverReports, "");
            }

            if (IsValidInput())
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void chboxDeliverConfirm_CheckedChanged(object sender, EventArgs e)
        {
            cboDeliverConfirm.Enabled = (chboxDeliverConfirm.Checked) ? true : false;

            if (chboxDeliverConfirm.Checked)
            {
                cboDeliverConfirm.Focus();
                ValidateEmailInputHandle(cboDeliverConfirm, null);
            }
            else
            {
                errpdEmail.SetError(cboDeliverConfirm, "");
            }

            if (IsValidInput())
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void chboxDeliverInvoices_CheckedChanged(object sender, EventArgs e)
        {
            cboDeliverInvoices.Enabled = (chboxDeliverInvoices.Checked) ? true : false;

            if (cboDeliverInvoices.Enabled)
            {
                cboDeliverInvoices.Focus();
                ValidateEmailInputHandle(cboDeliverInvoices, null);
            }
            else
            {
                errpdEmail.SetError(cboDeliverInvoices, "");
            }

            if (IsValidInput())
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void chkUpdateCreditReport_CheckedChanged(object sender, EventArgs e)
        {
            cboCreditReports.Enabled = (chkUpdateCreditReport.Checked) ? true : false;

            if (chkUpdateCreditReport.Checked)
            {
                cboCreditReports.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> lstUpdateFields = new Dictionary<string, string>();

                SaveWideMgtInfoCommand command = new SaveWideMgtInfoCommand();

                if (this.chboxBillingAddr.Checked)
                {
                    lstUpdateFields.Add("Billing Address", this.txtBillingAddr.Text);
                }
                if (this.chboxDeliverReports.Checked)
                {
                    lstUpdateFields.Add("Default Report Delivery", this.cboDeliverReports.Text);
                }
                if (this.chboxDeliverConfirm.Checked)
                {
                    lstUpdateFields.Add("Default Confirmation Delivery", this.cboDeliverConfirm.Text);
                }
                if (this.chboxDeliverInvoices.Checked)
                {
                    lstUpdateFields.Add("Default Invoice Delivery", this.cboDeliverInvoices.Text);
                }
                if (this.chboxUpdateConfVerification.Checked)
                {
                    lstUpdateFields.Add("Confirmation Delivery Verification", chkConfVerification.Checked ? "True" : "False");
                }
                if (this.chboxUpdateDecLetter.Checked)
                {
                    lstUpdateFields.Add("Declination Letter Generation", chkDecLetter.Checked ? "True" : "False");
                }
                if (this.chboxUpdatePrintInvs.Checked)
                {
                    lstUpdateFields.Add("Copies of Printed Invoices", this.nudPrintInvs.Value.ToString());
                }

                if (this.chkUpdateCreditReport.Checked)
                {
                    lstUpdateFields.Add("Types of Credit Reports Pulled", ((CreditTypeData)this.cboCreditReports.SelectedItem).Value.ToString());
                }

                if (lstUpdateFields.Any())
                {
                    if (MessageBox.Show(this.BuildConfirmationMessage(lstUpdateFields, this.lblManagementCompanyName.Text), "Management-Wide Update",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string setClause = BuildSqlSetClause(lstUpdateFields);

                        ManagementCompanyData mgt = new ManagementCompanyData(this.ManagementCompanyId, this.ManagementCompanyName);
                        ManagementCompanyCachedApiQuery cacheQuery = ManagementCompanyCachedApiQuery.Instance;
                        MgmWideInfoCachedApiQuery WideInfoCacheApiQuery = MgmWideInfoCachedApiQuery.Instance;

                        if (this.chboxUpdateMgmName.Checked)
                        {                           
                            ManagementCompanyData data = new ManagementCompanyData(this.ManagementCompanyId, this.ManagementCompanyName);
                            cacheQuery.UpdateManagementCompayName(data);
                        }

                        ManagementWideInfoUpdates wideInfo = new ManagementWideInfoUpdates();
                        wideInfo.ManagementCompanyData = mgt;
                        wideInfo.SetClause = setClause;
                        WideInfoCacheApiQuery.Update(wideInfo);
                    }
                }
                else if (this.chboxUpdateMgmName.Checked)
                {

                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("Name of Management Company", "");

                    if (MessageBox.Show(this.BuildConfirmationMessage(dic, this.lblManagementCompanyName.Text), "Management-Wide Update",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        ManagementCompanyData data = new ManagementCompanyData(this.ManagementCompanyId, this.ManagementCompanyName);

                        ManagementCompanyCachedApiQuery cacheQuery = ManagementCompanyCachedApiQuery.Instance;
                        cacheQuery.UpdateManagementCompayName(data);
                    }
                }
                else
                {
                    MessageBox.Show("You must check the item(s) that you would like to update.", "No Items Checked to Update", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ResetForm();
        }

        private void cboDeliverConfirm_TextChanged(object sender, EventArgs e)
        {
            ValidateEmailInputHandle(sender, null);

            if (IsValidInput())
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void cboDeliverReports_TextChanged(object sender, EventArgs e)
        {
            ValidateEmailInputHandle(sender, null);

            if (IsValidInput())
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void cboDeliverInvoices_TextChanged(object sender, EventArgs e)
        {
            ValidateEmailInputHandle(sender, null);

            if (IsValidInput())
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void txtMgmName_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtCompanyName = sender as TextBox;

            string error = null;

            if (string.IsNullOrEmpty(txtCompanyName.Text))
            {
                error = "Please enter company name.";
            }

            errpdEmail.SetError((Control)sender, error);

            if (IsValidInput())
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }

        }

        private void txtMgmName_TextChanged(object sender, EventArgs e)
        {
            txtMgmName_Validating(sender, null);
        }

        #endregion

        #region Other functions : Convert, Build,...

        private string BuildConfirmationMessage(Dictionary<string, string> dicInput, string companyName)
        {
            StringBuilder msg = new StringBuilder();
            try
            {
                msg.Append(string.Format("This will replace the information below for all clients whose management company is '{0}' \n\n ", companyName));

                foreach (string item in dicInput.Keys)
                {
                    msg.Append(string.Format("- {0} \n\n", item));
                }

                msg.Append("Existing information will be lost. \n\n");
                msg.Append("Do you want to proceed?");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return msg.ToString();
        }

        private string BuildSqlSetClause(Dictionary<string, string> dicInput)
        {
            string setClause = string.Empty;

            try
            {
                if (dicInput.Keys.Contains("Name of Management Company"))
                {
                    dicInput.Remove("Name of Management Company");
                }

                if (dicInput.Count > 0)
                {
                    int i = 0;
                    foreach (var item in dicInput)
                    {
                        i++;

                        string sqlColumn = ConvertToSqlColumnName(item.Key);

                        setClause += string.Format("{0} = '{1}'", sqlColumn, item.Value);

                        if (i < dicInput.Count)
                        {
                            setClause += ",";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

            return setClause;
        }

        private string ConvertToSqlColumnName(string input)
        {
            switch (input)
            {
                case "Billing Address":
                    return "billing_address";
                case "Default Report Delivery":
                    return "default_deliver_reports_to";
                case "Default Confirmation Delivery":
                    return "default_deliver_confirmation_to";
                case "Default Invoice Delivery":
                    return "default_deliver_invoices_to";
                case "Confirmation Delivery Verification":
                    return "default_verify_confirm_delivery";
                case "Declination Letter Generation":
                    return "declination_letter";
                case "Confidentially Cover Generation":
                    return "confidentiality_cover";
                case "Copies of Printed Invoices":
                    return "invoices_copies_number";
                case "Types of Credit Reports Pulled":
                    return "credit_type";
            }
            return "";
        }

        private void ResetForm()
        {
            this.chboxBillingAddr.CheckState = CheckState.Unchecked;
            this.chboxDeliverConfirm.CheckState = CheckState.Unchecked;
            this.chboxDeliverInvoices.CheckState = CheckState.Unchecked;
            this.chboxUpdateConfVerification.CheckState = CheckState.Unchecked;
            this.chkDecLetter.CheckState = CheckState.Unchecked;
            this.chboxUpdatePrintInvs.CheckState = CheckState.Unchecked;
            this.chboxUpdateMgmName.CheckState = CheckState.Unchecked;
            this.chboxDeliverReports.CheckState = CheckState.Unchecked;
            this.chkUpdateCreditReport.CheckState = CheckState.Unchecked;
            this.chboxUpdateDecLetter.CheckState = CheckState.Unchecked;

            this.errpdEmail.Clear();

            this.cboCreditReports.Items.Clear();
            this.cboDeliverConfirm.Items.Clear();
            this.cboDeliverReports.Items.Clear();
            this.cboDeliverInvoices.Items.Clear();
        }

        #endregion

        private void ValidateEmailInputHandle(object sender, CancelEventArgs e)
        {
            ComboBox txtEmailInput = sender as ComboBox;

            string error = null;

            if (!string.IsNullOrEmpty(txtEmailInput.Text))
            {
                string tempEmail = txtEmailInput.Text;

                if (tempEmail.IndexOf(',') > 0)
                {
                    tempEmail = tempEmail.Replace(',', ';');
                }

                if (tempEmail.IndexOf(';') > 0)
                {
                    string[] arrEmail = tempEmail.Split(';');

                    bool isValid = true;
                    foreach (string email in arrEmail)
                    {
                        if (!IsValidEmail(email))
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (!isValid)
                    {
                        error = "Please enter valid Email(s)";
                    }
                }
                else
                {
                    if (!IsValidEmail(tempEmail))
                    {
                        error = "Please enter valid Email(s)";
                    }
                }
            }
            errpdEmail.SetError((Control)sender, error);
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

        private bool IsValidInput()
        {
            if (errpdEmail.GetError(this.cboDeliverConfirm) != "")
            {
                return false;
            }
            if (errpdEmail.GetError(this.cboDeliverReports) != "")
            {
                return false;
            }
            if (errpdEmail.GetError(this.cboDeliverInvoices) != "")
            {
                return false;
            }
            if (errpdEmail.GetError(this.txtMgmName) != "")
            {
                return false;
            }

            return true;
        }

        private void FormMgmWideUpdates_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetForm();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.U:
                    this.btnUpdate_Click(this, null);
                    return true;
                case Keys.Alt | Keys.C:
                    this.btnCancel_Click(this, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

