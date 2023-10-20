using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeCard.Domain.Model;
using TimeCard.Application.Data;

namespace TimeCard.Application.AutoMap
{
    public class TimeCardItemMapping : AutoMapper.Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TimeCardItemId, string>()
               .ConvertUsing(r => (r.Id == null ? string.Empty : r.Id));
            Mapper.CreateMap<TimeCardDateId, string>()
                .ConvertUsing(r => (r.Id == null ? string.Empty : r.Id));

            Mapper.CreateMap<TimeCardItem, TimeCardItemData>();
            Mapper.CreateMap<TimeCardDate, TimeCardDateData>();
            Mapper.CreateMap<TimeCardType, TimeCardTypeData>();

            Mapper.CreateMap<string, TimeCardItemId>()
                .ConvertUsing(r => (string.IsNullOrEmpty(r) ? null : new TimeCardItemId(r)));
            Mapper.CreateMap<string, TimeCardDateId>()
                .ConvertUsing(r => (string.IsNullOrEmpty(r) ? null : new TimeCardDateId(r)));
            Mapper.CreateMap<TimeCardTypeData, TimeCardType>()
                .ConvertUsing(s => (TimeCardType.CreateInstance(s.Value)));
            Mapper.CreateMap<TimeCardDateData, TimeCardDate>();

            Mapper.CreateMap<TimeCardDateData, TimeCardDateData>();
            Mapper.CreateMap<TimeCardItemData, TimeCardItemData>();

            base.Configure();
        }
    }
}
