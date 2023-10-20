using AutoMapper;
using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.AutoMap
{
    public class InvoiceContextMapping : AutoMapper.Profile
    {
        public InvoiceContextMapping()
        {
            CreateMap<string, string>().ConvertUsing(s => s ?? string.Empty);

            CreateMap<Invoice.Domain.Model.InvoiceId, string>()
                .ConvertUsing(r => (r.Id == null ? string.Empty : r.Id));
            CreateMap<Invoice.Domain.Model.InvoiceItemId, string>()
                .ConvertUsing(r => (r.Id == null ? string.Empty : r.Id));
            CreateMap<Invoice.Domain.Model.PaymentId, string>()
                .ConvertUsing(r => (r.Id == null ? string.Empty : r.Id));
            CreateMap<Invoice.Domain.Model.Status, StatusData>();
            CreateMap<Invoice.Domain.Model.ActionStatus, ActionStatusData>();
            CreateMap<Invoice.Domain.Model.Invoice, InvoiceData>();
            CreateMap<Invoice.Domain.Model.InvoiceItem, InvoiceItemData>();
            CreateMap<Invoice.Domain.Model.Payment, PaymentData>();

            CreateMap<string, Invoice.Domain.Model.InvoiceId>()
                .ConvertUsing(r => (string.IsNullOrEmpty(r) ? null : new Invoice.Domain.Model.InvoiceId(r)));
            CreateMap<string, Invoice.Domain.Model.InvoiceItemId>()
                .ConvertUsing(r => (string.IsNullOrEmpty(r) ? null : new Invoice.Domain.Model.InvoiceItemId(r)));
            CreateMap<string, Invoice.Domain.Model.PaymentId>()
                .ConvertUsing(r => (string.IsNullOrEmpty(r) ? null : new Invoice.Domain.Model.PaymentId(r)));
            CreateMap<StatusData, Invoice.Domain.Model.Status>()
                .ConvertUsing(s =>
                {
                    if (s == null)
                    {
                        return Invoice.Domain.Model.Status.CreateInstance(2);
                    }
                    else
                    {
                        return Invoice.Domain.Model.Status.CreateInstance(s.Value);
                    }
                });
            CreateMap<ActionStatusData, Invoice.Domain.Model.ActionStatus>()
                .ConvertUsing(s =>
                {
                    if (s == null)
                    {
                        return Invoice.Domain.Model.ActionStatus.CreateInstance(0);
                    }
                    else
                    {
                        return Invoice.Domain.Model.ActionStatus.CreateInstance(s.Value);
                    }
                });
            CreateMap<InvoiceData, Invoice.Domain.Model.Invoice>();
            CreateMap<InvoiceItemData, Invoice.Domain.Model.InvoiceItem>();
            CreateMap<PaymentData, Invoice.Domain.Model.Payment>();

            // Copy
            CreateMap<StatusData, StatusData>();
            CreateMap<ActionStatusData, ActionStatusData>();
            CreateMap<InvoiceData, InvoiceData>();
            CreateMap<InvoiceItemData, InvoiceItemData>();
            CreateMap<PaymentData, PaymentData>();
        }
    }
}
