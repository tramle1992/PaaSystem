using Common.Infrastructure.UI;
using Core.Application.Data.ExploreApps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.AppExplore
{
    public partial class FormMoveApps : BaseForm
    {
        public LocationData NewLocation { get; set; }
        public FormMoveApps(List<string> applicants, LocationData newLocation, string confirmText)
        {
            InitializeComponent();
            int applicantNum = applicants.Count;
            if (applicants.Count >= 1)
            {
                this.Text = "Move These Applications?";
            }
            else
            {
                this.Text = "Move This Application";
            }

            for (int i = 0; i < applicants.Count; i++ )
            {
                string applicant = applicants[i];
                listBoxMoveApps.Items.Add(applicant);
            }

            lbConfirm.Text = confirmText;
            this.NewLocation = newLocation;
            this.radioButtonReview1.Checked = true;

            if (NewLocation.LocationId == Core.Domain.Model.ExploreApps.Location.Review1.LocationId ||
                NewLocation.LocationId == Core.Domain.Model.ExploreApps.Location.Review2.LocationId ||
                NewLocation.LocationId == Core.Domain.Model.ExploreApps.Location.Review3.LocationId)
            {
                this.groupBoxReviews.Show();
            }
            else
            {
                this.groupBoxReviews.Hide();
            }
        }

        private void FormMoveApps_LoadCompleted(object sender, EventArgs e)
        {

        }

        private void btnMoveYes_Click(object sender, EventArgs e)
        {
            // If the new location is one of reviews locations, then we have user choose what location they want to move apps to
            if (NewLocation.LocationId == Core.Domain.Model.ExploreApps.Location.Review1.LocationId ||
                NewLocation.LocationId == Core.Domain.Model.ExploreApps.Location.Review2.LocationId ||
                NewLocation.LocationId == Core.Domain.Model.ExploreApps.Location.Review3.LocationId)
            {
                var checkedButton = this.groupBoxReviews.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
                if (checkedButton == this.radioButtonReview1)
                {
                    this.NewLocation = new LocationData(Core.Domain.Model.ExploreApps.Location.Review1.LocationId, Core.Domain.Model.ExploreApps.Location.Review1.LocationName);
                }
                else if (checkedButton == this.radioButtonReview2)
                {
                    this.NewLocation = new LocationData(Core.Domain.Model.ExploreApps.Location.Review2.LocationId, Core.Domain.Model.ExploreApps.Location.Review2.LocationName);
                }
                else if (checkedButton == this.radioButtonReview3)
                {
                    this.NewLocation = new LocationData(Core.Domain.Model.ExploreApps.Location.Review3.LocationId, Core.Domain.Model.ExploreApps.Location.Review3.LocationName);
                }
            }
        }

        private void btnMoveNo_Click(object sender, EventArgs e)
        {

        }
    }
}
