using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.Common
{
    public enum WordDocumentType
    {
        SmallLabel,
        LargeLabel,
        Label,
        ClientInfo,
        DataGrid,
        ResidentialContract,
        EmploymentContract,
        InfoResourceCourtInfo,
        InfoResourceEmployer,
        InfoResourceLandlord,
        // cover
        RentalCover,
        EmpVerCover,
        GenericCover,
        CredRefCover,
        BankRefCover,
        ClientUpdate,
        CrimCover,
        EmpRefCover,
        DegreeVerCover,
        DeclinationLetter,
        AdverseActionLetter,
        ConfidentialityCoverPage,
        FileCoverPage,
        
        // app report
        ResidentialNameEmpPage,
        ResRentalRefs,
        CommRentalRefs,
        ResCredCrimPage,
        ResXCriminalPage,
        ResXEvictionPage,
        CreditOnlyPage,
        CrimNameCrimPage,
        ResFinalPage,
        ResFinalPageA,
        EmpNameCrimPage,
        EmpRefsPage,
        EmpFinalPage,
        EmpFinalPageComment,
        CommNameBankPage,
        CreditRefs,
        CommFinalPage,
        FinalCommentsPage,

        // invoice
        Invoice,
        InvoicesClientPastDue,

        // others
        Confirm,
        Timecard,

        // auto document
        DailyReport,
        ReceiptLog,
        Calendar,
        MonthlyScreener,
        ApplicationVolume,
        YearlyBusiness
    }
}
