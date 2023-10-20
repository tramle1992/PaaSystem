namespace PaaApplication.UserControls.AutoDocument
{
    partial class CommonChartOptionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboCommonChartSubType = new System.Windows.Forms.ComboBox();
            this.dtmTo = new System.Windows.Forms.DateTimePicker();
            this.dtmFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.chkFullAppsOnly = new System.Windows.Forms.CheckBox();
            this.btnMakeChart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboCommonChartSubType
            // 
            this.cboCommonChartSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCommonChartSubType.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCommonChartSubType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboCommonChartSubType.FormattingEnabled = true;
            this.cboCommonChartSubType.Location = new System.Drawing.Point(37, 26);
            this.cboCommonChartSubType.Name = "cboCommonChartSubType";
            this.cboCommonChartSubType.Size = new System.Drawing.Size(330, 24);
            this.cboCommonChartSubType.TabIndex = 1;
            this.cboCommonChartSubType.SelectedIndexChanged += new System.EventHandler(this.cboCommonChartSubType_SelectedIndexChanged);
            // 
            // dtmTo
            // 
            this.dtmTo.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmTo.Location = new System.Drawing.Point(247, 66);
            this.dtmTo.Name = "dtmTo";
            this.dtmTo.Size = new System.Drawing.Size(120, 24);
            this.dtmTo.TabIndex = 3;
            this.dtmTo.ValueChanged += new System.EventHandler(this.CommonChartDatetime_ValueChanged);
            // 
            // dtmFrom
            // 
            this.dtmFrom.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFrom.Location = new System.Drawing.Point(82, 66);
            this.dtmFrom.Name = "dtmFrom";
            this.dtmFrom.Size = new System.Drawing.Size(120, 24);
            this.dtmFrom.TabIndex = 2;
            this.dtmFrom.ValueChanged += new System.EventHandler(this.CommonChartDatetime_ValueChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTo.Location = new System.Drawing.Point(218, 70);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(26, 15);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "TO:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFrom.Location = new System.Drawing.Point(37, 70);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(43, 15);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "FROM:";
            // 
            // chkFullAppsOnly
            // 
            this.chkFullAppsOnly.AutoSize = true;
            this.chkFullAppsOnly.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFullAppsOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkFullAppsOnly.Location = new System.Drawing.Point(81, 103);
            this.chkFullAppsOnly.Name = "chkFullAppsOnly";
            this.chkFullAppsOnly.Size = new System.Drawing.Size(123, 19);
            this.chkFullAppsOnly.TabIndex = 4;
            this.chkFullAppsOnly.Text = "FULL  APPS  ONLY";
            this.chkFullAppsOnly.UseVisualStyleBackColor = true;
            // 
            // btnMakeChart
            // 
            this.btnMakeChart.BackColor = System.Drawing.Color.DarkGray;
            this.btnMakeChart.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeChart.ForeColor = System.Drawing.Color.White;
            this.btnMakeChart.Location = new System.Drawing.Point(260, 127);
            this.btnMakeChart.Name = "btnMakeChart";
            this.btnMakeChart.Size = new System.Drawing.Size(106, 29);
            this.btnMakeChart.TabIndex = 5;
            this.btnMakeChart.Text = "Make Chart";
            this.btnMakeChart.UseVisualStyleBackColor = false;
            this.btnMakeChart.Click += new System.EventHandler(this.btnMakeChart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCommonChartSubType);
            this.groupBox1.Controls.Add(this.btnMakeChart);
            this.groupBox1.Controls.Add(this.dtmTo);
            this.groupBox1.Controls.Add(this.chkFullAppsOnly);
            this.groupBox1.Controls.Add(this.dtmFrom);
            this.groupBox1.Controls.Add(this.lblFrom);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(7, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COMMON  CHARTS:";
            // 
            // CommonChartOptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "CommonChartOptionControl";
            this.Size = new System.Drawing.Size(506, 185);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCommonChartSubType;
        private System.Windows.Forms.DateTimePicker dtmTo;
        private System.Windows.Forms.DateTimePicker dtmFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.CheckBox chkFullAppsOnly;
        private System.Windows.Forms.Button btnMakeChart;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
