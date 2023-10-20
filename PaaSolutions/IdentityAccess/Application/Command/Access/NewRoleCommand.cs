using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityAccess.Domain.Model.Access;

namespace IdentityAccess.Application.Command.Access
{
    public class NewRoleCommand
    {
        public string RoleName { get; set; }

        public string Remark { get; set; }

        public string CreateBy { get; set; }

        public List<FeaturePermission> FeaturePermissions { get; set; }

        public NewRoleCommand(string name, string remark, string createby, List<FeaturePermission> features)
        {
            this.RoleName = name;
            this.Remark = remark;
            this.CreateBy = createby;
            this.FeaturePermissions = features;
        }
    }
}
