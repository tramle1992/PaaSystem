namespace PaaApplication.Forms.AppExplore
{
    partial class FormPullCreditResult
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
            this.pullCreditResultControl = new PaaApplication.UserControls.AppExplore.PullCreditResultControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pullCreditResultControl
            // 
            this.pullCreditResultControl.Location = new System.Drawing.Point(26, 26);
            this.pullCreditResultControl.Name = "pullCreditResultControl";
            this.pullCreditResultControl.Size = new System.Drawing.Size(1209, 452);
            this.pullCreditResultControl.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Gray;
            this.btnOK.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(1109, 488);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(126, 52);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormPullCreditResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 548);
            this.Controls.Add(this.pullCreditResultControl);
            this.Controls.Add(this.btnOK);
            this.Name = "FormPullCreditResult";
            this.Text = "Pulling credit result(s)";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormPullCreditResult_LoadCompleted);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.AppExplore.PullCreditResultControl pullCreditResultControl;
        private System.Windows.Forms.Button btnOK;
    }
}