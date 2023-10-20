using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Application.AutoMap;
using Invoice.Application.AutoMap;
using TimeCard.AutoMap;
using ZipCodeContext.Application.AutoMap;
using SystemConfiguration.Application.AutoMap;
using CreditReport.Application.AutoMap;

namespace PaaApi
{
    public class AutoMapperConfig
    {
        public static void RegisterMappers()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CoreContextMapping>();
                cfg.AddProfile<CopyContextMapping>();
                cfg.AddProfile<InvoiceContextMapping>();
                cfg.AddProfile<TimeCardItemMapping>();
                cfg.AddProfile<ZipCodeContextMapping>();
                cfg.AddProfile<SysConfigContextMapping>();
                cfg.AddProfile<CreditReportContextMapping>();
            });
        }
    }
}