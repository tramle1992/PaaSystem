using BrightIdeasSoftware;
using PaaApplication.ExtendControls;
using System.Drawing;

namespace PaaApplication
{
    partial class FormInfoResources
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
            BrightIdeasSoftware.CellStyle cellStyle1 = new BrightIdeasSoftware.CellStyle();
            BrightIdeasSoftware.CellStyle cellStyle2 = new BrightIdeasSoftware.CellStyle();
            BrightIdeasSoftware.CellStyle cellStyle3 = new BrightIdeasSoftware.CellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfoResources));
            this.infoResourcesRibbon = new PaaApplication.UserControls.Ribbons.InfoResourcesRibbon();
            this.olvInfoResources = new BrightIdeasSoftware.FastObjectListView();
            this.olvcolResourceName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolBtnRemove = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolBtnEdit = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolTarget = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolPhone = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolEmail = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolComment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.hyperlinkStyle = new BrightIdeasSoftware.HyperlinkStyle();
            this.imglstInforResources = new System.Windows.Forms.ImageList(this.components);
            this.ttipAddNew = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddNewItem = new System.Windows.Forms.Button();
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            this.mnuMaster = new System.Windows.Forms.StatusStrip();
            this.sttlblClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttlblCount = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.olvInfoResources)).BeginInit();
            this.mnuMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoResourcesRibbon
            // 
            this.infoResourcesRibbon.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoResourcesRibbon.Location = new System.Drawing.Point(0, 0);
            this.infoResourcesRibbon.Name = "infoResourcesRibbon";
            this.infoResourcesRibbon.Size = new System.Drawing.Size(1580, 130);
            this.infoResourcesRibbon.TabIndex = 0;
            // 
            // olvInfoResources
            // 
            this.olvInfoResources.AllColumns.Add(this.olvcolResourceName);
            this.olvInfoResources.AllColumns.Add(this.olvcolBtnRemove);
            this.olvInfoResources.AllColumns.Add(this.olvcolBtnEdit);
            this.olvInfoResources.AllColumns.Add(this.olvcolTarget);
            this.olvInfoResources.AllColumns.Add(this.olvcolPhone);
            this.olvInfoResources.AllColumns.Add(this.olvcolEmail);
            this.olvInfoResources.AllColumns.Add(this.olvcolComment);
            this.olvInfoResources.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvInfoResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvInfoResources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcolResourceName,
            this.olvcolBtnRemove,
            this.olvcolBtnEdit,
            this.olvcolTarget,
            this.olvcolPhone,
            this.olvcolEmail,
            this.olvcolComment});
            this.olvInfoResources.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvInfoResources.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvInfoResources.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvInfoResources.FullRowSelect = true;
            this.olvInfoResources.HideSelection = false;
            this.olvInfoResources.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvInfoResources.HotItemStyle = this.hotItemStyle;
            this.olvInfoResources.HyperlinkStyle = this.hyperlinkStyle;
            this.olvInfoResources.LabelWrap = false;
            this.olvInfoResources.Location = new System.Drawing.Point(12, 173);
            this.olvInfoResources.Name = "olvInfoResources";
            this.olvInfoResources.OverlayText.BackColor = System.Drawing.Color.Lime;
            this.olvInfoResources.OwnerDraw = true;
            this.olvInfoResources.ShowGroups = false;
            this.olvInfoResources.Size = new System.Drawing.Size(1555, 605);
            this.olvInfoResources.SmallImageList = this.imglstInforResources;
            this.olvInfoResources.TabIndex = 3;
            this.olvInfoResources.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvInfoResources.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvInfoResources.UseAlternatingBackColors = true;
            this.olvInfoResources.UseCompatibleStateImageBehavior = false;
            this.olvInfoResources.UseCustomSelectionColors = true;
            this.olvInfoResources.UseFiltering = true;
            this.olvInfoResources.UseHotItem = true;
            this.olvInfoResources.UseHyperlinks = true;
            this.olvInfoResources.View = System.Windows.Forms.View.Details;
            this.olvInfoResources.VirtualMode = true;
            this.olvInfoResources.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvInfoResources_CellClick);
            this.olvInfoResources.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.olvInfoResources_CellToolTipShowing);
            this.olvInfoResources.IsHyperlink += new System.EventHandler<BrightIdeasSoftware.IsHyperlinkEventArgs>(this.olvInfoResources_IsHyperlink);
            this.olvInfoResources.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.olvInfoResources_ItemsChanged);
            this.olvInfoResources.SelectionChanged += new System.EventHandler(this.olvInfoResources_SelectionChanged);
            this.olvInfoResources.SelectedIndexChanged += new System.EventHandler(this.olvInfoResources_SelectedIndexChanged);
            this.olvInfoResources.KeyDown += new System.Windows.Forms.KeyEventHandler(this.olvInfoResources_KeyDown);
            this.olvInfoResources.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.olvInfoResources_MouseDoubleClick);
            // 
            // olvcolResourceName
            // 
            this.olvcolResourceName.AspectName = "Name";
            this.olvcolResourceName.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolResourceName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolResourceName.Text = "Name";
            this.olvcolResourceName.Width = 300;
            // 
            // olvcolBtnRemove
            // 
            this.olvcolBtnRemove.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolBtnRemove.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolBtnRemove.Hideable = false;
            this.olvcolBtnRemove.IsEditable = false;
            this.olvcolBtnRemove.Searchable = false;
            this.olvcolBtnRemove.Sortable = false;
            this.olvcolBtnRemove.Text = "";
            this.olvcolBtnRemove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolBtnRemove.UseFiltering = false;
            this.olvcolBtnRemove.Width = 35;
            // 
            // olvcolBtnEdit
            // 
            this.olvcolBtnEdit.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolBtnEdit.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolBtnEdit.Hideable = false;
            this.olvcolBtnEdit.IsEditable = false;
            this.olvcolBtnEdit.Searchable = false;
            this.olvcolBtnEdit.Sortable = false;
            this.olvcolBtnEdit.Text = "";
            this.olvcolBtnEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolBtnEdit.UseFiltering = false;
            this.olvcolBtnEdit.Width = 35;
            // 
            // olvcolTarget
            // 
            this.olvcolTarget.AspectName = "Target";
            this.olvcolTarget.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolTarget.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolTarget.Hyperlink = true;
            this.olvcolTarget.IsTileViewColumn = true;
            this.olvcolTarget.Text = "Fax";
            this.olvcolTarget.Width = 178;
            // 
            // olvcolPhone
            // 
            this.olvcolPhone.AspectName = "Phone";
            this.olvcolPhone.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.olvcolPhone.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolPhone.Text = "Phone";
            this.olvcolPhone.Width = 178;
            // 
            // olvcolEmail
            // 
            this.olvcolEmail.AspectName = "Email";
            this.olvcolEmail.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.olvcolEmail.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolEmail.Text = "Email";
            this.olvcolEmail.Width = 178;
            // 
            // olvcolComment
            // 
            this.olvcolComment.AspectName = "Comment";
            this.olvcolComment.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvcolComment.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvcolComment.Text = "Other";
            this.olvcolComment.Width = 750;
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // hyperlinkStyle
            // 
            cellStyle1.Font = null;
            cellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.hyperlinkStyle.Normal = cellStyle1;
            cellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cellStyle2.FontStyle = System.Drawing.FontStyle.Underline;
            this.hyperlinkStyle.Over = cellStyle2;
            this.hyperlinkStyle.OverCursor = System.Windows.Forms.Cursors.Hand;
            cellStyle3.Font = null;
            cellStyle3.ForeColor = System.Drawing.Color.Purple;
            this.hyperlinkStyle.Visited = cellStyle3;
            // 
            // imglstInforResources
            // 
            this.imglstInforResources.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstInforResources.ImageStream")));
            this.imglstInforResources.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstInforResources.Images.SetKeyName(0, "delete.png");
            this.imglstInforResources.Images.SetKeyName(1, "editing-icon15.png");
            // 
            // btnAddNewItem
            // 
            this.btnAddNewItem.BackColor = System.Drawing.Color.Gray;
            this.btnAddNewItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewItem.ForeColor = System.Drawing.Color.White;
            this.btnAddNewItem.Location = new System.Drawing.Point(328, 137);
            this.btnAddNewItem.Name = "btnAddNewItem";
            this.btnAddNewItem.Size = new System.Drawing.Size(124, 29);
            this.btnAddNewItem.TabIndex = 8;
            this.btnAddNewItem.Text = "Add New Item";
            this.btnAddNewItem.UseVisualStyleBackColor = false;
            this.btnAddNewItem.Click += new System.EventHandler(this.btnAddNewItem_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(12, 140);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(308, 21);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.WatermarkText = null;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // mnuMaster
            // 
            this.mnuMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttlblClock,
            this.sttlblCount});
            this.mnuMaster.Location = new System.Drawing.Point(0, 791);
            this.mnuMaster.Name = "mnuMaster";
            this.mnuMaster.Size = new System.Drawing.Size(1580, 22);
            this.mnuMaster.TabIndex = 10;
            // 
            // sttlblClock
            // 
            this.sttlblClock.Name = "sttlblClock";
            this.sttlblClock.Size = new System.Drawing.Size(0, 17);
            // 
            // sttlblCount
            // 
            this.sttlblCount.Name = "sttlblCount";
            this.sttlblCount.Size = new System.Drawing.Size(0, 17);
            // 
            // FormInfoResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 813);
            this.Controls.Add(this.infoResourcesRibbon);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAddNewItem);
            this.Controls.Add(this.olvInfoResources);
            this.Controls.Add(this.mnuMaster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormInfoResources";
            this.Text = "Info Resources";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInfoResources_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormInfoResources_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.olvInfoResources)).EndInit();
            this.mnuMaster.ResumeLayout(false);
            this.mnuMaster.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UserControls.Ribbons.InfoResourcesRibbon infoResourcesRibbon;

        private WaterMarkTextBox txtSearch;
        private BrightIdeasSoftware.FastObjectListView olvInfoResources;
        private System.Windows.Forms.ToolTip ttipAddNew;
        private System.Windows.Forms.Button btnAddNewItem;
        private BrightIdeasSoftware.OLVColumn olvcolResourceName;
        private BrightIdeasSoftware.OLVColumn olvcolTarget;
        private BrightIdeasSoftware.OLVColumn olvcolComment;
        private OLVColumn olvcolPhone;
        private OLVColumn olvcolEmail;
        private BrightIdeasSoftware.OLVColumn olvcolBtnRemove;
        private BrightIdeasSoftware.OLVColumn olvcolBtnEdit;
        private System.Windows.Forms.ImageList imglstInforResources;
        private HyperlinkStyle hyperlinkStyle;
        private HotItemStyle hotItemStyle;

        private System.Windows.Forms.StatusStrip mnuMaster;
        private System.Windows.Forms.ToolStripStatusLabel sttlblClock;
        private System.Windows.Forms.ToolStripStatusLabel sttlblCount;
        
    }
}
