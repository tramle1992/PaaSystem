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
    public class EmpRef : ValueObject, IXmlSerializable
    {

        private EmpRef()
        { }

        public EmpRef(string info, string sw,
            string pos, string hired, string term,
            string ft, string salary, string rh, string comment)
        {
            Info = info;
            SW = sw;
            Pos = pos;
            Hired = hired;
            Termination = term;
            FullTime = ft;
            Salary = salary;
            RH = rh;
            Comment = comment;
        }

        public EmpRef(EmpRef empRef)
            : this(empRef.Info, empRef.SW, empRef.Pos,
                empRef.Hired, empRef.Termination, empRef.FullTime,
                empRef.Salary, empRef.RH, empRef.Comment)
        { }

        public string Info { get; set; }

        public string SW { get; set; }

        public string Pos { get; set; }

        public string Hired { get; set; }

        public string Termination { get; set; }

        public string FullTime { get; set; }

        public string Salary { get; set; }

        public string RH { get; set; }

        public string Comment { get; set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return Info;
            yield return SW;
            yield return Pos;
            yield return Hired;
            yield return Termination;
            yield return FullTime;
            yield return Salary;
            yield return RH;
            yield return Comment;
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
                this.Info = reader.ReadElementString("Info");
                this.SW = reader.ReadElementString("SW");
                this.Pos = reader.ReadElementString("Pos");
                this.Hired = reader.ReadElementString("Hired");
                this.Termination = reader.ReadElementString("Termination");
                this.FullTime = reader.ReadElementString("FullTime");
                this.Salary = reader.ReadElementString("Salary");
                this.RH = reader.ReadElementString("RH");
                this.Comment = reader.ReadElementString("Comment");
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Info", this.Info);
            writer.WriteElementString("SW", this.SW);
            writer.WriteElementString("Pos", this.Pos);
            writer.WriteElementString("Hired", this.Hired);
            writer.WriteElementString("Termination", this.Termination);
            writer.WriteElementString("FullTime", this.FullTime);
            writer.WriteElementString("Salary", this.Salary);
            writer.WriteElementString("RH", this.RH);
            writer.WriteElementString("Comment", this.Comment);
        }

        #endregion
    }
}
