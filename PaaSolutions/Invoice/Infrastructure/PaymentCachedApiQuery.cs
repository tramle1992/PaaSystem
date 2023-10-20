using Common.Infrastructure.Cache;
using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure
{
    public class PaymentCachedApiQuery
    {
        private PaymentApiRepository repository = new PaymentApiRepository();

        private static readonly PaymentCachedApiQuery instance = new PaymentCachedApiQuery();

        private const string KEY_PAYMENTS_BY_INVOICE_ID = "PAYMENTS_BY_INVOICE_ID";

        public static PaymentCachedApiQuery Instance
        {
            get { return instance; }
        }

        static PaymentCachedApiQuery()
        {
        }

        public List<PaymentData> GetPaymentsByInvoiceId(string invoiceId)
        {
            TypedObjectCache<List<PaymentData>> cacheList = TypedObjectCache<List<PaymentData>>.Instance;

            string cacheListKey = KEY_PAYMENTS_BY_INVOICE_ID + "_" + invoiceId;
            List<PaymentData> cacheListValue = null;

            if (cacheList.TryGet(cacheListKey, out cacheListValue))
            {
                return cacheListValue;
            }

            List<PaymentData> payments = (List<PaymentData>)repository.FindByInvoiceId(invoiceId);
            cacheList.Set(cacheListKey, payments);
            return payments;
        }

        public PaymentData GetPayment(string id)
        {
            TypedObjectCache<PaymentData> cacheItems = TypedObjectCache<PaymentData>.Instance;
            PaymentData payment = null;
            if (!cacheItems.TryGet(id, out payment))
            {
                payment = repository.Find(id);
                cacheItems.Set(id, payment);
            }
            return payment;
        }

        public void RemovePaymentsByInvoiceId(string invoiceId)
        {
            TypedObjectCache<List<PaymentData>> cacheList = TypedObjectCache<List<PaymentData>>.Instance;
            string cacheListKey = KEY_PAYMENTS_BY_INVOICE_ID + "_" + invoiceId;
            cacheList.Remove(cacheListKey);
        }

        public void RemovePayment(string id)
        {
            TypedObjectCache<PaymentData> cacheItems = TypedObjectCache<PaymentData>.Instance;
            cacheItems.Remove(id);
        }
    }
}
