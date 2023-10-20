namespace PaaApplication.Forms
{
    partial class FormMultipleDocumentComplete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMultipleDocumentComplete));
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.lblCopies = new System.Windows.Forms.Label();
            this.nudCopies = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboxClientMails = new System.Windows.Forms.ComboBox();
            this.cboxClients = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblClientEmail = new System.Windows.Forms.Label();
            this.pnlEmailOptions = new System.Windows.Forms.Panel();
            this.pnlButtonGroup = new System.Windows.Forms.Panel();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.errpdDocumentReportComplete = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudCopies)).BeginInit();
            this.pnlEmailOptions.SuspendLayout();
            this.pnlButtonGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errpdDocumentReportComplete)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Navy;
            this.lblMessage.Location = new System.Drawing.Point(9, 3);
            this.lblMessage.MaximumSize = new System.Drawing.Size(450, 36);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(68, 18);
            this.lblMessage.TabIndex = 100;
            this.lblMessage.Text = "Message";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(36, 45);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPrint.Size = new System.Drawing.Size(106, 35);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.White;
            this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmail.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnEmail.Image")));
            this.btnEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmail.Location = new System.Drawing.Point(168, 45);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEmail.Size = new System.Drawing.Size(106, 35);
            this.btnEmail.TabIndex = 2;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // lblCopies
            // 
            this.lblCopies.AutoSize = true;
            this.lblCopies.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCopies.Location = new System.Drawing.Point(10, 99);
            this.lblCopies.Name = "lblCopies";
            this.lblCopies.Size = new System.Drawing.Size(74, 18);
            this.lblCopies.TabIndex = 100;
            this.lblCopies.Text = "# of Copies";
            // 
            // nudCopies
            // 
            this.nudCopies.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCopies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudCopies.Location = new System.Drawing.Point(84, 97);
            this.nudCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopies.Name = "nudCopies";
            this.nudCopies.Size = new System.Drawing.Size(58, 24);
            this.nudCopies.TabIndex = 4;
            this.nudCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Gray;
            this.btnOK.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(330, 88);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(43, 29);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(381, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboxClientMails
            // 
            this.cboxClientMails.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxClientMails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboxClientMails.FormattingEnabled = true;
            this.cboxClientMails.Location = new System.Drawing.Point(168, 35);
            this.cboxClientMails.Name = "cboxClientMails";
            this.cboxClientMails.Size = new System.Drawing.Size(279, 24);
            this.cboxClientMails.TabIndex = 8;
            this.cboxClientMails.TextChanged += new System.EventHandler(this.cboxClientMails_TextChanged);
            this.cboxClientMails.Validating += new System.ComponentModel.CancelEventHandler(this.cboxClientMails_Validating);
            // 
            // cboxClients
            // 
            this.cboxClients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboxClients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboxClients.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboxClients.FormattingEnabled = true;
            this.cboxClients.Location = new System.Drawing.Point(168, 68);
            this.cboxClients.Name = "cboxClients";
            this.cboxClients.Size = new System.Drawing.Size(279, 24);
            this.cboxClients.TabIndex = 9;
            this.cboxClients.SelectedIndexChanged += new System.EventHandler(this.cboxClients_SelectedIndexChanged);
            this.cboxClients.TextChanged += new System.EventHandler(this.cboxClients_TextChanged);
            this.cboxClients.Leave += new System.EventHandler(this.cboxClients_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(63, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 100;
            this.label1.Text = "E-MAIL  ADDRESS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(48, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 100;
            this.label2.Text = "AVAILABLE  CLIENTS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(4, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 15);
            this.label3.TabIndex = 100;
            this.label3.Text = "EMAIL  DOCUMENT  TO: ";
            // 
            // lblClientEmail
            // 
            this.lblClientEmail.AutoSize = true;
            this.lblClientEmail.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientEmail.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblClientEmail.Location = new System.Drawing.Point(135, 5);
            this.lblClientEmail.Name = "lblClientEmail";
            this.lblClientEmail.Size = new System.Drawing.Size(0, 18);
            this.lblClientEmail.TabIndex = 0;
            // 
            // pnlEmailOptions
            // 
            this.pnlEmailOptions.Controls.Add(this.cboxClients);
            this.pnlEmailOptions.Controls.Add(this.lblClientEmail);
            this.pnlEmailOptions.Controls.Add(this.cboxClientMails);
            this.pnlEmailOptions.Controls.Add(this.label3);
            this.pnlEmailOptions.Controls.Add(this.label1);
            this.pnlEmailOptions.Controls.Add(this.label2);
            this.pnlEmailOptions.Location = new System.Drawing.Point(6, 3);
            this.pnlEmailOptions.Name = "pnlEmailOptions";
            this.pnlEmailOptions.Size = new System.Drawing.Size(465, 110);
            this.pnlEmailOptions.TabIndex = 107;
            this.pnlEmailOptions.Visible = false;
            // 
            // pnlButtonGroup
            // 
            this.pnlButtonGroup.Controls.Add(this.chkPDF);
            this.pnlButtonGroup.Controls.Add(this.btnPrint);
            this.pnlButtonGroup.Controls.Add(this.lblMessage);
            this.pnlButtonGroup.Controls.Add(this.btnCancel);
            this.pnlButtonGroup.Controls.Add(this.btnOK);
            this.pnlButtonGroup.Controls.Add(this.btnEmail);
            this.pnlButtonGroup.Controls.Add(this.nudCopies);
            this.pnlButtonGroup.Controls.Add(this.lblCopies);
            this.pnlButtonGroup.Location = new System.Drawing.Point(6, 119);
            this.pnlButtonGroup.Name = "pnlButtonGroup";
            this.pnlButtonGroup.Size = new System.Drawing.Size(465, 135);
            this.pnlButtonGroup.TabIndex = 108;
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPDF.ForeColor = System.Drawing.Color.Red;
            this.chkPDF.Location = new System.Drawing.Point(168, 99);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(73, 22);
            this.chkPDF.TabIndex = 100;
            this.chkPDF.Text = "In PDF";
            this.chkPDF.UseVisualStyleBackColor = true;
            this.chkPDF.CheckedChanged += new System.EventHandler(this.chkPDF_CheckedChanged);
            // 
            // errpdDocumentReportComplete
            // 
            this.errpdDocumentReportComplete.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errpdDocumentReportComplete.ContainerControl = this;
            // 
            // FormMultipleDocumentComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 263);
            this.Controls.Add(this.pnlButtonGroup);
            this.Controls.Add(this.pnlEmailOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMultipleDocumentComplete";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Document Complete!";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormDocumentComplete_LoadCompleted);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDocumentComplete_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudCopies)).EndInit();
            this.pnlEmailOptions.ResumeLayout(false);
            this.pnlEmailOptions.PerformLayout();
            this.pnlButtonGroup.ResumeLayout(false);
            this.pnlButtonGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errpdDocumentReportComplete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label lblCopies;
        private System.Windows.Forms.NumericUpDown nudCopies;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboxClientMails;
        private System.Windows.Forms.ComboBox cboxClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblClientEmail;
        private System.Windows.Forms.Panel pnlEmailOptions;
        private System.Windows.Forms.Panel pnlButtonGroup;
        private System.Windows.Forms.ErrorProvider errpdDocumentReportComplete;
        private System.Windows.Forms.CheckBox chkPDF;
    }
}