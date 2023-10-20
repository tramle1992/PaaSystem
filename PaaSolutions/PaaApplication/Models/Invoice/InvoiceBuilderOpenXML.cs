using Common.Application;
using Common.Infrastructure.Office;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ExploreApps;
using DocumentFormat.OpenXml.Packaging;
using Invoice.Application.Data;
using Invoice.Application.Helper;
using OpenXmlPowerTools;
using PaaApplication.Models.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.Invoice
{
    public class InvoiceBuilderOpenXML
    {
        private struct InvoicePastDueResult
        {
            public decimal SubTotal;
            public decimal Interest;
            public decimal Payment;
            public decimal Amount;
        }

        public static void InvoicePage(List<Source> sources, ClientData client, InvoiceData invoice, List<InvoiceItemData> invoiceItems, List<InvoiceData> outstandingInvoices)
        {
            int PageCount = invoiceItems.Count > 25 ? (invoiceItems.Count / 25) + ((invoiceItems.Count % 25) == 0 ? 0 : 1) : 1;

            InvoiceCalculationHelper.UpdateInvoiceStatus(invoice);
            foreach (var outstandingInvoice in outstandingInvoices)
            {
                InvoiceCalculationHelper.UpdateInvoiceStatus(outstandingInvoice);
            }

            for (int i = 1; i <= PageCount; i++)
            {
                string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.Invoice);
                byte[] byteArray = File.ReadAllBytes(templatePath);
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(byteArray, 0, (int)byteArray.Length);
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                    {
                        InvoiceInfo(wordDoc.MainDocumentPart, client, invoice, outstandingInvoices, i, PageCount);
                        InvoiceItems(wordDoc.MainDocumentPart, invoiceItems, i, PageCount);
                        wordDoc.Save();
                    }
                    sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
                }
            }
        }

        public static void InvoicesPastDueByClientPage(List<Source> sources, ClientData client, List<InvoiceData> invoices)
        {
            int PageCount = invoices.Count > 25 ? (invoices.Count / 25) + ((invoices.Count % 25) == 0 ? 0 : 1) : 1;
            decimal totalAmount = 0;
            decimal totalPayment = 0;
            decimal interest = 0;
            decimal total = 0;
            for (int i = 1; i <= PageCount; i++)
            {
                string templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.InvoicesClientPastDue);
                byte[] byteArray = File.ReadAllBytes(templatePath);
                using (MemoryStream mem = new MemoryStream())
                {
                    mem.Write(byteArray, 0, (int)byteArray.Length);
                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                    {
                        InvoicePastDueResult result = InvoicesPastDueByClient(wordDoc.MainDocumentPart, client, invoices.OrderBy(a => a.InvoiceNumber).ToList(), i, PageCount);
                        totalAmount += result.Amount;
                        totalPayment += result.Payment;
                        interest += result.Interest;

                        if (i == PageCount)
                        {
                            total = (totalAmount - totalPayment) + interest;
                            WordMLService.RemoveSdtContentCellNumberByName(wordDoc.MainDocumentPart, "Invoice_Amount", string.Format("${0}", totalAmount.ToString(GlobalConstants.MoneyFormat)));
                            WordMLService.RemoveSdtContentCellNumberByName(wordDoc.MainDocumentPart, "Invoice_Payment", string.Format("${0}", totalPayment.ToString(GlobalConstants.MoneyFormat)));
                            WordMLService.RemoveSdtContentCellNumberByName(wordDoc.MainDocumentPart, "Invoice_Interest", string.Format("${0}", interest.ToString(GlobalConstants.MoneyFormat)));
                            WordMLService.RemoveSdtContentCellNumberByName(wordDoc.MainDocumentPart, "Invoice_Total", string.Format("${0}", total.ToString(GlobalConstants.MoneyFormat)));
                        }
                        wordDoc.Save();
                    }
                    sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
                }
            }
        }

        private static void InvoiceInfo(MainDocumentPart mainPart, ClientData client, InvoiceData invoice, List<InvoiceData> outstandingInvoices, int PageNo, int PageCount)
        {
            string billingCycle = string.Empty;
            string invoiceDate = string.Empty;
            string dueDate = string.Empty;
            string currentDate = string.Empty;
            string invBillingToDate = string.Empty;

            if (invoice.InvoiceDate != null)
            {
                DateTime invoiceDateLocal = invoice.InvoiceDate.ToLocalTime();
                DateTime billingFrom = new DateTime(invoiceDateLocal.Year, invoiceDateLocal.Month, 1).Date;
                DateTime billingTo = billingFrom.AddMonths(1).AddSeconds(-5);
                billingCycle = billingFrom.ToString("MM/dd/yyyy") + " - " + billingTo.ToString("MM/dd/yyyy");
                invoiceDate = invoiceDateLocal.ToString("MM/dd/yy");
                dueDate = InvoiceCalculationHelper.GetDueDate(invoiceDateLocal)
                                        .ToString("MM/dd/yyyy"); // LocalTime
                currentDate = DateTime.Now.ToString("MM/dd/yyyy");
                invBillingToDate = billingTo.ToString("MM/dd/yyyy");
            }
            string outstandingClient = string.Format("Additional Outstanding Invoices for {0}...", invoice.ClientName);
            List<string> outstandingTexts = new List<string>();
            foreach(var outstandingInvoice in outstandingInvoices)
            {
                string text = string.Format("Inv#-{0} Bal-${1}", outstandingInvoice.InvoiceNumber, outstandingInvoice.Balance.ToString(GlobalConstants.MoneyFormat));
                if (!string.IsNullOrEmpty(text))
                {
                    outstandingTexts.Add(text);
                }
            }

            string defaultEmailTo = string.Empty;
            if (client != null)
            {
                defaultEmailTo = client.DefaultDeliverInvoicesTo;
            }
            if (string.IsNullOrEmpty(defaultEmailTo.Trim()))
            {
                defaultEmailTo = "USPS";
            }
            else
            {
                List<string> defaultEmailsTo = defaultEmailTo.Split(';').Select(p => p.Trim()).ToList();
                defaultEmailsTo = defaultEmailsTo.Take(2).ToList();
                defaultEmailTo = string.Join("; ", defaultEmailsTo);
            }

            string companyName = string.Empty;
            string[] billingAddresses = (client == null) ? new string[0] : client.BillingAddress.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_Number", invoice.InvoiceNumber.ToString());
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_Billing", billingCycle);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_SoldToClientName", invoice.SoldToClientName);
            if(!string.IsNullOrEmpty(invoice.InvoiceReference))
            {
                WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_Reference", invoice.InvoiceReference);
            }
            else
            {
                WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_Reference", invoice.InvoiceDivision);
            }
            
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_CustomerNumber", invoice.CustomerNumber);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_DueDate", dueDate);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_Date", invBillingToDate);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_ShippingMethod", defaultEmailTo);

            for (int i = 1; i <= 4; i++ )
            {
                if (i <= billingAddresses.Length)
                {
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("Invoice_BillTo{0}", i), billingAddresses[i-1].ToString());
                }
                else
                {
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("Invoice_BillTo{0}", i), string.Empty);
                }
            }

            WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Balance", invoice.Balance.ToString());

            if (PageNo < PageCount)
            {
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Amount", "Continued...");
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Payment", "Continued...");
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Interest", "Continued...");
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Total", "Continued...");
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Outstanding", "");
                WordMLService.RemoveTableSdtRunByName(mainPart, "Invoice_FinalComment");
            }
            else
            {
                decimal totalValue = invoice.Amount;
                decimal paymentValue = InvoiceCalculationHelper.GetTotalPaidAmount(invoice.InvoiceId);
                decimal interestValue = InvoiceCalculationHelper.GetInterest(invoice);
                decimal balanceValue = (totalValue + interestValue) - paymentValue;
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Amount", string.Format("${0}", totalValue.ToString(GlobalConstants.MoneyFormat)));
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Payment", string.Format("${0}", paymentValue.ToString(GlobalConstants.MoneyFormat)));
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Interest", string.Format("${0}", interestValue.ToString(GlobalConstants.MoneyFormat)));
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Total", string.Format("${0}", balanceValue.ToString(GlobalConstants.MoneyFormat)));
                WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_FinalComment", string.Empty);
                if (outstandingTexts.Count > 0)
                {
                    string outstanding = outstandingClient;
                    for (int i = 0; i < outstandingTexts.Count; i++)
                    {
                        if (i %2 == 0)
                        {
                            outstanding += Environment.NewLine + outstandingTexts[i];
                        }
                        else
                        {
                            outstanding += "    " + outstandingTexts[i];
                        }
                    }
                    WordMLService.RemoveSdtContentCellMultiLineByName(mainPart, "Invoice_Outstanding", outstanding);
                }
                else
                {
                    WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Outstanding", "");
                }
            }
        }

        private static void InvoiceItems(MainDocumentPart mainPart, List<InvoiceItemData> invoiceItems, int PageNo, int PageCount)
        {
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_Page", PageNo.ToString());
            invoiceItems = invoiceItems.GetRange(25 * (PageNo - 1), invoiceItems.Count - (25 * (PageNo - 1)) > 25 ? 25 : invoiceItems.Count - (25 * (PageNo - 1)));
            decimal subtotal = 0;
            for (int i = 0; i < invoiceItems.Count; i++)
            {
                AppApiRepository appApiRepository = new AppApiRepository();
                var app = appApiRepository.Find(invoiceItems[i].ApplicationId);

                subtotal += invoiceItems[i].UnitPrice;
                WordMLService.AddRow3ColumnSdtContentCellByName(mainPart, "InvoiceItems_Name",
                    "InvoiceItems_Description", "InvoiceItems_UnitPrice",
                    (app != null && app.ReportTypeName != null) ? app.ReportTypeName : GlobalConstants.DefaultReportTypeName, 
                    invoiceItems[i].Description, string.Format("${0}", 
                    invoiceItems[i].UnitPrice.ToString(GlobalConstants.MoneyFormat)));
            }
            WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_SubTotal", string.Format("${0}", subtotal.ToString(GlobalConstants.MoneyFormat)));
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "InvoiceItems_Name");
        }

        private static InvoicePastDueResult InvoicesPastDueByClient(MainDocumentPart mainPart, ClientData client, List<InvoiceData> invoices, int PageNo, int PageCount)
        {
            InvoicePastDueResult result;
            result.SubTotal = 0;
            result.Payment = 0;
            result.Interest = 0;

            string billingCycle = string.Empty;
            string invBillingToDate = string.Empty;

            if (invoices.Count == 1)
            {
                InvoiceData invoice = invoices.FirstOrDefault();
                if (invoice.InvoiceDate != null)
                {
                    DateTime invoiceDateLocal = invoice.InvoiceDate.ToLocalTime();
                    DateTime billingFrom = new DateTime(invoiceDateLocal.Year, invoiceDateLocal.Month, 1).Date;
                    DateTime billingTo = billingFrom.AddMonths(1).AddSeconds(-5);
                    billingCycle = billingFrom.ToString("MM/dd/yyyy") + " - " + billingTo.ToString("MM/dd/yyyy");
                    invBillingToDate = billingTo.ToString("MM/dd/yyyy");
                }
            }
            else
            {
                InvoiceData invoice = invoices.FirstOrDefault();
                billingCycle = "SEE BELOW";
                if (invoice.InvoiceDate != null)
                {
                    DateTime invoiceDateLocal = invoice.InvoiceDate.ToLocalTime();
                    DateTime billingFrom = new DateTime(invoiceDateLocal.Year, invoiceDateLocal.Month, 1).Date;
                    DateTime billingTo = billingFrom.AddMonths(1).AddSeconds(-5);
                    invBillingToDate = billingTo.ToString("MM/dd/yyyy");
                }
            }

            string defaultEmailTo = string.Empty;
            if (client != null)
            {
                defaultEmailTo = client.DefaultDeliverInvoicesTo;
            }
            if (string.IsNullOrEmpty(defaultEmailTo.Trim()))
            {
                defaultEmailTo = "USPS";
            }
            else
            {
                List<string> defaultEmailsTo = defaultEmailTo.Split(';').Select(p => p.Trim()).ToList();
                defaultEmailsTo = defaultEmailsTo.Take(2).ToList();
                defaultEmailTo = string.Join("; ", defaultEmailsTo);
            }

            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_Billing", billingCycle);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_Date", invBillingToDate);
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_SoldToClientName", client.ClientName ?? "");
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_CustomerNumber", client.CustomerNumber?? "");
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_Page", PageNo.ToString());
            WordMLService.RemoveSdtContentCellByName(mainPart, "Invoice_Reference", "Past Due Invoices");

            string[] billingAddresses = (client == null) ? new string[0] : client.BillingAddress.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 1; i <= 4; i++)
            {
                if (i <= billingAddresses.Length)
                {
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("Invoice_BillTo{0}", i), billingAddresses[i - 1].ToString());
                }
                else
                {
                    WordMLService.RemoveSdtContentCellByName(mainPart, string.Format("Invoice_BillTo{0}", i), string.Empty);
                }
            }
            
            var currentInvoices = invoices.GetRange(25 * (PageNo - 1), invoices.Count - (25 * (PageNo - 1)) > 25 ? 25 : invoices.Count - (25 * (PageNo - 1)));
            decimal subTotal = 0;
            decimal interestTotal = 0;
            decimal paymentTotal = 0;
            decimal totalAmount = 0;
            for (int i = 0; i < currentInvoices.Count; i++)
            {
                InvoiceData invoice = currentInvoices[i];
                InvoiceCalculationHelper.UpdateInvoiceStatus(invoice);
                var amount = InvoiceCalculationHelper.GetTotalInvoiceItemsAmount(invoice.InvoiceId);
                var payment = InvoiceCalculationHelper.GetTotalPaidAmount(invoice.InvoiceId);
                var interest = InvoiceCalculationHelper.GetInterest(invoice);
                var balance = amount - payment;
                var price = balance + interest;
                string name = string.Format("#{0}", currentInvoices[i].InvoiceNumber);
                string description = string.Format("{0} Invoice - ({1}) Amount: ${2}", invoice.InvoiceDate.ToString("MM/yyyy"), invoice.InvoiceDivision ?? "N/A", invoice.Amount.ToString(GlobalConstants.MoneyFormat));
                string unitPrice = string.Format("${0}", price.ToString(GlobalConstants.MoneyFormat));
                WordMLService.AddRow3ColumnSdtContentCellByName(mainPart, "InvoiceItems_Name",
                    "InvoiceItems_Description", "InvoiceItems_UnitPrice", name, description, unitPrice);
                subTotal += price;
                totalAmount += invoice.Amount;
                interestTotal += interest;
                paymentTotal += payment;
            }
            WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_SubTotal", string.Format("${0}", subTotal.ToString(GlobalConstants.MoneyFormat)));
            WordMLService.RemoveRowSdtContentCellByName(mainPart, "InvoiceItems_Name");
            result.Amount = totalAmount;
            result.SubTotal = subTotal;
            result.Interest = interestTotal;
            result.Payment = paymentTotal;

            if (PageNo < PageCount)
            {
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Amount", "Continued...");
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Payment", "Continued...");
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Interest", "Continued...");
                WordMLService.RemoveSdtContentCellNumberByName(mainPart, "Invoice_Total", "Continued...");
            }
            return result;
        }
    }
}
