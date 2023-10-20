namespace PaaApplication.Forms.Administration
{
    partial class FormSysConfig
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
            this.lblJobScheduling = new System.Windows.Forms.Label();
            this.grpFtp = new System.Windows.Forms.GroupBox();
            this.txtFtpPassword = new System.Windows.Forms.TextBox();
            this.lblFtpPassword = new System.Windows.Forms.Label();
            this.txtFtpUsername = new System.Windows.Forms.TextBox();
            this.txtFtpUri = new System.Windows.Forms.TextBox();
            this.lblFtpUsername = new System.Windows.Forms.Label();
            this.lblFtpUri = new System.Windows.Forms.Label();
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.txtBackupLocation = new System.Windows.Forms.TextBox();
            this.chkEnableBackup = new System.Windows.Forms.CheckBox();
            this.dtmBackupTime = new System.Windows.Forms.DateTimePicker();
            this.btnSelectLocation = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.grpOperationSettings = new System.Windows.Forms.GroupBox();
            this.txtBillingEmailConfirmation = new System.Windows.Forms.TextBox();
            this.nudAutoSaveTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.dtmWorkingHoursTo = new System.Windows.Forms.DateTimePicker();
            this.dtmWorkingHoursFrom = new System.Windows.Forms.DateTimePicker();
            this.nudNumberAppsBonus = new System.Windows.Forms.NumericUpDown();
            this.lblBillingEmailConfirmation = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblAutoSaveTimeInterval = new System.Windows.Forms.Label();
            this.lblWorkingHoursTo = new System.Windows.Forms.Label();
            this.lblWorkingHoursFrom = new System.Windows.Forms.Label();
            this.lblWorkingHours = new System.Windows.Forms.Label();
            this.lblNumberAppsBonus = new System.Windows.Forms.Label();
            this.grpFtp.SuspendLayout();
            this.grpBackup.SuspendLayout();
            this.grpOperationSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoSaveTimeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberAppsBonus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJobScheduling
            // 
            this.lblJobScheduling.AutoSize = true;
            this.lblJobScheduling.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobScheduling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblJobScheduling.Location = new System.Drawing.Point(14, 30);
            this.lblJobScheduling.Name = "lblJobScheduling";
            this.lblJobScheduling.Size = new System.Drawing.Size(110, 15);
            this.lblJobScheduling.TabIndex = 19;
            this.lblJobScheduling.Text = "JOB  SCHEDULING:";
            // 
            // grpFtp
            // 
            this.grpFtp.BackColor = System.Drawing.SystemColors.Control;
            this.grpFtp.Controls.Add(this.txtFtpPassword);
            this.grpFtp.Controls.Add(this.lblFtpPassword);
            this.grpFtp.Controls.Add(this.txtFtpUsername);
            this.grpFtp.Controls.Add(this.txtFtpUri);
            this.grpFtp.Controls.Add(this.lblFtpUsername);
            this.grpFtp.Controls.Add(this.lblFtpUri);
            this.grpFtp.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFtp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpFtp.Location = new System.Drawing.Point(17, 192);
            this.grpFtp.Name = "grpFtp";
            this.grpFtp.Size = new System.Drawing.Size(556, 146);
            this.grpFtp.TabIndex = 2;
            this.grpFtp.TabStop = false;
            this.grpFtp.Text = "FTP Information";
            // 
            // txtFtpPassword
            // 
            this.txtFtpPassword.Location = new System.Drawing.Point(362, 103);
            this.txtFtpPassword.Name = "txtFtpPassword";
            this.txtFtpPassword.Size = new System.Drawing.Size(169, 25);
            this.txtFtpPassword.TabIndex = 7;
            this.txtFtpPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formSysConfig_KeyDown);
            this.txtFtpPassword.Validating += new System.ComponentModel.CancelEventHandler(this.formSysConfig_Validating);
            // 
            // lblFtpPassword
            // 
            this.lblFtpPassword.AutoSize = true;
            this.lblFtpPassword.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFtpPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFtpPassword.Location = new System.Drawing.Point(359, 85);
            this.lblFtpPassword.Name = "lblFtpPassword";
            this.lblFtpPassword.Size = new System.Drawing.Size(73, 15);
            this.lblFtpPassword.TabIndex = 32;
            this.lblFtpPassword.Text = "PASSWORD:";
            // 
            // txtFtpUsername
            // 
            this.txtFtpUsername.Location = new System.Drawing.Point(17, 103);
            this.txtFtpUsername.Name = "txtFtpUsername";
            this.txtFtpUsername.Size = new System.Drawing.Size(169, 25);
            this.txtFtpUsername.TabIndex = 6;
            this.txtFtpUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formSysConfig_KeyDown);
            this.txtFtpUsername.Validating += new System.ComponentModel.CancelEventHandler(this.formSysConfig_Validating);
            // 
            // txtFtpUri
            // 
            this.txtFtpUri.Location = new System.Drawing.Point(17, 47);
            this.txtFtpUri.Name = "txtFtpUri";
            this.txtFtpUri.Size = new System.Drawing.Size(514, 25);
            this.txtFtpUri.TabIndex = 5;
            this.txtFtpUri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formSysConfig_KeyDown);
            this.txtFtpUri.Validating += new System.ComponentModel.CancelEventHandler(this.formSysConfig_Validating);
            // 
            // lblFtpUsername
            // 
            this.lblFtpUsername.AutoSize = true;
            this.lblFtpUsername.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFtpUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFtpUsername.Location = new System.Drawing.Point(14, 85);
            this.lblFtpUsername.Name = "lblFtpUsername";
            this.lblFtpUsername.Size = new System.Drawing.Size(71, 15);
            this.lblFtpUsername.TabIndex = 27;
            this.lblFtpUsername.Text = "USERNAME:";
            // 
            // lblFtpUri
            // 
            this.lblFtpUri.AutoSize = true;
            this.lblFtpUri.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFtpUri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFtpUri.Location = new System.Drawing.Point(14, 29);
            this.lblFtpUri.Name = "lblFtpUri";
            this.lblFtpUri.Size = new System.Drawing.Size(91, 15);
            this.lblFtpUri.TabIndex = 25;
            this.lblFtpUri.Text = "SERVER  NAME:";
            // 
            // grpBackup
            // 
            this.grpBackup.BackColor = System.Drawing.SystemColors.Control;
            this.grpBackup.Controls.Add(this.txtBackupLocation);
            this.grpBackup.Controls.Add(this.chkEnableBackup);
            this.grpBackup.Controls.Add(this.dtmBackupTime);
            this.grpBackup.Controls.Add(this.btnSelectLocation);
            this.grpBackup.Controls.Add(this.lblLocation);
            this.grpBackup.Controls.Add(this.lblJobScheduling);
            this.grpBackup.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpBackup.Location = new System.Drawing.Point(17, 23);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(556, 154);
            this.grpBackup.TabIndex = 1;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Backup Database";
            // 
            // txtBackupLocation
            // 
            this.txtBackupLocation.Location = new System.Drawing.Point(17, 116);
            this.txtBackupLocation.Name = "txtBackupLocation";
            this.txtBackupLocation.Size = new System.Drawing.Size(454, 25);
            this.txtBackupLocation.TabIndex = 3;
            this.txtBackupLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formSysConfig_KeyDown);
            this.txtBackupLocation.Validating += new System.ComponentModel.CancelEventHandler(this.formSysConfig_Validating);
            // 
            // chkEnableBackup
            // 
            this.chkEnableBackup.AutoSize = true;
            this.chkEnableBackup.Location = new System.Drawing.Point(17, 55);
            this.chkEnableBackup.Name = "chkEnableBackup";
            this.chkEnableBackup.Size = new System.Drawing.Size(192, 22);
            this.chkEnableBackup.TabIndex = 1;
            this.chkEnableBackup.Text = "Enable Daily Backup At:";
            this.chkEnableBackup.UseVisualStyleBackColor = true;
            this.chkEnableBackup.CheckedChanged += new System.EventHandler(this.chkEnableBackup_CheckedChanged);
            this.chkEnableBackup.Validating += new System.ComponentModel.CancelEventHandler(this.formSysConfig_Validating);
            // 
            // dtmBackupTime
            // 
            this.dtmBackupTime.CalendarFont = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmBackupTime.CustomFormat = "HH:mm";
            this.dtmBackupTime.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmBackupTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmBackupTime.Location = new System.Drawing.Point(215, 51);
            this.dtmBackupTime.Name = "dtmBackupTime";
            this.dtmBackupTime.Size = new System.Drawing.Size(119, 28);
            this.dtmBackupTime.TabIndex = 2;
            this.dtmBackupTime.ValueChanged += new System.EventHandler(this.dtmBackupTime_ValueChanged);
            // 
            // btnSelectLocation
            // 
            this.btnSelectLocation.BackColor = System.Drawing.Color.Gray;
            this.btnSelectLocation.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectLocation.ForeColor = System.Drawing.Color.White;
            this.btnSelectLocation.Location = new System.Drawing.Point(486, 112);
            this.btnSelectLocation.Name = "btnSelectLocation";
            this.btnSelectLocation.Size = new System.Drawing.Size(45, 32);
            this.btnSelectLocation.TabIndex = 4;
            this.btnSelectLocation.Text = "...";
            this.btnSelectLocation.UseVisualStyleBackColor = false;
            this.btnSelectLocation.Click += new System.EventHandler(this.btnSelectLocation_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLocation.Location = new System.Drawing.Point(14, 91);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(67, 15);
            this.lblLocation.TabIndex = 20;
            this.lblLocation.Text = "LOCATION:";
            // 
            // grpOperationSettings
            // 
            this.grpOperationSettings.BackColor = System.Drawing.SystemColors.Control;
            this.grpOperationSettings.Controls.Add(this.txtBillingEmailConfirmation);
            this.grpOperationSettings.Controls.Add(this.nudAutoSaveTimeInterval);
            this.grpOperationSettings.Controls.Add(this.dtmWorkingHoursTo);
            this.grpOperationSettings.Controls.Add(this.dtmWorkingHoursFrom);
            this.grpOperationSettings.Controls.Add(this.nudNumberAppsBonus);
            this.grpOperationSettings.Controls.Add(this.lblBillingEmailConfirmation);
            this.grpOperationSettings.Controls.Add(this.lblSec);
            this.grpOperationSettings.Controls.Add(this.lblAutoSaveTimeInterval);
            this.grpOperationSettings.Controls.Add(this.lblWorkingHoursTo);
            this.grpOperationSettings.Controls.Add(this.lblWorkingHoursFrom);
            this.grpOperationSettings.Controls.Add(this.lblWorkingHours);
            this.grpOperationSettings.Controls.Add(this.lblNumberAppsBonus);
            this.grpOperationSettings.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOperationSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpOperationSettings.Location = new System.Drawing.Point(17, 354);
            this.grpOperationSettings.Name = "grpOperationSettings";
            this.grpOperationSettings.Size = new System.Drawing.Size(556, 290);
            this.grpOperationSettings.TabIndex = 3;
            this.grpOperationSettings.TabStop = false;
            this.grpOperationSettings.Text = "Operation Settings";
            // 
            // txtBillingEmailConfirmation
            // 
            this.txtBillingEmailConfirmation.Location = new System.Drawing.Point(26, 227);
            this.txtBillingEmailConfirmation.Name = "txtBillingEmailConfirmation";
            this.txtBillingEmailConfirmation.Size = new System.Drawing.Size(298, 25);
            this.txtBillingEmailConfirmation.TabIndex = 12;
            this.txtBillingEmailConfirmation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formSysConfig_KeyDown);
            this.txtBillingEmailConfirmation.Validating += new System.ComponentModel.CancelEventHandler(this.formSysConfig_Validating);
            // 
            // nudAutoSaveTimeInterval
            // 
            this.nudAutoSaveTimeInterval.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudAutoSaveTimeInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudAutoSaveTimeInterval.Location = new System.Drawing.Point(65, 162);
            this.nudAutoSaveTimeInterval.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.nudAutoSaveTimeInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAutoSaveTimeInterval.Name = "nudAutoSaveTimeInterval";
            this.nudAutoSaveTimeInterval.Size = new System.Drawing.Size(95, 28);
            this.nudAutoSaveTimeInterval.TabIndex = 11;
            this.nudAutoSaveTimeInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAutoSaveTimeInterval.ValueChanged += new System.EventHandler(this.nudAutoSaveTimeInterval_ValueChanged);
            this.nudAutoSaveTimeInterval.Validating += new System.ComponentModel.CancelEventHandler(this.formSysConfig_Validating);
            // 
            // dtmWorkingHoursTo
            // 
            this.dtmWorkingHoursTo.CalendarFont = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmWorkingHoursTo.CustomFormat = "HH:mm";
            this.dtmWorkingHoursTo.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmWorkingHoursTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmWorkingHoursTo.Location = new System.Drawing.Point(238, 92);
            this.dtmWorkingHoursTo.Name = "dtmWorkingHoursTo";
            this.dtmWorkingHoursTo.Size = new System.Drawing.Size(95, 28);
            this.dtmWorkingHoursTo.TabIndex = 10;
            this.dtmWorkingHoursTo.ValueChanged += new System.EventHandler(this.dtmWorkingHoursTo_ValueChanged);
            this.dtmWorkingHoursTo.Validating += new System.ComponentModel.CancelEventHandler(this.formSysConfig_Validating);
            // 
            // dtmWorkingHoursFrom
            // 
            this.dtmWorkingHoursFrom.CalendarFont = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmWorkingHoursFrom.Checked = false;
            this.dtmWorkingHoursFrom.CustomFormat = "HH:mm";
            this.dtmWorkingHoursFrom.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmWorkingHoursFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmWorkingHoursFrom.Location = new System.Drawing.Point(65, 93);
            this.dtmWorkingHoursFrom.Name = "dtmWorkingHoursFrom";
            this.dtmWorkingHoursFrom.Size = new System.Drawing.Size(95, 28);
            this.dtmWorkingHoursFrom.TabIndex = 9;
            this.dtmWorkingHoursFrom.ValueChanged += new System.EventHandler(this.dtmWorkingHoursFrom_ValueChanged);
            this.dtmWorkingHoursFrom.Validating += new System.ComponentModel.CancelEventHandler(this.formSysConfig_Validating);
            // 
            // nudNumberAppsBonus
            // 
            this.nudNumberAppsBonus.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumberAppsBonus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudNumberAppsBonus.Location = new System.Drawing.Point(238, 27);
            this.nudNumberAppsBonus.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberAppsBonus.Name = "nudNumberAppsBonus";
            this.nudNumberAppsBonus.Size = new System.Drawing.Size(95, 28);
            this.nudNumberAppsBonus.TabIndex = 8;
            this.nudNumberAppsBonus.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberAppsBonus.ValueChanged += new System.EventHandler(this.nudNumberAppsBonus_ValueChanged);
            this.nudNumberAppsBonus.Validating += new System.ComponentModel.CancelEventHandler(this.formSysConfig_Validating);
            // 
            // lblBillingEmailConfirmation
            // 
            this.lblBillingEmailConfirmation.AutoSize = true;
            this.lblBillingEmailConfirmation.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillingEmailConfirmation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBillingEmailConfirmation.Location = new System.Drawing.Point(14, 209);
            this.lblBillingEmailConfirmation.Name = "lblBillingEmailConfirmation";
            this.lblBillingEmailConfirmation.Size = new System.Drawing.Size(194, 15);
            this.lblBillingEmailConfirmation.TabIndex = 41;
            this.lblBillingEmailConfirmation.Text = "4. BILLING  EMAIL  CONFIRMATION:";
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSec.Location = new System.Drawing.Point(178, 167);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(30, 16);
            this.lblSec.TabIndex = 40;
            this.lblSec.Text = "sec.";
            // 
            // lblAutoSaveTimeInterval
            // 
            this.lblAutoSaveTimeInterval.AutoSize = true;
            this.lblAutoSaveTimeInterval.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoSaveTimeInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAutoSaveTimeInterval.Location = new System.Drawing.Point(14, 143);
            this.lblAutoSaveTimeInterval.Name = "lblAutoSaveTimeInterval";
            this.lblAutoSaveTimeInterval.Size = new System.Drawing.Size(146, 15);
            this.lblAutoSaveTimeInterval.TabIndex = 38;
            this.lblAutoSaveTimeInterval.Text = "3. AUTO  SAVE  INTERVAL:";
            // 
            // lblWorkingHoursTo
            // 
            this.lblWorkingHoursTo.AutoSize = true;
            this.lblWorkingHoursTo.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkingHoursTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWorkingHoursTo.Location = new System.Drawing.Point(207, 101);
            this.lblWorkingHoursTo.Name = "lblWorkingHoursTo";
            this.lblWorkingHoursTo.Size = new System.Drawing.Size(25, 16);
            this.lblWorkingHoursTo.TabIndex = 37;
            this.lblWorkingHoursTo.Text = "To:";
            // 
            // lblWorkingHoursFrom
            // 
            this.lblWorkingHoursFrom.AutoSize = true;
            this.lblWorkingHoursFrom.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkingHoursFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWorkingHoursFrom.Location = new System.Drawing.Point(23, 101);
            this.lblWorkingHoursFrom.Name = "lblWorkingHoursFrom";
            this.lblWorkingHoursFrom.Size = new System.Drawing.Size(40, 16);
            this.lblWorkingHoursFrom.TabIndex = 35;
            this.lblWorkingHoursFrom.Text = "From:";
            // 
            // lblWorkingHours
            // 
            this.lblWorkingHours.AutoSize = true;
            this.lblWorkingHours.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkingHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWorkingHours.Location = new System.Drawing.Point(14, 72);
            this.lblWorkingHours.Name = "lblWorkingHours";
            this.lblWorkingHours.Size = new System.Drawing.Size(122, 15);
            this.lblWorkingHours.TabIndex = 33;
            this.lblWorkingHours.Text = "2. WORKING  HOURS:";
            // 
            // lblNumberAppsBonus
            // 
            this.lblNumberAppsBonus.AutoSize = true;
            this.lblNumberAppsBonus.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberAppsBonus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNumberAppsBonus.Location = new System.Drawing.Point(14, 33);
            this.lblNumberAppsBonus.Name = "lblNumberAppsBonus";
            this.lblNumberAppsBonus.Size = new System.Drawing.Size(218, 15);
            this.lblNumberAppsBonus.TabIndex = 31;
            this.lblNumberAppsBonus.Text = "1. TOTAL  APPLICATIONS  FOR  BONUS:";
            // 
            // FormSysConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 685);
            this.Controls.Add(this.grpOperationSettings);
            this.Controls.Add(this.grpBackup);
            this.Controls.Add(this.grpFtp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSysConfig";
            this.Text = "FormSysConfig";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormSysConfig_LoadCompleted);
            this.grpFtp.ResumeLayout(false);
            this.grpFtp.PerformLayout();
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            this.grpOperationSettings.ResumeLayout(false);
            this.grpOperationSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoSaveTimeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberAppsBonus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblJobScheduling;
        private System.Windows.Forms.GroupBox grpFtp;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.GroupBox grpOperationSettings;
        private System.Windows.Forms.Label lblFtpUri;
        private System.Windows.Forms.DateTimePicker dtmBackupTime;
        private System.Windows.Forms.Button btnSelectLocation;
        private System.Windows.Forms.Label lblFtpUsername;
        private System.Windows.Forms.Label lblBillingEmailConfirmation;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblAutoSaveTimeInterval;
        private System.Windows.Forms.Label lblWorkingHoursTo;
        private System.Windows.Forms.Label lblWorkingHoursFrom;
        private System.Windows.Forms.Label lblWorkingHours;
        private System.Windows.Forms.Label lblNumberAppsBonus;
        private System.Windows.Forms.DateTimePicker dtmWorkingHoursTo;
        private System.Windows.Forms.DateTimePicker dtmWorkingHoursFrom;
        private System.Windows.Forms.NumericUpDown nudNumberAppsBonus;
        private System.Windows.Forms.CheckBox chkEnableBackup;
        private System.Windows.Forms.TextBox txtBackupLocation;
        private System.Windows.Forms.TextBox txtFtpUri;
        private System.Windows.Forms.TextBox txtFtpUsername;
        private System.Windows.Forms.TextBox txtFtpPassword;
        private System.Windows.Forms.Label lblFtpPassword;
        private System.Windows.Forms.NumericUpDown nudAutoSaveTimeInterval;
        private System.Windows.Forms.TextBox txtBillingEmailConfirmation;
    }
}