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
using System.Windows.Forms.DataVisualization.Charting;
using Common.Infrastructure.ApiClient;
using System.Net.Http;
using Newtonsoft.Json;
using PaaApplication.Models.AutoDocument;
using System.Configuration;
using PaaApplication.Models.Common;

namespace PaaApplication.UserControls.AutoDocument
{
    public partial class ChartSectionControl : UserControl
    {


        public ChartSectionControl()
        {
            InitializeComponent();
        }

        public void InitializeSettings()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUri"];
            httpClient = ApiClientFactory.GetHttpClient(baseAddress);
        }

        private HttpClient httpClient;

        public void GenerateChart(ChartType chartType, ChartFrom chartFrom, ChartFilterData chartFilterData)
        {
            try
            {
                switch (chartType)
                {
                    case ChartType.PieChartType:
                        PieChartData pieChartData = GeneratePieChart(chartFrom, chartFilterData);
                        if (pieChartData != null)
                        {
                            RenderPieChart(pieChartData);
                        }
                        break;
                    case ChartType.BarChartType:
                        BarChartData barChartData = GenerateBarChart(chartFrom, chartFilterData);
                        if (barChartData != null)
                        {
                            RenderBarChart(barChartData);
                        }
                        break;
                    case ChartType.LineChartType:
                        LineChartData lineChartData = GenerateLineChart(chartFrom, chartFilterData);
                        if (lineChartData != null)
                        {
                            RenderLineChart(lineChartData);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        public void ClearChart()
        {
            mainChart.Series.Clear();
            mainChart.Legends.Clear();
            mainChart.Titles.Clear();
        }

        #region PieChart
        private PieChartData GeneratePieChart(ChartFrom chartFrom, ChartFilterData chartFilterData)
        {
            switch(chartFrom)
            {
                case ChartFrom.FromApplications:
                    return GeneratePieChartFromApplications(chartFilterData);
                case ChartFrom.FromInvoices:
                    return GeneratePieChartFromInvoices(chartFilterData);
                case ChartFrom.FromCommon:
                    return GeneratePieChartCommon(chartFilterData);
            }
            return null;
        }

        private PieChartData GeneratePieChartFromApplications(ChartFilterData chartFilterData)
        {
            string url = string.Format("api/chart/{0}/from/{1}", (int)ChartType.PieChartType, (int)ChartFrom.FromApplications);
            string content = JsonConvert.SerializeObject(chartFilterData);
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {                    
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                PieChartData pieChartData = JsonConvert.DeserializeObject<PieChartData>(jsonContent);
                return pieChartData;
            }
            else
            {
                ApiError error = response.Content.ReadAsAsync<ApiError>().Result;
                MessageBox.Show(error.ExceptionMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private PieChartData GeneratePieChartFromInvoices(ChartFilterData chartFilterData)
        {
            string url = string.Format("api/chart/{0}/from/{1}", (int)ChartType.PieChartType, (int)ChartFrom.FromInvoices);
            string content = JsonConvert.SerializeObject(chartFilterData);
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                PieChartData pieChartData = JsonConvert.DeserializeObject<PieChartData>(jsonContent);
                return pieChartData;
            }
            else
            {
                ApiError error = response.Content.ReadAsAsync<ApiError>().Result;
                MessageBox.Show(error.ExceptionMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private PieChartData GeneratePieChartCommon(ChartFilterData chartFilterData)
        {
            string content = JsonConvert.SerializeObject(chartFilterData);
            string url = string.Format("api/chart/{0}/from/{1}", (int)ChartType.PieChartType, (int)ChartFrom.FromCommon);
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                PieChartData pieChartData = JsonConvert.DeserializeObject<PieChartData>(jsonContent);
                return pieChartData;
            }
            else
            {
                ApiError error = response.Content.ReadAsAsync<ApiError>().Result;
                MessageBox.Show(error.ExceptionMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        #endregion;

        #region BarChart

        private BarChartData GenerateBarChart(ChartFrom chartFrom, ChartFilterData chartFilterData)
        {
            switch (chartFrom)
            {
                case ChartFrom.FromApplications:
                    return GenerateBarChartFromApplications(chartFilterData);
                case ChartFrom.FromInvoices:
                    return GenerateBarChartFromInvoices(chartFilterData);
            }
            return null;
        }

        private BarChartData GenerateBarChartFromApplications(ChartFilterData chartFilterData)
        {
            string content = JsonConvert.SerializeObject(chartFilterData);
            string url = string.Format("api/chart/{0}/from/{1}", (int)ChartType.BarChartType, (int)ChartFrom.FromApplications);
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                BarChartData barChartData = JsonConvert.DeserializeObject<BarChartData>(jsonContent);
                return barChartData;
            } 
            else
            {
                ApiError error = response.Content.ReadAsAsync<ApiError>().Result;
                MessageBox.Show(error.ExceptionMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private BarChartData GenerateBarChartFromInvoices(ChartFilterData chartFilterData)
        {
            string content = JsonConvert.SerializeObject(chartFilterData);
            string url = string.Format("api/chart/{0}/from/{1}", (int)ChartType.BarChartType, (int)ChartFrom.FromInvoices);
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                BarChartData barChartData = JsonConvert.DeserializeObject<BarChartData>(jsonContent);
                return barChartData;
            }
            else
            {
                ApiError error = response.Content.ReadAsAsync<ApiError>().Result;
                MessageBox.Show(error.ExceptionMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        #endregion;

        #region LineChart

        private LineChartData GenerateLineChart(ChartFrom chartFrom, ChartFilterData chartFilterData)
        {
            switch (chartFrom)
            {
                case ChartFrom.FromApplications:
                    return GenerateLineChartFromApplications(chartFilterData);
                case ChartFrom.FromInvoices:
                    return GenerateLineChartFromInvoices(chartFilterData);
                case ChartFrom.FromCommon:
                    return GenerateLineChartFromCommon(chartFilterData);
            }
            return null;
        }

        private LineChartData GenerateLineChartFromApplications(ChartFilterData chartFilterData)
        {
            string content = JsonConvert.SerializeObject(chartFilterData);
            string url = string.Format("api/chart/{0}/from/{1}", (int)ChartType.LineChartType, (int)ChartFrom.FromApplications);
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                LineChartData lineChartData = JsonConvert.DeserializeObject<LineChartData>(jsonContent);
                return lineChartData;
            }
            else
            {
                ApiError error = response.Content.ReadAsAsync<ApiError>().Result;
                MessageBox.Show(error.ExceptionMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private LineChartData GenerateLineChartFromInvoices(ChartFilterData chartFilterData)
        {
            string content = JsonConvert.SerializeObject(chartFilterData);
            string url = string.Format("api/chart/{0}/from/{1}", (int)ChartType.LineChartType, (int)ChartFrom.FromInvoices);
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                LineChartData lineChartData = JsonConvert.DeserializeObject<LineChartData>(jsonContent);
                return lineChartData;
            }
            else
            {
                ApiError error = response.Content.ReadAsAsync<ApiError>().Result;
                MessageBox.Show(error.ExceptionMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private LineChartData GenerateLineChartFromCommon(ChartFilterData chartFilterData)
        {
            string content = JsonConvert.SerializeObject(chartFilterData);
            string url = string.Format("api/chart/{0}/from/{1}", (int)ChartType.LineChartType, (int)ChartFrom.FromCommon);
            HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                LineChartData lineChartData = JsonConvert.DeserializeObject<LineChartData>(jsonContent);
                return lineChartData;
            }
            else
            {
                ApiError error = response.Content.ReadAsAsync<ApiError>().Result;
                MessageBox.Show(error.ExceptionMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        #endregion;

        #region Render

        private void ZoomToggle(bool Enabled)
        {
            // Enable range selection and zooming end user interface
            this.mainChart.ChartAreas[0].CursorX.IsUserEnabled = Enabled;
            this.mainChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = Enabled;
            this.mainChart.ChartAreas[0].CursorX.Interval = 0;
            this.mainChart.ChartAreas[0].AxisX.ScaleView.Zoomable = Enabled;
            this.mainChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            this.mainChart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            this.mainChart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 0;

            this.mainChart.ChartAreas[0].CursorY.IsUserEnabled = Enabled;
            this.mainChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = Enabled;
            this.mainChart.ChartAreas[0].CursorY.Interval = 0;
            this.mainChart.ChartAreas[0].AxisY.ScaleView.Zoomable = Enabled;
            this.mainChart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            this.mainChart.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;
            this.mainChart.ChartAreas[0].AxisY.ScaleView.SmallScrollMinSize = 0;
            if (Enabled == false)
            {
                //Remove the cursor lines
                this.mainChart.ChartAreas[0].CursorX.SetCursorPosition(double.NaN);
                this.mainChart.ChartAreas[0].CursorY.SetCursorPosition(double.NaN);
            }
        }

        private void RenderPieChart(PieChartData data)
        {
            this.ClearChart();
            
            if (data.Numbers.Count > data.NameOfXAxisValues.Count)
            {
                //@todo: something wrong here, need to show message box and return
                return;
            }

            Series series = new Series("ChartSeries");
            series.ChartType = SeriesChartType.Pie;
            series["PieLabelStyle"] = "Outside";
            if (!string.IsNullOrEmpty(data.Title))
            {
                Title title = new Title();
                title.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold);
                title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                title.Name = "Title";
                title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                title.ShadowOffset = 3;
                title.Text = data.Title;
                mainChart.Titles.Add(title);
            }

            for (int i = 0; i < data.NameOfXAxisValues.Count; i++)
            {
                if (data.Numbers[i] > 0)
                {
                    series.Points.AddXY(data.NameOfXAxisValues[i], data.Numbers[i]);
                }
            }

            Legend legend = new Legend("PieLegend");
            legend.Alignment = StringAlignment.Center;
            legend.Docking = Docking.Right;
            legend.Font = new Font("Arial Unicode MS", 12.0f);
            legend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend.IsTextAutoFit = true;
            legend.MaximumAutoSize = 50;
            mainChart.Legends.Add(legend);
            series.Legend = "PieLegend";
            series.LegendText = "#VALX (#VALY: #PERCENT{P2})";
            series["PieLabelStyle"] = "Disabled";
            this.mainChart.Series.Add(series);
            this.mainChart.Invalidate();
        }

        private void RenderBarChart(BarChartData data)
        {
            this.ClearChart();

            Legend legend = new Legend("Default");
            legend.LegendStyle = LegendStyle.Row;
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Arial Unicode MS", 12.0f);
            legend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend.IsTextAutoFit = true;
            legend.MaximumAutoSize = 50;
            mainChart.Legends.Add(legend);
            if (!string.IsNullOrEmpty(data.Title))
            {
                Title title = new Title();
                title.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold);
                title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                title.Name = "Title";
                title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                title.ShadowOffset = 3;
                title.Text = data.Title;
                mainChart.Titles.Add(title);
                
            }

            ZoomToggle(true);
            mainChart.ChartAreas[0].AxisX.Interval = 1;

            for (int seriesIndex = 0; seriesIndex < data.SeriesNames.Count; seriesIndex++)
            {
                Series series = new Series(data.SeriesNames[seriesIndex]);
                List<int> yValues = data.SeriesYValues[seriesIndex];
                series.ChartType = SeriesChartType.Column;
                for (int i = 0; i < data.Labels.Count; i++)
                {
                    series.Points.AddXY(i, yValues[i]);
                    series.Points[i].AxisLabel = data.Labels[i];
                }
                series["PointWidth"] = "0.6";
                series.Legend = "Default";
                if (data.Labels.Count < 20)
                    series.IsValueShownAsLabel = true;
                this.mainChart.Series.Add(series);
            }

            mainChart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            mainChart.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
            mainChart.ChartAreas[0].AxisY.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;

            this.mainChart.Invalidate();
        }

        private void RenderLineChart(LineChartData data)
        {
            this.ClearChart();

            Legend legend = new Legend("Default");
            legend.LegendStyle = LegendStyle.Row;
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Arial Unicode MS", 12.0f);
            legend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend.IsTextAutoFit = true;
            legend.MaximumAutoSize = 50;
            mainChart.Legends.Add(legend);

            if (!string.IsNullOrEmpty(data.Title))
            {
                Title title = new Title();
                title.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold);
                title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                title.Name = "Title";
                title.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                title.ShadowOffset = 3;
                title.Text = data.Title;
                mainChart.Titles.Add(title);

            }

            ZoomToggle(true);
            mainChart.ChartAreas[0].AxisX.Interval = 1;

            for (int seriesIndex = 0; seriesIndex < data.SeriesNames.Count; seriesIndex++)
            {
                Series series = new Series(data.SeriesNames[seriesIndex]);
                List<int> yValues = data.SeriesYValues[seriesIndex];
                series.ChartType = SeriesChartType.Line;
                for (int i = 0; i < data.Labels.Count; i++)
                {
                    series.Points.AddXY(i, yValues[i]);
                    series.Points[i].AxisLabel = data.Labels[i];
                }
                series.Legend = "Default";
                this.mainChart.Series.Add(series);
            }

            for (int seriesIndex = 0; seriesIndex < data.SeriesNames.Count; seriesIndex++)
            {
                Series serie = this.mainChart.Series[seriesIndex];
                if (serie.Points.Count > 0)
                {
                    DataPoint point = serie.Points[0];
                    point.Label = serie.Name;
                }
                serie.BorderWidth = 3;
            }
            mainChart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            mainChart.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
            mainChart.ChartAreas[0].AxisY.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;

            this.mainChart.Invalidate();
        }

        #endregion;
    }
}
