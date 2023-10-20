using BrightIdeasSoftware;
namespace PaaApplication.UserControls.AppExplore
{
    partial class CreditReportControl
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
            BrightIdeasSoftware.CellStyle cellStyle1 = new BrightIdeasSoftware.CellStyle();
            BrightIdeasSoftware.CellStyle cellStyle2 = new BrightIdeasSoftware.CellStyle();
            BrightIdeasSoftware.CellStyle cellStyle3 = new BrightIdeasSoftware.CellStyle();
            this.hyperlinkStyle = new BrightIdeasSoftware.HyperlinkStyle();
            this.olvReports = new BrightIdeasSoftware.FastObjectListView();
            this.olvcolPulledDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolPulledBy = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolApplicantName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolEndUser = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolCreditType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolReportId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.olvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // hyperlinkStyle
            // 
            cellStyle1.Font = null;
            cellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.hyperlinkStyle.Normal = cellStyle1;
            cellStyle2.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cellStyle2.FontStyle = System.Drawing.FontStyle.Underline;
            this.hyperlinkStyle.Over = cellStyle2;
            this.hyperlinkStyle.OverCursor = System.Windows.Forms.Cursors.Hand;
            cellStyle3.Font = null;
            cellStyle3.ForeColor = System.Drawing.Color.Purple;
            this.hyperlinkStyle.Visited = cellStyle3;
            // 
            // olvReports
            // 
            this.olvReports.AllColumns.Add(this.olvcolPulledDate);
            this.olvReports.AllColumns.Add(this.olvcolPulledBy);
            this.olvReports.AllColumns.Add(this.olvcolApplicantName);
            this.olvReports.AllColumns.Add(this.olvcolEndUser);
            this.olvReports.AllColumns.Add(this.olvcolCreditType);
            this.olvReports.AllColumns.Add(this.olvcolReportId);
            this.olvReports.AllColumns.Add(this.olvcolStatus);
            this.olvReports.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvReports.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolPulledDate,
            this.olvcolPulledBy,
            this.olvcolApplicantName,
            this.olvcolEndUser,
            this.olvcolCreditType,
            this.olvcolReportId,
            this.olvcolStatus});
            this.olvReports.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvReports.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvReports.FullRowSelect = true;
            this.olvReports.HideSelection = false;
            this.olvReports.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvReports.HyperlinkStyle = this.hyperlinkStyle;
            this.olvReports.Location = new System.Drawing.Point(0, 0);
            this.olvReports.MultiSelect = false;
            this.olvReports.Name = "olvReports";
            this.olvReports.OwnerDraw = true;
            this.olvReports.ShowGroups = false;
            this.olvReports.ShowImagesOnSubItems = true;
            this.olvReports.Size = new System.Drawing.Size(1418, 382);
            this.olvReports.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.olvReports.TabIndex = 3;
            this.olvReports.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvReports.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvReports.UseAlternatingBackColors = true;
            this.olvReports.UseCompatibleStateImageBehavior = false;
            this.olvReports.UseFiltering = true;
            this.olvReports.UseHotItem = true;
            this.olvReports.UseHyperlinks = true;
            this.olvReports.UseSubItemCheckBoxes = true;
            this.olvReports.View = System.Windows.Forms.View.Details;
            this.olvReports.VirtualMode = true;
            this.olvReports.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvReports_CellClick);
            this.olvReports.IsHyperlink += new System.EventHandler<BrightIdeasSoftware.IsHyperlinkEventArgs>(this.olvReports_IsHyperlink);
            // 
            // olvcolPulledDate
            // 
            this.olvcolPulledDate.AspectName = "";
            this.olvcolPulledDate.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.olvcolPulledDate.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolPulledDate.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolPulledDate.IsEditable = false;
            this.olvcolPulledDate.Searchable = false;
            this.olvcolPulledDate.Text = "Pulled Date";
            this.olvcolPulledDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolPulledDate.Width = 140;
            // 
            // olvcolPulledBy
            // 
            this.olvcolPulledBy.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolPulledBy.IsEditable = false;
            this.olvcolPulledBy.Searchable = false;
            this.olvcolPulledBy.Text = "Pulled By";
            this.olvcolPulledBy.Width = 127;
            // 
            // olvcolApplicantName
            // 
            this.olvcolApplicantName.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolApplicantName.IsEditable = false;
            this.olvcolApplicantName.Searchable = false;
            this.olvcolApplicantName.Text = "Applicant Name";
            this.olvcolApplicantName.Width = 175;
            // 
            // olvcolEndUser
            // 
            this.olvcolEndUser.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolEndUser.IsEditable = false;
            this.olvcolEndUser.Searchable = false;
            this.olvcolEndUser.Text = "End User";
            this.olvcolEndUser.Width = 126;
            // 
            // olvcolCreditType
            // 
            this.olvcolCreditType.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolCreditType.IsEditable = false;
            this.olvcolCreditType.Searchable = false;
            this.olvcolCreditType.Text = "Credit Type";
            this.olvcolCreditType.Width = 119;
            // 
            // olvcolReportId
            // 
            this.olvcolReportId.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolReportId.Hyperlink = true;
            this.olvcolReportId.IsEditable = false;
            this.olvcolReportId.Searchable = false;
            this.olvcolReportId.Text = "Report ID";
            this.olvcolReportId.UseFiltering = false;
            this.olvcolReportId.Width = 372;
            // 
            // olvcolStatus
            // 
            this.olvcolStatus.Text = "Status";
            this.olvcolStatus.Width = 99;
            // 
            // CreditReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.olvReports);
            this.Name = "CreditReportControl";
            this.Size = new System.Drawing.Size(1418, 382);
            ((System.ComponentModel.ISupportInitialize)(this.olvReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView olvReports;
        private BrightIdeasSoftware.OLVColumn olvcolPulledDate;
        private BrightIdeasSoftware.OLVColumn olvcolPulledBy;
        private BrightIdeasSoftware.OLVColumn olvcolApplicantName;
        private BrightIdeasSoftware.OLVColumn olvcolEndUser;
        private BrightIdeasSoftware.OLVColumn olvcolReportId;
        private BrightIdeasSoftware.OLVColumn olvcolCreditType;
        private HyperlinkStyle hyperlinkStyle;
        private OLVColumn olvcolStatus;

    }
}
