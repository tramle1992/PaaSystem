namespace PaaApplication.Forms.ClientInfo
{
    partial class FormSearchClient
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
            this.rdoSpecialBilling = new System.Windows.Forms.RadioButton();
            this.lblClientsThatMeet = new System.Windows.Forms.Label();
            this.chkSpecialBilling1 = new System.Windows.Forms.CheckBox();
            this.chkSpecialBilling2 = new System.Windows.Forms.CheckBox();
            this.chkSpecialBilling3 = new System.Windows.Forms.CheckBox();
            this.chkSpecialBilling4 = new System.Windows.Forms.CheckBox();
            this.rdoLastScreening = new System.Windows.Forms.RadioButton();
            this.rdoCustom = new System.Windows.Forms.RadioButton();
            this.lblBetween = new System.Windows.Forms.Label();
            this.dtmLastScreeningFrom = new System.Windows.Forms.DateTimePicker();
            this.lblAnd = new System.Windows.Forms.Label();
            this.dtmLastScreeningTo = new System.Windows.Forms.DateTimePicker();
            this.lblSearchFor = new System.Windows.Forms.Label();
            this.lblSearchIn = new System.Windows.Forms.Label();
            this.txtSearchFor = new System.Windows.Forms.TextBox();
            this.cboSearchIn = new System.Windows.Forms.ComboBox();
            this.btnCustomSQLQuery = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblOfTheseCriteria = new System.Windows.Forms.Label();
            this.rdoSpecialBillingAll = new System.Windows.Forms.RadioButton();
            this.rdoSpecialBillingAny = new System.Windows.Forms.RadioButton();
            this.pnlSpecialBilling = new System.Windows.Forms.Panel();
            this.cboSearchFor = new System.Windows.Forms.ComboBox();
            this.pnlSpecialBilling.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoSpecialBilling
            // 
            this.rdoSpecialBilling.AutoSize = true;
            this.rdoSpecialBilling.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSpecialBilling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoSpecialBilling.Location = new System.Drawing.Point(23, 18);
            this.rdoSpecialBilling.Name = "rdoSpecialBilling";
            this.rdoSpecialBilling.Size = new System.Drawing.Size(263, 19);
            this.rdoSpecialBilling.TabIndex = 0;
            this.rdoSpecialBilling.Text = "SPECIAL  BILLING  CIRCUMSTANCE  SEARCH";
            this.rdoSpecialBilling.UseVisualStyleBackColor = true;
            this.rdoSpecialBilling.CheckedChanged += new System.EventHandler(this.rdoSpecialBilling_CheckedChanged);
            // 
            // lblClientsThatMeet
            // 
            this.lblClientsThatMeet.AutoSize = true;
            this.lblClientsThatMeet.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientsThatMeet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblClientsThatMeet.Location = new System.Drawing.Point(38, 47);
            this.lblClientsThatMeet.Name = "lblClientsThatMeet";
            this.lblClientsThatMeet.Size = new System.Drawing.Size(100, 16);
            this.lblClientsThatMeet.TabIndex = 100;
            this.lblClientsThatMeet.Text = "Clients that meet";
            // 
            // chkSpecialBilling1
            // 
            this.chkSpecialBilling1.AutoSize = true;
            this.chkSpecialBilling1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpecialBilling1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSpecialBilling1.Location = new System.Drawing.Point(67, 100);
            this.chkSpecialBilling1.Name = "chkSpecialBilling1";
            this.chkSpecialBilling1.Size = new System.Drawing.Size(220, 20);
            this.chkSpecialBilling1.TabIndex = 3;
            this.chkSpecialBilling1.Text = "One or more Invoice Divisions";
            this.chkSpecialBilling1.UseVisualStyleBackColor = true;
            // 
            // chkSpecialBilling2
            // 
            this.chkSpecialBilling2.AutoSize = true;
            this.chkSpecialBilling2.Enabled = false;
            this.chkSpecialBilling2.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpecialBilling2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSpecialBilling2.Location = new System.Drawing.Point(67, 128);
            this.chkSpecialBilling2.Name = "chkSpecialBilling2";
            this.chkSpecialBilling2.Size = new System.Drawing.Size(386, 20);
            this.chkSpecialBilling2.TabIndex = 4;
            this.chkSpecialBilling2.Text = "Special Invoice Line (Other than Recommendation only)";
            this.chkSpecialBilling2.UseVisualStyleBackColor = true;
            // 
            // chkSpecialBilling3
            // 
            this.chkSpecialBilling3.AutoSize = true;
            this.chkSpecialBilling3.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpecialBilling3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSpecialBilling3.Location = new System.Drawing.Point(67, 155);
            this.chkSpecialBilling3.Name = "chkSpecialBilling3";
            this.chkSpecialBilling3.Size = new System.Drawing.Size(371, 20);
            this.chkSpecialBilling3.TabIndex = 5;
            this.chkSpecialBilling3.Text = "Client with Special Prices on Cosigner or Roommates";
            this.chkSpecialBilling3.UseVisualStyleBackColor = true;
            // 
            // chkSpecialBilling4
            // 
            this.chkSpecialBilling4.AutoSize = true;
            this.chkSpecialBilling4.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpecialBilling4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSpecialBilling4.Location = new System.Drawing.Point(67, 183);
            this.chkSpecialBilling4.Name = "chkSpecialBilling4";
            this.chkSpecialBilling4.Size = new System.Drawing.Size(293, 20);
            this.chkSpecialBilling4.TabIndex = 6;
            this.chkSpecialBilling4.Text = "Client with Special Prices on Any Reports";
            this.chkSpecialBilling4.UseVisualStyleBackColor = true;
            // 
            // rdoLastScreening
            // 
            this.rdoLastScreening.AutoSize = true;
            this.rdoLastScreening.Enabled = false;
            this.rdoLastScreening.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLastScreening.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoLastScreening.Location = new System.Drawing.Point(23, 216);
            this.rdoLastScreening.Name = "rdoLastScreening";
            this.rdoLastScreening.Size = new System.Drawing.Size(202, 19);
            this.rdoLastScreening.TabIndex = 7;
            this.rdoLastScreening.Text = "CLIENT  WITH  LAST  SCREENING";
            this.rdoLastScreening.UseVisualStyleBackColor = true;
            this.rdoLastScreening.CheckedChanged += new System.EventHandler(this.rdoLastScreening_CheckedChanged);
            // 
            // rdoCustom
            // 
            this.rdoCustom.AutoSize = true;
            this.rdoCustom.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCustom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoCustom.Location = new System.Drawing.Point(23, 288);
            this.rdoCustom.Name = "rdoCustom";
            this.rdoCustom.Size = new System.Drawing.Size(169, 19);
            this.rdoCustom.TabIndex = 10;
            this.rdoCustom.Text = "CUSTOM  CLIENT  SEARCH";
            this.rdoCustom.UseVisualStyleBackColor = true;
            this.rdoCustom.CheckedChanged += new System.EventHandler(this.rdoCustom_CheckedChanged);
            // 
            // lblBetween
            // 
            this.lblBetween.AutoSize = true;
            this.lblBetween.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBetween.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBetween.Location = new System.Drawing.Point(38, 248);
            this.lblBetween.Name = "lblBetween";
            this.lblBetween.Size = new System.Drawing.Size(56, 16);
            this.lblBetween.TabIndex = 100;
            this.lblBetween.Text = "Between";
            // 
            // dtmLastScreeningFrom
            // 
            this.dtmLastScreeningFrom.CustomFormat = "dd / MM / yyyy";
            this.dtmLastScreeningFrom.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmLastScreeningFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmLastScreeningFrom.Location = new System.Drawing.Point(100, 245);
            this.dtmLastScreeningFrom.MinDate = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            this.dtmLastScreeningFrom.Name = "dtmLastScreeningFrom";
            this.dtmLastScreeningFrom.Size = new System.Drawing.Size(125, 24);
            this.dtmLastScreeningFrom.TabIndex = 8;
            this.dtmLastScreeningFrom.ValueChanged += new System.EventHandler(this.dtmLastScreeningFrom_ValueChanged);
            // 
            // lblAnd
            // 
            this.lblAnd.AutoSize = true;
            this.lblAnd.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAnd.Location = new System.Drawing.Point(231, 248);
            this.lblAnd.Name = "lblAnd";
            this.lblAnd.Size = new System.Drawing.Size(30, 16);
            this.lblAnd.TabIndex = 100;
            this.lblAnd.Text = "And";
            // 
            // dtmLastScreeningTo
            // 
            this.dtmLastScreeningTo.CustomFormat = "dd / MM / yyyy";
            this.dtmLastScreeningTo.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmLastScreeningTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmLastScreeningTo.Location = new System.Drawing.Point(267, 245);
            this.dtmLastScreeningTo.MinDate = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            this.dtmLastScreeningTo.Name = "dtmLastScreeningTo";
            this.dtmLastScreeningTo.Size = new System.Drawing.Size(125, 24);
            this.dtmLastScreeningTo.TabIndex = 9;
            this.dtmLastScreeningTo.ValueChanged += new System.EventHandler(this.dtmLastScreeningTo_ValueChanged);
            // 
            // lblSearchFor
            // 
            this.lblSearchFor.AutoSize = true;
            this.lblSearchFor.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchFor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSearchFor.Location = new System.Drawing.Point(38, 317);
            this.lblSearchFor.Name = "lblSearchFor";
            this.lblSearchFor.Size = new System.Drawing.Size(71, 16);
            this.lblSearchFor.TabIndex = 100;
            this.lblSearchFor.Text = "Search For:";
            // 
            // lblSearchIn
            // 
            this.lblSearchIn.AutoSize = true;
            this.lblSearchIn.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSearchIn.Location = new System.Drawing.Point(37, 356);
            this.lblSearchIn.Name = "lblSearchIn";
            this.lblSearchIn.Size = new System.Drawing.Size(63, 16);
            this.lblSearchIn.TabIndex = 100;
            this.lblSearchIn.Text = "Search In:";
            // 
            // txtSearchFor
            // 
            this.txtSearchFor.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchFor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchFor.Location = new System.Drawing.Point(109, 314);
            this.txtSearchFor.Name = "txtSearchFor";
            this.txtSearchFor.Size = new System.Drawing.Size(378, 25);
            this.txtSearchFor.TabIndex = 11;
            // 
            // cboSearchIn
            // 
            this.cboSearchIn.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboSearchIn.FormattingEnabled = true;
            this.cboSearchIn.Location = new System.Drawing.Point(109, 353);
            this.cboSearchIn.Name = "cboSearchIn";
            this.cboSearchIn.Size = new System.Drawing.Size(242, 26);
            this.cboSearchIn.TabIndex = 12;
            this.cboSearchIn.SelectedIndexChanged += new System.EventHandler(this.cboSearchIn_SelectedIndexChanged);
            this.cboSearchIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSearchIn_KeyPress);
            // 
            // btnCustomSQLQuery
            // 
            this.btnCustomSQLQuery.BackColor = System.Drawing.Color.DarkGray;
            this.btnCustomSQLQuery.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomSQLQuery.ForeColor = System.Drawing.Color.Black;
            this.btnCustomSQLQuery.Location = new System.Drawing.Point(357, 353);
            this.btnCustomSQLQuery.Name = "btnCustomSQLQuery";
            this.btnCustomSQLQuery.Size = new System.Drawing.Size(130, 27);
            this.btnCustomSQLQuery.TabIndex = 13;
            this.btnCustomSQLQuery.Text = "Custom &SQL Query...";
            this.btnCustomSQLQuery.UseVisualStyleBackColor = false;
            this.btnCustomSQLQuery.Click += new System.EventHandler(this.btnCustomSQLQuery_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Gray;
            this.btnSearch.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(341, 392);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 29);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(417, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 29);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblOfTheseCriteria
            // 
            this.lblOfTheseCriteria.AutoSize = true;
            this.lblOfTheseCriteria.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfTheseCriteria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOfTheseCriteria.Location = new System.Drawing.Point(61, 6);
            this.lblOfTheseCriteria.Name = "lblOfTheseCriteria";
            this.lblOfTheseCriteria.Size = new System.Drawing.Size(91, 16);
            this.lblOfTheseCriteria.TabIndex = 100;
            this.lblOfTheseCriteria.Text = "of these criteria";
            // 
            // rdoSpecialBillingAll
            // 
            this.rdoSpecialBillingAll.AutoSize = true;
            this.rdoSpecialBillingAll.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSpecialBillingAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoSpecialBillingAll.Location = new System.Drawing.Point(13, 30);
            this.rdoSpecialBillingAll.Name = "rdoSpecialBillingAll";
            this.rdoSpecialBillingAll.Size = new System.Drawing.Size(43, 20);
            this.rdoSpecialBillingAll.TabIndex = 2;
            this.rdoSpecialBillingAll.Text = "All";
            this.rdoSpecialBillingAll.UseVisualStyleBackColor = true;
            // 
            // rdoSpecialBillingAny
            // 
            this.rdoSpecialBillingAny.AutoSize = true;
            this.rdoSpecialBillingAny.Checked = true;
            this.rdoSpecialBillingAny.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSpecialBillingAny.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rdoSpecialBillingAny.Location = new System.Drawing.Point(13, 7);
            this.rdoSpecialBillingAny.Name = "rdoSpecialBillingAny";
            this.rdoSpecialBillingAny.Size = new System.Drawing.Size(50, 20);
            this.rdoSpecialBillingAny.TabIndex = 1;
            this.rdoSpecialBillingAny.TabStop = true;
            this.rdoSpecialBillingAny.Text = "Any";
            this.rdoSpecialBillingAny.UseVisualStyleBackColor = true;
            // 
            // pnlSpecialBilling
            // 
            this.pnlSpecialBilling.Controls.Add(this.rdoSpecialBillingAny);
            this.pnlSpecialBilling.Controls.Add(this.lblOfTheseCriteria);
            this.pnlSpecialBilling.Controls.Add(this.rdoSpecialBillingAll);
            this.pnlSpecialBilling.Location = new System.Drawing.Point(140, 43);
            this.pnlSpecialBilling.Name = "pnlSpecialBilling";
            this.pnlSpecialBilling.Size = new System.Drawing.Size(175, 52);
            this.pnlSpecialBilling.TabIndex = 100;
            // 
            // cboSearchFor
            // 
            this.cboSearchFor.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchFor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboSearchFor.FormattingEnabled = true;
            this.cboSearchFor.Location = new System.Drawing.Point(109, 314);
            this.cboSearchFor.Name = "cboSearchFor";
            this.cboSearchFor.Size = new System.Drawing.Size(378, 26);
            this.cboSearchFor.TabIndex = 11;
            this.cboSearchFor.TextChanged += new System.EventHandler(this.cboSearchFor_TextChanged);
            this.cboSearchFor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSearchFor_KeyPress);
            // 
            // FormSearchClient
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(517, 435);
            this.Controls.Add(this.cboSearchFor);
            this.Controls.Add(this.pnlSpecialBilling);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCustomSQLQuery);
            this.Controls.Add(this.cboSearchIn);
            this.Controls.Add(this.txtSearchFor);
            this.Controls.Add(this.lblSearchIn);
            this.Controls.Add(this.lblSearchFor);
            this.Controls.Add(this.dtmLastScreeningTo);
            this.Controls.Add(this.lblAnd);
            this.Controls.Add(this.dtmLastScreeningFrom);
            this.Controls.Add(this.lblBetween);
            this.Controls.Add(this.rdoCustom);
            this.Controls.Add(this.rdoLastScreening);
            this.Controls.Add(this.chkSpecialBilling4);
            this.Controls.Add(this.chkSpecialBilling3);
            this.Controls.Add(this.chkSpecialBilling2);
            this.Controls.Add(this.chkSpecialBilling1);
            this.Controls.Add(this.lblClientsThatMeet);
            this.Controls.Add(this.rdoSpecialBilling);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchClient";
            this.Text = "Search Client";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormSearchClient_LoadCompleted);
            this.pnlSpecialBilling.ResumeLayout(false);
            this.pnlSpecialBilling.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoSpecialBilling;
        private System.Windows.Forms.Label lblClientsThatMeet;
        private System.Windows.Forms.CheckBox chkSpecialBilling1;
        private System.Windows.Forms.CheckBox chkSpecialBilling2;
        private System.Windows.Forms.CheckBox chkSpecialBilling3;
        private System.Windows.Forms.CheckBox chkSpecialBilling4;
        private System.Windows.Forms.RadioButton rdoLastScreening;
        private System.Windows.Forms.RadioButton rdoCustom;
        private System.Windows.Forms.Label lblBetween;
        private System.Windows.Forms.DateTimePicker dtmLastScreeningFrom;
        private System.Windows.Forms.Label lblAnd;
        private System.Windows.Forms.DateTimePicker dtmLastScreeningTo;
        private System.Windows.Forms.Label lblSearchFor;
        private System.Windows.Forms.Label lblSearchIn;
        private System.Windows.Forms.TextBox txtSearchFor;
        private System.Windows.Forms.ComboBox cboSearchIn;
        private System.Windows.Forms.Button btnCustomSQLQuery;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblOfTheseCriteria;
        private System.Windows.Forms.RadioButton rdoSpecialBillingAll;
        private System.Windows.Forms.RadioButton rdoSpecialBillingAny;
        private System.Windows.Forms.Panel pnlSpecialBilling;
        private System.Windows.Forms.ComboBox cboSearchFor;
    }
}