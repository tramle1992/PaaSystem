namespace PaaApplication.Forms.ClientInfo
{
    partial class FormMgmWideUpdates
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
            this.components = new System.ComponentModel.Container();
            this.lblManagementCompanyName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chboxBillingAddr = new System.Windows.Forms.CheckBox();
            this.txtBillingAddr = new System.Windows.Forms.TextBox();
            this.chboxDeliverReports = new System.Windows.Forms.CheckBox();
            this.cboDeliverReports = new System.Windows.Forms.ComboBox();
            this.cboDeliverConfirm = new System.Windows.Forms.ComboBox();
            this.chboxDeliverConfirm = new System.Windows.Forms.CheckBox();
            this.cboDeliverInvoices = new System.Windows.Forms.ComboBox();
            this.chboxDeliverInvoices = new System.Windows.Forms.CheckBox();
            this.chboxUpdateConfVerification = new System.Windows.Forms.CheckBox();
            this.chkConfVerification = new System.Windows.Forms.CheckBox();
            this.chkDecLetter = new System.Windows.Forms.CheckBox();
            this.chboxUpdateDecLetter = new System.Windows.Forms.CheckBox();
            this.chboxUpdatePrintInvs = new System.Windows.Forms.CheckBox();
            this.nudPrintInvs = new System.Windows.Forms.NumericUpDown();
            this.lblInvoices = new System.Windows.Forms.Label();
            this.chboxUpdateMgmName = new System.Windows.Forms.CheckBox();
            this.txtMgmName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblConfDelivery = new System.Windows.Forms.Label();
            this.lblDecLetters = new System.Windows.Forms.Label();
            this.lblInvs = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkUpdateCreditReport = new System.Windows.Forms.CheckBox();
            this.cboCreditReports = new System.Windows.Forms.ComboBox();
            this.lblComnayId = new System.Windows.Forms.Label();
            this.errpdEmail = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrintInvs)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errpdEmail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblManagementCompanyName
            // 
            this.lblManagementCompanyName.AutoSize = true;
            this.lblManagementCompanyName.Font = new System.Drawing.Font("Arial Unicode MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagementCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblManagementCompanyName.Location = new System.Drawing.Point(18, 13);
            this.lblManagementCompanyName.Name = "lblManagementCompanyName";
            this.lblManagementCompanyName.Size = new System.Drawing.Size(242, 23);
            this.lblManagementCompanyName.TabIndex = 0;
            this.lblManagementCompanyName.Text = "Display Client Name Here...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(18, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(701, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check the information that you would like to update to all clients sharing this m" +
    "anagement company, and click \"Update\"";
            // 
            // chboxBillingAddr
            // 
            this.chboxBillingAddr.AutoSize = true;
            this.chboxBillingAddr.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxBillingAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxBillingAddr.Location = new System.Drawing.Point(21, 94);
            this.chboxBillingAddr.Name = "chboxBillingAddr";
            this.chboxBillingAddr.Size = new System.Drawing.Size(215, 19);
            this.chboxBillingAddr.TabIndex = 0;
            this.chboxBillingAddr.Text = "UPDATE  BILLING  ADDRESSES  TO:";
            this.chboxBillingAddr.UseVisualStyleBackColor = true;
            this.chboxBillingAddr.CheckedChanged += new System.EventHandler(this.chboxBillingAddr_CheckedChanged);
            // 
            // txtBillingAddr
            // 
            this.txtBillingAddr.Enabled = false;
            this.txtBillingAddr.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillingAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBillingAddr.Location = new System.Drawing.Point(242, 92);
            this.txtBillingAddr.MaxLength = 255;
            this.txtBillingAddr.Multiline = true;
            this.txtBillingAddr.Name = "txtBillingAddr";
            this.txtBillingAddr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBillingAddr.Size = new System.Drawing.Size(262, 95);
            this.txtBillingAddr.TabIndex = 1;
            // 
            // chboxDeliverReports
            // 
            this.chboxDeliverReports.AutoSize = true;
            this.chboxDeliverReports.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxDeliverReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxDeliverReports.Location = new System.Drawing.Point(21, 216);
            this.chboxDeliverReports.Name = "chboxDeliverReports";
            this.chboxDeliverReports.Size = new System.Drawing.Size(181, 19);
            this.chboxDeliverReports.TabIndex = 2;
            this.chboxDeliverReports.Text = "DELIVER  ALL  REPORTS  TO:";
            this.chboxDeliverReports.UseVisualStyleBackColor = true;
            this.chboxDeliverReports.CheckedChanged += new System.EventHandler(this.chboxDeliverReports_CheckedChanged);
            // 
            // cboDeliverReports
            // 
            this.cboDeliverReports.Enabled = false;
            this.cboDeliverReports.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDeliverReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboDeliverReports.FormattingEnabled = true;
            this.cboDeliverReports.Location = new System.Drawing.Point(242, 213);
            this.cboDeliverReports.MaxLength = 255;
            this.cboDeliverReports.Name = "cboDeliverReports";
            this.cboDeliverReports.Size = new System.Drawing.Size(262, 26);
            this.cboDeliverReports.TabIndex = 3;
            this.cboDeliverReports.TextChanged += new System.EventHandler(this.cboDeliverReports_TextChanged);
            // 
            // cboDeliverConfirm
            // 
            this.cboDeliverConfirm.Enabled = false;
            this.cboDeliverConfirm.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDeliverConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboDeliverConfirm.FormattingEnabled = true;
            this.cboDeliverConfirm.Location = new System.Drawing.Point(242, 263);
            this.cboDeliverConfirm.MaxLength = 255;
            this.cboDeliverConfirm.Name = "cboDeliverConfirm";
            this.cboDeliverConfirm.Size = new System.Drawing.Size(262, 26);
            this.cboDeliverConfirm.TabIndex = 5;
            this.cboDeliverConfirm.TextChanged += new System.EventHandler(this.cboDeliverConfirm_TextChanged);
            // 
            // chboxDeliverConfirm
            // 
            this.chboxDeliverConfirm.AutoSize = true;
            this.chboxDeliverConfirm.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxDeliverConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxDeliverConfirm.Location = new System.Drawing.Point(20, 266);
            this.chboxDeliverConfirm.Name = "chboxDeliverConfirm";
            this.chboxDeliverConfirm.Size = new System.Drawing.Size(221, 19);
            this.chboxDeliverConfirm.TabIndex = 4;
            this.chboxDeliverConfirm.Text = "DELIVER  ALL  CONFIRMATIONS  TO:";
            this.chboxDeliverConfirm.UseVisualStyleBackColor = true;
            this.chboxDeliverConfirm.CheckedChanged += new System.EventHandler(this.chboxDeliverConfirm_CheckedChanged);
            // 
            // cboDeliverInvoices
            // 
            this.cboDeliverInvoices.Enabled = false;
            this.cboDeliverInvoices.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDeliverInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboDeliverInvoices.FormattingEnabled = true;
            this.cboDeliverInvoices.Location = new System.Drawing.Point(242, 313);
            this.cboDeliverInvoices.MaxLength = 255;
            this.cboDeliverInvoices.Name = "cboDeliverInvoices";
            this.cboDeliverInvoices.Size = new System.Drawing.Size(262, 26);
            this.cboDeliverInvoices.TabIndex = 7;
            this.cboDeliverInvoices.TextChanged += new System.EventHandler(this.cboDeliverInvoices_TextChanged);
            // 
            // chboxDeliverInvoices
            // 
            this.chboxDeliverInvoices.AutoSize = true;
            this.chboxDeliverInvoices.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxDeliverInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxDeliverInvoices.Location = new System.Drawing.Point(20, 315);
            this.chboxDeliverInvoices.Name = "chboxDeliverInvoices";
            this.chboxDeliverInvoices.Size = new System.Drawing.Size(180, 19);
            this.chboxDeliverInvoices.TabIndex = 6;
            this.chboxDeliverInvoices.Text = "DELIVER  ALL  INVOICES  TO:";
            this.chboxDeliverInvoices.UseVisualStyleBackColor = true;
            this.chboxDeliverInvoices.CheckedChanged += new System.EventHandler(this.chboxDeliverInvoices_CheckedChanged);
            // 
            // chboxUpdateConfVerification
            // 
            this.chboxUpdateConfVerification.AutoSize = true;
            this.chboxUpdateConfVerification.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxUpdateConfVerification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxUpdateConfVerification.Location = new System.Drawing.Point(547, 92);
            this.chboxUpdateConfVerification.Name = "chboxUpdateConfVerification";
            this.chboxUpdateConfVerification.Size = new System.Drawing.Size(307, 19);
            this.chboxUpdateConfVerification.TabIndex = 8;
            this.chboxUpdateConfVerification.Text = "UPDATE  CONFIRMATION  DELIVERY  VERIFICATION:";
            this.chboxUpdateConfVerification.UseVisualStyleBackColor = true;
            this.chboxUpdateConfVerification.CheckedChanged += new System.EventHandler(this.chboxUpdateConfVerification_CheckedChanged);
            // 
            // chkConfVerification
            // 
            this.chkConfVerification.AutoSize = true;
            this.chkConfVerification.Enabled = false;
            this.chkConfVerification.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConfVerification.ForeColor = System.Drawing.Color.White;
            this.chkConfVerification.Location = new System.Drawing.Point(565, 113);
            this.chkConfVerification.Name = "chkConfVerification";
            this.chkConfVerification.Size = new System.Drawing.Size(159, 20);
            this.chkConfVerification.TabIndex = 9;
            this.chkConfVerification.Text = "Verify Conf. Delivery";
            this.chkConfVerification.UseVisualStyleBackColor = true;
            // 
            // chkDecLetter
            // 
            this.chkDecLetter.AutoSize = true;
            this.chkDecLetter.Enabled = false;
            this.chkDecLetter.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDecLetter.ForeColor = System.Drawing.Color.White;
            this.chkDecLetter.Location = new System.Drawing.Point(565, 168);
            this.chkDecLetter.Name = "chkDecLetter";
            this.chkDecLetter.Size = new System.Drawing.Size(148, 20);
            this.chkDecLetter.TabIndex = 11;
            this.chkDecLetter.Text = "Declination Letters";
            this.chkDecLetter.UseVisualStyleBackColor = true;
            // 
            // chboxUpdateDecLetter
            // 
            this.chboxUpdateDecLetter.AutoSize = true;
            this.chboxUpdateDecLetter.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxUpdateDecLetter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxUpdateDecLetter.Location = new System.Drawing.Point(547, 146);
            this.chboxUpdateDecLetter.Name = "chboxUpdateDecLetter";
            this.chboxUpdateDecLetter.Size = new System.Drawing.Size(280, 19);
            this.chboxUpdateDecLetter.TabIndex = 10;
            this.chboxUpdateDecLetter.Text = "UPDATE  DECLINATION  LETTER  GENERATION:";
            this.chboxUpdateDecLetter.UseVisualStyleBackColor = true;
            this.chboxUpdateDecLetter.CheckedChanged += new System.EventHandler(this.chboxUpdateDecLetter_CheckedChanged);
            // 
            // chboxUpdatePrintInvs
            // 
            this.chboxUpdatePrintInvs.AutoSize = true;
            this.chboxUpdatePrintInvs.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxUpdatePrintInvs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxUpdatePrintInvs.Location = new System.Drawing.Point(547, 202);
            this.chboxUpdatePrintInvs.Name = "chboxUpdatePrintInvs";
            this.chboxUpdatePrintInvs.Size = new System.Drawing.Size(260, 19);
            this.chboxUpdatePrintInvs.TabIndex = 12;
            this.chboxUpdatePrintInvs.Text = "UPDATE  NUMBER  OF  PRINTED  INVOICES:";
            this.chboxUpdatePrintInvs.UseVisualStyleBackColor = true;
            this.chboxUpdatePrintInvs.CheckedChanged += new System.EventHandler(this.chboxUpdatePrintInvs_CheckedChanged);
            // 
            // nudPrintInvs
            // 
            this.nudPrintInvs.Enabled = false;
            this.nudPrintInvs.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrintInvs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudPrintInvs.Location = new System.Drawing.Point(565, 225);
            this.nudPrintInvs.Name = "nudPrintInvs";
            this.nudPrintInvs.Size = new System.Drawing.Size(40, 24);
            this.nudPrintInvs.TabIndex = 13;
            // 
            // lblInvoices
            // 
            this.lblInvoices.AutoSize = true;
            this.lblInvoices.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoices.Location = new System.Drawing.Point(611, 227);
            this.lblInvoices.Name = "lblInvoices";
            this.lblInvoices.Size = new System.Drawing.Size(38, 16);
            this.lblInvoices.TabIndex = 17;
            this.lblInvoices.Text = "Invs.";
            // 
            // chboxUpdateMgmName
            // 
            this.chboxUpdateMgmName.AutoSize = true;
            this.chboxUpdateMgmName.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxUpdateMgmName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxUpdateMgmName.Location = new System.Drawing.Point(547, 329);
            this.chboxUpdateMgmName.Name = "chboxUpdateMgmName";
            this.chboxUpdateMgmName.Size = new System.Drawing.Size(277, 19);
            this.chboxUpdateMgmName.TabIndex = 16;
            this.chboxUpdateMgmName.Text = "UPDATE  NAME  OF  MANAGEMENT  COMPANY:";
            this.chboxUpdateMgmName.UseVisualStyleBackColor = true;
            this.chboxUpdateMgmName.CheckedChanged += new System.EventHandler(this.chboxUpdateMgmName_CheckedChanged);
            // 
            // txtMgmName
            // 
            this.txtMgmName.Enabled = false;
            this.txtMgmName.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMgmName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMgmName.Location = new System.Drawing.Point(566, 350);
            this.txtMgmName.MaxLength = 250;
            this.txtMgmName.Name = "txtMgmName";
            this.txtMgmName.Size = new System.Drawing.Size(301, 25);
            this.txtMgmName.TabIndex = 17;
            this.txtMgmName.TextChanged += new System.EventHandler(this.txtMgmName_TextChanged);
            this.txtMgmName.Validating += new System.ComponentModel.CancelEventHandler(this.txtMgmName_Validating);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gray;
            this.btnUpdate.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(703, 385);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(792, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblConfDelivery
            // 
            this.lblConfDelivery.AutoSize = true;
            this.lblConfDelivery.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfDelivery.ForeColor = System.Drawing.Color.Gray;
            this.lblConfDelivery.Location = new System.Drawing.Point(582, 115);
            this.lblConfDelivery.Name = "lblConfDelivery";
            this.lblConfDelivery.Size = new System.Drawing.Size(140, 16);
            this.lblConfDelivery.TabIndex = 0;
            this.lblConfDelivery.Text = "Verify Conf. Delivery";
            // 
            // lblDecLetters
            // 
            this.lblDecLetters.AutoSize = true;
            this.lblDecLetters.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecLetters.ForeColor = System.Drawing.Color.Gray;
            this.lblDecLetters.Location = new System.Drawing.Point(583, 170);
            this.lblDecLetters.Name = "lblDecLetters";
            this.lblDecLetters.Size = new System.Drawing.Size(129, 16);
            this.lblDecLetters.TabIndex = 23;
            this.lblDecLetters.Text = "Declination Letters";
            // 
            // lblInvs
            // 
            this.lblInvs.AutoSize = true;
            this.lblInvs.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvs.ForeColor = System.Drawing.Color.Gray;
            this.lblInvs.Location = new System.Drawing.Point(611, 227);
            this.lblInvs.Name = "lblInvs";
            this.lblInvs.Size = new System.Drawing.Size(38, 16);
            this.lblInvs.TabIndex = 24;
            this.lblInvs.Text = "Invs.";
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(18, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 7);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkUpdateCreditReport);
            this.panel1.Controls.Add(this.chboxDeliverConfirm);
            this.panel1.Controls.Add(this.lblConfDelivery);
            this.panel1.Controls.Add(this.lblInvs);
            this.panel1.Controls.Add(this.chkConfVerification);
            this.panel1.Controls.Add(this.nudPrintInvs);
            this.panel1.Controls.Add(this.chboxUpdateConfVerification);
            this.panel1.Controls.Add(this.lblInvoices);
            this.panel1.Controls.Add(this.chboxDeliverInvoices);
            this.panel1.Controls.Add(this.cboCreditReports);
            this.panel1.Controls.Add(this.cboDeliverConfirm);
            this.panel1.Controls.Add(this.chboxDeliverReports);
            this.panel1.Controls.Add(this.lblDecLetters);
            this.panel1.Controls.Add(this.lblComnayId);
            this.panel1.Controls.Add(this.cboDeliverReports);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.txtMgmName);
            this.panel1.Controls.Add(this.txtBillingAddr);
            this.panel1.Controls.Add(this.chboxUpdateMgmName);
            this.panel1.Controls.Add(this.chkDecLetter);
            this.panel1.Controls.Add(this.chboxUpdatePrintInvs);
            this.panel1.Controls.Add(this.chboxUpdateDecLetter);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.cboDeliverInvoices);
            this.panel1.Location = new System.Drawing.Point(0, -8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 425);
            this.panel1.TabIndex = 26;
            // 
            // chkUpdateCreditReport
            // 
            this.chkUpdateCreditReport.AutoSize = true;
            this.chkUpdateCreditReport.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUpdateCreditReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkUpdateCreditReport.Location = new System.Drawing.Point(547, 266);
            this.chkUpdateCreditReport.Name = "chkUpdateCreditReport";
            this.chkUpdateCreditReport.Size = new System.Drawing.Size(176, 19);
            this.chkUpdateCreditReport.TabIndex = 14;
            this.chkUpdateCreditReport.Text = "UPDATE  CREDIT  REPORTS";
            this.chkUpdateCreditReport.UseVisualStyleBackColor = true;
            this.chkUpdateCreditReport.CheckedChanged += new System.EventHandler(this.chkUpdateCreditReport_CheckedChanged);
            // 
            // cboCreditReports
            // 
            this.cboCreditReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCreditReports.Enabled = false;
            this.cboCreditReports.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCreditReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboCreditReports.FormattingEnabled = true;
            this.cboCreditReports.Location = new System.Drawing.Point(565, 287);
            this.cboCreditReports.Name = "cboCreditReports";
            this.cboCreditReports.Size = new System.Drawing.Size(302, 26);
            this.cboCreditReports.TabIndex = 15;
            // 
            // lblComnayId
            // 
            this.lblComnayId.AutoSize = true;
            this.lblComnayId.Location = new System.Drawing.Point(658, 18);
            this.lblComnayId.Name = "lblComnayId";
            this.lblComnayId.Size = new System.Drawing.Size(35, 13);
            this.lblComnayId.TabIndex = 100000;
            this.lblComnayId.Text = "label2";
            this.lblComnayId.Visible = false;
            // 
            // errpdEmail
            // 
            this.errpdEmail.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errpdEmail.ContainerControl = this;
            // 
            // FormMgmWideUpdates
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(896, 428);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chboxBillingAddr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblManagementCompanyName);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMgmWideUpdates";
            this.Text = "Management-Wide Information Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMgmWideUpdates_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrintInvs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errpdEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblManagementCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chboxBillingAddr;
        private System.Windows.Forms.TextBox txtBillingAddr;
        private System.Windows.Forms.CheckBox chboxDeliverReports;
        private System.Windows.Forms.ComboBox cboDeliverReports;
        private System.Windows.Forms.ComboBox cboDeliverConfirm;
        private System.Windows.Forms.CheckBox chboxDeliverConfirm;
        private System.Windows.Forms.ComboBox cboDeliverInvoices;
        private System.Windows.Forms.CheckBox chboxDeliverInvoices;
        private System.Windows.Forms.CheckBox chboxUpdateConfVerification;
        private System.Windows.Forms.CheckBox chkConfVerification;
        private System.Windows.Forms.CheckBox chkDecLetter;
        private System.Windows.Forms.CheckBox chboxUpdateDecLetter;
        private System.Windows.Forms.CheckBox chboxUpdatePrintInvs;
        private System.Windows.Forms.NumericUpDown nudPrintInvs;
        private System.Windows.Forms.Label lblInvoices;
        private System.Windows.Forms.CheckBox chboxUpdateMgmName;
        private System.Windows.Forms.TextBox txtMgmName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblConfDelivery;
        private System.Windows.Forms.Label lblDecLetters;
        private System.Windows.Forms.Label lblInvs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblComnayId;
        private System.Windows.Forms.CheckBox chkUpdateCreditReport;
        private System.Windows.Forms.ComboBox cboCreditReports;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errpdEmail;       
    }
}