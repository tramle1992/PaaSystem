using Common.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Infrastructure.CheckSpelling.Forms
{
    public partial class OptionForm : BaseForm
    {
        private Spelling spellChecker;

        public OptionForm(ref Spelling spellChecker)
        {
            this.spellChecker = spellChecker;
            InitializeComponent();
        }

        private void OptionForm_LoadCompleted(object sender, EventArgs e)
        {
            this.chkIgnoreDigits.Checked = this.spellChecker.IgnoreWordsWithDigits;
            this.chkIgnoreUpper.Checked = this.spellChecker.IgnoreAllCapsWords;
            this.chkIgnoreHtml.Checked = this.spellChecker.IgnoreHtml;
            this.txtMaxSuggestions.Text = this.spellChecker.MaxSuggestions.ToString(CultureInfo.CurrentUICulture);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.spellChecker.IgnoreWordsWithDigits = this.chkIgnoreDigits.Checked;
            this.spellChecker.IgnoreAllCapsWords = this.chkIgnoreUpper.Checked;
            this.spellChecker.IgnoreHtml = this.chkIgnoreHtml.Checked;
            this.spellChecker.MaxSuggestions = int.Parse(this.txtMaxSuggestions.Text, CultureInfo.CurrentUICulture);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtMaxSuggestions_KeyPress(object sender, KeyPressEventArgs e)
        {
            char dot = Convert.ToChar(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
            if (e.KeyChar == dot || (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtMaxSuggestions_TextChanged(object sender, EventArgs e)
        {
            if (this.txtMaxSuggestions.Text.Length == 0)
            {
                errorProvider.SetError(this.txtMaxSuggestions, "Please input maximum suggestion count!");
                this.btnOK.Enabled = false;
            }
            else
            {
                errorProvider.SetError(this.txtMaxSuggestions, string.Empty);
                this.btnOK.Enabled = true;
            }
        }
    }
}
