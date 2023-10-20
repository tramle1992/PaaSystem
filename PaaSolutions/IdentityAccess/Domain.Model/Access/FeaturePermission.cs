using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace IdentityAccess.Domain.Model.Access
{
    public class FeaturePermission : ValueObject
    {
        public string FeatureId { get; set; }

        public string FeatureName { get; set; }

        public bool IsAllowed { get; set; }

        public string ParentFeatureId { get; set; }

        public void SetAllowed(bool isAllowed)
        {
            IsAllowed = isAllowed;
        }

        public FeaturePermission()
        { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.FeatureId;
            yield return this.FeatureName;
            yield return this.ParentFeatureId;
            yield return this.IsAllowed;
        }

        public override string ToString()
        {
            return "FeaturePermission [featureName=" + FeatureName
                + ", featureId=" + FeatureId + "]";
        }

        public FeaturePermission(string id, string name, string parentFeatureId, bool isAllowed = false)
        {
            FeatureId = id;
            FeatureName = name;
            ParentFeatureId = parentFeatureId;
            IsAllowed = isAllowed;
        }
    }
}
