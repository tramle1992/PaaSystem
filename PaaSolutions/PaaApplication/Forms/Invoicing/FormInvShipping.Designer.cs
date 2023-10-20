namespace PaaApplication.Forms.Invoicing
{
    partial class FormInvShipping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvShipping));
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.chkInPdf = new System.Windows.Forms.CheckBox();
            this.picRoseMoneyMain = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBillApps = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblBillingCycleIs = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.tabStep = new PaaApplication.ExtendControls.TablessTabControl();
            this.tabPageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoseMoneyMain)).BeginInit();
            this.tabStep.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.chkInPdf);
            this.tabPageMain.Controls.Add(this.picRoseMoneyMain);
            this.tabPageMain.Controls.Add(this.btnCancel);
            this.tabPageMain.Controls.Add(this.btnBillApps);
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
            // chkInPdf
            // 
            this.chkInPdf.AutoSize = true;
            this.chkInPdf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkInPdf.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInPdf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkInPdf.Location = new System.Drawing.Point(285, 235);
            this.chkInPdf.MaximumSize = new System.Drawing.Size(220, 30);
            this.chkInPdf.MinimumSize = new System.Drawing.Size(220, 30);
            this.chkInPdf.Name = "chkInPdf";
            this.chkInPdf.Size = new System.Drawing.Size(220, 30);
            this.chkInPdf.TabIndex = 20;
            this.chkInPdf.Text = "  Ship all invoices in PDF";
            this.chkInPdf.UseVisualStyleBackColor = true;
            // 
            // picRoseMoneyMain
            // 
            this.picRoseMoneyMain.Image = global::PaaApplication.Properties.Resources.worldmoney;
            this.picRoseMoneyMain.InitialImage = global::PaaApplication.Properties.Resources.worldmoney;
            this.picRoseMoneyMain.Location = new System.Drawing.Point(256, 12);
            this.picRoseMoneyMain.Name = "picRoseMoneyMain";
            this.picRoseMoneyMain.Size = new System.Drawing.Size(267, 188);
            this.picRoseMoneyMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRoseMoneyMain.TabIndex = 19;
            this.picRoseMoneyMain.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(350, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 60);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBillApps
            // 
            this.btnBillApps.BackColor = System.Drawing.SystemColors.Window;
            this.btnBillApps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBillApps.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.btnBillApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBillApps.Location = new System.Drawing.Point(48, 315);
            this.btnBillApps.Name = "btnBillApps";
            this.btnBillApps.Size = new System.Drawing.Size(150, 60);
            this.btnBillApps.TabIndex = 16;
            this.btnBillApps.Text = "Ship Invoices";
            this.btnBillApps.UseVisualStyleBackColor = false;
            this.btnBillApps.Click += new System.EventHandler(this.btnBillApps_Click);
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
            this.lblDescription.Size = new System.Drawing.Size(220, 160);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
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
            this.lblBillingCycleIs.Location = new System.Drawing.Point(21, 30);
            this.lblBillingCycleIs.Name = "lblBillingCycleIs";
            this.lblBillingCycleIs.Size = new System.Drawing.Size(232, 21);
            this.lblBillingCycleIs.TabIndex = 11;
            this.lblBillingCycleIs.Text = "The Current Billing Cycle is:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Firebrick;
            this.pnlButtons.Location = new System.Drawing.Point(0, 296);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(540, 100);
            this.pnlButtons.TabIndex = 12;
            // 
            // tabStep
            // 
            this.tabStep.Controls.Add(this.tabPageMain);
            this.tabStep.Location = new System.Drawing.Point(0, 0);
            this.tabStep.Name = "tabStep";
            this.tabStep.SelectedIndex = 0;
            this.tabStep.Size = new System.Drawing.Size(540, 424);
            this.tabStep.TabIndex = 0;
            // 
            // FormInvShipping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(539, 400);
            this.Controls.Add(this.tabStep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInvShipping";
            this.Text = "Ship All Current Invoices";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormAutomaticBilling_LoadCompleted);
            this.Load += new System.EventHandler(this.FormAutomaticBilling_Load);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoseMoneyMain)).EndInit();
            this.tabStep.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBillApps;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblBillingCycleIs;
        private System.Windows.Forms.Panel pnlButtons;
        private ExtendControls.TablessTabControl tabStep;
        private System.Windows.Forms.PictureBox picRoseMoneyMain;
        private System.Windows.Forms.CheckBox chkInPdf;
    }
}