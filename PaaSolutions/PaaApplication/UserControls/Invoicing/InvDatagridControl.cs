using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoice.Application.Data;
using Common.Infrastructure.OLV;
using Invoice.Domain.Model;
using System.Globalization;
using PaaApplication.Forms.Invoicing;
using Common.Infrastructure.Csv;
using PaaApplication.Forms;
using PaaApplication.Forms.Common;
using PaaApplication.Models.Common;
using Common.Infrastructure.Office;
using System.IO;
using PaaApplication.Helper;
using Invoice.Application.Helper;

namespace PaaApplication.UserControls.Invoicing
{
    public partial class InvDatagridControl : UserControl
    {
        private List<InvoiceData> invList = null;
        private OLVColumnFormat olvFormat = new OLVColumnFormat();
        private DocumentCompleteResult documentResult;

        public InvDatagridControl()
        {
            InitializeComponent();
            IniOLVInvs();
            InvoiceData i = new InvoiceData();            
        }

        public void Refresh(List<InvoiceData> invs)
        {
            this.invList = invs;
            if (this.invList != null && this.invList.Count > 0)
            {
                this.olvInvoice.SetObjects(this.invList);
            }
            else
            {
                this.olvInvoice.ClearObjects();
            }
        }

        public void IniOLVInvs()
        {
            this.olvFormat.FormatMonthString(this.olvColMonth);

            this.olvColStatus.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    InvoiceData invoice = row as InvoiceData;
                    if (invoice != null && invoice.Status != null && !string.IsNullOrEmpty(invoice.Status.DisplayName))
                    {
                        return invoice.Status.DisplayName.ToUpper();
                    }
                }
                return Status.PAID.DisplayName.ToUpper();
            };

            this.olvColMonth.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    InvoiceData invoice = row as InvoiceData;
                    if (invoice != null)
                    {
                        return invoice.InvoiceDate.ToLocalTime();
                    }
                }
                return DateTime.Now;
            };

            this.olvColAmount.AspectToStringConverter = delegate(object aspect)
            {
                if (aspect != null)
                {
                    return "$" + ((decimal)aspect).ToString("N", CultureInfo.CurrentUICulture);
                }
                return "$0.00";
            };

            this.olvColBalance.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    InvoiceData invoice = row as InvoiceData;
                    if (invoice != null && invoice.Status != null)
                    {
                        //if (invoice.Status.Value == Status.PAST_DUE.Value)
                        //{
                        //    decimal total = invoice.Balance + InvoiceCalculationHelper.GetInterest(invoice);
                        //    return "$" + total.ToString("N", CultureInfo.CurrentUICulture);
                        //}
                        //else
                        //{
                        //    return "$" + invoice.Balance.ToString("N", CultureInfo.CurrentUICulture);
                        //}
                        return "$" + invoice.Balance.ToString("N", CultureInfo.CurrentUICulture);
                    }
                }
                return "$0.00";
            };

            this.olvColPayment.AspectGetter = delegate(object row)
            {
                if (row != null)
                {
                    InvoiceData invoice = row as InvoiceData;
                    string paymentStat = new InvStatsControl().GetPaymentStatus(invoice);
                    return paymentStat; 
                }
                return string.Empty;
            };
        }

        private void olvInvoice_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            int index = this.olvInvoice.Columns.IndexOf(this.olvColNumRow);
            if (index >= 0)
            {
                e.Item.SubItems[index].Text = (e.DisplayIndex + 1).ToString();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string strSearch = txtSearch.Text.Trim();

            if (e.KeyCode == Keys.Back && strSearch == string.Empty)
            {
                new ObjectListViewService().FilterOlv(this.olvInvoice, strSearch);
            }

            else if (e.KeyCode == Keys.Enter && strSearch.Length > 0)
            {
                new ObjectListViewService().FilterOlv(this.olvInvoice, strSearch);
            }
        }

        private void autoSizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ColumnHeader col in this.olvInvoice.Columns)
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
                if (col.Index == this.olvInvoice.Columns.Count - 1)
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
                csvService.WriteObjectListView(fileName, this.olvInvoice);
                MessageBox.Show("Export Csv File successfully!", "Csv Export Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void typeDatagridInMSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ObjectListViewService olvService = new ObjectListViewService();
                DataTable table = olvService.GetDataTableFromOlv(this.olvInvoice);

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

        private void truncateDatagridAfterThisRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.olvInvoice.SelectedIndex;
            if (selectedIndex < 0)
            {
                return;
            }

            List<InvoiceData> removeObjects = new List<InvoiceData>();
            for (int i = selectedIndex + 1; i < this.olvInvoice.GetItemCount(); i++)
            {
                removeObjects.Add((InvoiceData)this.olvInvoice.GetModelObject(i));
            }

            this.olvInvoice.RemoveObjects(removeObjects);
        }
    }
}
