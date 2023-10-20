using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace PaaApplication.Models.AppExplore
{
    public class InvoiceDivisionChangedEventArgs
    {
        public string InvoiceDivisionName { get; set; }
        public bool IsEnter { get; set; }
        public InvoiceDivisionChangedEventArgs(string invoiceDivisionName, bool isEnter = false)
        {
            InvoiceDivisionName = invoiceDivisionName;
            IsEnter = isEnter;
        }
    }
}