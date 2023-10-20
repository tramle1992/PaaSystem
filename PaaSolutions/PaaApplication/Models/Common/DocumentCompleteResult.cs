using Common.Infrastructure.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = NetOffice.WordApi;
using Outlook = NetOffice.OutlookApi;
using Common.Infrastructure.Office;
using System.IO;
using System.Windows.Forms;

namespace PaaApplication.Models.Common
{
    public class DocumentCompleteResult
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private WordService word;

        private string filePath;
        private string emailSubject;
        private bool exportedPDF = false;

        public string EmailBody { get; set; }


        public event EventHandler OnWordClose;
        public event EventHandler OnOutlookClose;

        public DocumentCompleteResult(string filePath, WordService word, string emailSubject)
        {
            this.word = word;
            this.filePath = filePath;
            this.emailSubject = emailSubject;
            this.EmailBody = string.Empty;
            word.OnApplicationQuit += OnWordCloseHandler;
        }

        private void OnWordCloseHandler(object sender, EventArgs e)
        {
            EventHandler handler = OnWordClose;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnOutlookCloseHandler(object sender, EventArgs e)
        {
            EventHandler handler = OnOutlookClose;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void SetWordDocumentVisible(bool visible)
        {
            if (this.word != null)
            {
                this.word.SetVisible(visible);
            }
        }

        public bool GetWordDocumentVisible()
        {
            if (this.word != null)
            {
                return this.word.GetVisible();
            }
            return false;
        }

        public void PrintWordDocument(int numberOfCopies)
        {
            if (this.word != null)
            {
                this.word.Print(numberOfCopies);
            }
        }

        public void SendOutlookEmail(string emailTo)
        {
            OutlookService outlook = null;
            try
            {
                if (this.word != null)
                {
                    string workingFilePath = GetFilePath();

                    if (!string.IsNullOrEmpty(workingFilePath))
                    {
                        if (this.word.GetFileType() == FileType.Word)
                        {
                            this.word.SaveDocumentByPath(workingFilePath);
                        }
                        else if (this.word.GetFileType() == FileType.PDF)
                        {
                            string extension = Path.GetExtension(workingFilePath);
                            if (extension.ToLower() != "pdf")
                            {
                                workingFilePath = Path.ChangeExtension(workingFilePath, "pdf");
                            }
                            ExportPDF(workingFilePath, false);
                        }
                    }
                    else
                    {
                        workingFilePath = GetWordWorkingFilePath();
                    }
                    outlook = new OutlookService(emailSubject, emailTo, string.Empty, this.EmailBody, workingFilePath);
                    if (outlook != null)
                    {
                        outlook.OnOutlookClose += OnOutlookCloseHandler;
                        outlook.Send();
                    }
                }
            }
            catch (Exception ex)
            {
                if (outlook != null)
                    outlook.Quit();
            }
        }

        public void ShowOutlookEmail(string emailTo)
        {
            OutlookService outlook = null;
            try
            {
                if (this.word != null)
                {
                    string workingFilePath = GetFilePath();

                    if (!string.IsNullOrEmpty(workingFilePath))
                    {
                        if (this.word.GetFileType() == FileType.Word)
                        {
                            this.word.SaveDocumentByPath(workingFilePath);
                        }
                        else if (this.word.GetFileType() == FileType.PDF)
                        {
                            string extension = Path.GetExtension(workingFilePath);
                            if (extension.ToLower() != "pdf")
                            {
                                workingFilePath = Path.ChangeExtension(workingFilePath, "pdf");
                            }
                            ExportPDF(workingFilePath, false);
                        }
                    }
                    else
                    {
                        workingFilePath = GetWordWorkingFilePath();
                    }
                    outlook = new OutlookService(emailSubject, emailTo, string.Empty, this.EmailBody, workingFilePath);
                    if (outlook != null)
                    {
                        outlook.OnOutlookClose += OnOutlookCloseHandler;
                        outlook.Display();
                    }
                }
            }
            catch (Exception ex)
            {
                if (outlook != null)
                    outlook.Quit();
            }
        }

        public void SendFax(string fax)
        {
            if (this.word != null)
                word.SendFax(fax);
        }

        public void ExportPDF(string filePath, bool openAfterExport)
        {
            try
            {
                if (this.word != null)
                {
                    this.word.ExportPDF(filePath, openAfterExport);
                    this.exportedPDF = true;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        public string GetWordWorkingFilePath()
        {
            if (this.word != null)
            {
                return this.word.GetWorkingFilePath();
            }
            return null;
        }

        public string GetFilePath()
        {
            return this.filePath;
        }

        public void SetFileType(FileType fileType)
        {
            if (this.word != null)
            {
                this.word.SetFileType(fileType);
            }
        }

        public void QuitWordDocument(bool saveChanges)
        {
            if (this.word != null)
            {
                this.word.Quit(saveChanges);
            }
            this.word = null;
        }

    }
}
