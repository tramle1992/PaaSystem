namespace PaaApplication.Forms
{
    partial class FormDocumentsMenu
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
            this.btnMakeDocument = new System.Windows.Forms.Button();
            this.rdoCalendar = new System.Windows.Forms.RadioButton();
            this.rdoReceiptLog = new System.Windows.Forms.RadioButton();
            this.rdoDailyReport = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabDocuments = new PaaApplication.ExtendControls.TablessTabControl();
            this.tabPageDailyReport = new System.Windows.Forms.TabPage();
            this.dtmDailyReport = new System.Windows.Forms.DateTimePicker();
            this.lblDailyReportOn = new System.Windows.Forms.Label();
            this.cboUsername = new System.Windows.Forms.ComboBox();
            this.tabPageReceiptLog = new System.Windows.Forms.TabPage();
            this.dtmReceiptLogTo = new System.Windows.Forms.DateTimePicker();
            this.lblReceiptLogTo = new System.Windows.Forms.Label();
            this.lblReceiptLogFrom = new System.Windows.Forms.Label();
            this.dtmReceiptLogFrom = new System.Windows.Forms.DateTimePicker();
            this.cboClientName = new System.Windows.Forms.ComboBox();
            this.tabPageCalendar = new System.Windows.Forms.TabPage();
            this.dtmCalendarTo = new System.Windows.Forms.DateTimePicker();
            this.lblCalendarTo = new System.Windows.Forms.Label();
            this.lblCalendarFrom = new System.Windows.Forms.Label();
            this.dtmCalendarFrom = new System.Windows.Forms.DateTimePicker();
            this.tabDocuments.SuspendLayout();
            this.tabPageDailyReport.SuspendLayout();
            this.tabPageReceiptLog.SuspendLayout();
            this.tabPageCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMakeDocument
            // 
            this.btnMakeDocument.BackColor = System.Drawing.Color.DarkGray;
            this.btnMakeDocument.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeDocument.ForeColor = System.Drawing.Color.White;
            this.btnMakeDocument.Location = new System.Drawing.Point(337, 91);
            this.btnMakeDocument.Name = "btnMakeDocument";
            this.btnMakeDocument.Size = new System.Drawing.Size(136, 29);
            this.btnMakeDocument.TabIndex = 10;
            this.btnMakeDocument.Text = "Make Document";
            this.btnMakeDocument.UseVisualStyleBackColor = false;
            this.btnMakeDocument.Click += new System.EventHandler(this.btnMakeDocument_Click);
            // 
            // rdoCalendar
            // 
            this.rdoCalendar.AutoSize = true;
            this.rdoCalendar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rdoCalendar.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCalendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoCalendar.Location = new System.Drawing.Point(14, 79);
            this.rdoCalendar.Name = "rdoCalendar";
            this.rdoCalendar.Size = new System.Drawing.Size(84, 19);
            this.rdoCalendar.TabIndex = 2;
            this.rdoCalendar.Text = "CALENDAR";
            this.rdoCalendar.UseVisualStyleBackColor = false;
            this.rdoCalendar.CheckedChanged += new System.EventHandler(this.rdoCalendar_CheckedChanged);
            // 
            // rdoReceiptLog
            // 
            this.rdoReceiptLog.AutoSize = true;
            this.rdoReceiptLog.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rdoReceiptLog.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReceiptLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoReceiptLog.Location = new System.Drawing.Point(14, 49);
            this.rdoReceiptLog.Name = "rdoReceiptLog";
            this.rdoReceiptLog.Size = new System.Drawing.Size(102, 19);
            this.rdoReceiptLog.TabIndex = 1;
            this.rdoReceiptLog.Text = "RECEIPT  LOG";
            this.rdoReceiptLog.UseVisualStyleBackColor = false;
            this.rdoReceiptLog.CheckedChanged += new System.EventHandler(this.rdoReceiptLog_CheckedChanged);
            // 
            // rdoDailyReport
            // 
            this.rdoDailyReport.AutoSize = true;
            this.rdoDailyReport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rdoDailyReport.Checked = true;
            this.rdoDailyReport.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDailyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoDailyReport.Location = new System.Drawing.Point(14, 18);
            this.rdoDailyReport.Name = "rdoDailyReport";
            this.rdoDailyReport.Size = new System.Drawing.Size(108, 19);
            this.rdoDailyReport.TabIndex = 0;
            this.rdoDailyReport.TabStop = true;
            this.rdoDailyReport.Text = "DAILY  REPORT";
            this.rdoDailyReport.UseVisualStyleBackColor = false;
            this.rdoDailyReport.CheckedChanged += new System.EventHandler(this.rdoDailyReport_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 131);
            this.panel1.TabIndex = 101;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Location = new System.Drawing.Point(129, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 131);
            this.panel2.TabIndex = 102;
            // 
            // tabDocuments
            // 
            this.tabDocuments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabDocuments.Controls.Add(this.tabPageDailyReport);
            this.tabDocuments.Controls.Add(this.tabPageReceiptLog);
            this.tabDocuments.Controls.Add(this.tabPageCalendar);
            this.tabDocuments.Location = new System.Drawing.Point(128, 1);
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.SelectedIndex = 0;
            this.tabDocuments.Size = new System.Drawing.Size(367, 131);
            this.tabDocuments.TabIndex = 100;
            // 
            // tabPageDailyReport
            // 
            this.tabPageDailyReport.BackColor = System.Drawing.Color.White;
            this.tabPageDailyReport.Controls.Add(this.dtmDailyReport);
            this.tabPageDailyReport.Controls.Add(this.lblDailyReportOn);
            this.tabPageDailyReport.Controls.Add(this.cboUsername);
            this.tabPageDailyReport.Location = new System.Drawing.Point(4, 22);
            this.tabPageDailyReport.Name = "tabPageDailyReport";
            this.tabPageDailyReport.Size = new System.Drawing.Size(359, 105);
            this.tabPageDailyReport.TabIndex = 2;
            this.tabPageDailyReport.Text = "tabPage1";
            // 
            // dtmDailyReport
            // 
            this.dtmDailyReport.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmDailyReport.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtmDailyReport.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtmDailyReport.CalendarTitleForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtmDailyReport.CustomFormat = "MM/dd/yyyy";
            this.dtmDailyReport.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmDailyReport.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmDailyReport.Location = new System.Drawing.Point(230, 15);
            this.dtmDailyReport.Name = "dtmDailyReport";
            this.dtmDailyReport.Size = new System.Drawing.Size(115, 24);
            this.dtmDailyReport.TabIndex = 4;
            // 
            // lblDailyReportOn
            // 
            this.lblDailyReportOn.AutoSize = true;
            this.lblDailyReportOn.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailyReportOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDailyReportOn.Location = new System.Drawing.Point(202, 20);
            this.lblDailyReportOn.Name = "lblDailyReportOn";
            this.lblDailyReportOn.Size = new System.Drawing.Size(24, 15);
            this.lblDailyReportOn.TabIndex = 100;
            this.lblDailyReportOn.Text = "ON";
            // 
            // cboUsername
            // 
            this.cboUsername.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboUsername.FormattingEnabled = true;
            this.cboUsername.Items.AddRange(new object[] {
            "JadeUsername",
            "KenUsername",
            "LukeUsername",
            "QuinUsername",
            "TroyUsername",
            "VinceUsername"});
            this.cboUsername.Location = new System.Drawing.Point(16, 15);
            this.cboUsername.Name = "cboUsername";
            this.cboUsername.Size = new System.Drawing.Size(180, 24);
            this.cboUsername.TabIndex = 3;
            this.cboUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboUsername_KeyPress);
            // 
            // tabPageReceiptLog
            // 
            this.tabPageReceiptLog.BackColor = System.Drawing.Color.White;
            this.tabPageReceiptLog.Controls.Add(this.dtmReceiptLogTo);
            this.tabPageReceiptLog.Controls.Add(this.lblReceiptLogTo);
            this.tabPageReceiptLog.Controls.Add(this.lblReceiptLogFrom);
            this.tabPageReceiptLog.Controls.Add(this.dtmReceiptLogFrom);
            this.tabPageReceiptLog.Controls.Add(this.cboClientName);
            this.tabPageReceiptLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageReceiptLog.Name = "tabPageReceiptLog";
            this.tabPageReceiptLog.Size = new System.Drawing.Size(359, 105);
            this.tabPageReceiptLog.TabIndex = 3;
            this.tabPageReceiptLog.Text = "tabPage2";
            // 
            // dtmReceiptLogTo
            // 
            this.dtmReceiptLogTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmReceiptLogTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtmReceiptLogTo.CustomFormat = "MM/dd/yyyy";
            this.dtmReceiptLogTo.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmReceiptLogTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmReceiptLogTo.Location = new System.Drawing.Point(230, 53);
            this.dtmReceiptLogTo.Name = "dtmReceiptLogTo";
            this.dtmReceiptLogTo.Size = new System.Drawing.Size(115, 24);
            this.dtmReceiptLogTo.TabIndex = 7;
            this.dtmReceiptLogTo.ValueChanged += new System.EventHandler(this.dtmReceiptLogTo_ValueChanged);
            // 
            // lblReceiptLogTo
            // 
            this.lblReceiptLogTo.AutoSize = true;
            this.lblReceiptLogTo.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptLogTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReceiptLogTo.Location = new System.Drawing.Point(204, 57);
            this.lblReceiptLogTo.Name = "lblReceiptLogTo";
            this.lblReceiptLogTo.Size = new System.Drawing.Size(26, 15);
            this.lblReceiptLogTo.TabIndex = 100;
            this.lblReceiptLogTo.Text = "TO:";
            // 
            // lblReceiptLogFrom
            // 
            this.lblReceiptLogFrom.AutoSize = true;
            this.lblReceiptLogFrom.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptLogFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReceiptLogFrom.Location = new System.Drawing.Point(14, 57);
            this.lblReceiptLogFrom.Name = "lblReceiptLogFrom";
            this.lblReceiptLogFrom.Size = new System.Drawing.Size(43, 15);
            this.lblReceiptLogFrom.TabIndex = 100;
            this.lblReceiptLogFrom.Text = "FROM:";
            // 
            // dtmReceiptLogFrom
            // 
            this.dtmReceiptLogFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmReceiptLogFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtmReceiptLogFrom.CustomFormat = "MM/dd/yyyy";
            this.dtmReceiptLogFrom.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmReceiptLogFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmReceiptLogFrom.Location = new System.Drawing.Point(59, 54);
            this.dtmReceiptLogFrom.Name = "dtmReceiptLogFrom";
            this.dtmReceiptLogFrom.Size = new System.Drawing.Size(115, 24);
            this.dtmReceiptLogFrom.TabIndex = 6;
            this.dtmReceiptLogFrom.ValueChanged += new System.EventHandler(this.dtmReceiptLogFrom_ValueChanged);
            // 
            // cboClientName
            // 
            this.cboClientName.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboClientName.FormattingEnabled = true;
            this.cboClientName.Items.AddRange(new object[] {
            "KenClient",
            "LukeClient",
            "TroyClient",
            "VinceClient",
            "JadeClient",
            "QuinClient"});
            this.cboClientName.Location = new System.Drawing.Point(17, 15);
            this.cboClientName.Name = "cboClientName";
            this.cboClientName.Size = new System.Drawing.Size(328, 24);
            this.cboClientName.TabIndex = 5;
            this.cboClientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboClientName_KeyPress);
            // 
            // tabPageCalendar
            // 
            this.tabPageCalendar.BackColor = System.Drawing.Color.White;
            this.tabPageCalendar.Controls.Add(this.dtmCalendarTo);
            this.tabPageCalendar.Controls.Add(this.lblCalendarTo);
            this.tabPageCalendar.Controls.Add(this.lblCalendarFrom);
            this.tabPageCalendar.Controls.Add(this.dtmCalendarFrom);
            this.tabPageCalendar.Location = new System.Drawing.Point(4, 22);
            this.tabPageCalendar.Name = "tabPageCalendar";
            this.tabPageCalendar.Size = new System.Drawing.Size(359, 105);
            this.tabPageCalendar.TabIndex = 4;
            this.tabPageCalendar.Text = "tabPage3";
            // 
            // dtmCalendarTo
            // 
            this.dtmCalendarTo.CustomFormat = "MM / yyyy";
            this.dtmCalendarTo.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmCalendarTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmCalendarTo.Location = new System.Drawing.Point(245, 15);
            this.dtmCalendarTo.Name = "dtmCalendarTo";
            this.dtmCalendarTo.Size = new System.Drawing.Size(100, 24);
            this.dtmCalendarTo.TabIndex = 9;
            this.dtmCalendarTo.ValueChanged += new System.EventHandler(this.dtmCalendarTo_ValueChanged);
            // 
            // lblCalendarTo
            // 
            this.lblCalendarTo.AutoSize = true;
            this.lblCalendarTo.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalendarTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCalendarTo.Location = new System.Drawing.Point(217, 19);
            this.lblCalendarTo.Name = "lblCalendarTo";
            this.lblCalendarTo.Size = new System.Drawing.Size(26, 15);
            this.lblCalendarTo.TabIndex = 100;
            this.lblCalendarTo.Text = "TO:";
            // 
            // lblCalendarFrom
            // 
            this.lblCalendarFrom.AutoSize = true;
            this.lblCalendarFrom.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalendarFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCalendarFrom.Location = new System.Drawing.Point(12, 19);
            this.lblCalendarFrom.Name = "lblCalendarFrom";
            this.lblCalendarFrom.Size = new System.Drawing.Size(43, 15);
            this.lblCalendarFrom.TabIndex = 100;
            this.lblCalendarFrom.Text = "FROM:";
            // 
            // dtmCalendarFrom
            // 
            this.dtmCalendarFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmCalendarFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtmCalendarFrom.CustomFormat = "MM / yyyy";
            this.dtmCalendarFrom.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmCalendarFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmCalendarFrom.Location = new System.Drawing.Point(57, 15);
            this.dtmCalendarFrom.Name = "dtmCalendarFrom";
            this.dtmCalendarFrom.Size = new System.Drawing.Size(100, 24);
            this.dtmCalendarFrom.TabIndex = 8;
            this.dtmCalendarFrom.ValueChanged += new System.EventHandler(this.dtmCalendarFrom_ValueChanged);
            // 
            // FormDocumentsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(496, 133);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rdoCalendar);
            this.Controls.Add(this.rdoReceiptLog);
            this.Controls.Add(this.rdoDailyReport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMakeDocument);
            this.Controls.Add(this.tabDocuments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDocumentsMenu";
            this.Text = "FormDocumentMenu";
            this.Load += new System.EventHandler(this.frmDocumentsMenu_Load);
            this.tabDocuments.ResumeLayout(false);
            this.tabPageDailyReport.ResumeLayout(false);
            this.tabPageDailyReport.PerformLayout();
            this.tabPageReceiptLog.ResumeLayout(false);
            this.tabPageReceiptLog.PerformLayout();
            this.tabPageCalendar.ResumeLayout(false);
            this.tabPageCalendar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtmCalendarTo;
        private System.Windows.Forms.Label lblCalendarTo;
        private System.Windows.Forms.DateTimePicker dtmCalendarFrom;
        private System.Windows.Forms.DateTimePicker dtmReceiptLogFrom;
        private System.Windows.Forms.ComboBox cboClientName;
        private System.Windows.Forms.TabPage tabPageDailyReport;
        private System.Windows.Forms.DateTimePicker dtmDailyReport;
        private System.Windows.Forms.Label lblDailyReportOn;
        private System.Windows.Forms.ComboBox cboUsername;
        private System.Windows.Forms.DateTimePicker dtmReceiptLogTo;
        private System.Windows.Forms.Label lblReceiptLogTo;
        private System.Windows.Forms.Label lblReceiptLogFrom;
        private System.Windows.Forms.TabPage tabPageReceiptLog;
        private System.Windows.Forms.Button btnMakeDocument;
        private ExtendControls.TablessTabControl tabDocuments;
        private System.Windows.Forms.TabPage tabPageCalendar;
        private System.Windows.Forms.Label lblCalendarFrom;
        private System.Windows.Forms.RadioButton rdoCalendar;
        private System.Windows.Forms.RadioButton rdoReceiptLog;
        private System.Windows.Forms.RadioButton rdoDailyReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

    }
}