using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Word = NetOffice.WordApi;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using NetOffice.WordApi.Enums;
using NetOffice;
using Common.Infrastructure.Helper;

namespace Common.Infrastructure.Office
{
    public enum FileType
    {
        Word,
        PDF
    }
    public class WordService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Object oMissing = Type.Missing;
        private Object oTrue = true;
        private Object oFalse = false;
        private Object oToSaveFilename;
        private Word.Document oDocument;
        //private Word.DocumentClass oDocumentClass;
        private Word.Application oApplication;
        //private Word.ApplicationClass oApplicationClass;
        private FileType fileType = FileType.Word;
        private string sFileExtension = "docx";
        private string sPDFPath;
        private string sWordPath;

        public event EventHandler OnApplicationQuit;

        // Attach FormProgress.SetProgress to this delegate type
        public delegate void WordServiceMakeProgressEventHandler(int percent, string status);

        // Fire MakeProgress event when you want to update the progress form
        public event WordServiceMakeProgressEventHandler MakeProgress;

        public delegate bool WordServiceCheckCancellationEventHandler();

        public event WordServiceCheckCancellationEventHandler CheckCancellation;

        public WordService()
        {
            oApplication = new Word.Application();
            oApplication.Visible = false;
            InitEventHandler();
        }

        public WordService(string templatePath, string toSaveFilename, bool visible, bool autoOpenDocument = true)
        {
            Init(templatePath, toSaveFilename, visible, autoOpenDocument);
        }

        public void Init(string templatePath, string toSaveFilename, bool visible, bool autoOpenDocument = true)
        {
            try
            {
                oToSaveFilename = toSaveFilename;
                oApplication = new Word.Application();
                oApplication.Visible = visible;

                if (string.IsNullOrEmpty(templatePath) && autoOpenDocument)
                {
                    oDocument = oApplication.Documents.Add();
                }
                else if (!string.IsNullOrEmpty(templatePath))
                {
                    oDocument = oApplication.Documents.Add(templatePath);
                }

                // Set filename in Save dialog
                if (!string.IsNullOrEmpty(toSaveFilename) && oDocument != null)
                {
                    Word.Dialog dialog = oApplication.Dialogs[WdWordDialog.wdDialogFileSummaryInfo];
                    System.Type dialogType = dialog.UnderlyingObject.GetType();
                    string[] args = new string[1] { toSaveFilename };
                    dynamic d = dialog.UnderlyingObject;
                    d.Title = toSaveFilename;
                    dialog.Execute();
                }

                // Init events
                InitEventHandler();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                this.Quit(false);
                throw new Exception("Cannot open report template. Please check if you generate reports for same applicant");
            }
        }

        private void InitEventHandler()
        {
            oApplication.QuitEvent += new NetOffice.WordApi.Application_QuitEventHandler(Application_Event_Quit);
        }

        public void AssignActiveDocument()
        {
            if (oApplication.Documents.Count > 0 && 
                oApplication.ActiveDocument != null &&
                oDocument == null)
            {
                oDocument = oApplication.ActiveDocument;
            }
        }

        private void Application_Event_Quit()
        {
            if (OnApplicationQuit != null)
            {
                OnApplicationQuit(this, null);
            }
        }

