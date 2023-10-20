using AutoDocument.Application.Data;
using Common.Infrastructure.UI;
using Core.Application.Command.ExploreApps;
using Core.Application.Data.ExploreApps;
using Core.Infrastructure.ExploreApps;
using CreditReport.Application.Data;
using CreditReport.Domain.Model;
using PaaApplication.Helper;
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
    public partial class FormViewCredit : BaseForm
    {
        private List<ReportLightweightData> lstReport = null;
        private AppData app = null;
        private AppApiRepository apiRepository = new AppApiRepository();

        public FormViewCredit()
        {
            InitializeComponent();
        }

        private void FormViewCredit_LoadCompleted(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                Refresh();
            }
        }

        public void SetApps(List<ReportLightweightData> lstReport, AppData app)
        {
            this.lstReport = lstReport;
            this.app = app;
        }

        private void Refresh()
        {
            string formText = string.IsNullOrEmpty(this.app.FirstName) && string.IsNullOrEmpty(this.app.LastName) ? "" : this.app.LastName + " " + app.MiddleName + " " + this.app.FirstName;
            this.Text = "TransUnion Credit Details of " + formText;
            List<CreditReportViewItem> viewReports = new List<CreditReportViewItem>();
            if (this.lstReport != null)
            {
                List<string> appIds = this.lstReport.Select(x => x.ApplicationId).ToList();
                List<AppData> apps = apiRepository.GetAppByIds(new GetAppByIdsCommand(appIds));
                foreach (ReportLightweightData item in this.lstReport)
                {
                    CreditReportViewItem viewItem = new CreditReportViewItem(item.ReportId, item.ApplicationId);
                    viewItem.Type = item.Type;
                    viewItem.EndUser = item.EndUser;
                    viewItem.CreatedAt = item.CreatedAt;
                    viewItem.UpdatedAt = item.UpdatedAt;
                    viewItem.StatusCode = item.StatusCode;
                    viewItem.PulledBy = item.PulledBy;
                    AppData a = apps.Find(x => x.ApplicationId == item.ApplicationId);
                    if (a != null)
                    {
                        viewItem.ApplicantName = Utils.GetApplicantName(a, null);
                    }
                    viewReports.Add(viewItem);

                }
                this.creditReportControl1.Refresh(viewReports);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
