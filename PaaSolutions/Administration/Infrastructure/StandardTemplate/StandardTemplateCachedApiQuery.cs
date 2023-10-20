using Administration.Domain.Model.StandardTemplate;
using Common.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Infrastructure.StandardTemplate
{
    public class StandardTemplateCachedApiQuery
    {
        private StandardTemplateApiRepository repository = new StandardTemplateApiRepository();

        private static readonly StandardTemplateCachedApiQuery instance = new StandardTemplateCachedApiQuery();

        private const string KEY_ALL_TEMPLATE_ITEMS = "ALL_TEMPLATE_ITEMS";

        static StandardTemplateCachedApiQuery()
        {
        }

        public static StandardTemplateCachedApiQuery Instance
        {
            get { return instance; }
        }

        public List<TemplateItem> GetAllTemplateItems()
        {
            TypedObjectCache<List<TemplateItem>> cacheList = TypedObjectCache<List<TemplateItem>>.Instance;
            TypedObjectCache<TemplateItem> cacheItems = TypedObjectCache<TemplateItem>.Instance;
            bool isCacheStale = false;

            List<TemplateItem> cacheTemplateItems = null;
            List<TemplateItem> resultantTemplateItems = new List<TemplateItem>();

            if (cacheList.TryGet(KEY_ALL_TEMPLATE_ITEMS, out cacheTemplateItems))
            {
                foreach (TemplateItem templateItem in cacheTemplateItems)
                {
                    TemplateItem templateItemInCache = null;
                    if (!cacheItems.TryGet(templateItem.TemplateItemId.Id, out templateItemInCache))
                    {
                        isCacheStale = true;
                        break;
                    }
                    else
                    {
                        resultantTemplateItems.Add(templateItemInCache);
                    }
                }
                cacheTemplateItems = resultantTemplateItems;
            }

            if (isCacheStale || cacheTemplateItems == null)
            {
                List<TemplateItem> templateItems = (List<TemplateItem>)repository.FindAll();
                foreach (TemplateItem templateItem in templateItems)
                {
                    cacheItems.Set(templateItem.TemplateItemId.Id, templateItem);
                }
                cacheList.Set(KEY_ALL_TEMPLATE_ITEMS, templateItems);
                return templateItems;
            }
            else
            {
                return cacheTemplateItems;
            }
        }

        public TemplateItem GetTemplateItem(string id)
        {
            TypedObjectCache<TemplateItem> cacheItems = TypedObjectCache<TemplateItem>.Instance;
            TemplateItem templateItem = null;
            if (!cacheItems.TryGet(id, out templateItem))
            {
                templateItem = repository.Find(id);
                cacheItems.Set(id, templateItem);
                RemoveAllTemplateItems();
            }
            return templateItem;
        }

        public void RemoveAllTemplateItems()
        {
            TypedObjectCache<List<TemplateItem>> cacheList = TypedObjectCache<List<TemplateItem>>.Instance;
            cacheList.Remove(KEY_ALL_TEMPLATE_ITEMS);
        }

        public void RemoveTemplateItem(string id)
        {
            TypedObjectCache<TemplateItem> cacheItems = TypedObjectCache<TemplateItem>.Instance;
            cacheItems.Remove(id);
        }
    }
}
