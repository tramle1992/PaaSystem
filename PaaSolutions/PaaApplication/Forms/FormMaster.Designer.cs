using System.Drawing;
namespace PaaApplication.Forms
{
    partial class FormMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMaster));
            this.ribbon = new System.Windows.Forms.Ribbon();
            this.rbtnHelp = new System.Windows.Forms.RibbonButton();
            this.rbtnAbout = new System.Windows.Forms.RibbonButton();
            this.rtabAutoDocument = new System.Windows.Forms.RibbonTab();
            this.rpnlAutoDoc = new System.Windows.Forms.RibbonPanel();
            this.rbtnAutoDoc = new System.Windows.Forms.RibbonButton();
            this.rbtnAutoReport = new System.Windows.Forms.RibbonButton();
            this.rpnlEditTimecard = new System.Windows.Forms.RibbonPanel();
            this.rbtnEditTimecard = new System.Windows.Forms.RibbonButton();
            this.rpnlCommonChart = new System.Windows.Forms.RibbonPanel();
            this.rbtnCommonChart = new System.Windows.Forms.RibbonButton();
            this.rbtnCustomChart = new System.Windows.Forms.RibbonButton();
            this.rpnlCreditReports = new System.Windows.Forms.RibbonPanel();
            this.rbtnCreditReports = new System.Windows.Forms.RibbonButton();
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
            this.rtabExploreApps = new System.Windows.Forms.RibbonTab();
            this.rpnlDesk = new System.Windows.Forms.RibbonPanel();
            this.rbtnChangeLocation = new System.Windows.Forms.RibbonButton();
            this.rbtnDesk = new System.Windows.Forms.RibbonButton();
            this.rpnlAppAction = new System.Windows.Forms.RibbonPanel();
            this.rbtnAppAction = new System.Windows.Forms.RibbonButton();
            this.rbtnCreateNewApp = new System.Windows.Forms.RibbonButton();
            this.rbtnDeleteApp = new System.Windows.Forms.RibbonButton();
            this.rbtnCopyApp = new System.Windows.Forms.RibbonButton();
            this.rbtnMarkAppRoommates = new System.Windows.Forms.RibbonButton();
            this.rbtnGeoLookup = new System.Windows.Forms.RibbonButton();
            this.rpnlSearchApp = new System.Windows.Forms.RibbonPanel();
            this.rbtnSearchApp = new System.Windows.Forms.RibbonButton();
            this.rbtnArchive = new System.Windows.Forms.RibbonButton();
            this.rpnlCheckSpelling = new System.Windows.Forms.RibbonPanel();
            this.rbtnCheckSpelling = new System.Windows.Forms.RibbonButton();
            this.rbtnCheckCurrTextBox = new System.Windows.Forms.RibbonButton();
            this.rbtnCheckCurrApp = new System.Windows.Forms.RibbonButton();
            this.rpnlPrintAndDoc = new System.Windows.Forms.RibbonPanel();
            this.rbtnPrintCoverSheet = new System.Windows.Forms.RibbonButton();
            this.rbtnRentalCover = new System.Windows.Forms.RibbonButton();
            this.rbtnEmpVerCover = new System.Windows.Forms.RibbonButton();
            this.rbtnEmpRefCover = new System.Windows.Forms.RibbonButton();
            this.rbtnCriminalCover = new System.Windows.Forms.RibbonButton();
            this.rbtnGenericCover = new System.Windows.Forms.RibbonButton();
            this.rbtnDegreeVerCover = new System.Windows.Forms.RibbonButton();
            this.rbtnCreditRefCover = new System.Windows.Forms.RibbonButton();
            this.rbtnBankCover = new System.Windows.Forms.RibbonButton();
            this.rbtnClientUpdate = new System.Windows.Forms.RibbonButton();
            this.rbtnPrintConfirmPages = new System.Windows.Forms.RibbonButton();
            this.rbtnPrintFileCoverPages = new System.Windows.Forms.RibbonButton();
            this.rbtnAppDatagrid = new System.Windows.Forms.RibbonButton();
            this.rbtnDatagridSelectedApps = new System.Windows.Forms.RibbonButton();
            this.rbtnDatagridAllApps = new System.Windows.Forms.RibbonButton();
            this.rbtnEmailReport = new System.Windows.Forms.RibbonButton();
            this.rbtnPrintReport = new System.Windows.Forms.RibbonButton();
            this.rbtnUploadReport = new System.Windows.Forms.RibbonButton();
            this.rpnlSaveApp = new System.Windows.Forms.RibbonPanel();
            this.rbtnSaveApp = new System.Windows.Forms.RibbonButton();
            this.rpnlRefresh = new System.Windows.Forms.RibbonPanel();
            this.rbtnRefreshApp = new System.Windows.Forms.RibbonButton();
            this.rtabInfoResources = new System.Windows.Forms.RibbonTab();
            this.rpnlInfoResource = new System.Windows.Forms.RibbonPanel();
            this.rbtnLandlordContact = new System.Windows.Forms.RibbonButton();
            this.ribbonButton8 = new System.Windows.Forms.RibbonButton();
            this.rbtnCriminalInfo = new System.Windows.Forms.RibbonButton();
            this.rbtnEmployment = new System.Windows.Forms.RibbonButton();
            this.rbtnDocLib = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.rbtnRefreshInfoResources = new System.Windows.Forms.RibbonButton();
            this.rtabInvoicing = new System.Windows.Forms.RibbonTab();
            this.rpnlSearchInvoices = new System.Windows.Forms.RibbonPanel();
            this.rbtnSearchInvoices = new System.Windows.Forms.RibbonButton();
            this.ribbonButton15 = new System.Windows.Forms.RibbonButton();
            this.rbtnSearchApplications = new System.Windows.Forms.RibbonButton();
            this.rpnlBilling = new System.Windows.Forms.RibbonPanel();
            this.rbtnBillingMonth = new System.Windows.Forms.RibbonButton();
            this.rbtnBillingMonthSub1 = new System.Windows.Forms.RibbonButton();
            this.rbtnBillingMonthSub2 = new System.Windows.Forms.RibbonButton();
            this.rbtnBillingMonthSub3 = new System.Windows.Forms.RibbonButton();
            this.rpnlInvoiceDoc = new System.Windows.Forms.RibbonPanel();
            this.rbtnInvoiceDataGrid = new System.Windows.Forms.RibbonButton();
            this.rbtnDgAllClients = new System.Windows.Forms.RibbonButton();
            this.rbtnDgSelectedClients = new System.Windows.Forms.RibbonButton();
            this.rbtnDgAllShownInvoices = new System.Windows.Forms.RibbonButton();
            this.rbtnDgSelectedInvoices = new System.Windows.Forms.RibbonButton();
            this.rbtnDgAllShownApps = new System.Windows.Forms.RibbonButton();
            this.rbtnDgSelectedApps = new System.Windows.Forms.RibbonButton();
            this.rbtnInvoicePrintMenu = new System.Windows.Forms.RibbonButton();
            this.rbtnPrtClientLabels = new System.Windows.Forms.RibbonButton();
            this.rbtnPrtClientInfoSheet = new System.Windows.Forms.RibbonButton();
            this.rbtnPrtResidentClienCtact = new System.Windows.Forms.RibbonButton();
            this.rbtnPrtEmpServCtact = new System.Windows.Forms.RibbonButton();
            this.rbtnPrtSelectedInvoices = new System.Windows.Forms.RibbonButton();
            this.rbtnPrtAllInvoices = new System.Windows.Forms.RibbonButton();
            this.rbtnPrtAllShownInvs = new System.Windows.Forms.RibbonButton();
            this.rbtnPrtSelectedInvs = new System.Windows.Forms.RibbonButton();
            this.rpnlRefreshInv = new System.Windows.Forms.RibbonPanel();
            this.rbtnRefreshInvoice = new System.Windows.Forms.RibbonButton();
            this.rtabUserManager = new System.Windows.Forms.RibbonTab();
            this.rpnlUserMgt = new System.Windows.Forms.RibbonPanel();
            this.rbtnMyProfile = new System.Windows.Forms.RibbonButton();
            this.ribbonButton14 = new System.Windows.Forms.RibbonButton();
            this.rbtnUserMgt = new System.Windows.Forms.RibbonButton();
            this.rpnlRoleMgt = new System.Windows.Forms.RibbonPanel();
            this.rbtnRoleMgt = new System.Windows.Forms.RibbonButton();
            this.rpnlBtnSaveUser = new System.Windows.Forms.RibbonPanel();
            this.rbtnSaveUser = new System.Windows.Forms.RibbonButton();
            this.rpnlRefreshUserManager = new System.Windows.Forms.RibbonPanel();
            this.rbtnRefreshUserManager = new System.Windows.Forms.RibbonButton();
            this.rtabCommonDatagrid = new System.Windows.Forms.RibbonTab();
            this.rpnlDataGrid = new System.Windows.Forms.RibbonPanel();
            this.rbtnApplication = new System.Windows.Forms.RibbonButton();
            this.ribbonButton17 = new System.Windows.Forms.RibbonButton();
            this.rbtnClients = new System.Windows.Forms.RibbonButton();
            this.ribbonButton16 = new System.Windows.Forms.RibbonButton();
            this.rbtnInvoices = new System.Windows.Forms.RibbonButton();
            this.rtabAdministration = new System.Windows.Forms.RibbonTab();
            this.rpnlAdministration = new System.Windows.Forms.RibbonPanel();
            this.rbtnReportMgt = new System.Windows.Forms.RibbonButton();
            this.rbtnStandardTemp = new System.Windows.Forms.RibbonButton();
            this.rbtnInternetTool = new System.Windows.Forms.RibbonButton();
            this.rpnlSystemConfig = new System.Windows.Forms.RibbonPanel();
            this.rbtnSystemConfg = new System.Windows.Forms.RibbonButton();
            this.rpnlStandardTemplatesButtons = new System.Windows.Forms.RibbonPanel();
            this.rbtnStandardTemplatesSave = new System.Windows.Forms.RibbonButton();
            this.rpnlRefreshAdministration = new System.Windows.Forms.RibbonPanel();
            this.rbtnRefreshAdministration = new System.Windows.Forms.RibbonButton();
            this.pnlContentDisplay = new System.Windows.Forms.Panel();
            this.mnuMaster = new System.Windows.Forms.StatusStrip();
            this.sttlblClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttlblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttlblAutoSave = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.ribbonButton9 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton10 = new System.Windows.Forms.RibbonButton();
            this.timerTriggerLogOut = new System.Windows.Forms.Timer(this.components);
            this.mnuMaster.SuspendLayout();
            this.SuspendLayout();
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
            // 
            // 
            // 
            this.ribbon.QuickAcessToolbar.DropDownButtonItems.Add(this.rbtnHelp);
            this.ribbon.QuickAcessToolbar.DropDownButtonItems.Add(this.rbtnAbout);
            this.ribbon.RibbonTabFont = new System.Drawing.Font("Arial Unicode MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon.Tabs.Add(this.rtabAutoDocument);
            this.ribbon.Tabs.Add(this.rtabClientInfo);
            this.ribbon.Tabs.Add(this.rtabExploreApps);
            this.ribbon.Tabs.Add(this.rtabInfoResources);
            this.ribbon.Tabs.Add(this.rtabInvoicing);
            this.ribbon.Tabs.Add(this.rtabUserManager);
            this.ribbon.Tabs.Add(this.rtabCommonDatagrid);
            this.ribbon.Tabs.Add(this.rtabAdministration);
            this.ribbon.TabsMargin = new System.Windows.Forms.Padding(12, 26, 30, 0);
            this.ribbon.ThemeColor = System.Windows.Forms.RibbonTheme.Black;
            this.ribbon.ActiveTabChanged += new System.EventHandler(this.ribbon_ActiveTabChanged);
            // 
            // rbtnHelp
            // 
            this.rbtnHelp.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnHelp.Image = ((System.Drawing.Image)(resources.GetObject("rbtnHelp.Image")));
            this.rbtnHelp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnHelp.SmallImage")));
            resources.ApplyResources(this.rbtnHelp, "rbtnHelp");
            this.rbtnHelp.Click += new System.EventHandler(this.rbtnHelp_Click);
            // 
            // rbtnAbout
            // 
            this.rbtnAbout.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnAbout.Image = ((System.Drawing.Image)(resources.GetObject("rbtnAbout.Image")));
            this.rbtnAbout.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnAbout.SmallImage")));
            resources.ApplyResources(this.rbtnAbout, "rbtnAbout");
            this.rbtnAbout.Click += new System.EventHandler(this.rbtnAbout_Click);
            // 
            // rtabAutoDocument
            // 
            this.rtabAutoDocument.Panels.Add(this.rpnlAutoDoc);
            this.rtabAutoDocument.Panels.Add(this.rpnlEditTimecard);
            this.rtabAutoDocument.Panels.Add(this.rpnlCommonChart);
            this.rtabAutoDocument.Panels.Add(this.rpnlCreditReports);
            resources.ApplyResources(this.rtabAutoDocument, "rtabAutoDocument");
            this.rtabAutoDocument.Value = "0";
            // 
            // rpnlAutoDoc
            // 
            this.rpnlAutoDoc.ButtonMoreEnabled = false;
            this.rpnlAutoDoc.Items.Add(this.rbtnAutoDoc);
            this.rpnlAutoDoc.Items.Add(this.rbtnAutoReport);
            resources.ApplyResources(this.rpnlAutoDoc, "rpnlAutoDoc");
            // 
            // rbtnAutoDoc
            // 
            this.rbtnAutoDoc.Image = ((System.Drawing.Image)(resources.GetObject("rbtnAutoDoc.Image")));
            this.rbtnAutoDoc.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnAutoDoc.SmallImage")));
            resources.ApplyResources(this.rbtnAutoDoc, "rbtnAutoDoc");
            this.rbtnAutoDoc.Click += new System.EventHandler(this.rbtnAutoDoc_Click);
            // 
            // rbtnAutoReport
            // 
            this.rbtnAutoReport.Image = ((System.Drawing.Image)(resources.GetObject("rbtnAutoReport.Image")));
            this.rbtnAutoReport.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnAutoReport.SmallImage")));
            resources.ApplyResources(this.rbtnAutoReport, "rbtnAutoReport");
            this.rbtnAutoReport.Click += new System.EventHandler(this.rbtnAutoReport_Click);
            // 
            // rpnlEditTimecard
            // 
            this.rpnlEditTimecard.ButtonMoreEnabled = false;
            this.rpnlEditTimecard.Items.Add(this.rbtnEditTimecard);
            resources.ApplyResources(this.rpnlEditTimecard, "rpnlEditTimecard");
            // 
            // rbtnEditTimecard
            // 
            this.rbtnEditTimecard.Image = ((System.Drawing.Image)(resources.GetObject("rbtnEditTimecard.Image")));
            this.rbtnEditTimecard.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEditTimecard.SmallImage")));
            resources.ApplyResources(this.rbtnEditTimecard, "rbtnEditTimecard");
            this.rbtnEditTimecard.Click += new System.EventHandler(this.rbtnEditTimecard_Click);
            // 
            // rpnlCommonChart
            // 
            this.rpnlCommonChart.ButtonMoreEnabled = false;
            this.rpnlCommonChart.Items.Add(this.rbtnCommonChart);
            this.rpnlCommonChart.Items.Add(this.rbtnCustomChart);
            resources.ApplyResources(this.rpnlCommonChart, "rpnlCommonChart");
            // 
            // rbtnCommonChart
            // 
            this.rbtnCommonChart.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCommonChart.Image")));
            this.rbtnCommonChart.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCommonChart.SmallImage")));
            resources.ApplyResources(this.rbtnCommonChart, "rbtnCommonChart");
            this.rbtnCommonChart.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.rbtnCommonChart.Click += new System.EventHandler(this.rbtnCommonChart_Click);
            // 
            // rbtnCustomChart
            // 
            this.rbtnCustomChart.DropDownArrowSize = new System.Drawing.Size(3, 3);
            this.rbtnCustomChart.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCustomChart.Image")));
            this.rbtnCustomChart.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCustomChart.SmallImage")));
            resources.ApplyResources(this.rbtnCustomChart, "rbtnCustomChart");
            this.rbtnCustomChart.Click += new System.EventHandler(this.rbtnCustomChart_Click);
            // 
            // rpnlCreditReports
            // 
            this.rpnlCreditReports.ButtonMoreEnabled = false;
            this.rpnlCreditReports.Items.Add(this.rbtnCreditReports);
            resources.ApplyResources(this.rpnlCreditReports, "rpnlCreditReports");
            // 
            // rbtnCreditReports
            // 
            this.rbtnCreditReports.DropDownArrowSize = new System.Drawing.Size(3, 3);
            this.rbtnCreditReports.Image = ((System.Drawing.Image)(resources.GetObject("CreditReports.Image")));
            this.rbtnCreditReports.SmallImage = ((System.Drawing.Image)(resources.GetObject("CreditReports.Image")));
            resources.ApplyResources(this.rbtnCreditReports, "rbtnCreditReports");
            this.rbtnCreditReports.Click += new System.EventHandler(this.rbtnCreditReports_Click);
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
            this.rtabClientInfo.Value = "1";
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
            // rbtnCommonPrintClientInfo
            // 
            this.rbtnCommonPrintClientInfo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCommonPrintClientInfo.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintClientInfo.Image")));
            this.rbtnCommonPrintClientInfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintClientInfo.SmallImage")));
            resources.ApplyResources(this.rbtnCommonPrintClientInfo, "rbtnCommonPrintClientInfo");
            this.rbtnCommonPrintClientInfo.Click += new System.EventHandler(this.rbtnCommonPrint_Click);
            // 
            // rbtnCommonPrintResContract
            // 
            this.rbtnCommonPrintResContract.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCommonPrintResContract.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintResContract.Image")));
            this.rbtnCommonPrintResContract.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintResContract.SmallImage")));
            resources.ApplyResources(this.rbtnCommonPrintResContract, "rbtnCommonPrintResContract");
            this.rbtnCommonPrintResContract.Click += new System.EventHandler(this.rbtnCommonPrint_Click);
            // 
            // rbtnCommonPrintEmpContract
            // 
            this.rbtnCommonPrintEmpContract.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCommonPrintEmpContract.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintEmpContract.Image")));
            this.rbtnCommonPrintEmpContract.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCommonPrintEmpContract.SmallImage")));
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
            // rtabExploreApps
            // 
            this.rtabExploreApps.Panels.Add(this.rpnlDesk);
            this.rtabExploreApps.Panels.Add(this.rpnlAppAction);
            this.rtabExploreApps.Panels.Add(this.rpnlSearchApp);
            this.rtabExploreApps.Panels.Add(this.rpnlCheckSpelling);
            this.rtabExploreApps.Panels.Add(this.rpnlPrintAndDoc);
            this.rtabExploreApps.Panels.Add(this.rpnlSaveApp);
            this.rtabExploreApps.Panels.Add(this.rpnlRefresh);
            resources.ApplyResources(this.rtabExploreApps, "rtabExploreApps");
            this.rtabExploreApps.Value = "2";
            // 
            // rpnlDesk
            // 
            this.rpnlDesk.ButtonMoreEnabled = false;
            this.rpnlDesk.Items.Add(this.rbtnChangeLocation);
            this.rpnlDesk.Items.Add(this.rbtnDesk);
            resources.ApplyResources(this.rpnlDesk, "rpnlDesk");
            // 
            // rbtnChangeLocation
            // 
            this.rbtnChangeLocation.Image = ((System.Drawing.Image)(resources.GetObject("rbtnChangeLocation.Image")));
            this.rbtnChangeLocation.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnChangeLocation.SmallImage")));
            this.rbtnChangeLocation.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnChangeLocation, "rbtnChangeLocation");
            // 
            // rbtnDesk
            // 
            this.rbtnDesk.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDesk.Image")));
            this.rbtnDesk.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDesk.SmallImage")));
            this.rbtnDesk.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnDesk, "rbtnDesk");
            this.rbtnDesk.DoubleClick += new System.EventHandler(this.rbtnDesk_DoubleClick);
            // 
            // rpnlAppAction
            // 
            this.rpnlAppAction.ButtonMoreEnabled = false;
            this.rpnlAppAction.Items.Add(this.rbtnAppAction);
            this.rpnlAppAction.Items.Add(this.rbtnGeoLookup);
            resources.ApplyResources(this.rpnlAppAction, "rpnlAppAction");
            // 
            // rbtnAppAction
            // 
            this.rbtnAppAction.DropDownItems.Add(this.rbtnCreateNewApp);
            this.rbtnAppAction.DropDownItems.Add(this.rbtnDeleteApp);
            this.rbtnAppAction.DropDownItems.Add(this.rbtnCopyApp);
            this.rbtnAppAction.DropDownItems.Add(this.rbtnMarkAppRoommates);
            this.rbtnAppAction.Image = ((System.Drawing.Image)(resources.GetObject("rbtnAppAction.Image")));
            this.rbtnAppAction.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnAppAction.SmallImage")));
            this.rbtnAppAction.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnAppAction, "rbtnAppAction");
            this.rbtnAppAction.DoubleClick += new System.EventHandler(this.rbtnAppAction_DoubleClick);
            // 
            // rbtnCreateNewApp
            // 
            this.rbtnCreateNewApp.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCreateNewApp.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCreateNewApp.Image")));
            this.rbtnCreateNewApp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCreateNewApp.SmallImage")));
            resources.ApplyResources(this.rbtnCreateNewApp, "rbtnCreateNewApp");
            this.rbtnCreateNewApp.Click += new System.EventHandler(this.rbtnCreateNewApp_Click);
            // 
            // rbtnDeleteApp
            // 
            this.rbtnDeleteApp.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDeleteApp.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDeleteApp.Image")));
            this.rbtnDeleteApp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDeleteApp.SmallImage")));
            resources.ApplyResources(this.rbtnDeleteApp, "rbtnDeleteApp");
            this.rbtnDeleteApp.Click += new System.EventHandler(this.rbtnDeleteApp_Click);
            // 
            // rbtnCopyApp
            // 
            this.rbtnCopyApp.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCopyApp.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCopyApp.Image")));
            this.rbtnCopyApp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCopyApp.SmallImage")));
            resources.ApplyResources(this.rbtnCopyApp, "rbtnCopyApp");
            this.rbtnCopyApp.Click += new System.EventHandler(this.rbtnCopyApp_Click);
            // 
            // rbtnMarkAppRoommates
            // 
            this.rbtnMarkAppRoommates.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnMarkAppRoommates.Image = ((System.Drawing.Image)(resources.GetObject("rbtnMarkAppRoommates.Image")));
            this.rbtnMarkAppRoommates.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnMarkAppRoommates.SmallImage")));
            resources.ApplyResources(this.rbtnMarkAppRoommates, "rbtnMarkAppRoommates");
            this.rbtnMarkAppRoommates.Click += new System.EventHandler(this.rbtnMarkAppRoommates_Click);
            // 
            // rbtnGeoLookup
            // 
            this.rbtnGeoLookup.Image = ((System.Drawing.Image)(resources.GetObject("rbtnGeoLookup.Image")));
            this.rbtnGeoLookup.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnGeoLookup.SmallImage")));
            resources.ApplyResources(this.rbtnGeoLookup, "rbtnGeoLookup");
            this.rbtnGeoLookup.Click += new System.EventHandler(this.rbtnGeoLookup_Click);
            // 
            // rpnlSearchApp
            // 
            this.rpnlSearchApp.ButtonMoreEnabled = false;
            this.rpnlSearchApp.Items.Add(this.rbtnSearchApp);
            this.rpnlSearchApp.Items.Add(this.rbtnArchive);
            resources.ApplyResources(this.rpnlSearchApp, "rpnlSearchApp");
            // 
            // rbtnSearchApp
            // 
            this.rbtnSearchApp.Image = ((System.Drawing.Image)(resources.GetObject("rbtnSearchApp.Image")));
            this.rbtnSearchApp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSearchApp.SmallImage")));
            resources.ApplyResources(this.rbtnSearchApp, "rbtnSearchApp");
            this.rbtnSearchApp.Click += new System.EventHandler(this.rbtnSearchApp_Click);
            // 
            // rbtnArchive
            // 
            this.rbtnArchive.Image = ((System.Drawing.Image)(resources.GetObject("rbtnArchive.Image")));
            this.rbtnArchive.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnArchive.SmallImage")));
            resources.ApplyResources(this.rbtnArchive, "rbtnArchive");
            this.rbtnArchive.Click += new System.EventHandler(this.rbtnArchive_Click);
            // 
            // rpnlCheckSpelling
            // 
            this.rpnlCheckSpelling.ButtonMoreEnabled = false;
            this.rpnlCheckSpelling.Items.Add(this.rbtnCheckSpelling);
            resources.ApplyResources(this.rpnlCheckSpelling, "rpnlCheckSpelling");
            // 
            // rbtnCheckSpelling
            // 
            this.rbtnCheckSpelling.DropDownItems.Add(this.rbtnCheckCurrTextBox);
            this.rbtnCheckSpelling.DropDownItems.Add(this.rbtnCheckCurrApp);
            this.rbtnCheckSpelling.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCheckSpelling.Image")));
            this.rbtnCheckSpelling.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCheckSpelling.SmallImage")));
            this.rbtnCheckSpelling.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnCheckSpelling, "rbtnCheckSpelling");
            // 
            // rbtnCheckCurrTextBox
            // 
            this.rbtnCheckCurrTextBox.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCheckCurrTextBox.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCheckCurrTextBox.Image")));
            this.rbtnCheckCurrTextBox.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCheckCurrTextBox.SmallImage")));
            resources.ApplyResources(this.rbtnCheckCurrTextBox, "rbtnCheckCurrTextBox");
            this.rbtnCheckCurrTextBox.Click += new System.EventHandler(this.rbtnCheckCurrTextBox_Click);
            // 
            // rbtnCheckCurrApp
            // 
            this.rbtnCheckCurrApp.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCheckCurrApp.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCheckCurrApp.Image")));
            this.rbtnCheckCurrApp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCheckCurrApp.SmallImage")));
            resources.ApplyResources(this.rbtnCheckCurrApp, "rbtnCheckCurrApp");
            this.rbtnCheckCurrApp.Click += new System.EventHandler(this.rbtnCheckCurrApp_Click);
            // 
            // rpnlPrintAndDoc
            // 
            this.rpnlPrintAndDoc.ButtonMoreEnabled = false;
            this.rpnlPrintAndDoc.Items.Add(this.rbtnPrintCoverSheet);
            this.rpnlPrintAndDoc.Items.Add(this.rbtnAppDatagrid);
            this.rpnlPrintAndDoc.Items.Add(this.rbtnEmailReport);
            this.rpnlPrintAndDoc.Items.Add(this.rbtnPrintReport);
            this.rpnlPrintAndDoc.Items.Add(this.rbtnUploadReport);
            resources.ApplyResources(this.rpnlPrintAndDoc, "rpnlPrintAndDoc");
            // 
            // rbtnPrintCoverSheet
            // 
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnRentalCover);
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnEmpVerCover);
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnEmpRefCover);
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnCriminalCover);
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnGenericCover);
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnDegreeVerCover);
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnCreditRefCover);
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnBankCover);
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnClientUpdate);
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnPrintConfirmPages);
            this.rbtnPrintCoverSheet.DropDownItems.Add(this.rbtnPrintFileCoverPages);
            this.rbtnPrintCoverSheet.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrintCoverSheet.Image")));
            this.rbtnPrintCoverSheet.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrintCoverSheet.SmallImage")));
            this.rbtnPrintCoverSheet.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnPrintCoverSheet, "rbtnPrintCoverSheet");
            // 
            // rbtnRentalCover
            // 
            this.rbtnRentalCover.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnRentalCover.Image = ((System.Drawing.Image)(resources.GetObject("rbtnRentalCover.Image")));
            this.rbtnRentalCover.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRentalCover.SmallImage")));
            resources.ApplyResources(this.rbtnRentalCover, "rbtnRentalCover");
            this.rbtnRentalCover.Click += new System.EventHandler(this.rbtnRentalCover_Click);
            // 
            // rbtnEmpVerCover
            // 
            this.rbtnEmpVerCover.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnEmpVerCover.Image = ((System.Drawing.Image)(resources.GetObject("rbtnEmpVerCover.Image")));
            this.rbtnEmpVerCover.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEmpVerCover.SmallImage")));
            resources.ApplyResources(this.rbtnEmpVerCover, "rbtnEmpVerCover");
            this.rbtnEmpVerCover.Click += new System.EventHandler(this.rbtnEmpVerCover_Click);
            // 
            // rbtnEmpRefCover
            // 
            this.rbtnEmpRefCover.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnEmpRefCover.Image = ((System.Drawing.Image)(resources.GetObject("rbtnEmpRefCover.Image")));
            this.rbtnEmpRefCover.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEmpRefCover.SmallImage")));
            resources.ApplyResources(this.rbtnEmpRefCover, "rbtnEmpRefCover");
            this.rbtnEmpRefCover.Click += new System.EventHandler(this.rbtnEmpRefCover_Click);
            // 
            // rbtnCriminalCover
            // 
            this.rbtnCriminalCover.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCriminalCover.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCriminalCover.Image")));
            this.rbtnCriminalCover.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCriminalCover.SmallImage")));
            resources.ApplyResources(this.rbtnCriminalCover, "rbtnCriminalCover");
            this.rbtnCriminalCover.Click += new System.EventHandler(this.rbtnCriminalCover_Click);
            // 
            // rbtnGenericCover
            // 
            this.rbtnGenericCover.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnGenericCover.Image = ((System.Drawing.Image)(resources.GetObject("rbtnGenericCover.Image")));
            this.rbtnGenericCover.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnGenericCover.SmallImage")));
            resources.ApplyResources(this.rbtnGenericCover, "rbtnGenericCover");
            this.rbtnGenericCover.Click += new System.EventHandler(this.rbtnGenericCover_Click);
            // 
            // rbtnDegreeVerCover
            // 
            this.rbtnDegreeVerCover.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDegreeVerCover.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDegreeVerCover.Image")));
            this.rbtnDegreeVerCover.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDegreeVerCover.SmallImage")));
            resources.ApplyResources(this.rbtnDegreeVerCover, "rbtnDegreeVerCover");
            this.rbtnDegreeVerCover.Click += new System.EventHandler(this.rbtnDegreeVerCover_Click);
            // 
            // rbtnCreditRefCover
            // 
            this.rbtnCreditRefCover.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnCreditRefCover.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCreditRefCover.Image")));
            this.rbtnCreditRefCover.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCreditRefCover.SmallImage")));
            resources.ApplyResources(this.rbtnCreditRefCover, "rbtnCreditRefCover");
            this.rbtnCreditRefCover.Click += new System.EventHandler(this.rbtnCreditRefCover_Click);
            // 
            // rbtnBankCover
            // 
            this.rbtnBankCover.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnBankCover.Image = ((System.Drawing.Image)(resources.GetObject("rbtnBankCover.Image")));
            this.rbtnBankCover.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnBankCover.SmallImage")));
            resources.ApplyResources(this.rbtnBankCover, "rbtnBankCover");
            this.rbtnBankCover.Click += new System.EventHandler(this.rbtnBankCover_Click);
            // 
            // rbtnClientUpdate
            // 
            this.rbtnClientUpdate.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnClientUpdate.Image = ((System.Drawing.Image)(resources.GetObject("rbtnClientUpdate.Image")));
            this.rbtnClientUpdate.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnClientUpdate.SmallImage")));
            resources.ApplyResources(this.rbtnClientUpdate, "rbtnClientUpdate");
            this.rbtnClientUpdate.Click += new System.EventHandler(this.rbtnClientUpdate_Click);
            // 
            // rbtnPrintConfirmPages
            // 
            this.rbtnPrintConfirmPages.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnPrintConfirmPages.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrintConfirmPages.Image")));
            this.rbtnPrintConfirmPages.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrintConfirmPages.SmallImage")));
            resources.ApplyResources(this.rbtnPrintConfirmPages, "rbtnPrintConfirmPages");
            this.rbtnPrintConfirmPages.Click += new System.EventHandler(this.rbtnPrintConfirmPages_Click);
            // 
            // rbtnPrintFileCoverPages
            // 
            this.rbtnPrintFileCoverPages.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnPrintFileCoverPages.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrintFileCoverPages.Image")));
            this.rbtnPrintFileCoverPages.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrintFileCoverPages.SmallImage")));
            resources.ApplyResources(this.rbtnPrintFileCoverPages, "rbtnPrintFileCoverPages");
            this.rbtnPrintFileCoverPages.Click += new System.EventHandler(this.rbtnPrintFileCoverPages_Click);
            // 
            // rbtnAppDatagrid
            // 
            this.rbtnAppDatagrid.DropDownItems.Add(this.rbtnDatagridSelectedApps);
            this.rbtnAppDatagrid.DropDownItems.Add(this.rbtnDatagridAllApps);
            this.rbtnAppDatagrid.Image = ((System.Drawing.Image)(resources.GetObject("rbtnAppDatagrid.Image")));
            this.rbtnAppDatagrid.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnAppDatagrid.SmallImage")));
            this.rbtnAppDatagrid.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnAppDatagrid, "rbtnAppDatagrid");
            // 
            // rbtnDatagridSelectedApps
            // 
            this.rbtnDatagridSelectedApps.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDatagridSelectedApps.Image = global::PaaApplication.Properties.Resources.tick_20x16;
            this.rbtnDatagridSelectedApps.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbtnDatagridSelectedApps.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rbtnDatagridSelectedApps.SmallImage = global::PaaApplication.Properties.Resources.tick_20x16;
            resources.ApplyResources(this.rbtnDatagridSelectedApps, "rbtnDatagridSelectedApps");
            this.rbtnDatagridSelectedApps.Click += new System.EventHandler(this.rbtnDatagridSelectedApps_Click);
            // 
            // rbtnDatagridAllApps
            // 
            this.rbtnDatagridAllApps.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDatagridAllApps.Image = global::PaaApplication.Properties.Resources.star_24x24;
            this.rbtnDatagridAllApps.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbtnDatagridAllApps.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.rbtnDatagridAllApps.SmallImage = global::PaaApplication.Properties.Resources.star_20x16;
            resources.ApplyResources(this.rbtnDatagridAllApps, "rbtnDatagridAllApps");
            this.rbtnDatagridAllApps.Click += new System.EventHandler(this.rbtnDatagridAllApps_Click);
            // 
            // rbtnEmailReport
            // 
            this.rbtnEmailReport.Image = ((System.Drawing.Image)(resources.GetObject("rbtnEmailReport.Image")));
            this.rbtnEmailReport.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEmailReport.SmallImage")));
            this.rbtnEmailReport.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnEmailReport, "rbtnEmailReport");
            // 
            // rbtnPrintReport
            // 
            this.rbtnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrintReport.Image")));
            this.rbtnPrintReport.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrintReport.SmallImage")));
            this.rbtnPrintReport.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnPrintReport, "rbtnPrintReport");
            // 
            // rbtnUploadReport
            // 
            this.rbtnUploadReport.Image = ((System.Drawing.Image)(resources.GetObject("rbtnUploadReport.Image")));
            this.rbtnUploadReport.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnUploadReport.SmallImage")));
            resources.ApplyResources(this.rbtnUploadReport, "rbtnUploadReport");
            this.rbtnUploadReport.Click += new System.EventHandler(this.rbtnUploadReport_Click);
            // 
            // rpnlSaveApp
            // 
            this.rpnlSaveApp.Items.Add(this.rbtnSaveApp);
            resources.ApplyResources(this.rpnlSaveApp, "rpnlSaveApp");
            // 
            // rbtnSaveApp
            // 
            this.rbtnSaveApp.Image = ((System.Drawing.Image)(resources.GetObject("rbtnSaveApp.Image")));
            this.rbtnSaveApp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSaveApp.SmallImage")));
            resources.ApplyResources(this.rbtnSaveApp, "rbtnSaveApp");
            this.rbtnSaveApp.Click += new System.EventHandler(this.rbtnSaveApp_Click);
            // 
            // rpnlRefresh
            // 
            this.rpnlRefresh.Items.Add(this.rbtnRefreshApp);
            resources.ApplyResources(this.rpnlRefresh, "rpnlRefresh");
            // 
            // rbtnRefreshApp
            // 
            this.rbtnRefreshApp.Image = ((System.Drawing.Image)(resources.GetObject("rbtnRefreshApp.Image")));
            this.rbtnRefreshApp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRefreshApp.SmallImage")));
            resources.ApplyResources(this.rbtnRefreshApp, "rbtnRefreshApp");
            this.rbtnRefreshApp.Click += new System.EventHandler(this.rbtnRefreshApp_Click);
            // 
            // rtabInfoResources
            // 
            this.rtabInfoResources.Panels.Add(this.rpnlInfoResource);
            this.rtabInfoResources.Panels.Add(this.ribbonPanel3);
            resources.ApplyResources(this.rtabInfoResources, "rtabInfoResources");
            this.rtabInfoResources.Value = "3";
            // 
            // rpnlInfoResource
            // 
            this.rpnlInfoResource.ButtonMoreEnabled = false;
            this.rpnlInfoResource.Image = ((System.Drawing.Image)(resources.GetObject("rpnlInfoResource.Image")));
            this.rpnlInfoResource.Items.Add(this.rbtnLandlordContact);
            this.rpnlInfoResource.Items.Add(this.rbtnCriminalInfo);
            this.rpnlInfoResource.Items.Add(this.rbtnEmployment);
            this.rpnlInfoResource.Items.Add(this.rbtnDocLib);
            resources.ApplyResources(this.rpnlInfoResource, "rpnlInfoResource");
            
            // 
            // rbtnDocLib
            // 
            this.rbtnDocLib.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDocLib.Image")));
            this.rbtnDocLib.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDocLib.SmallImage")));
            resources.ApplyResources(this.rbtnDocLib, "rbtnDocLib");
            this.rbtnDocLib.Click += new System.EventHandler(this.rbtnDocLib_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.rbtnRefreshInfoResources);
            resources.ApplyResources(this.ribbonPanel3, "ribbonPanel3");
            // 
            // rbtnRefreshInfoResources
            // 
            this.rbtnRefreshInfoResources.Image = ((System.Drawing.Image)(resources.GetObject("rbtnRefreshInfoResources.Image")));
            this.rbtnRefreshInfoResources.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRefreshInfoResources.SmallImage")));
            resources.ApplyResources(this.rbtnRefreshInfoResources, "rbtnRefreshInfoResources");
            this.rbtnRefreshInfoResources.Click += new System.EventHandler(this.rbtnRefreshInfoResources_Click);
            // 
            // rtabInvoicing
            // 
            this.rtabInvoicing.Panels.Add(this.rpnlSearchInvoices);
            this.rtabInvoicing.Panels.Add(this.rpnlBilling);
            this.rtabInvoicing.Panels.Add(this.rpnlInvoiceDoc);
            this.rtabInvoicing.Panels.Add(this.rpnlRefreshInv);
            resources.ApplyResources(this.rtabInvoicing, "rtabInvoicing");
            this.rtabInvoicing.Value = "4";
            // 
            // rpnlSearchInvoices
            // 
            this.rpnlSearchInvoices.ButtonMoreEnabled = false;
            this.rpnlSearchInvoices.Items.Add(this.rbtnSearchInvoices);
            this.rpnlSearchInvoices.Items.Add(this.rbtnSearchApplications);
            resources.ApplyResources(this.rpnlSearchInvoices, "rpnlSearchInvoices");
            // 
            // rbtnSearchInvoices
            // 
            this.rbtnSearchInvoices.DropDownItems.Add(this.ribbonButton15);
            this.rbtnSearchInvoices.Image = ((System.Drawing.Image)(resources.GetObject("rbtnSearchInvoices.Image")));
            this.rbtnSearchInvoices.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSearchInvoices.SmallImage")));
            resources.ApplyResources(this.rbtnSearchInvoices, "rbtnSearchInvoices");
            this.rbtnSearchInvoices.Click += new System.EventHandler(this.rbtnSearchInvoices_Click);
            // 
            // ribbonButton15
            // 
            this.ribbonButton15.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton15.Image")));
            this.ribbonButton15.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton15.SmallImage")));
            resources.ApplyResources(this.ribbonButton15, "ribbonButton15");
            // 
            // rbtnSearchApplications
            // 
            this.rbtnSearchApplications.Image = ((System.Drawing.Image)(resources.GetObject("rbtnSearchApplications.Image")));
            this.rbtnSearchApplications.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSearchApplications.SmallImage")));
            resources.ApplyResources(this.rbtnSearchApplications, "rbtnSearchApplications");
            this.rbtnSearchApplications.Click += new System.EventHandler(this.rbtnSearchApplications_Click);
            // 
            // rpnlBilling
            // 
            this.rpnlBilling.ButtonMoreEnabled = false;
            this.rpnlBilling.Items.Add(this.rbtnBillingMonth);
            resources.ApplyResources(this.rpnlBilling, "rpnlBilling");
            // 
            // rbtnBillingMonth
            // 
            this.rbtnBillingMonth.DropDownItems.Add(this.rbtnBillingMonthSub1);
            this.rbtnBillingMonth.DropDownItems.Add(this.rbtnBillingMonthSub2);
            this.rbtnBillingMonth.DropDownItems.Add(this.rbtnBillingMonthSub3);
            this.rbtnBillingMonth.Image = ((System.Drawing.Image)(resources.GetObject("rbtnBillingMonth.Image")));
            this.rbtnBillingMonth.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnBillingMonth.SmallImage")));
            this.rbtnBillingMonth.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnBillingMonth, "rbtnBillingMonth");
            this.rbtnBillingMonth.DoubleClick += new System.EventHandler(this.rbtnBillingMonth_DoubleClick);
            // 
            // rbtnBillingMonthSub1
            // 
            this.rbtnBillingMonthSub1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnBillingMonthSub1.Image = ((System.Drawing.Image)(resources.GetObject("rbtnBillingMonthSub1.Image")));
            this.rbtnBillingMonthSub1.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnBillingMonthSub1.SmallImage")));
            // 
            // rbtnBillingMonthSub2
            // 
            this.rbtnBillingMonthSub2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnBillingMonthSub2.Image = ((System.Drawing.Image)(resources.GetObject("rbtnBillingMonthSub2.Image")));
            this.rbtnBillingMonthSub2.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnBillingMonthSub2.SmallImage")));
            // 
            // rbtnBillingMonthSub3
            // 
            this.rbtnBillingMonthSub3.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnBillingMonthSub3.Image = ((System.Drawing.Image)(resources.GetObject("rbtnBillingMonthSub3.Image")));
            this.rbtnBillingMonthSub3.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnBillingMonthSub3.SmallImage")));
            // 
            // rpnlInvoiceDoc
            // 
            this.rpnlInvoiceDoc.ButtonMoreEnabled = false;
            this.rpnlInvoiceDoc.Items.Add(this.rbtnInvoiceDataGrid);
            this.rpnlInvoiceDoc.Items.Add(this.rbtnInvoicePrintMenu);
            resources.ApplyResources(this.rpnlInvoiceDoc, "rpnlInvoiceDoc");
            // 
            // rbtnInvoiceDataGrid
            // 
            this.rbtnInvoiceDataGrid.DropDownItems.Add(this.rbtnDgAllClients);
            this.rbtnInvoiceDataGrid.DropDownItems.Add(this.rbtnDgSelectedClients);
            this.rbtnInvoiceDataGrid.DropDownItems.Add(this.rbtnDgAllShownInvoices);
            this.rbtnInvoiceDataGrid.DropDownItems.Add(this.rbtnDgSelectedInvoices);
            this.rbtnInvoiceDataGrid.DropDownItems.Add(this.rbtnDgAllShownApps);
            this.rbtnInvoiceDataGrid.DropDownItems.Add(this.rbtnDgSelectedApps);
            this.rbtnInvoiceDataGrid.Image = ((System.Drawing.Image)(resources.GetObject("rbtnInvoiceDataGrid.Image")));
            this.rbtnInvoiceDataGrid.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnInvoiceDataGrid.SmallImage")));
            this.rbtnInvoiceDataGrid.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnInvoiceDataGrid, "rbtnInvoiceDataGrid");
            // 
            // rbtnDgAllClients
            // 
            this.rbtnDgAllClients.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDgAllClients.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDgAllClients.Image")));
            this.rbtnDgAllClients.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDgAllClients.SmallImage")));
            resources.ApplyResources(this.rbtnDgAllClients, "rbtnDgAllClients");
            this.rbtnDgAllClients.Click += new System.EventHandler(this.rbtnDgAllClients_Click);
            // 
            // rbtnDgSelectedClients
            // 
            this.rbtnDgSelectedClients.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDgSelectedClients.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDgSelectedClients.Image")));
            this.rbtnDgSelectedClients.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDgSelectedClients.SmallImage")));
            resources.ApplyResources(this.rbtnDgSelectedClients, "rbtnDgSelectedClients");
            this.rbtnDgSelectedClients.Click += new System.EventHandler(this.rbtnDgSelectedClients_Click);
            // 
            // rbtnDgAllShownInvoices
            // 
            this.rbtnDgAllShownInvoices.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDgAllShownInvoices.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDgAllShownInvoices.Image")));
            this.rbtnDgAllShownInvoices.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDgAllShownInvoices.SmallImage")));
            resources.ApplyResources(this.rbtnDgAllShownInvoices, "rbtnDgAllShownInvoices");
            this.rbtnDgAllShownInvoices.Click += new System.EventHandler(this.rbtnDgAllShownInvoices_Click);
            // 
            // rbtnDgSelectedInvoices
            // 
            this.rbtnDgSelectedInvoices.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDgSelectedInvoices.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDgSelectedInvoices.Image")));
            this.rbtnDgSelectedInvoices.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDgSelectedInvoices.SmallImage")));
            resources.ApplyResources(this.rbtnDgSelectedInvoices, "rbtnDgSelectedInvoices");
            this.rbtnDgSelectedInvoices.Click += new System.EventHandler(this.rbtnDgSelectedInvoices_Click);
            // 
            // rbtnDgAllShownApps
            // 
            this.rbtnDgAllShownApps.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDgAllShownApps.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDgAllShownApps.Image")));
            this.rbtnDgAllShownApps.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDgAllShownApps.SmallImage")));
            resources.ApplyResources(this.rbtnDgAllShownApps, "rbtnDgAllShownApps");
            this.rbtnDgAllShownApps.Click += new System.EventHandler(this.rbtnDgAllShownApps_Click);
            // 
            // rbtnDgSelectedApps
            // 
            this.rbtnDgSelectedApps.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnDgSelectedApps.Image = ((System.Drawing.Image)(resources.GetObject("rbtnDgSelectedApps.Image")));
            this.rbtnDgSelectedApps.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnDgSelectedApps.SmallImage")));
            resources.ApplyResources(this.rbtnDgSelectedApps, "rbtnDgSelectedApps");
            this.rbtnDgSelectedApps.Click += new System.EventHandler(this.rbtnDgSelectedApps_Click);
            // 
            // rbtnInvoicePrintMenu
            // 
            this.rbtnInvoicePrintMenu.DropDownItems.Add(this.rbtnPrtClientLabels);
            this.rbtnInvoicePrintMenu.DropDownItems.Add(this.rbtnPrtClientInfoSheet);
            this.rbtnInvoicePrintMenu.DropDownItems.Add(this.rbtnPrtResidentClienCtact);
            this.rbtnInvoicePrintMenu.DropDownItems.Add(this.rbtnPrtEmpServCtact);
            this.rbtnInvoicePrintMenu.DropDownItems.Add(this.rbtnPrtSelectedInvoices);
            this.rbtnInvoicePrintMenu.DropDownItems.Add(this.rbtnPrtAllInvoices);
            this.rbtnInvoicePrintMenu.DropDownItems.Add(this.rbtnPrtAllShownInvs);
            this.rbtnInvoicePrintMenu.DropDownItems.Add(this.rbtnPrtSelectedInvs);
            this.rbtnInvoicePrintMenu.Image = ((System.Drawing.Image)(resources.GetObject("rbtnInvoicePrintMenu.Image")));
            this.rbtnInvoicePrintMenu.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnInvoicePrintMenu.SmallImage")));
            this.rbtnInvoicePrintMenu.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            resources.ApplyResources(this.rbtnInvoicePrintMenu, "rbtnInvoicePrintMenu");
            this.rbtnInvoicePrintMenu.DoubleClick += new System.EventHandler(this.rbtnInvoicePrintMenu_DoubleClick);
            // 
            // rbtnPrtClientLabels
            // 
            this.rbtnPrtClientLabels.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnPrtClientLabels.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrtClientLabels.Image")));
            this.rbtnPrtClientLabels.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrtClientLabels.SmallImage")));
            resources.ApplyResources(this.rbtnPrtClientLabels, "rbtnPrtClientLabels");
            this.rbtnPrtClientLabels.Visible = false;
            // 
            // rbtnPrtClientInfoSheet
            // 
            this.rbtnPrtClientInfoSheet.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnPrtClientInfoSheet.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrtClientInfoSheet.Image")));
            this.rbtnPrtClientInfoSheet.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrtClientInfoSheet.SmallImage")));
            resources.ApplyResources(this.rbtnPrtClientInfoSheet, "rbtnPrtClientInfoSheet");
            this.rbtnPrtClientInfoSheet.Click += new System.EventHandler(this.rbtnPrtClientCommon_Click);
            // 
            // rbtnPrtResidentClienCtact
            // 
            this.rbtnPrtResidentClienCtact.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnPrtResidentClienCtact.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrtResidentClienCtact.Image")));
            this.rbtnPrtResidentClienCtact.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrtResidentClienCtact.SmallImage")));
            resources.ApplyResources(this.rbtnPrtResidentClienCtact, "rbtnPrtResidentClienCtact");
            this.rbtnPrtResidentClienCtact.Click += new System.EventHandler(this.rbtnPrtClientCommon_Click);
            // 
            // rbtnPrtEmpServCtact
            // 
            this.rbtnPrtEmpServCtact.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnPrtEmpServCtact.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrtEmpServCtact.Image")));
            this.rbtnPrtEmpServCtact.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrtEmpServCtact.SmallImage")));
            resources.ApplyResources(this.rbtnPrtEmpServCtact, "rbtnPrtEmpServCtact");
            this.rbtnPrtEmpServCtact.Click += new System.EventHandler(this.rbtnPrtClientCommon_Click);
            // 
            // rbtnPrtSelectedInvoices
            // 
            this.rbtnPrtSelectedInvoices.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnPrtSelectedInvoices.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrtSelectedInvoices.Image")));
            this.rbtnPrtSelectedInvoices.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrtSelectedInvoices.SmallImage")));
            resources.ApplyResources(this.rbtnPrtSelectedInvoices, "rbtnPrtSelectedInvoices");
            this.rbtnPrtSelectedInvoices.Click += new System.EventHandler(this.rbtnPrtSelectedInvoices_Click);
            // 
            // rbtnPrtAllInvoices
            // 
            this.rbtnPrtAllInvoices.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnPrtAllInvoices.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrtAllInvoices.Image")));
            this.rbtnPrtAllInvoices.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrtAllInvoices.SmallImage")));
            resources.ApplyResources(this.rbtnPrtAllInvoices, "rbtnPrtAllInvoices");
            this.rbtnPrtAllInvoices.Click += new System.EventHandler(this.rbtnPrtAllInvoices_Click);
            // 
            // rbtnPrtAllShownInvs
            // 
            this.rbtnPrtAllShownInvs.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnPrtAllShownInvs.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrtAllShownInvs.Image")));
            this.rbtnPrtAllShownInvs.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrtAllShownInvs.SmallImage")));
            resources.ApplyResources(this.rbtnPrtAllShownInvs, "rbtnPrtAllShownInvs");
            this.rbtnPrtAllShownInvs.Click += new System.EventHandler(this.rbtnPrtAllShownInvs_Click);
            // 
            // rbtnPrtSelectedInvs
            // 
            this.rbtnPrtSelectedInvs.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtnPrtSelectedInvs.Image = ((System.Drawing.Image)(resources.GetObject("rbtnPrtSelectedInvs.Image")));
            this.rbtnPrtSelectedInvs.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnPrtSelectedInvs.SmallImage")));
            resources.ApplyResources(this.rbtnPrtSelectedInvs, "rbtnPrtSelectedInvs");
            this.rbtnPrtSelectedInvs.Click += new System.EventHandler(this.rbtnPrtSelectedInvs_Click);
            // 
            // rpnlRefreshInv
            // 
            this.rpnlRefreshInv.Items.Add(this.rbtnRefreshInvoice);
            resources.ApplyResources(this.rpnlRefreshInv, "rpnlRefreshInv");
            // 
            // rbtnRefreshInvoice
            // 
            this.rbtnRefreshInvoice.Image = ((System.Drawing.Image)(resources.GetObject("rbtnRefreshInvoice.Image")));
            this.rbtnRefreshInvoice.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRefreshInvoice.SmallImage")));
            resources.ApplyResources(this.rbtnRefreshInvoice, "rbtnRefreshInvoice");
            this.rbtnRefreshInvoice.Click += new System.EventHandler(this.rbtnRefreshInvoice_Click);
            // 
            // rtabUserManager
            // 
            this.rtabUserManager.Panels.Add(this.rpnlUserMgt);
            this.rtabUserManager.Panels.Add(this.rpnlRoleMgt);
            this.rtabUserManager.Panels.Add(this.rpnlBtnSaveUser);
            this.rtabUserManager.Panels.Add(this.rpnlRefreshUserManager);
            resources.ApplyResources(this.rtabUserManager, "rtabUserManager");
            this.rtabUserManager.Value = "5";
            // 
            // rpnlUserMgt
            // 
            this.rpnlUserMgt.ButtonMoreEnabled = false;
            this.rpnlUserMgt.Items.Add(this.rbtnMyProfile);
            this.rpnlUserMgt.Items.Add(this.rbtnUserMgt);
            resources.ApplyResources(this.rpnlUserMgt, "rpnlUserMgt");
            // 
            // rbtnMyProfile
            // 
            this.rbtnMyProfile.DropDownItems.Add(this.ribbonButton14);
            this.rbtnMyProfile.Image = ((System.Drawing.Image)(resources.GetObject("rbtnMyProfile.Image")));
            this.rbtnMyProfile.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnMyProfile.SmallImage")));
            resources.ApplyResources(this.rbtnMyProfile, "rbtnMyProfile");
            this.rbtnMyProfile.Click += new System.EventHandler(this.rbtnMyProfile_Click);
            // 
            // ribbonButton14
            // 
            this.ribbonButton14.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton14.Image")));
            this.ribbonButton14.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton14.SmallImage")));
            resources.ApplyResources(this.ribbonButton14, "ribbonButton14");
            // 
            // rbtnUserMgt
            // 
            this.rbtnUserMgt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnUserMgt.Image")));
            this.rbtnUserMgt.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnUserMgt.SmallImage")));
            resources.ApplyResources(this.rbtnUserMgt, "rbtnUserMgt");
            this.rbtnUserMgt.Click += new System.EventHandler(this.rbtnUserMgt_Click);
            // 
            // rpnlRoleMgt
            // 
            this.rpnlRoleMgt.ButtonMoreEnabled = false;
            this.rpnlRoleMgt.Items.Add(this.rbtnRoleMgt);
            resources.ApplyResources(this.rpnlRoleMgt, "rpnlRoleMgt");
            // 
            // rbtnRoleMgt
            // 
            this.rbtnRoleMgt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnRoleMgt.Image")));
            this.rbtnRoleMgt.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRoleMgt.SmallImage")));
            resources.ApplyResources(this.rbtnRoleMgt, "rbtnRoleMgt");
            this.rbtnRoleMgt.Click += new System.EventHandler(this.rbtnRoleMgt_Click);
            // 
            // rpnlBtnSaveUser
            // 
            this.rpnlBtnSaveUser.Items.Add(this.rbtnSaveUser);
            resources.ApplyResources(this.rpnlBtnSaveUser, "rpnlBtnSaveUser");
            // 
            // rbtnSaveUser
            // 
            this.rbtnSaveUser.Image = ((System.Drawing.Image)(resources.GetObject("rbtnSaveUser.Image")));
            this.rbtnSaveUser.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSaveUser.SmallImage")));
            resources.ApplyResources(this.rbtnSaveUser, "rbtnSaveUser");
            this.rbtnSaveUser.Click += new System.EventHandler(this.rbtnSaveUser_Click);
            // 
            // rpnlRefreshUserManager
            // 
            this.rpnlRefreshUserManager.Items.Add(this.rbtnRefreshUserManager);
            resources.ApplyResources(this.rpnlRefreshUserManager, "rpnlRefreshUserManager");
            // 
            // rbtnRefreshUserManager
            // 
            this.rbtnRefreshUserManager.Image = global::PaaApplication.Properties.Resources.refresh;
            this.rbtnRefreshUserManager.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRefreshUserManager.SmallImage")));
            resources.ApplyResources(this.rbtnRefreshUserManager, "rbtnRefreshUserManager");
            this.rbtnRefreshUserManager.Click += new System.EventHandler(this.rbtnRefreshUserManager_Click);
            // 
            // rtabCommonDatagrid
            // 
            this.rtabCommonDatagrid.Panels.Add(this.rpnlDataGrid);
            resources.ApplyResources(this.rtabCommonDatagrid, "rtabCommonDatagrid");
            this.rtabCommonDatagrid.Value = "6";
            // 
            // rpnlDataGrid
            // 
            this.rpnlDataGrid.Items.Add(this.rbtnApplication);
            this.rpnlDataGrid.Items.Add(this.rbtnClients);
            this.rpnlDataGrid.Items.Add(this.rbtnInvoices);
            resources.ApplyResources(this.rpnlDataGrid, "rpnlDataGrid");
            // 
            // rbtnApplication
            // 
            this.rbtnApplication.DropDownItems.Add(this.ribbonButton17);
            this.rbtnApplication.Image = ((System.Drawing.Image)(resources.GetObject("rbtnApplication.Image")));
            this.rbtnApplication.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnApplication.SmallImage")));
            resources.ApplyResources(this.rbtnApplication, "rbtnApplication");
            this.rbtnApplication.Click += new System.EventHandler(this.rbtnApplication_Click);
            // 
            // ribbonButton17
            // 
            this.ribbonButton17.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton17.Image")));
            this.ribbonButton17.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton17.SmallImage")));
            resources.ApplyResources(this.ribbonButton17, "ribbonButton17");
            // 
            // rbtnClients
            // 
            this.rbtnClients.DropDownItems.Add(this.ribbonButton16);
            this.rbtnClients.Image = ((System.Drawing.Image)(resources.GetObject("rbtnClients.Image")));
            this.rbtnClients.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnClients.SmallImage")));
            resources.ApplyResources(this.rbtnClients, "rbtnClients");
            this.rbtnClients.Click += new System.EventHandler(this.rbtnClients_Click);
            // 
            // ribbonButton16
            // 
            this.ribbonButton16.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton16.Image")));
            this.ribbonButton16.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton16.SmallImage")));
            resources.ApplyResources(this.ribbonButton16, "ribbonButton16");
            // 
            // rbtnInvoices
            // 
            this.rbtnInvoices.Image = ((System.Drawing.Image)(resources.GetObject("rbtnInvoices.Image")));
            this.rbtnInvoices.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnInvoices.SmallImage")));
            resources.ApplyResources(this.rbtnInvoices, "rbtnInvoices");
            this.rbtnInvoices.Click += new System.EventHandler(this.rbtnInvoices_Click);
            // 
            // rtabAdministration
            // 
            this.rtabAdministration.Panels.Add(this.rpnlAdministration);
            this.rtabAdministration.Panels.Add(this.rpnlSystemConfig);
            this.rtabAdministration.Panels.Add(this.rpnlStandardTemplatesButtons);
            this.rtabAdministration.Panels.Add(this.rpnlRefreshAdministration);
            resources.ApplyResources(this.rtabAdministration, "rtabAdministration");
            this.rtabAdministration.Value = "7";
            // 
            // rpnlAdministration
            // 
            this.rpnlAdministration.Items.Add(this.rbtnReportMgt);
            this.rpnlAdministration.Items.Add(this.rbtnStandardTemp);
            this.rpnlAdministration.Items.Add(this.rbtnInternetTool);
            resources.ApplyResources(this.rpnlAdministration, "rpnlAdministration");
            // 
            // rbtnReportMgt
            // 
            this.rbtnReportMgt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnReportMgt.Image")));
            this.rbtnReportMgt.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnReportMgt.SmallImage")));
            resources.ApplyResources(this.rbtnReportMgt, "rbtnReportMgt");
            this.rbtnReportMgt.Click += new System.EventHandler(this.rbtnReportMgt_Click);
            // 
            // rbtnStandardTemp
            // 
            this.rbtnStandardTemp.Image = ((System.Drawing.Image)(resources.GetObject("rbtnStandardTemp.Image")));
            this.rbtnStandardTemp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnStandardTemp.SmallImage")));
            resources.ApplyResources(this.rbtnStandardTemp, "rbtnStandardTemp");
            this.rbtnStandardTemp.Click += new System.EventHandler(this.rbtnStandardTemp_Click);
            // 
            // rbtnInternetTool
            // 
            this.rbtnInternetTool.Image = ((System.Drawing.Image)(resources.GetObject("rbtnInternetTool.Image")));
            this.rbtnInternetTool.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnInternetTool.SmallImage")));
            resources.ApplyResources(this.rbtnInternetTool, "rbtnInternetTool");
            this.rbtnInternetTool.Click += new System.EventHandler(this.rbtnInternetTool_Click);
            // 
            // rpnlSystemConfig
            // 
            this.rpnlSystemConfig.Items.Add(this.rbtnSystemConfg);
            resources.ApplyResources(this.rpnlSystemConfig, "rpnlSystemConfig");
            // 
            // rbtnSystemConfg
            // 
            this.rbtnSystemConfg.Image = ((System.Drawing.Image)(resources.GetObject("rbtnSystemConfg.Image")));
            this.rbtnSystemConfg.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnSystemConfg.SmallImage")));
            resources.ApplyResources(this.rbtnSystemConfg, "rbtnSystemConfg");
            this.rbtnSystemConfg.Click += new System.EventHandler(this.rbtnSystemConfg_Click);
            // 
            // rpnlStandardTemplatesButtons
            // 
            this.rpnlStandardTemplatesButtons.Items.Add(this.rbtnStandardTemplatesSave);
            resources.ApplyResources(this.rpnlStandardTemplatesButtons, "rpnlStandardTemplatesButtons");
            // 
            // rbtnStandardTemplatesSave
            // 
            this.rbtnStandardTemplatesSave.Image = ((System.Drawing.Image)(resources.GetObject("rbtnStandardTemplatesSave.Image")));
            this.rbtnStandardTemplatesSave.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnStandardTemplatesSave.SmallImage")));
            resources.ApplyResources(this.rbtnStandardTemplatesSave, "rbtnStandardTemplatesSave");
            this.rbtnStandardTemplatesSave.Click += new System.EventHandler(this.rbtnTemplateSave_Click);
            // 
            // rpnlRefreshAdministration
            // 
            this.rpnlRefreshAdministration.Items.Add(this.rbtnRefreshAdministration);
            resources.ApplyResources(this.rpnlRefreshAdministration, "rpnlRefreshAdministration");
            // 
            // rbtnRefreshAdministration
            // 
            this.rbtnRefreshAdministration.Image = global::PaaApplication.Properties.Resources.refresh;
            this.rbtnRefreshAdministration.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnRefreshAdministration.SmallImage")));
            resources.ApplyResources(this.rbtnRefreshAdministration, "rbtnRefreshAdministration");
            this.rbtnRefreshAdministration.Click += new System.EventHandler(this.rbtnRefreshAdministration_Click);
            // 
            // pnlContentDisplay
            // 
            resources.ApplyResources(this.pnlContentDisplay, "pnlContentDisplay");
            this.pnlContentDisplay.BackColor = System.Drawing.SystemColors.Window;
            this.pnlContentDisplay.Name = "pnlContentDisplay";
            // 
            // mnuMaster
            // 
            this.mnuMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttlblClock,
            this.sttlblCount,
            this.sttlblAutoSave});
            resources.ApplyResources(this.mnuMaster, "mnuMaster");
            this.mnuMaster.Name = "mnuMaster";
            // 
            // sttlblClock
            // 
            this.sttlblClock.Name = "sttlblClock";
            resources.ApplyResources(this.sttlblClock, "sttlblClock");
            // 
            // sttlblCount
            // 
            this.sttlblCount.Name = "sttlblCount";
            resources.ApplyResources(this.sttlblCount, "sttlblCount");
            // 
            // sttlblAutoSave
            // 
            this.sttlblAutoSave.Name = "sttlblAutoSave";
            resources.ApplyResources(this.sttlblAutoSave, "sttlblAutoSave");
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.PaleGoldenrod;
            resources.ApplyResources(this.btnLogout, "btnLogout");
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // ribbonButton9
            // 
            this.ribbonButton9.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton9.Image")));
            this.ribbonButton9.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton9.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton9.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton9.SmallImage")));
            resources.ApplyResources(this.ribbonButton9, "ribbonButton9");
            this.ribbonButton9.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            // 
            // ribbonButton10
            // 
            this.ribbonButton10.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton10.Image")));
            this.ribbonButton10.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton10.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton10.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton10.SmallImage")));
            resources.ApplyResources(this.ribbonButton10, "ribbonButton10");
            this.ribbonButton10.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Right;
            // 
            // FormMaster
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.mnuMaster);
            this.Controls.Add(this.pnlContentDisplay);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMaster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMaster_FormClosing);
            this.Load += new System.EventHandler(this.frmMaster_Load);
            this.VisibleChanged += new System.EventHandler(this.FormMaster_VisibleChanged);
            this.mnuMaster.ResumeLayout(false);
            this.mnuMaster.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }     

        #endregion

        private System.Windows.Forms.Ribbon ribbon;
        
        private System.Windows.Forms.RibbonTab rtabAutoDocument;
        private System.Windows.Forms.RibbonTab rtabClientInfo;
        private System.Windows.Forms.RibbonTab rtabExploreApps;
        private System.Windows.Forms.RibbonTab rtabInfoResources;
        private System.Windows.Forms.RibbonTab rtabInvoicing;
        private System.Windows.Forms.RibbonTab rtabUserManager;
        private System.Windows.Forms.RibbonTab rtabCommonDatagrid;
        private System.Windows.Forms.RibbonTab rtabAdministration;

        private System.Windows.Forms.RibbonPanel rpnlAutoDoc;
        private System.Windows.Forms.RibbonButton rbtnAutoDoc;
        private System.Windows.Forms.RibbonButton rbtnAutoReport;
        private System.Windows.Forms.RibbonPanel rpnlEditTimecard;
        private System.Windows.Forms.RibbonButton rbtnEditTimecard;
        private System.Windows.Forms.RibbonPanel rpnlCommonChart;
        private System.Windows.Forms.RibbonButton rbtnCommonChart;
        private System.Windows.Forms.RibbonButton rbtnCustomChart;
        private System.Windows.Forms.RibbonPanel rpnlCreditReports;
        private System.Windows.Forms.RibbonButton rbtnCreditReports;
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
        private System.Windows.Forms.RibbonPanel rpnlInfoResource;
        private System.Windows.Forms.RibbonButton rbtnLandlordContact;
        private System.Windows.Forms.RibbonButton ribbonButton8;
        private System.Windows.Forms.RibbonButton rbtnCriminalInfo;
        private System.Windows.Forms.RibbonButton rbtnEmployment;
        private System.Windows.Forms.RibbonButton rbtnDocLib;
        private System.Windows.Forms.StatusStrip mnuMaster;
        private System.Windows.Forms.ToolStripStatusLabel sttlblClock;
        private System.Windows.Forms.ToolStripStatusLabel sttlblCount;
        private System.Windows.Forms.RibbonPanel rpnlDesk;
        private System.Windows.Forms.RibbonButton rbtnChangeLocation;
        private System.Windows.Forms.RibbonButton rbtnDesk;
        private System.Windows.Forms.RibbonPanel rpnlAppAction;
        private System.Windows.Forms.RibbonButton rbtnAppAction;
        private System.Windows.Forms.RibbonButton rbtnGeoLookup;
        private System.Windows.Forms.RibbonPanel rpnlSearchApp;
        private System.Windows.Forms.RibbonButton rbtnSearchApp;
        private System.Windows.Forms.RibbonButton rbtnArchive;
        private System.Windows.Forms.RibbonPanel rpnlCheckSpelling;
        private System.Windows.Forms.RibbonButton rbtnCheckSpelling;
        private System.Windows.Forms.RibbonPanel rpnlPrintAndDoc;
        private System.Windows.Forms.RibbonButton rbtnPrintCoverSheet;
        private System.Windows.Forms.RibbonButton rbtnAppDatagrid;
        private System.Windows.Forms.RibbonButton rbtnEmailReport;
        private System.Windows.Forms.RibbonButton rbtnCheckCurrTextBox;
        private System.Windows.Forms.RibbonButton rbtnCheckCurrApp;
        private System.Windows.Forms.RibbonPanel rpnlUserMgt;
        private System.Windows.Forms.RibbonButton rbtnMyProfile;
        private System.Windows.Forms.RibbonButton ribbonButton14;
        private System.Windows.Forms.RibbonButton rbtnUserMgt;
        private System.Windows.Forms.RibbonPanel rpnlRoleMgt;
        private System.Windows.Forms.RibbonButton rbtnRoleMgt;
        private System.Windows.Forms.RibbonPanel rpnlSearchInvoices;
        private System.Windows.Forms.RibbonButton rbtnSearchInvoices;
        private System.Windows.Forms.RibbonButton ribbonButton15;
        private System.Windows.Forms.RibbonButton rbtnSearchApplications;
        private System.Windows.Forms.RibbonPanel rpnlBilling;
        private System.Windows.Forms.RibbonButton rbtnBillingMonth;
        private System.Windows.Forms.RibbonPanel rpnlInvoiceDoc;
        private System.Windows.Forms.RibbonButton rbtnInvoiceDataGrid;
        private System.Windows.Forms.RibbonButton rbtnDgAllClients;
        private System.Windows.Forms.RibbonButton rbtnDgSelectedClients;
        private System.Windows.Forms.RibbonButton rbtnDgAllShownInvoices;
        private System.Windows.Forms.RibbonButton rbtnDgSelectedInvoices;
        private System.Windows.Forms.RibbonButton rbtnDgAllShownApps;
        private System.Windows.Forms.RibbonButton rbtnDgSelectedApps;
        private System.Windows.Forms.RibbonButton rbtnInvoicePrintMenu;
        private System.Windows.Forms.RibbonButton rbtnPrtClientLabels;
        private System.Windows.Forms.RibbonButton rbtnPrtClientInfoSheet;
        private System.Windows.Forms.RibbonButton rbtnPrtResidentClienCtact;
        private System.Windows.Forms.RibbonButton rbtnPrtEmpServCtact;
        private System.Windows.Forms.RibbonButton rbtnPrtSelectedInvoices;
        private System.Windows.Forms.RibbonButton rbtnPrtAllInvoices;
        private System.Windows.Forms.RibbonButton rbtnPrtAllShownInvs;
        private System.Windows.Forms.RibbonButton rbtnPrtSelectedInvs;
        private System.Windows.Forms.RibbonPanel rpnlDataGrid;
        private System.Windows.Forms.RibbonButton rbtnApplication;
        private System.Windows.Forms.RibbonButton rbtnClients;
        private System.Windows.Forms.RibbonButton ribbonButton17;
        private System.Windows.Forms.RibbonButton ribbonButton16;
        private System.Windows.Forms.RibbonButton rbtnInvoices;
        private System.Windows.Forms.RibbonPanel rpnlAdministration;
        private System.Windows.Forms.RibbonButton rbtnReportMgt;
        private System.Windows.Forms.RibbonButton rbtnStandardTemp;
        private System.Windows.Forms.RibbonButton rbtnInternetTool;
        private System.Windows.Forms.RibbonPanel rpnlSystemConfig;
        private System.Windows.Forms.RibbonButton rbtnSystemConfg;
        private System.Windows.Forms.RibbonPanel rpnlSaveClient;
        private System.Windows.Forms.RibbonButton rbtnSaveClient;
        private System.Windows.Forms.RibbonPanel rpnlSaveApp;
        private System.Windows.Forms.RibbonButton rbtnSaveApp;
        private System.Windows.Forms.RibbonPanel rpnlBtnSaveUser;
        private System.Windows.Forms.RibbonButton rbtnSaveUser;
        private System.Windows.Forms.RibbonPanel rpnlStandardTemplatesButtons;
        private System.Windows.Forms.RibbonButton rbtnStandardTemplatesSave;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.RibbonButton rbtnCreateNewApp;
        private System.Windows.Forms.RibbonButton rbtnDeleteApp;
        private System.Windows.Forms.RibbonButton rbtnCopyApp;
        private System.Windows.Forms.RibbonButton rbtnMarkAppRoommates;
        private System.Windows.Forms.RibbonButton rbtnPrintReport;
        private System.Windows.Forms.RibbonButton rbtnUploadReport;
        private System.Windows.Forms.RibbonButton rbtnDatagridSelectedApps;
        private System.Windows.Forms.RibbonButton rbtnDatagridAllApps;
        private System.Windows.Forms.RibbonButton rbtnBillingMonthSub1;
        private System.Windows.Forms.RibbonButton rbtnBillingMonthSub2;
        private System.Windows.Forms.RibbonButton rbtnBillingMonthSub3;
        private System.Windows.Forms.Timer timerTriggerLogOut;
        private System.Windows.Forms.ToolStripStatusLabel sttlblAutoSave;
        private System.Windows.Forms.RibbonPanel rpnlRefresh;
        private System.Windows.Forms.RibbonButton rbtnRefreshApp;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rbtnRefreshClient;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton rbtnRefreshInfoResources;
        private System.Windows.Forms.RibbonButton rbtnRefreshInvoice;

        private System.Windows.Forms.RibbonPanel rpnlRefreshRole;
        private System.Windows.Forms.RibbonButton rbtnRefreshRole;
        private System.Windows.Forms.RibbonPanel rpnlRefreshNetTool;
        private System.Windows.Forms.RibbonButton rbtnRefreshNetTool;
        private System.Windows.Forms.RibbonPanel rpnlRefreshReportMgt;
        private System.Windows.Forms.RibbonButton rbtnRefreshReportMgt;
        private System.Windows.Forms.RibbonButton rbtnHelp;
        private System.Windows.Forms.RibbonButton rbtnAbout;

        private System.Windows.Forms.RibbonPanel rpnlRefreshAdministration;
        private System.Windows.Forms.RibbonButton rbtnRefreshAdministration;
        private System.Windows.Forms.RibbonPanel rpnlRefreshUserManager;
        private System.Windows.Forms.RibbonButton rbtnRefreshUserManager;
        private System.Windows.Forms.RibbonButton rbtnRentalCover;
        private System.Windows.Forms.RibbonButton rbtnEmpVerCover;
        private System.Windows.Forms.RibbonButton rbtnCriminalCover;
        private System.Windows.Forms.RibbonButton rbtnGenericCover;
        private System.Windows.Forms.RibbonButton rbtnBankCover;
        private System.Windows.Forms.RibbonButton rbtnClientUpdate;
        private System.Windows.Forms.RibbonButton rbtnPrintFileCoverPages;
        private System.Windows.Forms.RibbonButton rbtnEmpRefCover;
        private System.Windows.Forms.RibbonButton rbtnDegreeVerCover;
        private System.Windows.Forms.RibbonButton rbtnPrintConfirmPages;
        private System.Windows.Forms.RibbonButton rbtnCreditRefCover;
        private System.Windows.Forms.RibbonPanel rpnlRefreshInv;

    }
}

