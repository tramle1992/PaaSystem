using BrightIdeasSoftware;
using Common.Application.DialogMessage;
using Common.Infrastructure.ApiClient;
using Common.Infrastructure.ComboBoxCustom;
using Common.Infrastructure.OLV;
using Common.Infrastructure.UI;
using Core.Application.Command.ClientInfo;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using Newtonsoft.Json;
using System;
using System.Collections;
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

namespace PaaApplication.Forms.Adminstration
{
    public partial class FormReportsManagement : BaseForm
    {
        public class ClientPriceData
        {
            public string ClientId { get; set; }
            public string ClientName { get; set; }
            public string ReportTypeId { get; set; }
            public decimal SpecialPrice { get; set; }

            public ClientPriceData()
            {
            }

            public ClientPriceData(string clientId, string clientName, string reportTypeId, decimal specialPrice)
            {
                this.ClientId = clientId;
                this.ClientName = clientName;
                this.ReportTypeId = reportTypeId;
                this.SpecialPrice = specialPrice;
            }
        }

        enum Mode
        {
            Edit,
            AddNew
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ReportTypeApiRepository reportTypeApiRepository = new ReportTypeApiRepository();
        private ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
        private ClientApiRepository clientApiRepository = new ClientApiRepository();
        private ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;

        private Mode reportTypesMode = Mode.Edit;
        private OLVColumnFormat olvFormat = new OLVColumnFormat();
        private bool loadCompleted = false;

        private FormMaster formMaster;

        private string[] absoluteTypeData = new string[] { "Commercial", "Credit", "Credit/Criminal", "Criminal", "Employment", "Residential" };

        public FormReportsManagement(FormMaster formMaster)
        {
            InitializeComponent();
            this.formMaster = formMaster;
        }

        private void ReportsManagement_LoadCompleted(object sender, EventArgs e)
        {
            InitOLV();
            LoadData(true, false);
            this.loadCompleted = true;
        }

        private void InitOLV()
        {
            this.olvcolBtnDeleteReportType.ImageGetter = delegate(object row)
            {
                return 0;
            };

            this.olvcolFullApp.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    string type = ((ReportTypeData)row).AbsoluteTypeName;
                    if (!string.IsNullOrEmpty(type) &&
                        (type.Equals("Commercial") || type.Equals("Employment") || type.Equals("Residential")))
                    {
                        return true;
                    }
                }
                return false;
            };
        }

