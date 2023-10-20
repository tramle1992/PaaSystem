using Administration.Domain.Model.InternetTool;
using Common.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Infrastructure.InternetTool
{
    public class InternetToolCachedApiQuery
    {
        private InternetToolApiRepository repository = new InternetToolApiRepository();

        private static readonly InternetToolCachedApiQuery instance = new InternetToolCachedApiQuery();

        private const string KEY_ALL_INTERNET_ITEMS = "ALL_INTERNET_ITEMS";

        static InternetToolCachedApiQuery()
        {
        }

        public static InternetToolCachedApiQuery Instance
        {
            get { return instance; }
        }

        public List<InternetItem> GetAllInternetItems()
        {
            TypedObjectCache<List<InternetItem>> cacheList = TypedObjectCache<List<InternetItem>>.Instance;
            TypedObjectCache<InternetItem> cacheItems = TypedObjectCache<InternetItem>.Instance;
            bool isCacheStale = false;

            List<InternetItem> cacheInternetItems = null;
            List<InternetItem> resultantInternetItems = new List<InternetItem>();

            if (cacheList.TryGet(KEY_ALL_INTERNET_ITEMS, out cacheInternetItems))
            {
                foreach (InternetItem internetItem in cacheInternetItems)
                {
                    InternetItem internetItemInCache = null;
                    if (!cacheItems.TryGet(internetItem.InternetItemId.Id, out internetItemInCache))
                    {
                        isCacheStale = true;
                        break;
                    }
                    else
                    {
                        resultantInternetItems.Add(internetItemInCache);
                    }
                }
                cacheInternetItems = resultantInternetItems;
            }

            if (isCacheStale || cacheInternetItems == null)
            {
                List<InternetItem> internetItems = (List<InternetItem>)repository.FindAll();
                foreach (InternetItem internetItem in internetItems)
                {
                    cacheItems.Set(internetItem.InternetItemId.Id, internetItem);
                }
                cacheList.Set(KEY_ALL_INTERNET_ITEMS, internetItems);
                return internetItems;
            }
            else
            {
                return cacheInternetItems;
            }
        }

        public InternetItem GetInternetItem(string id)
        {
            TypedObjectCache<InternetItem> cacheItems = TypedObjectCache<InternetItem>.Instance;
            InternetItem internetItem = null;
            if (!cacheItems.TryGet(id, out internetItem))
            {
                internetItem = repository.Find(id);
                cacheItems.Set(id, internetItem);
                RemoveAllInternetItems();
            }
            return internetItem;
        }

        public void RemoveAllInternetItems()
        {
            TypedObjectCache<List<InternetItem>> cacheList = TypedObjectCache<List<InternetItem>>.Instance;
            cacheList.Remove(KEY_ALL_INTERNET_ITEMS);
        }

        public void RemoveInternetItem(string id)
        {
            TypedObjectCache<InternetItem> cacheItems = TypedObjectCache<InternetItem>.Instance;
            cacheItems.Remove(id);
        }
    }
}
