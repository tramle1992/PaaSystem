using Core.Application.Data.ClientInfo;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Common.ClientInfo
{
    public class GetClientData
    {
        public static List<string> SearchClientCustomSQL(List<ClientData> clientData, string conditions)
        {
            if (clientData.Any())
            {
                DataTable dtInfos = new DataTable();
                DataTable dtContacts = new DataTable();
                DataTable dtInvoiceDivisions = new DataTable();
                DataTable dtOtherAddresses = new DataTable();
                DataTable dtSpecialPrices = new DataTable();

                #region Add columns for Infos
                dtInfos.Columns.Add("BillingAddress", typeof(String));
                dtInfos.Columns.Add("BillingInfo", typeof(String));
                dtInfos.Columns.Add("ClientName", typeof(String));
                dtInfos.Columns.Add("ClientRevoked", typeof(Boolean));
                dtInfos.Columns.Add("Credentialed", typeof(Boolean));
                dtInfos.Columns.Add("CustomerNumber", typeof(String));
                dtInfos.Columns.Add("DeclinationLetter", typeof(Boolean));
                dtInfos.Columns.Add("DefaultConfDelivery", typeof(String));
                dtInfos.Columns.Add("DefaultInvDelivery", typeof(String));
                dtInfos.Columns.Add("DefaultReportDelivery", typeof(String));
                dtInfos.Columns.Add("Email", typeof(String));
                dtInfos.Columns.Add("Fax", typeof(String));
                dtInfos.Columns.Add("InvoiceCopies", typeof(Int32));
                dtInfos.Columns.Add("Management", typeof(String));
                dtInfos.Columns.Add("MiscComments", typeof(String));
                dtInfos.Columns.Add("Phone", typeof(String));
                dtInfos.Columns.Add("PrimaryKey", typeof(String));
                dtInfos.Columns.Add("Since", typeof(DateTime));
                dtInfos.Columns.Add("SpecialCriteriaInfo", typeof(String));
                dtInfos.Columns.Add("SpecialEntryInfo", typeof(String));
                dtInfos.Columns.Add("Summaries", typeof(Boolean));
                dtInfos.Columns.Add("VerifyConfDelivery", typeof(Boolean));
                dtInfos.Columns.Add("WebPass", typeof(String));
                dtInfos.Columns.Add("WebsiteDir", typeof(String));
                #endregion

                #region Add columns for Contacts
                dtContacts.Columns.Add("PrimaryKey", typeof(String));
                dtContacts.Columns.Add("Contacts", typeof(String));
                #endregion

                #region Add columns for InvoiceDivisions
                dtInvoiceDivisions.Columns.Add("PrimaryKey", typeof(String));
                dtInvoiceDivisions.Columns.Add("InvoiceDivisions", typeof(String));
                #endregion

                #region Add columns for OtherAddresses
                dtOtherAddresses.Columns.Add("PrimaryKey", typeof(String));
                dtOtherAddresses.Columns.Add("OtherAddresses", typeof(String));
                #endregion

                #region Add columns for SpecialPrices
                dtSpecialPrices.Columns.Add("PrimaryKey", typeof(String));
                dtSpecialPrices.Columns.Add("SpecialPrices", typeof(Decimal));
                #endregion

                for (int i = 0; i < clientData.Count(); i++)
                {
                    #region Load data to Infos
                    DataRow infoRow = dtInfos.NewRow();
                    infoRow["BillingAddress"] = clientData[i].BillingAddress;
                    infoRow["BillingInfo"] = clientData[i].BillingInfo;
                    infoRow["ClientName"] = clientData[i].ClientName;
                    infoRow["ClientRevoked"] = clientData[i].ClientRevoked;
                    infoRow["Credentialed"] = clientData[i].Credentialed;
                    infoRow["CustomerNumber"] = clientData[i].CustomerNumber;
                    infoRow["DeclinationLetter"] = clientData[i].DeclinationLetter;
                    infoRow["DefaultConfDelivery"] = clientData[i].DefaultDeliverConfirmationsTo;
                    infoRow["DefaultInvDelivery"] = clientData[i].DefaultDeliverInvoicesTo;
                    infoRow["DefaultReportDelivery"] = clientData[i].DefaultDeliverReportsTo;
                    infoRow["Email"] = clientData[i].Email;
                    infoRow["Fax"] = clientData[i].Fax;
                    infoRow["InvoiceCopies"] = clientData[i].InvoicesCopiesNumber;
                    if (clientData[i].ManagementCompany != null && !string.IsNullOrEmpty(clientData[i].ManagementCompany.Name.Trim()))
                    {
                        infoRow["Management"] = clientData[i].ManagementCompany.Name;
                    }
                    else
                    {
                        infoRow["Management"] = "";
                    }
                    infoRow["MiscComments"] = clientData[i].MiscComments;
                    infoRow["Phone"] = clientData[i].Phone;
                    infoRow["PrimaryKey"] = clientData[i].ClientId;
                    infoRow["Since"] = clientData[i].Since;
                    infoRow["SpecialCriteriaInfo"] = clientData[i].SpecialCriteriaInfo;
                    infoRow["SpecialEntryInfo"] = clientData[i].SpecialEntryInfo;
                    infoRow["Summaries"] = clientData[i].Summaries;
                    infoRow["VerifyConfDelivery"] = clientData[i].DefaultVerifyConfirmDelivery;
                    infoRow["WebPass"] = clientData[i].WebPass;
                    infoRow["WebsiteDir"] = clientData[i].WebsiteDir;
                    dtInfos.Rows.Add(infoRow);
                    #endregion

                    #region Load data to Contacts
                    if (clientData[i].Contacts.Any())
                    {
                        foreach (ContactData contact in clientData[i].Contacts)
                        {
                            DataRow row = dtContacts.NewRow();
                            row["PrimaryKey"] = clientData[i].ClientId;
                            row["Contacts"] = contact.ContactInfo;
                            dtContacts.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DataRow row = dtContacts.NewRow();
                        row["PrimaryKey"] = clientData[i].ClientId;
                        row["Contacts"] = "";
                        dtContacts.Rows.Add(row);
                    }
                    #endregion

                    #region Add data to InvoiceDivisions
                    if (clientData[i].InvoiceDivisions.Any())
                    {
                        foreach (InvoiceDivisionData invoiceDivision in clientData[i].InvoiceDivisions)
                        {
                            DataRow row = dtInvoiceDivisions.NewRow();
                            row["PrimaryKey"] = clientData[i].ClientId;
                            row["InvoiceDivisions"] = invoiceDivision.DivisionName;
                            dtInvoiceDivisions.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DataRow row = dtInvoiceDivisions.NewRow();
                        row["PrimaryKey"] = clientData[i].ClientId;
                        row["InvoiceDivisions"] = "";
                        dtInvoiceDivisions.Rows.Add(row);
                    }
                    #endregion

                    #region Load data to OtherAddresses
                    if (clientData[i].OtherAddresses.Any())
                    {
                        foreach (OtherAddressData otherAddress in clientData[i].OtherAddresses)
                        {
                            DataRow row = dtOtherAddresses.NewRow();
                            row["PrimaryKey"] = clientData[i].ClientId;
                            row["OtherAddresses"] = otherAddress.Address;
                            dtOtherAddresses.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DataRow row = dtOtherAddresses.NewRow();
                        row["PrimaryKey"] = clientData[i].ClientId;
                        row["OtherAddresses"] = "";
                        dtOtherAddresses.Rows.Add(row);
                    }
                    #endregion

                    #region Load data to SpecialPrices
                    if (clientData[i].ClientReportSpecialPrices.Any())
                    {
                        foreach (ClientReportSpecialPriceData specialPrice in clientData[i].ClientReportSpecialPrices)
                        {
                            DataRow row = dtSpecialPrices.NewRow();
                            row["PrimaryKey"] = clientData[i].ClientId;
                            row["SpecialPrices"] = specialPrice.SpecialPrice;
                            dtSpecialPrices.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DataRow row = dtSpecialPrices.NewRow();
                        row["PrimaryKey"] = clientData[i].ClientId;
                        row["SpecialPrices"] = DBNull.Value;
                        dtSpecialPrices.Rows.Add(row);
                    }
                    #endregion
                }

                #region Join 5 tables
                IEnumerable<SearchClientCustomSQLData> join5Result = (from infos in dtInfos.AsEnumerable()
                                                                      join contacts in dtContacts.AsEnumerable() on (string)infos["PrimaryKey"] equals (string)contacts["PrimaryKey"]
                                                                      join invoiceDivisions in dtInvoiceDivisions.AsEnumerable() on (string)infos["PrimaryKey"] equals (string)invoiceDivisions["PrimaryKey"]
                                                                      join otherAddresses in dtOtherAddresses.AsEnumerable() on (string)infos["PrimaryKey"] equals (string)otherAddresses["PrimaryKey"]
                                                                      join specialPrices in dtSpecialPrices.AsEnumerable() on (string)infos["PrimaryKey"] equals (string)specialPrices["PrimaryKey"]
                                                                      select new SearchClientCustomSQLData()
                                                                      {
                                                                          BillingAddress = infos.Field<string>("BillingAddress"),
                                                                          BillingInfo = infos.Field<string>("BillingInfo"),
                                                                          ClientName = infos.Field<string>("ClientName"),
                                                                          ClientRevoked = infos.Field<bool>("ClientRevoked"),
                                                                          Contacts = contacts.Field<string>("Contacts"),
                                                                          Credentialed = infos.Field<bool>("Credentialed"),
                                                                          CustomerNumber = infos.Field<string>("CustomerNumber"),
                                                                          DeclinationLetter = infos.Field<bool>("DeclinationLetter"),
                                                                          DefaultConfDelivery = infos.Field<string>("DefaultConfDelivery"),
                                                                          DefaultInvDelivery = infos.Field<string>("DefaultInvDelivery"),
                                                                          DefaultReportDelivery = infos.Field<string>("DefaultReportDelivery"),
                                                                          Email = infos.Field<string>("Email"),
                                                                          Fax = infos.Field<string>("Fax"),
                                                                          InvoiceCopies = infos.Field<int>("InvoiceCopies"),
                                                                          InvoiceDivisions = invoiceDivisions.Field<string>("InvoiceDivisions"),
                                                                          Management = infos.Field<string>("Management"),
                                                                          MiscComments = infos.Field<string>("MiscComments"),
                                                                          OtherAddresses = otherAddresses.Field<string>("OtherAddresses"),
                                                                          Phone = infos.Field<string>("Phone"),
                                                                          PrimaryKey = infos.Field<string>("PrimaryKey"),
                                                                          Since = infos.Field<DateTime>("Since"),
                                                                          SpecialCriteriaInfo = infos.Field<string>("SpecialCriteriaInfo"),
                                                                          SpecialEntryInfo = infos.Field<string>("SpecialEntryInfo"),
                                                                          SpecialPrices = specialPrices.Field<decimal?>("SpecialPrices"),
                                                                          Summaries = infos.Field<bool>("Summaries"),
                                                                          VerifyConfDelivery = infos.Field<bool>("VerifyConfDelivery"),
                                                                          WebPass = infos.Field<string>("WebPass"),
                                                                          WebsiteDir = infos.Field<string>("WebsiteDir")
                                                                      }).AsEnumerable<SearchClientCustomSQLData>();
                #endregion

                // Release
                dtInfos = null;
                dtContacts = null;
                dtInvoiceDivisions = null;
                dtOtherAddresses = null;
                dtSpecialPrices = null;

                // Get dtResult from joinResult
                DataTable dtJoined = new DataTable();
                using (var reader = ObjectReader.Create(join5Result))
                {
                    dtJoined.Load(reader);
                }

                // Escape
                conditions = conditions.Replace("'", "''");
                conditions = conditions.Replace("\"", "'");

                // Filter
                DataView dvFilter = new DataView(dtJoined);
                dvFilter.RowFilter = conditions;
                dtJoined = dvFilter.ToTable(true, "PrimaryKey");

                List<string> lstClientId = (from client in dtJoined.AsEnumerable()
                                            select client.Field<string>("PrimaryKey")).ToList<string>();

                //List<ClientData> lstClient = new List<ClientData>();
                //foreach (DataRow row in dtJoined.Rows)
                //{
                //    ClientData client = new ClientData();
                //    client.ClientId = row["PrimaryKey"].ToString();
                //    lstClient.Add(client);
                //}

                //// Get all columns after filter
                //IEnumerable<ClientData> join2Result = (from client1 in lstClient.AsEnumerable()
                //                                       join client2 in clientData.AsEnumerable() on client1.ClientId equals client2.ClientId
                //                                       select client2).AsEnumerable<ClientData>();

                return lstClientId;
            }
            else
            {
                return null;
            }
        }

        public static List<string> SearchClientCustom(List<ClientData> clientData, string conditions)
        {
            if (clientData.Any())
            {
                DataTable dtInfos = new DataTable();
                DataTable dtContacts = new DataTable();
                DataTable dtInvoiceDivisions = new DataTable();
                DataTable dtOtherAddresses = new DataTable();

                #region Add columns for Infos
                dtInfos.Columns.Add("BillingAddress", typeof(String));
                dtInfos.Columns.Add("BillingInfo", typeof(String));
                dtInfos.Columns.Add("ClientName", typeof(String));
                dtInfos.Columns.Add("CustomerNumber", typeof(String));
                dtInfos.Columns.Add("DefaultConfDelivery", typeof(String));
                dtInfos.Columns.Add("DefaultInvDelivery", typeof(String));
                dtInfos.Columns.Add("DefaultReportDelivery", typeof(String));
                dtInfos.Columns.Add("Email", typeof(String));
                dtInfos.Columns.Add("Fax", typeof(String));
                dtInfos.Columns.Add("Management", typeof(String));
                dtInfos.Columns.Add("MiscComments", typeof(String));
                dtInfos.Columns.Add("Phone", typeof(String));
                dtInfos.Columns.Add("PrimaryKey", typeof(String));
                dtInfos.Columns.Add("SpecialCriteriaInfo", typeof(String));
                dtInfos.Columns.Add("SpecialEntryInfo", typeof(String));
                #endregion

                #region Add columns for Contacts
                dtContacts.Columns.Add("PrimaryKey", typeof(String));
                dtContacts.Columns.Add("Contacts", typeof(String));
                #endregion

                #region Add columns for InvoiceDivisions
                dtInvoiceDivisions.Columns.Add("PrimaryKey", typeof(String));
                dtInvoiceDivisions.Columns.Add("InvoiceDivisions", typeof(String));
                #endregion

                #region Add columns for OtherAddresses
                dtOtherAddresses.Columns.Add("PrimaryKey", typeof(String));
                dtOtherAddresses.Columns.Add("OtherAddresses", typeof(String));
                #endregion

                for (int i = 0; i < clientData.Count(); i++)
                {
                    #region Load data to Infos
                    DataRow infoRow = dtInfos.NewRow();
                    infoRow["BillingAddress"] = clientData[i].BillingAddress;
                    infoRow["BillingInfo"] = clientData[i].BillingInfo;
                    infoRow["ClientName"] = clientData[i].ClientName;
                    infoRow["CustomerNumber"] = clientData[i].CustomerNumber;
                    infoRow["DefaultConfDelivery"] = clientData[i].DefaultDeliverConfirmationsTo;
                    infoRow["DefaultInvDelivery"] = clientData[i].DefaultDeliverInvoicesTo;
                    infoRow["DefaultReportDelivery"] = clientData[i].DefaultDeliverReportsTo;
                    infoRow["Email"] = clientData[i].Email;
                    infoRow["Fax"] = clientData[i].Fax;
                    if (clientData[i].ManagementCompany != null && !string.IsNullOrEmpty(clientData[i].ManagementCompany.Name.Trim()))
                    {
                        infoRow["Management"] = clientData[i].ManagementCompany.Name;
                    }
                    else
                    {
                        infoRow["Management"] = "";
                    }
                    infoRow["MiscComments"] = clientData[i].MiscComments;
                    infoRow["Phone"] = clientData[i].Phone;
                    infoRow["PrimaryKey"] = clientData[i].ClientId;
                    infoRow["SpecialCriteriaInfo"] = clientData[i].SpecialCriteriaInfo;
                    infoRow["SpecialEntryInfo"] = clientData[i].SpecialEntryInfo;
                    dtInfos.Rows.Add(infoRow);
                    #endregion

                    #region Load data to Contacts
                    if (clientData[i].Contacts.Any())
                    {
                        foreach (ContactData contact in clientData[i].Contacts)
                        {
                            DataRow row = dtContacts.NewRow();
                            row["PrimaryKey"] = clientData[i].ClientId;
                            row["Contacts"] = contact.ContactInfo;
                            dtContacts.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DataRow row = dtContacts.NewRow();
                        row["PrimaryKey"] = clientData[i].ClientId;
                        row["Contacts"] = "";
                        dtContacts.Rows.Add(row);
                    }
                    #endregion

                    #region Add data to InvoiceDivisions
                    if (clientData[i].InvoiceDivisions.Any())
                    {
                        foreach (InvoiceDivisionData invoiceDivision in clientData[i].InvoiceDivisions)
                        {
                            DataRow row = dtInvoiceDivisions.NewRow();
                            row["PrimaryKey"] = clientData[i].ClientId;
                            row["InvoiceDivisions"] = invoiceDivision.DivisionName;
                            dtInvoiceDivisions.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DataRow row = dtInvoiceDivisions.NewRow();
                        row["PrimaryKey"] = clientData[i].ClientId;
                        row["InvoiceDivisions"] = "";
                        dtInvoiceDivisions.Rows.Add(row);
                    }
                    #endregion

                    #region Load data to OtherAddresses
                    if (clientData[i].OtherAddresses.Any())
                    {
                        foreach (OtherAddressData otherAddress in clientData[i].OtherAddresses)
                        {
                            DataRow row = dtOtherAddresses.NewRow();
                            row["PrimaryKey"] = clientData[i].ClientId;
                            row["OtherAddresses"] = otherAddress.Address;
                            dtOtherAddresses.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DataRow row = dtOtherAddresses.NewRow();
                        row["PrimaryKey"] = clientData[i].ClientId;
                        row["OtherAddresses"] = "";
                        dtOtherAddresses.Rows.Add(row);
                    }
                    #endregion
                }

                #region Join 4 tables
                IEnumerable<SearchClientCustomData> join4Result = (from infos in dtInfos.AsEnumerable()
                                                                   join contacts in dtContacts.AsEnumerable() on (string)infos["PrimaryKey"] equals (string)contacts["PrimaryKey"]
                                                                   join invoiceDivisions in dtInvoiceDivisions.AsEnumerable() on (string)infos["PrimaryKey"] equals (string)invoiceDivisions["PrimaryKey"]
                                                                   join otherAddresses in dtOtherAddresses.AsEnumerable() on (string)infos["PrimaryKey"] equals (string)otherAddresses["PrimaryKey"]
                                                                   select new SearchClientCustomData()
                                                                  {
                                                                      BillingAddress = infos.Field<string>("BillingAddress"),
                                                                      BillingInfo = infos.Field<string>("BillingInfo"),
                                                                      ClientName = infos.Field<string>("ClientName"),
                                                                      Contacts = contacts.Field<string>("Contacts"),
                                                                      CustomerNumber = infos.Field<string>("CustomerNumber"),
                                                                      DefaultConfDelivery = infos.Field<string>("DefaultConfDelivery"),
                                                                      DefaultInvDelivery = infos.Field<string>("DefaultInvDelivery"),
                                                                      DefaultReportDelivery = infos.Field<string>("DefaultReportDelivery"),
                                                                      Email = infos.Field<string>("Email"),
                                                                      Fax = infos.Field<string>("Fax"),
                                                                      InvoiceDivisions = invoiceDivisions.Field<string>("InvoiceDivisions"),
                                                                      Management = infos.Field<string>("Management"),
                                                                      MiscComments = infos.Field<string>("MiscComments"),
                                                                      OtherAddresses = otherAddresses.Field<string>("OtherAddresses"),
                                                                      Phone = infos.Field<string>("Phone"),
                                                                      PrimaryKey = infos.Field<string>("PrimaryKey"),
                                                                      SpecialCriteriaInfo = infos.Field<string>("SpecialCriteriaInfo"),
                                                                      SpecialEntryInfo = infos.Field<string>("SpecialEntryInfo")
                                                                  }).AsEnumerable<SearchClientCustomData>();
                #endregion

                // Release
                dtInfos = null;
                dtContacts = null;
                dtInvoiceDivisions = null;
                dtOtherAddresses = null;

                // Get dtResult from joinResult
                DataTable dtJoined = new DataTable();
                using (var reader = ObjectReader.Create(join4Result))
                {
                    dtJoined.Load(reader);
                }

                // Escape
                conditions = conditions.Replace("'", "''");
                conditions = conditions.Replace("\"", "'");

                // Filter
                DataView dvFilter = new DataView(dtJoined);
                dvFilter.RowFilter = conditions;
                dtJoined = dvFilter.ToTable(true, "PrimaryKey");

                List<string> lstClientId = (from client in dtJoined.AsEnumerable()
                                            select client.Field<string>("PrimaryKey")).ToList<string>();

                //List<ClientData> lstClient = new List<ClientData>();
                //foreach (DataRow row in dtJoined.Rows)
                //{
                //    ClientData client = new ClientData();
                //    client.ClientId = row["PrimaryKey"].ToString();
                //    lstClient.Add(client);
                //}

                //// Get all columns after filter
                //IEnumerable<ClientData> join2Result = (from client1 in lstClient.AsEnumerable()
                //                                       join client2 in clientData.AsEnumerable() on client1.ClientId equals client2.ClientId
                //                                       select client2).AsEnumerable<ClientData>();

                return lstClientId;
            }
            else
            {
                return null;
            }
        }

        public static List<string> SearchClientSpecialBilling(List<ClientData> clientData, string conditions, List<ReportTypeData> reportTypeData)
        {
            if (clientData.Any())
            {
                DataTable dtInvoiceDivisions = new DataTable();
                DataTable dtSpecialPrices = new DataTable();
                DataTable dtReportTypes = null;

                if (reportTypeData != null && reportTypeData.Count > 0)
                {
                    using (var reader = ObjectReader.Create(reportTypeData.AsEnumerable<ReportTypeData>()))
                    {
                        dtReportTypes = new DataTable();
                        dtReportTypes.Load(reader);
                    }
                }

                #region Add columns for InvoiceDivisions
                dtInvoiceDivisions.Columns.Add("PrimaryKey", typeof(String));
                dtInvoiceDivisions.Columns.Add("InvoiceDivisions", typeof(String));
                #endregion

                #region Add columns for SpecialPrices
                dtSpecialPrices.Columns.Add("PrimaryKey", typeof(String));
                dtSpecialPrices.Columns.Add("ReportTypeId", typeof(String));
                dtSpecialPrices.Columns.Add("SpecialPrices", typeof(Decimal));
                #endregion

                for (int i = 0; i < clientData.Count(); i++)
                {
                    #region Add data to InvoiceDivisions
                    if (clientData[i].InvoiceDivisions.Any())
                    {
                        foreach (InvoiceDivisionData invoiceDivision in clientData[i].InvoiceDivisions)
                        {
                            DataRow row = dtInvoiceDivisions.NewRow();
                            row["PrimaryKey"] = clientData[i].ClientId;
                            row["InvoiceDivisions"] = invoiceDivision.DivisionName;
                            dtInvoiceDivisions.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DataRow row = dtInvoiceDivisions.NewRow();
                        row["PrimaryKey"] = clientData[i].ClientId;
                        row["InvoiceDivisions"] = "";
                        dtInvoiceDivisions.Rows.Add(row);
                    }
                    #endregion

                    #region Load data to SpecialPrices
                    if (clientData[i].ClientReportSpecialPrices.Any())
                    {
                        foreach (ClientReportSpecialPriceData specialPrice in clientData[i].ClientReportSpecialPrices)
                        {
                            DataRow row = dtSpecialPrices.NewRow();
                            row["PrimaryKey"] = clientData[i].ClientId;
                            row["ReportTypeId"] = specialPrice.ReportTypeId;
                            row["SpecialPrices"] = specialPrice.SpecialPrice;
                            dtSpecialPrices.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DataRow row = dtSpecialPrices.NewRow();
                        row["PrimaryKey"] = clientData[i].ClientId;
                        row["ReportTypeId"] = "";
                        row["SpecialPrices"] = DBNull.Value;
                        dtSpecialPrices.Rows.Add(row);
                    }
                    #endregion
                }

                #region Join tables
                IEnumerable<SearchClientSpecialBillingData> joinResult;
                if (dtReportTypes == null)
                {
                    joinResult = (from invoiceDivisions in dtInvoiceDivisions.AsEnumerable()
                                  join specialPrices in dtSpecialPrices.AsEnumerable() on (string)invoiceDivisions["PrimaryKey"] equals (string)specialPrices["PrimaryKey"]
                                  select new SearchClientSpecialBillingData()
                                  {
                                      InvoiceDivisions = invoiceDivisions.Field<string>("InvoiceDivisions"),
                                      PrimaryKey = invoiceDivisions.Field<string>("PrimaryKey"),
                                      SpecialPrices = specialPrices.Field<decimal?>("SpecialPrices")
                                  }).AsEnumerable<SearchClientSpecialBillingData>();
                }
                else
                {
                    joinResult = (from invoiceDivisions in dtInvoiceDivisions.AsEnumerable()
                                  join specialPrices in dtSpecialPrices.AsEnumerable() on (string)invoiceDivisions["PrimaryKey"] equals (string)specialPrices["PrimaryKey"]
                                  join reportTypes in dtReportTypes.AsEnumerable() on (string)specialPrices["ReportTypeId"] equals (string)reportTypes["ReportTypeId"]
                                  select new SearchClientSpecialBillingData()
                                  {
                                      InvoiceDivisions = invoiceDivisions.Field<string>("InvoiceDivisions"),
                                      PrimaryKey = invoiceDivisions.Field<string>("PrimaryKey"),
                                      ReportTypeName = reportTypes.Field<string>("TypeName"),
                                      SpecialPrices = specialPrices.Field<decimal?>("SpecialPrices")
                                  }).AsEnumerable<SearchClientSpecialBillingData>();
                }
                #endregion

                // Release
                dtInvoiceDivisions = null;
                dtSpecialPrices = null;
                dtReportTypes = null;

                // Get dtResult from joinResult
                DataTable dtJoined = new DataTable();
                using (var reader = ObjectReader.Create(joinResult))
                {
                    dtJoined.Load(reader);
                }

                // Escape
                conditions = conditions.Replace("'", "''");
                conditions = conditions.Replace("\"", "'");

                // Filter
                DataView dvFilter = new DataView(dtJoined);
                dvFilter.RowFilter = conditions;
                dtJoined = dvFilter.ToTable(true, "PrimaryKey");

                List<string> lstClientId = (from client in dtJoined.AsEnumerable()
                                            select client.Field<string>("PrimaryKey")).ToList<string>();

                //List<ClientData> lstClient = new List<ClientData>();
                //foreach (DataRow row in dtJoined.Rows)
                //{
                //    ClientData client = new ClientData();
                //    client.ClientId = row["PrimaryKey"].ToString();
                //    lstClient.Add(client);
                //}

                //// Get all columns after filter
                //IEnumerable<ClientData> join2Result = (from client1 in lstClient.AsEnumerable()
                //                                       join client2 in clientData.AsEnumerable() on client1.ClientId equals client2.ClientId
                //                                       select client2).AsEnumerable<ClientData>();

                return lstClientId;
            }
            else
            {
                return null;
            }
        }
    }
}
