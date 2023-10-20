namespace PaaApplication.Forms.Invoicing
{
    partial class FormInvSearchApps
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
            this.grpAppsReceived = new System.Windows.Forms.GroupBox();
            this.dtmAppsReceivedTo = new System.Windows.Forms.DateTimePicker();
            this.dtmAppsReceivedFrom = new System.Windows.Forms.DateTimePicker();
            this.lblReceivedBetween = new System.Windows.Forms.Label();
            this.rdoAppsReceivedBetween = new System.Windows.Forms.RadioButton();
            this.rdoAppsReceivedMonth = new System.Windows.Forms.RadioButton();
            this.rdoClientsAND = new System.Windows.Forms.RadioButton();
            this.lblOneOfReportTypes = new System.Windows.Forms.Label();
            this.rdoReportTypesOR = new System.Windows.Forms.RadioButton();
            this.txtCustomSQLConditions = new System.Windows.Forms.TextBox();
            this.lblCustomSQLQuery = new System.Windows.Forms.Label();
            this.lblCustomSQLDescription = new System.Windows.Forms.Label();
            this.chkCustomSQL = new System.Windows.Forms.CheckBox();
            this.rdoReportTypesAND = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboSearchIn = new System.Windows.Forms.ComboBox();
            this.grpReportTypes = new System.Windows.Forms.GroupBox();
            this.lboxReportTypes = new System.Windows.Forms.CheckedListBox();
            this.lblFromClients = new System.Windows.Forms.Label();
            this.grpClients = new System.Windows.Forms.GroupBox();
            this.lboxClients = new System.Windows.Forms.CheckedListBox();
            this.rdoClientsOR = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpCustomSQL = new System.Windows.Forms.GroupBox();
            this.lstColumns = new System.Windows.Forms.ListBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.cboKeyword = new System.Windows.Forms.ComboBox();
            this.grpAppsReceived.SuspendLayout();
            this.grpReportTypes.SuspendLayout();
            this.grpClients.SuspendLayout();
            this.grpCustomSQL.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAppsReceived
            // 
            this.grpAppsReceived.BackColor = System.Drawing.SystemColors.Control;
            this.grpAppsReceived.Controls.Add(this.dtmAppsReceivedTo);
            this.grpAppsReceived.Controls.Add(this.dtmAppsReceivedFrom);
            this.grpAppsReceived.Controls.Add(this.lblReceivedBetween);
            this.grpAppsReceived.Controls.Add(this.rdoAppsReceivedBetween);
            this.grpAppsReceived.Controls.Add(this.rdoAppsReceivedMonth);
            this.grpAppsReceived.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAppsReceived.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpAppsReceived.Location = new System.Drawing.Point(4, 7);
            this.grpAppsReceived.Name = "grpAppsReceived";
            this.grpAppsReceived.Size = new System.Drawing.Size(573, 86);
            this.grpAppsReceived.TabIndex = 1;
            this.grpAppsReceived.TabStop = false;
            this.grpAppsReceived.Text = "Show me the applications received ";
            // 
            // dtmAppsReceivedTo
            // 
            this.dtmAppsReceivedTo.CalendarFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmAppsReceivedTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtmAppsReceivedTo.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtmAppsReceivedTo.CalendarTitleForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtmAppsReceivedTo.CustomFormat = "MM / dd / yy";
            this.dtmAppsReceivedTo.Enabled = false;
            this.dtmAppsReceivedTo.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmAppsReceivedTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmAppsReceivedTo.Location = new System.Drawing.Point(258, 51);
            this.dtmAppsReceivedTo.MaxDate = new System.DateTime(2099, 12, 1, 0, 0, 0, 0);
            this.dtmAppsReceivedTo.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dtmAppsReceivedTo.Name = "dtmAppsReceivedTo";
            this.dtmAppsReceivedTo.Size = new System.Drawing.Size(107, 24);
            this.dtmAppsReceivedTo.TabIndex = 4;
            // 
            // dtmAppsReceivedFrom
            // 
            this.dtmAppsReceivedFrom.CalendarFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmAppsReceivedFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtmAppsReceivedFrom.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtmAppsReceivedFrom.CalendarTitleForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtmAppsReceivedFrom.CustomFormat = "MM / dd / yy";
            this.dtmAppsReceivedFrom.Enabled = false;
            this.dtmAppsReceivedFrom.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmAppsReceivedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmAppsReceivedFrom.Location = new System.Drawing.Point(113, 51);
            this.dtmAppsReceivedFrom.MaxDate = new System.DateTime(2099, 12, 1, 0, 0, 0, 0);
            this.dtmAppsReceivedFrom.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dtmAppsReceivedFrom.Name = "dtmAppsReceivedFrom";
            this.dtmAppsReceivedFrom.Size = new System.Drawing.Size(107, 24);
            this.dtmAppsReceivedFrom.TabIndex = 3;
            // 
            // lblReceivedBetween
            // 
            this.lblReceivedBetween.AutoSize = true;
            this.lblReceivedBetween.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivedBetween.Location = new System.Drawing.Point(223, 56);
            this.lblReceivedBetween.Name = "lblReceivedBetween";
            this.lblReceivedBetween.Size = new System.Drawing.Size(30, 15);
            this.lblReceivedBetween.TabIndex = 1;
            this.lblReceivedBetween.Text = "AND";
            // 
            // rdoAppsReceivedBetween
            // 
            this.rdoAppsReceivedBetween.AutoSize = true;
            this.rdoAppsReceivedBetween.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAppsReceivedBetween.Location = new System.Drawing.Point(31, 54);
            this.rdoAppsReceivedBetween.Name = "rdoAppsReceivedBetween";
            this.rdoAppsReceivedBetween.Size = new System.Drawing.Size(81, 19);
            this.rdoAppsReceivedBetween.TabIndex = 2;
            this.rdoAppsReceivedBetween.Text = "BETWEEN:";
            this.rdoAppsReceivedBetween.UseVisualStyleBackColor = true;
            this.rdoAppsReceivedBetween.CheckedChanged += new System.EventHandler(this.rdoAppsReceived_CheckedChanged);
            // 
            // rdoAppsReceivedMonth
            // 
            this.rdoAppsReceivedMonth.AutoSize = true;
            this.rdoAppsReceivedMonth.Checked = true;
            this.rdoAppsReceivedMonth.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAppsReceivedMonth.Location = new System.Drawing.Point(31, 26);
            this.rdoAppsReceivedMonth.Name = "rdoAppsReceivedMonth";
            this.rdoAppsReceivedMonth.Size = new System.Drawing.Size(115, 20);
            this.rdoAppsReceivedMonth.TabIndex = 1;
            this.rdoAppsReceivedMonth.TabStop = true;
            this.rdoAppsReceivedMonth.Text = "Received Month";
            this.rdoAppsReceivedMonth.UseVisualStyleBackColor = true;
            this.rdoAppsReceivedMonth.CheckedChanged += new System.EventHandler(this.rdoAppsReceived_CheckedChanged);
            // 
            // rdoClientsAND
            // 
            this.rdoClientsAND.AutoSize = true;
            this.rdoClientsAND.BackColor = System.Drawing.SystemColors.Control;
            this.rdoClientsAND.Checked = true;
            this.rdoClientsAND.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoClientsAND.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoClientsAND.Location = new System.Drawing.Point(11, -3);
            this.rdoClientsAND.Name = "rdoClientsAND";
            this.rdoClientsAND.Size = new System.Drawing.Size(48, 19);
            this.rdoClientsAND.TabIndex = 5;
            this.rdoClientsAND.TabStop = true;
            this.rdoClientsAND.Text = "AND";
            this.rdoClientsAND.UseVisualStyleBackColor = false;
            // 
            // lblOneOfReportTypes
            // 
            this.lblOneOfReportTypes.AutoSize = true;
            this.lblOneOfReportTypes.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOneOfReportTypes.Location = new System.Drawing.Point(4, 19);
            this.lblOneOfReportTypes.Name = "lblOneOfReportTypes";
            this.lblOneOfReportTypes.Size = new System.Drawing.Size(192, 16);
            this.lblOneOfReportTypes.TabIndex = 10;
            this.lblOneOfReportTypes.Text = "are one of these report types";
            // 
            // rdoReportTypesOR
            // 
            this.rdoReportTypesOR.AutoSize = true;
            this.rdoReportTypesOR.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReportTypesOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoReportTypesOR.Location = new System.Drawing.Point(71, -3);
            this.rdoReportTypesOR.Name = "rdoReportTypesOR";
            this.rdoReportTypesOR.Size = new System.Drawing.Size(42, 19);
            this.rdoReportTypesOR.TabIndex = 9;
            this.rdoReportTypesOR.Text = "OR";
            this.rdoReportTypesOR.UseVisualStyleBackColor = true;
            // 
            // txtCustomSQLConditions
            // 
            this.txtCustomSQLConditions.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomSQLConditions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCustomSQLConditions.Location = new System.Drawing.Point(21, 81);
            this.txtCustomSQLConditions.Name = "txtCustomSQLConditions";
            this.txtCustomSQLConditions.Size = new System.Drawing.Size(322, 24);
            this.txtCustomSQLConditions.TabIndex = 14;
            // 
            // lblCustomSQLQuery
            // 
            this.lblCustomSQLQuery.AutoSize = true;
            this.lblCustomSQLQuery.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomSQLQuery.Location = new System.Drawing.Point(19, 58);
            this.lblCustomSQLQuery.Name = "lblCustomSQLQuery";
            this.lblCustomSQLQuery.Size = new System.Drawing.Size(238, 16);
            this.lblCustomSQLQuery.TabIndex = 2;
            this.lblCustomSQLQuery.Text = "Select * FROM Applications WHERE";
            // 
            // lblCustomSQLDescription
            // 
            this.lblCustomSQLDescription.AutoSize = true;
            this.lblCustomSQLDescription.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomSQLDescription.Location = new System.Drawing.Point(19, 26);
            this.lblCustomSQLDescription.Name = "lblCustomSQLDescription";
            this.lblCustomSQLDescription.Size = new System.Drawing.Size(210, 16);
            this.lblCustomSQLDescription.TabIndex = 1;
            this.lblCustomSQLDescription.Text = "Type your query in the text box below";
            // 
            // chkCustomSQL
            // 
            this.chkCustomSQL.AutoSize = true;
            this.chkCustomSQL.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustomSQL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkCustomSQL.Location = new System.Drawing.Point(7, -1);
            this.chkCustomSQL.Name = "chkCustomSQL";
            this.chkCustomSQL.Size = new System.Drawing.Size(150, 19);
            this.chkCustomSQL.TabIndex = 13;
            this.chkCustomSQL.Text = "CUSTOM SQL QUERY...";
            this.chkCustomSQL.UseVisualStyleBackColor = true;
            // 
            // rdoReportTypesAND
            // 
            this.rdoReportTypesAND.AutoSize = true;
            this.rdoReportTypesAND.Checked = true;
            this.rdoReportTypesAND.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReportTypesAND.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoReportTypesAND.Location = new System.Drawing.Point(9, -3);
            this.rdoReportTypesAND.Name = "rdoReportTypesAND";
            this.rdoReportTypesAND.Size = new System.Drawing.Size(48, 19);
            this.rdoReportTypesAND.TabIndex = 8;
            this.rdoReportTypesAND.TabStop = true;
            this.rdoReportTypesAND.Text = "AND";
            this.rdoReportTypesAND.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(506, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 29);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboSearchIn
            // 
            this.cboSearchIn.BackColor = System.Drawing.SystemColors.Window;
            this.cboSearchIn.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboSearchIn.FormattingEnabled = true;
            this.cboSearchIn.Location = new System.Drawing.Point(368, 340);
            this.cboSearchIn.Name = "cboSearchIn";
            this.cboSearchIn.Size = new System.Drawing.Size(203, 24);
            this.cboSearchIn.TabIndex = 12;
            this.cboSearchIn.SelectedIndexChanged += new System.EventHandler(this.cboSearchIn_SelectedIndexChanged);
            this.cboSearchIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSearchIn_KeyPress);
            // 
            // grpReportTypes
            // 
            this.grpReportTypes.BackColor = System.Drawing.SystemColors.Control;
            this.grpReportTypes.Controls.Add(this.lboxReportTypes);
            this.grpReportTypes.Controls.Add(this.rdoReportTypesAND);
            this.grpReportTypes.Controls.Add(this.lblOneOfReportTypes);
            this.grpReportTypes.Controls.Add(this.rdoReportTypesOR);
            this.grpReportTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReportTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpReportTypes.Location = new System.Drawing.Point(362, 104);
            this.grpReportTypes.Name = "grpReportTypes";
            this.grpReportTypes.Size = new System.Drawing.Size(215, 197);
            this.grpReportTypes.TabIndex = 3;
            this.grpReportTypes.TabStop = false;
            this.grpReportTypes.Text = "                ";
            // 
            // lboxReportTypes
            // 
            this.lboxReportTypes.CheckOnClick = true;
            this.lboxReportTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxReportTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lboxReportTypes.FormattingEnabled = true;
            this.lboxReportTypes.Location = new System.Drawing.Point(9, 43);
            this.lboxReportTypes.Name = "lboxReportTypes";
            this.lboxReportTypes.Size = new System.Drawing.Size(200, 148);
            this.lboxReportTypes.TabIndex = 10;
            // 
            // lblFromClients
            // 
            this.lblFromClients.AutoSize = true;
            this.lblFromClients.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromClients.Location = new System.Drawing.Point(4, 19);
            this.lblFromClients.Name = "lblFromClients";
            this.lblFromClients.Size = new System.Drawing.Size(188, 16);
            this.lblFromClients.TabIndex = 6;
            this.lblFromClients.Text = "that are from these Client(s)";
            // 
            // grpClients
            // 
            this.grpClients.BackColor = System.Drawing.SystemColors.Control;
            this.grpClients.Controls.Add(this.lboxClients);
            this.grpClients.Controls.Add(this.lblFromClients);
            this.grpClients.Controls.Add(this.rdoClientsOR);
            this.grpClients.Controls.Add(this.rdoClientsAND);
            this.grpClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpClients.Location = new System.Drawing.Point(5, 105);
            this.grpClients.Name = "grpClients";
            this.grpClients.Size = new System.Drawing.Size(350, 260);
            this.grpClients.TabIndex = 2;
            this.grpClients.TabStop = false;
            this.grpClients.Text = "               ";
            // 
            // lboxClients
            // 
            this.lboxClients.CheckOnClick = true;
            this.lboxClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lboxClients.FormattingEnabled = true;
            this.lboxClients.Location = new System.Drawing.Point(9, 42);
            this.lboxClients.Name = "lboxClients";
            this.lboxClients.Size = new System.Drawing.Size(332, 212);
            this.lboxClients.TabIndex = 7;
            this.lboxClients.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lboxClients_KeyPress);
            // 
            // rdoClientsOR
            // 
            this.rdoClientsOR.AutoSize = true;
            this.rdoClientsOR.BackColor = System.Drawing.SystemColors.Control;
            this.rdoClientsOR.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoClientsOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoClientsOR.Location = new System.Drawing.Point(73, -3);
            this.rdoClientsOR.Name = "rdoClientsOR";
            this.rdoClientsOR.Size = new System.Drawing.Size(42, 19);
            this.rdoClientsOR.TabIndex = 6;
            this.rdoClientsOR.Text = "OR";
            this.rdoClientsOR.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Gray;
            this.btnSearch.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(429, 510);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 29);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpCustomSQL
            // 
            this.grpCustomSQL.BackColor = System.Drawing.SystemColors.Control;
            this.grpCustomSQL.Controls.Add(this.lstColumns);
            this.grpCustomSQL.Controls.Add(this.txtCustomSQLConditions);
            this.grpCustomSQL.Controls.Add(this.lblCustomSQLQuery);
            this.grpCustomSQL.Controls.Add(this.lblCustomSQLDescription);
            this.grpCustomSQL.Controls.Add(this.chkCustomSQL);
            this.grpCustomSQL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpCustomSQL.Location = new System.Drawing.Point(5, 376);
            this.grpCustomSQL.Name = "grpCustomSQL";
            this.grpCustomSQL.Size = new System.Drawing.Size(573, 127);
            this.grpCustomSQL.TabIndex = 4;
            this.grpCustomSQL.TabStop = false;
            // 
            // lstColumns
            // 
            this.lstColumns.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstColumns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.ItemHeight = 16;
            this.lstColumns.Location = new System.Drawing.Point(392, 17);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(175, 100);
            this.lstColumns.TabIndex = 15;
            // 
            // txtKeyword
            // 
            this.txtKeyword.BackColor = System.Drawing.SystemColors.Window;
            this.txtKeyword.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtKeyword.Location = new System.Drawing.Point(368, 307);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(203, 24);
            this.txtKeyword.TabIndex = 11;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlMain.Controls.Add(this.cboKeyword);
            this.pnlMain.Controls.Add(this.btnSearch);
            this.pnlMain.Controls.Add(this.grpAppsReceived);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.txtKeyword);
            this.pnlMain.Controls.Add(this.cboSearchIn);
            this.pnlMain.Controls.Add(this.grpReportTypes);
            this.pnlMain.Location = new System.Drawing.Point(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(585, 548);
            this.pnlMain.TabIndex = 2;
            // 
            // cboKeyword
            // 
            this.cboKeyword.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.cboKeyword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboKeyword.FormattingEnabled = true;
            this.cboKeyword.Location = new System.Drawing.Point(368, 307);
            this.cboKeyword.Name = "cboKeyword";
            this.cboKeyword.Size = new System.Drawing.Size(203, 24);
            this.cboKeyword.TabIndex = 11;
            this.cboKeyword.TextChanged += new System.EventHandler(this.cboKeyword_TextChanged);
            this.cboKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboKeyword_KeyPress);
            // 
            // FormInvSearchApps
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(587, 550);
            this.Controls.Add(this.grpClients);
            this.Controls.Add(this.grpCustomSQL);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInvSearchApps";
            this.Text = "FormSearchApps";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormSearchApps_LoadCompleted);
            this.VisibleChanged += new System.EventHandler(this.FormInvSearchApps_VisibleChanged);
            this.grpAppsReceived.ResumeLayout(false);
            this.grpAppsReceived.PerformLayout();
            this.grpReportTypes.ResumeLayout(false);
            this.grpReportTypes.PerformLayout();
            this.grpClients.ResumeLayout(false);
            this.grpClients.PerformLayout();
            this.grpCustomSQL.ResumeLayout(false);
            this.grpCustomSQL.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAppsReceived;
        private System.Windows.Forms.DateTimePicker dtmAppsReceivedTo;
        private System.Windows.Forms.DateTimePicker dtmAppsReceivedFrom;
        private System.Windows.Forms.Label lblReceivedBetween;
        private System.Windows.Forms.RadioButton rdoAppsReceivedBetween;
        private System.Windows.Forms.RadioButton rdoAppsReceivedMonth;
        private System.Windows.Forms.RadioButton rdoClientsAND;
        private System.Windows.Forms.Label lblOneOfReportTypes;
        private System.Windows.Forms.RadioButton rdoReportTypesOR;
        private System.Windows.Forms.TextBox txtCustomSQLConditions;
        private System.Windows.Forms.Label lblCustomSQLQuery;
        private System.Windows.Forms.Label lblCustomSQLDescription;
        private System.Windows.Forms.CheckBox chkCustomSQL;
        private System.Windows.Forms.RadioButton rdoReportTypesAND;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboSearchIn;
        private System.Windows.Forms.GroupBox grpReportTypes;
        private System.Windows.Forms.Label lblFromClients;
        private System.Windows.Forms.GroupBox grpClients;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdoClientsOR;
        private System.Windows.Forms.GroupBox grpCustomSQL;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.CheckedListBox lboxClients;
        private System.Windows.Forms.CheckedListBox lboxReportTypes;
        private System.Windows.Forms.ListBox lstColumns;
        private System.Windows.Forms.ComboBox cboKeyword;

    }
}