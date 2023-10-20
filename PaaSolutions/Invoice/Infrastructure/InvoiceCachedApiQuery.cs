using Common.Infrastructure.Cache;
using Invoice.Application.Data;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure
{
    public class InvoiceCachedApiQuery
    {
        private InvoiceApiRepository repository = new InvoiceApiRepository();

        private static readonly InvoiceCachedApiQuery instance = new InvoiceCachedApiQuery();

        private const string KEY_INVOICES_BY_YEAR_AND_MONTH = "INVOICES_BY_YEAR_AND_MONTH";

        public static InvoiceCachedApiQuery Instance
        {
            get { return instance; }
        }

        static InvoiceCachedApiQuery()
        {
        }

        public List<InvoiceData> GetInvoicesByYearAndMonth(int year, int month)
        {

            TypedObjectCache<List<InvoiceData>> cacheList = TypedObjectCache<List<InvoiceData>>.Instance;

            string cacheListKey = KEY_INVOICES_BY_YEAR_AND_MONTH + "_" + year + "_" + month;
            List<InvoiceData> cacheListValue = null;

            if (cacheList.TryGet(cacheListKey, out cacheListValue))
            {
                return cacheListValue;
            }

            DateTimeZone tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();
            List<InvoiceData> invoices = (List<InvoiceData>)repository.FindByYearAndMonth(year, month, tz.Id);
            cacheList.Set(cacheListKey, invoices);
            return invoices;
        }

        //public InvoiceData GetInvoice(string id)
        //{
        //    TypedObjectCache<InvoiceData> cacheItems = TypedObjectCache<InvoiceData>.Instance;
        //    InvoiceData invoice = null;
        //    if (!cacheItems.TryGet(id, out invoice))
        //    {
        //        invoice = repository.Find(id);
        //        cacheItems.Set(id, invoice);
        //    }
        //    return invoice;
        //}

        public void RemoveInvoicesByYearAndMonth(int year, int month)
        {
            TypedObjectCache<List<InvoiceData>> cacheList = TypedObjectCache<List<InvoiceData>>.Instance;
            string cacheListKey = KEY_INVOICES_BY_YEAR_AND_MONTH + "_" + year + "_" + month;
            cacheList.Remove(cacheListKey);
        }

        //public void RemoveInvoice(string id)
        //{
        //    TypedObjectCache<InvoiceData> cacheItems = TypedObjectCache<InvoiceData>.Instance;
        //    cacheItems.Remove(id);
        //}
    }
}
