using Common.Application;
using Core.Domain.Model.ExploreApps;
using Invoice.Domain.Model;
using Invoice.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMigrationApp
{
    public class InvoiceMigrationService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TimeZoneInfo pacificTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        private InvoiceRepository invoiceRepository = new InvoiceRepository();
        private InvoiceItemRepository invoiceItemRepository = new InvoiceItemRepository();
        private PaymentRepository paymentRepository = new PaymentRepository();
        private AppIdMappingRepository appIdMappingRepository = new AppIdMappingRepository();

        public Dictionary<string, string> appIdDictionary = new Dictionary<string, string>(); // oldAppId - newAppId

        public string SourceConnectionString { get; set; }

        public InvoiceMigrationService(string sourceConnectionString, Dictionary<string, string> appIdDictionary)
        {
            this.SourceConnectionString = sourceConnectionString;
            this.appIdDictionary = appIdDictionary;
        }

        public void MigrateInvoice()
        {
            try
            {
                DataTable sourceTable = new DataTable();

                invoiceItemRepository.RemoveAll();
                paymentRepository.RemoveAll();
                invoiceRepository.RemoveAll();

                _logger.Error("InvoiceMigrationService appIdDictionary Count: " + this.appIdDictionary.Count);
                if (this.appIdDictionary == null || this.appIdDictionary.Count == 0)
                {
                    this.appIdDictionary = new Dictionary<string, string>();
                    List<AppIdMapping> appIdMappingList = appIdMappingRepository.GetAll();
                    if (appIdMappingList != null && appIdMappingList.Count > 0)
                    {
                        _logger.Error("InvoiceMigrationService appIdMappingList Count: " + appIdMappingList.Count);
                        foreach (AppIdMapping appIdMapping in appIdMappingList)
                        {
                            this.appIdDictionary.Add(appIdMapping.OldAppId, appIdMapping.NewAppId);
                        }
                    }
                }

                using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                {
                    OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                    sourceAdapter.SelectCommand = new OleDbCommand("select * from Invoices", sourceConnection);
                    sourceAdapter.Fill(sourceTable);
                }

                foreach (DataRow row in sourceTable.Rows)
                {
                    try
                    {
                        Invoice.Domain.Model.InvoiceId invoiceId = new Invoice.Domain.Model.InvoiceId(Guid.NewGuid().ToString());
                        Invoice.Domain.Model.Invoice invoice = new Invoice.Domain.Model.Invoice(invoiceId);
                        invoice.ClientName = row.IsNull("ClientName") ? "" : row["ClientName"].ToString();
                        invoice.SoldToClientName = row.IsNull("SoldToClientName") ? "" : row["SoldToClientName"].ToString();
                        invoice.Address = row.IsNull("Address") ? "" : row["Address"].ToString();
                        invoice.InvoiceReference = row.IsNull("InvoiceReference") ? "" : row["InvoiceReference"].ToString();
                        invoice.CustomerNumber = row["CustomerNumber"].ToString();
                        invoice.InvoiceComments = row.IsNull("InvoiceComments") ? "" : row["InvoiceComments"].ToString();
                        invoice.InvoiceNumber = (int)(row["InvoiceNumber"]);
                        invoice.InvoiceDate = TimeZoneInfo.ConvertTimeToUtc(((DateTime)row["InvoiceDate"]).Date, pacificTimeZone);
                        invoice.NoteToClient = row.IsNull("NoteToClient") ? "" : row["NoteToClient"].ToString();
                        invoice.PONumber = row.IsNull("PONumber") ? "" : row["PONumber"].ToString();
                        invoice.InvoiceDivision = row.IsNull("InvoiceDivision") ? "" : row["InvoiceDivision"].ToString();

                        Invoice.Domain.Model.Status status;
                        string statusString = row.IsNull("Status") ? "" : row["Status"].ToString();
                        switch (statusString.Trim())
                        {
                            case "OVERPAY":
                                status = Invoice.Domain.Model.Status.OVER_PAY;
                                break;
                            case "PAST DUE":
                                status = Invoice.Domain.Model.Status.PAST_DUE;
                                break;
                            case "PAID":
                                status = Invoice.Domain.Model.Status.PAID;
                                break;
                            case "PD LATE":
                                status = Invoice.Domain.Model.Status.PD_LATE;
                                break;
                            case "UNPAID":
                                status = Invoice.Domain.Model.Status.UNPAID;
                                break;
                            default:
                                status = Invoice.Domain.Model.Status.PAID;
                                break;
                        }
                        invoice.Status = status;

                        Invoice.Domain.Model.ActionStatus actionStatus;
                        string actionStatusString = row.IsNull("ActionStatus") ? "" : row["ActionStatus"].ToString();
                        switch (statusString.Trim())
                        {
                            case "NONE":
                                actionStatus = Invoice.Domain.Model.ActionStatus.NONE;
                                break;
                            case "EMAILED":
                                actionStatus = Invoice.Domain.Model.ActionStatus.EMAILED;
                                break;
                            case "PRINTED":
                                actionStatus = Invoice.Domain.Model.ActionStatus.PRINTED;
                                break;
                            case "EMAILED_PRINTED":
                                actionStatus = Invoice.Domain.Model.ActionStatus.EMAILED_PRINTED;
                                break;
                                break;
                            default:
                                actionStatus = Invoice.Domain.Model.ActionStatus.NONE;
                                break;
                        }
                        invoice.ActionStatus = actionStatus;

                        try
                        {
                            invoice.Amount = decimal.Parse(row["Amount"].ToString());
                        }
                        catch (Exception ex)
                        {
                            invoice.Amount = 0;
                        }

                        try
                        {
                            invoice.Balance = decimal.Parse(row["Balance"].ToString());
                        }
                        catch (Exception ex)
                        {
                            invoice.Balance = 0;
                        }

                        invoiceRepository.Add(invoice);

                        string paymentsString = row.IsNull("Payments") ? "" : row["Payments"].ToString();
                        InsertPaymentsFromString(paymentsString, invoiceId);

                        string invoiceItemsString = row.IsNull("Items") ? "" : row["Items"].ToString();
                        InsertInvoiceItemsFromString(invoiceItemsString, invoiceId);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Data row: " + string.Join(",", row.ItemArray));
                        _logger.Error(ex);
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void InsertPaymentsFromString(string paymentsString,
            Invoice.Domain.Model.InvoiceId invoiceId)
        {
            if (!string.IsNullOrEmpty(paymentsString))
            {
                string[] paymentItemArr = paymentsString.Split(GlobalConstants.RecSep);
                foreach (string payment in paymentItemArr)
                {
                    try
                    {
                        string[] columns = payment.Split(GlobalConstants.Sep);
                        Invoice.Domain.Model.PaymentId paymentId = new Invoice.Domain.Model.PaymentId(Guid.NewGuid().ToString());
                        Invoice.Domain.Model.Payment paymentData = new Invoice.Domain.Model.Payment(paymentId, invoiceId);

                        try
                        {
                            paymentData.Amount = decimal.Parse(columns[2]);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex);
                            continue;
                        }

                        string[] dateStrArr = columns[3].Split('/');
                        int year;
                        int month;
                        int day;
                        if (dateStrArr.Length == 3)
                        {
                            if (dateStrArr[2].Length == 2)
                            {
                                dateStrArr[2] = "20" + dateStrArr[2];
                            }
                            year = int.Parse(dateStrArr[2]);
                            month = int.Parse(dateStrArr[0]);
                            day = int.Parse(dateStrArr[1]);
                        }
                        else if (dateStrArr.Length == 2)
                        {
                            if (dateStrArr[1].Length == 2)
                            {
                                dateStrArr[1] = "20" + dateStrArr[1];
                            }
                            year = int.Parse(dateStrArr[1]);
                            month = int.Parse(dateStrArr[0]);
                            day = 1;
                        }
                        else
                        {
                            continue;
                        }
                        DateTime date = new DateTime(year, month, day);
                        paymentData.Date = TimeZoneInfo.ConvertTimeToUtc(date.Date, pacificTimeZone);
                        paymentData.Check = columns[4];
                        paymentRepository.Add(paymentData);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex.ToString());
                    }
                }
            }
        }

        private void InsertInvoiceItemsFromString(string invoiceItemsString,
            Invoice.Domain.Model.InvoiceId invoiceId)
        {
            if (!string.IsNullOrEmpty(invoiceItemsString))
            {
                string[] invoiceItemArr = invoiceItemsString.Split(GlobalConstants.RecSep);
                foreach (string invoiceItem in invoiceItemArr)
                {
                    try
                    {
                        string[] columns = invoiceItem.Split(GlobalConstants.Sep);
                        columns[0] = columns[0].Trim();
                        string oldAppId = columns[0].Substring(0, columns[0].Length - 3); // sub " ID"
                        string newAppId = string.Empty;
                        if (this.appIdDictionary != null && this.appIdDictionary.Count > 0)
                        {
                            string value;
                            if (this.appIdDictionary.TryGetValue(oldAppId, out value))
                            {
                                newAppId = value;
                            }
                        }

                        Invoice.Domain.Model.InvoiceItemId invoiceItemId = new Invoice.Domain.Model.InvoiceItemId(Guid.NewGuid().ToString());
                        AppId applicationId = new AppId(newAppId);
                        Invoice.Domain.Model.InvoiceItem invoiceItemData = new Invoice.Domain.Model.InvoiceItem(invoiceItemId, invoiceId, applicationId);
                        invoiceItemData.Name = columns[2];
                        invoiceItemData.Description = columns[3];
                        string unitPriceStr = columns[4];
                        if (unitPriceStr.IndexOf("$") == 0)
                        {
                            unitPriceStr = unitPriceStr.Substring(1);
                        }
                        decimal unitPrice;
                        if (!decimal.TryParse(unitPriceStr, out unitPrice))
                        {
                            unitPrice = 0;
                        }
                        invoiceItemData.UnitPrice = unitPrice;
                        invoiceItemRepository.Add(invoiceItemData);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex.ToString());
                    }
                }
            }
        }
    }
}
