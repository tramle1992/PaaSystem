using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Application.Data.ExploreApps;
using Common.Infrastructure.OLV;
using Common.Infrastructure.Csv;
using PaaApplication.Forms.Common;
using Common.Infrastructure.Office;
using PaaApplication.Models.Common;
using PaaApplication.Forms;
using Core.Infrastructure.ClientInfo;
using Core.Application.Data.ClientInfo;
using PaaApplication.Helper;
using System.IO;

namespace PaaApplication.UserControls.AppExplore
{
    public partial class AppDataGridControl : UserControl
    {
        private ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;

        private OLVColumnFormat olvFormat = new OLVColumnFormat();
        private DocumentCompleteResult documentResult;
        private List<AppData> appList = null;

        public AppDataGridControl()
        {
            InitializeComponent();
            InitOLVApps();
        }

        public void InitOLVApps()
        {
            this.olvFormat.FormatLongDateString(this.olvColReceiveDate);

            this.olvFormat.FormatCompletedDate(this.olvColCompleteDate);

            this.olvColName.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                    return Utils.GetApplicantName(app, reportType);
                }
                return "";
            };

            this.olvColClient.AspectGetter = delegate(object row)
            {
                AppData app = row as AppData;
                if (app != null)
                {
                    return Utils.GetClientName(app);
                }
                return "";
            };
        }

        public void Refresh(List<AppData> apps)
        {
            this.appList = apps;
            if (this.appList != null && this.appList.Count > 0)
            {
                this.olvApps.SetObjects(this.appList);
            }
            else
            {
                this.olvApps.ClearObjects();
            }
        }

        #region OLVApps
        private void olvApps_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            int index = this.olvApps.Columns.IndexOf(this.olvColNumRow);
            if (index >= 0)
            {
                e.Item.SubItems[index].Text = (e.DisplayIndex + 1).ToString();
            }
        }
        #endregion

        #region Search
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string strSearch = txtSearch.Text.Trim();
            bool hasChange = false;

            if (e.KeyCode == Keys.Back && strSearch == string.Empty)
            {
                new ObjectListViewService().FilterOlv(this.olvApps, strSearch);
                hasChange = true;
            }
            else if (e.KeyCode == Keys.Enter && strSearch.Length > 0)
            {
                new ObjectListViewService().FilterOlv(this.olvApps, strSearch);
                hasChange = true;
            }

            if (hasChange)
            {
            }
        }
        #endregion

        #region Context Menu
        private void autoSizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ColumnHeader col in this.olvApps.Columns)
            {
                int colWidthBeforeAutoResize = col.Width;
                col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                int colWidthAfterAutoResizeByHeader = col.Width;
                col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                int colWidthAfterAutoResizeByContent = col.Width;

                if (colWidthAfterAutoResizeByHeader > colWidthAfterAutoResizeByContent)
                {
                    col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }

                //last column
                if (col.Index == this.olvApps.Columns.Count - 1)
                {
                    //avoid "fill free space" bug
                    if (colWidthBeforeAutoResize > colWidthAfterAutoResizeByContent)
                    {
                        col.Width = colWidthBeforeAutoResize;
                    }
                    else
                    {
                        col.Width = colWidthAfterAutoResizeByContent;
                    }
                }
            }
        }

        private void expoertDatagridCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog csvSaveFileDialog = new SaveFileDialog();
            csvSaveFileDialog.DefaultExt = "csv";
            csvSaveFileDialog.Filter = "Csv files (*.csv)|*.csv|All files (*.*)|*.*";
            csvSaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (csvSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = csvSaveFileDialog.FileName;
                CsvService csvService = new CsvService();
                csvService.WriteObjectListView(fileName, this.olvApps);
                MessageBox.Show("Export Csv File successfully!", "Csv Export Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void typeDatagridInMSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectListViewService olvService = new ObjectListViewService();
                DataTable table = olvService.GetDataTableFromOlv(this.olvApps);

                FormProgress formProgress = new FormProgress();
                formProgress.Text = "Export Datagrid to Word";
                formProgress.Argument = table;
                formProgress.DoWork += new FormProgress.DoWorkEventHandler(exportOlvToWord_DoWork);
                DialogResult result = formProgress.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Operation has been cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (result == DialogResult.Abort)
                {
                    MessageBox.Show("Exception:" + Environment.NewLine + formProgress.Result.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (documentResult != null && result == DialogResult.OK)
                {
                    FormDocumentComplete dialog = new FormDocumentComplete("Bemrose Datagrid", documentResult);
                    dialog.StartPosition = FormStartPosition.CenterScreen;
                    dialog.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void truncateDatagridAfterThisRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.olvApps.SelectedIndex;
            if (selectedIndex < 0)
            {
                return;
            }

            List<AppData> removeObjects = new List<AppData>();
            for (int i = selectedIndex + 1; i < this.olvApps.GetItemCount(); i++)
            {
                removeObjects.Add((AppData)this.olvApps.GetModelObject(i));
            }

            this.olvApps.RemoveObjects(removeObjects);
        }
        #endregion

        #region Do Work Progress
        private void exportOlvToWord_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            TemplateHelper templateHelper = new TemplateHelper();
            string filename = WordTemplatePathResolver.GetTemplateFileName(WordDocumentType.DataGrid);
            if (!string.IsNullOrEmpty(filename))
            {
                string url = string.Format("api/templates");
                string savePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.DataGrid);
                templateHelper.DownloadTemplate(savePath, filename);
            }

            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.DataGrid);

            if (!File.Exists(templatePath))
                return; 

            DataTable table = (DataTable)e.Argument;
            WordService word = new WordService(templatePath, "Datagrid", false);
            word.MakeProgress += new WordService.WordServiceMakeProgressEventHandler(sender.SetProgress);
            word.CheckCancellation += new WordService.WordServiceCheckCancellationEventHandler(sender.IsCancellation);
            word.InsertTable(table);
            if (sender.CancelllationPending == true)
            {
                sender.DialogResult = DialogResult.Cancel;
                sender.SetProgress(sender.CancellingText);
                return;
            }
            sender.SetProgress(100, "Finish Operation");
            documentResult = new DocumentCompleteResult(null, word, "Data Grid");
        }
        #endregion

    }
}
