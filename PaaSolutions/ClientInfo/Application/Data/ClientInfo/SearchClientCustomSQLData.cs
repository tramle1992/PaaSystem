using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ClientInfo
{
    public enum SearchClientCustomSQLType
    {
        BillingAddress,
        BillingInfo,
        ClientName,
        ClientRevoked,
        //ConfidentialityCover,
        Contacts,
        Credentialed,
        //CreditType,
        CustomerNumber,
        DeclinationLetter,
        DefaultConfDelivery,
        DefaultInvDelivery,
        DefaultReportDelivery,
        Email,
        Fax,
        InvoiceCopies,
        InvoiceDivisions,
        //InvoiceLine,
        Management,
        MiscComments,
        OtherAddresses,
        Phone,
        PrimaryKey,
        Since,
        SpecialCriteriaInfo,
        SpecialEntryInfo,
        SpecialPrices,
        Summaries,
        VerifyConfDelivery,
        WebPass,
        WebsiteDir
    }

    public class SearchClientCustomSQL
    {
        private static Dictionary<string, string> data;

        static SearchClientCustomSQL()
        {
            if (data == null)
            {
                data = new Dictionary<string, string>();
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.BillingAddress), "billing_address");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.BillingInfo), "billing_info");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.ClientName), "client_name");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.ClientRevoked), "client_revoked");
                //data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.ConfidentialityCover), "confidentiality_cover");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.Contacts), "contacts");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.Credentialed), "credentialed");
                //data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.CreditType), "credit_type");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.CustomerNumber), "customer_number");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.DeclinationLetter), "declination_letter");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.DefaultConfDelivery), "default_deliver_confirmation_to");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.DefaultInvDelivery), "default_deliver_invoices_to");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.DefaultReportDelivery), "default_deliver_reports_to");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.Email), "email");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.Fax), "fax");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.InvoiceCopies), "invoices_copies_number");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.InvoiceDivisions), "invoice_divisions");
                //data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.InvoiceLine), "invoice_lines");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.MiscComments), "misc_comments");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.OtherAddresses), "other_addresses");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.Phone), "phone");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.PrimaryKey), "client_id");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.Since), "since");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.SpecialCriteriaInfo), "special_criteria_info");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.SpecialEntryInfo), "special_entry_info");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.SpecialPrices), "client_report_special_price");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.Summaries), "summaries");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.VerifyConfDelivery), "default_verify_confirm_delivery");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.WebPass), "web_pass");
                data.Add(Enum.GetName(typeof(SearchClientCustomSQLType), SearchClientCustomSQLType.WebsiteDir), "website_dir");
            }
        }

        public static List<string> GetAllTypes()
        {
            return new List<string>(data.Keys);
        }

        public static string GetColumnNameByTypeName(string typeName)
        {
            try
            {
                if (!string.IsNullOrEmpty(typeName))
                {
                    bool hasKey;
                    string value;
                    hasKey = data.TryGetValue(typeName, out value);
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

    public class SearchClientCustomSQLData
    {
        public string BillingAddress { get; set; }
        public string BillingInfo { get; set; }
        public string ClientName { get; set; }
        public bool ClientRevoked { get; set; }
        public string Contacts { get; set; }
        public bool Credentialed { get; set; }
        public string CustomerNumber { get; set; }
        public bool DeclinationLetter { get; set; }
        public string DefaultConfDelivery { get; set; }
        public string DefaultInvDelivery { get; set; }
        public string DefaultReportDelivery { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public int InvoiceCopies { get; set; }
        public string InvoiceDivisions { get; set; }
        public string Management { get; set; }
        public string MiscComments { get; set; }
        public string OtherAddresses { get; set; }
        public string Phone { get; set; }
        public string PrimaryKey { get; set; }
        public DateTime Since { get; set; }
        public string SpecialCriteriaInfo { get; set; }
        public string SpecialEntryInfo { get; set; }
        public decimal? SpecialPrices { get; set; }
        public bool Summaries { get; set; }
        public bool VerifyConfDelivery { get; set; }
        public string WebPass { get; set; }
        public string WebsiteDir { get; set; }
    }
}
