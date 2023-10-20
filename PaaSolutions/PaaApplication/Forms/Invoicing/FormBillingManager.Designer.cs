namespace PaaApplication.Forms.Invoicing
{
    partial class FormBillingManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBillingManager));
            this.uInvoicingRibbon = new PaaApplication.UserControls.Ribbons.InvoicingRibbon(this);
            this.olvClients = new BrightIdeasSoftware.FastObjectListView();
            this.olvColClientName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColClientManagement = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColClientPhone = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColClientFax = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColClientSince = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cmnuClient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolClientPaymentHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientPrintInvOfPastDues = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientPrintMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientPrintLabels = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientPrintInfoSheets = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientPrintResidentialContracts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientPrintEmploymentContracts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientCreateDatagrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientDatagridAllClients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientDatagridSelectedClients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolClientView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientArrangeAlignTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientArrangeAlignLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClientArrangeAlignNone = new System.Windows.Forms.ToolStripMenuItem();
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.olvInvoices = new BrightIdeasSoftware.FastObjectListView();
            this.olvColInvClientName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvDivision = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvMonth = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvNum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvAmount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvBalance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvActionStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cmnuInvoice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolInvoiceShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceEditPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceStats = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoicePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.wordToolEmailInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.pdfToolEmailInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceUpdateClientName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolInvoiceDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceCreateDatagrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceDatagridAllShownInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceDatagridSelectedInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceArrangeAlignTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceArrangeAlignLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInvoiceArrangeAlignNone = new System.Windows.Forms.ToolStripMenuItem();
            this.olvApplications = new BrightIdeasSoftware.FastObjectListView();
            this.olvColAppName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAppClientName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAppReportType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAppReceivedDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAppInvDivision = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAppRoommate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAppBilledStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cmnuApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolAppEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppShowBilledStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppFindOnInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppBillingValidation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppMoveTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAppMoveToArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppMoveToReview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppMoveToPickup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppMoveToNewApps = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAppCreateDatagrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppDatagridAllShownApps = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppDatagridSelectedApps = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAppDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAppView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppArrangeAlignTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppArrangeAlignLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAppArrangeAlignNone = new System.Windows.Forms.ToolStripMenuItem();
            this.lblInvoiceTitle = new System.Windows.Forms.TextBox();
            this.lblAppTitle = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.appTabsControl = new PaaApplication.UserControls.AppExplore.AppTabsControl();
            this.invStatsControl = new PaaApplication.UserControls.Invoicing.InvStatsControl();
            this.invPaymentControl = new PaaApplication.UserControls.Invoicing.InvPaymentControl();
            this.invDetailControl = new PaaApplication.UserControls.Invoicing.InvDetailControl();
            this.mnuMaster = new System.Windows.Forms.StatusStrip();
            this.sttlblClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttlblCount = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.olvClients)).BeginInit();
            this.cmnuClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvInvoices)).BeginInit();
            this.cmnuInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvApplications)).BeginInit();
            this.cmnuApplication.SuspendLayout();
            this.mnuMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            this.uInvoicingRibbon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uInvoicingRibbon.Dock = System.Windows.Forms.DockStyle.Top;
            this.uInvoicingRibbon.Size = new System.Drawing.Size(900, 130);
            this.uInvoicingRibbon.Name = "uClientInfoRibbon";
            this.uInvoicingRibbon.TabIndex = 0;
            // olvClients
            // 
            this.olvClients.AllColumns.Add(this.olvColClientName);
            this.olvClients.AllColumns.Add(this.olvColClientManagement);
            this.olvClients.AllColumns.Add(this.olvColClientPhone);
            this.olvClients.AllColumns.Add(this.olvColClientFax);
            this.olvClients.AllColumns.Add(this.olvColClientSince);
            this.olvClients.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvClients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.olvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColClientName,
            this.olvColClientManagement,
            this.olvColClientPhone,
            this.olvColClientFax,
            this.olvColClientSince});
            this.olvClients.ContextMenuStrip = this.cmnuClient;
            this.olvClients.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvClients.FullRowSelect = true;
            this.olvClients.HideSelection = false;
            this.olvClients.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvClients.HotItemStyle = this.hotItemStyle;
            this.olvClients.Location = new System.Drawing.Point(10, 143);
            this.olvClients.Name = "olvClients";
            this.olvClients.OwnerDraw = true;
            this.olvClients.ShowGroups = false;
            this.olvClients.Size = new System.Drawing.Size(950, 200);
            this.olvClients.TabIndex = 0;
            this.olvClients.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvClients.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvClients.UseAlternatingBackColors = true;
            this.olvClients.UseCompatibleStateImageBehavior = false;
            this.olvClients.UseHotItem = true;
            this.olvClients.View = System.Windows.Forms.View.Details;
            this.olvClients.VirtualMode = true;
            this.olvClients.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.objectListView_ItemsChanged);
            this.olvClients.SelectionChanged += new System.EventHandler(this.olvClients_SelectionChanged);
            this.olvClients.SelectedIndexChanged += new System.EventHandler(this.olvClients_SelectedIndexChanged);
            this.olvClients.DoubleClick += new System.EventHandler(this.olvClients_DoubleClick);
            this.olvClients.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.olvClients_KeyPress);
            // 
            // olvColClientName
            // 
            this.olvColClientName.AspectName = "ClientName";
            this.olvColClientName.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColClientName.Text = "Client Name";
            this.olvColClientName.Width = 270;
            // 
            // olvColClientManagement
            // 
            this.olvColClientManagement.AspectName = "";
            this.olvColClientManagement.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColClientManagement.Text = "Management";
            this.olvColClientManagement.Width = 220;
            // 
            // olvColClientPhone
            // 
            this.olvColClientPhone.AspectName = "Phone";
            this.olvColClientPhone.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColClientPhone.Text = "Phone";
            this.olvColClientPhone.Width = 130;
            // 
            // olvColClientFax
            // 
            this.olvColClientFax.AspectName = "Fax";
            this.olvColClientFax.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColClientFax.Text = "Fax";
            this.olvColClientFax.Width = 130;
            // 
            // olvColClientSince
            // 
            this.olvColClientSince.AspectName = "Since";
            this.olvColClientSince.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColClientSince.Text = "Since";
            this.olvColClientSince.Width = 130;
            // 
            // cmnuClient
            // 
            this.cmnuClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolClientPaymentHistory,
            this.toolClientPrintInvOfPastDues,
            this.toolClientPrintMenu,
            this.toolClientCreateDatagrid,
            this.toolStripSeparator1,
            this.toolClientView,
            this.toolClientArrange});
            this.cmnuClient.Name = "cxtClientMenu";
            this.cmnuClient.Size = new System.Drawing.Size(210, 142);
            this.cmnuClient.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuClient_Opening);
            // 
            // toolClientPaymentHistory
            // 
            this.toolClientPaymentHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolClientPaymentHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientPaymentHistory.Name = "toolClientPaymentHistory";
            this.toolClientPaymentHistory.Size = new System.Drawing.Size(209, 22);
            this.toolClientPaymentHistory.Text = "Show Payment History";
            this.toolClientPaymentHistory.Click += new System.EventHandler(this.toolClientPaymentHistory_Click);
            // 
            // toolClientPrintInvOfPastDues
            // 
            this.toolClientPrintInvOfPastDues.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolClientPrintInvOfPastDues.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientPrintInvOfPastDues.Name = "toolClientPrintInvOfPastDues";
            this.toolClientPrintInvOfPastDues.Size = new System.Drawing.Size(209, 22);
            this.toolClientPrintInvOfPastDues.Text = "Print Inv. of Past Dues";
            this.toolClientPrintInvOfPastDues.Click += new System.EventHandler(this.toolClientPrintInvOfPastDues_Click);
            // 
            // toolClientPrintMenu
            // 
            this.toolClientPrintMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolClientPrintLabels,
            this.toolClientPrintInfoSheets,
            this.toolClientPrintResidentialContracts,
            this.toolClientPrintEmploymentContracts});
            this.toolClientPrintMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolClientPrintMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientPrintMenu.Name = "toolClientPrintMenu";
            this.toolClientPrintMenu.Size = new System.Drawing.Size(209, 22);
            this.toolClientPrintMenu.Text = "Print Menu";
            // 
            // toolClientPrintLabels
            // 
            this.toolClientPrintLabels.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientPrintLabels.Name = "toolClientPrintLabels";
            this.toolClientPrintLabels.Size = new System.Drawing.Size(210, 22);
            this.toolClientPrintLabels.Text = "Label(s)";
            // 
            // toolClientPrintInfoSheets
            // 
            this.toolClientPrintInfoSheets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientPrintInfoSheets.Name = "toolClientPrintInfoSheets";
            this.toolClientPrintInfoSheets.Size = new System.Drawing.Size(210, 22);
            this.toolClientPrintInfoSheets.Text = "Client Info Sheet(s)";
            // 
            // toolClientPrintResidentialContracts
            // 
            this.toolClientPrintResidentialContracts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientPrintResidentialContracts.Name = "toolClientPrintResidentialContracts";
            this.toolClientPrintResidentialContracts.Size = new System.Drawing.Size(210, 22);
            this.toolClientPrintResidentialContracts.Text = "Residential Contracts";
            // 
            // toolClientPrintEmploymentContracts
            // 
            this.toolClientPrintEmploymentContracts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientPrintEmploymentContracts.Name = "toolClientPrintEmploymentContracts";
            this.toolClientPrintEmploymentContracts.Size = new System.Drawing.Size(210, 22);
            this.toolClientPrintEmploymentContracts.Text = "Employment Contracts";
            // 
            // toolClientCreateDatagrid
            // 
            this.toolClientCreateDatagrid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolClientDatagridAllClients,
            this.toolClientDatagridSelectedClients});
            this.toolClientCreateDatagrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolClientCreateDatagrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientCreateDatagrid.Name = "toolClientCreateDatagrid";
            this.toolClientCreateDatagrid.Size = new System.Drawing.Size(209, 22);
            this.toolClientCreateDatagrid.Text = "Create Datagrid";
            // 
            // toolClientDatagridAllClients
            // 
            this.toolClientDatagridAllClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientDatagridAllClients.Name = "toolClientDatagridAllClients";
            this.toolClientDatagridAllClients.Size = new System.Drawing.Size(207, 22);
            this.toolClientDatagridAllClients.Text = "From All Clients";
            this.toolClientDatagridAllClients.Click += new System.EventHandler(this.toolClientDatagridAllClients_Click);
            // 
            // toolClientDatagridSelectedClients
            // 
            this.toolClientDatagridSelectedClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientDatagridSelectedClients.Name = "toolClientDatagridSelectedClients";
            this.toolClientDatagridSelectedClients.Size = new System.Drawing.Size(207, 22);
            this.toolClientDatagridSelectedClients.Text = "From Selected Clients";
            this.toolClientDatagridSelectedClients.Click += new System.EventHandler(this.toolClientDatagridSelectedClients_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // toolClientView
            // 
            this.toolClientView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolClientViewSmallIcons,
            this.toolClientViewLargeIcons,
            this.toolClientViewList,
            this.toolClientViewDetails});
            this.toolClientView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolClientView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientView.Name = "toolClientView";
            this.toolClientView.Size = new System.Drawing.Size(209, 22);
            this.toolClientView.Text = "&View";
            // 
            // toolClientViewSmallIcons
            // 
            this.toolClientViewSmallIcons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientViewSmallIcons.Name = "toolClientViewSmallIcons";
            this.toolClientViewSmallIcons.Size = new System.Drawing.Size(146, 22);
            this.toolClientViewSmallIcons.Text = "Small Icons";
            // 
            // toolClientViewLargeIcons
            // 
            this.toolClientViewLargeIcons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientViewLargeIcons.Name = "toolClientViewLargeIcons";
            this.toolClientViewLargeIcons.Size = new System.Drawing.Size(146, 22);
            this.toolClientViewLargeIcons.Text = "Large Icons";
            // 
            // toolClientViewList
            // 
            this.toolClientViewList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientViewList.Name = "toolClientViewList";
            this.toolClientViewList.Size = new System.Drawing.Size(146, 22);
            this.toolClientViewList.Text = "List";
            // 
            // toolClientViewDetails
            // 
            this.toolClientViewDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientViewDetails.Name = "toolClientViewDetails";
            this.toolClientViewDetails.Size = new System.Drawing.Size(146, 22);
            this.toolClientViewDetails.Text = "Details";
            // 
            // toolClientArrange
            // 
            this.toolClientArrange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolClientArrangeAlignTop,
            this.toolClientArrangeAlignLeft,
            this.toolClientArrangeAlignNone});
            this.toolClientArrange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolClientArrange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientArrange.Name = "toolClientArrange";
            this.toolClientArrange.Size = new System.Drawing.Size(209, 22);
            this.toolClientArrange.Text = "&Arrange";
            // 
            // toolClientArrangeAlignTop
            // 
            this.toolClientArrangeAlignTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientArrangeAlignTop.Name = "toolClientArrangeAlignTop";
            this.toolClientArrangeAlignTop.Size = new System.Drawing.Size(142, 22);
            this.toolClientArrangeAlignTop.Text = "Align Top";
            // 
            // toolClientArrangeAlignLeft
            // 
            this.toolClientArrangeAlignLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientArrangeAlignLeft.Name = "toolClientArrangeAlignLeft";
            this.toolClientArrangeAlignLeft.Size = new System.Drawing.Size(142, 22);
            this.toolClientArrangeAlignLeft.Text = "Align Left";
            // 
            // toolClientArrangeAlignNone
            // 
            this.toolClientArrangeAlignNone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolClientArrangeAlignNone.Name = "toolClientArrangeAlignNone";
            this.toolClientArrangeAlignNone.Size = new System.Drawing.Size(142, 22);
            this.toolClientArrangeAlignNone.Text = "Align None";
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // olvInvoices
            // 
            this.olvInvoices.AllColumns.Add(this.olvColInvClientName);
            this.olvInvoices.AllColumns.Add(this.olvColInvDivision);
            this.olvInvoices.AllColumns.Add(this.olvColInvMonth);
            this.olvInvoices.AllColumns.Add(this.olvColInvStatus);
            this.olvInvoices.AllColumns.Add(this.olvColInvNum);
            this.olvInvoices.AllColumns.Add(this.olvColInvAmount);
            this.olvInvoices.AllColumns.Add(this.olvColInvBalance);
            this.olvInvoices.AllColumns.Add(this.olvColInvActionStatus);
            this.olvInvoices.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvInvoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.olvInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColInvClientName,
            this.olvColInvDivision,
            this.olvColInvMonth,
            this.olvColInvStatus,
            this.olvColInvNum,
            this.olvColInvAmount,
            this.olvColInvBalance,
            this.olvColInvActionStatus});
            this.olvInvoices.ContextMenuStrip = this.cmnuInvoice;
            this.olvInvoices.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvInvoices.FullRowSelect = true;
            this.olvInvoices.HideSelection = false;
            this.olvInvoices.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvInvoices.HotItemStyle = this.hotItemStyle;
            this.olvInvoices.Location = new System.Drawing.Point(10, 374);
            this.olvInvoices.Name = "olvInvoices";
            this.olvInvoices.OwnerDraw = true;
            this.olvInvoices.ShowGroups = false;
            this.olvInvoices.Size = new System.Drawing.Size(950, 200);
            this.olvInvoices.TabIndex = 1;
            this.olvInvoices.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvInvoices.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvInvoices.UseAlternatingBackColors = true;
            this.olvInvoices.UseCompatibleStateImageBehavior = false;
            this.olvInvoices.UseHotItem = true;
            this.olvInvoices.View = System.Windows.Forms.View.Details;
            this.olvInvoices.VirtualMode = true;
            this.olvInvoices.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.objectListView_ItemsChanged);
            this.olvInvoices.SelectionChanged += new System.EventHandler(this.olvInvoices_SelectionChanged);
            this.olvInvoices.SelectedIndexChanged += new System.EventHandler(this.olvInvoices_SelectedIndexChanged);
            // 
            // olvColInvClientName
            // 
            this.olvColInvClientName.AspectName = "ClientName";
            this.olvColInvClientName.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvClientName.Text = "Client Name";
            this.olvColInvClientName.Width = 220;
            // 
            // olvColInvDivision
            // 
            this.olvColInvDivision.AspectName = "InvoiceDivision";
            this.olvColInvDivision.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvDivision.Text = "Division";
            this.olvColInvDivision.Width = 190;
            // 
            // olvColInvMonth
            // 
            this.olvColInvMonth.AspectName = "InvoiceDate";
            this.olvColInvMonth.AspectToStringFormat = "{0:MM/yyyy}";
            this.olvColInvMonth.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvMonth.Text = "Month";
            this.olvColInvMonth.Width = 100;
            // 
            // olvColInvStatus
            // 
            this.olvColInvStatus.AspectName = "";
            this.olvColInvStatus.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvStatus.Text = "Status";
            this.olvColInvStatus.Width = 100;
            // 
            // olvColInvNum
            // 
            this.olvColInvNum.AspectName = "InvoiceNumber";
            this.olvColInvNum.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvNum.Text = "Invoice #";
            this.olvColInvNum.Width = 90;
            // 
            // olvColInvAmount
            // 
            this.olvColInvAmount.AspectName = "Amount";
            this.olvColInvAmount.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvAmount.Text = "Amount";
            this.olvColInvAmount.Width = 90;
            // 
            // olvColInvBalance
            // 
            this.olvColInvBalance.AspectName = "";
            this.olvColInvBalance.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvBalance.Text = "Balance";
            this.olvColInvBalance.Width = 100;
            // 
            // olvColInvActionStatus
            // 
            this.olvColInvActionStatus.AspectName = "";
            this.olvColInvActionStatus.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvActionStatus.Text = "Action Status";
            this.olvColInvActionStatus.Width = 100;
            // 
            // cmnuInvoice
            // 
            this.cmnuInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolInvoiceShow,
            this.toolInvoiceEditPayments,
            this.toolInvoiceSearch,
            this.toolInvoiceStats,
            this.toolInvoicePrint,
            this.toolInvoiceEmail,
            this.toolInvoiceUpdateClientName,
            this.toolStripSeparator2,
            this.toolInvoiceDelete,
            this.toolInvoiceCreateDatagrid,
            this.toolInvoiceView,
            this.toolInvoiceArrange});
            this.cmnuInvoice.Name = "cxtInvMenu";
            this.cmnuInvoice.Size = new System.Drawing.Size(206, 252);
            this.cmnuInvoice.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuInvoice_Opening);
            // 
            // toolInvoiceShow
            // 
            this.toolInvoiceShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoiceShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceShow.Name = "toolInvoiceShow";
            this.toolInvoiceShow.Size = new System.Drawing.Size(205, 22);
            this.toolInvoiceShow.Text = "Show &Invoice";
            this.toolInvoiceShow.Visible = false;
            this.toolInvoiceShow.Click += new System.EventHandler(this.toolInvoiceShow_Click);
            // 
            // toolInvoiceEditPayments
            // 
            this.toolInvoiceEditPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoiceEditPayments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceEditPayments.Name = "toolInvoiceEditPayments";
            this.toolInvoiceEditPayments.Size = new System.Drawing.Size(205, 22);
            this.toolInvoiceEditPayments.Text = "&Edit Payments";
            this.toolInvoiceEditPayments.Click += new System.EventHandler(this.toolInvoiceEditPayments_Click);
            // 
            // toolInvoiceSearch
            // 
            this.toolInvoiceSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoiceSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceSearch.Name = "toolInvoiceSearch";
            this.toolInvoiceSearch.Size = new System.Drawing.Size(205, 22);
            this.toolInvoiceSearch.Text = "&Search Invoices";
            this.toolInvoiceSearch.Click += new System.EventHandler(this.toolInvoiceSearch_Click);
            // 
            // toolInvoiceStats
            // 
            this.toolInvoiceStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoiceStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceStats.Name = "toolInvoiceStats";
            this.toolInvoiceStats.Size = new System.Drawing.Size(205, 22);
            this.toolInvoiceStats.Text = "Show Inv. S&tats";
            this.toolInvoiceStats.Click += new System.EventHandler(this.toolInvoiceStats_Click);
            // 
            // toolInvoicePrint
            // 
            this.toolInvoicePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoicePrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoicePrint.Name = "toolInvoicePrint";
            this.toolInvoicePrint.Size = new System.Drawing.Size(205, 22);
            this.toolInvoicePrint.Text = "&Print Invoice(s)";
            this.toolInvoicePrint.Click += new System.EventHandler(this.toolInvoicePrint_Click);
            // 
            // toolInvoiceEmail
            // 
            this.toolInvoiceEmail.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordToolEmailInvoice,
            this.pdfToolEmailInvoice});
            this.toolInvoiceEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoiceEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceEmail.Name = "toolInvoiceEmail";
            this.toolInvoiceEmail.Size = new System.Drawing.Size(205, 22);
            this.toolInvoiceEmail.Text = "Email Invoice(s)";
            // 
            // wordToolEmailInvoice
            // 
            this.wordToolEmailInvoice.Name = "wordToolEmailInvoice";
            this.wordToolEmailInvoice.Size = new System.Drawing.Size(152, 22);
            this.wordToolEmailInvoice.Text = "Word";
            this.wordToolEmailInvoice.Click += new System.EventHandler(this.wordToolEmailInvoice_Click);
            // 
            // pdfToolEmailInvoice
            // 
            this.pdfToolEmailInvoice.Name = "pdfToolEmailInvoice";
            this.pdfToolEmailInvoice.Size = new System.Drawing.Size(152, 22);
            this.pdfToolEmailInvoice.Text = "PDF";
            this.pdfToolEmailInvoice.Click += new System.EventHandler(this.pdfToolEmailInvoice_Click);
            // 
            // toolInvoiceUpdateClientName
            // 
            this.toolInvoiceUpdateClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoiceUpdateClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceUpdateClientName.Name = "toolInvoiceUpdateClientName";
            this.toolInvoiceUpdateClientName.Size = new System.Drawing.Size(205, 22);
            this.toolInvoiceUpdateClientName.Text = "Update Client Name...";
            this.toolInvoiceUpdateClientName.Click += new System.EventHandler(this.toolInvoiceUpdateClientName_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // toolInvoiceDelete
            // 
            this.toolInvoiceDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoiceDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceDelete.Name = "toolInvoiceDelete";
            this.toolInvoiceDelete.Size = new System.Drawing.Size(205, 22);
            this.toolInvoiceDelete.Text = "Delete Invoice(s)";
            this.toolInvoiceDelete.Click += new System.EventHandler(this.toolInvoiceDelete_Click);
            // 
            // toolInvoiceCreateDatagrid
            // 
            this.toolInvoiceCreateDatagrid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolInvoiceDatagridAllShownInvoices,
            this.toolInvoiceDatagridSelectedInvoices});
            this.toolInvoiceCreateDatagrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoiceCreateDatagrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceCreateDatagrid.Name = "toolInvoiceCreateDatagrid";
            this.toolInvoiceCreateDatagrid.Size = new System.Drawing.Size(205, 22);
            this.toolInvoiceCreateDatagrid.Text = "Create Datagrid";
            // 
            // toolInvoiceDatagridAllShownInvoices
            // 
            this.toolInvoiceDatagridAllShownInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceDatagridAllShownInvoices.Name = "toolInvoiceDatagridAllShownInvoices";
            this.toolInvoiceDatagridAllShownInvoices.Size = new System.Drawing.Size(221, 22);
            this.toolInvoiceDatagridAllShownInvoices.Text = "From All Shown Invoices";
            this.toolInvoiceDatagridAllShownInvoices.Click += new System.EventHandler(this.toolInvoiceDatagridAllShownInvoices_Click);
            // 
            // toolInvoiceDatagridSelectedInvoices
            // 
            this.toolInvoiceDatagridSelectedInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceDatagridSelectedInvoices.Name = "toolInvoiceDatagridSelectedInvoices";
            this.toolInvoiceDatagridSelectedInvoices.Size = new System.Drawing.Size(221, 22);
            this.toolInvoiceDatagridSelectedInvoices.Text = "From Selected Invoices";
            this.toolInvoiceDatagridSelectedInvoices.Click += new System.EventHandler(this.toolInvoiceDatagridSelectedInvoices_Click);
            // 
            // toolInvoiceView
            // 
            this.toolInvoiceView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolInvoiceViewSmallIcons,
            this.toolInvoiceViewLargeIcons,
            this.toolInvoiceViewList,
            this.toolInvoiceViewDetails});
            this.toolInvoiceView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoiceView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceView.Name = "toolInvoiceView";
            this.toolInvoiceView.Size = new System.Drawing.Size(205, 22);
            this.toolInvoiceView.Text = "&View";
            // 
            // toolInvoiceViewSmallIcons
            // 
            this.toolInvoiceViewSmallIcons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceViewSmallIcons.Name = "toolInvoiceViewSmallIcons";
            this.toolInvoiceViewSmallIcons.Size = new System.Drawing.Size(146, 22);
            this.toolInvoiceViewSmallIcons.Text = "Small Icons";
            // 
            // toolInvoiceViewLargeIcons
            // 
            this.toolInvoiceViewLargeIcons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceViewLargeIcons.Name = "toolInvoiceViewLargeIcons";
            this.toolInvoiceViewLargeIcons.Size = new System.Drawing.Size(146, 22);
            this.toolInvoiceViewLargeIcons.Text = "Large Icons";
            // 
            // toolInvoiceViewList
            // 
            this.toolInvoiceViewList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceViewList.Name = "toolInvoiceViewList";
            this.toolInvoiceViewList.Size = new System.Drawing.Size(146, 22);
            this.toolInvoiceViewList.Text = "List";
            // 
            // toolInvoiceViewDetails
            // 
            this.toolInvoiceViewDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceViewDetails.Name = "toolInvoiceViewDetails";
            this.toolInvoiceViewDetails.Size = new System.Drawing.Size(146, 22);
            this.toolInvoiceViewDetails.Text = "Details";
            // 
            // toolInvoiceArrange
            // 
            this.toolInvoiceArrange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolInvoiceArrangeAlignTop,
            this.toolInvoiceArrangeAlignLeft,
            this.toolInvoiceArrangeAlignNone});
            this.toolInvoiceArrange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInvoiceArrange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceArrange.Name = "toolInvoiceArrange";
            this.toolInvoiceArrange.Size = new System.Drawing.Size(205, 22);
            this.toolInvoiceArrange.Text = "&Arrange";
            // 
            // toolInvoiceArrangeAlignTop
            // 
            this.toolInvoiceArrangeAlignTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceArrangeAlignTop.Name = "toolInvoiceArrangeAlignTop";
            this.toolInvoiceArrangeAlignTop.Size = new System.Drawing.Size(142, 22);
            this.toolInvoiceArrangeAlignTop.Text = "Align Top";
            // 
            // toolInvoiceArrangeAlignLeft
            // 
            this.toolInvoiceArrangeAlignLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceArrangeAlignLeft.Name = "toolInvoiceArrangeAlignLeft";
            this.toolInvoiceArrangeAlignLeft.Size = new System.Drawing.Size(142, 22);
            this.toolInvoiceArrangeAlignLeft.Text = "Align Left";
            // 
            // toolInvoiceArrangeAlignNone
            // 
            this.toolInvoiceArrangeAlignNone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInvoiceArrangeAlignNone.Name = "toolInvoiceArrangeAlignNone";
            this.toolInvoiceArrangeAlignNone.Size = new System.Drawing.Size(142, 22);
            this.toolInvoiceArrangeAlignNone.Text = "Align None";
            // 
            // olvApplications
            // 
            this.olvApplications.AllColumns.Add(this.olvColAppName);
            this.olvApplications.AllColumns.Add(this.olvColAppClientName);
            this.olvApplications.AllColumns.Add(this.olvColAppReportType);
            this.olvApplications.AllColumns.Add(this.olvColAppReceivedDate);
            this.olvApplications.AllColumns.Add(this.olvColAppInvDivision);
            this.olvApplications.AllColumns.Add(this.olvColAppRoommate);
            this.olvApplications.AllColumns.Add(this.olvColAppBilledStatus);
            this.olvApplications.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvApplications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.olvApplications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColAppName,
            this.olvColAppClientName,
            this.olvColAppReportType,
            this.olvColAppReceivedDate,
            this.olvColAppInvDivision,
            this.olvColAppRoommate});
            this.olvApplications.ContextMenuStrip = this.cmnuApplication;
            this.olvApplications.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvApplications.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvApplications.FullRowSelect = true;
            this.olvApplications.HideSelection = false;
            this.olvApplications.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvApplications.HotItemStyle = this.hotItemStyle;
            this.olvApplications.IsSimpleDragSource = true;
            this.olvApplications.Location = new System.Drawing.Point(10, 606);
            this.olvApplications.Name = "olvApplications";
            this.olvApplications.OwnerDraw = true;
            this.olvApplications.ShowGroups = false;
            this.olvApplications.Size = new System.Drawing.Size(950, 197);
            this.olvApplications.TabIndex = 2;
            this.olvApplications.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvApplications.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvApplications.UseAlternatingBackColors = true;
            this.olvApplications.UseCompatibleStateImageBehavior = false;
            this.olvApplications.UseHotItem = true;
            this.olvApplications.View = System.Windows.Forms.View.Details;
            this.olvApplications.VirtualMode = true;
            this.olvApplications.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.objectListView_ItemsChanged);
            this.olvApplications.SelectionChanged += new System.EventHandler(this.olvApplications_SelectionChanged);
            // 
            // olvColAppName
            // 
            this.olvColAppName.AspectName = "";
            this.olvColAppName.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAppName.Text = "Name";
            this.olvColAppName.Width = 200;
            // 
            // olvColAppClientName
            // 
            this.olvColAppClientName.AspectName = "ClientAppliedName";
            this.olvColAppClientName.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAppClientName.Text = "Client Name";
            this.olvColAppClientName.Width = 160;
            // 
            // olvColAppReportType
            // 
            this.olvColAppReportType.AspectName = "ReportTypeName";
            this.olvColAppReportType.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAppReportType.Text = "Type";
            this.olvColAppReportType.Width = 100;
            // 
            // olvColAppReceivedDate
            // 
            this.olvColAppReceivedDate.AspectName = "ReceivedDate";
            this.olvColAppReceivedDate.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAppReceivedDate.Text = "Received";
            this.olvColAppReceivedDate.Width = 130;
            // 
            // olvColAppInvDivision
            // 
            this.olvColAppInvDivision.AspectName = "InvoiceDivision";
            this.olvColAppInvDivision.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAppInvDivision.Text = "Invoice Division";
            this.olvColAppInvDivision.Width = 150;
            // 
            // olvColAppRoommate
            // 
            this.olvColAppRoommate.AspectName = "ReportSpecialField";
            this.olvColAppRoommate.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAppRoommate.Text = "Roommates";
            this.olvColAppRoommate.Width = 100;
            // 
            // olvColAppBilledStatus
            // 
            this.olvColAppBilledStatus.AspectName = "BilledStatus";
            this.olvColAppBilledStatus.DisplayIndex = 6;
            this.olvColAppBilledStatus.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.olvColAppBilledStatus.IsEditable = false;
            this.olvColAppBilledStatus.IsVisible = false;
            this.olvColAppBilledStatus.Searchable = false;
            this.olvColAppBilledStatus.Text = "Billed";
            this.olvColAppBilledStatus.UseFiltering = false;
            this.olvColAppBilledStatus.Width = 70;
            // 
            // cmnuApplication
            // 
            this.cmnuApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAppEdit,
            this.toolAppShowBilledStatus,
            this.toolAppFindOnInvoice,
            this.toolAppBillingValidation,
            this.toolAppMoveTo,
            this.toolStripSeparator3,
            this.toolAppCreateDatagrid,
            this.toolAppSearch,
            this.toolStripSeparator4,
            this.toolAppDelete,
            this.toolStripSeparator5,
            this.toolAppView,
            this.toolAppArrange});
            this.cmnuApplication.Name = "cxtAppMenu";
            this.cmnuApplication.Size = new System.Drawing.Size(194, 242);
            this.cmnuApplication.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuApplication_Opening);
            // 
            // toolAppEdit
            // 
            this.toolAppEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAppEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppEdit.Name = "toolAppEdit";
            this.toolAppEdit.Size = new System.Drawing.Size(193, 22);
            this.toolAppEdit.Text = "&Edit App";
            this.toolAppEdit.Click += new System.EventHandler(this.toolAppEdit_Click);
            // 
            // toolAppShowBilledStatus
            // 
            this.toolAppShowBilledStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAppShowBilledStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppShowBilledStatus.Name = "toolAppShowBilledStatus";
            this.toolAppShowBilledStatus.Size = new System.Drawing.Size(193, 22);
            this.toolAppShowBilledStatus.Text = "&Show Billed Status";
            this.toolAppShowBilledStatus.Click += new System.EventHandler(this.toolAppShowBilledStatus_Click);
            // 
            // toolAppFindOnInvoice
            // 
            this.toolAppFindOnInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAppFindOnInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppFindOnInvoice.Name = "toolAppFindOnInvoice";
            this.toolAppFindOnInvoice.Size = new System.Drawing.Size(193, 22);
            this.toolAppFindOnInvoice.Text = "&Find App on Invoice";
            this.toolAppFindOnInvoice.Click += new System.EventHandler(this.toolAppFindOnInvoice_Click);
            // 
            // toolAppBillingValidation
            // 
            this.toolAppBillingValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAppBillingValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppBillingValidation.Name = "toolAppBillingValidation";
            this.toolAppBillingValidation.Size = new System.Drawing.Size(193, 22);
            this.toolAppBillingValidation.Text = "&Billing Validation";
            this.toolAppBillingValidation.Click += new System.EventHandler(this.toolAppBillingValidation_Click);
            // 
            // toolAppMoveTo
            // 
            this.toolAppMoveTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.toolAppMoveToArchive,
            this.toolAppMoveToReview,
            this.toolAppMoveToPickup,
            this.toolAppMoveToNewApps});
            this.toolAppMoveTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAppMoveTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppMoveTo.Name = "toolAppMoveTo";
            this.toolAppMoveTo.Size = new System.Drawing.Size(193, 22);
            this.toolAppMoveTo.Text = "&Move To";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(135, 6);
            // 
            // toolAppMoveToArchive
            // 
            this.toolAppMoveToArchive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppMoveToArchive.Name = "toolAppMoveToArchive";
            this.toolAppMoveToArchive.Size = new System.Drawing.Size(138, 22);
            this.toolAppMoveToArchive.Text = "Archive";
            // 
            // toolAppMoveToReview
            // 
            this.toolAppMoveToReview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppMoveToReview.Name = "toolAppMoveToReview";
            this.toolAppMoveToReview.Size = new System.Drawing.Size(138, 22);
            this.toolAppMoveToReview.Text = "Review";
            // 
            // toolAppMoveToPickup
            // 
            this.toolAppMoveToPickup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppMoveToPickup.Name = "toolAppMoveToPickup";
            this.toolAppMoveToPickup.Size = new System.Drawing.Size(138, 22);
            this.toolAppMoveToPickup.Text = "Pickup";
            // 
            // toolAppMoveToNewApps
            // 
            this.toolAppMoveToNewApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppMoveToNewApps.Name = "toolAppMoveToNewApps";
            this.toolAppMoveToNewApps.Size = new System.Drawing.Size(138, 22);
            this.toolAppMoveToNewApps.Text = "New Apps";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
            // 
            // toolAppCreateDatagrid
            // 
            this.toolAppCreateDatagrid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAppDatagridAllShownApps,
            this.toolAppDatagridSelectedApps});
            this.toolAppCreateDatagrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAppCreateDatagrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppCreateDatagrid.Name = "toolAppCreateDatagrid";
            this.toolAppCreateDatagrid.Size = new System.Drawing.Size(193, 22);
            this.toolAppCreateDatagrid.Text = "Create Datagrid";
            // 
            // toolAppDatagridAllShownApps
            // 
            this.toolAppDatagridAllShownApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppDatagridAllShownApps.Name = "toolAppDatagridAllShownApps";
            this.toolAppDatagridAllShownApps.Size = new System.Drawing.Size(245, 22);
            this.toolAppDatagridAllShownApps.Text = "From All Shown Applications";
            this.toolAppDatagridAllShownApps.Click += new System.EventHandler(this.toolAppDatagridAllShownApps_Click);
            // 
            // toolAppDatagridSelectedApps
            // 
            this.toolAppDatagridSelectedApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppDatagridSelectedApps.Name = "toolAppDatagridSelectedApps";
            this.toolAppDatagridSelectedApps.Size = new System.Drawing.Size(245, 22);
            this.toolAppDatagridSelectedApps.Text = "From Selected Applications";
            this.toolAppDatagridSelectedApps.Click += new System.EventHandler(this.toolAppDatagridSelectedApps_Click);
            // 
            // toolAppSearch
            // 
            this.toolAppSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAppSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppSearch.Name = "toolAppSearch";
            this.toolAppSearch.Size = new System.Drawing.Size(193, 22);
            this.toolAppSearch.Text = "&Search Apps...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(190, 6);
            // 
            // toolAppDelete
            // 
            this.toolAppDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAppDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppDelete.Name = "toolAppDelete";
            this.toolAppDelete.Size = new System.Drawing.Size(193, 22);
            this.toolAppDelete.Text = "&Delete App";
            this.toolAppDelete.Click += new System.EventHandler(this.toolAppDelete_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(190, 6);
            // 
            // toolAppView
            // 
            this.toolAppView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAppViewSmallIcons,
            this.toolAppViewLargeIcons,
            this.toolAppViewList,
            this.toolAppViewDetails});
            this.toolAppView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAppView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppView.Name = "toolAppView";
            this.toolAppView.Size = new System.Drawing.Size(193, 22);
            this.toolAppView.Text = "&View";
            // 
            // toolAppViewSmallIcons
            // 
            this.toolAppViewSmallIcons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppViewSmallIcons.Name = "toolAppViewSmallIcons";
            this.toolAppViewSmallIcons.Size = new System.Drawing.Size(146, 22);
            this.toolAppViewSmallIcons.Text = "Small Icons";
            // 
            // toolAppViewLargeIcons
            // 
            this.toolAppViewLargeIcons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppViewLargeIcons.Name = "toolAppViewLargeIcons";
            this.toolAppViewLargeIcons.Size = new System.Drawing.Size(146, 22);
            this.toolAppViewLargeIcons.Text = "Large Icons";
            // 
            // toolAppViewList
            // 
            this.toolAppViewList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppViewList.Name = "toolAppViewList";
            this.toolAppViewList.Size = new System.Drawing.Size(146, 22);
            this.toolAppViewList.Text = "List";
            // 
            // toolAppViewDetails
            // 
            this.toolAppViewDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppViewDetails.Name = "toolAppViewDetails";
            this.toolAppViewDetails.Size = new System.Drawing.Size(146, 22);
            this.toolAppViewDetails.Text = "Details";
            // 
            // toolAppArrange
            // 
            this.toolAppArrange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAppArrangeAlignTop,
            this.toolAppArrangeAlignLeft,
            this.toolAppArrangeAlignNone});
            this.toolAppArrange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAppArrange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppArrange.Name = "toolAppArrange";
            this.toolAppArrange.Size = new System.Drawing.Size(193, 22);
            this.toolAppArrange.Text = "&Arrange";
            // 
            // toolAppArrangeAlignTop
            // 
            this.toolAppArrangeAlignTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppArrangeAlignTop.Name = "toolAppArrangeAlignTop";
            this.toolAppArrangeAlignTop.Size = new System.Drawing.Size(142, 22);
            this.toolAppArrangeAlignTop.Text = "Align Top";
            // 
            // toolAppArrangeAlignLeft
            // 
            this.toolAppArrangeAlignLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppArrangeAlignLeft.Name = "toolAppArrangeAlignLeft";
            this.toolAppArrangeAlignLeft.Size = new System.Drawing.Size(142, 22);
            this.toolAppArrangeAlignLeft.Text = "Align Left";
            // 
            // toolAppArrangeAlignNone
            // 
            this.toolAppArrangeAlignNone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolAppArrangeAlignNone.Name = "toolAppArrangeAlignNone";
            this.toolAppArrangeAlignNone.Size = new System.Drawing.Size(142, 22);
            this.toolAppArrangeAlignNone.Text = "Align None";
            // 
            // lblInvoiceTitle
            // 
            this.lblInvoiceTitle.Enabled = false;
            this.lblInvoiceTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceTitle.Location = new System.Drawing.Point(10, 353);
            this.lblInvoiceTitle.Name = "lblInvoiceTitle";
            this.lblInvoiceTitle.Size = new System.Drawing.Size(950, 20);
            this.lblInvoiceTitle.TabIndex = 6;
            this.lblInvoiceTitle.Text = "---------- INVOICES ----------";
            this.lblInvoiceTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Enabled = false;
            this.lblAppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.Location = new System.Drawing.Point(10, 585);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(950, 20);
            this.lblAppTitle.TabIndex = 7;
            this.lblAppTitle.Text = "---------- APPLICATIONS ----------";
            this.lblAppTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTitle.Location = new System.Drawing.Point(972, 142);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(596, 22);
            this.txtTitle.TabIndex = 9;
            this.txtTitle.Text = "Invoice Statistic Title";
            this.txtTitle.Visible = false;
            // 
            // appTabsControl
            // 
            this.appTabsControl.Location = new System.Drawing.Point(971, 140);
            this.appTabsControl.Name = "appTabsControl";
            this.appTabsControl.Size = new System.Drawing.Size(603, 661);
            this.appTabsControl.TabIndex = 3;
            this.appTabsControl.Visible = false;
            // 
            // invStatsControl
            // 
            this.invStatsControl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.invStatsControl.Location = new System.Drawing.Point(967, 158);
            this.invStatsControl.Name = "invStatsControl";
            this.invStatsControl.Size = new System.Drawing.Size(601, 270);
            this.invStatsControl.TabIndex = 8;
            this.invStatsControl.Visible = false;
            // 
            // invPaymentControl
            // 
            this.invPaymentControl.Location = new System.Drawing.Point(968, 159);
            this.invPaymentControl.Name = "invPaymentControl";
            this.invPaymentControl.Size = new System.Drawing.Size(602, 358);
            this.invPaymentControl.TabIndex = 11;
            this.invPaymentControl.Visible = false;
            // 
            // invDetailControl
            // 
            this.invDetailControl.Location = new System.Drawing.Point(972, 137);
            this.invDetailControl.Name = "invDetailControl";
            this.invDetailControl.Size = new System.Drawing.Size(597, 669);
            this.invDetailControl.TabIndex = 10;
            this.invDetailControl.Visible = false;
            // 
            // mnuMaster
            // 
            this.mnuMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttlblClock,
            this.sttlblCount});
            resources.ApplyResources(this.mnuMaster, "mnuMaster");
            this.mnuMaster.Name = "mnuMaster";
            // 
            // sttlblClock
            // 
            this.sttlblClock.Name = "sttlblClock";
            resources.ApplyResources(this.sttlblClock, "sttlblClock");

            // 
            // sttlblCount
            // 
            this.sttlblCount.Name = "sttlblCount";
            resources.ApplyResources(this.sttlblCount, "sttlblCount");

            // 
            // FormBillingManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 833);
            this.Controls.Add(this.uInvoicingRibbon);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblAppTitle);
            this.Controls.Add(this.lblInvoiceTitle);
            this.Controls.Add(this.olvApplications);
            this.Controls.Add(this.olvInvoices);
            this.Controls.Add(this.olvClients);
            this.Controls.Add(this.appTabsControl);
            this.Controls.Add(this.invStatsControl);
            this.Controls.Add(this.invPaymentControl);
            this.Controls.Add(this.invDetailControl);
            this.Controls.Add(this.mnuMaster);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBillingManager";
            this.Text = "Billing Manager";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormBillingManager_LoadCompleted);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBillingManager_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormBillingManager_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.olvClients)).EndInit();
            this.cmnuClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvInvoices)).EndInit();
            this.cmnuInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvApplications)).EndInit();
            this.cmnuApplication.ResumeLayout(false);
            this.mnuMaster.ResumeLayout(false);
            this.mnuMaster.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView olvClients;
        private BrightIdeasSoftware.OLVColumn olvColClientName;
        private BrightIdeasSoftware.OLVColumn olvColClientManagement;
        private BrightIdeasSoftware.OLVColumn olvColClientPhone;
        private BrightIdeasSoftware.OLVColumn olvColClientFax;
        private BrightIdeasSoftware.OLVColumn olvColClientSince;
        private BrightIdeasSoftware.FastObjectListView olvInvoices;
        private BrightIdeasSoftware.OLVColumn olvColInvClientName;
        private BrightIdeasSoftware.OLVColumn olvColInvDivision;
        private BrightIdeasSoftware.OLVColumn olvColInvMonth;
        private BrightIdeasSoftware.OLVColumn olvColInvStatus;
        private BrightIdeasSoftware.OLVColumn olvColInvActionStatus;
        private BrightIdeasSoftware.FastObjectListView olvApplications;
        private BrightIdeasSoftware.OLVColumn olvColAppName;
        private BrightIdeasSoftware.OLVColumn olvColAppClientName;
        private BrightIdeasSoftware.OLVColumn olvColAppReportType;
        private BrightIdeasSoftware.OLVColumn olvColAppReceivedDate;
        private BrightIdeasSoftware.OLVColumn olvColAppInvDivision;
        private BrightIdeasSoftware.OLVColumn olvColInvNum;
        private BrightIdeasSoftware.OLVColumn olvColInvAmount;
        private BrightIdeasSoftware.OLVColumn olvColInvBalance;
        private BrightIdeasSoftware.OLVColumn olvColAppRoommate;
        private UserControls.AppExplore.AppTabsControl appTabsControl;
        private System.Windows.Forms.ContextMenuStrip cmnuClient;
        private System.Windows.Forms.ToolStripMenuItem toolClientPaymentHistory;
        private System.Windows.Forms.ToolStripMenuItem toolClientPrintInvOfPastDues;
        private System.Windows.Forms.ToolStripMenuItem toolClientPrintMenu;
        private System.Windows.Forms.ToolStripMenuItem toolClientCreateDatagrid;
        private System.Windows.Forms.ToolStripMenuItem toolClientView;
        private System.Windows.Forms.ToolStripMenuItem toolClientArrange;
        private System.Windows.Forms.ToolStripMenuItem toolClientPrintLabels;
        private System.Windows.Forms.ToolStripMenuItem toolClientPrintInfoSheets;
        private System.Windows.Forms.ToolStripMenuItem toolClientPrintResidentialContracts;
        private System.Windows.Forms.ToolStripMenuItem toolClientPrintEmploymentContracts;
        private System.Windows.Forms.ToolStripMenuItem toolClientDatagridAllClients;
        private System.Windows.Forms.ToolStripMenuItem toolClientDatagridSelectedClients;
        private System.Windows.Forms.ToolStripMenuItem toolClientViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem toolClientViewLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem toolClientViewList;
        private System.Windows.Forms.ToolStripMenuItem toolClientViewDetails;
        private System.Windows.Forms.ToolStripMenuItem toolClientArrangeAlignTop;
        private System.Windows.Forms.ToolStripMenuItem toolClientArrangeAlignLeft;
        private System.Windows.Forms.ToolStripMenuItem toolClientArrangeAlignNone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip cmnuInvoice;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceShow;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceEditPayments;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceSearch;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceStats;
        private System.Windows.Forms.ToolStripMenuItem toolInvoicePrint;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceEmail;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceUpdateClientName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceDelete;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceCreateDatagrid;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceDatagridAllShownInvoices;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceDatagridSelectedInvoices;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceView;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceViewLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceViewList;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceViewDetails;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceArrange;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceArrangeAlignTop;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceArrangeAlignLeft;
        private System.Windows.Forms.ToolStripMenuItem toolInvoiceArrangeAlignNone;
        private System.Windows.Forms.ContextMenuStrip cmnuApplication;
        private System.Windows.Forms.ToolStripMenuItem toolAppEdit;
        private System.Windows.Forms.ToolStripMenuItem toolAppShowBilledStatus;
        private System.Windows.Forms.ToolStripMenuItem toolAppFindOnInvoice;
        private System.Windows.Forms.ToolStripMenuItem toolAppBillingValidation;
        private System.Windows.Forms.ToolStripMenuItem toolAppMoveTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolAppMoveToArchive;
        private System.Windows.Forms.ToolStripMenuItem toolAppMoveToReview;
        private System.Windows.Forms.ToolStripMenuItem toolAppMoveToPickup;
        private System.Windows.Forms.ToolStripMenuItem toolAppMoveToNewApps;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolAppCreateDatagrid;
        private System.Windows.Forms.ToolStripMenuItem toolAppDatagridAllShownApps;
        private System.Windows.Forms.ToolStripMenuItem toolAppDatagridSelectedApps;
        private System.Windows.Forms.ToolStripMenuItem toolAppSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolAppDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolAppView;
        private System.Windows.Forms.ToolStripMenuItem toolAppViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem toolAppViewLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem toolAppViewList;
        private System.Windows.Forms.ToolStripMenuItem toolAppViewDetails;
        private System.Windows.Forms.ToolStripMenuItem toolAppArrange;
        private System.Windows.Forms.ToolStripMenuItem toolAppArrangeAlignTop;
        private System.Windows.Forms.ToolStripMenuItem toolAppArrangeAlignLeft;
        private System.Windows.Forms.ToolStripMenuItem toolAppArrangeAlignNone;
        private System.Windows.Forms.TextBox lblInvoiceTitle;
        private System.Windows.Forms.TextBox lblAppTitle;
        private UserControls.Invoicing.InvStatsControl invStatsControl;
        private System.Windows.Forms.TextBox txtTitle;
        private UserControls.Invoicing.InvDetailControl invDetailControl;
        private UserControls.Invoicing.InvPaymentControl invPaymentControl;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private BrightIdeasSoftware.OLVColumn olvColAppBilledStatus;

        private UserControls.Ribbons.InvoicingRibbon uInvoicingRibbon;

        private System.Windows.Forms.StatusStrip mnuMaster;
        private System.Windows.Forms.ToolStripStatusLabel sttlblClock;
        private System.Windows.Forms.ToolStripStatusLabel sttlblCount;
        private System.Windows.Forms.ToolStripMenuItem wordToolEmailInvoice;
        private System.Windows.Forms.ToolStripMenuItem pdfToolEmailInvoice;
    }
}