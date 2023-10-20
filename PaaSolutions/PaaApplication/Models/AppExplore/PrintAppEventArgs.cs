using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.AppExplore
{
    public class PrintAppEventArgs : EventArgs
    {
        public enum MainActionType
        {
            EmailTo,
            Print,
            Email
        }

        public List<AppReportItem> ReportItems;

        public MainActionType MainAction;

        public PrintAppEventArgs(List<AppReportItem> lst, MainActionType mainAction)
        {
            ReportItems = lst;
            MainAction = mainAction;
        }
    }
}
