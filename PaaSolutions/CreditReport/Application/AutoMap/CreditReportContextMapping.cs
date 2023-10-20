using CreditReport.Application.Data;
using CreditReport.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditReport.Application.AutoMap
{
    public class CreditReportContextMapping : AutoMapper.Profile
    {
        public CreditReportContextMapping()
        {
            CreateMap<Report, ReportData>();
            CreateMap<Report, ReportLightweightData>();
        }
    }
}
