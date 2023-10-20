namespace PaaApplication.UserControls.AppExplore.ApplicantInfo
{
    partial class PartSixControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPosApplied = new System.Windows.Forms.Label();
            this.txtCompApplied = new System.Windows.Forms.TextBox();
            this.lblCompApplied = new System.Windows.Forms.Label();
            this.nudPgReceived = new System.Windows.Forms.NumericUpDown();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblPgReceived = new System.Windows.Forms.Label();
            this.txtRoommates = new System.Windows.Forms.TextBox();
            this.lblRoommates = new System.Windows.Forms.Label();
            this.txtPosApplied = new System.Windows.Forms.TextBox();
            this.uddPriority = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPgReceived)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPosApplied
            // 
            this.lblPosApplied.AutoSize = true;
            this.lblPosApplied.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosApplied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPosApplied.Location = new System.Drawing.Point(10, 66);
            this.lblPosApplied.Name = "lblPosApplied";
            this.lblPosApplied.Size = new System.Drawing.Size(138, 15);
            this.lblPosApplied.TabIndex = 0;
            this.lblPosApplied.Text = "POSITION APPLIED FOR:";
            // 
            // txtCompApplied
            // 
            this.txtCompApplied.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompApplied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCompApplied.Location = new System.Drawing.Point(12, 27);
            this.txtCompApplied.Name = "txtCompApplied";
            this.txtCompApplied.Size = new System.Drawing.Size(417, 28);
            this.txtCompApplied.TabIndex = 13;
            this.txtCompApplied.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleCaseTextBox_KeyPress);
            this.txtCompApplied.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCompApplied_MouseClick);
            // 
            // lblCompApplied
            // 
            this.lblCompApplied.AutoSize = true;
            this.lblCompApplied.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompApplied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCompApplied.Location = new System.Drawing.Point(9, 7);
            this.lblCompApplied.Name = "lblCompApplied";
            this.lblCompApplied.Size = new System.Drawing.Size(144, 15);
            this.lblCompApplied.TabIndex = 0;
            this.lblCompApplied.Text = "COMPANY APPLIED WITH:";
            // 
            // nudPgReceived
            // 
            this.nudPgReceived.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPgReceived.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudPgReceived.Location = new System.Drawing.Point(448, 27);
            this.nudPgReceived.Name = "nudPgReceived";
            this.nudPgReceived.Size = new System.Drawing.Size(120, 28);
            this.nudPgReceived.TabIndex = 14;
            this.nudPgReceived.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPriority.Location = new System.Drawing.Point(445, 66);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(62, 15);
            this.lblPriority.TabIndex = 0;
            this.lblPriority.Text = "PRIORITY:";
            // 
            // lblPgReceived
            // 
            this.lblPgReceived.AutoSize = true;
            this.lblPgReceived.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPgReceived.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPgReceived.Location = new System.Drawing.Point(445, 7);
            this.lblPgReceived.Name = "lblPgReceived";
            this.lblPgReceived.Size = new System.Drawing.Size(105, 15);
            this.lblPgReceived.TabIndex = 0;
            this.lblPgReceived.Text = "PAGES RECEIVED:";
            // 
            // txtRoommates
            // 
            this.txtRoommates.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoommates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRoommates.Location = new System.Drawing.Point(13, 25);
            this.txtRoommates.Name = "txtRoommates";
            this.txtRoommates.Size = new System.Drawing.Size(417, 28);
            this.txtRoommates.TabIndex = 13;
            this.txtRoommates.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleCaseTextBox_KeyPress);
            this.txtRoommates.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRoommates_MouseClick);
            // 
            // lblRoommates
            // 
            this.lblRoommates.AutoSize = true;
            this.lblRoommates.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoommates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRoommates.Location = new System.Drawing.Point(9, 7);
            this.lblRoommates.Name = "lblRoommates";
            this.lblRoommates.Size = new System.Drawing.Size(82, 15);
            this.lblRoommates.TabIndex = 0;
            this.lblRoommates.Text = "ROOMMATES:";
            // 
            // txtPosApplied
            // 
            this.txtPosApplied.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosApplied.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPosApplied.Location = new System.Drawing.Point(12, 85);
            this.txtPosApplied.Name = "txtPosApplied";
            this.txtPosApplied.Size = new System.Drawing.Size(417, 28);
            this.txtPosApplied.TabIndex = 15;
            this.txtPosApplied.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleCaseTextBox_KeyPress);
            this.txtPosApplied.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPosApplied_MouseClick);
            // 
            // uddPriority
            // 
            this.uddPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uddPriority.FormattingEnabled = true;
            this.uddPriority.Items.AddRange(new object[] {
            "0 - None",
            "1 - Low",
            "2 - Medium",
            "3 - High"});
            this.uddPriority.Location = new System.Drawing.Point(445, 84);
            this.uddPriority.Name = "uddPriority";
            this.uddPriority.Size = new System.Drawing.Size(121, 21);
            this.uddPriority.TabIndex = 16;
            // 
            // PartSixControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.uddPriority);
            this.Controls.Add(this.txtPosApplied);
            this.Controls.Add(this.txtRoommates);
            this.Controls.Add(this.lblRoommates);
            this.Controls.Add(this.lblPosApplied);
            this.Controls.Add(this.txtCompApplied);
            this.Controls.Add(this.lblCompApplied);
            this.Controls.Add(this.nudPgReceived);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblPgReceived);
            this.Name = "PartSixControl";
            this.Size = new System.Drawing.Size(585, 120);
            ((System.ComponentModel.ISupportInitialize)(this.nudPgReceived)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPosApplied;
        private System.Windows.Forms.TextBox txtCompApplied;
        private System.Windows.Forms.Label lblCompApplied;
        private System.Windows.Forms.NumericUpDown nudPgReceived;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblPgReceived;
        private System.Windows.Forms.TextBox txtRoommates;
        private System.Windows.Forms.Label lblRoommates;
        private System.Windows.Forms.TextBox txtPosApplied;
        private System.Windows.Forms.ComboBox uddPriority;
    }
}
