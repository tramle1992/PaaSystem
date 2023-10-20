namespace PaaApplication.Forms.Datagrid
{
    partial class FormInvoiceDatagrid
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
            this.ctMenuStripClientDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expoertDatagridCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDatagridInMSWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truncateDatagridAfterThisRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMakeChart = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.olvColName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cboClientList = new System.Windows.Forms.ComboBox();
            this.radioInvoices = new System.Windows.Forms.RadioButton();
            this.olvColMonth = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new PaaApplication.ExtendControls.WaterMarkTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.olvClients = new BrightIdeasSoftware.ObjectListView();
            this.olvColNumRow = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColBalance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAmount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvDivision = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvComment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPayment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvNum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctMenuStripClientDataGrid.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvClients)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctMenuStripClientDataGrid
            // 
            this.ctMenuStripClientDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printDataToolStripMenuItem,
            this.autoSizeColumnsToolStripMenuItem,
            this.expoertDatagridCsvToolStripMenuItem,
            this.typeDatagridInMSWordToolStripMenuItem,
            this.truncateDatagridAfterThisRowToolStripMenuItem});
            this.ctMenuStripClientDataGrid.Name = "ctMenuStripClientDataGrid";
            this.ctMenuStripClientDataGrid.Size = new System.Drawing.Size(263, 114);
            // 
            // printDataToolStripMenuItem
            // 
            this.printDataToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printDataToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.printDataToolStripMenuItem.Name = "printDataToolStripMenuItem";
            this.printDataToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.printDataToolStripMenuItem.Text = "Print Datagrid";
            // 
            // autoSizeColumnsToolStripMenuItem
            // 
            this.autoSizeColumnsToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoSizeColumnsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.autoSizeColumnsToolStripMenuItem.Name = "autoSizeColumnsToolStripMenuItem";
            this.autoSizeColumnsToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.autoSizeColumnsToolStripMenuItem.Text = "Auto-Size Columns";
            // 
            // expoertDatagridCsvToolStripMenuItem
            // 
            this.expoertDatagridCsvToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expoertDatagridCsvToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.expoertDatagridCsvToolStripMenuItem.Name = "expoertDatagridCsvToolStripMenuItem";
            this.expoertDatagridCsvToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.expoertDatagridCsvToolStripMenuItem.Text = "Export Datagrid Csv";
            // 
            // typeDatagridInMSWordToolStripMenuItem
            // 
            this.typeDatagridInMSWordToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeDatagridInMSWordToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.typeDatagridInMSWordToolStripMenuItem.Name = "typeDatagridInMSWordToolStripMenuItem";
            this.typeDatagridInMSWordToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.typeDatagridInMSWordToolStripMenuItem.Text = "Type Datagrid in MS Word";
            // 
            // truncateDatagridAfterThisRowToolStripMenuItem
            // 
            this.truncateDatagridAfterThisRowToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truncateDatagridAfterThisRowToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.truncateDatagridAfterThisRowToolStripMenuItem.Name = "truncateDatagridAfterThisRowToolStripMenuItem";
            this.truncateDatagridAfterThisRowToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.truncateDatagridAfterThisRowToolStripMenuItem.Text = "Truncate Datagrid after this Row";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(310, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 115;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnMakeChart
            // 
            this.btnMakeChart.BackColor = System.Drawing.Color.DarkGray;
            this.btnMakeChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeChart.ForeColor = System.Drawing.Color.White;
            this.btnMakeChart.Location = new System.Drawing.Point(166, 317);
            this.btnMakeChart.Name = "btnMakeChart";
            this.btnMakeChart.Size = new System.Drawing.Size(135, 29);
            this.btnMakeChart.TabIndex = 16;
            this.btnMakeChart.Text = "Make Datagrid";
            this.btnMakeChart.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton3.Location = new System.Drawing.Point(16, 246);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(144, 19);
            this.radioButton3.TabIndex = 111;
            this.radioButton3.Text = "ALL  INVOICES  FROM:";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton2.Location = new System.Drawing.Point(16, 170);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(135, 19);
            this.radioButton2.TabIndex = 106;
            this.radioButton2.Text = "ALL  INVOICES  FOR:";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton1.Location = new System.Drawing.Point(16, 94);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(131, 19);
            this.radioButton1.TabIndex = 103;
            this.radioButton1.Text = "PAST  DUES  FROM:";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // olvColName
            // 
            this.olvColName.AspectName = "ClientName";
            this.olvColName.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColName.IsEditable = false;
            this.olvColName.Text = "Client Name";
            this.olvColName.Width = 372;
            // 
            // cboClientList
            // 
            this.cboClientList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientList.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClientList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboClientList.FormattingEnabled = true;
            this.cboClientList.Location = new System.Drawing.Point(21, 23);
            this.cboClientList.Name = "cboClientList";
            this.cboClientList.Size = new System.Drawing.Size(354, 24);
            this.cboClientList.TabIndex = 101;
            // 
            // radioInvoices
            // 
            this.radioInvoices.AutoSize = true;
            this.radioInvoices.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioInvoices.Location = new System.Drawing.Point(16, 18);
            this.radioInvoices.Name = "radioInvoices";
            this.radioInvoices.Size = new System.Drawing.Size(115, 19);
            this.radioInvoices.TabIndex = 6;
            this.radioInvoices.Text = "PAST  DUE  FOR:";
            this.radioInvoices.UseVisualStyleBackColor = true;
            // 
            // olvColMonth
            // 
            this.olvColMonth.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColMonth.Text = "Month";
            this.olvColMonth.Width = 103;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboClientList);
            this.groupBox2.Location = new System.Drawing.Point(7, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 61);
            this.groupBox2.TabIndex = 116;
            this.groupBox2.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.Location = new System.Drawing.Point(430, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(311, 24);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.WatermarkText = "#000000";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateTimePicker4);
            this.groupBox3.Controls.Add(this.dateTimePicker5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(393, 61);
            this.groupBox3.TabIndex = 117;
            this.groupBox3.TabStop = false;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker4.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker4.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker4.Location = new System.Drawing.Point(202, 24);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(130, 24);
            this.dateTimePicker4.TabIndex = 122;
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker5.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker5.CustomFormat = "MM / dd / yyyy";
            this.dateTimePicker5.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker5.Location = new System.Drawing.Point(24, 24);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(130, 24);
            this.dateTimePicker5.TabIndex = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(170, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 15);
            this.label3.TabIndex = 121;
            this.label3.Text = "TO:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Location = new System.Drawing.Point(8, 171);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(393, 61);
            this.groupBox4.TabIndex = 118;
            this.groupBox4.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(354, 24);
            this.comboBox1.TabIndex = 102;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dateTimePicker3);
            this.groupBox5.Controls.Add(this.dateTimePicker6);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(8, 247);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(393, 61);
            this.groupBox5.TabIndex = 119;
            this.groupBox5.TabStop = false;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker3.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(200, 24);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(130, 24);
            this.dateTimePicker3.TabIndex = 125;
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker6.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker6.CustomFormat = "MM / dd / yyyy";
            this.dateTimePicker6.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker6.Location = new System.Drawing.Point(22, 24);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.Size = new System.Drawing.Size(130, 24);
            this.dateTimePicker6.TabIndex = 123;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(168, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 124;
            this.label2.Text = "TO:";
            // 
            // olvClients
            // 
            this.olvClients.AllColumns.Add(this.olvColNumRow);
            this.olvClients.AllColumns.Add(this.olvColName);
            this.olvClients.AllColumns.Add(this.olvColMonth);
            this.olvClients.AllColumns.Add(this.olvColBalance);
            this.olvClients.AllColumns.Add(this.olvColAmount);
            this.olvClients.AllColumns.Add(this.olvColStatus);
            this.olvClients.AllColumns.Add(this.olvColInvDivision);
            this.olvClients.AllColumns.Add(this.olvColInvComment);
            this.olvClients.AllColumns.Add(this.olvColPayment);
            this.olvClients.AllColumns.Add(this.olvColInvNum);
            this.olvClients.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.olvClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvClients.CellEditEnterChangesRows = true;
            this.olvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColNumRow,
            this.olvColName,
            this.olvColMonth,
            this.olvColBalance,
            this.olvColAmount,
            this.olvColStatus});
            this.olvClients.ContextMenuStrip = this.ctMenuStripClientDataGrid;
            this.olvClients.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvClients.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvClients.FullRowSelect = true;
            this.olvClients.GridLines = true;
            this.olvClients.HeaderWordWrap = true;
            this.olvClients.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvClients.HotItemStyle = this.hotItemStyle;
            this.olvClients.Location = new System.Drawing.Point(430, 47);
            this.olvClients.Name = "olvClients";
            this.olvClients.ShowGroups = false;
            this.olvClients.Size = new System.Drawing.Size(949, 615);
            this.olvClients.SortGroupItemsByPrimaryColumn = false;
            this.olvClients.TabIndex = 9;
            this.olvClients.UseAlternatingBackColors = true;
            this.olvClients.UseCompatibleStateImageBehavior = false;
            this.olvClients.UseFiltering = true;
            this.olvClients.UseHotItem = true;
            this.olvClients.View = System.Windows.Forms.View.Details;
            // 
            // olvColNumRow
            // 
            this.olvColNumRow.AspectName = "";
            this.olvColNumRow.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColNumRow.IsEditable = false;
            this.olvColNumRow.Searchable = false;
            this.olvColNumRow.Sortable = false;
            this.olvColNumRow.Text = "#";
            // 
            // olvColBalance
            // 
            this.olvColBalance.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColBalance.Text = "Balance";
            this.olvColBalance.Width = 102;
            // 
            // olvColAmount
            // 
            this.olvColAmount.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColAmount.Text = "Amount";
            this.olvColAmount.Width = 91;
            // 
            // olvColStatus
            // 
            this.olvColStatus.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColStatus.Text = "Status";
            this.olvColStatus.Width = 105;
            // 
            // olvColInvDivision
            // 
            this.olvColInvDivision.DisplayIndex = 6;
            this.olvColInvDivision.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvDivision.IsVisible = false;
            this.olvColInvDivision.Text = "Invoice Division";
            // 
            // olvColInvComment
            // 
            this.olvColInvComment.DisplayIndex = 7;
            this.olvColInvComment.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvComment.IsVisible = false;
            this.olvColInvComment.Text = "Inv. Comments";
            // 
            // olvColPayment
            // 
            this.olvColPayment.DisplayIndex = 8;
            this.olvColPayment.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColPayment.IsVisible = false;
            this.olvColPayment.Text = "Payment";
            // 
            // olvColInvNum
            // 
            this.olvColInvNum.DisplayIndex = 9;
            this.olvColInvNum.HeaderFont = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvColInvNum.IsVisible = false;
            this.olvColInvNum.Text = "Inv. Num";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnMakeChart);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioInvoices);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(11, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 356);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // FormInvoiceDatagrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 672);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.olvClients);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInvoiceDatagrid";
            this.Text = "FormInvoiceDatagrid";
            this.ctMenuStripClientDataGrid.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvClients)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctMenuStripClientDataGrid;
        private System.Windows.Forms.ToolStripMenuItem printDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSizeColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expoertDatagridCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeDatagridInMSWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truncateDatagridAfterThisRowToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMakeChart;
        private System.Windows.Forms.RadioButton radioButton3;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private BrightIdeasSoftware.OLVColumn olvColName;
        private System.Windows.Forms.ComboBox cboClientList;
        private System.Windows.Forms.RadioButton radioInvoices;
        private BrightIdeasSoftware.OLVColumn olvColMonth;
        private System.Windows.Forms.GroupBox groupBox2;
        private ExtendControls.WaterMarkTextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private BrightIdeasSoftware.ObjectListView olvClients;
        private BrightIdeasSoftware.OLVColumn olvColNumRow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        public System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        public System.Windows.Forms.DateTimePicker dateTimePicker6;
        private System.Windows.Forms.Label label2;
        private BrightIdeasSoftware.OLVColumn olvColAmount;
        private BrightIdeasSoftware.OLVColumn olvColBalance;
        private BrightIdeasSoftware.OLVColumn olvColStatus;
        private BrightIdeasSoftware.OLVColumn olvColInvDivision;
        private BrightIdeasSoftware.OLVColumn olvColInvComment;
        private BrightIdeasSoftware.OLVColumn olvColPayment;
        private BrightIdeasSoftware.OLVColumn olvColInvNum;
    }
}