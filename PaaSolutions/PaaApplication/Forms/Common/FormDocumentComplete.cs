using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoDocument.Application.Data;
using Common.Infrastructure.Office;
using System.Net.Http;
using Newtonsoft.Json;
using System.Configuration;
using Common.Infrastructure.ApiClient;
using Core.Application.Data.ClientInfo;
using Word = NetOffice.WordApi;
using Common.Infrastructure.UI;
using PaaApplication.Models.Common;
using Core.Infrastructure.ClientInfo;
using PaaApplication.Models.AppExplore;
using System.Text.RegularExpressions;
using Outlook = NetOffice.OutlookApi;
using Common.Application.DialogMessage;
using System.Globalization;
using AutoDocument.Application;
using System.IO;
using PaaApplication.Helper;

namespace PaaApplication.Forms
{
    public partial class FormDocumentComplete : BaseForm
    {

        enum ActionMethod
        {
            PrintMethod,
            EmailMethod
        }

        private DocumentCompleteResult result;

        private HttpClient httpClient;

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ClientApiRepository clientApiRepository = new ClientApiRepository();

        private ActionMethod actionMethod = ActionMethod.PrintMethod;
        private FileType fileType = FileType.Word;

        private PrintAppEventArgs.MainActionType mainAction = PrintAppEventArgs.MainActionType.Print;
        private string firstLoadClientId;
        private string firstLoadClientEmail;
        private bool closeByButton = false;

        public bool ConfirmEdit = true;
        public string DefaultEmailTo { get; set; }
        public string DefaultClientName { get; set; }
        public List<string> ApplicantNames { get; set; }


        public FormDocumentComplete(string message, DocumentCompleteResult result)
        {

            InitializeComponent();
            InitializeSettings();
            this.Height -= pnlEmailOptions.Height;
            pnlButtonGroup.Location = new System.Drawing.Point(10, 10);
            ApplicantNames = new List<string>();
            if (string.IsNullOrEmpty(message))
            {
                lblMessage.Visible = false;
            }
            else
            {
                lblMessage.Text = message;
            }
            this.result = result;
            this.result.OnWordClose += OnWordCloseHandler;
            this.result.OnOutlookClose += OnOutlookCloseHandler;
        }

        public void InitializeSettings()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUri"];
            httpClient = ApiClientFactory.GetHttpClient(baseAddress);
        }

        public void CleanupWordDocument()
        {
            if (this.result != null)
            {
                this.result.QuitWordDocument(false);
            }
        }

