namespace PaaApplication.Forms.AppExplore
{
    partial class FormPullCredit
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
            this.olvApplications = new BrightIdeasSoftware.FastObjectListView();
            this.olvcolChecked = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolAppName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDOB = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolSSN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolEndUser = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolPermissPurpose = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolCreditType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.btnCancelPull = new System.Windows.Forms.Button();
            this.btnProceed = new System.Windows.Forms.Button();
            this.tabControlPullCredit = new System.Windows.Forms.TabControl();
            this.tabPullCredit = new System.Windows.Forms.TabPage();
            this.tabCheckDuplicate = new System.Windows.Forms.TabPage();
            this.tlvDuplicates = new BrightIdeasSoftware.DataTreeListView();
            this.olvcolDupName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupClient = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupReceived = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnCheckDuplicates = new System.Windows.Forms.Button();
            this.lblDuplicate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.olvApplications)).BeginInit();
            this.tabControlPullCredit.SuspendLayout();
            this.tabPullCredit.SuspendLayout();
            this.tabCheckDuplicate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvDuplicates)).BeginInit();
            this.SuspendLayout();
            // 
            // olvApplications
            // 
            this.olvApplications.AllColumns.Add(this.olvcolChecked);
            this.olvApplications.AllColumns.Add(this.olvcolAppName);
            this.olvApplications.AllColumns.Add(this.olvcolDOB);
            this.olvApplications.AllColumns.Add(this.olvcolSSN);
            this.olvApplications.AllColumns.Add(this.olvcolEndUser);
            this.olvApplications.AllColumns.Add(this.olvcolPermissPurpose);
            this.olvApplications.AllColumns.Add(this.olvcolCreditType);
            this.olvApplications.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvApplications.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvApplications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolChecked,
            this.olvcolAppName,
            this.olvcolDOB,
            this.olvcolSSN,
            this.olvcolEndUser,
            this.olvcolPermissPurpose,
            this.olvcolCreditType});
            this.olvApplications.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvApplications.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvApplications.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvApplications.FullRowSelect = true;
            this.olvApplications.HideSelection = false;
            this.olvApplications.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvApplications.HotItemStyle = this.hotItemStyle;
            this.olvApplications.Location = new System.Drawing.Point(3, 3);
            this.olvApplications.MultiSelect = false;
            this.olvApplications.Name = "olvApplications";
            this.olvApplications.OwnerDraw = true;
            this.olvApplications.ShowGroups = false;
            this.olvApplications.ShowImagesOnSubItems = true;
            this.olvApplications.Size = new System.Drawing.Size(1150, 315);
            this.olvApplications.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.olvApplications.TabIndex = 2;
            this.olvApplications.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvApplications.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvApplications.UseAlternatingBackColors = true;
            this.olvApplications.UseCompatibleStateImageBehavior = false;
            this.olvApplications.UseFiltering = true;
            this.olvApplications.UseHotItem = true;
            this.olvApplications.UseSubItemCheckBoxes = true;
            this.olvApplications.View = System.Windows.Forms.View.Details;
            this.olvApplications.VirtualMode = true;
            this.olvApplications.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.olvApplications_ItemChecked);
            // 
            // olvcolChecked
            // 
            this.olvcolChecked.AspectName = "";
            this.olvcolChecked.CheckBoxes = true;
            this.olvcolChecked.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.olvcolChecked.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolChecked.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolChecked.Searchable = false;
            this.olvcolChecked.Sortable = false;
            this.olvcolChecked.Text = "";
            this.olvcolChecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolChecked.UseFiltering = false;
            this.olvcolChecked.Width = 70;
            // 
            // olvcolAppName
            // 
            this.olvcolAppName.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolAppName.IsEditable = false;
            this.olvcolAppName.Searchable = false;
            this.olvcolAppName.Text = "Applicant Name";
            this.olvcolAppName.UseFiltering = false;
            this.olvcolAppName.Width = 230;
            // 
            // olvcolDOB
            // 
            this.olvcolDOB.AspectToStringFormat = "{0:MM / dd / yyyy}";
            this.olvcolDOB.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolDOB.IsEditable = false;
            this.olvcolDOB.Searchable = false;
            this.olvcolDOB.Text = "DOB";
            this.olvcolDOB.UseFiltering = false;
            this.olvcolDOB.Width = 170;
            // 
            // olvcolSSN
            // 
            this.olvcolSSN.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolSSN.IsEditable = false;
            this.olvcolSSN.Searchable = false;
            this.olvcolSSN.Text = "SSN";
            this.olvcolSSN.UseFiltering = false;
            this.olvcolSSN.Width = 170;
            // 
            // olvcolEndUser
            // 
            this.olvcolEndUser.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolEndUser.IsEditable = false;
            this.olvcolEndUser.Searchable = false;
            this.olvcolEndUser.Text = "End User";
            this.olvcolEndUser.UseFiltering = false;
            this.olvcolEndUser.Width = 170;
            // 
            // olvcolPermissPurpose
            // 
            this.olvcolPermissPurpose.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolPermissPurpose.IsEditable = false;
            this.olvcolPermissPurpose.Searchable = false;
            this.olvcolPermissPurpose.Text = "Permissible Purpose";
            this.olvcolPermissPurpose.UseFiltering = false;
            this.olvcolPermissPurpose.Width = 170;
            // 
            // olvcolCreditType
            // 
            this.olvcolCreditType.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolCreditType.IsEditable = false;
            this.olvcolCreditType.Searchable = false;
            this.olvcolCreditType.Text = "Credit Type";
            this.olvcolCreditType.UseFiltering = false;
            this.olvcolCreditType.Width = 170;
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // btnCancelPull
            // 
            this.btnCancelPull.BackColor = System.Drawing.Color.Gray;
            this.btnCancelPull.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelPull.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelPull.ForeColor = System.Drawing.Color.White;
            this.btnCancelPull.Location = new System.Drawing.Point(1021, 391);
            this.btnCancelPull.Name = "btnCancelPull";
            this.btnCancelPull.Size = new System.Drawing.Size(149, 68);
            this.btnCancelPull.TabIndex = 28;
            this.btnCancelPull.Text = "Cancel";
            this.btnCancelPull.UseVisualStyleBackColor = false;
            this.btnCancelPull.Click += new System.EventHandler(this.btnCancelPull_Click);
            // 
            // btnProceed
            // 
            this.btnProceed.BackColor = System.Drawing.Color.Gray;
            this.btnProceed.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnProceed.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.ForeColor = System.Drawing.Color.White;
            this.btnProceed.Location = new System.Drawing.Point(841, 391);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(149, 68);
            this.btnProceed.TabIndex = 28;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // tabControlPullCredit
            // 
            this.tabControlPullCredit.Controls.Add(this.tabPullCredit);
            this.tabControlPullCredit.Controls.Add(this.tabCheckDuplicate);
            this.tabControlPullCredit.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlPullCredit.Location = new System.Drawing.Point(12, 12);
            this.tabControlPullCredit.Name = "tabControlPullCredit";
            this.tabControlPullCredit.SelectedIndex = 0;
            this.tabControlPullCredit.Size = new System.Drawing.Size(1164, 350);
            this.tabControlPullCredit.TabIndex = 29;
            this.tabControlPullCredit.SelectedIndexChanged += new System.EventHandler(this.tabControlPullCredit_SelectedIndexChanged);
            // 
            // tabPullCredit
            // 
            this.tabPullCredit.Controls.Add(this.olvApplications);
            this.tabPullCredit.Location = new System.Drawing.Point(4, 29);
            this.tabPullCredit.Name = "tabPullCredit";
            this.tabPullCredit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPullCredit.Size = new System.Drawing.Size(1156, 317);
            this.tabPullCredit.TabIndex = 0;
            this.tabPullCredit.Text = "Applications";
            this.tabPullCredit.UseVisualStyleBackColor = true;
            // 
            // tabCheckDuplicate
            // 
            this.tabCheckDuplicate.Controls.Add(this.tlvDuplicates);
            this.tabCheckDuplicate.Location = new System.Drawing.Point(4, 29);
            this.tabCheckDuplicate.Name = "tabCheckDuplicate";
            this.tabCheckDuplicate.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheckDuplicate.Size = new System.Drawing.Size(1156, 317);
            this.tabCheckDuplicate.TabIndex = 1;
            this.tabCheckDuplicate.Text = "Duplicates";
            this.tabCheckDuplicate.UseVisualStyleBackColor = true;
            // 
            // tlvDuplicates
            // 
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupName);
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupClient);
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupType);
            this.tlvDuplicates.AllColumns.Add(this.olvcolDupReceived);
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
            this.tlvDuplicates.Location = new System.Drawing.Point(-4, 0);
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
            this.tlvDuplicates.Size = new System.Drawing.Size(1160, 328);
            this.tlvDuplicates.TabIndex = 1;
            this.tlvDuplicates.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.tlvDuplicates.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.tlvDuplicates.UseCompatibleStateImageBehavior = false;
            this.tlvDuplicates.UseHotItem = true;
            this.tlvDuplicates.View = System.Windows.Forms.View.Details;
            this.tlvDuplicates.VirtualMode = true;
            // 
            // olvcolDupName
            // 
            this.olvcolDupName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolDupName.IsEditable = false;
            this.olvcolDupName.Searchable = false;
            this.olvcolDupName.Text = "Name";
            this.olvcolDupName.UseFiltering = false;
            this.olvcolDupName.Width = 170;
            // 
            // olvcolDupClient
            // 
            this.olvcolDupClient.AspectName = "ClientAppliedName";
            this.olvcolDupClient.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolDupClient.IsEditable = false;
            this.olvcolDupClient.Searchable = false;
            this.olvcolDupClient.Text = "Client";
            this.olvcolDupClient.UseFiltering = false;
            this.olvcolDupClient.Width = 170;
            // 
            // olvcolDupType
            // 
            this.olvcolDupType.AspectName = "ReportTypeName";
            this.olvcolDupType.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.olvcolDupReceived.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolDupReceived.IsEditable = false;
            this.olvcolDupReceived.Searchable = false;
            this.olvcolDupReceived.Text = "Received";
            this.olvcolDupReceived.UseFiltering = false;
            this.olvcolDupReceived.Width = 150;
            // 
            // btnCheckDuplicates
            // 
            this.btnCheckDuplicates.BackColor = System.Drawing.Color.Gray;
            this.btnCheckDuplicates.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCheckDuplicates.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckDuplicates.ForeColor = System.Drawing.Color.White;
            this.btnCheckDuplicates.Location = new System.Drawing.Point(958, 391);
            this.btnCheckDuplicates.Name = "btnCheckDuplicates";
            this.btnCheckDuplicates.Size = new System.Drawing.Size(211, 68);
            this.btnCheckDuplicates.TabIndex = 28;
            this.btnCheckDuplicates.Text = "Check for duplicates";
            this.btnCheckDuplicates.UseVisualStyleBackColor = false;
            this.btnCheckDuplicates.Click += new System.EventHandler(this.btnCheckDuplicates_Click);
            // 
            // lblDuplicate
            // 
            this.lblDuplicate.AutoSize = true;
            this.lblDuplicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuplicate.Location = new System.Drawing.Point(16, 420);
            this.lblDuplicate.Name = "lblDuplicate";
            this.lblDuplicate.Size = new System.Drawing.Size(0, 17);
            this.lblDuplicate.TabIndex = 30;
            // 
            // FormPullCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelPull;
            this.ClientSize = new System.Drawing.Size(1188, 480);
            this.Controls.Add(this.lblDuplicate);
            this.Controls.Add(this.tabControlPullCredit);
            this.Controls.Add(this.btnCheckDuplicates);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.btnCancelPull);
            this.Name = "FormPullCredit";
            this.Text = "Pulling credit applicant(s) info";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormPullCredit_LoadCompleted);
            ((System.ComponentModel.ISupportInitialize)(this.olvApplications)).EndInit();
            this.tabControlPullCredit.ResumeLayout(false);
            this.tabPullCredit.ResumeLayout(false);
            this.tabCheckDuplicate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlvDuplicates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private BrightIdeasSoftware.FastObjectListView olvApplications;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private BrightIdeasSoftware.OLVColumn olvcolChecked;
        private BrightIdeasSoftware.OLVColumn olvcolAppName;
        private BrightIdeasSoftware.OLVColumn olvcolDOB;
        private BrightIdeasSoftware.OLVColumn olvcolSSN;
        private BrightIdeasSoftware.OLVColumn olvcolEndUser;
        private BrightIdeasSoftware.OLVColumn olvcolPermissPurpose;
        private BrightIdeasSoftware.OLVColumn olvcolCreditType;
        private System.Windows.Forms.Button btnCancelPull;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.TabControl tabControlPullCredit;
        private System.Windows.Forms.TabPage tabPullCredit;
        private System.Windows.Forms.TabPage tabCheckDuplicate;
        private BrightIdeasSoftware.DataTreeListView tlvDuplicates;
        private BrightIdeasSoftware.OLVColumn olvcolDupName;
        private BrightIdeasSoftware.OLVColumn olvcolDupClient;
        private BrightIdeasSoftware.OLVColumn olvcolDupType;
        private BrightIdeasSoftware.OLVColumn olvcolDupReceived;
        private System.Windows.Forms.Button btnCheckDuplicates;
        private System.Windows.Forms.Label lblDuplicate;
    }
}