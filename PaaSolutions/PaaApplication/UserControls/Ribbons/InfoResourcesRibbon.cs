using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfoResource.Application.Data;
using PaaApplication.Forms;

namespace PaaApplication.UserControls.Ribbons
{
    public partial class InfoResourcesRibbon : UserControl
    {
        FormInfoResources form;

        public EventHandler<EventArgs> LandlordContactClick;
        public EventHandler<EventArgs> CriminalClick;
        public EventHandler<EventArgs> EmploymentClick;
        public EventHandler<EventArgs> DoclibClick;
        public EventHandler<EventArgs> RefreshClick;

        public InfoResourcesRibbon()
        {
            InitializeComponent();
            rbtnLandlordContact.Checked = true;
        }

        #region RibbonTab InfoResources
        private void rbtnDocLib_Click(object sender, EventArgs e)
        {
            this.rbtnDocLib.Checked = true;
            this.rbtnLandlordContact.Checked = false;
            this.rbtnCriminalInfo.Checked = false;
            this.rbtnEmployment.Checked = false;

            if(DoclibClick != null)
            {
                DoclibClick(sender, e);
            }
        }

        private void rbtnLandlordContact_Click(object sender, EventArgs e)
        {
            this.rbtnLandlordContact.Checked = true;
            this.rbtnCriminalInfo.Checked = false;
            this.rbtnEmployment.Checked = false;
            this.rbtnDocLib.Checked = false;

            if (LandlordContactClick != null)
            {
                LandlordContactClick(sender, e);
            }
        }

        private void rbtnCriminalInfo_Click(object sender, EventArgs e)
        {
            this.rbtnCriminalInfo.Checked = true;
            this.rbtnEmployment.Checked = false;
            this.rbtnLandlordContact.Checked = false;
            this.rbtnDocLib.Checked = false;

            if (CriminalClick != null)
            {
                CriminalClick(sender, e);
            }
        }

        private void rbtnEmployment_Click(object sender, EventArgs e)
        {
            this.rbtnEmployment.Checked = true;
            this.rbtnCriminalInfo.Checked = false;
            this.rbtnLandlordContact.Checked = false;
            this.rbtnDocLib.Checked = false;

            if (EmploymentClick != null)
            {
                EmploymentClick(sender, e);
            }
        }

        private void rbtnRefreshInfoResources_Click(object sender, EventArgs e)
        {
            if (RefreshClick != null)
            {
                RefreshClick(sender, e);
            }
        }
        #endregion RibbonTab InfoResources
    }
}
