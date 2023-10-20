using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain.Model.ExploreApps;
using Core.Domain.Model.ClientInfo;
using Core.Application.Data.ExploreApps;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.CreditReports;

namespace Core.Application.AutoMap
{

    public class CoreContextMapping : AutoMapper.Profile
    {
        public CoreContextMapping()
        {
            CreateMap<string, string>().ConvertUsing(s => s ?? string.Empty);
            CreateMap<CreditInfo, CreditInfoData>();
            CreateMap<CreditRef, CreditRefData>();
            CreateMap<EmpVer, EmpVerData>();
            CreateMap<EmpRef, EmpRefData>();
            CreateMap<RentalRef, RentalRefData>();
            CreateMap<ChargeRef, ChargeRefData>();
            CreateMap<EvictionRef, EvictionRefData>();
            CreateMap<RecommendationFactInfo, RecommendationFactInfoData>();
            CreateMap<PriorityApp, PriorityAppData>();
            CreateMap<ContactAttemptType, ContactAttemptTypeData>();
            CreateMap<ContactAttempt, ContactAttemptData>();
            CreateMap<Location, LocationData>();
            CreateMap<Screener, ScreenerData>();
            CreateMap<AppId, string>()
                .ConvertUsing(r => r.Id);
            CreateMap<App, AppData>()
                .ForMember(d => d.ApplicationId, o => o.MapFrom(s => (s.ApplicationId == null) ? string.Empty : s.ApplicationId.Id))
                .ForMember(d => d.ReportTypeId, o => o.MapFrom(s => (s.ReportTypeId == null) ? string.Empty : s.ReportTypeId.Id))
                .ForMember(d => d.LocationId, o => o.MapFrom(s => (s.Location == null) ? string.Empty : s.Location.LocationId))
                .ForMember(d => d.LocationName, o => o.MapFrom(s => (s.Location == null) ? string.Empty : s.Location.LocationName))
                .ForMember(d => d.ScreenerId, o => o.MapFrom(s => (s.Screener == null) ? string.Empty : s.Screener.ScreenerId))
                .ForMember(d => d.ScreenerName, o => o.MapFrom(s => (s.Screener == null) ? string.Empty : s.Screener.ScreenerName));
            CreateMap<Client, AppData>()
                .ForMember(d => d.ClientApplied, o => o.MapFrom(s => (s.ClientId == null) ? string.Empty : s.ClientId.Id))
                .ForMember(d => d.ClientAppliedName, o => o.MapFrom(s => s.ClientName));



            CreateMap<CreditInfoData, CreditInfo>();
            CreateMap<CreditRefData, CreditRef>();
            CreateMap<EmpVerData, EmpVer>();
            CreateMap<EmpRefData, EmpRef>();
            CreateMap<RentalRefData, RentalRef>();
            CreateMap<ChargeRefData, ChargeRef>();
            CreateMap<EvictionRefData, EvictionRef>();
            CreateMap<RecommendationFactInfoData, RecommendationFactInfo>();
            CreateMap<PriorityAppData, PriorityApp>()
                .ConvertUsing(s =>
                {
                    if (s == null)
                        return PriorityApp.CreateInstance(0);
                    else
                        return PriorityApp.CreateInstance(s.Value);
                });

            CreateMap<ContactAttemptTypeData, ContactAttemptType>()
                .ConvertUsing(s =>
                {
                    if (s == null)
                        return ContactAttemptType.CreateInstance(0);
                    else
                        return ContactAttemptType.CreateInstance(s.Value);
                });
            CreateMap<ContactAttemptData, ContactAttempt>();

            CreateMap<LocationData, Location>();
            CreateMap<ScreenerData, Screener>();
            CreateMap<string, AppId>()
                .ConvertUsing(r => new AppId(r));
            CreateMap<AppData, App>()
                .ForMember(d => d.ReportTypeId, o => o.MapFrom(s => string.IsNullOrEmpty(s.ReportTypeId) ? null : new ReportTypeId(s.ReportTypeId)))
                .ForMember(d => d.ClientApplied, o => o.MapFrom(s => string.IsNullOrEmpty(s.ClientApplied) ? null : new ClientId(s.ClientApplied)))
                .ForMember(d => d.Location, o => o.MapFrom(s => string.IsNullOrEmpty(s.LocationId) ? null : new Location(s.LocationId, s.LocationName)))
                .ForMember(d => d.ClientName, o => o.MapFrom(s => string.IsNullOrEmpty(s.ClientName) ? null : s.ClientName))
            .ForMember(d => d.Screener, o => o.MapFrom(s => string.IsNullOrEmpty(s.ScreenerId) ? null : new Screener(s.ScreenerId, s.ScreenerName)));
        }
    }
}
