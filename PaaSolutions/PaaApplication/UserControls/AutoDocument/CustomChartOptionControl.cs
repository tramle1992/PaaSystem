using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoDocument.Application.Data;
using PaaApplication.Models.AutoDocument;
using Common.Infrastructure.ApiClient;
using System.Net.Http;
using Newtonsoft.Json;
using Core.Application.Data.ClientInfo;
using System.Configuration;
using NodaTime;

namespace PaaApplication.UserControls.AutoDocument
{
    public partial class CustomChartOptionControl : UserControl
    {

        public CustomChartOptionControl()
        {
            InitializeComponent();
            radioPieChart.Select();
            radioApplications.Select();
        }

        public event EventHandler<MakeChartEventArgs> OnMakeChart;

        public void InitializeSettings()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUri"];
            httpClient = ApiClientFactory.GetHttpClient(baseAddress);

            ChartType chartType = this.CurrentChartType();
            ChartFrom chartFrom = this.CurrentChartFrom();

            resetChartDate();
            
            LoadListBoxSubTypes(chartType, chartFrom);
            
            LoadListBoxReportTypes();
            listBoxReportTypes.SelectedIndex = 0;
            listBoxReportTypes.SetItemChecked(0, true);

            LoadListBoxClientDisplayInfo();
            listBoxClients.SelectedIndex = 0;
            listBoxClients.SetItemChecked(0, true);
        }

        private HttpClient httpClient;
            
        
        private void LoadListBoxSubTypes(ChartType chartType, ChartFrom chartFrom)
        {
            List<IChartSubType> lstSubType = new List<IChartSubType>();
            switch(chartType)
            {
                case ChartType.PieChartType:
                    if (chartFrom == ChartFrom.FromApplications)
                    {
                        IEnumerable<PieChartSubTypeApplications> enumerableChartSubTypes = PieChartSubTypeApplications.GetAll<PieChartSubTypeApplications>();
                        foreach (PieChartSubTypeApplications item in enumerableChartSubTypes)
                        {
                            lstSubType.Add(item);
                        }
                    } else if (chartFrom == ChartFrom.FromInvoices)
                    {
                        IEnumerable<PieChartSubTypeInvoices> enumerableChartSubTypes = PieChartSubTypeInvoices.GetAll<PieChartSubTypeInvoices>();
                        foreach (PieChartSubTypeInvoices item in enumerableChartSubTypes)
                        {
                            lstSubType.Add(item);
                        }
                    }
                    break;
                case ChartType.BarChartType:
                    if (chartFrom == ChartFrom.FromApplications)
                    {
                        IEnumerable<BarChartSubTypeApplications> enumerableChartSubTypes = BarChartSubTypeApplications.GetAll<BarChartSubTypeApplications>();
                        foreach (BarChartSubTypeApplications item in enumerableChartSubTypes)
                        {
                            lstSubType.Add(item);
                        }
                    }
                    else if (chartFrom == ChartFrom.FromInvoices)
                    {
                        IEnumerable<BarChartSubTypeInvoices> enumerableChartSubTypes = BarChartSubTypeInvoices.GetAll<BarChartSubTypeInvoices>();
                        foreach (BarChartSubTypeInvoices item in enumerableChartSubTypes)
                        {
                            lstSubType.Add(item);
                        }
                    }
                    break;
                case ChartType.LineChartType:
                    if (chartFrom == ChartFrom.FromApplications)
                    {
                        IEnumerable<LineChartSubTypeApplications> enumerableChartSubTypes = LineChartSubTypeApplications.GetAll<LineChartSubTypeApplications>();
                        foreach (LineChartSubTypeApplications item in enumerableChartSubTypes)
                        {
                            lstSubType.Add(item);
                        }
                    }
                    else if (chartFrom == ChartFrom.FromInvoices)
                    {
                        IEnumerable<LineChartSubTypeInvoices> enumerableChartSubTypes = LineChartSubTypeInvoices.GetAll<LineChartSubTypeInvoices>();
                        foreach (LineChartSubTypeInvoices item in enumerableChartSubTypes)
                        {
                            lstSubType.Add(item);
                        }
                    }
                    break;
            }
            listBoxSubTypes.Items.Clear();
            listBoxSubTypes.ValueMember = "Value";
            listBoxSubTypes.DisplayMember = "DisplayName";
            foreach(IChartSubType item in lstSubType)
            {
                listBoxSubTypes.Items.Add(item);
            }
            if (this.listBoxSubTypes.Items.Count > 0)
            {
                this.listBoxSubTypes.SetSelected(0, true);
            }

        }
        
