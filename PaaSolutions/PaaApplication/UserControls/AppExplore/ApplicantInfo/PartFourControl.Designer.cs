using PaaApplication.Helper;
namespace PaaApplication.UserControls.AppExplore.ApplicantInfo
{
    partial class PartFourControl
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
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.lblStreetName = new System.Windows.Forms.Label();
            this.txtHouse = new System.Windows.Forms.TextBox();
            this.lblHouse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPostCode
            // 
            this.txtPostCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPostCode.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPostCode.Location = new System.Drawing.Point(426, 84);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(144, 28);
            this.txtPostCode.TabIndex = 14;
            this.txtPostCode.TextChanged += new System.EventHandler(this.txtPostCode_TextChanged);
            this.txtPostCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPostCode_KeyUp);
            this.txtPostCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostCode_Validating);
            this.txtPostCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPostCode_MouseClick);
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPostCode.Location = new System.Drawing.Point(424, 65);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(88, 15);
            this.lblPostCode.TabIndex = 0;
            this.lblPostCode.Text = "POSTAL CODE:";
            // 
            // txtRegion
            // 
            this.txtRegion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRegion.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRegion.Location = new System.Drawing.Point(297, 84);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(111, 28);
            this.txtRegion.TabIndex = 13;
            this.txtRegion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRegion_MouseClick);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRegion.Location = new System.Drawing.Point(294, 64);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(54, 15);
            this.lblRegion.TabIndex = 0;
            this.lblRegion.Text = "REGION:";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCity.Location = new System.Drawing.Point(10, 85);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(269, 28);
            this.txtCity.TabIndex = 12;
            this.txtCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleCaseTextBox_KeyPress);
            this.txtCity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCity_MouseClick);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCity.Location = new System.Drawing.Point(9, 65);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(35, 15);
            this.lblCity.TabIndex = 0;
            this.lblCity.Text = "CITY:";
            // 
            // txtStreetName
            // 
            this.txtStreetName.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreetName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtStreetName.Location = new System.Drawing.Point(132, 24);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(438, 28);
            this.txtStreetName.TabIndex = 11;
            this.txtStreetName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleCaseTextBox_KeyPress);
            this.txtStreetName.KeyUp += txtStreetName_KeyUp;
            this.txtStreetName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStreetName_MouseClick);
            // 
            // lblStreetName
            // 
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreetName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStreetName.Location = new System.Drawing.Point(129, 5);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(87, 15);
            this.lblStreetName.TabIndex = 0;
            this.lblStreetName.Text = "STREET NAME:";
            // 
            // txtHouse
            // 
            this.txtHouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHouse.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHouse.Location = new System.Drawing.Point(10, 24);
            this.txtHouse.Name = "txtHouse";
            this.txtHouse.Size = new System.Drawing.Size(105, 28);
            this.txtHouse.TabIndex = 10;
            this.txtHouse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtHouse_MouseClick);
            // 
            // lblHouse
            // 
            this.lblHouse.AutoSize = true;
            this.lblHouse.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHouse.Location = new System.Drawing.Point(8, 5);
            this.lblHouse.Name = "lblHouse";
            this.lblHouse.Size = new System.Drawing.Size(58, 15);
            this.lblHouse.TabIndex = 0;
            this.lblHouse.Text = "HOUSE #:";
            // 
            // PartFourControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtPostCode);
            this.Controls.Add(this.lblPostCode);
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtStreetName);
            this.Controls.Add(this.lblStreetName);
            this.Controls.Add(this.txtHouse);
            this.Controls.Add(this.lblHouse);
            this.Name = "PartFourControl";
            this.Size = new System.Drawing.Size(585, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.Label lblPostCode;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.Label lblStreetName;
        private System.Windows.Forms.TextBox txtHouse;
        private System.Windows.Forms.Label lblHouse;
    }
}
