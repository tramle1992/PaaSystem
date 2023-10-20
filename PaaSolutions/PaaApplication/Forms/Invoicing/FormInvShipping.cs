using Common.Infrastructure.UI;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using Invoice.Application.Command;
using Invoice.Application.Data;
using Invoice.Application.Helper;
using Invoice.Domain.Model;
using Invoice.Infrastructure;
using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.Invoicing
{
    public partial class FormInvShipping : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private InvoiceApiRepository invoiceApiRepository = new InvoiceApiRepository();
        private InvoiceItemApiRepository invoiceItemApiRepository = new InvoiceItemApiRepository();

        private FormBillingManager formBillingManager;

        private List<InvoiceData> newInvoiceList = new List<InvoiceData>();

        public FormInvShipping(FormBillingManager formBillingManager)
        {
            InitializeComponent();
            this.formBillingManager = formBillingManager;
        }

        private void FormAutomaticBilling_Load(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                try
                {
                    DateTime billingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
                    this.lblMonth.Text = billingMonth.ToString("MM/yyyy");
                    DateTimeZone tz = DateTimeZoneProviders.Tzdb.GetSystemDefault();
                    InvoiceCachedApiQuery.Instance.RemoveInvoicesByYearAndMonth(billingMonth.Year, billingMonth.Month);
                    List<InvoiceData> invoices = invoiceApiRepository.FindByYearAndMonth(billingMonth.Year, billingMonth.Month, tz.Id);
                    newInvoiceList = invoices.OrderBy(x => x.ClientName).ThenBy(x => x.InvoiceNumber).ToList();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void FormAutomaticBilling_LoadCompleted(object sender, EventArgs e)
        {
        }

        private void btnBillApps_Click(object sender, EventArgs e)
        {
            var isPdf = this.chkInPdf.Checked;
            if (this.newInvoiceList != null && this.newInvoiceList.Count > 0)
            {
                DateTime billingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
                string subject = string.Format("Bemrose Invoice for {0}", billingMonth.ToString("MM/yy"));
                this.formBillingManager.EmailAndPrintInvoices(this.newInvoiceList, subject, true, isPdf);
            }

            this.Close();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
