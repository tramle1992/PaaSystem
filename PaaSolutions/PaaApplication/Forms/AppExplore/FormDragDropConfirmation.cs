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
    public partial class FormDragDropConfirmation : Form
    {
        public enum Action
        {
            ReplaceAll,
            Append,
            Cancel
        }

        private Action formAction = Action.Cancel;

        public Action FormAction
        {
            get { return this.formAction; }
        }

        public string Message
        {
            set { this.lblMessage.Text = value; }
        }

        public FormDragDropConfirmation()
        {
            InitializeComponent();
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            this.formAction = Action.ReplaceAll;
            this.DialogResult = DialogResult.OK;
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            this.formAction = Action.Append;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
