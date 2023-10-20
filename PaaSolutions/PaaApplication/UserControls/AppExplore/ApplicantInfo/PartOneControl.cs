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
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using PaaApplication.Models.AppExplore;
using Common.Infrastructure.ComboBoxCustom;
using PaaApplication.Forms;
using CreditReport.Domain.Model;
using CreditReport.Application;
using Common.Infrastructure.UI;
using PaaApplication.Forms.AppExplore;
using CreditReport.Infrastructure;
using System.IO;
using CreditReport.Application.Data;

namespace PaaApplication.UserControls.AppExplore
{
    public partial class PartOneControl : UserControl
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private FormViewCredit formViewCredit;
        ClientData _originalClient = null;
        AppData application = null;
        List<Report> lstReport = null;

        public PartOneControl()
        {
            InitializeComponent();
            ReloadClientsCombobox();
        }

        public string SpecialEntry { get; set; }

        public string ClientAppliedName { get; set; }

        public FormMaster FormMaster { get; set; }

        public bool IsClientAppliedFocus
        {
            get
            {
                return cmbClientApplied.Focused;
            }
        }

        public void InitializeSettings()
        {
            cmbClientApplied.MouseWheel += cmbClientApplied_MouseWheel;
        }

        public event EventHandler<ClientAppliedChangedEventArgs> ClientAppliedChanged;
        public event EventHandler<ClientData> ViewClientInformation;

        public ClientData GetCurrentClient()
        {
            ClientData client = (ClientData)cmbClientApplied.SelectedItem;
            return client;
        }

        public void SetCurrentClient(ClientData client)
        {
            throw new NotImplementedException();
        }

        public void ResetControls()
        {
            cmbClientApplied.SelectedIndex = -1;
            cmbClientApplied.Text = "";
            txtCustPhone.Text = "";
            btnSpecialEntry.Visible = false;
            btnClientInfo.Enabled = false;
            lnkViewCredit.Visible = false;
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            ClientData client = GetCurrentClient();

            if (client != null && !client.ClientRevoked)
            {
                app.ClientApplied = client.ClientId;
                app.ClientAppliedName = client.ClientName;
            }
        }

        public void ReloadClientsCombobox()
        {
            List<ClientData> clients;
            if (FormMaster != null)
            {
                clients = FormMaster.LIST_CLIENTS;
            }
            else
            {
                clients = ClientCachedApiQuery.Instance.GetAllClients();
            }

            cmbClientApplied.DataSource = clients;
            cmbClientApplied.DisplayMember = "ClientName";
            cmbClientApplied.ValueMember = "ClientId";
        }

        public void UpdateControlsFromApp(AppData app)
        {
            this.application = app;
            ResetControls();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            bool foundClient = false;

            if (!string.IsNullOrEmpty(app.ClientApplied))
            {
                foreach (var item in cmbClientApplied.Items)
                {
                    ClientData client = item as ClientData;
                    if (client.ClientId == app.ClientApplied)
                    {
                        cmbClientApplied.SelectedItem = client;
                        txtCustPhone.Text = client.Phone;
                        foundClient = true;
                        btnClientInfo.Enabled = true;
                        break;
                    }
                }
            }
            if (!foundClient)
            {
                cmbClientApplied.SelectedItem = null;
                cmbClientApplied.Text = (app.ClientName == null) ? string.Empty : app.ClientName;
                btnClientInfo.Enabled = false;
            }

            try
            {
                ReportApiRepository reportApiRepository = new ReportApiRepository();
                List<Report> lstReport = reportApiRepository.FindByAppId(this.application.ApplicationId);
                if (lstReport != null && lstReport.Count > 0)
                {
                    bool existedNoHitReport = lstReport.Count(x => x.StatusCode.Trim().Equals("-4")) > 0;
                    bool existedCompletedReport = lstReport.Count(x => x.StatusCode.Trim().Equals("0")) > 0;
                    this.lstReport = lstReport;
                    
                    if (existedNoHitReport && !existedCompletedReport)
                    {
                        // no completed report and there's no hit report
                        lnkViewCredit.Text = "No Hit";
                        lnkViewCredit.Enabled = false;
                    }
                    else
                    {
                        lnkViewCredit.Text = "View TransUnion Credit";
                        lnkViewCredit.Enabled = true;
                    }
                    lnkViewCredit.Visible = true;
                }
            }
            catch(Exception ex) 
            {
                _logger.Error(ex);
            }
        }

        public void SetVisibleButtonSpecialEntry(bool isVisible)
        {
            this.btnSpecialEntry.Visible = isVisible;
        }

