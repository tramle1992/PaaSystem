namespace PaaApplication.Forms.Datagrid
{
    partial class FormClientDatagrid
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
            this.olvColInvDivision = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvComment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPayment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInvNum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ctMenuStripClientDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expoertDatagridCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeDatagridInMSWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truncateDatagridAfterThisRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotItemStyle = new BrightIdeasSoftware.HotItemStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMakeChart = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioInvoices = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.clientDataGridControl1 = new PaaApplication.UserControls.ClientInfo.ClientDataGridControl();
            this.ctMenuStripClientDataGrid.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // hotItemStyle
            // 
            this.hotItemStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hotItemStyle.ForeColor = System.Drawing.Color.Black;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(291, 276);
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
            this.btnMakeChart.Location = new System.Drawing.Point(147, 276);
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
            this.radioButton3.Location = new System.Drawing.Point(16, 166);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(302, 19);
            this.radioButton3.TabIndex = 111;
            this.radioButton3.Text = "CLIENT  WITH  ADDITIONAL  BILLING  INFORMATION";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton2.Location = new System.Drawing.Point(16, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(183, 19);
            this.radioButton2.TabIndex = 106;
            this.radioButton2.Text = "CLIENT\'S  EMAIL  ADDRESSES";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton1.Location = new System.Drawing.Point(16, 94);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(164, 19);
            this.radioButton1.TabIndex = 103;
            this.radioButton1.Text = "CLIENT  WITH  MGMT  CO:";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioInvoices
            // 
            this.radioInvoices.AutoSize = true;
            this.radioInvoices.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioInvoices.Location = new System.Drawing.Point(16, 18);
            this.radioInvoices.Name = "radioInvoices";
            this.radioInvoices.Size = new System.Drawing.Size(93, 19);
            this.radioInvoices.TabIndex = 6;
            this.radioInvoices.Text = "CLIENT  LIST";
            this.radioInvoices.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnMakeChart);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioInvoices);
            this.groupBox1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(11, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 324);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker5.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateTimePicker5.CustomFormat = "MM / dd / yyyy";
            this.dateTimePicker5.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker5.Location = new System.Drawing.Point(27, 231);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(130, 24);
            this.dateTimePicker5.TabIndex = 120;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton4.Location = new System.Drawing.Point(16, 206);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(289, 19);
            this.radioButton4.TabIndex = 116;
            this.radioButton4.Text = "CLIENTS WHO HAVE  SCREENED  AN  APP  SINCE:";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(27, 119);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(354, 24);
            this.comboBox1.TabIndex = 102;
            // 
            // clientDataGridControl1
            // 
            this.clientDataGridControl1.Location = new System.Drawing.Point(430, 14);
            this.clientDataGridControl1.Name = "clientDataGridControl1";
            this.clientDataGridControl1.Size = new System.Drawing.Size(947, 648);
            this.clientDataGridControl1.TabIndex = 12;
            // 
            // FormClientDatagrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 672);
            this.Controls.Add(this.clientDataGridControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormClientDatagrid";
            this.Text = "FormClientDatagrid";
            this.ctMenuStripClientDataGrid.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.OLVColumn olvColInvDivision;
        private BrightIdeasSoftware.OLVColumn olvColInvComment;
        private BrightIdeasSoftware.OLVColumn olvColPayment;
        private BrightIdeasSoftware.OLVColumn olvColInvNum;
        private System.Windows.Forms.ContextMenuStrip ctMenuStripClientDataGrid;
        private System.Windows.Forms.ToolStripMenuItem printDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSizeColumnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expoertDatagridCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeDatagridInMSWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truncateDatagridAfterThisRowToolStripMenuItem;
        private BrightIdeasSoftware.HotItemStyle hotItemStyle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMakeChart;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioInvoices;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DateTimePicker dateTimePicker5;
        private UserControls.ClientInfo.ClientDataGridControl clientDataGridControl1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}