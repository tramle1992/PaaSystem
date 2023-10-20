namespace PaaApplication.Forms.ClientInfo
{
    partial class FormClientDataGrid
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
            this.clientDataGridControl = new PaaApplication.UserControls.ClientInfo.ClientDataGridControl();
            this.SuspendLayout();
            // 
            // clientDataGridControl
            // 
            this.clientDataGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientDataGridControl.Location = new System.Drawing.Point(12, 12);
            this.clientDataGridControl.Name = "clientDataGridControl";
            this.clientDataGridControl.Size = new System.Drawing.Size(702, 581);
            this.clientDataGridControl.TabIndex = 0;
            // 
            // FormClientDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 599);
            this.Controls.Add(this.clientDataGridControl);
            this.Name = "FormClientDataGrid";
            this.Text = "Datagrid";
            this.LoadCompleted += new System.EventHandler<System.EventArgs>(this.FormClientDataGrid_LoadCompleted);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ClientInfo.ClientDataGridControl clientDataGridControl;
    }
}