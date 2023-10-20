namespace PaaApplication.Forms
{
    partial class FormReportsMenu
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
            this.rdoYearlyBusiness = new System.Windows.Forms.RadioButton();
            this.rdoMonthlyScreener = new System.Windows.Forms.RadioButton();
            this.btnMakeReport = new System.Windows.Forms.Button();
            this.rdoApplicationVolume = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabReports = new PaaApplication.ExtendControls.TablessTabControl();
            this.tabPageMonthlyScreener = new System.Windows.Forms.TabPage();
            this.dtmMonthlyScreener = new System.Windows.Forms.DateTimePicker();
            this.lblMonthlyScreenerOn = new System.Windows.Forms.Label();
            this.cboUsername = new System.Windows.Forms.ComboBox();
            this.tabPageApplicationVolume = new System.Windows.Forms.TabPage();
            this.dtmApplicationVolume = new System.Windows.Forms.DateTimePicker();
            this.tabPageYearlyBusiness = new System.Windows.Forms.TabPage();
            this.dtmYearlyBusiness = new System.Windows.Forms.DateTimePicker();
            this.tabReports.SuspendLayout();
            this.tabPageMonthlyScreener.SuspendLayout();
            this.tabPageApplicationVolume.SuspendLayout();
            this.tabPageYearlyBusiness.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoYearlyBusiness
            // 
            this.rdoYearlyBusiness.AutoSize = true;
            this.rdoYearlyBusiness.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rdoYearlyBusiness.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoYearlyBusiness.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoYearlyBusiness.Location = new System.Drawing.Point(15, 74);
            this.rdoYearlyBusiness.Name = "rdoYearlyBusiness";
            this.rdoYearlyBusiness.Size = new System.Drawing.Size(262, 19);
            this.rdoYearlyBusiness.TabIndex = 2;
            this.rdoYearlyBusiness.Text = "CREATE  YEARLY  BUSINESS  REPORT  FOR:";
            this.rdoYearlyBusiness.UseVisualStyleBackColor = false;
            this.rdoYearlyBusiness.CheckedChanged += new System.EventHandler(this.rdoYearlyBusiness_CheckedChanged);
            // 
            // rdoMonthlyScreener
            // 
            this.rdoMonthlyScreener.AutoSize = true;
            this.rdoMonthlyScreener.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rdoMonthlyScreener.Checked = true;
            this.rdoMonthlyScreener.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMonthlyScreener.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoMonthlyScreener.Location = new System.Drawing.Point(15, 14);
            this.rdoMonthlyScreener.Name = "rdoMonthlyScreener";
            this.rdoMonthlyScreener.Size = new System.Drawing.Size(332, 19);
            this.rdoMonthlyScreener.TabIndex = 0;
            this.rdoMonthlyScreener.TabStop = true;
            this.rdoMonthlyScreener.Text = "CREATE  MONTHLY  SCREENER  VOLUME  REPORT  FOR:";
            this.rdoMonthlyScreener.UseVisualStyleBackColor = false;
            this.rdoMonthlyScreener.CheckedChanged += new System.EventHandler(this.rdoMonthlyScreener_CheckedChanged);
            // 
            // btnMakeReport
            // 
            this.btnMakeReport.BackColor = System.Drawing.Color.DarkGray;
            this.btnMakeReport.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeReport.ForeColor = System.Drawing.Color.White;
            this.btnMakeReport.Location = new System.Drawing.Point(499, 72);
            this.btnMakeReport.Name = "btnMakeReport";
            this.btnMakeReport.Size = new System.Drawing.Size(106, 29);
            this.btnMakeReport.TabIndex = 7;
            this.btnMakeReport.Text = "Make Report";
            this.btnMakeReport.UseVisualStyleBackColor = false;
            this.btnMakeReport.Click += new System.EventHandler(this.btnMakeReport_Click);
            // 
            // rdoApplicationVolume
            // 
            this.rdoApplicationVolume.AutoSize = true;
            this.rdoApplicationVolume.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rdoApplicationVolume.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoApplicationVolume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoApplicationVolume.Location = new System.Drawing.Point(15, 44);
            this.rdoApplicationVolume.Name = "rdoApplicationVolume";
            this.rdoApplicationVolume.Size = new System.Drawing.Size(297, 19);
            this.rdoApplicationVolume.TabIndex = 1;
            this.rdoApplicationVolume.Text = "CREATE  APPLICATION  VOLUME  CALENDAR  FOR:";
            this.rdoApplicationVolume.UseVisualStyleBackColor = false;
            this.rdoApplicationVolume.CheckedChanged += new System.EventHandler(this.rdoApplicationVolume_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 110);
            this.panel1.TabIndex = 101;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Location = new System.Drawing.Point(351, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 110);
            this.panel2.TabIndex = 0;
            // 
            // tabReports
            // 
            this.tabReports.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabReports.Controls.Add(this.tabPageMonthlyScreener);
            this.tabReports.Controls.Add(this.tabPageApplicationVolume);
            this.tabReports.Controls.Add(this.tabPageYearlyBusiness);
            this.tabReports.Location = new System.Drawing.Point(351, 1);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(266, 110);
            this.tabReports.TabIndex = 100;
            // 
            // tabPageMonthlyScreener
            // 
            this.tabPageMonthlyScreener.BackColor = System.Drawing.Color.White;
            this.tabPageMonthlyScreener.Controls.Add(this.dtmMonthlyScreener);
            this.tabPageMonthlyScreener.Controls.Add(this.lblMonthlyScreenerOn);
            this.tabPageMonthlyScreener.Controls.Add(this.cboUsername);
            this.tabPageMonthlyScreener.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonthlyScreener.Name = "tabPageMonthlyScreener";
            this.tabPageMonthlyScreener.Size = new System.Drawing.Size(258, 84);
            this.tabPageMonthlyScreener.TabIndex = 2;
            this.tabPageMonthlyScreener.Text = "tabPage1";
            // 
            // dtmMonthlyScreener
            // 
            this.dtmMonthlyScreener.CustomFormat = "MM / yyyy";
            this.dtmMonthlyScreener.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmMonthlyScreener.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmMonthlyScreener.Location = new System.Drawing.Point(173, 13);
            this.dtmMonthlyScreener.Name = "dtmMonthlyScreener";
            this.dtmMonthlyScreener.Size = new System.Drawing.Size(80, 24);
            this.dtmMonthlyScreener.TabIndex = 4;
            this.dtmMonthlyScreener.ValueChanged += new System.EventHandler(this.dtmMonthlyScreener_ValueChanged);
            // 
            // lblMonthlyScreenerOn
            // 
            this.lblMonthlyScreenerOn.AutoSize = true;
            this.lblMonthlyScreenerOn.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyScreenerOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMonthlyScreenerOn.Location = new System.Drawing.Point(147, 17);
            this.lblMonthlyScreenerOn.Name = "lblMonthlyScreenerOn";
            this.lblMonthlyScreenerOn.Size = new System.Drawing.Size(24, 15);
            this.lblMonthlyScreenerOn.TabIndex = 100;
            this.lblMonthlyScreenerOn.Text = "ON";
            // 
            // cboUsername
            // 
            this.cboUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsername.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboUsername.FormattingEnabled = true;
            this.cboUsername.Items.AddRange(new object[] {
            "KenUsername",
            "LukeUsername",
            "TroyUsername",
            "VinceUsername",
            "JadeUsername",
            "QuinUsername"});
            this.cboUsername.Location = new System.Drawing.Point(14, 12);
            this.cboUsername.Name = "cboUsername";
            this.cboUsername.Size = new System.Drawing.Size(130, 24);
            this.cboUsername.TabIndex = 3;
            this.cboUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboUsername_KeyPress);
            // 
            // tabPageApplicationVolume
            // 
            this.tabPageApplicationVolume.BackColor = System.Drawing.Color.White;
            this.tabPageApplicationVolume.Controls.Add(this.dtmApplicationVolume);
            this.tabPageApplicationVolume.Location = new System.Drawing.Point(4, 22);
            this.tabPageApplicationVolume.Name = "tabPageApplicationVolume";
            this.tabPageApplicationVolume.Size = new System.Drawing.Size(258, 84);
            this.tabPageApplicationVolume.TabIndex = 3;
            this.tabPageApplicationVolume.Text = "tabPage2";
            // 
            // dtmApplicationVolume
            // 
            this.dtmApplicationVolume.CustomFormat = "MM / yyyy";
            this.dtmApplicationVolume.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmApplicationVolume.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmApplicationVolume.Location = new System.Drawing.Point(153, 13);
            this.dtmApplicationVolume.Name = "dtmApplicationVolume";
            this.dtmApplicationVolume.Size = new System.Drawing.Size(100, 24);
            this.dtmApplicationVolume.TabIndex = 5;
            this.dtmApplicationVolume.ValueChanged += new System.EventHandler(this.dtmApplicationVolume_ValueChanged);
            // 
            // tabPageYearlyBusiness
            // 
            this.tabPageYearlyBusiness.BackColor = System.Drawing.Color.White;
            this.tabPageYearlyBusiness.Controls.Add(this.dtmYearlyBusiness);
            this.tabPageYearlyBusiness.Location = new System.Drawing.Point(4, 22);
            this.tabPageYearlyBusiness.Name = "tabPageYearlyBusiness";
            this.tabPageYearlyBusiness.Size = new System.Drawing.Size(258, 84);
            this.tabPageYearlyBusiness.TabIndex = 4;
            this.tabPageYearlyBusiness.Text = "tabPage3";
            // 
            // dtmYearlyBusiness
            // 
            this.dtmYearlyBusiness.CustomFormat = "yyyy";
            this.dtmYearlyBusiness.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmYearlyBusiness.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmYearlyBusiness.Location = new System.Drawing.Point(153, 13);
            this.dtmYearlyBusiness.Name = "dtmYearlyBusiness";
            this.dtmYearlyBusiness.Size = new System.Drawing.Size(100, 24);
            this.dtmYearlyBusiness.TabIndex = 6;
            this.dtmYearlyBusiness.ValueChanged += new System.EventHandler(this.dtmYearlyBusiness_ValueChanged);
            // 
            // FormReportsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(618, 112);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rdoApplicationVolume);
            this.Controls.Add(this.rdoYearlyBusiness);
            this.Controls.Add(this.rdoMonthlyScreener);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMakeReport);
            this.Controls.Add(this.tabReports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReportsMenu";
            this.Text = "FormReportMenu";
            this.Load += new System.EventHandler(this.FormReportsMenu_Load);
            this.tabReports.ResumeLayout(false);
            this.tabPageMonthlyScreener.ResumeLayout(false);
            this.tabPageMonthlyScreener.PerformLayout();
            this.tabPageApplicationVolume.ResumeLayout(false);
            this.tabPageYearlyBusiness.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoYearlyBusiness;
        private System.Windows.Forms.RadioButton rdoMonthlyScreener;
        private System.Windows.Forms.TabPage tabPageYearlyBusiness;
        private System.Windows.Forms.DateTimePicker dtmYearlyBusiness;
        private System.Windows.Forms.Button btnMakeReport;
        private ExtendControls.TablessTabControl tabReports;
        private System.Windows.Forms.TabPage tabPageMonthlyScreener;
        private System.Windows.Forms.DateTimePicker dtmMonthlyScreener;
        private System.Windows.Forms.Label lblMonthlyScreenerOn;
        private System.Windows.Forms.ComboBox cboUsername;
        private System.Windows.Forms.TabPage tabPageApplicationVolume;
        private System.Windows.Forms.DateTimePicker dtmApplicationVolume;
        private System.Windows.Forms.RadioButton rdoApplicationVolume;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

    }
}