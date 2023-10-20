using AutoDocument.Application.Data;
using Common.Application;
using Common.Infrastructure.ApiClient;
using Common.Infrastructure.Helper;
using Common.Infrastructure.Office;
using NetOffice.WordApi.Enums;
using Newtonsoft.Json;
using PaaApplication.Helper;
using PaaApplication.Models.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SystemConfiguration.Application.Data;
using SystemConfiguration.Infrastructure;
using Word = NetOffice.WordApi;

namespace PaaApplication.Models.AutoDocument
{
    public class GetDocumentCompleteResult
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static HttpClient httpClient;

        private static SysConfigApiRepository sysConfigApiRepository = new SysConfigApiRepository();
        private static ConfigData sysConfig;

        static GetDocumentCompleteResult()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUri"];
            httpClient = ApiClientFactory.GetHttpClient(baseAddress);
        }

        public static string DownloadDocumentTemplate(WordDocumentType doctype)
        {
            TemplateHelper templateHelper = new TemplateHelper();
            string filename = WordTemplatePathResolver.GetTemplateFileName(doctype);
            if (!string.IsNullOrEmpty(filename))
            {
                string url = string.Format("api/templates");
                string savePath = WordTemplatePathResolver.GetWordTemplatePath(doctype);
                templateHelper.DownloadTemplate(savePath, filename);
            }

            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(doctype);

            if (!File.Exists(templatePath))
            {
                return "";
            }
            return templatePath;
        }

        #region DailyReport
        public static DocumentCompleteResult DailyReport(DocumentReportDailyReportOption option)
        {
            WordService word = null;
            try
            {
                DocumentReportData data = LoadData(option);
                string templatePath = DownloadDocumentTemplate(WordDocumentType.DailyReport);
                if (string.IsNullOrEmpty(templatePath))
                    return null;
                word = new WordService(templatePath, option.GetToSaveFilename(), false);
                Word.Application applicationInstance = word.GetApplicationInstance();
                Word.Document documentInstance = word.GetDocumentInstance();

                int totalColumns = data.TableData[1].Columns.Count;
                int totalRows = data.TableData[1].Rows.Count;
                int maximumRowsInPage = 30;
                int totalPages = (int)Math.Ceiling((double)totalRows / maximumRowsInPage);
                int curRow = 1;

                for (int curPage = 1; curPage <= totalPages; curPage++)
                {
                    if (curPage > 1)
                    {
                        word.InsertBreakToLast();
                        word.AppendDocument(templatePath);
                    }

                    documentInstance.Bookmarks["Date"].Range.Text = data.BookmarkData["Date"];
                    documentInstance.Bookmarks["Username"].Range.Text = data.BookmarkData["Username"];
                    if (totalPages == 1)
                    {
                        documentInstance.Bookmarks["TotalFulls"].Range.Text = data.BookmarkData["TotalFulls"];
                        documentInstance.Bookmarks["TotalOtherApps"].Range.Text = data.BookmarkData["TotalOtherApps"];
                    }
                    else
                    {
                        if (curPage < totalPages)
                        {
                            documentInstance.Bookmarks["TotalFulls"].Range.Text = "Continued...";
                            documentInstance.Bookmarks["TotalOtherApps"].Range.Text = "N/A";
                        }
                        else
                        {
                            documentInstance.Bookmarks["TotalFulls"].Range.Text = data.BookmarkData["TotalFulls"];
                            documentInstance.Bookmarks["TotalOtherApps"].Range.Text = data.BookmarkData["TotalOtherApps"];
                        }
                    }

                    documentInstance.Bookmarks["STB"].Range.Select();

                    int rowsInPage;
                    if (totalPages == 1)
                    {
                        rowsInPage = totalRows;
                    }
                    else
                    {
                        if (curPage < totalPages)
                        {
                            rowsInPage = maximumRowsInPage;
                        }
                        else
                        {
                            rowsInPage = totalRows - (curPage - 1) * maximumRowsInPage;
                        }
                    }
                    for (int i = 1; i <= rowsInPage; i++)
                    {
                        for (int j = 1; j <= totalColumns; j++)
                        {
                            if (j == 4) // colum Received Day
                            {
                                DateTime receivedDay = Convert.ToDateTime(data.TableData[1].Rows[curRow - 1][j - 1].ToString());
                                applicationInstance.Selection.Range.Text = receivedDay.ToLocalTime().ToString("M/d/yy h:mm tt");
                            }
                            else if (j == 5)  // collum Completed Day
                            {
                                if (!string.IsNullOrEmpty(data.TableData[1].Rows[curRow - 1][j - 1].ToString()))
                                {
                                    DateTime completedDat = Convert.ToDateTime(data.TableData[1].Rows[curRow - 1][j - 1].ToString());
                                    applicationInstance.Selection.Range.Text = completedDat.ToLocalTime().ToString("h:mm tt");
                                }
                                else
                                {
                                    applicationInstance.Selection.Range.Text = string.Empty;
                                }
                            }
                            else
                            {
                                applicationInstance.Selection.Range.Text = data.TableData[1].Rows[curRow - 1][j - 1].ToString();
                            }

                            applicationInstance.Selection.MoveRight(WdUnits.wdCell, 1, Type.Missing);
                        }
                        curRow += 1;
                    }
                }
                if (totalPages == 0)
                {
                    documentInstance.Bookmarks["Date"].Range.Text = data.BookmarkData["Date"];
                    documentInstance.Bookmarks["Username"].Range.Text = data.BookmarkData["Username"];
                    documentInstance.Bookmarks["STB"].Range.Text = data.BookmarkData["STB"];
                    documentInstance.Bookmarks["TotalFulls"].Range.Text = "0";
                    documentInstance.Bookmarks["TotalOtherApps"].Range.Text = "0";
                }

                applicationInstance.Selection.HomeKey(WdUnits.wdStory, Type.Missing);
                string toSaveFileName = option.GetToSaveFilename();
                string sFileExtension = "docx";
                string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
                return new DocumentCompleteResult(tempFilePath, word, option.GetToSaveFilename());
            }
            catch (Exception ex)
            {
                if (word != null)
                    word.Quit(false);
                throw;
            }
        }
        #endregion

        #region ReceiptLog
        public static DocumentCompleteResult ReceiptLog(DocumentReportReceiptLogOption option)
        {
            WordService word = null;
            try
            {
                DocumentReportData data = LoadData(option);
                string templatePath = DownloadDocumentTemplate(WordDocumentType.ReceiptLog);
                word = new WordService(templatePath, option.GetToSaveFilename(), false);
                Word.Application applicationInstance = word.GetApplicationInstance();
                Word.Document documentInstance = word.GetDocumentInstance();

                int totalColumns = data.TableData[1].Columns.Count;
                int totalRows = data.TableData[1].Rows.Count;
                int maximumRowsInPage = 15;
                int totalPages = (int)Math.Ceiling((double)totalRows / maximumRowsInPage);
                int curRow = 1;

                for (int curPage = 1; curPage <= totalPages; curPage++)
                {
                    if (curPage > 1)
                    {
                        word.InsertBreakToLast();
                        word.AppendDocument(templatePath);
                    }

                    documentInstance.Bookmarks["ClientName"].Range.Text = data.BookmarkData["ClientName"];
                    documentInstance.Bookmarks["ClientAddress"].Range.Text = data.BookmarkData["ClientAddress"];
                    documentInstance.Bookmarks["ClientPhone"].Range.Text = data.BookmarkData["ClientPhone"];
                    documentInstance.Bookmarks["ClientFax"].Range.Text = data.BookmarkData["ClientFax"];
                    documentInstance.Bookmarks["Date"].Range.Text = data.BookmarkData["Date"];
                    documentInstance.Bookmarks["BCIncRep"].Range.Text = data.BookmarkData["BCIncRep"];
                    if (totalPages == 1 || totalPages == 0)
                    {
                        documentInstance.Bookmarks["Total"].Range.Text = data.BookmarkData["Total"];
                    }
                    else
                    {
                        if (curPage < totalPages)
                        {
                            documentInstance.Bookmarks["Total"].Range.Text = "Continued...";
                        }
                        else
                        {
                            documentInstance.Bookmarks["Total"].Range.Text = data.BookmarkData["Total"];
                        }
                    }

                    documentInstance.Bookmarks["STB"].Range.Select();

                    int rowsInPage;
                    if (totalPages == 1)
                    {
                        rowsInPage = totalRows;
                    }
                    else
                    {
                        if (curPage < totalPages)
                        {
                            rowsInPage = maximumRowsInPage;
                        }
                        else
                        {
                            rowsInPage = totalRows - (curPage - 1) * maximumRowsInPage;
                        }
                    }
                    for (int i = 1; i <= rowsInPage; i++)
                    {
                        for (int j = 1; j <= totalColumns; j++)
                        {
                            applicationInstance.Selection.Range.Text = data.TableData[1].Rows[curRow - 1][j - 1].ToString();
                            applicationInstance.Selection.MoveRight(WdUnits.wdCell, 1, Type.Missing);
                        }
                        curRow += 1;
                    }
                }
                if (totalPages == 0)
                {
                    documentInstance.Bookmarks["ClientName"].Range.Text = data.BookmarkData["ClientName"];
                    documentInstance.Bookmarks["ClientAddress"].Range.Text = data.BookmarkData["ClientAddress"];
                    documentInstance.Bookmarks["ClientPhone"].Range.Text = data.BookmarkData["ClientPhone"];
                    documentInstance.Bookmarks["ClientFax"].Range.Text = data.BookmarkData["ClientFax"];
                    documentInstance.Bookmarks["Date"].Range.Text = data.BookmarkData["Date"];
                    documentInstance.Bookmarks["BCIncRep"].Range.Text = data.BookmarkData["BCIncRep"];
                    documentInstance.Bookmarks["Total"].Range.Text = data.BookmarkData["Total"];
                }

                applicationInstance.Selection.HomeKey(WdUnits.wdStory, Type.Missing);
                string toSaveFileName = option.GetToSaveFilename();
                string sFileExtension = "docx";
                string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
                return new DocumentCompleteResult(tempFilePath, word, toSaveFileName);
            }
            catch (Exception ex)
            {
                if (word != null)
                    word.Quit(false);
                throw;
            }
        }
        #endregion

        #region Calendar
        public static DocumentCompleteResult Calendar(DocumentReportCalendarOption option)
        {
            WordService word = null;
            try
            {
                DocumentReportData data = LoadData(option);
                string templatePath = DownloadDocumentTemplate(WordDocumentType.Calendar);
                word = new WordService(templatePath, option.GetToSaveFilename(), false);
                Word.Application applicationInstance = word.GetApplicationInstance();
                Word.Document documentInstance = word.GetDocumentInstance();

                int currentTableIndex = 1;

                if (option.CalendarFrom.Year == option.CalendarTo.Year)
                {
                    for (int i = option.CalendarFrom.Month; i <= option.CalendarTo.Month; i++)
                    {
                        if (currentTableIndex > 1)
                        {
                            word.InsertBreakToLast();
                            word.AppendDocument(templatePath);
                        }
                        FillCalendarByYearAndMonth(applicationInstance, documentInstance, currentTableIndex, option.CalendarFrom.Year, i);
                        currentTableIndex += 1;
                    }
                }
                else if (option.CalendarFrom.Year < option.CalendarTo.Year)
                {
                    int startMonth = option.CalendarFrom.Month;
                    int endMonth = 12;
                    for (int i = option.CalendarFrom.Year; i <= option.CalendarTo.Year; i++)
                    {
                        for (int j = startMonth; j <= endMonth; j++)
                        {
                            if (j == 12)
                            {
                                startMonth = 1;
                                if (i + 1 == option.CalendarTo.Year)
                                {
                                    endMonth = option.CalendarTo.Month;
                                }
                            }
                            if (currentTableIndex > 1)
                            {
                                word.InsertBreakToLast();
                                word.AppendDocument(templatePath);
                            }
                            FillCalendarByYearAndMonth(applicationInstance, documentInstance, currentTableIndex, i, j);
                            currentTableIndex += 1;
                        }
                    }
                }

                applicationInstance.Selection.HomeKey(WdUnits.wdStory, Type.Missing);
                string toSaveFileName = option.GetToSaveFilename();
                string sFileExtension = "docx";
                string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
                return new DocumentCompleteResult(tempFilePath, word, toSaveFileName);
            }
            catch (Exception ex)
            {
                if (word != null)
                    word.Quit(false);
                throw;
            }
        }

        private static void FillCalendarByYearAndMonth(Word.Application application, Word.Document document, int currentTableIndex, int year, int month)
        {
            int numberOfDaysInMonth = DateTime.DaysInMonth(year, month);
            DateTime fullDateToUse = new DateTime(year, month, 1);
            int dayOfWeek = (int)fullDateToUse.DayOfWeek;
            string monthName = fullDateToUse.ToString("MMMM");

            document.Bookmarks["Date"].Range.Text = monthName + " " + year;

            document.Bookmarks["STB"].Range.Select();
            if (dayOfWeek > 0)
            {
                application.Selection.Range.Text = String.Empty;
                application.Selection.MoveRight(WdUnits.wdCell, dayOfWeek, Type.Missing);
            }
            int curCol = dayOfWeek + 1;
            for (int i = 1; i <= numberOfDaysInMonth; i++)
            {
                application.Selection.Range.Text = i.ToString();
                curCol += 1;
                if (curCol > 7)
                {
                    curCol = 1;
                }
                application.Selection.MoveRight(WdUnits.wdCell, 1, Type.Missing);
            }
        }
        #endregion

        #region MonthlyScreener
        public static DocumentCompleteResult MonthlyScreener(DocumentReportMonthlyScreenerOption option)
        {
            WordService word = null;
            try
            {
                DocumentReportData data = LoadData(option);
                string templatePath = DownloadDocumentTemplate(WordDocumentType.MonthlyScreener);
                word = new WordService(templatePath, option.GetToSaveFilename(), false);
                Word.Document documentInstance = word.GetDocumentInstance();
                Word.Application applicationInstance = word.GetApplicationInstance();

                documentInstance.Bookmarks["Username"].Range.Text = data.BookmarkData["Username"];
                documentInstance.Bookmarks["Date"].Range.Text = data.BookmarkData["Date"];
                documentInstance.Bookmarks["TotalApps"].Range.Text = data.BookmarkData["TotalApps"];
                documentInstance.Bookmarks["TotalFullApps"].Range.Text = data.BookmarkData["TotalFullApps"];
                documentInstance.Bookmarks["TotalOtherApps"].Range.Text = data.BookmarkData["TotalOtherApps"];

                int numberOfDaysInMonth = DateTime.DaysInMonth(option.ReportDate.Year, option.ReportDate.Month);
                DateTime fullDateToUse = new DateTime(option.ReportDate.Year, option.ReportDate.Month, 1);
                int dayOfWeek = (int)fullDateToUse.DayOfWeek;
                DateTime curDate = DateTime.Now;
                int curYear = curDate.Year;
                int curMonth = curDate.Month;
                int curDay = curDate.Day;

                documentInstance.Bookmarks["STB"].Range.Select();

                if (dayOfWeek == 0)
                {
                    applicationInstance.Selection.Font.Size = 16;
                    applicationInstance.Selection.Font.Bold = 1;
                    applicationInstance.Selection.TypeText("1");
                    if (option.ReportDate.Year == curYear && option.ReportDate.Month == curMonth && curDay == 1)
                    {
                        applicationInstance.Selection.Font.Size = 10;
                        applicationInstance.Selection.TypeText(" (Today)");
                    }
                    applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                }
                else
                {
                    applicationInstance.Selection.TypeText(String.Empty);
                    applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                    applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                }
                applicationInstance.Selection.Font.Size = 10;
                applicationInstance.Selection.Font.Bold = 1;
                applicationInstance.Selection.TypeText("Weekly Totals:");
                applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                applicationInstance.Selection.Font.Bold = 0;
                applicationInstance.Selection.TypeText(CountWeeklyFullsCompletedMonthlyScreener(data.TableData[1], 1, 7 - dayOfWeek).ToString() + " Fulls Compl.");
                applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                applicationInstance.Selection.TypeText(CountWeeklyTotalCompletedMonthlyScreener(data.TableData[1], 1, 7 - dayOfWeek).ToString() + " Total Compl.");

                if (dayOfWeek > 0)
                {
                    applicationInstance.Selection.MoveRight(WdUnits.wdCell, dayOfWeek, Type.Missing);
                }

                int curCol = dayOfWeek + 1;
                for (int i = 1; i <= numberOfDaysInMonth; i++)
                {
                    if (i == 1 && dayOfWeek == 0)
                    {
                        curCol += 1;
                        applicationInstance.Selection.MoveRight(WdUnits.wdCell, 1, Type.Missing);
                        continue;
                    }

                    applicationInstance.Selection.Font.Size = 16;
                    applicationInstance.Selection.Font.Bold = 1;
                    applicationInstance.Selection.TypeText(i.ToString());
                    if (option.ReportDate.Year == curYear && option.ReportDate.Month == curMonth && i == curDay)
                    {
                        applicationInstance.Selection.Font.Size = 10;
                        applicationInstance.Selection.TypeText(" (Today)");
                    }

                    if (option.ReportDate.Year != curYear || option.ReportDate.Month != curMonth || i <= curDay)
                    {
                        if (curCol == 1)
                        {
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.Font.Size = 10;
                            applicationInstance.Selection.Font.Bold = 1;
                            applicationInstance.Selection.TypeText("Weekly Totals:");
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.Font.Bold = 0;
                            applicationInstance.Selection.TypeText(CountWeeklyFullsCompletedMonthlyScreener(data.TableData[1], i, i + 6).ToString() + " Fulls Compl.");
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.TypeText(CountWeeklyTotalCompletedMonthlyScreener(data.TableData[1], i, i + 6).ToString() + " Total Compl.");
                        }
                        else
                        {
                            int dailyFullsCompleted = int.Parse(data.TableData[1].Rows[i - 1][0].ToString());
                            int dailyTotalCompleted = int.Parse(data.TableData[1].Rows[i - 1][1].ToString());

                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.Font.Size = 10;
                            applicationInstance.Selection.Font.Bold = 0;
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.TypeText(dailyFullsCompleted.ToString() + " Fulls Compl.");
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.TypeText(dailyTotalCompleted.ToString() + " Total Compl.");

                            // Load system config
                            sysConfig = sysConfigApiRepository.Find(GlobalConstants.SYS_CONFIG_ID);
                            if (sysConfig == null || string.IsNullOrEmpty(sysConfig.ConfigId))
                            {
                                sysConfig = new ConfigData();
                                sysConfig.NumberAppsBonus = (short)GlobalConstants.DEFAULT_NUMBER_APPS_BONUS;
                            }

                            if (dailyFullsCompleted >= sysConfig.NumberAppsBonus)
                            {
                                applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                                applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                                applicationInstance.Selection.Font.Size = 12;
                                applicationInstance.Selection.Font.Bold = 1;
                                applicationInstance.Selection.TypeText("BONUS!");
                            }
                        }
                    }

                    curCol += 1;
                    if (curCol > 7)
                    {
                        curCol = 1;
                    }
                    applicationInstance.Selection.MoveRight(WdUnits.wdCell, 1, Type.Missing);
                }

                applicationInstance.Selection.HomeKey(WdUnits.wdStory, Type.Missing);
                string toSaveFileName = option.GetToSaveFilename();
                string sFileExtension = "docx";
                string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
                return new DocumentCompleteResult(tempFilePath, word, toSaveFileName);
            }
            catch (Exception ex)
            {
                if (word != null)
                    word.Quit(false);
                throw;
            }

        }

        private static int CountWeeklyFullsCompletedMonthlyScreener(DataTable table, int fromIndex, int toIndex)
        {
            int count = 0;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                if (i > table.Rows.Count)
                {
                    break;
                }
                count += int.Parse(table.Rows[i - 1][0].ToString());
            }
            return count;
        }

        private static int CountWeeklyTotalCompletedMonthlyScreener(DataTable table, int fromIndex, int toIndex)
        {
            int count = 0;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                if (i > table.Rows.Count)
                {
                    break;
                }
                count += int.Parse(table.Rows[i - 1][1].ToString());
            }
            return count;
        }
        #endregion

        #region ApplicationVolume
        public static DocumentCompleteResult ApplicationVolume(DocumentReportApplicationVolumeOption option)
        {
            WordService word = null;
            try
            {
                DocumentReportData data = LoadData(option);
                string templatePath = DownloadDocumentTemplate(WordDocumentType.ApplicationVolume);
                word = new WordService(templatePath, option.GetToSaveFilename(), false);
                Word.Document documentInstance = word.GetDocumentInstance();
                Word.Application applicationInstance = word.GetApplicationInstance();

                documentInstance.Bookmarks["Date"].Range.Text = data.BookmarkData["Date"];
                documentInstance.Bookmarks["TotalRec"].Range.Text = data.BookmarkData["TotalRec"];
                documentInstance.Bookmarks["TotalFullRec"].Range.Text = data.BookmarkData["TotalFullRec"];
                documentInstance.Bookmarks["TotalOtherRec"].Range.Text = data.BookmarkData["TotalOtherRec"];
                documentInstance.Bookmarks["TotalCom"].Range.Text = data.BookmarkData["TotalCom"];
                documentInstance.Bookmarks["TotalFullCom"].Range.Text = data.BookmarkData["TotalFullCom"];
                documentInstance.Bookmarks["TotalOtherCom"].Range.Text = data.BookmarkData["TotalOtherCom"];

                int numberOfDaysInMonth = DateTime.DaysInMonth(option.ReportDate.Year, option.ReportDate.Month);
                DateTime fullDateToUse = new DateTime(option.ReportDate.Year, option.ReportDate.Month, 1);
                int dayOfWeek = (int)fullDateToUse.DayOfWeek;
                DateTime curDate = DateTime.Now;
                int curYear = curDate.Year;
                int curMonth = curDate.Month;
                int curDay = curDate.Day;

                documentInstance.Bookmarks["STB"].Range.Select();

                if (dayOfWeek == 0)
                {
                    applicationInstance.Selection.Font.Size = 16;
                    applicationInstance.Selection.Font.Bold = 1;
                    applicationInstance.Selection.TypeText("1");
                    if (option.ReportDate.Year == curYear && option.ReportDate.Month == curMonth && curDay == 1)
                    {
                        applicationInstance.Selection.Font.Size = 10;
                        applicationInstance.Selection.TypeText(" (Today)");
                    }
                    applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                }
                else
                {
                    applicationInstance.Selection.TypeText(String.Empty);
                    applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                    applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                }
                applicationInstance.Selection.Font.Size = 10;
                applicationInstance.Selection.Font.Bold = 1;
                applicationInstance.Selection.TypeText("Weekly Totals:");
                applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                applicationInstance.Selection.Font.Bold = 0;
                applicationInstance.Selection.TypeText(CountWeeklyReceivedApplicationVolume(data.TableData[1], 1, 7 - dayOfWeek).ToString() + " Rec'd");
                applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                applicationInstance.Selection.TypeText(CountWeeklyFullsReceivedApplicationVolume(data.TableData[1], 1, 7 - dayOfWeek).ToString() + " Fulls Rec'd.");
                applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                applicationInstance.Selection.TypeText(CountWeeklyCompletedApplicationVolume(data.TableData[1], 1, 7 - dayOfWeek).ToString() + " Compl.");
                applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                applicationInstance.Selection.TypeText(CountWeeklyFullsCompletedApplicationVolume(data.TableData[1], 1, 7 - dayOfWeek).ToString() + " Fulls Compl.");

                if (dayOfWeek > 0)
                {
                    applicationInstance.Selection.MoveRight(WdUnits.wdCell, dayOfWeek, Type.Missing);
                }

                int curCol = dayOfWeek + 1;
                for (int i = 1; i <= numberOfDaysInMonth; i++)
                {
                    if (i == 1 && dayOfWeek == 0)
                    {
                        curCol += 1;
                        applicationInstance.Selection.MoveRight(WdUnits.wdCell, 1, Type.Missing);
                        continue;
                    }

                    applicationInstance.Selection.Font.Size = 16;
                    applicationInstance.Selection.Font.Bold = 1;
                    applicationInstance.Selection.TypeText(i.ToString());
                    if (option.ReportDate.Year == curYear && option.ReportDate.Month == curMonth && i == curDay)
                    {
                        applicationInstance.Selection.Font.Size = 10;
                        applicationInstance.Selection.TypeText(" (Today)");
                    }

                    if (option.ReportDate.Year != curYear || option.ReportDate.Month != curMonth || i <= curDay)
                    {
                        if (curCol == 1)
                        {
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.Font.Size = 10;
                            applicationInstance.Selection.Font.Bold = 1;
                            applicationInstance.Selection.TypeText("Weekly Totals:");
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.Font.Bold = 0;
                            applicationInstance.Selection.TypeText(CountWeeklyReceivedApplicationVolume(data.TableData[1], i, i + 6).ToString() + " Rec'd");
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.TypeText(CountWeeklyFullsReceivedApplicationVolume(data.TableData[1], i, i + 6).ToString() + " Fulls Rec'd.");
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.TypeText(CountWeeklyCompletedApplicationVolume(data.TableData[1], i, i + 6).ToString() + " Compl.");
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.TypeText(CountWeeklyFullsCompletedApplicationVolume(data.TableData[1], i, i + 6).ToString() + " Fulls Compl.");
                        }
                        else
                        {
                            int dailyReceived = int.Parse(data.TableData[1].Rows[i - 1][0].ToString());
                            int dailyFullsReceived = int.Parse(data.TableData[1].Rows[i - 1][1].ToString());
                            int dailyCompleted = int.Parse(data.TableData[1].Rows[i - 1][2].ToString());
                            int dailyFullsCompleted = int.Parse(data.TableData[1].Rows[i - 1][3].ToString());

                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.Font.Size = 10;
                            applicationInstance.Selection.Font.Bold = 0;
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.TypeText(dailyReceived.ToString() + " Rec'd");
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.TypeText(dailyFullsReceived.ToString() + " Fulls Rec'd");
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.TypeText(dailyCompleted.ToString() + " Compl.");
                            applicationInstance.Selection.InsertBreak(WdBreakType.wdLineBreak);
                            applicationInstance.Selection.TypeText(dailyFullsCompleted.ToString() + " Fulls Compl.");
                        }
                    }

                    curCol += 1;
                    if (curCol > 7)
                    {
                        curCol = 1;
                    }
                    applicationInstance.Selection.MoveRight(WdUnits.wdCell, 1, Type.Missing);
                }

                applicationInstance.Selection.HomeKey(WdUnits.wdStory, Type.Missing);
                string toSaveFileName = option.GetToSaveFilename();
                string sFileExtension = "docx";
                string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
                return new DocumentCompleteResult(tempFilePath, word, toSaveFileName);
            }
            catch (Exception ex)
            {
                if (word != null)
                    word.Quit(false);
                return null;
            }
        }

        private static int CountWeeklyReceivedApplicationVolume(DataTable table, int fromIndex, int toIndex)
        {
            int count = 0;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                if (i > table.Rows.Count)
                {
                    break;
                }
                count += int.Parse(table.Rows[i - 1][0].ToString());
            }
            return count;
        }

        private static int CountWeeklyFullsReceivedApplicationVolume(DataTable table, int fromIndex, int toIndex)
        {
            int count = 0;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                if (i > table.Rows.Count)
                {
                    break;
                }
                count += int.Parse(table.Rows[i - 1][1].ToString());
            }
            return count;
        }

        private static int CountWeeklyCompletedApplicationVolume(DataTable table, int fromIndex, int toIndex)
        {
            int count = 0;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                if (i > table.Rows.Count)
                {
                    break;
                }
                count += int.Parse(table.Rows[i - 1][2].ToString());
            }
            return count;
        }

        private static int CountWeeklyFullsCompletedApplicationVolume(DataTable table, int fromIndex, int toIndex)
        {
            int count = 0;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                if (i > table.Rows.Count)
                {
                    break;
                }
                count += int.Parse(table.Rows[i - 1][3].ToString());
            }
            return count;
        }
        #endregion

        #region YearlyBusiness
        public static DocumentCompleteResult YearlyBusiness(DocumentReportYearlyBusinessOption option)
        {
            WordService word = null;
            try
            {
                DocumentReportData data = LoadData(option);
                string templatePath = DownloadDocumentTemplate(WordDocumentType.YearlyBusiness);
                word = new WordService(templatePath, option.GetToSaveFilename(), false);
                Word.Document documentInstance = word.GetDocumentInstance();
                Word.Application applicationInstance = word.GetApplicationInstance();

                documentInstance.Bookmarks["Year"].Range.Text = data.BookmarkData["Year"];
                documentInstance.Bookmarks["CreatedDate"].Range.Text = data.BookmarkData["CreatedDate"];

                DateTime curDate = DateTime.Now;
                int curYear = curDate.Year;
                int curMonth = curDate.Month;

                for (int i = 1; i <= 12; i++)
                {
                    if (int.Parse(data.BookmarkData["Year"]) == curYear && i == curMonth)
                    {
                        documentInstance.Bookmarks["Month" + i].Range.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i) + " " + data.BookmarkData["Year"] + " (Incomplete)";
                    }
                    else
                    {
                        documentInstance.Bookmarks["Month" + i].Range.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i) + " " + data.BookmarkData["Year"];
                    }

                    if (int.Parse(data.BookmarkData["Year"]) == curYear && i > curMonth)
                    {
                        documentInstance.Bookmarks["Month" + i + "Data"].Select();
                        documentInstance.Bookmarks["Month" + i + "Data"].Range.Text = String.Empty;
                        applicationInstance.Selection.MoveLeft(WdUnits.wdCell, 1, Type.Missing);
                        applicationInstance.Selection.Text = String.Empty;
                    }
                    else
                    {
                        StringBuilder monthlyData = new StringBuilder();
                        for (int j = 1; j <= 8; j++)
                        {
                            monthlyData.Append(data.TableData[1].Rows[i - 1][j - 1]);
                            if (j < 8)
                            {
                                monthlyData.Append("\n");
                            }
                        }
                        documentInstance.Bookmarks["Month" + i + "Data"].Range.Text = monthlyData.ToString();
                    }
                }

                applicationInstance.Selection.HomeKey(WdUnits.wdStory, Type.Missing);
                string toSaveFileName = option.GetToSaveFilename();
                string sFileExtension = "docx";
                string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
                return new DocumentCompleteResult(tempFilePath, word, toSaveFileName);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region LoadData
        private static DocumentReportData LoadData(DocumentReportOption option)
        {
            try
            {
                int reportTypeValue = option.DocumentReportType.Value;
                if (reportTypeValue != DocumentReportType.CalendarValue)
                {
                    string url = string.Format("api/autodocumentreport/{0}", reportTypeValue);
                    string content = JsonConvert.SerializeObject(option);
                    HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<DocumentReportData>(jsonContent);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return null;
        }
        #endregion
    }
}
