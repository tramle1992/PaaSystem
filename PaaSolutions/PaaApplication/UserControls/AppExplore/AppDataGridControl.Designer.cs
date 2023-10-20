namespace PaaApplication.UserControls.AppExplore
{
    partial class AppDataGridControl
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
            this.components = new System.ComponentModel.Container();
            this.olvApps = new BrightIdeasSoftware.ObjectListView();
            this.olvColName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNumRow = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColClient = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColReceiveDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCompleteDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColScreener = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCommunity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColUnitNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColRecommendation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvoiceDivision = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPastDueDebt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAreas = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColTurnaroundTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColLocation = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ctMenuStripAppDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoSizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expoertDatagridCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDatagridInMSWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truncateDatagridAfterThisRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.olvApps)).BeginInit();
            this.ctMenuStripAppDataGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // olvApps
            // 
            this.olvApps.AllColumns.Add(this.olvColName);
            this.olvApps.AllColumns.Add(this.olvColNumRow);
            this.olvApps.AllColumns.Add(this.olvColClient);
            this.olvApps.AllColumns.Add(this.olvType);
            this.olvApps.AllColumns.Add(this.olvColReceiveDate);
            this.olvApps.AllColumns.Add(this.olvColCompleteDate);
            this.olvApps.AllColumns.Add(this.olvColScreener);
            this.olvApps.AllColumns.Add(this.olvColCommunity);
            this.olvApps.AllColumns.Add(this.olvColUnitNumber);
            this.olvApps.AllColumns.Add(this.olvColRecommendation);
            this.olvApps.AllColumns.Add(this.olvColInvoiceDivision);
            this.olvApps.AllColumns.Add(this.olvColPastDueDebt);
            this.olvApps.AllColumns.Add(this.olvColAreas);
            this.olvApps.AllColumns.Add(this.olvColTurnaroundTime);
            this.olvApps.AllColumns.Add(this.olvColLocation);
            this.olvApps.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvApps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvApps.CellEditEnterChangesRows = true;
            this.olvApps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColName,
            this.olvColNumRow,
            this.olvColClient,
            this.olvType,
            this.olvColReceiveDate,
            this.olvColCompleteDate});
            this.olvApps.ContextMenuStrip = this.ctMenuStripAppDataGrid;
            this.olvApps.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvApps.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvApps.FullRowSelect = true;
            this.olvApps.GridLines = true;
            this.olvApps.HeaderWordWrap = true;
            this.olvApps.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvApps.HotItemStyle = this.hotItemStyle;
            this.olvApps.Location = new System.Drawing.Point(0, 34);
            this.olvApps.Name = "olvApps";
            this.olvApps.ShowGroups = false;
            this.olvApps.Size = new System.Drawing.Size(949, 659);
            this.olvApps.SortGroupItemsByPrimaryColumn = false;
            this.olvApps.TabIndex = 1;
            this.olvApps.UseAlternatingBackColors = true;
            this.olvApps.UseCompatibleStateImageBehavior = false;
            this.olvApps.UseFiltering = true;
            this.olvApps.UseHotItem = true;
            this.olvApps.View = System.Windows.Forms.View.Details;
            this.olvApps.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvApps_FormatRow);
            // 
            // olvColName
            // 
            this.olvColName.AspectName = "";
            this.olvColName.DisplayIndex = 1;
            this.olvColName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColName.IsEditable = false;
            this.olvColName.Text = "Name";
            this.olvColName.Width = 140;
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
            // 
            // olvColClient
            // 
            this.olvColClient.AspectName = "";
            this.olvColClient.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColClient.IsEditable = false;
            this.olvColClient.Text = "Client";
            this.olvColClient.Width = 140;
            // 
            // olvType
            // 
            this.olvType.AspectName = "ReportTypeName";
            this.olvType.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvType.IsEditable = false;
            this.olvType.Text = "Type";
            this.olvType.Width = 90;
            // 
            // olvColReceiveDate
            // 
            this.olvColReceiveDate.AspectName = "ReceivedDate";
            this.olvColReceiveDate.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColReceiveDate.IsEditable = false;
            this.olvColReceiveDate.Text = "Receive Date";
            this.olvColReceiveDate.Width = 120;
            // 
            // olvColCompleteDate
            // 
            this.olvColCompleteDate.AspectName = "CompletedDate";
            this.olvColCompleteDate.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColCompleteDate.IsEditable = false;
            this.olvColCompleteDate.Text = "Complete Date";
            this.olvColCompleteDate.Width = 120;
            // 
            // olvColScreener
            // 
            this.olvColScreener.AspectName = "ScreenerName";
            this.olvColScreener.DisplayIndex = 6;
            this.olvColScreener.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColScreener.IsEditable = false;
            this.olvColScreener.IsVisible = false;
            this.olvColScreener.Text = "Screener";
            // 
            // olvColCommunity
            // 
            this.olvColCommunity.AspectName = "ReportCommunity";
            this.olvColCommunity.DisplayIndex = 7;
            this.olvColCommunity.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColCommunity.IsEditable = false;
            this.olvColCommunity.IsVisible = false;
            this.olvColCommunity.Text = "Community";
            this.olvColCommunity.Width = 120;
            // 
            // olvColUnitNumber
            // 
            this.olvColUnitNumber.AspectName = "UnitNumber";
            this.olvColUnitNumber.DisplayIndex = 8;
            this.olvColUnitNumber.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColUnitNumber.IsEditable = false;
            this.olvColUnitNumber.IsVisible = false;
            this.olvColUnitNumber.Text = "Unit Number";
            this.olvColUnitNumber.Width = 120;
            // 
            // olvColRecommendation
            // 
            this.olvColRecommendation.DisplayIndex = 9;
            this.olvColRecommendation.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColRecommendation.IsEditable = false;
            this.olvColRecommendation.IsVisible = false;
            this.olvColRecommendation.Text = "Recommendation";
            this.olvColRecommendation.Width = 120;
            // 
            // olvColInvoiceDivision
            // 
            this.olvColInvoiceDivision.AspectName = "InvoiceDivision";
            this.olvColInvoiceDivision.DisplayIndex = 10;
            this.olvColInvoiceDivision.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColInvoiceDivision.IsEditable = false;
            this.olvColInvoiceDivision.IsVisible = false;
            this.olvColInvoiceDivision.Text = "Invoice Division";
            this.olvColInvoiceDivision.Width = 120;
            // 
            // olvColPastDueDebt
            // 
            this.olvColPastDueDebt.DisplayIndex = 11;
            this.olvColPastDueDebt.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColPastDueDebt.IsEditable = false;
            this.olvColPastDueDebt.IsVisible = false;
            this.olvColPastDueDebt.Text = "Past Due Debt";
            this.olvColPastDueDebt.Width = 100;
            // 
            // olvColAreas
            // 
            this.olvColAreas.DisplayIndex = 12;
            this.olvColAreas.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColAreas.IsEditable = false;
            this.olvColAreas.IsVisible = false;
            this.olvColAreas.Text = "Areas of Sub-Qualification";
            this.olvColAreas.Width = 120;
            // 
            // olvColTurnaroundTime
            // 
            this.olvColTurnaroundTime.DisplayIndex = 13;
            this.olvColTurnaroundTime.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColTurnaroundTime.IsEditable = false;
            this.olvColTurnaroundTime.IsVisible = false;
            this.olvColTurnaroundTime.Text = "Turnaround Time";
            this.olvColTurnaroundTime.Width = 100;
            // 
            // olvColLocation
            // 
            this.olvColLocation.AspectName = "LocationName";
            this.olvColLocation.DisplayIndex = 14;
            this.olvColLocation.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColLocation.IsEditable = false;
            this.olvColLocation.IsVisible = false;
            this.olvColLocation.Text = "Location";
            this.olvColLocation.Width = 80;
            // 
            // ctMenuStripAppDataGrid
            // 
            this.ctMenuStripAppDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoSizeColumnsToolStripMenuItem,
            this.expoertDatagridCsvToolStripMenuItem,
            this.typeDatagridInMSWordToolStripMenuItem,
            this.truncateDatagridAfterThisRowToolStripMenuItem});
            this.ctMenuStripAppDataGrid.Name = "ctMenuStripClientDataGrid";
            this.ctMenuStripAppDataGrid.Size = new System.Drawing.Size(263, 92);
            // 
            // autoSizeColumnsToolStripMenuItem
            // 
            this.autoSizeColumnsToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoSizeColumnsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.autoSizeColumnsToolStripMenuItem.Name = "autoSizeColumnsToolStripMenuItem";
            this.autoSizeColumnsToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.autoSizeColumnsToolStripMenuItem.Text = "Auto-Size Columns";
            this.autoSizeColumnsToolStripMenuItem.Click += new System.EventHandler(this.autoSizeColumnsToolStripMenuItem_Click);
            // 
            // expoertDatagridCsvToolStripMenuItem
            // 
            this.expoertDatagridCsvToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expoertDatagridCsvToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.expoertDatagridCsvToolStripMenuItem.Name = "expoertDatagridCsvToolStripMenuItem";
            this.expoertDatagridCsvToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.expoertDatagridCsvToolStripMenuItem.Text = "Export Datagrid Csv";
            this.expoertDatagridCsvToolStripMenuItem.Click += new System.EventHandler(this.expoertDatagridCsvToolStripMenuItem_Click);
            // 
            // typeDatagridInMSWordToolStripMenuItem
            // 
            this.typeDatagridInMSWordToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeDatagridInMSWordToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.typeDatagridInMSWordToolStripMenuItem.Name = "typeDatagridInMSWordToolStripMenuItem";
            this.typeDatagridInMSWordToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.typeDatagridInMSWordToolStripMenuItem.Text = "Type Datagrid in MS Word";
            this.typeDatagridInMSWordToolStripMenuItem.Click += new System.EventHandler(this.typeDatagridInMSWordToolStripMenuItem_Click);
            // 
            // truncateDatagridAfterThisRowToolStripMenuItem
            // 
            this.truncateDatagridAfterThisRowToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truncateDatagridAfterThisRowToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.truncateDatagridAfterThisRowToolStripMenuItem.Name = "truncateDatagridAfterThisRowToolStripMenuItem";
            this.truncateDatagridAfterThisRowToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.truncateDatagridAfterThisRowToolStripMenuItem.Text = "Truncate Datagrid after this Row";
            this.truncateDatagridAfterThisRowToolStripMenuItem.Click += new System.EventHandler(this.truncateDatagridAfterThisRowToolStripMenuItem_Click);
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(313, 24);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.WatermarkText = "#000000";
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // AppDataGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.olvApps);
            this.Name = "AppDataGridControl";
            this.Size = new System.Drawing.Size(949, 696);
            ((System.ComponentModel.ISupportInitialize)(this.olvApps)).EndInit();
            this.ctMenuStripAppDataGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendControls.WaterMarkTextBox txtSearch;
        private BrightIdeasSoftware.ObjectListView olvApps;
        private BrightIdeasSoftware.OLVColumn olvColNumRow;
        private BrightIdeasSoftware.OLVColumn olvColName;
        private BrightIdeasSoftware.OLVColumn olvColClient;
        private BrightIdeasSoftware.OLVColumn olvType;
        private BrightIdeasSoftware.OLVColumn olvColReceiveDate;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private System.Windows.Forms.ContextMenuStrip ctMenuStripAppDataGrid;
        private System.Windows.Forms.ToolStripMenuItem autoSizeColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expoertDatagridCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeDatagridInMSWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truncateDatagridAfterThisRowToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColCompleteDate;
        private BrightIdeasSoftware.OLVColumn olvColScreener;
        private BrightIdeasSoftware.OLVColumn olvColCommunity;
        private BrightIdeasSoftware.OLVColumn olvColUnitNumber;
        private BrightIdeasSoftware.OLVColumn olvColRecommendation;
        private BrightIdeasSoftware.OLVColumn olvColInvoiceDivision;
        private BrightIdeasSoftware.OLVColumn olvColPastDueDebt;
        private BrightIdeasSoftware.OLVColumn olvColAreas;
        private BrightIdeasSoftware.OLVColumn olvColTurnaroundTime;
        private BrightIdeasSoftware.OLVColumn olvColLocation;
    }
}
