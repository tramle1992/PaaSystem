using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeCard.Data;
using TimeCard.Domain.Model;

namespace TimeCard.AutoMap
{
    public class TimeCardItemMapping : AutoMapper.Profile
    {
        public TimeCardItemMapping()
        {
            CreateMap<TimeCardItemId, string>()
               .ConvertUsing(r => (r.Id == null ? string.Empty : r.Id));
            CreateMap<TimeCardDateId, string>()
                .ConvertUsing(r => (r.Id == null ? string.Empty : r.Id));

            CreateMap<TimeCardItem, TimeCardItemData>();
            CreateMap<TimeCardDate, TimeCardDateData>();
            CreateMap<TimeCardType, TimeCardTypeData>();

            CreateMap<string, TimeCardItemId>()
                .ConvertUsing(r => (string.IsNullOrEmpty(r) ? null : new TimeCardItemId(r)));
            CreateMap<string, TimeCardDateId>()
                .ConvertUsing(r => (string.IsNullOrEmpty(r) ? null : new TimeCardDateId(r)));
            CreateMap<TimeCardTypeData, TimeCardType>()
                .ConvertUsing(s => (TimeCardType.CreateInstance(s.Value)));
            CreateMap<TimeCardDateData, TimeCardDate>();

            CreateMap<TimeCardDateData, TimeCardDateData>();
            CreateMap<TimeCardItemData, TimeCardItemData>();
        }
    }
}
