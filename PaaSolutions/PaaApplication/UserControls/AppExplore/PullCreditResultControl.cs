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
using CreditReport.Infrastructure;
using CreditReport.Domain.Model;
using Core.Domain.Model.ClientInfo;

namespace PaaApplication.UserControls.AppExplore
{
    public partial class PullCreditResultControl : UserControl
    {
        private List<AppData> appList = null;
        private List<Report> pullList = null;
        private ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<string> cancelList = null;
        private bool isCancel;


        public PullCreditResultControl()
        {
            InitializeComponent();
            InitOLV();
        }

        private bool isAbleToPullCredit(AppData app, ClientData client)
        {
            string creditType = client.CreditType.DisplayName;
            // Only proceed pull credit for particular report types
            if (string.IsNullOrEmpty(creditType) ||
                creditType.Equals(CreditType.EnhancePeopleSearch.DisplayName) ||
                creditType.Equals(CreditType.NoCreditReports.DisplayName))
            {
                return false;
            }
            if (app.ReportTypeName == "Res1" ||
                app.ReportTypeName == "Res2" ||
                app.ReportTypeName == "Res3" ||
                app.ReportTypeName == "Res4" ||
                app.ReportTypeName == "Cred1" ||
                app.ReportTypeName == "Cred2" ||
                app.ReportTypeName == "CredCrim" ||
                app.ReportTypeName == "ResECC" ||
                app.ReportTypeName == "ZFreebieCC " ||
                app.ReportTypeName == "ZFreebieCred ")
            {
                return true;
            }
            return false;
        }

        private void InitOLV()
        {
            this.olvcolResult.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    try
                    {
                        if(this.isCancel == true)
                        {
                            string appCanceledId = this.cancelList.Find(x => x == app.ApplicationId);
                            if(!string.IsNullOrEmpty(appCanceledId))
                            {
                                return "Cancelled";
                            }
                        }

                        if(this.pullList != null && this.pullList.Count > 0)
                        {
                            Report report = this.pullList.FirstOrDefault(p => p.ApplicationId == app.ApplicationId);

                            if (report == null)
                            {
                                return "Not Completed";
                            }
                            if (report.StatusCode.Trim() == "MT")
                            {
                                return "Missing Type";
                            }
                            if (report.StatusCode.Trim() == "NW_ERR")
                            {
                                return "Network Error";
                            }
                            if (report.StatusCode.Trim() == "UN_ERR")
                            {
                                return "Unknown Error";
                            }
                            if (report.StatusCode.Trim().Equals("-1"))
                            {
                                return "Bureau Error";
                            }
                            if (report.StatusCode.Trim().Equals("-2"))
                            {
                                return "Internal Error";
                            }
                            if (report.StatusCode.Trim().Equals("-3"))
                            {
                                return "Line Error";
                            }
                            if (report.StatusCode.Trim().Equals("-4"))
                            {
                                return "No Hit";
                            }
                            if (report.StatusCode.Trim().Equals("-5"))
                            {
                                return "Authentication Error";
                            }
                            if (report.StatusCode.Trim().Equals("-6"))
                            {
                                return "In Process";
                            }
                            if (report.StatusCode.Trim().Equals("0"))
                            {
                                return "Completed";
                            }
                            else
                            {
                                return "Not Completed";
                            }
                        }
                        else
                        {
                            return "Not Completed";
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex);
                        return "";
                    }                    
                }
                return "";
            };
            this.olvcolAppName.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                    return Utils.GetApplicantName(app, reportType);
                }
                return "";
            };
            this.olvcolDOB.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    return app.BirthDate;
                }
                return "";
            };
            this.olvcolSSN.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    return app.AppSSN;
                }
                return "";
            };
            this.olvcolEndUser.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    if (!string.IsNullOrEmpty(app.ReportManagement) && !app.ReportManagement.Trim().ToLower().Equals("ind")) return app.ReportManagement;
                    return app.ClientAppliedName;;
                }
                return "";
            };
            this.olvcolPermissPurpose.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    return "Tenant Screening";
                }
                return "";
            };
            this.olvcolCreditType.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    ClientData client = ClientCachedApiQuery.Instance.GetClient(app.ClientApplied);
                    return client.CreditType.DisplayName;
                }
                return "";
            };
        }

        public void Refresh(List<AppData> apps, List<Report> pullList, bool isCancel, List<string> cancelList)
        {
            this.appList = apps;
            this.pullList = pullList;
            this.isCancel = isCancel;
            this.cancelList = cancelList;
            if (this.appList != null && this.appList.Count > 0)
            {
                this.olvApplications.SetObjects(this.appList);
            }
            else
            {
                this.olvApplications.ClearObjects();
            }
        }
    }
}
