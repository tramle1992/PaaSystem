using Common.Infrastructure.Cache;
using InfoResource.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoResource.Infrastructure.InfoResource
{
    public class ResourceTypeCachedApiQuery
    {
        private ResourceTypeApiRepository repository = new ResourceTypeApiRepository();

        private static readonly ResourceTypeCachedApiQuery instance = new ResourceTypeCachedApiQuery();

        private const string KEY_ALL_RESOURCE_TYPE_ITEMS = "KEY_ALL_RESOURCE_TYPE_ITEMS";

        static ResourceTypeCachedApiQuery()
        {
        }

        public static ResourceTypeCachedApiQuery Instance
        {
            get { return instance; }
        }

        public List<ResourceTypeData> GetAllItems()
        {
            TypedObjectCache<List<ResourceTypeData>> cacheList = TypedObjectCache<List<ResourceTypeData>>.Instance;
            List<ResourceTypeData> cacheItems = null;

            if (cacheList.TryGet(KEY_ALL_RESOURCE_TYPE_ITEMS, out cacheItems))
            {
                return cacheItems;
            }

            cacheItems = (List<ResourceTypeData>)repository.FindAll();
            cacheList.Set(KEY_ALL_RESOURCE_TYPE_ITEMS, cacheItems);

            return cacheItems;
        }

        public void RemoveAllItems()
        {
            TypedObjectCache<List<ResourceTypeData>> cacheList = TypedObjectCache<List<ResourceTypeData>>.Instance;
            cacheList.Remove(KEY_ALL_RESOURCE_TYPE_ITEMS);
        }
    }
}
