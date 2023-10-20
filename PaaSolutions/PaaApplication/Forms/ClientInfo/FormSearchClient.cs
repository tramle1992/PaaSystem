using Common.Application;
using Common.Infrastructure.ApiClient;
using Common.Infrastructure.ComboBoxCustom;
using Common.Infrastructure.UI;
using Core.Application.Common.ClientInfo;
using Core.Application.Data.ClientInfo;
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

namespace PaaApplication.Forms.ClientInfo
{
    public partial class FormSearchClient : BaseForm
    {
        enum SearchType
        {
            SpecialBilling,
            LastScreening,
            Custom
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private FormSearchClientCustomSQL formSearchClientCustom;
        private SearchType searchType = SearchType.SpecialBilling;

        private List<string> typeNameData = null;
        private List<ClientDisplayInfoData> clientNameData = null;
        private List<string> customerNumberData = null;
        private List<string> invoiceDivisionData = null;
        private List<ManagementCompanyData> managementCompanyData = null;

        public List<ClientData> ClientData { get; set; }

        private HttpClient httpClient;

        public event EventHandler<List<string>> OnSearchClient;

        public FormSearchClient()
        {
            InitializeComponent();
            InitializeSettings();
        }

        private void FormSearchClient_LoadCompleted(object sender, EventArgs e)
        {

        }

