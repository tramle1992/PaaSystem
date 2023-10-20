using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Application.Data.ExploreApps;
using PaaApplication.Helper;

namespace PaaApplication.UserControls.AppExplore.ApplicantInfo
{
    public partial class PartFiveControl : UserControl
    {
        public TextBox CommunityControl
        {
            get { return txtCommunity; }
        }

        public TextBox ManagementControl
        {
            get { return txtManagement; }
        }

        public PartFiveControl()
        {
            InitializeComponent();
        }

        public void ResetControls()
        {
            txtCommunity.Text = "";
            txtManagement.Text = "";
            txtUnit.Text = "";
            txtRent.Text = "";
            txtMoveIn.Text = "";
        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetControls();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            txtCommunity.Text = app.ReportCommunity;
            txtManagement.Text = app.ReportManagement;
            txtUnit.Text = app.UnitNumber;
            txtRent.Text = app.RentAmount;
            txtMoveIn.Text = app.MoveInDate;
        }

        public void UpdateReportCommunity(string community)
        {
            txtCommunity.Text = community;
        }

        public void UpdateReportManagement(string management)
        {
            txtManagement.Text = management;
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            app.ReportCommunity = txtCommunity.Text;
            app.ReportManagement = txtManagement.Text;
            app.UnitNumber = txtUnit.Text;
            app.RentAmount = txtRent.Text;
            app.MoveInDate = txtMoveIn.Text;
        }

        private void TitleCaseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHandlerHelper.TitleCaseTextBox_KeyPress(sender, e);
        }

        #region txtMoveIn
        private void txtMoveIn_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtMoveIn);
        }
        #endregion

        #region txtRent
        private void txtRent_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtRent);
        }
        #endregion

        #region txtUnit
        private void txtUnit_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtUnit);
        }
        #endregion

        #region txtManagement
        private void txtManagement_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtManagement);
        }
        #endregion

        #region txtCommunity
        private void txtCommunity_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtCommunity);
        }
        #endregion
    }
}
