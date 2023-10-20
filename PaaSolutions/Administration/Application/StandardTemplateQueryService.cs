using Administration.Domain.Model.StandardTemplate;
using Administration.Infrastructure.StandardTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application
{
    public class StandardTemplateQueryService
    {
        readonly StandardTemplateRepository repository;

        public StandardTemplateQueryService()
        {
            repository = new StandardTemplateRepository();
        }

        public TemplateItem GetById(string id)
        {
            TemplateItem item = repository.Find(id);
            return item;
        }

        public IList<TemplateItem> GetAll()
        {
            IList<TemplateItem> items = repository.FindAll();
            if (items.Count > 0)
            {
                return items;
            }
            return null;
        }

        public List<TemplateItem> GetChildren(string id)
        {
            List<TemplateItem> result = new List<TemplateItem>();
            try
            {
                List<TemplateItem> listChildren = new List<TemplateItem>();

                listChildren = repository.FindChildren(id);              

                if (listChildren != null)
                {
                    foreach (TemplateItem item in listChildren)
                    {
                        result.Add(item);
                        if (item.TemplateItemId.Id == id) continue;

                        List<TemplateItem> children = null;
                        children = repository.FindChildren(item.TemplateItemId.Id);

                        if (children != null)
                        {
                            foreach (TemplateItem child in children)
                            {
                                if (!result.Contains(child)) result.Add(child);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public TemplateItem FindByParentAndName(string parentId, string name)
        {
            TemplateItem item = repository.FindByParentAndName(parentId, name);
            return item;
        }
    }
}
