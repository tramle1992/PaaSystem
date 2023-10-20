namespace PaaApplication.Forms.Invoicing
{
    partial class FormInvDatagrid
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
            this.components = new System.ComponentModel.Container();
            this.invDatagridControl1 = new PaaApplication.UserControls.Invoicing.InvDatagridControl();
            this.SuspendLayout();
            // 
            // invDatagridControl1
            // 
            this.invDatagridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invDatagridControl1.Location = new System.Drawing.Point(12, 12);
            this.invDatagridControl1.Name = "invDatagridControl1";
            this.invDatagridControl1.Size = new System.Drawing.Size(702, 581);
            this.invDatagridControl1.TabIndex = 0;
            // 
            // FormInvDatagrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 599);
            this.Controls.Add(this.invDatagridControl1);
            this.Name = "FormInvDatagrid";
            this.Text = "Datagrid";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Invoicing.InvDatagridControl invDatagridControl1;


        // private UserControls.Invoicing.InvDatagridControl invDataGridControl;
    }
}