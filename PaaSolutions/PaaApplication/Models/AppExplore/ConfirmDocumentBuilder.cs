using Common.Infrastructure.Office;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using PaaApplication.Models.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = NetOffice.WordApi;
using Core.Infrastructure.ClientInfo;
using PaaApplication.Helper;
using System.IO;

namespace PaaApplication.Models.AppExplore
{
    public class ConfirmDocumentBuilder
    {
        public static DocumentCompleteResult Confirmation(AppData app, string toSaveFileName)
        {
            WordService word = null;
            try
            {
                bool verify = false;
                WordDocumentType docType = WordDocumentType.Confirm;

                string templatePath = WordTemplatePathResolver.GetWordTemplatePath(docType);

                if (!File.Exists(templatePath))
                {
                    return null;
                }
                word = new WordService(templatePath, toSaveFileName, false);
                Word.Document documentInstance = word.GetDocumentInstance();
                Word.Application applicationInstance = word.GetApplicationInstance();
                ClientCachedApiQuery clientCachedApiQuery = ClientCachedApiQuery.Instance;
                ReportTypeCachedApiQuery reportTypeCachedApiQuery = ReportTypeCachedApiQuery.Instance;
                if (app != null && !string.IsNullOrEmpty(app.ApplicationId))
                {
                    string clientHeadLine = "";
                    ClientData client = clientCachedApiQuery.GetClient(app.ClientApplied);
                    ReportTypeData reportType = reportTypeCachedApiQuery.GetReportType(app.ReportTypeId);
                    string absoluteReportType = "";
                    if (client != null && reportType != null)
                    {
                        if (Utils.GetSendMethod(client.DefaultDeliverConfirmationsTo) == SendMethod.ViaEmail)
                        {
                            clientHeadLine = "Client:  " + client.ClientName + "       " + "Email:  " + client.DefaultDeliverConfirmationsTo;
                            verify = client.DefaultVerifyConfirmDelivery;
                        }
                        else if (!string.IsNullOrEmpty(client.DefaultDeliverConfirmationsTo))
                        {
                            clientHeadLine = "Client:  " + client.ClientName + "       " + "Fax:  " + client.DefaultDeliverConfirmationsTo;
                        }
                        else
                        {
                            clientHeadLine = "Client:  " + client.ClientName + "       " + "Fax:  " + client.Fax;
                        }
                        absoluteReportType = reportType.AbsoluteTypeName;
                    }

                    List<string> checkboxBookmarks = new List<string>()
                    {
                        "Confirm_Residential",
                        "Confirm_Employment",
                        "Confirm_Commercial",
                        "Confirm_Credit",
                        "Confirm_Credit_Criminal",
                        "Confirm_Criminal",
                    };
                    object Font = "Wingdings";
                    object Unicode = true;
                    foreach (string bookmark in checkboxBookmarks)
                    {
                        if (("Confirm_" + absoluteReportType.Replace('/', '_') == bookmark))
                        {
                            documentInstance.Bookmarks[bookmark].Range.InsertSymbol(254, Font, Unicode);
                        }
                        else
                        {
                            documentInstance.Bookmarks[bookmark].Select();
                            documentInstance.Bookmarks[bookmark].Range.InsertSymbol(168, Font, Unicode);
                        }
                    }

                    string applicantName = Utils.GetApplicantName(app, reportType);
                    string enailTitle = string.Format("Application Confirmation");

                    documentInstance.Bookmarks["Confirm_Date"].Range.Text = DateTime.Now.ToString("MM/dd/yy");
                    documentInstance.Bookmarks["Confirm_Time"].Range.Text = DateTime.Now.ToString("h:mm tt");
                    documentInstance.Bookmarks["Confirm_BC_Representative"].Range.Text = "Clerical";
                    documentInstance.Bookmarks["Confirm_Pages_Received"].Range.Text = app.PagesReceived.ToString();
                    documentInstance.Bookmarks["Confirm_Applicants"].Range.Text = applicantName;
                    documentInstance.Bookmarks["Confirm_Client_Info"].Range.Text = clientHeadLine;

                    string filePath = word.GetWorkingFilePath();
                    word.SaveDocumentByPath(filePath);
                    return new DocumentCompleteResult(filePath, word, enailTitle);
                }
                return null;
            }
            catch (Exception ex)
            {
                if (word != null)
                    word.Quit();
                word = null;
                throw;
            }
        }
    }
}
