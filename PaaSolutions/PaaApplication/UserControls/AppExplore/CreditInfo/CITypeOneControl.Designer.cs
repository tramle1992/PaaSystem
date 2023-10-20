using PaaApplication.ExtendControls;
namespace PaaApplication.UserControls.AppExplore.CreditInfo
{
    partial class CITypeOneControl
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
            this.chboxCRObtained = new System.Windows.Forms.CheckBox();
            this.txtPastDue1 = new System.Windows.Forms.TextBox();
            this.chboxMatchApp = new System.Windows.Forms.CheckBox();
            this.chboxCreditHist = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPastDue = new System.Windows.Forms.Label();
            this.lblRent = new System.Windows.Forms.Label();
            this.lblLiens = new System.Windows.Forms.Label();
            this.lblCollections = new System.Windows.Forms.Label();
            this.lblJudgments = new System.Windows.Forms.Label();
            this.lblChildSupport = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblTotals = new System.Windows.Forms.Label();
            this.txtRent1 = new System.Windows.Forms.TextBox();
            this.txtCollection1 = new System.Windows.Forms.TextBox();
            this.txtLient1 = new System.Windows.Forms.TextBox();
            this.txtJudgment1 = new System.Windows.Forms.TextBox();
            this.txtChildSupport1 = new System.Windows.Forms.TextBox();
            this.lblTotalPast = new System.Windows.Forms.Label();
            this.txtTotalPast = new System.Windows.Forms.TextBox();
            this.chBoxPositive = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDates = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.nudChildSupport = new PaaApplication.ExtendControls.NumericEditBox();
            this.nudJudgment = new PaaApplication.ExtendControls.NumericEditBox();
            this.nudLiens = new PaaApplication.ExtendControls.NumericEditBox();
            this.nudCollection = new PaaApplication.ExtendControls.NumericEditBox();
            this.nudRent = new PaaApplication.ExtendControls.NumericEditBox();
            this.nudPassdue = new PaaApplication.ExtendControls.NumericEditBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildSupport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudJudgment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLiens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPassdue)).BeginInit();
            this.SuspendLayout();
            // 
            // chboxCRObtained
            // 
            this.chboxCRObtained.AutoSize = true;
            this.chboxCRObtained.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxCRObtained.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxCRObtained.Location = new System.Drawing.Point(16, 47);
            this.chboxCRObtained.Name = "chboxCRObtained";
            this.chboxCRObtained.Size = new System.Drawing.Size(189, 22);
            this.chboxCRObtained.TabIndex = 1;
            this.chboxCRObtained.Text = "Credit Report Obtained?";
            this.chboxCRObtained.UseVisualStyleBackColor = true;
            // 
            // txtPastDue1
            // 
            this.txtPastDue1.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPastDue1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPastDue1.Location = new System.Drawing.Point(219, 43);
            this.txtPastDue1.Name = "txtPastDue1";
            this.txtPastDue1.ReadOnly = true;
            this.txtPastDue1.Size = new System.Drawing.Size(138, 28);
            this.txtPastDue1.TabIndex = 6;
            this.txtPastDue1.TabStop = false;
            this.txtPastDue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chboxMatchApp
            // 
            this.chboxMatchApp.AutoSize = true;
            this.chboxMatchApp.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxMatchApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxMatchApp.Location = new System.Drawing.Point(16, 93);
            this.chboxMatchApp.Name = "chboxMatchApp";
            this.chboxMatchApp.Size = new System.Drawing.Size(194, 40);
            this.chboxMatchApp.TabIndex = 2;
            this.chboxMatchApp.Text = "Do the names, SSN, and\r\nDOB match application?";
            this.chboxMatchApp.UseVisualStyleBackColor = true;
            // 
            // chboxCreditHist
            // 
            this.chboxCreditHist.AutoSize = true;
            this.chboxCreditHist.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxCreditHist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxCreditHist.Location = new System.Drawing.Point(16, 150);
            this.chboxCreditHist.Name = "chboxCreditHist";
            this.chboxCreditHist.Size = new System.Drawing.Size(199, 58);
            this.chboxCreditHist.TabIndex = 3;
            this.chboxCreditHist.Text = "Does credit history show \r\nbankrupcties or past due\r\nbalances?";
            this.chboxCreditHist.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDate.Location = new System.Drawing.Point(13, 232);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(54, 15);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "DATE(S):";
            // 
            // lblPastDue
            // 
            this.lblPastDue.AutoSize = true;
            this.lblPastDue.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPastDue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPastDue.Location = new System.Drawing.Point(10, 35);
            this.lblPastDue.Name = "lblPastDue";
            this.lblPastDue.Size = new System.Drawing.Size(68, 30);
            this.lblPastDue.TabIndex = 0;
            this.lblPastDue.Text = "PAST  DUE\r\n AMOUNTS:";
            // 
            // lblRent
            // 
            this.lblRent.AutoSize = true;
            this.lblRent.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRent.Location = new System.Drawing.Point(10, 85);
            this.lblRent.Name = "lblRent";
            this.lblRent.Size = new System.Drawing.Size(40, 15);
            this.lblRent.TabIndex = 0;
            this.lblRent.Text = "RENT:";
            // 
            // lblLiens
            // 
            this.lblLiens.AutoSize = true;
            this.lblLiens.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLiens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLiens.Location = new System.Drawing.Point(10, 165);
            this.lblLiens.Name = "lblLiens";
            this.lblLiens.Size = new System.Drawing.Size(41, 15);
            this.lblLiens.TabIndex = 0;
            this.lblLiens.Text = "LIENS:";
            // 
            // lblCollections
            // 
            this.lblCollections.AutoSize = true;
            this.lblCollections.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollections.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCollections.Location = new System.Drawing.Point(9, 125);
            this.lblCollections.Name = "lblCollections";
            this.lblCollections.Size = new System.Drawing.Size(88, 15);
            this.lblCollections.TabIndex = 0;
            this.lblCollections.Text = "COLLECTIONS:";
            // 
            // lblJudgments
            // 
            this.lblJudgments.AutoSize = true;
            this.lblJudgments.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudgments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblJudgments.Location = new System.Drawing.Point(9, 205);
            this.lblJudgments.Name = "lblJudgments";
            this.lblJudgments.Size = new System.Drawing.Size(79, 15);
            this.lblJudgments.TabIndex = 0;
            this.lblJudgments.Text = "JUDGMENTS:";
            // 
            // lblChildSupport
            // 
            this.lblChildSupport.AutoSize = true;
            this.lblChildSupport.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChildSupport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblChildSupport.Location = new System.Drawing.Point(6, 245);
            this.lblChildSupport.Name = "lblChildSupport";
            this.lblChildSupport.Size = new System.Drawing.Size(102, 15);
            this.lblChildSupport.TabIndex = 0;
            this.lblChildSupport.Text = "CHILD  SUPPORT:";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblAdd.Location = new System.Drawing.Point(333, 21);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(37, 15);
            this.lblAdd.TabIndex = 0;
            this.lblAdd.Text = "ADD:";
            // 
            // lblTotals
            // 
            this.lblTotals.AutoSize = true;
            this.lblTotals.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotals.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblTotals.Location = new System.Drawing.Point(434, 20);
            this.lblTotals.Name = "lblTotals";
            this.lblTotals.Size = new System.Drawing.Size(60, 15);
            this.lblTotals.TabIndex = 0;
            this.lblTotals.Text = "TOTALS:";
            // 
            // txtRent1
            // 
            this.txtRent1.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRent1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRent1.Location = new System.Drawing.Point(219, 85);
            this.txtRent1.Name = "txtRent1";
            this.txtRent1.ReadOnly = true;
            this.txtRent1.Size = new System.Drawing.Size(138, 28);
            this.txtRent1.TabIndex = 7;
            this.txtRent1.TabStop = false;
            this.txtRent1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCollection1
            // 
            this.txtCollection1.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollection1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCollection1.Location = new System.Drawing.Point(219, 125);
            this.txtCollection1.Name = "txtCollection1";
            this.txtCollection1.ReadOnly = true;
            this.txtCollection1.Size = new System.Drawing.Size(138, 28);
            this.txtCollection1.TabIndex = 8;
            this.txtCollection1.TabStop = false;
            this.txtCollection1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLient1
            // 
            this.txtLient1.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLient1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLient1.Location = new System.Drawing.Point(219, 165);
            this.txtLient1.Name = "txtLient1";
            this.txtLient1.ReadOnly = true;
            this.txtLient1.Size = new System.Drawing.Size(138, 28);
            this.txtLient1.TabIndex = 9;
            this.txtLient1.TabStop = false;
            this.txtLient1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtJudgment1
            // 
            this.txtJudgment1.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJudgment1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtJudgment1.Location = new System.Drawing.Point(219, 203);
            this.txtJudgment1.Name = "txtJudgment1";
            this.txtJudgment1.ReadOnly = true;
            this.txtJudgment1.Size = new System.Drawing.Size(138, 28);
            this.txtJudgment1.TabIndex = 10;
            this.txtJudgment1.TabStop = false;
            this.txtJudgment1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtChildSupport1
            // 
            this.txtChildSupport1.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChildSupport1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtChildSupport1.Location = new System.Drawing.Point(219, 243);
            this.txtChildSupport1.Name = "txtChildSupport1";
            this.txtChildSupport1.ReadOnly = true;
            this.txtChildSupport1.Size = new System.Drawing.Size(138, 28);
            this.txtChildSupport1.TabIndex = 11;
            this.txtChildSupport1.TabStop = false;
            this.txtChildSupport1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotalPast
            // 
            this.lblTotalPast.AutoSize = true;
            this.lblTotalPast.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalPast.Location = new System.Drawing.Point(123, 282);
            this.lblTotalPast.Name = "lblTotalPast";
            this.lblTotalPast.Size = new System.Drawing.Size(77, 30);
            this.lblTotalPast.TabIndex = 0;
            this.lblTotalPast.Text = "TOTAL  PAST\r\nDUE  DEBTS:";
            // 
            // txtTotalPast
            // 
            this.txtTotalPast.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTotalPast.Location = new System.Drawing.Point(217, 286);
            this.txtTotalPast.Name = "txtTotalPast";
            this.txtTotalPast.ReadOnly = true;
            this.txtTotalPast.Size = new System.Drawing.Size(140, 28);
            this.txtTotalPast.TabIndex = 14;
            this.txtTotalPast.TabStop = false;
            this.txtTotalPast.Text = "$0";
            this.txtTotalPast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chBoxPositive
            // 
            this.chBoxPositive.AutoSize = true;
            this.chBoxPositive.Enabled = false;
            this.chBoxPositive.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxPositive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chBoxPositive.Location = new System.Drawing.Point(17, 286);
            this.chBoxPositive.Name = "chBoxPositive";
            this.chBoxPositive.Size = new System.Drawing.Size(178, 22);
            this.chBoxPositive.TabIndex = 5;
            this.chBoxPositive.Text = "Positive Credit Since?";
            this.chBoxPositive.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDates);
            this.groupBox1.Location = new System.Drawing.Point(7, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 334);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // txtDates
            // 
            this.txtDates.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDates.Location = new System.Drawing.Point(9, 245);
            this.txtDates.Name = "txtDates";
            this.txtDates.Size = new System.Drawing.Size(163, 28);
            this.txtDates.TabIndex = 4;
            this.txtDates.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDates.TextChanged += new System.EventHandler(this.txtDates_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.nudChildSupport);
            this.groupBox2.Controls.Add(this.nudJudgment);
            this.groupBox2.Controls.Add(this.nudLiens);
            this.groupBox2.Controls.Add(this.nudCollection);
            this.groupBox2.Controls.Add(this.nudRent);
            this.groupBox2.Controls.Add(this.nudPassdue);
            this.groupBox2.Controls.Add(this.btnCalculator);
            this.groupBox2.Controls.Add(this.lblTotalPast);
            this.groupBox2.Controls.Add(this.txtTotalPast);
            this.groupBox2.Controls.Add(this.lblPastDue);
            this.groupBox2.Controls.Add(this.lblJudgments);
            this.groupBox2.Controls.Add(this.lblChildSupport);
            this.groupBox2.Controls.Add(this.lblLiens);
            this.groupBox2.Controls.Add(this.lblCollections);
            this.groupBox2.Controls.Add(this.txtChildSupport1);
            this.groupBox2.Controls.Add(this.lblRent);
            this.groupBox2.Controls.Add(this.txtJudgment1);
            this.groupBox2.Controls.Add(this.txtLient1);
            this.groupBox2.Controls.Add(this.txtCollection1);
            this.groupBox2.Controls.Add(this.txtRent1);
            this.groupBox2.Controls.Add(this.txtPastDue1);
            this.groupBox2.Location = new System.Drawing.Point(218, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 360);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(287, 325);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(70, 29);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCalculator
            // 
            this.btnCalculator.Image = global::PaaApplication.Properties.Resources.calculators;
            this.btnCalculator.Location = new System.Drawing.Point(33, 274);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(47, 47);
            this.btnCalculator.TabIndex = 12;
            this.btnCalculator.TabStop = false;
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // nudChildSupport
            // 
            this.nudChildSupport.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudChildSupport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudChildSupport.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudChildSupport.Location = new System.Drawing.Point(118, 241);
            this.nudChildSupport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudChildSupport.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudChildSupport.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudChildSupport.Name = "nudChildSupport";
            this.nudChildSupport.Size = new System.Drawing.Size(90, 28);
            this.nudChildSupport.TabIndex = 11;
            this.nudChildSupport.ThousandsSeparator = true;
            this.nudChildSupport.ValueChanged += new System.EventHandler(this.nudChildSupport_ValueChanged);
            this.nudChildSupport.Enter += new System.EventHandler(this.nudChildSupport_Enter);
            this.nudChildSupport.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudChildSupport_KeyUp);
            this.nudChildSupport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nudChildSupport_MouseClick);
            // 
            // nudJudgment
            // 
            this.nudJudgment.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudJudgment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudJudgment.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudJudgment.Location = new System.Drawing.Point(118, 202);
            this.nudJudgment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudJudgment.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudJudgment.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudJudgment.Name = "nudJudgment";
            this.nudJudgment.Size = new System.Drawing.Size(90, 28);
            this.nudJudgment.TabIndex = 10;
            this.nudJudgment.ThousandsSeparator = true;
            this.nudJudgment.ValueChanged += new System.EventHandler(this.nudJudgment_ValueChanged);
            this.nudJudgment.Enter += new System.EventHandler(this.nudJudgment_Enter);
            this.nudJudgment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudJudgment_KeyUp);
            this.nudJudgment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nudJudgment_MouseClick);
            // 
            // nudLiens
            // 
            this.nudLiens.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLiens.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudLiens.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLiens.Location = new System.Drawing.Point(118, 165);
            this.nudLiens.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudLiens.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudLiens.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudLiens.Name = "nudLiens";
            this.nudLiens.Size = new System.Drawing.Size(90, 28);
            this.nudLiens.TabIndex = 9;
            this.nudLiens.ThousandsSeparator = true;
            this.nudLiens.ValueChanged += new System.EventHandler(this.nudLiens_ValueChanged);
            this.nudLiens.Enter += new System.EventHandler(this.nudLiens_Enter);
            this.nudLiens.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudLiens_KeyUp);
            this.nudLiens.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nudLiens_MouseClick);
            // 
            // nudCollection
            // 
            this.nudCollection.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCollection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudCollection.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCollection.Location = new System.Drawing.Point(118, 125);
            this.nudCollection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudCollection.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudCollection.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudCollection.Name = "nudCollection";
            this.nudCollection.Size = new System.Drawing.Size(90, 28);
            this.nudCollection.TabIndex = 8;
            this.nudCollection.ThousandsSeparator = true;
            this.nudCollection.ValueChanged += new System.EventHandler(this.nudCollection_ValueChanged);
            this.nudCollection.Enter += new System.EventHandler(this.nudCollection_Enter);
            this.nudCollection.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudCollection_KeyUp);
            this.nudCollection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nudCollection_MouseClick);
            // 
            // nudRent
            // 
            this.nudRent.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudRent.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRent.Location = new System.Drawing.Point(118, 85);
            this.nudRent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudRent.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudRent.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudRent.Name = "nudRent";
            this.nudRent.Size = new System.Drawing.Size(90, 28);
            this.nudRent.TabIndex = 7;
            this.nudRent.ThousandsSeparator = true;
            this.nudRent.ValueChanged += new System.EventHandler(this.nudRent_ValueChanged);
            this.nudRent.Enter += new System.EventHandler(this.nudRent_Enter);
            this.nudRent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudRent_KeyUp);
            this.nudRent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nudRent_MouseClick);
            // 
            // nudPassdue
            // 
            this.nudPassdue.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPassdue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudPassdue.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPassdue.Location = new System.Drawing.Point(118, 42);
            this.nudPassdue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudPassdue.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudPassdue.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nudPassdue.Name = "nudPassdue";
            this.nudPassdue.Size = new System.Drawing.Size(90, 28);
            this.nudPassdue.TabIndex = 6;
            this.nudPassdue.ThousandsSeparator = true;
            this.nudPassdue.ValueChanged += new System.EventHandler(this.nudPassdue_ValueChanged);
            this.nudPassdue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudPassdue_KeyUp);
            this.nudPassdue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nudPassdue_MouseClick);
            // 
            // CITypeOneControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.chBoxPositive);
            this.Controls.Add(this.lblTotals);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.chboxCreditHist);
            this.Controls.Add(this.chboxMatchApp);
            this.Controls.Add(this.chboxCRObtained);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "CITypeOneControl";
            this.Size = new System.Drawing.Size(596, 656);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChildSupport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudJudgment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLiens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPassdue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chboxCRObtained;
        private System.Windows.Forms.TextBox txtPastDue1;
        private System.Windows.Forms.CheckBox chboxMatchApp;
        private System.Windows.Forms.CheckBox chboxCreditHist;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblPastDue;
        private System.Windows.Forms.Label lblRent;
        private System.Windows.Forms.Label lblLiens;
        private System.Windows.Forms.Label lblCollections;
        private System.Windows.Forms.Label lblJudgments;
        private System.Windows.Forms.Label lblChildSupport;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label lblTotals;
        private System.Windows.Forms.TextBox txtRent1;
        private System.Windows.Forms.TextBox txtCollection1;
        private System.Windows.Forms.TextBox txtLient1;
        private System.Windows.Forms.TextBox txtJudgment1;
        private System.Windows.Forms.TextBox txtChildSupport1;
        private System.Windows.Forms.Label lblTotalPast;
        private System.Windows.Forms.TextBox txtTotalPast;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.CheckBox chBoxPositive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDates;        
        private NumericEditBox nudPassdue;
        private NumericEditBox nudChildSupport;
        private NumericEditBox nudJudgment;
        private NumericEditBox nudLiens;
        private NumericEditBox nudCollection;
        private NumericEditBox nudRent;
        private System.Windows.Forms.Button btnReset;
    }
}
