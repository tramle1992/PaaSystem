using PaaApplication.Forms;
namespace PaaApplication.UserControls.Ribbons
{
    partial class InvoicingRibbon
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
            this.ribbon.Tabs.Add(this.rtabInvoicing);
            this.ribbon.TabsMargin = new System.Windows.Forms.Padding(12, 0, 30, 0);
            this.ribbon.ThemeColor = System.Windows.Forms.RibbonTheme.Black;
            // 
            // rtabInvoicing
            // 
            this.rtabInvoicing.Panels.Add(this.rpnlSearchInvoices);
            this.rtabInvoicing.Panels.Add(this.rpnlBilling);
            this.rtabInvoicing.Panels.Add(this.rpnlInvoiceDoc);
            this.rtabInvoicing.Panels.Add(this.rpnlRefreshInv);
            resources.ApplyResources(this.rtabInvoicing, "rtabInvoicing");
            this.rtabInvoicing.Value = "4";
            this.rtabInvoicing.Text = "";
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

            //Billing Manager
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbon);
            this.Name = "Billing Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Ribbon ribbon;

        private System.Windows.Forms.RibbonTab rtabInvoicing;

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

        private System.Windows.Forms.RibbonButton rbtnBillingMonthSub1;
        private System.Windows.Forms.RibbonButton rbtnBillingMonthSub2;
        private System.Windows.Forms.RibbonButton rbtnBillingMonthSub3;

        private System.Windows.Forms.RibbonPanel rpnlRefreshInv;
        private System.Windows.Forms.RibbonButton rbtnRefreshInvoice;
    }
}
