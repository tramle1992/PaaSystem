namespace PaaApplication.Forms
{
    partial class FormClientInfo
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
        /// 

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientInfo));
            this.uClientInfoRibbon = new PaaApplication.UserControls.Ribbons.ClientInfoRibbon(formMaster);
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            this.olvClientInfo = new BrightIdeasSoftware.FastObjectListView();
            this.olvcolClientName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolManagement = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolCustNo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolPhone = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolFax = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolSince = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cmnuClientInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tstripAddClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tstripDeleteClient = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstripPrintMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.labelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientInfoSheetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.residentialContractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employmentContractsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstripCreateDataGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.fromAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromSelectedClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tstripComposeEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tstripView = new System.Windows.Forms.ToolStripMenuItem();
            this.tstripArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.ucClientInfo = new PaaApplication.UserControls.ClientInfo.ClientInfoTabsControl(this);
            this.mnuMaster = new System.Windows.Forms.StatusStrip();
            this.sttlblClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttlblCount = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.olvClientInfo)).BeginInit();
            this.cmnuClientInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // uClientInfoRibbon
            // 
            this.uClientInfoRibbon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uClientInfoRibbon.Dock = System.Windows.Forms.DockStyle.Top;
            this.uClientInfoRibbon.Size = new System.Drawing.Size(900, 130);
            this.uClientInfoRibbon.Name = "uClientInfoRibbon";
            this.uClientInfoRibbon.TabIndex = 0;
            // 
            // txtSearch
            // 
            //this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearch.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.Location = new System.Drawing.Point(5, 140);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(305, 24);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.WatermarkText = null;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // olvClientInfo
            // 
            this.olvClientInfo.AllColumns.Add(this.olvcolClientName);
            this.olvClientInfo.AllColumns.Add(this.olvcolManagement);
            this.olvClientInfo.AllColumns.Add(this.olvcolCustNo);
            this.olvClientInfo.AllColumns.Add(this.olvcolPhone);
            this.olvClientInfo.AllColumns.Add(this.olvcolFax);
            this.olvClientInfo.AllColumns.Add(this.olvcolSince);
            this.olvClientInfo.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvClientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvClientInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolClientName,
            this.olvcolManagement,
            this.olvcolCustNo,
            this.olvcolPhone,
            this.olvcolFax,
            this.olvcolSince});
            this.olvClientInfo.ContextMenuStrip = this.cmnuClientInfo;
            this.olvClientInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvClientInfo.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvClientInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvClientInfo.FullRowSelect = true;
            this.olvClientInfo.HideSelection = false;
            this.olvClientInfo.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvClientInfo.HotItemStyle = this.hotItemStyle;
            this.olvClientInfo.Location = new System.Drawing.Point(5, 173);
            this.olvClientInfo.Name = "olvClientInfo";
            this.olvClientInfo.ShowGroups = false;
            this.olvClientInfo.Size = new System.Drawing.Size(977, 640);
            this.olvClientInfo.TabIndex = 4;
            this.olvClientInfo.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvClientInfo.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvClientInfo.UseAlternatingBackColors = true;
            this.olvClientInfo.UseCompatibleStateImageBehavior = false;
            this.olvClientInfo.UseCustomSelectionColors = true;
            this.olvClientInfo.UseFiltering = true;
            this.olvClientInfo.UseHotItem = true;
            this.olvClientInfo.View = System.Windows.Forms.View.Details;
            this.olvClientInfo.VirtualMode = true;
            this.olvClientInfo.SelectionChanged += new System.EventHandler(this.olvClientInfo_SelectionChanged);
            this.olvClientInfo.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.olvClientInfo_ItemsChanged);
            // 
            // olvcolClientName
            // 
            this.olvcolClientName.AspectName = "ClientName";
            this.olvcolClientName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolClientName.Text = "Client Name";
            this.olvcolClientName.Width = 230;
            // 
            // olvcolManagement
            // 
            this.olvcolManagement.AspectName = "ManagementCompany.Name";
            this.olvcolManagement.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolManagement.Text = "Management";
            this.olvcolManagement.Width = 211;
            // 
            // olvcolCustNo
            // 
            this.olvcolCustNo.AspectName = "CustomerNumber";
            this.olvcolCustNo.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolCustNo.Text = "Cust. No";
            this.olvcolCustNo.Width = 80;
            // 
            // olvcolPhone
            // 
            this.olvcolPhone.AspectName = "Phone";
            this.olvcolPhone.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolPhone.Text = "Phone";
            this.olvcolPhone.Width = 150;
            // 
            // olvcolFax
            // 
            this.olvcolFax.AspectName = "Fax";
            this.olvcolFax.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolFax.Text = "Fax";
            this.olvcolFax.Width = 150;
            // 
            // olvcolSince
            // 
            this.olvcolSince.AspectName = "Since";
            this.olvcolSince.AspectToStringFormat = "{0:MM / dd / yyyy}";
            this.olvcolSince.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolSince.Text = "Since";
            this.olvcolSince.Width = 130;
            // 
            // cmnuClientInfo
            // 
            this.cmnuClientInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstripAddClient,
            this.tstripDeleteClient,
            this.toolStripSeparator1,
            this.tstripPrintMenu,
            this.tstripCreateDataGrid,
            this.tstripComposeEmail,
            this.toolStripSeparator2,
            this.tstripView,
            this.tstripArrange});
            this.cmnuClientInfo.Name = "contextMenuStrip1";
            this.cmnuClientInfo.Size = new System.Drawing.Size(168, 192);
            // 
            // tstripAddClient
            // 
            this.tstripAddClient.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstripAddClient.Image = ((System.Drawing.Image)(resources.GetObject("tstripAddClient.Image")));
            this.tstripAddClient.Name = "tstripAddClient";
            this.tstripAddClient.Size = new System.Drawing.Size(167, 22);
            this.tstripAddClient.Text = "Add Client";
            this.tstripAddClient.Click += new System.EventHandler(this.tstripAddClient_Click);
            // 
            // tstripDeleteClient
            // 
            this.tstripDeleteClient.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstripDeleteClient.Image = ((System.Drawing.Image)(resources.GetObject("tstripDeleteClient.Image")));
            this.tstripDeleteClient.Name = "tstripDeleteClient";
            this.tstripDeleteClient.Size = new System.Drawing.Size(167, 22);
            this.tstripDeleteClient.Text = "Delete Client";
            this.tstripDeleteClient.Click += new System.EventHandler(this.tstripDeleteClient_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // tstripPrintMenu
            // 
            this.tstripPrintMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelsToolStripMenuItem,
            this.clientInfoSheetsToolStripMenuItem,
            this.residentialContractToolStripMenuItem,
            this.employmentContractsToolStripMenuItem});
            this.tstripPrintMenu.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstripPrintMenu.Image = ((System.Drawing.Image)(resources.GetObject("tstripPrintMenu.Image")));
            this.tstripPrintMenu.Name = "tstripPrintMenu";
            this.tstripPrintMenu.Size = new System.Drawing.Size(167, 22);
            this.tstripPrintMenu.Text = "Print Menu";
            // 
            // labelsToolStripMenuItem
            // 
            this.labelsToolStripMenuItem.Name = "labelsToolStripMenuItem";
            this.labelsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.labelsToolStripMenuItem.Text = "Label(s)";
            this.labelsToolStripMenuItem.Click += new System.EventHandler(this.labelsToolStripMenuItem_Click);
            // 
            // clientInfoSheetsToolStripMenuItem
            // 
            this.clientInfoSheetsToolStripMenuItem.Name = "clientInfoSheetsToolStripMenuItem";
            this.clientInfoSheetsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.clientInfoSheetsToolStripMenuItem.Text = "Client Info Sheet(s)";
            this.clientInfoSheetsToolStripMenuItem.Click += new System.EventHandler(this.clientInfoSheetsToolStripMenuItem_Click);
            // 
            // residentialContractToolStripMenuItem
            // 
            this.residentialContractToolStripMenuItem.Name = "residentialContractToolStripMenuItem";
            this.residentialContractToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.residentialContractToolStripMenuItem.Text = "Residential Contracts";
            this.residentialContractToolStripMenuItem.Click += new System.EventHandler(this.residentialContractToolStripMenuItem_Click);
            // 
            // employmentContractsToolStripMenuItem
            // 
            this.employmentContractsToolStripMenuItem.Name = "employmentContractsToolStripMenuItem";
            this.employmentContractsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.employmentContractsToolStripMenuItem.Text = "Employment Contracts";
            this.employmentContractsToolStripMenuItem.Click += new System.EventHandler(this.employmentContractsToolStripMenuItem_Click);
            // 
            // tstripCreateDataGrid
            // 
            this.tstripCreateDataGrid.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromAllToolStripMenuItem,
            this.fromSelectedClientsToolStripMenuItem});
            this.tstripCreateDataGrid.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstripCreateDataGrid.Image = ((System.Drawing.Image)(resources.GetObject("tstripCreateDataGrid.Image")));
            this.tstripCreateDataGrid.Name = "tstripCreateDataGrid";
            this.tstripCreateDataGrid.Size = new System.Drawing.Size(167, 22);
            this.tstripCreateDataGrid.Text = "Create Datagrid";
            // 
            // fromAllToolStripMenuItem
            // 
            this.fromAllToolStripMenuItem.Name = "fromAllToolStripMenuItem";
            this.fromAllToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.fromAllToolStripMenuItem.Text = "From All Clients";
            this.fromAllToolStripMenuItem.Click += new System.EventHandler(this.fromAllToolStripMenuItem_Click);
            // 
            // fromSelectedClientsToolStripMenuItem
            // 
            this.fromSelectedClientsToolStripMenuItem.Name = "fromSelectedClientsToolStripMenuItem";
            this.fromSelectedClientsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.fromSelectedClientsToolStripMenuItem.Text = "From Selected Clients";
            this.fromSelectedClientsToolStripMenuItem.Click += new System.EventHandler(this.fromSelectedClientsToolStripMenuItem_Click);
            // 
            // tstripComposeEmail
            // 
            this.tstripComposeEmail.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstripComposeEmail.Image = ((System.Drawing.Image)(resources.GetObject("tstripComposeEmail.Image")));
            this.tstripComposeEmail.Name = "tstripComposeEmail";
            this.tstripComposeEmail.Size = new System.Drawing.Size(167, 22);
            this.tstripComposeEmail.Text = "Compose Email";
            this.tstripComposeEmail.Click += new System.EventHandler(this.tstripComposeEmail_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // tstripView
            // 
            this.tstripView.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstripView.Name = "tstripView";
            this.tstripView.Size = new System.Drawing.Size(167, 22);
            this.tstripView.Text = "View";
            // 
            // tstripArrange
            // 
            this.tstripArrange.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstripArrange.Name = "tstripArrange";
            this.tstripArrange.Size = new System.Drawing.Size(167, 22);
            this.tstripArrange.Text = "Arrange";
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // ucClientInfo
            // 
            this.ucClientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right))));
            this.ucClientInfo.EditingClientName = null;
            this.ucClientInfo.Location = new System.Drawing.Point(983, 140);
            this.ucClientInfo.Name = "ucClientInfo";
            this.ucClientInfo.Size = new System.Drawing.Size(593, 680);
            this.ucClientInfo.TabIndex = 0;
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
            // FormClientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 842);
            this.Controls.Add(this.uClientInfoRibbon);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.olvClientInfo);
            this.Controls.Add(this.ucClientInfo);
            this.Controls.Add(this.mnuMaster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormClientInfo";
            this.Text = "Client Info";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormClientInfo_LoadCompleted);
            this.Load += new System.EventHandler(this.FormClientInfo_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClientInfo_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormClientInfo_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.olvClientInfo)).EndInit();
            this.mnuMaster.ResumeLayout(false);
            this.mnuMaster.PerformLayout();
            this.cmnuClientInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ClientInfo.ClientInfoTabsControl ucClientInfo;
        private UserControls.Ribbons.ClientInfoRibbon uClientInfoRibbon;
        
        private ExtendControls.WaterMarkTextBox txtSearch;
        private BrightIdeasSoftware.FastObjectListView olvClientInfo;
        private BrightIdeasSoftware.OLVColumn olvcolClientName;
        private BrightIdeasSoftware.OLVColumn olvcolManagement;
        private BrightIdeasSoftware.OLVColumn olvcolCustNo;
        private BrightIdeasSoftware.OLVColumn olvcolPhone;
        private BrightIdeasSoftware.OLVColumn olvcolFax;
        private BrightIdeasSoftware.OLVColumn olvcolSince;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private System.Windows.Forms.ContextMenuStrip cmnuClientInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tstripPrintMenu;
        private System.Windows.Forms.ToolStripMenuItem tstripCreateDataGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tstripView;
        private System.Windows.Forms.ToolStripMenuItem tstripArrange;
        private System.Windows.Forms.ToolStripMenuItem tstripAddClient;
        private System.Windows.Forms.ToolStripMenuItem tstripDeleteClient;
        private System.Windows.Forms.ToolStripMenuItem tstripComposeEmail;
        private System.Windows.Forms.ToolStripMenuItem labelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientInfoSheetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem residentialContractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employmentContractsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromSelectedClientsToolStripMenuItem;

        private System.Windows.Forms.StatusStrip mnuMaster;
        private System.Windows.Forms.ToolStripStatusLabel sttlblClock;
        private System.Windows.Forms.ToolStripStatusLabel sttlblCount;
    }
}