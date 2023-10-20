namespace PaaApplication.Forms.UserManager
{
    partial class FormUserManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserManager));
            this.olvUsers = new BrightIdeasSoftware.ObjectListView();
            this.olvColLogin = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNumRow = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColRole = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColHire = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColTerm = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColEmail = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            this.ucUserProfile = new PaaApplication.UserControls.UserManager.UserProfileControl();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.olvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // olvUsers
            // 
            this.olvUsers.AllColumns.Add(this.olvColLogin);
            this.olvUsers.AllColumns.Add(this.olvColNumRow);
            this.olvUsers.AllColumns.Add(this.olvColRole);
            this.olvUsers.AllColumns.Add(this.olvColStatus);
            this.olvUsers.AllColumns.Add(this.olvColHire);
            this.olvUsers.AllColumns.Add(this.olvColTerm);
            this.olvUsers.AllColumns.Add(this.olvColEmail);
            this.olvUsers.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvUsers.CellEditEnterChangesRows = true;
            this.olvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColLogin,
            this.olvColNumRow,
            this.olvColRole,
            this.olvColStatus,
            this.olvColHire,
            this.olvColTerm,
            this.olvColEmail});
            this.olvUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvUsers.FullRowSelect = true;
            this.olvUsers.GridLines = true;
            this.olvUsers.HeaderWordWrap = true;
            this.olvUsers.HideSelection = false;
            this.olvUsers.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvUsers.HotItemStyle = this.hotItemStyle;
            this.olvUsers.Location = new System.Drawing.Point(23, 48);
            this.olvUsers.MultiSelect = false;
            this.olvUsers.Name = "olvUsers";
            this.olvUsers.ShowGroups = false;
            this.olvUsers.Size = new System.Drawing.Size(768, 612);
            this.olvUsers.SortGroupItemsByPrimaryColumn = false;
            this.olvUsers.TabIndex = 8;
            this.olvUsers.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvUsers.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvUsers.UseAlternatingBackColors = true;
            this.olvUsers.UseCompatibleStateImageBehavior = false;
            this.olvUsers.UseCustomSelectionColors = true;
            this.olvUsers.UseFiltering = true;
            this.olvUsers.UseHotItem = true;
            this.olvUsers.View = System.Windows.Forms.View.Details;
            this.olvUsers.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvUsers_FormatRow);
            this.olvUsers.SelectionChanged += new System.EventHandler(this.olvUsers_SelectionChanged);
            // 
            // olvColLogin
            // 
            this.olvColLogin.AspectName = "UserName";
            this.olvColLogin.DisplayIndex = 1;
            this.olvColLogin.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColLogin.IsEditable = false;
            this.olvColLogin.Text = "Login";
            this.olvColLogin.Width = 164;
            // 
            // olvColNumRow
            // 
            this.olvColNumRow.AspectName = "";
            this.olvColNumRow.DisplayIndex = 0;
            this.olvColNumRow.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColNumRow.IsEditable = false;
            this.olvColNumRow.Searchable = false;
            this.olvColNumRow.Sortable = false;
            this.olvColNumRow.Text = "#";
            this.olvColNumRow.Width = 36;
            // 
            // olvColRole
            // 
            this.olvColRole.AspectName = "RoleId";
            this.olvColRole.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColRole.IsEditable = false;
            this.olvColRole.Text = "Role";
            this.olvColRole.Width = 173;
            // 
            // olvColStatus
            // 
            this.olvColStatus.AspectName = "Status";
            this.olvColStatus.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColStatus.IsEditable = false;
            this.olvColStatus.Text = "Status";
            this.olvColStatus.Width = 100;
            // 
            // olvColHire
            // 
            this.olvColHire.AspectName = "HiredDate";
            this.olvColHire.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColHire.IsEditable = false;
            this.olvColHire.Text = "Hire Date";
            this.olvColHire.Width = 125;
            // 
            // olvColTerm
            // 
            this.olvColTerm.AspectName = "TerminationDate";
            this.olvColTerm.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColTerm.IsEditable = false;
            this.olvColTerm.Text = "Term Date";
            this.olvColTerm.Width = 130;
            // 
            // olvColEmail
            // 
            this.olvColEmail.AspectName = "EmailAddress";
            this.olvColEmail.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColEmail.Text = "Email";
            this.olvColEmail.Width = 228;
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.Location = new System.Drawing.Point(23, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(313, 21);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.WatermarkText = "#000000";
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // ucUserProfile
            // 
            this.ucUserProfile.Address = "";
            this.ucUserProfile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ucUserProfile.EditingUserName = null;
            this.ucUserProfile.Email = "";
            this.ucUserProfile.HiredDate = new System.DateTime(2015, 8, 29, 18, 2, 3, 683);
            this.ucUserProfile.Location = new System.Drawing.Point(991, 37);
            this.ucUserProfile.Name = "ucUserProfile";
            this.ucUserProfile.Other = "";
            this.ucUserProfile.Password = "";
            this.ucUserProfile.Size = new System.Drawing.Size(585, 623);
            this.ucUserProfile.Status = 0;
            this.ucUserProfile.TabIndex = 1;
            this.ucUserProfile.TermDate = new System.DateTime(2015, 8, 29, 18, 2, 3, 679);
            this.ucUserProfile.UserId = null;
            this.ucUserProfile.UserName = "";
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.BackColor = System.Drawing.Color.Gray;
            this.btnAddNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewUser.ForeColor = System.Drawing.Color.White;
            this.btnAddNewUser.Location = new System.Drawing.Point(356, 9);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(124, 29);
            this.btnAddNewUser.TabIndex = 10;
            this.btnAddNewUser.Text = "Add New User";
            this.btnAddNewUser.UseVisualStyleBackColor = false;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.Gray;
            this.btnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(500, 9);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(124, 29);
            this.btnDeleteUser.TabIndex = 10;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // FormUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 672);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.olvUsers);
            this.Controls.Add(this.ucUserProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUserManager";
            this.Text = "FormUserManager";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormUserManager_LoadCompleted);
            this.VisibleChanged += new System.EventHandler(this.FormUserManager_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.olvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.UserManager.UserProfileControl ucUserProfile;
        private ExtendControls.WaterMarkTextBox txtSearch;
        private BrightIdeasSoftware.ObjectListView olvUsers;
        private BrightIdeasSoftware.OLVColumn olvColNumRow;
        private BrightIdeasSoftware.OLVColumn olvColLogin;
        private BrightIdeasSoftware.OLVColumn olvColRole;
        private BrightIdeasSoftware.OLVColumn olvColStatus;
        private BrightIdeasSoftware.OLVColumn olvColHire;
        private BrightIdeasSoftware.OLVColumn olvColTerm;
        private BrightIdeasSoftware.OLVColumn olvColEmail;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Button btnDeleteUser;
    }
}