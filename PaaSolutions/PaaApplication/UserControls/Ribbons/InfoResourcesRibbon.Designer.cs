using PaaApplication.Forms;
namespace PaaApplication.UserControls.Ribbons
{
    partial class InfoResourcesRibbon
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
            this.rtabInfoResources = new System.Windows.Forms.RibbonTab();
            this.rpnlInfoResource = new System.Windows.Forms.RibbonPanel();
            this.rbtnLandlordContact = new System.Windows.Forms.RibbonButton();
            this.ribbonButton8 = new System.Windows.Forms.RibbonButton();
            this.rbtnCriminalInfo = new System.Windows.Forms.RibbonButton();
            this.rbtnEmployment = new System.Windows.Forms.RibbonButton();
            this.rbtnDocLib = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.rbtnRefreshInfoResources = new System.Windows.Forms.RibbonButton();
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
            this.ribbon.OrbVisible = false;
            this.ribbon.Size = new System.Drawing.Size(50, 134);
            this.ribbon.QuickAcessToolbar.Visible = false;
            // 
            // 
            // 
            this.ribbon.RibbonTabFont = new System.Drawing.Font("Arial Unicode MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon.Tabs.Add(this.rtabInfoResources);
            this.ribbon.TabsMargin = new System.Windows.Forms.Padding(12, 0, 30, 0);
            this.ribbon.ThemeColor = System.Windows.Forms.RibbonTheme.Black;
            // 
            // rtabInfoResources
            // 
            this.rtabInfoResources.Panels.Add(this.rpnlInfoResource);
            this.rtabInfoResources.Panels.Add(this.ribbonPanel3);
            resources.ApplyResources(this.rtabInfoResources, "rtabInfoResources");
            this.rtabInfoResources.Value = "0";
            this.rtabInfoResources.Text = "";
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
            // rbtnLandlordContact
            // 
            this.rbtnLandlordContact.AltKey = "L";
            this.rbtnLandlordContact.DropDownItems.Add(this.ribbonButton8);
            this.rbtnLandlordContact.Image = ((System.Drawing.Image)(resources.GetObject("rbtnLandlordContact.Image")));
            this.rbtnLandlordContact.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnLandlordContact.SmallImage")));
            resources.ApplyResources(this.rbtnLandlordContact, "rbtnLandlordContact");
            this.rbtnLandlordContact.Click += new System.EventHandler(this.rbtnLandlordContact_Click);
            // 
            // ribbonButton8
            // 
            this.ribbonButton8.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.Image")));
            this.ribbonButton8.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton8.SmallImage")));
            resources.ApplyResources(this.ribbonButton8, "ribbonButton8");
            // 
            // rbtnCriminalInfo
            // 
            this.rbtnCriminalInfo.Image = ((System.Drawing.Image)(resources.GetObject("rbtnCriminalInfo.Image")));
            this.rbtnCriminalInfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnCriminalInfo.SmallImage")));
            resources.ApplyResources(this.rbtnCriminalInfo, "rbtnCriminalInfo");
            this.rbtnCriminalInfo.Click += new System.EventHandler(this.rbtnCriminalInfo_Click);
            // 
            // rbtnEmployment
            // 
            this.rbtnEmployment.Image = ((System.Drawing.Image)(resources.GetObject("rbtnEmployment.Image")));
            this.rbtnEmployment.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtnEmployment.SmallImage")));
            resources.ApplyResources(this.rbtnEmployment, "rbtnEmployment");
            this.rbtnEmployment.Click += new System.EventHandler(this.rbtnEmployment_Click);
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
            // InfoResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbon);
            this.Name = "InfoResources";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon;

        private System.Windows.Forms.RibbonPanel rpnlInfoResource;
        private System.Windows.Forms.RibbonButton rbtnLandlordContact;
        private System.Windows.Forms.RibbonButton ribbonButton8;
        private System.Windows.Forms.RibbonButton rbtnCriminalInfo;
        private System.Windows.Forms.RibbonButton rbtnEmployment;
        private System.Windows.Forms.RibbonButton rbtnDocLib;

        private System.Windows.Forms.RibbonTab rtabInfoResources;

        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton rbtnRefreshInfoResources;
    }
}
