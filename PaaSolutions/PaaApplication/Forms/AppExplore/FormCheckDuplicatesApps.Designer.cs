namespace PaaApplication.Forms.AppExplore
{
    partial class FormCheckDuplicatesApps
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
            this.btnCheckDuplicates = new System.Windows.Forms.Button();
            this.tlvDuplicates = new BrightIdeasSoftware.DataTreeListView();
            this.olvcolDupName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupClient = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDupReceived = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lblDuplicate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tlvDuplicates)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheckDuplicates
            // 
            this.btnCheckDuplicates.BackColor = System.Drawing.Color.Gray;
            this.btnCheckDuplicates.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCheckDuplicates.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckDuplicates.ForeColor = System.Drawing.Color.White;
            this.btnCheckDuplicates.Location = new System.Drawing.Point(976, 348);
            this.btnCheckDuplicates.Name = "btnCheckDuplicates";
            this.btnCheckDuplicates.Size = new System.Drawing.Size(211, 68);
            this.btnCheckDuplicates.TabIndex = 29;
            this.btnCheckDuplicates.Text = "Check for duplicates";
            this.btnCheckDuplicates.UseVisualStyleBackColor = false;
            this.btnCheckDuplicates.Click += new System.EventHandler(this.btnCheckDuplicates_Click);
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
            this.tlvDuplicates.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvDuplicates.FullRowSelect = true;
            this.tlvDuplicates.HideSelection = false;
            this.tlvDuplicates.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.tlvDuplicates.KeyAspectName = "Id";
            this.tlvDuplicates.Location = new System.Drawing.Point(12, 12);
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
            this.tlvDuplicates.Size = new System.Drawing.Size(1175, 328);
            this.tlvDuplicates.TabIndex = 30;
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
            this.olvcolDupName.AspectName = "FullName";
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
            // lblDuplicate
            // 
            this.lblDuplicate.AutoSize = true;
            this.lblDuplicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuplicate.Location = new System.Drawing.Point(12, 375);
            this.lblDuplicate.Name = "lblDuplicate";
            this.lblDuplicate.Size = new System.Drawing.Size(0, 17);
            this.lblDuplicate.TabIndex = 31;
            // 
            // FormCheckDuplicatesApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 428);
            this.Controls.Add(this.lblDuplicate);
            this.Controls.Add(this.tlvDuplicates);
            this.Controls.Add(this.btnCheckDuplicates);
            this.Name = "FormCheckDuplicatesApps";
            this.Text = "Check for duplicates";
            ((System.ComponentModel.ISupportInitialize)(this.tlvDuplicates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckDuplicates;
        private BrightIdeasSoftware.DataTreeListView tlvDuplicates;
        private BrightIdeasSoftware.OLVColumn olvcolDupName;
        private BrightIdeasSoftware.OLVColumn olvcolDupClient;
        private BrightIdeasSoftware.OLVColumn olvcolDupType;
        private BrightIdeasSoftware.OLVColumn olvcolDupReceived;
        private System.Windows.Forms.Label lblDuplicate;
    }
}