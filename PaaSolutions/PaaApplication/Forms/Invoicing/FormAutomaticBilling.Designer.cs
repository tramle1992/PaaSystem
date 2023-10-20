namespace PaaApplication.Forms.Invoicing
{
    partial class FormAutomaticBilling
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabStep = new PaaApplication.ExtendControls.TablessTabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.picRoseMoneyMain = new System.Windows.Forms.PictureBox();
            this.chkMonthIncomplete = new System.Windows.Forms.CheckBox();
            this.btnBillApps = new System.Windows.Forms.Button();
            this.chkFoundBalances = new System.Windows.Forms.CheckBox();
            this.btnDetails = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblBillingCycleIs = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.tabPageInProgress = new System.Windows.Forms.TabPage();
            this.picInvoices = new System.Windows.Forms.PictureBox();
            this.picRoseMoneyInProgress = new System.Windows.Forms.PictureBox();
            this.pnlInProgress = new System.Windows.Forms.Panel();
            this.btnCancelProgress = new System.Windows.Forms.Button();
            this.lblBillingAppsFor = new System.Windows.Forms.Label();
            this.proBillingPercentage = new System.Windows.Forms.ProgressBar();
            this.tabStep.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoseMoneyMain)).BeginInit();
            this.tabPageInProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRoseMoneyInProgress)).BeginInit();
            this.pnlInProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(350, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 60);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabStep
            // 
            this.tabStep.Controls.Add(this.tabPageMain);
            this.tabStep.Controls.Add(this.tabPageInProgress);
            this.tabStep.Location = new System.Drawing.Point(0, 0);
            this.tabStep.Name = "tabStep";
            this.tabStep.SelectedIndex = 0;
            this.tabStep.Size = new System.Drawing.Size(540, 424);
            this.tabStep.TabIndex = 0;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.picRoseMoneyMain);
            this.tabPageMain.Controls.Add(this.chkMonthIncomplete);
            this.tabPageMain.Controls.Add(this.btnCancel);
            this.tabPageMain.Controls.Add(this.btnBillApps);
            this.tabPageMain.Controls.Add(this.chkFoundBalances);
            this.tabPageMain.Controls.Add(this.btnDetails);
            this.tabPageMain.Controls.Add(this.lblDescription);
            this.tabPageMain.Controls.Add(this.lblMonth);
            this.tabPageMain.Controls.Add(this.lblBillingCycleIs);
            this.tabPageMain.Controls.Add(this.pnlButtons);
            this.tabPageMain.Location = new System.Drawing.Point(4, 22);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(532, 398);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "tabPage1";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // picRoseMoneyMain
            // 
            this.picRoseMoneyMain.Image = global::PaaApplication.Properties.Resources.rose_money;
            this.picRoseMoneyMain.Location = new System.Drawing.Point(370, 28);
            this.picRoseMoneyMain.Name = "picRoseMoneyMain";
            this.picRoseMoneyMain.Size = new System.Drawing.Size(80, 130);
            this.picRoseMoneyMain.TabIndex = 18;
            this.picRoseMoneyMain.TabStop = false;
            // 
            // chkMonthIncomplete
            // 
            this.chkMonthIncomplete.AutoSize = true;
            this.chkMonthIncomplete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMonthIncomplete.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMonthIncomplete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkMonthIncomplete.Location = new System.Drawing.Point(300, 180);
            this.chkMonthIncomplete.MaximumSize = new System.Drawing.Size(220, 30);
            this.chkMonthIncomplete.MinimumSize = new System.Drawing.Size(220, 30);
            this.chkMonthIncomplete.Name = "chkMonthIncomplete";
            this.chkMonthIncomplete.Size = new System.Drawing.Size(220, 30);
            this.chkMonthIncomplete.TabIndex = 14;
            this.chkMonthIncomplete.Text = "  This month is still in progress.\r\n  Check here to continue anyway.";
            this.chkMonthIncomplete.UseVisualStyleBackColor = true;
            this.chkMonthIncomplete.CheckedChanged += new System.EventHandler(this.chkIncompleteAndFound_CheckedChanged);
            // 
            // btnBillApps
            // 
            this.btnBillApps.BackColor = System.Drawing.SystemColors.Window;
            this.btnBillApps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillApps.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.btnBillApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBillApps.Location = new System.Drawing.Point(48, 328);
            this.btnBillApps.Name = "btnBillApps";
            this.btnBillApps.Size = new System.Drawing.Size(150, 60);
            this.btnBillApps.TabIndex = 16;
            this.btnBillApps.Text = "Bill 04/2015 Apps";
            this.btnBillApps.UseVisualStyleBackColor = false;
            this.btnBillApps.Click += new System.EventHandler(this.btnBillApps_Click);
            // 
            // chkFoundBalances
            // 
            this.chkFoundBalances.AutoSize = true;
            this.chkFoundBalances.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkFoundBalances.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFoundBalances.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkFoundBalances.Location = new System.Drawing.Point(300, 225);
            this.chkFoundBalances.MaximumSize = new System.Drawing.Size(220, 30);
            this.chkFoundBalances.MinimumSize = new System.Drawing.Size(220, 30);
            this.chkFoundBalances.Name = "chkFoundBalances";
            this.chkFoundBalances.Size = new System.Drawing.Size(220, 30);
            this.chkFoundBalances.TabIndex = 15;
            this.chkFoundBalances.Text = "  Existing balances were found.\r\n  Check here to continue anyway.";
            this.chkFoundBalances.UseVisualStyleBackColor = true;
            this.chkFoundBalances.CheckedChanged += new System.EventHandler(this.chkIncompleteAndFound_CheckedChanged);
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.Gray;
            this.btnDetails.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Location = new System.Drawing.Point(48, 240);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(150, 35);
            this.btnDetails.TabIndex = 13;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescription.Location = new System.Drawing.Point(30, 105);
            this.lblDescription.MaximumSize = new System.Drawing.Size(220, 0);
            this.lblDescription.MinimumSize = new System.Drawing.Size(220, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(220, 120);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "All applications received during\r\nthis cycle will be billed to the\r\nappropriate c" +
    "lient\'s invoice\r\nusing the configured invoice line\r\nstructure, price, invoice di" +
    "vision,\r\nand billing address.";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMonth.Location = new System.Drawing.Point(68, 61);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(128, 39);
            this.lblMonth.TabIndex = 10;
            this.lblMonth.Text = "04/2015";
            // 
            // lblBillingCycleIs
            // 
            this.lblBillingCycleIs.AutoSize = true;
            this.lblBillingCycleIs.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillingCycleIs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBillingCycleIs.Location = new System.Drawing.Point(30, 30);
            this.lblBillingCycleIs.Name = "lblBillingCycleIs";
            this.lblBillingCycleIs.Size = new System.Drawing.Size(232, 21);
            this.lblBillingCycleIs.TabIndex = 11;
            this.lblBillingCycleIs.Text = "The Current Billing Cycle is:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlButtons.Location = new System.Drawing.Point(0, 316);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(540, 80);
            this.pnlButtons.TabIndex = 12;
            // 
            // tabPageInProgress
            // 
            this.tabPageInProgress.Controls.Add(this.picInvoices);
            this.tabPageInProgress.Controls.Add(this.picRoseMoneyInProgress);
            this.tabPageInProgress.Controls.Add(this.pnlInProgress);
            this.tabPageInProgress.Location = new System.Drawing.Point(4, 22);
            this.tabPageInProgress.Name = "tabPageInProgress";
            this.tabPageInProgress.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInProgress.Size = new System.Drawing.Size(532, 398);
            this.tabPageInProgress.TabIndex = 1;
            this.tabPageInProgress.Text = "tabPage2";
            this.tabPageInProgress.UseVisualStyleBackColor = true;
            // 
            // picInvoices
            // 
            this.picInvoices.Image = global::PaaApplication.Properties.Resources.invoices;
            this.picInvoices.Location = new System.Drawing.Point(205, 25);
            this.picInvoices.Name = "picInvoices";
            this.picInvoices.Size = new System.Drawing.Size(275, 248);
            this.picInvoices.TabIndex = 20;
            this.picInvoices.TabStop = false;
            // 
            // picRoseMoneyInProgress
            // 
            this.picRoseMoneyInProgress.Image = global::PaaApplication.Properties.Resources.rose_money;
            this.picRoseMoneyInProgress.Location = new System.Drawing.Point(70, 80);
            this.picRoseMoneyInProgress.Name = "picRoseMoneyInProgress";
            this.picRoseMoneyInProgress.Size = new System.Drawing.Size(80, 130);
            this.picRoseMoneyInProgress.TabIndex = 19;
            this.picRoseMoneyInProgress.TabStop = false;
            // 
            // pnlInProgress
            // 
            this.pnlInProgress.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlInProgress.Controls.Add(this.btnCancelProgress);
            this.pnlInProgress.Controls.Add(this.lblBillingAppsFor);
            this.pnlInProgress.Controls.Add(this.proBillingPercentage);
            this.pnlInProgress.Location = new System.Drawing.Point(0, 296);
            this.pnlInProgress.Name = "pnlInProgress";
            this.pnlInProgress.Size = new System.Drawing.Size(540, 100);
            this.pnlInProgress.TabIndex = 13;
            // 
            // btnCancelProgress
            // 
            this.btnCancelProgress.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancelProgress.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelProgress.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.btnCancelProgress.Location = new System.Drawing.Point(453, 52);
            this.btnCancelProgress.Name = "btnCancelProgress";
            this.btnCancelProgress.Size = new System.Drawing.Size(70, 35);
            this.btnCancelProgress.TabIndex = 1;
            this.btnCancelProgress.Text = "Cancel";
            this.btnCancelProgress.UseVisualStyleBackColor = false;
            this.btnCancelProgress.Click += new System.EventHandler(this.btnCancelProgress_Click);
            // 
            // lblBillingAppsFor
            // 
            this.lblBillingAppsFor.AutoSize = true;
            this.lblBillingAppsFor.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.lblBillingAppsFor.ForeColor = System.Drawing.SystemColors.Window;
            this.lblBillingAppsFor.Location = new System.Drawing.Point(22, 52);
            this.lblBillingAppsFor.Name = "lblBillingAppsFor";
            this.lblBillingAppsFor.Size = new System.Drawing.Size(155, 20);
            this.lblBillingAppsFor.TabIndex = 0;
            this.lblBillingAppsFor.Text = "Billing Applications for:";
            // 
            // proBillingPercentage
            // 
            this.proBillingPercentage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.proBillingPercentage.ForeColor = System.Drawing.SystemColors.Window;
            this.proBillingPercentage.Location = new System.Drawing.Point(8, 12);
            this.proBillingPercentage.Name = "proBillingPercentage";
            this.proBillingPercentage.Size = new System.Drawing.Size(515, 30);
            this.proBillingPercentage.Step = 1;
            this.proBillingPercentage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.proBillingPercentage.TabIndex = 0;
            // 
            // FormAutomaticBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(539, 417);
            this.Controls.Add(this.tabStep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAutomaticBilling";
            this.Text = "Automatic Billing";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormAutomaticBilling_LoadCompleted);
            this.Load += new System.EventHandler(this.FormAutomaticBilling_Load);
            this.tabStep.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoseMoneyMain)).EndInit();
            this.tabPageInProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRoseMoneyInProgress)).EndInit();
            this.pnlInProgress.ResumeLayout(false);
            this.pnlInProgress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendControls.TablessTabControl tabStep;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageInProgress;
        private System.Windows.Forms.PictureBox picRoseMoneyMain;
        private System.Windows.Forms.CheckBox chkMonthIncomplete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBillApps;
        private System.Windows.Forms.CheckBox chkFoundBalances;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblBillingCycleIs;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlInProgress;
        private System.Windows.Forms.PictureBox picRoseMoneyInProgress;
        private System.Windows.Forms.ProgressBar proBillingPercentage;
        private System.Windows.Forms.Button btnCancelProgress;
        private System.Windows.Forms.Label lblBillingAppsFor;
        private System.Windows.Forms.PictureBox picInvoices;

    }
}