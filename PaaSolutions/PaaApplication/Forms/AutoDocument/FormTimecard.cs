using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaaApplication.Views;
using PaaApplication.Presenters;
using PaaApplication.Models;
using BrightIdeasSoftware;
using Common.Infrastructure.OLV;
using Common.Infrastructure.UI;
using TimeCard.Domain.Model;
using TimeCard.Infrastructure.TimeCard;
using TimeCard.Data;
using TimeCard.Command;
using System.Globalization;
using TimeCard.Domain.Model.TimeCard;
using PaaApplication.Models.Common;

namespace PaaApplication.Forms
{
    public partial class FormTimecard : BaseForm
    {
        public class DateToComboBox
        {
            public string displayString { get; set; }
            public DateTime value { get; set; }

            public DateToComboBox(string displayString, DateTime dateValue)
            {
                this.displayString = displayString;
                this.value = dateValue;
            }
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        TimeCardApiRepository timeCardRepository = new TimeCardApiRepository();

        List<TimeCardTypeData> listTimeCardType = new List<TimeCardTypeData>();

        FormMaster formMaster;

        public FormTimecard(FormMaster formMaster)
        {
            this.formMaster = formMaster;
            InitializeComponent();
            Initialize();
        }

        private void FormTimecard_LoadCompleted(object sender, EventArgs e)
        {
            
        }

        private void Initialize()
        {
            try
            {
                CultureInfo ci = new CultureInfo("en-US");
                DateTimeFormatInfo dtfi = ci.DateTimeFormat;

                cboTimeCardDate.DisplayMember = "displayString";
                cboTimeCardDate.ValueMember = "value";

                LoadDatesToComboBox();

                this.olvcolHours.AspectGetter = delegate(object row)
                {
                    TimeCardDateData tc = row as TimeCardDateData;
                    if (tc != null)
                    {
                        List<TimeCardItemData> listTimeCardItemData = tc.ListTimeCardItems;
                        if (listTimeCardItemData != null && listTimeCardItemData.Count > 0)
                        {
                            double totalHours = 0;
                            foreach (TimeCardItemData item in listTimeCardItemData)
                            {
                                if (item.LogoutTime != null)
                                {
                                    double diff = ((DateTime)item.LogoutTime - item.LoginTime).TotalHours;
                                    totalHours += diff;
                                }
                            }
                            return string.Format("{0:N1}", totalHours);
                        }
                    }
                    return "";
                };

                this.olvTcDate.AspectGetter = delegate(object row)
                {
                    TimeCardDateData tc = row as TimeCardDateData;
                    if (tc != null)
                    {
                        DateTime date = tc.Date.ToLocalTime();
                        return (date.ToString("MM / dd / yyyy") + date.ToString(" (ddd)"));
                    }
                    return " ";
                };

                this.olvcolTimeIn.AspectGetter = delegate(object row)
                {
                    TimeCardDateData tc = row as TimeCardDateData;
                    if (tc != null)
                    {
                        DateTime timein = tc.FirstLogin.ToLocalTime();
                        return string.Format("{0}", timein.ToString("hh:mm:ss tt"));
                    }
                    return " ";
                };

                this.olvcolTimeOut.AspectGetter = delegate(object row)
                {
                    TimeCardDateData tc = row as TimeCardDateData;
                    if (tc != null)
                    {
                        if (tc.LastLogout != null)
                        {
                            DateTime timeOut = ((DateTime)tc.LastLogout).ToLocalTime();
                            return string.Format("{0}", timeOut.ToString("hh:mm:ss tt"));
                        }
                    }
                    return " ";
                };

                this.olvcolType.AspectGetter = delegate(object row)
                {
                    TimeCardDateData tc = row as TimeCardDateData;
                    if (tc != null)
                    {
                        TimeCardTypeData type = tc.TimeCardType;
                        return type.DisplayName;
                    }
                    return " ";
                };

                this.olvcolBonus.AspectGetter = delegate(object row)
                {
                    TimeCardDateData tc = row as TimeCardDateData;
                    if (tc != null)
                    {
                        return string.Format("{0:N1}", tc.Bonus);
                    }
                    return "";
                };

                LoadTimeCardTypes();
                LoadDataForOLV();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);                
            }
        }

        private void LoadDatesToComboBox()
        {
            try
            {
                int currentYear = DateTime.Now.Year;
                int currentMonth = DateTime.Now.Month;


                //Load previous month
                if (currentMonth > 2)
                {
                    for (int i = 2; i >= 1; i--)
                    {
                        GetDateForCombobox(currentYear, currentMonth - i);
                    }
                }
                else if (currentMonth == 2)
                {
                    GetDateForCombobox(currentYear - 1, 12);
                    GetDateForCombobox(currentYear, 1);
                }
                else if (currentMonth == 1)
                {
                    GetDateForCombobox(currentYear - 1, 11);
                    GetDateForCombobox(currentYear - 1, 12);
                }
                

                //Load current month
                GetDateForCombobox(currentYear, currentMonth);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);                
            }
        }

