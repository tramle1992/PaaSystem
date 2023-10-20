using AutoMapper;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.CreditReports;
using Core.Application.Data.ExploreApps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.AutoMap
{
    public class CopyContextMapping : AutoMapper.Profile
    {
        public CopyContextMapping()
        {
            CreateMap<CreditInfoData, CreditInfoData>();
            CreateMap<CreditRefData, CreditRefData>();
            CreateMap<EmpVerData, EmpVerData>();
            CreateMap<EmpRefData, EmpRefData>();
            CreateMap<RentalRefData, RentalRefData>();
            CreateMap<ChargeRefData, ChargeRefData>();
            CreateMap<EvictionRefData, EvictionRefData>();
            CreateMap<RecommendationFactInfoData, RecommendationFactInfoData>();
            CreateMap<PriorityAppData, PriorityAppData>();
            CreateMap<ContactAttemptData, ContactAttemptData>();
            CreateMap<AppData, AppData>()
                .ForMember(d => d.CreditRefs, o => o.MapFrom(s => Mapper.Map<List<CreditRefData>, List<CreditRefData>>(s.CreditRefs)))
                .ForMember(d => d.EmpRefs, o => o.MapFrom(s => Mapper.Map<List<EmpRefData>, List<EmpRefData>>(s.EmpRefs)))
                .ForMember(d => d.RentalRefs, o => o.MapFrom(s => Mapper.Map<List<RentalRefData>, List<RentalRefData>>(s.RentalRefs)))
                .ForMember(d => d.Charges, o => o.MapFrom(s => Mapper.Map<List<ChargeRefData>, List<ChargeRefData>>(s.Charges)))
                .ForMember(d => d.Evictions, o => o.MapFrom(s => Mapper.Map<List<EvictionRefData>, List<EvictionRefData>>(s.Evictions)))
                .ForMember(d => d.ContactAttempts, o => o.MapFrom(s => Mapper.Map<List<ContactAttemptData>, List<ContactAttemptData>>(s.ContactAttempts)));
            CreateMap<CreditReportData, CreditReportData>();
        }
    }
}
