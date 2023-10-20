using PaaApplication.ExtendControls;
namespace PaaApplication.UserControls.ClientInfo
{
    partial class ClientDataGridControl
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
            this.olvColBillingAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColMiscComments = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAdditionalBillingInfo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColContacts = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColLastScreening = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColScreeningLast12Months = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ctMenuStripClientDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoSizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expoertDatagridCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDatagridInMSWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truncateDatagridAfterThisRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.olvClients = new BrightIdeasSoftware.ObjectListView();
            this.olvColClientName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNumRow = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColManagement = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPhone = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColFax = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColEmail = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            this.ctMenuStripClientDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // olvColBillingAddress
            // 
            this.olvColBillingAddress.DisplayIndex = 5;
            this.olvColBillingAddress.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColBillingAddress.IsEditable = false;
            this.olvColBillingAddress.IsVisible = false;
            this.olvColBillingAddress.Text = "Billing Address";
            // 
            // olvColMiscComments
            // 
            this.olvColMiscComments.DisplayIndex = 6;
            this.olvColMiscComments.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColMiscComments.IsEditable = false;
            this.olvColMiscComments.IsVisible = false;
            this.olvColMiscComments.Text = "Misc. Comments";
            // 
            // olvColAdditionalBillingInfo
            // 
            this.olvColAdditionalBillingInfo.DisplayIndex = 7;
            this.olvColAdditionalBillingInfo.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAdditionalBillingInfo.IsEditable = false;
            this.olvColAdditionalBillingInfo.IsVisible = false;
            this.olvColAdditionalBillingInfo.Text = "Additional Billing Info";
            // 
            // olvColContacts
            // 
            this.olvColContacts.DisplayIndex = 8;
            this.olvColContacts.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColContacts.IsEditable = false;
            this.olvColContacts.IsVisible = false;
            this.olvColContacts.Text = "Contacts";
            // 
            // olvColLastScreening
            // 
            this.olvColLastScreening.DisplayIndex = 9;
            this.olvColLastScreening.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColLastScreening.IsEditable = false;
            this.olvColLastScreening.IsVisible = false;
            this.olvColLastScreening.Text = "Last Screening";
            // 
            // olvColScreeningLast12Months
            // 
            this.olvColScreeningLast12Months.DisplayIndex = 10;
            this.olvColScreeningLast12Months.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColScreeningLast12Months.IsEditable = false;
            this.olvColScreeningLast12Months.IsVisible = false;
            this.olvColScreeningLast12Months.Text = "Screening Last 12 Months";
            // 
            // ctMenuStripClientDataGrid
            // 
            this.ctMenuStripClientDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoSizeColumnsToolStripMenuItem,
            this.expoertDatagridCsvToolStripMenuItem,
            this.typeDatagridInMSWordToolStripMenuItem,
            this.truncateDatagridAfterThisRowToolStripMenuItem});
            this.ctMenuStripClientDataGrid.Name = "ctMenuStripClientDataGrid";
            this.ctMenuStripClientDataGrid.Size = new System.Drawing.Size(263, 92);
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
            this.expoertDatagridCsvToolStripMenuItem.Click += new System.EventHandler(this.exportDatagridCsvToolStripMenuItem_Click);
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
            // olvClients
            // 
            this.olvClients.AllColumns.Add(this.olvColClientName);
            this.olvClients.AllColumns.Add(this.olvColNumRow);
            this.olvClients.AllColumns.Add(this.olvColManagement);
            this.olvClients.AllColumns.Add(this.olvColPhone);
            this.olvClients.AllColumns.Add(this.olvColFax);
            this.olvClients.AllColumns.Add(this.olvColEmail);
            this.olvClients.AllColumns.Add(this.olvColBillingAddress);
            this.olvClients.AllColumns.Add(this.olvColMiscComments);
            this.olvClients.AllColumns.Add(this.olvColAdditionalBillingInfo);
            this.olvClients.AllColumns.Add(this.olvColContacts);
            this.olvClients.AllColumns.Add(this.olvColLastScreening);
            this.olvClients.AllColumns.Add(this.olvColScreeningLast12Months);
            this.olvClients.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvClients.CellEditEnterChangesRows = true;
            this.olvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColClientName,
            this.olvColNumRow,
            this.olvColManagement,
            this.olvColPhone,
            this.olvColFax,
            this.olvColEmail});
            this.olvClients.ContextMenuStrip = this.ctMenuStripClientDataGrid;
            this.olvClients.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvClients.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvClients.FullRowSelect = true;
            this.olvClients.GridLines = true;
            this.olvClients.HeaderWordWrap = true;
            this.olvClients.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvClients.HotItemStyle = this.hotItemStyle;
            this.olvClients.Location = new System.Drawing.Point(0, 34);
            this.olvClients.Name = "olvClients";
            this.olvClients.ShowGroups = false;
            this.olvClients.Size = new System.Drawing.Size(949, 659);
            this.olvClients.SortGroupItemsByPrimaryColumn = false;
            this.olvClients.TabIndex = 0;
            this.olvClients.UseAlternatingBackColors = true;
            this.olvClients.UseCompatibleStateImageBehavior = false;
            this.olvClients.UseFiltering = true;
            this.olvClients.UseHotItem = true;
            this.olvClients.View = System.Windows.Forms.View.Details;
            this.olvClients.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvClients_FormatRow);
            // 
            // olvColClientName
            // 
            this.olvColClientName.AspectName = "ClientName";
            this.olvColClientName.DisplayIndex = 1;
            this.olvColClientName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColClientName.IsEditable = false;
            this.olvColClientName.Text = "Client Name";
            this.olvColClientName.Width = 129;
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
            // olvColManagement
            // 
            this.olvColManagement.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColManagement.IsEditable = false;
            this.olvColManagement.Text = "Management";
            this.olvColManagement.Width = 100;
            // 
            // olvColPhone
            // 
            this.olvColPhone.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColPhone.IsEditable = false;
            this.olvColPhone.Text = "Phone";
            this.olvColPhone.Width = 100;
            // 
            // olvColFax
            // 
            this.olvColFax.AspectName = "Fax";
            this.olvColFax.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColFax.IsEditable = false;
            this.olvColFax.Text = "Fax";
            this.olvColFax.Width = 100;
            // 
            // olvColEmail
            // 
            this.olvColEmail.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColEmail.IsEditable = false;
            this.olvColEmail.Text = "Email";
            this.olvColEmail.Width = 180;
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
            this.txtSearch.TabIndex = 5;
            this.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.WatermarkText = "#000000";
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // ClientDataGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.olvClients);
            this.Name = "ClientDataGridControl";
            this.Size = new System.Drawing.Size(949, 696);
            this.ctMenuStripClientDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private WaterMarkTextBox txtSearch;
        private BrightIdeasSoftware.OLVColumn olvColBillingAddress;
        private BrightIdeasSoftware.OLVColumn olvColMiscComments;
        private BrightIdeasSoftware.OLVColumn olvColAdditionalBillingInfo;
        private BrightIdeasSoftware.OLVColumn olvColContacts;
        private BrightIdeasSoftware.OLVColumn olvColLastScreening;
        private BrightIdeasSoftware.OLVColumn olvColScreeningLast12Months;
        private System.Windows.Forms.ContextMenuStrip ctMenuStripClientDataGrid;
        private System.Windows.Forms.ToolStripMenuItem autoSizeColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expoertDatagridCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeDatagridInMSWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truncateDatagridAfterThisRowToolStripMenuItem;
        private BrightIdeasSoftware.ObjectListView olvClients;
        private BrightIdeasSoftware.OLVColumn olvColClientName;
        private BrightIdeasSoftware.OLVColumn olvColManagement;
        private BrightIdeasSoftware.OLVColumn olvColPhone;
        private BrightIdeasSoftware.OLVColumn olvColFax;
        private BrightIdeasSoftware.OLVColumn olvColEmail;        
        private BrightIdeasSoftware.OLVColumn olvColNumRow;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
    }
}
