using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Infrastructure.UI;

namespace PaaApplication.Forms.Common
{
    public partial class FormProgress : BaseForm
    {

        public ProgressBar ProgressBar { get { return progressBar; } }

        public object Argument { get; set; }

        public RunWorkerCompletedEventArgs Result { get; private set; }

        public bool CancelllationPending
        {
            get { return worker.CancellationPending; }
        }

        public bool IsCancellation()
        {
            return this.CancelllationPending;
        }

        public string CancellingText { get; set; }

        public string DefaultStatusText { get; set; }

        public delegate void DoWorkEventHandler(FormProgress sender, DoWorkEventArgs e);
        /// <summary>
        /// Occurs when the background worker starts.
        /// </summary>
        public event DoWorkEventHandler DoWork;

        BackgroundWorker worker;
        int lastPercent;
        string lastStatus;

        public FormProgress()
        {
            InitializeComponent();

            DefaultStatusText = "Please wait...";
            CancellingText = "Cancelling operation...";

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new System.ComponentModel.DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        /// <summary>
        /// Changes the status text only.
        /// </summary>
        /// <param name="status">New status text.</param>
        public void SetProgress(string status)
        {
            //do not update the text if it didn't change
            //or if a cancellation request is pending
            if (status != lastStatus && !worker.CancellationPending)
            {
                lastStatus = status;
                worker.ReportProgress(progressBar.Minimum - 1, status);
            }
        }

        /// <summary>
        /// Changes the progress bar value only.
        /// </summary>
        /// <param name="percent">New value for the progress bar.</param>
        public void SetProgress(int percent)
        {
            //do not update the progress bar if the value didn't change
            if (percent != lastPercent)
            {
                lastPercent = percent;
                worker.ReportProgress(lastPercent);
            }
        }

        /// <summary>
        /// Changes both progress bar value and status text.
        /// </summary>
        /// <param name="percent">New value for the progress bar.</param>
        /// <param name="status">New status text.</param>
        public void SetProgress(int percent, string status)
        {
            if (percent != lastPercent || (status != lastStatus && !worker.CancellationPending))
            {
                lastPercent = percent;
                lastStatus = status;
                worker.ReportProgress(percent, status);
            }
        }

        private void FormProgress_Load(object sender, EventArgs e)
        {
            Result = null;
            buttonCancel.Enabled = true;
            progressBar.Value = ProgressBar.Minimum;
            labelStatus.Text = DefaultStatusText;
            lastPercent = progressBar.Minimum;
            worker.RunWorkerAsync(Argument);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //notify the background worker we want to cancel
            worker.CancelAsync();
            //disable the cancel button and change the status text
            buttonCancel.Enabled = false;
            labelStatus.Text = CancellingText;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //the background worker started
            //let's call the user's event handler
            if (DoWork != null)
                DoWork(this, e);
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //make sure the new value is valid for the progress bar and update it
            if (e.ProgressPercentage >= progressBar.Minimum && e.ProgressPercentage <= progressBar.Maximum)
            {
                progressBar.Value = e.ProgressPercentage;
            }
            //do not update the text if a cancellation request is pending
            if (e.UserState != null && !worker.CancellationPending)
            {
                labelStatus.Text = e.UserState.ToString();
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //the background worker completed
            //keep the resul and close the form
            Result = e;
            if (e.Error != null)
                DialogResult = System.Windows.Forms.DialogResult.Abort;
            else if (e.Cancelled)
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            else
                DialogResult = DialogResult.OK;
        }
    }
}