        private void GetDateForCombobox(int year, int month)
        {
            int currentDay = DateTime.Now.Date.Day;

            DateTime firstDateOfMonth = new DateTime(year, month, 1);
            DateTime middleDateOfMonth = new DateTime(year, month, 16);

            DateToComboBox firstDateObject = new DateToComboBox(firstDateOfMonth.ToString("MM / dd / yyyy"), firstDateOfMonth);
            
            cboTimeCardDate.Items.Add(firstDateObject);
            if (currentDay >= 15 || month < DateTime.Today.Month || ((month == 11 || month == 12) && (DateTime.Today.Month == 1 || DateTime.Today.Month == 2)))
            {
                DateToComboBox middleDateObject = new DateToComboBox(middleDateOfMonth.ToString("MM / dd / yyyy"), middleDateOfMonth);
                cboTimeCardDate.Items.Add(middleDateObject);
            }

            cboTimeCardDate.SelectedIndex = cboTimeCardDate.Items.Count - 1;
        }

        private void LoadTimeCardTypes()
        {
            foreach (TimeCardType tc in TimeCardType.GetAll<TimeCardType>())
            {
                listTimeCardType.Add(new TimeCardTypeData(tc.Value, tc.DisplayName));
            }
        }

        private void LoadDataForOLV()
        {
            rtbTimeCardDetails.Clear();
            lblTimecardFor.Text = "";

            lblTimecardFor.Text = string.Format("{0}'S TIMECARD FOR PERIOD BEGINING:", formMaster.CURRENT_USER.UserName.ToUpper());

            string userId = formMaster.CURRENT_USER.UserId.Id;
            List<TimeCardDateData> list = this.GetTimeCardData(userId, ((DateToComboBox)cboTimeCardDate.SelectedItem).value);

            List<TimeCardDateData> shownList = new List<TimeCardDateData>(); // Just show Records that have the TimeCard date != Sunday

            if (list.Count > 0)
            {
                foreach (TimeCardDateData item in list)
                {
                    if (item.Date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        TimeCardDateData timecardData = AutoMapper.Mapper.Map<TimeCardDateData, TimeCardDateData>(item);
                        shownList.Add(timecardData);
                    }
                }
            }

            this.olvTimecard.SetObjects(shownList);

            if (olvTimecard.Items.Count > 0)
            {
                olvTimecard.SelectedIndex = 0;
            }
        }

