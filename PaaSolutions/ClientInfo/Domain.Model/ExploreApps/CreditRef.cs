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
    public class CreditRef : ValueObject, IXmlSerializable
    {
        private CreditRef()
        { }

        public CreditRef(string company, string phone, string opened,
            string terms, string balance, string highBalance, string payHabits, string rating, string sw)
        {
            Company = company;
            Phone = phone;
            Opened = opened;
            Terms = terms;
            Balance = balance;
            HighBalance = highBalance;
            Rating = rating;
            PayHabits = payHabits;
            SW = sw;
        }

        public CreditRef(CreditRef creditRef)
            : this(creditRef.Company, creditRef.Phone, creditRef.Opened,
                creditRef.Terms, creditRef.Balance, creditRef.HighBalance,
                creditRef.PayHabits, creditRef.Rating, creditRef.SW)
        { }

        public string Company { get; set; }

        public string Phone { get; set; }

        public string Opened { get; set; }

        public string Terms { get; set; }

        public string Balance { get; set; }

        public string HighBalance { get; set; }

        public string PayHabits { get; set; }

        public string Rating { get; set; }

        public string SW { get; set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return Company;
            yield return Phone;
            yield return Opened;
            yield return Terms;
            yield return Balance;
            yield return HighBalance;
            yield return PayHabits;
            yield return Rating;
            yield return SW;
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
                this.Company = reader.ReadElementString("Company");
                this.Phone = reader.ReadElementString("Phone");
                this.Opened = reader.ReadElementString("Opened");
                this.Terms = reader.ReadElementString("Terms");
                this.Balance = reader.ReadElementString("Balance");
                this.HighBalance = reader.ReadElementString("HighBalance");
                this.PayHabits = reader.ReadElementString("PayHabits");
                this.Rating = reader.ReadElementString("Rating");
                this.SW = reader.ReadElementString("SW");
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Company", this.Company);
            writer.WriteElementString("Phone", this.Phone);
            writer.WriteElementString("Opened", this.Opened);
            writer.WriteElementString("Terms", this.Terms);
            writer.WriteElementString("Balance", this.Balance);
            writer.WriteElementString("HighBalance", this.HighBalance);
            writer.WriteElementString("PayHabits", this.PayHabits);
            writer.WriteElementString("Rating", this.Rating);
            writer.WriteElementString("SW", this.SW);
        }

        #endregion
    }
}
