using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Application.Data.ClientInfo
{
    public class InvoiceDivisionData
    {
        public string DivisionName { get; set; }

        public InvoiceDivisionData()
        {
        }

        public InvoiceDivisionData(string divisionName)
        {
            this.DivisionName = divisionName;
        }
    }
}
