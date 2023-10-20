using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Application.Data.ClientInfo;
using IdentityAccess.Application.Data;
using Common.Infrastructure.OLV;
using System.IO;
using Common.Infrastructure.Csv;
using Common.Infrastructure.Office;
using PaaApplication.Forms.Common;
using PaaApplication.Models.Common;
using PaaApplication.Forms;
using PaaApplication.Helper;

namespace PaaApplication.UserControls.ClientInfo
{
    public partial class ClientDataGridControl : UserControl
    {
        private List<ClientGridData> _lstClientData;
        DocumentCompleteResult documentResult;

        public ClientDataGridControl()
        {
            InitializeComponent();
            _lstClientData = new List<ClientGridData>();
        }

        public void InitializeSettings()
        {

            olvColClientName.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                return clientGridData.ClientName;
            };

            olvColManagement.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                return clientGridData.ManagementName;
            };

            olvColPhone.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                return clientGridData.Phone;
            };

            olvColFax.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                return clientGridData.Fax;
            };

            olvColEmail.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                return clientGridData.Email;
            };

            olvColBillingAddress.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                return clientGridData.BillingAddress;
            };

            olvColMiscComments.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                return clientGridData.MiscComments;
            };

            olvColAdditionalBillingInfo.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                return clientGridData.BillingInfo;
            };

            olvColContacts.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                StringBuilder builder = new StringBuilder();
                if (clientGridData.Contacts.Count > 0)
                {
                    foreach (ContactData contact in clientGridData.Contacts)
                    {
                        builder.Append(contact.ContactInfo);
                        builder.Append(", ");
                    }
                    builder.Remove(builder.Length - 2, 2);
                }

                return builder.ToString();

            };

            olvColLastScreening.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                return "";

            };

            olvColScreeningLast12Months.AspectGetter = delegate(object row)
            {
                ClientGridData clientGridData = row as ClientGridData;
                return "@Todo";
            };
        }

        public void Refresh(List<ClientGridData> lst)
        {
            this._lstClientData = lst;
            olvClients.SetObjects(_lstClientData);
            olvClients.BuildList();
        }

        #region Search Box

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            string strSearch = (sender as TextBox).Text;
            string selectedText = (sender as TextBox).SelectedText;

            if (e.KeyCode == Keys.Back && strSearch.Length <= 1 || (selectedText.Length == strSearch.Length))
            {
                strSearch = string.Empty;
                new ObjectListViewService().FilterOlv(this.olvClients, strSearch);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                new ObjectListViewService().FilterOlv(this.olvClients, strSearch);
            }
        }


        #endregion

        #region Listview Events
        private void olvClients_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            int index = olvClients.Columns.IndexOf(olvColNumRow);
            if (index >= 0)
            {
                e.Item.SubItems[index].Text = (e.DisplayIndex + 1).ToString();
            }
        }
        #endregion

        #region Functionalities
        private void AutoSizeColumns()
        {
            foreach (ColumnHeader col in olvClients.Columns)
            {
                int colWidthBeforeAutoResize = col.Width;
                col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                int colWidthAfterAutoResizeByHeader = col.Width;
                col.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                int colWidthAfterAutoResizeByContent = col.Width;

                if (colWidthAfterAutoResizeByHeader > colWidthAfterAutoResizeByContent)
                    col.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

                //last column
                if (col.Index == olvClients.Columns.Count - 1)
                    //avoid "fill free space" bug
                    if (colWidthBeforeAutoResize > colWidthAfterAutoResizeByContent)
                        col.Width = colWidthBeforeAutoResize;
                    else
                        col.Width = colWidthAfterAutoResizeByContent;
            }
        }
        #endregion

        #region Context Menu
        private void autoSizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AutoSizeColumns();
        }

        private void truncateDatagridAfterThisRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = olvClients.SelectedIndex;
            if (selectedIndex < 0)
                return;
            List<ClientGridData> lstRemoveObjects = new List<ClientGridData>();
            for (int i = selectedIndex + 1; i < olvClients.GetItemCount(); i++)
            {
                lstRemoveObjects.Add((ClientGridData)olvClients.GetModelObject(i));
            }

            olvClients.RemoveObjects(lstRemoveObjects);
        }

        private void exportDatagridCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog csvSaveFileDialog = new SaveFileDialog();
            csvSaveFileDialog.DefaultExt = "csv";
            csvSaveFileDialog.Filter = "Csv files (*.csv)|*.csv|All files (*.*)|*.*";
            csvSaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (csvSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = csvSaveFileDialog.FileName;
                CsvService csvService = new CsvService();
                csvService.WriteObjectListView(fileName, this.olvClients);
                MessageBox.Show("Export Csv File successfully!", "Csv Export Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void typeDatagridInMSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObjectListViewService olvService = new ObjectListViewService();
            DataTable table = olvService.GetDataTableFromOlv(olvClients);

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
        #endregion

        #region Do Work Progress
        private void exportOlvToWord_DoWork(FormProgress sender, DoWorkEventArgs e)
        {
            DataTable table = (DataTable)e.Argument;
            TemplateHelper templateHelper = new TemplateHelper();
            string filename = WordTemplatePathResolver.GetTemplateFileName(WordDocumentType.DataGrid);
            if (!string.IsNullOrEmpty(filename))
            {
                string url = string.Format("api/templates");
                string savePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.DataGrid);
                templateHelper.DownloadTemplate(savePath, filename);
            }
            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.DataGrid);
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
