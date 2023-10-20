using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using PaaApplication.Models.Common;
using Core.Application.Data.ExploreApps;
using Core.Application.Data.ClientInfo;
using System.Configuration;
using Common.Infrastructure.Office;
using Word = NetOffice.WordApi;
using System.Text.RegularExpressions;
using PaaApplication.Helper;
using Common.Infrastructure.AppEnvironment;
using NetOffice.WordApi.Enums;
using IdentityAccess.Domain.Model.Identity;
using Core.Application.Command.ExploreApps;
using Core.Infrastructure.ExploreApps;

namespace PaaApplication.Models.AppExplore
{
    public class AppReportDocumentBuilder 
    {
        public static void FileCover(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType)
        {
            AppendPage(wordApplication, WordDocumentType.FileCoverPage);

            Word.Document doc = wordApplication.ActiveDocument;
            if (doc == null)
                return;

            string receivedDate = app.ReceivedDate.HasValue ? app.ReceivedDate.Value.ToLocalTime().ToString("M/d/yy") : string.Empty;
            string clientName = client.ClientName ?? string.Empty;

            string reportTypeName = reportType.AbsoluteTypeName;
            string applicantName = Utils.GetApplicantName(app, reportType);
            string namePlace = string.Empty;

            DateTime localReceivedDate = app.ReceivedDate.Value.ToLocalTime();
            DateTime upToDate = new DateTime(localReceivedDate.Year, localReceivedDate.AddMonths(-2).Month, 1).ToUniversalTime();
            SearchAppCommand command = new SearchAppCommand();
            command.ReceivedDateTo = upToDate;
            string customSql = string.Format(" cast(a.last_name + ', ' + a.first_name as nvarchar) < '{0}'", applicantName);
            command.CustomCondition = customSql;
            AppApiRepository appApiRepository = new AppApiRepository();
            namePlace  = appApiRepository.Count(command).ToString();

            doc.Bookmarks["Client_Name"].Range.Text = clientName;

            doc.Bookmarks["Received_Date"].Range.Text = receivedDate;

            doc.Bookmarks["Report_Type_Name"].Range.Text = reportTypeName;

            doc.Bookmarks["Name_Place"].Range.Text = namePlace;

            doc.Bookmarks["Applicant_Name"].Range.Text = applicantName;

            WordHelper.RemoveAllBookmarks(doc);

        }
        public static void Cover(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType, User user, WordDocumentType docType)
        {
            string recipient = string.Empty;
            string fax = string.Empty;
            string username = user.UserName ?? string.Empty;
            string date = DateTime.Now.ToString("M/d/yy");
            string time = DateTime.Now.ToString("h:mm tt");
            string pageNum = "2";
            string appName = Utils.GetApplicantName(app, reportType);

            Word.Document doc = wordApplication.ActiveDocument;

            if (doc == null)
                return;

            if (docType == WordDocumentType.EmpVerCover || docType == WordDocumentType.CredRefCover || 
                docType == WordDocumentType.BankRefCover || docType == WordDocumentType.RentalCover)
            {
                doc.Bookmarks["Cover_Application_Name"].Range.Text = appName;
            }
            else if (docType == WordDocumentType.EmpRefCover)
            {
                pageNum = "3";
                doc.Bookmarks["Cover_Application_Name1"].Range.Text = appName;
                doc.Bookmarks["Cover_Application_Name2"].Range.Text = appName;
            }
            else if (docType == WordDocumentType.CrimCover)
            {
                recipient = "Records Dept.";
                doc.Bookmarks["Cover_Application_Name"].Range.Text = appName;
                doc.Bookmarks["Cover_SSN"].Range.Text = app.AppSSN ?? string.Empty;
                doc.Bookmarks["Cover_BirthDate"].Range.Text = app.BirthDate.HasValue ? app.BirthDate.Value.ToString("MM/dd/yy") : string.Empty;
            }
            else if (docType == WordDocumentType.ClientUpdate)
            {
                pageNum = "1";
                if (client != null)
                {
                    recipient = client.ClientName ?? string.Empty;
                    fax = client.Fax ?? string.Empty;
                }
                doc.Bookmarks["Cover_Application_Name"].Range.Text = appName;
            }
            else if (docType == WordDocumentType.DegreeVerCover)
            {
                string text = string.Format("Please release education records for {0} as allowed by the following release of liability.", appName);
                doc.Bookmarks["Cover_Messages"].Range.Text = text;
            }

            doc.Bookmarks["Cover_Recipient"].Range.Text = recipient;
            doc.Bookmarks["Cover_Fax"].Range.Text = fax;
            doc.Bookmarks["Cover_From"].Range.Text = username;
            doc.Bookmarks["Cover_Date"].Range.Text = date;
            doc.Bookmarks["Cover_Time"].Range.Text = time;
            doc.Bookmarks["Cover_PageNum"].Range.Text = pageNum;

            WordHelper.RemoveAllBookmarks(doc);
        }

