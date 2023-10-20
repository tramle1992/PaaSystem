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
using ZipCodeContext.Application.Data;
using ZipCodeContext.Infrastructure;
using Common.Infrastructure.UI;
using PaaApplication.Helper;

namespace PaaApplication.UserControls.AppExplore.ApplicantInfo
{
    public partial class PartFourControl : UserControl
    {
        public PartFourControl()
        {
            InitializeComponent();
        }

        public void ResetControls()
        {
            txtHouse.Text = "";
            txtStreetName.Text = "";
            txtCity.Text = "";
            txtRegion.Text = "";
            txtPostCode.Text = "";
        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetControls();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            txtHouse.Text = app.HouseNumber;
            txtStreetName.Text = app.StreetAddress;
            txtCity.Text = app.City;
            txtRegion.Text = app.State;
            txtPostCode.Text = app.PostalCode;
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            app.HouseNumber = txtHouse.Text;
            app.StreetAddress = txtStreetName.Text;
            app.City = txtCity.Text;
            app.State = txtRegion.Text;
            app.PostalCode = txtPostCode.Text;
        }

        private void txtPostCode_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPostCode_Validating(object sender, CancelEventArgs e)
        {            
        }

        private void TitleCaseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHandlerHelper.TitleCaseTextBox_KeyPress(sender, e);
        }


        private void txtStreetName_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            int selectionStart = textbox.SelectionStart;

            if(selectionStart > 2 && e.KeyCode == Keys.Space)
            {
                string text = string.Empty;
                if(!textbox.Text[selectionStart - 2].Equals('.'))
                {
                    text = textbox.Text.Substring(selectionStart - 3, 3);

                    if(text.StartsWith("Se") || text.StartsWith("Sw") || text.StartsWith("Ne") || text.StartsWith("Nw"))
                    {
                        textbox.Text = textbox.Text.Substring(0, selectionStart - 3) + text.ToUpper();
                    }
                }
                else if (textbox.Text[selectionStart - 2].Equals('.'))
                {
                    text = textbox.Text.Substring(selectionStart - 4, 4);
                    if (text.StartsWith("Se") || text.StartsWith("Sw") || text.StartsWith("Ne") || text.StartsWith("Nw"))
                    {
                        textbox.Text = textbox.Text.Substring(0, selectionStart - 4) + text.ToUpper();
                    }
                }
            }
            textbox.SelectionStart = selectionStart;
        }

        private void UpdatFieldsAfterPostCodeChanged()
        {
            string postCode = txtPostCode.Text;

            if (!string.IsNullOrEmpty(postCode))
            {
                using (new HourGlass())
                {
                    List<ZipCodeData> listZipCodes = ZipCodeCachedApiQuery.Instance.GetAll();

                    if (listZipCodes.Count > 0)
                    {
                        ZipCodeData result = (from zc in listZipCodes
                                              where zc.ZipCodeName == postCode
                                              select zc).FirstOrDefault();

                        if (result != null)
                        {
                            txtCity.Text = result.City;
                            txtRegion.Text = result.StateCode;
                        }
                        else
                        {
                            txtCity.Clear();
                            txtRegion.Clear();
                        }
                    }
                }
            }            
        }

        private void txtPostCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatFieldsAfterPostCodeChanged();
            }
        }

        #region txtPostCode
        private void txtPostCode_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtPostCode);
        }
        #endregion

        #region txtRegion
        private void txtRegion_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtRegion);
        }
        #endregion

        #region txtCity
        private void txtCity_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtCity);
        }
        #endregion

        #region txtStreetName
        private void txtStreetName_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtStreetName);
        }
        #endregion

        #region txtHouse
        private void txtHouse_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtHouse);
        }
        #endregion
    }
}
