using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemConfiguration.Domain.Model
{
    public class ConfigId : Identity
    {
        public ConfigId() { }

        public ConfigId(string id)
            : base(id)
        {
        }
    }
}
