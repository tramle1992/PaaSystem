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
    public class ChargeRef : ValueObject, IXmlSerializable
    {

        private ChargeRef()
        { }

        public ChargeRef(string heading, string state,
                string county, string charge, string date, string sentence)
        {
            Heading = heading;
            State = state;
            County = county;
            Charge = charge;
            Date = date;
            Sentence = sentence;

        }

        public ChargeRef(ChargeRef charge)
            : this(charge.Heading, charge.State,
                charge.County, charge.Charge, charge.Date, charge.Sentence)
        {
        }

        public string Heading { get; set; }

        public string State { get; set; }

        public string County { get; set; }

        public string Charge { get; set; }

        public string Date { get; set; }

        public string Sentence { get; set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return Heading;
            yield return State;
            yield return County;
            yield return Charge;
            yield return Date;
        }

        public override string ToString()
        {
            return "Eviction[heading=" + this.Heading
                + ", state=" + this.State
                + ", county=" + this.County
                + ", charge=" + this.Charge
                + ", date=" + this.Date.ToString()
                + ", sentence=" + this.Sentence
                + "]";
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
                this.Heading = reader.ReadElementString("Heading");
                this.State = reader.ReadElementString("State");
                this.County = reader.ReadElementString("County");
                this.Charge = reader.ReadElementString("Charge");
                this.Date = (reader.ReadElementString("Date"));
                this.Sentence = reader.ReadElementString("Sentence");
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Heading", this.Heading);
            writer.WriteElementString("State", this.State);
            writer.WriteElementString("County", this.County);
            writer.WriteElementString("Charge", this.Charge);
            writer.WriteElementString("Date", this.Date);
            writer.WriteElementString("Sentence", this.Sentence);
        }

        #endregion
    }
}
