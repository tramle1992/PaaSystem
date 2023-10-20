using Common.Infrastructure.UI;
using Core.Application.Data.ClientInfo;
using Invoice.Application.Data;
using Invoice.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.Invoicing
{
    public partial class FormNewInvoice : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public enum Action
        {
            NewInvoice,
            ViewInvoices
        }

        private ClientData client;
        private DateTime billingMonth; // LocalTime

        private Action formAction;
        private string selectedInvoiceDivision = string.Empty;

        public Action FormAction
        {
            get { return this.formAction; }
        }

        public string SelectedInvoiceDivision
        {
            get { return this.selectedInvoiceDivision; }
        }

        public FormNewInvoice(ClientData client, DateTime billingMonth)
        {
            InitializeComponent();
            this.client = client;
            this.billingMonth = billingMonth;
        }

        private void FormNewInvoice_Load(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                try
                {
                    if (this.billingMonth != null)
                    {
                        this.Text = "New " + this.billingMonth.ToString("MM/yy") + " Invoice";
                    }
                    else
                    {
                        this.Text = "New Invoice";
                    }

                    if (this.client.ClientName != null && !string.IsNullOrEmpty(this.client.ClientName))
                    {
                        this.lblClientName.Text = this.client.ClientName;
                    }
                    else
                    {
                        this.lblClientName.Visible = false;
                    }

                    if (this.client.InvoiceDivisions != null && this.client.InvoiceDivisions.Count > 0)
                    {
                        foreach (InvoiceDivisionData invoiceDivision in this.client.InvoiceDivisions)
                        {
                            this.lstInvoiceDivisions.Items.Add(invoiceDivision.DivisionName);
                        }
                        this.lstInvoiceDivisions.SelectedIndex = 0;
                    }
                    else
                    {
                        this.lstInvoiceDivisions.Visible = false;
                        this.Height = 150;
                    }

                    List<InvoiceData> invoices = new List<InvoiceData>();
                    List<InvoiceData> allInvoicesInMonth = InvoiceCachedApiQuery.Instance.
                        GetInvoicesByYearAndMonth(billingMonth.Year, billingMonth.Month);
                    if (allInvoicesInMonth != null && allInvoicesInMonth.Count > 0)
                    {
                        invoices = allInvoicesInMonth.FindAll(r => (!string.IsNullOrEmpty(r.ClientName) &&
                                                                r.ClientName.Equals(this.client.ClientName)));
                    }
                    if (invoices == null || invoices.Count == 0)
                    {
                        this.btnViewInvoices.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void FormNewInvoice_LoadCompleted(object sender, EventArgs e)
        {
        }

        private void lstInvoiceDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstInvoiceDivisions.SelectedIndex >= 0)
            {
                this.selectedInvoiceDivision = this.lstInvoiceDivisions.SelectedItem as string;
            }
        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            this.formAction = Action.NewInvoice;
            this.DialogResult = DialogResult.OK;
        }

        private void btnViewInvoices_Click(object sender, EventArgs e)
        {
            this.formAction = Action.ViewInvoices;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
