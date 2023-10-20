using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.IO;
using Common.Infrastructure.Office;
using Core.Application.Data.ExploreApps;
using Core.Application.Data.ClientInfo;
using PaaApplication.Models.Common;
using PaaApplication.Helper;
using OpenXmlPowerTools;
using System.Text.RegularExpressions;

namespace PaaApplication.Models.AppExplore
{
    public class AppReportDocumentBuilderOpenXML
    {
        private static string FindPhoneNumber(string PhoneNumber)
        {
            string strPhone = "";
            string FormatPhone = "";
            string[] newLineArray = { Environment.NewLine, "\n" };
            string[] textArray = PhoneNumber.Split(newLineArray, StringSplitOptions.None);

            Regex phoneRegex = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");

            foreach (string line in textArray)
            {
                string[] newLineArray1 = { "," };
                string[] textArray1 = line.Split(newLineArray1, StringSplitOptions.None);
                foreach (string line1 in textArray1)
                {
                    string strline1 = line1.Replace(" ", "");
                    if (phoneRegex.IsMatch(strline1))
                    {
                        FormatPhone = phoneRegex.Replace(strline1, "$1-$2-$3");
                        if (strPhone.IndexOf(FormatPhone) == -1)
                        {
                            if (strPhone == "") strPhone = FormatPhone;
                            else strPhone = strPhone + ", " + FormatPhone;
                        }
                    }

                }
            }
            return strPhone.Trim();
        }
        public static void EmpRefsPaging(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {

            int startRef = (pageNo * 2) - 2;
            EmpRefData curEmpRef = new EmpRefData();
            var bCheckEmpRef = false;
            if (startRef >= app.EmpRefs.Count)
            {
                bCheckEmpRef = true;
            }
            else
            {
                curEmpRef = app.EmpRefs.ElementAt(startRef);
            }
            if (app.EmpRefs.Count == 0)
            {
                app.Company = "N/A";
                app.StreetAddress = "N/A";
                app.City = "N/A";
                app.State = "N/A";
                app.PostalCode = "N/A";
                app.Phone = "N/A";
                curEmpRef.Pos = "N/A";
                curEmpRef.Hired = "N/A";
                curEmpRef.Termination = "N/A";
                curEmpRef.FullTime = "N/A";
                curEmpRef.Salary = "N/A";
                curEmpRef.RH = "N/A";
                curEmpRef.SW = Environment.NewLine + Environment.NewLine + "No employment history obtained." + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "No further information available.";

                //TypeEmpRefs(wordDoc.MainDocumentPart, curEmpRef, app, 1, false);
            }
            //else
            //TypeEmpRefs(wordDoc.MainDocumentPart, curEmpRef, app, 1, bCheckEmpRef);

            EmpRefData curEmpRef1 = new EmpRefData();
            if (startRef + 1 >= app.EmpRefs.Count)
            {
                bCheckEmpRef = true;
            }
            else
            {
                curEmpRef1 = app.EmpRefs.ElementAt(startRef + 1);
            }

            //TypeEmpRefs(wordDoc.MainDocumentPart, curEmpRef, app, 2, bCheckEmpRef);
            int RowLenght = 38; // initative = 58
            int FirstPageRow = 9;
            int SecondPageRow = 9;

            string strSW = Helper.Utils.RtfToText(curEmpRef.SW == null ? "" : curEmpRef.SW) + Environment.NewLine + Environment.NewLine + Helper.Utils.RtfToText(curEmpRef.Comment == null ? "" : curEmpRef.Comment);
            string strSW1 = Helper.Utils.RtfToText(curEmpRef1.SW == null ? "" : curEmpRef1.SW) + Environment.NewLine + Environment.NewLine + Helper.Utils.RtfToText(curEmpRef1.Comment == null ? "" : curEmpRef1.Comment);
            int PageCount = WordMLService.PageCount(strSW, RowLenght, FirstPageRow, SecondPageRow);
            int PageCount1 = WordMLService.PageCount(strSW1, RowLenght, FirstPageRow, SecondPageRow);

            int RowLenghtOther = 13; // reduce row lenght initial value = 15
            bool bcheckOther = false;
            int PosCount = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef.Pos == null ? "" : curEmpRef.Pos), RowLenghtOther, 1, 1);
            int HiredCount = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef.Hired == null ? "" : curEmpRef.Hired), RowLenghtOther, 1, 1);
            int TermCount = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef.Termination == null ? "" : curEmpRef.Termination), RowLenghtOther, 1, 1);
            int StatusCount = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef.FullTime == null ? "" : curEmpRef.FullTime), RowLenghtOther, 1, 1);
            int SalaryCount = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef.Salary == null ? "" : curEmpRef.Salary), RowLenghtOther, 1, 1);
            int ReHireCount = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef.RH == null ? "" : curEmpRef.RH), RowLenghtOther, 1, 1);
            if (PosCount > 1 || HiredCount > 1 || TermCount > 1 || StatusCount > 1 || SalaryCount > 1 || ReHireCount > 1) bcheckOther = true;
            int PosCount1 = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef1.Pos == null ? "" : curEmpRef1.Pos), RowLenghtOther, 1, 1);
            int HiredCount1 = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef1.Hired == null ? "" : curEmpRef1.Hired), RowLenghtOther, 1, 1);
            int TermCount1 = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef1.Termination == null ? "" : curEmpRef1.Termination), RowLenghtOther, 1, 1);
            int StatusCount1 = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef1.FullTime == null ? "" : curEmpRef1.FullTime), RowLenghtOther, 1, 1);
            int SalaryCount1 = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef1.Salary == null ? "" : curEmpRef1.Salary), RowLenghtOther, 1, 1);
            int ReHireCount1 = WordMLService.PageCount(Helper.Utils.RtfToText(curEmpRef1.RH == null ? "" : curEmpRef1.RH), RowLenghtOther, 1, 1);
            if (PosCount1 > 1 || HiredCount1 > 1 || TermCount1 > 1 || StatusCount1 > 1 || SalaryCount1 > 1 || ReHireCount1 > 1) bcheckOther = true;

            if (PageCount < 2 && PageCount1 < 2 && bcheckOther == false)
            {
                if (startRef + 1 < app.EmpRefs.Count)
                    EmpRefsPage(sources, app, client, reportType, pageNo);
                else
                    TypeEmpRefPaging(sources, curEmpRef, app, reportType, 1, false);
            }
            else
            {
                TypeEmpRefPaging(sources, curEmpRef, app, reportType, 1, false);
                if (startRef + 1 < app.EmpRefs.Count)
                    TypeEmpRefPaging(sources, curEmpRef1, app, reportType, 1, false);
            }

        }

        private static void TypeEmpRefPaging(List<Source> sources, EmpRefData emprefs, AppData app, ReportTypeData reportType, int index, bool bCheckEmpRef)
        {
            int FirstPageHeight = 5000;
            int FirstPagePos = 100;
            int RowLenghtOther = 13;

            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.EmpRefsPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            string applicantName = Utils.GetApplicantName(app, reportType);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                    WordMLService.RemoveSdtContentCellByName(mainPart, "EmpRef_ApplicantName", applicantName);
                    WordMLService.RemoveTableSdtContentCellByName(mainPart, "EmpRefs_ComName_2");
                    WordMLService.RemoveTableSdtContentCellByName(mainPart, "EmpRefs_Label");

                    int PosCount = WordMLService.PageCount(Helper.Utils.RtfToText(emprefs.Pos == null ? "" : emprefs.Pos), RowLenghtOther, 1, 1);
                    int HiredCount = WordMLService.PageCount(Helper.Utils.RtfToText(emprefs.Hired == null ? "" : emprefs.Hired), RowLenghtOther, 1, 1);
                    int TermCount = WordMLService.PageCount(Helper.Utils.RtfToText(emprefs.Termination == null ? "" : emprefs.Termination), RowLenghtOther, 1, 1);
                    int StatusCount = WordMLService.PageCount(Helper.Utils.RtfToText(emprefs.FullTime == null ? "" : emprefs.FullTime), RowLenghtOther, 1, 1);
                    int SalaryCount = WordMLService.PageCount(Helper.Utils.RtfToText(emprefs.Salary == null ? "" : emprefs.Salary), RowLenghtOther, 1, 1);
                    int ReHireCount = WordMLService.PageCount(Helper.Utils.RtfToText(emprefs.RH == null ? "" : emprefs.RH), RowLenghtOther, 1, 1);
                    if (PosCount > 1) FirstPageHeight = FirstPageHeight - ((PosCount - 1) * 150);
                    if (HiredCount > 1) FirstPageHeight = FirstPageHeight - ((HiredCount - 1) * 150);
                    if (TermCount > 1) FirstPageHeight = FirstPageHeight - ((TermCount - 1) * 150);
                    if (StatusCount > 1) FirstPageHeight = FirstPageHeight - ((StatusCount - 1) * 150);
                    if (SalaryCount > 1) FirstPageHeight = FirstPageHeight - ((SalaryCount - 1) * 150);
                    if (ReHireCount > 1) FirstPageHeight = FirstPageHeight - ((ReHireCount - 1) * 150);
                    WordMLService.SetTablePositionYSdtContentCellByName(mainPart, string.Format("EmpRefs{0}_Paging", index), FirstPagePos, FirstPageHeight);
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs{0}_Paging", index), "");

                    if (bCheckEmpRef)
                    {
                        WordMLService.RemoveTableSdtContentCellByName(mainPart, string.Format("EmpRefs_ComName_{0}", index));
                        WordMLService.RemoveTableSdtContentCellByName(mainPart, "EmpRefs_Label");
                    }
                    else
                    {
                        string[] newLineArray = { Environment.NewLine, "\n" };
                        List<string> textArray = new List<string>();
                        if (emprefs.Info != null)
                            textArray = emprefs.Info.Split(newLineArray, StringSplitOptions.None).ToList();

                        string companyname = string.Empty;
                        string streetAddress = string.Empty;
                        string cityStateCode = string.Empty;
                        string phonenumber = string.Empty;
                        phonenumber = string.IsNullOrEmpty(emprefs.Info) ? string.Empty : FindPhoneNumber(emprefs.Info);
                        for (int i = 0; i < textArray.Count; i++)
                        {
                            if (string.IsNullOrEmpty(textArray[i]) || textArray[i].Trim() == phonenumber.Trim())
                                textArray[i] = string.Empty;
                        }

                        if (textArray.Count > 0)
                        {
                            companyname = textArray.Count() > 0 ? textArray[0] : string.Empty;
                            // replace address info of employer/reference
                            streetAddress = textArray.Count() > 1 ? textArray[1] : string.Empty; ;
                            cityStateCode = textArray.Count() > 2 ? textArray[2] : string.Empty; ;
                        }

                        if (index == 2) WordMLService.RemoveSdtContentCellByName(mainPart, "EmpRefs_Label", "");
                        WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_ComName_{0}", index), companyname);
                        //WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_ComAddress_{0}", index), app.StreetAddress);
                        //WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_ComCity_{0}", index), app.City + ", " + app.State + " " + app.PostalCode);
                        WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_ComAddress_{0}", index), streetAddress);
                        WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_ComCity_{0}", index), cityStateCode);
                        WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_ComPhone_{0}", index), phonenumber);
                        WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_Pos_{0}", index), emprefs.Pos);
                        WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_Hired_{0}", index), emprefs.Hired);
                        WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_Term_{0}", index), emprefs.Termination);
                        WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_Status_{0}", index), emprefs.FullTime);
                        WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_Salary_{0}", index), emprefs.Salary);
                        WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_ReHire_{0}", index), emprefs.RH);
                        string strSW = Helper.Utils.RtfToText(emprefs.SW == null ? "" : emprefs.SW) + Environment.NewLine + Environment.NewLine + Helper.Utils.RtfToText(emprefs.Comment == null ? "" : emprefs.Comment);
                        WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_SW_{0}", index), strSW);
                    }
                    wordDoc.Save();
                }
                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

        private static void TypeCreditInfoTotals_EmpFinalPage(MainDocumentPart mainPart, CreditInfoData creditInfo)
        {
            TypeCredInfo(mainPart, creditInfo);
            TypeCreditInfoTotals(mainPart, creditInfo);
        }

        // done
        public static void EmpFinalPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            int RowLenght = 80;
            int FirstPageRow = 12;
            int SecondPageRow = 33;
            int FirstPagePos = 1000;
            int SecondPagePos = 100;
            int FirstPageHeight = 8800;
            int SecondPageHeight = 7800;

            bool isCreditTotalSectionExist = true;
            bool isCreditInfoMatchedExist = true;
            bool isFinalCommentOnly = false;


            if (isFinalCommentOnly)
            {
                FirstPageRow = 33;
            }
            else
            {
                if (!isCreditTotalSectionExist && isCreditInfoMatchedExist)
                    FirstPageRow = 30;
                else if (!isCreditInfoMatchedExist && isCreditTotalSectionExist)
                    FirstPageRow = 16;
            }

            int PageCount = WordMLService.PageCount(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow);

            string strComment = "";

            for (int i = 1; i <= PageCount; i++)
            {
                string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.EmpFinalPage);
                if (isFinalCommentOnly)
                    templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.EmpFinalPageComment);

                byte[] byteArray = File.ReadAllBytes(templatePath);
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(byteArray, 0, (int)byteArray.Length);
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                    {
                        if (i < PageCount)
                        {
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "DueTo");
                            WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments_Label", "Final Comments: (Continued...)");
                        }
                        else
                        {
                            WordMLService.RemoveSdtRunByName(wordDoc.MainDocumentPart, "DueTo");
                            WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments_Label", "Final Comments:");
                        }
                        if (i == 1)
                        {
                            strComment = WordMLService.GetStringRowPerPage(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow, i);
                            TypeCreditInfoTotals_EmpFinalPage(wordDoc.MainDocumentPart, app.CreditInfo);
                            WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, true);
                        }
                        else
                        {
                            strComment = WordMLService.GetStringRowPerPage(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow, i);
                            WordMLService.RemoveTableSdtContentCellByName(wordDoc.MainDocumentPart, "CreditInfoTotals_PastDueAmounts");
                            WordMLService.RemoveTableSdtContentCellByName(wordDoc.MainDocumentPart, "CredInfo_CreditMatched_Yes");
                            WordMLService.SetTablePositionYSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments", SecondPagePos, SecondPageHeight);
                            WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, false);
                        }

                        WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, "FinalComments", strComment);
                        string applicantName = Utils.GetApplicantName(app, reportType);
                        WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalHeader_ApplicantName", applicantName);
                        wordDoc.Save();
                    }

                    sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
                }
            }
        }

        // done
        public static void EmpRefsPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.EmpRefsPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            string applicantName = Utils.GetApplicantName(app, reportType);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "EmpRef_ApplicantName", applicantName);
                    int startRef = (pageNo * 2) - 2;
                    EmpRefData curEmpRef = new EmpRefData();
                    var bCheckEmpRef = false;
                    if (startRef >= app.EmpRefs.Count)
                    {
                        bCheckEmpRef = true;
                    }
                    else
                    {
                        curEmpRef = app.EmpRefs.ElementAt(startRef);
                    }
                    if (app.EmpRefs.Count == 0)
                    {
                        app.Company = "N/A";
                        app.StreetAddress = "N/A";
                        app.City = "N/A";
                        app.State = "N/A";
                        app.PostalCode = "N/A";
                        app.Phone = "N/A";
                        curEmpRef.Pos = "N/A";
                        curEmpRef.Hired = "N/A";
                        curEmpRef.Termination = "N/A";
                        curEmpRef.FullTime = "N/A";
                        curEmpRef.Salary = "N/A";
                        curEmpRef.RH = "N/A";
                        curEmpRef.SW = Environment.NewLine + Environment.NewLine + "No employment history obtained." + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + "No further information available.";

                        TypeEmpRefs(wordDoc.MainDocumentPart, curEmpRef, app, 1, false);
                    }
                    else
                        TypeEmpRefs(wordDoc.MainDocumentPart, curEmpRef, app, 1, bCheckEmpRef);

                    if (startRef + 1 >= app.EmpRefs.Count)
                    {
                        bCheckEmpRef = true;
                    }
                    else
                    {
                        curEmpRef = app.EmpRefs.ElementAt(startRef + 1);
                    }

                    TypeEmpRefs(wordDoc.MainDocumentPart, curEmpRef, app, 2, bCheckEmpRef);
                    
                    wordDoc.Save();
                }

                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

        // done
        public static void EmpNameCrimPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.EmpNameCrimPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    string applicantName = Utils.GetApplicantName(app, reportType);
                    TypeResidentialHeader(wordDoc.MainDocumentPart, app, client, reportType, false, false);

                    AppInfo(wordDoc.MainDocumentPart, app, reportType);

                    TypeCharges(wordDoc.MainDocumentPart, app.Charges, 0);

                    TypeEvictions(wordDoc.MainDocumentPart, app.Evictions, 0);
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "EmpReport_ApplicantName", applicantName);
                    wordDoc.Save();
                }

                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

        // done 
        public static void DeclinationLetter(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            //AppendPage(wordApplication, WordDocumentType.DeclinationLetter);

            string declinationAppDetail = "";
            //Word.Document doc = wordApplication.ActiveDocument;
            //if (doc == null)
            //    return;

            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.DeclinationLetter);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    declinationAppDetail = Helper.Utils.GetApplicantName(app, reportType) + Environment.NewLine +
                        app.HouseNumber + " " + app.StreetAddress + Environment.NewLine +
                        app.City + ", " + app.State + " " + app.PostalCode;

                    string clientName = client != null ? client.ClientName : string.Empty;

                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;

                    WordMLService.RemoveTextStdElementByName(mainPart, "Declination_ClientName", clientName);
                    WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, "Declination_AppDetail", declinationAppDetail);
                    WordMLService.RemoveSdtContentCellByName(mainPart, "DeclinationLetter_Date", DateTime.Today.Date.ToShortDateString());

                    if (app.Recommendation != null)
                    {
                        if (app.Recommendation.RentalHistory)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_RentalHistory", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_RentalHistory", "");

                        if (app.Recommendation.CreditHistory)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_CreditHistory", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_CreditHistory", "");

                        if (app.Recommendation.RentToIncome)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_RentToIncome", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_RentToIncome", "");

                        if (app.Recommendation.FalseOrDiscrimminationInfo)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_FalseOrDiscrimminationInfo", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_FalseOrDiscrimminationInfo", "");

                        if (app.Recommendation.ShortTimeOnTheJob)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_ShortTimeOnTheJob", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_ShortTimeOnTheJob", "");

                        if (app.Recommendation.LackOfInformation)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_LackOfInformation", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_LackOfInformation", "");

                        if (app.Recommendation.CrimminalHistory)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_CrimminalHistory", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "Declination_CrimminalHistory", "");
                    }
                    
                    wordDoc.Save();
                }

                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }

        }

        public static void AdverseActionLetter(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            string appDetail = "";

            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.AdverseActionLetter);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    appDetail = Helper.Utils.GetApplicantName(app, reportType) + Environment.NewLine +
                        app.HouseNumber + " " + app.StreetAddress + Environment.NewLine +
                        app.City + ", " + app.State + " " + app.PostalCode;

                    string clientName = client != null ? client.ClientName : string.Empty;

                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;

                    WordMLService.RemoveTextStdElementByName(mainPart, "AdverseAction_ClientName", clientName);
                    WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, "AdverseAction_AppDetail", appDetail);
                    WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, "AdverseAction_AppCompletedDate", app.CompletedDate.ToString());

                    if (app.Recommendation != null)
                    {
                        if (app.Recommendation.RentalHistory)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_RentalHistory", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_RentalHistory", "");

                        if (app.Recommendation.CreditHistory)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_CreditHistory", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_CreditHistory", "");

                        if (app.Recommendation.RentToIncome)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_RentToIncome", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_RentToIncome", "");

                        if (app.Recommendation.FalseOrDiscrimminationInfo)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_FalseOrDiscrimminationInfo", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_FalseOrDiscrimminationInfo", "");

                        if (app.Recommendation.ShortTimeOnTheJob)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_ShortTimeOnTheJob", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_ShortTimeOnTheJob", "");

                        if (app.Recommendation.LackOfInformation)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_LackOfInformation", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_LackOfInformation", "");

                        if (app.Recommendation.CrimminalHistory)
                            WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_CrimminalHistory", "true");
                        else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "AdverseAction_CrimminalHistory", "");
                    }
                    WordMLService.RemoveSdtContentCellByName(mainPart, "AdvActionLetter_Date", DateTime.Today.Date.ToShortDateString());
                    wordDoc.Save();
                }
                
                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }

        }

        public static void FinalCommentsPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            int RowLenght = 80;
            int FirstPageRow = 30;
            int SecondPageRow = 33;
            int FirstPagePos = 1000;
            int SecondPagePos = 100;
            int FirstPageHeight = 8800;
            int SecondPageHeight = 9000;
            int PageCount = WordMLService.PageCount(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow);
            string applicantName = Utils.GetApplicantName(app, reportType);
            string strComment = "";
            for (int i = 1; i <= PageCount; i++)
            {
                string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.FinalCommentsPage);
                byte[] byteArray = File.ReadAllBytes(templatePath);
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(byteArray, 0, (int)byteArray.Length);
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                    {
                        if (i < PageCount)
                        {
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "DueTo");
                            WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments_Label", "Final Comments: (Continued...)");
                        }
                        else
                        {
                            WordMLService.RemoveSdtRunByName(wordDoc.MainDocumentPart, "DueTo");
                            WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments_Label", "Final Comments:");
                        }

                        strComment = WordMLService.GetStringRowPerPage(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow, i);
                        WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, "FinalComments", strComment);
                        WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, true);
                        WordMLService.SetTablePositionYSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments", SecondPagePos, SecondPageHeight);
                        WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalHeader_ApplicantName", applicantName);
                        wordDoc.Save();
                    }

                    sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
                }
            }
        }

        public static void ResFinalPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            int RowLenght = 80;
            int FirstPageRow = 9;
            int SecondPageRow = 33;
            int FirstPagePos = 1000;
            int SecondPagePos = 100;
            int FirstPageHeight = 8800;
            int SecondPageHeight = 9600;
            string applicantName = Utils.GetApplicantName(app, reportType);
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

            if (lbApproval && !lbBlankRec) FirstPageRow = 30;

            int PageCount = WordMLService.PageCount(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow);

            string strComment = "";

            for (int i = 1; i <= PageCount; i++)
            {
                string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ResFinalPage);
                byte[] byteArray = File.ReadAllBytes(templatePath);
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(byteArray, 0, (int)byteArray.Length);
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                    {
                        if (i < PageCount)
                        {
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "DueTo");
                            WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments_Label", "Final Comments: (Continued...)");
                        }
                        else
                        {
                            WordMLService.RemoveSdtRunByName(wordDoc.MainDocumentPart, "DueTo");
                            WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments_Label", "Final Comments:");
                        }

                        if (i == 1)
                        {
                            strComment = WordMLService.GetStringRowPerPage(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow, i);
                            bool bCriteria = false;
                            if (lbApproval && !lbBlankRec)
                            {
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_Yes", "true");
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_No", "");
                                bCriteria = true;
                                WordMLService.SetTablePositionYSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments", FirstPagePos, FirstPageHeight);

                                WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, false);
                            }
                            else if (!lbApproval && !lbBlankRec)
                            {
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_Yes", "");
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_No", "true");

                                WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, true);
                            }
                            else
                            {
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_Yes", "");
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_No", "");

                                WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, true);
                            }

                            if (lbApproval && !lbBlankRec)
                            {
                                if (string.IsNullOrEmpty(app.FinalComments))
                                {
                                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments", "Applicant Qualifies.");
                                }
                                else
                                {
                                    WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, "FinalComments", strComment);
                                }
                            }
                            else
                            {
                                WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, "FinalComments", strComment);
                            }
                            TypeRecommendation(wordDoc.MainDocumentPart, app.Recommendation, bCriteria);
                        }
                        else
                        {
                            strComment = WordMLService.GetStringRowPerPage(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow, i);

                            WordMLService.RemoveTableSdtContentCellByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_Yes");
                            WordMLService.SetTablePositionYSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments", SecondPagePos, SecondPageHeight);
                            WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, false);
                            WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, "FinalComments", strComment);
                            TypeRecommendation(wordDoc.MainDocumentPart, app.Recommendation, true);
                            
                        }

                        WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalHeader_ApplicantName", applicantName);
                        wordDoc.Save();
                    }

                    sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
                }
            }//end for PageCount
        }

        public static void ResFinalPageA(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            int RowLenght = 80;
            int FirstPageRow = 28;
            int SecondPageRow = 33;
            int FirstPagePos = 1000;
            int SecondPagePos = 100;
            int FirstPageHeight = 8800;
            int SecondPageHeight = 9000;
            string applicantName = Utils.GetApplicantName(app, reportType);
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

            if (lbApproval && !lbBlankRec) FirstPageRow = 30;

            int PageCount = WordMLService.PageCount(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow);

            string strComment = "";

            for (int i = 1; i <= PageCount; i++)
            {
                string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ResFinalPageA);
                byte[] byteArray = File.ReadAllBytes(templatePath);
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(byteArray, 0, (int)byteArray.Length);
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                    {
                        if (i < PageCount)
                        {
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "DueTo");
                            WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments_Label", "Final Comments: (Continued...)");
                        }
                        else
                        {
                            WordMLService.RemoveSdtRunByName(wordDoc.MainDocumentPart, "DueTo");
                            WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments_Label", "Final Comments:");
                        }

                        if (i == 1)
                        {
                            strComment = WordMLService.GetStringRowPerPage(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow, i);
                            bool bCriteria = false;
                            if (lbApproval && !lbBlankRec)
                            {
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_Yes", "true");
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_No", "");
                                WordMLService.SetTablePositionYSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments", FirstPagePos, FirstPageHeight);
                                WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, false);
                            }
                            else if (!lbApproval && !lbBlankRec)
                            {
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_Yes", "");
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_No", "true");

                                WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, true);
                            }
                            else
                            {
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_Yes", "");
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_No", "");

                                WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, true);
                            }

                            if (lbApproval && !lbBlankRec)
                            {
                                if (string.IsNullOrEmpty(app.FinalComments))
                                {
                                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments", "Applicant Qualifies.");
                                }
                                else
                                {
                                    WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, "FinalComments", strComment);
                                }
                            }
                            else
                            {
                                WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, "FinalComments", strComment);
                            }
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "rfinal_Label_1");
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "rfinal_Label_2");
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "rfinal_Label_3");
                        }
                        else
                        {
                            strComment = WordMLService.GetStringRowPerPage(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow, i);

                            WordMLService.RemoveTableSdtContentCellByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_Yes");
                            WordMLService.SetTablePositionYSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments", SecondPagePos, SecondPageHeight);
                            WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, false);
                            WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, "FinalComments", strComment);
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "rfinal_Label_1");
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "rfinal_Label_2");
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "rfinal_Label_3");
                        }

                        WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalHeader_ApplicantName", applicantName);
                        wordDoc.Save();
                    }

                    sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
                }
            }//end for PageCount
        }

        public static void CommFinalPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            int RowLenght = 80;
            int FirstPageRow = 30;
            int SecondPageRow = 57;
            int FirstPagePos = 1000;
            int SecondPagePos = 100;
            int FirstPageHeight = 8900;
            int SecondPageHeight = 9000;

            int PageCount = WordMLService.PageCount(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow);
            string applicantName = Utils.GetApplicantName(app, reportType);
            string strComment = "";
            for (int i = 1; i <= PageCount; i++)
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

                string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.CommFinalPage);
                byte[] byteArray = File.ReadAllBytes(templatePath);
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(byteArray, 0, (int)byteArray.Length);
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                    {
                        if (i < PageCount)
                        {
                            WordMLService.RemoveTableSdtRunByName(wordDoc.MainDocumentPart, "DueTo");
                            WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments_Label", "Final Comments: (Continued...)");
                        }
                        else
                        {
                            WordMLService.RemoveSdtRunByName(wordDoc.MainDocumentPart, "DueTo");
                            WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments_Label", "Final Comments:");
                        }

                        if (i == 1)
                        {
                            strComment = WordMLService.GetStringRowPerPage(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow, i);
                            int startRef = (pageNo * 2) - 2;
                            //string applicantName = Utils.GetApplicantName(app, reportType);
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
                            TypeResRentalRef(curRentalRef, wordDoc.MainDocumentPart, app, 1);

                            if (lbApproval && !lbBlankRec)
                            {
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_Yes", "true");
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_No", "");
                            }
                            else if (!lbApproval && !lbApproval)
                            {
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_Yes", "");
                                WordMLService.RemoveSdtContentCellYesNoByName(wordDoc.MainDocumentPart, "ResFinalPage_MeetRentalCriteria_No", "true");
                            }
                            WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, true);
                        }
                        else
                        {
                            strComment = WordMLService.GetStringRowPerPage(Helper.Utils.RtfToText(app.FinalComments), RowLenght, FirstPageRow, SecondPageRow, i);
                            WordMLService.RemoveTableSdtContentCellByName(wordDoc.MainDocumentPart, "ResRentalRef1_Current_Previous");
                            WordMLService.SetTablePositionYSdtContentCellByName(wordDoc.MainDocumentPart, "FinalComments", SecondPagePos, SecondPageHeight);
                            WordMLService.RemoveAllSdtBlock(wordDoc.MainDocumentPart, false);
                        }

                        WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, "FinalComments", strComment != null ? strComment : "");
                        WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "ComRentalRef1_ApplicantName", applicantName);
                        wordDoc.Save();

                    }

                    sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
                }
            }
        }

        // done
        public static void ResCredCrimPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ResCredCrimPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    string applicantName = Utils.GetApplicantName(app, reportType);

                    TypeCharges(wordDoc.MainDocumentPart, app.Charges, 0);

                    TypeEvictions(wordDoc.MainDocumentPart, app.Evictions, 0);

                    TypeCreditInfoTotals(wordDoc.MainDocumentPart, app.CreditInfo);

                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "ResCredCrimHeader_ApplicantName", applicantName);
                    wordDoc.Save();

                }

                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }


        }

        // done
        public static void CrimNameCrimPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.CrimNameCrimPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);

            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    string applicantName = Utils.GetApplicantName(app, reportType);
                    TypeResidentialHeader(wordDoc.MainDocumentPart, app, client, reportType, false, false);

                    AppInfo(wordDoc.MainDocumentPart, app, reportType);

                    // Delete the credit part in Criminal.docx file
                    WordMLService.RemoveTableSdtContentCellByName(wordDoc.MainDocumentPart, "CredInfo_CreditReportObtained_No");

                    TypeCreditInfoTotals(wordDoc.MainDocumentPart, app.CreditInfo);

                    TypeCharges(wordDoc.MainDocumentPart, app.Charges, 0);

                    TypeEvictions(wordDoc.MainDocumentPart, app.Evictions, 0);
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "CriminalReportHeader_ApplicantName", applicantName);
                    wordDoc.Save();
                }

                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }

        }

        // done
        public static void CreditOnlyPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.CreditOnlyPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    string applicantName = Utils.GetApplicantName(app, reportType);
                    TypeResidentialHeader(wordDoc.MainDocumentPart, app, client, reportType, false, false);

                    AppInfo(wordDoc.MainDocumentPart, app, reportType);

                    TypeCredInfo(wordDoc.MainDocumentPart, app.CreditInfo);

                    TypeCreditInfoTotals(wordDoc.MainDocumentPart, app.CreditInfo);
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "CreditInfo_ApplicantName", applicantName);
                    wordDoc.Save();
                }

                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

        public static void ResidentialNameEmpPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ResidentialNameEmpPage);

            byte[] byteArray = File.ReadAllBytes(templatePath);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    RevisionAccepter.AcceptRevisions(wordDoc);

                    TypeResidentialHeader(wordDoc.MainDocumentPart, app, client, reportType, false, false);

                    TypeCredInfo(wordDoc.MainDocumentPart, app.CreditInfo);

                    TypeEmpVersYesNo(wordDoc.MainDocumentPart, app, reportType);

                    wordDoc.MainDocumentPart.Document.Save();

                    wordDoc.Save();
                }
                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }

        }

        public static void CommNameBankPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.CommNameBankPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            string applicantName = Helper.Utils.GetApplicantName(app, reportType);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "CompReportHeader_ApplicantName", applicantName);
                    TypeResidentialHeader(wordDoc.MainDocumentPart, app, client, reportType, false, false);

                    AppInfo(wordDoc.MainDocumentPart, app, reportType);

                    BusinessInfo(wordDoc.MainDocumentPart, app);

                    BankInfo(wordDoc.MainDocumentPart, app);

                    wordDoc.Save();
                }

                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));

            }
        }

        private static void AppInfo(MainDocumentPart mainPart, AppData app, ReportTypeData reportType)
        {
            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_Name", Helper.Utils.GetApplicantName(app, reportType));

            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_BirthDate", app.BirthDate.HasValue ? app.BirthDate.Value.ToString("MM/dd/yy") : "");

            string strStreetAddress = app.HouseNumber + " " + app.StreetAddress + Environment.NewLine + app.City + ", " + app.State + ", " + app.PostalCode;
            WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, "Applicant_Address", Helper.Utils.RtfToText(strStreetAddress));

            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_SS", app.AppSSN);

            if (reportType.TypeName == "Cred1" || reportType.TypeName == "Cred2" || reportType.TypeName == "CredCrim")
            {
                WordMLService.RemoveRowSdtContentCellByName(mainPart, "Applicant_Pos");
            }
            else
            {
                if (String.IsNullOrEmpty(app.PositionApplied))
                {
                    WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_Pos", String.Empty);
                }
                else
                {
                    WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_Pos", app.PositionApplied);
                }
            }

            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_Phone", app.Phone);
        }

        private static void BusinessInfo(MainDocumentPart mainPart, AppData app)
        {
            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_StateActive", app.StateActive);

            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_DateActive", app.DateActive);

            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_RegAgent", app.RegAgent);

        }

        private static void BankInfo(MainDocumentPart mainPart, AppData app)
        {
            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_BankComm", app.BankComm);

            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_AcctComm", app.AcctComm);

            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_OpenedComm", app.OpenedComm);

            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_NSFODComm", app.NSFODComm);

            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_BalanceComm", app.BalanceComm);

            WordMLService.RemoveSdtContentCellByName(mainPart, "Applicant_SWComm", app.SWComm);
        }

        private static void TypeResidentialHeader(MainDocumentPart mainPart, AppData app, ClientData client, ReportTypeData reportType, bool skipSpecialField = true, bool skipMgmt = true)
        {
            WordMLService.RemoveSdtContentCellByName(mainPart, "ResidentialHeader_Client", !string.IsNullOrEmpty(app.ReportCommunity) ? app.ReportCommunity : app.ClientAppliedName);

            if (!skipMgmt)
            {
                WordMLService.RemoveSdtContentCellByName(mainPart, "ResidentialHeader_ReportManagement", app.ReportManagement);
            }

            string applicantName = Helper.Utils.GetApplicantName(app, reportType);
            WordMLService.RemoveSdtContentCellByName(mainPart, "ResidentialHeader_ApplicantName", applicantName);

            string receivedDate = app.ReceivedDate.HasValue ? app.ReceivedDate.Value.ToLocalTime().ToString("MM/dd/yy") : "";
            WordMLService.RemoveSdtContentCellByName(mainPart, "ResidentialHeader_ReceivedDate", receivedDate);

            WordMLService.RemoveSdtContentCellByName(mainPart, "ResidentialHeader_UnitNumber", app.UnitNumber);

            WordMLService.RemoveSdtContentCellByName(mainPart, "ResidentialHeader_RentAmount", app.RentAmount);

            WordMLService.RemoveSdtContentCellByName(mainPart, "ResidentialHeader_MoveInDate", app.MoveInDate);

            WordMLService.RemoveSdtContentCellByName(mainPart, "ResidentialHeader_Applicant", Utils.GetApplicantName(app, reportType));
            if (!skipSpecialField)
            {
                WordMLService.RemoveSdtContentCellByName(mainPart, "ResidentialHeader_ReportSpecialField", app.ReportSpecialField);
            }
        }

        // done
        private static void TypeCredInfo(MainDocumentPart mainPart, CreditInfoData creditInfo)
        {
            if (creditInfo == null)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditReportObtained_No", "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditReportObtained_Yes", "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditMatched_No", "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditMatched_Yes", "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditHistoryBankrupted_No", "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditHistoryBankrupted_Yes", "");
                return;
            }

            if (creditInfo.CreditReportObtained == false)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditReportObtained_No", "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditReportObtained_Yes", "");
                if (creditInfo.CreditMatched == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditMatched_Yes", "true");
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditMatched_No", "");
                }
                else
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditMatched_No", "");
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditMatched_Yes", "");
                }

                if (creditInfo.CreditHistoryBankrupted == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditHistoryBankrupted_Yes", "true");
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditHistoryBankrupted_No", "");
                }
                else
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditHistoryBankrupted_Yes", "");
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditHistoryBankrupted_No", "");
                }
                return;
            }

            if (creditInfo.CreditReportObtained == true)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditReportObtained_No", "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditReportObtained_Yes", "true");

                if (creditInfo.CreditMatched == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditMatched_Yes", "true");
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditMatched_No", "");
                }
                else
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditMatched_Yes", "");
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditMatched_No", "true");
                }

                if (creditInfo.CreditHistoryBankrupted == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditHistoryBankrupted_Yes", "true");
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditHistoryBankrupted_No", "");
                }
                else
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditHistoryBankrupted_Yes", "");
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "CredInfo_CreditHistoryBankrupted_No", "true");
                }
                return;
            }
        }

        // done
        private static void TypeCreditInfoTotals(MainDocumentPart mainPart, CreditInfoData creditInfo)
        {
            if (creditInfo == null)
            {
                WordMLService.RemoveTableSdtContentCellByName(mainPart, "CreditInfoTotals_PastDueAmounts");
                WordMLService.RemoveTableSdtContentCellByName(mainPart, "CredInfo_CreditMatched_Yes");
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Label", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_PastDueAmounts", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Rent", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Collections", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Liens", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Judgements", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_ChildSupport", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_BankruptcyDate", string.Empty);
                return;
            }

            if (creditInfo.PastDueAmounts == 0 && creditInfo.Rent == 0 && creditInfo.Collections == 0 && creditInfo.Liens == 0 && creditInfo.Judgements == 0 && creditInfo.ChildSupport == 0 && string.IsNullOrEmpty(creditInfo.Dates))
            {
                //WordMLService.RemoveTableSdtContentCellByName(mainPart, "CreditInfoTotals_PastDueAmounts");
                //WordMLService.RemoveTableSdtContentCellByName(mainPart, "CreditInfoTotals_Label");
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Label", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_PastDueAmounts", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Rent", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Collections", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Liens", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Judgements", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_ChildSupport", string.Empty);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_BankruptcyDate", string.Empty);
            }
            else
            {
                // refactor if need
                decimal total = 0m;
                total = creditInfo.PastDueAmounts + creditInfo.Rent + creditInfo.Collections + creditInfo.Liens + creditInfo.Judgements + creditInfo.ChildSupport;
                //Word.Document doc = wordApplication.ActiveDocument;

                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Label", "");
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_PastDueAmounts", creditInfo.PastDueAmounts.ToString());
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Rent", creditInfo.Rent.ToString());
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Collections", creditInfo.Collections.ToString());
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Liens", creditInfo.Liens.ToString());
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Judgements", creditInfo.Judgements.ToString());
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_ChildSupport", creditInfo.ChildSupport.ToString());
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_BankruptcyDate", creditInfo.Dates);

                if (!string.IsNullOrEmpty(creditInfo.Dates))
                {
                    WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_PositiveCreditSince", creditInfo.PositiveCreditSince ? "Yes" : "No");
                }

                string totalText = String.Format("{0:#,###,###,##0.00}", total);
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "CreditInfoTotals_Total", "$" + totalText);
            }
        }

        private static void TypeEmpVersYesNo(MainDocumentPart mainPart, AppData app, ReportTypeData reportType)
        {

            int numCharPerLine = 38;
            EmpVerData empVers = app.EmpVer;
            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_Heading", string.IsNullOrEmpty(empVers.Heading) ? "Applicant" : empVers.Heading);
            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_Pos", empVers.Pos);
            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_Hire", empVers.Hire);
            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_Salary", empVers.Salary);
            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_FullTime", empVers.FullTime);

            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_Heading2", string.IsNullOrEmpty(empVers.Heading2) ? "Applicant" : empVers.Heading2);
            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_Pos2", empVers.Pos2);
            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_Hire2", empVers.Hire2);
            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_Salary2", empVers.Salary2);
            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_FullTime2", empVers.FullTime2);



            #region empver 1

            string sw = empVers.SW;
            string co = empVers.Co;
            string tele = empVers.Tele;
            if (!string.IsNullOrEmpty(empVers.Tele))
            {
                sw = !string.IsNullOrEmpty(empVers.SW) ? "S/W: " + empVers.SW : string.Empty;
                co = !string.IsNullOrEmpty(empVers.Co) ? "@    " + empVers.Co : string.Empty;
            }
            List<string> linesOfSW = Utils.Wrap(Helper.Utils.RtfToText(sw), numCharPerLine).ToList();
            List<string> linesOfCo = Utils.Wrap(co, numCharPerLine).ToList();
            List<string> linesOfTele = Utils.Wrap(tele, numCharPerLine).ToList();
            if (linesOfSW.Count == 1 && linesOfSW[0] == string.Empty)
                linesOfSW = new List<string>();
            if (linesOfCo.Count == 1 && linesOfCo[0] == string.Empty)
                linesOfCo = new List<string>();
            if (linesOfTele.Count == 1 && linesOfTele[0] == string.Empty)
                linesOfTele = new List<string>();
            List<string> linesOfCol1 = new List<string>();
            linesOfCol1.AddRange(linesOfSW);
            linesOfCol1.AddRange(linesOfCo);
            linesOfCol1.AddRange(linesOfTele);
            #endregion;

            #region empver 2
            string sw2 = empVers.SW2;
            string co2 = empVers.Co2;
            string tele2 = empVers.Tele2;
            if (!string.IsNullOrEmpty(empVers.Tele2))
            {
                sw2 = !string.IsNullOrEmpty(empVers.SW2) ? "S/W: " + empVers.SW2 : string.Empty;
                co2 = !string.IsNullOrEmpty(empVers.Co2) ? "@    " + empVers.Co2 : string.Empty;
            }
            List<string> linesOfSW2 = Utils.Wrap(Helper.Utils.RtfToText(sw2), numCharPerLine).ToList();
            List<string> linesOfCo2 = Utils.Wrap(co2, numCharPerLine).ToList();
            List<string> linesOfTele2 = Utils.Wrap(tele2, numCharPerLine).ToList();
            if (linesOfSW2.Count == 1 && linesOfSW2[0] == string.Empty)
                linesOfSW2 = new List<string>();
            if (linesOfCo2.Count == 1 && linesOfCo2[0] == string.Empty)
                linesOfCo2 = new List<string>();
            if (linesOfTele2.Count == 1 && linesOfTele2[0] == string.Empty)
                linesOfTele2 = new List<string>();
            List<string> linesOfCol2 = new List<string>();
            linesOfCol2.AddRange(linesOfSW2);
            linesOfCol2.AddRange(linesOfCo2);
            linesOfCol2.AddRange(linesOfTele2);
            #endregion;

            int maxline = Math.Max(linesOfCol1.Count, linesOfCol2.Count);
            while (maxline > linesOfCol1.Count)
            {
                linesOfCol1.Add(string.Empty);
            }
            while (maxline > linesOfCol2.Count)
            {
                linesOfCol2.Add(string.Empty);
            }

            DocumentFormat.OpenXml.Wordprocessing.TableRow rowRef = WordMLService.GetRowSdtContentCellByName(mainPart, "EmpVersYesNo_MiscComment") as DocumentFormat.OpenXml.Wordprocessing.TableRow;
            DocumentFormat.OpenXml.Wordprocessing.Table table = rowRef != null ? rowRef.Parent as DocumentFormat.OpenXml.Wordprocessing.Table : null;
            if (rowRef == null || table == null)
                return;

            for (int i = 0; i < maxline; i++)
            {
                DocumentFormat.OpenXml.Wordprocessing.TableRow rowToClone = WordMLService.GetRowSdtContentCellByName(mainPart, "EmpVersYesNo_Col1") as DocumentFormat.OpenXml.Wordprocessing.TableRow;
                DocumentFormat.OpenXml.Wordprocessing.TableRow newRow = ((OpenXmlElement)rowToClone).CloneNode(true) as DocumentFormat.OpenXml.Wordprocessing.TableRow;
                WordMLService.RemoveSdtContentCellByName(newRow, "EmpVersYesNo_Col1", linesOfCol1[i]);
                WordMLService.RemoveSdtContentCellByName(newRow, "EmpVersYesNo_Col2", linesOfCol2[i]);
                table.InsertBefore(newRow, rowRef);
            }

            WordMLService.RemoveRowSdtContentCellByName(mainPart, "EmpVersYesNo_Col1");
            WordMLService.RemoveSdtContentCellByName(mainPart, "EmpVersYesNo_MiscComment", empVers.MiscComment);
        }

        // done
        public static void ResRentalRefs(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ResRentalRefs);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            string applicantName = Helper.Utils.GetApplicantName(app, reportType);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "ResRentalRef1_ApplicantName", applicantName);
                    int startRef = (pageNo * 2) - 2;                    
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
                    TypeResRentalRef(curRentalRef, wordDoc.MainDocumentPart, app, 1);
                    
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
                    TypeResRentalRef(curRentalRef, wordDoc.MainDocumentPart, app, 2);
                    
                    wordDoc.Save();
                }
                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

        //ResRentalRefs Paging 
        public static void ResRentalRefsPaging(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            int startRef = (pageNo * 2) - 2;

            string applicantName = Helper.Utils.GetApplicantName(app, reportType);

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
            //TypeResRentalRef(curRentalRef, wordDoc.MainDocumentPart, app, 1);

            RentalRefData curRentalRef1;
            if (startRef + 1 >= app.RentalRefs.Count)
            {
                curRentalRef1 = new RentalRefData();
                curRentalRef1.MoveIn = "N/A";
                curRentalRef1.MoveOut = "N/A";
                if (startRef == 0)
                {
                    curRentalRef1.Comment = Environment.NewLine + Environment.NewLine + "No rental history obtained." + Utils.StringText(Environment.NewLine, 6, "") + "No further information available.";
                }
                else
                {
                    curRentalRef1.Comment = Environment.NewLine + Environment.NewLine + "No further rental history obtained." + Utils.StringText(Environment.NewLine, 6, "") + "No further information available.";
                }
            }
            else
            {
                curRentalRef1 = app.RentalRefs.ElementAt(startRef + 1);
            }
            //TypeResRentalRef(curRentalRef1, wordDoc.MainDocumentPart, app, 2);
            int RowLenght = 50;
            int FirstPageRow = 12;
            int SecondPageRow = 12;
            int PageCount = WordMLService.PageCount(Helper.Utils.RtfToText(curRentalRef.Comment), RowLenght, FirstPageRow, SecondPageRow);
            int PageCount1 = WordMLService.PageCount(Helper.Utils.RtfToText(curRentalRef1.Comment), RowLenght, FirstPageRow, SecondPageRow);
            if (PageCount < 2 && PageCount1 < 2)
            {
                if (startRef + 1 < app.RentalRefs.Count)
                    ResRentalRefs(sources, app, client, reportType, pageNo);
                else
                    TypeResRentalRefPaging(sources, curRentalRef, app, reportType, 1);
            }
            else
            {
                TypeResRentalRefPaging(sources, curRentalRef, app, reportType, 1);
                if (startRef + 1 < app.RentalRefs.Count)
                    TypeResRentalRefPaging(sources, curRentalRef1, app, reportType, 1);
            }
        }

        private static void TypeResRentalRefPaging(List<Source> sources, RentalRefData curRentalRef, AppData app, ReportTypeData reportType, int index)
        {
            int FirstPageHeight = 5000;
            int FirstPagePos = 100;
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ResRentalRefs);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            string applicantName = Utils.GetApplicantName(app, reportType);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                    WordMLService.RemoveSdtContentCellByName(mainPart, "ResRentalRef1_ApplicantName", applicantName);
                    WordMLService.RemoveTableSdtContentCellByName(mainPart, "ResRentalRef2_Current_Previous");
                    WordMLService.SetTablePositionYSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_Paging", index), FirstPagePos, FirstPageHeight);
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_Paging", index), "");
                    bool isCurrent = false;
                    if (!app.ReceivedDate.HasValue)
                    {
                        isCurrent = false;
                    }
                    else
                    {
                        DateTime received = app.ReceivedDate.Value;
                        if (curRentalRef.MoveOut.ToLower().Contains("curr") ||
                        Helper.Utils.IsFutureDate(curRentalRef.MoveOut, received))
                        {
                            isCurrent = true;
                        }
                    }
                    if (isCurrent)
                    {
                        WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_Current_Previous", index), "CURRENT");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_Current_Previous", index), "PREVIOUS");
                    }

                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_MoveIn", index), curRentalRef.MoveIn);
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_MoveOut", index), curRentalRef.MoveOut);
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_Amount", index), curRentalRef.Amount);

                    if (curRentalRef.Written == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_No", index), "");
                    }
                    else if (curRentalRef.Written == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_No", index), "");
                    }
                    if (curRentalRef.KickedOut == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_No", index), "");
                    }
                    else if (curRentalRef.KickedOut == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_No", index), "");
                    }
                    if (curRentalRef.PrprNotice == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_No", index), "");
                    }
                    else if (curRentalRef.PrprNotice == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_No", index), "");
                    }
                    if (curRentalRef.LateNSF == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_No", index), "");
                    }
                    else if (curRentalRef.LateNSF == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_No", index), "");
                    }
                    if (curRentalRef.Complaints == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_No", index), "");
                    }
                    else if (curRentalRef.Complaints == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_No", index), "");
                    }
                    if (curRentalRef.Damages == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_No", index), "");
                    }
                    else if (curRentalRef.Damages == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_No", index), "");
                    }
                    if (curRentalRef.Owing == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_No", index), "");
                    }
                    else if (curRentalRef.Owing == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_No", index), "");
                    }
                    if (curRentalRef.Roommates == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_No", index), "");
                    }
                    else if (curRentalRef.Roommates == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_No", index), "");
                    }
                    if (curRentalRef.AddressMatch == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_No", index), "");
                    }
                    else if (curRentalRef.AddressMatch == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_No", index), "");
                    }
                    if (curRentalRef.Pets == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_No", index), "");
                    }
                    else if (curRentalRef.Pets == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_No", index), "");
                    }
                    if (curRentalRef.RltveFrnd == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_No", index), "");
                    }
                    else if (curRentalRef.RltveFrnd == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_No", index), "");
                    }
                    if (curRentalRef.ReRent == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_No", index), "");
                    }
                    else if (curRentalRef.ReRent == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_No", index), "");
                    }
                    if (curRentalRef.BedBugs == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_No", index), "");
                    }
                    else if (curRentalRef.BedBugs == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_No", index), "");
                    }
                    if (string.IsNullOrEmpty(curRentalRef.SW))
                    {
                        WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("ResRentalRef{0}_Comment", index), Utils.RtfToText(curRentalRef.Comment));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(curRentalRef.Comp))
                        {
                            curRentalRef.Comp = curRentalRef.Phone;
                            curRentalRef.Phone = "";
                        }
                        string comment = string.Empty;
                        if (!string.IsNullOrEmpty(curRentalRef.SW))
                            comment += "SW: " + curRentalRef.SW + Environment.NewLine;
                        if (!string.IsNullOrEmpty(curRentalRef.Comp))
                            comment += "@    " + curRentalRef.Comp + Environment.NewLine;
                        comment += curRentalRef.Phone + Environment.NewLine + Environment.NewLine;
                        comment += Helper.Utils.RtfToText(curRentalRef.Comment);

                        WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("ResRentalRef{0}_Comment", index), Utils.RtfToText(comment));
                    }

                    wordDoc.Save();
                }
                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

        // done
        public static void CommRentalRefs(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.CommRentalRefs);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    int startRef = (pageNo * 2) - 1;

                    string applicantName = Helper.Utils.GetApplicantName(app, reportType);
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "ComRentalRef_ApplicantName", applicantName);
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
                    TypeCommRentalRef(curRentalRef, wordDoc.MainDocumentPart, app, 1);


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
                    TypeCommRentalRef(curRentalRef, wordDoc.MainDocumentPart, app, 2);

                    wordDoc.Save();
                }
                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

        // done
        private static void 
            TypeCommRentalRef(RentalRefData curRentalRef, MainDocumentPart mainPart, AppData app, int index)
        {
            bool isCurrent = false;
            if (!app.ReceivedDate.HasValue)
            {
                isCurrent = false;
            }
            else
            {
                DateTime received = app.ReceivedDate.Value;
                if (curRentalRef.MoveOut.ToLower().Contains("curr") ||
                Helper.Utils.IsFutureDate(curRentalRef.MoveOut, received))
                {
                    isCurrent = true;
                }
            }
            if (isCurrent)
            {
                WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_Current_Previous", index), "CURRENT");
            }
            else
            {
                WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_Current_Previous", index), "PREVIOUS");
            }

            WordMLService.RemoveRowSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_Paging", index));
            WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_MoveIn", index), curRentalRef.MoveIn);
            WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_MoveOut", index), curRentalRef.MoveOut);
            WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_Amount", index), curRentalRef.Amount);

            if (curRentalRef.Written == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_No", index), "");
            }
            else if (curRentalRef.Written == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_No", index), "");
            }
            if (curRentalRef.KickedOut == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_No", index), "");
            }
            else if (curRentalRef.KickedOut == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_No", index), "");
            }
            if (curRentalRef.PrprNotice == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_No", index), "");
            }
            else if (curRentalRef.PrprNotice == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_No", index), "");
            }
            if (curRentalRef.LateNSF == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_No", index), "");
            }
            else if (curRentalRef.LateNSF == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_No", index), "");
            }
            if (curRentalRef.Complaints == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_No", index), "");
            }
            else if (curRentalRef.Complaints == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_No", index), "");
            }
            if (curRentalRef.Damages == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_No", index), "");
            }
            else if (curRentalRef.Damages == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_No", index), "");
            }
            if (curRentalRef.Owing == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_No", index), "");
            }
            else if (curRentalRef.Owing == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_No", index), "");
            }
            if (curRentalRef.RltveFrnd == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_No", index), "");
            }
            else if (curRentalRef.RltveFrnd == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_No", index), "");
            }
            if (curRentalRef.ReRent == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_No", index), "");
            }
            else if (curRentalRef.ReRent == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_No", index), "");
            }
            if (curRentalRef.BedBugs == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_No", index), "");
            }
            else if (curRentalRef.BedBugs == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_No", index), "");
            }
            if (string.IsNullOrEmpty(curRentalRef.SW))
            {
                WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("CommRentalRef{0}_Comment", index), Utils.RtfToText(curRentalRef.Comment));
            }
            else
            {
                if (string.IsNullOrEmpty(curRentalRef.Comp))
                {
                    curRentalRef.Comp = curRentalRef.Phone;
                    curRentalRef.Phone = "";
                }

                string comment = string.Empty;
                if (!string.IsNullOrEmpty(curRentalRef.SW))
                    comment += "SW: " + curRentalRef.SW + Environment.NewLine;
                if (!string.IsNullOrEmpty(curRentalRef.Comp))
                    comment += "@    " + curRentalRef.Comp + Environment.NewLine;
                comment += curRentalRef.Phone + Environment.NewLine + Environment.NewLine;
                comment += Helper.Utils.RtfToText(curRentalRef.Comment);

                WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("CommRentalRef{0}_Comment", index), Utils.RtfToText(comment));
            }
        }

        public static void CommRentalRefsPaging(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {

            int startRef = (pageNo * 2) - 1;

            string applicantName = Helper.Utils.GetApplicantName(app, reportType);

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
            //TypeCommRentalRef(curRentalRef, wordDoc.MainDocumentPart, app, 1);

            RentalRefData curRentalRef1;
            if (startRef + 1 >= app.RentalRefs.Count)
            {
                curRentalRef1 = new RentalRefData();
                curRentalRef1.MoveIn = "N/A";
                curRentalRef1.MoveOut = "N/A";
                if (startRef == 0)
                {
                    curRentalRef1.Comment = Environment.NewLine + Environment.NewLine + "No rental history obtained." + Utils.StringText(Environment.NewLine, 6, "") + "No further information available.";
                }
                else
                {
                    curRentalRef1.Comment = Environment.NewLine + Environment.NewLine + "No further rental history obtained." + Utils.StringText(Environment.NewLine, 6, "") + "No further information available.";
                }
            }
            else
            {
                curRentalRef1 = app.RentalRefs.ElementAt(startRef + 1);
            }
            //TypeCommRentalRef(curRentalRef, wordDoc.MainDocumentPart, app, 2);
            int RowLenght = 50;
            int FirstPageRow = 12;
            int SecondPageRow = 12;
            int PageCount = WordMLService.PageCount(Helper.Utils.RtfToText(curRentalRef.Comment), RowLenght, FirstPageRow, SecondPageRow);
            int PageCount1 = WordMLService.PageCount(Helper.Utils.RtfToText(curRentalRef1.Comment), RowLenght, FirstPageRow, SecondPageRow);
            if (PageCount < 2 && PageCount1 < 2)
            {
                if (startRef + 1 < app.RentalRefs.Count)
                    CommRentalRefs(sources, app, client, reportType, pageNo);
                else
                    TypeCommRentalRefPaging(sources, curRentalRef, reportType, app, 1);
            }
            else
            {
                TypeCommRentalRefPaging(sources, curRentalRef, reportType, app, 1);
                if (startRef + 1 < app.RentalRefs.Count)
                    TypeCommRentalRefPaging(sources, curRentalRef1, reportType, app, 1);
            }

        }

        private static void TypeCommRentalRefPaging(List<Source> sources, RentalRefData curRentalRef, ReportTypeData reportType, AppData app, int index)
        {
            int FirstPageHeight = 6000;
            int FirstPagePos = 100;
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.CommRentalRefs);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    string applicantName = Helper.Utils.GetApplicantName(app, reportType);
                    MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                    WordMLService.RemoveSdtContentCellByName(mainPart, "ComRentalRef_ApplicantName", applicantName);
                    WordMLService.RemoveTableSdtContentCellByName(mainPart, "CommRentalRef2_Current_Previous");
                    WordMLService.SetTablePositionYSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_Paging", index), FirstPagePos, FirstPageHeight);
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_Paging", index), "");

                    bool isCurrent = false;
                    if (!app.ReceivedDate.HasValue)
                    {
                        isCurrent = false;
                    }
                    else
                    {
                        DateTime received = app.ReceivedDate.Value;
                        if (curRentalRef.MoveOut.ToLower().Contains("curr") ||
                        Helper.Utils.IsFutureDate(curRentalRef.MoveOut, received))
                        {
                            isCurrent = true;
                        }
                    }
                    if (isCurrent)
                    {
                        WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_Current_Previous", index), "CURRENT");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_Current_Previous", index), "PREVIOUS");
                    }

                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_MoveIn", index), curRentalRef.MoveIn);
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_MoveOut", index), curRentalRef.MoveOut);
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("CommRentalRef{0}_Amount", index), curRentalRef.Amount);

                    if (curRentalRef.Written == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_No", index), "");
                    }
                    else if (curRentalRef.Written == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Written_No", index), "");
                    }
                    if (curRentalRef.KickedOut == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_No", index), "");
                    }
                    else if (curRentalRef.KickedOut == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_KickedOut_No", index), "");
                    }
                    if (curRentalRef.PrprNotice == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_No", index), "");
                    }
                    else if (curRentalRef.PrprNotice == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_PrprNotice_No", index), "");
                    }
                    if (curRentalRef.LateNSF == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_No", index), "");
                    }
                    else if (curRentalRef.LateNSF == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_LateNSF_No", index), "");
                    }
                    if (curRentalRef.Complaints == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_No", index), "");
                    }
                    else if (curRentalRef.Complaints == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Complaints_No", index), "");
                    }
                    if (curRentalRef.Damages == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_No", index), "");
                    }
                    else if (curRentalRef.Damages == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Damages_No", index), "");
                    }
                    if (curRentalRef.Owing == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_No", index), "");
                    }
                    else if (curRentalRef.Owing == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_Owing_No", index), "");
                    }
                    if (curRentalRef.RltveFrnd == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_No", index), "");
                    }
                    else if (curRentalRef.RltveFrnd == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_RltveFrnd_No", index), "");
                    }
                    if (curRentalRef.ReRent == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_No", index), "");
                    }
                    else if (curRentalRef.ReRent == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_ReRent_No", index), "");
                    }
                    if (curRentalRef.BedBugs == RentalRefFactInfoData.Yes)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_Yes", index), "true");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_No", index), "");
                    }
                    else if (curRentalRef.BedBugs == RentalRefFactInfoData.No)
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_No", index), "true");
                    }
                    else
                    {
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_Yes", index), "");
                        WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("CommRentalRef{0}_BedBugs_No", index), "");
                    }
                    if (string.IsNullOrEmpty(curRentalRef.SW))
                    {
                        WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("CommRentalRef{0}_Comment", index), Utils.RtfToText(curRentalRef.Comment));
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(curRentalRef.Comp))
                        {
                            curRentalRef.Comp = curRentalRef.Phone;
                            curRentalRef.Phone = "";
                        }

                        string comment = string.Empty;
                        if (!string.IsNullOrEmpty(curRentalRef.SW))
                            comment += "SW: " + curRentalRef.SW + Environment.NewLine;
                        if (!string.IsNullOrEmpty(curRentalRef.Comp))
                            comment += "@    " + curRentalRef.Comp + Environment.NewLine;
                        comment += curRentalRef.Phone + Environment.NewLine + Environment.NewLine;
                        comment += Helper.Utils.RtfToText(curRentalRef.Comment);
                        WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("CommRentalRef{0}_Comment", index), Utils.RtfToText(comment));
                    }
                    wordDoc.Save();
                }
                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

        // done
        private static void TypeResRentalRef(RentalRefData curRentalRef, MainDocumentPart mainPart, AppData app, int index)
        {
            bool isCurrent = false;
            if (!app.ReceivedDate.HasValue)
            {
                isCurrent = false;
            }
            else
            {
                DateTime received = app.ReceivedDate.Value;
                if (curRentalRef.MoveOut.ToLower().Contains("curr") ||
                Helper.Utils.IsFutureDate(curRentalRef.MoveOut, received))
                {
                    isCurrent = true;
                }
            }
            if (isCurrent)
            {
                WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_Current_Previous", index), "CURRENT");
            }
            else
            {
                WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_Current_Previous", index), "PREVIOUS");
            }

            WordMLService.RemoveRowSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_Paging", index));
            WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_MoveIn", index), curRentalRef.MoveIn);
            WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_MoveOut", index), curRentalRef.MoveOut);
            WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("ResRentalRef{0}_Amount", index), curRentalRef.Amount);

            if (curRentalRef.Written == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_No", index), "");
            }
            else if (curRentalRef.Written == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Written_No", index), "");
            }
            if (curRentalRef.KickedOut == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_No", index), "");
            }
            else if (curRentalRef.KickedOut == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_KickedOut_No", index), "");
            }
            if (curRentalRef.PrprNotice == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_No", index), "");
            }
            else if (curRentalRef.PrprNotice == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_PrprNotice_No", index), "");
            }
            if (curRentalRef.LateNSF == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_No", index), "");
            }
            else if (curRentalRef.LateNSF == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_LateNSF_No", index), "");
            }
            if (curRentalRef.Complaints == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_No", index), "");
            }
            else if (curRentalRef.Complaints == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Complaints_No", index), "");
            }
            if (curRentalRef.Damages == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_No", index), "");
            }
            else if (curRentalRef.Damages == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Damages_No", index), "");
            }
            if (curRentalRef.Owing == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_No", index), "");
            }
            else if (curRentalRef.Owing == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Owing_No", index), "");
            }
            if (curRentalRef.Roommates == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_No", index), "");
            }
            else if (curRentalRef.Roommates == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Roommates_No", index), "");
            }
            if (curRentalRef.AddressMatch == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_No", index), "");
            }
            else if (curRentalRef.AddressMatch == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_AddressMatch_No", index), "");
            }
            if (curRentalRef.Pets == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_No", index), "");
            }
            else if (curRentalRef.Pets == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_Pets_No", index), "");
            }
            if (curRentalRef.RltveFrnd == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_No", index), "");
            }
            else if (curRentalRef.RltveFrnd == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_RltveFrnd_No", index), "");
            }
            if (curRentalRef.ReRent == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_No", index), "");
            }
            else if (curRentalRef.ReRent == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_ReRent_No", index), "");
            }
            if (curRentalRef.BedBugs == RentalRefFactInfoData.Yes)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_Yes", index), "true");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_No", index), "");
            }
            else if (curRentalRef.BedBugs == RentalRefFactInfoData.No)
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_No", index), "true");
            }
            else
            {
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_Yes", index), "");
                WordMLService.RemoveSdtContentCellYesNoByName(mainPart, string.Format("ResRentalRef{0}_BedBugs_No", index), "");
            }
            if (string.IsNullOrEmpty(curRentalRef.SW))
            {
                WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("ResRentalRef{0}_Comment", index), Utils.RtfToText(curRentalRef.Comment));
            }
            else
            {
                if (string.IsNullOrEmpty(curRentalRef.Comp))
                {
                    curRentalRef.Comp = curRentalRef.Phone;
                    curRentalRef.Phone = "";
                }

                string comment = string.Empty;
                if (!string.IsNullOrEmpty(curRentalRef.SW))
                    comment += "SW: " + curRentalRef.SW + Environment.NewLine;
                if (!string.IsNullOrEmpty(curRentalRef.Comp))
                    comment += "@    " + curRentalRef.Comp + Environment.NewLine;
                comment += curRentalRef.Phone + Environment.NewLine + Environment.NewLine;
                comment += Helper.Utils.RtfToText(curRentalRef.Comment);
                WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("ResRentalRef{0}_Comment", index), Utils.RtfToText(comment));
            }
        }

        public static void ResXCriminalPages(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            string Total = "8";
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ResXCriminalPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            string applicantName = Helper.Utils.GetApplicantName(app, reportType);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    Total = WordMLService.GetTextSdtContentCellByName(wordDoc.MainDocumentPart, "XCriminal_Total");
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "XCriminalHeader_ApplicantName", applicantName);
                }
            }
            if (Total == "") Total = "8";
            int PageCount = 1;
            if (app.Charges.Count - 2 > Convert.ToInt32(Total))
                PageCount = ((app.Charges.Count - 2) / Convert.ToInt32(Total)) + ((app.Charges.Count - 2) % Convert.ToInt32(Total) > 0 ? 1 : 0);
            for (int i = 1; i <= PageCount; i++)
            {
                ResXCriminalPage(sources, app, client, reportType, i);
            }

        }

        // done
        public static void ResXCriminalPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ResXCriminalPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            string applicantName = Helper.Utils.GetApplicantName(app, reportType);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    string Total = WordMLService.GetTextSdtContentCellByName(wordDoc.MainDocumentPart, "XCriminal_Total");
                    if (Total == "") Total = "8";
                    int startIndex = ((pageNo - 1) * Convert.ToInt32(Total)) + 2;
                    int numToGet = app.Charges.Count - startIndex > Convert.ToInt32(Total) ? Convert.ToInt32(Total) : app.Charges.Count - startIndex;
                    List<ChargeRefData> charges = app.Charges.GetRange(startIndex, numToGet);
                    TypeXCriminal(wordDoc.MainDocumentPart, charges);
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "XCriminalHeader_ApplicantName", applicantName);
                    wordDoc.Save();
                }

                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

        // done
        public static void ResXEvictionPages(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            string Total = "8";
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ResXEvictionPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            string applicantName = Helper.Utils.GetApplicantName(app, reportType);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    Total = WordMLService.GetTextSdtContentCellByName(wordDoc.MainDocumentPart, "XEviction_Total");
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "XEvictionHeader_ApplicantName", applicantName);
                }
            }
            if (Total == "") Total = "8";
            int PageCount = 1;
            if (app.Evictions.Count - 2 > Convert.ToInt32(Total))
                PageCount = ((app.Evictions.Count - 2) / Convert.ToInt32(Total)) + ((app.Evictions.Count - 2) % Convert.ToInt32(Total) > 0 ? 1 : 0);
            for (int i = 1; i <= PageCount; i++)
            {
                ResXEvictionPage(sources, app, client, reportType, i);
            }
        }

        // done
        public static void ResXEvictionPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.ResXEvictionPage);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            string applicantName = Helper.Utils.GetApplicantName(app, reportType);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    string Total = WordMLService.GetTextSdtContentCellByName(wordDoc.MainDocumentPart, "XEviction_Total");
                    if (Total == "") Total = "8";
                    int startIndex = ((pageNo - 1) * Convert.ToInt32(Total)) + 2;
                    int numToGet = app.Evictions.Count - startIndex > Convert.ToInt32(Total) ? Convert.ToInt32(Total) : app.Evictions.Count - startIndex;
                    List<EvictionRefData> evictions = app.Evictions.GetRange(startIndex, numToGet);
                    TypeXEviction(wordDoc.MainDocumentPart, evictions);
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "XEvictionHeader_ApplicantName", applicantName);
                    wordDoc.Save();
                }

                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

        // done 
        private static void TypeXCriminal(MainDocumentPart mainPart, List<ChargeRefData> charges)
        {
            for (int i = 0; i < charges.Count; i = i + 2)
            {
                ChargeRefData firstCharge, secondCharge;
                firstCharge = charges.ElementAt(i);
                bool bWithoutCol = false;
                if (i + 1 >= charges.Count)
                {
                    secondCharge = new ChargeRefData();
                    secondCharge.Heading = "";
                    secondCharge.State = "N/A";
                    secondCharge.County = "N/A";
                    secondCharge.Charge = "N/A";
                    secondCharge.Date = "N/A";
                    secondCharge.Sentence = "N/A";
                    bWithoutCol = true;
                }
                else
                {
                    secondCharge = charges.ElementAt(i + 1);
                }


                if (i > 1)
                {
                    //if (firstCharge.Heading != "" || secondCharge.Heading != "")
                    //{
                    //    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "XCriminal_Heading_1", "", "", true, true, bWithoutCol);
                    //}
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "XCriminal_Heading_1", "", "", true, true, bWithoutCol);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "XCriminal_Heading_1", "", "", true, true, bWithoutCol);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "XCriminal_Heading_1", "", "", true, true, bWithoutCol);
                }

                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "XCriminal_Heading_1", firstCharge.Heading, secondCharge.Heading, true, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "XCriminal_State_Label_1", "XCriminal_State_1", firstCharge.State, secondCharge.State, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "XCriminal_County_Label_1", "XCriminal_County_1", firstCharge.County, secondCharge.County, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "XCriminal_Charge_Label_1", "XCriminal_Charge_1", firstCharge.Charge, secondCharge.Charge, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "XCriminal_Date_Label_1", "XCriminal_Date_1", firstCharge.Date, secondCharge.Date, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "XCriminal_Sentence_Label_1", "XCriminal_Sentence_1", firstCharge.Sentence, secondCharge.Sentence, false, false, bWithoutCol);

            }

            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XCriminal_Heading_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XCriminal_State_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XCriminal_County_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XCriminal_Charge_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XCriminal_Date_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XCriminal_Sentence_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XCriminal_Total");

        }

        // done
        private static void TypeXEviction(MainDocumentPart mainPart, List<EvictionRefData> evictions)
        {
            for (int i = 0; i < evictions.Count; i = i + 2)
            {
                EvictionRefData firstEviction, secondEviction;
                firstEviction = evictions.ElementAt(i);
                bool bWithoutCol = false;
                if (i + 1 >= evictions.Count)
                {
                    secondEviction = new EvictionRefData();
                    secondEviction.Heading = "";
                    secondEviction.State = "N/A";
                    secondEviction.County = "N/A";
                    secondEviction.Owners = "N/A";
                    secondEviction.Date = "N/A";
                    bWithoutCol = true;
                }
                else
                {
                    secondEviction = evictions.ElementAt(i + 1);
                }

                if (i > 1)
                {
                    //if (firstEviction.Heading != "" || secondEviction.Heading != "")
                    //{
                    //    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "XEviction_Heading_1", "", "", true, true, bWithoutCol);
                    //}
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "XEviction_Heading_1", "", "", true, true, bWithoutCol);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "XEviction_Heading_1", "", "", true, true, bWithoutCol);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "XEviction_Heading_1", "", "", true, true, bWithoutCol);
                }

                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "XEviction_Heading_1", firstEviction.Heading, secondEviction.Heading, true, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "XEviction_State_Label_1", "XEviction_State_1", firstEviction.State, secondEviction.State, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "XEviction_County_Label_1", "XEviction_County_1", firstEviction.County, secondEviction.County, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "XEviction_Owners_Label_1", "XEviction_Owners_1", firstEviction.Owners, secondEviction.Owners, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "XEviction_Date_Label_1", "XEviction_Date_1", firstEviction.Date, secondEviction.Date, false, false, bWithoutCol);

            }
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XEviction_Total");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XEviction_Heading_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XEviction_State_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XEviction_County_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XEviction_Owners_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "XEviction_Date_1");
        }

        // done
        private static void TypeEvictions(MainDocumentPart mainPart, List<EvictionRefData> evictions, int index)
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

            WordMLService.RemoveSdtContentCellByName(mainPart, "Eviction_Heading_1", eviction1.Heading);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Eviction_State_1", eviction1.State);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Eviction_County_1", eviction1.County);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Eviction_Owners_1", eviction1.Owners);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Eviction_Date_1", eviction1.Date);

            WordMLService.RemoveSdtContentCellByName(mainPart, "Eviction_Heading_2", eviction2.Heading);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Eviction_State_2", eviction2.State);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Eviction_County_2", eviction2.County);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Eviction_Owners_2", eviction2.Owners);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Eviction_Date_2", eviction2.Date);

        }

        private static void TypeCharges(MainDocumentPart mainPart, List<ChargeRefData> charges, int index)
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

            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_Heading_1", currentCharge1.Heading);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_State_1", currentCharge1.State);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_County_1", currentCharge1.County);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_Charge_1", currentCharge1.Charge);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_Date_1", currentCharge1.Date);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_Sentence_1", currentCharge1.Sentence);

            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_Heading_2", currentCharge2.Heading);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_State_2", currentCharge2.State);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_County_2", currentCharge2.County);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_Charge_2", currentCharge2.Charge);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_Date_2", currentCharge2.Date);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Charge_Sentence_2", currentCharge2.Sentence);

        }
        // done
        private static void TypeRecommendation(MainDocumentPart mainPart, RecommendationFactInfoData recommendationFactInfoData, bool bCriteria)
        {
            WordMLService.RemoveTableSdtRunByName(mainPart, "rfinal_Label_1");
            if (bCriteria)
            {   
                WordMLService.RemoveTableSdtRunByName(mainPart, "rfinal_Label_2");
                WordMLService.RemoveTableSdtRunByName(mainPart, "rfinal_Label_3");
                WordMLService.RemoveTableSdtContentCellByName(mainPart, "RentOptions_QualifiedRoommate");
                WordMLService.RemoveTableSdtContentCellByName(mainPart, "RentOptions_RentalHistory");

            }
            else
            {
                WordMLService.RemoveSdtRunByName(mainPart, "rfinal_Label_2");
                WordMLService.RemoveSdtRunByName(mainPart, "rfinal_Label_3");

                if (recommendationFactInfoData.QualifiedRoommate == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_QualifiedRoommate", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_QualifiedRoommate", "");
                if (recommendationFactInfoData.Cosigner == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_Cosigner", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_Cosigner", "");
                if (recommendationFactInfoData.FirstAndSecurity == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_FirstAndSecurity", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_FirstAndSecurity", "");
                if (recommendationFactInfoData.AbsPosNO == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_AbsPosNO", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_AbsPosNO", "");
                if (recommendationFactInfoData.RentalHistory == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_RentalHistory", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_RentalHistory", "");
                if (recommendationFactInfoData.CreditHistory == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_CreditHistory", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_CreditHistory", "");
                if (recommendationFactInfoData.RentToIncome == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_RentToIncome", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_RentToIncome", "");
                if (recommendationFactInfoData.FalseOrDiscrimminationInfo == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_FalseOrDiscrimminationInfo", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_FalseOrDiscrimminationInfo", "");
                if (recommendationFactInfoData.ShortTimeOnTheJob == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_ShortTimeOnTheJob", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_ShortTimeOnTheJob", "");
                if (recommendationFactInfoData.LackOfInformation == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_LackOfInformation", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_LackOfInformation", "");
                if (recommendationFactInfoData.CrimminalHistory == true)
                {
                    WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_CrimminalHistory", "true");
                }
                else WordMLService.RemoveSdtContentCellYesNoByName(mainPart, "RentOptions_CrimminalHistory", "");
            }
        }

        // done
        public static void CreditRefsPage(List<Source> sources, AppData app, ClientData client, ReportTypeData reportType, int pageNo)
        {
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.CreditRefs);
            byte[] byteArray = File.ReadAllBytes(templatePath);
            string applicantName = Helper.Utils.GetApplicantName(app, reportType);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    WordMLService.RemoveSdtContentCellByName(wordDoc.MainDocumentPart, "CreditRef_ApplicantName", applicantName);
                    if (app.CreditRefs.Count > 0)
                    {
                        string Total = "4";
                        int startIndex = ((pageNo - 1) * Convert.ToInt32(Total));
                        int numToGet = app.CreditRefs.Count - startIndex > Convert.ToInt32(Total) ? Convert.ToInt32(Total) : app.CreditRefs.Count - startIndex;
                        List<CreditRefData> credits = app.CreditRefs.GetRange(startIndex, numToGet);
                        TypeCreditRefs(wordDoc.MainDocumentPart, credits);
                    }
                    else
                    {
                        CreditRefData credit = new CreditRefData();
                        credit.Company = "No credit references obtained.";
                        credit.Phone = "N/A";
                        credit.Opened = "N/A";
                        credit.Terms = "N/A";
                        credit.Balance = "N/A";
                        credit.HighBalance = "N/A";
                        credit.PayHabits = "N/A";
                        credit.Rating = "N/A";
                        credit.SW = "N/A";
                        List<CreditRefData> credits = new List<CreditRefData>();
                        credits.Add(credit);
                        TypeCreditRefs(wordDoc.MainDocumentPart, credits);
                    }

                    wordDoc.Save();
                }

                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));

            }
        }

        // done 
        private static void TypeCreditRefs(MainDocumentPart mainPart, List<CreditRefData> credits)
        {
            for (int i = 0; i < credits.Count; i = i + 2)
            {
                CreditRefData firstCredit, secondCredit;
                firstCredit = credits.ElementAt(i);
                bool bWithoutCol = false;
                if (i + 1 >= credits.Count)
                {
                    secondCredit = new CreditRefData();
                    secondCredit.Company = "";
                    secondCredit.Phone = "N/A";
                    secondCredit.Opened = "N/A";
                    secondCredit.Terms = "N/A";
                    secondCredit.Balance = "N/A";
                    secondCredit.HighBalance = "N/A";
                    secondCredit.PayHabits = "N/A";
                    secondCredit.Rating = "N/A";
                    secondCredit.SW = "N/A";
                    bWithoutCol = true;
                }
                else
                {
                    secondCredit = credits.ElementAt(i + 1);
                }

                if (i > 0)
                {
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, false);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, false);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, false);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, false);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "", "Credit_Bottom_1", "________________________________________________________________________________________", "", true, true, false);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, false);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, false);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, false);
                    WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, false);
                }

                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Company_Label_1", "Credit_Company_1", firstCredit.Company, secondCredit.Company, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Phone_Label_1", "Credit_Phone_1", firstCredit.Phone, secondCredit.Phone, false, false, bWithoutCol);
                //WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, bWithoutCol);
                //WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, bWithoutCol);
                //WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Label_1", "Credit_1", "", "", true, true, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Opened_Label_1", "Credit_Opened_1", firstCredit.Opened, secondCredit.Opened, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Terms_Label_1", "Credit_Terms_1", firstCredit.Terms, secondCredit.Terms, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Balance_Label_1", "Credit_Balance_1", firstCredit.Balance, secondCredit.Balance, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_HighBalance_Label_1", "Credit_HighBalance_1", firstCredit.HighBalance, secondCredit.HighBalance, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_PayHabits_Label_1", "Credit_PayHabits_1", firstCredit.PayHabits, secondCredit.PayHabits, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_Rating_Label_1", "Credit_Rating_1", firstCredit.Rating, secondCredit.Rating, false, false, bWithoutCol);
                WordMLService.AddRow4ColumnSdtContentCellByName(mainPart, "Credit_SW_Label_1", "Credit_SW_1", firstCredit.SW, secondCredit.SW, false, false, bWithoutCol);

            }

            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_Company_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_Phone_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_Bottom_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_Opened_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_Terms_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_Balance_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_HighBalance_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_PayHabits_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_Rating_1");
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "Credit_SW_1");

        }

        // done 
        private static void TypeEmpRefs(MainDocumentPart mainPart, EmpRefData emprefs, AppData app, int index, bool bCheckEmpRef)
        {
            WordMLService.RemoveRowSdtContentCellByName(mainPart, string.Format("EmpRefs{0}_Paging", index));
            if (bCheckEmpRef)
            {
                WordMLService.RemoveTableSdtContentCellByName(mainPart, string.Format("EmpRefs_ComName_{0}", index));
                WordMLService.RemoveTableSdtContentCellByName(mainPart, "EmpRefs_Label");
            }
            else
            {
                string[] newLineArray = { Environment.NewLine, "\n" };
                List<string> textArray = new List<string>();
                if (emprefs.Info != null)
                    textArray = emprefs.Info.Split(newLineArray, StringSplitOptions.None).ToList();

                string companyname = string.Empty;
                string streetAddress = string.Empty;
                string cityStateCode = string.Empty;
                string phonenumber = string.Empty;
                phonenumber = string.IsNullOrEmpty(emprefs.Info) ? string.Empty : FindPhoneNumber(emprefs.Info);
                for (int i = 0; i < textArray.Count; i++)
                {
                    if (string.IsNullOrEmpty(textArray[i]) || textArray[i].Trim() == phonenumber.Trim())
                        textArray[i] = string.Empty;
                }

                if (textArray.Count > 0)
                {
                    companyname = textArray.Count() > 0 ? textArray[0] : string.Empty;
                    streetAddress = textArray.Count() > 1 ? textArray[1] : string.Empty; ;
                    cityStateCode = textArray.Count() > 2 ? textArray[2] : string.Empty; ;
                }

                if (index == 2) WordMLService.RemoveSdtContentCellByName(mainPart, "EmpRefs_Label", "");
                WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_ComName_{0}", index), companyname);
                WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_ComAddress_{0}", index), streetAddress);
                WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_ComCity_{0}", index), cityStateCode);
                WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_ComPhone_{0}", index), phonenumber);
                WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_Pos_{0}", index), emprefs.Pos);
                WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_Hired_{0}", index), emprefs.Hired);
                WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_Term_{0}", index), emprefs.Termination);
                WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_Status_{0}", index), emprefs.FullTime);
                WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_Salary_{0}", index), emprefs.Salary);
                WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("EmpRefs_ReHire_{0}", index), emprefs.RH);
                string strSW = Helper.Utils.RtfToText(emprefs.SW == null ? "" : emprefs.SW) + Environment.NewLine + Environment.NewLine + Helper.Utils.RtfToText(emprefs.Comment == null ? "" : emprefs.Comment);
                WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, string.Format("EmpRefs_SW_{0}", index), strSW);
            }
        }
    }
}
