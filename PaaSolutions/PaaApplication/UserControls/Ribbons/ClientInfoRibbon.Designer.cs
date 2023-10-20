using PaaApplication.Forms;
namespace PaaApplication.UserControls.Ribbons
{
    partial class ClientInfoRibbon
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMaster));
            this.ribbon = new System.Windows.Forms.Ribbon();
            this.rtabClientInfo = new System.Windows.Forms.RibbonTab();
            this.rpnlCreateClient = new System.Windows.Forms.RibbonPanel();
            this.rbtnCreateClient = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonList1 = new System.Windows.Forms.RibbonButtonList();
            this.ribbonButton7 = new System.Windows.Forms.RibbonButton();
            this.rbtnDeleteClient = new System.Windows.Forms.RibbonButton();
            this.rpnlSearchClient = new System.Windows.Forms.RibbonPanel();
            this.rbtnSearchClient = new System.Windows.Forms.RibbonButton();
            this.rpnlShowApp = new System.Windows.Forms.RibbonPanel();
            this.rbtnShowApp = new System.Windows.Forms.RibbonButton();
            this.rbtnForClient = new System.Windows.Forms.RibbonButton();
            this.rbtnForShownClient = new System.Windows.Forms.RibbonButton();
            this.rbtnNotForClient = new System.Windows.Forms.RibbonButton();
            this.rpnlPrintJob = new System.Windows.Forms.RibbonPanel();
            this.rbtnCommonPrint = new System.Windows.Forms.RibbonButton();
            this.rbtnLabel = new System.Windows.Forms.RibbonButton();
            this.rbtnCommonPrintClientInfo = new System.Windows.Forms.RibbonButton();
            this.rbtnCommonPrintResContract = new System.Windows.Forms.RibbonButton();
            this.rbtnCommonPrintEmpContract = new System.Windows.Forms.RibbonButton();
            this.rbtnClientDatagrid = new System.Windows.Forms.RibbonButton();
            this.rbtnDatagridSelectedClients = new System.Windows.Forms.RibbonButton();
            this.rbtnDatagridAllShownClients = new System.Windows.Forms.RibbonButton();
            this.rbtnEmailClient = new System.Windows.Forms.RibbonButton();
            this.rbtnEmailSelectedClients = new System.Windows.Forms.RibbonButton();
            this.rbtnEmailAllShownClients = new System.Windows.Forms.RibbonButton();
            this.rpnlEditPrice = new System.Windows.Forms.RibbonPanel();
            this.rbtnEditClientPrice = new System.Windows.Forms.RibbonButton();
            this.rpnlSaveClient = new System.Windows.Forms.RibbonPanel();
            this.rbtnSaveClient = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbtnRefreshClient = new System.Windows.Forms.RibbonButton();

            // 
            // ribbon
            // 
            this.ribbon.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.ribbon, "ribbon");
            this.ribbon.Minimized = false;
            this.ribbon.Name = "ribbon";
            // 
            // 
            // 
            this.ribbon.OrbDropDown.BorderRoundness = 8;
            this.ribbon.OrbDropDown.Location = ((System.Drawing.Point)(resources.GetObject("ribbon.OrbDropDown.Location")));
            this.ribbon.OrbDropDown.Name = "";
            this.ribbon.OrbDropDown.Size = ((System.Drawing.Size)(resources.GetObject("ribbon.OrbDropDown.Size")));
            this.ribbon.OrbDropDown.TabIndex = ((int)(resources.GetObject("ribbon.OrbDropDown.TabIndex")));
            this.ribbon.OrbImage = null;
            this.ribbon.OrbText = "";
            this.ribbon.OrbVisible = false;
            this.ribbon.Size = new System.Drawing.Size(50, 134);
            this.ribbon.QuickAcessToolbar.Visible = false;
            // 
            // 
            // 
            this.ribbon.RibbonTabFont = new System.Drawing.Font("Arial Unicode MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon.Tabs.Add(this.rtabClientInfo);
            this.ribbon.TabsMargin = new System.Windows.Forms.Padding(12, 0, 30, 0);
            this.ribbon.ThemeColor = System.Windows.Forms.RibbonTheme.Black;
            // 
            // rtabClientInfo
            // 
            this.rtabClientInfo.Panels.Add(this.rpnlCreateClient);
            this.rtabClientInfo.Panels.Add(this.rpnlSearchClient);
            this.rtabClientInfo.Panels.Add(this.rpnlShowApp);
            this.rtabClientInfo.Panels.Add(this.rpnlPrintJob);
            this.rtabClientInfo.Panels.Add(this.rpnlEditPrice);
            this.rtabClientInfo.Panels.Add(this.rpnlSaveClient);
            this.rtabClientInfo.Panels.Add(this.ribbonPanel1);
            resources.ApplyResources(this.rtabClientInfo, "rtabClientInfo");
            this.rtabClientInfo.Value = "0";
            this.rtabClientInfo.Text = "";
            // 
            // rpnlCreateClient
            // 
            this.rpnlCreateClient.ButtonMoreEnabled = false;
            this.rpnlCreateClient.Items.Add(this.rbtnCreateClient);
            this.rpnlCreateClient.Items.Add(this.rbtnDeleteClient);
            resources.ApplyResources(this.rpnlCreateClient, "rpnlCreateClient");
            // 
            // rbtnCreateClient
            // 
            this.rbtnCreateClient.DropDownItems.Add(this.ribbonButtonList1);
            this.rbtnCreateClient.DropDownItems.Add(this.ribbonButton7);
            this.rbtnCreateClient.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCreateClient.Image")));
            this.rbtnCreateClient.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.rbtnCreateClient.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.rbtnCreateClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCreateClient.SmallImage")));
            resources.ApplyResources(this.rbtnCreateClient, "rbtnCreateClient");
            this.rbtnCreateClient.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.rbtnCreateClient.Click += new System.EventHandler(this.rbtnCreateClient_Click);
            // 
            // ribbonButtonList1
            // 
            this.ribbonButtonList1.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButtonList1.FlowToBottom = false;
            this.ribbonButtonList1.ItemsSizeInDropwDownMode = new System.Drawing.Size(7, 5);
            resources.ApplyResources(this.ribbonButtonList1, "ribbonButtonList1");
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.Image")));
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            resources.ApplyResources(this.ribbonButton7, "ribbonButton7");
            // 
            // rbtnDeleteClient
            // 
            this.rbtnDeleteClient.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDeleteClient.Image")));
            this.rbtnDeleteClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDeleteClient.SmallImage")));
            resources.ApplyResources(this.rbtnDeleteClient, "rbtnDeleteClient");
            this.rbtnDeleteClient.Click += new System.EventHandler(this.rbtnDeleteClient_Click);
            // 
            // rpnlSearchClient
            // 
            this.rpnlSearchClient.ButtonMoreEnabled = false;
            this.rpnlSearchClient.Items.Add(this.rbtnSearchClient);
            resources.ApplyResources(this.rpnlSearchClient, "rpnlSearchClient");
            // 
            // rbtnSearchClient
            // 
            this.rbtnSearchClient.Image = ((System.Drawing.Image)(resources.GetObject("rbtnSearchClient.Image")));
            this.rbtnSearchClient.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.rbtnSearchClient.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.rbtnSearchClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSearchClient.SmallImage")));
            resources.ApplyResources(this.rbtnSearchClient, "rbtnSearchClient");
            this.rbtnSearchClient.Click += new System.EventHandler(this.rbtnSearchClient_Click);
            // 
            // rpnlShowApp
            // 
            this.rpnlShowApp.ButtonMoreEnabled = false;
            this.rpnlShowApp.Items.Add(this.rbtnShowApp);
            resources.ApplyResources(this.rpnlShowApp, "rpnlShowApp");
            // 
            // rbtnShowApp
            // 
            this.rbtnShowApp.DropDownItems.Add(this.rbtnForClient);
            this.rbtnShowApp.DropDownItems.Add(this.rbtnForShownClient);
            this.rbtnShowApp.DropDownItems.Add(this.rbtnNotForClient);
            this.rbtnShowApp.Image = ((System.Drawing.Image)(resources.GetObject("rbtnShowApp.Image")));
            this.rbtnShowApp.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.rbtnShowApp.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.rbtnShowApp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnShowApp.SmallImage")));
            this.rbtnShowApp.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnShowApp, "rbtnShowApp");
            // 
            // rbtnForClient
            // 
            this.rbtnForClient.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnForClient.Image = global::PaaApplication.Properties.Resources.tick_20x16;
            this.rbtnForClient.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbtnForClient.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rbtnForClient.SmallImage = global::PaaApplication.Properties.Resources.tick_20x16;
            resources.ApplyResources(this.rbtnForClient, "rbtnForClient");
            this.rbtnForClient.Click += new System.EventHandler(this.rbtnForClient_Click);
            // 
            // rbtnForShownClient
            // 
            this.rbtnForShownClient.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnForShownClient.Image = global::PaaApplication.Properties.Resources.star_24x24;
            this.rbtnForShownClient.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbtnForShownClient.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rbtnForShownClient.SmallImage = global::PaaApplication.Properties.Resources.star_20x16;
            resources.ApplyResources(this.rbtnForShownClient, "rbtnForShownClient");
            this.rbtnForShownClient.Click += new System.EventHandler(this.rbtnForShownClient_Click);
            // 
            // rbtnNotForClient
            // 
            this.rbtnNotForClient.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnNotForClient.Image = ((System.Drawing.Image)(resources.GetObject("rbtnNotForClient.Image")));
            this.rbtnNotForClient.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbtnNotForClient.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rbtnNotForClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnNotForClient.SmallImage")));
            resources.ApplyResources(this.rbtnNotForClient, "rbtnNotForClient");
            this.rbtnNotForClient.Click += new System.EventHandler(this.rbtnNotForClient_Click);
            // 
            // rpnlPrintJob
            // 
            this.rpnlPrintJob.ButtonMoreEnabled = false;
            this.rpnlPrintJob.Items.Add(this.rbtnCommonPrint);
            this.rpnlPrintJob.Items.Add(this.rbtnClientDatagrid);
            this.rpnlPrintJob.Items.Add(this.rbtnEmailClient);
            resources.ApplyResources(this.rpnlPrintJob, "rpnlPrintJob");
            // 
            // rbtnCommonPrint
            // 
            this.rbtnCommonPrint.DropDownItems.Add(this.rbtnLabel);
            this.rbtnCommonPrint.DropDownItems.Add(this.rbtnCommonPrintClientInfo);
            this.rbtnCommonPrint.DropDownItems.Add(this.rbtnCommonPrintResContract);
            this.rbtnCommonPrint.DropDownItems.Add(this.rbtnCommonPrintEmpContract);
            this.rbtnCommonPrint.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrint.Image")));
            this.rbtnCommonPrint.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.rbtnCommonPrint.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.rbtnCommonPrint.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrint.SmallImage")));
            this.rbtnCommonPrint.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnCommonPrint, "rbtnCommonPrint");
            // 
            // rbtnLabel
            // 
            this.rbtnLabel.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnLabel.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintClientInfo.Image")));
            this.rbtnLabel.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintClientInfo.SmallImage")));
            this.rbtnLabel.Value = "rbtnLabel";
            this.rbtnLabel.Text = "Label(s)";
            resources.ApplyResources(this.rbtnLabel, "rbtnLabel");
            this.rbtnLabel.Click += new System.EventHandler(this.rbtnLabel_Click);
            // 
            // rbtnCommonPrintClientInfo
            // 
            this.rbtnCommonPrintClientInfo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCommonPrintClientInfo.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintClientInfo.Image")));
            this.rbtnCommonPrintClientInfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintClientInfo.SmallImage")));
            this.rbtnCommonPrintClientInfo.Value = "rbtnCommonPrintClientInfo";
            resources.ApplyResources(this.rbtnCommonPrintClientInfo, "rbtnCommonPrintClientInfo");
            this.rbtnCommonPrintClientInfo.Click += new System.EventHandler(this.rbtnCommonPrint_Click);
            // 
            // rbtnCommonPrintResContract
            // 
            this.rbtnCommonPrintResContract.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCommonPrintResContract.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintResContract.Image")));
            this.rbtnCommonPrintResContract.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintResContract.SmallImage")));
            this.rbtnCommonPrintResContract.Value = "rbtnCommonPrintResContract";
            resources.ApplyResources(this.rbtnCommonPrintResContract, "rbtnCommonPrintResContract");
            this.rbtnCommonPrintResContract.Click += new System.EventHandler(this.rbtnCommonPrint_Click);
            // 
            // rbtnCommonPrintEmpContract
            // 
            this.rbtnCommonPrintEmpContract.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCommonPrintEmpContract.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintEmpContract.Image")));
            this.rbtnCommonPrintEmpContract.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintEmpContract.SmallImage")));
            this.rbtnCommonPrintEmpContract.Value = "rbtnCommonPrintEmpContract";
            resources.ApplyResources(this.rbtnCommonPrintEmpContract, "rbtnCommonPrintEmpContract");
            this.rbtnCommonPrintEmpContract.Click += new System.EventHandler(this.rbtnCommonPrint_Click);
            // 
            // rbtnClientDatagrid
            // 
            this.rbtnClientDatagrid.DropDownItems.Add(this.rbtnDatagridSelectedClients);
            this.rbtnClientDatagrid.DropDownItems.Add(this.rbtnDatagridAllShownClients);
            this.rbtnClientDatagrid.Image = ((System.Drawing.Image)(resources.GetObject("rbtnClientDatagrid.Image")));
            this.rbtnClientDatagrid.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnClientDatagrid.SmallImage")));
            this.rbtnClientDatagrid.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnClientDatagrid, "rbtnClientDatagrid");
            // 
            // rbtnDatagridSelectedClients
            // 
            this.rbtnDatagridSelectedClients.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDatagridSelectedClients.Image = global::PaaApplication.Properties.Resources.tick_20x16;
            this.rbtnDatagridSelectedClients.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbtnDatagridSelectedClients.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rbtnDatagridSelectedClients.SmallImage = global::PaaApplication.Properties.Resources.tick_20x16;
            resources.ApplyResources(this.rbtnDatagridSelectedClients, "rbtnDatagridSelectedClients");
            this.rbtnDatagridSelectedClients.Click += new System.EventHandler(this.rbtnDatagridSelectedClients_Click);
            // 
            // rbtnDatagridAllShownClients
            // 
            this.rbtnDatagridAllShownClients.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDatagridAllShownClients.Image = global::PaaApplication.Properties.Resources.star_24x24;
            this.rbtnDatagridAllShownClients.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbtnDatagridAllShownClients.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rbtnDatagridAllShownClients.SmallImage = global::PaaApplication.Properties.Resources.star_20x16;
            resources.ApplyResources(this.rbtnDatagridAllShownClients, "rbtnDatagridAllShownClients");
            this.rbtnDatagridAllShownClients.Click += new System.EventHandler(this.rbtnDatagridAllShownClients_Click);
            // 
            // rbtnEmailClient
            // 
            this.rbtnEmailClient.DropDownItems.Add(this.rbtnEmailSelectedClients);
            this.rbtnEmailClient.DropDownItems.Add(this.rbtnEmailAllShownClients);
            this.rbtnEmailClient.Image = ((System.Drawing.Image)(resources.GetObject("rbtnEmailClient.Image")));
            this.rbtnEmailClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEmailClient.SmallImage")));
            this.rbtnEmailClient.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnEmailClient, "rbtnEmailClient");
            this.rbtnEmailClient.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // rbtnEmailSelectedClients
            // 
            this.rbtnEmailSelectedClients.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnEmailSelectedClients.Image = global::PaaApplication.Properties.Resources.tick_20x16;
            this.rbtnEmailSelectedClients.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbtnEmailSelectedClients.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rbtnEmailSelectedClients.SmallImage = global::PaaApplication.Properties.Resources.tick_20x16;
            resources.ApplyResources(this.rbtnEmailSelectedClients, "rbtnEmailSelectedClients");
            this.rbtnEmailSelectedClients.Click += new System.EventHandler(this.rbtnEmailSelectedClients_Click);
            // 
            // rbtnEmailAllShownClients
            // 
            this.rbtnEmailAllShownClients.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnEmailAllShownClients.Image = global::PaaApplication.Properties.Resources.star_24x24;
            this.rbtnEmailAllShownClients.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbtnEmailAllShownClients.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rbtnEmailAllShownClients.SmallImage = global::PaaApplication.Properties.Resources.star_20x16;
            resources.ApplyResources(this.rbtnEmailAllShownClients, "rbtnEmailAllShownClients");
            this.rbtnEmailAllShownClients.Click += new System.EventHandler(this.rbtnEmailAllShownClients_Click);
            // 
            // rpnlEditPrice
            // 
            this.rpnlEditPrice.ButtonMoreEnabled = false;
            this.rpnlEditPrice.Items.Add(this.rbtnEditClientPrice);
            resources.ApplyResources(this.rpnlEditPrice, "rpnlEditPrice");
            // 
            // rbtnEditClientPrice
            // 
            this.rbtnEditClientPrice.Image = ((System.Drawing.Image)(resources.GetObject("rbtnEditClientPrice.Image")));
            this.rbtnEditClientPrice.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.rbtnEditClientPrice.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.rbtnEditClientPrice.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEditClientPrice.SmallImage")));
            resources.ApplyResources(this.rbtnEditClientPrice, "rbtnEditClientPrice");
            this.rbtnEditClientPrice.Click += new System.EventHandler(this.rbtnEditClientPrice_Click);
            // 
            // rpnlSaveClient
            // 
            this.rpnlSaveClient.Items.Add(this.rbtnSaveClient);
            resources.ApplyResources(this.rpnlSaveClient, "rpnlSaveClient");
            // 
            // rbtnSaveClient
            // 
            this.rbtnSaveClient.Image = ((System.Drawing.Image)(resources.GetObject("rbtnSaveClient.Image")));
            this.rbtnSaveClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSaveClient.SmallImage")));
            resources.ApplyResources(this.rbtnSaveClient, "rbtnSaveClient");
            this.rbtnSaveClient.Click += new System.EventHandler(this.rbtnSaveClient_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.rbtnRefreshClient);
            resources.ApplyResources(this.ribbonPanel1, "ribbonPanel1");
            // 
            // rbtnRefreshClient
            // 
            this.rbtnRefreshClient.Image = ((System.Drawing.Image)(resources.GetObject("rbtnRefreshClient.Image")));
            this.rbtnRefreshClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRefreshClient.SmallImage")));
            resources.ApplyResources(this.rbtnRefreshClient, "rbtnRefreshClient");
            this.rbtnRefreshClient.Click += new System.EventHandler(this.rbtnRefreshClient_Click);

            // 
            // ClientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbon);
            this.Name = "Client Info";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Ribbon ribbon;

        private System.Windows.Forms.RibbonTab rtabClientInfo;
        private System.Windows.Forms.RibbonPanel rpnlCreateClient;
        private System.Windows.Forms.RibbonButton rbtnCreateClient;
        private System.Windows.Forms.RibbonPanel rpnlSearchClient;
        private System.Windows.Forms.RibbonButton rbtnSearchClient;
        private System.Windows.Forms.RibbonPanel rpnlShowApp;
        private System.Windows.Forms.RibbonButton rbtnShowApp;
        private System.Windows.Forms.RibbonButton rbtnForClient;
        private System.Windows.Forms.RibbonButton rbtnForShownClient;
        private System.Windows.Forms.RibbonButton rbtnNotForClient;
        private System.Windows.Forms.RibbonButton rbtnCommonPrint;
        private System.Windows.Forms.RibbonButtonList ribbonButtonList1;

        private System.Windows.Forms.RibbonButton rbtnDatagridSelectedClients;
        private System.Windows.Forms.RibbonButton rbtnDatagridAllShownClients;
        private System.Windows.Forms.RibbonButton rbtnEmailSelectedClients;

        private System.Windows.Forms.RibbonButton rbtnEmailAllShownClients;
        private System.Windows.Forms.RibbonPanel rpnlEditPrice;
        private System.Windows.Forms.RibbonButton rbtnEditClientPrice;
        private System.Windows.Forms.RibbonPanel rpnlPrintJob;
        private System.Windows.Forms.RibbonButton rbtnLabel;
        private System.Windows.Forms.RibbonButton rbtnCommonPrintClientInfo;
        private System.Windows.Forms.RibbonButton rbtnCommonPrintResContract;
        private System.Windows.Forms.RibbonButton rbtnCommonPrintEmpContract;
        private System.Windows.Forms.RibbonButton rbtnClientDatagrid;
        private System.Windows.Forms.RibbonButton rbtnEmailClient;
        private System.Windows.Forms.Panel pnlContentDisplay;
        private System.Windows.Forms.RibbonButton ribbonButton7;
        private System.Windows.Forms.RibbonButton ribbonButton9;
        private System.Windows.Forms.RibbonButton ribbonButton10;
        private System.Windows.Forms.RibbonButton rbtnDeleteClient;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rbtnRefreshClient;
        private System.Windows.Forms.RibbonPanel rpnlSaveClient;
        private System.Windows.Forms.RibbonButton rbtnSaveClient;
    }
}
