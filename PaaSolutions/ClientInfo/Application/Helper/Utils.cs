using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Helper
{
    public static class Utils
    {
        public static string GetApplicantName(AppData app, ReportTypeData reportType)
        {
            string currentReportType = (reportType != null && !string.IsNullOrEmpty(reportType.TypeName)) ? reportType.TypeName : "";
            string bufferName = "";
            if (currentReportType == "Comm")
            {
                bufferName = app.Company;
            }
            else
            {
                bufferName = app.LastName.Trim();
                string firstName = app.FirstName.Trim();
                if (!string.IsNullOrEmpty(firstName))
                {
                    if (!string.IsNullOrEmpty(bufferName))
                    {
                        bufferName += ", " + firstName;
                    }
                    else
                    {
                        bufferName = firstName;
                    }
                }
            }
            return bufferName;
        }

        public static decimal GetPrice(ReportTypeData reportType, ClientData client)
        {
            var defaultPrice = reportType.DefaultPrice;
            var specialPrice = defaultPrice;
            if (client.ClientReportSpecialPrices == null || 
                client.ClientReportSpecialPrices.Count == 0 ||
                reportType == null || client == null)
                return defaultPrice;

            foreach (var price in client.ClientReportSpecialPrices)
            {
                if (reportType.ReportTypeId == price.ReportTypeId)
                {
                    specialPrice = price.SpecialPrice;
                    break;
                }
            }
            return specialPrice;
        }
    }
}
