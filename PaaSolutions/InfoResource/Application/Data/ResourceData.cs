using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfoResource.Application.Data
{
    public class ResourceData
    {
        public string ResourceId { get; set; }

        public ResourceTypeData ResourceTypeData { get; set; }

        public string Name { get; set; }

        // Fax
        public string Target { get; set; }

        public string Comment { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ResourceData()
        {
        }

        public ResourceData(string ResourceId, ResourceTypeData ResourceTypeData, string Name, string Target, string Comment, string Phone, string Email)
        {
            this.ResourceId = ResourceId;
            this.ResourceTypeData = ResourceTypeData;
            this.Name = Name;
            this.Target = Target;
            this.Comment = Comment;
            this.Phone = Phone;
            this.Email = Email;
        }
    }
}
