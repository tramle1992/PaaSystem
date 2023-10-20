using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace Core.Domain.Model.ClientInfo
{
    public class ManagementCompany : EntityWithCompositeId
    {
        public ManagementCompanyId ManagementCompanyId { get; private set; }

        public string Name { get; private set; }

        public ManagementCompany(ManagementCompanyId id, string name)
        {
            AssertionConcern.AssertArgumentNotEmpty(name, "The name is required");
            this.ManagementCompanyId = id;
            this.Name = name;
        }

        public void ChangeName(string newName)
        {
            this.Name = newName;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.ManagementCompanyId;
            yield return this.Name;
        }

        public override string ToString()
        {
            return "ManagementCompany[managementCompanyId=" + this.ManagementCompanyId
                + ", name=" + this.Name + "]";                
        }
    }
}
