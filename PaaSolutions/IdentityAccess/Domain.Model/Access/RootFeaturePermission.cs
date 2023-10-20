using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Domain.Model.Access
{
    public class RootFeaturePermission : FeaturePermission
    {
        public List<FeaturePermission> Children { get; set; }

        public RootFeaturePermission(string id, string name, bool isAllowed = false)
            : base(id, name, "", isAllowed)
        {
            Children = new List<FeaturePermission>();
        }
    }
}
