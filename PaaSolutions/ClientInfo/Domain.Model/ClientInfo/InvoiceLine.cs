using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Core.Domain.Model.ClientInfo
{
    public class InvoiceLine : Enumeration, IXmlSerializable
    {
        public InvoiceLine()
        { }

        private InvoiceLine(int value, string displayName) : base(value, displayName)
        {

        }

        public string DetailMessage {
            get
            {
                switch(this.Value)
                {
                    case 0:
                        return "The Community is the Client Name at the top of the report, "
                        + "entered near the bottom of the 'Applicant Info' tab of the Application Explorer";                        
                    case 1:
                        return "The Recommendation is based on the five levels of qualification, "
                        + "'Denial', '1st + Security', 'Cosigner', 'Approval', or 'Qual. Roommate', 'Qual Rmmt & ' "
                        + "can also be placed prior to any recommendation other than 'Qual. Roommate' if it is selected."
                        + "Recommendation is '(In-Process)' for applications that have not yet been archived, and 'N/A' for all non-residential applications";                        
                    case 2:
                        return "The City is entered after the company applied for employment reports, and after the community for all others."
                        + " It must be separated from the rest of the line by a hyphen.   (i.e. 'PUEC - Salt Lake')";
                    case 3:
                        return "The PO Number is entered after the Unit Number field, on the 'Applicant Info' tab for all residential applications."
                        + "It must begin with PO#, as in '123 PO# 456'";                        
                }
                return "";
            }
        }

        # region IXmlSerializable members
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {            
        }


        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Value", this.Value.ToString());
            writer.WriteElementString("DisplayName", this.DisplayName);
        }

        #endregion

        public static readonly InvoiceLine Community = new InvoiceLine(0, "Community");

        public static readonly InvoiceLine Recommendation = new InvoiceLine(1, "Recommendation");

        public static readonly InvoiceLine CityApplied = new InvoiceLine(2, "CityApplied");

        public static readonly InvoiceLine PONumber = new InvoiceLine(3, "PONumber");

        public static InvoiceLine CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return InvoiceLine.Community;
                case 1:
                    return InvoiceLine.Recommendation;
                case 2:
                    return InvoiceLine.CityApplied;
                case 3:
                    return InvoiceLine.PONumber;
                default:
                    return null;
            }
        }

        
    }
}
