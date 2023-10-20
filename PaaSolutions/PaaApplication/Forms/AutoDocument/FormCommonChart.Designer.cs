namespace PaaApplication.Forms
{
    partial class FormCommonChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chartSectionControl = new PaaApplication.UserControls.AutoDocument.ChartSectionControl();
            this.commonChartOptionControl = new PaaApplication.UserControls.AutoDocument.CommonChartOptionControl();
            this.SuspendLayout();
            // 
            // chartSectionControl
            // 
            this.chartSectionControl.Location = new System.Drawing.Point(521, 12);
            this.chartSectionControl.Name = "chartSectionControl";
            this.chartSectionControl.Size = new System.Drawing.Size(960, 550);
            this.chartSectionControl.TabIndex = 1;
            // 
            // commonChartOptionControl
            // 
            this.commonChartOptionControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.commonChartOptionControl.Location = new System.Drawing.Point(4, 4);
            this.commonChartOptionControl.Name = "commonChartOptionControl";
            this.commonChartOptionControl.Size = new System.Drawing.Size(506, 196);
            this.commonChartOptionControl.TabIndex = 0;
            this.commonChartOptionControl.TabStop = false;
            // 
            // FormCommonChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 654);
            this.Controls.Add(this.chartSectionControl);
            this.Controls.Add(this.commonChartOptionControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCommonChart";
            this.Text = "Common Chart Form";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormCommonChart_LoadCompleted);
            this.VisibleChanged += new System.EventHandler(this.FormCommonChart_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.AutoDocument.ChartSectionControl chartSectionControl;
        private UserControls.AutoDocument.CommonChartOptionControl commonChartOptionControl;
    }
}