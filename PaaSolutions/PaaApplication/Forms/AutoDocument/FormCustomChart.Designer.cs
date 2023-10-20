namespace PaaApplication.Forms
{
    partial class FormCustomChart
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
            this.customChartOptionControl = new PaaApplication.UserControls.AutoDocument.CustomChartOptionControl();
            this.SuspendLayout();
            // 
            // chartSectionControl
            // 
            this.chartSectionControl.Location = new System.Drawing.Point(521, 12);
            this.chartSectionControl.Name = "chartSectionControl";
            this.chartSectionControl.Size = new System.Drawing.Size(960, 550);
            this.chartSectionControl.TabIndex = 1;
            this.chartSectionControl.Load += new System.EventHandler(this.chartSectionControl_Load);
            // 
            // customChartOptionControl
            // 
            this.customChartOptionControl.Location = new System.Drawing.Point(4, 9);
            this.customChartOptionControl.Name = "customChartOptionControl";
            this.customChartOptionControl.Size = new System.Drawing.Size(506, 551);
            this.customChartOptionControl.TabIndex = 0;
            this.customChartOptionControl.Load += new System.EventHandler(this.customChartOptionControl_Load);
            // 
            // FormCustomChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 654);
            this.Controls.Add(this.chartSectionControl);
            this.Controls.Add(this.customChartOptionControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCustomChart";
            this.Text = "Custom Chart Form";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormCustomChart_LoadCompleted);
            this.VisibleChanged += new System.EventHandler(this.FormCustomChart_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.AutoDocument.CustomChartOptionControl customChartOptionControl;
        private UserControls.AutoDocument.ChartSectionControl chartSectionControl;



    }
}