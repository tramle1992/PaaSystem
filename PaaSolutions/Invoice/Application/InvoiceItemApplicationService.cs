using Invoice.Application.Command;
using Invoice.Application.Data;
using Invoice.Domain.Model;
using Invoice.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application
{
    public class InvoiceItemApplicationService
    {
        private readonly InvoiceItemRepository repository;

        public InvoiceItemApplicationService()
        {
            this.repository = new InvoiceItemRepository();
        }

        public string NewInvoiceItem(NewInvoiceItemCommand command)
        {
            InvoiceItemData invoiceItemData = command.InvoiceItemData;
            InvoiceItem invoiceItem = AutoMapper.Mapper.Map<InvoiceItemData, InvoiceItem>(invoiceItemData);
            this.repository.Add(invoiceItem);
            return invoiceItem.InvoiceItemId.Id;
        }

        public void MultiNewInvoiceItem(MultiNewInvoiceItemCommand commandList)
        {
            foreach (NewInvoiceItemCommand command in commandList.CommandList)
            {
                NewInvoiceItem(command);
            }
        }

        public void SaveInvoiceItem(SaveInvoiceItemCommand command)
        {
            InvoiceItemData invoiceItemData = command.InvoiceItemData;
            InvoiceItem invoiceItem = AutoMapper.Mapper.Map<InvoiceItemData, InvoiceItem>(invoiceItemData);
            this.repository.Update(invoiceItem);
        }

        public void RemoveInvoiceItem(RemoveInvoiceItemCommand command)
        {
            this.repository.Remove(command.InvoiceItemId);
        }

        public void RemoveInvoiceItemByInvoiceId(RemoveInvoiceItemByInvoiceIdCommand command)
        {
            this.repository.RemoveByInvoiceId(command.InvoiceId);
        }

        public void MultiRemoveInvoiceItem(MultiRemoveInvoiceItemCommand commandList)
        {
            foreach (RemoveInvoiceItemCommand command in commandList.CommandList)
            {
                RemoveInvoiceItem(command);
            }
        }

        public void MultiRemoveInvoiceItemByInvoiceId(MultiRemoveInvoiceItemByInvoiceIdCommand commandList)
        {
            foreach (RemoveInvoiceItemByInvoiceIdCommand command in commandList.CommandList)
            {
                RemoveInvoiceItemByInvoiceId(command);
            }
        }
    }
}
