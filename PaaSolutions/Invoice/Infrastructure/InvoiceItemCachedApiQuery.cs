using Common.Infrastructure.Cache;
using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure
{
    public class InvoiceItemCachedApiQuery
    {
        private InvoiceItemApiRepository repository = new InvoiceItemApiRepository();

        private static readonly InvoiceItemCachedApiQuery instance = new InvoiceItemCachedApiQuery();

        private const string KEY_INVOICE_ITEMS_BY_INVOICE_ID = "INVOICE_ITEMS_BY_INVOICE_ID";

        public static InvoiceItemCachedApiQuery Instance
        {
            get { return instance; }
        }

        static InvoiceItemCachedApiQuery()
        {
        }

        public List<InvoiceItemData> GetInvoiceItemsByInvoiceId(string invoiceId)
        {
            TypedObjectCache<List<InvoiceItemData>> cacheList = TypedObjectCache<List<InvoiceItemData>>.Instance;

            string cacheListKey = KEY_INVOICE_ITEMS_BY_INVOICE_ID + "_" + invoiceId;
            List<InvoiceItemData> cacheListValue = null;

            if (cacheList.TryGet(cacheListKey, out cacheListValue))
            {
                return cacheListValue;
            }

            List<InvoiceItemData> invoiceItems = (List<InvoiceItemData>)repository.FindByInvoiceId(invoiceId);
            cacheList.Set(cacheListKey, invoiceItems);
            return invoiceItems;
        }

        public InvoiceItemData GetInvoiceItem(string id)
        {
            TypedObjectCache<InvoiceItemData> cacheItems = TypedObjectCache<InvoiceItemData>.Instance;
            InvoiceItemData invoiceItem = null;
            if (!cacheItems.TryGet(id, out invoiceItem))
            {
                invoiceItem = repository.Find(id);
                cacheItems.Set(id, invoiceItem);
            }
            return invoiceItem;
        }

        public void RemoveInvoiceItemsByInvoiceId(string invoiceId)
        {
            TypedObjectCache<List<InvoiceItemData>> cacheList = TypedObjectCache<List<InvoiceItemData>>.Instance;
            string cacheListKey = KEY_INVOICE_ITEMS_BY_INVOICE_ID + "_" + invoiceId;
            cacheList.Remove(cacheListKey);
        }

        public void RemoveInvoiceItem(string id)
        {
            TypedObjectCache<InvoiceItemData> cacheItems = TypedObjectCache<InvoiceItemData>.Instance;
            cacheItems.Remove(id);
        }
    }
}
