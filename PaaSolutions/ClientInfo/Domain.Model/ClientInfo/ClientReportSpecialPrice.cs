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
    public class ClientReportSpecialPrice : ValueObject, IXmlSerializable
    {
        private ClientReportSpecialPrice()
        { }

        public ClientReportSpecialPrice(string reportTypeId, decimal specialPrice)
        {
            this.ReportTypeId = reportTypeId;
            this.SpecialPrice = specialPrice;
        }

        public ClientReportSpecialPrice(ClientReportSpecialPrice clientReportSpecialPrice)
            : this(clientReportSpecialPrice.ReportTypeId, clientReportSpecialPrice.SpecialPrice)
        {

        }

        public string ReportTypeId { get; private set; }

        public decimal SpecialPrice { get; private set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return ReportTypeId;
            yield return SpecialPrice;
        }

        public override string ToString()
        {
            return "ClientReportSpecialPrice[reportTypeId=" + ReportTypeId
                + ", specialPrice=" + SpecialPrice + "]";
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
                this.ReportTypeId = reader.ReadElementString("ReportTypeId");
                this.SpecialPrice = decimal.Parse(reader.ReadElementString("SpecialPrice"));
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("ReportTypeId", this.ReportTypeId);
            writer.WriteElementString("SpecialPrice", this.SpecialPrice.ToString());
        }
        #endregion
    }
}
