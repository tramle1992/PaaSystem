using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Configuration;
using PaaApplication.Forms;
using PaaApplication.Models.ClientInfo;
using PaaApplication.Forms.ClientInfo;
using Core.Application.Data.ClientInfo;
using Core.Domain.Model.ClientInfo;
using Core.Application.Command.ClientInfo;
using Common.Infrastructure.ApiClient;
using Newtonsoft.Json;
using Common.Infrastructure.UI;
using Common.Infrastructure.ComboBoxCustom;
using System.Net;
using System.IO;
using Common.Infrastructure.FTPService;
using System.Text.RegularExpressions;
using Core.Infrastructure.ClientInfo;
using SystemConfiguration.Infrastructure;
using SystemConfiguration.Application.Data;
using Common.Application;


namespace PaaApplication.UserControls.ClientInfo
{
    public enum State
    {
        onEdit,
        onAddNew
    }

    public partial class ClientInfoTabsControl : UserControl
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ClientApiRepository _clientApiRepository = new ClientApiRepository();
        private SysConfigApiRepository _sysConfigApiRepository = new SysConfigApiRepository();

        private FormClientInfo _formClientInfo;
        private State _formState;
        private State _invDivisonState = State.onEdit;

        private int _currOtherAddIndex;
        private List<ManagementCompanyData> _lstManagementCompany = new List<ManagementCompanyData>();
        private Dictionary<int, OtherAddressData> _lstOtherAddress = new Dictionary<int, OtherAddressData>();
        private ClientData _currentClient;

        List<ClientData> _clients;
        List<ReportTypeData> _reportTypes;

        public FormMaster FormMaster { get; set; }

        #region Variables
        public State FormState
        {
            get { return this._formState; }
            set { this._formState = value; }
        }

        public string EditingClientName
        {
            get;
            set;
        }

        public string ClientName
        {
            set { txtClientName.Text = value; }
        }

        public string CustomerNumber
        {
            set { txtCustomerNumber.Text = value; }
        }

        public bool EditClientNameEnabled
        {
            set { btnLockEdit.Enabled = value; }
        }

        public bool EditClientNameVisible
        {
            set { btnLockEdit.Visible = value; }
        }

        /*
        public void GetCurrentClient(ClientData client)
        {
            GetClientDataFromForm(client);
        }*/

        public void SetCurrentClient(ClientData client)
        {
            this._currentClient = client;
        }

        public bool AbleToBlockUnblockActivity
        {
            set { chkBlockActivity.Enabled = value; }
        }
        #endregion

        #region Form Initial
        public ClientInfoTabsControl(FormClientInfo formClientInfo)
        {
            InitializeComponent();

            this._formClientInfo = formClientInfo;

            this.olvcolContactName.AutoCompleteEditor = false;
            this.olvcolDivisionName.AutoCompleteEditor = false;
            this.olvcolDivisionName.AutoCompleteEditorMode = AutoCompleteMode.None;
            this.olvcolContactName.AutoCompleteEditorMode = AutoCompleteMode.None;
        }
        #endregion

        #region Control Events

