using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaaApplication.Models.AutoDocument;
using Common.Infrastructure.UI;

namespace PaaApplication.Forms
{
    public partial class FormCommonChart : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormCommonChart()
        {
            InitializeComponent();

            this.commonChartOptionControl.OnMakeChart += new System.EventHandler<MakeChartEventArgs>(this.commonChartOptionControl_OnMakeChart);
        }

        private void commonChartOptionControl_OnMakeChart(object sender, MakeChartEventArgs args)
        {
            try
            {
                using (new HourGlass())
                {
                    chartSectionControl.GenerateChart(args.ChartType, args.ChartFrom, args.FilterData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _logger.Error(ex.ToString());
            }
        }

        private void FormCommonChart_LoadCompleted(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                this.chartSectionControl.InitializeSettings();
                this.commonChartOptionControl.InitializeSettings();
            }            
        }

        private void FormCommonChart_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.chartSectionControl.ClearChart();
            }
        }

    }
}
