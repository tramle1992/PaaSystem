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
    public class RentalRef : ValueObject, IXmlSerializable
    {

        private RentalRef()
        { }

        public RentalRef(RentalRefFactInfo written, RentalRefFactInfo kickedOut,
            RentalRefFactInfo prprNotice, RentalRefFactInfo lateNSF,
            RentalRefFactInfo complaints, RentalRefFactInfo damages,
            RentalRefFactInfo owing, RentalRefFactInfo roommates,
            RentalRefFactInfo addressMatch, RentalRefFactInfo pets,
            RentalRefFactInfo rltveFrnd, RentalRefFactInfo reRent, RentalRefFactInfo bedBugs,
            string moveIn, string moveOut, string amount,
            string sw, string comp, string phone, string comment)
        {
            this.Written = written;
            this.KickedOut = kickedOut;
            this.PrprNotice = prprNotice;
            this.LateNSF = lateNSF;
            this.Complaints = complaints;
            this.Damages = damages;
            this.Owing = owing;
            this.Roommates = roommates;
            this.AddressMatch = addressMatch;
            this.Pets = pets;
            this.RltveFrnd = rltveFrnd;
            this.ReRent = reRent;
            this.BedBugs = bedBugs;
            this.MoveIn = moveIn;
            this.MoveOut = moveOut;
            this.Amount = amount;
            this.SW = sw;
            this.Comp = comp;
            this.Phone = phone;
            this.Comment = comment;
        }

        public RentalRef(RentalRef rentalRef)
            : this(rentalRef.Written, rentalRef.KickedOut, rentalRef.PrprNotice,
            rentalRef.LateNSF, rentalRef.Complaints, rentalRef.Damages,
            rentalRef.Owing, rentalRef.Roommates, rentalRef.AddressMatch,
            rentalRef.Pets, rentalRef.RltveFrnd, rentalRef.ReRent, rentalRef.BedBugs,
            rentalRef.MoveIn, rentalRef.MoveOut, rentalRef.Amount,
            rentalRef.SW, rentalRef.Comp, rentalRef.Phone, rentalRef.Comment)
        {
        }

        public RentalRefFactInfo Written { get; set; }

        public RentalRefFactInfo KickedOut { get; set; }

        public RentalRefFactInfo PrprNotice { get; set; }

        public RentalRefFactInfo LateNSF { get; set; }

        public RentalRefFactInfo Complaints { get; set; }

        public RentalRefFactInfo Damages { get; set; }

        public RentalRefFactInfo Owing { get; set; }

        public RentalRefFactInfo Roommates { get; set; }

        public RentalRefFactInfo AddressMatch { get; set; }

        public RentalRefFactInfo Pets { get; set; }

        public RentalRefFactInfo RltveFrnd { get; set; }

        public RentalRefFactInfo ReRent { get; set; }

        public RentalRefFactInfo BedBugs { get; set; }

        public string MoveIn { get; set; }

        public string MoveOut { get; set; }

        public string Amount { get; set; }

        public string SW { get; set; }

        public string Comp { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return Written;
            yield return KickedOut;
            yield return PrprNotice;
            yield return LateNSF;
            yield return Complaints;
            yield return Damages;
            yield return Owing;
            yield return Roommates;
            yield return AddressMatch;
            yield return Pets;
            yield return RltveFrnd;
            yield return ReRent;
            yield return BedBugs;
            yield return MoveIn;
            yield return MoveOut;
            yield return Amount;
            yield return SW;
            yield return Comp;
            yield return Phone;
            yield return Comment;
        }

        public override string ToString()
        {
            return "RentalRef[comment=" + this.Comment
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
                this.Written = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("Written")));
                this.KickedOut = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("KickedOut")));
                this.PrprNotice = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("PrprNotice")));
                this.LateNSF = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("LateNSF")));
                this.Complaints = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("Complaints")));
                this.Damages = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("Damages")));
                this.Owing = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("Owing")));
                this.Roommates = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("Roommates")));
                this.AddressMatch = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("AddressMatch")));
                this.Pets = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("Pets")));
                this.RltveFrnd = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("RltveFrnd")));
                this.ReRent = (RentalRefFactInfo)(int.Parse(reader.ReadElementString("ReRent")));
                if (reader.Name == "BedBugs")
                {
                    this.BedBugs = (RentalRefFactInfo)int.Parse(reader.ReadElementString("BedBugs"));
                }
                else
                {
                    this.BedBugs = RentalRefFactInfo.NotAvailable;
                }
                this.MoveIn = reader.ReadElementString("MoveIn");
                this.MoveOut = reader.ReadElementString("MoveOut");
                this.Amount = reader.ReadElementString("Amount");
                this.SW = reader.ReadElementString("SW");
                this.Comp = reader.ReadElementString("Comp");
                this.Phone = reader.ReadElementString("Phone");
                this.Comment = reader.ReadElementString("Comment");
                reader.ReadEndElement();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Written", this.Written.ToString("d"));
            writer.WriteElementString("KickedOut", this.KickedOut.ToString("d"));
            writer.WriteElementString("PrprNotice", this.PrprNotice.ToString("d"));
            writer.WriteElementString("LateNSF", this.LateNSF.ToString("d"));
            writer.WriteElementString("Complaints", this.Complaints.ToString("d"));
            writer.WriteElementString("Damages", this.Damages.ToString("d"));
            writer.WriteElementString("Owing", this.Owing.ToString("d"));
            writer.WriteElementString("Roommates", this.Roommates.ToString("d"));
            writer.WriteElementString("AddressMatch", this.AddressMatch.ToString("d"));
            writer.WriteElementString("Pets", this.Pets.ToString("d"));
            writer.WriteElementString("RltveFrnd", this.RltveFrnd.ToString("d"));
            writer.WriteElementString("ReRent", this.ReRent.ToString("d"));
            writer.WriteElementString("BedBugs", this.BedBugs.ToString("d"));
            writer.WriteElementString("MoveIn", this.MoveIn.ToString());
            writer.WriteElementString("MoveOut", this.MoveOut.ToString());
            writer.WriteElementString("Amount", this.Amount);
            writer.WriteElementString("SW", this.SW);
            writer.WriteElementString("Comp", this.Comp);
            writer.WriteElementString("Phone", this.Phone);
            writer.WriteElementString("Comment", this.Comment);
        }

        #endregion
    }
}
