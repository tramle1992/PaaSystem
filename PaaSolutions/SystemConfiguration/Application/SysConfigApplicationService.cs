using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemConfiguration.Application.Command;
using SystemConfiguration.Application.Data;
using SystemConfiguration.Infrastructure;

namespace SystemConfiguration.Application
{
    public class SysConfigApplicationService
    {
        private readonly SysConfigRepository repository;

        public SysConfigApplicationService()
        {
            this.repository = new SysConfigRepository();
        }

        public string NewConfig(NewConfigCommand command)
        {
            ConfigData configData = command.ConfigData;
            SystemConfiguration.Domain.Model.Config config = AutoMapper.Mapper.Map<ConfigData, SystemConfiguration.Domain.Model.Config>(configData);
            this.repository.Add(config);
            return config.ConfigId.Id;
        }

        public void SaveConfig(SaveConfigCommand command)
        {
            ConfigData configData = command.ConfigData;
            SystemConfiguration.Domain.Model.Config config = AutoMapper.Mapper.Map<ConfigData, SystemConfiguration.Domain.Model.Config>(configData);
            this.repository.Update(config);
        }

        public void RemoveConfig(RemoveConfigCommand command)
        {
            this.repository.Remove(command.ConfigId);
        }
    }
}
