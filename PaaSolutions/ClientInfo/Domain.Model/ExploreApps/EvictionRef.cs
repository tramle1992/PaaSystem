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
    public class EvictionRef : ValueObject, IXmlSerializable
    {

        private EvictionRef()
            { }

        public EvictionRef(string heading, string state,
                string county, string owners, string date)
        {
            Heading = heading;
            State = state;
            County = county;
            Owners = owners;
            Date = date;

        }

        public EvictionRef(EvictionRef eviction) : this(eviction.Heading, eviction.State,
            eviction.County, eviction.Owners, eviction.Date)
        {
        }

        public string Heading { get; set; }

        public string State { get; set; }

        public string County { get; set; }

        public string Owners { get; set; }

        public string Date { get; set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return Heading;
            yield return State;
            yield return County;
            yield return Owners;
            yield return Date;
        }

        public override string ToString()
        {
            return "Eviction[heading=" + this.Heading
                + ", state=" + this.State
                + ", county=" + this.County
                + ", owner=" + this.Owners
                + ", date=" + this.Date.ToString()
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
                this.Owners = reader.ReadElementString("Owners");
                this.Date = reader.ReadElementString("Date");
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Heading", this.Heading);
            writer.WriteElementString("State", this.State);
            writer.WriteElementString("County", this.County);
            writer.WriteElementString("Owners", this.Owners);
            writer.WriteElementString("Date", this.Date);
        }

        #endregion
    }
}
