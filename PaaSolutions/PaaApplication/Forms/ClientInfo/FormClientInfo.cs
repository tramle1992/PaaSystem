using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Application.Data.ClientInfo;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;
using Common.Infrastructure.ApiClient;
using Common.Infrastructure.OLV;
using Common.Application.DialogMessage;
using PaaApplication.Models.ClientInfo;
using PaaApplication.UserControls.ClientInfo;
using Common.Infrastructure.UI;
using Core.Application.Command.ClientInfo;
using BrightIdeasSoftware;
using System.Collections;
using PaaApplication.Models.Common;
using PaaApplication.Forms.ClientInfo;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Infrastructure.Authorization;
using Core.Infrastructure.ClientInfo;
using Core.Domain.Model.ClientInfo;
using Common.Infrastructure.Office;

namespace PaaApplication.Forms
{
    public partial class FormClientInfo : BaseForm
    {
        public class ClientDataListFilter : IListFilter
        {
            public ClientDataListFilter(List<string> lstClientIds)
            {
                this._listClientIds = lstClientIds;
            }

            public IEnumerable Filter(IEnumerable modelObjects)
            {
                List<ClientData> lstResult = new List<ClientData>();

                foreach (var item in modelObjects)
                {
                    ClientData data = (ClientData)item;
                    if (_listClientIds.Contains(data.ClientId))
                    {
                        lstResult.Add(data);
                    }
                }
                return lstResult;
            }

            private List<string> _listClientIds;
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ObjectListViewService _olvService = new ObjectListViewService();
        OLVColumnFormat _olvFormat = new OLVColumnFormat();

        ClientCachedApiQuery _clientCachedApiQuery = ClientCachedApiQuery.Instance;
        ClientApiRepository _clientApiRepository = new ClientApiRepository();

        private static List<Form> formList = new List<Form>();
        private FormClientAddNew _formAddNew = new FormClientAddNew();
        public FormMaster formMaster;
        private FormSearchClient formSearch;

        private State _formState = State.onEdit;
        private bool _loadCompleted = false;

        public ClientData CurrentLoadedClient = null;

        private List<ClientData> selectedObjects = new List<ClientData>();

        private Timer timer = new Timer();

        #region Form Initial

        public FormClientInfo() { }

        public FormClientInfo(FormMaster formMaster)
        {
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            this.formMaster = formMaster;
            InitializeComponent();            
            this.uClientInfoRibbon.CreateClientClick += CreateClientClickHandler;
            this.uClientInfoRibbon.DeleteClientClick += DeleteClientClickHandler;
            this.uClientInfoRibbon.SearchClientClick += SearchClientClickHandler;
            this.uClientInfoRibbon.ForClientClick += ForClientClickHandler;
            this.uClientInfoRibbon.ForShownClientClick += ForShownClientClickHandler;
            this.uClientInfoRibbon.NotForClientClick += NotForClientClickHandler;
            this.uClientInfoRibbon.CommonPrintClick += CommonPrintClickHandler;
            this.uClientInfoRibbon.LabelClick += LabelClickHandler;
            this.uClientInfoRibbon.DatagridSelectedClientsClick += DatagridSelectedClientsClickHandler;
            this.uClientInfoRibbon.DatagridAllShownClientsClick += DatagridAllShownClientsClickHandler;
            this.uClientInfoRibbon.EmailSelectedClientsClick += EmailSelectedClientsClickHandler;
            this.uClientInfoRibbon.EmailAllShownClientsClick += EmailAllShownClientsClickHandler;
            this.uClientInfoRibbon.EditClientPriceClick += EditClientPriceClickHandler;
            this.uClientInfoRibbon.SaveClientClick += SaveClientClickHandler;
            this.uClientInfoRibbon.RefreshClientClick += RefreshClientClickHandler;
        }

        #endregion

        #region Control Events

        private void FormClientInfo_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            this.olvcolSince.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    ClientData client = row as ClientData;
                    if (client != null)
                    {
                        return client.Since;
                    }
                }
                return DateTime.Now;
            };

