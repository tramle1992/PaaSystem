using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Command
{
    public class SearchInvoiceCommand
    {
        public DateTime? CreatedFrom { get; set; }

        public DateTime? CreatedTo { get; set; }

        public bool ClientsOperator { get; set; }

        public List<string> ClientNames { get; set; }

        public bool StatusOperator { get; set; }

        public List<int> StatusValues { get; set; }

        public string Keyword { get; set; }

        public string SearchIn { get; set; }

        public SearchInvoiceCommand()
        {
        }

        public SearchInvoiceCommand(DateTime? createdFrom, DateTime? createdTo,
            bool clientsOperator, List<string> clientNames, bool statusOperator, List<int> statusValues,
            string keyword, string searchIn)
        {
            this.CreatedFrom = createdFrom;
            this.CreatedTo = createdTo;
            this.ClientsOperator = clientsOperator;
            this.ClientNames = clientNames;
            this.StatusOperator = statusOperator;
            this.StatusValues = statusValues;
            this.Keyword = keyword;
            this.SearchIn = searchIn;
        }
    }
}
