using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDocument.Application.Data
{
    public enum DocumentReportCompleteMethod
    {
        PrintMethod,
        EmailMethod,
        ViewEditMethod
    }

    public class DocumentReportCompleteOption
    {
        public DocumentReportCompleteMethod ReportMethod { get; set; }
        public int NumberOfCopies { get; set; }
        public bool KeepDocumentOpen { get; set; }

        public DocumentReportCompleteOption(DocumentReportCompleteMethod method, int numOfCopies, bool keepDocumentOpen)
        {
            this.ReportMethod = method;
            this.NumberOfCopies = numOfCopies;
            this.KeepDocumentOpen = keepDocumentOpen;
        }
    }

}
