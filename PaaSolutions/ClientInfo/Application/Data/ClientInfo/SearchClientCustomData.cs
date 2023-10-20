using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ClientInfo
{
    public enum SearchClientCustomType
    {
        AllFields,
        BillingInfo,
        BillingAddress,
        ClientName,
        Contacts,
        CustomerNumber,
        DefaultDeliveries,
        DefaultConfDelivery,
        DefaultInvDelivery,
        DefaultReportDelivery,
        Email,
        Fax,
        InvoiceDivisions,
        Management,
        MiscComments,
        OtherAddresses,
        Phone,
        SpecialCriteriaInfo,
        SpecialEntryInfo
    }

    public class SearchClientCustom
    {
        private static Dictionary<string, string> data;

        static SearchClientCustom()
        {
            if (data == null)
            {
                data = new Dictionary<string, string>();
                data.Add("All Fields", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.AllFields));
                data.Add("Additional BillingInfo", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.BillingInfo));
                data.Add("Billing Address", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.BillingAddress));
                data.Add("Client Name", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.ClientName));
                data.Add("Contacts", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.Contacts));
                data.Add("Customer Number", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.CustomerNumber));
                data.Add("Default Deliveries", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.DefaultDeliveries));
                data.Add("Email Address", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.Email));
                data.Add("Fax", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.Fax));
                data.Add("Invoice Divisions", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.InvoiceDivisions));
                data.Add("Management", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.Management));
                data.Add("Miscellaneous Comments", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.MiscComments));
                data.Add("Other Addresses", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.OtherAddresses));
                data.Add("Phone", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.Phone));
                data.Add("Special Criteria Info", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.SpecialCriteriaInfo));
                data.Add("Special Entry Info", Enum.GetName(typeof(SearchClientCustomType), SearchClientCustomType.SpecialEntryInfo));
            }
        }

        public static List<string> GetAllTypes()
        {
            return new List<string>(data.Keys);
        }

        public static List<string> GetAllColumns()
        {
            return new List<string>(data.Values);
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

    public class SearchClientCustomData
    {
        public string BillingAddress { get; set; }
        public string BillingInfo { get; set; }
        public string ClientName { get; set; }
        public string Contacts { get; set; }
        public string CustomerNumber { get; set; }
        public string DefaultConfDelivery { get; set; }
        public string DefaultInvDelivery { get; set; }
        public string DefaultReportDelivery { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string InvoiceDivisions { get; set; }
        public string Management { get; set; }
        public string MiscComments { get; set; }
        public string OtherAddresses { get; set; }
        public string Phone { get; set; }
        public string PrimaryKey { get; set; }
        public string SpecialCriteriaInfo { get; set; }
        public string SpecialEntryInfo { get; set; }
    }
}
