namespace PaaApplication.Forms.AppExplore
{
    partial class FormAppExplore
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.olvAppExplore = new BrightIdeasSoftware.ObjectListView();
            this.olvcolAppName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolClient = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolScreener = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolReportType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolReceived = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolCompleted = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolLocation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolCommunity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvUnitNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolInvoiceDivision = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColRecommendation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            this.cmnuOLVAppExplore = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendReportToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailRecipientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.createDataGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromAllShownApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromSelectedApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAppMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuItemEportCreditFullApps = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuItemEportCreditSelectedApps = new System.Windows.Forms.ToolStripMenuItem();
            this.printEmailConfirmationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDupAllAppsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDupSelectedAppsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabAppExplore = new System.Windows.Forms.TabControl();
            this.tabAppInfoDetail = new System.Windows.Forms.TabPage();
            this.partSixControl1 = new PaaApplication.UserControls.AppExplore.ApplicantInfo.PartSixControl();
            this.partOneControl1 = new PaaApplication.UserControls.AppExplore.PartOneControl();
            this.partTwoControl1 = new PaaApplication.UserControls.AppExplore.ApplicantInfo.PartTwoControl();
            this.partFiveControl1 = new PaaApplication.UserControls.AppExplore.ApplicantInfo.PartFiveControl();
            this.partFourControl1 = new PaaApplication.UserControls.AppExplore.ApplicantInfo.PartFourControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.partSixControl2 = new PaaApplication.UserControls.AppExplore.ApplicantInfo.PartSixControl();
            this.partThreeControl1 = new PaaApplication.UserControls.AppExplore.ApplicantInfo.PartThreeControl();
            this.tabCreditInfoDetail = new System.Windows.Forms.TabPage();
            this.ciTypeTwo1 = new PaaApplication.UserControls.AppExplore.CreditInfo.CITypeTwoControl();
            this.ciTypeOne1 = new PaaApplication.UserControls.AppExplore.CreditInfo.CITypeOneControl();
            this.tabEmpInfoDetail = new System.Windows.Forms.TabPage();
            this.empTypeTwo1 = new PaaApplication.UserControls.AppExplore.EmpInfo.EmpTypeTwoControl();
            this.empTypeOne1 = new PaaApplication.UserControls.AppExplore.EmpInfo.EmpTypeOneControl();
            this.tabRentalInfoDetail = new System.Windows.Forms.TabPage();
            this.rentalControl1 = new PaaApplication.UserControls.AppExplore.RentalInfo.RentalControl();
            this.tabCriEviDetail = new System.Windows.Forms.TabPage();
            this.criEvControl1 = new PaaApplication.UserControls.AppExplore.GeneralInfo.CriEvControl();
            this.tabFinalDetail = new System.Windows.Forms.TabPage();
            this.finalInfoControl1 = new PaaApplication.UserControls.AppExplore.GeneralInfo.FinalInfoControl();
            this.tabMenuDetail = new System.Windows.Forms.TabPage();
            this.appMenuControl1 = new PaaApplication.UserControls.AppExplore.GeneralInfo.AppMenuControl();
            this.tabNetToolDetail = new System.Windows.Forms.TabPage();
            this.netToolControl1 = new PaaApplication.UserControls.AppExplore.GeneralInfo.NetToolControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvAppExplore)).BeginInit();
            this.cmnuOLVAppExplore.SuspendLayout();
            this.tabAppExplore.SuspendLayout();
            this.tabAppInfoDetail.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabCreditInfoDetail.SuspendLayout();
            this.tabEmpInfoDetail.SuspendLayout();
            this.tabRentalInfoDetail.SuspendLayout();
            this.tabCriEviDetail.SuspendLayout();
            this.tabFinalDetail.SuspendLayout();
            this.tabMenuDetail.SuspendLayout();
            this.tabNetToolDetail.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.olvAppExplore);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(11, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 667);
            this.panel1.TabIndex = 16;
            // 
            // olvAppExplore
            // 
            this.olvAppExplore.AllColumns.Add(this.olvcolAppName);
            this.olvAppExplore.AllColumns.Add(this.olvcolClient);
            this.olvAppExplore.AllColumns.Add(this.olvcolScreener);
            this.olvAppExplore.AllColumns.Add(this.olvcolReportType);
            this.olvAppExplore.AllColumns.Add(this.olvcolReceived);
            this.olvAppExplore.AllColumns.Add(this.olvcolCompleted);
            this.olvAppExplore.AllColumns.Add(this.olvcolLocation);
            this.olvAppExplore.AllColumns.Add(this.olvcolCommunity);
            this.olvAppExplore.AllColumns.Add(this.olvUnitNumber);
            this.olvAppExplore.AllColumns.Add(this.olvcolInvoiceDivision);
            this.olvAppExplore.AllColumns.Add(this.olvColRecommendation);
            this.olvAppExplore.AllowDrop = true;
            this.olvAppExplore.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvAppExplore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolAppName,
            this.olvcolClient,
            this.olvcolScreener,
            this.olvcolReportType,
            this.olvcolReceived,
            this.olvcolCompleted,
            this.olvcolLocation});
            this.olvAppExplore.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvAppExplore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.olvAppExplore.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvAppExplore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvAppExplore.FullRowSelect = true;
            this.olvAppExplore.HideSelection = false;
            this.olvAppExplore.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvAppExplore.HotItemStyle = this.hotItemStyle;
            this.olvAppExplore.Location = new System.Drawing.Point(0, 37);
            this.olvAppExplore.Name = "olvAppExplore";
            this.olvAppExplore.ShowGroups = false;
            this.olvAppExplore.Size = new System.Drawing.Size(955, 630);
            this.olvAppExplore.TabIndex = 32;
            this.olvAppExplore.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvAppExplore.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvAppExplore.UseAlternatingBackColors = true;
            this.olvAppExplore.UseCompatibleStateImageBehavior = false;
            this.olvAppExplore.UseCustomSelectionColors = true;
            this.olvAppExplore.UseFiltering = true;
            this.olvAppExplore.UseHotItem = true;
            this.olvAppExplore.View = System.Windows.Forms.View.Details;
            this.olvAppExplore.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvAppExplore_CellClick);
            this.olvAppExplore.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olvAppExplore_CellRightClick);
            this.olvAppExplore.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.olvAppExplore_ItemsChanged);
            this.olvAppExplore.SelectionChanged += new System.EventHandler(this.olvAppExplore_SelectionChanged);
            this.olvAppExplore.ItemActivate += new System.EventHandler(this.olvAppExplore_ItemActivate);
            this.olvAppExplore.DragDrop += new System.Windows.Forms.DragEventHandler(this.olvAppExplore_DragDrop);
            this.olvAppExplore.DragOver += new System.Windows.Forms.DragEventHandler(this.olvAppExplore_DragOver);
            // 
            // olvcolAppName
            // 
            this.olvcolAppName.AspectName = "";
            this.olvcolAppName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolAppName.Text = "Applicant Name";
            this.olvcolAppName.Width = 180;
            // 
            // olvcolClient
            // 
            this.olvcolClient.AspectName = "ClientAppliedName";
            this.olvcolClient.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolClient.Text = "Client";
            this.olvcolClient.Width = 190;
            // 
            // olvcolScreener
            // 
            this.olvcolScreener.AspectName = "ScreenerName";
            this.olvcolScreener.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolScreener.Text = "Screener";
            this.olvcolScreener.Width = 100;
            // 
            // olvcolReportType
            // 
            this.olvcolReportType.AspectName = "ReportTypeName";
            this.olvcolReportType.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolReportType.Text = "Report Type";
            this.olvcolReportType.Width = 130;
            // 
            // olvcolReceived
            // 
            this.olvcolReceived.AspectName = "ReceivedDate";
            this.olvcolReceived.AspectToStringFormat = "{0:MM/dd/yyyy hh:mm tt}";
            this.olvcolReceived.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolReceived.Text = "Received";
            this.olvcolReceived.Width = 160;
            // 
            // olvcolCompleted
            // 
            this.olvcolCompleted.AspectName = "CompletedDate";
            this.olvcolCompleted.AspectToStringFormat = "";
            this.olvcolCompleted.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolCompleted.Text = "Completed";
            this.olvcolCompleted.Width = 160;
            // 
            // olvcolLocation
            // 
            this.olvcolLocation.AspectName = "LocationName";
            this.olvcolLocation.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvcolLocation.IsEditable = false;
            this.olvcolLocation.Text = "Location";
            this.olvcolLocation.Width = 120;
            // 
            // olvcolCommunity
            // 
            this.olvcolCommunity.AspectName = "ReportCommunity";
            this.olvcolCommunity.DisplayIndex = 7;
            this.olvcolCommunity.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvcolCommunity.IsEditable = false;
            this.olvcolCommunity.IsVisible = false;
            this.olvcolCommunity.Text = "Community";
            this.olvcolCommunity.Width = 150;
            // 
            // olvUnitNumber
            // 
            this.olvUnitNumber.AspectName = "UnitNumber";
            this.olvUnitNumber.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvUnitNumber.IsEditable = false;
            this.olvUnitNumber.IsVisible = false;
            this.olvUnitNumber.Text = "Unit Number";
            // 
            // olvcolInvoiceDivision
            // 
            this.olvcolInvoiceDivision.AspectName = "InvoiceDivision";
            this.olvcolInvoiceDivision.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvcolInvoiceDivision.IsEditable = false;
            this.olvcolInvoiceDivision.IsVisible = false;
            this.olvcolInvoiceDivision.Text = "Invoice Division";
            // 
            // olvColRecommendation
            // 
            this.olvColRecommendation.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColRecommendation.IsEditable = false;
            this.olvColRecommendation.IsVisible = false;
            this.olvColRecommendation.Text = "Recommendation";
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtSearch.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.Location = new System.Drawing.Point(0, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(305, 24);
            this.txtSearch.TabIndex = 31;
            this.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.WatermarkText = "#000000";
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // cmnuOLVAppExplore
            // 
            this.cmnuOLVAppExplore.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeLocationToolStripMenuItem,
            this.moveToToolStripMenuItem,
            this.sendReportToToolStripMenuItem,
            this.toolStripSeparator2,
            this.createDataGridToolStripMenuItem,
            this.newAppMenuToolStripMenuItem,
            this.checkForDuplicatesToolStripMenuItem,
            this.searchApplicationToolStripMenuItem,
            this.enterArchiveToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteAppToolStripMenuItem,
            this.addNewAppToolStripMenuItem});
            this.cmnuOLVAppExplore.Name = "cmnuOLVAppExplore";
            this.cmnuOLVAppExplore.Size = new System.Drawing.Size(211, 236);
            this.cmnuOLVAppExplore.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuOLVAppExplore_Opening);
            // 
            // changeLocationToolStripMenuItem
            // 
            this.changeLocationToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.changeLocationToolStripMenuItem.Name = "changeLocationToolStripMenuItem";
            this.changeLocationToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.changeLocationToolStripMenuItem.Text = "Move to Review";
            // 
            // moveToToolStripMenuItem
            // 
            this.moveToToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.moveToToolStripMenuItem.Name = "moveToToolStripMenuItem";
            this.moveToToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.moveToToolStripMenuItem.Text = "Move To";
            // 
            // sendReportToToolStripMenuItem
            // 
            this.sendReportToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printerToolStripMenuItem,
            this.emailRecipientToolStripMenuItem,
            this.websiteToolStripMenuItem});
            this.sendReportToToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.sendReportToToolStripMenuItem.Name = "sendReportToToolStripMenuItem";
            this.sendReportToToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.sendReportToToolStripMenuItem.Text = "Send Report(s) To";
            // 
            // printerToolStripMenuItem
            // 
            this.printerToolStripMenuItem.Name = "printerToolStripMenuItem";
            this.printerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.printerToolStripMenuItem.Text = "Printer";
            this.printerToolStripMenuItem.Click += new System.EventHandler(this.printerToolStripMenuItem_Click);
            // 
            // emailRecipientToolStripMenuItem
            // 
            this.emailRecipientToolStripMenuItem.Name = "emailRecipientToolStripMenuItem";
            this.emailRecipientToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.emailRecipientToolStripMenuItem.Text = "Email Recipient";
            this.emailRecipientToolStripMenuItem.Click += new System.EventHandler(this.emailRecipientToolStripMenuItem_Click);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // createDataGridToolStripMenuItem
            // 
            this.createDataGridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromAllShownApplicationToolStripMenuItem,
            this.fromSelectedApplicationToolStripMenuItem});
            this.createDataGridToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.createDataGridToolStripMenuItem.Name = "createDataGridToolStripMenuItem";
            this.createDataGridToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.createDataGridToolStripMenuItem.Text = "Create Data Grid";
            // 
            // fromAllShownApplicationToolStripMenuItem
            // 
            this.fromAllShownApplicationToolStripMenuItem.Name = "fromAllShownApplicationToolStripMenuItem";
            this.fromAllShownApplicationToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.fromAllShownApplicationToolStripMenuItem.Text = "From All Shown Applications";
            this.fromAllShownApplicationToolStripMenuItem.Click += new System.EventHandler(this.fromAllShownApplicationToolStripMenuItem_Click);
            // 
            // fromSelectedApplicationToolStripMenuItem
            // 
            this.fromSelectedApplicationToolStripMenuItem.Name = "fromSelectedApplicationToolStripMenuItem";
            this.fromSelectedApplicationToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.fromSelectedApplicationToolStripMenuItem.Text = "From Selected Application";
            this.fromSelectedApplicationToolStripMenuItem.Click += new System.EventHandler(this.fromSelectedApplicationToolStripMenuItem_Click);
            // 
            // newAppMenuToolStripMenuItem
            // 
            this.newAppMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuItemEportCreditFullApps,
            this.cmnuItemEportCreditSelectedApps,
            this.printEmailConfirmationsToolStripMenuItem});
            this.newAppMenuToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.newAppMenuToolStripMenuItem.Name = "newAppMenuToolStripMenuItem";
            this.newAppMenuToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.newAppMenuToolStripMenuItem.Text = "New App Menu";
            // 
            // cmnuItemEportCreditFullApps
            // 
            this.cmnuItemEportCreditFullApps.Name = "cmnuItemEportCreditFullApps";
            this.cmnuItemEportCreditFullApps.Size = new System.Drawing.Size(275, 22);
            this.cmnuItemEportCreditFullApps.Text = "Pull Credit Report (All Apps)";
            this.cmnuItemEportCreditFullApps.Click += new System.EventHandler(this.cmnuItemEportCreditFullApps_Click);
            // 
            // cmnuItemEportCreditSelectedApps
            // 
            this.cmnuItemEportCreditSelectedApps.Name = "cmnuItemEportCreditSelectedApps";
            this.cmnuItemEportCreditSelectedApps.Size = new System.Drawing.Size(275, 22);
            this.cmnuItemEportCreditSelectedApps.Text = "Pull Credit Report (Selected Apps)";
            this.cmnuItemEportCreditSelectedApps.Click += new System.EventHandler(this.cmnuItemEportCreditSelectedApps_Click);
            // 
            // printEmailConfirmationsToolStripMenuItem
            // 
            this.printEmailConfirmationsToolStripMenuItem.Name = "printEmailConfirmationsToolStripMenuItem";
            this.printEmailConfirmationsToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.printEmailConfirmationsToolStripMenuItem.Text = "Print/Email Confirmation(s)";
            this.printEmailConfirmationsToolStripMenuItem.Click += new System.EventHandler(this.emailConfirmationsToolStripMenuItem_Click);
            // 
            // searchApplicationToolStripMenuItem
            // 
            this.searchApplicationToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.searchApplicationToolStripMenuItem.Name = "searchApplicationToolStripMenuItem";
            this.searchApplicationToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.searchApplicationToolStripMenuItem.Text = "Search Application...";
            this.searchApplicationToolStripMenuItem.Click += new System.EventHandler(this.searchApplicationToolStripMenuItem_Click);
            // 
            // enterArchiveToolStripMenuItem
            // 
            this.enterArchiveToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.enterArchiveToolStripMenuItem.Name = "enterArchiveToolStripMenuItem";
            this.enterArchiveToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.enterArchiveToolStripMenuItem.Text = "Enter Archive...";
            this.enterArchiveToolStripMenuItem.Click += new System.EventHandler(this.enterArchiveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // deleteAppToolStripMenuItem
            // 
            this.deleteAppToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.deleteAppToolStripMenuItem.Name = "deleteAppToolStripMenuItem";
            this.deleteAppToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.deleteAppToolStripMenuItem.Text = "Delete Application";
            this.deleteAppToolStripMenuItem.Click += new System.EventHandler(this.deleteAppToolStripMenuItem_Click);
            // 
            // addNewAppToolStripMenuItem
            // 
            this.addNewAppToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.addNewAppToolStripMenuItem.Name = "addNewAppToolStripMenuItem";
            this.addNewAppToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.addNewAppToolStripMenuItem.Text = "Create New Application";
            this.addNewAppToolStripMenuItem.Click += new System.EventHandler(this.addNewAppToolStripMenuItem_Click);
            // 
            // checkForDuplicatesToolStripMenuItem
            // 
            this.checkForDuplicatesToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.checkForDuplicatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkDupAllAppsToolStripMenuItem,
            this.checkDupSelectedAppsToolStripMenuItem});
            this.checkForDuplicatesToolStripMenuItem.Name = "checkForDuplicatesToolStripMenuItem";
            this.checkForDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.checkForDuplicatesToolStripMenuItem.Text = "Check For Duplicates";
            // 
            // checkDupAllAppsToolStripMenuItem
            // 
            this.checkDupAllAppsToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.checkDupAllAppsToolStripMenuItem.Name = "checkDupAllAppsToolStripMenuItem";
            this.checkDupAllAppsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.checkDupAllAppsToolStripMenuItem.Text = "All Apps";
            this.checkDupAllAppsToolStripMenuItem.Click += new System.EventHandler(this.checkDupAllAppsToolStripMenuItem_Click);
            // 
            // checkDupSelectedAppsToolStripMenuItem
            // 
            this.checkDupSelectedAppsToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.checkDupSelectedAppsToolStripMenuItem.Name = "checkDupSelectedAppsToolStripMenuItem";
            this.checkDupSelectedAppsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.checkDupSelectedAppsToolStripMenuItem.Text = "Selected Apps";
            this.checkDupSelectedAppsToolStripMenuItem.Click += new System.EventHandler(this.checkDupSelectedAppsToolStripMenuItem_Click);
            // 
            // tabAppExplore
            // 
            this.tabAppExplore.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabAppExplore.Controls.Add(this.tabAppInfoDetail);
            this.tabAppExplore.Controls.Add(this.tabCreditInfoDetail);
            this.tabAppExplore.Controls.Add(this.tabEmpInfoDetail);
            this.tabAppExplore.Controls.Add(this.tabRentalInfoDetail);
            this.tabAppExplore.Controls.Add(this.tabCriEviDetail);
            this.tabAppExplore.Controls.Add(this.tabFinalDetail);
            this.tabAppExplore.Controls.Add(this.tabMenuDetail);
            this.tabAppExplore.Controls.Add(this.tabNetToolDetail);
            this.tabAppExplore.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAppExplore.Location = new System.Drawing.Point(3, 11);
            this.tabAppExplore.Multiline = true;
            this.tabAppExplore.Name = "tabAppExplore";
            this.tabAppExplore.Padding = new System.Drawing.Point(20, 5);
            this.tabAppExplore.SelectedIndex = 0;
            this.tabAppExplore.Size = new System.Drawing.Size(596, 666);
            this.tabAppExplore.TabIndex = 61;
            this.tabAppExplore.TabStop = false;
            // 
            // tabAppInfoDetail
            // 
            this.tabAppInfoDetail.Controls.Add(this.partSixControl1);
            this.tabAppInfoDetail.Controls.Add(this.partOneControl1);
            this.tabAppInfoDetail.Controls.Add(this.partTwoControl1);
            this.tabAppInfoDetail.Controls.Add(this.partFiveControl1);
            this.tabAppInfoDetail.Controls.Add(this.partFourControl1);
            this.tabAppInfoDetail.Controls.Add(this.panel3);
            this.tabAppInfoDetail.Location = new System.Drawing.Point(4, 67);
            this.tabAppInfoDetail.Name = "tabAppInfoDetail";
            this.tabAppInfoDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppInfoDetail.Size = new System.Drawing.Size(588, 595);
            this.tabAppInfoDetail.TabIndex = 0;
            this.tabAppInfoDetail.Text = "Applicant Info";
            this.tabAppInfoDetail.UseVisualStyleBackColor = true;
            // 
            // partSixControl1
            // 
            this.partSixControl1.BackColor = System.Drawing.Color.White;
            this.partSixControl1.Location = new System.Drawing.Point(2, 467);
            this.partSixControl1.Name = "partSixControl1";
            this.partSixControl1.Size = new System.Drawing.Size(582, 121);
            this.partSixControl1.TabIndex = 5;
            // 
            // partOneControl1
            // 
            this.partOneControl1.AutoSize = true;
            this.partOneControl1.BackColor = System.Drawing.Color.White;
            this.partOneControl1.ClientAppliedName = null;
            this.partOneControl1.FormMaster = null;
            this.partOneControl1.Location = new System.Drawing.Point(2, 3);
            this.partOneControl1.Name = "partOneControl1";
            this.partOneControl1.Size = new System.Drawing.Size(585, 120);
            this.partOneControl1.SpecialEntry = null;
            this.partOneControl1.TabIndex = 1;
            // 
            // partTwoControl1
            // 
            this.partTwoControl1.BackColor = System.Drawing.Color.White;
            this.partTwoControl1.Location = new System.Drawing.Point(2, 115);
            this.partTwoControl1.Name = "partTwoControl1";
            this.partTwoControl1.Size = new System.Drawing.Size(575, 126);
            this.partTwoControl1.TabIndex = 2;
            // 
            // partFiveControl1
            // 
            this.partFiveControl1.BackColor = System.Drawing.Color.White;
            this.partFiveControl1.Location = new System.Drawing.Point(2, 350);
            this.partFiveControl1.Name = "partFiveControl1";
            this.partFiveControl1.Size = new System.Drawing.Size(581, 123);
            this.partFiveControl1.TabIndex = 4;
            // 
            // partFourControl1
            // 
            this.partFourControl1.BackColor = System.Drawing.Color.White;
            this.partFourControl1.Location = new System.Drawing.Point(2, 234);
            this.partFourControl1.Name = "partFourControl1";
            this.partFourControl1.Size = new System.Drawing.Size(581, 122);
            this.partFourControl1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.partSixControl2);
            this.panel3.Controls.Add(this.partThreeControl1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(587, 588);
            this.panel3.TabIndex = 15;
            // 
            // partSixControl2
            // 
            this.partSixControl2.BackColor = System.Drawing.Color.White;
            this.partSixControl2.Location = new System.Drawing.Point(2, 350);
            this.partSixControl2.Name = "partSixControl2";
            this.partSixControl2.Size = new System.Drawing.Size(584, 126);
            this.partSixControl2.TabIndex = 4;
            // 
            // partThreeControl1
            // 
            this.partThreeControl1.BackColor = System.Drawing.Color.White;
            this.partThreeControl1.Location = new System.Drawing.Point(2, 117);
            this.partThreeControl1.Name = "partThreeControl1";
            this.partThreeControl1.Size = new System.Drawing.Size(579, 125);
            this.partThreeControl1.TabIndex = 2;
            // 
            // tabCreditInfoDetail
            // 
            this.tabCreditInfoDetail.Controls.Add(this.ciTypeTwo1);
            this.tabCreditInfoDetail.Controls.Add(this.ciTypeOne1);
            this.tabCreditInfoDetail.Location = new System.Drawing.Point(4, 67);
            this.tabCreditInfoDetail.Name = "tabCreditInfoDetail";
            this.tabCreditInfoDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreditInfoDetail.Size = new System.Drawing.Size(588, 595);
            this.tabCreditInfoDetail.TabIndex = 1;
            this.tabCreditInfoDetail.Text = "  Credit Info  ";
            this.tabCreditInfoDetail.UseVisualStyleBackColor = true;
            // 
            // ciTypeTwo1
            // 
            this.ciTypeTwo1.Location = new System.Drawing.Point(1, 9);
            this.ciTypeTwo1.Name = "ciTypeTwo1";
            this.ciTypeTwo1.Size = new System.Drawing.Size(597, 567);
            this.ciTypeTwo1.TabIndex = 1;
            // 
            // ciTypeOne1
            // 
            this.ciTypeOne1.Location = new System.Drawing.Point(0, 9);
            this.ciTypeOne1.Name = "ciTypeOne1";
            this.ciTypeOne1.Size = new System.Drawing.Size(586, 487);
            this.ciTypeOne1.TabIndex = 0;
            // 
            // tabEmpInfoDetail
            // 
            this.tabEmpInfoDetail.Controls.Add(this.empTypeTwo1);
            this.tabEmpInfoDetail.Controls.Add(this.empTypeOne1);
            this.tabEmpInfoDetail.Location = new System.Drawing.Point(4, 67);
            this.tabEmpInfoDetail.Name = "tabEmpInfoDetail";
            this.tabEmpInfoDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmpInfoDetail.Size = new System.Drawing.Size(588, 595);
            this.tabEmpInfoDetail.TabIndex = 2;
            this.tabEmpInfoDetail.Text = "Employment Info";
            this.tabEmpInfoDetail.UseVisualStyleBackColor = true;
            // 
            // empTypeTwo1
            // 
            this.empTypeTwo1.Location = new System.Drawing.Point(2, 7);
            this.empTypeTwo1.Name = "empTypeTwo1";
            this.empTypeTwo1.Size = new System.Drawing.Size(586, 588);
            this.empTypeTwo1.TabIndex = 1;
            // 
            // empTypeOne1
            // 
            this.empTypeOne1.Location = new System.Drawing.Point(1, 10);
            this.empTypeOne1.Name = "empTypeOne1";
            this.empTypeOne1.Size = new System.Drawing.Size(591, 585);
            this.empTypeOne1.TabIndex = 0;
            // 
            // tabRentalInfoDetail
            // 
            this.tabRentalInfoDetail.Controls.Add(this.rentalControl1);
            this.tabRentalInfoDetail.Location = new System.Drawing.Point(4, 67);
            this.tabRentalInfoDetail.Name = "tabRentalInfoDetail";
            this.tabRentalInfoDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabRentalInfoDetail.Size = new System.Drawing.Size(588, 595);
            this.tabRentalInfoDetail.TabIndex = 3;
            this.tabRentalInfoDetail.Text = "  Rental Info  ";
            this.tabRentalInfoDetail.UseVisualStyleBackColor = true;
            // 
            // rentalControl1
            // 
            this.rentalControl1.Location = new System.Drawing.Point(5, 6);
            this.rentalControl1.Name = "rentalControl1";
            this.rentalControl1.Size = new System.Drawing.Size(580, 568);
            this.rentalControl1.TabIndex = 0;
            // 
            // tabCriEviDetail
            // 
            this.tabCriEviDetail.Controls.Add(this.criEvControl1);
            this.tabCriEviDetail.Location = new System.Drawing.Point(4, 67);
            this.tabCriEviDetail.Name = "tabCriEviDetail";
            this.tabCriEviDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabCriEviDetail.Size = new System.Drawing.Size(588, 595);
            this.tabCriEviDetail.TabIndex = 4;
            this.tabCriEviDetail.Text = "Criminal/Eviction";
            this.tabCriEviDetail.UseVisualStyleBackColor = true;
            // 
            // criEvControl1
            // 
            this.criEvControl1.Location = new System.Drawing.Point(-5, 9);
            this.criEvControl1.Name = "criEvControl1";
            this.criEvControl1.Size = new System.Drawing.Size(592, 517);
            this.criEvControl1.TabIndex = 0;
            // 
            // tabFinalDetail
            // 
            this.tabFinalDetail.Controls.Add(this.finalInfoControl1);
            this.tabFinalDetail.Location = new System.Drawing.Point(4, 67);
            this.tabFinalDetail.Name = "tabFinalDetail";
            this.tabFinalDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinalDetail.Size = new System.Drawing.Size(588, 595);
            this.tabFinalDetail.TabIndex = 5;
            this.tabFinalDetail.Text = "Final Info";
            this.tabFinalDetail.UseVisualStyleBackColor = true;
            // 
            // finalInfoControl1
            // 
            this.finalInfoControl1.ClientAppliedName = null;
            this.finalInfoControl1.Location = new System.Drawing.Point(4, 5);
            this.finalInfoControl1.Name = "finalInfoControl1";
            this.finalInfoControl1.Size = new System.Drawing.Size(588, 656);
            this.finalInfoControl1.SpecialCriteriaInfo = null;
            this.finalInfoControl1.TabIndex = 0;
            // 
            // tabMenuDetail
            // 
            this.tabMenuDetail.Controls.Add(this.appMenuControl1);
            this.tabMenuDetail.Location = new System.Drawing.Point(4, 67);
            this.tabMenuDetail.Name = "tabMenuDetail";
            this.tabMenuDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabMenuDetail.Size = new System.Drawing.Size(588, 595);
            this.tabMenuDetail.TabIndex = 6;
            this.tabMenuDetail.Text = "Application Menu";
            this.tabMenuDetail.UseVisualStyleBackColor = true;
            // 
            // appMenuControl1
            // 
            this.appMenuControl1.CausesValidation = false;
            this.appMenuControl1.ClientBillingInfo = null;
            this.appMenuControl1.CompletedDate = null;
            this.appMenuControl1.FormMaster = null;
            this.appMenuControl1.Location = new System.Drawing.Point(0, 2);
            this.appMenuControl1.Name = "appMenuControl1";
            this.appMenuControl1.Size = new System.Drawing.Size(588, 594);
            this.appMenuControl1.TabIndex = 0;
            // 
            // tabNetToolDetail
            // 
            this.tabNetToolDetail.Controls.Add(this.netToolControl1);
            this.tabNetToolDetail.Location = new System.Drawing.Point(4, 67);
            this.tabNetToolDetail.Name = "tabNetToolDetail";
            this.tabNetToolDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabNetToolDetail.Size = new System.Drawing.Size(588, 595);
            this.tabNetToolDetail.TabIndex = 7;
            this.tabNetToolDetail.Text = "Internet Tools";
            this.tabNetToolDetail.UseVisualStyleBackColor = true;
            // 
            // netToolControl1
            // 
            this.netToolControl1.Location = new System.Drawing.Point(7, 9);
            this.netToolControl1.Name = "netToolControl1";
            this.netToolControl1.Size = new System.Drawing.Size(577, 521);
            this.netToolControl1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabAppExplore);
            this.panel2.Location = new System.Drawing.Point(979, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(713, 680);
            this.panel2.TabIndex = 15;
            // 
            // FormAppExplore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 698);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormAppExplore";
            this.Text = "Applications Explore";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormAppExplore_LoadCompleted);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAppExplore_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormAppExplore_VisibleChanged);
            this.Shown += new System.EventHandler(this.FormAppExplore_FormShown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvAppExplore)).EndInit();
            this.cmnuOLVAppExplore.ResumeLayout(false);
            this.tabAppExplore.ResumeLayout(false);
            this.tabAppInfoDetail.ResumeLayout(false);
            this.tabAppInfoDetail.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabCreditInfoDetail.ResumeLayout(false);
            this.tabEmpInfoDetail.ResumeLayout(false);
            this.tabRentalInfoDetail.ResumeLayout(false);
            this.tabCriEviDetail.ResumeLayout(false);
            this.tabFinalDetail.ResumeLayout(false);
            this.tabMenuDetail.ResumeLayout(false);
            this.tabNetToolDetail.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion

        private ExtendControls.WaterMarkTextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private BrightIdeasSoftware.ObjectListView olvAppExplore;
        private BrightIdeasSoftware.OLVColumn olvcolAppName;
        private BrightIdeasSoftware.OLVColumn olvcolClient;
        private BrightIdeasSoftware.OLVColumn olvcolScreener;
        private BrightIdeasSoftware.OLVColumn olvcolReportType;
        private BrightIdeasSoftware.OLVColumn olvcolReceived;
        private BrightIdeasSoftware.OLVColumn olvcolCompleted;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private System.Windows.Forms.ContextMenuStrip cmnuOLVAppExplore;
        private System.Windows.Forms.ToolStripMenuItem newAppMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemEportCreditFullApps;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemEportCreditSelectedApps;
        private System.Windows.Forms.ToolStripMenuItem sendReportToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailRecipientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem createDataGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromAllShownApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromSelectedApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printEmailConfirmationsToolStripMenuItem;
        private System.Windows.Forms.TabControl tabAppExplore;
        private System.Windows.Forms.TabPage tabAppInfoDetail;
        private UserControls.AppExplore.ApplicantInfo.PartSixControl partSixControl2;
        private UserControls.AppExplore.ApplicantInfo.PartFiveControl partFiveControl1;
        private UserControls.AppExplore.ApplicantInfo.PartSixControl partSixControl1;
        private UserControls.AppExplore.ApplicantInfo.PartThreeControl partThreeControl1;
        private UserControls.AppExplore.PartOneControl partOneControl1;
        private UserControls.AppExplore.ApplicantInfo.PartFourControl partFourControl1;
        private UserControls.AppExplore.ApplicantInfo.PartTwoControl partTwoControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabPage tabCreditInfoDetail;
        private UserControls.AppExplore.CreditInfo.CITypeTwoControl ciTypeTwo1;
        private UserControls.AppExplore.CreditInfo.CITypeOneControl ciTypeOne1;
        private System.Windows.Forms.TabPage tabEmpInfoDetail;
        private UserControls.AppExplore.EmpInfo.EmpTypeTwoControl empTypeTwo1;
        private UserControls.AppExplore.EmpInfo.EmpTypeOneControl empTypeOne1;
        private System.Windows.Forms.TabPage tabRentalInfoDetail;
        private UserControls.AppExplore.RentalInfo.RentalControl rentalControl1;
        private System.Windows.Forms.TabPage tabCriEviDetail;
        private UserControls.AppExplore.GeneralInfo.CriEvControl criEvControl1;
        private System.Windows.Forms.TabPage tabFinalDetail;
        private UserControls.AppExplore.GeneralInfo.FinalInfoControl finalInfoControl1;
        private System.Windows.Forms.TabPage tabMenuDetail;
        internal UserControls.AppExplore.GeneralInfo.AppMenuControl appMenuControl1;
        private System.Windows.Forms.TabPage tabNetToolDetail;
        private UserControls.AppExplore.GeneralInfo.NetToolControl netToolControl1;
        private System.Windows.Forms.Panel panel2;
        private BrightIdeasSoftware.OLVColumn olvcolLocation;
        private BrightIdeasSoftware.OLVColumn olvcolCommunity;
        private BrightIdeasSoftware.OLVColumn olvUnitNumber;
        private BrightIdeasSoftware.OLVColumn olvcolInvoiceDivision;
        private BrightIdeasSoftware.OLVColumn olvColRecommendation;
        private System.Windows.Forms.ToolStripMenuItem checkForDuplicatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkDupAllAppsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkDupSelectedAppsToolStripMenuItem;
    }
}