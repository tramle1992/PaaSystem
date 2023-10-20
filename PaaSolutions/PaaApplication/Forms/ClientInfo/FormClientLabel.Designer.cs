namespace PaaApplication.Forms.ClientInfo
{
    partial class FormClientLabel
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
            this.clientLabelControl = new PaaApplication.UserControls.ClientInfo.ClientLabelControl();
            this.SuspendLayout();
            // 
            // clientLabelControl
            // 
            this.clientLabelControl.BackColor = System.Drawing.Color.White;
            this.clientLabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientLabelControl.Location = new System.Drawing.Point(0, 0);
            this.clientLabelControl.Name = "clientLabelControl";
            this.clientLabelControl.Size = new System.Drawing.Size(819, 541);
            this.clientLabelControl.TabIndex = 0;
            this.clientLabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // FormClientLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 550);
            this.Controls.Add(this.clientLabelControl);
            this.Name = "FormClientLabel";
            this.Text = "Bemrose LabelMaker";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormClientLabel_LoadCompleted);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ClientInfo.ClientLabelControl clientLabelControl;
    }
}