        // done
        public static void DeclinationLetter(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType)
        {
            AppendPage(wordApplication, WordDocumentType.DeclinationLetter);

            string declinationAppDetail = "";
            Word.Document doc = wordApplication.ActiveDocument;
            if (doc == null)
                return;

            declinationAppDetail = Utils.GetApplicantName(app, reportType) + Environment.NewLine +
                app.HouseNumber + " " + app.StreetAddress + Environment.NewLine +
                app.City + ", " + app.State + " " + app.PostalCode;

            string clientName = app.ClientAppliedName ?? "";

            doc.Bookmarks["Declination_AppDetail"].Range.Text = declinationAppDetail;
            doc.Bookmarks["Declination_ClientName"].Range.Text = clientName;

            if (app.Recommendation != null)
            {
                if (app.Recommendation.RentalHistory)
                    doc.Bookmarks["Declination_RentalHistory"].Range.Text = "t";
                if (app.Recommendation.CreditHistory)
                    doc.Bookmarks["Declination_CreditHistory"].Range.Text = "t";
                if (app.Recommendation.RentToIncome)
                    doc.Bookmarks["Declination_RentToIncome"].Range.Text = "t";
                if (app.Recommendation.FalseOrDiscrimminationInfo)
                    doc.Bookmarks["Declination_FalseOrDiscrimminationInfo"].Range.Text = "t";
                if (app.Recommendation.ShortTimeOnTheJob)
                    doc.Bookmarks["Declination_ShortTimeOnTheJob"].Range.Text = "t";
                if (app.Recommendation.LackOfInformation)
                    doc.Bookmarks["Declination_LackOfInformation"].Range.Text = "t";
                if (app.Recommendation.CrimminalHistory)
                    doc.Bookmarks["Declination_CrimminalHistory"].Range.Text = "t";
            }
        }

        public static DocumentCompleteResult ConfidentialityCoverPage(AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ConfidentialityCoverPage);
            WordService word = new WordService(templatePath, null, false);
            Word.Application applicationInstance = word.GetApplicationInstance();
            Word.Document documentInstance = word.GetDocumentInstance();

            return new DocumentCompleteResult(null, word, string.Empty);
        }

        // done
        public static void ResidentialNameEmpPage(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType)
        {
            AppendPage(wordApplication, WordDocumentType.ResidentialNameEmpPage);

            TypeResidentialHeader(wordApplication, app, client, reportType, false, false);

            TypeCredInfo(wordApplication, app.CreditInfo);

            TypeEmpVersYesNo(wordApplication, app, reportType);

            Word.Document doc = wordApplication.ActiveDocument;

            WordHelper.RemoveAllBookmarks(doc);

        }

        // done
        public static void ResRentalRefs(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            int startRef = (pageNo * 2) - 2;

            
            string applicantName = Utils.GetApplicantName(app, reportType);
            bool appendPage = AppendPage(wordApplication, WordDocumentType.ResRentalRefs);

            Word.Document doc = wordApplication.ActiveDocument;
            if (doc == null)
                return;
            
            RentalRefData curRentalRef;
            if (startRef >= app.RentalRefs.Count)
            {
                curRentalRef = new RentalRefData();
                curRentalRef.MoveIn = "N/A";
                curRentalRef.MoveOut = "N/A";
                if (startRef == 0)
                {
                    curRentalRef.Comment = Environment.NewLine + Environment.NewLine + "No rental history obtained." + Utils.StringText(Environment.NewLine, 6, "") + "No further information available.";
                }
                else
                {
                    curRentalRef.Comment = Environment.NewLine + Environment.NewLine + "No further rental history obtained." + Utils.StringText(Environment.NewLine, 6, "") + "No further information available.";
                }
            }
            else
            {
                curRentalRef = app.RentalRefs.ElementAt(startRef);
            }
            TypeResRentalRef(curRentalRef, wordApplication, app, 1);
            

            if (startRef + 1 >= app.RentalRefs.Count)
            {
                curRentalRef = new RentalRefData();
                curRentalRef.MoveIn = "N/A";
                curRentalRef.MoveOut = "N/A";
                if (startRef == 0)
                {
                    curRentalRef.Comment = Environment.NewLine + Environment.NewLine + "No rental history obtained." + Utils.StringText(Environment.NewLine, 6, "") + "No further information available.";
                }
                else
                {
                    curRentalRef.Comment = Environment.NewLine + Environment.NewLine + "No further rental history obtained." + Utils.StringText(Environment.NewLine, 6, "") + "No further information available.";
                }
            }
            else
            {
                curRentalRef = app.RentalRefs.ElementAt(startRef + 1);
            }
            TypeResRentalRef(curRentalRef, wordApplication, app, 2);

            WordHelper.RemoveAllBookmarks(doc);
        }

        // done
        public static void ResCredCrimPage(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType)
        {
            AppendPage(wordApplication, WordDocumentType.ResCredCrimPage);

            string applicantName = Utils.GetApplicantName(app, reportType);

            Word.Document doc = wordApplication.ActiveDocument;
            if (doc == null)
                return;

            TypeCharges(wordApplication, app.Charges, 0);

            TypeEvictions(wordApplication, app.Evictions, 0);

            TypeCreditInfoTotals(wordApplication, app.CreditInfo);

            WordHelper.RemoveAllBookmarks(doc);

        }

