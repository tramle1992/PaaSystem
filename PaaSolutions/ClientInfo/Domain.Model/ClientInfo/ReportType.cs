using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace Core.Domain.Model.ClientInfo
{
    public class ReportType : EntityWithCompositeId
    {
        public ReportType(string reportTypeId, string typeName, string absoluteTypeName, decimal defaultPrice)
        {
            this.ReportTypeId = reportTypeId;
            this.TypeName = typeName;
            this.AbsoluteTypeName = absoluteTypeName;
            this.DefaultPrice = defaultPrice;
        }

        public string ReportTypeId {get; private set;}

        public string TypeName { get; private set; }
        
        public string AbsoluteTypeName { get; private set; }

        public decimal DefaultPrice { get; private set; }

        public void ChangeTypeName(string typeName)
        {
            this.TypeName = typeName;
        }

        public void ChangeAbsoluteName(string absoluteName)
        {
            this.AbsoluteTypeName = absoluteName;
        }

        public void ChangeDefaultPrice(decimal defaultPrice)
        {
            this.DefaultPrice = defaultPrice;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.ReportTypeId;
            yield return this.TypeName;
        }

        public override string ToString()
        {
            return "ReportType[reportTypeId=" + this.ReportTypeId
                + ", typeName=" + this.TypeName
                + ", absoluteTypeName=" + this.AbsoluteTypeName
                + ", defaultPrice=" + this.DefaultPrice +"]";
        }
    }
}