        private List<TimeCardDateData> GetTimeCardData(string userId, DateTime fromDate)
        {
            List<TimeCardDateData> listResult = new List<TimeCardDateData>();

            try
            {
                DateTime toDate;
                if (fromDate.Day <= 15)
                {
                    toDate = new DateTime(fromDate.Year, fromDate.Month, 15, 23, 59, 59);
                }
                else
                {
                    toDate = new DateTime(fromDate.Year, fromDate.Month, DateTime.DaysInMonth(fromDate.Year, fromDate.Month), 23, 59, 59);
                }

                FindTimeCardCommand command = new FindTimeCardCommand(formMaster.CURRENT_USER.UserId.Id, fromDate, toDate);

                using (new HourGlass())
                {
                    listResult = timeCardRepository.FindTimeCard(command);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
            return listResult;
        }

        private void olvTimecard_SelectionChanged(object sender, EventArgs e)
        {
            rtbTimeCardDetails.Clear();
            lblTimeLogDetails.Text = "";

            TimeCardDateData selectedTimeCard = this.olvTimecard.SelectedObject as TimeCardDateData;

            if (selectedTimeCard != null && selectedTimeCard.ListTimeCardItems.Count > 0)
            {
                lblTimeLogDetails.Text = String.Format("{0}'s timelog details on {1}", formMaster.CURRENT_USER.UserName, selectedTimeCard.Date.ToLocalTime().ToString("MM / dd / yyyy"));

                List<TimeCardItemData> sortedList = selectedTimeCard.ListTimeCardItems.OrderBy(o => o.LoginTime).ToList();

                int count = 0;
                foreach (TimeCardItemData item in sortedList)
                {
                    string login = "";
                    string logout = "";

                    login = string.Format("- Login: {0}", item.LoginTime.ToLocalTime().ToString("hh:mm:ss tt"));

                    if (item.LogoutTime != null)
                    {
                        DateTime logOutTime = Convert.ToDateTime(item.LogoutTime);
                        logout = string.Format("- Logout: {0}", logOutTime.ToLocalTime().ToString("hh:mm:ss tt"));
                    }
                    else
                    {
                        logout = string.Format("- Logout: {0}", " --- ");
                    }

                    this.rtbTimeCardDetails.AppendText(string.Format("{0} /", (count + 1).ToString()));
                    this.rtbTimeCardDetails.AppendText(System.Environment.NewLine);
                    this.rtbTimeCardDetails.AppendText(login);
                    this.rtbTimeCardDetails.AppendText(System.Environment.NewLine);
                    this.rtbTimeCardDetails.AppendText(logout);
                    this.rtbTimeCardDetails.AppendText(System.Environment.NewLine);
                    this.rtbTimeCardDetails.AppendText(System.Environment.NewLine);
                    count++;
                }
            }
        }

        private double RoundNumber(double number)
        {
            double result = number * 2;

            result = Math.Round(result, MidpointRounding.AwayFromZero) / 2;

            return result;
        }

        private void olvTimecard_CellEditStarting(object sender, CellEditEventArgs e)
        {
            TimeCardDateData timeCard = (TimeCardDateData)e.RowObject;
            if (timeCard == null)
            {
                e.Cancel = true;
                return;
            }

            if (e.Column == this.olvcolType)
            {
                ComboBox cboControl = new ComboBox();
                cboControl.DisplayMember = "DisplayName";
                cboControl.ValueMember = "Value";

                cboControl.Bounds = e.CellBounds;
                cboControl.DropDownStyle = ComboBoxStyle.DropDownList;

                foreach (var item in listTimeCardType)
                {
                    cboControl.Items.Add(item);
                }

                int index = listTimeCardType.FindIndex(d => d.DisplayName == e.Value.ToString());
                cboControl.SelectedIndex = index > 0 ? index : 0;
                e.Control = cboControl;
            }
        }

        private void olvTimecard_CellEditValidating(object sender, CellEditEventArgs e)
        {
        }

        private void olvTimecard_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            TimeCardDateData timeCard = (TimeCardDateData)e.RowObject;
            if (timeCard == null)
            {
                e.Cancel = true;
                return;
            }
            if (!e.Cancel)
            {
                timeCard.TimeCardType = (TimeCardTypeData)((ComboBox)e.Control).SelectedItem;
            }

            this.olvTimecard.RefreshObject(timeCard);
        }

        private void cboTimeCardDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataForOLV();
        }

        private void FormTimecard_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                    LoadDataForOLV();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void FormTimecard_Shown(object sender, EventArgs e)
        { }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (olvTimecard.Objects == null ||
                olvTimecard.GetItemCount() == 0)
            {
                return;
            }

            List<TimeCardDateData> timecardList = olvTimecard.Objects.Cast<TimeCardDateData>().ToList();

            List<UpdateTimeCardDate> listtcToUpdate = new List<UpdateTimeCardDate>();

            if (timecardList.Count > 0)
            {
                foreach (TimeCardDateData item in timecardList)
                {
                    UpdateTimeCardDate tc = new UpdateTimeCardDate(item.TimeCardDateId, item.TimeCardType.Value, item.Bonus);
                    listtcToUpdate.Add(tc);
                }

                SaveTimeCardCommand command = new SaveTimeCardCommand(listtcToUpdate);

                using (new HourGlass())
                {
                    timeCardRepository.UpdateTimeCard(command);

                    TimeCardCachedApiQuery tcCachedApiQuery = TimeCardCachedApiQuery.Instance;
                    tcCachedApiQuery.RemoveAllTimeCards();
                }
            }

        }

        private void btnCancelWithoutSaving_Click(object sender, EventArgs e)
        {
            LoadDataForOLV();
            if (olvTimecard.Items.Count > 0)
            {
                olvTimecard.SelectedIndex = 0;
            }
        }

        private void btnPrintTimecard_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = DateTime.Now;
                if (DateTime.TryParseExact(cboTimeCardDate.Text, "MM / dd / yyyy", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out fromDate) == false)
                    return;

                string userId = formMaster.CURRENT_USER.UserId.Id;
                List<TimeCardDateData> timecard = GetTimeCardData(userId, fromDate);
                DateTime toDate;
                if (fromDate.Day <= 15)
                {
                    toDate = new DateTime(fromDate.Year, fromDate.Month, 15);
                }
                else
                {
                    toDate = new DateTime(fromDate.Year, fromDate.Month, DateTime.DaysInMonth(fromDate.Year, fromDate.Month));
                }

                DocumentCompleteResult documentReportResult = TimecardDocumentBuilder.Timecard(timecard, fromDate, toDate, formMaster.CURRENT_USER.UserName);

                if (documentReportResult != null)
                {
                    FormDocumentComplete dialog = new FormDocumentComplete("Time Card", documentReportResult);
                    dialog.StartPosition = FormStartPosition.CenterScreen;
                    dialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
