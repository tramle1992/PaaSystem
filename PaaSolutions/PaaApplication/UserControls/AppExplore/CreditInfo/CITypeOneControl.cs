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
using System.Globalization;

namespace PaaApplication.UserControls.AppExplore.CreditInfo
{
    public partial class CITypeOneControl : UserControl
    {
        readonly string formatDecimalString = "#,0.00";
        readonly string formatTotalDecimalString = "#,0.#";

        public CITypeOneControl()
        {
            InitializeComponent();
            DisableMouseWheelEvent();
        }

        private void DisableMouseWheelEvent()
        {
            nudPassdue.MouseWheel += nudPassdue_MouseWheel;
            nudRent.MouseWheel += nudRent_MouseWheel;
            nudCollection.MouseWheel += nudCollection_MouseWheel;
            nudLiens.MouseWheel += nudLiens_MouseWheel;
            nudJudgment.MouseWheel += nudJudgment_MouseWheel;
            nudChildSupport.MouseWheel += nudChildSupport_MouseWheel;
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            decimal tmpDecimal;
            CreditInfoData creditInfo = new CreditInfoData();
            creditInfo.CreditReportObtained = chboxCRObtained.Checked;
            creditInfo.CreditMatched = chboxMatchApp.Checked;
            creditInfo.CreditHistoryBankrupted = chboxCreditHist.Checked;

            if (!decimal.TryParse(txtPastDue1.Text, out tmpDecimal))
                creditInfo.PastDueAmounts = 0.0m;
            else
                creditInfo.PastDueAmounts = tmpDecimal;

            if (!decimal.TryParse(txtRent1.Text, out tmpDecimal))
                creditInfo.Rent = 0.0m;
            else
                creditInfo.Rent = tmpDecimal;

            if (!decimal.TryParse(txtCollection1.Text, out tmpDecimal))
                creditInfo.Collections = 0.0m;
            else
                creditInfo.Collections = tmpDecimal;

            if (!decimal.TryParse(txtLient1.Text, out tmpDecimal))
                creditInfo.Liens = 0.0m;
            else
                creditInfo.Liens = tmpDecimal;

            if (!decimal.TryParse(txtJudgment1.Text, out tmpDecimal))
                creditInfo.Judgements = 0.0m;
            else
                creditInfo.Judgements = tmpDecimal;

            if (!decimal.TryParse(txtChildSupport1.Text, out tmpDecimal))
                creditInfo.ChildSupport = 0.0m;
            else
                creditInfo.ChildSupport = tmpDecimal;

            creditInfo.Dates = txtDates.Text;

            creditInfo.PositiveCreditSince = chBoxPositive.Checked;

            app.CreditInfo = creditInfo;
        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetControls();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            CreditInfoData creditInfo = app.CreditInfo;
            if (creditInfo != null)
            {
                chboxCRObtained.Checked = creditInfo.CreditReportObtained;
                chboxMatchApp.Checked = creditInfo.CreditMatched;
                chboxCreditHist.Checked = creditInfo.CreditHistoryBankrupted;
                txtPastDue1.Text = creditInfo.PastDueAmounts.ToString(formatTotalDecimalString);
                txtRent1.Text = creditInfo.Rent.ToString(formatTotalDecimalString);
                txtCollection1.Text = creditInfo.Collections.ToString(formatTotalDecimalString);
                txtJudgment1.Text = creditInfo.Judgements.ToString(formatTotalDecimalString);
                txtLient1.Text = creditInfo.Liens.ToString(formatTotalDecimalString);
                txtChildSupport1.Text = creditInfo.ChildSupport.ToString(formatTotalDecimalString);
                txtDates.Text = creditInfo.Dates;
                chBoxPositive.Checked = creditInfo.PositiveCreditSince;

                decimal totalPast = creditInfo.PastDueAmounts + creditInfo.Rent + creditInfo.Collections + creditInfo.Judgements + creditInfo.Liens + creditInfo.ChildSupport;

                txtTotalPast.Text = "$ " + totalPast.ToString(formatTotalDecimalString);
            }
        }

        public void ResetControls()
        {
            chboxCRObtained.Checked = false;
            chboxMatchApp.Checked = false;
            chboxCreditHist.Checked = false;
            txtPastDue1.Text = string.Empty;
            txtRent1.Text = string.Empty;
            txtCollection1.Text = string.Empty;
            txtJudgment1.Text = string.Empty;
            txtLient1.Text = string.Empty;
            txtChildSupport1.Text = string.Empty;
            txtDates.Text = string.Empty;
            chBoxPositive.Checked = false;
        }