        public void InitializeSettings()
        {
            try
            {
                using (new HourGlass())
                {
                    string baseAddress = ConfigurationManager.AppSettings["ApiUri"];
                    httpClient = ApiClientFactory.GetHttpClient(baseAddress);

                    LoadComboboxSearchIn();
                    txtSearchFor.BringToFront();
                    rdoCustom.Select();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        #region Search Type Radio events
        private void rdoSpecialBilling_CheckedChanged(object sender, EventArgs e)
        {
            searchType = SearchType.SpecialBilling;

            SetStatusSpecialBillingControls(true);
            SetStatusLastScreeningControls(false);
            SetStatusCustomControls(false);
        }

        private void rdoLastScreening_CheckedChanged(object sender, EventArgs e)
        {
            searchType = SearchType.LastScreening;

            SetStatusSpecialBillingControls(false);
            SetStatusLastScreeningControls(true);
            SetStatusCustomControls(false);
        }

        private void rdoCustom_CheckedChanged(object sender, EventArgs e)
        {
            searchType = SearchType.Custom;

            SetStatusSpecialBillingControls(false);
            SetStatusLastScreeningControls(false);
            SetStatusCustomControls(true);
        }
        #endregion

        #region Button events
        public void btnCustomSQLQuery_Click(object sender, EventArgs e)
        {
            if (formSearchClientCustom == null)
            {
                formSearchClientCustom = new FormSearchClientCustomSQL();
                formSearchClientCustom.OnClickSearchButton += new EventHandler<List<string>>(SearchClientCustomHandler);
                formSearchClientCustom.OnClickCancelButton += new EventHandler(delegate(object delegateSender, EventArgs delegateE)
                {
                    this.Hide();
                });
            }
            formSearchClientCustom.ClientData = this.ClientData;
            formSearchClientCustom.StartPosition = FormStartPosition.CenterParent;
            formSearchClientCustom.BringToFront();
            formSearchClientCustom.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> data;

            try
            {
                using (new HourGlass())
                {
                    switch (searchType)
                    {
                        case SearchType.SpecialBilling:
                            if (!chkSpecialBilling1.Checked && !chkSpecialBilling2.Checked
                                && !chkSpecialBilling3.Checked && !chkSpecialBilling4.Checked)
                            {
                                MessageBox.Show("You must check one or more items to search for.", "No Items Checked!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            data = SearchTypeSpecialBillingHandler();
                            break;
                        case SearchType.LastScreening:
                            data = SearchTypeLastScreeningHandler();
                            break;
                        case SearchType.Custom:
                            data = SearchTypeCustomHandler();
                            break;
                        default:
                            data = null;
                            break;
                    }
                    if (this.OnSearchClient != null)
                    {
                        this.OnSearchClient(this, data);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        private List<string> SearchTypeSpecialBillingHandler()
        {
            string sqlOperator = " AND ";
            bool statementAdded = false;
            List<ReportTypeData> reportTypeData = null;
            StringBuilder sqlConditions = new StringBuilder();

            if (rdoSpecialBillingAny.Checked)
            {
                sqlOperator = " OR ";
            }

            if (chkSpecialBilling1.Checked)
            {
                sqlConditions.Append("InvoiceDivisions <> \"\"");
                sqlConditions.Append(sqlOperator);
                statementAdded = true;
            }
            if (chkSpecialBilling2.Checked)
            {
                // TODO: Invoice Line
                // InvoiceLine <> '' AND InvoiceLine <> 'Recommendation'
            }
            if (chkSpecialBilling3.Checked && !chkSpecialBilling4.Checked)
            {
                sqlConditions.Append("ReportTypeName = \"Roommate\" OR ReportTypeName = \"Cosigner\"");
                sqlConditions.Append(sqlOperator);
                statementAdded = true;
                reportTypeData = GetAllReportType();
            }
            if (chkSpecialBilling4.Checked)
            {
                sqlConditions.Append("SpecialPrices IS NOT NULL");
                sqlConditions.Append(sqlOperator);
                statementAdded = true;
            }

            if (statementAdded)
            {
                sqlConditions.Remove(sqlConditions.Length - sqlOperator.Length, sqlOperator.Length);
            }

            return GetClientData.SearchClientSpecialBilling(this.ClientData, sqlConditions.ToString(), reportTypeData);
        }

        private List<ReportTypeData> GetAllReportType()
        {
            List<ReportTypeData> lst = new List<ReportTypeData>();
            try
            {
                string url = string.Format("api/reporttypes");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    lst = JsonConvert.DeserializeObject<List<ReportTypeData>>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return lst;
        }

        private List<string> SearchTypeLastScreeningHandler()
        {
            // TODO: SearchTypeLastScreeningHandler
            // SELECT * FROM Clients WHERE EXISTS (SELECT * FROM Applications WHERE ReceiveDate BETWEEN #" & DTDate(0).Value & "# AND #" & DTDate(1).Value + 1 & "# AND ClientApplied = Clients.ClientName)
            return null;
        }

        private List<string> SearchTypeCustomHandler()
        {
            string value = txtSearchFor.Text.Trim();
            if (string.IsNullOrEmpty(value))
            {
                return (from client in this.ClientData
                        select client.ClientId).ToList<string>();
            }
            else
            {
                string sqlConditions;
                string typeName = cboSearchIn.Text.Trim();
                string columnName = SearchClientCustom.GetColumnNameByTypeName(typeName);

                if (columnName.Equals(Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.AllFields)))
                {
                    sqlConditions = GetSqlConditionsInAnyFields(value);
                }
                else if (columnName.Equals(Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.DefaultDeliveries)))
                {
                    sqlConditions = GetSqlConditionsInDefaultDeliveriesField(value);
                }
                else
                {
                    sqlConditions = columnName + " like \"%" + value + "%\"";
                }

                return GetClientData.SearchClientCustom(this.ClientData, sqlConditions);
            }
        }

        private string GetSqlConditionsInDefaultDeliveriesField(string value)
        {
            StringBuilder sqlConditions = new StringBuilder();

            sqlConditions.Append(Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.DefaultConfDelivery));
            sqlConditions.Append(" like \"%");
            sqlConditions.Append(value);
            sqlConditions.Append("%\" OR ");
            sqlConditions.Append(Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.DefaultInvDelivery));
            sqlConditions.Append(" like \"%");
            sqlConditions.Append(value);
            sqlConditions.Append("%\" OR ");
            sqlConditions.Append(Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.DefaultReportDelivery));
            sqlConditions.Append(" like \"%");
            sqlConditions.Append(value);
            sqlConditions.Append("%\"");

            return sqlConditions.ToString();
        }

        private string GetSqlConditionsInAnyFields(string value)
        {
            string sqlOperator = " OR ";
            bool statementAdded = false;
            StringBuilder sqlConditions = new StringBuilder();

            foreach (string columnName in SearchClientCustom.GetAllColumns())
            {
                if (columnName.Equals(Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.AllFields)))
                {
                    continue;
                }
                else if (columnName.Equals(Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.DefaultDeliveries)))
                {
                    sqlConditions.Append(GetSqlConditionsInDefaultDeliveriesField(value));
                    sqlConditions.Append(sqlOperator);
                    statementAdded = true;
                }
                else
                {
                    sqlConditions.Append(columnName);
                    sqlConditions.Append(" like \"%");
                    sqlConditions.Append(value);
                    sqlConditions.Append("%\"");
                    sqlConditions.Append(sqlOperator);
                    statementAdded = true;
                }
            }
            if (statementAdded)
            {
                sqlConditions.Remove(sqlConditions.Length - sqlOperator.Length, sqlOperator.Length);
            }

            return sqlConditions.ToString();
        }

        private void SearchClientCustomHandler(object sender, List<string> data)
        {
            if (this.OnSearchClient != null)
            {
                this.OnSearchClient(this, data);
            }
        }

        #region Validate Last Screening
        private void dtmLastScreeningFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtmLastScreeningFrom.Value > dtmLastScreeningTo.Value)
            {
                dtmLastScreeningTo.Value = dtmLastScreeningFrom.Value;
            }
        }

        private void dtmLastScreeningTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtmLastScreeningTo.Value < dtmLastScreeningFrom.Value)
            {
                dtmLastScreeningFrom.Value = dtmLastScreeningTo.Value;
            }
        }
        #endregion

