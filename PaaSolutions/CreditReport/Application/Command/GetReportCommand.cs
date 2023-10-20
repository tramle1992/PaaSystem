using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditReport.Application.Command
{
    public class GetReportCommand
    {
        public string AccountId { get; set; }
        public string AccountPassword { get; set; }
        public int AccountCreditType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Ssn { get; set; }
        public string StreetNum { get; set; }
        public string EndUser { get; set; }
        public string PermissiblePurposes { get; set; }

        public GetReportCommand()
        {
            // How to parse from app
            // StreetNum = app.House
            // StreetName = app.StreetName
        }
    }
}
