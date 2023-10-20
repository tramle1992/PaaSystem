using Administration.Domain.Model.InternetTool;
using Administration.Infrastructure.InternetTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application
{
    public class InternetToolQueryService
    {
        readonly InternetToolRepository repository;

        public InternetToolQueryService()
        {
            repository = new InternetToolRepository();
        }

        public InternetItem GetById(string id)
        {
            InternetItem item = repository.Find(id);
            return item;
        }

        public IList<InternetItem> GetAll()
        {
            IList<InternetItem> items = repository.FindAll();
            if (items.Count > 0)
            {
                return items;
            }
            return null;
        }

        public int GetMaxOrder()
        {
            return repository.FindMaxOrder();
        }

        public int GetItemCount()
        {
            return repository.GetItemCount();
        }
    }
}