        private void LoadComboboxSearchIn()
        {
            try
            {
                if (typeNameData == null)
                {
                    typeNameData = SearchClientCustom.GetAllTypes();
                }
                cboSearchIn.Items.Clear();
                foreach (string item in typeNameData)
                {
                    cboSearchIn.Items.Add(item);
                }
                if (cboSearchIn.Items.Count > 0)
                {
                    cboSearchIn.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void LoadClientNameData()
        {
            try
            {
                if (clientNameData == null)
                {
                    string url = "api/displayinfo/clients";
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        clientNameData = JsonConvert.DeserializeObject<List<ClientDisplayInfoData>>(jsonContent);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void LoadCustomerNumberData()
        {
            try
            {
                if (customerNumberData == null)
                {
                    string url = "api/displayinfo/customernumber";
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        customerNumberData = new List<string>();
                        customerNumberData = JsonConvert.DeserializeObject<List<string>>(jsonContent);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void LoadInvoiceDivisionData()
        {
            try
            {
                if (invoiceDivisionData == null)
                {
                    string url = "api/displayinfo/invoicedivision";
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        invoiceDivisionData = new List<string>();
                        invoiceDivisionData = JsonConvert.DeserializeObject<List<string>>(jsonContent);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void LoadManagementCompanyData()
        {
            try
            {
                if (managementCompanyData == null)
                {
                    string url = "api/mgtcompany/clients";
                    HttpResponseMessage response = httpClient.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        managementCompanyData = new List<ManagementCompanyData>();
                        managementCompanyData = JsonConvert.DeserializeObject<List<ManagementCompanyData>>(jsonContent);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void SetStatusSpecialBillingControls(bool status)
        {
            lblClientsThatMeet.Enabled = status;
            rdoSpecialBillingAny.Enabled = status;
            rdoSpecialBillingAll.Enabled = status;
            lblOfTheseCriteria.Enabled = status;
            chkSpecialBilling1.Enabled = status;
            //chkSpecialBilling2.Enabled = status;
            chkSpecialBilling3.Enabled = status;
            chkSpecialBilling4.Enabled = status;
        }

        private void SetStatusLastScreeningControls(bool status)
        {
            lblBetween.Enabled = status;
            dtmLastScreeningFrom.Enabled = status;
            lblAnd.Enabled = status;
            dtmLastScreeningTo.Enabled = status;
        }

        private void SetStatusCustomControls(bool status)
        {
            lblSearchFor.Enabled = status;
            txtSearchFor.Enabled = status;
            cboSearchFor.Enabled = status;
            lblSearchIn.Enabled = status;
            cboSearchIn.Enabled = status;
            btnCustomSQLQuery.Enabled = status;
        }

        private void cboSearchIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboSearchIn.SelectedIndex)
                {
                    case (int)SearchClientCustomType.ClientName:
                        using (new HourGlass())
                        {
                            LoadClientNameData();

                            cboSearchFor.Items.Clear();
                            cboSearchFor.ValueMember = "ClientId";
                            cboSearchFor.DisplayMember = "ClientName";
                            foreach (ClientDisplayInfoData item in clientNameData)
                            {
                                cboSearchFor.Items.Add(item);
                            }
                            cboSearchFor.BringToFront();
                        }
                        break;
                    case (int)SearchClientCustomType.CustomerNumber:
                        using (new HourGlass())
                        {
                            LoadCustomerNumberData();

                            cboSearchFor.Items.Clear();
                            foreach (string item in customerNumberData)
                            {
                                cboSearchFor.Items.Add(item);
                            }
                            cboSearchFor.BringToFront();
                        }
                        break;
                    case (int)SearchClientCustomType.InvoiceDivisions:
                        using (new HourGlass())
                        {
                            LoadInvoiceDivisionData();

                            cboSearchFor.Items.Clear();
                            foreach (string item in invoiceDivisionData)
                            {
                                cboSearchFor.Items.Add(item);
                            }
                            cboSearchFor.BringToFront();
                        }
                        break;
                    case (int)SearchClientCustomType.Management:
                        using (new HourGlass())
                        {
                            LoadManagementCompanyData();

                            cboSearchFor.Items.Clear();
                            cboSearchFor.ValueMember = "ManagementCompanyId";
                            cboSearchFor.DisplayMember = "Name";
                            foreach (ManagementCompanyData item in managementCompanyData)
                            {
                                cboSearchFor.Items.Add(item);
                            }
                            cboSearchFor.BringToFront();
                        }
                        break;
                    default:
                        txtSearchFor.BringToFront();
                        break;
                }
                cboSearchFor.Text = txtSearchFor.Text;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void cboSearchFor_TextChanged(object sender, EventArgs e)
        {
            txtSearchFor.Text = (sender as ComboBox).Text;
        }

        private void cboSearchIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboSearchFor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(this.cboSearchFor, e, false);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.S:
                    this.btnCustomSQLQuery_Click(this, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