        public void LoadData(bool firstLoad, bool clearAllCaches)
        {
            try
            {
                using (new HourGlass())
                {
                    if (clearAllCaches)
                    {
                        reportTypeCachedApiQuery.RemoveAllReportTypes();
                        clientCachedApiQuery.RemoveAllClients();
                    }

                    List<ReportTypeData> reportTypeData = reportTypeCachedApiQuery.GetAllReportTypes();
                    if (reportTypeData != null && reportTypeData.Count > 0)
                    {
                        ReportTypeData selectedItem = null;
                        if (!firstLoad)
                        {
                            selectedItem = (ReportTypeData)this.olvReportTypes.SelectedObject;
                        }
                        LoadOLVReportTypes(reportTypeData, selectedItem);
                    }
                    else
                    {
                        this.olvReportTypes.ClearObjects();
                    }
                    //LoadDefaultOLVClients(clientData, "0", decimal.Parse("0"));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void LoadOLVReportTypes(List<ReportTypeData> reportTypeList, ReportTypeData selectedItem)
        {
            if (reportTypeList == null || reportTypeList.Count == 0)
            {
                this.olvReportTypes.ClearObjects();
                return;
            }

            this.olvFormat.FormatPriceString(this.olvcolDefaultPrice);
            this.olvReportTypes.SetObjects(reportTypeList);
            this.olvReportTypes.BuildList();

            if (selectedItem == null || string.IsNullOrEmpty(selectedItem.ReportTypeId))
            {
                this.olvReportTypes.SelectedIndex = 0;
                this.olvReportTypes.EnsureVisible(0);
            }
            else
            {
                for (int i = 0; i < this.olvReportTypes.Items.Count; i++)
                {
                    ReportTypeData item = (ReportTypeData)this.olvReportTypes.GetModelObject(i);
                    if (item != null && !string.IsNullOrEmpty(item.ReportTypeId) &&
                        item.ReportTypeId.Equals(selectedItem.ReportTypeId))
                    {
                        this.olvReportTypes.SelectedIndex = i;
                        this.olvReportTypes.EnsureVisible(i);
                        break;
                    }
                }
            }
        }

        #region olvReportTypes
        private void olvReportTypes_SelectionChanged(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                this.olvClients.SelectedIndex = -1;

                ReportTypeData reportType = (ReportTypeData)this.olvReportTypes.SelectedObject;

                if (reportType != null)
                {
                    ChangeCheckBoxEdit(reportType.TypeName);
                    ReloadOLVClientsByReportType(reportType);
                }
                else
                {
                    ChangeCheckBoxEdit(string.Empty);
                }
            }
        }

        private void olvReportTypes_CellEditStarting(object sender, CellEditEventArgs e)
        {
            ReportTypeData reportType = (ReportTypeData)e.RowObject;
            if (reportType == null)
            {
                e.Cancel = true;
                return;
            }

            if (e.Column == this.olvcolDefaultPrice)
            {
                NumericUpDown nudControl = new NumericUpDown();
                nudControl.Bounds = e.CellBounds;
                nudControl.Minimum = 0;
                nudControl.Maximum = 100;
                nudControl.DecimalPlaces = 2;
                nudControl.Increment = decimal.Parse("0.5");
                nudControl.Value = decimal.Parse(e.Value.ToString());
                e.Control = nudControl;
            }
            else if (e.Column == this.olvcolAbsoluteTypeName)
            {
                ComboBox cboControl = new ComboBox();
                cboControl.Bounds = e.CellBounds;
                cboControl.DropDownStyle = ComboBoxStyle.DropDownList;
                cboControl.Items.AddRange(absoluteTypeData);
                int index = Array.IndexOf(absoluteTypeData, e.Value);
                cboControl.SelectedIndex = index > 0 ? index : 0;
                e.Control = cboControl;
            }
        }

        private void olvReportTypes_CellEditValidating(object sender, CellEditEventArgs e)
        {
            if (this.reportTypesMode == Mode.AddNew)
            {
                ReportTypeData reportType = (ReportTypeData)e.RowObject;
                if (reportType == null)
                {
                    e.Cancel = true;
                    return;
                }

                string value;

                List<ReportTypeData> reportTypeData = reportTypeCachedApiQuery.GetAllReportTypes();
                if (e.Column == this.olvcolTypeName)
                {
                    value = e.NewValue.ToString();
                    if (string.IsNullOrEmpty(value))
                    {
                        MessageBox.Show("Report Name cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (value.Length > 50)
                    {
                        MessageBox.Show("Report Name cannot be longer than 50 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (GetReportTypeIndexByName(reportTypeData, value) >= 0)
                    {
                        MessageBox.Show("Report Name already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        reportType.TypeName = value;
                        reportType.DefaultPrice = decimal.Parse("0");
                        reportType.AbsoluteTypeName = absoluteTypeData[0];
                    }
                }

                using (new HourGlass())
                {
                    string reportTypeId = reportTypeApiRepository.Add(reportType);
                    if (!string.IsNullOrEmpty(reportTypeId))
                    {
                        reportType.ReportTypeId = reportTypeId;
                        AddReportTypeCompleted(reportType);
                    }
                }
            }
            else if (this.reportTypesMode == Mode.Edit)
            {
                ReportTypeData reportType = (ReportTypeData)e.RowObject;
                if (reportType == null)
                {
                    e.Cancel = true;
                    return;
                }

                string oldValue;
                string newValue;
                bool update = false;

                List<ReportTypeData> reportTypeData = reportTypeCachedApiQuery.GetAllReportTypes();
                if (e.Column == this.olvcolTypeName)
                {
                    oldValue = e.Value.ToString();
                    newValue = e.NewValue.ToString();
                    if (string.IsNullOrEmpty(newValue))
                    {
                        MessageBox.Show("Report Name cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (newValue.Length > 50)
                    {
                        MessageBox.Show("Report Name cannot be longer than 50 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (!oldValue.Equals(newValue))
                    {
                        if (GetReportTypeIndexByName(reportTypeData, newValue) >= 0)
                        {
                            MessageBox.Show("Report Name already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            reportType.TypeName = newValue;
                            update = true;
                        }
                    }
                }
                else if (e.Column == this.olvcolDefaultPrice)
                {
                    oldValue = e.Value.ToString();
                    newValue = e.NewValue.ToString();
                    if (!oldValue.Equals(newValue))
                    {
                        reportType.DefaultPrice = ((NumericUpDown)e.Control).Value;
                        update = true;
                    }
                }
                else if (e.Column == this.olvcolAbsoluteTypeName)
                {
                    oldValue = e.Value.ToString();
                    newValue = ((ComboBox)e.Control).SelectedItem.ToString();
                    if (!oldValue.Equals(newValue))
                    {
                        reportType.AbsoluteTypeName = newValue;
                        update = true;
                    }
                }

                if (update)
                {
                    using (new HourGlass())
                    {
                        reportTypeApiRepository.Update(reportType);
                        UpdateReportTypeCompleted(reportType);
                    }
                }
            }

            this.reportTypesMode = Mode.Edit;
        }

        private void olvReportTypes_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            ReportTypeData reportType = (ReportTypeData)e.RowObject;
            if (reportType == null)
            {
                this.reportTypesMode = Mode.Edit;
                return;
            }

            if (e.Cancel && this.reportTypesMode == Mode.AddNew)
            {
                this.olvReportTypes.RemoveObject(reportType);
                if (this.olvReportTypes.Items.Count > 0)
                {
                    this.olvReportTypes.SelectedIndex = 0;
                    this.olvReportTypes.EnsureVisible(0);
                }
            }
            else if (!e.Cancel)
            {
                if (e.Column == this.olvcolTypeName)
                {
                    reportType.TypeName = e.NewValue.ToString();
                    ChangeCheckBoxEdit(reportType.TypeName);
                }
                else if (e.Column == this.olvcolDefaultPrice)
                {
                    reportType.DefaultPrice = ((NumericUpDown)e.Control).Value;
                }
                else if (e.Column == this.olvcolAbsoluteTypeName)
                {
                    reportType.AbsoluteTypeName = ((ComboBox)e.Control).SelectedItem.ToString();
                }

                this.olvReportTypes.RefreshObject(reportType);
                e.Cancel = true;
            }

            this.reportTypesMode = Mode.Edit;
        }

        private void olvReportTypes_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == this.olvcolBtnDeleteReportType)
            {
                ReportTypeData reportType = (ReportTypeData)this.olvReportTypes.SelectedObject;
                if (reportType == null)
                {
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete \"" + reportType.TypeName + "\" type?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    using (new HourGlass())
                    {
                        reportTypeApiRepository.Remove(reportType);
                        RemoveReportTypeCompleted(reportType);
                    }
                }
            }
        }
        #endregion

        #region ReportTypes functions
        private int GetReportTypeIndexByName(List<ReportTypeData> reportTypeList, string reportTypeName)
        {
            if (reportTypeList == null || reportTypeList.Count == 0 || string.IsNullOrEmpty(reportTypeName))
            {
                return -1;
            }

            return reportTypeList.FindIndex(
                delegate(ReportTypeData reportType)
                {
                    return reportType.TypeName.Equals(reportTypeName);
                });
        }

        private int GetReportTypeIndexById(List<ReportTypeData> reportTypeList, string reportTypeId)
        {
            if (reportTypeList == null || reportTypeList.Count == 0 || string.IsNullOrEmpty(reportTypeId))
            {
                return -1;
            }

            return reportTypeList.FindIndex(
                delegate(ReportTypeData reportType)
                {
                    return reportType.ReportTypeId.Equals(reportTypeId);
                });
        }

        private void AddReportTypeCompleted(ReportTypeData reportType)
        {
            if (reportType == null || string.IsNullOrEmpty(reportType.ReportTypeId))
            {
                return;
            }

            // remove cache & get new
            reportTypeCachedApiQuery.RemoveAllReportTypes();
            List<ReportTypeData> reportTypeData = reportTypeCachedApiQuery.GetAllReportTypes();

            // reload OLVReportTypes
            LoadOLVReportTypes(reportTypeData, reportType);
        }

        private void UpdateReportTypeCompleted(ReportTypeData reportType)
        {
            if (reportType == null || string.IsNullOrEmpty(reportType.ReportTypeId))
            {
                return;
            }

            // remove cache & get new
            reportTypeCachedApiQuery.RemoveAllReportTypes();
            List<ReportTypeData> reportTypeData = reportTypeCachedApiQuery.GetAllReportTypes();

            // reload OLVReportTypes
            LoadOLVReportTypes(reportTypeData, reportType);
        }

        private void RemoveReportTypeCompleted(ReportTypeData reportType)
        {
            if (reportType == null || string.IsNullOrEmpty(reportType.ReportTypeId))
            {
                return;
            }

            // remove cache & get new
            reportTypeCachedApiQuery.RemoveAllReportTypes();
            List<ReportTypeData> reportTypeData = reportTypeCachedApiQuery.GetAllReportTypes();

            // reload OLVReportTypes
            LoadOLVReportTypes(reportTypeData, null);

            List<ClientData> clientData = clientCachedApiQuery.GetAllClients();
            if (clientData != null && clientData.Count > 0)
            {
                List<ClientData> clientChangedList = UpdateClientsByRemoveSpecialPrice(clientData, reportType.ReportTypeId);
                if (clientChangedList != null)
                {
                    clientApiRepository.UpdateMulti(clientChangedList);
                    UpdateClientCompleted();
                }
            }
        }
        #endregion

        #region olvClients
        private void olvClients_CellEditStarting(object sender, CellEditEventArgs e)
        {
            ClientPriceData clientPrice = (ClientPriceData)e.RowObject;
            if (clientPrice == null)
            {
                e.Cancel = true;
                return;
            }

            if (e.Column == this.olvcolSpecialPrice)
            {
                NumericUpDown nudControl = new NumericUpDown();
                nudControl.Bounds = e.CellBounds;
                nudControl.Minimum = 0;
                nudControl.Maximum = 100;
                nudControl.DecimalPlaces = 2;
                nudControl.Increment = decimal.Parse("0.5");
                nudControl.Value = decimal.Parse(e.Value.ToString());
                e.Control = nudControl;
            }
        }

        private void olvClients_CellEditValidating(object sender, CellEditEventArgs e)
        {
            ClientPriceData clientPrice = (ClientPriceData)e.RowObject;
            if (clientPrice == null)
            {
                e.Cancel = true;
                return;
            }

            bool update = false;

            if (e.Column == this.olvcolSpecialPrice)
            {
                if (clientPrice.SpecialPrice != ((NumericUpDown)e.Control).Value)
                {
                    clientPrice.SpecialPrice = ((NumericUpDown)e.Control).Value;
                    update = true;
                }
            }

            if (update)
            {
                using (new HourGlass())
                {
                    List<ClientData> clientData = clientCachedApiQuery.GetAllClients();
                    if (clientData != null && clientData.Count > 0)
                    {
                        ClientData clientChanged = UpdateClientByChangeSpecialPrice(clientData, clientPrice);
                        if (clientChanged != null)
                        {
                            clientApiRepository.Update(clientChanged);
                            UpdateClientCompleted();
                        }
                    }
                }
            }
        }

        private void olvClients_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            ClientPriceData clientPrice = (ClientPriceData)e.RowObject;
            if (clientPrice == null)
            {
                return;
            }

            if (!e.Cancel)
            {
                if (e.Column == this.olvcolSpecialPrice)
                {
                    clientPrice.SpecialPrice = ((NumericUpDown)e.Control).Value;
                }

                this.olvClients.RefreshObject(clientPrice);
                e.Cancel = true;
            }
        }

        private void olvClients_CellClick(object sender, CellClickEventArgs e)
        {
        }

        private void UpdateClientCompleted()
        {
            // remove cache
            clientCachedApiQuery.RemoveAllClients();
        }
        #endregion

        #region Clients function
        private void LoadDefaultOLVClients(List<ClientData> clientList, string reportTypeId, decimal defaultPrice)
        {
            if (clientList == null || clientList.Count == 0 ||
                string.IsNullOrEmpty(reportTypeId) || defaultPrice < 0)
            {
                return;
            }

            List<ClientPriceData> clientPriceData = new List<ClientPriceData>(clientList.Count);
            foreach (ClientData client in clientList)
            {
                clientPriceData.Add(new ClientPriceData(client.ClientId, client.ClientName, reportTypeId, defaultPrice));
            }

            this.olvFormat.FormatPriceString(this.olvcolSpecialPrice);
            this.olvClients.SetObjects(clientPriceData);
            this.olvClients.BuildList();
        }

        private void ReloadOLVClientsByReportType(ReportTypeData reportType)
        {
            if (reportType == null || string.IsNullOrEmpty(reportType.ReportTypeId) || reportType.DefaultPrice < 0)
            {
                return;
            }

            List<ClientData> clientData = clientCachedApiQuery.GetAllClients();
            if (clientData == null || clientData.Count == 0)
            {
                return;
            }

            List<ClientPriceData> clientPriceData = new List<ClientPriceData>(clientData.Count);
            foreach (ClientData client in clientData)
            {
                if (client.ClientReportSpecialPrices.Count > 0)
                {
                    ClientReportSpecialPriceData specialPrice =
                        client.ClientReportSpecialPrices.FirstOrDefault(
                            item => item.ReportTypeId.Equals(reportType.ReportTypeId)
                        );

                    if (specialPrice != null)
                    {
                        clientPriceData.Add(new ClientPriceData(client.ClientId, client.ClientName, specialPrice.ReportTypeId, specialPrice.SpecialPrice));
                        continue;
                    }
                }
                clientPriceData.Add(new ClientPriceData(client.ClientId, client.ClientName, reportType.ReportTypeId, reportType.DefaultPrice));
            }

            this.olvFormat.FormatPriceString(this.olvcolSpecialPrice);
            this.olvClients.SetObjects(clientPriceData);
            this.olvClients.BuildList();
        }

        private void ChangeCheckBoxEdit(string typeName)
        {
            if (!string.IsNullOrEmpty(typeName))
            {
                chkEdit.Enabled = true;
                this.olvClients.Enabled = true;
                chkEdit.Text = "EDIT '" + typeName.ToUpper() + "' SPECIAL PRICE FOR CLIENT(S):";
            }
            else
            {
                chkEdit.Enabled = false;
                this.olvClients.Enabled = false;
                chkEdit.Text = "EDIT SPECIAL PRICE FOR CLIENT(S):";
            }
        }

        private int GetClientIndexById(List<ClientData> clientList, string clientId)
        {
            if (clientList == null || clientList.Count == 0 || string.IsNullOrEmpty(clientId))
            {
                return -1;
            }

            return clientList.FindIndex(
                delegate(ClientData client)
                {
                    return client.ClientId.Equals(clientId);
                });
        }

        private ClientData UpdateClientByChangeSpecialPrice(List<ClientData> clientList, ClientPriceData clientPrice)
        {
            if (clientList == null || clientList.Count == 0 ||
                clientPrice == null || string.IsNullOrEmpty(clientPrice.ClientId))
            {
                return null;
            }

            ReportTypeData reportType = (ReportTypeData)this.olvReportTypes.SelectedObject;
            if (reportType == null)
            {
                return null;
            }

            int clientIndex = GetClientIndexById(clientList, clientPrice.ClientId);
            if (clientIndex < 0)
            {
                return null;
            }

            decimal defaultPrice = reportType.DefaultPrice;
            ClientData clientChanged = clientList[clientIndex];
            ClientReportSpecialPriceData specialPrice = clientChanged.ClientReportSpecialPrices.FirstOrDefault(
                        item => item.ReportTypeId.Equals(clientPrice.ReportTypeId)
                    );

            if (specialPrice != null)
            {
                if (defaultPrice != clientPrice.SpecialPrice)
                {
                    specialPrice.SpecialPrice = clientPrice.SpecialPrice;
                }
                else
                {
                    clientChanged.ClientReportSpecialPrices.Remove(specialPrice);
                }
            }
            else if (defaultPrice != clientPrice.SpecialPrice)
            {
                ClientReportSpecialPriceData item =
                    new ClientReportSpecialPriceData(clientPrice.ReportTypeId, clientPrice.SpecialPrice);
                clientChanged.ClientReportSpecialPrices.Add(item);
            }

            return clientChanged;
        }

        private List<ClientData> UpdateClientsByRemoveSpecialPrice(List<ClientData> clientList, string reportTypeId)
        {
            if (clientList == null || clientList.Count == 0 || string.IsNullOrEmpty(reportTypeId))
            {
                return null;
            }

            List<ClientData> clientChangedList = new List<ClientData>();

            for (int i = 0; i < clientList.Count; i++)
            {
                ClientReportSpecialPriceData specialPrice =
                        clientList[i].ClientReportSpecialPrices.FirstOrDefault(
                            item => item.ReportTypeId.Equals(reportTypeId)
                        );
                if (specialPrice != null)
                {
                    clientList[i].ClientReportSpecialPrices.Remove(specialPrice);
                    clientChangedList.Add(clientList[i]);
                }
            }

            if (clientChangedList.Count > 0)
            {
                return clientChangedList;
            }
            return null;
        }
        #endregion

        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEdit.Checked)
            {
                this.olvClients.Enabled = true;
                this.olvClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            }
            else
            {
                this.olvClients.Enabled = false;
                this.olvClients.ForeColor = System.Drawing.Color.Silver;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.reportTypesMode = Mode.AddNew;
            ReportTypeData reportType = new ReportTypeData();
            this.olvReportTypes.AddObject(reportType);
            this.olvReportTypes.SelectObject(reportType, true);
            this.olvReportTypes.EnsureModelVisible(reportType);
            this.olvReportTypes.EditModel(reportType);
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string strSearch = txtSearch.Text.Trim();
            bool filter = false;

            if (e.KeyCode == Keys.Back && strSearch.Length == 0)
            {
                strSearch = string.Empty;
                new ObjectListViewService().FilterOlv(this.olvReportTypes, strSearch);
                filter = true;
            }
            else if (e.KeyCode == Keys.Enter && strSearch.Length > 0)
            {
                new ObjectListViewService().FilterOlv(this.olvReportTypes, strSearch);
                filter = true;
            }

            if (filter)
            {
                if (this.olvReportTypes.Items.Count > 0)
                {
                    this.olvReportTypes.SelectedIndex = 0;
                    this.olvReportTypes.EnsureVisible(0);
                }
                else
                {
                    ChangeCheckBoxEdit(string.Empty);
                }
            }
        }

        private void FormReportsManagement_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && this.loadCompleted)
            {
                LoadData(false, false);
            }
        }

    }
}
