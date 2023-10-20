using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Core.Domain.Model.ExploreApps
{
    public class ContactAttemptType : Enumeration
    {

        public static readonly ContactAttemptType RentalReference = new ContactAttemptType(0, "Rental Reference");

        public static readonly ContactAttemptType Employment = new ContactAttemptType(1, "Employment");

        public static readonly ContactAttemptType CrimminalInfo = new ContactAttemptType(2, "Crimminal Info");

        public static readonly ContactAttemptType CreditBankRef = new ContactAttemptType(3, "Credit/Bank Ref.");

        public static readonly ContactAttemptType ClientUpdate = new ContactAttemptType(4, "Client Update");

        public static ContactAttemptType CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return ContactAttemptType.RentalReference;
                case 1:
                    return ContactAttemptType.Employment;
                case 2:
                    return ContactAttemptType.CrimminalInfo;
                case 3:
                    return ContactAttemptType.CreditBankRef;
                case 4:
                    return ContactAttemptType.ClientUpdate;
                default:
                    return null;
            }
        }

        public ContactAttemptType()
        { }

        public ContactAttemptType(int value, string displayName)
            : base(value, displayName)
        {}
    }
}
