namespace PaaApplication.Forms.Invoicing
{
    partial class FormAutomaticBillingDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutomaticBillingDetail));
            this.lblDesc1 = new System.Windows.Forms.Label();
            this.lblDesc2 = new System.Windows.Forms.Label();
            this.lblDesc3 = new System.Windows.Forms.Label();
            this.lblDesc4 = new System.Windows.Forms.Label();
            this.lblDesc5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.pic3 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.pic4 = new System.Windows.Forms.PictureBox();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesc1
            // 
            this.lblDesc1.AutoSize = true;
            this.lblDesc1.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.lblDesc1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDesc1.Location = new System.Drawing.Point(136, 33);
            this.lblDesc1.MaximumSize = new System.Drawing.Size(220, 0);
            this.lblDesc1.MinimumSize = new System.Drawing.Size(220, 0);
            this.lblDesc1.Name = "lblDesc1";
            this.lblDesc1.Size = new System.Drawing.Size(220, 60);
            this.lblDesc1.TabIndex = 0;
            this.lblDesc1.Text = "If the client name is not a valid client, then the application is not billed to a" +
    "ny invoice.";
            // 
            // lblDesc2
            // 
            this.lblDesc2.AutoSize = true;
            this.lblDesc2.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.lblDesc2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDesc2.Location = new System.Drawing.Point(136, 131);
            this.lblDesc2.MaximumSize = new System.Drawing.Size(220, 0);
            this.lblDesc2.MinimumSize = new System.Drawing.Size(220, 0);
            this.lblDesc2.Name = "lblDesc2";
            this.lblDesc2.Size = new System.Drawing.Size(220, 120);
            this.lblDesc2.TabIndex = 1;
            this.lblDesc2.Text = "The invoice line will contain the receive date of the application and optionally " +
    "another item that is selected in the \'Edit Invoice Line\' dialog in the Client Ex" +
    "plorer.";
            // 
            // lblDesc3
            // 
            this.lblDesc3.AutoSize = true;
            this.lblDesc3.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.lblDesc3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDesc3.Location = new System.Drawing.Point(136, 278);
            this.lblDesc3.MaximumSize = new System.Drawing.Size(220, 0);
            this.lblDesc3.MinimumSize = new System.Drawing.Size(220, 0);
            this.lblDesc3.Name = "lblDesc3";
            this.lblDesc3.Size = new System.Drawing.Size(220, 80);
            this.lblDesc3.TabIndex = 2;
            this.lblDesc3.Text = "The amount for each item is either the default price for the report type or a spe" +
    "cial price set up per client.";
            // 
            // lblDesc4
            // 
            this.lblDesc4.AutoSize = true;
            this.lblDesc4.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.lblDesc4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDesc4.Location = new System.Drawing.Point(496, 13);
            this.lblDesc4.MaximumSize = new System.Drawing.Size(230, 0);
            this.lblDesc4.MinimumSize = new System.Drawing.Size(230, 0);
            this.lblDesc4.Name = "lblDesc4";
            this.lblDesc4.Size = new System.Drawing.Size(230, 160);
            this.lblDesc4.TabIndex = 3;
            this.lblDesc4.Text = resources.GetString("lblDesc4.Text");
            // 
            // lblDesc5
            // 
            this.lblDesc5.AutoSize = true;
            this.lblDesc5.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F);
            this.lblDesc5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDesc5.Location = new System.Drawing.Point(496, 189);
            this.lblDesc5.MaximumSize = new System.Drawing.Size(230, 0);
            this.lblDesc5.MinimumSize = new System.Drawing.Size(230, 0);
            this.lblDesc5.Name = "lblDesc5";
            this.lblDesc5.Size = new System.Drawing.Size(230, 180);
            this.lblDesc5.TabIndex = 4;
            this.lblDesc5.Text = resources.GetString("lblDesc5.Text");
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Silver;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(300, 397);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(150, 42);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // pic3
            // 
            this.pic3.Image = global::PaaApplication.Properties.Resources.money;
            this.pic3.Location = new System.Drawing.Point(28, 278);
            this.pic3.Name = "pic3";
            this.pic3.Size = new System.Drawing.Size(90, 90);
            this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic3.TabIndex = 22;
            this.pic3.TabStop = false;
            // 
            // pic2
            // 
            this.pic2.Image = global::PaaApplication.Properties.Resources.edit_client;
            this.pic2.Location = new System.Drawing.Point(28, 147);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(90, 90);
            this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic2.TabIndex = 21;
            this.pic2.TabStop = false;
            // 
            // pic4
            // 
            this.pic4.Image = global::PaaApplication.Properties.Resources.cancel;
            this.pic4.Location = new System.Drawing.Point(386, 33);
            this.pic4.Name = "pic4";
            this.pic4.Size = new System.Drawing.Size(90, 90);
            this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic4.TabIndex = 20;
            this.pic4.TabStop = false;
            // 
            // pic1
            // 
            this.pic1.Image = global::PaaApplication.Properties.Resources.cancel;
            this.pic1.Location = new System.Drawing.Point(28, 21);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(90, 90);
            this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic1.TabIndex = 19;
            this.pic1.TabStop = false;
            // 
            // pic5
            // 
            this.pic5.Image = global::PaaApplication.Properties.Resources.check;
            this.pic5.Location = new System.Drawing.Point(386, 240);
            this.pic5.Name = "pic5";
            this.pic5.Size = new System.Drawing.Size(90, 90);
            this.pic5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic5.TabIndex = 23;
            this.pic5.TabStop = false;
            // 
            // FormAutomaticBillingDetail
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(744, 462);
            this.Controls.Add(this.pic5);
            this.Controls.Add(this.pic3);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic4);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDesc5);
            this.Controls.Add(this.lblDesc4);
            this.Controls.Add(this.lblDesc3);
            this.Controls.Add(this.lblDesc2);
            this.Controls.Add(this.lblDesc1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutomaticBillingDetail";
            this.Text = "Billing Procedure For Each Application";
            ((System.ComponentModel.ISupportInitialize)(this.pic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDesc1;
        private System.Windows.Forms.Label lblDesc2;
        private System.Windows.Forms.Label lblDesc3;
        private System.Windows.Forms.Label lblDesc4;
        private System.Windows.Forms.Label lblDesc5;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic4;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.PictureBox pic3;
        private System.Windows.Forms.PictureBox pic5;
    }
}