        // done
        public static void ResXCriminalPage(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            AppendPage(wordApplication, WordDocumentType.ResXCriminalPage);
            int startIndex = 2 + ((pageNo - 1) * 12);
            int numToGet = app.Charges.Count - startIndex > 12 ? 12 : app.Charges.Count - startIndex;
            List<ChargeRefData> charges = app.Charges.GetRange(startIndex, numToGet);
            TypeXCriminal(wordApplication, charges);
        }

        // done
        public static void ResXEvictionPage(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            AppendPage(wordApplication, WordDocumentType.ResXEvictionPage);
            int startIndex = 2 + ((pageNo - 1) * 16);
            int numToGet = app.Evictions.Count - startIndex > 16 ? 16 : app.Evictions.Count - startIndex;
            List<EvictionRefData> evictions = app.Evictions.GetRange(startIndex, numToGet);
            TypeXEviction(wordApplication, evictions);

        }

        public static void ResFinalPage(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType)
        {
            AppendPage(wordApplication, WordDocumentType.ResFinalPage);

            Word.Document doc = wordApplication.Documents.Application.ActiveDocument;
            if (doc == null)
                return;

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

            TypeRecommendation(wordApplication, app.Recommendation);

            if (lbApproval && !lbBlankRec)
            {
                doc.Bookmarks["ResFinalPage_MeetRentalCriteria_Yes"].Range.Text = "t";
            }
            else if (!lbApproval && !lbApproval)
            {
                doc.Bookmarks["ResFinalPage_MeetRentalCriteria_No"].Range.Text = "t";
            }

            doc.Bookmarks["FinalComments"].Range.Text = app.FinalComments != null ? Utils.RtfToText(app.FinalComments) : "";

            WordHelper.RemoveAllBookmarks(doc);
        }

        public static void ResFinalPageA(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType)
        {
            AppendPage(wordApplication, WordDocumentType.ResFinalPage);

            Word.Document doc = wordApplication.Documents.Application.ActiveDocument;
            if (doc == null)
                return;

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

            if (lbApproval && !lbBlankRec)
            {
                doc.Bookmarks["ResFinalPage_MeetRentalCriteria_Yes"].Range.Text = "t";
            }
            else if (!lbApproval && !lbApproval)
            {
                doc.Bookmarks["ResFinalPage_MeetRentalCriteria_No"].Range.Text = "t";
            }

            if (lbApproval && !lbBlankRec)
            {
                if (string.IsNullOrEmpty(app.FinalComments))
                {
                    doc.Bookmarks["FinalComments"].Range.Text = "Applicant Qualifies.";
                }
                else
                {
                    doc.Bookmarks["FinalComments"].Range.Text = Utils.RtfToText(app.FinalComments);
                }
            }
            else
            {
                doc.Bookmarks["FinalComments"].Range.Text = Utils.RtfToText(app.FinalComments);
            }


            WordHelper.RemoveAllBookmarks(doc);
        }

        public static DocumentCompleteResult EmpNameCrimPage(AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.EmpNameCrimPage);
            WordService word = new WordService(templatePath, null, false);
            Word.Document documentInstance = word.GetDocumentInstance();
            Word.Application applicationInstance = word.GetApplicationInstance();

