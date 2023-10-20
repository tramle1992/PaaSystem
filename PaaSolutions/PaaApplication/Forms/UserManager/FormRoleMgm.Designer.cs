namespace PaaApplication.Forms.UserManager
{
    partial class FormRoleMgm
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
            this.olvColCreated = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNumRow = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColRoleName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvRoles = new BrightIdeasSoftware.ObjectListView();
            this.olvColRemark = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.treelvFeaturePermission = new BrightIdeasSoftware.TreeListView();
            this.treecolName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.olvColModified = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.olvRoles)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treelvFeaturePermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // olvColCreated
            // 
            this.olvColCreated.AspectName = "CreateBy";
            this.olvColCreated.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColCreated.IsEditable = false;
            this.olvColCreated.Text = "Created By";
            this.olvColCreated.Width = 181;
            // 
            // olvColNumRow
            // 
            this.olvColNumRow.AspectName = "";
            this.olvColNumRow.DisplayIndex = 0;
            this.olvColNumRow.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColNumRow.IsEditable = false;
            this.olvColNumRow.Searchable = false;
            this.olvColNumRow.Sortable = false;
            this.olvColNumRow.Text = "#";
            this.olvColNumRow.Width = 36;
            // 
            // olvColRoleName
            // 
            this.olvColRoleName.AspectName = "RoleName";
            this.olvColRoleName.DisplayIndex = 1;
            this.olvColRoleName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColRoleName.IsEditable = false;
            this.olvColRoleName.Text = "Name";
            this.olvColRoleName.Width = 270;
            // 
            // olvRoles
            // 
            this.olvRoles.AllColumns.Add(this.olvColRoleName);
            this.olvRoles.AllColumns.Add(this.olvColNumRow);
            this.olvRoles.AllColumns.Add(this.olvColRemark);
            this.olvRoles.AllColumns.Add(this.olvColCreated);
            this.olvRoles.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvRoles.CellEditEnterChangesRows = true;
            this.olvRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColRoleName,
            this.olvColNumRow,
            this.olvColRemark,
            this.olvColCreated});
            this.olvRoles.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvRoles.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvRoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvRoles.FullRowSelect = true;
            this.olvRoles.GridLines = true;
            this.olvRoles.HeaderWordWrap = true;
            this.olvRoles.HideSelection = false;
            this.olvRoles.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvRoles.HotItemStyle = this.hotItemStyle;
            this.olvRoles.Location = new System.Drawing.Point(12, 47);
            this.olvRoles.Name = "olvRoles";
            this.olvRoles.ShowGroups = false;
            this.olvRoles.Size = new System.Drawing.Size(768, 612);
            this.olvRoles.SortGroupItemsByPrimaryColumn = false;
            this.olvRoles.TabIndex = 8;
            this.olvRoles.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvRoles.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvRoles.UseAlternatingBackColors = true;
            this.olvRoles.UseCompatibleStateImageBehavior = false;
            this.olvRoles.UseCustomSelectionColors = true;
            this.olvRoles.UseFiltering = true;
            this.olvRoles.UseHotItem = true;
            this.olvRoles.View = System.Windows.Forms.View.Details;
            this.olvRoles.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvRoles_FormatRow);
            this.olvRoles.SelectionChanged += new System.EventHandler(this.olvRoles_SelectionChanged);
            // 
            // olvColRemark
            // 
            this.olvColRemark.AspectName = "Remark";
            this.olvColRemark.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColRemark.Text = "Remark";
            this.olvColRemark.Width = 469;
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // groupBox3
            // 
            this.groupBox3.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox3.Location = new System.Drawing.Point(1005, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(545, 3);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRemark.Location = new System.Drawing.Point(17, 131);
            this.txtRemark.MaxLength = 250;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(544, 95);
            this.txtRemark.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Location = new System.Drawing.Point(14, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 15);
            this.label12.TabIndex = 67;
            this.label12.Text = "REMARK:";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Enabled = false;
            this.txtCreatedBy.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreatedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCreatedBy.Location = new System.Drawing.Point(1300, 112);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Size = new System.Drawing.Size(250, 28);
            this.txtCreatedBy.TabIndex = 57;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.errorProvider.SetIconPadding(this.txtRoleName, 5);
            this.txtRoleName.Location = new System.Drawing.Point(1005, 112);
            this.txtRoleName.MaxLength = 50;
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(250, 28);
            this.txtRoleName.TabIndex = 0;
            this.txtRoleName.Validating += new System.ComponentModel.CancelEventHandler(this.txtRoleName_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(1297, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 55;
            this.label6.Text = "CREATED BY:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(1002, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 54;
            this.label5.Text = "ROLE  NAME:";
            // 
            // groupBox2
            // 
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox2.Location = new System.Drawing.Point(1005, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 3);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox4.Controls.Add(this.treelvFeaturePermission);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtRemark);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(989, 40);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(579, 618);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            // 
            // treelvFeaturePermission
            // 
            this.treelvFeaturePermission.AllColumns.Add(this.treecolName);
            this.treelvFeaturePermission.AllowColumnReorder = true;
            this.treelvFeaturePermission.AllowDrop = true;
            this.treelvFeaturePermission.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.treelvFeaturePermission.CheckBoxes = true;
            this.treelvFeaturePermission.CheckedAspectName = "";
            this.treelvFeaturePermission.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.treecolName});
            this.treelvFeaturePermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treelvFeaturePermission.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treelvFeaturePermission.FullRowSelect = true;
            this.treelvFeaturePermission.HideSelection = false;
            this.treelvFeaturePermission.HierarchicalCheckboxes = true;
            this.treelvFeaturePermission.HotItemStyle = this.hotItemStyle;
            this.treelvFeaturePermission.IsSimpleDragSource = true;
            this.treelvFeaturePermission.IsSimpleDropSink = true;
            this.treelvFeaturePermission.Location = new System.Drawing.Point(17, 283);
            this.treelvFeaturePermission.Name = "treelvFeaturePermission";
            this.treelvFeaturePermission.OwnerDraw = true;
            this.treelvFeaturePermission.ShowGroups = false;
            this.treelvFeaturePermission.ShowImagesOnSubItems = true;
            this.treelvFeaturePermission.Size = new System.Drawing.Size(544, 325);
            this.treelvFeaturePermission.TabIndex = 2;
            this.treelvFeaturePermission.UseAlternatingBackColors = true;
            this.treelvFeaturePermission.UseCompatibleStateImageBehavior = false;
            this.treelvFeaturePermission.UseHotItem = true;
            this.treelvFeaturePermission.View = System.Windows.Forms.View.Details;
            this.treelvFeaturePermission.VirtualMode = true;
            // 
            // treecolName
            // 
            this.treecolName.AspectName = "FeatureName";
            this.treecolName.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treecolName.Text = "Feature Name";
            this.treecolName.Width = 400;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(16, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 4);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.groupBox5.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox5.Location = new System.Drawing.Point(16, 265);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(139, 4);
            this.groupBox5.TabIndex = 74;
            this.groupBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(46, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 73;
            this.label2.Text = "USER ROLE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(48, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 73;
            this.label1.Text = "PERMISSIONS";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Image = global::PaaApplication.Properties.Resources.checkmark_mod;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(1009, 281);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 20);
            this.label13.TabIndex = 71;
            this.label13.Text = "    ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Image = global::PaaApplication.Properties.Resources.security_mod;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(1007, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 52;
            this.label4.Text = "    ";
            // 
            // olvColModified
            // 
            this.olvColModified.AspectName = "ModifiedDate";
            this.olvColModified.DisplayIndex = 4;
            this.olvColModified.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColModified.IsEditable = false;
            this.olvColModified.Text = "Modified Date";
            this.olvColModified.Width = 130;
            // 
            // olvColStatus
            // 
            this.olvColStatus.AspectName = "Status";
            this.olvColStatus.DisplayIndex = 2;
            this.olvColStatus.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColStatus.IsEditable = false;
            this.olvColStatus.Text = "Status";
            this.olvColStatus.Width = 97;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(313, 24);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.WatermarkText = "#000000";
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // btnAddRole
            // 
            this.btnAddRole.BackColor = System.Drawing.Color.Gray;
            this.btnAddRole.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRole.ForeColor = System.Drawing.Color.White;
            this.btnAddRole.Location = new System.Drawing.Point(342, 9);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(124, 29);
            this.btnAddRole.TabIndex = 73;
            this.btnAddRole.Text = "Add New Role";
            this.btnAddRole.UseVisualStyleBackColor = false;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.BackColor = System.Drawing.Color.Gray;
            this.btnDeleteRole.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRole.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRole.Location = new System.Drawing.Point(480, 9);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(124, 29);
            this.btnDeleteRole.TabIndex = 73;
            this.btnDeleteRole.Text = "Delete Role";
            this.btnDeleteRole.UseVisualStyleBackColor = false;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormRoleMgm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 672);
            this.Controls.Add(this.btnAddRole);
            this.Controls.Add(this.btnDeleteRole);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCreatedBy);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.olvRoles);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRoleMgm";
            this.Text = "FormRoleMgm";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormRoleMgm_LoadCompleted);
            this.Load += new System.EventHandler(this.FormRoleMgm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olvRoles)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treelvFeaturePermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.OLVColumn olvColCreated;
        private BrightIdeasSoftware.OLVColumn olvColNumRow;
        private BrightIdeasSoftware.OLVColumn olvColRoleName;
        private BrightIdeasSoftware.ObjectListView olvRoles;
        private BrightIdeasSoftware.OLVColumn olvColRemark;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private ExtendControls.WaterMarkTextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCreatedBy;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private BrightIdeasSoftware.TreeListView treelvFeaturePermission;
        private BrightIdeasSoftware.OLVColumn olvColModified;
        private BrightIdeasSoftware.OLVColumn olvColStatus;
        private BrightIdeasSoftware.OLVColumn treecolName;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}