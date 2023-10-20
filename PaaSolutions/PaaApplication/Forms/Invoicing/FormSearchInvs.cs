using Common.Infrastructure.ComboBoxCustom;
using Common.Infrastructure.UI;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using Invoice.Application.Command;
using Invoice.Application.Data;
using Invoice.Domain.Model;
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
using PaaApplication.Helper;

namespace PaaApplication.Forms.Invoicing
{
    public partial class FormSearchInvs : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private InvoiceApiRepository invoiceApiRepository = new InvoiceApiRepository();

        private FormBillingManager formBillingManager;

        public event EventHandler<List<InvoiceData>> OnSearchInvoices;

        public FormSearchInvs(FormBillingManager formBillingManager)
        {
            InitializeComponent();
            this.formBillingManager = formBillingManager;
        }

        private void FormSearchInvs_LoadCompleted(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                try
                {
                    SetControlValues();

                    LoadClientsCheckedListBox();
                    LoadStatusCheckedListBox();
                    LoadComboBoxSearchIn();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void SetControlValues()
        {
            try
            {
                DateTime currentBillingMonth = this.formBillingManager.GetCurrentBillingMonth(); // LocalTime
                this.rdoInvsCreatedMonth1.Text = currentBillingMonth.ToString("MM/yyyy");
                this.rdoInvsCreatedMonth2.Text = currentBillingMonth.AddMonths(-1).ToString("MM/yyyy");
                this.dtmInvsCreatedFrom.Value = currentBillingMonth.Date.AddMonths(-1);
                this.dtmInvsCreatedTo.Value = currentBillingMonth.Date;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void LoadClientsCheckedListBox()
        {
            try
            {
                this.lboxClients.Items.Clear();
                this.lboxClients.ValueMember = "ClientId";
                this.lboxClients.DisplayMember = "ClientName";

                List<ClientData> clients = this.formBillingManager.formMaster.LIST_CLIENTS;
                if (clients != null && clients.Count > 0)
                {
                    ClientData allClients = new ClientData();
                    allClients.ClientId = "-1";
                    allClients.ClientName = "All Clients";
                    this.lboxClients.Items.Add(allClients);

                    foreach (ClientData client in clients)
                    {
                        this.lboxClients.Items.Add(client, false);
                    }

                    this.lboxClients.SetItemChecked(0, true);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void LoadStatusCheckedListBox()
        {
            this.lboxInvStatus.Items.Clear();
            this.lboxInvStatus.ValueMember = "Value";
            this.lboxInvStatus.DisplayMember = "DisplayName";

            foreach (StatusData status in SearchInvoiceStatusData.Data)
            {
                this.lboxInvStatus.Items.Add(status, false);
            }

            this.lboxInvStatus.SetItemChecked(0, true);
        }

        private void LoadComboBoxSearchIn()
        {
            this.cboSearchIn.Items.Clear();
            this.cboSearchIn.Items.AddRange(SearchInvoiceSearchInData.GetAllFields().ToArray());
            this.cboSearchIn.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchInvoiceCommand command = GetSearchInvoiceCommand();
                List<InvoiceData> invoices = invoiceApiRepository.SearchInvoice(command);
                if (this.OnSearchInvoices != null)
                {
                    this.OnSearchInvoices(this, invoices);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString());
            }

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cboSearchIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(this.cboKeyword, e, false);
        }

        private void cboKeyword_TextChanged(object sender, EventArgs e)
        {
            this.txtKeyword.Text = this.cboKeyword.Text;
        }

        private void cboSearchIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                try
                {
                    switch (this.cboSearchIn.Text)
                    {
                        case "Client Name":
                            this.cboKeyword.Items.Clear();
                            this.cboKeyword.ValueMember = "ClientId";
                            this.cboKeyword.DisplayMember = "ClientName";
                            List<ClientData> clients = this.formBillingManager.formMaster.LIST_CLIENTS;
                            if (clients != null && clients.Count > 0)
                            {
                                foreach (ClientData client in clients)
                                {
                                    this.cboKeyword.Items.Add(client);
                                }
                            }
                            this.cboKeyword.BringToFront();
                            break;
                        case "Customer Number":
                            this.cboKeyword.Items.Clear();
                            List<string> customerNumbers = this.formBillingManager.formMaster.LIST_CUSTOMER_NUMBERS;
                            if (customerNumbers != null && customerNumbers.Count > 0)
                            {
                                foreach (string customerNumber in customerNumbers)
                                {
                                    this.cboKeyword.Items.Add(customerNumber);
                                }
                            }
                            this.cboKeyword.BringToFront();
                            break;
                        case "Invoice Division":
                            this.cboKeyword.Items.Clear();
                            List<string> invoiceDivisions = this.formBillingManager.formMaster.LIST_INVOICE_DIVISIONS;
                            if (invoiceDivisions != null && invoiceDivisions.Count > 0)
                            {
                                foreach (string invoiceDivision in invoiceDivisions)
                                {
                                    this.cboKeyword.Items.Add(invoiceDivision);
                                }
                            }
                            this.cboKeyword.BringToFront();
                            break;
                        case "Status":
                            this.cboKeyword.Items.Clear();
                            this.cboKeyword.ValueMember = "Value";
                            this.cboKeyword.DisplayMember = "DisplayName";
                            foreach (Status status in Status.GetAll<Status>())
                            {
                                this.cboKeyword.Items.Add(new StatusData(status.Value, status.DisplayName.ToUpper()));
                            }
                            this.cboKeyword.BringToFront();
                            break;
                        default:
                            this.txtKeyword.BringToFront();
                            break;
                    }
                    this.cboKeyword.Text = this.txtKeyword.Text;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                }
            }
        }

        public SearchInvoiceCommand GetSearchInvoiceCommand()
        {
            SearchInvoiceCommand command = new SearchInvoiceCommand();

            DateTime? createdFrom;
            DateTime? createdTo;
            if (this.rdoInvsCreatedAnyTime.Checked)
            {
                createdFrom = null;
                createdTo = null;
            }
            else if (this.rdoInvsCreatedMonth1.Checked || this.rdoInvsCreatedMonth2.Checked)
            {
                RadioButton sender = this.rdoInvsCreatedMonth1.Checked ? this.rdoInvsCreatedMonth1 : this.rdoInvsCreatedMonth2;
                DateTime date;
                if (DateTime.TryParse(sender.Text, out date))
                {
                    createdFrom = new DateTime(date.Year, date.Month, 1).Date.ToUniversalTime();
                    createdTo = createdFrom.Value.AddMonths(1).AddSeconds(-5);
                }
                else
                {
                    createdFrom = null;
                    createdTo = null;
                }
            }
            else // rdoInvsCreatedBetween.Checked
            {
                DateTime dateFrom = this.dtmInvsCreatedFrom.Value;
                DateTime dateTo = this.dtmInvsCreatedTo.Value;
                createdFrom = new DateTime(dateFrom.Year, dateFrom.Month, 1).Date.ToUniversalTime();
                createdTo = new DateTime(dateTo.Year, dateTo.Month, 1).Date.AddMonths(1).AddSeconds(-5).ToUniversalTime();
            }
            command.CreatedFrom = createdFrom;
            command.CreatedTo = createdTo;

            if (this.rdoClientsAND.Checked)
            {
                command.ClientsOperator = true;
            }
            else
            {
                command.ClientsOperator = false;
            }

            HashSet<string> clientNames = new HashSet<string>();
            if (this.lboxClients.Items.Count > 0 &&
                this.lboxClients.CheckedItems.Count > 0 && !this.lboxClients.GetItemChecked(0))
            {
                foreach (ClientData client in this.lboxClients.CheckedItems)
                {
                    if (!string.IsNullOrEmpty(client.ClientName))
                    {
                        clientNames.Add(client.ClientName);
                    }
                }
            }
            command.ClientNames = clientNames.ToList<string>();

            if (this.rdoStatusAND.Checked)
            {
                command.StatusOperator = true;
            }
            else
            {
                command.StatusOperator = false;
            }

            List<int> statusValues = new List<int>();
            if (this.lboxInvStatus.Items.Count > 0 &&
                this.lboxInvStatus.CheckedItems.Count > 0 && !this.lboxInvStatus.GetItemChecked(0))
            {
                foreach (StatusData status in this.lboxInvStatus.CheckedItems)
                {
                    statusValues.Add(status.Value);
                }
            }
            command.StatusValues = statusValues;

            command.SearchIn = this.cboSearchIn.Text.Trim();
            if (command.SearchIn.Equals("Status"))
            {
                StatusData status = this.cboKeyword.SelectedItem as StatusData;
                if (status != null)
                {
                    command.Keyword = status.Value.ToString();
                }
                else
                {
                    command.Keyword = this.txtKeyword.Text.Trim();
                }
            }
            else
            {
                command.Keyword = this.txtKeyword.Text.Trim();
            }

            return command;
        }

        private void rdoInvsCreated_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if ((rb == this.rdoInvsCreatedAnyTime || rb == this.rdoInvsCreatedMonth1
                || rb == this.rdoInvsCreatedMonth2) && rb.Checked)
            {
                this.dtmInvsCreatedFrom.Enabled = false;
                this.dtmInvsCreatedTo.Enabled = false;
            }
            else if (rb == this.rdoInvsCreatedBetween && rb.Checked)
            {
                this.dtmInvsCreatedFrom.Enabled = true;
                this.dtmInvsCreatedTo.Enabled = true;
            }
        }

        private void FormSearchInvs_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                SetControlValues();
            }
        }

        #region Handle KeyPress Event of CheckedListBox
        string text;
        int lastTick;

        private void lboxClients_KeyPress(object sender, KeyPressEventArgs e)
        {
            EventHandlerHelper.CheckedListBoxSearch_KeyPress(sender, e);
        }

        #endregion
    }
}