        private void nudPassdue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nudPassdue.Select(0, 5);
            }
        }

        private void nudRent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nudRent.Select(0, 5);
            }
        }

        private void nudCollection_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nudCollection.Select(0, 5);
            }
        }

        private void nudLiens_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nudLiens.Select(0, 5);
            }
        }

        private void nudChildSupport_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nudChildSupport.Select(0, 5);
            }
        }

        private void nudJudgment_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nudJudgment.Select(0, 5);
            }
        }

        private void nudPassdue_ValueChanged(object sender, EventArgs e)
        {
            decimal value = nudPassdue.Value;
            decimal originValue = Convert.ToDecimal(txtPastDue1.Text);
            originValue += value;

            if (originValue < 0)
            {
                originValue = 0m;
            }

            string formatString = originValue.ToString(formatTotalDecimalString);

            txtPastDue1.Text = formatString;

            CalculateTotal();

            nudPassdue.Value = 0m;
        }

        private void nudRent_ValueChanged(object sender, EventArgs e)
        {
            decimal value = nudRent.Value;
            decimal originValue = Convert.ToDecimal(txtRent1.Text);
            originValue += value;

            if (originValue < 0)
            {
                originValue = 0m;
            }

            string formatString = originValue.ToString(formatTotalDecimalString);

            txtRent1.Text = formatString;

            CalculateTotal();

            nudRent.Value = 0m;
        }

        private void CalculateTotal()
        {
            decimal totalPast = Convert.ToDecimal(txtRent1.Text) +
                Convert.ToDecimal(txtChildSupport1.Text) +
                Convert.ToDecimal(txtCollection1.Text) +
                Convert.ToDecimal(txtJudgment1.Text) +
                Convert.ToDecimal(txtLient1.Text) +
                Convert.ToDecimal(txtPastDue1.Text);

            txtTotalPast.Text = "$ " + totalPast.ToString(formatTotalDecimalString);
        }

        private void nudCollection_ValueChanged(object sender, EventArgs e)
        {
            decimal value = nudCollection.Value;
            decimal originValue = Convert.ToDecimal(txtCollection1.Text);
            originValue += value;

            if (originValue < 0)
            {
                originValue = 0m;
            }

            string formatString = originValue.ToString(formatTotalDecimalString);
            txtCollection1.Text = formatString;

            CalculateTotal();

            nudCollection.Value = 0m;
        }

        private void nudLiens_ValueChanged(object sender, EventArgs e)
        {
            decimal value = nudLiens.Value;
            decimal originValue = Convert.ToDecimal(txtLient1.Text);
            originValue += value;

            if (originValue < 0)
            {
                originValue = 0m;
            }

            string formatString = originValue.ToString(formatTotalDecimalString);
            txtLient1.Text = formatString;

            CalculateTotal();

            nudLiens.Value = 0m;
        }

        private void nudJudgment_ValueChanged(object sender, EventArgs e)
        {
            decimal value = nudJudgment.Value;
            decimal originValue = Convert.ToDecimal(txtJudgment1.Text);
            originValue += value;

            if (originValue < 0)
            {
                originValue = 0m;
            }

            string formatString = originValue.ToString(formatTotalDecimalString);
            txtJudgment1.Text = formatString;

            CalculateTotal();

            nudJudgment.Value = 0m;
        }

        private void nudChildSupport_ValueChanged(object sender, EventArgs e)
        {
            decimal value = nudChildSupport.Value;
            decimal originValue = Convert.ToDecimal(txtChildSupport1.Text);
            originValue += value;

            if (originValue < 0)
            {
                originValue = 0m;
            }

            string formatString = originValue.ToString(formatTotalDecimalString);
            txtChildSupport1.Text = formatString;

            CalculateTotal();

            nudChildSupport.Value = 0m;
        }

        #region Numeric MouseWheel

        void nudPassdue_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        void nudRent_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        void nudCollection_MouseWheel(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        void nudLiens_MouseWheel(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        void nudJudgment_MouseWheel(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        void nudChildSupport_MouseWheel(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void txtDates_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                chBoxPositive.Enabled = false;
            }
            else
            {
                chBoxPositive.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to reset all credit info?", "Reset Credit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                ResetCreditInfo();
            }
        }

        private void ResetCreditInfo()
        {
            try
            {
                nudPassdue.Value = 0;
                nudRent.Value = 0;
                nudCollection.Value = 0;
                nudLiens.Value = 0;
                nudJudgment.Value = 0;
                nudChildSupport.Value = 0;

                decimal zero = 0m;

                string zeroString = zero.ToString(formatTotalDecimalString);
                txtPastDue1.Text = zeroString;
                txtRent1.Text = zeroString;
                txtCollection1.Text = zeroString;
                txtLient1.Text = zeroString;
                txtJudgment1.Text = zeroString;
                txtChildSupport1.Text = zeroString;

                txtTotalPast.Text = string.Format("$ {0}", zeroString);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void nudPassdue_MouseClick(object sender, MouseEventArgs e)
        {
            nudPassdue.Select(0, 5);
        }

        private void nudRent_MouseClick(object sender, MouseEventArgs e)
        {
            nudRent.Select(0, 5);
        }

        private void nudCollection_MouseClick(object sender, MouseEventArgs e)
        {
            nudCollection.Select(0, 5);
        }

        private void nudLiens_MouseClick(object sender, MouseEventArgs e)
        {
            nudLiens.Select(0, 5);
        }

        private void nudJudgment_MouseClick(object sender, MouseEventArgs e)
        {
            nudJudgment.Select(0, 5);
        }

        private void nudChildSupport_MouseClick(object sender, MouseEventArgs e)
        {
            nudChildSupport.Select(0, 5);
        }

        private void nudRent_Enter(object sender, EventArgs e)
        {
            nudRent.Select(0, 5);
        }

        private void nudCollection_Enter(object sender, EventArgs e)
        {
            nudCollection.Select(0, 5);
        }

        private void nudLiens_Enter(object sender, EventArgs e)
        {
            nudLiens.Select(0, 5);
        }

        private void nudJudgment_Enter(object sender, EventArgs e)
        {
            nudJudgment.Select(0, 5);
        }

        private void nudChildSupport_Enter(object sender, EventArgs e)
        {
            nudChildSupport.Select(0, 5);
        }
    }
}
