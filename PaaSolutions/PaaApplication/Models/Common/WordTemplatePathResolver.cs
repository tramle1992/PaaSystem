using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PaaApplication.Models.Common
{
    public class WordTemplatePathResolver
    {
        private static readonly string WordTemplateBasePath = string.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ConfigurationManager.AppSettings["WordTemplate"]);

        public static string GetTemplateFileName(WordDocumentType type)
        {
            switch (type)
            {
                case WordDocumentType.ClientInfo:
                    return "ClientInfo.dotx";
                case WordDocumentType.DataGrid:
                    return "DataGridTable.dot";
                case WordDocumentType.ResidentialContract:
                    return "SC.dotx";
                case WordDocumentType.EmploymentContract:
                    return "ESC.dotx";
                case WordDocumentType.InfoResourceCourtInfo:
                    return "CriminalCover.dotx";
                case WordDocumentType.InfoResourceEmployer:
                    return "EmpVerCover.dotx";
                case WordDocumentType.InfoResourceLandlord:
                    return "RentalCover.dotx";
                case WordDocumentType.SmallLabel:
                    return "SmallLabels.docx";
                case WordDocumentType.LargeLabel:
                    return "LargeLabels.docx";


                // cover
                case WordDocumentType.RentalCover:
                    return "RentalCover.dotx";
                case WordDocumentType.EmpVerCover:
                    return "EmpVerCover.dotx";
                case WordDocumentType.GenericCover:
                    return "GenericCover.dotx";
                case WordDocumentType.CredRefCover:
                    return "CredRefCover.dotx";
                case WordDocumentType.BankRefCover:
                    return "BankCover.dotx";
                case WordDocumentType.ClientUpdate:
                    return "ClientUpdate.dotx";
                case WordDocumentType.CrimCover:
                    return "CriminalCover.dotx";
                case WordDocumentType.EmpRefCover:
                    return "EmpRefCover.dotx";
                case WordDocumentType.DegreeVerCover:
                    return "GenericCover.dotx";
                
                case WordDocumentType.ConfidentialityCoverPage:
                    return "GenericCoverx.dot";
                case WordDocumentType.FileCoverPage:
                    return "FileCover.dotx";

                // app report
                case WordDocumentType.ResidentialNameEmpPage:                    
                    return "Res1.docx";
                case WordDocumentType.ResRentalRefs:                    
                    return "RentalReferences.docx";
                case WordDocumentType.CommRentalRefs:
                    return "CommRentalReferences.docx";                    
                case WordDocumentType.ResCredCrimPage:                    
                    return "ResCredCrim.docx";
                case WordDocumentType.ResXCriminalPage:                   
                    return "XCriminal.docx";
                case WordDocumentType.ResXEvictionPage:                    
                    return "XEviction.docx";
                case WordDocumentType.CreditOnlyPage:                    
                    return "Credit.docx";
                case WordDocumentType.CrimNameCrimPage:                    
                    return "Criminal.docx";
                case WordDocumentType.ResFinalPage:
                    //return "RFinal.dot"; // note: RFinalA: need to determine template at start
                    return "RFinal.docx";
                case WordDocumentType.ResFinalPageA:                    
                    return "rfinala.docx";
                case WordDocumentType.EmpNameCrimPage:
                    return "Emp1.docx";
                case WordDocumentType.EmpRefsPage:
                    return "EmploymentReferences.docx";
                case WordDocumentType.EmpFinalPage:
                    return "EFinal.docx";
                case WordDocumentType.EmpFinalPageComment:
                    return "EFinalComments.docx";
                case WordDocumentType.CommNameBankPage:
                    return "Comm.docx";
                case WordDocumentType.DeclinationLetter:
                    return "DL.docx";
                case WordDocumentType.AdverseActionLetter:
                    return "AdverseActionLetter.docx";
                case WordDocumentType.CreditRefs:
                    return "CreditReferences.docx";
                case WordDocumentType.CommFinalPage:
                    return "CFinal.docx";
                case WordDocumentType.FinalCommentsPage:                    
                    return "FinalComments.docx";

                case WordDocumentType.Invoice:
                    return "Invoice.docx";
                case WordDocumentType.InvoicesClientPastDue:
                    return "InvoicePastDue.docx";

                // others
                case WordDocumentType.Confirm:
                    return "Confirm.dotx";
                case WordDocumentType.Timecard:
                    return "Timecard.dot";

                // auto document
                case WordDocumentType.DailyReport:
                    return "DailyReport.dot";
                case WordDocumentType.ReceiptLog:
                    return "ReceiptLog.dot";
                case WordDocumentType.Calendar:
                    return "Calendar.dot";
                case WordDocumentType.MonthlyScreener:
                    return "MonthlyScreener.dot";
                case WordDocumentType.ApplicationVolume:
                    return "ApplicationVolume.dot";
                case WordDocumentType.YearlyBusiness:
                    return "YearlyBusiness.dot";
            }
            return "";
        }

        public static string GetWordTemplatePath(WordDocumentType type)
        {
            string filename = GetTemplateFileName(type);
            if (!string.IsNullOrEmpty(filename))
                return WordTemplateBasePath + GetTemplateFileName(type);
            return "";
        }
    }
}
