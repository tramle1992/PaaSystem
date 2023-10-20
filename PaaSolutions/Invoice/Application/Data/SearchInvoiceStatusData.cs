using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Data
{
    public class SearchInvoiceStatusData
    {
        private static List<StatusData> data;

        public static List<StatusData> Data
        {
            get { return data; }
        }

        static SearchInvoiceStatusData()
        {
            if (data == null)
            {
                data = new List<StatusData>(4);
                data.Add(new StatusData(-1, "All Invoices"));
                data.Add(new StatusData(2, "Paid Invs."));
                data.Add(new StatusData(4, "Unpaid Invs."));
                data.Add(new StatusData(1, "Past Due Invs."));
            }
        }
    }
}
