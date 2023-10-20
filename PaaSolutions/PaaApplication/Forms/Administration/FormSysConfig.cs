using Common.Application;
using Common.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemConfiguration.Application.Data;
using SystemConfiguration.Infrastructure;

namespace PaaApplication.Forms.Administration
{
    public partial class FormSysConfig : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SysConfigApiRepository apiRepository = new SysConfigApiRepository();

        private TimeSpan workingHoursFromLastValue;
        private TimeSpan workingHoursToLastValue;

        private bool loadCompleted = false;

        private FormMaster formMaster;

        public FormSysConfig(FormMaster formMaster)
        {
            InitializeComponent();
            this.formMaster = formMaster;
        }

        private void FormSysConfig_LoadCompleted(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    ConfigData config = formMaster.SYSTEM_CONFIG;
                    if (config != null && !string.IsNullOrEmpty(config.ConfigId))
                    {
                        this.chkEnableBackup.Checked = config.BackupEnabled;
                        this.dtmBackupTime.Value = DateTime.UtcNow.Date + config.BackupTime;
                        this.txtBackupLocation.Text = config.BackupLocation;

                        this.txtFtpUri.Text = config.FtpUri;
                        this.txtFtpUsername.Text = config.FtpUsername;
                        this.txtFtpPassword.Text = config.FtpPassword;

                        this.nudNumberAppsBonus.Value = (decimal)config.NumberAppsBonus;
                        workingHoursFromLastValue = config.WorkingHourFrom;
                        this.dtmWorkingHoursFrom.Value = DateTime.UtcNow.Date + config.WorkingHourFrom;
                        workingHoursToLastValue = config.WorkingHourTo;
                        this.dtmWorkingHoursTo.Value = DateTime.UtcNow.Date + config.WorkingHourTo;
                        this.nudAutoSaveTimeInterval.Value = (decimal)config.AutoSaveTimeInterval;
                        this.txtBillingEmailConfirmation.Text = config.BillingEmailConfirmation;
                    }
                    loadCompleted = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message);                
            }
        }

        private void UpdateSystemConfig()
        {
            if (!loadCompleted)
            {
                return;
            }

            ConfigData config = new ConfigData();
            config.ConfigId = GlobalConstants.SYS_CONFIG_ID;
            config.BackupEnabled = this.chkEnableBackup.Checked;
            config.BackupTime = this.dtmBackupTime.Value.TimeOfDay;
            this.txtBackupLocation.Text = NormalizeBackupLocation(this.txtBackupLocation.Text);
            config.BackupLocation = this.txtBackupLocation.Text;
            config.FtpUri = this.txtFtpUri.Text;
            config.FtpUsername = this.txtFtpUsername.Text;
            config.FtpPassword = this.txtFtpPassword.Text;
            config.NumberAppsBonus = (short)this.nudNumberAppsBonus.Value;
            workingHoursFromLastValue = this.dtmWorkingHoursFrom.Value.TimeOfDay;
            config.WorkingHourFrom = this.dtmWorkingHoursFrom.Value.TimeOfDay;
            workingHoursToLastValue = this.dtmWorkingHoursTo.Value.TimeOfDay;
            config.WorkingHourTo = this.dtmWorkingHoursTo.Value.TimeOfDay;
            config.AutoSaveTimeInterval = (int)this.nudAutoSaveTimeInterval.Value;
            config.BillingEmailConfirmation = this.txtBillingEmailConfirmation.Text;

            using (new HourGlass())
            {
                apiRepository.Update(config);
                formMaster.SYSTEM_CONFIG = config;
                formMaster.ResetHandlers();
            }
        }

        private string NormalizeBackupLocation(string value)
        {
            string backupLocation = value;
            while (backupLocation.LastIndexOf("\\") == backupLocation.Length - 1)
            {
                backupLocation = backupLocation.Substring(0, backupLocation.Length - 1);
            }
            return backupLocation;
        }

        private void btnSelectLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtBackupLocation.Text = folderBrowserDialog.SelectedPath;
                UpdateSystemConfig();
            }
        }

        private void chkEnableBackup_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null)
            {
                return;
            }

            if (cb.Checked)
            {
                this.dtmBackupTime.Enabled = true;
                this.txtBackupLocation.Enabled = true;
                this.btnSelectLocation.Enabled = true;
            }
            else
            {
                this.dtmBackupTime.Enabled = false;
                this.txtBackupLocation.Enabled = false;
                this.btnSelectLocation.Enabled = false;
            }
            UpdateSystemConfig();
        }

        private void formSysConfig_Validating(object sender, CancelEventArgs e)
        {
            UpdateSystemConfig();
        }

        private void formSysConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSystemConfig();
            }
        }

        private void dtmBackupTime_ValueChanged(object sender, EventArgs e)
        {
            UpdateSystemConfig();
        }

        private void nudNumberAppsBonus_ValueChanged(object sender, EventArgs e)
        {
            UpdateSystemConfig();
        }

        private void dtmWorkingHoursFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime newValue = RoundToNearestQuarterMinute(sender, this.dtmWorkingHoursFrom.Value);
            this.dtmWorkingHoursFrom.Value = newValue;
            if (newValue.Hour != workingHoursFromLastValue.Hours
                || newValue.Minute != workingHoursFromLastValue.Minutes)
            {
                UpdateSystemConfig();
            }
        }

        private void dtmWorkingHoursTo_ValueChanged(object sender, EventArgs e)
        {
            DateTime newValue = RoundToNearestQuarterMinute(sender, this.dtmWorkingHoursTo.Value);
            this.dtmWorkingHoursTo.Value = newValue;
            if (newValue.Hour != workingHoursToLastValue.Hours
                || newValue.Minute != workingHoursToLastValue.Minutes)
            {
                UpdateSystemConfig();
            }
        }

        private void nudAutoSaveTimeInterval_ValueChanged(object sender, EventArgs e)
        {
            UpdateSystemConfig();
        }

        private DateTime RoundToNearestQuarterMinute(object sender, DateTime time)
        {
            bool change = false;
            bool increase = false;
            int minute = time.Minute;
            int lastMinute;

            DateTimePicker dtm = sender as DateTimePicker;
            if (dtm == this.dtmWorkingHoursFrom)
            {
                lastMinute = workingHoursFromLastValue.Minutes;
            }
            else if (dtm == this.dtmWorkingHoursTo)
            {
                lastMinute = workingHoursToLastValue.Minutes;
            }
            else
            {
                return time;
            }

            if (minute != lastMinute && minute == 59 && lastMinute == 0)
            {
                change = false;
            }
            else if (minute > lastMinute)
            {
                change = true;
                increase = true;
            }
            else if (minute < lastMinute)
            {
                change = true;
                increase = false;
            }

            if (change)
            {
                if (minute > 0 && minute < 15)
                {
                    if (increase)
                    {
                        minute = 15;
                    }
                    else
                    {
                        minute = 0;
                    }
                }
                else if (minute > 15 && minute < 30)
                {
                    if (increase)
                    {
                        minute = 30;
                    }
                    else
                    {
                        minute = 15;
                    }
                }
                else if (minute > 30 && minute < 45)
                {
                    if (increase)
                    {
                        minute = 45;
                    }
                    else
                    {
                        minute = 30;
                    }
                }
                else if (minute > 45)
                {
                    minute = 45;
                }
            }
            else
            {
                minute = lastMinute;
            }

            return new DateTime(time.Year, time.Month, time.Day, time.Hour, minute, 0);
        }

    }
}
