using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Common.Domain.Model;

namespace Core.Domain.Model.ExploreApps
{
    public class CreditInfo : ValueObject, IXmlSerializable
    {
        private CreditInfo()
        { } 

        public CreditInfo(bool creditReportObtained, bool creditMatched, bool creditHistoryBankrupted,
            decimal pastDueAmounts, decimal rent, decimal collections, decimal liens,
            decimal judgements, decimal childSupport, string dates,
            bool positiveCreditSince, string creditPreface)
        {
            CreditReportObtained = creditReportObtained;
            CreditMatched = creditMatched;
            CreditHistoryBankrupted = creditHistoryBankrupted;
            PastDueAmounts = pastDueAmounts;
            Rent = rent;
            Collections = collections;
            Liens = liens;
            Judgements = judgements;
            ChildSupport = childSupport;
            Dates = dates;
            PositiveCreditSince = positiveCreditSince;
            CreditPreface = creditPreface;
        }

        public CreditInfo(CreditInfo creditInfo) : this(creditInfo.CreditReportObtained, creditInfo.CreditMatched,
            creditInfo.CreditHistoryBankrupted, creditInfo.PastDueAmounts, creditInfo.Rent, creditInfo.Collections,
            creditInfo.Liens, creditInfo.Judgements, creditInfo.ChildSupport, creditInfo.Dates,
            creditInfo.PositiveCreditSince, creditInfo.CreditPreface)
        { }

        public bool CreditReportObtained { get; set; }

        public bool CreditMatched { get; set; }

        public bool CreditHistoryBankrupted { get; set; }

        public decimal PastDueAmounts { get; set; }

        public decimal Rent { get; set; }

        public decimal Collections { get; set; }

        public decimal Liens { get; set; }

        public decimal Judgements { get; set; }

        public decimal ChildSupport { get; set; }

        public string Dates { get; set; }

        public bool PositiveCreditSince { get; set; }

        public string CreditPreface { get; set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return CreditReportObtained;
            yield return CreditMatched;
            yield return CreditHistoryBankrupted;
            yield return PastDueAmounts;
            yield return Rent;
            yield return Collections;
            yield return Liens;
            yield return Judgements;
            yield return ChildSupport;
            yield return Dates;
            yield return PositiveCreditSince;
            yield return CreditPreface;
        }

        # region IXmlSerializable members
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {

            reader.MoveToContent();
            bool isEmptyElement = reader.IsEmptyElement;
            reader.ReadStartElement();
            if (!isEmptyElement)
            {
                this.CreditReportObtained = Boolean.Parse(reader.ReadElementString("CreditReportObtained"));
                this.CreditMatched = Boolean.Parse(reader.ReadElementString("CreditMatched"));
                this.CreditHistoryBankrupted = Boolean.Parse(reader.ReadElementString("CreditHistoryBankrupted"));
                this.PastDueAmounts = Decimal.Parse(reader.ReadElementString("PastDueAmounts"));
                this.Rent = Decimal.Parse(reader.ReadElementString("Rent"));
                this.Collections = Decimal.Parse(reader.ReadElementString("Collections"));
                this.Liens = Decimal.Parse(reader.ReadElementString("Liens"));
                this.Judgements = Decimal.Parse(reader.ReadElementString("Judgements"));
                this.ChildSupport = Decimal.Parse(reader.ReadElementString("ChildSupport"));
                this.Dates = reader.ReadElementString("Dates");
                this.PositiveCreditSince = Boolean.Parse(reader.ReadElementString("PositiveCreditSince"));
                this.CreditPreface = reader.ReadElementString("CreditPreface");
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("CreditReportObtained", this.CreditReportObtained.ToString());
            writer.WriteElementString("CreditMatched", this.CreditMatched.ToString());
            writer.WriteElementString("CreditHistoryBankrupted", this.CreditHistoryBankrupted.ToString());
            writer.WriteElementString("PastDueAmounts", this.PastDueAmounts.ToString("G"));
            writer.WriteElementString("Rent", this.Rent.ToString("G"));
            writer.WriteElementString("Collections", this.Collections.ToString("G"));
            writer.WriteElementString("Liens", this.Liens.ToString("G"));
            writer.WriteElementString("Judgements", this.Judgements.ToString("G"));
            writer.WriteElementString("ChildSupport", this.ChildSupport.ToString("G"));
            writer.WriteElementString("Dates", this.Dates);
            writer.WriteElementString("PositiveCreditSince", this.PositiveCreditSince.ToString());
            writer.WriteElementString("CreditPreface", this.CreditPreface);
        }

        #endregion

    }
}
