using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Common.Domain.Model;

namespace Core.Domain.Model.ClientInfo
{
    public enum ContactType
    {
        Email,
        Fax,
        Other
    }

    public class Contact : ValueObject, IXmlSerializable
    {
        private Contact()
        { }

        public Contact(ContactType contactType, string contactInfo)
        {
            this.ContactType = contactType;
            this.ContactInfo = contactInfo;
        }

        public Contact(Contact contact)
            : this(contact.ContactType, contact.ContactInfo)
        {

        }

        public string ContactInfo { get; private set; }

        public ContactType ContactType { get; private set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return ContactType;
            yield return ContactInfo;
        }

        public override string ToString()
        {            
            switch(ContactType)
            {
                case ContactType.Fax:
                    return "Contact [contactType=Fax, contactInfo=" + ContactInfo + "]";
                case ContactType.Email:
                    return "Contact [contactType=Email, contactInfo=" + ContactInfo + "]";
                default:
                    return "Contact [contactType=Other, contactInfo=" + ContactInfo + "]";
            }
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
                this.ContactType = (ContactType)(int.Parse(reader.ReadElementString("ContactType")));
                this.ContactInfo = reader.ReadElementString("ContactInfo");
                reader.ReadEndElement();
            }
        }
        
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("ContactType", this.ContactType.ToString("d"));
            writer.WriteElementString("ContactInfo", this.ContactInfo);
        }

        #endregion

    }
}
