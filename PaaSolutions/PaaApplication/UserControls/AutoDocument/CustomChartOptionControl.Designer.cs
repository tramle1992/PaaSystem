namespace PaaApplication.UserControls.AutoDocument
{
    partial class CustomChartOptionControl
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
            this.btnMakeChart = new System.Windows.Forms.Button();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtmFrom = new System.Windows.Forms.DateTimePicker();
            this.dtmTo = new System.Windows.Forms.DateTimePicker();
            this.radioPieChart = new System.Windows.Forms.RadioButton();
            this.textBoxChartDescriptoin = new System.Windows.Forms.TextBox();
            this.radioLineChart = new System.Windows.Forms.RadioButton();
            this.radioBarChart = new System.Windows.Forms.RadioButton();
            this.radioInvoices = new System.Windows.Forms.RadioButton();
            this.radioApplications = new System.Windows.Forms.RadioButton();
            this.listBoxSubTypes = new System.Windows.Forms.ListBox();
            this.listBoxClients = new System.Windows.Forms.CheckedListBox();
            this.listBoxReportTypes = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMakeChart
            // 
            this.btnMakeChart.BackColor = System.Drawing.Color.Gray;
            this.btnMakeChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeChart.ForeColor = System.Drawing.Color.White;
            this.btnMakeChart.Location = new System.Drawing.Point(388, 516);
            this.btnMakeChart.Name = "btnMakeChart";
            this.btnMakeChart.Size = new System.Drawing.Size(106, 29);
            this.btnMakeChart.TabIndex = 15;
            this.btnMakeChart.Text = "&Make Chart";
            this.btnMakeChart.UseVisualStyleBackColor = false;
            this.btnMakeChart.Click += new System.EventHandler(this.btnMakeChart_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFrom.Location = new System.Drawing.Point(23, 24);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(43, 15);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "FROM:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTo.Location = new System.Drawing.Point(218, 24);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(26, 15);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "TO:";
            // 
            // dtmFrom
            // 
            this.dtmFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtmFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmFrom.Location = new System.Drawing.Point(68, 20);
            this.dtmFrom.Name = "dtmFrom";
            this.dtmFrom.Size = new System.Drawing.Size(115, 21);
            this.dtmFrom.TabIndex = 7;
            this.dtmFrom.ValueChanged += new System.EventHandler(this.CustomChartDatetime_ValueChanged);
            // 
            // dtmTo
            // 
            this.dtmTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtmTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmTo.Location = new System.Drawing.Point(246, 20);
            this.dtmTo.Name = "dtmTo";
            this.dtmTo.Size = new System.Drawing.Size(115, 21);
            this.dtmTo.TabIndex = 8;
            this.dtmTo.ValueChanged += new System.EventHandler(this.CustomChartDatetime_ValueChanged);
            // 
            // radioPieChart
            // 
            this.radioPieChart.AutoSize = true;
            this.radioPieChart.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPieChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioPieChart.Location = new System.Drawing.Point(6, 19);
            this.radioPieChart.Name = "radioPieChart";
            this.radioPieChart.Size = new System.Drawing.Size(86, 20);
            this.radioPieChart.TabIndex = 1;
            this.radioPieChart.Text = "&Pie Chart";
            this.radioPieChart.UseVisualStyleBackColor = true;
            this.radioPieChart.CheckedChanged += new System.EventHandler(this.radioChart_CheckedChanged);
            // 
            // textBoxChartDescriptoin
            // 
            this.textBoxChartDescriptoin.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxChartDescriptoin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxChartDescriptoin.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxChartDescriptoin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxChartDescriptoin.Location = new System.Drawing.Point(9, 43);
            this.textBoxChartDescriptoin.Multiline = true;
            this.textBoxChartDescriptoin.Name = "textBoxChartDescriptoin";
            this.textBoxChartDescriptoin.ReadOnly = true;
            this.textBoxChartDescriptoin.Size = new System.Drawing.Size(471, 37);
            this.textBoxChartDescriptoin.TabIndex = 0;
            // 
            // radioLineChart
            // 
            this.radioLineChart.AutoSize = true;
            this.radioLineChart.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioLineChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioLineChart.Location = new System.Drawing.Point(232, 19);
            this.radioLineChart.Name = "radioLineChart";
            this.radioLineChart.Size = new System.Drawing.Size(93, 20);
            this.radioLineChart.TabIndex = 3;
            this.radioLineChart.Text = "&Line Chart";
            this.radioLineChart.UseVisualStyleBackColor = true;
            this.radioLineChart.CheckedChanged += new System.EventHandler(this.radioChart_CheckedChanged);
            // 
            // radioBarChart
            // 
            this.radioBarChart.AutoSize = true;
            this.radioBarChart.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBarChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioBarChart.Location = new System.Drawing.Point(119, 19);
            this.radioBarChart.Name = "radioBarChart";
            this.radioBarChart.Size = new System.Drawing.Size(87, 20);
            this.radioBarChart.TabIndex = 2;
            this.radioBarChart.Text = "&Bar Chart";
            this.radioBarChart.UseVisualStyleBackColor = true;
            this.radioBarChart.CheckedChanged += new System.EventHandler(this.radioChart_CheckedChanged);
            // 
            // radioInvoices
            // 
            this.radioInvoices.AutoSize = true;
            this.radioInvoices.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioInvoices.Location = new System.Drawing.Point(6, 52);
            this.radioInvoices.Name = "radioInvoices";
            this.radioInvoices.Size = new System.Drawing.Size(79, 20);
            this.radioInvoices.TabIndex = 5;
            this.radioInvoices.Text = "Invoices";
            this.radioInvoices.UseVisualStyleBackColor = true;
            this.radioInvoices.CheckedChanged += new System.EventHandler(this.radioChart_CheckedChanged);
            // 
            // radioApplications
            // 
            this.radioApplications.AutoSize = true;
            this.radioApplications.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioApplications.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioApplications.Location = new System.Drawing.Point(6, 22);
            this.radioApplications.Name = "radioApplications";
            this.radioApplications.Size = new System.Drawing.Size(105, 20);
            this.radioApplications.TabIndex = 4;
            this.radioApplications.Text = "Applications";
            this.radioApplications.UseVisualStyleBackColor = true;
            this.radioApplications.CheckedChanged += new System.EventHandler(this.radioChart_CheckedChanged);
            // 
            // listBoxSubTypes
            // 
            this.listBoxSubTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSubTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBoxSubTypes.FormattingEnabled = true;
            this.listBoxSubTypes.ItemHeight = 15;
            this.listBoxSubTypes.Location = new System.Drawing.Point(6, 20);
            this.listBoxSubTypes.Name = "listBoxSubTypes";
            this.listBoxSubTypes.Size = new System.Drawing.Size(355, 109);
            this.listBoxSubTypes.TabIndex = 6;
            this.listBoxSubTypes.SelectedIndexChanged += new System.EventHandler(this.listBoxSubTypes_SelectedIndexChanged);
            // 
            // listBoxClients
            // 
            this.listBoxClients.CheckOnClick = true;
            this.listBoxClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.Location = new System.Drawing.Point(7, 22);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(288, 148);
            this.listBoxClients.TabIndex = 9;
            // 
            // listBoxReportTypes
            // 
            this.listBoxReportTypes.CheckOnClick = true;
            this.listBoxReportTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxReportTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBoxReportTypes.FormattingEnabled = true;
            this.listBoxReportTypes.Location = new System.Drawing.Point(6, 22);
            this.listBoxReportTypes.Name = "listBoxReportTypes";
            this.listBoxReportTypes.Size = new System.Drawing.Size(177, 148);
            this.listBoxReportTypes.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioPieChart);
            this.groupBox1.Controls.Add(this.textBoxChartDescriptoin);
            this.groupBox1.Controls.Add(this.radioBarChart);
            this.groupBox1.Controls.Add(this.radioLineChart);
            this.groupBox1.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 89);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CHOOSE  A  CHART  TYPE:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioInvoices);
            this.groupBox2.Controls.Add(this.radioApplications);
            this.groupBox2.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(4, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 208);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CHART  FORM:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxSubTypes);
            this.groupBox3.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.Location = new System.Drawing.Point(133, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 145);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CHOOSE  A  CHART  SUB-TYPE:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtmFrom);
            this.groupBox4.Controls.Add(this.dtmTo);
            this.groupBox4.Controls.Add(this.lblTo);
            this.groupBox4.Controls.Add(this.lblFrom);
            this.groupBox4.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox4.Location = new System.Drawing.Point(133, 258);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(367, 53);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CHART  DATES:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listBoxClients);
            this.groupBox5.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox5.Location = new System.Drawing.Point(4, 322);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(301, 184);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "CHART  THESE  CLIENTS:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listBoxReportTypes);
            this.groupBox6.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox6.Location = new System.Drawing.Point(311, 322);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(189, 184);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "REPORT  TYPES:";
            // 
            // CustomChartOptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMakeChart);
            this.Name = "CustomChartOptionControl";
            this.Size = new System.Drawing.Size(503, 558);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMakeChart;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtmFrom;
        private System.Windows.Forms.DateTimePicker dtmTo;
        private System.Windows.Forms.RadioButton radioPieChart;
        private System.Windows.Forms.TextBox textBoxChartDescriptoin;
        private System.Windows.Forms.RadioButton radioLineChart;
        private System.Windows.Forms.RadioButton radioBarChart;
        private System.Windows.Forms.RadioButton radioInvoices;
        private System.Windows.Forms.RadioButton radioApplications;
        private System.Windows.Forms.ListBox listBoxSubTypes;
        private System.Windows.Forms.CheckedListBox listBoxClients;
        private System.Windows.Forms.CheckedListBox listBoxReportTypes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}