        private void btnSpecialEntry_Click(object sender, EventArgs e)
        {
            string messageString = string.Format("The following information should be noted for {0} : \n \n {1}", this.ClientAppliedName, this.SpecialEntry);

            MessageBox.Show(messageString, "Special Entry Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void cmbClientApplied_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (!cmb.Focused)
                return;
            ClientData client = (ClientData)cmb.SelectedItem;
        }

        private void cmbClientApplied_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (!cmb.Focused)
                return;
            ClientData client = (ClientData)cmb.SelectedItem;
            if (client != null)
            {
                ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                var clientApplied = clientCachedApiQuery.GetClient(client.ClientId);
                if(clientApplied == null)
                {
                    MessageBox.Show("Selected client is deleted. Please check and try again.", "Action denied", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    cmb.SelectedItem = _originalClient;
                    return;
                }
                if (client.ClientRevoked)
                {
                    MessageBox.Show("Selected client is revoked. Please check and try again.", "Action denied", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    cmb.SelectedItem = _originalClient;
                    return;
                }
            }
        }

        private void cmbClientApplied_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(cmbClientApplied, e, false);
        }

        private void cmbClientApplied_Enter(object sender, EventArgs e)
        {
            GlobalVars.IsIgnoreAutoSave = true;
            ComboBox cmb = sender as ComboBox;
            if (!cmb.Focused)
                return;
            _originalClient = (ClientData)cmb.SelectedItem;
            GlobalVars.IsIgnoreAutoSave = false;
        }

        private void cmbClientApplied_Validating(object sender, CancelEventArgs e)
        {
            GlobalVars.IsIgnoreAutoSave = true;

            // Return immediately if the forms are not loaded 
            if (!GlobalVars.IsFormLoaded)
                return;

            string cmbClientAppliedText = cmbClientApplied.Text;
            List<ClientData> clients;
            if (FormMaster != null)
            {
                clients = FormMaster.LIST_CLIENTS;
            }
            else
            {
                clients = ClientCachedApiQuery.Instance.GetAllClients();
            }
            ClientData client = clients.Find(r => (r != null
                                                    && !string.IsNullOrEmpty(cmbClientAppliedText)
                                                    && !string.IsNullOrEmpty(r.ClientName)
                                                    && r.ClientName.Equals(cmbClientAppliedText)
                                                    && !r.ClientRevoked));
            if (client != null && !string.IsNullOrEmpty(client.ClientId))
            {
                _originalClient = client;
                cmbClientApplied.SelectedItem = client;
                txtCustPhone.Text = client.Phone;
            }
            else if (_originalClient != null)
            {
                MessageBox.Show("Invalid client applied. Please check and try again.", "Action denied", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                cmbClientApplied.SelectedItem = _originalClient;
                client = _originalClient;
            }

            if (client != null)
            {
                txtCustPhone.Text = client.Phone;
                if (this.ClientAppliedChanged != null)
                {
                    ClientAppliedChangedEventArgs args = new ClientAppliedChangedEventArgs(client, ClientAppliedChangedEventArgs.ChangedBy.BySelect);
                    this.ClientAppliedChanged(this, args);
                }
            }
            GlobalVars.IsIgnoreAutoSave = false;
        }

        void cmbClientApplied_MouseWheel(object sender, MouseEventArgs e)
        {
            //((HandledMouseEventArgs)e).Handled = true;
        }

        private void btnClientInfo_Click(object sender, EventArgs e)
        {
            ClientData client = (ClientData)cmbClientApplied.SelectedItem;
            if (client == null || string.IsNullOrEmpty(client.ClientId))
            {
                return;
            }

            if (this.ViewClientInformation != null)
            {
                this.ViewClientInformation(this, client);
            }
        }

        private void cmbClientApplied_KeyUp(object sender, KeyEventArgs e)
        {
            GlobalVars.IsIgnoreAutoSave = true;
            if (e.KeyCode == Keys.Enter)
            {
                ComboBox cmb = sender as ComboBox;
                if (!cmb.Focused)
                    return;
                ClientData client = (ClientData)cmb.SelectedItem;
                if (client != null && _originalClient != null)
                {
                    _originalClient = client;
                    txtCustPhone.Text = client.Phone;
                    if (this.ClientAppliedChanged != null)
                    {
                        ClientAppliedChangedEventArgs args = new ClientAppliedChangedEventArgs(client, ClientAppliedChangedEventArgs.ChangedBy.ByEnterKeyPress);
                        this.ClientAppliedChanged(this, args);
                    }
                }
            }
            GlobalVars.IsIgnoreAutoSave = false;
        }

        private void lnkViewCredit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ReportApiRepository reportApiRepository = new ReportApiRepository();
                List<Report> lstReport = reportApiRepository.FindByAppId(this.application.ApplicationId);
                List<ReportLightweightData> lwReports = new List<ReportLightweightData>();
                foreach (var item in lstReport)
                {
                    lwReports.Add(AutoMapper.Mapper.Map<Report, ReportLightweightData>(item));
                }
                if (lstReport.Count > 1)
                {
                    using (new HourGlass())
                    {
                        formViewCredit = new FormViewCredit();
                        formViewCredit.SetApps(lwReports, application);
                        formViewCredit.BringToFront();
                        formViewCredit.Show();
                    }
                }
                else if (lstReport.Count == 1)
                {
                    Report report = lstReport.FirstOrDefault();
                    string dataBlob = report.DataBlob;

                    byte[] data = Convert.FromBase64String(dataBlob);
                    string url = Encoding.UTF8.GetString(data);

                    string path = Path.GetTempPath() + report.ReportId + ".html";

                    try
                    {
                        File.WriteAllText(path, url);
                        System.Diagnostics.Process.Start(path);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex);
                    }
                }
                else
                {
                    using (new HourGlass())
                    {
                        formViewCredit = new FormViewCredit();
                        formViewCredit.SetApps(lwReports, application);
                        formViewCredit.BringToFront();
                        formViewCredit.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }
    }
}
