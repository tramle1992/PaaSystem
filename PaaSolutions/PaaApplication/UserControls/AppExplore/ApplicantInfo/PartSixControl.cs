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
using Core.Domain.Model.ExploreApps;
using PaaApplication.Helper;

namespace PaaApplication.UserControls.AppExplore.ApplicantInfo
{
    public partial class PartSixControl : UserControl
    {
        public TextBox CompAppliedControl
        {
            get { return txtCompApplied; }
        }

        public TextBox PosAppliedControl
        {
            get { return txtPosApplied; }
        }

        public TextBox RoommatesControl
        {
            get { return txtRoommates; }
        }

        public PartSixControl()
        {
            InitializeComponent();
        }

        private void InitializeData()
        {
            IEnumerable<PriorityApp> priorities = PriorityApp.GetAll<PriorityApp>();
            List<PriorityAppData> prioritiesData = new List<PriorityAppData>();
            List<string> domainUpDownItems = new List<string>();
            foreach (PriorityApp priorityApp in priorities)
            {
                domainUpDownItems.Add(priorityApp.DisplayName);
            }
            uddPriority.Items.Clear();

            foreach (var item in domainUpDownItems)
            {
                uddPriority.Items.Add(item);
            }
        }

        public void HideLabelAndTextBox(String str)
        {
            if (str == "Residential")
            {
                lblCompApplied.Hide();
                lblPosApplied.Hide();
                lblRoommates.Show();
                txtCompApplied.Hide();
                txtPosApplied.Hide();
                txtRoommates.Show();
            }
            else if (str == "Employment")
            {
                lblCompApplied.Show();
                lblPosApplied.Show();
                lblRoommates.Hide();
                txtCompApplied.Show();
                txtPosApplied.Show();
                txtRoommates.Hide();
            }
            else
            {
                lblCompApplied.Hide();
                lblPosApplied.Hide();
                lblRoommates.Hide();
                txtCompApplied.Hide();
                txtRoommates.Hide();
                txtPosApplied.Hide();
            }
        }

        public void ResetControls()
        {
            txtCompApplied.Text = "";
            txtRoommates.Text = "";
            txtPosApplied.Text = "";
            nudPgReceived.Value = 1;
            uddPriority.SelectedIndex = 0;
        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetControls();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            txtRoommates.Text = app.ReportSpecialField;
            txtPosApplied.Text = app.PositionApplied;
            txtCompApplied.Text = app.CompanyApplied;
            nudPgReceived.Value = app.PagesReceived;
            uddPriority.SelectedItem = app.Priority.DisplayName;
        }

        public void UpdateAppFromControls(AppData app)
        {
            try
            {
                if (app == null || string.IsNullOrEmpty(app.ApplicationId))
                {
                    return;
                }

                app.ReportSpecialField = txtRoommates.Text;
                app.PositionApplied = txtPosApplied.Text;
                app.CompanyApplied = txtCompApplied.Text;
                app.PagesReceived = int.Parse(nudPgReceived.Value.ToString());

                int valueMember = 0;
                string displayName = "0 - None";

                if (uddPriority.SelectedItem != null)
                {
                    displayName = uddPriority.SelectedItem as string;
                    valueMember = int.Parse(displayName.Split('-')[0]);
                }

                PriorityAppData priority = new PriorityAppData();
                priority.DisplayName = displayName;
                priority.Value = valueMember;
                app.Priority = priority;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TitleCaseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHandlerHelper.TitleCaseTextBox_KeyPress(sender, e);
        }

        public void UpdateReportCompApplied(string compApplied)
        {
            txtCompApplied.Text = compApplied;
        }

        #region txtCompApplied
        private void txtCompApplied_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtCompApplied);
        }
        #endregion

        #region txtRoommates
        private void txtRoommates_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtRoommates);
        }
        #endregion

        #region txtPosApplied
        private void txtPosApplied_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtPosApplied);
        }
        #endregion
    }
}
