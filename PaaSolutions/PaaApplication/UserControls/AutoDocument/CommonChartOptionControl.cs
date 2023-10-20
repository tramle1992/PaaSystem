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
using NodaTime;

namespace PaaApplication.UserControls.AutoDocument
{
    public partial class CommonChartOptionControl : UserControl
    {
        public CommonChartOptionControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.Selectable, false);
        }

        public event EventHandler<MakeChartEventArgs> OnMakeChart;

        public void InitializeSettings()
        {
            this.LoadComboBoxOptions();
            DateTime curDate = DateTime.Now;
            dtmTo.Value = curDate;
            dtmFrom.Value = curDate.AddMonths(-1);
            dtmTo.MaxDate = curDate;
        }

        private void LoadComboBoxOptions()
        {
            List<ChartSubTypeCommon> lstSubTypeCommon = new List<ChartSubTypeCommon>();
            IEnumerable<ChartSubTypeCommon> commonChartSubTypes = ChartSubTypeCommon.GetAll<ChartSubTypeCommon>();
            foreach (ChartSubTypeCommon item in commonChartSubTypes)
            {
                lstSubTypeCommon.Add(item);
            }
            cboCommonChartSubType.DataSource = lstSubTypeCommon;
            cboCommonChartSubType.ValueMember = "Value";
            cboCommonChartSubType.DisplayMember = "DisplayName";
        }

        private void btnMakeChart_Click(object sender, EventArgs e)
        {
            if (OnMakeChart != null)
            {
                ChartFilterData filterData = new ChartFilterData();
                filterData.DateFrom = this.dtmFrom.Value.ToUniversalTime();
                filterData.DateTo = this.dtmTo.Value.Date.AddDays(1).AddMinutes(-10).ToUniversalTime();
                DateTimeZone tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();
                filterData.LocalTimeZone = tz.Id;
                filterData.ChartSubType = (int)this.cboCommonChartSubType.SelectedValue;
                ChartFrom chartFrom = ChartFrom.FromCommon;
                ChartType chartType = (filterData.ChartSubType < 3) ? ChartType.PieChartType : ChartType.LineChartType;
                filterData.IsFullAppOnly = chkFullAppsOnly.Checked;
                filterData.IsAllClients = true;
                filterData.IsAllReportTypes = true;
                MakeChartEventArgs args = new MakeChartEventArgs(chartType, chartFrom, filterData);
                this.OnMakeChart(this, args);
            }                
        }

        private void CommonChartDatetime_ValueChanged(object sender, EventArgs e)
        {
            dtmFrom.MaxDate = dtmTo.Value;
            dtmTo.MinDate = dtmFrom.Value;
        }

        private void cboCommonChartSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCommonChartSubType.SelectedIndex >= 0)
            {
                ChartSubTypeCommon selectedItem = this.cboCommonChartSubType.SelectedItem as ChartSubTypeCommon;
                if (selectedItem.Value == ChartSubTypeCommon.PercentageAppsReceivedByType.Value ||
                    selectedItem.Value == ChartSubTypeCommon.PercentageAppsCompletedByTurnaround.Value)
                {
                    chkFullAppsOnly.Enabled = false;
                }
                else
                {
                    chkFullAppsOnly.Enabled = true;
                }

                if (selectedItem.Value == ChartSubTypeCommon.PercentageAppsCompletedByTurnaround.Value)
                {
                    chkFullAppsOnly.Checked = true;
                }
                if (selectedItem.Value == ChartSubTypeCommon.PercentageAppsReceivedByType.Value)
                {
                    chkFullAppsOnly.Checked = false;
                }
            }
        }
    }

        
}
