namespace PaaApplication.Forms.AppExplore
{
    partial class FormMoveApps
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
            this.listBoxMoveApps = new System.Windows.Forms.ListBox();
            this.btnMoveNo = new System.Windows.Forms.Button();
            this.btnMoveYes = new System.Windows.Forms.Button();
            this.lbConfirm = new System.Windows.Forms.Label();
            this.groupBoxReviews = new System.Windows.Forms.GroupBox();
            this.radioButtonReview3 = new System.Windows.Forms.RadioButton();
            this.radioButtonReview2 = new System.Windows.Forms.RadioButton();
            this.radioButtonReview1 = new System.Windows.Forms.RadioButton();
            this.groupBoxReviews.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMoveApps
            // 
            this.listBoxMoveApps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.listBoxMoveApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBoxMoveApps.FormattingEnabled = true;
            this.listBoxMoveApps.ItemHeight = 16;
            this.listBoxMoveApps.Location = new System.Drawing.Point(12, 12);
            this.listBoxMoveApps.Name = "listBoxMoveApps";
            this.listBoxMoveApps.Size = new System.Drawing.Size(380, 260);
            this.listBoxMoveApps.TabIndex = 0;
            // 
            // btnMoveNo
            // 
            this.btnMoveNo.BackColor = System.Drawing.Color.Gray;
            this.btnMoveNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnMoveNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveNo.ForeColor = System.Drawing.Color.White;
            this.btnMoveNo.Location = new System.Drawing.Point(300, 356);
            this.btnMoveNo.Name = "btnMoveNo";
            this.btnMoveNo.Size = new System.Drawing.Size(92, 29);
            this.btnMoveNo.TabIndex = 19;
            this.btnMoveNo.Text = "No";
            this.btnMoveNo.UseVisualStyleBackColor = false;
            this.btnMoveNo.Click += new System.EventHandler(this.btnMoveNo_Click);
            // 
            // btnMoveYes
            // 
            this.btnMoveYes.BackColor = System.Drawing.Color.Gray;
            this.btnMoveYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnMoveYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveYes.ForeColor = System.Drawing.Color.White;
            this.btnMoveYes.Location = new System.Drawing.Point(177, 356);
            this.btnMoveYes.Name = "btnMoveYes";
            this.btnMoveYes.Size = new System.Drawing.Size(97, 29);
            this.btnMoveYes.TabIndex = 18;
            this.btnMoveYes.Text = "Yes";
            this.btnMoveYes.UseVisualStyleBackColor = false;
            this.btnMoveYes.Click += new System.EventHandler(this.btnMoveYes_Click);
            // 
            // lbConfirm
            // 
            this.lbConfirm.AutoSize = true;
            this.lbConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbConfirm.Location = new System.Drawing.Point(12, 285);
            this.lbConfirm.Name = "lbConfirm";
            this.lbConfirm.Size = new System.Drawing.Size(45, 16);
            this.lbConfirm.TabIndex = 20;
            this.lbConfirm.Text = "label1";
            // 
            // groupBoxReviews
            // 
            this.groupBoxReviews.Controls.Add(this.radioButtonReview3);
            this.groupBoxReviews.Controls.Add(this.radioButtonReview2);
            this.groupBoxReviews.Controls.Add(this.radioButtonReview1);
            this.groupBoxReviews.Location = new System.Drawing.Point(13, 305);
            this.groupBoxReviews.Name = "groupBoxReviews";
            this.groupBoxReviews.Size = new System.Drawing.Size(379, 45);
            this.groupBoxReviews.TabIndex = 21;
            this.groupBoxReviews.TabStop = false;
            // 
            // radioButtonReview3
            // 
            this.radioButtonReview3.AutoSize = true;
            this.radioButtonReview3.Location = new System.Drawing.Point(309, 19);
            this.radioButtonReview3.Name = "radioButtonReview3";
            this.radioButtonReview3.Size = new System.Drawing.Size(70, 17);
            this.radioButtonReview3.TabIndex = 2;
            this.radioButtonReview3.TabStop = true;
            this.radioButtonReview3.Text = "Review 3";
            this.radioButtonReview3.UseVisualStyleBackColor = true;
            // 
            // radioButtonReview2
            // 
            this.radioButtonReview2.AutoSize = true;
            this.radioButtonReview2.Location = new System.Drawing.Point(147, 19);
            this.radioButtonReview2.Name = "radioButtonReview2";
            this.radioButtonReview2.Size = new System.Drawing.Size(70, 17);
            this.radioButtonReview2.TabIndex = 1;
            this.radioButtonReview2.TabStop = true;
            this.radioButtonReview2.Text = "Review 2";
            this.radioButtonReview2.UseVisualStyleBackColor = true;
            // 
            // radioButtonReview1
            // 
            this.radioButtonReview1.AutoSize = true;
            this.radioButtonReview1.Location = new System.Drawing.Point(2, 19);
            this.radioButtonReview1.Name = "radioButtonReview1";
            this.radioButtonReview1.Size = new System.Drawing.Size(70, 17);
            this.radioButtonReview1.TabIndex = 0;
            this.radioButtonReview1.TabStop = true;
            this.radioButtonReview1.Text = "Review 1";
            this.radioButtonReview1.UseVisualStyleBackColor = true;
            // 
            // FormMoveApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 397);
            this.Controls.Add(this.groupBoxReviews);
            this.Controls.Add(this.lbConfirm);
            this.Controls.Add(this.btnMoveNo);
            this.Controls.Add(this.btnMoveYes);
            this.Controls.Add(this.listBoxMoveApps);
            this.Name = "FormMoveApps";
            this.Text = "FormMoveApps";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormMoveApps_LoadCompleted);
            this.groupBoxReviews.ResumeLayout(false);
            this.groupBoxReviews.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMoveApps;
        private System.Windows.Forms.Button btnMoveNo;
        private System.Windows.Forms.Button btnMoveYes;
        private System.Windows.Forms.Label lbConfirm;
        private System.Windows.Forms.GroupBox groupBoxReviews;
        private System.Windows.Forms.RadioButton radioButtonReview3;
        private System.Windows.Forms.RadioButton radioButtonReview2;
        private System.Windows.Forms.RadioButton radioButtonReview1;
    }
}