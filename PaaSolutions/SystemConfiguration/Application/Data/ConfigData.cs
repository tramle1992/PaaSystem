using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemConfiguration.Application.Data
{
    public class ConfigData
    {
        public string ConfigId { get; set; }

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

        public ConfigData()
        {
        }
    }
}
