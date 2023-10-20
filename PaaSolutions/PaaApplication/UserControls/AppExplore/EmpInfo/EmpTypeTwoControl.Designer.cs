namespace PaaApplication.UserControls.AppExplore.EmpInfo
{
    partial class EmpTypeTwoControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpTypeTwoControl));
            this.btnRefs = new System.Windows.Forms.Button();
            this.txtSW = new System.Windows.Forms.TextBox();
            this.lblSW = new System.Windows.Forms.Label();
            this.lblEmployer = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.txtEmployer = new System.Windows.Forms.TextBox();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.lblPos = new System.Windows.Forms.Label();
            this.txtTerm = new System.Windows.Forms.TextBox();
            this.lblTerm = new System.Windows.Forms.Label();
            this.txtHired = new System.Windows.Forms.TextBox();
            this.lblHired = new System.Windows.Forms.Label();
            this.txtRH = new System.Windows.Forms.TextBox();
            this.lblRH = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.lblMoney = new System.Windows.Forms.Label();
            this.txtFT = new System.Windows.Forms.TextBox();
            this.lblFT = new System.Windows.Forms.Label();
            this.btnDelRef = new System.Windows.Forms.Button();
            this.btnAddRef = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblEmployment = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtComment = new System.Windows.Forms.RichTextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRefs
            // 
            this.btnRefs.BackColor = System.Drawing.Color.Silver;
            this.btnRefs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefs.Location = new System.Drawing.Point(240, 15);
            this.btnRefs.Name = "btnRefs";
            this.btnRefs.Size = new System.Drawing.Size(138, 28);
            this.btnRefs.TabIndex = 2;
            this.btnRefs.Text = "Standard Refs.";
            this.btnRefs.UseVisualStyleBackColor = false;
            this.btnRefs.Click += new System.EventHandler(this.btnRefs_Click);
            // 
            // txtSW
            // 
            this.txtSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSW.Location = new System.Drawing.Point(10, 195);
            this.txtSW.Name = "txtSW";
            this.txtSW.Size = new System.Drawing.Size(200, 24);
            this.txtSW.TabIndex = 2;
            // 
            // lblSW
            // 
            this.lblSW.AutoSize = true;
            this.lblSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSW.Location = new System.Drawing.Point(8, 176);
            this.lblSW.Name = "lblSW";
            this.lblSW.Size = new System.Drawing.Size(33, 13);
            this.lblSW.TabIndex = 0;
            this.lblSW.Text = "S/W:";
            // 
            // lblEmployer
            // 
            this.lblEmployer.AutoSize = true;
            this.lblEmployer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmployer.Location = new System.Drawing.Point(61, 54);
            this.lblEmployer.Name = "lblEmployer";
            this.lblEmployer.Size = new System.Drawing.Size(148, 26);
            this.lblEmployer.TabIndex = 0;
            this.lblEmployer.Text = "EMPLOYER  /  REFERENCE\r\nINFORMATION:";
            this.lblEmployer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblReference.Location = new System.Drawing.Point(422, 21);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(84, 16);
            this.lblReference.TabIndex = 129;
            this.lblReference.Text = "Reference:";
            // 
            // txtEmployer
            // 
            this.txtEmployer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmployer.Location = new System.Drawing.Point(240, 54);
            this.txtEmployer.Multiline = true;
            this.txtEmployer.Name = "txtEmployer";
            this.txtEmployer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmployer.Size = new System.Drawing.Size(335, 125);
            this.txtEmployer.TabIndex = 1;
            // 
            // txtPos
            // 
            this.txtPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPos.Location = new System.Drawing.Point(10, 254);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(200, 24);
            this.txtPos.TabIndex = 3;
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPos.Location = new System.Drawing.Point(8, 234);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(32, 13);
            this.lblPos.TabIndex = 0;
            this.lblPos.Text = "POS:";
            // 
            // txtTerm
            // 
            this.txtTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTerm.Location = new System.Drawing.Point(11, 371);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(200, 24);
            this.txtTerm.TabIndex = 5;
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTerm.Location = new System.Drawing.Point(9, 351);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(41, 13);
            this.lblTerm.TabIndex = 0;
            this.lblTerm.Text = "TERM:";
            // 
            // txtHired
            // 
            this.txtHired.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHired.Location = new System.Drawing.Point(11, 313);
            this.txtHired.Name = "txtHired";
            this.txtHired.Size = new System.Drawing.Size(200, 24);
            this.txtHired.TabIndex = 4;
            // 
            // lblHired
            // 
            this.lblHired.AutoSize = true;
            this.lblHired.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHired.Location = new System.Drawing.Point(9, 293);
            this.lblHired.Name = "lblHired";
            this.lblHired.Size = new System.Drawing.Size(44, 13);
            this.lblHired.TabIndex = 0;
            this.lblHired.Text = "HIRED:";
            // 
            // txtRH
            // 
            this.txtRH.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRH.Location = new System.Drawing.Point(13, 548);
            this.txtRH.Name = "txtRH";
            this.txtRH.Size = new System.Drawing.Size(200, 24);
            this.txtRH.TabIndex = 8;
            // 
            // lblRH
            // 
            this.lblRH.AutoSize = true;
            this.lblRH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRH.Location = new System.Drawing.Point(11, 528);
            this.lblRH.Name = "lblRH";
            this.lblRH.Size = new System.Drawing.Size(26, 13);
            this.lblRH.TabIndex = 0;
            this.lblRH.Text = "RH:";
            // 
            // txtMoney
            // 
            this.txtMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMoney.Location = new System.Drawing.Point(13, 489);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(200, 24);
            this.txtMoney.TabIndex = 7;
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMoney.Location = new System.Drawing.Point(11, 469);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(22, 13);
            this.lblMoney.TabIndex = 0;
            this.lblMoney.Text = "$$:";
            // 
            // txtFT
            // 
            this.txtFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFT.Location = new System.Drawing.Point(12, 430);
            this.txtFT.Name = "txtFT";
            this.txtFT.Size = new System.Drawing.Size(200, 24);
            this.txtFT.TabIndex = 6;
            // 
            // lblFT
            // 
            this.lblFT.AutoSize = true;
            this.lblFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFT.Location = new System.Drawing.Point(10, 410);
            this.lblFT.Name = "lblFT";
            this.lblFT.Size = new System.Drawing.Size(23, 13);
            this.lblFT.TabIndex = 0;
            this.lblFT.Text = "FT:";
            // 
            // btnDelRef
            // 
            this.btnDelRef.BackColor = System.Drawing.Color.Gray;
            this.btnDelRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelRef.ForeColor = System.Drawing.Color.White;
            this.btnDelRef.Location = new System.Drawing.Point(481, 512);
            this.btnDelRef.Name = "btnDelRef";
            this.btnDelRef.Size = new System.Drawing.Size(70, 29);
            this.btnDelRef.TabIndex = 11;
            this.btnDelRef.Text = "Delete";
            this.btnDelRef.UseVisualStyleBackColor = false;
            this.btnDelRef.Click += new System.EventHandler(this.btnDelRef_Click);
            // 
            // btnAddRef
            // 
            this.btnAddRef.BackColor = System.Drawing.Color.Gray;
            this.btnAddRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRef.ForeColor = System.Drawing.Color.White;
            this.btnAddRef.Location = new System.Drawing.Point(399, 512);
            this.btnAddRef.Name = "btnAddRef";
            this.btnAddRef.Size = new System.Drawing.Size(70, 29);
            this.btnAddRef.TabIndex = 10;
            this.btnAddRef.Text = "New";
            this.btnAddRef.UseVisualStyleBackColor = false;
            this.btnAddRef.Click += new System.EventHandler(this.btnAddRef_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(491, 547);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(60, 29);
            this.btnNext.TabIndex = 15;
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(255, 547);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(60, 29);
            this.btnPrevious.TabIndex = 12;
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblEmployment
            // 
            this.lblEmployment.AutoSize = true;
            this.lblEmployment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblEmployment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmployment.Location = new System.Drawing.Point(520, 22);
            this.lblEmployment.Name = "lblEmployment";
            this.lblEmployment.Size = new System.Drawing.Size(51, 16);
            this.lblEmployment.TabIndex = 132;
            this.lblEmployment.Text = "label1";
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtComment.Location = new System.Drawing.Point(240, 197);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(335, 298);
            this.txtComment.TabIndex = 9;
            this.txtComment.Text = "";
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::PaaApplication.Properties.Resources.copy_doc;
            this.btnCopy.Location = new System.Drawing.Point(255, 501);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(60, 40);
            this.btnCopy.TabIndex = 165;
            this.btnCopy.TabStop = false;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCopy_MouseDown);
            // 
            // btnUp
            // 
            this.btnUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(337, 547);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(55, 29);
            this.btnUp.TabIndex = 13;
            this.btnUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(414, 547);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(55, 29);
            this.btnDown.TabIndex = 14;
            this.btnDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // EmpTypeTwoControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblEmployment);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnDelRef);
            this.Controls.Add(this.btnAddRef);
            this.Controls.Add(this.txtRH);
            this.Controls.Add(this.lblRH);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.txtFT);
            this.Controls.Add(this.lblFT);
            this.Controls.Add(this.txtTerm);
            this.Controls.Add(this.lblTerm);
            this.Controls.Add(this.txtHired);
            this.Controls.Add(this.lblHired);
            this.Controls.Add(this.txtPos);
            this.Controls.Add(this.lblPos);
            this.Controls.Add(this.txtEmployer);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.lblEmployer);
            this.Controls.Add(this.btnRefs);
            this.Controls.Add(this.txtSW);
            this.Controls.Add(this.lblSW);
            this.Name = "EmpTypeTwoControl";
            this.Size = new System.Drawing.Size(588, 656);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefs;
        private System.Windows.Forms.TextBox txtSW;
        private System.Windows.Forms.Label lblSW;
        private System.Windows.Forms.Label lblEmployer;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox txtEmployer;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.TextBox txtTerm;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.TextBox txtHired;
        private System.Windows.Forms.Label lblHired;
        private System.Windows.Forms.TextBox txtRH;
        private System.Windows.Forms.Label lblRH;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.TextBox txtFT;
        private System.Windows.Forms.Label lblFT;
        private System.Windows.Forms.Button btnDelRef;
        private System.Windows.Forms.Button btnAddRef;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblEmployment;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.RichTextBox txtComment;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
    }
}
