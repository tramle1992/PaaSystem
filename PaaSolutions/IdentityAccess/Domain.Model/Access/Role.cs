using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace IdentityAccess.Domain.Model.Access
{
    public class Role : EntityWithCompositeId
    {
        public Role(RoleId roleId)
            : this()
        {
            RoleId = roleId;
        }

        public Role()
        {
            FeaturePermissions = new List<FeaturePermission>();
        }

        public RoleId RoleId { get; set; }

        public string RoleName { get; set; }

        public string Remark { get; set; }

        public string CreateBy { get; set; }

        public List<FeaturePermission> FeaturePermissions { get; set; }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.RoleId;
            yield return this.RoleName;
            yield return this.Remark;
            yield return this.CreateBy;
        }

        public override string ToString()
        {
            return "Role[roleId=" + this.RoleId.Id
                + ", roleName=" + this.RoleName + "]";
        }

        public List<RootFeaturePermission> GetRootFeaturePermission()
        {
            List<RootFeaturePermission> lst = new List<RootFeaturePermission>();

            for (int i = 0; i < FeaturePermissions.Count; i++)
            {
                if (string.IsNullOrEmpty(FeaturePermissions.ElementAt(i).ParentFeatureId))
                {
                    FeaturePermission permission = FeaturePermissions.ElementAt(i);
                    RootFeaturePermission rootFeature = new RootFeaturePermission(permission.FeatureId, permission.FeatureName, permission.IsAllowed);
                    lst.Add(rootFeature);
                }
            }

            for (int i = 0; i < FeaturePermissions.Count; i++)
            {
                FeaturePermission feature = FeaturePermissions.ElementAt(i);
                foreach(RootFeaturePermission rootFeature in lst)
                {
                    if (feature.ParentFeatureId == rootFeature.FeatureId && !string.IsNullOrEmpty(feature.ParentFeatureId))
                    {
                        FeaturePermission child = new FeaturePermission(feature.FeatureId, feature.FeatureName, feature.ParentFeatureId, feature.IsAllowed);
                        rootFeature.Children.Add(child);
                    }
                }
            }

            return lst;
        }

    }
}
