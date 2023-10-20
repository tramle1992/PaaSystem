using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using TimeCard.Data;
using PaaApplication.Models.Common;
using System.Configuration;
using Common.Infrastructure.Office;
using Word = NetOffice.WordApi;
using TimeCard.Domain.Model;
using PaaApplication.Helper;
using Common.Infrastructure.Helper;

namespace PaaApplication.Models
{
    public class TimecardDocumentBuilder
    {
        public static DocumentCompleteResult Timecard(List<TimeCardDateData> data, DateTime fromDate, DateTime toDate, string username)
        {
            WordDocumentType docType = WordDocumentType.Timecard;

            TemplateHelper templateHelper = new TemplateHelper();
            string filename = WordTemplatePathResolver.GetTemplateFileName(docType);
            if (!string.IsNullOrEmpty(filename))
            {
                string url = string.Format("api/templates");
                string savePath = WordTemplatePathResolver.GetWordTemplatePath(docType);
                templateHelper.DownloadTemplate(savePath, filename);
            }

            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(docType);
            string toSaveFileName = string.Format("{0} - {1} - {2} - {3}", "Timecard", username, fromDate.ToString("Mdyy"), toDate.ToString("Mdyy"));
            if (!File.Exists(templatePath))
            {
                return null;
            }

            WordService word = new WordService(templatePath, toSaveFileName, false);
            Word.Document documentInstance = word.GetDocumentInstance();
            Word.Application applicationInstance = word.GetApplicationInstance();
            System.Data.DataTable timecardTable = new System.Data.DataTable();

            timecardTable.Columns.Add("Date", typeof(string));
            timecardTable.Columns.Add("In", typeof(string));
            timecardTable.Columns.Add("Out", typeof(string));
            timecardTable.Columns.Add("Total Hours", typeof(string));
            timecardTable.Columns.Add("Bonus", typeof(string));

            double totalRegulars = 0;
            double totalHoliday = 0;
            double totalVacation = 0;
            double totalOT = 0;
            double workThisWeek = 0;
            decimal totalBonus = 0;

            for (var day = fromDate.Date; day <= toDate.Date; day = day.AddDays(1))
            {
                string dateCol = day.ToString("MM/dd/yy") + day.ToString("(ddd)");
                string inCol = string.Empty;
                string outCol = string.Empty;
                string totalHoursCol = string.Empty;
                string bonusCol = string.Empty;

                if (day.DayOfWeek == DayOfWeek.Sunday)
                {
                    dateCol = string.Empty;
                    timecardTable.Rows.Add(dateCol, inCol, outCol, totalHoursCol, bonusCol);
                    continue;
                }
                TimeCardDateData timecard = data.FirstOrDefault(d => d.Date.ToLocalTime().Date == day.Date);
                if (timecard != null)
                {
                    DateTime startTime = timecard.FirstLogin.ToLocalTime();
                    DateTime endTime = (timecard.LastLogout == null) ? startTime.Date.AddHours(18) : timecard.LastLogout.Value.ToLocalTime();

                    double workHours = 0;

                    if (timecard.ListTimeCardItems != null && timecard.ListTimeCardItems.Count > 0)
                    {
                        foreach (TimeCardItemData item in timecard.ListTimeCardItems)
                        {
                            if (item.LogoutTime != null)
                            {
                                workHours += ((DateTime)item.LogoutTime - item.LoginTime).TotalHours;
                            }
                        }
                    }

                    if (workHours == 0)
                    {
                        inCol = "-----";
                        outCol = "-----";
                    }
                    else
                    {
                        inCol = startTime.ToString("h:mm tt");
                        outCol = endTime.ToString("h:mm tt");
                    }

                    if (workHours > 0)
                    {
                        workHours = Math.Round(workHours, 1);
                        if (timecard.TimeCardType.Value == TimeCardType.Regular.Value)
                        {
                            totalRegulars = totalRegulars + workHours;
                            totalHoursCol = string.Format("{0:N1}", workHours);
                        }
                        else if (timecard.TimeCardType.Value == TimeCardType.Holiday.Value)
                        {
                            totalHoliday = totalHoliday + workHours;
                            totalHoursCol = string.Format("{0:N1} (Holiday)", workHours);
                        }
                        else if (timecard.TimeCardType.Value == TimeCardType.Vacation.Value)
                        {
                            totalVacation = totalVacation + workHours;
                            totalHoursCol = string.Format("{0:N1} (Vacation)", workHours);
                        }
                        else if (timecard.TimeCardType.Value == TimeCardType.HolidayLastInOut.Value)
                        {
                            totalHoliday = totalHoliday + workHours;
                            totalHoursCol = string.Format("{0:N1} (Holiday)", workHours);
                        }
                        else if (timecard.TimeCardType.Value == TimeCardType.VacationLastInOut.Value)
                        {
                            totalVacation = totalVacation + workHours;
                            totalHoursCol = string.Format("{0:N1} (Vacation)", workHours);
                        }

                        workThisWeek += workHours;

                        if (workThisWeek > 40)
                        {
                            double tempHours = 0;
                            if (workThisWeek - 40 > workHours)
                            {
                                tempHours = workHours;
                                totalOT = totalOT + tempHours;
                                if (workHours > 0)
                                    totalHoursCol += " (OT)";
                            }
                            else
                            {
                                tempHours = workThisWeek - 40;
                                totalOT = totalOT + tempHours;
                                totalHoursCol += string.Format(" ({0:N1} OT)", tempHours);
                            }

                            if (timecard.TimeCardType.Value == TimeCardType.Regular.Value)
                            {
                                totalRegulars = totalRegulars - tempHours;
                            }
                            else if (timecard.TimeCardType.Value == TimeCardType.Holiday.Value)
                            {
                                totalHoliday = totalHoliday - tempHours;
                            }
                            else if (timecard.TimeCardType.Value == TimeCardType.Vacation.Value)
                            {
                                totalVacation = totalVacation - tempHours;
                            }
                            else if (timecard.TimeCardType.Value == TimeCardType.HolidayLastInOut.Value)
                            {
                                totalHoliday = totalHoliday - tempHours;
                            }
                            else if (timecard.TimeCardType.Value == TimeCardType.VacationLastInOut.Value)
                            {
                                totalVacation = totalVacation + tempHours;
                            }
                        }

                        if (timecard.Bonus > 0)
                        {
                            totalBonus = totalBonus + timecard.Bonus;
                            bonusCol = timecard.Bonus.ToString();
                        }
                    }
                    timecardTable.Rows.Add(dateCol, inCol, outCol, totalHoursCol, bonusCol);
                }
                else
                {
                    timecardTable.Rows.Add(dateCol, inCol, outCol, totalHoursCol, bonusCol);
                }
            }

            word.FillTable(1, timecardTable, 4);

            double totalOthers = totalRegulars + totalVacation + totalHoliday;

            if (totalBonus > 0)
            {
                documentInstance.Bookmarks["Timecard_Total_Bonus"].Range.Text = string.Format("{0:N1}", totalBonus);
            }
            if (totalOthers > 0)
            {
                documentInstance.Bookmarks["Timecard_Total_Other"].Range.Text = string.Format("{0:N1}", totalOthers);

            }
            if (totalHoliday > 0)
            {
                documentInstance.Bookmarks["Timecard_Holiday"].Range.Text = string.Format("{0:N1}", totalHoliday);

            }
            if (totalVacation > 0)
            {
                documentInstance.Bookmarks["Timecard_Vacation"].Range.Text = string.Format("{0:N1}", totalVacation);
            }
            if (totalOT > 0)
            {
                documentInstance.Bookmarks["Timecard_Overtime"].Range.Text = string.Format("{0:N1}", totalOT);
                documentInstance.Bookmarks["Timecard_Total_OT"].Range.Text = string.Format("{0:N1}", totalOT);
            }
            documentInstance.Bookmarks["Timecard_Regular"].Range.Text = string.Format("{0:N1}", totalRegulars);
            documentInstance.Bookmarks["Timecard_Username"].Range.Text = string.Format(username);

            string sFileExtension = "docx";
            string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
            DocumentCompleteResult documentCompleteResult = new DocumentCompleteResult(tempFilePath, word, "Timecard");
            return documentCompleteResult;
        }
    }
}