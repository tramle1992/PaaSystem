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
    public class InvoiceDivision : ValueObject, IXmlSerializable
    {

        private InvoiceDivision()
        { }

        public InvoiceDivision(string divisionName)
        {
            this.DivisionName = divisionName;
        }

        public string DivisionName { get; private set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return DivisionName;            
        }

        public override string ToString()
        {
            return "InvoiceDivision[divisionName=" + DivisionName + "]";
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
                this.DivisionName = reader.ReadElementString();
                reader.ReadEndElement();
            }
            
        }


        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("DivisionName", this.DivisionName);
        }

        #endregion
    }
}
