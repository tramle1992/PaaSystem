
namespace PaaApplication.Forms
{
    partial class FormEditInfoResources
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.lblOther = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.errpdEditInfoRs = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnCopyFax = new System.Windows.Forms.Button();
            this.ttCopyFax = new System.Windows.Forms.ToolTip(this.components);
            this.btnCopyPhone = new System.Windows.Forms.Button();
            this.btnCopyEmail = new System.Windows.Forms.Button();
            this.btnCopyOther = new System.Windows.Forms.Button();
            this.btnCopyName = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errpdEditInfoRs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(301, 327);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gray;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(219, 327);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtOther
            // 
            this.txtOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOther.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOther.Location = new System.Drawing.Point(17, 247);
            this.txtOther.MaxLength = 1000;
            this.txtOther.Multiline = true;
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(321, 66);
            this.txtOther.TabIndex = 4;
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOther.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOther.Location = new System.Drawing.Point(14, 229);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(48, 13);
            this.lblOther.TabIndex = 66;
            this.lblOther.Text = "OTHER:";
            // 
            // txtTarget
            // 
            this.txtTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTarget.Location = new System.Drawing.Point(15, 88);
            this.txtTarget.MaxLength = 250;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(321, 21);
            this.txtTarget.TabIndex = 1;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTarget.Location = new System.Drawing.Point(13, 69);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(30, 13);
            this.lblTarget.TabIndex = 64;
            this.lblTarget.Text = "FAX:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtName.Location = new System.Drawing.Point(14, 33);
            this.txtName.MaxLength = 250;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(235, 21);
            this.txtName.TabIndex = 0;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUpdate_ItemName_Validating);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblName.Location = new System.Drawing.Point(12, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 62;
            this.lblName.Text = "NAME:";
            // 
            // errpdEditInfoRs
            // 
            this.errpdEditInfoRs.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errpdEditInfoRs.ContainerControl = this;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPhone.Location = new System.Drawing.Point(16, 140);
            this.txtPhone.MaxLength = 250;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(321, 21);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtUpdate_ItemPhone_Validating);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPhone.Location = new System.Drawing.Point(14, 121);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(48, 13);
            this.lblPhone.TabIndex = 68;
            this.lblPhone.Text = "PHONE:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmail.Location = new System.Drawing.Point(17, 194);
            this.txtEmail.MaxLength = 250;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(321, 21);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtUpdate_ItemEmail_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmail.Location = new System.Drawing.Point(15, 175);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 13);
            this.lblEmail.TabIndex = 70;
            this.lblEmail.Text = "EMAIL:";
            // 
            // btnCopyFax
            // 
            this.btnCopyFax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCopyFax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyFax.FlatAppearance.BorderSize = 0;
            this.btnCopyFax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyFax.Image = global::PaaApplication.Properties.Resources.copy3;
            this.btnCopyFax.Location = new System.Drawing.Point(348, 86);
            this.btnCopyFax.Name = "btnCopyFax";
            this.btnCopyFax.Size = new System.Drawing.Size(34, 23);
            this.btnCopyFax.TabIndex = 71;
            this.ttCopyFax.SetToolTip(this.btnCopyFax, "Copy Fax to clipboard");
            this.btnCopyFax.UseVisualStyleBackColor = false;
            this.btnCopyFax.Click += new System.EventHandler(this.btnCopyFax_Click);
            this.btnCopyFax.MouseEnter += new System.EventHandler(this.btnCopyFax_MouseEnter);
            this.btnCopyFax.MouseLeave += new System.EventHandler(this.btnCopyFax_MouseLeave);
            // 
            // ttCopyFax
            // 
            this.ttCopyFax.ToolTipTitle = "Copy";
            // 
            // btnCopyPhone
            // 
            this.btnCopyPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCopyPhone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyPhone.FlatAppearance.BorderSize = 0;
            this.btnCopyPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyPhone.Image = global::PaaApplication.Properties.Resources.copy3;
            this.btnCopyPhone.Location = new System.Drawing.Point(348, 138);
            this.btnCopyPhone.Name = "btnCopyPhone";
            this.btnCopyPhone.Size = new System.Drawing.Size(34, 23);
            this.btnCopyPhone.TabIndex = 72;
            this.ttCopyFax.SetToolTip(this.btnCopyPhone, "Copy Phone to clipboard");
            this.btnCopyPhone.UseVisualStyleBackColor = false;
            this.btnCopyPhone.Click += new System.EventHandler(this.btnCopyPhone_Click);
            this.btnCopyPhone.MouseEnter += new System.EventHandler(this.btnCopyPhone_MouseEnter);
            this.btnCopyPhone.MouseLeave += new System.EventHandler(this.btnCopyPhone_MouseLeave);
            // 
            // btnCopyEmail
            // 
            this.btnCopyEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCopyEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyEmail.FlatAppearance.BorderSize = 0;
            this.btnCopyEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyEmail.Image = global::PaaApplication.Properties.Resources.copy3;
            this.btnCopyEmail.Location = new System.Drawing.Point(348, 192);
            this.btnCopyEmail.Name = "btnCopyEmail";
            this.btnCopyEmail.Size = new System.Drawing.Size(34, 23);
            this.btnCopyEmail.TabIndex = 73;
            this.ttCopyFax.SetToolTip(this.btnCopyEmail, "Copy Email to clipboard");
            this.btnCopyEmail.UseVisualStyleBackColor = false;
            this.btnCopyEmail.Click += new System.EventHandler(this.btnCopyEmail_Click);
            this.btnCopyEmail.MouseEnter += new System.EventHandler(this.btnCopyEmail_MouseEnter);
            this.btnCopyEmail.MouseLeave += new System.EventHandler(this.btnCopyEmail_MouseLeave);
            // 
            // btnCopyOther
            // 
            this.btnCopyOther.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCopyOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyOther.FlatAppearance.BorderSize = 0;
            this.btnCopyOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyOther.Image = global::PaaApplication.Properties.Resources.copy3;
            this.btnCopyOther.Location = new System.Drawing.Point(348, 268);
            this.btnCopyOther.Name = "btnCopyOther";
            this.btnCopyOther.Size = new System.Drawing.Size(34, 23);
            this.btnCopyOther.TabIndex = 74;
            this.ttCopyFax.SetToolTip(this.btnCopyOther, "Copy Other to clipboard");
            this.btnCopyOther.UseVisualStyleBackColor = false;
            this.btnCopyOther.Click += new System.EventHandler(this.btnCopyOther_Click);
            this.btnCopyOther.MouseEnter += new System.EventHandler(this.btnCopyOther_MouseEnter);
            this.btnCopyOther.MouseLeave += new System.EventHandler(this.btnCopyOther_MouseLeave);
            // 
            // btnCopyName
            // 
            this.btnCopyName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCopyName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyName.FlatAppearance.BorderSize = 0;
            this.btnCopyName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyName.Image = global::PaaApplication.Properties.Resources.copy3;
            this.btnCopyName.Location = new System.Drawing.Point(348, 33);
            this.btnCopyName.Name = "btnCopyName";
            this.btnCopyName.Size = new System.Drawing.Size(34, 21);
            this.btnCopyName.TabIndex = 75;
            this.ttCopyFax.SetToolTip(this.btnCopyName, "Copy Name to clipboard");
            this.btnCopyName.UseVisualStyleBackColor = false;
            this.btnCopyName.Click += new System.EventHandler(this.btnCopyName_Click);
            this.btnCopyName.MouseEnter += new System.EventHandler(this.btnCopyName_MouseEnter);
            this.btnCopyName.MouseLeave += new System.EventHandler(this.btnCopyName_MouseLeave);
            // 
            // FormEditInfoResources
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 368);
            this.Controls.Add(this.btnCopyName);
            this.Controls.Add(this.btnCopyOther);
            this.Controls.Add(this.btnCopyEmail);
            this.Controls.Add(this.btnCopyPhone);
            this.Controls.Add(this.btnCopyFax);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtOther);
            this.Controls.Add(this.lblOther);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEditInfoResources";
            this.Text = "Edit Resource";
            this.Shown += new System.EventHandler(this.FormEditInfoResources_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errpdEditInfoRs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ErrorProvider errpdEditInfoRs;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Button btnCopyFax;
        private System.Windows.Forms.ToolTip ttCopyFax;
        private System.Windows.Forms.Button btnCopyOther;
        private System.Windows.Forms.Button btnCopyEmail;
        private System.Windows.Forms.Button btnCopyPhone;
        private System.Windows.Forms.Button btnCopyName;
    }
}