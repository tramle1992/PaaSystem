namespace PaaApplication.Forms.Adminstration
{
    partial class FormReportsManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportsManagement));
            this.olvReportTypes = new BrightIdeasSoftware.FastObjectListView();
            this.olvcolBtnDeleteReportType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolTypeName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolDefaultPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolAbsoluteTypeName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolFullApp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.olvClients = new BrightIdeasSoftware.FastObjectListView();
            this.olvcolClientName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolSpecialPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.chkEdit = new System.Windows.Forms.CheckBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.olvReportTypes)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // olvReportTypes
            // 
            this.olvReportTypes.AllColumns.Add(this.olvcolTypeName);
            this.olvReportTypes.AllColumns.Add(this.olvcolBtnDeleteReportType);
            
            this.olvReportTypes.AllColumns.Add(this.olvcolDefaultPrice);
            this.olvReportTypes.AllColumns.Add(this.olvcolAbsoluteTypeName);
            this.olvReportTypes.AllColumns.Add(this.olvcolFullApp);
            this.olvReportTypes.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvReportTypes.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvReportTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolTypeName,
            this.olvcolBtnDeleteReportType,
            
            this.olvcolDefaultPrice,
            this.olvcolAbsoluteTypeName,
            this.olvcolFullApp});
            this.olvReportTypes.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvReportTypes.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvReportTypes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvReportTypes.FullRowSelect = true;
            this.olvReportTypes.HideSelection = false;
            this.olvReportTypes.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvReportTypes.HotItemStyle = this.hotItemStyle;
            this.olvReportTypes.Location = new System.Drawing.Point(11, 42);
            this.olvReportTypes.MultiSelect = false;
            this.olvReportTypes.Name = "olvReportTypes";
            this.olvReportTypes.OwnerDraw = true;
            this.olvReportTypes.ShowGroups = false;
            this.olvReportTypes.ShowImagesOnSubItems = true;
            this.olvReportTypes.Size = new System.Drawing.Size(891, 628);
            this.olvReportTypes.SmallImageList = this.imgList;
            this.olvReportTypes.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.olvReportTypes.TabIndex = 2;
            this.olvReportTypes.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvReportTypes.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvReportTypes.UseAlternatingBackColors = true;
            this.olvReportTypes.UseCompatibleStateImageBehavior = false;
            this.olvReportTypes.UseFiltering = true;
            this.olvReportTypes.UseHotItem = true;
            this.olvReportTypes.UseSubItemCheckBoxes = true;
            this.olvReportTypes.View = System.Windows.Forms.View.Details;
            this.olvReportTypes.VirtualMode = true;
            this.olvReportTypes.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvReportTypes_CellEditFinishing);
            this.olvReportTypes.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvReportTypes_CellEditStarting);
            this.olvReportTypes.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.olvReportTypes_CellEditValidating);
            this.olvReportTypes.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvReportTypes_CellClick);
            this.olvReportTypes.SelectionChanged += new System.EventHandler(this.olvReportTypes_SelectionChanged);
            // 
            // olvcolTypeName
            // 
            this.olvcolTypeName.AspectName = "TypeName";
            this.olvcolTypeName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolTypeName.Text = "Name";
            this.olvcolTypeName.Width = 300;
            this.olvcolTypeName.DisplayIndex = 1;
            // 
            // olvcolBtnDeleteReportType
            // 
            this.olvcolBtnDeleteReportType.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolBtnDeleteReportType.IsEditable = false;
            this.olvcolBtnDeleteReportType.Searchable = false;
            this.olvcolBtnDeleteReportType.Sortable = false;
            this.olvcolBtnDeleteReportType.Text = "";
            this.olvcolBtnDeleteReportType.UseFiltering = false;
            this.olvcolBtnDeleteReportType.Width = 40;
            this.olvcolBtnDeleteReportType.DisplayIndex = 0;
            // 
            // olvcolDefaultPrice
            // 
            this.olvcolDefaultPrice.AspectName = "DefaultPrice";
            this.olvcolDefaultPrice.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolDefaultPrice.Text = "Default Price";
            this.olvcolDefaultPrice.Width = 180;
            this.olvcolDefaultPrice.DisplayIndex = 2;
            // 
            // olvcolAbsoluteTypeName
            // 
            this.olvcolAbsoluteTypeName.AspectName = "AbsoluteTypeName";
            this.olvcolAbsoluteTypeName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolAbsoluteTypeName.Text = "Type";
            this.olvcolAbsoluteTypeName.Width = 180;
            this.olvcolAbsoluteTypeName.DisplayIndex = 3;
            // 
            // olvcolFullApp
            // 
            this.olvcolFullApp.AspectName = "";
            this.olvcolFullApp.CheckBoxes = true;
            this.olvcolFullApp.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolFullApp.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolFullApp.IsEditable = false;
            this.olvcolFullApp.Searchable = false;
            this.olvcolFullApp.Sortable = false;
            this.olvcolFullApp.Text = "Full App";
            this.olvcolFullApp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolFullApp.UseFiltering = false;
            this.olvcolFullApp.Width = 120;
            this.olvcolFullApp.DisplayIndex = 4;
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "delete.png");
            this.imgList.Images.SetKeyName(1, "editing-icon15.png");
            // 
            // pnlEdit
            // 
            this.pnlEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEdit.Controls.Add(this.olvClients);
            this.pnlEdit.Location = new System.Drawing.Point(925, 43);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(650, 627);
            this.pnlEdit.TabIndex = 100;
            // 
            // olvClients
            // 
            this.olvClients.AllColumns.Add(this.olvcolClientName);
            this.olvClients.AllColumns.Add(this.olvcolSpecialPrice);
            this.olvClients.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvClients.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolClientName,
            this.olvcolSpecialPrice});
            this.olvClients.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvClients.Enabled = false;
            this.olvClients.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvClients.ForeColor = System.Drawing.Color.Silver;
            this.olvClients.FullRowSelect = true;
            this.olvClients.HideSelection = false;
            this.olvClients.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvClients.HotItemStyle = this.hotItemStyle;
            this.olvClients.Location = new System.Drawing.Point(11, 13);
            this.olvClients.MultiSelect = false;
            this.olvClients.Name = "olvClients";
            this.olvClients.ShowGroups = false;
            this.olvClients.Size = new System.Drawing.Size(625, 601);
            this.olvClients.TabIndex = 4;
            this.olvClients.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvClients.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvClients.UseAlternatingBackColors = true;
            this.olvClients.UseCompatibleStateImageBehavior = false;
            this.olvClients.UseHotItem = true;
            this.olvClients.View = System.Windows.Forms.View.Details;
            this.olvClients.VirtualMode = true;
            this.olvClients.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvClients_CellEditFinishing);
            this.olvClients.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvClients_CellEditStarting);
            this.olvClients.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.olvClients_CellEditValidating);
            this.olvClients.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvClients_CellClick);
            // 
            // olvcolClientName
            // 
            this.olvcolClientName.AspectName = "ClientName";
            this.olvcolClientName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolClientName.IsEditable = false;
            this.olvcolClientName.Text = "Client Name";
            this.olvcolClientName.Width = 431;
            // 
            // olvcolSpecialPrice
            // 
            this.olvcolSpecialPrice.AspectName = "SpecialPrice";
            this.olvcolSpecialPrice.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolSpecialPrice.Text = "Special Price";
            this.olvcolSpecialPrice.Width = 173;
            // 
            // chkEdit
            // 
            this.chkEdit.AutoSize = true;
            this.chkEdit.Enabled = false;
            this.chkEdit.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkEdit.Location = new System.Drawing.Point(932, 34);
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.chkEdit.Size = new System.Drawing.Size(227, 19);
            this.chkEdit.TabIndex = 3;
            this.chkEdit.Text = "EDIT SPECIAL PRICE FOR CLIENT(S):";
            this.chkEdit.UseVisualStyleBackColor = true;
            this.chkEdit.CheckedChanged += new System.EventHandler(this.chkEdit_CheckedChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.Gray;
            this.btnAddNew.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(326, 8);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(60, 29);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(11, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(308, 24);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.WatermarkText = null;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // FormReportsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 683);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.chkEdit);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.olvReportTypes);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReportsManagement";
            this.Text = "FormReportsManagement";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.ReportsManagement_LoadCompleted);
            this.VisibleChanged += new System.EventHandler(this.FormReportsManagement_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.olvReportTypes)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendControls.WaterMarkTextBox txtSearch;
        private BrightIdeasSoftware.FastObjectListView olvReportTypes;
        private System.Windows.Forms.Panel pnlEdit;
        private BrightIdeasSoftware.FastObjectListView olvClients;
        private System.Windows.Forms.CheckBox chkEdit;
        private BrightIdeasSoftware.OLVColumn olvcolBtnDeleteReportType;
        private BrightIdeasSoftware.OLVColumn olvcolTypeName;
        private BrightIdeasSoftware.OLVColumn olvcolDefaultPrice;
        private BrightIdeasSoftware.OLVColumn olvcolAbsoluteTypeName;
        private BrightIdeasSoftware.OLVColumn olvcolFullApp;
        private BrightIdeasSoftware.OLVColumn olvcolClientName;
        private BrightIdeasSoftware.OLVColumn olvcolSpecialPrice;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnAddNew;
    }
}