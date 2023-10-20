using PaaApplication.Helper;
namespace PaaApplication.UserControls.AppExplore.ApplicantInfo
{
    partial class PartTwoControl
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
            this.lblDOB = new System.Windows.Forms.Label();
            this.txtSSN = new System.Windows.Forms.MaskedTextBox();
            this.lblSSN = new System.Windows.Forms.Label();
            this.txtMidName = new System.Windows.Forms.TextBox();
            this.lblMidName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFName = new System.Windows.Forms.Label();
            this.txtBirthday = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkbPdxInd = new System.Windows.Forms.CheckBox();
            this.cmbInvoice2 = new System.Windows.Forms.ComboBox();
            this.lblInvoice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDOB.Location = new System.Drawing.Point(8, 67);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(65, 13);
            this.lblDOB.TabIndex = 0;
            this.lblDOB.Text = "BIRTHDAY:";
            // 
            // txtSSN
            // 
            this.txtSSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSSN.Location = new System.Drawing.Point(461, 28);
            this.txtSSN.Mask = "000-00-0000";
            this.txtSSN.Name = "txtSSN";
            this.txtSSN.Size = new System.Drawing.Size(104, 24);
            this.txtSSN.TabIndex = 7;
            this.txtSSN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSSN_MouseClick);
            this.txtSSN.Leave += new System.EventHandler(this.txtSSN_Leave);
            // 
            // lblSSN
            // 
            this.lblSSN.AutoSize = true;
            this.lblSSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSSN.Location = new System.Drawing.Point(459, 8);
            this.lblSSN.Name = "lblSSN";
            this.lblSSN.Size = new System.Drawing.Size(32, 13);
            this.lblSSN.TabIndex = 0;
            this.lblSSN.Text = "SSN:";
            // 
            // txtMidName
            // 
            this.txtMidName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMidName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMidName.Location = new System.Drawing.Point(404, 28);
            this.txtMidName.Name = "txtMidName";
            this.txtMidName.Size = new System.Drawing.Size(40, 24);
            this.txtMidName.TabIndex = 6;
            this.txtMidName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMidName_MouseClick);
            this.txtMidName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleCaseTextBox_KeyPress);
            // 
            // lblMidName
            // 
            this.lblMidName.AutoSize = true;
            this.lblMidName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMidName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMidName.Location = new System.Drawing.Point(400, 9);
            this.lblMidName.Name = "lblMidName";
            this.lblMidName.Size = new System.Drawing.Size(19, 13);
            this.lblMidName.TabIndex = 0;
            this.lblMidName.Text = "M.";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFirstName.Location = new System.Drawing.Point(232, 28);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(153, 24);
            this.txtFirstName.TabIndex = 5;
            this.txtFirstName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtFirstName_MouseClick);
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleCaseTextBox_KeyPress);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFirstName.Location = new System.Drawing.Point(229, 9);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(78, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "FIRST  NAME:";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLastName.Location = new System.Drawing.Point(11, 28);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(203, 24);
            this.txtLastName.TabIndex = 4;
            this.txtLastName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLastName_MouseClick);
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleCaseTextBox_KeyPress);
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFName.Location = new System.Drawing.Point(9, 9);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(74, 13);
            this.lblFName.TabIndex = 0;
            this.lblFName.Text = "LAST  NAME:";
            // 
            // txtBirthday
            // 
            this.txtBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBirthday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBirthday.Location = new System.Drawing.Point(11, 85);
            this.txtBirthday.Mask = "00/00/0000";
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(130, 24);
            this.txtBirthday.TabIndex = 8;
            this.txtBirthday.ValidatingType = typeof(System.DateTime);
            this.txtBirthday.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.txtBirthday_TypeValidationCompleted);
            this.txtBirthday.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtBirthday_MouseClick);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // chkbPdxInd
            // 
            this.chkbPdxInd.AutoSize = true;
            this.chkbPdxInd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbPdxInd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkbPdxInd.Location = new System.Drawing.Point(493, 89);
            this.chkbPdxInd.Name = "chkbPdxInd";
            this.chkbPdxInd.Size = new System.Drawing.Size(48, 17);
            this.chkbPdxInd.TabIndex = 10;
            this.chkbPdxInd.Text = "PDX";
            this.chkbPdxInd.UseVisualStyleBackColor = true;
            // 
            // cmbInvoice2
            // 
            this.cmbInvoice2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInvoice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInvoice2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbInvoice2.FormattingEnabled = true;
            this.cmbInvoice2.Location = new System.Drawing.Point(170, 85);
            this.cmbInvoice2.Name = "cmbInvoice2";
            this.cmbInvoice2.Size = new System.Drawing.Size(288, 24);
            this.cmbInvoice2.TabIndex = 9;
            this.cmbInvoice2.SelectionChangeCommitted += new System.EventHandler(this.cmbInvoice2_SelectionChangeCommitted);
            this.cmbInvoice2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbInvoice2_KeyDown);
            this.cmbInvoice2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbInvoice2_KeyPress);
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInvoice.Location = new System.Drawing.Point(167, 67);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(103, 13);
            this.lblInvoice.TabIndex = 10;
            this.lblInvoice.Text = "INVOICE DIVISION:";
            // 
            // PartTwoControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbInvoice2);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.chkbPdxInd);
            this.Controls.Add(this.txtBirthday);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.txtSSN);
            this.Controls.Add(this.lblSSN);
            this.Controls.Add(this.txtMidName);
            this.Controls.Add(this.lblMidName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblFName);
            this.Name = "PartTwoControl";
            this.Size = new System.Drawing.Size(585, 120);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.MaskedTextBox txtSSN;
        private System.Windows.Forms.Label lblSSN;
        private System.Windows.Forms.TextBox txtMidName;
        private System.Windows.Forms.Label lblMidName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.MaskedTextBox txtBirthday;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox chkbPdxInd;
        private System.Windows.Forms.ComboBox cmbInvoice2;
        private System.Windows.Forms.Label lblInvoice;
    }
}
