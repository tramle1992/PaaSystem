namespace PaaApplication.UserControls.AppExplore
{
    partial class PartOneControl
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
            this.btnSpecialEntry = new System.Windows.Forms.Button();
            this.txtCustPhone = new System.Windows.Forms.TextBox();
            this.lblCustPhone = new System.Windows.Forms.Label();
            this.btnClientInfo = new System.Windows.Forms.Button();
            this.lblClientName = new System.Windows.Forms.Label();
            this.cmbClientApplied = new System.Windows.Forms.ComboBox();
            this.lnkViewCredit = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnSpecialEntry
            // 
            this.btnSpecialEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpecialEntry.BackColor = System.Drawing.Color.Yellow;
            this.btnSpecialEntry.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpecialEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSpecialEntry.Location = new System.Drawing.Point(293, 12);
            this.btnSpecialEntry.Name = "btnSpecialEntry";
            this.btnSpecialEntry.Size = new System.Drawing.Size(112, 40);
            this.btnSpecialEntry.TabIndex = 0;
            this.btnSpecialEntry.Text = "Special Entry";
            this.btnSpecialEntry.UseVisualStyleBackColor = false;
            this.btnSpecialEntry.Click += new System.EventHandler(this.btnSpecialEntry_Click);
            // 
            // txtCustPhone
            // 
            this.txtCustPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustPhone.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCustPhone.Location = new System.Drawing.Point(421, 81);
            this.txtCustPhone.Name = "txtCustPhone";
            this.txtCustPhone.ReadOnly = true;
            this.txtCustPhone.Size = new System.Drawing.Size(151, 28);
            this.txtCustPhone.TabIndex = 3;
            this.txtCustPhone.TabStop = false;
            // 
            // lblCustPhone
            // 
            this.lblCustPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustPhone.AutoSize = true;
            this.lblCustPhone.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCustPhone.Location = new System.Drawing.Point(418, 61);
            this.lblCustPhone.Name = "lblCustPhone";
            this.lblCustPhone.Size = new System.Drawing.Size(94, 15);
            this.lblCustPhone.TabIndex = 0;
            this.lblCustPhone.Text = "CLIENT  PHONE:";
            // 
            // btnClientInfo
            // 
            this.btnClientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientInfo.BackColor = System.Drawing.Color.Gray;
            this.btnClientInfo.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientInfo.ForeColor = System.Drawing.Color.White;
            this.btnClientInfo.Location = new System.Drawing.Point(414, 12);
            this.btnClientInfo.Name = "btnClientInfo";
            this.btnClientInfo.Size = new System.Drawing.Size(158, 40);
            this.btnClientInfo.TabIndex = 1;
            this.btnClientInfo.Text = "Client Information";
            this.btnClientInfo.UseVisualStyleBackColor = false;
            this.btnClientInfo.Click += new System.EventHandler(this.btnClientInfo_Click);
            // 
            // lblClientName
            // 
            this.lblClientName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblClientName.Location = new System.Drawing.Point(9, 61);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(134, 15);
            this.lblClientName.TabIndex = 0;
            this.lblClientName.Text = "CLIENT  APPLIED  WITH:";
            // 
            // cmbClientApplied
            // 
            this.cmbClientApplied.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbClientApplied.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClientApplied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbClientApplied.FormattingEnabled = true;
            this.cmbClientApplied.Location = new System.Drawing.Point(11, 81);
            this.cmbClientApplied.Name = "cmbClientApplied";
            this.cmbClientApplied.Size = new System.Drawing.Size(397, 28);
            this.cmbClientApplied.TabIndex = 2;
            this.cmbClientApplied.SelectedIndexChanged += new System.EventHandler(this.cmbClientApplied_SelectedIndexChanged);
            this.cmbClientApplied.SelectionChangeCommitted += new System.EventHandler(this.cmbClientApplied_SelectionChangeCommitted);
            this.cmbClientApplied.Enter += new System.EventHandler(this.cmbClientApplied_Enter);
            this.cmbClientApplied.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbClientApplied_KeyPress);
            this.cmbClientApplied.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbClientApplied_KeyUp);
            this.cmbClientApplied.Validating += new System.ComponentModel.CancelEventHandler(this.cmbClientApplied_Validating);
            // 
            // lnkViewCredit
            // 
            this.lnkViewCredit.AutoSize = true;
            this.lnkViewCredit.Location = new System.Drawing.Point(8, 27);
            this.lnkViewCredit.Name = "lnkViewCredit";
            this.lnkViewCredit.Size = new System.Drawing.Size(118, 13);
            this.lnkViewCredit.TabIndex = 4;
            this.lnkViewCredit.TabStop = true;
            this.lnkViewCredit.Text = "View TransUnion Credit";
            this.lnkViewCredit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkViewCredit_LinkClicked);
            // 
            // PartOneControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lnkViewCredit);
            this.Controls.Add(this.btnSpecialEntry);
            this.Controls.Add(this.txtCustPhone);
            this.Controls.Add(this.lblCustPhone);
            this.Controls.Add(this.btnClientInfo);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.cmbClientApplied);
            this.Name = "PartOneControl";
            this.Size = new System.Drawing.Size(585, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSpecialEntry;
        private System.Windows.Forms.TextBox txtCustPhone;
        private System.Windows.Forms.Label lblCustPhone;
        private System.Windows.Forms.Button btnClientInfo;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.ComboBox cmbClientApplied;
        private System.Windows.Forms.LinkLabel lnkViewCredit;
    }
}
