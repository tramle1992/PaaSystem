using Common.Infrastructure.UI;
using Core.Application.Data.ExploreApps;
using CreditReport.Domain.Model;
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
    public partial class FormPullCreditResult : BaseForm
    {
        private List<AppData> appList = null;
        private List<string> cancelList = null;
        private List<Report> pullList = null;
        private bool isCancel;

        public FormPullCreditResult()
        {
            InitializeComponent();
        }

        public FormPullCreditResult(List<AppData> apps)
            : this()
        {
            this.appList = apps;
        }

        private void FormPullCreditResult_LoadCompleted(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                Refresh();
            }
        }

        public void SetApps(List<AppData> apps, List<Report> pullList, bool isCancel, List<string> cancelList)
        {
            using (new HourGlass())
            {
                this.appList = apps;
                this.pullList = pullList;
                this.cancelList = cancelList;
                this.isCancel = isCancel;
                Refresh();
            }
        }

        private void Refresh()
        {
            this.pullCreditResultControl.Refresh(this.appList, this.pullList, isCancel, cancelList);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
