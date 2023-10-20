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
    public class EmpVer : ValueObject, IXmlSerializable
    {

        private EmpVer()
        { }

        public EmpVer(string heading, string pos,
            string hire, string salary, string ft, 
            string sw, string co, string tele, string miscComment,
            string heading2, string pos2,
            string hire2, string salary2, string ft2,
            string sw2, string co2, string tele2)
        {
            Heading = heading;
            Pos = pos;
            Hire = hire;
            SW = sw;
            Salary = salary;
            Co = co;
            FullTime = ft;
            Tele = tele;
            MiscComment = miscComment;
            Heading2 = heading2;
            Pos2 = pos2;
            Hire2 = hire2;
            SW2 = sw2;
            Salary2 = salary2;
            Co2 = co2;
            FullTime2 = ft2;
            Tele2 = tele2;
        }

        public EmpVer(EmpVer empVer)
            : this(empVer.Heading, empVer.Pos, empVer.Hire,
                empVer.Salary, empVer.FullTime, empVer.SW,
                empVer.Co, empVer.Tele, empVer.MiscComment,
                empVer.Heading2, empVer.Pos2, empVer.Hire2,
                empVer.Salary2, empVer.FullTime2, empVer.SW2,
                empVer.Co2, empVer.Tele2)
        { }

        public string Heading { get; private set; }

        public string Pos { get; private set; }

        public string Hire { get; private set; }

        public string Salary { get; private set; }

        public string FullTime { get; private set; }

        public string SW { get; private set; }

        public string Co { get; private set; }

        public string Tele { get; private set; }

        public string MiscComment { get; private set; }

        public string Heading2 { get; private set; }

        public string Pos2 { get; private set; }

        public string Hire2 { get; private set; }

        public string Salary2 { get; private set; }

        public string FullTime2 { get; private set; }

        public string SW2 { get; private set; }

        public string Co2 { get; private set; }

        public string Tele2 { get; private set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return Heading;
            yield return Pos;
            yield return Hire;
            yield return SW;
            yield return Salary;
            yield return Co;
            yield return FullTime;
            yield return Tele;
            yield return MiscComment;
            yield return Heading2;
            yield return Pos2;
            yield return Hire2;
            yield return SW2;
            yield return Salary2;
            yield return Co2;
            yield return FullTime2;
            yield return Tele2;
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
                this.Pos = reader.ReadElementString("Pos");
                this.Hire = reader.ReadElementString("Hire");
                this.SW = reader.ReadElementString("SW");
                this.Salary = reader.ReadElementString("Salary");
                this.Co = reader.ReadElementString("Co");
                this.FullTime = reader.ReadElementString("FullTime");
                this.Tele = reader.ReadElementString("Tele");
                this.MiscComment = reader.ReadElementString("MiscComment");
                this.Heading2 = reader.ReadElementString("Heading2");
                this.Pos2 = reader.ReadElementString("Pos2");
                this.Hire2 = reader.ReadElementString("Hire2");
                this.SW2 = reader.ReadElementString("SW2");
                this.Salary2 = reader.ReadElementString("Salary2");
                this.Co2 = reader.ReadElementString("Co2");
                this.FullTime2 = reader.ReadElementString("FullTime2");
                this.Tele2 = reader.ReadElementString("Tele2");
                reader.ReadEndElement();
            }     
        }
        
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Heading", this.Heading);
            writer.WriteElementString("Pos", this.Pos);
            writer.WriteElementString("Hire", this.Hire);
            writer.WriteElementString("SW", this.SW);
            writer.WriteElementString("Salary", this.Salary);
            writer.WriteElementString("Co", this.Co);
            writer.WriteElementString("FullTime", this.FullTime);
            writer.WriteElementString("Tele", this.Tele);
            writer.WriteElementString("MiscComment", this.MiscComment);
            writer.WriteElementString("Heading2", this.Heading2);
            writer.WriteElementString("Pos2", this.Pos2);
            writer.WriteElementString("Hire2", this.Hire2);
            writer.WriteElementString("SW2", this.SW2);
            writer.WriteElementString("Salary2", this.Salary2);
            writer.WriteElementString("Co2", this.Co2);
            writer.WriteElementString("FullTime2", this.FullTime2);
            writer.WriteElementString("Tele2", this.Tele2);
        }

        #endregion
    }
}
