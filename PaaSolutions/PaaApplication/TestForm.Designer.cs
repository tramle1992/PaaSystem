namespace PaaApplication
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>      
        

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
       

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testCommonChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commonChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testCommonChartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(234, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testCommonChartToolStripMenuItem
            // 
            this.testCommonChartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commonChartToolStripMenuItem,
            this.customChartToolStripMenuItem});
            this.testCommonChartToolStripMenuItem.Name = "testCommonChartToolStripMenuItem";
            this.testCommonChartToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.testCommonChartToolStripMenuItem.Text = "Test Common Chart";
            // 
            // commonChartToolStripMenuItem
            // 
            this.commonChartToolStripMenuItem.Name = "commonChartToolStripMenuItem";
            this.commonChartToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.commonChartToolStripMenuItem.Text = "Common Chart";
            this.commonChartToolStripMenuItem.Click += new System.EventHandler(this.commonChartToolStripMenuItem_Click);
            // 
            // customChartToolStripMenuItem
            // 
            this.customChartToolStripMenuItem.Name = "customChartToolStripMenuItem";
            this.customChartToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.customChartToolStripMenuItem.Text = "Custom Chart";
            this.customChartToolStripMenuItem.Click += new System.EventHandler(this.customChartToolStripMenuItem_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(12, 43);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 20);
            this.username.TabIndex = 1;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(12, 80);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 2;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 132);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testCommonChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commonChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customChartToolStripMenuItem;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
    }
}