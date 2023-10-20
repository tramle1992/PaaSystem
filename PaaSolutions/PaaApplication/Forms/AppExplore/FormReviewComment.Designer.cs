namespace PaaApplication.Forms.AppExplore
{
    partial class FormReviewComment
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
            this.lblApplicantName = new System.Windows.Forms.Label();
            this.cmbAreas = new System.Windows.Forms.ComboBox();
            this.lblSimpleLookFor = new System.Windows.Forms.Label();
            this.listboxAreas = new System.Windows.Forms.ListBox();
            this.rtbComment = new RichTextBoxExtended.RichTextBoxExtended();
            this.lblCorrectArea = new System.Windows.Forms.Label();
            this.pnlAddArea = new System.Windows.Forms.Panel();
            this.pnlAddArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblApplicantName
            // 
            this.lblApplicantName.AutoSize = true;
            this.lblApplicantName.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicantName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblApplicantName.Location = new System.Drawing.Point(12, 9);
            this.lblApplicantName.Name = "lblApplicantName";
            this.lblApplicantName.Size = new System.Drawing.Size(149, 21);
            this.lblApplicantName.TabIndex = 2;
            this.lblApplicantName.Text = "lblApplicantName";
            // 
            // cmbAreas
            // 
            this.cmbAreas.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAreas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbAreas.FormattingEnabled = true;
            this.cmbAreas.Location = new System.Drawing.Point(114, 3);
            this.cmbAreas.Name = "cmbAreas";
            this.cmbAreas.Size = new System.Drawing.Size(344, 26);
            this.cmbAreas.TabIndex = 42;
            this.cmbAreas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAreas_KeyDown);
            // 
            // lblSimpleLookFor
            // 
            this.lblSimpleLookFor.AutoSize = true;
            this.lblSimpleLookFor.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimpleLookFor.ForeColor = System.Drawing.Color.Gray;
            this.lblSimpleLookFor.Location = new System.Drawing.Point(-4, 7);
            this.lblSimpleLookFor.Name = "lblSimpleLookFor";
            this.lblSimpleLookFor.Size = new System.Drawing.Size(93, 15);
            this.lblSimpleLookFor.TabIndex = 48;
            this.lblSimpleLookFor.Text = "ADD THIS AREA:";
            // 
            // listboxAreas
            // 
            this.listboxAreas.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listboxAreas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listboxAreas.FormattingEnabled = true;
            this.listboxAreas.ItemHeight = 18;
            this.listboxAreas.Location = new System.Drawing.Point(12, 92);
            this.listboxAreas.Name = "listboxAreas";
            this.listboxAreas.Size = new System.Drawing.Size(462, 112);
            this.listboxAreas.TabIndex = 49;
            this.listboxAreas.Visible = false;
            this.listboxAreas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listboxAreas_KeyDown);
            // 
            // rtbComment
            // 
            this.rtbComment.AcceptsTab = false;
            this.rtbComment.AutoWordSelection = false;
            this.rtbComment.BulletIndent = 0;
            this.rtbComment.DefaultFontName = "Arial Unicode MS";
            this.rtbComment.DefaultFontSize = 11F;
            this.rtbComment.DetectUrls = true;
            this.rtbComment.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbComment.HideSelection = false;
            this.rtbComment.Lines = new string[0];
            this.rtbComment.Location = new System.Drawing.Point(12, 56);
            this.rtbComment.Location_AlignToolbar = new System.Drawing.Point(375, 0);
            this.rtbComment.Location_BoldToolbar = new System.Drawing.Point(3, 0);
            this.rtbComment.Location_FontToolbar = new System.Drawing.Point(159, 0);
            this.rtbComment.Margin = new System.Windows.Forms.Padding(4);
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.ReadOnly = false;
            this.rtbComment.RichText = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Arial Unico" +
    "de MS;}}\r\n\\viewkind4\\uc1\\pard\\b\\f0\\fs23\\par\r\n}\r\n";
            this.rtbComment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbComment.ShortcutsEnabled = true;
            this.rtbComment.ShowFormattingToolbar = true;
            this.rtbComment.Size = new System.Drawing.Size(465, 250);
            this.rtbComment.TabIndex = 50;
            this.rtbComment.WordWrap = true;
            // 
            // lblCorrectArea
            // 
            this.lblCorrectArea.AutoSize = true;
            this.lblCorrectArea.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrectArea.Location = new System.Drawing.Point(8, 37);
            this.lblCorrectArea.Name = "lblCorrectArea";
            this.lblCorrectArea.Size = new System.Drawing.Size(195, 16);
            this.lblCorrectArea.TabIndex = 51;
            this.lblCorrectArea.Text = "Please correct the following areas:";
            // 
            // pnlAddArea
            // 
            this.pnlAddArea.Controls.Add(this.cmbAreas);
            this.pnlAddArea.Controls.Add(this.lblSimpleLookFor);
            this.pnlAddArea.Location = new System.Drawing.Point(12, 56);
            this.pnlAddArea.Name = "pnlAddArea";
            this.pnlAddArea.Size = new System.Drawing.Size(462, 32);
            this.pnlAddArea.TabIndex = 52;
            this.pnlAddArea.Visible = false;
            // 
            // FormReviewComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 316);
            this.Controls.Add(this.lblCorrectArea);
            this.Controls.Add(this.lblApplicantName);
            this.Controls.Add(this.rtbComment);
            this.Controls.Add(this.listboxAreas);
            this.Controls.Add(this.pnlAddArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormReviewComment";
            this.Text = "Review Comment";
            this.pnlAddArea.ResumeLayout(false);
            this.pnlAddArea.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicantName;
        private System.Windows.Forms.ComboBox cmbAreas;
        private System.Windows.Forms.Label lblSimpleLookFor;
        private System.Windows.Forms.ListBox listboxAreas;
        private RichTextBoxExtended.RichTextBoxExtended rtbComment;
        private System.Windows.Forms.Label lblCorrectArea;
        private System.Windows.Forms.Panel pnlAddArea;
    }
}