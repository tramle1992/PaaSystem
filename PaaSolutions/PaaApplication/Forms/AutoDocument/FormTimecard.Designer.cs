using BrightIdeasSoftware;
using System;
namespace PaaApplication.Forms
{
    partial class FormTimecard
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
            this.lblTimecardFor = new System.Windows.Forms.Label();
            this.olvTimecard = new BrightIdeasSoftware.ObjectListView();
            this.olvTcDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolTimeIn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolTimeOut = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolHours = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolBonus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcolType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancelWithoutSaving = new System.Windows.Forms.Button();
            this.btnPrintTimecard = new System.Windows.Forms.Button();
            this.cboTimeCardDate = new System.Windows.Forms.ComboBox();
            this.rtbTimeCardDetails = new System.Windows.Forms.RichTextBox();
            this.lblTimeLogDetails = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.olvTimecard)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimecardFor
            // 
            this.lblTimecardFor.AutoSize = true;
            this.lblTimecardFor.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimecardFor.Location = new System.Drawing.Point(29, 22);
            this.lblTimecardFor.Name = "lblTimecardFor";
            this.lblTimecardFor.Size = new System.Drawing.Size(103, 15);
            this.lblTimecardFor.TabIndex = 0;
            this.lblTimecardFor.Text = "TIME CARD LABEL";
            // 
            // olvTimecard
            // 
            this.olvTimecard.AllColumns.Add(this.olvTcDate);
            this.olvTimecard.AllColumns.Add(this.olvcolTimeIn);
            this.olvTimecard.AllColumns.Add(this.olvcolTimeOut);
            this.olvTimecard.AllColumns.Add(this.olvcolHours);
            this.olvTimecard.AllColumns.Add(this.olvcolBonus);
            this.olvTimecard.AllColumns.Add(this.olvcolType);
            this.olvTimecard.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.olvTimecard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvTcDate,
            this.olvcolTimeIn,
            this.olvcolTimeOut,
            this.olvcolHours,
            this.olvcolBonus,
            this.olvcolType});
            this.olvTimecard.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvTimecard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.olvTimecard.FullRowSelect = true;
            this.olvTimecard.HideSelection = false;
            this.olvTimecard.HighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvTimecard.Location = new System.Drawing.Point(15, 58);
            this.olvTimecard.Name = "olvTimecard";
            this.olvTimecard.ShowGroups = false;
            this.olvTimecard.Size = new System.Drawing.Size(943, 570);
            this.olvTimecard.TabIndex = 5;
            this.olvTimecard.UnfocusedHighlightBackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.olvTimecard.UnfocusedHighlightForegroundColor = System.Drawing.Color.White;
            this.olvTimecard.UseCompatibleStateImageBehavior = false;
            this.olvTimecard.UseCustomSelectionColors = true;
            this.olvTimecard.View = System.Windows.Forms.View.Details;
            this.olvTimecard.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvTimecard_CellEditFinishing);
            this.olvTimecard.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvTimecard_CellEditStarting);
            this.olvTimecard.CellEditValidating += new BrightIdeasSoftware.CellEditEventHandler(this.olvTimecard_CellEditValidating);
            this.olvTimecard.SelectionChanged += new System.EventHandler(this.olvTimecard_SelectionChanged);
            // 
            // olvTcDate
            // 
            this.olvTcDate.AspectName = "Date";
            this.olvTcDate.IsEditable = false;
            this.olvTcDate.Text = "Date";
            this.olvTcDate.Width = 140;
            // 
            // olvcolTimeIn
            // 
            this.olvcolTimeIn.AspectName = "FirstLogin";
            this.olvcolTimeIn.IsEditable = false;
            this.olvcolTimeIn.Text = "Time In";
            this.olvcolTimeIn.Width = 161;
            // 
            // olvcolTimeOut
            // 
            this.olvcolTimeOut.AspectName = "LastLogout";
            this.olvcolTimeOut.IsEditable = false;
            this.olvcolTimeOut.Text = "Time Out";
            this.olvcolTimeOut.Width = 149;
            // 
            // olvcolHours
            // 
            this.olvcolHours.IsEditable = false;
            this.olvcolHours.Text = "Hours";
            this.olvcolHours.Width = 150;
            // 
            // olvcolBonus
            // 
            this.olvcolBonus.AspectName = "Bonus";
            this.olvcolBonus.IsEditable = false;
            this.olvcolBonus.Text = "Bonus";
            this.olvcolBonus.Width = 100;
            // 
            // olvcolType
            // 
            this.olvcolType.AspectName = "";
            this.olvcolType.Text = "Type";
            this.olvcolType.Width = 244;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.Gray;
            this.btnSaveChanges.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(537, 642);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(70, 29);
            this.btnSaveChanges.TabIndex = 11;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnCancelWithoutSaving
            // 
            this.btnCancelWithoutSaving.BackColor = System.Drawing.Color.Gray;
            this.btnCancelWithoutSaving.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelWithoutSaving.ForeColor = System.Drawing.Color.White;
            this.btnCancelWithoutSaving.Location = new System.Drawing.Point(623, 642);
            this.btnCancelWithoutSaving.Name = "btnCancelWithoutSaving";
            this.btnCancelWithoutSaving.Size = new System.Drawing.Size(183, 29);
            this.btnCancelWithoutSaving.TabIndex = 12;
            this.btnCancelWithoutSaving.Text = "Cancel Without Saving";
            this.btnCancelWithoutSaving.UseVisualStyleBackColor = false;
            this.btnCancelWithoutSaving.Click += new System.EventHandler(this.btnCancelWithoutSaving_Click);
            // 
            // btnPrintTimecard
            // 
            this.btnPrintTimecard.BackColor = System.Drawing.Color.Gray;
            this.btnPrintTimecard.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintTimecard.ForeColor = System.Drawing.Color.White;
            this.btnPrintTimecard.Location = new System.Drawing.Point(822, 642);
            this.btnPrintTimecard.Name = "btnPrintTimecard";
            this.btnPrintTimecard.Size = new System.Drawing.Size(137, 29);
            this.btnPrintTimecard.TabIndex = 13;
            this.btnPrintTimecard.Text = "Print Timecard";
            this.btnPrintTimecard.UseVisualStyleBackColor = false;
            this.btnPrintTimecard.Click += new System.EventHandler(this.btnPrintTimecard_Click);
            // 
            // cboTimeCardDate
            // 
            this.cboTimeCardDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeCardDate.FormattingEnabled = true;
            this.cboTimeCardDate.Location = new System.Drawing.Point(313, 19);
            this.cboTimeCardDate.Name = "cboTimeCardDate";
            this.cboTimeCardDate.Size = new System.Drawing.Size(121, 21);
            this.cboTimeCardDate.TabIndex = 17;
            this.cboTimeCardDate.SelectedIndexChanged += new System.EventHandler(this.cboTimeCardDate_SelectedIndexChanged);
            // 
            // rtbTimeCardDetails
            // 
            this.rtbTimeCardDetails.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTimeCardDetails.ForeColor = System.Drawing.SystemColors.GrayText;
            this.rtbTimeCardDetails.Location = new System.Drawing.Point(979, 95);
            this.rtbTimeCardDetails.Name = "rtbTimeCardDetails";
            this.rtbTimeCardDetails.ReadOnly = true;
            this.rtbTimeCardDetails.Size = new System.Drawing.Size(589, 533);
            this.rtbTimeCardDetails.TabIndex = 18;
            this.rtbTimeCardDetails.Text = "";
            // 
            // lblTimeLogDetails
            // 
            this.lblTimeLogDetails.AutoSize = true;
            this.lblTimeLogDetails.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLogDetails.Location = new System.Drawing.Point(6, 16);
            this.lblTimeLogDetails.Name = "lblTimeLogDetails";
            this.lblTimeLogDetails.Size = new System.Drawing.Size(284, 18);
            this.lblTimeLogDetails.TabIndex = 19;
            this.lblTimeLogDetails.Text = "User\'s timelog detail on (MM / dd / yyyy)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTimeLogDetails);
            this.groupBox1.Location = new System.Drawing.Point(979, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 43);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // FormTimecard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 683);
            this.Controls.Add(this.rtbTimeCardDetails);
            this.Controls.Add(this.cboTimeCardDate);
            this.Controls.Add(this.btnPrintTimecard);
            this.Controls.Add(this.btnCancelWithoutSaving);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.olvTimecard);
            this.Controls.Add(this.lblTimecardFor);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTimecard";
            this.Text = "FormTimecard";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormTimecard_LoadCompleted);
            this.Shown += new System.EventHandler(this.FormTimecard_Shown);
            this.VisibleChanged += new System.EventHandler(this.FormTimecard_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.olvTimecard)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }       

        #endregion

        private System.Windows.Forms.Label lblTimecardFor;
        private BrightIdeasSoftware.ObjectListView olvTimecard;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnCancelWithoutSaving;
        private System.Windows.Forms.Button btnPrintTimecard;
        private System.Windows.Forms.ComboBox cboTimeCardDate;
        private OLVColumn olvcolTimeIn;
        private OLVColumn olvcolTimeOut;
        private OLVColumn olvcolHours;
        private OLVColumn olvcolType;
        private System.Windows.Forms.RichTextBox rtbTimeCardDetails;
        private OLVColumn olvcolBonus;
        private System.Windows.Forms.Label lblTimeLogDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private OLVColumn olvTcDate;
    }
}