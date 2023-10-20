using Common.Application;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using PaaApplication.Helper;
using PaaApplication.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.AppExplore
{
    public class AppReportItem
    {
        public WordDocumentType WordDocumentType { get; set; }

        public string DisplayReportItem { get; set; }

        public int PageNo { get; set; }

        public AppReportItem(WordDocumentType docType, string displayReportItem, int pageNo = 0)
        {
            this.WordDocumentType = docType;
            this.DisplayReportItem = displayReportItem;
            this.PageNo = pageNo;
        }

        public static List<AppReportItem> GetAppReportItems(AppData app, ReportTypeData reportType)
        {
            List<AppReportItem> lstReportItems = new List<AppReportItem>();

            if (reportType == null)
                return lstReportItems;

            string currentReportTypeAbsoluteTypeName = reportType.AbsoluteTypeName;

            if (currentReportTypeAbsoluteTypeName == GlobalConstants.Residential)
            {
                lstReportItems = GetResidentialAppReportItems(app, reportType);
            }
            else if (currentReportTypeAbsoluteTypeName == GlobalConstants.Employment)
            {
                lstReportItems = GetEmploymentAppReportItems(app, reportType);
            }
            else if (currentReportTypeAbsoluteTypeName == GlobalConstants.Commercial)
            {
                lstReportItems = GetCommercialAppReportItems(app, reportType);
            }
            else if (currentReportTypeAbsoluteTypeName == GlobalConstants.CreditOnly)
            {
                lstReportItems = GetCreditOnlyAppReportItems(app, reportType);
            }
            else if (currentReportTypeAbsoluteTypeName == GlobalConstants.CrimminalOnly)
            {
                lstReportItems = GetCriminalOnlyAppReportItems(app, reportType);
            }
            else if (currentReportTypeAbsoluteTypeName == GlobalConstants.CreditCrimminal)
            {
                lstReportItems = GetCreditCriminalAppReportItems(app, reportType);
            }

            return lstReportItems;
        }

        private static List<AppReportItem> GetResidentialAppReportItems(AppData app, ReportTypeData reportType)
        {
            List<AppReportItem> result = new List<AppReportItem>();
            string bufferName = Utils.GetApplicantName(app, reportType);
            result.Add(new AppReportItem(Models.Common.WordDocumentType.ResidentialNameEmpPage, bufferName + " - Residential - Name & Emp. Page"));
            
            if (app.ReportTypeName != "ResECC")
            {
                result.Add(new AppReportItem(Models.Common.WordDocumentType.ResRentalRefs, bufferName + " - Residential - Rental Refs(Page 1)", 1));
                int numOfRentalRefs = (app.RentalRefs == null) ? 0 : app.RentalRefs.Count;
                for (int i = 2; i < numOfRentalRefs; i = i + 2)
                {
                    int pageNo = (i / 2) + 1;
                    string reportName = string.Format(bufferName + " - Residential - Rental Refs(Page {0})", pageNo);
                    result.Add(new AppReportItem(Models.Common.WordDocumentType.ResRentalRefs, reportName, pageNo));
                }
            }

            if (app.ReportTypeName != "Res2")
            {
                result.Add(new AppReportItem(Models.Common.WordDocumentType.ResCredCrimPage, bufferName + " - Residential - CredCrim Page"));
                int numOfCharges = (app.Charges == null) ? 0 : app.Charges.Count;
                int numOfEvictions = (app.Evictions == null) ? 0 : app.Evictions.Count;
                for (int i = 2; i < numOfCharges; i = i + 8)
                {
                    int pageNo = ((i - 2) / 8) + 1;
                    string reportName = string.Format(bufferName + " - Residential - Extra Criminal(Page {0})", pageNo);
                    result.Add(new AppReportItem(Models.Common.WordDocumentType.ResXCriminalPage, reportName, pageNo));
                }
                for (int i = 2; i < numOfEvictions; i = i + 8)
                {
                    int pageNo = ((i - 2) / 8) + 1;
                    string reportName = string.Format(bufferName + " - Residential - Extra Evictions(Page {0})", pageNo);
                    result.Add(new AppReportItem(Models.Common.WordDocumentType.ResXEvictionPage, reportName, pageNo));
                }
            }
            else
            {
                result.Add(new AppReportItem(Models.Common.WordDocumentType.CreditOnlyPage, bufferName + " - Bemrose Credit Report"));
                result.Add(new AppReportItem(Models.Common.WordDocumentType.CrimNameCrimPage, bufferName + " - Criminal - Name & Crim. Page"));
                int numOfCharges = (app.Charges == null) ? 0 : app.Charges.Count;
                int numOfEvictions = (app.Evictions == null) ? 0 : app.Evictions.Count;
                for (int i = 2; i < numOfCharges; i = i + 8)
                {
                    int pageNo = ((i - 2) / 8) + 1;
                    string reportName = string.Format(bufferName + " - Residential - Extra Criminal(Page {0})", pageNo);
                    result.Add(new AppReportItem(Models.Common.WordDocumentType.ResXCriminalPage, reportName, pageNo));
                }
                for (int i = 2; i < numOfEvictions; i = i + 8)
                {
                    int pageNo = ((i - 2) / 8) + 1;
                    string reportName = string.Format(bufferName + " - Residential - Extra Evictions(Page {0})", pageNo);
                    result.Add(new AppReportItem(Models.Common.WordDocumentType.ResXEvictionPage, reportName, pageNo));
                }
            }
            if (!string.IsNullOrEmpty(app.FinalComments) ||
                app.Recommendation.QualifiedRoommate ||
                app.Recommendation.Cosigner ||
                app.Recommendation.FirstAndSecurity ||
                app.Recommendation.AbsPosNO ||
                app.Recommendation.RentalHistory ||
                app.Recommendation.CreditHistory ||
                app.Recommendation.RentToIncome ||
                app.Recommendation.FalseOrDiscrimminationInfo ||
                app.Recommendation.ShortTimeOnTheJob ||
                app.Recommendation.LackOfInformation ||
                app.Recommendation.CrimminalHistory)
            {
                bool lbBlankRec = app.ReportManagement.ToLower().Contains("follett");
                lbBlankRec = lbBlankRec || app.ReportManagement.Contains("Moland");
                lbBlankRec = lbBlankRec || app.ReportCommunity.Contains("Moland");
                lbBlankRec = lbBlankRec || app.ReportCommunity.ToLower().Contains("seattle housing authority");
                bool lbApproval = (!app.Recommendation.QualifiedRoommate &&
                    !app.Recommendation.Cosigner &&
                    !app.Recommendation.FirstAndSecurity &&
                    !app.Recommendation.AbsPosNO &&
                    !app.Recommendation.RentalHistory &&
                    !app.Recommendation.CreditHistory &&
                    !app.Recommendation.RentToIncome &&
                    !app.Recommendation.FalseOrDiscrimminationInfo &&
                    !app.Recommendation.ShortTimeOnTheJob &&
                    !app.Recommendation.LackOfInformation &&
                    !app.Recommendation.CrimminalHistory);
                if (lbBlankRec || lbApproval)
                {
                    result.Add(new AppReportItem(Models.Common.WordDocumentType.ResFinalPageA, bufferName + " - Residential - Final Page"));
                }
                else
                {
                    result.Add(new AppReportItem(Models.Common.WordDocumentType.ResFinalPage, bufferName + " - Residential - Final Page"));
                }
            }

            if (app.Recommendation != null && app.Recommendation.AbsPosNO == true)
            {
                bool isOneDeclinationLetter = true;
                string reportManagement = app.ReportManagement ?? "";
                string clientName = app.ClientAppliedName ?? "";
                if (reportManagement.Contains("IPM") && !isOneDeclinationLetter)
                {
                    result.Add(new AppReportItem(Models.Common.WordDocumentType.DeclinationLetter, bufferName + " - Declination Letter"));
                    result.Add(new AppReportItem(Models.Common.WordDocumentType.DeclinationLetter, bufferName + " - Declination Letter"));
                }
                else
                {
                    result.Add(new AppReportItem(Models.Common.WordDocumentType.DeclinationLetter, bufferName + " - Declination Letter"));
                }
            }
            else if (app.Recommendation != null && (app.Recommendation.Cosigner == true || app.Recommendation.FirstAndSecurity == true))
            {
                result.Add(new AppReportItem(Models.Common.WordDocumentType.AdverseActionLetter, bufferName + " - Adverse Action Letter"));
            }

            return result;
        }

        private static List<AppReportItem> GetEmploymentAppReportItems(AppData app, ReportTypeData reportType)
        {
            List<AppReportItem> result = new List<AppReportItem>();

            string bufferName = Utils.GetApplicantName(app, reportType);
            result.Add(new AppReportItem(Models.Common.WordDocumentType.EmpNameCrimPage, bufferName + " - Employment - Name & Crim. Page"));

            int numOfCharges = (app.Charges == null) ? 0 : app.Charges.Count;
            int numOfEvictions = (app.Evictions == null) ? 0 : app.Evictions.Count;
            for (int i = 2; i < numOfCharges; i = i + 8)
            {
                int pageNo = ((i - 2) / 8) + 1;
                string reportName = string.Format(bufferName + " - Residential - Extra Criminal(Page {0})", pageNo);
                result.Add(new AppReportItem(Models.Common.WordDocumentType.ResXCriminalPage, reportName, pageNo));
            }
            for (int i = 2; i < numOfEvictions; i = i + 8)
            {
                int pageNo = ((i - 2) / 8) + 1;
                string reportName = string.Format(bufferName + " - Residential - Extra Evictions(Page {0})", pageNo);
                result.Add(new AppReportItem(Models.Common.WordDocumentType.ResXEvictionPage, reportName, pageNo));
            }

            result.Add(new AppReportItem(Models.Common.WordDocumentType.EmpRefsPage, bufferName + " - Employment - Emp. Refs(Page 1)", 1));

            int numOfEmpRefs = (app.EmpRefs == null) ? 0 : app.EmpRefs.Count;
            for (int i = 2; i < numOfEmpRefs; i = i + 2)
            {
                int pageNo = (i / 2) + 1;
                string reportName = string.Format(bufferName + " - Employment - Emp. Refs(Page {0})", pageNo);
                result.Add(new AppReportItem(Models.Common.WordDocumentType.EmpRefsPage, reportName, pageNo));
            }

            if (CheckEmpFinalPageCommentOnly(app))
            {
                result.Add(new AppReportItem(Models.Common.WordDocumentType.EmpFinalPageComment, bufferName + " - Employment - Final Page"));
            }
            else
            {
                result.Add(new AppReportItem(Models.Common.WordDocumentType.EmpFinalPage, bufferName + " - Employment - Final Page"));
            }

            int numOfRentalRefs = (app.RentalRefs == null) ? 0 : app.RentalRefs.Count;
            for (int i = 0; i < numOfRentalRefs; i = i + 2)
            {
                int pageNo = (i / 2) + 1;
                string reportName = string.Format(bufferName + " - Employment - Rental Refs(Page {0})", pageNo);
                result.Add(new AppReportItem(Models.Common.WordDocumentType.ResRentalRefs, reportName, pageNo));
            }

            return result;
        }

        private static List<AppReportItem> GetCommercialAppReportItems(AppData app, ReportTypeData reportType)
        {
            List<AppReportItem> result = new List<AppReportItem>();

            string bufferName = Utils.GetApplicantName(app, reportType);
            result.Add(new AppReportItem(Models.Common.WordDocumentType.CommNameBankPage, bufferName + " - Commercial - Name & Bank Page"));
            result.Add(new AppReportItem(Models.Common.WordDocumentType.CreditRefs, bufferName + " - Commercial - Credit Refs(Page 1)", 1));

            int numOfCreditRefs = (app.CreditRefs == null) ? 0 : app.CreditRefs.Count;
            for (int i = 4; i < numOfCreditRefs; i = i + 4)
            {
                int pageNo = (i / 4) + 1;
                string reportName = string.Format(bufferName + " - Commercial - Credit Refs(Page {0})", pageNo);
                result.Add(new AppReportItem(Models.Common.WordDocumentType.CreditRefs, reportName, pageNo));
            }

            result.Add(new AppReportItem(Models.Common.WordDocumentType.CommFinalPage, bufferName + " - Commercial - Final Page"));

            int numOfRentalRefs = (app.RentalRefs == null) ? 0 : app.RentalRefs.Count;
            for (int i = 1; i < numOfRentalRefs; i = i + 2)
            {
                int pageNo = ((i - 1) / 2) + 1;
                string reportName = string.Format(bufferName + " - Commercial - Rental Refs(Page {0})", pageNo);
                result.Add(new AppReportItem(Models.Common.WordDocumentType.CommRentalRefs, reportName, pageNo));
            }

            return result;
        }

        private static List<AppReportItem> GetCreditOnlyAppReportItems(AppData app, ReportTypeData reportType)
        {
            List<AppReportItem> result = new List<AppReportItem>();
            string bufferName = Utils.GetApplicantName(app, reportType);

            result.Add(new AppReportItem(Models.Common.WordDocumentType.CreditOnlyPage, bufferName + " - Bemrose Credit Report"));

            if (!string.IsNullOrEmpty(app.FinalComments))
            {
                result.Add(new AppReportItem(Models.Common.WordDocumentType.FinalCommentsPage, bufferName + " - Credit - Final Comments"));
            }

            return result;
        }

        private static List<AppReportItem> GetCriminalOnlyAppReportItems(AppData app, ReportTypeData reportType)
        {
            List<AppReportItem> result = new List<AppReportItem>();
            string bufferName = Utils.GetApplicantName(app, reportType);

            result.Add(new AppReportItem(Models.Common.WordDocumentType.CrimNameCrimPage, bufferName + " - Criminal - Name & Crim. Page"));
            int numOfCharges = (app.Charges == null) ? 0 : app.Charges.Count;
            int numOfEvictions = (app.Evictions == null) ? 0 : app.Evictions.Count;
            for (int i = 2; i < numOfCharges; i = i + 8)
            {
                int pageNo = ((i - 2) / 8) + 1;
                string reportName = string.Format(bufferName + " - Criminal - Extra Criminal(Page {0})", pageNo);
                result.Add(new AppReportItem(Models.Common.WordDocumentType.ResXCriminalPage, reportName, pageNo));
            }
            for (int i = 2; i < numOfEvictions; i = i + 8)
            {
                int pageNo = ((i - 2) / 8) + 1;
                string reportName = string.Format(bufferName + " - Criminal - Extra Evictions(Page {0})", pageNo);
                result.Add(new AppReportItem(Models.Common.WordDocumentType.ResXEvictionPage, reportName, pageNo));
            }
            if (!string.IsNullOrEmpty(app.FinalComments))
            {
                result.Add(new AppReportItem(Models.Common.WordDocumentType.FinalCommentsPage, bufferName + " - Criminal - Final Comments"));
            }

            return result;
        }

        private static List<AppReportItem> GetCreditCriminalAppReportItems(AppData app, ReportTypeData reportType)
        {
            List<AppReportItem> result = new List<AppReportItem>();

            string bufferName = Utils.GetApplicantName(app, reportType);

            result.Add(new AppReportItem(Models.Common.WordDocumentType.CrimNameCrimPage, bufferName + " - CredCrim - Name & Crim. Page"));

            int numOfCharges = (app.Charges == null) ? 0 : app.Charges.Count;
            int numOfEvictions = (app.Evictions == null) ? 0 : app.Evictions.Count;
            for (int i = 2; i < numOfCharges; i = i + 8)
            {
                int pageNo = ((i - 2) / 8) + 1;
                string reportName = string.Format(bufferName + " - CredCrim - Extra Criminal(Page {0})", pageNo);
                result.Add(new AppReportItem(Models.Common.WordDocumentType.ResXCriminalPage, reportName, pageNo));
            }
            for (int i = 2; i < numOfEvictions; i = i + 8)
            {
                int pageNo = ((i - 2) / 8) + 1;
                string reportName = string.Format(bufferName + " - CredCrim - Extra Evictions(Page {0})", pageNo);
                result.Add(new AppReportItem(Models.Common.WordDocumentType.ResXEvictionPage, reportName, pageNo));
            }

            result.Add(new AppReportItem(Models.Common.WordDocumentType.CreditOnlyPage, bufferName + " - CredCrim - Bemrose Credit Report"));

            if (!string.IsNullOrEmpty(app.FinalComments))
            {
                result.Add(new AppReportItem(Models.Common.WordDocumentType.FinalCommentsPage, bufferName + " - CredCrim - Final Comments"));
            }

            return result;
        }

        private static bool CheckEmpFinalPageCommentOnly(AppData app)
        {
            var creditInfo = app.CreditInfo;

            bool isCreditTotalSectionExist = true;
            bool isCreditInfoSectionExist = true;
            bool isFinalCommentOnly = false;

            if (creditInfo == null)
            {
                isFinalCommentOnly = true;
                isCreditTotalSectionExist = false;
                isCreditInfoSectionExist = true;
            }
            else
            {
                // Credit info section is always existed for Employee report
                isCreditInfoSectionExist = true;
                if (creditInfo.PastDueAmounts == 0 &&
                    creditInfo.Rent == 0 &&
                    creditInfo.Collections == 0 &&
                    creditInfo.Liens == 0 &&
                    creditInfo.Judgements == 0 &&
                    creditInfo.ChildSupport == 0)
                {
                    isCreditTotalSectionExist = false;
                }

                if (!isCreditInfoSectionExist && !isCreditTotalSectionExist)
                {
                    isFinalCommentOnly = true;
                }
            }
            return isFinalCommentOnly;
        }
    }
}
