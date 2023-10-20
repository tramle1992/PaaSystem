using Common.Infrastructure.ApiClient;
using Common.Infrastructure.UI;
using Core.Application.Command.ClientInfo;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.ClientInfo
{
    public partial class FormClientEditSpecialPrice : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ClientApiRepository clientApiRepository = new ClientApiRepository();
        private ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;

        private bool selectReportTypeAction = false;
        private ClientData currentClient = null;

        public event EventHandler<ClientData> OnEditSpecialPrices;

        public FormClientEditSpecialPrice(ClientData client)
        {
            InitializeComponent();
            SetCurrentClient(client);
        }

        private void FormClientEditSpecialPrice_LoadCompleted(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void LoadData()
        {
            if (this.currentClient != null && !string.IsNullOrEmpty(this.currentClient.ClientId))
            {
                this.Text = "Prices for: " + this.currentClient.ClientName;
            }
            else
            {
                this.Text = "Edit Special Price";
            }
            LoadListBoxReportTypes();
        }

        private void LoadListBoxReportTypes()
        {
            this.lstReportTypes.Items.Clear();
            List<ReportTypeData> reportTypeData = reportTypeCachedApiQuery.GetAllReportTypes();
            if (reportTypeData != null && reportTypeData.Count > 0)
            {
                foreach (ReportTypeData reportType in reportTypeData)
                {
                    this.lstReportTypes.Items.Add(reportType.TypeName);
                }
                this.lstReportTypes.SelectedIndex = 0;
            }
        }

        private void SetCurrentClient(ClientData client)
        {
            this.currentClient = client;
        }

        private void lstReportTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectReportTypeAction = true;
            List<ReportTypeData> reportTypeData = reportTypeCachedApiQuery.GetAllReportTypes();
            if (this.lstReportTypes.SelectedItems.Count > 0 &&
                reportTypeData != null && reportTypeData.Count > 0)
            {
                int reportTypeIndex = this.lstReportTypes.SelectedIndex;
                ReportTypeData reportType = reportTypeData[reportTypeIndex];
                if (reportType != null)
                {
                    lblReportTypeName.Text = reportType.TypeName;
                    nudSpecialPrice.Value = reportType.DefaultPrice;
                    ValidatePrice();
                    txtDefaultPrice.Text = reportType.DefaultPrice.ToString("F");
                    if (this.currentClient.ClientReportSpecialPrices != null && this.currentClient.ClientReportSpecialPrices.Count > 0)
                    {
                        foreach (ClientReportSpecialPriceData specialPrice in this.currentClient.ClientReportSpecialPrices)
                        {
                            if (reportType.ReportTypeId.Equals(specialPrice.ReportTypeId))
                            {
                                nudSpecialPrice.Value = specialPrice.SpecialPrice;
                                ValidatePrice();
                                break;
                            }
                        }
                    }
                }
            }
            selectReportTypeAction = false;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (this.currentClient == null || string.IsNullOrEmpty(this.currentClient.ClientId))
            {
                this.Close();
            }

            using (new HourGlass())
            {
                try
                {
                    clientApiRepository.Update(this.currentClient);
                    if (this.OnEditSpecialPrices != null)
                    {
                        this.OnEditSpecialPrices(this, this.currentClient);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _logger.Error(ex.ToString());
                }
            }
        }

        private void nudSpecialPrice_ValueChanged(object sender, EventArgs e)
        {
            if (selectReportTypeAction)
            {
                return;
            }

            int reportTypeIndex = this.lstReportTypes.SelectedIndex;
            List<ReportTypeData> reportTypeData = reportTypeCachedApiQuery.GetAllReportTypes();

            if (reportTypeIndex < 0 || reportTypeData == null || reportTypeData.Count == 0)
            {
                return;
            }

            ReportTypeData reportType = reportTypeData[reportTypeIndex];
            if (reportType != null)
            {
                bool found = false;
                bool updateAction = false;
                if (reportType.DefaultPrice != nudSpecialPrice.Value)
                {
                    updateAction = true;
                }

                if (this.currentClient.ClientReportSpecialPrices != null && this.currentClient.ClientReportSpecialPrices.Count > 0)
                {
                    List<ClientReportSpecialPriceData> specialPriceList = this.currentClient.ClientReportSpecialPrices.ToList();
                    for (int i = 0; i < specialPriceList.Count; i++)
                    {
                        if (reportType.ReportTypeId.Equals(specialPriceList[i].ReportTypeId))
                        {
                            if (updateAction)
                            {
                                specialPriceList[i].SpecialPrice = nudSpecialPrice.Value;
                            }
                            else
                            {
                                specialPriceList.RemoveAt(i);
                            }
                            this.currentClient.ClientReportSpecialPrices = new HashSet<ClientReportSpecialPriceData>(specialPriceList);
                            found = true;
                            break;
                        }
                    }
                }
                if (updateAction && !found)
                {
                    ClientReportSpecialPriceData specialPrice = new ClientReportSpecialPriceData();
                    specialPrice.ReportTypeId = reportType.ReportTypeId;
                    specialPrice.SpecialPrice = nudSpecialPrice.Value;
                    if (this.currentClient.ClientReportSpecialPrices == null)
                    {
                        this.currentClient.ClientReportSpecialPrices = new HashSet<ClientReportSpecialPriceData>();
                    }
                    this.currentClient.ClientReportSpecialPrices.Add(specialPrice);
                }
            }
        }

        private bool ValidatePrice()
        {
            string input = ((UpDownBase)nudSpecialPrice).Text;
            if (string.IsNullOrEmpty(input) ||
                !Regex.IsMatch(input, @"^[0-9]+([,.][0-9]{1,2})?$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                string error = "Invalid Price.";
                errpdSpecialPrice.SetError(nudSpecialPrice, error);
                btnDone.Enabled = false;
                return false;
            }
            else
            {
                errpdSpecialPrice.SetError(nudSpecialPrice, null);
                btnDone.Enabled = true;
                return true;
            }
        }

        private void nudSpecialPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char dot = Convert.ToChar(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != dot && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void nudSpecialPrice_KeyUp(object sender, KeyEventArgs e)
        {
            ValidatePrice();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    return true;
                case Keys.Alt | Keys.D:
                    this.btnDone_Click(this, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