            ucClientInfo.InitDataForFields(CurrentLoadedClient);
        }

        private void olvClientInfo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.ucClientInfo.ResetAllFields();
                this.ucClientInfo.SetCurrentClient(null);

                ClientData selectedClient = ((ClientData)olvClientInfo.SelectedObject);

                if (selectedClient == null && olvClientInfo.Items.Count > 0 && olvClientInfo.MultiSelect && olvClientInfo.SelectedObjects.Count > 1)
                {
                    ObjectListView olv = sender as ObjectListView;
                    Core.Domain.Model.ExploreApps.Location archiveLocation = Core.Domain.Model.ExploreApps.Location.Archive;
                    List<ClientData> listSelectedApps = new List<ClientData>();

                    if (selectedObjects.Count > 0)
                        selectedObjects.Clear();

                    foreach (ClientData clientData in olvClientInfo.SelectedObjects)
                    {
                        selectedObjects.Add(clientData);
                    }

                    CurrentLoadedClient = null;
                    return;
                }
                else if (selectedClient == null)
                {
                    CurrentLoadedClient = null;

                    if (selectedObjects.Count == 1)
                        olvClientInfo.SelectedObject = selectedObjects.FirstOrDefault();
                    else if (selectedObjects.Count > 1)
                        olvClientInfo.SelectedObjects = selectedObjects;

                    return;
                }


                ucClientInfo.EditingClientName = selectedClient.ClientName;
                ucClientInfo.SetCurrentClient(selectedClient);
                ucClientInfo.LoadData(selectedClient);
                CurrentLoadedClient = selectedClient;

                if (selectedObjects.Count > 0)
                    selectedObjects.Clear();
                selectedObjects.Add(selectedClient);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void olvClientInfo_ItemsChanged(object sender, EventArgs e)
        {
            if (formMaster != null)
            {
                string message = (olvClientInfo.Items.Count > 0) ? string.Format("{0} Clients In View", olvClientInfo.Items.Count) : string.Empty;
                SetAppCount(message);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string strSearch = (sender as TextBox).Text;
            bool filter = false;

            if (e.KeyCode == Keys.Back && strSearch.Length == 0)
            {
                strSearch = string.Empty;
                _olvService.FilterOlv(this.olvClientInfo, strSearch);
                filter = true;
            }
            else if (e.KeyCode == Keys.Enter && strSearch.Length > 0)
            {
                _olvService.FilterOlv(this.olvClientInfo, strSearch);
                filter = true;
            }

            if (filter)
            {
                if (this.olvClientInfo.Items.Count > 0)
                {
                    this.olvClientInfo.SelectedIndex = 0;
                }
                else
                {
                    this.ucClientInfo.ResetAllFields();
                    this.ucClientInfo.SetCurrentClient(null);
                }
            }
        }

        //Context Menu

        private void tstripDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                //  ClientData selectedClient = (ClientData)this.olvClientInfo.SelectedObject;

                DeleteClient();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void tstripAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowFormAddNewClient();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Event Handlers

        public void SetClientOlv(List<string> lstClientId)
        {
            this.olvClientInfo.ListFilter = new ClientDataListFilter(lstClientId);

            if (this.olvClientInfo.Items.Count > 0)
            {
                this.olvClientInfo.SelectedIndex = 0;
                this.olvClientInfo.EnsureVisible(0);
            }
            else
            {
                ucClientInfo.ResetAllFields();
                ucClientInfo.SetCurrentClient(null);
            }
        }

        public void ShowFormAddNewClient()
        {
            ucClientInfo.FormState = State.onAddNew;
            FormClientAddNew formAdd = new FormClientAddNew();
            formAdd.StartPosition = FormStartPosition.CenterParent;

            if (formAdd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ClientData client = new ClientData();
                client = InitNewClient(formAdd.ClientName, formAdd.CustNo);

                using (new HourGlass())
                {
                    client.ClientId = _clientCachedApiQuery.AddClient(client);
                }

                client.Since = client.Since.ToLocalTime();

                this.olvClientInfo.AddObject(client);
                this.olvClientInfo.SelectObject(client, true);
                this.olvClientInfo.EnsureModelVisible(client);

                if (!string.IsNullOrEmpty(client.CustomerNumber))
                {
                    string letterCusNo = client.CustomerNumber[0].ToString();
                    int number = Convert.ToInt32(client.CustomerNumber.Substring(1, client.CustomerNumber.Length - 1));

                    _clientApiRepository.UpdateCustomerNumber(letterCusNo, number);
                }
            }
        }

        public ClientData InitNewClient(string clientName, string custNo)
        {
            ClientData data = new ClientData();
            try
            {
                data.ClientName = clientName;
                data.CustomerNumber = custNo;

                CreditTypeData credit = new CreditTypeData();
                credit.Value = 0;
                credit.DisplayName = CreditType.RegularCreditReports.DisplayName;

                data.CreditType = credit;
                data.Since = DateTime.UtcNow;
                data.BillingAddress = string.Empty;
                data.BillingInfo = string.Empty;
                data.ClientRevoked = false;
                data.CreatedAt = DateTime.UtcNow;
                data.Credentialed = false;
                data.DeclinationLetter = false;
                data.DefaultDeliverConfirmationsTo = string.Empty;
                data.DefaultDeliverInvoicesTo = string.Empty;
                data.DefaultDeliverReportsTo = string.Empty;
                data.DefaultVerifyConfirmDelivery = false;
                data.Email = string.Empty;
                data.Fax = string.Empty;
                data.InvoicesCopiesNumber = 0;
                data.MiscComments = string.Empty;
                data.Phone = string.Empty;
                data.SpecialCriteriaInfo = string.Empty;
                data.SpecialEntryInfo = string.Empty;
                data.Summaries = false;
                data.WebPass = string.Empty;
                data.WebsiteDir = string.Empty;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message, "Exception");
            }
            return data;
        }

        public void ReloadClientInfoData(ClientData selectedClient)
        {
            try
            {
                using (new HourGlass())
                {
                    if (!this._loadCompleted)
                    {
                        this._loadCompleted = true;
                    }

                    List<ClientData> clientData = formMaster.LIST_CLIENTS;

                    if (clientData == null || clientData.Count == 0)
                    {
                        this.olvClientInfo.ClearObjects();
                        return;
                    }

                    this.olvClientInfo.SetObjects(clientData);

                    if (selectedClient == null || string.IsNullOrEmpty(selectedClient.ClientId))
                    {
                        this.olvClientInfo.SelectedIndex = 0;
                        this.olvClientInfo.EnsureVisible(0);
                        return;
                    }

                    for (int i = 0; i < this.olvClientInfo.Items.Count; i++)
                    {
                        ClientData item = (ClientData)this.olvClientInfo.GetModelObject(i);
                        if (item != null && !string.IsNullOrEmpty(item.ClientId) &&
                            item.ClientId.Equals(selectedClient.ClientId))
                        {
                            this.olvClientInfo.SelectedIndex = i;
                            this.olvClientInfo.EnsureVisible(i);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        public void DeleteClient()
        {
            try
            {
                ClientData client = (ClientData)this.olvClientInfo.SelectedObject;
                if (client == null)
                {
                    return;
                }

                // Special code to prevent user to delete the anchor(first) client
                if (client.CustomerNumber == "Z062" || client.ClientName == "111 DO NOT DELETE")
                {
                    return;
                }


                string message = string.Format("Are you sure to delete client \"{0}\" ?", client.ClientName);

                if (MessageBox.Show(message, "Delete Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (client != null)
                    {
                        int index = this.olvClientInfo.SelectedIndex;
                        string clientId = client.ClientId;
                        _clientApiRepository.Remove(client);
                        _clientCachedApiQuery.RemoveClient(client.ClientId);
                        this.olvClientInfo.RemoveObject(client);

                        ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                        clientCachedApiQuery.RemoveClient(clientId);

                        if (this.olvClientInfo.Items.Count > 0)
                        {
                            index = index.Equals(this.olvClientInfo.Items.Count) ? index - 1 : index;
                            this.olvClientInfo.SelectedIndex = index;
                            this.olvClientInfo.EnsureVisible(index);
                        }
                        else
                        {
                            ucClientInfo.ResetAllFields();
                            ucClientInfo.SetCurrentClient(null);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        public List<string> GetListSelectedClientIds()
        {
            List<string> ids = new List<string>();
            foreach (var clientData in olvClientInfo.SelectedObjects)
            {
                ClientData data = (ClientData)clientData;
                ids.Add(data.ClientId);
            }
            return ids;
        }

        public ClientData GetSelectedClient()
        {
            if (this.olvClientInfo.Items.Count > 0 && this.olvClientInfo.SelectedObjects.Count > 0)
            {
                ClientData client = (ClientData)olvClientInfo.SelectedObjects[olvClientInfo.SelectedObjects.Count - 1];
                return client;
            }
            return null;
        }

        public List<ClientData> GetListSelectedClients()
        {
            List<ClientData> clients = new List<ClientData>();
            foreach (var clientData in olvClientInfo.SelectedObjects)
            {
                ClientData data = (ClientData)clientData;
                clients.Add(data);
            }
            return clients;
        }

        public List<ClientData> GetShownClients()
        {
            List<ClientData> clients = new List<ClientData>();
            foreach (var clientData in olvClientInfo.FilteredObjects)
            {
                ClientData data = (ClientData)clientData;
                clients.Add(data);
            }
            return clients;
        }

        public List<ClientData> GetNotShownClients()
        {
            List<ClientData> allClients = formMaster.LIST_CLIENTS;
            List<ClientData> shownClients = GetShownClients();
            List<ClientData> notShownClients = new List<ClientData>();
            foreach (ClientData client in allClients)
            {
                if (shownClients.Find(x => x.ClientId == client.ClientId) != null)
                    continue;
                notShownClients.Add(client);
            }
            return notShownClients;
        }

        public List<ClientData> GetListAllClients()
        {
            List<ClientData> clients = new List<ClientData>();

            if (olvClientInfo.Objects == null ||
                olvClientInfo.GetItemCount() == 0)
            {
                return clients;
            }

            foreach (ClientData clientData in olvClientInfo.Objects)
            {
                if (clientData != null && !string.IsNullOrEmpty(clientData.ClientId))
                {
                    clients.Add(clientData);
                }
            }

            return clients;
        }

        public void GetClientDataFromForm(ClientData client)
        {
            ucClientInfo.GetClientDataFromForm(client);
        }

        public void LoadDataFromClient(ClientData client)
        {
            GlobalVars.IsIgnoreAutoSave = true;
            ucClientInfo.LoadData(client);
            GlobalVars.IsIgnoreAutoSave = false;
        }

        public void OnEditSpecialPricesCompletedHandler(ClientData updatedClient)
        {
            try
            {
                _clientCachedApiQuery.RemoveAllClients();
                ReloadClientInfoData(updatedClient);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        public Task<bool> SaveClientAsync(ClientData client)
        {
            return Task.Run(() =>
                {
                    try
                    {
                        if (client == null)
                            return false;
                        _clientApiRepository.Update(client);
                        _clientCachedApiQuery.SetClient(client);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex);
                        return false;
                    }
                });
        }

        public void SaveClient()
        {
            ClientData selectedClient = this.olvClientInfo.SelectedObject as ClientData;

            if (selectedClient == null) return;
            ClientData client = new ClientData();
            ucClientInfo.GetClientDataFromForm(client);

            if (client.ClientRevoked && selectedClient.ClientRevoked)
            {
                MessageBox.Show("Unable to save! The client is blocked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (client.CustomerNumber == "Z062" || client.ClientName == "111 DO NOT DELETE")
            {
                return;
            }

            using (new HourGlass())
            {
                if (SaveClientData(client)) return;

                selectedClient.ClientName = client.ClientName;
                selectedClient.BillingAddress = client.BillingAddress;
                selectedClient.BillingInfo = client.BillingInfo;
                selectedClient.ClientReportSpecialPrices = client.ClientReportSpecialPrices;
                selectedClient.ClientRevoked = client.ClientRevoked;
                selectedClient.Contacts = client.Contacts;
                selectedClient.CreatedAt = client.CreatedAt;
                selectedClient.Credentialed = client.Credentialed;
                selectedClient.CreditType = client.CreditType;
                selectedClient.CustomerNumber = client.CustomerNumber;
                selectedClient.DeclinationLetter = client.DeclinationLetter;
                selectedClient.Email = client.Email;
                selectedClient.DefaultDeliverConfirmationsTo = client.DefaultDeliverConfirmationsTo;
                selectedClient.DefaultDeliverInvoicesTo = client.DefaultDeliverInvoicesTo;
                selectedClient.DefaultDeliverReportsTo = client.DefaultDeliverReportsTo;
                selectedClient.DefaultVerifyConfirmDelivery = client.DefaultVerifyConfirmDelivery;
                selectedClient.Fax = client.Fax;
                selectedClient.InvoiceDivisions = client.InvoiceDivisions;
                selectedClient.InvoicesCopiesNumber = client.InvoicesCopiesNumber;
                selectedClient.ManagementCompany = client.ManagementCompany;
                selectedClient.MiscComments = client.MiscComments;
                selectedClient.OtherAddresses = client.OtherAddresses;
                selectedClient.Phone = client.Phone;
                selectedClient.Since = client.Since;
                selectedClient.SpecialCriteriaInfo = client.SpecialCriteriaInfo;
                selectedClient.SpecialEntryInfo = client.SpecialEntryInfo;
                selectedClient.Summaries = client.Summaries;
                selectedClient.UpdatedAt = client.UpdatedAt;
                selectedClient.WebPass = client.WebPass;
                selectedClient.WebsiteDir = client.WebsiteDir;
                selectedClient.DefaultReportTypeId = client.DefaultReportTypeId;
            }

            olvClientInfo.RefreshObject(selectedClient);
        }

        private bool SaveClientData(ClientData clientData)
        {
            bool hasError = false;
            try
            {
                if (clientData == null) return true;

                if (_formState == State.onEdit)
                {
                    if (!string.IsNullOrEmpty(clientData.ClientName) && clientData.ClientName != ucClientInfo.EditingClientName)
                    {
                        ClientData returnClient = _clientApiRepository.FindByName(clientData.ClientName);

                        if (returnClient != null)
                        {
                            ucClientInfo.SetErrorBtnLockEdit("ClientName already exists");
                            hasError = true;
                        }
                        else
                        {
                            ucClientInfo.SetErrorBtnLockEdit("");
                        }
                        ucClientInfo.EditingClientName = clientData.ClientName;
                    }

                    _clientCachedApiQuery.UpdateClient(clientData);
                }

                if (!ucClientInfo.IsValidInput())
                {
                    MessageBox.Show("Some input are invalid. Please check again.", "Save Client Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    hasError = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message);
            }
            return hasError;
        }

        #region Context Menu Events
        private void labelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this != null)
                {
                    List<string> clientIds = GetListSelectedClientIds();
                    FormClientLabel formClientLabel = new FormClientLabel(clientIds);
                    formClientLabel.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }

        }

        private void clientInfoSheetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    DocumentCompleteResult result = null;
                    WordDocumentBuilder wordDocumentBuilder = new WordDocumentBuilder();
                    ClientData selectedClient = (ClientData)this.olvClientInfo.SelectedObject;
                    result = wordDocumentBuilder.BuildClientInfoDocument(WordDocumentType.ClientInfo, selectedClient);
                    if (result != null)
                    {
                        result.PrintWordDocument(1);
                        result.QuitWordDocument(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }

        }

        private void residentialContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    DocumentCompleteResult result = null;
                    WordDocumentBuilder wordDocumentBuilder = new WordDocumentBuilder();
                    ClientData selectedClient = (ClientData)this.olvClientInfo.SelectedObject;
                    result = wordDocumentBuilder.BuildContractDocument(WordDocumentType.ResidentialContract, selectedClient);
                    if (result != null)
                    {
                        result.PrintWordDocument(1);
                        result.QuitWordDocument(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void employmentContractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    DocumentCompleteResult result = null;
                    WordDocumentBuilder wordDocumentBuilder = new WordDocumentBuilder();
                    ClientData selectedClient = (ClientData)this.olvClientInfo.SelectedObject;
                    result = wordDocumentBuilder.BuildContractDocument(WordDocumentType.EmploymentContract, selectedClient);
                    if (result != null)
                    {
                        result.PrintWordDocument(1);
                        result.QuitWordDocument(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void fromAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormClientDataGrid formClientDataGrid = new FormClientDataGrid();
                formClientDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void fromSelectedClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> clientIds = this.GetListSelectedClientIds();
                FormClientDataGrid formClientDataGrid = new FormClientDataGrid(clientIds);
                formClientDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }

        private void tstripComposeEmail_Click(object sender, EventArgs e)
        {
            List<ClientData> clients = GetListSelectedClients();
            SendCustomerServiceEmailToClients(clients);
        }
        #endregion

        private void FormClientInfo_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                CheckPermission();
                RefreshData();

                string message = (olvClientInfo.Items.Count > 0) ? string.Format("{0} Clients In View", olvClientInfo.Items.Count) : string.Empty;
                SetAppCount(message);                
            }
        }

        private void CheckPermission()
        {
            if (formMaster != null)
            {
                if (formMaster.CURRENT_USER != null)
                {
                    Role role = formMaster.CURRENT_ROLE;
                    FeatureAuthorization featureAuth = new FeatureAuthorization();

                    if (role != null)
                    {
                        foreach (FeaturePermission item in role.FeaturePermissions)
                        {
                            if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.DeleteClient))
                            {
                                if (!item.IsAllowed)
                                {
                                    cmnuClientInfo.Items[0].Visible = false;
                                    cmnuClientInfo.Items[1].Visible = false;
                                    toolStripSeparator1.Visible = false;
                                }
                                else
                                {
                                    cmnuClientInfo.Items[0].Visible = true;
                                    cmnuClientInfo.Items[1].Visible = true;
                                    toolStripSeparator1.Visible = true;
                                }
                            }

                            if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.ChangeClientName))
                            {
                                if (!item.IsAllowed)
                                {
                                    ucClientInfo.EditClientNameEnabled = false;
                                    ucClientInfo.EditClientNameVisible = false;
                                }
                                else
                                {
                                    ucClientInfo.EditClientNameEnabled = true;
                                    ucClientInfo.EditClientNameVisible = true;
                                }
                            }

                            if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.BlockUnblockActivity))
                            {
                                if (!item.IsAllowed)
                                
                           
                                {
                                    ucClientInfo.AbleToBlockUnblockActivity = false;
                                    ucClientInfo.AbleToBlockUnblockActivity = false;
                                }
                                else
                                {
                                    ucClientInfo.AbleToBlockUnblockActivity = true;
                                    ucClientInfo.AbleToBlockUnblockActivity = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void RefreshData()
        {
            try
            {
                ClientData selectedClient = GetSelectedClient();
                ReloadClientInfoData(selectedClient);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshClient(ClientData clientToRefresh)
        {
            if (clientToRefresh == null || string.IsNullOrEmpty(clientToRefresh.ClientId))
                return;

            ClientData client = null;
            foreach (ClientData c in olvClientInfo.Objects)
            {
                if (c.ClientId == clientToRefresh.ClientId)
                {
                    client = c;
                    break;
                }
            }
            if (client != null)
            {
                client.ClientName = clientToRefresh.ClientName;
                client.BillingAddress = clientToRefresh.BillingAddress;
                client.BillingInfo = clientToRefresh.BillingInfo;
                client.ClientReportSpecialPrices = clientToRefresh.ClientReportSpecialPrices;
                client.ClientRevoked = clientToRefresh.ClientRevoked;
                client.Contacts = clientToRefresh.Contacts;
                client.CreatedAt = clientToRefresh.CreatedAt;
                client.Credentialed = clientToRefresh.Credentialed;
                client.CreditType = clientToRefresh.CreditType;
                client.CustomerNumber = clientToRefresh.CustomerNumber;
                client.DeclinationLetter = clientToRefresh.DeclinationLetter;
                client.Email = clientToRefresh.Email;
                client.DefaultDeliverConfirmationsTo = clientToRefresh.DefaultDeliverConfirmationsTo;
                client.DefaultDeliverInvoicesTo = clientToRefresh.DefaultDeliverInvoicesTo;
                client.DefaultDeliverReportsTo = clientToRefresh.DefaultDeliverReportsTo;
                client.DefaultVerifyConfirmDelivery = clientToRefresh.DefaultVerifyConfirmDelivery;
                client.Fax = clientToRefresh.Fax;
                client.InvoiceDivisions = clientToRefresh.InvoiceDivisions;
                client.InvoicesCopiesNumber = clientToRefresh.InvoicesCopiesNumber;
                client.ManagementCompany = clientToRefresh.ManagementCompany;
                client.MiscComments = clientToRefresh.MiscComments;
                client.OtherAddresses = clientToRefresh.OtherAddresses;
                client.Phone = clientToRefresh.Phone;
                client.Since = clientToRefresh.Since;
                client.SpecialCriteriaInfo = clientToRefresh.SpecialCriteriaInfo;
                client.SpecialEntryInfo = clientToRefresh.SpecialEntryInfo;
                client.Summaries = clientToRefresh.Summaries;
                client.UpdatedAt = clientToRefresh.UpdatedAt;
                client.WebPass = clientToRefresh.WebPass;
                client.WebsiteDir = clientToRefresh.WebsiteDir;

                olvClientInfo.RefreshObject(client);
                LoadDataFromClient(client);
            }
        }

        public void ClearFilterOlv()
        {
            txtSearch.Text = string.Empty;
            _olvService.FilterOlv(this.olvClientInfo, string.Empty);
        }

        private void FormClientInfo_LoadCompleted(object sender, EventArgs e)
        {
        }

        public void OpenFormMagement()
        {
            this.ucClientInfo.btnMgtWideInfo_Click(this, null);
        }

        public void SendCustomerServiceEmailToClients(List<ClientData> clients)
        {
            List<string> emails = new List<string>();
            try
            {
                using (new HourGlass())
                {
                    foreach (ClientData client in clients)
                    {
                        if (!string.IsNullOrEmpty(client.Email))
                            emails.Add(client.Email);
                        foreach (ContactData contact in client.Contacts)
                        {
                            if (contact.ContactTypeName == "Email" && !string.IsNullOrEmpty(contact.ContactInfo))
                                emails.Add(contact.ContactInfo);
                        }
                    }
                    OutlookService outlook = new OutlookService();
                    outlook.SetTo(ConfigurationManager.AppSettings["CustomerServiceEmail"]);
                    outlook.SetBcc(emails);
                    outlook.Display();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool RigthSectionIsFocused()
        {
            return this.olvClientInfo.Focused;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            string date = t.ToLongDateString();
            string time = t.ToLongTimeString();
            sttlblClock.Text = string.Format("{0} | {1}", date, time);
        }

        public void SetAppCount(string message = "")
        {
            if (string.IsNullOrEmpty(message))
            {
                sttlblCount.Text = "No Clients In View";
            }
            else
            {
                sttlblCount.Text = message;
            }
        }

        public void ViewClientInformationFromAppExplore(ClientData client)
         {
              this.Init();
              this.ClearFilterOlv();
              this.ReloadClientInfoData(client);
              this.BringToFront();
              this.Show();            
          }

        #region Click Handler
        private void CreateClientClickHandler(object sender, EventArgs e)
        {
            ShowFormAddNewClient();
        }
        private void DeleteClientClickHandler(object sender, EventArgs e)
        {
            DeleteClient();
        }
        private void SearchClientClickHandler(object sender, EventArgs e)
        {
            
            if (formSearch == null)
            {
                formSearch = new FormSearchClient();
                formList.Add(formSearch);

                if (this != null)
                {
                    (formSearch as FormSearchClient).OnSearchClient += new EventHandler<List<string>>(delegate(object delegateSender, List<string> data)
                    {
                        this.SetClientOlv(data);
                    });
                }
            }

            if (this != null)
            {
                ClientCachedApiQuery clientCacheApi = ClientCachedApiQuery.Instance;
                (formSearch as FormSearchClient).ClientData = clientCacheApi.GetAllClients();
            }

            formSearch.StartPosition = FormStartPosition.CenterParent;
            formSearch.BringToFront();
            formSearch.ShowDialog();
        }
        private void ForClientClickHandler(object sender, EventArgs e)
        {
            List<ClientData> clients = GetListSelectedClients();
            List<string> clientIds = new List<string>();
            foreach (ClientData client in clients)
            {
                clientIds.Add(client.ClientId);
            }
            formMaster.ShowAppsByClients(clientIds);
        }
        private void ForShownClientClickHandler(object sender, EventArgs e)
        {
            List<ClientData> clients = GetShownClients();
            List<string> clientIds = new List<string>();
            foreach (ClientData client in clients)
            {
                clientIds.Add(client.ClientId);
            }
            formMaster.ShowAppsByClients(clientIds);
        }
        private void NotForClientClickHandler(object sender, EventArgs e)
        {
            List<ClientData> clients = GetNotShownClients();
            List<string> clientIds = new List<string>();
            foreach (ClientData client in clients)
            {
                clientIds.Add(client.ClientId);
            }
            formMaster.ShowAppsByClients(clientIds);
        }
        private void CommonPrintClickHandler(object sender, EventArgs e)
        {
            RibbonButton button = sender as System.Windows.Forms.RibbonButton;
            WordDocumentType documentType = uClientInfoRibbon.GetDocType(button);
            try
            {
                if (this != null)
                {
                    List<ClientData> clients = GetListSelectedClients();
                    using (new HourGlass())
                    {
                        foreach (ClientData client in clients)
                        {
                            formMaster.CommonPrintDocument(documentType, client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LabelClickHandler(object sender, EventArgs e)
        {
            try
            {
                if (this != null)
                {
                    List<string> clientIds = GetListSelectedClientIds();
                    FormClientLabel formClientLabel = new FormClientLabel(clientIds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }
        private void DatagridSelectedClientsClickHandler(object sender, EventArgs e)
        {
            try
            {
                if (this != null)
                {
                    List<string> clientIds = GetListSelectedClientIds();
                    FormClientDataGrid formClientDataGrid = new FormClientDataGrid(clientIds);
                    formClientDataGrid.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }
        private void DatagridAllShownClientsClickHandler(object sender, EventArgs e)
        {
            try
            {
                FormClientDataGrid formClientDataGrid = new FormClientDataGrid();
                formClientDataGrid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex);
            }
        }
        private void EmailSelectedClientsClickHandler(object sender, EventArgs e)
        {
            if (this != null)
            {
                List<ClientData> clients = GetListSelectedClients();
                SendCustomerServiceEmailToClients(clients);
            }
        }
        private void EmailAllShownClientsClickHandler(object sender, EventArgs e)
        {
            if (this != null)
            {
                List<ClientData> clients = GetListAllClients();
                SendCustomerServiceEmailToClients(clients);
            }
        }
        private void EditClientPriceClickHandler(object sender, EventArgs e)
        {
            if (this == null)
            {
                return;
            }

            ClientData selectedClient = GetSelectedClient();
            if (selectedClient == null)
            {
                MessageBox.Show("Please select client to edit Special Prices.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormClientEditSpecialPrice form = new FormClientEditSpecialPrice(selectedClient);
            form.OnEditSpecialPrices += new EventHandler<ClientData>(delegate(object delegateSender, ClientData data)
            {
                OnEditSpecialPricesCompletedHandler(data);
            });
            form.StartPosition = FormStartPosition.CenterParent;
            form.BringToFront();
            form.ShowDialog();
        }
        private void SaveClientClickHandler(object sender, EventArgs e)
        {
            if (this != null)
            {
                using (new HourGlass())
                {
                    SaveClient();
                }
            }
        }
        private void RefreshClientClickHandler(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                formMaster.RefreshClientData();
                RefreshData();
            }
        }

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.RigthSectionIsFocused() && keyData == Keys.Delete)
            {
                this.DeleteClient();
            }

            switch (keyData)
            {
                case Keys.F5:
                    // Call Refresh and reload function

                    using (new HourGlass())
                    {
                        //RefreshAllDataAsync();
                        RefreshData();
                        this.RefreshData();
                    }
                    return true;
                case Keys.Control | Keys.S:
                    using (new HourGlass())
                    {
                        this.SaveClient();
                    }
                    return true;
                case Keys.Alt | Keys.U:
                    this.OpenFormMagement();
                    return true;
                case Keys.Alt | Keys.S:
                    new FormSearchClient().btnCustomSQLQuery_Click(this, null);
                    return true;
                case Keys.Alt | Keys.A:
                    this.ShowFormAddNewClient();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void FormClientInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Hide it instead.
                this.Hide();
                // Prevent the form from closing.
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }


    }
}
