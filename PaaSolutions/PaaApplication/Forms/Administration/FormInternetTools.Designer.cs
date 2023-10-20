namespace PaaApplication.Forms.Administration
{
    partial class FormInternetTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInternetTools));
            this.olvInternetItems = new BrightIdeasSoftware.FastObjectListView();
            this.olvcolBtnDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolCaption = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolTarget = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolImage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.olvInternetItems)).BeginInit();
            this.SuspendLayout();
            // 
            // olvInternetItems
            // 
            this.olvInternetItems.AllColumns.Add(this.olvcolCaption);
            this.olvInternetItems.AllColumns.Add(this.olvcolBtnDelete);
            this.olvInternetItems.AllColumns.Add(this.olvcolTarget);
            this.olvInternetItems.AllColumns.Add(this.olvcolImage);
            this.olvInternetItems.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvInternetItems.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvInternetItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolCaption,
            this.olvcolBtnDelete,
            this.olvcolTarget,
            this.olvcolImage});
            this.olvInternetItems.CopySelectionOnControlCUsesDragSource = false;
            this.olvInternetItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvInternetItems.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvInternetItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvInternetItems.FullRowSelect = true;
            this.olvInternetItems.GridLines = true;
            this.olvInternetItems.HideSelection = false;
            this.olvInternetItems.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvInternetItems.HotItemStyle = this.hotItemStyle;
            this.olvInternetItems.Location = new System.Drawing.Point(11, 42);
            this.olvInternetItems.MultiSelect = false;
            this.olvInternetItems.Name = "olvInternetItems";
            this.olvInternetItems.OwnerDraw = true;
            this.olvInternetItems.SelectColumnsOnRightClick = false;
            this.olvInternetItems.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.olvInternetItems.ShowFilterMenuOnRightClick = false;
            this.olvInternetItems.ShowGroups = false;
            this.olvInternetItems.ShowImagesOnSubItems = true;
            this.olvInternetItems.Size = new System.Drawing.Size(817, 629);
            this.olvInternetItems.SmallImageList = this.imgList;
            this.olvInternetItems.TabIndex = 2;
            this.olvInternetItems.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvInternetItems.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvInternetItems.UseAlternatingBackColors = true;
            this.olvInternetItems.UseCompatibleStateImageBehavior = false;
            this.olvInternetItems.UseFiltering = true;
            this.olvInternetItems.UseHotItem = true;
            this.olvInternetItems.View = System.Windows.Forms.View.Details;
            this.olvInternetItems.VirtualMode = true;
            this.olvInternetItems.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvInternetItems_CellEditFinishing);
            this.olvInternetItems.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvInternetItems_CellEditStarting);
            this.olvInternetItems.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.olvInternetItems_CellEditValidating);
            this.olvInternetItems.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvInternetItems_CellClick);
            this.olvInternetItems.SelectionChanged += new System.EventHandler(this.olvInternetItems_SelectionChanged);
            // 
            // olvcolCaption
            // 
            this.olvcolCaption.AspectName = "Caption";
            this.olvcolCaption.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolCaption.Sortable = false;
            this.olvcolCaption.Text = "Caption";
            this.olvcolCaption.Width = 198;
            this.olvcolCaption.DisplayIndex = 1;
            // 
            // olvcolBtnDelete
            // 
            this.olvcolBtnDelete.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolBtnDelete.IsEditable = false;
            this.olvcolBtnDelete.Searchable = false;
            this.olvcolBtnDelete.Sortable = false;
            this.olvcolBtnDelete.Text = "";
            this.olvcolBtnDelete.UseFiltering = false;
            this.olvcolBtnDelete.Width = 40;
            this.olvcolBtnDelete.DisplayIndex = 0;            
            // 
            // olvcolTarget
            // 
            this.olvcolTarget.AspectName = "Target";
            this.olvcolTarget.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolTarget.Sortable = false;
            this.olvcolTarget.Text = "Target";
            this.olvcolTarget.Width = 430;
            this.olvcolTarget.DisplayIndex = 2;
            // 
            // olvcolImage
            // 
            this.olvcolImage.AspectName = "";
            this.olvcolImage.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolImage.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolImage.ImageAspectName = "Image";
            this.olvcolImage.IsEditable = false;
            this.olvcolImage.Searchable = false;
            this.olvcolImage.Sortable = false;
            this.olvcolImage.Text = "Image";
            this.olvcolImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolImage.UseFiltering = false;
            this.olvcolImage.Width = 126;
            this.olvcolImage.DisplayIndex = 3;
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
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.Gray;
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(325, 7);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(60, 29);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Silver;
            this.btnDown.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDown.ForeColor = System.Drawing.Color.White;
            this.btnDown.Image = global::PaaApplication.Properties.Resources.down;
            this.btnDown.Location = new System.Drawing.Point(834, 122);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 50);
            this.btnDown.TabIndex = 4;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Silver;
            this.btnUp.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Image = global::PaaApplication.Properties.Resources.up;
            this.btnUp.Location = new System.Drawing.Point(834, 67);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(50, 50);
            this.btnUp.TabIndex = 3;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
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
            // FormInternetTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 683);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.olvInternetItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInternetTools";
            this.Text = "FormInternetTools";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormInternetTools_LoadCompleted);
            ((System.ComponentModel.ISupportInitialize)(this.olvInternetItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView olvInternetItems;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private System.Windows.Forms.ImageList imgList;
        private BrightIdeasSoftware.OLVColumn olvcolCaption;
        private BrightIdeasSoftware.OLVColumn olvcolTarget;
        private BrightIdeasSoftware.OLVColumn olvcolImage;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private BrightIdeasSoftware.OLVColumn olvcolBtnDelete;
        private System.Windows.Forms.Button btnAddNew;
        private ExtendControls.WaterMarkTextBox txtSearch;
    }
}