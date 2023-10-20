using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using System.ComponentModel;
using Core.Infrastructure.ExploreApps;
using Core.Domain.Model.ExploreApps;
using System.Globalization;
using Core.Infrastructure.ClientInfo;
using Core.Domain.Model.ClientInfo;
using IdentityAccess.Infrastructure.Identity;
using IdentityAccess.Domain.Model.Identity;
using Common.Application;
using Invoice.Infrastructure;
using Invoice.Domain.Model;
using Core.Application;

namespace DataMigrationApp
{
    public class AppMigrationService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TimeZoneInfo z = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        public Dictionary<string, string> appIdDictionary = new Dictionary<string, string>(); // oldAppId - newAppId

        public AppMigrationService(string sourceConnectionString, Dictionary<string, string> appIdDictionary)
        {
            this.SourceConnectionString = sourceConnectionString;
            this.appIdDictionary = appIdDictionary;
        }

        public string SourceConnectionString { get; set; }

        public void UpdateAppData(BackgroundWorker bw)
        {
            AppRepository appRepository = new AppRepository();
            ClientRepository clientRepository = new ClientRepository();
            ReportTypeRepository reportTypeRepository = new ReportTypeRepository();
            UserRepository userRepository = new UserRepository();
            AppIdMappingRepository appIdMappingRepository = new AppIdMappingRepository();

            ExploreAppsQueryService service = new ExploreAppsQueryService();
            List<App> apps = service.FindAllAppHasNullClientId();
            List<Client> lstClients = clientRepository.FindAll();
            List<ReportType> lstReportTypes = (List<ReportType>)reportTypeRepository.FindAll();
            List<User> lstUsers = userRepository.FindAll();
            string appId = string.Empty;
            try
            {
                foreach (var app in apps)
                {
                    DataTable sourceAppTable = new DataTable();
                    string lastName = app.LastName;
                    if (!string.IsNullOrEmpty(app.LastName) && app.LastName.Contains("'"))
                    {
                        lastName = app.LastName.Replace("'", "''");
                    }

                    string firstName = app.FirstName;
                    if (!string.IsNullOrEmpty(app.FirstName) && app.FirstName.Contains("'"))
                    {
                        firstName = app.FirstName.Replace("'", "''");
                    }
                    
                    
                    using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                    {                        
                        OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                        sourceAdapter.SelectCommand = new OleDbCommand(string.Format("select * from Applications where LastName = '{0}' and FirstName = '{1}'", lastName, firstName), sourceConnection);
                        sourceAdapter.Fill(sourceAppTable);
                        if(sourceAppTable.Rows[0] == null)
                        {
                            continue;
                        }
                        string clientName = sourceAppTable.Rows[0]["ClientApplied"].ToString().Trim();
                        appRepository.Update(app.ApplicationId.ToString(), clientName);
                        appId = app.ApplicationId.Id;
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Update error at application Id: {0}", appId));
                System.Diagnostics.Trace.WriteLine(ex.Message);
                throw;
            }
        }

        public void MigrateApp(BackgroundWorker bw)
        {
            try
            {
                DataTable sourceAppTable = new DataTable();

                AppRepository appRepository = new AppRepository();
                ClientRepository clientRepository = new ClientRepository();
                ReportTypeRepository reportTypeRepository = new ReportTypeRepository();
                UserRepository userRepository = new UserRepository();
                AppIdMappingRepository appIdMappingRepository = new AppIdMappingRepository();

                List<Client> lstClients = clientRepository.FindAll();
                List<ReportType> lstReportTypes = (List<ReportType>)reportTypeRepository.FindAll();
                List<User> lstUsers = userRepository.FindAll();

                int latestPrimaryKey = 0;

                try
                {
                    using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                    {
                        OleDbDataAdapter sourceAdapter = new OleDbDataAdapter();
                        sourceAdapter.SelectCommand = new OleDbCommand("select top 100000 [PrimaryKey],[LastName] ,[FirstName] ,[MiddleName] " +
                            ",[AppSSN],[SpouseFirstName],[SpouseMiddleName],[SpouseSSN],[BirthDate],[HouseNumber],[StreetAddress],[City],[State],[PostalCode],[ClientApplied],[ReportType]" +
                            ",[ReportCommunity],[ReportManagement],[UnitNumber],[RentAmount],[MoveInDate],[ReportSpecialField],[RecQualifier],[BankInfo]" +
                            ",[PagesReceived],[Location],[ReceiveDate],[CompleteDate],[Screener],[PositionApplied],[CompanyApplied],[CreditInfo]" +
                            ",[CreditRefs],[EmpVers],[EmpRefs],[RentalRefs],[BankInfo],[Charges],[Evictions],[StaffComments],[Recommendation]" +
                            ",[FinalComments],[Priority],[CallsOut],[InvoiceDivision],[CreditPulled] from Applications order by [PrimaryKey] ASC", sourceConnection);
                        sourceAdapter.Fill(sourceAppTable);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                    throw;
                }

                foreach (DataRow row in sourceAppTable.Rows)
                {
                    if (!string.IsNullOrEmpty(row["PrimaryKey"].ToString()))
                    {
                        AppId appId = new AppId(Guid.NewGuid().ToString());

                        AppIdMapping appIdMapping = new AppIdMapping();
                        appIdMapping.OldAppId = row["PrimaryKey"].ToString();
                        appIdMapping.NewAppId = appId.Id;
                        appIdMappingRepository.Add(appIdMapping);

                        try
                        {
                            this.appIdDictionary.Add(appIdMapping.OldAppId, appIdMapping.NewAppId);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex.ToString());
                            this.appIdDictionary.Remove(appIdMapping.OldAppId);
                            this.appIdDictionary.Add(appIdMapping.OldAppId, appIdMapping.NewAppId);
                        }

                        App app = new App(appId);
                        app.LastName = row.IsNull("LastName") ? "" : row["LastName"].ToString();
                        app.FirstName = row.IsNull("FirstName") ? "" : row["FirstName"].ToString();
                        app.MiddleName = row.IsNull("MiddleName") ? "" : row["MiddleName"].ToString();
                        app.AppSSN = row.IsNull("AppSSN") ? "" : row["AppSSN"].ToString();
                        app.Company = "";
                        app.Phone = "";
                        app.RegAgent = "";
                        app.DateActive = "";
                        app.StateActive = "";
                        app.BankComm = "";
                        app.OpenedComm = "";
                        app.BalanceComm = "";
                        app.AcctComm = "";
                        app.NSFODComm = "";
                        app.SWComm = "";
                        if (!row.IsNull("BirthDate"))
                        {
                            DateTime tmp;
                            if (DateTime.TryParseExact(row["BirthDate"].ToString(), "MM/dd/yy",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out tmp))
                            {
                                app.BirthDate = tmp;
                            }
                            else
                            {
                                app.BirthDate = null;
                            }
                        }
                        app.HouseNumber = row.IsNull("HouseNumber") ? "" : row["HouseNumber"].ToString();
                        app.StreetAddress = row.IsNull("StreetAddress") ? "" : row["StreetAddress"].ToString();
                        app.City = row.IsNull("City") ? "" : row["City"].ToString();
                        app.State = row.IsNull("State") ? "" : row["State"].ToString();
                        app.PostalCode = row.IsNull("PostalCode") ? "" : row["PostalCode"].ToString();
                        app.ReportCommunity = row.IsNull("ReportCommunity") ? "" : row["ReportCommunity"].ToString();
                        app.ReportManagement = row.IsNull("ReportManagement") ? "" : row["ReportManagement"].ToString();
                        app.UnitNumber = row.IsNull("UnitNumber") ? "" : row["UnitNumber"].ToString();
                        app.RentAmount = row.IsNull("RentAmount") ? "" : row["RentAmount"].ToString();
                        app.MoveInDate = row.IsNull("MoveInDate") ? "" : row["MoveInDate"].ToString();
                        app.ReportSpecialField = row.IsNull("ReportSpecialField") ? "" : row["ReportSpecialField"].ToString();
                        if (!row.IsNull("PagesReceived"))
                        {
                            int tmp;
                            if (int.TryParse(row["PagesReceived"].ToString(), out tmp))
                            {
                                app.PagesReceived = tmp;
                            }
                            else
                            {
                                app.PagesReceived = 0;
                            }
                        }
                        else
                        {
                            app.PagesReceived = 0;
                        }

                        if (!row.IsNull("ReceiveDate"))
                        {
                            app.ReceivedDate = TimeZoneInfo.ConvertTimeToUtc((DateTime)row["ReceiveDate"], z);
                        }
                        else
                        {
                            app.ReceivedDate = null;
                        }

                        if (!row.IsNull("CompleteDate"))
                        {
                            app.CompletedDate = TimeZoneInfo.ConvertTimeToUtc((DateTime)row["CompleteDate"], z);
                        }
                        else
                        {
                            app.CompletedDate = null;
                        }
                        app.PositionApplied = row.IsNull("PositionApplied") ? "" : row["PositionApplied"].ToString();
                        app.CompanyApplied = row.IsNull("CompanyApplied") ? "" : row["CompanyApplied"].ToString();
                        app.StaffComments = row.IsNull("StaffComments") ? "" : row["StaffComments"].ToString();
                        app.FinalComments = row.IsNull("FinalComments") ? "" : row["FinalComments"].ToString();
                        app.InvoiceDivision = row.IsNull("InvoiceDivision") ? "" : row["InvoiceDivision"].ToString();
                        app.CreditPulled = row.IsNull("CreditPulled") ? "" : row["CreditPulled"].ToString();
                        app.CreatedAt = app.ReceivedDate;
                        app.UpdatedAt = app.CompletedDate;

                        app.ClientApplied = null;
                        if (!row.IsNull("ClientApplied"))
                        {
                            string clientApplied = row["ClientApplied"].ToString().Trim();
                            foreach (Client client in lstClients)
                            {
                                if (clientApplied == client.ClientName)
                                {
                                    ClientId clientId = new ClientId(client.ClientId.Id);
                                    app.ClientApplied = clientId;
                                    break;
                                }
                            }
                        }

                        if(app.ClientApplied == null)
                        {
                            app.ClientName = row["ClientApplied"].ToString().Trim();
                        }

                        app.ReportTypeId = null;
                        if (!row.IsNull("ReportType"))
                        {
                            foreach (ReportType reportType in lstReportTypes)
                            {
                                if (reportType.TypeName == row["ReportType"].ToString())
                                {
                                    ReportTypeId reportTypeId = new ReportTypeId(reportType.ReportTypeId);
                                    app.ReportTypeId = reportTypeId;
                                    break;
                                }
                            }
                            if (row["ReportType"].ToString() == "Comm")
                            {
                                app.Company = row.IsNull("LastName") ? "" : row["LastName"].ToString();
                                app.Phone = row.IsNull("FirstName") ? "" : row["FirstName"].ToString();
                                app.RegAgent = row.IsNull("SpouseFirstName") ? "" : row["SpouseFirstName"].ToString();
                                app.DateActive = row.IsNull("MiddleName") ? "" : row["MiddleName"].ToString();
                                app.StateActive = row.IsNull("SpouseMiddleName") ? "" : row["SpouseMiddleName"].ToString();

                                app.BankComm = "";
                                app.OpenedComm = "";
                                app.BalanceComm = "";
                                app.AcctComm = "";
                                app.NSFODComm = "";
                                app.SWComm = "";

                                string bankInfoString = row.IsNull("BankInfo") ? "" : row["BankInfo"].ToString();

                                try
                                {
                                    if (!string.IsNullOrEmpty(bankInfoString))
                                    {
                                        string[] infos = bankInfoString.Split(GlobalConstants.Sep);
                                        app.BankComm = infos[0] ?? "";
                                        app.OpenedComm = infos[1] ?? "";
                                        app.BalanceComm = infos[2] ?? "";
                                        app.AcctComm = infos[3] ?? "";
                                        app.NSFODComm = infos[4] ?? "";
                                        app.SWComm = infos[5] ?? "";
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Trace.WriteLine(ex.Message);
                                }
                            }
                        }

                        if (!row.IsNull("Location"))
                        {
                            string location = row["Location"].ToString();
                            if (location == "Archive")
                                app.Location = Location.Archive;
                            else if (location == "Review")
                                app.Location = Location.Review1;
                            else if (location == "New Apps")
                                app.Location = Location.NewApps;
                            else if (location == "Pickup")
                                app.Location = Location.Pickup;
                            else
                            {
                                foreach (User user in lstUsers)
                                {
                                    if (user.UserName == location)
                                    {
                                        Location fromUser = Location.FromUser(user);
                                        app.Location = fromUser;
                                        break;
                                    }
                                }
                                if (app.Location == null)
                                    app.Location = new Location("Invalid Location", location);
                            }
                        }
                        else
                        {
                            app.Location = Location.Archive;
                        }

                        // screener
                        if (!row.IsNull("Screener"))
                        {
                            string screener = row["Screener"].ToString();
                            foreach (User user in lstUsers)
                            {
                                if (user.UserName == screener)
                                {
                                    Screener fromUser = Screener.FromUser(user);
                                    app.Screener = fromUser;
                                    break;
                                }
                            }
                            if (app.Screener == null)
                                app.Screener = new Screener("Invalid Screener", screener);
                        }

                        // credit info
                        string creditInfoString = row.IsNull("CreditInfo") ? "" : row["CreditInfo"].ToString();
                        app.CreditInfo = GetCreditInfoFromString(creditInfoString);

                        // credit refs
                        string creditRefsString = row.IsNull("CreditRefs") ? "" : row["CreditRefs"].ToString();
                        app.CreditRefs = GetCreditRefsFromString(creditRefsString);

                        // empver
                        string empVerString = row.IsNull("EmpVers") ? "" : row["EmpVers"].ToString();
                        app.EmpVer = GetEmpVerFromString(empVerString);

                        //empRefs
                        string empRefsString = row.IsNull("EmpRefs") ? "" : row["EmpRefs"].ToString();
                        app.EmpRefs = GetEmpRefsFromString(empRefsString);

                        string rentalRefsString = row.IsNull("RentalRefs") ? "" : row["RentalRefs"].ToString();
                        app.RentalRefs = GetRentalRefsFromString(rentalRefsString);

                        string chargeRefsString = row.IsNull("Charges") ? "" : row["Charges"].ToString();
                        app.Charges = GetChargeRefsFromStrings(chargeRefsString);

                        string evictionRefsString = row.IsNull("Evictions") ? "" : row["Evictions"].ToString();
                        app.Evictions = GetEvictionRefsFromString(evictionRefsString);

                        string recommendationFactInfoString = row.IsNull("Recommendation") ? "" : row["Recommendation"].ToString();
                        app.Recommendation = GetRecommendationFactInfoFromString(recommendationFactInfoString);

                        string priorityString = row.IsNull("Priority") ? "" : row["Priority"].ToString();
                        app.Priority = GetPriorityAppFromString(priorityString);

                        string contactAttemptString = row.IsNull("CallsOut") ? "" : row["CallsOut"].ToString();
                        app.ContactAttempts = GetContactAttemptsFromString(contactAttemptString);


                        appRepository.Add(app);

                        latestPrimaryKey = int.Parse(row["PrimaryKey"].ToString());
                    }
                }

                _logger.Error("AppMigrationService appIdDictionary Count: " + this.appIdDictionary.Count);

                using (OleDbConnection sourceConnection = new OleDbConnection(SourceConnectionString))
                {
                    sourceConnection.Open();
                    OleDbCommand oledbcommand = new OleDbCommand("delete from Applications where PrimaryKey <= @PrimaryKey ", sourceConnection);
                    OleDbParameter param = oledbcommand.Parameters.Add("@PrimaryKey", latestPrimaryKey);
                    oledbcommand.ExecuteNonQuery();
                    sourceConnection.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                _logger.Error(ex);
            }
        }

        private CreditInfo GetCreditInfoFromString(string creditInfoString)
        {
            try
            {
                if (!string.IsNullOrEmpty(creditInfoString))
                {
                    string[] creditInfos = creditInfoString.Split(GlobalConstants.Sep);
                    return new CreditInfo(((creditInfos[0]) == "1"),
                        (creditInfos[1] == "1"),
                        (creditInfos[2] == "1"),
                        decimal.Parse(creditInfos[3]),
                        decimal.Parse(creditInfos[4]),
                        decimal.Parse(creditInfos[5]),
                        decimal.Parse(creditInfos[6]),
                        decimal.Parse(creditInfos[7]),
                        decimal.Parse(creditInfos[8]),
                        creditInfos[9].ToString(),
                        (creditInfos[10] == "1"),
                        creditInfos[11].ToString());
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<CreditRef> GetCreditRefsFromString(string creditRefsString)
        {
            List<CreditRef> result = new List<CreditRef>();
            try
            {
                if (!string.IsNullOrEmpty(creditRefsString))
                {
                    string[] creditRefStrings = creditRefsString.Split(GlobalConstants.RecSep);
                    foreach (string creditRefItemString in creditRefStrings)
                    {
                        string[] items = creditRefItemString.Split(GlobalConstants.Sep);
                        CreditRef refItem = new CreditRef(items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10]);
                        result.Add(refItem);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Clear();
                return result;
            }
        }

        private EmpVer GetEmpVerFromString(string empVerString)
        {
            try
            {
                if (!string.IsNullOrEmpty(empVerString))
                {
                    string[] items = empVerString.Split(GlobalConstants.Sep);
                    return new EmpVer(items[0], items[1], items[2], items[3], items[4],
                        items[5], items[6], items[7], items[8], items[9],
                        items[10], items[11], items[12], items[13], items[14],
                        items[15], items[16]);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<EmpRef> GetEmpRefsFromString(string empRefsString)
        {
            List<EmpRef> result = new List<EmpRef>();
            try
            {
                if (!string.IsNullOrEmpty(empRefsString))
                {
                    string[] empRefStrings = empRefsString.Split(GlobalConstants.RecSep);
                    foreach (string empRefItemString in empRefStrings)
                    {
                        string[] items = empRefItemString.Split(GlobalConstants.Sep);
                        EmpRef refItem = new EmpRef(items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10]);
                        result.Add(refItem);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Clear();
                return result;
            }
        }

        private List<RentalRef> GetRentalRefsFromString(string rentalRefsString)
        {
            List<RentalRef> result = new List<RentalRef>();
            try
            {
                if (!string.IsNullOrEmpty(rentalRefsString))
                {
                    string[] rentalRefStrings = rentalRefsString.Split(GlobalConstants.RecSep);
                    foreach (string rentalRefItemString in rentalRefStrings)
                    {
                        string[] items = rentalRefItemString.Split(GlobalConstants.Sep);
                        RentalRefFactInfo[] rentalFactInfos = new RentalRefFactInfo[12];
                        for (int i = 0; i < 12; i++)
                        {
                            if (items[i + 2] == "Y")
                            {
                                rentalFactInfos[i] = RentalRefFactInfo.Yes;
                            }
                            else if (items[i + 2] == "N")
                            {
                                rentalFactInfos[i] = RentalRefFactInfo.No;
                            }
                            else
                                rentalFactInfos[i] = RentalRefFactInfo.NotAvailable;
                        }
                        RentalRefFactInfo bedBugs = RentalRefFactInfo.NotAvailable;
                        RentalRef refItem = new RentalRef(rentalFactInfos[0], rentalFactInfos[1],
                            rentalFactInfos[2], rentalFactInfos[3], rentalFactInfos[4], rentalFactInfos[5],
                            rentalFactInfos[6], rentalFactInfos[7], rentalFactInfos[8], rentalFactInfos[9], rentalFactInfos[10],
                            rentalFactInfos[11], bedBugs, items[14], items[15], items[16],
                            items[17], items[18], items[19], items[20]);

                        result.Add(refItem);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Clear();
                return result;
            }
        }

        private List<ChargeRef> GetChargeRefsFromStrings(string chargeRefsString)
        {
            List<ChargeRef> result = new List<ChargeRef>();
            try
            {
                if (!string.IsNullOrEmpty(chargeRefsString))
                {
                    string[] rentalRefStrings = chargeRefsString.Split(GlobalConstants.RecSep);
                    foreach (string chargeRefItemString in rentalRefStrings)
                    {
                        string[] items = chargeRefItemString.Split(GlobalConstants.Sep);

                        ChargeRef refItem = new ChargeRef(items[2], items[3], items[4], items[5], items[6], items[7]);

                        result.Add(refItem);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Clear();
                return result;
            }
        }

        private List<EvictionRef> GetEvictionRefsFromString(string evictionRefsString)
        {
            List<EvictionRef> result = new List<EvictionRef>();
            try
            {
                if (!string.IsNullOrEmpty(evictionRefsString))
                {
                    string[] rentalRefStrings = evictionRefsString.Split(GlobalConstants.RecSep);
                    foreach (string evictionRefItemString in rentalRefStrings)
                    {
                        string[] items = evictionRefItemString.Split(GlobalConstants.Sep);

                        EvictionRef refItem = new EvictionRef(items[2], items[3], items[4], items[5], items[6]);

                        result.Add(refItem);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Clear();
                return result;
            }
        }

        private RecommendationFactInfo GetRecommendationFactInfoFromString(string recommendationFactInfoString)
        {
            try
            {
                if (!string.IsNullOrEmpty(recommendationFactInfoString))
                {
                    string[] items = recommendationFactInfoString.Split(GlobalConstants.Sep);
                    bool[] values = new bool[11];
                    for (int i = 0; i < 11; i++)
                    {
                        values[i] = (items[i] == "1");
                    }
                    return new RecommendationFactInfo(
                        values[0], values[1], values[2], values[3], values[4],
                        values[5], values[6], values[7], values[8], values[9], values[10]);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private PriorityApp GetPriorityAppFromString(string priorityString)
        {
            try
            {
                if (!string.IsNullOrEmpty(priorityString))
                {
                    string[] items = priorityString.Split(GlobalConstants.Hyphen);
                    int value = int.Parse(items[0].Trim());
                    return PriorityApp.CreateInstance(value);
                }
                return PriorityApp.None;
            }
            catch (Exception ex)
            {
                return PriorityApp.None;
            }
        }

        private List<ContactAttempt> GetContactAttemptsFromString(string contactAttemptsString)
        {
            List<ContactAttempt> result = new List<ContactAttempt>();
            try
            {
                if (!string.IsNullOrEmpty(contactAttemptsString))
                {
                    string[] contactAttempStrings = contactAttemptsString.Split(GlobalConstants.RecSep);
                    foreach (string contactAttemptItemString in contactAttempStrings)
                    {
                        string[] items = contactAttemptItemString.Split(GlobalConstants.Sep);
                        string contactAttempTypeString = items[2];
                        ContactAttemptType attemptType = ContactAttemptType.RentalReference;
                        if (contactAttempTypeString == "Rental Reference")
                        {
                            attemptType = ContactAttemptType.RentalReference;
                        }
                        else if (contactAttempTypeString == "Employment")
                        {
                            attemptType = ContactAttemptType.Employment;
                        }
                        else if (contactAttempTypeString == "Criminal Info.")
                        {
                            attemptType = ContactAttemptType.CrimminalInfo;
                        }
                        else if (contactAttempTypeString == "Credit/Bank Ref.")
                        {
                            attemptType = ContactAttemptType.CreditBankRef;
                        }
                        else if (contactAttempTypeString == "Client Update")
                        {
                            attemptType = ContactAttemptType.ClientUpdate;
                        }

                        ContactAttempt refItem = new ContactAttempt(
                            attemptType, bool.Parse(items[3]), items[4], items[5], items[6]);

                        result.Add(refItem);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Clear();
                return result;
            }
        }

    }
}
