using Administration.Application.Command.StandardTemplate;
using Administration.Domain.Model.StandardTemplate;
using Administration.Infrastructure.StandardTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application
{
    public class StandardTemplateApplicationService
    {
        readonly StandardTemplateRepository repository;

        public StandardTemplateApplicationService()
        {
            repository = new StandardTemplateRepository();
        }

        public string NewTemplateItem(NewTemplateItemCommand command)
        {
            TemplateItem item = new TemplateItem();
            TemplateItemId templateItemId = new TemplateItemId(Guid.NewGuid().ToString());
            item.TemplateItemId = templateItemId;
            item.ParentId = command.ParentId;
            item.Name = command.Name;
            item.Caption = command.Caption;
            item.Index = command.Index;
            repository.Add(item);
            return item.TemplateItemId.Id;
        }

        public void SaveTemplateItem(SaveTemplateItemCommand command)
        {
            TemplateItem item = new TemplateItem();
            item = repository.Find(command.TemplateItemId);
            if (item != null)
            {
                item.ParentId = new TemplateItemId(command.ParentId);
                item.Name = command.Name;
                item.Caption = command.Caption;
                item.Index = command.Index;
                repository.Update(item);
            }
        }

        public void RemoveTemplateItem(RemoveTemplateItemCommand command)
        {
            TemplateItem item = new TemplateItem();
            item = repository.Find(command.TemplateItemId);
            if (item != null)
            {
                repository.Remove(command.TemplateItemId);
            }
        }

        public void RemoveMultiTemplateItem(RemoveMultiTemplateItemCommand commandList)
        {
            foreach (RemoveTemplateItemCommand command in commandList.CommandList)
            {
                RemoveTemplateItem(command);
            }
        }
    }
}
