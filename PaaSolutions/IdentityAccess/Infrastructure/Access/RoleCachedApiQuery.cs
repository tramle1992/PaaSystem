using Common.Infrastructure.Cache;
using IdentityAccess.Domain.Model.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Infrastructure.Access
{
    public class RoleCachedApiQuery
    {
        private RoleApiRepository repository = new RoleApiRepository();

        private static readonly RoleCachedApiQuery instance = new RoleCachedApiQuery();

        private const string KEY_ALL_FEATURE_PERMISSIONS = "ALL_FEATURE_PERMISSIONS";

        static RoleCachedApiQuery()
        {
        }

        public static RoleCachedApiQuery Instance
        {
            get { return instance; }
        }

        public List<FeaturePermission> ListFeaturePermission()
        {
            TypedObjectCache<List<FeaturePermission>> cacheList = TypedObjectCache<List<FeaturePermission>>.Instance;
            TypedObjectCache<FeaturePermission> cacheItems = TypedObjectCache<FeaturePermission>.Instance;
            bool isCacheStale = false;

            List<FeaturePermission> cacheFeaturePermissionItems = null;
            List<FeaturePermission> resultantFeaturePermissionItems = new List<FeaturePermission>();

            if (cacheList.TryGet(KEY_ALL_FEATURE_PERMISSIONS, out cacheFeaturePermissionItems))
            {
                foreach (FeaturePermission item in cacheFeaturePermissionItems)
                {
                    FeaturePermission internetItemInCache = null;
                    if (!cacheItems.TryGet(item.FeatureId, out internetItemInCache))
                    {
                        isCacheStale = true;
                        break;
                    }
                    else
                    {
                        resultantFeaturePermissionItems.Add(internetItemInCache);
                    }
                }
                cacheFeaturePermissionItems = resultantFeaturePermissionItems;
            }

            if (isCacheStale || cacheFeaturePermissionItems == null)
            {
                List<FeaturePermission> featurePermission = (List<FeaturePermission>)repository.ListFeaturePermission();
                foreach (FeaturePermission item in featurePermission)
                {
                    cacheItems.Set(item.FeatureId, item);
                }
                cacheList.Set(KEY_ALL_FEATURE_PERMISSIONS, featurePermission);
                return featurePermission;
            }
            else
            {
                return cacheFeaturePermissionItems;
            }
        }
        public void RemoveAllFeaturePermissions()
        {
            TypedObjectCache<List<FeaturePermission>> cacheList = TypedObjectCache<List<FeaturePermission>>.Instance;
            cacheList.Remove(KEY_ALL_FEATURE_PERMISSIONS);
        }

    }
}
