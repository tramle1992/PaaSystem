using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemConfiguration.Application.Data;

namespace SystemConfiguration.Application.AutoMap
{
    public class SysConfigContextMapping : AutoMapper.Profile
    {
        public SysConfigContextMapping()
        {
            CreateMap<string, string>().ConvertUsing(s => s ?? string.Empty);

            CreateMap<SystemConfiguration.Domain.Model.ConfigId, string>()
                .ConvertUsing(r => (r.Id == null ? string.Empty : r.Id));
            CreateMap<SystemConfiguration.Domain.Model.Config, ConfigData>();

            CreateMap<string, SystemConfiguration.Domain.Model.ConfigId>()
                .ConvertUsing(r => (string.IsNullOrEmpty(r) ? null : new SystemConfiguration.Domain.Model.ConfigId(r)));
            CreateMap<ConfigData, SystemConfiguration.Domain.Model.Config>();

            // Copy
            CreateMap<ConfigData, ConfigData>();
        }
    }
}
