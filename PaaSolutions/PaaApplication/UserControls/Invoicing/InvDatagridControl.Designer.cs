namespace PaaApplication.UserControls.Invoicing
{
    partial class InvDatagridControl
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
            this.olvInvoice = new BrightIdeasSoftware.ObjectListView();
            this.olvColClientName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNumRow = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColMonth = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAmount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBalance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvInvDivision = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvComment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPayment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvNum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ctMenuStripInvDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoSizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expoertDatagridCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDatagridInMSWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truncateDatagridAfterThisRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.olvInvoice)).BeginInit();
            this.ctMenuStripInvDataGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // olvInvoice
            // 
            this.olvInvoice.AllColumns.Add(this.olvColClientName);
            this.olvInvoice.AllColumns.Add(this.olvColNumRow);
            this.olvInvoice.AllColumns.Add(this.olvColMonth);
            this.olvInvoice.AllColumns.Add(this.olvColStatus);
            this.olvInvoice.AllColumns.Add(this.olvColAmount);
            this.olvInvoice.AllColumns.Add(this.olvColBalance);
            this.olvInvoice.AllColumns.Add(this.olvInvDivision);
            this.olvInvoice.AllColumns.Add(this.olvColInvComment);
            this.olvInvoice.AllColumns.Add(this.olvColPayment);
            this.olvInvoice.AllColumns.Add(this.olvColInvNum);
            this.olvInvoice.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvInvoice.CellEditEnterChangesRows = true;
            this.olvInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColClientName,
            this.olvColNumRow,
            this.olvColMonth,
            this.olvColStatus,
            this.olvColAmount,
            this.olvColBalance});
            this.olvInvoice.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvInvoice.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvInvoice.FullRowSelect = true;
            this.olvInvoice.GridLines = true;
            this.olvInvoice.HeaderWordWrap = true;
            this.olvInvoice.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvInvoice.Location = new System.Drawing.Point(0, 34);
            this.olvInvoice.Name = "olvInvoice";
            this.olvInvoice.ShowGroups = false;
            this.olvInvoice.Size = new System.Drawing.Size(916, 659);
            this.olvInvoice.SortGroupItemsByPrimaryColumn = false;
            this.olvInvoice.TabIndex = 2;
            this.olvInvoice.UseAlternatingBackColors = true;
            this.olvInvoice.UseCompatibleStateImageBehavior = false;
            this.olvInvoice.UseFiltering = true;
            this.olvInvoice.UseHotItem = true;
            this.olvInvoice.View = System.Windows.Forms.View.Details;
            this.olvInvoice.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvInvoice_FormatRow);
            // 
            // olvColClientName
            // 
            this.olvColClientName.AspectName = "ClientName";
            this.olvColClientName.DisplayIndex = 1;
            this.olvColClientName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColClientName.IsEditable = false;
            this.olvColClientName.Text = "Client Name";
            this.olvColClientName.Width = 200;
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
            // olvColMonth
            // 
            this.olvColMonth.AspectName = "InvoiceDate";
            this.olvColMonth.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColMonth.IsEditable = false;
            this.olvColMonth.Text = "Month";
            this.olvColMonth.Width = 140;
            // 
            // olvColStatus
            // 
            this.olvColStatus.AspectName = "";
            this.olvColStatus.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColStatus.IsEditable = false;
            this.olvColStatus.Text = "Status";
            this.olvColStatus.Width = 140;
            // 
            // olvColAmount
            // 
            this.olvColAmount.AspectName = "Amount";
            this.olvColAmount.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAmount.IsEditable = false;
            this.olvColAmount.Text = "Amount";
            this.olvColAmount.Width = 150;
            // 
            // olvColBalance
            // 
            this.olvColBalance.AspectName = "Balance";
            this.olvColBalance.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.olvColBalance.IsEditable = false;
            this.olvColBalance.Text = "Balance";
            this.olvColBalance.Width = 150;
            // 
            // olvInvDivision
            // 
            this.olvInvDivision.AspectName = "InvoiceDivision";
            this.olvInvDivision.DisplayIndex = 6;
            this.olvInvDivision.IsEditable = false;
            this.olvInvDivision.IsVisible = false;
            this.olvInvDivision.Text = "Invoice Division";
            // 
            // olvColInvComment
            // 
            this.olvColInvComment.AspectName = "InvoiceComment";
            this.olvColInvComment.DisplayIndex = 7;
            this.olvColInvComment.IsEditable = false;
            this.olvColInvComment.IsVisible = false;
            this.olvColInvComment.Text = "Inv. Comments";
            // 
            // olvColPayment
            // 
            this.olvColPayment.DisplayIndex = 8;
            this.olvColPayment.IsEditable = false;
            this.olvColPayment.IsVisible = false;
            this.olvColPayment.Text = "Payment";
            // 
            // olvColInvNum
            // 
            this.olvColInvNum.AspectName = "InvoiceNumber";
            this.olvColInvNum.DisplayIndex = 9;
            this.olvColInvNum.IsEditable = false;
            this.olvColInvNum.IsVisible = false;
            this.olvColInvNum.Text = "Inv. Num";
            // 
            // ctMenuStripInvDataGrid
            // 
            this.ctMenuStripInvDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoSizeColumnsToolStripMenuItem,
            this.expoertDatagridCsvToolStripMenuItem,
            this.typeDatagridInMSWordToolStripMenuItem,
            this.truncateDatagridAfterThisRowToolStripMenuItem});
            this.ctMenuStripInvDataGrid.Name = "ctMenuStripClientDataGrid";
            this.ctMenuStripInvDataGrid.Size = new System.Drawing.Size(263, 92);
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
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(313, 24);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.WatermarkText = "#000000";
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // InvDatagridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.ctMenuStripInvDataGrid;
            this.Controls.Add(this.olvInvoice);
            this.Controls.Add(this.txtSearch);
            this.Name = "InvDatagridControl";
            this.Size = new System.Drawing.Size(919, 696);
            ((System.ComponentModel.ISupportInitialize)(this.olvInvoice)).EndInit();
            this.ctMenuStripInvDataGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendControls.WaterMarkTextBox txtSearch;
        private BrightIdeasSoftware.ObjectListView olvInvoice;
        private BrightIdeasSoftware.OLVColumn olvColClientName;
        private BrightIdeasSoftware.OLVColumn olvColNumRow;
        private BrightIdeasSoftware.OLVColumn olvColMonth;
        private BrightIdeasSoftware.OLVColumn olvColStatus;
        private BrightIdeasSoftware.OLVColumn olvColAmount;
        private BrightIdeasSoftware.OLVColumn olvColBalance;
        private System.Windows.Forms.ContextMenuStrip ctMenuStripInvDataGrid;
        private System.Windows.Forms.ToolStripMenuItem autoSizeColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expoertDatagridCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeDatagridInMSWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truncateDatagridAfterThisRowToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvInvDivision;
        private BrightIdeasSoftware.OLVColumn olvColInvComment;
        private BrightIdeasSoftware.OLVColumn olvColPayment;
        private BrightIdeasSoftware.OLVColumn olvColInvNum;
    }
}
