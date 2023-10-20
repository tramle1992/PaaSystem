namespace PaaApplication.Forms.Invoicing
{
    partial class FormInvPrint
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.listBoxPrint = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPrint = new System.Windows.Forms.NumericUpDown();
            this.picInvoices = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.BackColor = System.Drawing.Color.Gray;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(542, 367);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 29);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(15, 428);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(602, 30);
            this.progressBar.TabIndex = 5;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelStatus.Location = new System.Drawing.Point(13, 469);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(96, 20);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Please wait...";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPrint.BackColor = System.Drawing.Color.Gray;
            this.buttonPrint.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Location = new System.Drawing.Point(453, 367);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 29);
            this.buttonPrint.TabIndex = 7;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // listBoxPrint
            // 
            this.listBoxPrint.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.listBoxPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBoxPrint.FormattingEnabled = true;
            this.listBoxPrint.ItemHeight = 20;
            this.listBoxPrint.Location = new System.Drawing.Point(15, 12);
            this.listBoxPrint.Name = "listBoxPrint";
            this.listBoxPrint.Size = new System.Drawing.Size(313, 384);
            this.listBoxPrint.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(467, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Copies to Print";
            // 
            // numericUpDownPrint
            // 
            this.numericUpDownPrint.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.numericUpDownPrint.Location = new System.Drawing.Point(580, 275);
            this.numericUpDownPrint.Name = "numericUpDownPrint";
            this.numericUpDownPrint.Size = new System.Drawing.Size(37, 28);
            this.numericUpDownPrint.TabIndex = 10;
            this.numericUpDownPrint.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // picInvoices
            // 
            this.picInvoices.Image = global::PaaApplication.Properties.Resources.invoices;
            this.picInvoices.Location = new System.Drawing.Point(342, 12);
            this.picInvoices.Name = "picInvoices";
            this.picInvoices.Size = new System.Drawing.Size(275, 248);
            this.picInvoices.TabIndex = 21;
            this.picInvoices.TabStop = false;
            // 
            // FormInvPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 511);
            this.ControlBox = false;
            this.Controls.Add(this.picInvoices);
            this.Controls.Add(this.numericUpDownPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxPrint);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInvPrint";
            this.Text = "Print Invoice";
            this.Load += new System.EventHandler(this.FormProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInvoices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.ListBox listBoxPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPrint;
        private System.Windows.Forms.PictureBox picInvoices;
    }
}