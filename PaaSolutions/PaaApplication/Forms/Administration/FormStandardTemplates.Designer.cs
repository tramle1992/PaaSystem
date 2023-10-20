namespace PaaApplication.Forms.Administration
{
    partial class FormStandardTemplates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStandardTemplates));
            this.tlvStandardTemplates = new BrightIdeasSoftware.DataTreeListView();
            this.tlvcolName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tlvcolIndex = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tlvcolCaption = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblParent = new System.Windows.Forms.Label();
            this.txtSW = new System.Windows.Forms.TextBox();
            this.lblSW = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtCo = new System.Windows.Forms.TextBox();
            this.lblCo = new System.Windows.Forms.Label();
            this.txtTele = new System.Windows.Forms.TextBox();
            this.lblTele = new System.Windows.Forms.Label();
            this.lblStandardRefs = new System.Windows.Forms.Label();
            this.lblFinalComments = new System.Windows.Forms.Label();
            this.ctbParent = new ComboTreeBox();
            this.lblTemplateType = new System.Windows.Forms.Label();
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.tsBtnCut = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCopy = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnUndo = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnBold = new System.Windows.Forms.ToolStripButton();
            this.tsBtnItalic = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnIncFontSize = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDecFontSize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnBulletList = new System.Windows.Forms.ToolStripButton();
            this.tsBtnNumberList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAlignRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnDecIndent = new System.Windows.Forms.ToolStripButton();
            this.tsBtnIncIndent = new System.Windows.Forms.ToolStripButton();
            this.rtfStandardRefs = new RichTextBoxEx.Controls.RichTextBoxEx();
            this.rtfFinalComments = new RichTextBoxEx.Controls.RichTextBoxEx();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tlvStandardTemplates)).BeginInit();
            this.tsToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlvStandardTemplates
            // 
            this.tlvStandardTemplates.AllColumns.Add(this.tlvcolName);
            this.tlvStandardTemplates.AllColumns.Add(this.tlvcolIndex);
            this.tlvStandardTemplates.AllColumns.Add(this.tlvcolCaption);
            this.tlvStandardTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tlvcolName,
            this.tlvcolIndex});
            this.tlvStandardTemplates.CopySelectionOnControlCUsesDragSource = false;
            this.tlvStandardTemplates.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvStandardTemplates.DataSource = null;
            this.tlvStandardTemplates.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.tlvStandardTemplates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tlvStandardTemplates.FullRowSelect = true;
            this.tlvStandardTemplates.HideSelection = false;
            this.tlvStandardTemplates.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.tlvStandardTemplates.HotItemStyle = this.hotItemStyle;
            this.tlvStandardTemplates.KeyAspectName = "Id";
            this.tlvStandardTemplates.Location = new System.Drawing.Point(11, 42);
            this.tlvStandardTemplates.MultiSelect = false;
            this.tlvStandardTemplates.Name = "tlvStandardTemplates";
            this.tlvStandardTemplates.OwnerDraw = true;
            this.tlvStandardTemplates.ParentKeyAspectName = "ParentId";
            this.tlvStandardTemplates.RootKeyValueString = "0";
            this.tlvStandardTemplates.SelectColumnsOnRightClick = false;
            this.tlvStandardTemplates.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.tlvStandardTemplates.ShowGroups = false;
            this.tlvStandardTemplates.ShowKeyColumns = false;
            this.tlvStandardTemplates.Size = new System.Drawing.Size(740, 614);
            this.tlvStandardTemplates.TabIndex = 1;
            this.tlvStandardTemplates.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.tlvStandardTemplates.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.tlvStandardTemplates.UseCompatibleStateImageBehavior = false;
            this.tlvStandardTemplates.UseFiltering = true;
            this.tlvStandardTemplates.UseHotItem = true;
            this.tlvStandardTemplates.View = System.Windows.Forms.View.Details;
            this.tlvStandardTemplates.VirtualMode = true;
            this.tlvStandardTemplates.SelectionChanged += new System.EventHandler(this.tlvStandardTemplates_SelectionChanged);
            // 
            // tlvcolName
            // 
            this.tlvcolName.AspectName = "Name";
            this.tlvcolName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.tlvcolName.Sortable = false;
            this.tlvcolName.Text = "Name";
            this.tlvcolName.Width = 550;
            // 
            // tlvcolIndex
            // 
            this.tlvcolIndex.AspectName = "Index";
            this.tlvcolIndex.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.tlvcolIndex.Searchable = false;
            this.tlvcolIndex.Sortable = false;
            this.tlvcolIndex.Text = "Index";
            this.tlvcolIndex.UseFiltering = false;
            this.tlvcolIndex.Width = 100;
            // 
            // tlvcolCaption
            // 
            this.tlvcolCaption.AspectName = "Caption";
            this.tlvcolCaption.DisplayIndex = 2;
            this.tlvcolCaption.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.tlvcolCaption.IsEditable = false;
            this.tlvcolCaption.IsVisible = false;
            this.tlvcolCaption.Searchable = false;
            this.tlvcolCaption.Sortable = false;
            this.tlvcolCaption.Text = "Caption";
            this.tlvcolCaption.UseFiltering = false;
            this.tlvcolCaption.Width = 0;
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblName.Location = new System.Drawing.Point(800, 170);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 100;
            this.lblName.Text = "NAME:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtName.Location = new System.Drawing.Point(802, 200);
            this.txtName.MaxLength = 1000;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(440, 28);
            this.txtName.TabIndex = 3;
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblParent.Location = new System.Drawing.Point(800, 90);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(54, 15);
            this.lblParent.TabIndex = 100;
            this.lblParent.Text = "PARENT:";
            // 
            // txtSW
            // 
            this.txtSW.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtSW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSW.Location = new System.Drawing.Point(802, 280);
            this.txtSW.MaxLength = 0;
            this.txtSW.Name = "txtSW";
            this.txtSW.Size = new System.Drawing.Size(440, 28);
            this.txtSW.TabIndex = 4;
            // 
            // lblSW
            // 
            this.lblSW.AutoSize = true;
            this.lblSW.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSW.Location = new System.Drawing.Point(800, 250);
            this.lblSW.Name = "lblSW";
            this.lblSW.Size = new System.Drawing.Size(30, 15);
            this.lblSW.TabIndex = 100;
            this.lblSW.Text = "S/W:";
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblIndex.Location = new System.Drawing.Point(800, 490);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(43, 15);
            this.lblIndex.TabIndex = 100;
            this.lblIndex.Text = "INDEX:";
            // 
            // txtIndex
            // 
            this.txtIndex.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIndex.Location = new System.Drawing.Point(802, 520);
            this.txtIndex.MaxLength = 4;
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(90, 28);
            this.txtIndex.TabIndex = 10;
            this.txtIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIndex_KeyPress);
            // 
            // txtCo
            // 
            this.txtCo.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtCo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCo.Location = new System.Drawing.Point(802, 360);
            this.txtCo.MaxLength = 0;
            this.txtCo.Name = "txtCo";
            this.txtCo.Size = new System.Drawing.Size(440, 28);
            this.txtCo.TabIndex = 5;
            // 
            // lblCo
            // 
            this.lblCo.AutoSize = true;
            this.lblCo.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCo.Location = new System.Drawing.Point(800, 330);
            this.lblCo.Name = "lblCo";
            this.lblCo.Size = new System.Drawing.Size(27, 15);
            this.lblCo.TabIndex = 100;
            this.lblCo.Text = "CO:";
            // 
            // txtTele
            // 
            this.txtTele.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTele.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTele.Location = new System.Drawing.Point(802, 440);
            this.txtTele.MaxLength = 0;
            this.txtTele.Name = "txtTele";
            this.txtTele.Size = new System.Drawing.Size(440, 28);
            this.txtTele.TabIndex = 6;
            // 
            // lblTele
            // 
            this.lblTele.AutoSize = true;
            this.lblTele.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTele.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTele.Location = new System.Drawing.Point(800, 410);
            this.lblTele.Name = "lblTele";
            this.lblTele.Size = new System.Drawing.Size(37, 15);
            this.lblTele.TabIndex = 100;
            this.lblTele.Text = "TELE:";
            // 
            // lblStandardRefs
            // 
            this.lblStandardRefs.AutoSize = true;
            this.lblStandardRefs.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandardRefs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStandardRefs.Location = new System.Drawing.Point(800, 250);
            this.lblStandardRefs.Name = "lblStandardRefs";
            this.lblStandardRefs.Size = new System.Drawing.Size(105, 15);
            this.lblStandardRefs.TabIndex = 100;
            this.lblStandardRefs.Text = "STANDARD REFS.:";
            // 
            // lblFinalComments
            // 
            this.lblFinalComments.AutoSize = true;
            this.lblFinalComments.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFinalComments.Location = new System.Drawing.Point(800, 250);
            this.lblFinalComments.Name = "lblFinalComments";
            this.lblFinalComments.Size = new System.Drawing.Size(108, 15);
            this.lblFinalComments.TabIndex = 100;
            this.lblFinalComments.Text = "FINAL COMMENTS:";
            // 
            // ctbParent
            // 
            this.ctbParent.DrawWithVisualStyles = false;
            this.ctbParent.DroppedDown = false;
            this.ctbParent.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbParent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ctbParent.Location = new System.Drawing.Point(802, 120);
            this.ctbParent.Name = "ctbParent";
            this.ctbParent.SelectedNode = null;
            this.ctbParent.Size = new System.Drawing.Size(440, 28);
            this.ctbParent.TabIndex = 101;
            this.ctbParent.SelectedNodeChanged += new System.EventHandler(this.ctbParent_SelectedNodeChanged);
            // 
            // lblTemplateType
            // 
            this.lblTemplateType.AutoSize = true;
            this.lblTemplateType.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplateType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTemplateType.Location = new System.Drawing.Point(800, 42);
            this.lblTemplateType.Name = "lblTemplateType";
            this.lblTemplateType.Size = new System.Drawing.Size(143, 21);
            this.lblTemplateType.TabIndex = 102;
            this.lblTemplateType.Text = "TEMPLATE TYPE";
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
            // tsToolbar
            // 
            this.tsToolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.tsToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCut,
            this.tsBtnCopy,
            this.tsBtnPaste,
            this.toolStripSeparator1,
            this.tsBtnUndo,
            this.tsBtnRedo,
            this.toolStripSeparator2,
            this.tsBtnBold,
            this.tsBtnItalic,
            this.tsBtnUnderline,
            this.toolStripSeparator3,
            this.tsBtnIncFontSize,
            this.tsBtnDecFontSize,
            this.toolStripSeparator4,
            this.tsBtnBulletList,
            this.tsBtnNumberList,
            this.toolStripSeparator5,
            this.tsBtnAlignLeft,
            this.tsBtnAlignCenter,
            this.tsBtnAlignRight,
            this.toolStripSeparator6,
            this.tsBtnDecIndent,
            this.tsBtnIncIndent});
            this.tsToolbar.Location = new System.Drawing.Point(802, 280);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tsToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsToolbar.Size = new System.Drawing.Size(440, 26);
            this.tsToolbar.TabIndex = 7;
            // 
            // tsBtnCut
            // 
            this.tsBtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnCut.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCut.Image")));
            this.tsBtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCut.Name = "tsBtnCut";
            this.tsBtnCut.Size = new System.Drawing.Size(23, 23);
            this.tsBtnCut.ToolTipText = "Cut";
            this.tsBtnCut.Click += new System.EventHandler(this.tsBtnCut_Click);
            // 
            // tsBtnCopy
            // 
            this.tsBtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCopy.Image")));
            this.tsBtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCopy.Name = "tsBtnCopy";
            this.tsBtnCopy.Size = new System.Drawing.Size(23, 23);
            this.tsBtnCopy.ToolTipText = "Copy";
            this.tsBtnCopy.Click += new System.EventHandler(this.tsBtnCopy_Click);
            // 
            // tsBtnPaste
            // 
            this.tsBtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnPaste.Image")));
            this.tsBtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPaste.Name = "tsBtnPaste";
            this.tsBtnPaste.Size = new System.Drawing.Size(23, 23);
            this.tsBtnPaste.ToolTipText = "Paste";
            this.tsBtnPaste.Click += new System.EventHandler(this.tsBtnPaste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // tsBtnUndo
            // 
            this.tsBtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUndo.Image")));
            this.tsBtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUndo.Name = "tsBtnUndo";
            this.tsBtnUndo.Size = new System.Drawing.Size(23, 23);
            this.tsBtnUndo.ToolTipText = "Undo";
            this.tsBtnUndo.Click += new System.EventHandler(this.tsBtnUndo_Click);
            // 
            // tsBtnRedo
            // 
            this.tsBtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRedo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRedo.Image")));
            this.tsBtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRedo.Name = "tsBtnRedo";
            this.tsBtnRedo.Size = new System.Drawing.Size(23, 23);
            this.tsBtnRedo.ToolTipText = "Redo";
            this.tsBtnRedo.Click += new System.EventHandler(this.tsBtnRedo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // tsBtnBold
            // 
            this.tsBtnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnBold.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tsBtnBold.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnBold.Image")));
            this.tsBtnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnBold.Name = "tsBtnBold";
            this.tsBtnBold.Size = new System.Drawing.Size(23, 23);
            this.tsBtnBold.Text = "B";
            this.tsBtnBold.ToolTipText = "Bold";
            this.tsBtnBold.Click += new System.EventHandler(this.tsBtnBold_Click);
            // 
            // tsBtnItalic
            // 
            this.tsBtnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnItalic.Font = new System.Drawing.Font("Palatino Linotype", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tsBtnItalic.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnItalic.Image")));
            this.tsBtnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnItalic.Name = "tsBtnItalic";
            this.tsBtnItalic.Size = new System.Drawing.Size(23, 23);
            this.tsBtnItalic.Text = "I";
            this.tsBtnItalic.ToolTipText = "Italic";
            this.tsBtnItalic.Click += new System.EventHandler(this.tsBtnItalic_Click);
            // 
            // tsBtnUnderline
            // 
            this.tsBtnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnUnderline.Font = new System.Drawing.Font("Palatino Linotype", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.tsBtnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUnderline.Image")));
            this.tsBtnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUnderline.Name = "tsBtnUnderline";
            this.tsBtnUnderline.Size = new System.Drawing.Size(24, 23);
            this.tsBtnUnderline.Text = "U";
            this.tsBtnUnderline.ToolTipText = "Underline";
            this.tsBtnUnderline.Click += new System.EventHandler(this.tsBtnUnderline_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // tsBtnIncFontSize
            // 
            this.tsBtnIncFontSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnIncFontSize.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnIncFontSize.Image")));
            this.tsBtnIncFontSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnIncFontSize.Name = "tsBtnIncFontSize";
            this.tsBtnIncFontSize.Size = new System.Drawing.Size(23, 23);
            this.tsBtnIncFontSize.ToolTipText = "Increase Font Size";
            this.tsBtnIncFontSize.Click += new System.EventHandler(this.tsBtnIncFontSize_Click);
            // 
            // tsBtnDecFontSize
            // 
            this.tsBtnDecFontSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDecFontSize.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDecFontSize.Image")));
            this.tsBtnDecFontSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDecFontSize.Name = "tsBtnDecFontSize";
            this.tsBtnDecFontSize.Size = new System.Drawing.Size(23, 23);
            this.tsBtnDecFontSize.ToolTipText = "Decrease Font Size";
            this.tsBtnDecFontSize.Click += new System.EventHandler(this.tsBtnDecFontSize_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
            // 
            // tsBtnBulletList
            // 
            this.tsBtnBulletList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnBulletList.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnBulletList.Image")));
            this.tsBtnBulletList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnBulletList.Name = "tsBtnBulletList";
            this.tsBtnBulletList.Size = new System.Drawing.Size(23, 23);
            this.tsBtnBulletList.ToolTipText = "Bullet List";
            this.tsBtnBulletList.Click += new System.EventHandler(this.tsBtnBulletList_Click);
            // 
            // tsBtnNumberList
            // 
            this.tsBtnNumberList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNumberList.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNumberList.Image")));
            this.tsBtnNumberList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNumberList.Name = "tsBtnNumberList";
            this.tsBtnNumberList.Size = new System.Drawing.Size(23, 23);
            this.tsBtnNumberList.ToolTipText = "Number List";
            this.tsBtnNumberList.Click += new System.EventHandler(this.tsBtnNumberList_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 26);
            // 
            // tsBtnAlignLeft
            // 
            this.tsBtnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAlignLeft.Image")));
            this.tsBtnAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAlignLeft.Name = "tsBtnAlignLeft";
            this.tsBtnAlignLeft.Size = new System.Drawing.Size(23, 23);
            this.tsBtnAlignLeft.ToolTipText = "Align Left";
            this.tsBtnAlignLeft.Click += new System.EventHandler(this.tsBtnAlignLeft_Click);
            // 
            // tsBtnAlignCenter
            // 
            this.tsBtnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAlignCenter.Image")));
            this.tsBtnAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAlignCenter.Name = "tsBtnAlignCenter";
            this.tsBtnAlignCenter.Size = new System.Drawing.Size(23, 23);
            this.tsBtnAlignCenter.ToolTipText = "Align Center";
            this.tsBtnAlignCenter.Click += new System.EventHandler(this.tsBtnAlignCenter_Click);
            // 
            // tsBtnAlignRight
            // 
            this.tsBtnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAlignRight.Image")));
            this.tsBtnAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAlignRight.Name = "tsBtnAlignRight";
            this.tsBtnAlignRight.Size = new System.Drawing.Size(23, 23);
            this.tsBtnAlignRight.ToolTipText = "Align Right";
            this.tsBtnAlignRight.Click += new System.EventHandler(this.tsBtnAlignRight_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 26);
            // 
            // tsBtnDecIndent
            // 
            this.tsBtnDecIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnDecIndent.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDecIndent.Image")));
            this.tsBtnDecIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDecIndent.Name = "tsBtnDecIndent";
            this.tsBtnDecIndent.Size = new System.Drawing.Size(23, 23);
            this.tsBtnDecIndent.ToolTipText = "Decrease Indent";
            this.tsBtnDecIndent.Click += new System.EventHandler(this.tsBtnDecIndent_Click);
            // 
            // tsBtnIncIndent
            // 
            this.tsBtnIncIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnIncIndent.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnIncIndent.Image")));
            this.tsBtnIncIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnIncIndent.Name = "tsBtnIncIndent";
            this.tsBtnIncIndent.Size = new System.Drawing.Size(23, 23);
            this.tsBtnIncIndent.ToolTipText = "Increase Indent";
            this.tsBtnIncIndent.Click += new System.EventHandler(this.tsBtnIncIndent_Click);
            // 
            // rtfStandardRefs
            // 
            this.rtfStandardRefs.AcceptsTab = true;
            this.rtfStandardRefs.BulletStyle = RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletStyle.NoNumber;
            this.rtfStandardRefs.BulletType = RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletType.Normal;
            this.rtfStandardRefs.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.rtfStandardRefs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtfStandardRefs.Location = new System.Drawing.Point(802, 304);
            this.rtfStandardRefs.Name = "rtfStandardRefs";
            this.rtfStandardRefs.Size = new System.Drawing.Size(440, 160);
            this.rtfStandardRefs.TabIndex = 8;
            this.rtfStandardRefs.Text = "";
            // 
            // rtfFinalComments
            // 
            this.rtfFinalComments.AcceptsTab = true;
            this.rtfFinalComments.BulletStyle = RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletStyle.NoNumber;
            this.rtfFinalComments.BulletType = RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletType.Normal;
            this.rtfFinalComments.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.rtfFinalComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtfFinalComments.Location = new System.Drawing.Point(802, 304);
            this.rtfFinalComments.Name = "rtfFinalComments";
            this.rtfFinalComments.Size = new System.Drawing.Size(440, 160);
            this.rtfFinalComments.TabIndex = 9;
            this.rtfFinalComments.Text = "";
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.Gray;
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(325, 7);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(60, 29);
            this.btnAddNew.TabIndex = 103;
            this.btnAddNew.Text = "Add";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Gray;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(391, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 29);
            this.btnDelete.TabIndex = 104;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormStandardTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 683);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.rtfFinalComments);
            this.Controls.Add(this.rtfStandardRefs);
            this.Controls.Add(this.tsToolbar);
            this.Controls.Add(this.lblTemplateType);
            this.Controls.Add(this.ctbParent);
            this.Controls.Add(this.lblFinalComments);
            this.Controls.Add(this.lblStandardRefs);
            this.Controls.Add(this.txtTele);
            this.Controls.Add(this.lblTele);
            this.Controls.Add(this.txtCo);
            this.Controls.Add(this.lblCo);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.txtSW);
            this.Controls.Add(this.lblSW);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tlvStandardTemplates);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStandardTemplates";
            this.Text = "FormStandardTemplates";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormStandardTemplate_LoadCompleted);
            ((System.ComponentModel.ISupportInitialize)(this.tlvStandardTemplates)).EndInit();
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendControls.WaterMarkTextBox txtSearch;
        private BrightIdeasSoftware.DataTreeListView tlvStandardTemplates;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private BrightIdeasSoftware.OLVColumn tlvcolName;
        private BrightIdeasSoftware.OLVColumn tlvcolIndex;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox txtSW;
        private System.Windows.Forms.Label lblSW;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.TextBox txtCo;
        private System.Windows.Forms.Label lblCo;
        private System.Windows.Forms.TextBox txtTele;
        private System.Windows.Forms.Label lblTele;
        private System.Windows.Forms.Label lblStandardRefs;
        private System.Windows.Forms.Label lblFinalComments;
        private BrightIdeasSoftware.OLVColumn tlvcolCaption;
        private ComboTreeBox ctbParent;
        private System.Windows.Forms.Label lblTemplateType;
        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.ToolStripButton tsBtnCut;
        private System.Windows.Forms.ToolStripButton tsBtnCopy;
        private System.Windows.Forms.ToolStripButton tsBtnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnUndo;
        private System.Windows.Forms.ToolStripButton tsBtnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnBold;
        private System.Windows.Forms.ToolStripButton tsBtnItalic;
        private System.Windows.Forms.ToolStripButton tsBtnUnderline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsBtnIncFontSize;
        private System.Windows.Forms.ToolStripButton tsBtnDecFontSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsBtnBulletList;
        private System.Windows.Forms.ToolStripButton tsBtnNumberList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsBtnAlignLeft;
        private System.Windows.Forms.ToolStripButton tsBtnAlignCenter;
        private System.Windows.Forms.ToolStripButton tsBtnAlignRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsBtnDecIndent;
        private System.Windows.Forms.ToolStripButton tsBtnIncIndent;
        private RichTextBoxEx.Controls.RichTextBoxEx rtfStandardRefs;
        private RichTextBoxEx.Controls.RichTextBoxEx rtfFinalComments;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnDelete;
    }
}