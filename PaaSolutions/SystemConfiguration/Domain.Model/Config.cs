using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemConfiguration.Domain.Model
{
    public class Config : EntityWithCompositeId
    {
        public ConfigId ConfigId { get; private set; }

        public string BackupLocation { get; set; }

        public TimeSpan BackupTime { get; set; }

        public bool BackupEnabled { get; set; }

        public TimeSpan WorkingHourFrom { get; set; }

        public TimeSpan WorkingHourTo { get; set; }

        public short NumberAppsBonus { get; set; }

        public string BillingEmailConfirmation { get; set; }

        public string FtpUri { get; set; }

        public string FtpUsername { get; set; }

        public string FtpPassword { get; set; }

        public int AutoSaveTimeInterval { get; set; }

        public Config()
        {
        }

        public Config(ConfigId configId)
            : this()
        {
            this.ConfigId = configId;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.ConfigId;
        }

        public override string ToString()
        {
            return "Config[configId=" + this.ConfigId + "]";
        }
    }
}