        private void txtDirName_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if (!string.IsNullOrEmpty(txtBox.Text))
            {
                this.btnCreateDir.Enabled = true;
                txtDirName_Validating(sender, null);
            }
            else
            {
                this.btnCreateDir.Enabled = false;
            }
        }

        private void chkBlockActivity_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBlockActivity.Checked == true)
            {
                this.chkBlockActivity.ForeColor = Color.Red;
            }
            else
            {
                this.chkBlockActivity.ForeColor = Color.DodgerBlue;
            }
        }

        private void txtClientName_Leave(object sender, EventArgs e)
        {
            string clientName = (sender as TextBox).Text;
            string custNo = string.Empty;

            if (_formState == State.onEdit)
            {
                if (!string.IsNullOrEmpty(clientName) && clientName != EditingClientName)
                {
                    ClientData returnClient = _clientApiRepository.FindByName(clientName);

                    if (returnClient != null)
                    {
                        errpdEmail.SetError(btnLockEdit, "ClientName already exists");
                        return;
                    }
                    else
                    {
                        errpdEmail.SetError(btnLockEdit, "");
                    }
                }

            }
            else
            {
                if (!string.IsNullOrEmpty(clientName))
                {
                    using (new HourGlass())
                    {
                        custNo = _clientApiRepository.GetNewCustomerNumber(clientName[0].ToString());
                    }
                    this.txtCustomerNumber.Text = custNo;
                }
            }
        }

        private void cboMgmtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(this.cboMgmtCompany, e, false);
        }

        public void btnMgtWideInfo_Click(object sender, EventArgs e)
        {
            try
            {
                ManagementCompanyData mgtCompany = (ManagementCompanyData)this.cboMgmtCompany.SelectedItem;

                if (mgtCompany == null) return;

                ManagementWideInfoUpdates wideInfo = new ManagementWideInfoUpdates();

                FormMgmWideUpdates frmUpdatemgm = new FormMgmWideUpdates();

                List<string> lstEmails = this.GetListEmailsFromComboBox(this.cboConfReport);

                frmUpdatemgm.ManagementCompanyId = mgtCompany.ManagementCompanyId;
                frmUpdatemgm.ManagementCompanyName = mgtCompany.Name;
                frmUpdatemgm.BillingAddress = this.txtBillingAddress.Text;
                frmUpdatemgm.DefaultDeliverReportsTo = this.cboConfReport.Text;
                frmUpdatemgm.DefaultDeliverConfirmationsTo = this.cboConfirmation.Text;
                frmUpdatemgm.DefaultDeliverInvoicesTo = this.cboConfInvoices.Text;
                frmUpdatemgm.ConfirmVerification = this.chkBoxVerifyConf.Checked ? true : false;
                frmUpdatemgm.DeclinationLetter = this.chkDecLetter.Checked ? true : false;
                frmUpdatemgm.InvoicesCopiesNumber = Convert.ToInt32(this.nudInvsCopiedNum.Value);
                frmUpdatemgm.CreditType = (CreditTypeData)this.cboCreditType.SelectedItem;
                frmUpdatemgm.ListEmails = lstEmails;

                frmUpdatemgm.StartPosition = FormStartPosition.CenterParent;

                if (frmUpdatemgm.ShowDialog() == DialogResult.OK)
                {
                    ClientData client = new ClientData();
                    client.ClientId = _currentClient.ClientId;

                    ((FormClientInfo)this.Parent).ReloadClientInfoData(client);
                    ManagementCompanyData data = new ManagementCompanyData(frmUpdatemgm.ManagementCompanyId, frmUpdatemgm.ManagementCompanyName);
                    this.UpdateLocalListManagementCompany(data);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void btnLockEdit_Click(object sender, EventArgs e)
        {
            if (this.txtClientName.ReadOnly)
            {
                this.txtClientName.ReadOnly = false;
                this.txtClientName.BackColor = Color.White;
                this.btnLockEdit.Image = PaaApplication.Properties.Resources.lock_open;
            }
            else
            {
                this.txtClientName.ReadOnly = true;
                this.txtClientName.BackColor = SystemColors.ControlLight;
                this.btnLockEdit.Image = PaaApplication.Properties.Resources.lock_16;
            }
        }

        private void btnCreateDir_Click(object sender, EventArgs e)
        {
            string rootPath = string.Format("bemroseconsulting.com/secure/client/");
            string ftpClientfolder = this.txtDirName.Text;

            string dirPath = string.Format(Path.GetTempPath()) + "PaaFtp\\";

            string localClientFile = string.Format("{0}{1}", dirPath, "log");
            string localIndexHtmlFile = string.Format("{0}{1}", dirPath, "index.html");

            using (new HourGlass())
            {
                #region Check and Write local File

                if (File.Exists(localClientFile))
                {
                    File.Delete(localClientFile);
                }
                else
                {
                    Directory.CreateDirectory(dirPath);
                }

                string contents = this.txtUserPass.Text;
                string[] newLineArray = { Environment.NewLine, "\n" };
                string[] textArray = contents.Split(newLineArray, StringSplitOptions.None);
                string userPass = "";
                foreach(var line in textArray)
                {
                    if (line == string.Empty) continue;
                    if (userPass != string.Empty)
                        userPass += "\n" + line;
                    else
                        userPass += line;
                }

                File.WriteAllText(localClientFile, userPass);

                if (!File.Exists(localIndexHtmlFile))
                {
                    File.WriteAllText(localIndexHtmlFile, "<html><head><meta http-equiv='refresh' content='0;url=http://www.bemroseconsulting.com/'></head><body></body></html>");
                }

                #endregion

                // Load system config
                ConfigData sysConfig;
                FormClientInfo formClientInfo;

                try
                {
                    formClientInfo = (FormClientInfo)this.ParentForm;
                }
                catch (Exception ex)
                {
                    formClientInfo = null;
                }

                if (formClientInfo == null)
                {
                    sysConfig = _sysConfigApiRepository.Find(GlobalConstants.SYS_CONFIG_ID);
                    if (sysConfig == null || string.IsNullOrEmpty(sysConfig.ConfigId))
                    {
                        sysConfig = new ConfigData();
                        sysConfig.FtpUri = GlobalConstants.DEFAULT_FTP_URI;
                        sysConfig.FtpUsername = GlobalConstants.DEFAULT_FTP_USERNAME;
                        sysConfig.FtpPassword = GlobalConstants.DEFAULT_FTP_PASSWORD;
                    }
                }
                else
                {
                    sysConfig = formClientInfo.formMaster.SYSTEM_CONFIG;
                }

                FTPService ftpClient = new FTPService(sysConfig.FtpUri, sysConfig.FtpUsername, sysConfig.FtpPassword);

                string[] files = Directory.GetFiles(dirPath, "*.*");

                var uploadPath = string.Format("{0}{1}", rootPath, ftpClientfolder);

                ftpClient.createDirectory(uploadPath);

                foreach (string file in files)
                {
                    ftpClient.upload(uploadPath + "/" + Path.GetFileName(file), file);
                }
            }
        }

        private void cboConfReport_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmailInputHandle(sender, e);
        }

        private void cboConfirmation_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmailInputHandle(sender, e);
        }

        private void cboConfInvoices_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmailInputHandle(sender, e);
        }

        private void cboConfReport_TextChanged(object sender, EventArgs e)
        {
            cboConfReport_Validating(sender, null);
        }

        private void cboConfirmation_TextChanged(object sender, EventArgs e)
        {
            cboConfirmation_Validating(sender, null);
        }

        private void cboConfInvoices_TextChanged(object sender, EventArgs e)
        {
            ValidateEmailInputHandle(sender, null);

            // Set nudInvsCopiedNum value based on cboConfInvoices
            if (!string.IsNullOrEmpty(this.cboConfInvoices.Text))
            {
                this.nudInvsCopiedNum.Value = 1;
            }
            else this.nudInvsCopiedNum.Value = 2;
        }

        private void txtClientPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                if (txtClientPhone.Text.Trim().Length > 254)
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtClientFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                if (txtClientFax.Text.Trim().Length > 254)
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtDirName_Validating(object sender, CancelEventArgs e)
        {
            string inputWebDir = (sender as TextBox).Text;
            bool isOverLong = false;
            string error = null;

            if (!string.IsNullOrEmpty(inputWebDir))
            {
                if (inputWebDir.IndexOf('/') > 0)
                {
                    string[] arrDirs = inputWebDir.Split('/');

                    foreach (string dir in arrDirs)
                    {
                        if (dir.Length > 150)
                        {
                            isOverLong = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (inputWebDir.Length > 150)
                    {
                        isOverLong = true;
                    }
                }

                if (isOverLong)
                {
                    error = "Directory must not be over 150 characters lenght.";
                    this.btnCreateDir.Enabled = false;
                }
                else
                {
                    this.btnCreateDir.Enabled = true;
                }
            }
            errpdEmail.SetError((Control)sender, error);
        }

        private void txtClientEmail_TextChanged(object sender, EventArgs e)
        {
            string inputEmail = (sender as TextBox).Text;
            ValidateEmailInput(inputEmail, sender);
        }

        #endregion

        #region Other Address

        private void SetTextOtherAddPagination()
        {
            if (_lstOtherAddress[_currOtherAddIndex] != null)
            {
                this.txtOtherAddr.Text = _lstOtherAddress[_currOtherAddIndex].AddressKind;
                this.txtOtherAddrDetail.Text = _lstOtherAddress[_currOtherAddIndex].Address;
                lblOtherAddPaging.Text = string.Format("{0} of {1}", _currOtherAddIndex + 1, _lstOtherAddress.Count().ToString());
            }
        }

        private void btnDelOtherAddr_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtOtherAddr.Focus();

                if (_currOtherAddIndex == _lstOtherAddress.Count())
                {
                    this.txtOtherAddr.Text = _lstOtherAddress[_currOtherAddIndex - 1].AddressKind;
                    this.txtOtherAddrDetail.Text = _lstOtherAddress[_currOtherAddIndex - 1].Address;
                    _currOtherAddIndex--;
                    this.lblOtherAddPaging.Text = string.Format("{0} of {1}", _currOtherAddIndex + 1, _lstOtherAddress.Count());
                    return;
                }

                if (!_lstOtherAddress.Any())
                {
                    return;
                }
                else
                {
                    SaveCurrentAddress();
                    for (int i = _currOtherAddIndex + 1; i < _lstOtherAddress.Count(); i++)
                    {
                        if (_lstOtherAddress.ContainsKey(i))
                        {
                            OtherAddressData data = new OtherAddressData();
                            data.Address = _lstOtherAddress[i].Address;
                            data.AddressKind = _lstOtherAddress[i].AddressKind;
                            _lstOtherAddress[i - 1] = data;
                        }
                    }

                    _lstOtherAddress.Remove(_lstOtherAddress.Count() - 1);

                    if (_lstOtherAddress.Any())
                    {

                        if (_currOtherAddIndex > 0)
                        {
                            _currOtherAddIndex--;
                        }

                        this.lblOtherAddPaging.Text = string.Format("{0} of {1}", _currOtherAddIndex + 1, _lstOtherAddress.Count());
                        this.txtOtherAddr.Text = _lstOtherAddress[_currOtherAddIndex].AddressKind;
                        this.txtOtherAddrDetail.Text = _lstOtherAddress[_currOtherAddIndex].Address;
                    }
                    else
                    {
                        _currOtherAddIndex = 0;
                        this.lblOtherAddPaging.Text = string.Format("0 of 0");
                        this.txtOtherAddr.Text = string.Empty;
                        this.txtOtherAddrDetail.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        private void btnAddOtherAddr_Click(object sender, EventArgs e)
        {
            this.txtOtherAddr.Focus();
            if (!_lstOtherAddress.Any())
            {
                SaveCurrentAddress();

                _currOtherAddIndex++;
            }
            else
            {
                SaveCurrentAddress();

                if (IsLastAddress())
                {
                    _currOtherAddIndex++;
                }
                else
                {
                    _currOtherAddIndex = _lstOtherAddress.Count();
                }
            }

            this.lblOtherAddPaging.Text = string.Format("{0} of {1}", _lstOtherAddress.Count() + 1, _lstOtherAddress.Count() + 1);
            this.txtOtherAddr.Text = string.Empty;
            this.txtOtherAddrDetail.Text = string.Empty;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_lstOtherAddress.Any()) return;
                if (_currOtherAddIndex == 0) return;

                SaveCurrentAddress();

                _currOtherAddIndex--;

                SetTextOtherAddPagination();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsLastAddress()) return;
            if (!_lstOtherAddress.Any()) return;

            SaveCurrentAddress();

            _currOtherAddIndex++;
            SetTextOtherAddPagination();
        }

        private bool IsLastAddress()
        {
            int lastIdx = _lstOtherAddress.Count - 1;
            if (_currOtherAddIndex == lastIdx) return true;
            return false;
        }

        private void SaveCurrentAddress()
        {
            if (string.IsNullOrEmpty(this.txtOtherAddr.Text) && string.IsNullOrEmpty(this.txtOtherAddrDetail.Text)) return;

            OtherAddressData addr = new OtherAddressData();
            addr.Address = this.txtOtherAddrDetail.Text;
            addr.AddressKind = this.txtOtherAddr.Text;

            if (!_lstOtherAddress.ContainsKey(_currOtherAddIndex))
            {
                _lstOtherAddress.Add(_currOtherAddIndex, addr);
            }
            else
            {
                _lstOtherAddress[_currOtherAddIndex] = addr;
            }
        }

        #endregion

        #region OLV Divisions & Contacts Events Handle

        private void btnAddDivision_Click(object sender, EventArgs e)
        {
            try
            {
                InvoiceDivisionData invsData = new InvoiceDivisionData();

                this.olvInvDivisions.AddObject(invsData);
                this.olvInvDivisions.EnsureModelVisible(invsData);
                this.olvInvDivisions.EditModel(invsData);

                this._invDivisonState = State.onAddNew;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void olvInvDivsions_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.Column == olvcolDeleteInvDivisions)
            {
                InvoiceDivisionData selectedItem = (InvoiceDivisionData)this.olvInvDivisions.SelectedObject;

                this.olvInvDivisions.RemoveObject(selectedItem);
            }
        }

        private List<string> GetAllInvDivisionsFromCacheAndForm()
        {
            List<string> result = new List<string>();

            ClientData client = this._formClientInfo.formMaster.LIST_CLIENTS
                                        .Find(r => (r != null
                                                    && !string.IsNullOrEmpty(r.ClientId)
                                                    && r.ClientId.Equals(this._currentClient.ClientId)));

            // Case occur when create new client
            if (client == null || string.IsNullOrEmpty(client.ClientId))
            {
                return result;
            }

            if (client.InvoiceDivisions != null && client.InvoiceDivisions.Count > 0)
            {
                foreach (InvoiceDivisionData invoiceDivision in client.InvoiceDivisions)
                {
                    if (!string.IsNullOrEmpty(invoiceDivision.DivisionName)
                        && result.IndexOf(invoiceDivision.DivisionName) < 0)
                    {
                        result.Add(invoiceDivision.DivisionName);
                    }
                }
            }

            foreach (InvoiceDivisionData invoiceDivision in this.olvInvDivisions.Objects)
            {
                if (!string.IsNullOrEmpty(invoiceDivision.DivisionName)
                        && result.IndexOf(invoiceDivision.DivisionName) < 0)
                {
                    result.Add(invoiceDivision.DivisionName);
                }
            }

            return result;
        }

        private void olvInvDivisions_CellEditValidating(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (this._invDivisonState == State.onAddNew)
            {
                InvoiceDivisionData item = (InvoiceDivisionData)e.RowObject;
                if (item == null)
                {
                    e.Cancel = true;
                    return;
                }

                if (e.Column == olvcolDivisionName)
                {
                    string value = e.NewValue.ToString().Trim();

                    if (string.IsNullOrEmpty(value) || value.Equals("(None)"))
                    {
                        MessageBox.Show("Invalid Invoice Division!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (value.Length > 255)
                    {
                        MessageBox.Show("Invoice Division cannot be longer than 255 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }

                    List<string> allInvDivisions = GetAllInvDivisionsFromCacheAndForm();

                    if (allInvDivisions.IndexOf(value) >= 0)
                    {
                        MessageBox.Show("Invoice Division already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        item.DivisionName = value;
                    }
                }
            }
            else if (this._invDivisonState == State.onEdit)
            {
                InvoiceDivisionData item = (InvoiceDivisionData)e.RowObject;
                if (item == null)
                {
                    e.Cancel = true;
                    return;
                }

                if (e.Column == olvcolDivisionName)
                {
                    string oldValue = e.Value.ToString();
                    string newValue = e.NewValue.ToString().Trim();

                    if (string.IsNullOrEmpty(newValue) || newValue.Equals("(None)"))
                    {
                        MessageBox.Show("Invalid Invoice Division!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (newValue.Length > 255)
                    {
                        MessageBox.Show("Invoice Division cannot be longer than 255 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (!oldValue.Equals(newValue))
                    {
                        List<string> allInvDivisions = GetAllInvDivisionsFromCacheAndForm();

                        if (allInvDivisions.IndexOf(newValue) >= 0)
                        {
                            MessageBox.Show("Invoice Division already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            item.DivisionName = newValue;
                        }
                    }
                }
            }

            this._invDivisonState = State.onEdit;
        }

        private void olvInvDivisions_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            InvoiceDivisionData item = (InvoiceDivisionData)e.RowObject;
            if (item == null)
            {
                this._invDivisonState = State.onEdit;
                return;
            }

            if (e.Cancel && this._invDivisonState == State.onAddNew)
            {
                this.olvInvDivisions.RemoveObject(item);
            }
            else if (!e.Cancel)
            {
                if (e.Column == this.olvcolDivisionName)
                {
                    item.DivisionName = e.NewValue.ToString();
                }

                this.olvInvDivisions.RefreshObject(item);
                e.Cancel = true;
            }

            this._invDivisonState = State.onEdit;
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                string contacType = this.cboContactTypes.Text;

                ContactData contactData = new ContactData();
                contactData.ContactTypeName = contacType;

                switch (contacType)
                {
                    case "Email":
                        contactData.ContactType = 0;
                        break;
                    case "Fax":
                        contactData.ContactType = 1;
                        break;
                    case "Other":
                        contactData.ContactType = 2;
                        break;
                }

                this.olvContacts.AddObject(contactData);
                this.olvContacts.EnsureModelVisible(contactData);
                this.olvContacts.EditSubItem(olvContacts.GetItem((olvContacts.Items.Count) - 1), 1);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        private void olvContacts_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            try
            {
                if (e.Column == olvcolDeleteContacts)
                {
                    ContactData selectedItem = (ContactData)this.olvContacts.SelectedObject;

                    this.olvContacts.RemoveObject(selectedItem);

                    UpdateListEmail(this.olvContacts);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        #endregion

        #region Load Data For Fields

        public void InitDataForFields(ClientData client)
        {
            try
            {
                //Contact Types
                if (this.cboContactTypes.Items.Count == 0)
                {
                    IEnumerable<ContactType> lstContactTypes = Enum.GetValues(typeof(ContactType)).Cast<ContactType>();

                    foreach (ContactType contact in lstContactTypes)
                    {
                        this.cboContactTypes.Items.Add(contact);
                    }

                    this.cboContactTypes.SelectedIndex = 0;

                    //Company Management
                    this.cboMgmtCompany.ValueMember = "ManagementCompanyId";
                    this.cboMgmtCompany.DisplayMember = "Name";

                    if (!_lstManagementCompany.Any())
                    {
                        ManagementCompanyCachedApiQuery cachedApiQuery = ManagementCompanyCachedApiQuery.Instance;

                        _lstManagementCompany = cachedApiQuery.GetAllManagementCompanies();
                    }

                    foreach (var item in _lstManagementCompany)
                    {
                        this.cboMgmtCompany.Items.Add(item);
                    }

                    //OLV
                    this.olvcolDeleteInvDivisions.ImageGetter = delegate(object row)
                    {
                        return 0;
                    };

                    this.olvcolDeleteInvDivisions.AspectGetter = delegate(object row)
                    {
                        return string.Empty;
                    };

                    this.olvcolDivisionName.ImageGetter = delegate(object row)
                    {
                        return 4;
                    };

                    this.olvcolContactName.AspectToStringConverter = delegate(object row)
                    {
                        return (String)row;
                    };

                    this.olvcolDeleteContacts.ImageGetter = delegate(object row)
                    {
                        return 0;
                    };

                    this.olvcolDeleteContacts.AspectGetter = delegate(object row)
                    {
                        return string.Empty;
                    };

                    this.olvcolContactName.AspectToStringConverter = delegate(object row)
                    {
                        return (String)row;
                    };

                    this.olvcolContactName.ImageGetter = delegate(object row)
                    {
                        string name = ((ContactData)row).ContactTypeName;

                        if (name == "Email")
                            return 1;
                        else if (name == "Fax")
                            return 2;
                        return 3;
                    };

                    this.cboCreditType.ValueMember = "Value";
                    this.cboCreditType.DisplayMember = "DisplayName";

                    List<CreditTypeData> lstCreditType = CreditTypeData.GetListCreditTypes();

                    if (lstCreditType != null && lstCreditType.Count > 0)
                    {
                        foreach (CreditTypeData creditType in lstCreditType.OrderBy(st => st.DisplayName))
                        {
                            this.cboCreditType.Items.Add(creditType);
                        }
                    }                    
                }
                if(this.cmbReportType.Items.Count == 0)
                {
                    cmbReportType.DisplayMember = "TypeName";
                    cmbReportType.ValueMember = "ReportTypeId";

                    ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                    ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;

                    
                    if (FormMaster == null)
                    {
                        _clients = clientCachedApiQuery.GetAllClients();
                        _reportTypes = reportTypeCachedApiQuery.GetAllReportTypes();
                    }
                    else
                    {
                        _clients = FormMaster.LIST_CLIENTS;
                        _reportTypes = FormMaster.LIST_REPORT_TYPES;
                    }
                    cmbReportType.DataSource = _reportTypes;
                    if (_currentClient != null)
                    {
                        if (!string.IsNullOrEmpty(_currentClient.DefaultReportTypeId))
                        {
                            foreach (ReportTypeData reportType in _reportTypes)
                            {
                                if (reportType.ReportTypeId == _currentClient.DefaultReportTypeId)
                                {
                                    cmbReportType.SelectedItem = reportType;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        this.cmbReportType.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        #endregion

        public void GetClientDataFromForm(ClientData clientData)
        {
            if (this._currentClient == null || string.IsNullOrEmpty(this._currentClient.ClientId))
            {
                return;
            }

            if (clientData == null)
                return;

            try
            {
                clientData.ClientId = this._currentClient.ClientId;
                clientData.ManagementCompany = (ManagementCompanyData)this.cboMgmtCompany.SelectedItem;

                if (clientData.ManagementCompany == null)
                {
                    string mgtCompany = this.cboMgmtCompany.Text;
                    if (!string.IsNullOrEmpty(mgtCompany))
                    {
                        bool isLstContain = false;
                        foreach (ManagementCompanyData item in _lstManagementCompany)
                        {
                            if (item.Name.Equals(mgtCompany, StringComparison.OrdinalIgnoreCase))
                            {
                                clientData.ManagementCompany = item;
                                isLstContain = true;
                                break;
                            }
                        }
                        if (!isLstContain)
                        {
                            ManagementCompanyData data = new ManagementCompanyData();
                            data.Name = mgtCompany;

                            ManagementCompanyApiRepository repository = new ManagementCompanyApiRepository();
                            ManagementCompanyCachedApiQuery cachedApiQuery = ManagementCompanyCachedApiQuery.Instance;

                            string newMgtComId = cachedApiQuery.AddManagementCompany(data);

                            ManagementCompanyData company = new ManagementCompanyData(newMgtComId, mgtCompany);
                            _lstManagementCompany.Add(company);

                            this.cboMgmtCompany.Items.Add(company);
                            clientData.ManagementCompany = company;
                        }
                    }
                }

                clientData.ClientId = _currentClient.ClientId;

                clientData.ClientName = this.txtClientName.Text;
                clientData.CustomerNumber = this.txtCustomerNumber.Text;
                clientData.ClientRevoked = this.chkBlockActivity.Checked ? true : false;

                //Client Information Tab

                clientData.BillingAddress = this.txtBillingAddress.Text;
                clientData.MiscComments = this.txtMiscComments.Text;
                clientData.BillingInfo = this.txtBillingInfo.Text;
                clientData.Phone = this.txtClientPhone.Text;
                clientData.Fax = this.txtClientFax.Text;
                clientData.Email = this.txtClientEmail.Text;
                clientData.Since = this.dtmCustSince.Value;

                OtherAddressData newAddr = new OtherAddressData();
                newAddr.Address = this.txtOtherAddrDetail.Text;
                newAddr.AddressKind = this.txtOtherAddr.Text;

                if (!string.IsNullOrEmpty(newAddr.Address) || !string.IsNullOrEmpty(newAddr.AddressKind))
                {
                    if (!_lstOtherAddress.ContainsKey(_currOtherAddIndex))
                    {
                        _lstOtherAddress.Add(_currOtherAddIndex, newAddr);
                    }
                    else
                    {
                        _lstOtherAddress[_currOtherAddIndex] = newAddr;
                    }

                    clientData.OtherAddresses.Clear();

                    if (_lstOtherAddress.Any())
                    {
                        foreach (var item in _lstOtherAddress)
                        {
                            clientData.OtherAddresses.Add(item.Value);
                        }
                    }
                }

                //Invs. Divisions & Contacts Tab                

                if (this.olvInvDivisions.Objects != null)
                {
                    HashSet<InvoiceDivisionData> lstInvDivisions = new HashSet<InvoiceDivisionData>();

                    // this.olvInvDivisions.FinishCellEdit();

                    foreach (object item in this.olvInvDivisions.Objects)
                    {
                        lstInvDivisions.Add((InvoiceDivisionData)item);
                    }

                    clientData.InvoiceDivisions = lstInvDivisions;
                }

                if (this.olvContacts.Objects != null)
                {
                    HashSet<ContactData> lstContact = new HashSet<ContactData>();

                    // this.olvContacts.FinishCellEdit();

                    foreach (object item in this.olvContacts.Objects)
                    {
                        lstContact.Add((ContactData)item);
                    }

                    clientData.Contacts = lstContact;
                }

                //Services Tab
                clientData.DeclinationLetter = chkDecLetter.Checked ? true : false;
                clientData.Credentialed = chkCredentialed.Checked ? true : false;

                clientData.DefaultDeliverConfirmationsTo = cboConfirmation.Text;
                clientData.DefaultDeliverInvoicesTo = cboConfInvoices.Text;
                clientData.DefaultDeliverReportsTo = cboConfReport.Text;

                if (cmbReportType.SelectedItem != null)
                {
                    clientData.DefaultReportTypeId = cmbReportType.SelectedValue.ToString();
                    clientData.DefaultReportTypeName = cmbReportType.Text;
                }

                clientData.DefaultVerifyConfirmDelivery = chkBoxVerifyConf.Checked ? true : false;
                clientData.SpecialCriteriaInfo = txtCriteriaInfo.Text;
                clientData.SpecialEntryInfo = txtEntryInfo.Text;
                clientData.WebPass = txtUserPass.Text;
                clientData.WebsiteDir = txtDirName.Text;
                clientData.InvoicesCopiesNumber = (int)nudInvsCopiedNum.Value;
                clientData.CreditType = (CreditTypeData)cboCreditType.SelectedItem;

                //Special Prices
                clientData.ClientReportSpecialPrices = _currentClient.ClientReportSpecialPrices;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void ResetAllFields()
        {
            this.cboConfReport.Items.Clear();
            this.cboConfirmation.Items.Clear();
            this.cboConfInvoices.Items.Clear();
            this.cboContactTypes.SelectedIndex = 0;

            this.cboMgmtCompany.Text = string.Empty;
            this.cboMgmtCompany.SelectedIndex = -1;

            this.cboConfReport.Text = string.Empty;
            this.cboConfirmation.Text = string.Empty;
            this.cboConfInvoices.Text = string.Empty;
            this.cmbReportType.SelectedIndex = 0; 

            this.txtClientEmail.Text = string.Empty;
            this.txtClientName.Text = string.Empty;
            this.txtCustomerNumber.Text = string.Empty;
            this.txtCustomerNumber.Text = string.Empty;
            this.txtBillingAddress.Text = string.Empty;
            this.txtOtherAddr.Text = string.Empty;
            this.txtOtherAddrDetail.Text = string.Empty;
            this.txtMiscComments.Text = string.Empty;
            this.txtClientPhone.Text = string.Empty;
            this.txtClientFax.Text = string.Empty;
            this.txtClientEmail.Text = string.Empty;
            this.dtmCustSince.Text = DateTime.Now.ToShortDateString();
            this.txtCriteriaInfo.Text = string.Empty;
            this.txtDirName.Text = string.Empty;
            this.txtEntryInfo.Text = string.Empty;
            this.txtUserPass.Text = string.Empty;
            this.chkBlockActivity.CheckState = CheckState.Unchecked;
            this.chkDecLetter.CheckState = CheckState.Unchecked;
            this.nudInvsCopiedNum.Value = 2;
            this.olvContacts.ClearObjects();
            this.olvInvDivisions.ClearObjects();
            this.txtBillingInfo.Clear();
            this.dtmCustSince.Value = DateTime.Now;
            this.chkCredentialed.CheckState = CheckState.Unchecked;
            this.cboCreditType.SelectedIndex = -1;
            this.btnCreateDir.Enabled = false;
            this.errpdEmail.Clear();

            _lstOtherAddress.Clear();
        }

        private List<string> GetListEmailsFromComboBox(ComboBox combobox)
        {
            List<string> list = new List<string>();

            if (combobox.Items.Count > 0)
            {
                foreach (string email in combobox.Items)
                {
                    if (!list.Contains(email))
                    {
                        list.Add(email);
                    }
                }
            }

            return list;
        }

        private void UpdateLocalListManagementCompany(ManagementCompanyData mgt)
        {
            ManagementCompanyData company = (from c in _lstManagementCompany
                                             where c.ManagementCompanyId == mgt.ManagementCompanyId
                                             select c).First();

            if (company != null)
            {
                _lstManagementCompany.Remove(company);
                _lstManagementCompany.Add(mgt);

                this.cboMgmtCompany.Items.Clear();

                foreach (var item in _lstManagementCompany)
                {
                    this.cboMgmtCompany.Items.Add(item);
                }
            }
        }

        private void ValidateEmailInputHandle(object sender, CancelEventArgs e)
        {
            ComboBox txtEmailInput = sender as ComboBox;

            ValidateEmailInput(txtEmailInput.Text, sender);
        }

        #region Check input

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

        private bool IsValidMultiEmailStringInput(string input)
        {
            bool isValid = true;

            if (!string.IsNullOrEmpty(input))
            {
                string tempEmail = input;

                if (tempEmail.IndexOf(',') > 0)
                {
                    tempEmail = tempEmail.Replace(',', ';');
                }

                if (tempEmail.IndexOf(';') > 0)
                {
                    string[] arrEmail = tempEmail.Split(';');

                    foreach (string email in arrEmail)
                    {
                        if (!IsValidEmail(email))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                else
                {
                    if (!IsValidEmail(input))
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        public bool IsValidInput()
        {
            if (errpdEmail.GetError(this.cboConfInvoices) != "")
            {
                return false;
            }
            if (errpdEmail.GetError(this.cboConfirmation) != "")
            {
                return false;
            }
            if (errpdEmail.GetError(this.cboConfReport) != "")
            {
                return false;
            }
            if (errpdEmail.GetError(this.txtDirName) != "")
            {
                return false;
            }
            if (errpdEmail.GetError(this.txtClientEmail) != "")
            {
                return false;
            }
            if (errpdEmail.GetError(this.btnLockEdit) != "")
            {
                return false;
            }
            return true;
        }

        #endregion Validate input

        private void ValidateEmailInput(string inputEmail, object sender)
        {
            string error = null;

            if (!string.IsNullOrEmpty(inputEmail))
            {
                string tempEmail = inputEmail;

                if (tempEmail.IndexOf(',') > 0)
                {
                    tempEmail = inputEmail.Replace(',', ';');
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
                    if (!IsValidEmail(inputEmail))
                    {
                        error = "Please enter valid Email(s)";
                    }
                }
            }
            errpdEmail.SetError((Control)sender, error);
        }

        private void UpdateListEmail(BrightIdeasSoftware.ObjectListView olv)
        {
            this.cboConfirmation.Items.Clear();
            this.cboConfReport.Items.Clear();
            this.cboConfInvoices.Items.Clear();

            List<ContactData> listContact = new List<ContactData>();

            if (olv.Items.Count > 0)
            {
                foreach (ContactData contact in olv.Objects)
                {
                    if (contact.ContactType == 0)
                    {
                        listContact.Add(contact);
                    }
                }
            }

            if (listContact.Any())
            {
                foreach (ContactData contact in listContact)
                {
                    string email = contact.ContactInfo;

                    if (IsValidMultiEmailStringInput(email) && !string.IsNullOrEmpty(email))
                    {
                        this.cboConfirmation.Items.Add(email);
                        this.cboConfReport.Items.Add(email);
                        this.cboConfInvoices.Items.Add(email);
                    }
                }
            }

            if (IsValidMultiEmailStringInput(this.txtClientEmail.Text) && !string.IsNullOrEmpty(this.txtClientEmail.Text))
            {
                this.cboConfirmation.Items.Add(this.txtClientEmail.Text);
                this.cboConfReport.Items.Add(this.txtClientEmail.Text);
                this.cboConfInvoices.Items.Add(this.txtClientEmail.Text);

            }
        }

        private void olvContacts_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            BrightIdeasSoftware.ObjectListView olv = sender as BrightIdeasSoftware.ObjectListView;
            string editedText = olv.CellEditor.Text;
            int index = olv.SelectedIndex;

            if (index == -1)
            {
                index = olv.Items.Count - 1;
            }

            List<ContactData> listContact = new List<ContactData>();

            int count = 0;
            foreach (ContactData contact in olv.Objects)
            {
                if (count == index)
                {
                    contact.ContactInfo = editedText;
                }

                listContact.Add(contact);
                count++;
            }

            BrightIdeasSoftware.ObjectListView tmpOlv = new BrightIdeasSoftware.ObjectListView();
            tmpOlv.SetObjects(listContact);

            UpdateListEmail(tmpOlv);
        }

        private void txtClientEmail_Leave(object sender, EventArgs e)
        {
            UpdateListEmail(this.olvContacts);
        }

        public void LoadData(ClientData data)
        {
            try
            {
                this.chkBlockActivity.CheckState = data.ClientRevoked ? CheckState.Checked : CheckState.Unchecked;
                this.chkDecLetter.CheckState = data.DeclinationLetter ? CheckState.Checked : CheckState.Unchecked;
                this.chkCredentialed.CheckState = data.Credentialed ? CheckState.Checked : CheckState.Unchecked;                

                this.txtClientName.Text = data.ClientName;
                this.txtCustomerNumber.Text = data.CustomerNumber;
                this.txtBillingAddress.Text = data.BillingAddress;
                this.txtMiscComments.Text = data.MiscComments;
                this.txtBillingInfo.Text = data.BillingInfo;
                this.txtClientFax.Text = data.Fax;
                this.txtClientPhone.Text = data.Phone;
                this.txtClientEmail.Text = data.Email;
                this.dtmCustSince.Value = data.Since;

                if (data.OtherAddresses.Any())
                {
                    _lstOtherAddress.Clear();

                    int count = 0;
                    foreach (OtherAddressData addr in data.OtherAddresses)
                    {
                        _lstOtherAddress.Add(count++, addr);
                    }
                }

                #region OLV

                //OLV Invoices Divisions  

                List<InvoiceDivisionData> listInv = data.InvoiceDivisions.ToList();

                listInv.Sort(delegate(InvoiceDivisionData x, InvoiceDivisionData y)
                {
                    if (x.DivisionName == null && y.DivisionName == null) return 0;
                    else if (x.DivisionName == null) return -1;
                    else if (y.DivisionName == null) return 1;
                    else return x.DivisionName.CompareTo(y.DivisionName);
                });

                this.olvInvDivisions.SetObjects(listInv);

                //OLV contacts

                if (data.Contacts.Any())
                {
                    List<ContactData> listContacts = data.Contacts.ToList();

                    for (int i = 0; i < listContacts.Count(); i++)
                    {
                        if (listContacts[i].ContactInfo == null)
                        {
                            listContacts[i].ContactInfo = "";
                        }
                    }
                    this.olvContacts.SetObjects(listContacts);
                }

                #endregion

                if (_lstOtherAddress.Any())
                {
                    _currOtherAddIndex = 0;

                    this.txtOtherAddr.Text = _lstOtherAddress[_currOtherAddIndex].AddressKind;
                    this.txtOtherAddrDetail.Text = _lstOtherAddress[_currOtherAddIndex].Address;
                    lblOtherAddPaging.Text = string.Format("{0} of {1}", 1, _lstOtherAddress.Count());
                }
                else
                {
                    lblOtherAddPaging.Text = string.Format("0 of 0");
                }

                if (data.ManagementCompany != null)
                {
                    this.btnMgtWideInfo.Enabled = true;
                    int idx = _lstManagementCompany.FindIndex(a => a.ManagementCompanyId == data.ManagementCompany.ManagementCompanyId);

                    this.cboMgmtCompany.SelectedIndex = idx;
                }
                else
                {
                    this.btnMgtWideInfo.Enabled = false;
                }

                this.txtDirName.Text = data.WebsiteDir;
                this.txtUserPass.Text = data.WebPass;

                if (!string.IsNullOrEmpty(this.txtDirName.Text))
                {
                    this.btnCreateDir.Enabled = true;
                }
                else
                {
                    this.btnCreateDir.Enabled = false;
                }

                this.chkBoxVerifyConf.CheckState = data.DefaultVerifyConfirmDelivery ? CheckState.Checked : CheckState.Unchecked;

                #region Tab Services

                List<string> listEmailContacts = new List<string>();
                List<string> listEmailDefaultDeliverReport = new List<string>();

                if (!string.IsNullOrEmpty(data.DefaultDeliverReportsTo))
                {
                    this.cboConfReport.Text = data.DefaultDeliverReportsTo;
                }

                if (!string.IsNullOrEmpty(data.DefaultDeliverConfirmationsTo))
                {
                    this.cboConfirmation.Text = data.DefaultDeliverConfirmationsTo;
                }

                if (!string.IsNullOrEmpty(data.DefaultDeliverInvoicesTo))
                {
                    this.cboConfInvoices.Text = data.DefaultDeliverInvoicesTo;
                    this.nudInvsCopiedNum.Value = 1;
                }
                else this.nudInvsCopiedNum.Value = 2;

                if (!string.IsNullOrEmpty(data.DefaultReportTypeId))
                {
                    foreach (ReportTypeData reportType in _reportTypes)
                    {
                        if (reportType.ReportTypeId == data.DefaultReportTypeId)
                        {
                            cmbReportType.SelectedItem = reportType;
                            break;
                        }
                    }
                }
                if (string.IsNullOrEmpty(data.DefaultReportTypeId))
                {
                    cmbReportType.SelectedItem = null;
                    cmbReportType.Text = string.Empty;
                }

                if (data.Contacts.Count > 0)
                {
                    IEnumerable<ContactData> filteredContacts = from c in data.Contacts
                                                                where c.ContactTypeName == ContactType.Email.ToString()
                                                                select c;

                    if (filteredContacts.Any())
                    {
                        foreach (ContactData contact in filteredContacts.ToList())
                        {
                            if (!listEmailDefaultDeliverReport.Contains(contact.ContactInfo) && !string.IsNullOrEmpty(contact.ContactInfo))
                            {
                                bool isValidInputEmail = true;

                                string tempContact = contact.ContactInfo;
                                if (contact.ContactInfo.IndexOf(',') > 0)
                                {
                                    tempContact = contact.ContactInfo.Replace(',', ';');
                                }

                                if (tempContact.IndexOf(';') > 0)
                                {
                                    string[] arrContact = tempContact.Split(';');

                                    foreach (string c in arrContact)
                                    {
                                        if (!IsValidEmail(c.Trim()))
                                        {
                                            isValidInputEmail = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (!IsValidEmail(contact.ContactInfo))
                                    {
                                        isValidInputEmail = false;
                                    }
                                }

                                if (isValidInputEmail)
                                {
                                    listEmailContacts.Add(contact.ContactInfo);
                                }
                            }
                        }
                    }
                }

                if (listEmailContacts.Any())
                {
                    listEmailDefaultDeliverReport.AddRange(listEmailContacts);
                }

                if (!string.IsNullOrEmpty(data.Email))
                {
                    listEmailDefaultDeliverReport.Add(data.Email);
                }

                if (listEmailDefaultDeliverReport.Any())
                {
                    foreach (string email in listEmailDefaultDeliverReport)
                    {
                        this.cboConfReport.Items.Add(email);
                        this.cboConfirmation.Items.Add(email);
                        this.cboConfInvoices.Items.Add(email);
                    }
                }

                this.txtEntryInfo.Text = data.SpecialEntryInfo;
                this.txtCriteriaInfo.Text = data.SpecialCriteriaInfo;

                if (data.CreditType != null)
                {
                    for (var i = 0; i < this.cboCreditType.Items.Count; i++)
                    {
                        if (((CreditTypeData)this.cboCreditType.Items[i]).Value == data.CreditType.Value)
                        {
                            var indexToSelect = i;
                            this.cboCreditType.SelectedIndex = indexToSelect;
                            break;
                        }
                    }
                }
                else
                {
                    for (var i = 0; i < this.cboCreditType.Items.Count; i++)
                    {
                        var creditTypeValueToSearch = CreditType.EmptyCreditReport.Value;
                        if (((CreditTypeData)this.cboCreditType.Items[i]).Value == creditTypeValueToSearch)
                        {
                            var indexToSelect = i;
                            this.cboCreditType.SelectedIndex = indexToSelect;
                            break;
                        }
                    }
                    this.cboCreditType.SelectedItem = CreditType.EmptyCreditReport.Value;
                }

                #endregion
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        public void SetErrorBtnLockEdit(string error)
        {
            errpdEmail.SetError(btnLockEdit, error);
        }

        public void SetEnabledBlockActivity(bool enabled)
        {
            this.chkBlockActivity.Enabled = enabled;
        }

        public string GetCurrentReportTypeId()
        {
            return cmbReportType.SelectedValue.ToString();
        }

        private void tabClientInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabClientInfo.SelectedTab == tabpgService)
            {
                if (_currentClient != null)
                {
                    if (!string.IsNullOrEmpty(_currentClient.DefaultReportTypeId))
                    {
                        foreach (ReportTypeData reportType in _reportTypes)
                        {
                            if (reportType.ReportTypeId == _currentClient.DefaultReportTypeId)
                            {
                                cmbReportType.SelectedItem = reportType;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    this.cmbReportType.SelectedIndex = 0;
                }
            }
        }
    }
}