        private void LoadListBoxReportTypes()
        {
            listBoxReportTypes.Items.Clear();
            listBoxReportTypes.ValueMember = "ReportTypeId";
            listBoxReportTypes.DisplayMember = "TypeName";
            ReportTypeData allReportTypeItem = new ReportTypeData();
            allReportTypeItem.ReportTypeId = "";
            allReportTypeItem.TypeName = "All Reports";
            listBoxReportTypes.Items.Add(allReportTypeItem);

            string url = "api/reportTypes";
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                List<ReportTypeData> reportTypesData = JsonConvert.DeserializeObject<List<ReportTypeData>>(jsonContent);
                foreach(ReportTypeData item in reportTypesData)
                {
                    listBoxReportTypes.Items.Add(item);
                }
            }
        }
        
        private void LoadListBoxClientDisplayInfo()
        {
            listBoxClients.Items.Clear();
            listBoxClients.ValueMember = "ClientId";
            listBoxClients.DisplayMember = "ClientName";
            ClientDisplayInfoData allClientDisplayInfo = new ClientDisplayInfoData("", "All Clients");
            listBoxClients.Items.Add(allClientDisplayInfo);

            string url = "api/displayinfo/clients";
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                List<ClientDisplayInfoData> clientDisplayInfoData = JsonConvert.DeserializeObject<List<ClientDisplayInfoData>>(jsonContent);
                foreach (ClientDisplayInfoData item in clientDisplayInfoData)
                {
                    listBoxClients.Items.Add(item);
                }
            }
        }

        private void radioChart_CheckedChanged(object sender, EventArgs e)
        {
            ChartType chartType = this.CurrentChartType();
            ChartFrom chartFrom = this.CurrentChartFrom();
            LoadListBoxSubTypes(chartType, chartFrom);
            if (chartFrom == ChartFrom.FromInvoices)
            {
                listBoxReportTypes.Enabled = false;
            }
            else
            {
                listBoxReportTypes.Enabled = true;
            }
            resetChartDate();
        }

        private void resetChartDate()
        {
            ChartFrom chartFrom = this.CurrentChartFrom();
            DateTime curDate = DateTime.Now;
            dtmTo.MaxDate = curDate;
            dtmTo.Value = curDate;

            if (chartFrom == ChartFrom.FromApplications)
            {
                dtmFrom.Format = DateTimePickerFormat.Short;
                dtmTo.Format = DateTimePickerFormat.Short;
                dtmFrom.Value = curDate.AddDays(-7);
            }
            else if (chartFrom == ChartFrom.FromInvoices)
            {
                dtmFrom.Format = DateTimePickerFormat.Custom;
                dtmTo.Format = DateTimePickerFormat.Custom;
                dtmFrom.CustomFormat = "MM/yyyy";
                dtmTo.CustomFormat = "MM/yyyy";
                dtmFrom.Value = curDate.AddMonths(-1);
            }
        }

        private ChartType CurrentChartType()
        {
            if (radioPieChart.Checked)
            {
                return ChartType.PieChartType;
            }
            else if (radioBarChart.Checked)
            {
                return ChartType.BarChartType;
            }
            else if (radioLineChart.Checked)
            {
                return ChartType.LineChartType;
            }

            return ChartType.PieChartType;
        }

        private ChartFrom CurrentChartFrom()
        {
            if (radioApplications.Checked)
            {
                return ChartFrom.FromApplications;
            }
            else if (radioInvoices.Checked)
            {
                return ChartFrom.FromInvoices;
            }
            return ChartFrom.FromApplications;
        }

        private void listBoxSubTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            IChartSubType subType = (IChartSubType)listBoxSubTypes.SelectedItem;
            textBoxChartDescriptoin.Text = subType.ChartDescription;
        }

        private void btnMakeChart_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnMakeChart != null)
                {
                    ChartFilterData filterData = new ChartFilterData();
                    filterData.DateFrom = this.dtmFrom.Value.ToUniversalTime();
                    filterData.DateTo = this.dtmTo.Value.Date.AddDays(1).AddMinutes(-1).ToUniversalTime();
                    DateTimeZone tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();
                    filterData.LocalTimeZone = tz.Id;
                    filterData.ChartSubType = ((IChartSubType)this.listBoxSubTypes.SelectedItem).SubTypeValue;
                    ChartFrom chartFrom = this.CurrentChartFrom();

                    if (chartFrom == ChartFrom.FromInvoices)
                    {
                        filterData.DateFrom = new DateTime(dtmFrom.Value.Year, dtmFrom.Value.Month, 1).ToUniversalTime();
                        filterData.DateTo = new DateTime(dtmTo.Value.Year, dtmTo.Value.Month, 1).AddMonths(1).AddMinutes(-10).ToUniversalTime();
                    }

                    ChartType chartType = this.CurrentChartType();

                    foreach(object itemChecked in listBoxReportTypes.CheckedItems)
                    {
                        ReportTypeData castedItem = itemChecked as ReportTypeData;
                        if (castedItem.ReportTypeId == "")
                        {
                            filterData.IsAllReportTypes = true;
                            break;
                        }
                        else
                        {
                            filterData.ReportTypeIds.Add(castedItem.ReportTypeId);
                        }
                    }

                    foreach (object itemChecked in listBoxClients.CheckedItems)
                    {
                        ClientDisplayInfoData castedItem = itemChecked as ClientDisplayInfoData;
                        if (castedItem.ClientId == "")
                        {
                            filterData.IsAllClients = true;
                            break;
                        }
                        else
                        {
                            filterData.ClientIds.Add(castedItem.ClientId);
                        }
                    }

                    MakeChartEventArgs args = new MakeChartEventArgs(chartType, chartFrom, filterData);
                    this.OnMakeChart(this, args);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        private void CustomChartDatetime_ValueChanged(object sender, EventArgs e)
        {
            dtmFrom.MaxDate = dtmTo.Value;
            dtmTo.MinDate = dtmFrom.Value;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.P:
                    radioPieChart.Checked = true;
                    return true;
                case Keys.Alt | Keys.B:
                    radioBarChart.Checked = true;
                    return true;
                case Keys.Alt | Keys.L:
                    radioLineChart.Checked = true;
                    return true;
                case Keys.Alt | Keys.M:
                    this.btnMakeChart_Click(this, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
