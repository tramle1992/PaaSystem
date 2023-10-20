namespace PaaApplication.Forms.Invoicing
{
    partial class FormBillingValidation
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnEditApps = new System.Windows.Forms.Button();
            this.btnViewInvoices = new System.Windows.Forms.Button();
            this.grpSeparate = new System.Windows.Forms.GroupBox();
            this.grpBillingStats = new System.Windows.Forms.GroupBox();
            this.txtSmallestInv = new System.Windows.Forms.Label();
            this.txtAvgInvAmount = new System.Windows.Forms.Label();
            this.txtAvgRevenuePerApp = new System.Windows.Forms.Label();
            this.lblSmallestInv = new System.Windows.Forms.Label();
            this.lblAvgInvAmount = new System.Windows.Forms.Label();
            this.lblAvgRevenuePerApp = new System.Windows.Forms.Label();
            this.txtLargestInv = new System.Windows.Forms.Label();
            this.txtTotalVolumn = new System.Windows.Forms.Label();
            this.txtTotalInvs = new System.Windows.Forms.Label();
            this.lblLargestInv = new System.Windows.Forms.Label();
            this.lblTotalVolumn = new System.Windows.Forms.Label();
            this.lblTotalInvs = new System.Windows.Forms.Label();
            this.lblBillingStats = new System.Windows.Forms.Label();
            this.rdoAllAppsAppearToBeBilled = new System.Windows.Forms.RadioButton();
            this.rdoSomeAppsAppearNotToBeBilled = new System.Windows.Forms.RadioButton();
            this.olvApps = new BrightIdeasSoftware.ObjectListView();
            this.olvColAppName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColClientName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColReportType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvoiceDivision = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnBillSelectedApps = new System.Windows.Forms.Button();
            this.btnBillAllApps = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.grpAnalyzingBilling = new System.Windows.Forms.GroupBox();
            this.proAnalyzePercentage = new System.Windows.Forms.ProgressBar();
            this.lblAnalyzingBilling = new System.Windows.Forms.Label();
            this.grpBillingStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvApps)).BeginInit();
            this.grpAnalyzingBilling.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(292, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Application Billing Validation 04 / 2015";
            // 
            // btnEditApps
            // 
            this.btnEditApps.BackColor = System.Drawing.Color.Gray;
            this.btnEditApps.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditApps.ForeColor = System.Drawing.Color.White;
            this.btnEditApps.Location = new System.Drawing.Point(686, 469);
            this.btnEditApps.Name = "btnEditApps";
            this.btnEditApps.Size = new System.Drawing.Size(80, 29);
            this.btnEditApps.TabIndex = 7;
            this.btnEditApps.Text = "Edit Apps";
            this.btnEditApps.UseVisualStyleBackColor = false;
            this.btnEditApps.Click += new System.EventHandler(this.btnEditApps_Click);
            // 
            // btnViewInvoices
            // 
            this.btnViewInvoices.BackColor = System.Drawing.Color.Gray;
            this.btnViewInvoices.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInvoices.ForeColor = System.Drawing.Color.White;
            this.btnViewInvoices.Location = new System.Drawing.Point(772, 469);
            this.btnViewInvoices.Name = "btnViewInvoices";
            this.btnViewInvoices.Size = new System.Drawing.Size(117, 29);
            this.btnViewInvoices.TabIndex = 8;
            this.btnViewInvoices.Text = "View Invoice(s)";
            this.btnViewInvoices.UseVisualStyleBackColor = false;
            this.btnViewInvoices.Click += new System.EventHandler(this.btnViewInvoices_Click);
            // 
            // grpSeparate
            // 
            this.grpSeparate.ForeColor = System.Drawing.Color.DarkGray;
            this.grpSeparate.Location = new System.Drawing.Point(18, 32);
            this.grpSeparate.Name = "grpSeparate";
            this.grpSeparate.Size = new System.Drawing.Size(870, 2);
            this.grpSeparate.TabIndex = 0;
            this.grpSeparate.TabStop = false;
            // 
            // grpBillingStats
            // 
            this.grpBillingStats.Controls.Add(this.txtSmallestInv);
            this.grpBillingStats.Controls.Add(this.txtAvgInvAmount);
            this.grpBillingStats.Controls.Add(this.txtAvgRevenuePerApp);
            this.grpBillingStats.Controls.Add(this.lblSmallestInv);
            this.grpBillingStats.Controls.Add(this.lblAvgInvAmount);
            this.grpBillingStats.Controls.Add(this.lblAvgRevenuePerApp);
            this.grpBillingStats.Controls.Add(this.txtLargestInv);
            this.grpBillingStats.Controls.Add(this.txtTotalVolumn);
            this.grpBillingStats.Controls.Add(this.txtTotalInvs);
            this.grpBillingStats.Controls.Add(this.lblLargestInv);
            this.grpBillingStats.Controls.Add(this.lblTotalVolumn);
            this.grpBillingStats.Controls.Add(this.lblTotalInvs);
            this.grpBillingStats.Controls.Add(this.lblBillingStats);
            this.grpBillingStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBillingStats.Location = new System.Drawing.Point(21, 44);
            this.grpBillingStats.Name = "grpBillingStats";
            this.grpBillingStats.Size = new System.Drawing.Size(867, 100);
            this.grpBillingStats.TabIndex = 0;
            this.grpBillingStats.TabStop = false;
            // 
            // txtSmallestInv
            // 
            this.txtSmallestInv.AutoSize = true;
            this.txtSmallestInv.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSmallestInv.Location = new System.Drawing.Point(668, 70);
            this.txtSmallestInv.Name = "txtSmallestInv";
            this.txtSmallestInv.Size = new System.Drawing.Size(44, 16);
            this.txtSmallestInv.TabIndex = 0;
            this.txtSmallestInv.Text = "$0.00";
            // 
            // txtAvgInvAmount
            // 
            this.txtAvgInvAmount.AutoSize = true;
            this.txtAvgInvAmount.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgInvAmount.Location = new System.Drawing.Point(668, 48);
            this.txtAvgInvAmount.Name = "txtAvgInvAmount";
            this.txtAvgInvAmount.Size = new System.Drawing.Size(60, 16);
            this.txtAvgInvAmount.TabIndex = 0;
            this.txtAvgInvAmount.Text = "$188.38";
            // 
            // txtAvgRevenuePerApp
            // 
            this.txtAvgRevenuePerApp.AutoSize = true;
            this.txtAvgRevenuePerApp.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgRevenuePerApp.Location = new System.Drawing.Point(668, 24);
            this.txtAvgRevenuePerApp.Name = "txtAvgRevenuePerApp";
            this.txtAvgRevenuePerApp.Size = new System.Drawing.Size(52, 16);
            this.txtAvgRevenuePerApp.TabIndex = 0;
            this.txtAvgRevenuePerApp.Text = "$60.73";
            // 
            // lblSmallestInv
            // 
            this.lblSmallestInv.AutoSize = true;
            this.lblSmallestInv.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmallestInv.Location = new System.Drawing.Point(544, 70);
            this.lblSmallestInv.Name = "lblSmallestInv";
            this.lblSmallestInv.Size = new System.Drawing.Size(117, 15);
            this.lblSmallestInv.TabIndex = 0;
            this.lblSmallestInv.Text = "SMALLEST  INVOICE:";
            // 
            // lblAvgInvAmount
            // 
            this.lblAvgInvAmount.AutoSize = true;
            this.lblAvgInvAmount.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgInvAmount.Location = new System.Drawing.Point(494, 48);
            this.lblAvgInvAmount.Name = "lblAvgInvAmount";
            this.lblAvgInvAmount.Size = new System.Drawing.Size(167, 15);
            this.lblAvgInvAmount.TabIndex = 0;
            this.lblAvgInvAmount.Text = "AVERAGE  INVOICE  AMOUNT:";
            // 
            // lblAvgRevenuePerApp
            // 
            this.lblAvgRevenuePerApp.AutoSize = true;
            this.lblAvgRevenuePerApp.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgRevenuePerApp.Location = new System.Drawing.Point(435, 24);
            this.lblAvgRevenuePerApp.Name = "lblAvgRevenuePerApp";
            this.lblAvgRevenuePerApp.Size = new System.Drawing.Size(226, 15);
            this.lblAvgRevenuePerApp.TabIndex = 0;
            this.lblAvgRevenuePerApp.Text = "AVERAGE  REVENUE  PER  APPLICATION:";
            // 
            // txtLargestInv
            // 
            this.txtLargestInv.AutoSize = true;
            this.txtLargestInv.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLargestInv.Location = new System.Drawing.Point(240, 70);
            this.txtLargestInv.Name = "txtLargestInv";
            this.txtLargestInv.Size = new System.Drawing.Size(72, 16);
            this.txtLargestInv.TabIndex = 0;
            this.txtLargestInv.Text = "$3,670.00";
            // 
            // txtTotalVolumn
            // 
            this.txtTotalVolumn.AutoSize = true;
            this.txtTotalVolumn.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalVolumn.Location = new System.Drawing.Point(240, 48);
            this.txtTotalVolumn.Name = "txtTotalVolumn";
            this.txtTotalVolumn.Size = new System.Drawing.Size(80, 16);
            this.txtTotalVolumn.TabIndex = 0;
            this.txtTotalVolumn.Text = "$92,345.00";
            // 
            // txtTotalInvs
            // 
            this.txtTotalInvs.AutoSize = true;
            this.txtTotalInvs.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalInvs.Location = new System.Drawing.Point(240, 24);
            this.txtTotalInvs.Name = "txtTotalInvs";
            this.txtTotalInvs.Size = new System.Drawing.Size(32, 16);
            this.txtTotalInvs.TabIndex = 0;
            this.txtTotalInvs.Text = "491";
            // 
            // lblLargestInv
            // 
            this.lblLargestInv.AutoSize = true;
            this.lblLargestInv.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLargestInv.Location = new System.Drawing.Point(117, 70);
            this.lblLargestInv.Name = "lblLargestInv";
            this.lblLargestInv.Size = new System.Drawing.Size(112, 15);
            this.lblLargestInv.TabIndex = 0;
            this.lblLargestInv.Text = "LARGEST  INVOICE:";
            // 
            // lblTotalVolumn
            // 
            this.lblTotalVolumn.AutoSize = true;
            this.lblTotalVolumn.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVolumn.Location = new System.Drawing.Point(131, 48);
            this.lblTotalVolumn.Name = "lblTotalVolumn";
            this.lblTotalVolumn.Size = new System.Drawing.Size(98, 15);
            this.lblTotalVolumn.TabIndex = 0;
            this.lblTotalVolumn.Text = "TOTAL  VOLUME:";
            // 
            // lblTotalInvs
            // 
            this.lblTotalInvs.AutoSize = true;
            this.lblTotalInvs.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInvs.Location = new System.Drawing.Point(133, 24);
            this.lblTotalInvs.Name = "lblTotalInvs";
            this.lblTotalInvs.Size = new System.Drawing.Size(96, 15);
            this.lblTotalInvs.TabIndex = 0;
            this.lblTotalInvs.Text = "#  OF  INVOICES:";
            // 
            // lblBillingStats
            // 
            this.lblBillingStats.AutoSize = true;
            this.lblBillingStats.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillingStats.Location = new System.Drawing.Point(13, -2);
            this.lblBillingStats.Name = "lblBillingStats";
            this.lblBillingStats.Size = new System.Drawing.Size(145, 15);
            this.lblBillingStats.TabIndex = 0;
            this.lblBillingStats.Text = " BILLING  STATISTICS ";
            // 
            // rdoAllAppsAppearToBeBilled
            // 
            this.rdoAllAppsAppearToBeBilled.AutoSize = true;
            this.rdoAllAppsAppearToBeBilled.Enabled = false;
            this.rdoAllAppsAppearToBeBilled.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAllAppsAppearToBeBilled.Location = new System.Drawing.Point(140, 152);
            this.rdoAllAppsAppearToBeBilled.Name = "rdoAllAppsAppearToBeBilled";
            this.rdoAllAppsAppearToBeBilled.Size = new System.Drawing.Size(263, 19);
            this.rdoAllAppsAppearToBeBilled.TabIndex = 2;
            this.rdoAllAppsAppearToBeBilled.TabStop = true;
            this.rdoAllAppsAppearToBeBilled.Text = "ALL  APPLICATIONS  APPEAR  TO  BE  BILLED";
            this.rdoAllAppsAppearToBeBilled.UseVisualStyleBackColor = true;
            this.rdoAllAppsAppearToBeBilled.CheckedChanged += new System.EventHandler(this.rdoBillApps_CheckedChanged);
            // 
            // rdoSomeAppsAppearNotToBeBilled
            // 
            this.rdoSomeAppsAppearNotToBeBilled.AutoSize = true;
            this.rdoSomeAppsAppearNotToBeBilled.Enabled = false;
            this.rdoSomeAppsAppearNotToBeBilled.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSomeAppsAppearNotToBeBilled.Location = new System.Drawing.Point(460, 152);
            this.rdoSomeAppsAppearNotToBeBilled.Name = "rdoSomeAppsAppearNotToBeBilled";
            this.rdoSomeAppsAppearNotToBeBilled.Size = new System.Drawing.Size(299, 19);
            this.rdoSomeAppsAppearNotToBeBilled.TabIndex = 3;
            this.rdoSomeAppsAppearNotToBeBilled.TabStop = true;
            this.rdoSomeAppsAppearNotToBeBilled.Text = "SOME  APPLICATION  APPEAR  NOT  TO  BE  BILLED";
            this.rdoSomeAppsAppearNotToBeBilled.UseVisualStyleBackColor = true;
            this.rdoSomeAppsAppearNotToBeBilled.CheckedChanged += new System.EventHandler(this.rdoBillApps_CheckedChanged);
            // 
            // olvApps
            // 
            this.olvApps.AllColumns.Add(this.olvColAppName);
            this.olvApps.AllColumns.Add(this.olvColClientName);
            this.olvApps.AllColumns.Add(this.olvColReportType);
            this.olvApps.AllColumns.Add(this.olvColInvoiceDivision);
            this.olvApps.AllColumns.Add(this.olvColStatus);
            this.olvApps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColAppName,
            this.olvColClientName,
            this.olvColReportType,
            this.olvColInvoiceDivision,
            this.olvColStatus});
            this.olvApps.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvApps.FullRowSelect = true;
            this.olvApps.HideSelection = false;
            this.olvApps.Location = new System.Drawing.Point(21, 179);
            this.olvApps.Name = "olvApps";
            this.olvApps.OwnerDraw = true;
            this.olvApps.SelectColumnsOnRightClick = false;
            this.olvApps.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.olvApps.ShowFilterMenuOnRightClick = false;
            this.olvApps.ShowGroups = false;
            this.olvApps.Size = new System.Drawing.Size(867, 276);
            this.olvApps.TabIndex = 4;
            this.olvApps.UseCompatibleStateImageBehavior = false;
            this.olvApps.View = System.Windows.Forms.View.Details;
            // 
            // olvColAppName
            // 
            this.olvColAppName.Text = "Name";
            this.olvColAppName.Width = 210;
            // 
            // olvColClientName
            // 
            this.olvColClientName.AspectName = "ClientAppliedName";
            this.olvColClientName.Text = "Client";
            this.olvColClientName.Width = 210;
            // 
            // olvColReportType
            // 
            this.olvColReportType.AspectName = "ReportTypeName";
            this.olvColReportType.Text = "Type";
            this.olvColReportType.Width = 90;
            // 
            // olvColInvoiceDivision
            // 
            this.olvColInvoiceDivision.AspectName = "InvoiceDivision";
            this.olvColInvoiceDivision.Text = "Invoice Division";
            this.olvColInvoiceDivision.Width = 150;
            // 
            // olvColStatus
            // 
            this.olvColStatus.Text = "Status";
            this.olvColStatus.Width = 100;
            // 
            // btnBillSelectedApps
            // 
            this.btnBillSelectedApps.BackColor = System.Drawing.Color.Gray;
            this.btnBillSelectedApps.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillSelectedApps.ForeColor = System.Drawing.Color.White;
            this.btnBillSelectedApps.Location = new System.Drawing.Point(542, 469);
            this.btnBillSelectedApps.Name = "btnBillSelectedApps";
            this.btnBillSelectedApps.Size = new System.Drawing.Size(138, 29);
            this.btnBillSelectedApps.TabIndex = 6;
            this.btnBillSelectedApps.Text = "Bill Selected Apps";
            this.btnBillSelectedApps.UseVisualStyleBackColor = false;
            this.btnBillSelectedApps.Click += new System.EventHandler(this.btnBillSelectedApps_Click);
            // 
            // btnBillAllApps
            // 
            this.btnBillAllApps.BackColor = System.Drawing.Color.Gray;
            this.btnBillAllApps.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillAllApps.ForeColor = System.Drawing.Color.White;
            this.btnBillAllApps.Location = new System.Drawing.Point(442, 469);
            this.btnBillAllApps.Name = "btnBillAllApps";
            this.btnBillAllApps.Size = new System.Drawing.Size(94, 29);
            this.btnBillAllApps.TabIndex = 5;
            this.btnBillAllApps.Text = "Bill All Apps";
            this.btnBillAllApps.UseVisualStyleBackColor = false;
            this.btnBillAllApps.Click += new System.EventHandler(this.btnBillAllApps_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.Gray;
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDone.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(20, 469);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(93, 29);
            this.btnDone.TabIndex = 9;
            this.btnDone.Text = "DONE";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // grpAnalyzingBilling
            // 
            this.grpAnalyzingBilling.Controls.Add(this.proAnalyzePercentage);
            this.grpAnalyzingBilling.Controls.Add(this.lblAnalyzingBilling);
            this.grpAnalyzingBilling.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAnalyzingBilling.Location = new System.Drawing.Point(21, 44);
            this.grpAnalyzingBilling.Name = "grpAnalyzingBilling";
            this.grpAnalyzingBilling.Size = new System.Drawing.Size(867, 100);
            this.grpAnalyzingBilling.TabIndex = 1;
            this.grpAnalyzingBilling.TabStop = false;
            // 
            // proAnalyzePercentage
            // 
            this.proAnalyzePercentage.Location = new System.Drawing.Point(18, 24);
            this.proAnalyzePercentage.Name = "proAnalyzePercentage";
            this.proAnalyzePercentage.Size = new System.Drawing.Size(830, 61);
            this.proAnalyzePercentage.Step = 1;
            this.proAnalyzePercentage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.proAnalyzePercentage.TabIndex = 1;
            // 
            // lblAnalyzingBilling
            // 
            this.lblAnalyzingBilling.AutoSize = true;
            this.lblAnalyzingBilling.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalyzingBilling.Location = new System.Drawing.Point(13, -2);
            this.lblAnalyzingBilling.Name = "lblAnalyzingBilling";
            this.lblAnalyzingBilling.Size = new System.Drawing.Size(155, 15);
            this.lblAnalyzingBilling.TabIndex = 0;
            this.lblAnalyzingBilling.Text = " ANALYZING  BILLING ...";
            // 
            // FormBillingValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.CancelButton = this.btnDone;
            this.ClientSize = new System.Drawing.Size(910, 510);
            this.Controls.Add(this.grpAnalyzingBilling);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnBillSelectedApps);
            this.Controls.Add(this.btnBillAllApps);
            this.Controls.Add(this.olvApps);
            this.Controls.Add(this.rdoSomeAppsAppearNotToBeBilled);
            this.Controls.Add(this.rdoAllAppsAppearToBeBilled);
            this.Controls.Add(this.grpBillingStats);
            this.Controls.Add(this.grpSeparate);
            this.Controls.Add(this.btnViewInvoices);
            this.Controls.Add(this.btnEditApps);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBillingValidation";
            this.Load += new System.EventHandler(this.FormBillingValidation_Load);
            this.grpBillingStats.ResumeLayout(false);
            this.grpBillingStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvApps)).EndInit();
            this.grpAnalyzingBilling.ResumeLayout(false);
            this.grpAnalyzingBilling.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnEditApps;
        private System.Windows.Forms.Button btnViewInvoices;
        private System.Windows.Forms.GroupBox grpSeparate;
        private System.Windows.Forms.GroupBox grpBillingStats;
        private System.Windows.Forms.Label txtLargestInv;
        private System.Windows.Forms.Label txtTotalVolumn;
        private System.Windows.Forms.Label txtTotalInvs;
        private System.Windows.Forms.Label lblLargestInv;
        private System.Windows.Forms.Label lblTotalVolumn;
        private System.Windows.Forms.Label lblTotalInvs;
        private System.Windows.Forms.Label lblBillingStats;
        private System.Windows.Forms.Label txtSmallestInv;
        private System.Windows.Forms.Label txtAvgInvAmount;
        private System.Windows.Forms.Label txtAvgRevenuePerApp;
        private System.Windows.Forms.Label lblSmallestInv;
        private System.Windows.Forms.Label lblAvgInvAmount;
        private System.Windows.Forms.Label lblAvgRevenuePerApp;
        private System.Windows.Forms.RadioButton rdoAllAppsAppearToBeBilled;
        private System.Windows.Forms.RadioButton rdoSomeAppsAppearNotToBeBilled;
        private BrightIdeasSoftware.ObjectListView olvApps;
        private BrightIdeasSoftware.OLVColumn olvColAppName;
        private BrightIdeasSoftware.OLVColumn olvColClientName;
        private BrightIdeasSoftware.OLVColumn olvColReportType;
        private BrightIdeasSoftware.OLVColumn olvColInvoiceDivision;
        private BrightIdeasSoftware.OLVColumn olvColStatus;
        private System.Windows.Forms.Button btnBillSelectedApps;
        private System.Windows.Forms.Button btnBillAllApps;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.GroupBox grpAnalyzingBilling;
        private System.Windows.Forms.Label lblAnalyzingBilling;
        private System.Windows.Forms.ProgressBar proAnalyzePercentage;       
    }
}