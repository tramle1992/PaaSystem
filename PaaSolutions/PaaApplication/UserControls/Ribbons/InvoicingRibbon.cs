using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaaApplication.Forms.Invoicing;
using PaaApplication.Models.Common;
using Invoice.Infrastructure;

namespace PaaApplication.UserControls.Ribbons
{
    public partial class InvoicingRibbon : UserControl
    {
        public EventHandler<EventArgs> SearchInvoicesClick;
        public EventHandler<EventArgs> SearchApplicationsClick;
        public EventHandler<EventArgs> BillingMonthDoubleClick;
        public EventHandler<EventArgs> DgAllClientsClick;
        public EventHandler<EventArgs> DgSelectedClientsClick;
        public EventHandler<EventArgs> DgAllShownInvoicesClick;
        public EventHandler<EventArgs> DgSelectedInvoicesClick;
        public EventHandler<EventArgs> DgAllShownAppsClick;
        public EventHandler<EventArgs> DgSelectedAppsClick;
        public EventHandler<EventArgs> InvoicePrintMenuDoubleClick;
        public EventHandler<EventArgs> PrtClientCommonClick;
        public EventHandler<EventArgs> PrtSelectedInvoicesClick;
        public EventHandler<EventArgs> PrtAllInvoicesClick;
        public EventHandler<EventArgs> PrtAllShownInvsClick;
        public EventHandler<EventArgs> PrtSelectedInvsClick;
        public EventHandler<EventArgs> RefreshInvoiceClick;

        FormBillingManager formBilling;

        public InvoicingRibbon(FormBillingManager frmInvoice)
        {
            InitializeComponent();
            this.formBilling = frmInvoice;

            InvoiceApiRepository invoiceApiRepository = new InvoiceApiRepository();
            DateTime maxInvoiceDate = invoiceApiRepository.FindMaxInvoiceDate(); // UniversalTime
            DateTime currentBillingMonth = maxInvoiceDate.ToLocalTime(); // LocalTime
            frmInvoice.SetCurrentBillingMonth(currentBillingMonth);
            rbtnBillingMonth.Text = "Billing: " + currentBillingMonth.ToString("MM/yy");
            rbtnBillingMonthSub1.Text = DateTime.Now.ToString("MM/yyyy");
            rbtnBillingMonthSub2.Text = DateTime.Now.AddMonths(-1).ToString("MM/yyyy");
            rbtnBillingMonthSub3.Text = DateTime.Now.AddMonths(-2).ToString("MM/yyyy");
            rbtnBillingMonthSub1.Click += rbtnBillingMonthSub_Click;
            rbtnBillingMonthSub2.Click += rbtnBillingMonthSub_Click;
            rbtnBillingMonthSub3.Click += rbtnBillingMonthSub_Click;
        }

        public void InitializeSearchForm(Form frm)
        {
            frm.Location = new Point(rpnlSearchInvoices.Bounds.X + 12, rpnlSearchInvoices.Bounds.Y + 108);
            frm.StartPosition = FormStartPosition.Manual;
            frm.BringToFront();
        }

        public void CloseBillingMonthDropDown()
        {
            rbtnBillingMonth.CloseDropDown();
        }

        public void CloseInvPrintMenuDropDown()
        {
            rbtnInvoicePrintMenu.CloseDropDown();
        }

        public WordDocumentType GetDocType(RibbonButton rbtn)
        {
            if (rbtn == rbtnPrtClientInfoSheet)
            {
                return WordDocumentType.ClientInfo;
            }
            else if (rbtn == rbtnPrtResidentClienCtact)
            {
                return WordDocumentType.ResidentialContract;
            }
            else if (rbtn == rbtnPrtEmpServCtact)
            {
                return WordDocumentType.EmploymentContract;
            }
            return WordDocumentType.ClientInfo;
        }

        #region Click Events
        private void rbtnSearchInvoices_Click(object sender, EventArgs e)
        {
            if (SearchInvoicesClick != null)
            {
                SearchInvoicesClick(sender, e);
            }
        }

