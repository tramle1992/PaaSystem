namespace PaaApplication.UserControls.AppExplore
{
    partial class PullCreditResultControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.olvApplications = new BrightIdeasSoftware.FastObjectListView();
            this.olvcolResult = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolAppName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDOB = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolSSN = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolEndUser = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolPermissPurpose = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolCreditType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.olvApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // olvApplications
            // 
            this.olvApplications.AllColumns.Add(this.olvcolResult);
            this.olvApplications.AllColumns.Add(this.olvcolAppName);
            this.olvApplications.AllColumns.Add(this.olvcolDOB);
            this.olvApplications.AllColumns.Add(this.olvcolSSN);
            this.olvApplications.AllColumns.Add(this.olvcolEndUser);
            this.olvApplications.AllColumns.Add(this.olvcolPermissPurpose);
            this.olvApplications.AllColumns.Add(this.olvcolCreditType);
            this.olvApplications.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvApplications.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvApplications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolResult,
            this.olvcolAppName,
            this.olvcolDOB,
            this.olvcolSSN,
            this.olvcolEndUser,
            this.olvcolPermissPurpose,
            this.olvcolCreditType});
            this.olvApplications.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvApplications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvApplications.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvApplications.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvApplications.FullRowSelect = true;
            this.olvApplications.HideSelection = false;
            this.olvApplications.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvApplications.Location = new System.Drawing.Point(0, 0);
            this.olvApplications.MultiSelect = false;
            this.olvApplications.Name = "olvApplications";
            this.olvApplications.OwnerDraw = true;
            this.olvApplications.ShowGroups = false;
            this.olvApplications.ShowImagesOnSubItems = true;
            this.olvApplications.Size = new System.Drawing.Size(1188, 382);
            this.olvApplications.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.olvApplications.TabIndex = 3;
            this.olvApplications.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvApplications.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvApplications.UseAlternatingBackColors = true;
            this.olvApplications.UseCompatibleStateImageBehavior = false;
            this.olvApplications.UseFiltering = true;
            this.olvApplications.UseHotItem = true;
            this.olvApplications.UseSubItemCheckBoxes = true;
            this.olvApplications.View = System.Windows.Forms.View.Details;
            this.olvApplications.VirtualMode = true;
            // 
            // olvcolResult
            // 
            this.olvcolResult.AspectName = "";
            this.olvcolResult.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.olvcolResult.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolResult.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolResult.IsEditable = false;
            this.olvcolResult.Searchable = false;
            this.olvcolResult.Sortable = false;
            this.olvcolResult.Text = "";
            this.olvcolResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolResult.UseFiltering = false;
            this.olvcolResult.Width = 120;
            // 
            // olvcolAppName
            // 
            this.olvcolAppName.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolAppName.IsEditable = false;
            this.olvcolAppName.Searchable = false;
            this.olvcolAppName.Text = "Applicant Name";
            this.olvcolAppName.UseFiltering = false;
            this.olvcolAppName.Width = 230;
            // 
            // olvcolDOB
            // 
            this.olvcolDOB.AspectToStringFormat = "{0:MM / dd / yyyy}";
            this.olvcolDOB.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolDOB.IsEditable = false;
            this.olvcolDOB.Searchable = false;
            this.olvcolDOB.Text = "DOB";
            this.olvcolDOB.UseFiltering = false;
            this.olvcolDOB.Width = 135;
            // 
            // olvcolSSN
            // 
            this.olvcolSSN.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolSSN.IsEditable = false;
            this.olvcolSSN.Searchable = false;
            this.olvcolSSN.Text = "SSN";
            this.olvcolSSN.UseFiltering = false;
            this.olvcolSSN.Width = 170;
            // 
            // olvcolEndUser
            // 
            this.olvcolEndUser.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolEndUser.IsEditable = false;
            this.olvcolEndUser.Searchable = false;
            this.olvcolEndUser.Text = "End User";
            this.olvcolEndUser.UseFiltering = false;
            this.olvcolEndUser.Width = 170;
            // 
            // olvcolPermissPurpose
            // 
            this.olvcolPermissPurpose.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolPermissPurpose.IsEditable = false;
            this.olvcolPermissPurpose.Searchable = false;
            this.olvcolPermissPurpose.Text = "Permissible Purpose";
            this.olvcolPermissPurpose.UseFiltering = false;
            this.olvcolPermissPurpose.Width = 170;
            // 
            // olvcolCreditType
            // 
            this.olvcolCreditType.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolCreditType.IsEditable = false;
            this.olvcolCreditType.Searchable = false;
            this.olvcolCreditType.Text = "Credit Type";
            this.olvcolCreditType.UseFiltering = false;
            this.olvcolCreditType.Width = 170;
            // 
            // PullCreditResultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.olvApplications);
            this.Name = "PullCreditResultControl";
            this.Size = new System.Drawing.Size(1188, 382);
            ((System.ComponentModel.ISupportInitialize)(this.olvApplications)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView olvApplications;
        private BrightIdeasSoftware.OLVColumn olvcolResult;
        private BrightIdeasSoftware.OLVColumn olvcolAppName;
        private BrightIdeasSoftware.OLVColumn olvcolDOB;
        private BrightIdeasSoftware.OLVColumn olvcolSSN;
        private BrightIdeasSoftware.OLVColumn olvcolEndUser;
        private BrightIdeasSoftware.OLVColumn olvcolPermissPurpose;
        private BrightIdeasSoftware.OLVColumn olvcolCreditType;

    }
}
