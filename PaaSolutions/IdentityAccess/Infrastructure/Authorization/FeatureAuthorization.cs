using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Infrastructure.Authorization
{
    public enum FeatureName
    {
        Module_InfoResource,
        Modue_AutoDocument,
        Module_UserManager,
        Module_ClientInfo,
        Module_Invoicing,
        Module_ExploreApps,
        ViewInfoResource,
        ReceiveInvoiceConfirmation,
        AddNewClient,
        ViewExploreApp,
        Administration,
        DeleteClient,
        ChangeClientName,
        EditSpecialPrice,
        AddEditReviewComment,
        ReportType,
        ArchiveApps,
        DeleteResource,
        ViewClientInfo,
        BlockUnblockActivity
    }

    public class FeatureAuthorization
    {       

        public string FeatureNameToString(FeatureName feature)
        {
            string result = "";

            switch (feature)
            {
                case FeatureName.Modue_AutoDocument:
                    result = "Auto Document";
                    break;
                case FeatureName.Module_ClientInfo:
                    result = "Client Info";
                    break;
                case FeatureName.Module_ExploreApps:
                    result = "Explore Apps";
                    break;
                case FeatureName.Module_InfoResource:
                    result = "Info Resources";
                    break;
                case FeatureName.Module_Invoicing:
                    result = "Invoicing";
                    break;
                case FeatureName.Module_UserManager:
                    result = "User Manager";
                    break;
                case FeatureName.ReceiveInvoiceConfirmation:
                    result = "Receive Invoice Confirmation";
                    break;
                case FeatureName.ReportType:
                    result = "Report Type";
                    break;
                case FeatureName.Administration:
                    result = "Administration";
                    break;
                case FeatureName.ViewClientInfo:
                    result = "View Client Info";
                    break;
                case FeatureName.ViewExploreApp:
                    result = "View Explore App";
                    break;
                case FeatureName.ViewInfoResource:
                    result = "View Info Resources";
                    break;
                case FeatureName.AddEditReviewComment:
                    result = "Add/Edit Review Comment";
                    break;
                case FeatureName.AddNewClient:
                    result = "Add New Client";
                    break;
                case FeatureName.ArchiveApps:
                    result = "Archive Apps";
                    break;
                case FeatureName.ChangeClientName:
                    result = "Change Client Name";
                    break;
                case FeatureName.DeleteClient:
                    result = "Delete Client";
                    break;
                case FeatureName.DeleteResource:
                    result = "Delete Resource Item(s)";
                    break;
                case FeatureName.EditSpecialPrice:
                    result = "Edit Special Price(s)";
                    break;
                case FeatureName.BlockUnblockActivity:
                    result = "Block/Unblock Activity";
                    break;
            }
            return result;
        }


    }
}
