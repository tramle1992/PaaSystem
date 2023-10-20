using AutoDocument.Application.Data;
using Common.Infrastructure.UI;
using Core.Application.Command.ExploreApps;
using Core.Application.Data.ExploreApps;
using Core.Infrastructure.ExploreApps;
using CreditReport.Domain.Model;
using CreditReport.Infrastructure;
using NodaTime;
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

namespace PaaApplication.Forms
{
    public partial class FormCreditReport : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<Report> lstReport = null;
        private AppApiRepository apiRepository = new AppApiRepository();

        public FormCreditReport()
        {
            InitializeComponent();
        }

        private void FormCreditReport_LoadCompleted(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                SetApps();
                Refresh();
            }
        }

        public void SetApps()
        {
            LoadDataToGrid();
        }

        private void Refresh()
        {
            List<CreditReportViewItem> viewReports = new List<CreditReportViewItem>();
            if (this.lstReport != null)
            {
                List<string> appIds = this.lstReport.Select(x => x.ApplicationId).ToList();
                List<AppData> apps = apiRepository.GetAppByIds(new GetAppByIdsCommand(appIds));
                foreach (Report item in this.lstReport)
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void LoadDataToGrid()
        {
            try
            {
                using (new HourGlass())
                {
                    ReportApiRepository reportApiRepo = new ReportApiRepository();
                    string findCriteria = dtpCreditReport.Value.ToString("MM/yyyy");
                    DateTimeZone tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();

                    this.lstReport = reportApiRepo.FindByDate(findCriteria, tz.Id);
                    if (this.lstReport.Count <= 0)
                    {
                        this.txtNoReport.Text = "No Credit Report Found";
                        this.txtNoReport.Show();
                    }
                    else
                    {
                        this.txtNoReport.Hide();
                    }

                    Refresh();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            
        }
    }
}