        public Word.Range GetLastWord()
        {
            try
            {
                if (oDocument != null)
                {
                    return oDocument.Words.Last;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return null;
        }

        public void InsertBreakToLast()
        {
            try
            {
                GetLastWord().InsertBreak(WdBreakType.wdPageBreak);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void AddTable(Word.Range range, int numRows, int numColumns, object defaultTableBehavior, object autoFitBehavior)
        {
            try
            {
                if (oDocument != null)
                {
                    if (range != null)
                    {
                        oDocument.Tables.Add(range, numRows, numColumns, defaultTableBehavior, autoFitBehavior);
                    }
                    else
                    {
                        object start = 0;
                        object end = 0;
                        Word.Range tableLocation = oDocument.Range(start, end);
                        oDocument.Tables.Add(tableLocation, numRows, numColumns, defaultTableBehavior, autoFitBehavior);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void AddTableRow(int tableIndex, object beforeRow)
        {
            try
            {
                if (oDocument != null)
                {
                    oDocument.Tables[tableIndex].Rows.Add(beforeRow);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public Word.Borders GetTableBorders(int tableIndex)
        {
            try
            {
                if (oDocument != null)
                {
                    return oDocument.Tables[tableIndex].Borders;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return null;
        }

        public void SetCellText(int tableIndex, int rowIndex, int columnIndex, string text)
        {
            try
            {
                if (oDocument != null)
                {
                    oDocument.Tables[tableIndex].Cell(rowIndex, columnIndex).Range.Text = text;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void SetCellHeight(int tableIndex, int rowIndex, int columnIndex, int height)
        {
            try
            {
                if (oDocument != null)
                {
                    oDocument.Tables[tableIndex].Cell(rowIndex, columnIndex).Height = height;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void SetCellWidth(int tableIndex, int rowIndex, int columnIndex, int width)
        {
            try
            {
                if (oDocument != null)
                {
                    oDocument.Tables[tableIndex].Cell(rowIndex, columnIndex).Width = width;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public Word.Range GetCellFormattedText(int tableIndex, int rowIndex, int columnIndex)
        {
            try
            {
                if (oDocument != null)
                {
                    return oDocument.Tables[tableIndex].Cell(rowIndex, columnIndex).Range.FormattedText;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return null;
        }

        public Word.ParagraphFormat GetCellParagraphFormat(int tableIndex, int rowIndex, int columnIndex)
        {
            try
            {
                if (oDocument != null)
                {
                    return oDocument.Tables[tableIndex].Cell(rowIndex, columnIndex).Range.ParagraphFormat;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return null;
        }

        public void MergeTableCell(int tableIndex, int fromRowIndex, int fromColumnIndex, int toRowIndex, int toColumnIndex)
        {
            try
            {
                if (oDocument != null)
                {
                    Word.Table table = oDocument.Tables[tableIndex];
                    table.Cell(fromRowIndex, fromColumnIndex).Merge(table.Cell(toRowIndex, toColumnIndex));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void AppendDocument(string templatePath)
        {
            try
            {
                if (oDocument != null)
                {
                    GetLastWord().InsertFile(templatePath);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void SetVisible(bool visible)
        {
            try
            {
                if (oApplication != null)
                {
                    oApplication.Visible = visible;
                    if (visible == true)
                    {
                        oApplication.Activate();
                        foreach (Word.Window window in oApplication.Windows)
                        {
                            window.WindowState = WdWindowState.wdWindowStateMinimize;
                            window.WindowState = WdWindowState.wdWindowStateMaximize;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public bool GetVisible()
        {
            try
            {
                if (oApplication != null)
                {
                    return oApplication.Visible;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return false;
        }

        public void SetFileType(FileType fileType)
        {
            try
            {
                this.fileType = fileType;
                if (fileType == FileType.Word)
                {
                    sFileExtension = "doc";
                }
                else if (fileType == FileType.PDF)
                {
                    sFileExtension = "pdf";
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public FileType GetFileType()
        {
            return this.fileType;
        }

        public void Fill(Dictionary<string, string> bookmarkData, Dictionary<int, DataTable> tableData)
        {
            if (bookmarkData.Count == 0)
            {
                return;
            }
            else
            {
                FillBookmark(bookmarkData);
            }
            if (tableData.Count == 0)
            {
                return;
            }
            else
            {
                FillTable(tableData);
            }
        }

        public void FillBookmark(Dictionary<string, string> bookmarkData)
        {
            if (bookmarkData.Count == 0)
            {
                return;
            }
            try
            {
                if (oDocument != null)
                {
                    foreach (string key in bookmarkData.Keys)
                    {
                        string value = null;
                        if (bookmarkData.TryGetValue(key, out value))
                        {
                            oDocument.Bookmarks[key].Range.Text = value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void InsertTable(DataTable tableData)
        {
            try
            {
                int percentage = 0;
                object start = 0;
                object end = 0;
                Word.Range tableLocation = oDocument.Range(start, end);
                Word.Table table = oDocument.Tables.Add(tableLocation, tableData.Rows.Count + 1, tableData.Columns.Count, oMissing, oMissing);

                for (int i = 0; i < tableData.Columns.Count; i++)
                {
                    table.Cell(1, i + 1).Range.Text = tableData.Columns[i].ColumnName;
                    table.Cell(1, i + 1).Range.Bold = 1;
                    table.Cell(1, i + 1).Range.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
                    table.Cell(1, i + 1).Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
                    table.Cell(1, i + 1).Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                    table.Cell(1, i + 1).Range.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;
                }

                int rowCount = tableData.Rows.Count;

                for (int i = 0; i < tableData.Rows.Count; i++)
                {
                    for (int j = 0; j < tableData.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = tableData.Rows[i][j].ToString();
                        table.Cell(i + 2, j + 1).Range.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
                        table.Cell(i + 2, j + 1).Range.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
                        table.Cell(i + 2, j + 1).Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                        table.Cell(i + 2, j + 1).Range.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;
                    }
                    if (MakeProgress != null)
                    {
                        percentage = (100 * i) / rowCount;
                        string status = string.Format("{0} of 100%", percentage);
                        MakeProgress(percentage, status);
                    }
                    if (CheckCancellation != null)
                    {
                        bool isCancellation = CheckCancellation();
                        if (isCancellation == true)
                        {
                            this.Quit(false);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void FillTable(Dictionary<int, DataTable> tableData)
        {
            if (tableData.Count == 0)
            {
                return;
            }
            try
            {
                if (oDocument != null)
                {
                    foreach (int key in tableData.Keys)
                    {
                        DataTable value = null;
                        if (tableData.TryGetValue(key, out value))
                        {
                            Word.Table table = oDocument.Tables[key];
                            int rowCount = value.Rows.Count;
                            int columnCount = value.Columns.Count;
                            for (int i = 0; i < rowCount; i++)
                            {
                                table.Rows.Add(oMissing);
                                for (int j = 0; j < columnCount; j++)
                                {
                                    table.Cell(i + 2, j + 1).Range.Text = value.Rows[i][j].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void FillTable(int key, DataTable tableData, int startRow)
        {
            try
            {
                if (oDocument != null)
                {
                    Word.Table table = oDocument.Tables[key];
                    int test = table.Rows.Count;
                    int col = table.Columns.Count;
                    int rowCount = tableData.Rows.Count;
                    int columnCount = tableData.Columns.Count;
                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            table.Cell(i + startRow, j + 1).Range.Text = tableData.Rows[i][j].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void Protect()
        {
            try
            {
                if (oDocument != null)
                {
                    oDocument.Protect(WdProtectionType.wdAllowOnlyFormFields, oTrue, oMissing, oMissing, oMissing);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public Word.Document GetDocumentInstance()
        {
            try
            {
                if (oDocument != null)
                {
                    return oDocument;
                }
                else if (oApplication != null)
                {
                    if (oApplication.ActiveDocument != null)
                    {
                        oDocument = oApplication.ActiveDocument;
                        return oDocument;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return null;
        }

        public Word.Application GetApplicationInstance()
        {
            try
            {
                if (oApplication != null)
                {
                    return oApplication;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return null;
        }

        public string GetWorkingFilePath()
        {
            try
            {
                string workingFilePath = null;
                if (fileType == FileType.Word)
                {
                    string documentFullName = string.Empty;
                    if (oDocument != null)
                    {
                        documentFullName = oDocument.FullName;
                    }
                    if (documentFullName.Contains("\\") && documentFullName.Contains("."))
                    {
                        workingFilePath = documentFullName;
                    }
                    else if (!string.IsNullOrEmpty(sWordPath))
                    {
                        workingFilePath = sWordPath;
                    }
                }
                else if (fileType == FileType.PDF && !string.IsNullOrEmpty(sPDFPath))
                {
                    workingFilePath = sPDFPath;
                }
                    
                if (string.IsNullOrEmpty(workingFilePath))
                {
                    string tempFilePath = null;
                    string tempFileName = string.IsNullOrEmpty((string)oToSaveFilename) == true ? "Document" : (string)oToSaveFilename;
                    tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), tempFileName, sFileExtension);

                    if (fileType == FileType.Word)
                    {
                        sWordPath = tempFilePath;
                    }
                    else if (fileType == FileType.PDF)
                    {
                        sPDFPath = tempFilePath;
                    }                        

                    return tempFilePath;
                }
                else
                {
                    return workingFilePath;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return null;
        }

        public void SaveDocumentByPath(string filePath)
        {
            try
            {
                if (oDocument != null)
                {
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        oDocument.SaveAs(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void Print(int copies)
        {
            try
            {
                if (oDocument != null)
                {
                    object oCopies = copies;
                    object oRange = WdPrintOutRange.wdPrintAllDocument;
                    object oPageType = WdPrintOutPages.wdPrintAllPages;
                    object oItem = WdPrintOutItem.wdPrintDocumentContent;
                    oDocument.PrintOut(
                        oFalse, oFalse, oRange, oMissing, oMissing, oMissing,
                        oItem, oCopies, oMissing, oPageType, oFalse, oTrue,
                        oMissing, oFalse, oMissing, oMissing, oMissing, oMissing);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void SendFax(string fax)
        {
            try
            {
                if (oDocument != null)
                {
                    oDocument.SendFax(fax);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void ExportPDF(string filePath, bool openAfterExport)
        {
            try
            {
                if (oDocument != null)
                {
                    oDocument.ExportAsFixedFormat(filePath, WdExportFormat.wdExportFormatPDF, openAfterExport);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw new IOException("Cannot generate Pdf file. Please close any programs currently the export path");
            }
        }

        public void Quit(bool saveChanges = false)
        {
            try
            {
                if (oApplication != null)
                {
                    object oSaveChanges;
                    if (saveChanges)
                    {
                        oSaveChanges = WdSaveOptions.wdSaveChanges;
                    }
                    else
                    {
                        oSaveChanges = WdSaveOptions.wdDoNotSaveChanges;
                    }
                    oApplication.Quit(oSaveChanges);
                    oApplication.Dispose();
                    oApplication = null;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }
    }
}
