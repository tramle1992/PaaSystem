using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Office;
using PaaApplication.Models.Common;
using Core.Application.Data.ClientInfo;
using Word = NetOffice.WordApi;
using PaaApplication.Helper;
using System.IO;
using NetOffice.WordApi.Enums;
using Common.Infrastructure.Helper;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;

namespace PaaApplication.Models.ClientInfo
{
    public class WordDocumentBuilder
    {
        public DocumentCompleteResult BuildClientInfoDocument(WordDocumentType documentType, ClientData data)
        {

            TemplateHelper templateHelper = new TemplateHelper();
            string filename = WordTemplatePathResolver.GetTemplateFileName(documentType);
            if (!string.IsNullOrEmpty(filename))
            {
                string url = string.Format("api/templates");
                string savePath = WordTemplatePathResolver.GetWordTemplatePath(documentType);
                templateHelper.DownloadTemplate(savePath, filename);
            }

            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(documentType);

            if (!File.Exists(templatePath))
            {
                return null;
            }

            string toSaveFileName = string.Format("Client Info - {0}", data.ClientName ?? string.Empty);
            WordService word = new WordService(templatePath, toSaveFileName, false);

            Word.Document documentInstance = word.GetDocumentInstance();
            Word.Application applicationInstance = word.GetApplicationInstance();

            string additionalInformation = string.IsNullOrEmpty(data.BillingInfo) ? data.MiscComments :
                data.BillingInfo + Environment.NewLine + data.MiscComments;

            string[] billingAddresses = data.BillingAddress.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark, Type.Missing, Type.Missing, "BillingAddress");
            for (int i = 0; i < billingAddresses.Length; i++ )
            {
                applicationInstance.Selection.TypeText(billingAddresses[i]);
                applicationInstance.Selection.MoveDown(WdUnits.wdLine);
            }

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark, Type.Missing, Type.Missing, "Address");
            if (data.OtherAddresses.Count > 0)
            {
                OtherAddressData otherAddress = data.OtherAddresses.ElementAt(0);
                string addressString = otherAddress.Address;
                string[] otherAddressLines = addressString.Split('\n');
                for (int i = 0; i < otherAddressLines.Length; i++)
                {
                    applicationInstance.Selection.TypeText(otherAddressLines[i]);
                    applicationInstance.Selection.MoveDown(WdUnits.wdLine);
                }
            }

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark, Type.Missing, Type.Missing, "Contacts");
            if (data.Contacts.Count > 0)
            {
                foreach(ContactData contact in data.Contacts)
                {
                    applicationInstance.Selection.TypeText(contact.ContactInfo);
                    applicationInstance.Selection.MoveDown(WdUnits.wdLine);

                }
            }

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark, Type.Missing, Type.Missing, "ClientName");
            applicationInstance.Selection.TypeText(data.ClientName);

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark,Type.Missing, Type.Missing, "CustomerNumber");
            applicationInstance.Selection.TypeText(data.CustomerNumber);

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark,Type.Missing, Type.Missing, "Since");
            applicationInstance.Selection.TypeText(data.Since.ToShortDateString());

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark,Type.Missing, Type.Missing, "Phone");
            applicationInstance.Selection.TypeText(data.Phone);

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark,Type.Missing, Type.Missing, "Fax");
            applicationInstance.Selection.TypeText(data.Fax);

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark,Type.Missing, Type.Missing, "Management");
            applicationInstance.Selection.TypeText((data.ManagementCompany == null) ? "" : data.ManagementCompany.Name);

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark,Type.Missing, Type.Missing, "Email");
            applicationInstance.Selection.TypeText(data.Email);

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark,Type.Missing, Type.Missing, "AdditionalInformation");
            applicationInstance.Selection.TypeText(additionalInformation);

            if (word != null)
            {
                string sFileExtension = "docx";
                string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
                DocumentCompleteResult result = new DocumentCompleteResult(tempFilePath, word, "Client Info");
                return result;
            }
            return null;
        }

        public DocumentCompleteResult BuildContractDocument(WordDocumentType documentType, ClientData data)
        {
            TemplateHelper templateHelper = new TemplateHelper();
            string filename = WordTemplatePathResolver.GetTemplateFileName(documentType);
            if (!string.IsNullOrEmpty(filename))
            {
                string url = string.Format("api/templates");
                string savePath = WordTemplatePathResolver.GetWordTemplatePath(documentType);
                templateHelper.DownloadTemplate(savePath, filename);
            }

            string templatePath = WordTemplatePathResolver.GetWordTemplatePath(documentType);

            if (!File.Exists(templatePath))
            {
                return null;
            }

            string toSaveFileName = string.Format("Contract - {0}", data.ClientName ?? string.Empty);
            WordService word = new WordService(templatePath, null, false);

            Word.Document documentInstance = word.GetDocumentInstance();
            Word.Application applicationInstance = word.GetApplicationInstance();

            string clientName = data.ClientName;
            string address = clientName + Environment.NewLine + data.BillingAddress;

            applicationInstance.Selection.GoTo(WdGoToItem.wdGoToBookmark, Type.Missing, Type.Missing, "CompanyName1");
            applicationInstance.Selection.TypeText(clientName);

            applicationInstance.Selection.GoToNext(WdGoToItem.wdGoToTable);
            applicationInstance.Selection.TypeText(address);

            if (word != null)
            {
                string sFileExtension = "docx";
                string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
                DocumentCompleteResult result = new DocumentCompleteResult(tempFilePath, word, "Client Info");
                return result;
            }
            return null;
        }

        public void BuildLabel(List<Source> sources, string size, List<string> labels, int pageNo)
        {
            string templatePath = "";
            switch (size)
            {
                case "Large":
                    templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.LargeLabel);
                    break;
                default:
                    templatePath = WordTemplatePathResolver.GetWordTemplatePath(WordDocumentType.SmallLabel);
                    break;
            }
            byte[] byteArray = File.ReadAllBytes(templatePath);
            using (MemoryStream mem = new MemoryStream())
            {
                mem.Write(byteArray, 0, (int)byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(mem, true))
                {
                    int itemsEmpty = 0;
                    if (size.Equals("Large"))
                    {
                        string Total = "4";
                        int startIndex = ((pageNo - 1) * Convert.ToInt32(Total));
                        int numToGet = labels.Count - startIndex > Convert.ToInt32(Total) ? Convert.ToInt32(Total) : labels.Count - startIndex;
                        List<string> lbls = labels.GetRange(startIndex, numToGet);
                        if(lbls.Count < Convert.ToInt32(Total))
                        {
                            itemsEmpty = Convert.ToInt32(Total) - lbls.Count;
                            for (int i = 0; i < itemsEmpty; i++)
                            {
                                lbls.Add(string.Empty);
                            }
                        }

                        int col = 0;
                        int row = 1;
                        foreach (var label in lbls)
                        {
                            if (col == 2)
                            {
                                row++;
                                col = 0;
                            }
                            var name = "Label" + row;
                            WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, name, label, "center");
                            col++;
                        }
                    }
                    else
                    {
                        string Total = "30";
                        int startIndex = ((pageNo - 1) * Convert.ToInt32(Total));
                        int numToGet = labels.Count - startIndex > Convert.ToInt32(Total) ? Convert.ToInt32(Total) : labels.Count - startIndex;
                        List<string> lbls = labels.GetRange(startIndex, numToGet);
                        if (lbls.Count < Convert.ToInt32(Total))
                        {
                            itemsEmpty = Convert.ToInt32(Total) - lbls.Count;
                            for(int i = 0; i < itemsEmpty; i++)
                            {
                                lbls.Add(string.Empty);
                            }
                        }

                        int col = 0;
                        int row = 1;
                        foreach (var label in lbls)
                        {
                            if (col == 3)
                            {
                                row++;
                                col = 0;
                            }
                            var name = "Label" + row;
                            WordMLService.RemoveSdtContentCellMultiLineByName(wordDoc.MainDocumentPart, name, label, "center");
                            col++;
                        }
                    }
                    wordDoc.Save();
                }
                sources.Add(new Source(new WmlDocument(string.Empty, mem.ToArray()), true));
            }
        }

    }
}
