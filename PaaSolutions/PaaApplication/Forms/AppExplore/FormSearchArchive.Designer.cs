namespace PaaApplication.Forms.AppExplore
{
    partial class FormSearchArchive
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
            this.monthCalendarArchive = new System.Windows.Forms.MonthCalendar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEnterArchive = new System.Windows.Forms.Button();
            this.lblShowApplications = new System.Windows.Forms.Label();
            this.rbCompleted = new System.Windows.Forms.RadioButton();
            this.rbReceived = new System.Windows.Forms.RadioButton();
            this.lblDateResult = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendarArchive
            // 
            this.monthCalendarArchive.CalendarDimensions = new System.Drawing.Size(2, 2);
            this.monthCalendarArchive.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendarArchive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.monthCalendarArchive.Location = new System.Drawing.Point(18, 18);
            this.monthCalendarArchive.MaxSelectionCount = 120;
            this.monthCalendarArchive.Name = "monthCalendarArchive";
            this.monthCalendarArchive.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(384, 417);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 29);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEnterArchive
            // 
            this.btnEnterArchive.BackColor = System.Drawing.Color.Gray;
            this.btnEnterArchive.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEnterArchive.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnterArchive.ForeColor = System.Drawing.Color.White;
            this.btnEnterArchive.Location = new System.Drawing.Point(243, 417);
            this.btnEnterArchive.Name = "btnEnterArchive";
            this.btnEnterArchive.Size = new System.Drawing.Size(117, 29);
            this.btnEnterArchive.TabIndex = 16;
            this.btnEnterArchive.Text = "Enter Archive";
            this.btnEnterArchive.UseVisualStyleBackColor = false;
            this.btnEnterArchive.Click += new System.EventHandler(this.btnEnterArchive_Click);
            // 
            // lblShowApplications
            // 
            this.lblShowApplications.AutoSize = true;
            this.lblShowApplications.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowApplications.Location = new System.Drawing.Point(76, 361);
            this.lblShowApplications.Name = "lblShowApplications";
            this.lblShowApplications.Size = new System.Drawing.Size(126, 15);
            this.lblShowApplications.TabIndex = 33;
            this.lblShowApplications.Text = "SHOW  APPLICATIONS";
            // 
            // rbCompleted
            // 
            this.rbCompleted.AutoSize = true;
            this.rbCompleted.BackColor = System.Drawing.SystemColors.Control;
            this.rbCompleted.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCompleted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbCompleted.Location = new System.Drawing.Point(15, 30);
            this.rbCompleted.Name = "rbCompleted";
            this.rbCompleted.Size = new System.Drawing.Size(93, 19);
            this.rbCompleted.TabIndex = 32;
            this.rbCompleted.Text = "COMPLETED";
            this.rbCompleted.UseVisualStyleBackColor = false;
            // 
            // rbReceived
            // 
            this.rbReceived.AutoSize = true;
            this.rbReceived.BackColor = System.Drawing.SystemColors.Control;
            this.rbReceived.Checked = true;
            this.rbReceived.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReceived.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbReceived.Location = new System.Drawing.Point(15, 5);
            this.rbReceived.Name = "rbReceived";
            this.rbReceived.Size = new System.Drawing.Size(80, 19);
            this.rbReceived.TabIndex = 31;
            this.rbReceived.TabStop = true;
            this.rbReceived.Text = "RECEIVED";
            this.rbReceived.UseVisualStyleBackColor = false;
            // 
            // lblDateResult
            // 
            this.lblDateResult.AutoSize = true;
            this.lblDateResult.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateResult.Location = new System.Drawing.Point(296, 417);
            this.lblDateResult.Name = "lblDateResult";
            this.lblDateResult.Size = new System.Drawing.Size(0, 15);
            this.lblDateResult.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbCompleted);
            this.panel1.Controls.Add(this.rbReceived);
            this.panel1.Location = new System.Drawing.Point(205, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 56);
            this.panel1.TabIndex = 37;
            // 
            // FormSearchArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(491, 457);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDateResult);
            this.Controls.Add(this.lblShowApplications);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEnterArchive);
            this.Controls.Add(this.monthCalendarArchive);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSearchArchive";
            this.Text = "Entering Archive ...";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendarArchive;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEnterArchive;
        private System.Windows.Forms.Label lblShowApplications;
        private System.Windows.Forms.RadioButton rbCompleted;
        private System.Windows.Forms.RadioButton rbReceived;
        private System.Windows.Forms.Label lblDateResult;
        private System.Windows.Forms.Panel panel1;
    }
}