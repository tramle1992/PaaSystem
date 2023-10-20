namespace PaaApplication.Forms.AppExplore
{
    partial class FormEportCredit
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
            this.tabDisplay = new System.Windows.Forms.TabControl();
            this.tabPageApplications = new System.Windows.Forms.TabPage();
            this.olvApplications = new BrightIdeasSoftware.FastObjectListView();
            this.olvcolAppName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolAppClient = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolAppType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolAppReceived = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.tabPageDuplicates = new System.Windows.Forms.TabPage();
            this.tlvDuplicates = new BrightIdeasSoftware.DataTreeListView();
            this.olvcolDupName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupClient = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupReceived = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupLastName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupFirstName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupLocationId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnCheckForDuplicates = new System.Windows.Forms.Button();
            this.lblDuplicate = new System.Windows.Forms.Label();
            this.olvcolDupCompany = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabDisplay.SuspendLayout();
            this.tabPageApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvApplications)).BeginInit();
            this.tabPageDuplicates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvDuplicates)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDisplay
            // 
            this.tabDisplay.Controls.Add(this.tabPageApplications);
            this.tabDisplay.Controls.Add(this.tabPageDuplicates);
            this.tabDisplay.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDisplay.Location = new System.Drawing.Point(0, 97);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.SelectedIndex = 0;
            this.tabDisplay.Size = new System.Drawing.Size(686, 290);
            this.tabDisplay.TabIndex = 0;
            // 
            // tabPageApplications
            // 
            this.tabPageApplications.Controls.Add(this.olvApplications);
            this.tabPageApplications.Location = new System.Drawing.Point(4, 25);
            this.tabPageApplications.Name = "tabPageApplications";
            this.tabPageApplications.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageApplications.Size = new System.Drawing.Size(678, 261);
            this.tabPageApplications.TabIndex = 0;
            this.tabPageApplications.Text = "Applications";
            this.tabPageApplications.UseVisualStyleBackColor = true;
            // 
            // olvApplications
            // 
            this.olvApplications.AllColumns.Add(this.olvcolAppName);
            this.olvApplications.AllColumns.Add(this.olvcolAppClient);
            this.olvApplications.AllColumns.Add(this.olvcolAppType);
            this.olvApplications.AllColumns.Add(this.olvcolAppReceived);
            this.olvApplications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolAppName,
            this.olvcolAppClient,
            this.olvcolAppType,
            this.olvcolAppReceived});
            this.olvApplications.CopySelectionOnControlCUsesDragSource = false;
            this.olvApplications.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvApplications.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvApplications.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvApplications.FullRowSelect = true;
            this.olvApplications.HideSelection = false;
            this.olvApplications.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvApplications.HotItemStyle = this.hotItemStyle;
            this.olvApplications.Location = new System.Drawing.Point(0, 0);
            this.olvApplications.MultiSelect = false;
            this.olvApplications.Name = "olvApplications";
            this.olvApplications.SelectColumnsOnRightClick = false;
            this.olvApplications.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.olvApplications.ShowFilterMenuOnRightClick = false;
            this.olvApplications.ShowGroups = false;
            this.olvApplications.Size = new System.Drawing.Size(678, 264);
            this.olvApplications.TabIndex = 0;
            this.olvApplications.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvApplications.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvApplications.UseCompatibleStateImageBehavior = false;
            this.olvApplications.UseHotItem = true;
            this.olvApplications.View = System.Windows.Forms.View.Details;
            this.olvApplications.VirtualMode = true;
            this.olvApplications.DoubleClick += new System.EventHandler(this.olvApplications_DoubleClick);
            // 
            // olvcolAppName
            // 
            this.olvcolAppName.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolAppName.IsEditable = false;
            this.olvcolAppName.Searchable = false;
            this.olvcolAppName.Text = "Name";
            this.olvcolAppName.UseFiltering = false;
            this.olvcolAppName.Width = 170;
            // 
            // olvcolAppClient
            // 
            this.olvcolAppClient.AspectName = "ClientAppliedName";
            this.olvcolAppClient.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolAppClient.IsEditable = false;
            this.olvcolAppClient.Searchable = false;
            this.olvcolAppClient.Text = "Client";
            this.olvcolAppClient.UseFiltering = false;
            this.olvcolAppClient.Width = 170;
            // 
            // olvcolAppType
            // 
            this.olvcolAppType.AspectName = "ReportTypeName";
            this.olvcolAppType.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolAppType.IsEditable = false;
            this.olvcolAppType.Searchable = false;
            this.olvcolAppType.Text = "Type";
            this.olvcolAppType.UseFiltering = false;
            this.olvcolAppType.Width = 120;
            // 
            // olvcolAppReceived
            // 
            this.olvcolAppReceived.AspectName = "ReceivedDate";
            this.olvcolAppReceived.AspectToStringFormat = "{0:MM/dd/yyyy hh:mm tt}";
            this.olvcolAppReceived.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolAppReceived.IsEditable = false;
            this.olvcolAppReceived.Searchable = false;
            this.olvcolAppReceived.Text = "Received";
            this.olvcolAppReceived.UseFiltering = false;
            this.olvcolAppReceived.Width = 150;
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // tabPageDuplicates
            // 
            this.tabPageDuplicates.Controls.Add(this.tlvDuplicates);
            this.tabPageDuplicates.Location = new System.Drawing.Point(4, 25);
            this.tabPageDuplicates.Name = "tabPageDuplicates";
            this.tabPageDuplicates.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDuplicates.Size = new System.Drawing.Size(678, 261);
            this.tabPageDuplicates.TabIndex = 1;
            this.tabPageDuplicates.Text = "Duplicates";
            this.tabPageDuplicates.UseVisualStyleBackColor = true;
            // 
            // tlvDuplicates
            // 
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupName);
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupClient);
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupType);
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupReceived);
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupLastName);
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupFirstName);
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupLocationId);
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupCompany);
            this.tlvDuplicates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolDupName,
            this.olvcolDupClient,
            this.olvcolDupType,
            this.olvcolDupReceived});
            this.tlvDuplicates.CopySelectionOnControlCUsesDragSource = false;
            this.tlvDuplicates.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvDuplicates.DataSource = null;
            this.tlvDuplicates.FullRowSelect = true;
            this.tlvDuplicates.HideSelection = false;
            this.tlvDuplicates.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.tlvDuplicates.HotItemStyle = this.hotItemStyle;
            this.tlvDuplicates.KeyAspectName = "Id";
            this.tlvDuplicates.Location = new System.Drawing.Point(0, 0);
            this.tlvDuplicates.MultiSelect = false;
            this.tlvDuplicates.Name = "tlvDuplicates";
            this.tlvDuplicates.OwnerDraw = true;
            this.tlvDuplicates.ParentKeyAspectName = "ParentId";
            this.tlvDuplicates.RootKeyValueString = "0";
            this.tlvDuplicates.SelectColumnsOnRightClick = false;
            this.tlvDuplicates.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.tlvDuplicates.ShowFilterMenuOnRightClick = false;
            this.tlvDuplicates.ShowGroups = false;
            this.tlvDuplicates.ShowKeyColumns = false;
            this.tlvDuplicates.Size = new System.Drawing.Size(678, 264);
            this.tlvDuplicates.TabIndex = 0;
            this.tlvDuplicates.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.tlvDuplicates.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.tlvDuplicates.UseCompatibleStateImageBehavior = false;
            this.tlvDuplicates.UseHotItem = true;
            this.tlvDuplicates.View = System.Windows.Forms.View.Details;
            this.tlvDuplicates.VirtualMode = true;
            this.tlvDuplicates.DoubleClick += new System.EventHandler(this.tlvDuplicates_DoubleClick);
            // 
            // olvcolDupName
            // 
            this.olvcolDupName.IsEditable = false;
            this.olvcolDupName.Searchable = false;
            this.olvcolDupName.Text = "Name";
            this.olvcolDupName.UseFiltering = false;
            this.olvcolDupName.Width = 170;
            // 
            // olvcolDupClient
            // 
            this.olvcolDupClient.AspectName = "ClientAppliedName";
            this.olvcolDupClient.IsEditable = false;
            this.olvcolDupClient.Searchable = false;
            this.olvcolDupClient.Text = "Client";
            this.olvcolDupClient.UseFiltering = false;
            this.olvcolDupClient.Width = 170;
            // 
            // olvcolDupType
            // 
            this.olvcolDupType.AspectName = "ReportTypeName";
            this.olvcolDupType.IsEditable = false;
            this.olvcolDupType.Searchable = false;
            this.olvcolDupType.Text = "Type";
            this.olvcolDupType.UseFiltering = false;
            this.olvcolDupType.Width = 120;
            // 
            // olvcolDupReceived
            // 
            this.olvcolDupReceived.AspectName = "ReceivedDate";
            this.olvcolDupReceived.AspectToStringFormat = "{0:MM/dd/yyyy hh:mm tt}";
            this.olvcolDupReceived.IsEditable = false;
            this.olvcolDupReceived.Searchable = false;
            this.olvcolDupReceived.Text = "Received";
            this.olvcolDupReceived.UseFiltering = false;
            this.olvcolDupReceived.Width = 150;
            // 
            // olvcolDupLastName
            // 
            this.olvcolDupLastName.AspectName = "LastName";
            this.olvcolDupLastName.IsEditable = false;
            this.olvcolDupLastName.IsVisible = false;
            this.olvcolDupLastName.Searchable = false;
            this.olvcolDupLastName.Sortable = false;
            this.olvcolDupLastName.Text = "Last Name";
            this.olvcolDupLastName.UseFiltering = false;
            this.olvcolDupLastName.Width = 0;
            // 
            // olvcolDupFirstName
            // 
            this.olvcolDupFirstName.AspectName = "FirstName";
            this.olvcolDupFirstName.IsEditable = false;
            this.olvcolDupFirstName.IsVisible = false;
            this.olvcolDupFirstName.Searchable = false;
            this.olvcolDupFirstName.Sortable = false;
            this.olvcolDupFirstName.Text = "First Name";
            this.olvcolDupFirstName.UseFiltering = false;
            this.olvcolDupFirstName.Width = 0;
            // 
            // olvcolDupLocationId
            // 
            this.olvcolDupLocationId.AspectName = "LocationId";
            this.olvcolDupLocationId.IsEditable = false;
            this.olvcolDupLocationId.IsVisible = false;
            this.olvcolDupLocationId.Searchable = false;
            this.olvcolDupLocationId.Sortable = false;
            this.olvcolDupLocationId.Text = "LocationId";
            this.olvcolDupLocationId.UseFiltering = false;
            this.olvcolDupLocationId.Width = 0;
            // 
            // btnCheckForDuplicates
            // 
            this.btnCheckForDuplicates.BackColor = System.Drawing.Color.Gray;
            this.btnCheckForDuplicates.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckForDuplicates.ForeColor = System.Drawing.Color.White;
            this.btnCheckForDuplicates.Location = new System.Drawing.Point(12, 12);
            this.btnCheckForDuplicates.Name = "btnCheckForDuplicates";
            this.btnCheckForDuplicates.Size = new System.Drawing.Size(100, 50);
            this.btnCheckForDuplicates.TabIndex = 0;
            this.btnCheckForDuplicates.Text = "Check For Duplicates";
            this.btnCheckForDuplicates.UseVisualStyleBackColor = false;
            this.btnCheckForDuplicates.Click += new System.EventHandler(this.btnCheckForDuplicates_Click);
            // 
            // lblDuplicate
            // 
            this.lblDuplicate.AutoSize = true;
            this.lblDuplicate.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuplicate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDuplicate.Location = new System.Drawing.Point(12, 73);
            this.lblDuplicate.Name = "lblDuplicate";
            this.lblDuplicate.Size = new System.Drawing.Size(73, 16);
            this.lblDuplicate.TabIndex = 1;
            this.lblDuplicate.Text = "lblDuplicate";
            this.lblDuplicate.Visible = false;
            // 
            // olvcolDupCompany
            // 
            this.olvcolDupCompany.AspectName = "Company";
            this.olvcolDupCompany.IsEditable = false;
            this.olvcolDupCompany.IsVisible = false;
            this.olvcolDupCompany.Searchable = false;
            this.olvcolDupCompany.Sortable = false;
            this.olvcolDupCompany.Text = "Company";
            this.olvcolDupCompany.UseFiltering = false;
            this.olvcolDupCompany.Width = 0;
            // 
            // FormEportCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 386);
            this.Controls.Add(this.lblDuplicate);
            this.Controls.Add(this.btnCheckForDuplicates);
            this.Controls.Add(this.tabDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEportCredit";
            this.Text = "Eport Credit";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormEportCredit_LoadCompleted);
            this.tabDisplay.ResumeLayout(false);
            this.tabPageApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvApplications)).EndInit();
            this.tabPageDuplicates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlvDuplicates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabDisplay;
        private System.Windows.Forms.TabPage tabPageApplications;
        private System.Windows.Forms.TabPage tabPageDuplicates;
        private System.Windows.Forms.Button btnCheckForDuplicates;
        private BrightIdeasSoftware.FastObjectListView olvApplications;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private BrightIdeasSoftware.OLVColumn olvcolAppName;
        private BrightIdeasSoftware.OLVColumn olvcolAppClient;
        private BrightIdeasSoftware.OLVColumn olvcolAppType;
        private BrightIdeasSoftware.OLVColumn olvcolAppReceived;
        private BrightIdeasSoftware.DataTreeListView tlvDuplicates;
        private BrightIdeasSoftware.OLVColumn olvcolDupName;
        private BrightIdeasSoftware.OLVColumn olvcolDupClient;
        private BrightIdeasSoftware.OLVColumn olvcolDupType;
        private BrightIdeasSoftware.OLVColumn olvcolDupReceived;
        private System.Windows.Forms.Label lblDuplicate;
        private BrightIdeasSoftware.OLVColumn olvcolDupLastName;
        private BrightIdeasSoftware.OLVColumn olvcolDupFirstName;
        private BrightIdeasSoftware.OLVColumn olvcolDupLocationId;
        private BrightIdeasSoftware.OLVColumn olvcolDupCompany;
    }
}