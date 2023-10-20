using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Application.Data.ExploreApps;
using PaaApplication.Helper;
using System.Text.RegularExpressions;
using Core.Infrastructure.ClientInfo;
using Core.Application.Data.ClientInfo;
using Common.Infrastructure.ComboBoxCustom;
using PaaApplication.Models.AppExplore;

namespace PaaApplication.UserControls.AppExplore.ApplicantInfo
{
    public partial class PartTwoControl : UserControl
    {
        public PartTwoControl()
        {
            InitializeComponent();
        }

        public EventHandler<InvoiceDivisionChangedEventArgs> InvoiceDivisionChanged;

        public void ResetControls()
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtMidName.Text = "";
            txtSSN.Text = "";
            txtBirthday.Text = "";
            chkbPdxInd.Checked = false;
            cmbInvoice2.Items.Clear();
            cmbInvoice2.Text = "";
        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetControls();

            ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            txtLastName.Text = app.LastName;
            txtFirstName.Text = app.FirstName;
            txtMidName.Text = app.MiddleName;
            txtSSN.Text = app.AppSSN;
            chkbPdxInd.Checked = app.PdxIndicator;            

            if (app.BirthDate != null)
            {
                DateTime dt = app.BirthDate.Value;
                txtBirthday.Text = dt.ToString("MM/dd/yyyy");
            }
            Regex regStr = new Regex(@"\d{3}-\d{2}-\d{4}");
            if (!regStr.IsMatch(txtSSN.Text) && (txtSSN.Text != "   -  -"))
                errorProvider.SetError(txtSSN, "Incorrect Format! Valid Format: ###-##-####");
            else
                errorProvider.Clear();

            if (!string.IsNullOrEmpty(app.ClientApplied))
            {
                clientCachedApiQuery.RemoveClient(app.ClientApplied);
                ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);

