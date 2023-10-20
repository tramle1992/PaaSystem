using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.UserControls.AppExplore
{
    public partial class AppTabsControl : UserControl
    {
        public AppTabsControl()
        {
            InitializeComponent();
        }

        public void ApplicantInfoTabViews(String rType)
        {
            // Initial Forms Load...
            partSixControl1.HideLabelAndTextBox(rType);
            partSixControl2.HideLabelAndTextBox(rType);
            ciTypeOne1.Show();
            ciTypeTwo1.Hide();
            empTypeOne1.Hide();
            empTypeTwo1.Hide();
            rentalControl1.Hide();
            criEvControl1.Show();
            finalInfoControl1.Show();
            finalInfoControl1.IsResidentialReport(rType);
            appMenuControl1.Show();
            netToolControl1.Show();

            switch (rType)
            {
                case ("Commercial"):
                    // Applicant Info - Group #2
                    partTwoControl1.Hide();
                    partThreeControl1.Show();
                    partSixControl1.Show();
                    partSixControl2.Hide();
                    criEvControl1.Hide();

                    // Only Commercial Credit Info has difference view from others
                    ciTypeOne1.Hide();
                    ciTypeTwo1.Show();

                    // No Employment Info
                    // Same Rental Info
                    rentalControl1.Show();
                    // No Criminal / Eviction Info
                    // Final Info - Group #2
                    break;
                case ("Employment"):
                    // Applicant Info - Goupr #3
                    partTwoControl1.Show();
                    partSixControl1.Hide();
                    partSixControl2.Show();
                    // Same Credit Info
                    // Employment Info - Group #1
                    empTypeTwo1.Show();
                    // Same Rental Info
                    rentalControl1.Show();
                    // Same Criminal / Eviction
                    // Final Info - Group #2
                    break;
                case ("Residential"):
                    // Applicant Info - Group #4
                    partTwoControl1.Show();
                    partThreeControl1.Hide();
                    partSixControl1.Show();
                    partSixControl2.Hide();
                    // Same Credit Info
                    // Employment Info - Group #2
                    empTypeOne1.Show();
                    // Same Rental Info
                    rentalControl1.Show();
                    // Same Criminal / Eviction
                    // Final Info - Group #1
                    break;
                case ("Credit"):
                    // Applicant Info - Group #1
                    partTwoControl1.Show();
                    partThreeControl1.Hide();
                    partSixControl1.Show();
                    partSixControl2.Hide();
                    // Same Credit Info
                    // No Employment Info
                    // No Rental Info
                    // Same Criminal / Eviction
                    // Final Info - Group #2
                    break;
                case ("Credit/Criminal"):
                    // Applicant Info - Group #1
                    partTwoControl1.Show();
                    partThreeControl1.Hide();
                    partSixControl1.Show();
                    partSixControl2.Hide();
                    // Same Credit Info
                    // No Employment Info
                    // No Rental Info
                    // Same Criminal / Eviction
                    // Final Info - Group #2
                    break;
                case ("Criminal"):
                    // Applicant Info - Group #1
                    partTwoControl1.Show();
                    partThreeControl1.Hide();
                    partSixControl1.Show();
                    partSixControl2.Hide();
                    // Same Credit Info
                    // No Employment Info
                    // No Rental Info
                    // Same Criminal / Eviction
                    // Final Info - Group #2
                    break;
                default:
                    MessageBox.Show("Undefined Report Type!");
                    break;
            }
        }
    }
}
