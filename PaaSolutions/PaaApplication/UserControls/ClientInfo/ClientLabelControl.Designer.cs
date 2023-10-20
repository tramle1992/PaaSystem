using System.Windows.Forms;
namespace PaaApplication.UserControls.ClientInfo
{
    partial class ClientLabelControl
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
        private void InitializeComponent(string size)
        {
            this.components = new System.ComponentModel.Container();
            this.labelContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);

            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addLabelFrClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteThisLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeLabels4X313ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallLabels1X258ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.panelContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.largeLabels4X313ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.smallLabels1X258ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.printLabelsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();

            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.buttonsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabelPanel = new System.Windows.Forms.Panel();
            this.tabelFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabelPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.buttonsFlowLayoutPanel);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 589);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(700, 34);
            this.buttonsPanel.TabIndex = 1;
            // 
            // buttonsFlowLayoutPanel
            // 
            this.buttonsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonsFlowLayoutPanel.Name = "buttonsFlowLayoutPanel";
            this.buttonsFlowLayoutPanel.Size = new System.Drawing.Size(700, 34);
            this.buttonsFlowLayoutPanel.TabIndex = 0;
            this.buttonsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            // 
            // tabelPanel
            // 
            this.tabelPanel.Controls.Add(this.tabelFlowLayoutPanel);
            this.tabelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelPanel.Location = new System.Drawing.Point(0, 0);
            this.tabelPanel.Name = "tabelPanel";
            this.tabelPanel.Size = new System.Drawing.Size(700, 598);
            this.tabelPanel.TabIndex = 2;
            // 
            // tabelFlowLayoutPanel
            // 
            this.tabelFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tabelFlowLayoutPanel.Name = "tabelFlowLayoutPanel";
            this.tabelFlowLayoutPanel.Size = new System.Drawing.Size(700, 598);
            this.tabelFlowLayoutPanel.TabIndex = 0;
            this.tabelFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tabelFlowLayoutPanel.AutoScroll = true;
            this.tabelFlowLayoutPanel.SizeChanged += new System.EventHandler(tabelFlowLayoutPanel_SizeChanged);
            this.tabelFlowLayoutPanel.ContextMenuStrip = this.panelContextMenuStrip;
            this.tabelFlowLayoutPanel.MouseDown += new MouseEventHandler(this.tabelFlowLayoutPanel_MouseDown);
            // 
            // labelContextMenuStrip
            // 
            this.labelContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToolStripMenuItem,
            this.CutToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.addLabelFrClientToolStripMenuItem,
            this.insertLabelToolStripMenuItem,
            this.deleteThisLabelToolStripMenuItem,
            this.largeLabels4X313ToolStripMenuItem,
            this.smallLabels1X258ToolStripMenuItem,
            this.printLabelsToolStripMenuItem});
            this.labelContextMenuStrip.Name = "contextMenuStrip1";
            this.labelContextMenuStrip.Size = new System.Drawing.Size(203, 136);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.CopyToolStripMenuItem.Text = "Copy";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.CutToolStripMenuItem.Text = "Cut";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.PasteToolStripMenuItem.Text = "Paste";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // addLabelFrClientToolStripMenuItem
            // 
            this.addLabelFrClientToolStripMenuItem.Name = "addLabelFrClientToolStripMenuItem";
            this.addLabelFrClientToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.addLabelFrClientToolStripMenuItem.Text = "Add Labels From Clients";
            this.addLabelFrClientToolStripMenuItem.Click += new System.EventHandler(this.addLabelFrClientToolStripMenuItem_Click);
            // 
            // insertLabelToolStripMenuItem
            // 
            this.insertLabelToolStripMenuItem.Name = "insertLabelToolStripMenuItem";
            this.insertLabelToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.insertLabelToolStripMenuItem.Text = "Insert Label Here";
            this.insertLabelToolStripMenuItem.Click += new System.EventHandler(this.insertLabelToolStripMenuItem_Click);
            // 
            // deleteThisLabelToolStripMenuItem
            // 
            this.deleteThisLabelToolStripMenuItem.Name = "deleteThisLabelToolStripMenuItem";
            this.deleteThisLabelToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.deleteThisLabelToolStripMenuItem.Text = "Delete This Label";
            this.deleteThisLabelToolStripMenuItem.Click += new System.EventHandler(this.deleteThisLabelToolStripMenuItem_Click);
            // 
            // largeLabels4X313ToolStripMenuItem
            // 
            this.largeLabels4X313ToolStripMenuItem.Name = "largeLabels4X313ToolStripMenuItem";
            this.largeLabels4X313ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.largeLabels4X313ToolStripMenuItem.Text = "Large Labels (4 x 3 1/3\")";
            this.largeLabels4X313ToolStripMenuItem.Click += new System.EventHandler(this.largeLabels4X313ToolStripMenuItem_Click);
            // 
            // smallLabels1X258ToolStripMenuItem
            // 
            this.smallLabels1X258ToolStripMenuItem.Name = "smallLabels1X258ToolStripMenuItem";
            this.smallLabels1X258ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.smallLabels1X258ToolStripMenuItem.Text = "Small Labels (1 x 2 5/8\")";
            this.smallLabels1X258ToolStripMenuItem.Click += new System.EventHandler(this.smallLabels1X258ToolStripMenuItem_Click);
            // 
            // printLabelsToolStripMenuItem
            // 
            this.printLabelsToolStripMenuItem.Name = "printLabelsToolStripMenuItem";
            this.printLabelsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.printLabelsToolStripMenuItem.Text = "Print Labels";
            this.printLabelsToolStripMenuItem.Click += new System.EventHandler(this.printLabelsToolStripMenuItem_Click);
            // 
            // panelContextMenuStrip
            // 
            this.panelContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeLabels4X313ToolStripMenuItem1,
            this.smallLabels1X258ToolStripMenuItem1,
            this.printLabelsToolStripMenuItem1});
            this.panelContextMenuStrip.Name = "panelContextMenuStrip";
            this.panelContextMenuStrip.Size = new System.Drawing.Size(203, 136);
            // 
            // largeLabels4X313ToolStripMenuItem
            // 
            this.largeLabels4X313ToolStripMenuItem1.Name = "largeLabels4X313ToolStripMenuItem1";
            this.largeLabels4X313ToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.largeLabels4X313ToolStripMenuItem1.Text = "Large Labels (4 x 3 1/3\")";
            this.largeLabels4X313ToolStripMenuItem1.Click += new System.EventHandler(this.largeLabels4X313ToolStripMenuItem_Click);
            // 
            // smallLabels1X258ToolStripMenuItem
            // 
            this.smallLabels1X258ToolStripMenuItem1.Name = "smallLabels1X258ToolStripMenuItem1";
            this.smallLabels1X258ToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.smallLabels1X258ToolStripMenuItem1.Text = "Small Labels (1 x 2 5/8\")";
            this.smallLabels1X258ToolStripMenuItem1.Click += new System.EventHandler(this.smallLabels1X258ToolStripMenuItem_Click);
            // 
            // printLabelsToolStripMenuItem
            // 
            this.printLabelsToolStripMenuItem1.Name = "printLabelsToolStripMenuItem1";
            this.printLabelsToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.printLabelsToolStripMenuItem1.Text = "Print Labels";
            this.printLabelsToolStripMenuItem1.Click += new System.EventHandler(this.printLabelsToolStripMenuItem_Click);
            // 
            // ClientLabelControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabelPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "ClientLabelControl";
            this.Size = new System.Drawing.Size(700, 632);
            this.tabelPanel.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.labelContextMenuStrip.ResumeLayout(false);
            this.panelContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Panel tabelPanel;
        private System.Windows.Forms.FlowLayoutPanel buttonsFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel tabelFlowLayoutPanel;

        private ContextMenuStrip labelContextMenuStrip;
        private ToolStripMenuItem CopyToolStripMenuItem;
        private ToolStripMenuItem CutToolStripMenuItem;
        private ToolStripMenuItem PasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem addLabelFrClientToolStripMenuItem;
        private ToolStripMenuItem insertLabelToolStripMenuItem;
        private ToolStripMenuItem deleteThisLabelToolStripMenuItem;
        private ToolStripMenuItem largeLabels4X313ToolStripMenuItem;
        private ToolStripMenuItem smallLabels1X258ToolStripMenuItem;
        private ToolStripMenuItem printLabelsToolStripMenuItem;

        private ContextMenuStrip panelContextMenuStrip;
        private ToolStripMenuItem largeLabels4X313ToolStripMenuItem1;
        private ToolStripMenuItem smallLabels1X258ToolStripMenuItem1;
        private ToolStripMenuItem printLabelsToolStripMenuItem1;
    }
}
