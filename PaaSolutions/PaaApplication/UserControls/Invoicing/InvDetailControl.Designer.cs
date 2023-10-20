namespace PaaApplication.UserControls.Invoicing
{
    partial class InvDetailControl
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
            this.lblSoldTo = new System.Windows.Forms.Label();
            this.txtSoldTo = new System.Windows.Forms.TextBox();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.lblInvNum = new System.Windows.Forms.Label();
            this.lblBillingCycle = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.lblInvNumValue = new System.Windows.Forms.Label();
            this.lblBillingCycleValue = new System.Windows.Forms.Label();
            this.lblCustID = new System.Windows.Forms.TextBox();
            this.lblCustPO = new System.Windows.Forms.TextBox();
            this.txtCustPO = new System.Windows.Forms.TextBox();
            this.txtCustID = new System.Windows.Forms.TextBox();
            this.txtShipDate = new System.Windows.Forms.TextBox();
            this.txtShipMethod = new System.Windows.Forms.TextBox();
            this.txtSalesRepID = new System.Windows.Forms.TextBox();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.olvInvoiceItems = new BrightIdeasSoftware.ObjectListView();
            this.olvColItem = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColNum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDesc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColUnitPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cmnuInvoiceItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolShowAvailableApps = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInsertItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDeleteThisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtInvComment = new System.Windows.Forms.TextBox();
            this.lblInvComment = new System.Windows.Forms.Label();
            this.lblPaymentTotalValue = new System.Windows.Forms.Label();
            this.lblInvTotalValue = new System.Windows.Forms.Label();
            this.lblPaymentTotal = new System.Windows.Forms.Label();
            this.lblInvTotal = new System.Windows.Forms.Label();
            this.lblInvBalanceValue = new System.Windows.Forms.Label();
            this.lblInvInterestValue = new System.Windows.Forms.Label();
            this.lblInvBalance = new System.Windows.Forms.Label();
            this.lblInvInterest = new System.Windows.Forms.Label();
            this.chkKeepOnTop = new System.Windows.Forms.CheckBox();
            this.btnPrintInv = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDueDate = new System.Windows.Forms.TextBox();
            this.lblShipDate = new System.Windows.Forms.TextBox();
            this.lblShipMethod = new System.Windows.Forms.TextBox();
            this.lblSalesRepID = new System.Windows.Forms.TextBox();
            this.txtPaymentTerms = new System.Windows.Forms.TextBox();
            this.lblPaymentTerms = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSearchInvItem = new PaaApplication.ExtendControls.WaterMarkTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.olvInvoiceItems)).BeginInit();
            this.cmnuInvoiceItems.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSoldTo
            // 
            this.lblSoldTo.AutoSize = true;
            this.lblSoldTo.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoldTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSoldTo.Location = new System.Drawing.Point(9, 6);
            this.lblSoldTo.Name = "lblSoldTo";
            this.lblSoldTo.Size = new System.Drawing.Size(62, 15);
            this.lblSoldTo.TabIndex = 0;
            this.lblSoldTo.Text = "SOLD  TO:";
            // 
            // txtSoldTo
            // 
            this.txtSoldTo.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoldTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSoldTo.Location = new System.Drawing.Point(11, 27);
            this.txtSoldTo.Multiline = true;
            this.txtSoldTo.Name = "txtSoldTo";
            this.txtSoldTo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSoldTo.Size = new System.Drawing.Size(291, 84);
            this.txtSoldTo.TabIndex = 1;
            this.txtSoldTo.Validating += new System.ComponentModel.CancelEventHandler(this.txtSoldTo_Validating);
            // 
            // txtReference
            // 
            this.txtReference.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReference.Location = new System.Drawing.Point(354, 87);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(227, 24);
            this.txtReference.TabIndex = 2;
            this.txtReference.Validating += new System.ComponentModel.CancelEventHandler(this.txtReference_Validating);
            // 
            // lblInvNum
            // 
            this.lblInvNum.AutoSize = true;
            this.lblInvNum.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvNum.Location = new System.Drawing.Point(345, 18);
            this.lblInvNum.Name = "lblInvNum";
            this.lblInvNum.Size = new System.Drawing.Size(67, 15);
            this.lblInvNum.TabIndex = 0;
            this.lblInvNum.Text = "INVOICE  #:";
            // 
            // lblBillingCycle
            // 
            this.lblBillingCycle.AutoSize = true;
            this.lblBillingCycle.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillingCycle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBillingCycle.Location = new System.Drawing.Point(326, 43);
            this.lblBillingCycle.Name = "lblBillingCycle";
            this.lblBillingCycle.Size = new System.Drawing.Size(94, 15);
            this.lblBillingCycle.TabIndex = 0;
            this.lblBillingCycle.Text = "BILLING  CYCLE:";
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReference.Location = new System.Drawing.Point(336, 67);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(77, 15);
            this.lblReference.TabIndex = 0;
            this.lblReference.Text = "REFERENCE:";
            // 
            // lblInvNumValue
            // 
            this.lblInvNumValue.AutoSize = true;
            this.lblInvNumValue.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvNumValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvNumValue.Location = new System.Drawing.Point(417, 18);
            this.lblInvNumValue.Name = "lblInvNumValue";
            this.lblInvNumValue.Size = new System.Drawing.Size(0, 16);
            this.lblInvNumValue.TabIndex = 0;
            // 
            // lblBillingCycleValue
            // 
            this.lblBillingCycleValue.AutoSize = true;
            this.lblBillingCycleValue.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillingCycleValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBillingCycleValue.Location = new System.Drawing.Point(418, 43);
            this.lblBillingCycleValue.Name = "lblBillingCycleValue";
            this.lblBillingCycleValue.Size = new System.Drawing.Size(0, 16);
            this.lblBillingCycleValue.TabIndex = 0;
            // 
            // lblCustID
            // 
            this.lblCustID.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCustID.Location = new System.Drawing.Point(12, 128);
            this.lblCustID.Name = "lblCustID";
            this.lblCustID.ReadOnly = true;
            this.lblCustID.Size = new System.Drawing.Size(151, 22);
            this.lblCustID.TabIndex = 0;
            this.lblCustID.TabStop = false;
            this.lblCustID.Text = "CUSTOMER  ID";
            this.lblCustID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCustPO
            // 
            this.lblCustPO.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCustPO.Location = new System.Drawing.Point(162, 128);
            this.lblCustPO.Name = "lblCustPO";
            this.lblCustPO.ReadOnly = true;
            this.lblCustPO.Size = new System.Drawing.Size(154, 22);
            this.lblCustPO.TabIndex = 0;
            this.lblCustPO.TabStop = false;
            this.lblCustPO.Text = "CUSTOMER  PO";
            this.lblCustPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustPO
            // 
            this.txtCustPO.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustPO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCustPO.Location = new System.Drawing.Point(162, 149);
            this.txtCustPO.Name = "txtCustPO";
            this.txtCustPO.Size = new System.Drawing.Size(154, 24);
            this.txtCustPO.TabIndex = 4;
            this.txtCustPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustPO.Validating += new System.ComponentModel.CancelEventHandler(this.txtCustPO_Validating);
            // 
            // txtCustID
            // 
            this.txtCustID.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustID.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCustID.Location = new System.Drawing.Point(12, 149);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.ReadOnly = true;
            this.txtCustID.Size = new System.Drawing.Size(151, 24);
            this.txtCustID.TabIndex = 3;
            this.txtCustID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtShipDate
            // 
            this.txtShipDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtShipDate.Enabled = false;
            this.txtShipDate.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtShipDate.Location = new System.Drawing.Point(315, 195);
            this.txtShipDate.Name = "txtShipDate";
            this.txtShipDate.ReadOnly = true;
            this.txtShipDate.Size = new System.Drawing.Size(124, 24);
            this.txtShipDate.TabIndex = 8;
            this.txtShipDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtShipMethod
            // 
            this.txtShipMethod.BackColor = System.Drawing.SystemColors.Window;
            this.txtShipMethod.Enabled = false;
            this.txtShipMethod.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtShipMethod.Location = new System.Drawing.Point(162, 195);
            this.txtShipMethod.Name = "txtShipMethod";
            this.txtShipMethod.ReadOnly = true;
            this.txtShipMethod.Size = new System.Drawing.Size(154, 24);
            this.txtShipMethod.TabIndex = 7;
            this.txtShipMethod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSalesRepID
            // 
            this.txtSalesRepID.BackColor = System.Drawing.SystemColors.Window;
            this.txtSalesRepID.Enabled = false;
            this.txtSalesRepID.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRepID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSalesRepID.Location = new System.Drawing.Point(12, 195);
            this.txtSalesRepID.Name = "txtSalesRepID";
            this.txtSalesRepID.ReadOnly = true;
            this.txtSalesRepID.Size = new System.Drawing.Size(151, 24);
            this.txtSalesRepID.TabIndex = 6;
            this.txtSalesRepID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDueDate
            // 
            this.txtDueDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtDueDate.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDueDate.Location = new System.Drawing.Point(438, 195);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(122, 24);
            this.txtDueDate.TabIndex = 9;
            this.txtDueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // olvInvoiceItems
            // 
            this.olvInvoiceItems.AllColumns.Add(this.olvColItem);
            this.olvInvoiceItems.AllColumns.Add(this.olvColNum);
            this.olvInvoiceItems.AllColumns.Add(this.olvColDesc);
            this.olvInvoiceItems.AllColumns.Add(this.olvColUnitPrice);
            this.olvInvoiceItems.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvInvoiceItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColItem,
            this.olvColNum,
            this.olvColDesc,
            this.olvColUnitPrice});
            this.olvInvoiceItems.ContextMenuStrip = this.cmnuInvoiceItems;
            this.olvInvoiceItems.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvInvoiceItems.FullRowSelect = true;
            this.olvInvoiceItems.HideSelection = false;
            this.olvInvoiceItems.IsSimpleDropSink = true;
            this.olvInvoiceItems.Location = new System.Drawing.Point(11, 275);
            this.olvInvoiceItems.MultiSelect = false;
            this.olvInvoiceItems.Name = "olvInvoiceItems";
            this.olvInvoiceItems.OwnerDraw = true;
            this.olvInvoiceItems.SelectColumnsOnRightClick = false;
            this.olvInvoiceItems.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.olvInvoiceItems.ShowFilterMenuOnRightClick = false;
            this.olvInvoiceItems.ShowGroups = false;
            this.olvInvoiceItems.Size = new System.Drawing.Size(574, 205);
            this.olvInvoiceItems.TabIndex = 11;
            this.olvInvoiceItems.UseCompatibleStateImageBehavior = false;
            this.olvInvoiceItems.UseFiltering = true;
            this.olvInvoiceItems.View = System.Windows.Forms.View.Details;
            this.olvInvoiceItems.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvInvoiceItems_CellEditFinishing);
            this.olvInvoiceItems.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvInvoiceItems_CellEditStarting);
            this.olvInvoiceItems.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.olvInvoiceItems_CellEditValidating);
            this.olvInvoiceItems.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvInvoiceItems_FormatRow);
            this.olvInvoiceItems.ModelCanDrop += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.olvInvoiceItems_ModelCanDrop);
            this.olvInvoiceItems.ModelDropped += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.olvInvoiceItems_ModelDropped);
            // 
            // olvColItem
            // 
            this.olvColItem.AspectName = "Name";
            this.olvColItem.DisplayIndex = 1;
            this.olvColItem.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColItem.Text = "Item";
            this.olvColItem.Width = 100;
            // 
            // olvColNum
            // 
            this.olvColNum.DisplayIndex = 0;
            this.olvColNum.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColNum.IsEditable = false;
            this.olvColNum.Searchable = false;
            this.olvColNum.Sortable = false;
            this.olvColNum.Text = "#";
            this.olvColNum.UseFiltering = false;
            this.olvColNum.Width = 30;
            // 
            // olvColDesc
            // 
            this.olvColDesc.AspectName = "Description";
            this.olvColDesc.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColDesc.Text = "Description";
            this.olvColDesc.Width = 300;
            // 
            // olvColUnitPrice
            // 
            this.olvColUnitPrice.AspectName = "UnitPrice";
            this.olvColUnitPrice.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColUnitPrice.Text = "Unit Price";
            this.olvColUnitPrice.Width = 110;
            // 
            // cmnuInvoiceItems
            // 
            this.cmnuInvoiceItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolShowAvailableApps,
            this.toolInsertItem,
            this.toolDeleteThisItem});
            this.cmnuInvoiceItems.Name = "cxtClientMenu";
            this.cmnuInvoiceItems.Size = new System.Drawing.Size(240, 70);
            this.cmnuInvoiceItems.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuInvoiceItems_Opening);
            // 
            // toolShowAvailableApps
            // 
            this.toolShowAvailableApps.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolShowAvailableApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolShowAvailableApps.Name = "toolShowAvailableApps";
            this.toolShowAvailableApps.Size = new System.Drawing.Size(239, 22);
            this.toolShowAvailableApps.Text = "Show Available Applications";
            this.toolShowAvailableApps.Click += new System.EventHandler(this.toolShowAvailableApps_Click);
            // 
            // toolInsertItem
            // 
            this.toolInsertItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolInsertItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolInsertItem.Name = "toolInsertItem";
            this.toolInsertItem.Size = new System.Drawing.Size(239, 22);
            this.toolInsertItem.Text = "Insert Item";
            this.toolInsertItem.Click += new System.EventHandler(this.toolInsertItem_Click);
            // 
            // toolDeleteThisItem
            // 
            this.toolDeleteThisItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolDeleteThisItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolDeleteThisItem.Name = "toolDeleteThisItem";
            this.toolDeleteThisItem.Size = new System.Drawing.Size(239, 22);
            this.toolDeleteThisItem.Text = "Delete This Item";
            this.toolDeleteThisItem.Click += new System.EventHandler(this.toolDeleteThisItem_Click);
            // 
            // txtInvComment
            // 
            this.txtInvComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtInvComment.Location = new System.Drawing.Point(11, 510);
            this.txtInvComment.Multiline = true;
            this.txtInvComment.Name = "txtInvComment";
            this.txtInvComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInvComment.Size = new System.Drawing.Size(365, 103);
            this.txtInvComment.TabIndex = 12;
            this.txtInvComment.Validating += new System.ComponentModel.CancelEventHandler(this.txtInvComment_Validating);
            // 
            // lblInvComment
            // 
            this.lblInvComment.AutoSize = true;
            this.lblInvComment.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvComment.Location = new System.Drawing.Point(9, 490);
            this.lblInvComment.Name = "lblInvComment";
            this.lblInvComment.Size = new System.Drawing.Size(193, 15);
            this.lblInvComment.TabIndex = 0;
            this.lblInvComment.Text = "INVOICE  COMMENTS  (Not Printed):";
            // 
            // lblPaymentTotalValue
            // 
            this.lblPaymentTotalValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPaymentTotalValue.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPaymentTotalValue.Location = new System.Drawing.Point(502, 314);
            this.lblPaymentTotalValue.Name = "lblPaymentTotalValue";
            this.lblPaymentTotalValue.Size = new System.Drawing.Size(80, 16);
            this.lblPaymentTotalValue.TabIndex = 0;
            this.lblPaymentTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvTotalValue
            // 
            this.lblInvTotalValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblInvTotalValue.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvTotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvTotalValue.Location = new System.Drawing.Point(499, 284);
            this.lblInvTotalValue.Name = "lblInvTotalValue";
            this.lblInvTotalValue.Size = new System.Drawing.Size(83, 16);
            this.lblInvTotalValue.TabIndex = 0;
            this.lblInvTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentTotal
            // 
            this.lblPaymentTotal.AutoSize = true;
            this.lblPaymentTotal.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPaymentTotal.Location = new System.Drawing.Point(397, 314);
            this.lblPaymentTotal.Name = "lblPaymentTotal";
            this.lblPaymentTotal.Size = new System.Drawing.Size(104, 15);
            this.lblPaymentTotal.TabIndex = 0;
            this.lblPaymentTotal.Text = "PAYMENT  TOTAL:";
            this.lblPaymentTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInvTotal
            // 
            this.lblInvTotal.AutoSize = true;
            this.lblInvTotal.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvTotal.Location = new System.Drawing.Point(404, 284);
            this.lblInvTotal.Name = "lblInvTotal";
            this.lblInvTotal.Size = new System.Drawing.Size(97, 15);
            this.lblInvTotal.TabIndex = 0;
            this.lblInvTotal.Text = "INVOICE  TOTAL:";
            this.lblInvTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInvBalanceValue
            // 
            this.lblInvBalanceValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblInvBalanceValue.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvBalanceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvBalanceValue.Location = new System.Drawing.Point(502, 372);
            this.lblInvBalanceValue.Name = "lblInvBalanceValue";
            this.lblInvBalanceValue.Size = new System.Drawing.Size(80, 16);
            this.lblInvBalanceValue.TabIndex = 0;
            this.lblInvBalanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvInterestValue
            // 
            this.lblInvInterestValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblInvInterestValue.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvInterestValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvInterestValue.Location = new System.Drawing.Point(502, 343);
            this.lblInvInterestValue.Name = "lblInvInterestValue";
            this.lblInvInterestValue.Size = new System.Drawing.Size(80, 16);
            this.lblInvInterestValue.TabIndex = 0;
            this.lblInvInterestValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvBalance
            // 
            this.lblInvBalance.AutoSize = true;
            this.lblInvBalance.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvBalance.Location = new System.Drawing.Point(390, 372);
            this.lblInvBalance.Name = "lblInvBalance";
            this.lblInvBalance.Size = new System.Drawing.Size(111, 15);
            this.lblInvBalance.TabIndex = 0;
            this.lblInvBalance.Text = "INVOICE  BALANCE:";
            this.lblInvBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInvInterest
            // 
            this.lblInvInterest.AutoSize = true;
            this.lblInvInterest.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvInterest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvInterest.Location = new System.Drawing.Point(437, 343);
            this.lblInvInterest.Name = "lblInvInterest";
            this.lblInvInterest.Size = new System.Drawing.Size(64, 15);
            this.lblInvInterest.TabIndex = 0;
            this.lblInvInterest.Text = "INTEREST:";
            this.lblInvInterest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkKeepOnTop
            // 
            this.chkKeepOnTop.AutoSize = true;
            this.chkKeepOnTop.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKeepOnTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkKeepOnTop.Location = new System.Drawing.Point(8, 409);
            this.chkKeepOnTop.Name = "chkKeepOnTop";
            this.chkKeepOnTop.Size = new System.Drawing.Size(191, 19);
            this.chkKeepOnTop.TabIndex = 13;
            this.chkKeepOnTop.Text = "KEEP  THIS  WINDOW  ON  TOP";
            this.chkKeepOnTop.UseVisualStyleBackColor = true;
            this.chkKeepOnTop.Visible = false;
            // 
            // btnPrintInv
            // 
            this.btnPrintInv.BackColor = System.Drawing.Color.Gray;
            this.btnPrintInv.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintInv.ForeColor = System.Drawing.Color.White;
            this.btnPrintInv.Location = new System.Drawing.Point(428, 402);
            this.btnPrintInv.Name = "btnPrintInv";
            this.btnPrintInv.Size = new System.Drawing.Size(154, 29);
            this.btnPrintInv.TabIndex = 14;
            this.btnPrintInv.Text = "Print This Invoice";
            this.btnPrintInv.UseVisualStyleBackColor = false;
            this.btnPrintInv.Click += new System.EventHandler(this.btnPrintInv_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDueDate);
            this.groupBox1.Controls.Add(this.lblShipDate);
            this.groupBox1.Controls.Add(this.lblShipMethod);
            this.groupBox1.Controls.Add(this.lblSalesRepID);
            this.groupBox1.Controls.Add(this.txtPaymentTerms);
            this.groupBox1.Controls.Add(this.lblPaymentTerms);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblDueDate
            // 
            this.lblDueDate.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDueDate.Location = new System.Drawing.Point(435, 173);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.ReadOnly = true;
            this.lblDueDate.Size = new System.Drawing.Size(122, 22);
            this.lblDueDate.TabIndex = 0;
            this.lblDueDate.TabStop = false;
            this.lblDueDate.Text = "DUE  DATE";
            this.lblDueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblShipDate
            // 
            this.lblShipDate.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblShipDate.Location = new System.Drawing.Point(312, 173);
            this.lblShipDate.Name = "lblShipDate";
            this.lblShipDate.ReadOnly = true;
            this.lblShipDate.Size = new System.Drawing.Size(124, 22);
            this.lblShipDate.TabIndex = 0;
            this.lblShipDate.TabStop = false;
            this.lblShipDate.Text = "SHIP  DATE";
            this.lblShipDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblShipMethod
            // 
            this.lblShipMethod.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblShipMethod.Location = new System.Drawing.Point(159, 173);
            this.lblShipMethod.Name = "lblShipMethod";
            this.lblShipMethod.ReadOnly = true;
            this.lblShipMethod.Size = new System.Drawing.Size(154, 22);
            this.lblShipMethod.TabIndex = 0;
            this.lblShipMethod.TabStop = false;
            this.lblShipMethod.Text = "SHIPPING  METHOD";
            this.lblShipMethod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSalesRepID
            // 
            this.lblSalesRepID.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesRepID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSalesRepID.Location = new System.Drawing.Point(9, 173);
            this.lblSalesRepID.Name = "lblSalesRepID";
            this.lblSalesRepID.ReadOnly = true;
            this.lblSalesRepID.Size = new System.Drawing.Size(152, 22);
            this.lblSalesRepID.TabIndex = 0;
            this.lblSalesRepID.TabStop = false;
            this.lblSalesRepID.Text = "SALES  REP  ID";
            this.lblSalesRepID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPaymentTerms
            // 
            this.txtPaymentTerms.BackColor = System.Drawing.SystemColors.Window;
            this.txtPaymentTerms.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentTerms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPaymentTerms.Location = new System.Drawing.Point(312, 149);
            this.txtPaymentTerms.Name = "txtPaymentTerms";
            this.txtPaymentTerms.ReadOnly = true;
            this.txtPaymentTerms.Size = new System.Drawing.Size(245, 24);
            this.txtPaymentTerms.TabIndex = 5;
            this.txtPaymentTerms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPaymentTerms
            // 
            this.lblPaymentTerms.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTerms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPaymentTerms.Location = new System.Drawing.Point(312, 128);
            this.lblPaymentTerms.Name = "lblPaymentTerms";
            this.lblPaymentTerms.ReadOnly = true;
            this.lblPaymentTerms.Size = new System.Drawing.Size(245, 22);
            this.lblPaymentTerms.TabIndex = 0;
            this.lblPaymentTerms.TabStop = false;
            this.lblPaymentTerms.Text = "PAYMENT  TERMS";
            this.lblPaymentTerms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkKeepOnTop);
            this.groupBox2.Controls.Add(this.lblInvTotal);
            this.groupBox2.Controls.Add(this.lblInvBalanceValue);
            this.groupBox2.Controls.Add(this.btnPrintInv);
            this.groupBox2.Controls.Add(this.lblInvInterestValue);
            this.groupBox2.Controls.Add(this.lblPaymentTotal);
            this.groupBox2.Controls.Add(this.lblInvBalance);
            this.groupBox2.Controls.Add(this.lblInvInterest);
            this.groupBox2.Controls.Add(this.lblPaymentTotalValue);
            this.groupBox2.Controls.Add(this.lblInvTotalValue);
            this.groupBox2.Location = new System.Drawing.Point(3, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 442);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtSearchInvItem
            // 
            this.txtSearchInvItem.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchInvItem.Location = new System.Drawing.Point(11, 241);
            this.txtSearchInvItem.Name = "txtSearchInvItem";
            this.txtSearchInvItem.Size = new System.Drawing.Size(308, 24);
            this.txtSearchInvItem.TabIndex = 10;
            this.txtSearchInvItem.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearchInvItem.WatermarkText = "#000000";
            this.txtSearchInvItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearchInvItem_KeyUp);
            // 
            // InvDetailControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtInvComment);
            this.Controls.Add(this.lblInvComment);
            this.Controls.Add(this.olvInvoiceItems);
            this.Controls.Add(this.txtDueDate);
            this.Controls.Add(this.txtShipDate);
            this.Controls.Add(this.txtShipMethod);
            this.Controls.Add(this.txtSalesRepID);
            this.Controls.Add(this.txtCustPO);
            this.Controls.Add(this.txtCustID);
            this.Controls.Add(this.lblCustPO);
            this.Controls.Add(this.lblCustID);
            this.Controls.Add(this.lblBillingCycleValue);
            this.Controls.Add(this.lblInvNumValue);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.lblBillingCycle);
            this.Controls.Add(this.lblInvNum);
            this.Controls.Add(this.txtSearchInvItem);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.txtSoldTo);
            this.Controls.Add(this.lblSoldTo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "InvDetailControl";
            this.Size = new System.Drawing.Size(604, 670);
            this.Load += new System.EventHandler(this.InvoiceDetailControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olvInvoiceItems)).EndInit();
            this.cmnuInvoiceItems.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoldTo;
        private System.Windows.Forms.TextBox txtSoldTo;
        private System.Windows.Forms.TextBox txtReference;
        private ExtendControls.WaterMarkTextBox txtSearchInvItem;
        private System.Windows.Forms.Label lblInvNum;
        private System.Windows.Forms.Label lblBillingCycle;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.Label lblInvNumValue;
        private System.Windows.Forms.Label lblBillingCycleValue;
        private System.Windows.Forms.TextBox lblCustID;
        private System.Windows.Forms.TextBox lblCustPO;
        private System.Windows.Forms.TextBox txtCustPO;
        private System.Windows.Forms.TextBox txtCustID;
        private System.Windows.Forms.TextBox txtShipDate;
        private System.Windows.Forms.TextBox txtShipMethod;
        private System.Windows.Forms.TextBox txtSalesRepID;
        private System.Windows.Forms.TextBox txtDueDate;
        private BrightIdeasSoftware.ObjectListView olvInvoiceItems;
        private System.Windows.Forms.TextBox txtInvComment;
        private System.Windows.Forms.Label lblInvComment;
        private System.Windows.Forms.Label lblPaymentTotalValue;
        private System.Windows.Forms.Label lblInvTotalValue;
        private System.Windows.Forms.Label lblPaymentTotal;
        private System.Windows.Forms.Label lblInvTotal;
        private System.Windows.Forms.Label lblInvBalanceValue;
        private System.Windows.Forms.Label lblInvInterestValue;
        private System.Windows.Forms.Label lblInvBalance;
        private System.Windows.Forms.Label lblInvInterest;
        private System.Windows.Forms.CheckBox chkKeepOnTop;
        private System.Windows.Forms.Button btnPrintInv;
        private BrightIdeasSoftware.OLVColumn olvColNum;
        private BrightIdeasSoftware.OLVColumn olvColItem;
        private BrightIdeasSoftware.OLVColumn olvColDesc;
        private BrightIdeasSoftware.OLVColumn olvColUnitPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox lblPaymentTerms;
        private System.Windows.Forms.TextBox txtPaymentTerms;
        private System.Windows.Forms.TextBox lblDueDate;
        private System.Windows.Forms.TextBox lblShipDate;
        private System.Windows.Forms.TextBox lblShipMethod;
        private System.Windows.Forms.TextBox lblSalesRepID;
        private System.Windows.Forms.ContextMenuStrip cmnuInvoiceItems;
        private System.Windows.Forms.ToolStripMenuItem toolShowAvailableApps;
        private System.Windows.Forms.ToolStripMenuItem toolInsertItem;
        private System.Windows.Forms.ToolStripMenuItem toolDeleteThisItem;


    }
}
