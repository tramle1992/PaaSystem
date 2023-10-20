namespace PaaApplication.Forms.Invoicing
{
    partial class FormNewInvoice
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
            this.lblClientName = new System.Windows.Forms.Label();
            this.btnNewInvoice = new System.Windows.Forms.Button();
            this.btnViewInvoices = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstInvoiceDivisions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(14, 15);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(86, 16);
            this.lblClientName.TabIndex = 100;
            this.lblClientName.Text = "[ClientName]";
            // 
            // btnNewInvoice
            // 
            this.btnNewInvoice.BackColor = System.Drawing.SystemColors.Window;
            this.btnNewInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewInvoice.Location = new System.Drawing.Point(17, 45);
            this.btnNewInvoice.Name = "btnNewInvoice";
            this.btnNewInvoice.Size = new System.Drawing.Size(100, 60);
            this.btnNewInvoice.TabIndex = 1;
            this.btnNewInvoice.Text = "New Invoice";
            this.btnNewInvoice.UseVisualStyleBackColor = false;
            this.btnNewInvoice.Click += new System.EventHandler(this.btnNewInvoice_Click);
            // 
            // btnViewInvoices
            // 
            this.btnViewInvoices.BackColor = System.Drawing.SystemColors.Window;
            this.btnViewInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewInvoices.Location = new System.Drawing.Point(146, 45);
            this.btnViewInvoices.Name = "btnViewInvoices";
            this.btnViewInvoices.Size = new System.Drawing.Size(100, 60);
            this.btnViewInvoices.TabIndex = 2;
            this.btnViewInvoices.Text = "View Invoice(s)";
            this.btnViewInvoices.UseVisualStyleBackColor = false;
            this.btnViewInvoices.Click += new System.EventHandler(this.btnViewInvoices_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(275, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 60);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstInvoiceDivisions
            // 
            this.lstInvoiceDivisions.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.lstInvoiceDivisions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstInvoiceDivisions.FormattingEnabled = true;
            this.lstInvoiceDivisions.ItemHeight = 16;
            this.lstInvoiceDivisions.Location = new System.Drawing.Point(17, 117);
            this.lstInvoiceDivisions.Name = "lstInvoiceDivisions";
            this.lstInvoiceDivisions.Size = new System.Drawing.Size(358, 116);
            this.lstInvoiceDivisions.TabIndex = 4;
            this.lstInvoiceDivisions.SelectedIndexChanged += new System.EventHandler(this.lstInvoiceDivisions_SelectedIndexChanged);
            // 
            // FormNewInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 241);
            this.Controls.Add(this.lstInvoiceDivisions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnViewInvoices);
            this.Controls.Add(this.btnNewInvoice);
            this.Controls.Add(this.lblClientName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormNewInvoice";
            this.Text = "New [MM/yy] Invoice";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormNewInvoice_LoadCompleted);
            this.Load += new System.EventHandler(this.FormNewInvoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Button btnNewInvoice;
        private System.Windows.Forms.Button btnViewInvoices;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstInvoiceDivisions;
    }
}