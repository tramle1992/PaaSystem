namespace PaaApplication.Forms.Invoicing
{
    partial class FormSearchInvs
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
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.cboSearchIn = new System.Windows.Forms.ComboBox();
            this.lblCustomSQLDescription = new System.Windows.Forms.Label();
            this.grpCustomSQL = new System.Windows.Forms.GroupBox();
            this.lstColumns = new System.Windows.Forms.ListBox();
            this.txtCustomSQLConditions = new System.Windows.Forms.TextBox();
            this.lblCustomSQLQuery = new System.Windows.Forms.Label();
            this.chkCustomSQL = new System.Windows.Forms.CheckBox();
            this.rdoStatusAND = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblInState = new System.Windows.Forms.Label();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lboxInvStatus = new System.Windows.Forms.CheckedListBox();
            this.rdoStatusOR = new System.Windows.Forms.RadioButton();
            this.rdoClientsAND = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblForClients = new System.Windows.Forms.Label();
            this.grpClients = new System.Windows.Forms.GroupBox();
            this.lboxClients = new System.Windows.Forms.CheckedListBox();
            this.rdoClientsOR = new System.Windows.Forms.RadioButton();
            this.grpInvsCreated = new System.Windows.Forms.GroupBox();
            this.dtmInvsCreatedTo = new System.Windows.Forms.DateTimePicker();
            this.dtmInvsCreatedFrom = new System.Windows.Forms.DateTimePicker();
            this.lblInvsCreatedBetween = new System.Windows.Forms.Label();
            this.rdoInvsCreatedBetween = new System.Windows.Forms.RadioButton();
            this.rdoInvsCreatedMonth2 = new System.Windows.Forms.RadioButton();
            this.rdoInvsCreatedMonth1 = new System.Windows.Forms.RadioButton();
            this.rdoInvsCreatedAnyTime = new System.Windows.Forms.RadioButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.cboKeyword = new System.Windows.Forms.ComboBox();
            this.grpCustomSQL.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.grpClients.SuspendLayout();
            this.grpInvsCreated.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtKeyword.Location = new System.Drawing.Point(352, 322);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(219, 24);
            this.txtKeyword.TabIndex = 11;
            // 
            // cboSearchIn
            // 
            this.cboSearchIn.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboSearchIn.FormattingEnabled = true;
            this.cboSearchIn.Location = new System.Drawing.Point(352, 349);
            this.cboSearchIn.Name = "cboSearchIn";
            this.cboSearchIn.Size = new System.Drawing.Size(219, 24);
            this.cboSearchIn.TabIndex = 12;
            this.cboSearchIn.SelectedIndexChanged += new System.EventHandler(this.cboSearchIn_SelectedIndexChanged);
            this.cboSearchIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSearchIn_KeyPress);
            // 
            // lblCustomSQLDescription
            // 
            this.lblCustomSQLDescription.AutoSize = true;
            this.lblCustomSQLDescription.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomSQLDescription.Location = new System.Drawing.Point(20, 26);
            this.lblCustomSQLDescription.Name = "lblCustomSQLDescription";
            this.lblCustomSQLDescription.Size = new System.Drawing.Size(210, 16);
            this.lblCustomSQLDescription.TabIndex = 0;
            this.lblCustomSQLDescription.Text = "Type your query in the text box below";
            // 
            // grpCustomSQL
            // 
            this.grpCustomSQL.Controls.Add(this.lstColumns);
            this.grpCustomSQL.Controls.Add(this.txtCustomSQLConditions);
            this.grpCustomSQL.Controls.Add(this.lblCustomSQLQuery);
            this.grpCustomSQL.Controls.Add(this.lblCustomSQLDescription);
            this.grpCustomSQL.Controls.Add(this.chkCustomSQL);
            this.grpCustomSQL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpCustomSQL.Location = new System.Drawing.Point(4, 382);
            this.grpCustomSQL.Name = "grpCustomSQL";
            this.grpCustomSQL.Size = new System.Drawing.Size(573, 125);
            this.grpCustomSQL.TabIndex = 41;
            this.grpCustomSQL.TabStop = false;
            // 
            // lstColumns
            // 
            this.lstColumns.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstColumns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstColumns.FormattingEnabled = true;
            this.lstColumns.ItemHeight = 16;
            this.lstColumns.Location = new System.Drawing.Point(392, 15);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(175, 100);
            this.lstColumns.TabIndex = 15;
            // 
            // txtCustomSQLConditions
            // 
            this.txtCustomSQLConditions.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomSQLConditions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCustomSQLConditions.Location = new System.Drawing.Point(23, 80);
            this.txtCustomSQLConditions.Name = "txtCustomSQLConditions";
            this.txtCustomSQLConditions.Size = new System.Drawing.Size(352, 24);
            this.txtCustomSQLConditions.TabIndex = 14;
            // 
            // lblCustomSQLQuery
            // 
            this.lblCustomSQLQuery.AutoSize = true;
            this.lblCustomSQLQuery.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomSQLQuery.Location = new System.Drawing.Point(20, 58);
            this.lblCustomSQLQuery.Name = "lblCustomSQLQuery";
            this.lblCustomSQLQuery.Size = new System.Drawing.Size(212, 16);
            this.lblCustomSQLQuery.TabIndex = 0;
            this.lblCustomSQLQuery.Text = "Select * FROM Invoices WHERE";
            // 
            // chkCustomSQL
            // 
            this.chkCustomSQL.AutoSize = true;
            this.chkCustomSQL.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustomSQL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkCustomSQL.Location = new System.Drawing.Point(8, -1);
            this.chkCustomSQL.Name = "chkCustomSQL";
            this.chkCustomSQL.Size = new System.Drawing.Size(150, 19);
            this.chkCustomSQL.TabIndex = 13;
            this.chkCustomSQL.Text = "CUSTOM SQL QUERY...";
            this.chkCustomSQL.UseVisualStyleBackColor = true;
            // 
            // rdoStatusAND
            // 
            this.rdoStatusAND.AutoSize = true;
            this.rdoStatusAND.Checked = true;
            this.rdoStatusAND.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStatusAND.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoStatusAND.Location = new System.Drawing.Point(10, -3);
            this.rdoStatusAND.Name = "rdoStatusAND";
            this.rdoStatusAND.Size = new System.Drawing.Size(48, 19);
            this.rdoStatusAND.TabIndex = 8;
            this.rdoStatusAND.TabStop = true;
            this.rdoStatusAND.Text = "AND";
            this.rdoStatusAND.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Gray;
            this.btnSearch.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(429, 513);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 29);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblInState
            // 
            this.lblInState.AutoSize = true;
            this.lblInState.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInState.Location = new System.Drawing.Point(5, 22);
            this.lblInState.Name = "lblInState";
            this.lblInState.Size = new System.Drawing.Size(186, 16);
            this.lblInState.TabIndex = 0;
            this.lblInState.Text = "are in this state of payment ";
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lboxInvStatus);
            this.grpStatus.Controls.Add(this.rdoStatusAND);
            this.grpStatus.Controls.Add(this.lblInState);
            this.grpStatus.Controls.Add(this.rdoStatusOR);
            this.grpStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpStatus.Location = new System.Drawing.Point(346, 101);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(231, 212);
            this.grpStatus.TabIndex = 0;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "                ";
            // 
            // lboxInvStatus
            // 
            this.lboxInvStatus.CheckOnClick = true;
            this.lboxInvStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxInvStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lboxInvStatus.FormattingEnabled = true;
            this.lboxInvStatus.Location = new System.Drawing.Point(14, 46);
            this.lboxInvStatus.Name = "lboxInvStatus";
            this.lboxInvStatus.Size = new System.Drawing.Size(199, 148);
            this.lboxInvStatus.TabIndex = 11;
            // 
            // rdoStatusOR
            // 
            this.rdoStatusOR.AutoSize = true;
            this.rdoStatusOR.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStatusOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoStatusOR.Location = new System.Drawing.Point(66, -3);
            this.rdoStatusOR.Name = "rdoStatusOR";
            this.rdoStatusOR.Size = new System.Drawing.Size(42, 19);
            this.rdoStatusOR.TabIndex = 9;
            this.rdoStatusOR.Text = "OR";
            this.rdoStatusOR.UseVisualStyleBackColor = true;
            // 
            // rdoClientsAND
            // 
            this.rdoClientsAND.AutoSize = true;
            this.rdoClientsAND.Checked = true;
            this.rdoClientsAND.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoClientsAND.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoClientsAND.Location = new System.Drawing.Point(6, -3);
            this.rdoClientsAND.Name = "rdoClientsAND";
            this.rdoClientsAND.Size = new System.Drawing.Size(48, 19);
            this.rdoClientsAND.TabIndex = 5;
            this.rdoClientsAND.TabStop = true;
            this.rdoClientsAND.Text = "AND";
            this.rdoClientsAND.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(506, 513);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 29);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblForClients
            // 
            this.lblForClients.AutoSize = true;
            this.lblForClients.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForClients.Location = new System.Drawing.Point(6, 22);
            this.lblForClients.Name = "lblForClients";
            this.lblForClients.Size = new System.Drawing.Size(190, 16);
            this.lblForClients.TabIndex = 0;
            this.lblForClients.Text = "that were for these Client(s) ";
            // 
            // grpClients
            // 
            this.grpClients.Controls.Add(this.lboxClients);
            this.grpClients.Controls.Add(this.rdoClientsOR);
            this.grpClients.Controls.Add(this.rdoClientsAND);
            this.grpClients.Controls.Add(this.lblForClients);
            this.grpClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpClients.Location = new System.Drawing.Point(3, 101);
            this.grpClients.Name = "grpClients";
            this.grpClients.Size = new System.Drawing.Size(334, 272);
            this.grpClients.TabIndex = 0;
            this.grpClients.TabStop = false;
            this.grpClients.Text = "               ";
            // 
            // lboxClients
            // 
            this.lboxClients.CheckOnClick = true;
            this.lboxClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lboxClients.FormattingEnabled = true;
            this.lboxClients.Location = new System.Drawing.Point(9, 46);
            this.lboxClients.Name = "lboxClients";
            this.lboxClients.Size = new System.Drawing.Size(319, 212);
            this.lboxClients.TabIndex = 12;
            this.lboxClients.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lboxClients_KeyPress);
            // 
            // rdoClientsOR
            // 
            this.rdoClientsOR.AutoSize = true;
            this.rdoClientsOR.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoClientsOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoClientsOR.Location = new System.Drawing.Point(62, -3);
            this.rdoClientsOR.Name = "rdoClientsOR";
            this.rdoClientsOR.Size = new System.Drawing.Size(42, 19);
            this.rdoClientsOR.TabIndex = 6;
            this.rdoClientsOR.Text = "OR";
            this.rdoClientsOR.UseVisualStyleBackColor = true;
            // 
            // grpInvsCreated
            // 
            this.grpInvsCreated.Controls.Add(this.dtmInvsCreatedTo);
            this.grpInvsCreated.Controls.Add(this.dtmInvsCreatedFrom);
            this.grpInvsCreated.Controls.Add(this.lblInvsCreatedBetween);
            this.grpInvsCreated.Controls.Add(this.rdoInvsCreatedBetween);
            this.grpInvsCreated.Controls.Add(this.rdoInvsCreatedMonth2);
            this.grpInvsCreated.Controls.Add(this.rdoInvsCreatedMonth1);
            this.grpInvsCreated.Controls.Add(this.rdoInvsCreatedAnyTime);
            this.grpInvsCreated.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInvsCreated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpInvsCreated.Location = new System.Drawing.Point(4, 7);
            this.grpInvsCreated.Name = "grpInvsCreated";
            this.grpInvsCreated.Size = new System.Drawing.Size(573, 85);
            this.grpInvsCreated.TabIndex = 0;
            this.grpInvsCreated.TabStop = false;
            this.grpInvsCreated.Text = "Show me the invoices created";
            // 
            // dtmInvsCreatedTo
            // 
            this.dtmInvsCreatedTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmInvsCreatedTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtmInvsCreatedTo.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtmInvsCreatedTo.CalendarTitleForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtmInvsCreatedTo.CustomFormat = "MM / yyyy";
            this.dtmInvsCreatedTo.Enabled = false;
            this.dtmInvsCreatedTo.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmInvsCreatedTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmInvsCreatedTo.Location = new System.Drawing.Point(259, 49);
            this.dtmInvsCreatedTo.MaxDate = new System.DateTime(2099, 12, 1, 0, 0, 0, 0);
            this.dtmInvsCreatedTo.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dtmInvsCreatedTo.Name = "dtmInvsCreatedTo";
            this.dtmInvsCreatedTo.Size = new System.Drawing.Size(107, 24);
            this.dtmInvsCreatedTo.TabIndex = 21;
            // 
            // dtmInvsCreatedFrom
            // 
            this.dtmInvsCreatedFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmInvsCreatedFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtmInvsCreatedFrom.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtmInvsCreatedFrom.CalendarTitleForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtmInvsCreatedFrom.CustomFormat = "MM / yyyy";
            this.dtmInvsCreatedFrom.Enabled = false;
            this.dtmInvsCreatedFrom.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmInvsCreatedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmInvsCreatedFrom.Location = new System.Drawing.Point(113, 49);
            this.dtmInvsCreatedFrom.MaxDate = new System.DateTime(2099, 12, 1, 0, 0, 0, 0);
            this.dtmInvsCreatedFrom.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dtmInvsCreatedFrom.Name = "dtmInvsCreatedFrom";
            this.dtmInvsCreatedFrom.Size = new System.Drawing.Size(107, 24);
            this.dtmInvsCreatedFrom.TabIndex = 20;
            // 
            // lblInvsCreatedBetween
            // 
            this.lblInvsCreatedBetween.AutoSize = true;
            this.lblInvsCreatedBetween.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvsCreatedBetween.Location = new System.Drawing.Point(225, 54);
            this.lblInvsCreatedBetween.Name = "lblInvsCreatedBetween";
            this.lblInvsCreatedBetween.Size = new System.Drawing.Size(30, 15);
            this.lblInvsCreatedBetween.TabIndex = 1;
            this.lblInvsCreatedBetween.Text = "AND";
            // 
            // rdoInvsCreatedBetween
            // 
            this.rdoInvsCreatedBetween.AutoSize = true;
            this.rdoInvsCreatedBetween.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInvsCreatedBetween.Location = new System.Drawing.Point(32, 52);
            this.rdoInvsCreatedBetween.Name = "rdoInvsCreatedBetween";
            this.rdoInvsCreatedBetween.Size = new System.Drawing.Size(81, 19);
            this.rdoInvsCreatedBetween.TabIndex = 4;
            this.rdoInvsCreatedBetween.Text = "BETWEEN:";
            this.rdoInvsCreatedBetween.UseVisualStyleBackColor = true;
            this.rdoInvsCreatedBetween.CheckedChanged += new System.EventHandler(this.rdoInvsCreated_CheckedChanged);
            // 
            // rdoInvsCreatedMonth2
            // 
            this.rdoInvsCreatedMonth2.AutoSize = true;
            this.rdoInvsCreatedMonth2.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInvsCreatedMonth2.Location = new System.Drawing.Point(263, 23);
            this.rdoInvsCreatedMonth2.Name = "rdoInvsCreatedMonth2";
            this.rdoInvsCreatedMonth2.Size = new System.Drawing.Size(70, 20);
            this.rdoInvsCreatedMonth2.TabIndex = 3;
            this.rdoInvsCreatedMonth2.Text = "Month 2";
            this.rdoInvsCreatedMonth2.UseVisualStyleBackColor = true;
            this.rdoInvsCreatedMonth2.CheckedChanged += new System.EventHandler(this.rdoInvsCreated_CheckedChanged);
            // 
            // rdoInvsCreatedMonth1
            // 
            this.rdoInvsCreatedMonth1.AutoSize = true;
            this.rdoInvsCreatedMonth1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInvsCreatedMonth1.Location = new System.Drawing.Point(143, 23);
            this.rdoInvsCreatedMonth1.Name = "rdoInvsCreatedMonth1";
            this.rdoInvsCreatedMonth1.Size = new System.Drawing.Size(70, 20);
            this.rdoInvsCreatedMonth1.TabIndex = 2;
            this.rdoInvsCreatedMonth1.Text = "Month 1";
            this.rdoInvsCreatedMonth1.UseVisualStyleBackColor = true;
            this.rdoInvsCreatedMonth1.CheckedChanged += new System.EventHandler(this.rdoInvsCreated_CheckedChanged);
            // 
            // rdoInvsCreatedAnyTime
            // 
            this.rdoInvsCreatedAnyTime.AutoSize = true;
            this.rdoInvsCreatedAnyTime.Checked = true;
            this.rdoInvsCreatedAnyTime.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInvsCreatedAnyTime.Location = new System.Drawing.Point(32, 23);
            this.rdoInvsCreatedAnyTime.Name = "rdoInvsCreatedAnyTime";
            this.rdoInvsCreatedAnyTime.Size = new System.Drawing.Size(73, 19);
            this.rdoInvsCreatedAnyTime.TabIndex = 1;
            this.rdoInvsCreatedAnyTime.TabStop = true;
            this.rdoInvsCreatedAnyTime.Text = "ANYTIME";
            this.rdoInvsCreatedAnyTime.UseVisualStyleBackColor = true;
            this.rdoInvsCreatedAnyTime.CheckedChanged += new System.EventHandler(this.rdoInvsCreated_CheckedChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlMain.Controls.Add(this.cboKeyword);
            this.pnlMain.Controls.Add(this.btnSearch);
            this.pnlMain.Controls.Add(this.grpInvsCreated);
            this.pnlMain.Controls.Add(this.grpCustomSQL);
            this.pnlMain.Controls.Add(this.grpStatus);
            this.pnlMain.Controls.Add(this.cboSearchIn);
            this.pnlMain.Controls.Add(this.grpClients);
            this.pnlMain.Controls.Add(this.txtKeyword);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Location = new System.Drawing.Point(1, 1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(583, 548);
            this.pnlMain.TabIndex = 2;
            // 
            // cboKeyword
            // 
            this.cboKeyword.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.cboKeyword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboKeyword.FormattingEnabled = true;
            this.cboKeyword.Location = new System.Drawing.Point(352, 322);
            this.cboKeyword.Name = "cboKeyword";
            this.cboKeyword.Size = new System.Drawing.Size(219, 24);
            this.cboKeyword.TabIndex = 52;
            this.cboKeyword.TextChanged += new System.EventHandler(this.cboKeyword_TextChanged);
            this.cboKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboKeyword_KeyPress);
            // 
            // FormSearchInvs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(585, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSearchInvs";
            this.Text = "FormSearchInvs";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormSearchInvs_LoadCompleted);
            this.VisibleChanged += new System.EventHandler(this.FormSearchInvs_VisibleChanged);
            this.grpCustomSQL.ResumeLayout(false);
            this.grpCustomSQL.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.grpClients.ResumeLayout(false);
            this.grpClients.PerformLayout();
            this.grpInvsCreated.ResumeLayout(false);
            this.grpInvsCreated.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.ComboBox cboSearchIn;
        private System.Windows.Forms.Label lblCustomSQLDescription;
        private System.Windows.Forms.GroupBox grpCustomSQL;
        private System.Windows.Forms.TextBox txtCustomSQLConditions;
        private System.Windows.Forms.Label lblCustomSQLQuery;
        private System.Windows.Forms.CheckBox chkCustomSQL;
        private System.Windows.Forms.RadioButton rdoStatusAND;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblInState;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.RadioButton rdoClientsAND;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblForClients;
        private System.Windows.Forms.GroupBox grpClients;
        private System.Windows.Forms.GroupBox grpInvsCreated;
        private System.Windows.Forms.DateTimePicker dtmInvsCreatedTo;
        private System.Windows.Forms.DateTimePicker dtmInvsCreatedFrom;
        private System.Windows.Forms.Label lblInvsCreatedBetween;
        private System.Windows.Forms.RadioButton rdoInvsCreatedBetween;
        private System.Windows.Forms.RadioButton rdoInvsCreatedMonth2;
        private System.Windows.Forms.RadioButton rdoInvsCreatedMonth1;
        private System.Windows.Forms.RadioButton rdoInvsCreatedAnyTime;
        private System.Windows.Forms.RadioButton rdoClientsOR;
        private System.Windows.Forms.RadioButton rdoStatusOR;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.CheckedListBox lboxInvStatus;
        private System.Windows.Forms.CheckedListBox lboxClients;
        private System.Windows.Forms.ListBox lstColumns;
        private System.Windows.Forms.ComboBox cboKeyword;

    }
}