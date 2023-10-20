using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;
using InfoResource.Infrastructure.InfoResource;

namespace InfoResource.Domain.Model.InfoResource
{
    public class ResourceType : EntityWithCompositeId, IAggregateRoot
    {
        public ResourceType(ResourceTypeId resourceTypeId,
            string name)
        {
            AssertionConcern.AssertArgumentNotNull(resourceTypeId, "The resource type id is required");
            AssertionConcern.AssertArgumentNotEmpty(name, "The name is required");

            this.ResourceTypeId = resourceTypeId;
            this.Name = name;
        }

        public ResourceTypeId ResourceTypeId { get; private set; }
        public string Name { get; set; }        

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.ResourceTypeId;
            yield return this.Name;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return "ResourceType [resourceTypeId=" + this.ResourceTypeId +
                ", name=" + this.Name + "]";
        }
    }
}
