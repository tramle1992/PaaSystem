using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Data
{
    public enum SearchInvoiceSearchInType
    {
        AllFields,
        Address,
        CheckNumber,
        ClientName,
        CustomerNumber,
        InvoiceComments,
        InvoiceDivision,
        InvoiceItems,
        InvoiceNumber,
        InvoiceReference,
        NoteToClient,
        Status
    }

    public class SearchInvoiceSearchInData
    {
        private static Dictionary<string, string> data;

        static SearchInvoiceSearchInData()
        {
            if (data == null)
            {
                data = new Dictionary<string, string>();
                data.Add("(All Fields)", "all_fields");
                data.Add("Address", "address");
                data.Add("Check Number", "check_number");
                data.Add("Client Name", "client_name");
                data.Add("Customer Number", "customer_number");
                data.Add("Invoice Comments", "invoice_comments");
                data.Add("Invoice Division", "invoice_division");
                data.Add("Invoice Items", "invoice_items");
                data.Add("Invoice Number", "invoice_number");
                data.Add("Invoice Reference", "invoice_reference");
                data.Add("Note To Client", "note_to_client");
                data.Add("Status", "status");
            }
        }

        public static List<string> GetAllFields()
        {
            return new List<string>(data.Keys);
        }

        public static List<string> GetAllColumnNames()
        {
            return new List<string>(data.Values);
        }

        public static string GetColumnNameByFieldName(string fieldName)
        {
            try
            {
                if (!string.IsNullOrEmpty(fieldName))
                {
                    bool hasKey;
                    string value;
                    hasKey = data.TryGetValue(fieldName, out value);
                    if (hasKey)
                    {
                        return value;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
