using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Helper
{
    public static class HighlightHelper
    {
        private static string controlSelected = string.Empty;
        
        public static void Highlight_TextBox(Object sender)
        {
            if (sender is MaskedTextBox)
            {
                MaskedTextBox maskedTextBox = sender as MaskedTextBox;
                if (!string.IsNullOrEmpty(controlSelected))
                {
                    if (!String.IsNullOrEmpty(maskedTextBox.Text) && !controlSelected.Equals(maskedTextBox.Name))
                    {
                        maskedTextBox.SelectAll();
                        controlSelected = maskedTextBox.Name;
                    }
                }
                else
                {
                    maskedTextBox.SelectAll();
                    controlSelected = maskedTextBox.Name;
                }
            }
            else
            {
                TextBox textbox = sender as TextBox;
                if (!string.IsNullOrEmpty(controlSelected))
                {
                    if (!String.IsNullOrEmpty(textbox.Text) && !controlSelected.Equals(textbox.Name))
                    {
                        textbox.SelectAll();
                        controlSelected = textbox.Name;
                    }
                }
                else
                {
                    textbox.SelectAll();
                    controlSelected = textbox.Name;
                }
            }
        }

    }
}
