using Core.Application.Data.ExploreApps;
using Core.Domain.Model.ExploreApps;
using Invoice.Application.Command;
using Invoice.Application.Data;
using Invoice.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application
{
    public class InvoiceQueryService
    {
        private readonly InvoiceRepository repository;

        public InvoiceQueryService()
        {
            this.repository = new InvoiceRepository();
        }

        public InvoiceData Get(string id)
        {
            Invoice.Domain.Model.Invoice invoice = this.repository.Find(id);
            InvoiceData invoiceData = null;
            if (invoice != null && !string.IsNullOrEmpty(invoice.InvoiceId.Id))
            {
                invoiceData = AutoMapper.Mapper.Map<Invoice.Domain.Model.Invoice, InvoiceData>(invoice);
            }
            return invoiceData;
        }

        public List<InvoiceData> GetAll()
        {
            List<Invoice.Domain.Model.Invoice> invoiceList = this.repository.FindAll();
            List<InvoiceData> invoiceDataList = null;
            if (invoiceList != null && invoiceList.Count > 0)
            {
                invoiceDataList = new List<InvoiceData>(invoiceList.Count);
                foreach (Invoice.Domain.Model.Invoice invoice in invoiceList)
                {
                    if (invoice != null && !string.IsNullOrEmpty(invoice.InvoiceId.Id))
                    {
                        InvoiceData invoiceData = AutoMapper.Mapper.Map<Invoice.Domain.Model.Invoice, InvoiceData>(invoice);
                        invoiceDataList.Add(invoiceData);
                    }
                }
            }
            return invoiceDataList;
        }

        public List<InvoiceData> GetByYearAndMonth(int year, int month, string timezone)
        {
            List<Invoice.Domain.Model.Invoice> invoiceList = this.repository.FindByYearAndMonth(year, month, timezone);
            List<InvoiceData> invoiceDataList = new List<InvoiceData>();
            if (invoiceList != null && invoiceList.Count > 0)
            {
                foreach (Invoice.Domain.Model.Invoice invoice in invoiceList)
                {
                    if (invoice != null && !string.IsNullOrEmpty(invoice.InvoiceId.Id))
                    {
                        InvoiceData invoiceData = AutoMapper.Mapper.Map<Invoice.Domain.Model.Invoice, InvoiceData>(invoice);
                        invoiceDataList.Add(invoiceData);
                    }
                }
            }
            return invoiceDataList;
        }

        public DateTime GetMaxInvoiceDate()
        {
            return this.repository.FindMaxInvoiceDate();
        }

        public int GetMaxInvoiceNumberByYearAndMonth(int year, int month, string timezone)
        {
            return this.repository.FindMaxInvoiceNumberByYearAndMonth(year, month, timezone);
        }

        public int GetInvoiceCountByYearAndMonth(int year, int month, string timezone)
        {
            return this.repository.FindInvoiceCountByYearAndMonth(year, month, timezone);
        }

        public List<InvoiceData> SearchInvoice(SearchInvoiceCommand command)
        {
            List<Invoice.Domain.Model.Invoice> invoiceList = this.repository.SearchInvoice(command);
            List<InvoiceData> invoiceDataList = new List<InvoiceData>();
            if (invoiceList != null && invoiceList.Count > 0)
            {
                foreach (Invoice.Domain.Model.Invoice invoice in invoiceList)
                {
                    if (invoice != null && !string.IsNullOrEmpty(invoice.InvoiceId.Id))
                    {
                        InvoiceData invoiceData = AutoMapper.Mapper.Map<Invoice.Domain.Model.Invoice, InvoiceData>(invoice);
                        invoiceDataList.Add(invoiceData);
                    }
                }
            }
            return invoiceDataList;
        }

        public BillingValidationStatsData GetBillingValidationStats(int year, int month, string timezone)
        {
            return this.repository.FindBillingValidationStats(year, month, timezone);
        }

    }
}
