namespace DataMigrationApp
{
    partial class frmDataMigration
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
            this.sourceOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelDataSource = new System.Windows.Forms.Label();
            this.chooseSourceFileTextBox = new System.Windows.Forms.TextBox();
            this.chooseSourceFileButton = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dummySSNToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dummySpouseSSNToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dummyEmailToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.migrationDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.managementCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.custNumberSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoResourceFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migrationUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migrationUserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.migrationAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migrateAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migrationInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAppIdMappingTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropAppIdMappingTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migrationInvoiceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.migrateZipcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migrateZipcodeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fixInvoiceDivisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskProgressBar = new System.Windows.Forms.ProgressBar();
            this.taskBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.fixClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixCustomerSinceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceOpenFileDialog
            // 
            this.sourceOpenFileDialog.FileName = "sourceOpenFileDialog";
            // 
            // labelDataSource
            // 
            this.labelDataSource.AutoSize = true;
            this.labelDataSource.Location = new System.Drawing.Point(12, 32);
            this.labelDataSource.Name = "labelDataSource";
            this.labelDataSource.Size = new System.Drawing.Size(67, 13);
            this.labelDataSource.TabIndex = 0;
            this.labelDataSource.Text = "Data Source";
            // 
            // chooseSourceFileTextBox
            // 
            this.chooseSourceFileTextBox.Location = new System.Drawing.Point(110, 30);
            this.chooseSourceFileTextBox.Name = "chooseSourceFileTextBox";
            this.chooseSourceFileTextBox.Size = new System.Drawing.Size(231, 20);
            this.chooseSourceFileTextBox.TabIndex = 1;
            // 
            // chooseSourceFileButton
            // 
            this.chooseSourceFileButton.Location = new System.Drawing.Point(375, 27);
            this.chooseSourceFileButton.Name = "chooseSourceFileButton";
            this.chooseSourceFileButton.Size = new System.Drawing.Size(110, 23);
            this.chooseSourceFileButton.TabIndex = 2;
            this.chooseSourceFileButton.Text = "Choose source file";
            this.chooseSourceFileButton.UseVisualStyleBackColor = true;
            this.chooseSourceFileButton.Click += new System.EventHandler(this.chooseSourceFileButton_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.migrationDataToolStripMenuItem,
            this.migrationUserToolStripMenuItem,
            this.migrationAppToolStripMenuItem,
            this.migrationInvoiceToolStripMenuItem,
            this.migrateZipcodeToolStripMenuItem,
            this.fixInvoiceDivisionToolStripMenuItem,
            this.updateDataToolStripMenuItem,
            this.fixClientToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(978, 24);
            this.mainMenu.TabIndex = 3;
            this.mainMenu.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientInfoToolStripMenuItem,
            this.applicationsToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.dataToolStripMenuItem.Text = "DummyData";
            // 
            // clientInfoToolStripMenuItem
            // 
            this.clientInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummySSNToolStripMenuItem1,
            this.dummySpouseSSNToolStripMenuItem1});
            this.clientInfoToolStripMenuItem.Name = "clientInfoToolStripMenuItem";
            this.clientInfoToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.clientInfoToolStripMenuItem.Text = "Applications";
            // 
            // dummySSNToolStripMenuItem1
            // 
            this.dummySSNToolStripMenuItem1.Name = "dummySSNToolStripMenuItem1";
            this.dummySSNToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.dummySSNToolStripMenuItem1.Text = "Dummy AppSSN";
            this.dummySSNToolStripMenuItem1.Click += new System.EventHandler(this.dummySSNToolStripMenuItem1_Click);
            // 
            // dummySpouseSSNToolStripMenuItem1
            // 
            this.dummySpouseSSNToolStripMenuItem1.Name = "dummySpouseSSNToolStripMenuItem1";
            this.dummySpouseSSNToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.dummySpouseSSNToolStripMenuItem1.Text = "Dummy SpouseSSN";
            this.dummySpouseSSNToolStripMenuItem1.Click += new System.EventHandler(this.dummySpouseSSNToolStripMenuItem1_Click);
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummyEmailToolStripMenuItem1});
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.applicationsToolStripMenuItem.Text = "Client Infos";
            // 
            // dummyEmailToolStripMenuItem1
            // 
            this.dummyEmailToolStripMenuItem1.Name = "dummyEmailToolStripMenuItem1";
            this.dummyEmailToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.dummyEmailToolStripMenuItem1.Text = "Dummy Emails";
            this.dummyEmailToolStripMenuItem1.Click += new System.EventHandler(this.dummyEmailToolStripMenuItem1_Click);
            // 
            // migrationDataToolStripMenuItem
            // 
            this.migrationDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoResourcesToolStripMenuItem,
            this.clientInfoToolStripMenuItem1,
            this.infoResourceFilePathToolStripMenuItem});
            this.migrationDataToolStripMenuItem.Name = "migrationDataToolStripMenuItem";
            this.migrationDataToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.migrationDataToolStripMenuItem.Text = "MigrationData";
            // 
            // infoResourcesToolStripMenuItem
            // 
            this.infoResourcesToolStripMenuItem.Name = "infoResourcesToolStripMenuItem";
            this.infoResourcesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.infoResourcesToolStripMenuItem.Text = "InfoResources";
            this.infoResourcesToolStripMenuItem.Click += new System.EventHandler(this.infoResourcesToolStripMenuItem_Click);
            // 
            // clientInfoToolStripMenuItem1
            // 
            this.clientInfoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managementCompanyToolStripMenuItem,
            this.reportTypeToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.specialPriceToolStripMenuItem,
            this.custNumberSettingToolStripMenuItem});
            this.clientInfoToolStripMenuItem1.Name = "clientInfoToolStripMenuItem1";
            this.clientInfoToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.clientInfoToolStripMenuItem1.Text = "ClientInfo";
            // 
            // managementCompanyToolStripMenuItem
            // 
            this.managementCompanyToolStripMenuItem.Name = "managementCompanyToolStripMenuItem";
            this.managementCompanyToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.managementCompanyToolStripMenuItem.Text = "ManagementCompany";
            this.managementCompanyToolStripMenuItem.Click += new System.EventHandler(this.managementCompanyToolStripMenuItem_Click);
            // 
            // reportTypeToolStripMenuItem
            // 
            this.reportTypeToolStripMenuItem.Name = "reportTypeToolStripMenuItem";
            this.reportTypeToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.reportTypeToolStripMenuItem.Text = "ReportType";
            this.reportTypeToolStripMenuItem.Click += new System.EventHandler(this.reportTypeToolStripMenuItem_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.clientToolStripMenuItem.Text = "Client";
            this.clientToolStripMenuItem.Click += new System.EventHandler(this.clientToolStripMenuItem_Click);
            // 
            // specialPriceToolStripMenuItem
            // 
            this.specialPriceToolStripMenuItem.Name = "specialPriceToolStripMenuItem";
            this.specialPriceToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.specialPriceToolStripMenuItem.Text = "SpecialPrice";
            this.specialPriceToolStripMenuItem.Click += new System.EventHandler(this.specialPriceToolStripMenuItem_Click);
            // 
            // custNumberSettingToolStripMenuItem
            // 
            this.custNumberSettingToolStripMenuItem.Name = "custNumberSettingToolStripMenuItem";
            this.custNumberSettingToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.custNumberSettingToolStripMenuItem.Text = "Customer Number Settings";
            this.custNumberSettingToolStripMenuItem.Click += new System.EventHandler(this.custNumberSettingToolStripMenuItem_Click);
            // 
            // infoResourceFilePathToolStripMenuItem
            // 
            this.infoResourceFilePathToolStripMenuItem.Name = "infoResourceFilePathToolStripMenuItem";
            this.infoResourceFilePathToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.infoResourceFilePathToolStripMenuItem.Text = "Info Resource File Path";
            this.infoResourceFilePathToolStripMenuItem.Click += new System.EventHandler(this.infoResourceFilePathToolStripMenuItem_Click);
            // 
            // migrationUserToolStripMenuItem
            // 
            this.migrationUserToolStripMenuItem.Checked = true;
            this.migrationUserToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.migrationUserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.migrationUserToolStripMenuItem1});
            this.migrationUserToolStripMenuItem.Name = "migrationUserToolStripMenuItem";
            this.migrationUserToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.migrationUserToolStripMenuItem.Text = "Migration User";
            // 
            // migrationUserToolStripMenuItem1
            // 
            this.migrationUserToolStripMenuItem1.Name = "migrationUserToolStripMenuItem1";
            this.migrationUserToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.migrationUserToolStripMenuItem1.Text = "Migration User";
            this.migrationUserToolStripMenuItem1.Click += new System.EventHandler(this.migrationUserToolStripMenuItem1_Click);
            // 
            // migrationAppToolStripMenuItem
            // 
            this.migrationAppToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.migrateAppToolStripMenuItem});
            this.migrationAppToolStripMenuItem.Name = "migrationAppToolStripMenuItem";
            this.migrationAppToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.migrationAppToolStripMenuItem.Text = "Migration App";
            // 
            // migrateAppToolStripMenuItem
            // 
            this.migrateAppToolStripMenuItem.Name = "migrateAppToolStripMenuItem";
            this.migrateAppToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.migrateAppToolStripMenuItem.Text = "Migrate App";
            this.migrateAppToolStripMenuItem.Click += new System.EventHandler(this.migrateAppToolStripMenuItem_Click);
            // 
            // migrationInvoiceToolStripMenuItem
            // 
            this.migrationInvoiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createAppIdMappingTableToolStripMenuItem,
            this.dropAppIdMappingTableToolStripMenuItem,
            this.migrationInvoiceToolStripMenuItem1});
            this.migrationInvoiceToolStripMenuItem.Name = "migrationInvoiceToolStripMenuItem";
            this.migrationInvoiceToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.migrationInvoiceToolStripMenuItem.Text = "Migration Invoice";
            // 
            // createAppIdMappingTableToolStripMenuItem
            // 
            this.createAppIdMappingTableToolStripMenuItem.Name = "createAppIdMappingTableToolStripMenuItem";
            this.createAppIdMappingTableToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.createAppIdMappingTableToolStripMenuItem.Text = "Create AppIdMapping Table";
            this.createAppIdMappingTableToolStripMenuItem.Click += new System.EventHandler(this.createAppIdMappingTableToolStripMenuItem_Click);
            // 
            // dropAppIdMappingTableToolStripMenuItem
            // 
            this.dropAppIdMappingTableToolStripMenuItem.Name = "dropAppIdMappingTableToolStripMenuItem";
            this.dropAppIdMappingTableToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.dropAppIdMappingTableToolStripMenuItem.Text = "Drop AppIdMapping Table";
            this.dropAppIdMappingTableToolStripMenuItem.Click += new System.EventHandler(this.dropAppIdMappingTableToolStripMenuItem_Click);
            // 
            // migrationInvoiceToolStripMenuItem1
            // 
            this.migrationInvoiceToolStripMenuItem1.Name = "migrationInvoiceToolStripMenuItem1";
            this.migrationInvoiceToolStripMenuItem1.Size = new System.Drawing.Size(223, 22);
            this.migrationInvoiceToolStripMenuItem1.Text = "Migration Invoice";
            this.migrationInvoiceToolStripMenuItem1.Click += new System.EventHandler(this.migrationInvoiceToolStripMenuItem1_Click);
            // 
            // migrateZipcodeToolStripMenuItem
            // 
            this.migrateZipcodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.migrateZipcodeToolStripMenuItem1});
            this.migrateZipcodeToolStripMenuItem.Name = "migrateZipcodeToolStripMenuItem";
            this.migrateZipcodeToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.migrateZipcodeToolStripMenuItem.Text = "Migrate Zipcode";
            // 
            // migrateZipcodeToolStripMenuItem1
            // 
            this.migrateZipcodeToolStripMenuItem1.Name = "migrateZipcodeToolStripMenuItem1";
            this.migrateZipcodeToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.migrateZipcodeToolStripMenuItem1.Text = "Migrate Zipcode";
            this.migrateZipcodeToolStripMenuItem1.Click += new System.EventHandler(this.migrateZipcodeToolStripMenuItem1_Click);
            // 
            // fixInvoiceDivisionToolStripMenuItem
            // 
            this.fixInvoiceDivisionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forClientToolStripMenuItem,
            this.forApplicationToolStripMenuItem,
            this.forInvoiceToolStripMenuItem});
            this.fixInvoiceDivisionToolStripMenuItem.Name = "fixInvoiceDivisionToolStripMenuItem";
            this.fixInvoiceDivisionToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.fixInvoiceDivisionToolStripMenuItem.Text = "Fix Invoice Division";
            // 
            // forClientToolStripMenuItem
            // 
            this.forClientToolStripMenuItem.Name = "forClientToolStripMenuItem";
            this.forClientToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.forClientToolStripMenuItem.Text = "For Client";
            this.forClientToolStripMenuItem.Click += new System.EventHandler(this.forClientToolStripMenuItem_Click);
            // 
            // forApplicationToolStripMenuItem
            // 
            this.forApplicationToolStripMenuItem.Name = "forApplicationToolStripMenuItem";
            this.forApplicationToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.forApplicationToolStripMenuItem.Text = "For Application";
            this.forApplicationToolStripMenuItem.Click += new System.EventHandler(this.forApplicationToolStripMenuItem_Click);
            // 
            // forInvoiceToolStripMenuItem
            // 
            this.forInvoiceToolStripMenuItem.Name = "forInvoiceToolStripMenuItem";
            this.forInvoiceToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.forInvoiceToolStripMenuItem.Text = "For Invoice";
            this.forInvoiceToolStripMenuItem.Click += new System.EventHandler(this.forInvoiceToolStripMenuItem_Click);
            // 
            // updateDataToolStripMenuItem
            // 
            this.updateDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateApplicationToolStripMenuItem,
            this.updateClientToolStripMenuItem});
            this.updateDataToolStripMenuItem.Name = "updateDataToolStripMenuItem";
            this.updateDataToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.updateDataToolStripMenuItem.Text = "Update Data";
            // 
            // updateApplicationToolStripMenuItem
            // 
            this.updateApplicationToolStripMenuItem.Name = "updateApplicationToolStripMenuItem";
            this.updateApplicationToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.updateApplicationToolStripMenuItem.Text = "Update Client of Application";
            this.updateApplicationToolStripMenuItem.Click += new System.EventHandler(this.updateApplicationToolStripMenuItem_Click);
            // 
            // updateClientToolStripMenuItem
            // 
            this.updateClientToolStripMenuItem.Name = "updateClientToolStripMenuItem";
            this.updateClientToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.updateClientToolStripMenuItem.Text = "Update missing Client";
            this.updateClientToolStripMenuItem.Click += new System.EventHandler(this.updateClientToolStripMenuItem_Click);
            // 
            // taskProgressBar
            // 
            this.taskProgressBar.Location = new System.Drawing.Point(15, 227);
            this.taskProgressBar.Name = "taskProgressBar";
            this.taskProgressBar.Size = new System.Drawing.Size(790, 23);
            this.taskProgressBar.TabIndex = 4;
            // 
            // taskBackgroundWorker
            // 
            this.taskBackgroundWorker.WorkerReportsProgress = true;
            this.taskBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.taskBackgroundWorker_DoWork);
            this.taskBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.taskBackgroundWorker_ProgressChanged);
            this.taskBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.taskBackgroundWorker_RunWorkerCompleted);
            // 
            // fixClientToolStripMenuItem
            // 
            this.fixClientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fixCustomerSinceToolStripMenuItem});
            this.fixClientToolStripMenuItem.Name = "fixClientToolStripMenuItem";
            this.fixClientToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.fixClientToolStripMenuItem.Text = "Fix Client";
            // 
            // fixCustomerSinceToolStripMenuItem
            // 
            this.fixCustomerSinceToolStripMenuItem.Name = "fixCustomerSinceToolStripMenuItem";
            this.fixCustomerSinceToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.fixCustomerSinceToolStripMenuItem.Text = "Fix Customer Since";
            this.fixCustomerSinceToolStripMenuItem.Click += new System.EventHandler(this.fixCustomerSinceToolStripMenuItem_Click);
            // 
            // frmDataMigration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 267);
            this.Controls.Add(this.taskProgressBar);
            this.Controls.Add(this.chooseSourceFileButton);
            this.Controls.Add(this.chooseSourceFileTextBox);
            this.Controls.Add(this.labelDataSource);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "frmDataMigration";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmDataMigration_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog sourceOpenFileDialog;
        private System.Windows.Forms.Label labelDataSource;
        private System.Windows.Forms.TextBox chooseSourceFileTextBox;
        private System.Windows.Forms.Button chooseSourceFileButton;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ProgressBar taskProgressBar;
        private System.ComponentModel.BackgroundWorker taskBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem clientInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dummySSNToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dummySpouseSSNToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dummyEmailToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem migrationDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoResourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientInfoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem managementCompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem custNumberSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem migrationUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem migrationAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem migrateAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem migrationInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem migrationInvoiceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem migrateZipcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoResourceFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAppIdMappingTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropAppIdMappingTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem migrationUserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem migrateZipcodeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fixInvoiceDivisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixCustomerSinceToolStripMenuItem;
    }
}

