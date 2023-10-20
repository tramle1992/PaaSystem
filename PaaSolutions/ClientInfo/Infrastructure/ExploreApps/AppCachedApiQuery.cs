using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Cache;
using Core.Application.Data.ExploreApps;

namespace Core.Infrastructure.ExploreApps
{
    public class AppCachedApiQuery
    {
        private AppApiRepository appApiRepository = new AppApiRepository();

        private static readonly AppCachedApiQuery instance = new AppCachedApiQuery();

        private const string KEY_ALL_APP_FOR_CHECK_DUPLICATE_ITEMS = "ALL_APP_FOR_CHECK_DUPLICATE_ITEMS";

        static AppCachedApiQuery()
        {
        }

        public static AppCachedApiQuery Instance
        {
            get { return instance; }
        }

        public AppData GetApp(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;
            TypedObjectCache<AppData> cacheItems = TypedObjectCache<AppData>.Instance;
            AppData app = null;
            if (!cacheItems.TryGet(id, out app))
            {
                app = appApiRepository.Find(id);
                cacheItems.Set(id, app);
            }
            return app;
        }

        public void SetApp(AppData app)
        {
            TypedObjectCache<AppData> cacheItems = TypedObjectCache<AppData>.Instance;
            if (app != null && !string.IsNullOrEmpty(app.ApplicationId))
            {
                cacheItems.Set(app.ApplicationId, app);
            }
        }

        public void RemoveAllAppsForCheckDuplicate()
        {
            TypedObjectCache<List<DuplicateAppData>> cacheList = TypedObjectCache<List<DuplicateAppData>>.Instance;
            cacheList.Remove(KEY_ALL_APP_FOR_CHECK_DUPLICATE_ITEMS);
        }

        public void Remove(string id)
        {
            TypedObjectCache<AppData> cacheItems = TypedObjectCache<AppData>.Instance;
            cacheItems.Remove(id);
        }
    }
}