            if (word != null)
            {
                DocumentCompleteResult result = new DocumentCompleteResult(null, word, "");
                return result;
            }
            return null;
        }

        public static DocumentCompleteResult EmpRefsPage(AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.EmpRefsPage);
            WordService word = new WordService(templatePath, null, false);
            Word.Document documentInstance = word.GetDocumentInstance();
            Word.Application applicationInstance = word.GetApplicationInstance();

            if (word != null)
            {
                DocumentCompleteResult result = new DocumentCompleteResult(null, word, "");
                return result;
            }
            return null;
        }

        public static DocumentCompleteResult EmpFinalPage(AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.EmpFinalPage);
            WordService word = new WordService(templatePath, null, false);
            Word.Document documentInstance = word.GetDocumentInstance();
            Word.Application applicationInstance = word.GetApplicationInstance();

            if (word != null)
            {
                DocumentCompleteResult result = new DocumentCompleteResult(null, word, "");
                return result;
            }
            return null;
        }

        // done
        public static void CrimNameCrimPage(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType)
        {
            AppendPage(wordApplication, WordDocumentType.CrimNameCrimPage);

            Word.Document doc = wordApplication.Documents.Application.ActiveDocument;
            if (doc == null)
                return;

            TypeResidentialHeader(wordApplication, app, client, reportType, false, false);

            TypeCredInfo(wordApplication, app.CreditInfo);

            TypeCreditInfoTotals(wordApplication, app.CreditInfo);

            WordHelper.RemoveAllBookmarks(doc);
        }

        public static DocumentCompleteResult FinalCommentsPage(AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.FinalCommentsPage);
            WordService word = new WordService(templatePath, null, false);
            Word.Document documentInstance = word.GetDocumentInstance();
            Word.Application applicationInstance = word.GetApplicationInstance();

            if (word != null)
            {
                DocumentCompleteResult result = new DocumentCompleteResult(null, word, "");
                return result;
            }
            return null;
        }

        // done
        public static void CreditOnlyPage(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType)
        {
            AppendPage(wordApplication, WordDocumentType.CreditOnlyPage);

            Word.Document doc = wordApplication.Documents.Application.ActiveDocument;
            if (doc == null)
                return;

            TypeResidentialHeader(wordApplication, app, client, reportType, false, false);

            TypeCredInfo(wordApplication, app.CreditInfo);

            TypeCreditInfoTotals(wordApplication, app.CreditInfo);

            WordHelper.RemoveAllBookmarks(doc);

        }

        public static DocumentCompleteResult CommNameBankPage(AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.CommNameBankPage);
            WordService word = new WordService(templatePath, null, false);
            Word.Document documentInstance = word.GetDocumentInstance();
            Word.Application applicationInstance = word.GetApplicationInstance();

            if (word != null)
            {
                DocumentCompleteResult result = new DocumentCompleteResult(null, word, "");
                return result;
            }
            return null;
        }

        public static DocumentCompleteResult CreditRefs(AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.CreditRefs);
            WordService word = new WordService(templatePath, null, false);
            Word.Document documentInstance = word.GetDocumentInstance();
            Word.Application applicationInstance = word.GetApplicationInstance();

            if (word != null)
            {
                DocumentCompleteResult result = new DocumentCompleteResult(null, word, "");
                return result;
            }
            return null;
        }

        public static DocumentCompleteResult CommFinalPage(AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.CommFinalPage);
            WordService word = new WordService(templatePath, null, false);
            Word.Document documentInstance = word.GetDocumentInstance();
            Word.Application applicationInstance = word.GetApplicationInstance();

            if (word != null)
            {
                DocumentCompleteResult result = new DocumentCompleteResult(null, word, "");
                return result;
            }
            return null;
        }

        private static bool AppendPage( Word.Application wordApplication, WordDocumentType docType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(docType);
            if (wordApplication.Documents.Count == 0)
            {
                wordApplication.Documents.Add(templatePath, false, WdNewDocumentType.wdNewBlankDocument);
                return false;
            }
            else
            {
                wordApplication.Selection.EndKey(WdUnits.wdStory);
                wordApplication.Selection.InsertBreak(WdBreakType.wdSectionBreakNextPage);
                wordApplication.Selection.InsertFile(templatePath, Type.Missing, true, false, false);
                return true;
            }
        }

        // done
        private static void TypeResidentialHeader(Word.Application wordApplication, AppData app, ClientData client, ReportTypeData reportType, bool skipSpecialField = true, bool skipMgmt = true)
        {
            Word.Document doc = wordApplication.ActiveDocument;
            if (doc == null)
                return;

            doc.Bookmarks["ResidentialHeader_Client"].Range.Text = !string.IsNullOrEmpty(app.ReportCommunity) ? app.ReportCommunity : app.ClientAppliedName;

            if (!skipMgmt)
            {
                doc.Bookmarks["ResidentialHeader_ReportManagement"].Range.Text = app.ReportManagement;
            }

            string receivedDate = app.ReceivedDate.HasValue ? app.ReceivedDate.Value.ToLocalTime().ToString("MM/dd/yy") : "";
            doc.Bookmarks["ResidentialHeader_ReceivedDate"].Range.Text = receivedDate;

            doc.Bookmarks["ResidentialHeader_UnitNumber"].Range.Text = app.UnitNumber;

            doc.Bookmarks["ResidentialHeader_RentAmount"].Range.Text = app.RentAmount;

            doc.Bookmarks["ResidentialHeader_MoveInDate"].Range.Text = app.MoveInDate;

            doc.Bookmarks["ResidentialHeader_Applicant"].Range.Text = Utils.GetApplicantName(app, reportType);

            if (!skipSpecialField)
            {
                doc.Bookmarks["ResidentialHeader_ReportSpecialField"].Range.Text = app.ReportSpecialField;
            }
        }

        // done
        private static void TypeCredInfo(Word.Application wordApplication, CreditInfoData creditInfo)
        {
            Word.Document doc = wordApplication.ActiveDocument;
            if (doc == null)
                return;

            if (creditInfo.CreditReportObtained == false)
            {
                doc.Bookmarks["CredInfo_CreditReportObtained_No"].Range.Text = "t";
                doc.Bookmarks["CredInfo_CreditMatched_No"].Range.Select();
                wordApplication.Selection.Font.Name = "Times New Romance";
                wordApplication.Selection.TypeText("N/A");

                doc.Bookmarks["CredInfo_CreditHistoryBankrupted_No"].Range.Select();
                wordApplication.Selection.Font.Name = "Times New Romance";
                wordApplication.Selection.TypeText("N/A");
                
            }
            else
            {
                if (creditInfo.CreditReportObtained == true)
                {
                    doc.Bookmarks["CredInfo_CreditReportObtained_Yes"].Range.Text = "t";
                }
                else
                {
                    doc.Bookmarks["CredInfo_CreditReportObtained_No"].Range.Text = "t";
                }

                if (creditInfo.CreditMatched == true)
                {
                    doc.Bookmarks["CredInfo_CreditMatched_Yes"].Range.Text = "t";
                }
                else
                {
                    doc.Bookmarks["CredInfo_CreditMatched_No"].Range.Text = "t";
                }

                if (creditInfo.CreditHistoryBankrupted == true)
                {
                    doc.Bookmarks["CredInfo_CreditHistoryBankrupted_Yes"].Range.Text = "t";
                }
                else
                {
                    doc.Bookmarks["CredInfo_CreditHistoryBankrupted_No"].Range.Text = "t";
                }
            }
        }

        // done
        private static void TypeEmpVersYesNo(Word.Application wordApplication, AppData app, ReportTypeData reportType)
        {
            Word.Document doc = wordApplication.ActiveDocument;
            EmpVerData empVers = app.EmpVer;
            doc.Bookmarks["EmpVersYesNo_Heading"].Range.Text = string.IsNullOrEmpty(empVers.Heading) ? "Applicant" : empVers.Heading;
            doc.Bookmarks["EmpVersYesNo_Pos"].Range.Text = empVers.Pos;
            doc.Bookmarks["EmpVersYesNo_Hire"].Range.Text = empVers.Hire;
            doc.Bookmarks["EmpVersYesNo_Salary"].Range.Text = empVers.Salary;
            doc.Bookmarks["EmpVersYesNo_FullTime"].Range.Text = empVers.FullTime;

            string sw = empVers.SW;
            if (((sw.Split(' ').ToList()).Count > 2) || (sw.ToLower() == "n/a"))
            {
                doc.Bookmarks["EmpVersYesNo_SW"].Range.Text = empVers.SW;
                doc.Bookmarks["EmpVersYesNo_Co"].Range.Text = empVers.Co;
            }
            else
            {
                doc.Bookmarks["EmpVersYesNo_SW"].Range.Text = "S/W: " + empVers.SW;
                doc.Bookmarks["EmpVersYesNo_Co"].Range.Text = "@    " + empVers.Co;
            }

            doc.Bookmarks["EmpVersYesNo_Tele"].Range.Text = empVers.Tele;
            doc.Bookmarks["EmpVersYesNo_MiscComment"].Range.Text = empVers.MiscComment;

            doc.Bookmarks["EmpVersYesNo_Heading2"].Range.Text = empVers.Heading2;
            doc.Bookmarks["EmpVersYesNo_Pos2"].Range.Text = empVers.Pos2;
            doc.Bookmarks["EmpVersYesNo_Hire2"].Range.Text = empVers.Hire2;
            doc.Bookmarks["EmpVersYesNo_Salary2"].Range.Text = empVers.Salary2;
            doc.Bookmarks["EmpVersYesNo_FullTime2"].Range.Text = empVers.FullTime2;

            string sw2 = empVers.SW2;
            if (((sw2.Split(' ').ToList()).Count > 2) || (sw.ToLower() == "n/a"))
            {
                doc.Bookmarks["EmpVersYesNo_SW2"].Range.Text = empVers.SW2;
                doc.Bookmarks["EmpVersYesNo_Co2"].Range.Text = empVers.Co2;
            }
            else
            {
                doc.Bookmarks["EmpVersYesNo_SW2"].Range.Text = "S/W: " + empVers.SW2;
                doc.Bookmarks["EmpVersYesNo_Co2"].Range.Text = "@    " + empVers.Co2;
            }

            doc.Bookmarks["EmpVersYesNo_Tele2"].Range.Text = empVers.Tele2;
        }

        private static void TypeCharges(Word.Application wordApplication, List<ChargeRefData> charges, int index)
        {
            ChargeRefData currentCharge1, currentCharge2;
            if (index >= charges.Count)
            {
                currentCharge1 = new ChargeRefData();
                currentCharge1.Heading = "";
                currentCharge1.State = "N/A";
                currentCharge1.County = "N/A";
                currentCharge1.Charge = "N/A";
                currentCharge1.Date = "N/A";
                currentCharge1.Sentence = "N/A";
            }
            else
            {
                currentCharge1 = charges.ElementAt(index);
            }
            if (index + 1 >= charges.Count)
            {
                currentCharge2 = new ChargeRefData();
                currentCharge2.Heading = "";
                currentCharge2.State = "N/A";
                currentCharge2.County = "N/A";
                currentCharge2.Charge = "N/A";
                currentCharge2.Date = "N/A";
                currentCharge2.Sentence = "N/A";
            }
            else
            {
                currentCharge2 = charges.ElementAt(index + 1);
            }

            Word.Document doc = wordApplication.ActiveDocument;
            doc.Bookmarks["Charge_Heading_1"].Range.Text = currentCharge1.Heading;
            doc.Bookmarks["Charge_State_1"].Range.Text = currentCharge1.State;
            doc.Bookmarks["Charge_County_1"].Range.Text = currentCharge1.County;
            doc.Bookmarks["Charge_Charge_1"].Range.Text = currentCharge1.Charge;
            doc.Bookmarks["Charge_Date_1"].Range.Text = currentCharge1.Date;
            doc.Bookmarks["Charge_Sentence_1"].Range.Text = currentCharge1.Sentence;

            doc.Bookmarks["Charge_Heading_2"].Range.Text = currentCharge2.Heading;
            doc.Bookmarks["Charge_State_2"].Range.Text = currentCharge2.State;
            doc.Bookmarks["Charge_County_2"].Range.Text = currentCharge2.County;
            doc.Bookmarks["Charge_Charge_2"].Range.Text = currentCharge2.Charge;
            doc.Bookmarks["Charge_Date_2"].Range.Text = currentCharge2.Date;
            doc.Bookmarks["Charge_Sentence_2"].Range.Text = currentCharge2.Sentence;
        }

        // done
        private static void TypeEvictions(Word.Application wordApplication, List<EvictionRefData> evictions, int index)
        {
            EvictionRefData eviction1, eviction2;
            if (index >= evictions.Count)
            {
                eviction1 = new EvictionRefData();
                eviction1.Heading = "";
                eviction1.State = "N/A";
                eviction1.County = "N/A";
                eviction1.Owners = "N/A";
                eviction1.Date = "N/A";
            }
            else
            {
                eviction1 = evictions.ElementAt(index);
            }
            if (index + 1 >= evictions.Count)
            {
                eviction2 = new EvictionRefData();
                eviction2.Heading = "";
                eviction2.State = "N/A";
                eviction2.County = "N/A";
                eviction2.Owners = "N/A";
                eviction2.Date = "N/A";
            }
            else
            {
                eviction2 = evictions.ElementAt(index + 1);
            }

            Word.Document doc = wordApplication.ActiveDocument;
            doc.Bookmarks["Eviction_Heading_1"].Range.Text = eviction1.Heading;
            doc.Bookmarks["Eviction_State_1"].Range.Text = eviction1.State;
            doc.Bookmarks["Eviction_County_1"].Range.Text = eviction1.County;
            doc.Bookmarks["Eviction_Owners_1"].Range.Text = eviction1.Owners;
            doc.Bookmarks["Eviction_Date_1"].Range.Text = eviction1.Date;

            doc.Bookmarks["Eviction_Heading_2"].Range.Text = eviction2.Heading;
            doc.Bookmarks["Eviction_State_2"].Range.Text = eviction2.State;
            doc.Bookmarks["Eviction_County_2"].Range.Text = eviction2.County;
            doc.Bookmarks["Eviction_Owners_2"].Range.Text = eviction2.Owners;
            doc.Bookmarks["Eviction_Date_2"].Range.Text = eviction2.Date;
        }

        // done
        private static void TypeResRentalRef(RentalRefData curRentalRef, Word.Application wordApplication, AppData app, int index)
        {
            Word.Document doc = wordApplication.ActiveDocument;
            bool isCurrent = false;
            if (!app.ReceivedDate.HasValue)
            {
                isCurrent = false;
            }
            else
            {
                DateTime received = app.ReceivedDate.Value;
                if (curRentalRef.MoveOut.ToLower().Contains("curr") ||
                Utils.IsFutureDate(curRentalRef.MoveOut, received))
                {
                    isCurrent = true;
                }
            }
            if (isCurrent)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Current_Previous", index)].Range.Text = "CURRENT";
            }
            else
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Current_Previous", index)].Range.Text = "PREVIOUS";
            }

            doc.Bookmarks[string.Format("ResRentalRef{0}_MoveIn", index)].Range.Text = curRentalRef.MoveIn;
            doc.Bookmarks[string.Format("ResRentalRef{0}_MoveOut", index)].Range.Text = curRentalRef.MoveOut;
            doc.Bookmarks[string.Format("ResRentalRef{0}_Amount", index)].Range.Text = curRentalRef.Amount;
            if (curRentalRef.Written == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Written_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.Written == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Written_No", index)].Range.Text = "t";
            }
            if (curRentalRef.KickedOut == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_KickedOut_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.KickedOut == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_KickedOut_No", index)].Range.Text = "t";
            }
            if (curRentalRef.PrprNotice == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_PrprNotice_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.PrprNotice == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_PrprNotice_No", index)].Range.Text = "t";
            }
            if (curRentalRef.LateNSF == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_LateNSF_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.LateNSF == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_LateNSF_No", index)].Range.Text = "t";
            }
            if (curRentalRef.Complaints == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Complaints_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.Complaints == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Complaints_No", index)].Range.Text = "t";
            }
            if (curRentalRef.Damages == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Damages_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.Damages == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Damages_No", index)].Range.Text = "t";
            }
            if (curRentalRef.Owing == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Owing_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.Owing == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Owing_No", index)].Range.Text = "t";
            }
            if (curRentalRef.Roommates == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Roommates_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.Roommates == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Roommates_No", index)].Range.Text = "t";
            }
            if (curRentalRef.AddressMatch == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_AddressMatch_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.AddressMatch == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_AddressMatch_No", index)].Range.Text = "t";
            }
            if (curRentalRef.Pets == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Pets_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.Pets == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Pets_No", index)].Range.Text = "t";
            }
            if (curRentalRef.RltveFrnd == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_RltveFrnd_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.RltveFrnd == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_RltveFrnd_No", index)].Range.Text = "t";
            }
            if (curRentalRef.ReRent == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_ReRent_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.ReRent == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_ReRent_No", index)].Range.Text = "t";
            }
            if (curRentalRef.BedBugs == RentalRefFactInfoData.Yes)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_BedBugs_Yes", index)].Range.Text = "t";
            }
            else if (curRentalRef.BedBugs == RentalRefFactInfoData.No)
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_BedBugs_No", index)].Range.Text = "t";
            }
            if (string.IsNullOrEmpty(curRentalRef.SW))
            {
                doc.Bookmarks[string.Format("ResRentalRef{0}_Comment", index)].Range.Text = Utils.RtfToText(curRentalRef.Comment);
            }
            else
            {
                if (string.IsNullOrEmpty(curRentalRef.Comp))
                {
                    curRentalRef.Comp = curRentalRef.Phone;
                    curRentalRef.Phone = "";
                }
                doc.Bookmarks[string.Format("ResRentalRef{0}_Comment", index)].Range.Text = "S/W: " + curRentalRef.SW +
                    Environment.NewLine + "@    " + curRentalRef.Comp +
                    Environment.NewLine + curRentalRef.Phone +
                    Environment.NewLine + Utils.RtfToText(curRentalRef.Comment);
            }
        }

        // done
        private static void TypeCreditInfoTotals(Word.Application wordApplication, CreditInfoData creditInfo)
        {
            // refactor if need
            decimal total = 0m;
            total = creditInfo.PastDueAmounts + creditInfo.Rent + creditInfo.Collections + creditInfo.Liens + creditInfo.Judgements + creditInfo.ChildSupport;
            Word.Document doc = wordApplication.ActiveDocument;
            doc.Bookmarks["CreditInfoTotals_PastDueAmounts"].Range.Text = creditInfo.PastDueAmounts.ToString();
            doc.Bookmarks["CreditInfoTotals_Rent"].Range.Text = creditInfo.Rent.ToString();
            doc.Bookmarks["CreditInfoTotals_Collections"].Range.Text = creditInfo.Collections.ToString();
            doc.Bookmarks["CreditInfoTotals_Liens"].Range.Text = creditInfo.Liens.ToString();
            doc.Bookmarks["CreditInfoTotals_Judgements"].Range.Text = creditInfo.Judgements.ToString();
            doc.Bookmarks["CreditInfoTotals_ChildSupport"].Range.Text = creditInfo.ChildSupport.ToString();
            doc.Bookmarks["CreditInfoTotals_BankruptcyDate"].Range.Text = creditInfo.Dates;

            if (!string.IsNullOrEmpty(creditInfo.Dates))
            {
                doc.Bookmarks["CreditInfoTotals_PositiveCreditSince"].Range.Text = creditInfo.PositiveCreditSince ? "Yes" : "No";
            }

            string totalText = String.Format("{0:#,###,###,##0.00}", total);
            doc.Bookmarks["CreditInfoTotals_Total"].Range.Text = "$" + totalText;
        }

        // done
        private static void TypeRecommendation(Word.Application wordApplication, RecommendationFactInfoData recommendationFactInfoData)
        {
            Word.Document doc = wordApplication.ActiveDocument;

            if (recommendationFactInfoData.QualifiedRoommate == true)
            {
                doc.Bookmarks["RentOptions_QualifiedRoommate"].Range.Text = "t";
            }
            if (recommendationFactInfoData.Cosigner == true)
            {
                doc.Bookmarks["RentOptions_Cosigner"].Range.Text = "t";
            }
            if (recommendationFactInfoData.FirstAndSecurity == true)
            {
                doc.Bookmarks["RentOptions_FirstAndSecurity"].Range.Text = "t";
            }
            if (recommendationFactInfoData.AbsPosNO == true)
            {
                doc.Bookmarks["RentOptions_AbsPosNO"].Range.Text = "t";
            }
            if (recommendationFactInfoData.RentalHistory == true)
            {
                doc.Bookmarks["RentOptions_RentalHistory"].Range.Text = "t";
            }
            if (recommendationFactInfoData.CreditHistory == true)
            {
                doc.Bookmarks["RentOptions_CreditHistory"].Range.Text = "t";
            }
            if (recommendationFactInfoData.RentToIncome == true)
            {
                doc.Bookmarks["RentOptions_RentToIncome"].Range.Text = "t";
            }
            if (recommendationFactInfoData.FalseOrDiscrimminationInfo == true)
            {
                doc.Bookmarks["RentOptions_FalseOrDiscrimminationInfo"].Range.Text = "t";
            }
            if (recommendationFactInfoData.ShortTimeOnTheJob == true)
            {
                doc.Bookmarks["RentOptions_ShortTimeOnTheJob"].Range.Text = "t";
            }
            if (recommendationFactInfoData.LackOfInformation == true)
            {
                doc.Bookmarks["RentOptions_LackOfInformation"].Range.Text = "t";
            }
            if (recommendationFactInfoData.CrimminalHistory == true)
            {
                doc.Bookmarks["RentOptions_CrimminalHistory"].Range.Text = "t";
            }
        }

        // done 
        private static void TypeXCriminal(Word.Application wordApplication, List<ChargeRefData> charges)
        {
            Word.Document doc = wordApplication.ActiveDocument;
            if (doc == null)
                return;

            for (int i = 0; i < charges.Count; i = i + 2)
            {
                ChargeRefData firstCharge, secondCharge;
                firstCharge = charges.ElementAt(i);

                if (i + 1 >= charges.Count)
                {
                    secondCharge = new ChargeRefData();
                    secondCharge.Heading = "";
                    secondCharge.State = "N/A";
                    secondCharge.County = "N/A";
                    secondCharge.Charge = "N/A";
                    secondCharge.Date = "N/A";
                    secondCharge.Sentence = "N/A";
                }
                else
                {
                    secondCharge = charges.ElementAt(i + 1);
                }

                doc.Bookmarks[string.Format("XCriminal_Heading_{0}", i + 1)].Range.Text = firstCharge.Heading;
                doc.Bookmarks[string.Format("XCriminal_State_{0}", i + 1)].Range.Text = firstCharge.State;
                doc.Bookmarks[string.Format("XCriminal_County_{0}", i + 1)].Range.Text = firstCharge.County;
                doc.Bookmarks[string.Format("XCriminal_Charge_{0}", i + 1)].Range.Text = firstCharge.Charge;
                doc.Bookmarks[string.Format("XCriminal_Date_{0}", i + 1)].Range.Text = firstCharge.Date;
                doc.Bookmarks[string.Format("XCriminal_Sentence_{0}", i + 1)].Range.Text = firstCharge.Sentence;

                doc.Bookmarks[string.Format("XCriminal_Heading_{0}", i + 2)].Range.Text = secondCharge.Heading;
                doc.Bookmarks[string.Format("XCriminal_State_{0}", i + 2)].Range.Text = secondCharge.State;
                doc.Bookmarks[string.Format("XCriminal_County_{0}", i + 2)].Range.Text = secondCharge.County;
                doc.Bookmarks[string.Format("XCriminal_Charge_{0}", i + 2)].Range.Text = secondCharge.Charge;
                doc.Bookmarks[string.Format("XCriminal_Date_{0}", i + 2)].Range.Text = secondCharge.Date;
                doc.Bookmarks[string.Format("XCriminal_Sentence_{0}", i + 2)].Range.Text = secondCharge.Sentence;
            }
        }

        // done
        private static void TypeXEviction(Word.Application wordApplication, List<EvictionRefData> evictions)
        {
            Word.Document doc = wordApplication.ActiveDocument;
            if (doc == null)
                return;

            for (int i = 0; i < evictions.Count; i = i + 2)
            {
                EvictionRefData firstEviction, secondEviction;
                firstEviction = evictions.ElementAt(i);

                if (i + 1 >= evictions.Count)
                {
                    secondEviction = new EvictionRefData();
                    secondEviction.Heading = "";
                    secondEviction.State = "N/A";
                    secondEviction.County = "N/A";
                    secondEviction.Owners = "N/A";
                    secondEviction.Date = "N/A";
                }
                else
                {
                    secondEviction = evictions.ElementAt(i + 1);
                }

                doc.Bookmarks[string.Format("XEviction_Heading_{0}", i + 1)].Range.Text = firstEviction.Heading;
                doc.Bookmarks[string.Format("XEviction_State_{0}", i + 1)].Range.Text = firstEviction.State;
                doc.Bookmarks[string.Format("XEviction_County_{0}", i + 1)].Range.Text = firstEviction.County;
                doc.Bookmarks[string.Format("XEviction_Owners_{0}", i + 1)].Range.Text = firstEviction.Owners;
                doc.Bookmarks[string.Format("XEviction_Date_{0}", i + 1)].Range.Text = firstEviction.Date;

                doc.Bookmarks[string.Format("XEviction_Heading_{0}", i + 2)].Range.Text = secondEviction.Heading;
                doc.Bookmarks[string.Format("XEviction_State_{0}", i + 2)].Range.Text = secondEviction.State;
                doc.Bookmarks[string.Format("XEviction_County_{0}", i + 2)].Range.Text = secondEviction.County;
                doc.Bookmarks[string.Format("XEviction_Owners_{0}", i + 2)].Range.Text = secondEviction.Owners;
                doc.Bookmarks[string.Format("XEviction_Date_{0}", i + 2)].Range.Text = secondEviction.Date;
            }
        }
    }
}