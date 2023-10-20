using Common.Infrastructure.UI;
using Core.Application.Command.ExploreApps;
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
    public partial class FormSearchArchive : BaseForm
    {
        private FormMaster formMaster;

        public FormSearchArchive(FormMaster formMaster)
        {
            InitializeComponent();
            this.formMaster = formMaster;
        }

        public SearchAppCommand GetSearchCommand()
        {
            SearchAppCommand command = new SearchAppCommand();
            DateTime fromDate = monthCalendarArchive.SelectionStart.Date;
            DateTime toDate = monthCalendarArchive.SelectionEnd.Date.AddDays(1).AddSeconds(-5);
            if (rbReceived.Checked)
            {
                command.ReceivedDateFrom = (DateTime?)fromDate.ToUniversalTime();
                command.ReceivedDateTo = (DateTime?)toDate.ToUniversalTime();
            }
            else
            {
                command.CompletedDateFrom = (DateTime?)fromDate.ToUniversalTime();
                command.CompletedDateTo = (DateTime?)toDate.ToUniversalTime();
            }
            command.Status = SearchAppCommand.AppStatus.Archive;
            return command;
        }

        private void btnEnterArchive_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
