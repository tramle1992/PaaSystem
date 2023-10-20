using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace Core.Domain.Model.ClientInfo
{
    public class CreditType : Enumeration
    {
        public static readonly CreditType RegularCreditReports = new CreditType(0, "Regular Credit Reports");

        public static readonly CreditType EnhancePeopleSearch = new CreditType(1, "Enhance People Search");

        public static readonly CreditType NoCreditReports = new CreditType(2, "No Credit Reports");

        public static readonly CreditType CreditAndFICOScore = new CreditType(3, "Credit & FICO Score");

        public static readonly CreditType EmptyCreditReport = new CreditType(4, "");

        public static CreditType CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return CreditType.RegularCreditReports;
                case 1:
                    return CreditType.EnhancePeopleSearch;
                case 2:
                    return CreditType.NoCreditReports;
                case 3:
                    return CreditType.CreditAndFICOScore;
                case 4:
                    return CreditType.EmptyCreditReport;
                default:
                    return null;
            }
        }

        public CreditType()
        { }

        public CreditType(int value, string displayName)
            : base(value, displayName)
        { }
    }
}
