namespace PaaApplication.Forms.AppExplore
{
    partial class FormViewCredit
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
            this.creditReportControl1 = new PaaApplication.UserControls.AppExplore.CreditReportControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // creditReportControl1
            // 
            this.creditReportControl1.Location = new System.Drawing.Point(12, 12);
            this.creditReportControl1.Name = "creditReportControl1";
            this.creditReportControl1.Size = new System.Drawing.Size(1188, 382);
            this.creditReportControl1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Gray;
            this.btnOK.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(1063, 412);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(137, 55);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormViewCredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 479);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.creditReportControl1);
            this.Name = "FormViewCredit";
            this.Text = "FormViewCredit";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormViewCredit_LoadCompleted);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.AppExplore.CreditReportControl creditReportControl1;
        private System.Windows.Forms.Button btnOK;
    }
}