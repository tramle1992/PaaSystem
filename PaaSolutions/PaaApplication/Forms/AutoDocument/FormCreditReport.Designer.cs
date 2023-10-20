namespace PaaApplication.Forms
{
    partial class FormCreditReport
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
            this.dtpCreditReport = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.creditReportControl1 = new PaaApplication.UserControls.AppExplore.CreditReportControl();
            this.txtNoReport = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpCreditReport
            // 
            this.dtpCreditReport.CustomFormat = "MMM yyyy";
            this.dtpCreditReport.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCreditReport.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreditReport.Location = new System.Drawing.Point(29, 22);
            this.dtpCreditReport.Name = "dtpCreditReport";
            this.dtpCreditReport.Size = new System.Drawing.Size(120, 24);
            this.dtpCreditReport.TabIndex = 19;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DarkGray;
            this.btnLoad.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(164, 21);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(106, 29);
            this.btnLoad.TabIndex = 20;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // creditReportControl1
            // 
            this.creditReportControl1.Location = new System.Drawing.Point(29, 71);
            this.creditReportControl1.Name = "creditReportControl1";
            this.creditReportControl1.Size = new System.Drawing.Size(1521, 382);
            this.creditReportControl1.TabIndex = 21;
            // 
            // txtNoReport
            // 
            this.txtNoReport.AutoSize = true;
            this.txtNoReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoReport.Location = new System.Drawing.Point(691, 237);
            this.txtNoReport.Name = "txtNoReport";
            this.txtNoReport.Size = new System.Drawing.Size(0, 17);
            this.txtNoReport.TabIndex = 22;
            // 
            // FormCreditReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 683);
            this.Controls.Add(this.txtNoReport);
            this.Controls.Add(this.creditReportControl1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dtpCreditReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCreditReport";
            this.Text = "FormCreditReport";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormCreditReport_LoadCompleted);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpCreditReport;
        private System.Windows.Forms.Button btnLoad;
        private UserControls.AppExplore.CreditReportControl creditReportControl1;
        private System.Windows.Forms.Label txtNoReport;
    }
}