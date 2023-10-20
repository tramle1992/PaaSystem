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
    public class OtherAddress : ValueObject, IXmlSerializable
    {
        private OtherAddress()
        { }

        public OtherAddress(string addressKind, string address)
        {
            AddressKind = addressKind;
            Address = address;
        }

        public OtherAddress(OtherAddress otherAddress) : this(otherAddress.AddressKind, otherAddress.Address)
        { }

        public string AddressKind { get; private set; }

        public string Address { get; private set; }

        public override string ToString()
        {
            return "OtherAddress [addressKind=" + AddressKind
                + ", address=" + this.Address + "]";
        }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return this.AddressKind;
            yield return this.Address;
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
                this.AddressKind = reader.ReadElementString("AddressKind");
                this.Address = reader.ReadElementString("Address");
                reader.ReadEndElement();
            }            
        }


        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("AddressKind", this.AddressKind);
            writer.WriteElementString("Address", this.Address);
        }

        #endregion

    }
}
