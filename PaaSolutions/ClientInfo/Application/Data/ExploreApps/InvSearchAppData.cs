using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public enum InvSearchAppType
    {
        AllFields,
        Address,
        ClientName,
        ContactAttempts,
        CreditInformation,
        CreditReferences,
        CriminalCharges,
        EmploymentReferences,
        EmploymentVerifications,
        Evictions,
        FinalStaffComments,
        AppName,
        Priority,
        RentalReferences,
        ReportHeading,
        ReportType,
        Screener,
        SSNOrBirthday
    }

    public class InvSearchAppData
    {
        private static Dictionary<string, string> data;

        static InvSearchAppData()
        {
            if (data == null)
            {
                data = new Dictionary<string, string>();
                data.Add("All Fields", "all_fields");
                data.Add("Address", "street_address");
                data.Add("Client Name", "client_name");
                data.Add("Contact Attempts", "contact_attempt");
                data.Add("Credit Information", "credit_info");
                data.Add("Credit References", "credit_refs");
                data.Add("Criminal Charges", "charges");
                data.Add("Employment References", "emp_refs");
                data.Add("Employment Verifications", "emp_ver");
                data.Add("Evictions", "evictions");
                data.Add("Final/Staff Comments", "final_comments/staff_comments");
                data.Add("Name", "last_name/first_name/middle_name");
                data.Add("Priority", "priority");
                data.Add("Rental References", "rental_refs");
                data.Add("Report Heading", "report_management");
                data.Add("Report Type", "type_name");
                data.Add("Screener", "screener_name");
                data.Add("SSN or Birthday", "app_ssn/birth_date");
                data.Add("Roommates", "report_special_field");
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
