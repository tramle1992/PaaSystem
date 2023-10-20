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
    public class InvoiceItemQueryService
    {
        private readonly InvoiceItemRepository repository;

        public InvoiceItemQueryService()
        {
            this.repository = new InvoiceItemRepository();
        }

        public InvoiceItemData Get(string id)
        {
            InvoiceItem invoiceItem = this.repository.Find(id);
            InvoiceItemData invoiceItemData = null;
            if (invoiceItem != null && !string.IsNullOrEmpty(invoiceItem.InvoiceItemId.Id))
            {
                invoiceItemData = AutoMapper.Mapper.Map<InvoiceItem, InvoiceItemData>(invoiceItem);
            }
            return invoiceItemData;
        }

        public List<InvoiceItemData> GetByInvoiceId(string invoiceId)
        {
            List<InvoiceItem> invoiceItemList = this.repository.FindByInvoiceId(invoiceId);
            List<InvoiceItemData> invoiceItemDataList = new List<InvoiceItemData>();
            if (invoiceItemList != null && invoiceItemList.Count > 0)
            {
                foreach (InvoiceItem invoiceItem in invoiceItemList)
                {
                    if (invoiceItem != null && !string.IsNullOrEmpty(invoiceItem.InvoiceItemId.Id))
                    {
                        InvoiceItemData invoiceItemData = AutoMapper.Mapper.Map<InvoiceItem, InvoiceItemData>(invoiceItem);
                        invoiceItemDataList.Add(invoiceItemData);
                    }
                }
            }
            return invoiceItemDataList;
        }

        public List<InvoiceItemData> GetAll()
        {
            List<InvoiceItem> invoiceItemList = this.repository.FindAll();
            List<InvoiceItemData> invoiceItemDataList = null;
            if (invoiceItemList != null && invoiceItemList.Count > 0)
            {
                invoiceItemDataList = new List<InvoiceItemData>(invoiceItemList.Count);
                foreach (InvoiceItem invoiceItem in invoiceItemList)
                {
                    if (invoiceItem != null && !string.IsNullOrEmpty(invoiceItem.InvoiceItemId.Id))
                    {
                        InvoiceItemData invoiceItemData = AutoMapper.Mapper.Map<InvoiceItem, InvoiceItemData>(invoiceItem);
                        invoiceItemDataList.Add(invoiceItemData);
                    }
                }
            }
            return invoiceItemDataList;
        }
    }
}
