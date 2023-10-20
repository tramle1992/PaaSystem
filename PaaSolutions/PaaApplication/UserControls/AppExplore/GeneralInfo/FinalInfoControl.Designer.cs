namespace PaaApplication.UserControls.AppExplore.GeneralInfo
{
    partial class FinalInfoControl
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
            this.btnSComments = new System.Windows.Forms.Button();
            this.grpCheckboxs = new System.Windows.Forms.GroupBox();
            this.chboxFalse = new System.Windows.Forms.CheckBox();
            this.chboxAbs = new System.Windows.Forms.CheckBox();
            this.chboxCriminal = new System.Windows.Forms.CheckBox();
            this.chboxRent = new System.Windows.Forms.CheckBox();
            this.chboxFirst = new System.Windows.Forms.CheckBox();
            this.chboxLack = new System.Windows.Forms.CheckBox();
            this.chboxCredit = new System.Windows.Forms.CheckBox();
            this.chboxCosigner = new System.Windows.Forms.CheckBox();
            this.chboxShort = new System.Windows.Forms.CheckBox();
            this.chboxRental = new System.Windows.Forms.CheckBox();
            this.chBoxQualifier = new System.Windows.Forms.CheckBox();
            this.btnRefs = new System.Windows.Forms.Button();
            this.lblFinalComment = new System.Windows.Forms.Label();
            this.lblAppComments = new System.Windows.Forms.Label();
            this.txtAppComment = new System.Windows.Forms.TextBox();
            this.btnCriteria = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtFinComment = new System.Windows.Forms.TextBox();
            this.grpCheckboxs.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSComments
            // 
            this.btnSComments.BackColor = System.Drawing.Color.Silver;
            this.btnSComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSComments.Location = new System.Drawing.Point(410, 146);
            this.btnSComments.Name = "btnSComments";
            this.btnSComments.Size = new System.Drawing.Size(169, 29);
            this.btnSComments.TabIndex = 13;
            this.btnSComments.Text = "&Standard Comments";
            this.btnSComments.UseVisualStyleBackColor = false;
            this.btnSComments.Click += new System.EventHandler(this.btnSComments_Click);
            // 
            // grpCheckboxs
            // 
            this.grpCheckboxs.Controls.Add(this.chboxFalse);
            this.grpCheckboxs.Controls.Add(this.chboxAbs);
            this.grpCheckboxs.Controls.Add(this.chboxCriminal);
            this.grpCheckboxs.Controls.Add(this.chboxRent);
            this.grpCheckboxs.Controls.Add(this.chboxFirst);
            this.grpCheckboxs.Controls.Add(this.chboxLack);
            this.grpCheckboxs.Controls.Add(this.chboxCredit);
            this.grpCheckboxs.Controls.Add(this.chboxCosigner);
            this.grpCheckboxs.Controls.Add(this.chboxShort);
            this.grpCheckboxs.Controls.Add(this.chboxRental);
            this.grpCheckboxs.Controls.Add(this.chBoxQualifier);
            this.grpCheckboxs.Controls.Add(this.btnRefs);
            this.grpCheckboxs.Location = new System.Drawing.Point(3, 3);
            this.grpCheckboxs.Name = "grpCheckboxs";
            this.grpCheckboxs.Size = new System.Drawing.Size(575, 128);
            this.grpCheckboxs.TabIndex = 1;
            this.grpCheckboxs.TabStop = false;
            // 
            // chboxFalse
            // 
            this.chboxFalse.AutoSize = true;
            this.chboxFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxFalse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxFalse.Location = new System.Drawing.Point(219, 97);
            this.chboxFalse.Name = "chboxFalse";
            this.chboxFalse.Size = new System.Drawing.Size(140, 20);
            this.chboxFalse.TabIndex = 8;
            this.chboxFalse.Text = "False/Discr. Info";
            this.chboxFalse.UseVisualStyleBackColor = true;
            // 
            // chboxAbs
            // 
            this.chboxAbs.AutoSize = true;
            this.chboxAbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxAbs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxAbs.Location = new System.Drawing.Point(11, 97);
            this.chboxAbs.Name = "chboxAbs";
            this.chboxAbs.Size = new System.Drawing.Size(119, 20);
            this.chboxAbs.TabIndex = 4;
            this.chboxAbs.Text = "Abs, Pos NO!";
            this.chboxAbs.UseVisualStyleBackColor = true;
            this.chboxAbs.CheckedChanged += new System.EventHandler(this.chboxAbs_CheckedChanged);
            // 
            // chboxCriminal
            // 
            this.chboxCriminal.AutoSize = true;
            this.chboxCriminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxCriminal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxCriminal.Location = new System.Drawing.Point(407, 71);
            this.chboxCriminal.Name = "chboxCriminal";
            this.chboxCriminal.Size = new System.Drawing.Size(136, 20);
            this.chboxCriminal.TabIndex = 11;
            this.chboxCriminal.Text = "Criminal History";
            this.chboxCriminal.UseVisualStyleBackColor = true;
            // 
            // chboxRent
            // 
            this.chboxRent.AutoSize = true;
            this.chboxRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxRent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxRent.Location = new System.Drawing.Point(219, 71);
            this.chboxRent.Name = "chboxRent";
            this.chboxRent.Size = new System.Drawing.Size(132, 20);
            this.chboxRent.TabIndex = 7;
            this.chboxRent.Text = "Rent-to-Income";
            this.chboxRent.UseVisualStyleBackColor = true;
            // 
            // chboxFirst
            // 
            this.chboxFirst.AutoSize = true;
            this.chboxFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxFirst.Location = new System.Drawing.Point(11, 71);
            this.chboxFirst.Name = "chboxFirst";
            this.chboxFirst.Size = new System.Drawing.Size(131, 20);
            this.chboxFirst.TabIndex = 3;
            this.chboxFirst.Text = "First && Security";
            this.chboxFirst.UseVisualStyleBackColor = true;
            this.chboxFirst.CheckedChanged += new System.EventHandler(this.chboxFirst_CheckedChanged);
            // 
            // chboxLack
            // 
            this.chboxLack.AutoSize = true;
            this.chboxLack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxLack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxLack.Location = new System.Drawing.Point(407, 45);
            this.chboxLack.Name = "chboxLack";
            this.chboxLack.Size = new System.Drawing.Size(157, 20);
            this.chboxLack.TabIndex = 10;
            this.chboxLack.Text = "Lack of Information";
            this.chboxLack.UseVisualStyleBackColor = true;
            // 
            // chboxCredit
            // 
            this.chboxCredit.AutoSize = true;
            this.chboxCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxCredit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxCredit.Location = new System.Drawing.Point(219, 45);
            this.chboxCredit.Name = "chboxCredit";
            this.chboxCredit.Size = new System.Drawing.Size(121, 20);
            this.chboxCredit.TabIndex = 6;
            this.chboxCredit.Text = "Credit History";
            this.chboxCredit.UseVisualStyleBackColor = true;
            // 
            // chboxCosigner
            // 
            this.chboxCosigner.AutoSize = true;
            this.chboxCosigner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxCosigner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxCosigner.Location = new System.Drawing.Point(11, 45);
            this.chboxCosigner.Name = "chboxCosigner";
            this.chboxCosigner.Size = new System.Drawing.Size(89, 20);
            this.chboxCosigner.TabIndex = 2;
            this.chboxCosigner.Text = "Cosigner";
            this.chboxCosigner.UseVisualStyleBackColor = true;
            this.chboxCosigner.CheckedChanged += new System.EventHandler(this.chboxCosigner_CheckedChanged);
            // 
            // chboxShort
            // 
            this.chboxShort.AutoSize = true;
            this.chboxShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxShort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxShort.Location = new System.Drawing.Point(407, 19);
            this.chboxShort.Name = "chboxShort";
            this.chboxShort.Size = new System.Drawing.Size(168, 20);
            this.chboxShort.TabIndex = 9;
            this.chboxShort.Text = "Short time on the job";
            this.chboxShort.UseVisualStyleBackColor = true;
            // 
            // chboxRental
            // 
            this.chboxRental.AutoSize = true;
            this.chboxRental.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chboxRental.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chboxRental.Location = new System.Drawing.Point(219, 19);
            this.chboxRental.Name = "chboxRental";
            this.chboxRental.Size = new System.Drawing.Size(125, 20);
            this.chboxRental.TabIndex = 5;
            this.chboxRental.Text = "Rental History";
            this.chboxRental.UseVisualStyleBackColor = true;
            // 
            // chBoxQualifier
            // 
            this.chBoxQualifier.AutoSize = true;
            this.chBoxQualifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxQualifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chBoxQualifier.Location = new System.Drawing.Point(11, 19);
            this.chBoxQualifier.Name = "chBoxQualifier";
            this.chBoxQualifier.Size = new System.Drawing.Size(168, 20);
            this.chBoxQualifier.TabIndex = 1;
            this.chBoxQualifier.Text = "Qualified Roommate";
            this.chBoxQualifier.UseVisualStyleBackColor = true;
            // 
            // btnRefs
            // 
            this.btnRefs.BackColor = System.Drawing.Color.Silver;
            this.btnRefs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefs.Location = new System.Drawing.Point(-99, -301);
            this.btnRefs.Name = "btnRefs";
            this.btnRefs.Size = new System.Drawing.Size(138, 22);
            this.btnRefs.TabIndex = 185;
            this.btnRefs.Text = "Standard Refs.";
            this.btnRefs.UseVisualStyleBackColor = false;
            // 
            // lblFinalComment
            // 
            this.lblFinalComment.AutoSize = true;
            this.lblFinalComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFinalComment.Location = new System.Drawing.Point(1, 192);
            this.lblFinalComment.Name = "lblFinalComment";
            this.lblFinalComment.Size = new System.Drawing.Size(108, 13);
            this.lblFinalComment.TabIndex = 163;
            this.lblFinalComment.Text = "FINAL  COMMENTS:";
            // 
            // lblAppComments
            // 
            this.lblAppComments.AutoSize = true;
            this.lblAppComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAppComments.Location = new System.Drawing.Point(0, 408);
            this.lblAppComments.Name = "lblAppComments";
            this.lblAppComments.Size = new System.Drawing.Size(102, 13);
            this.lblAppComments.TabIndex = 164;
            this.lblAppComments.Text = "APP.  COMMENTS:";
            // 
            // txtAppComment
            // 
            this.txtAppComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAppComment.Location = new System.Drawing.Point(3, 428);
            this.txtAppComment.Multiline = true;
            this.txtAppComment.Name = "txtAppComment";
            this.txtAppComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAppComment.Size = new System.Drawing.Size(575, 154);
            this.txtAppComment.TabIndex = 15;
            // 
            // btnCriteria
            // 
            this.btnCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCriteria.BackColor = System.Drawing.Color.Yellow;
            this.btnCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriteria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCriteria.Location = new System.Drawing.Point(3, 146);
            this.btnCriteria.Name = "btnCriteria";
            this.btnCriteria.Size = new System.Drawing.Size(135, 29);
            this.btnCriteria.TabIndex = 12;
            this.btnCriteria.Text = "S&pecial Criteria Info";
            this.btnCriteria.UseVisualStyleBackColor = false;
            this.btnCriteria.Click += new System.EventHandler(this.btnCriteria_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // txtFinComment
            // 
            this.txtFinComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtFinComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFinComment.Location = new System.Drawing.Point(4, 214);
            this.txtFinComment.Multiline = true;
            this.txtFinComment.Name = "txtFinComment";
            this.txtFinComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFinComment.Size = new System.Drawing.Size(575, 182);
            this.txtFinComment.TabIndex = 14;
            // 
            // FinalInfoControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtFinComment);
            this.Controls.Add(this.btnCriteria);
            this.Controls.Add(this.txtAppComment);
            this.Controls.Add(this.lblAppComments);
            this.Controls.Add(this.btnSComments);
            this.Controls.Add(this.lblFinalComment);
            this.Controls.Add(this.grpCheckboxs);
            this.Name = "FinalInfoControl";
            this.Size = new System.Drawing.Size(588, 656);
            this.grpCheckboxs.ResumeLayout(false);
            this.grpCheckboxs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSComments;
        private System.Windows.Forms.GroupBox grpCheckboxs;
        private System.Windows.Forms.Button btnRefs;
        private System.Windows.Forms.Label lblFinalComment;
        private System.Windows.Forms.CheckBox chboxFalse;
        private System.Windows.Forms.CheckBox chboxAbs;
        private System.Windows.Forms.CheckBox chboxCriminal;
        private System.Windows.Forms.CheckBox chboxRent;
        private System.Windows.Forms.CheckBox chboxFirst;
        private System.Windows.Forms.CheckBox chboxLack;
        private System.Windows.Forms.CheckBox chboxCredit;
        private System.Windows.Forms.CheckBox chboxCosigner;
        private System.Windows.Forms.CheckBox chboxShort;
        private System.Windows.Forms.CheckBox chboxRental;
        private System.Windows.Forms.CheckBox chBoxQualifier;
        private System.Windows.Forms.Label lblAppComments;
        private System.Windows.Forms.TextBox txtAppComment;
        private System.Windows.Forms.Button btnCriteria;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.TextBox txtFinComment;
    }
}
