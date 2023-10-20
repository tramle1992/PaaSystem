using Common.Infrastructure.CheckSpelling.Forms;
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

namespace Common.Infrastructure.CheckSpelling
{
    public partial class SuggestionForm : BaseForm
    {
        private Spelling spellChecker;
        public event EventHandler<EventArgs> OnCancel;

        public SuggestionForm(Spelling spellChecker)
        {
            this.spellChecker = spellChecker;
            this.AttachEvents();
            InitializeComponent();
        }

        private void SuggestionForm_Load(object sender, EventArgs e)
        {
            this.txtTextBeingChecked.Text = this.spellChecker.Text;
            this.statusPaneWord.Text = string.Empty;
            this.statusPaneCount.Text = "Word: 0 of 0";
            this.statusPaneIndex.Text = "Index: 0";
            this.lstSuggestionList.Items.Clear();
        }

        #region Form events
        private void btnIgnore_Click(object sender, EventArgs e)
        {
            this.spellChecker.IgnoreWord();
            this.spellChecker.SpellCheck();
        }

        private void btnIgnoreAll_Click(object sender, EventArgs e)
        {
            this.spellChecker.IgnoreAllWord();
            this.spellChecker.SpellCheck();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.spellChecker.Dictionary.Add(this.spellChecker.CurrentWord);
            this.spellChecker.SpellCheck();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            this.spellChecker.ReplaceWord(this.txtReplacementWord.Text);
            this.txtTextBeingChecked.Text = this.spellChecker.Text;
            this.spellChecker.SpellCheck();
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            this.spellChecker.ReplaceAllWord(this.txtReplacementWord.Text);
            this.txtTextBeingChecked.Text = this.spellChecker.Text;
            this.spellChecker.SpellCheck();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionForm optionForm = new OptionForm(ref this.spellChecker);
            optionForm.ShowDialog(this);
            if (optionForm.DialogResult == DialogResult.OK)
            {
                this.spellChecker.SpellCheck();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (this.OnCancel != null)
            {
                this.OnCancel(sender, e);
            }

            //if (this.Owner != null)
            //{
            //    this.Owner.Activate();
            //}
        }

        private void lstSuggestionList_DoubleClick(object sender, EventArgs e)
        {
            this.btnReplace_Click(sender, e);
        }

        private void lstSuggestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstSuggestionList.SelectedIndex >= 0)
            {
                this.txtReplacementWord.Text = this.lstSuggestionList.SelectedItem.ToString();
            }
        }

        private void SuggestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();

            if (this.OnCancel != null)
            {
                this.OnCancel(sender, e);
            }
        }
        #endregion

        #region Spell events
        private void SpellChecker_DoubledWord(object sender, SpellingEventArgs e)
        {
            this.UpdateDisplay(this.spellChecker.Text, e.Word,
                e.WordIndex, e.TextIndex);

            // Turn off ignore all option on double word
            this.btnIgnoreAll.Enabled = false;
            this.btnReplaceAll.Enabled = false;
            this.btnAdd.Enabled = false;
        }

        private void SpellChecker_EndOfText(object sender, System.EventArgs e)
        {
            if (!this.spellChecker.SuggestionFormEndOfTextEvent)
            {
                return;
            }

            this.UpdateDisplay(this.spellChecker.Text, string.Empty, 0, 0);

            //if (this.spellChecker.AlertComplete)
            //{
            //    MessageBox.Show(this, "Spell Check Complete.", "Spell Check",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            //this.Hide();
            //
            //if (this.OnCancel != null)
            //{
            //    this.OnCancel(sender, e);
            //}
            //
            //if (this.Owner != null)
            //{
            //    this.Owner.Activate();
            //}
        }

        private void SpellChecker_MisspelledWord(object sender, SpellingEventArgs e)
        {
            this.UpdateDisplay(this.spellChecker.Text, e.Word,
                e.WordIndex, e.TextIndex);

            // Turn on ignore all option
            this.btnIgnoreAll.Enabled = true;
            this.btnReplaceAll.Enabled = true;

            // Generate suggestions
            this.spellChecker.Suggest();

            // Display suggestions
            this.lstSuggestionList.Items.AddRange((string[])this.spellChecker.Suggestions.ToArray(typeof(string)));
        }

        public void UpdateDisplay(string text, string word, int wordIndex, int textIndex)
        {
            // Display form
            //if (!this.Visible)
            //{
            //    this.Show();
            //}
            //this.Activate();

            // Set text context
            this.txtTextBeingChecked.ResetText();
            this.txtTextBeingChecked.SelectionColor = Color.Black;

            if (word.Length > 0)
            {
                // Highlight current word
                this.txtTextBeingChecked.AppendText(text.Substring(0, textIndex));
                this.txtTextBeingChecked.SelectionColor = Color.Red;
                this.txtTextBeingChecked.AppendText(word);
                this.txtTextBeingChecked.SelectionColor = Color.Black;
                this.txtTextBeingChecked.AppendText(text.Substring(textIndex + word.Length));

                // Set caret and scroll window
                this.txtTextBeingChecked.Select(textIndex, 0);
                this.txtTextBeingChecked.Focus();
                this.txtTextBeingChecked.ScrollToCaret();
            }
            else
            {
                this.txtTextBeingChecked.AppendText(text);
            }

            // Update status bar
            this.statusPaneWord.Text = word;
            wordIndex++;  //WordIndex is 0 base, display is 1 based
            this.statusPaneCount.Text = string.Format("Word: {0} of {1}",
                wordIndex.ToString(), this.spellChecker.WordCount.ToString(CultureInfo.CurrentUICulture));
            this.statusPaneIndex.Text = string.Format("Index: {0}", textIndex.ToString());

            // Display suggestions
            this.lstSuggestionList.BeginUpdate();
            this.lstSuggestionList.SelectedIndex = -1;
            this.lstSuggestionList.Items.Clear();
            this.lstSuggestionList.EndUpdate();

            // Reset replacement word
            this.txtReplacementWord.Text = string.Empty;
            this.txtReplacementWord.Focus();
        }

        /// <summary>
        ///     called by spell checker to enable this 
        ///     form to handle spell checker events
        /// </summary>
        internal void AttachEvents()
        {
            this.spellChecker.MisspelledWord += new Spelling.MisspelledWordEventHandler(this.SpellChecker_MisspelledWord);
            this.spellChecker.DoubledWord += new Spelling.DoubledWordEventHandler(this.SpellChecker_DoubledWord);
            this.spellChecker.EndOfText += new Spelling.EndOfTextEventHandler(this.SpellChecker_EndOfText);
        }

        /// <summary>
        ///     called by spell checker to disable this 
        ///     form from handling spell checker events
        /// </summary>
        internal void DetachEvents()
        {
            this.spellChecker.MisspelledWord -= new Spelling.MisspelledWordEventHandler(this.SpellChecker_MisspelledWord);
            this.spellChecker.DoubledWord -= new Spelling.DoubledWordEventHandler(this.SpellChecker_DoubledWord);
            this.spellChecker.EndOfText -= new Spelling.EndOfTextEventHandler(this.SpellChecker_EndOfText);
        }
        #endregion

    }
}
