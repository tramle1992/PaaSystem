
using Common.Infrastructure.Cache;
using InfoResource.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoResource.Infrastructure.InfoResource
{
    public class InfoResourceCachedApiQuery
    {
        private InfoResourceApiRepository repository = new InfoResourceApiRepository();

        private static readonly InfoResourceCachedApiQuery instance = new InfoResourceCachedApiQuery();

        private const string KEY_ALL_INFO_RESOURCE_ITEMS = "ALL_INFO_RESOURCE_ITEMS";

        static InfoResourceCachedApiQuery()
        {
        }

        public static InfoResourceCachedApiQuery Instance
        {
            get { return instance; }
        }

        public List<ResourceData> GetAllResourceItems()
        {
            TypedObjectCache<List<ResourceData>> cacheList = TypedObjectCache<List<ResourceData>>.Instance;
            TypedObjectCache<ResourceData> cacheItems = TypedObjectCache<ResourceData>.Instance;
            bool isCacheStale = false;

            List<ResourceData> cacheResourceItems = null;
            List<ResourceData> resultantResourceItems = new List<ResourceData>();

            if (cacheList.TryGet(KEY_ALL_INFO_RESOURCE_ITEMS, out cacheResourceItems))
            {
                foreach (ResourceData resource in cacheResourceItems)
                {
                    ResourceData resourceItemInCache = null;
                    if (!cacheItems.TryGet(resource.ResourceId, out resourceItemInCache))
                    {
                        isCacheStale = true;
                        break;
                    }
                    else
                    {
                        resultantResourceItems.Add(resourceItemInCache);
                    }
                }
                cacheResourceItems = resultantResourceItems;
            }

            if (isCacheStale || cacheResourceItems == null)
            {
                List<ResourceData> resourceItems = (List<ResourceData>)repository.FindAll();
                foreach (ResourceData resource in resourceItems)
                {
                    cacheItems.Set(resource.ResourceId, resource);
                }
                cacheList.Set(KEY_ALL_INFO_RESOURCE_ITEMS, resourceItems);
                return resourceItems;
            }
            else
            {
                return cacheResourceItems;
            }
        }

        public ResourceData GetResourceItem(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            TypedObjectCache<ResourceData> cacheItems = TypedObjectCache<ResourceData>.Instance;
            ResourceData resourceItem = null;
            if (!cacheItems.TryGet(id, out resourceItem))
            {
                resourceItem = repository.Find(id);
                cacheItems.Set(id, resourceItem);
            }
            return resourceItem;
        }

        public void RemoveResourceItem(string id)
        {
            TypedObjectCache<ResourceData> cacheItems = TypedObjectCache<ResourceData>.Instance;
            cacheItems.Remove(id);            
        }

        public void RemoveAllInfoResources()
        {
            TypedObjectCache<List<ResourceData>> cacheList = TypedObjectCache<List<ResourceData>>.Instance;
            cacheList.Remove(KEY_ALL_INFO_RESOURCE_ITEMS);
        }
    }
}
