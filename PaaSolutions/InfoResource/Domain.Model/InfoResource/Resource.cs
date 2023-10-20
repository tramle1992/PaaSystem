using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace InfoResource.Domain.Model.InfoResource
{
    public class Resource : EntityWithCompositeId, IAggregateRoot
    {

        public Resource(
            ResourceId resourceId,
            string name,
            string target,
            string comment,
            string phone,
            string email,
            ResourceType resourceType)
        {
            AssertionConcern.AssertArgumentNotNull(resourceId, "The id is required");
            AssertionConcern.AssertArgumentNotEmpty(name, "The name is required");
            AssertionConcern.AssertArgumentNotNull(resourceType, "The resource type is required");

            this.ResourceId = resourceId;
            this.Name = name;
            this.Target = target;
            this.Comment = comment;
            this.Phone = phone;
            this.Email = email;
            this.ResourceType = resourceType;
        }

        public ResourceId ResourceId { get; private set; }

        public string Name { get; set; }

        public string Target { get; set; }

        public string Comment { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ResourceType ResourceType { get; set; }
        
        public void ChangeResource(string name, string target, string comment, string phone, string email, ResourceType resourceType)
        {
            this.Name = name;
            this.Target = target;
            this.Comment = comment;
            this.ResourceType = resourceType;
            this.Phone = phone;
            this.Email = email;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.ResourceId;
            yield return this.Name;
        }

        public override string ToString()
        {
            return "InfoResource[resourceId=" + this.ResourceId
                + ", name=" + this.Name
                + ", target=" + this.Target
                + ", comment=" + this.Comment
                + ", phone=" + this.Phone
                + ", email=" + this.Email
                + ", resourceType=" + this.ResourceType + "]";
        }
    }
}
