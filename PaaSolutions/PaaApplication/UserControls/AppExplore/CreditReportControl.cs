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
using Core.Application.Data.ClientInfo;
using PaaApplication.Helper;
using Core.Infrastructure.ClientInfo;
using CreditReport.Domain.Model;
using BrightIdeasSoftware;
using System.IO;
using Core.Infrastructure.ExploreApps;
using AutoDocument.Application.Data;
using CreditReport.Infrastructure;
using Common.Infrastructure.UI;

namespace PaaApplication.UserControls.AppExplore
{
    public partial class CreditReportControl : UserControl
    {
        private List<CreditReportViewItem> lstReport = null;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ReportApiRepository reportRepository = new ReportApiRepository();

        public CreditReportControl()
        {
            InitializeComponent();
            InitOLV();
        }

        private void InitOLV()
        {
            this.olvcolPulledDate.AspectGetter = delegate(object row)
            {
                CreditReportViewItem report = row as CreditReportViewItem;
                if (report != null)
                {
                    return ((DateTime)report.UpdatedAt).ToLocalTime();
                }
                return "";
            };
            this.olvcolPulledBy.AspectGetter = delegate(object row)
            {
                CreditReportViewItem report = row as CreditReportViewItem;
                if (report != null)
                {
                    return report.PulledBy;
                }
                return "";
            };
            this.olvcolApplicantName.AspectGetter = delegate(object row)
            {
                CreditReportViewItem report = row as CreditReportViewItem;

                if (report != null)
                {
                    return report.ApplicantName;
                }
                return "";
            };
            this.olvcolEndUser.AspectGetter = delegate(object row)
            {
                CreditReportViewItem report = row as CreditReportViewItem;
                if (report != null)
                {
                    return report.EndUser;
                }
                return "";
            };
            this.olvcolReportId.AspectGetter = delegate(object row)
            {
                CreditReportViewItem report = row as CreditReportViewItem;
                if (report != null)
                {
                    return report.ReportId;
                }
                return "";
            };
            this.olvcolCreditType.AspectGetter = delegate(object row)
            {
                CreditReportViewItem report = row as CreditReportViewItem;
                if (report != null)
                {
                    return report.Type;
                }
                return "";
            };
            this.olvcolStatus.AspectGetter = delegate(object row)
            {
                CreditReportViewItem report = row as CreditReportViewItem;
                if (report != null)
                {
                    if (report.StatusCode.Trim().Equals("0"))
                    {
                        return "Completed";
                    }
                    else if (report.StatusCode.Trim().Equals("-4"))
                    {
                        return "No Hit";
                    }
                }
                return "";
            };
        }

        public void Refresh(List<CreditReportViewItem> reports)
        {
            reports.Sort((x, y) => DateTime.Compare(x.UpdatedAt, y.UpdatedAt));
            this.lstReport = reports;
            if (this.lstReport != null && this.lstReport.Count > 0)
            {
                this.olvReports.SetObjects(this.lstReport);
            }
            else
            {
                this.olvReports.ClearObjects();
            }
        }

        private void olvReports_IsHyperlink(object sender, IsHyperlinkEventArgs e)
        {
            string status = ((CreditReportViewItem)e.Model).StatusCode;
            if (status.Trim().Equals("-4"))
            {
                e.IsHyperlink = false;
            }
            else if (status.Trim().Equals("0"))
            {
                e.IsHyperlink = true;
            }
            /*
            else
            {
                string dataBlob = ((CreditReportViewItem)e.Model).DataBlob;

                byte[] data = Convert.FromBase64String(dataBlob);
                string url = Encoding.UTF8.GetString(data);

                string path = Path.GetTempPath() + ((CreditReportViewItem)e.Model).ReportId + ".html";

                try
                {
                    File.WriteAllText(path, url);
                    e.Url = path;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }  
            }
             * */
        }

        private void olvReports_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.ClickCount < 2) return;
            var item = e.Model as CreditReportViewItem;
            var row = e.RowIndex;
            var col = e.ColumnIndex;

            if (item.StatusCode != "0") return;
            using (new HourGlass())
            {
                Report report = reportRepository.FindByReportAndAppId(item.ReportId, item.ApplicationId);
                if (report != null)
                {
                    string dataBlob = report.DataBlob;

                    byte[] data = Convert.FromBase64String(dataBlob);
                    string url = Encoding.UTF8.GetString(data);

                    string path = Path.GetTempPath() + report.ReportId + ".html";

                    try
                    {
                        File.WriteAllText(path, url);
                        System.Diagnostics.Process.Start(path);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex);
                    }
                }
            }
        }
    }
}