        private void FormDocumentComplete_LoadCompleted(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                LoadListBoxClientMailsDisplayInfo();
            }
        }

        private void OnWordCloseHandler(object sender, EventArgs e)
        {
            if (this == null)
                return;

            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                    this.Dispose();
                });
            }
            else
            {
                this.Close();
                this.Dispose();
            }
        }

        private void OnOutlookCloseHandler(object sender, EventArgs e)
        {

        }

        private void ReturnButtonsToDefaultStyle()
        {
            btnPrint.FlatStyle = FlatStyle.Popup;
            btnEmail.FlatStyle = FlatStyle.Popup;
            btnViewEdit.FlatStyle = FlatStyle.Popup;
        }

        #region Form events
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (pnlEmailOptions.Visible)
            {
                HideMessagePanel();
            }

            ReturnButtonsToDefaultStyle();
            btnPrint.FlatStyle = FlatStyle.Standard;
            actionMethod = ActionMethod.PrintMethod;
            btnOK.Enabled = true;
            nudCopies.Enabled = true;
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            ClickEmailButton();
        }

        private void btnViewEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlEmailOptions.Visible)
                {
                    HideMessagePanel();
                }

                ReturnButtonsToDefaultStyle();
                btnViewEdit.FlatStyle = FlatStyle.Standard;

                if (this.result != null)
                {
                    if (this.fileType == FileType.Word)
                    {
                        if (!string.IsNullOrEmpty(this.result.GetFilePath()) && File.Exists(this.result.GetFilePath()) && ConfirmEdit == true)
                        {
                            string strConfirmMsg = "Editing document may cause unexpected problems if this document is being used as template to report. Do you want do continue?";

                            if (MessageBox.Show(strConfirmMsg, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                            {
                                this.result.SetWordDocumentVisible(true);
                            }
                        }
                        else
                        {
                            this.result.SetWordDocumentVisible(true);
                        }
                        btnOK.Enabled = true;
                    }
                    else if (this.fileType == FileType.PDF)
                    {
                        string workingFilePath = this.result.GetWordWorkingFilePath();
                        if (!string.IsNullOrEmpty(workingFilePath))
                        {
                            string extension = Path.GetExtension(workingFilePath);
                            if (extension.ToLower() != "pdf")
                            {
                                workingFilePath = Path.ChangeExtension(workingFilePath, "pdf");
                            }
                            this.result.ExportPDF(workingFilePath, true);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error", "Cannot view or edit document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot view or edit document", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkKeepDocumentOpen.Checked)
                {
                    if (this.result != null)
                    {
                        if (this.fileType == FileType.Word)
                        {
                            this.result.SetWordDocumentVisible(true);
                        }
                        else if (this.fileType == FileType.PDF)
                        {
                            string workingFilePath = this.result.GetWordWorkingFilePath();
                            if (!string.IsNullOrEmpty(workingFilePath))
                            {
                                string extension = Path.GetExtension(workingFilePath);
                                if (extension.ToLower() != "pdf")
                                {
                                    workingFilePath = Path.ChangeExtension(workingFilePath, "pdf");
                                }
                                this.result.ExportPDF(workingFilePath, true);
                            }
                        }
                    }
                }

                if (actionMethod == ActionMethod.PrintMethod)
                {
                    if (this.result != null)
                    {
                        int numberOfCopies = int.Parse(nudCopies.Value.ToString());
                        this.result.PrintWordDocument(numberOfCopies);
                        btnOK.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error", "Cannot print document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (actionMethod == ActionMethod.EmailMethod)
                {
                    if (!ValidateComboboxClients() || !ValidateComboboxClientMails())
                    {
                        return;
                    }

                    if (this.result != null)
                    {
                        string mailTo = cboxClientMails.Text;
                        this.result.EmailBody = EmailHelper.BuildSignature(ApplicantNames);

                        this.result.ShowOutlookEmail(mailTo);
                        btnOK.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error", "Cannot email document", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (!chkKeepDocumentOpen.Checked)
                {
                    if (this.result != null)
                    {
                        this.result.QuitWordDocument(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                closeByButton = true;
                if (InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close();
                        this.Dispose();
                    });
                }
                else
                {
                    this.Close();
                    this.Dispose();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkKeepDocumentOpen.Checked)
                {
                    if (this.result != null)
                    {
                        if (this.fileType == FileType.Word)
                        {
                            this.result.SetWordDocumentVisible(true);
                        }
                        else if (this.fileType == FileType.PDF)
                        {
                            string workingFilePath = this.result.GetWordWorkingFilePath();
                            if (!string.IsNullOrEmpty(workingFilePath))
                            {
                                string extension = Path.GetExtension(workingFilePath);
                                if (extension.ToLower() != "pdf")
                                {
                                    workingFilePath = Path.ChangeExtension(workingFilePath, "pdf");
                                }
                                this.result.ExportPDF(workingFilePath, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            finally
            {
                closeByButton = true;
                if (InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close();
                        this.Dispose();
                    });
                }
                else
                {
                    this.Close();
                    this.Dispose();
                }
            }

        }
        #endregion

        private void cboxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboxClientMails.Items.Clear();
                cboxClientMails.Text = String.Empty;

                ComboBox cmb = (ComboBox)sender;

                ClientMailsDisplayInfoData selectedItem = (ClientMailsDisplayInfoData)cmb.SelectedItem;

                if (selectedItem.ClientMails.Any())
                {
                    foreach (string email in selectedItem.ClientMails)
                    {
                        cboxClientMails.Items.Add(email);
                    }
                }

                if (cboxClientMails.Items.Count > 0)
                {
                    cboxClientMails.SelectedIndex = 0;
                }

                lblClientEmail.Text = selectedItem.ClientName.ToString();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        private void cboxClients_Leave(object sender, EventArgs e)
        {
            lblClientEmail.Text = cboxClients.Text;
        }

        private void cboxClients_TextChanged(object sender, EventArgs e)
        {
            ValidateComboboxClients();
        }

        private void LoadListBoxClientMailsDisplayInfo()
        {
            if (cboxClients.Items.Count > 0)
            {
                return;
            }

            cboxClients.Items.Clear();
            cboxClients.ValueMember = "ClientMail";
            cboxClients.DisplayMember = "ClientName";

            List<ClientMailsDisplayInfoData> clientDisplayInfoData = clientApiRepository.GetClientMails();

            if (clientDisplayInfoData != null)
            {
                int selectIndex = 0;
                bool found = false;
                bool hasFirstLoadClientId = false;
                if (this.mainAction == PrintAppEventArgs.MainActionType.EmailTo &&
                    !string.IsNullOrEmpty(this.firstLoadClientId) &&
                    !string.IsNullOrEmpty(this.firstLoadClientEmail))
                {
                    hasFirstLoadClientId = true;
                }
                foreach (ClientMailsDisplayInfoData item in clientDisplayInfoData)
                {
                    cboxClients.Items.Add(item);
                    if (hasFirstLoadClientId && this.firstLoadClientId.Equals(item.ClientId))
                    {
                        found = true;
                    }
                    if (!found)
                    {
                        selectIndex += 1;
                    }
                }
                if (this.mainAction == PrintAppEventArgs.MainActionType.Email ||
                    this.mainAction == PrintAppEventArgs.MainActionType.EmailTo)
                {
                    ClientApiRepository query = new ClientApiRepository();
                    ClientData client = query.FindByName(DefaultClientName);

                    if (client != null)
                    {
                        cboxClients.SelectedIndex = cboxClients.FindStringExact(client.ClientName);
                        cboxClientMails.SelectedIndex = 0;
                    }
                    if (!string.IsNullOrEmpty(DefaultEmailTo) && this.mainAction == PrintAppEventArgs.MainActionType.EmailTo)
                    {
                        cboxClientMails.SelectedIndex = -1;
                        cboxClientMails.Text = DefaultEmailTo;
                    }
                    ClickEmailButton();
                }
                if (found)
                {
                    cboxClients.SelectedIndex = selectIndex;
                    cboxClientMails.Text = this.firstLoadClientEmail;
                }
            }
        }

        private void cboxClientMails_Validating(object sender, CancelEventArgs e)
        {
            ValidateComboboxClientMails();
        }

        private void cboxClientMails_TextChanged(object sender, EventArgs e)
        {
            ValidateComboboxClientMails();
        }

        private void cboxClients_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private bool ValidateComboboxClientMails()
        {
            string input = cboxClientMails.Text.Trim();
            bool isValid = true;
            if (string.IsNullOrEmpty(input))
            {
                isValid = false;
            }
            else
            {
                List<string> emails = input.Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (emails.All(x => string.IsNullOrEmpty(x.Trim())))
                    isValid = false;

                foreach (var email in emails)
                {
                    if (string.IsNullOrEmpty(email.Trim()))
                        continue;

                    if (!Regex.IsMatch(email.Trim(),
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (!isValid)
            {
                string error = "Invalid E-mail Address.";
                errpdDocumentReportComplete.SetError(cboxClientMails, error);
                btnOK.Enabled = false;
                return false;
            }
            else
            {
                errpdDocumentReportComplete.SetError(cboxClientMails, null);
                btnOK.Enabled = true;
                return true;
            }
        }

        private bool ValidateComboboxClients()
        {
            string input = cboxClients.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                string error = "Invalid Client Name.";
                errpdDocumentReportComplete.SetError(cboxClients, error);
                btnOK.Enabled = false;
                return false;
            }
            else
            {
                errpdDocumentReportComplete.SetError(cboxClients, null);
                btnOK.Enabled = true;
                return true;
            }
        }

        private void HideMessagePanel()
        {
            pnlEmailOptions.Hide();
            this.Height -= pnlEmailOptions.Height;
            pnlButtonGroup.Location = new System.Drawing.Point(10, 10);
        }

        private void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPDF.Checked)
            {
                btnViewEdit.Text = "View";
                this.fileType = FileType.PDF;
                this.result.SetFileType(FileType.PDF);
            }
            else
            {
                btnViewEdit.Text = "View/Edit";
                this.fileType = FileType.Word;
                this.result.SetFileType(FileType.Word);
            }
        }

        private void FormDocumentComplete_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.result != null &&
                    this.result.GetWordDocumentVisible() == false &&
                    this.chkKeepDocumentOpen.Checked == false)

                    this.result.QuitWordDocument(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClickEmailButton()
        {
            try
            {
                if (pnlEmailOptions.Visible)
                {
                    return;
                }

                pnlEmailOptions.Show();
                this.Height += pnlEmailOptions.Height;
                pnlButtonGroup.Location = new System.Drawing.Point(10, 10 + pnlEmailOptions.Height);

                ReturnButtonsToDefaultStyle();
                btnEmail.FlatStyle = FlatStyle.Standard;
                actionMethod = ActionMethod.EmailMethod;
                nudCopies.Enabled = false;

                if (!ValidateComboboxClients() || !ValidateComboboxClientMails())
                {
                    btnOK.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetMainAction(PrintAppEventArgs.MainActionType mainAction)
        {
            this.mainAction = mainAction;
        }

        public void SetFirstLoadClientId(string clientId)
        {
            this.firstLoadClientId = clientId;
        }

        public void SetFirstLoadClientEmail(string clientEmail)
        {
            this.firstLoadClientEmail = clientEmail;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.O:
                    btnOK_Click(this, null);
                    return true;
                case Keys.Alt | Keys.C:
                    btnCancel_Click(this, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
