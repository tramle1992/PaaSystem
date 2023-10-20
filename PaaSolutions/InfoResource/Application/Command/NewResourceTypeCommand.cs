using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoResource.Application.Command
{
    public class NewResourceTypeCommand
    {
        public NewResourceTypeCommand()
        {
        }

        public NewResourceTypeCommand(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
