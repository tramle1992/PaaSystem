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
    public class RecommendationFactInfo : ValueObject, IXmlSerializable
    {

        public RecommendationFactInfo()
        { }

        public RecommendationFactInfo(bool qualifiedRoommate, bool cosigner,
            bool firstAndSecurity, bool absPosNO, bool rentalHistory, 
            bool creditHistory, bool rentToIncome, bool falseOrDiscrimminationInfo, 
            bool shortTimeOnTheJob, bool lackOfInformation, bool crimminalHistory)
        {
            QualifiedRoommate = qualifiedRoommate;
            Cosigner = cosigner;
            FirstAndSecurity = firstAndSecurity;
            AbsPosNO = absPosNO;
            RentalHistory = rentalHistory;
            CreditHistory = creditHistory;
            RentToIncome = rentToIncome;
            FalseOrDiscrimminationInfo = falseOrDiscrimminationInfo;
            ShortTimeOnTheJob = shortTimeOnTheJob;
            LackOfInformation = lackOfInformation;
            CrimminalHistory = crimminalHistory;
        }

        public RecommendationFactInfo(RecommendationFactInfo info)
            : this(info.QualifiedRoommate, info.Cosigner,
                info.FirstAndSecurity, info.AbsPosNO, info.RentalHistory, 
                info.CreditHistory, info.RentToIncome, info.FalseOrDiscrimminationInfo, 
                info.ShortTimeOnTheJob, info.LackOfInformation, info.CrimminalHistory)
        { }

        public bool QualifiedRoommate { get; set; }

        public bool Cosigner { get; set; }

        public bool FirstAndSecurity { get; set; }

        public bool AbsPosNO { get; set; }

        public bool RentalHistory { get; set; }

        public bool CreditHistory { get; set; }

        public bool RentToIncome { get; set; }

        public bool FalseOrDiscrimminationInfo { get; set; }

        public bool ShortTimeOnTheJob { get; set; }

        public bool LackOfInformation { get; set; }

        public bool CrimminalHistory { get; set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return QualifiedRoommate;
            yield return Cosigner;
            yield return FirstAndSecurity;
            yield return AbsPosNO;
            yield return RentalHistory;
            yield return CreditHistory;
            yield return RentToIncome;
            yield return FalseOrDiscrimminationInfo;
            yield return ShortTimeOnTheJob;
            yield return LackOfInformation;
            yield return CrimminalHistory;
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
                this.QualifiedRoommate = Boolean.Parse(reader.ReadElementString("QualifiedRoommate"));
                this.Cosigner = Boolean.Parse(reader.ReadElementString("Cosigner"));
                this.FirstAndSecurity = Boolean.Parse(reader.ReadElementString("FirstAndSecurity"));
                this.AbsPosNO = Boolean.Parse(reader.ReadElementString("AbsPosNO"));
                this.RentalHistory = Boolean.Parse(reader.ReadElementString("RentalHistory"));
                this.CreditHistory = Boolean.Parse(reader.ReadElementString("CreditHistory"));
                this.RentToIncome = Boolean.Parse(reader.ReadElementString("RentToIncome"));
                this.FalseOrDiscrimminationInfo = Boolean.Parse(reader.ReadElementString("FalseOrDiscrimminationInfo"));
                this.ShortTimeOnTheJob = Boolean.Parse(reader.ReadElementString("ShortTimeOnTheJob"));
                this.LackOfInformation = Boolean.Parse(reader.ReadElementString("LackOfInformation"));
                this.CrimminalHistory = Boolean.Parse(reader.ReadElementString("CrimminalHistory"));
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("QualifiedRoommate", this.QualifiedRoommate.ToString());
            writer.WriteElementString("Cosigner", this.Cosigner.ToString());
            writer.WriteElementString("FirstAndSecurity", this.FirstAndSecurity.ToString());
            writer.WriteElementString("AbsPosNO", this.AbsPosNO.ToString());
            writer.WriteElementString("RentalHistory", this.RentalHistory.ToString());
            writer.WriteElementString("CreditHistory", this.CreditHistory.ToString());
            writer.WriteElementString("RentToIncome", this.RentToIncome.ToString());
            writer.WriteElementString("FalseOrDiscrimminationInfo", this.FalseOrDiscrimminationInfo.ToString());
            writer.WriteElementString("ShortTimeOnTheJob", this.ShortTimeOnTheJob.ToString());
            writer.WriteElementString("LackOfInformation", this.LackOfInformation.ToString());
            writer.WriteElementString("CrimminalHistory", this.CrimminalHistory.ToString());
        }

        #endregion
    }
}
