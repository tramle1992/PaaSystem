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
    public class ContactAttempt : ValueObject, IXmlSerializable
    {
        private ContactAttempt()
        { }

        public ContactAttempt(ContactAttemptType contactAttempttype, bool returnedOrResolved, string recipient,
            string phoneFaxEmail, string note)
        {
            ContactAttemptType = contactAttempttype;
            ReturnedOrResolved = returnedOrResolved;
            Recipient = recipient;
            phoneFaxEmail = PhoneFaxEmail;
            Note = note;
        }

        public ContactAttempt(ContactAttempt contactAttempt) : this(
            contactAttempt.ContactAttemptType,
            contactAttempt.ReturnedOrResolved,
            contactAttempt.Recipient,
            contactAttempt.PhoneFaxEmail,
            contactAttempt.Note)
        { }

        public ContactAttemptType ContactAttemptType { get; set; }

        public bool ReturnedOrResolved { get; set; }

        public string Recipient { get; set; }

        public string PhoneFaxEmail { get; set; }

        public string Note { get; set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return ContactAttemptType;
            yield return ReturnedOrResolved;
            yield return Recipient;
            yield return PhoneFaxEmail;
            yield return Note;
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
                this.ContactAttemptType = ContactAttemptType.CreateInstance(int.Parse(reader.ReadElementString("ContactAttemptType")));
                this.ReturnedOrResolved = Boolean.Parse(reader.ReadElementString("ReturnedOrResolved"));
                this.Recipient = reader.ReadElementString("Recipient");
                this.PhoneFaxEmail = reader.ReadElementString("PhoneFaxEmail");
                this.Note = reader.ReadElementString("Note");
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("ContactAttemptType", this.ContactAttemptType.Value.ToString("d"));
            writer.WriteElementString("ReturnedOrResolved", this.ReturnedOrResolved.ToString());
            writer.WriteElementString("Recipient", this.Recipient);
            writer.WriteElementString("PhoneFaxEmail", this.PhoneFaxEmail);
            writer.WriteElementString("Note", this.Note);
        }

        #endregion
    }
}
