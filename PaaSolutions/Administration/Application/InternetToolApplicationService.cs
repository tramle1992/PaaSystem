using Administration.Application.Command.InternetTool;
using Administration.Domain.Model.InternetTool;
using Administration.Infrastructure.InternetTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application
{
    public class InternetToolApplicationService
    {
        readonly InternetToolRepository repository;

        public InternetToolApplicationService()
        {
            repository = new InternetToolRepository();
        }

        public string NewInternetItem(NewInternetItemCommand command)
        {
            InternetItem item = new InternetItem();
            InternetItemId internetItemId = new InternetItemId(Guid.NewGuid().ToString());
            item.InternetItemId = internetItemId;
            item.Caption = command.Caption;
            item.Target = command.Target;
            item.Image = command.Image;
            item.Order = command.Order;
            repository.Add(item);
            return item.InternetItemId.Id;
        }

        public void SaveInternetItem(SaveInternetItemCommand command)
        {
            InternetItem item = new InternetItem();
            item = repository.Find(command.InternetItemId);
            if (item != null)
            {
                item.Caption = command.Caption;
                item.Target = command.Target;
                item.Image = command.Image;
                item.Order = command.Order;
                repository.Update(item);
            }
        }

        public void SaveMultiInternetItem(SaveMultiInternetItemCommand commandList)
        {
            foreach (SaveInternetItemCommand command in commandList.CommandList)
            {
                SaveInternetItem(command);
            }
        }

        public void RemoveInternetItem(string id)
        {
            repository.Remove(id);
        }
    }
}
