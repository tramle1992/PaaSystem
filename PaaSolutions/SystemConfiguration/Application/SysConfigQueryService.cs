using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemConfiguration.Application.Data;
using SystemConfiguration.Infrastructure;

namespace SystemConfiguration.Application
{
    public class SysConfigQueryService
    {
        private readonly SysConfigRepository repository;

        public SysConfigQueryService()
        {
            this.repository = new SysConfigRepository();
        }

        public ConfigData Get(string id)
        {
            SystemConfiguration.Domain.Model.Config config = this.repository.Find(id);
            ConfigData configData = null;
            if (config != null && !string.IsNullOrEmpty(config.ConfigId.Id))
            {
                configData = AutoMapper.Mapper.Map<SystemConfiguration.Domain.Model.Config, ConfigData>(config);
            }
            return configData;
        }
    }
}
