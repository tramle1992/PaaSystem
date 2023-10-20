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
    public partial class PartThreeControl : UserControl
    {
        public PartThreeControl()
        {
            InitializeComponent();
        }

        public void ResetControls()
        {
            txtCompany.Text = "";
            txtCompPhone.Text = "";
            txtRegAgent.Text = "";
            txtDateActive.Text = "";
            txtStateActive.Text = "";
        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetControls();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            txtCompany.Text = app.Company;
            txtCompPhone.Text = app.Phone;
            txtRegAgent.Text = app.RegAgent;
            txtDateActive.Text = app.DateActive;
            txtStateActive.Text = app.StateActive;
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            app.Company = txtCompany.Text;
            app.Phone = txtCompPhone.Text;
            app.RegAgent = txtRegAgent.Text;
            app.DateActive = txtDateActive.Text;
            app.StateActive = txtStateActive.Text;
        }

        private void TitleCaseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHandlerHelper.TitleCaseTextBox_KeyPress(sender, e);
        }
    }
}