                if (client != null)
                {
                    cmbInvoice2.Items.Clear();
                    if (client.InvoiceDivisions.Any(inv => inv.DivisionName.Equals("None")))
                    {
                        cmbInvoice2.Items.Add("(None)");
                    }
                    List<InvoiceDivisionData> invoiceDivisions = client.InvoiceDivisions.OrderBy(x => x.DivisionName).ToList<InvoiceDivisionData>();
                    foreach (InvoiceDivisionData invoiceDivision in invoiceDivisions)
                    {
                        if (!invoiceDivision.DivisionName.Equals("None"))
                        {
                            cmbInvoice2.Items.Add(invoiceDivision.DivisionName);
                        }
                    }
                    cmbInvoice2.Text = app.InvoiceDivision;
                }
            }
        }

        public void UpdateAppFromControls(AppData app, out List<string> messages)
        {
            messages = new List<string>();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            app.LastName = txtLastName.Text;
            app.FirstName = txtFirstName.Text;
            app.MiddleName = txtMidName.Text;
            app.PdxIndicator = chkbPdxInd.Checked;

            DateTime birthday = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(txtBirthday.Text) && !txtBirthday.Text.Equals("  /  /")) // If birthday.Text is empty, skip validation
            {
                if (DateTime.TryParse(txtBirthday.Text, out birthday) == true)
                {
                    app.BirthDate = birthday;
                }
                else
                {
                    app.BirthDate = null;
                    messages.Add("Birthday is invalid.");
                }
            }

            app.AppSSN = txtSSN.Text;
            if (app.AppSSN == "   -  -")
                app.AppSSN = "";

            string invoiceDivision = cmbInvoice2.Text.Trim();
            app.InvoiceDivision = invoiceDivision;
        }

        private void TitleCaseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHandlerHelper.TitleCaseTextBox_KeyPress(sender, e);
        }

        private void txtSSN_Leave(object sender, EventArgs e)
        {
            MaskedTextBox sd = sender as MaskedTextBox;
            Regex regStr = new Regex(@"\d{3}-\d{2}-\d{4}");
            if (!regStr.IsMatch(sd.Text) && (sd.Text != "   -  -"))
                errorProvider.SetError(sd, "Incorrect Format! Valid Format: ###-##-####");
            else
                errorProvider.Clear();
        }

        private void txtBirthday_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            MaskedTextBox sd = sender as MaskedTextBox;
            if (!e.IsValidInput)
            {
                DateTime birthday;
                if (!DateTime.TryParse(sd.Text, out birthday))
                {
                    errorProvider.SetError(sd, "Incorrect Format! Valid Format: MM/dd/yyyy");
                }
                else
                {
                    txtBirthday.Text = birthday.ToString("MM/dd/yyyy");
                    errorProvider.Clear();
                }
            }
        }
                
        #region textbox SSN
        private void txtSSN_Enter(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtSSN);
        }

        private void txtSSN_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtSSN);
        }

        private void txtSSN_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                HighlightHelper.Highlight_TextBox(txtSSN);
            }
        }
        #endregion

        #region textbox Mid Name
        private void txtMidName_Enter(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtMidName);

        }

        private void txtMidName_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtMidName);
        }
        #endregion

        #region textbox first name
        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtFirstName);
        }

        private void txtFirstName_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtFirstName);
        }
        #endregion

        #region textbox last name
        private void txtLastName_Enter(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtLastName);
        }

        private void txtLastName_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtLastName);
        }

        #endregion

        #region textbox birthday
        private void txtBirthday_Enter(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtBirthday);
        }

        private void txtBirthday_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtBirthday);
        }

        private void txtBirthday_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                HighlightHelper.Highlight_TextBox(txtBirthday);
            }
        }
        #endregion

        public void UpdateInvoiceDivisionClientChanged(string clientId, string newInvoiceDivision)
        {
            if (!string.IsNullOrEmpty(clientId))
            {
                ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                ClientData client = clientCachedApiQuery.GetClient(clientId);

                if (client != null)
                {
                    cmbInvoice2.Items.Clear();
                    if (client.InvoiceDivisions.Any(inv => inv.DivisionName.Equals("None")))
                    {
                        cmbInvoice2.Items.Add("(None)");
                    }

                    List<InvoiceDivisionData> invoiceDivisions = client.InvoiceDivisions.OrderBy(x => x.DivisionName).ToList<InvoiceDivisionData>();
                    foreach (InvoiceDivisionData invoiceDivision in invoiceDivisions)
                    {
                        if (!invoiceDivision.DivisionName.Equals("None"))
                        {
                            cmbInvoice2.Items.Add(invoiceDivision.DivisionName);
                        }
                    }
                    cmbInvoice2.Text = newInvoiceDivision;
                }
            }
        }

        private void cmbInvoice2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(cmbInvoice2, e, false);
        }

        private void cmbInvoice2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string currentText = cmbInvoice2.Text.Trim();
                bool isEnter = false;
                if (e.KeyData == Keys.Enter)
                {
                    isEnter = true;
                    bool changed = false;
                    string invoiceDivision = string.Empty;
                    if (cmbInvoice2.SelectedIndex > -1)
                    {
                        invoiceDivision = cmbInvoice2.SelectedItem as string;
                        changed = true;
                    }
                    else
                    {
                        invoiceDivision = currentText;
                        if (!string.IsNullOrEmpty(invoiceDivision))
                        {
                            cmbInvoice2.Items.Add(invoiceDivision);
                            changed = true;
                        }
                    }

                    if (changed
                        && InvoiceDivisionChanged != null)
                    {
                        InvoiceDivisionChangedEventArgs arg = new InvoiceDivisionChangedEventArgs(invoiceDivision, isEnter);
                        InvoiceDivisionChanged(sender, arg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<InvoiceDivisionData> GetListInvoiceDivision(bool includeCurrentText = false)
        {
            List<InvoiceDivisionData> lstResult = new List<InvoiceDivisionData>();

            try
            {
                if (cmbInvoice2.Items.Count > 0)
                {
                    foreach (string item in cmbInvoice2.Items)
                    {
                        if (item.Length == 0 || item.Equals("(None)"))
                        {
                            continue;
                        }

                        InvoiceDivisionData data = lstResult.Find(r => (r != null
                                                                        && r.DivisionName.Equals(item)));
                        if (data == null || string.IsNullOrEmpty(data.DivisionName))
                        {
                            lstResult.Add(new InvoiceDivisionData(item));
                        }
                    }
                }

                string cboText = cmbInvoice2.Text.Trim();
                if (includeCurrentText && cboText.Length > 0 && !cboText.Equals("(None)"))
                {
                    InvoiceDivisionData data = lstResult.Find(r => (r != null
                                                                        && r.DivisionName.Equals(cboText)));

                    if (data == null || string.IsNullOrEmpty(data.DivisionName))
                    {
                        lstResult.Add(new InvoiceDivisionData(cboText));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return lstResult;
        }

        private void cmbInvoice2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox invoiceCmb = sender as ComboBox;
            if (invoiceCmb.SelectedIndex > -1)
            {
                string invoiceDivision = invoiceCmb.SelectedItem as string;
                if (!string.IsNullOrEmpty(invoiceDivision) && InvoiceDivisionChanged != null)
                {
                    InvoiceDivisionChangedEventArgs arg = new InvoiceDivisionChangedEventArgs(invoiceDivision);
                    InvoiceDivisionChanged(sender, arg);
                }
            }
        }
    }
}
