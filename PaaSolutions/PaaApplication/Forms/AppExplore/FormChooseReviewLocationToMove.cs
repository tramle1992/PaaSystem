using Core.Application.Data.ExploreApps;
using System.Linq;
using System.Windows.Forms;

namespace PaaApplication.Forms.AppExplore
{
    public partial class FormChooseReviewLocationToMove : Form
    {
        public LocationData ChoosenReviewLocation;
        public FormChooseReviewLocationToMove()
        {
            InitializeComponent();

            this.radioButtonReview1.Checked = true;
        }

        private void btnMoveYes_Click(object sender, System.EventArgs e)
        {
            var checkedButton = this.groupBoxReviews.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            if (checkedButton == this.radioButtonReview1)
            {
                this.ChoosenReviewLocation = new LocationData(Core.Domain.Model.ExploreApps.Location.Review1.LocationId, Core.Domain.Model.ExploreApps.Location.Review1.LocationName);
            }
            else if (checkedButton == this.radioButtonReview2)
            {
                this.ChoosenReviewLocation = new LocationData(Core.Domain.Model.ExploreApps.Location.Review2.LocationId, Core.Domain.Model.ExploreApps.Location.Review2.LocationName);
            }
            else if (checkedButton == this.radioButtonReview3)
            {
                this.ChoosenReviewLocation = new LocationData(Core.Domain.Model.ExploreApps.Location.Review3.LocationId, Core.Domain.Model.ExploreApps.Location.Review3.LocationName);
            }
        }
    }
}
