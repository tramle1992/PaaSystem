using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoResource.Application.Command
{
    public class NewResourceCommand
    {
        public NewResourceCommand()
        {
        }

        public NewResourceCommand(string resourceTypeId, string name, string target, string comment, string phone, string email)
        {
            this.ResourceTypeId = resourceTypeId;
            this.Name = name;
            this.Target = target;
            this.Comment = comment;
            this.Phone = phone;
            this.Email = email;
        }

        public string ResourceTypeId { get; set; }

        public string Name { get; set; }

        public string Target { get; set; }

        public string Comment { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