        private void rbtnSearchApplications_Click(object sender, EventArgs e)
        {
            if (SearchApplicationsClick != null)
            {
                SearchApplicationsClick(sender, e);
            }
        }

        private void rbtnBillingMonth_DoubleClick(object sender, EventArgs e)
        {
            if (BillingMonthDoubleClick != null)
            {
                BillingMonthDoubleClick(sender, e);
            }
        }

        private void rbtnDgAllClients_Click(object sender, EventArgs e)
        {
            if (DgAllClientsClick != null)
            {
                DgAllClientsClick(sender, e);
            }
        }

        private void rbtnDgSelectedClients_Click(object sender, EventArgs e)
        {
            if (DgSelectedClientsClick != null)
            {
                DgSelectedClientsClick(sender, e);
            }
        }

        private void rbtnDgAllShownInvoices_Click(object sender, EventArgs e)
        {
            if (DgAllShownInvoicesClick != null)
            {
                DgAllShownInvoicesClick(sender, e);
            }
        }

        private void rbtnDgSelectedInvoices_Click(object sender, EventArgs e)
        {
            if (DgSelectedInvoicesClick != null)
            {
                DgSelectedInvoicesClick(sender, e);
            }
        }

        private void rbtnDgAllShownApps_Click(object sender, EventArgs e)
        {
            if (DgAllShownAppsClick != null)
            {
                DgAllShownAppsClick(sender, e);
            }
        }

        private void rbtnDgSelectedApps_Click(object sender, EventArgs e)
        {
            if (DgSelectedAppsClick != null)
            {
                DgSelectedAppsClick(sender, e);
            }
        }

        private void rbtnInvoicePrintMenu_DoubleClick(object sender, EventArgs e)
        {
            if (InvoicePrintMenuDoubleClick != null)
            {
                InvoicePrintMenuDoubleClick(sender, e);
            }
        }

        private void rbtnPrtClientCommon_Click(object sender, EventArgs e)
        {
            if (PrtClientCommonClick != null)
            {
                PrtClientCommonClick(sender, e);
            }
        }

        private void rbtnPrtSelectedInvoices_Click(object sender, EventArgs e)
        {
            if (PrtSelectedInvoicesClick != null)
            {
                PrtSelectedInvoicesClick(sender, e);
            }
        }

        private void rbtnPrtAllInvoices_Click(object sender, EventArgs e)
        {
            if (PrtAllInvoicesClick != null)
            {
                PrtAllInvoicesClick(sender, e);
            }
        }

        private void rbtnPrtAllShownInvs_Click(object sender, EventArgs e)
        {
            if (PrtAllShownInvsClick != null)
            {
                PrtAllShownInvsClick(sender, e);
            }
        }

        private void rbtnPrtSelectedInvs_Click(object sender, EventArgs e)
        {
            if (PrtSelectedInvsClick != null)
            {
                PrtSelectedInvsClick(sender, e);
            }
        }

        private void rbtnRefreshInvoice_Click(object sender, EventArgs e)
        {
            if (RefreshInvoiceClick != null)
            {
                RefreshInvoiceClick(sender, e);
            }
        }

        private void rbtnBillingMonthSub_Click(object sender, EventArgs e)
        {
            RibbonButton rbtn = sender as RibbonButton;
            DateTime currentBillingMonth;
            if (rbtn == rbtnBillingMonthSub1)
            {
                currentBillingMonth = DateTime.Now;
            }
            else if (rbtn == rbtnBillingMonthSub2)
            {
                currentBillingMonth = DateTime.Now.AddMonths(-1);
            }
            else // rbtn == rbtnBillingMonthSub3
            {
                currentBillingMonth = DateTime.Now.AddMonths(-2);
            }
            rbtnBillingMonth.Text = "Billing: " + currentBillingMonth.ToString("MM/yy");
            if (formBilling != null)
            {
                formBilling.SetCurrentBillingMonth(currentBillingMonth);
            }
        }
        #endregion
    }
}
