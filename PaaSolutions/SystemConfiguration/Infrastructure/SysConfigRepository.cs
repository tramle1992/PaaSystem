using Common.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Common.Application;

namespace SystemConfiguration.Infrastructure
{
    public class SysConfigRepository : Repository<SystemConfiguration.Domain.Model.Config, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SysConfigRepository()
        {
        }

        public override void Add(Domain.Model.Config item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert system_configuration(config_id, backup_location" +
                        ", backup_time, backup_enabled, working_hour_from, working_hour_to, number_apps_bonus" +
                        ", billing_email_confirmation, ftp_uri, ftp_username, ftp_password, auto_save_time_interval)" +
                        " values (@config_id, @backup_location, @backup_time, @backup_enabled" +
                        ", @working_hour_from, @working_hour_to, @number_apps_bonus, @billing_email_confirmation" +
                        ", @ftp_uri, @ftp_username, @ftp_password, @auto_save_time_interval)";

                    var args = new DynamicParameters();
                    args.Add("config_id", item.ConfigId.Id);
                    args.Add("backup_location", item.BackupLocation);
                    args.Add("backup_time", item.BackupTime);
                    args.Add("backup_enabled", item.BackupEnabled);
                    args.Add("working_hour_from", item.WorkingHourFrom);
                    args.Add("working_hour_to", item.WorkingHourTo);
                    args.Add("number_apps_bonus", item.NumberAppsBonus);
                    args.Add("billing_email_confirmation", item.BillingEmailConfirmation);
                    args.Add("ftp_uri", item.FtpUri);
                    args.Add("ftp_username", item.FtpUsername);
                    args.Add("ftp_password", item.FtpPassword);
                    args.Add("auto_save_time_interval", item.AutoSaveTimeInterval);

                    cn.Execute(insertStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Remove(Domain.Model.Config item)
        {
            if (item == null || string.IsNullOrEmpty(item.ConfigId.Id)
                || item.ConfigId.Id.Equals(GlobalConstants.SYS_CONFIG_ID))
            {
                return;
            }

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from system_configuration where config_id = @config_id";

                    cn.Execute(deleteStatement, new { config_id = item.ConfigId.Id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void Remove(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Equals(GlobalConstants.SYS_CONFIG_ID))
            {
                return;
            }

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from system_configuration where config_id = @config_id";

                    cn.Execute(deleteStatement, new { config_id = id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Update(Domain.Model.Config item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update system_configuration set backup_location=@backup_location" +
                        ", backup_time=@backup_time, backup_enabled=@backup_enabled, working_hour_from=@working_hour_from" +
                        ", working_hour_to=@working_hour_to, number_apps_bonus=@number_apps_bonus" +
                        ", billing_email_confirmation=@billing_email_confirmation, ftp_uri=@ftp_uri" +
                        ", ftp_username=@ftp_username, ftp_password=@ftp_password, auto_save_time_interval=@auto_save_time_interval" +
                        " where config_id=@config_id";

                    var args = new DynamicParameters();
                    args.Add("config_id", item.ConfigId.Id);
                    args.Add("backup_location", item.BackupLocation);
                    args.Add("backup_time", item.BackupTime);
                    args.Add("backup_enabled", item.BackupEnabled);
                    args.Add("working_hour_from", item.WorkingHourFrom);
                    args.Add("working_hour_to", item.WorkingHourTo);
                    args.Add("number_apps_bonus", item.NumberAppsBonus);
                    args.Add("billing_email_confirmation", item.BillingEmailConfirmation);
                    args.Add("ftp_uri", item.FtpUri);
                    args.Add("ftp_username", item.FtpUsername);
                    args.Add("ftp_password", item.FtpPassword);
                    args.Add("auto_save_time_interval", item.AutoSaveTimeInterval);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override Domain.Model.Config Find(string id)
        {
            Domain.Model.Config config = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select config_id, backup_location, backup_time, backup_enabled" +
                        ", working_hour_from, working_hour_to, number_apps_bonus, billing_email_confirmation" +
                        ", ftp_uri, ftp_username, ftp_password, auto_save_time_interval" +
                        " from system_configuration where config_id=@config_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { config_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.config_id))
                    {
                        Domain.Model.ConfigId configId = new Domain.Model.ConfigId(item.config_id);
                        config = new Domain.Model.Config(configId);
                        config.BackupLocation = item.backup_location;
                        config.BackupTime = item.backup_time;
                        config.BackupEnabled = item.backup_enabled;
                        config.WorkingHourFrom = item.working_hour_from;
                        config.WorkingHourTo = item.working_hour_to;
                        config.NumberAppsBonus = item.number_apps_bonus;
                        config.BillingEmailConfirmation = item.billing_email_confirmation;
                        config.FtpUri = item.ftp_uri;
                        config.FtpUsername = item.ftp_username;
                        config.FtpPassword = item.ftp_password;
                        config.AutoSaveTimeInterval = item.auto_save_time_interval;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return config;
        }
    }
}
