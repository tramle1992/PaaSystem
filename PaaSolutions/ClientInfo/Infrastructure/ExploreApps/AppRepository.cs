using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Common.Infrastructure.Repository;
using System.Data.SqlClient;
using Dapper;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Common.Infrastructure.Helper;
using Core.Domain.Model.ExploreApps;
using Core.Domain.Model.ClientInfo;

namespace Core.Infrastructure.ExploreApps
{
    public class AppRepository : Repository<App, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AppRepository()
        { }

        public override void Add(App item)
        {
            try
            {
                string empRefsXml = "";
                string rentalRefsXml = "";
                string chargesXml = "";
                string evictionsXml = "";
                string creditRefsXml = "";
                string empVerXml = "";
                string creditInfoXml = "";
                string contactAttemptXml = "";
                string recommendationXml = "";

                if (item.EmpRefs.Count > 0)
                {
                    empRefsXml = XmlSerializationHelper.Serialize<List<EmpRef>>((List<EmpRef>)item.EmpRefs);
                }
                if (item.RentalRefs.Count > 0)
                {
                    rentalRefsXml = XmlSerializationHelper.Serialize<List<RentalRef>>((List<RentalRef>)item.RentalRefs);
                }
                if (item.Charges.Count > 0)
                {
                    chargesXml = XmlSerializationHelper.Serialize<List<ChargeRef>>((List<ChargeRef>)item.Charges);
                }
                if (item.Evictions.Count > 0)
                {
                    evictionsXml = XmlSerializationHelper.Serialize<List<EvictionRef>>((List<EvictionRef>)item.Evictions);
                }
                if (item.CreditRefs.Count > 0)
                {
                    creditRefsXml = XmlSerializationHelper.Serialize<List<CreditRef>>((List<CreditRef>)item.CreditRefs);
                }
                if (item.EmpVer != null)
                {
                    empVerXml = XmlSerializationHelper.Serialize<EmpVer>(item.EmpVer);
                }
                if (item.CreditInfo != null)
                {
                    creditInfoXml = XmlSerializationHelper.Serialize<CreditInfo>(item.CreditInfo);
                }
                if (item.ContactAttempts != null)
                {
                    contactAttemptXml = XmlSerializationHelper.Serialize<List<ContactAttempt>>(item.ContactAttempts);
                }
                if (item.Recommendation != null)
                {
                    recommendationXml = XmlSerializationHelper.Serialize<RecommendationFactInfo>(item.Recommendation);
                }
                if (item.InvoiceDivision == null)
                {
                    item.InvoiceDivision = string.Empty;
                }

                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert application(application_id, last_name, first_name, middle_name " +
                        ", company, phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, client_id " +
                        ", report_type_id, report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field " +
                        ", page_received, location_id, location_name, received_date, completed_date, screener_id, screener_name " +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled" +
                        ", created_at, updated_at) values (@application_id, @last_name, @first_name, @middle_name " +
                        ", @company, @phone, @reg_agent, @state_active, @date_active " +
                        ", @app_ssn, @birth_date, @house_number, @street_address, @city, @state, @postal_code, @client_id " +
                        ", @report_type_id, @report_community, @report_management, @unit_number " +
                        ", @rent_amount, @movein_date, @report_special_field " +
                        ", @page_received, @location_id, @location_name, @received_date, @completed_date, @screener_id, @screener_name " +
                        ", @bank_comm, @opened_comm, @balance_comm, @acct_comm, @nsfod_comm, @sw_comm" +
                        ", @position_applied, @company_applied, @credit_info, @credit_refs, @emp_ver, @emp_refs" +
                        ", @rental_refs, @charges, @evictions, @staff_comments, @final_comments, @recommendation" +
                        ", @priority, @contact_attempt, @invoice_division, @credit_pulled" +
                        ", @created_at, @updated_at)";

                    var args = new DynamicParameters();
                    args.Add("application_id", item.ApplicationId.Id);
                    args.Add("last_name", item.LastName);
                    args.Add("first_name", item.FirstName);
                    args.Add("middle_name", item.MiddleName);
                    args.Add("app_ssn", item.AppSSN);
                    args.Add("company", item.Company);
                    args.Add("phone", item.Phone);
                    args.Add("reg_agent", item.RegAgent);
                    args.Add("state_active", item.StateActive);
                    args.Add("date_active", item.DateActive);
                    args.Add("birth_date", item.BirthDate);
                    args.Add("house_number", item.HouseNumber);
                    args.Add("street_address", item.StreetAddress);
                    args.Add("city", item.City);
                    args.Add("state", item.State);
                    args.Add("postal_code", item.PostalCode);
                    args.Add("client_id", (item.ClientApplied == null) ? null : item.ClientApplied.Id);
                    args.Add("report_type_id", (item.ReportTypeId == null) ? null : item.ReportTypeId.Id);
                    args.Add("report_community", item.ReportCommunity);
                    args.Add("report_management", item.ReportManagement);
                    args.Add("unit_number", item.UnitNumber);
                    args.Add("rent_amount", item.RentAmount);
                    args.Add("movein_date", item.MoveInDate);
                    args.Add("report_special_field", item.ReportSpecialField);
                    args.Add("page_received", item.PagesReceived);
                    args.Add("location_id", item.Location.LocationId);
                    args.Add("location_name", item.Location.LocationName);
                    args.Add("received_date", item.ReceivedDate);
                    args.Add("completed_date", item.CompletedDate);
                    args.Add("screener_id", item.Screener.ScreenerId);
                    args.Add("screener_name", item.Screener.ScreenerName);
                    args.Add("position_applied", item.PositionApplied);
                    args.Add("company_applied", item.CompanyApplied);
                    args.Add("credit_info", creditInfoXml);
                    args.Add("credit_refs", creditRefsXml);
                    args.Add("bank_comm", item.BankComm);
                    args.Add("opened_comm", item.OpenedComm);
                    args.Add("balance_comm", item.BalanceComm);
                    args.Add("acct_comm", item.AcctComm);
                    args.Add("nsfod_comm", item.NSFODComm);
                    args.Add("sw_comm", item.SWComm);
                    args.Add("emp_ver", empVerXml);
                    args.Add("emp_refs", empRefsXml);
                    args.Add("rental_refs", rentalRefsXml);
                    args.Add("charges", chargesXml);
                    args.Add("evictions", evictionsXml);
                    args.Add("staff_comments", item.StaffComments);
                    args.Add("final_comments", item.FinalComments);
                    args.Add("recommendation", recommendationXml);
                    args.Add("priority", item.Priority.Value);
                    args.Add("contact_attempt", contactAttemptXml);
                    args.Add("invoice_division", item.InvoiceDivision);
                    args.Add("credit_pulled", item.CreditPulled);
                    args.Add("created_at", DateTime.UtcNow);
                    args.Add("updated_at", DateTime.UtcNow);

                    cn.Execute(insertStatement, args);
                }

            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Remove(App item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from application where application_id = @application_id";

                    cn.Execute(deleteStatement, new { application_id = item.ApplicationId.Id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void Remove(string id)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from credit_report where application_id = @application_id; delete from application where application_id = @application_id";

                    cn.Execute(deleteStatement, new { application_id = id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void RemoveAll()
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from application ";

                    cn.Execute(deleteStatement);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void Update(string id, string clientName)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update application set client_applied_name = @client_applied_name where application_id = @application_id";

                    cn.Execute(updateStatement, new { client_applied_name = clientName, application_id = id });
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(App item)
        {
            try
            {
                string empRefsXml = "";
                string rentalRefsXml = "";
                string chargesXml = "";
                string evictionsXml = "";
                string creditRefsXml = "";
                string empVerXml = "";
                string creditInfoXml = "";
                string contactAttemptXml = "";
                string recommendationXml = "";

                if (item.EmpRefs.Count > 0)
                {
                    empRefsXml = XmlSerializationHelper.Serialize<List<EmpRef>>((List<EmpRef>)item.EmpRefs);
                }
                if (item.RentalRefs.Count > 0)
                {
                    rentalRefsXml = XmlSerializationHelper.Serialize<List<RentalRef>>((List<RentalRef>)item.RentalRefs);
                }
                if (item.Charges.Count > 0)
                {
                    chargesXml = XmlSerializationHelper.Serialize<List<ChargeRef>>((List<ChargeRef>)item.Charges);
                }
                if (item.Evictions.Count > 0)
                {
                    evictionsXml = XmlSerializationHelper.Serialize<List<EvictionRef>>((List<EvictionRef>)item.Evictions);
                }
                if (item.CreditRefs.Count > 0)
                {
                    creditRefsXml = XmlSerializationHelper.Serialize<List<CreditRef>>((List<CreditRef>)item.CreditRefs);
                }
                if (item.EmpVer != null)
                {
                    empVerXml = XmlSerializationHelper.Serialize<EmpVer>(item.EmpVer);
                }
                if (item.CreditInfo != null)
                {
                    creditInfoXml = XmlSerializationHelper.Serialize<CreditInfo>(item.CreditInfo);
                }
                if (item.ContactAttempts != null)
                {
                    contactAttemptXml = XmlSerializationHelper.Serialize<List<ContactAttempt>>(item.ContactAttempts);
                }
                if (item.Recommendation != null)
                {
                    recommendationXml = XmlSerializationHelper.Serialize<RecommendationFactInfo>(item.Recommendation);
                }

                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update application set last_name=@last_name, first_name=@first_name" +
                        ", company=@company, phone=@phone, reg_agent=@reg_agent, state_active=@state_active, date_active=@date_active" +
                        ", middle_name=@middle_name, app_ssn=@app_ssn, birth_date=@birth_date, house_number=@house_number " +
                        ", street_address=@street_address, city=@city, state=@state, postal_code=@postal_code, client_id=@client_id " +
                        ", report_type_id=@report_type_id, report_community=@report_community, report_management=@report_management" +
                        ", unit_number=@unit_number, rent_amount=@rent_amount, movein_date=@movein_date, report_special_field=@report_special_field " +
                        ", page_received=@page_received, location_id=@location_id, location_name=@location_name, received_date=@received_date" +
                        ", completed_date=@completed_date, screener_id=@screener_id, screener_name=@screener_name, position_applied=@position_applied " +
                        ", company_applied=@company_applied, credit_info=@credit_info, credit_refs=@credit_refs" +
                        ", bank_comm=@bank_comm, opened_comm=@opened_comm, balance_comm=@balance_comm, acct_comm=@acct_comm,nsfod_comm=@nsfod_comm,sw_comm=@sw_comm" +
                        ", emp_ver=@emp_ver, emp_refs=@emp_refs, rental_refs=@rental_refs, charges=@charges, evictions=@evictions" +
                        ", staff_comments=@staff_comments, final_comments=@final_comments, recommendation=@recommendation" +
                        ", priority=@priority, contact_attempt=@contact_attempt, invoice_division=@invoice_division, credit_pulled=@credit_pulled" +
                        ", updated_at=@updated_at, pdx_ind=@pdx_ind" +
                        " where application_id=@application_id";

                    var args = new DynamicParameters();
                    args.Add("application_id", item.ApplicationId.Id);
                    args.Add("last_name", item.LastName);
                    args.Add("first_name", item.FirstName);
                    args.Add("middle_name", item.MiddleName);
                    args.Add("app_ssn", item.AppSSN);
                    args.Add("company", item.Company);
                    args.Add("phone", item.Phone);
                    args.Add("reg_agent", item.RegAgent);
                    args.Add("state_active", item.StateActive);
                    args.Add("date_active", item.DateActive);
                    args.Add("birth_date", item.BirthDate);
                    args.Add("house_number", item.HouseNumber);
                    args.Add("street_address", item.StreetAddress);
                    args.Add("city", item.City);
                    args.Add("state", item.State);
                    args.Add("postal_code", item.PostalCode);
                    args.Add("client_id", (item.ClientApplied == null) ? null : item.ClientApplied.Id);
                    args.Add("report_type_id", (item.ReportTypeId == null) ? null : item.ReportTypeId.Id);
                    args.Add("report_community", item.ReportCommunity);
                    args.Add("report_management", item.ReportManagement);
                    args.Add("unit_number", item.UnitNumber);
                    args.Add("rent_amount", item.RentAmount);
                    args.Add("movein_date", item.MoveInDate);
                    args.Add("report_special_field", item.ReportSpecialField);
                    args.Add("page_received", item.PagesReceived);
                    args.Add("location_id", item.Location.LocationId);
                    args.Add("location_name", item.Location.LocationName);
                    args.Add("received_date", item.ReceivedDate);
                    args.Add("completed_date", item.CompletedDate);
                    args.Add("screener_id", item.Screener.ScreenerId);
                    args.Add("screener_name", item.Screener.ScreenerName);
                    args.Add("position_applied", item.PositionApplied);
                    args.Add("company_applied", item.CompanyApplied);
                    args.Add("credit_info", creditInfoXml);
                    args.Add("credit_refs", creditRefsXml);
                    args.Add("bank_comm", item.BankComm);
                    args.Add("opened_comm", item.OpenedComm);
                    args.Add("balance_comm", item.BalanceComm);
                    args.Add("acct_comm", item.AcctComm);
                    args.Add("nsfod_comm", item.NSFODComm);
                    args.Add("sw_comm", item.SWComm);
                    args.Add("emp_ver", empVerXml);
                    args.Add("emp_refs", empRefsXml);
                    args.Add("rental_refs", rentalRefsXml);
                    args.Add("charges", chargesXml);
                    args.Add("evictions", evictionsXml);
                    args.Add("staff_comments", item.StaffComments);
                    args.Add("final_comments", item.FinalComments);
                    args.Add("recommendation", recommendationXml);
                    args.Add("priority", item.Priority.Value);
                    args.Add("contact_attempt", contactAttemptXml);
                    args.Add("invoice_division", item.InvoiceDivision);
                    args.Add("credit_pulled", item.CreditPulled);
                    args.Add("updated_at", DateTime.UtcNow);
                    args.Add("pdx_ind", item.PdxIndicator ? "1" : "0");

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override App Find(string id)
        {
            App app = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, client_id, client_applied_name " +
                        ", report_type_id, report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, created_at, updated_at" +
                        " from application where application_id=@application_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { application_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.application_id))
                    {
                        AppId appId = new AppId(id);
                        app = new App(appId);
                        app.LastName = item.last_name;
                        app.FirstName = item.first_name;
                        app.MiddleName = item.middle_name;
                        app.AppSSN = item.app_ssn;
                        app.Company = item.company;
                        app.Phone = item.phone;
                        app.RegAgent = item.reg_agent;
                        app.StateActive = item.state_active;
                        app.DateActive = item.date_active;
                        app.BankComm = item.bank_comm;
                        app.OpenedComm = item.opened_comm;
                        app.BalanceComm = item.balance_comm;
                        app.AcctComm = item.acct_comm;
                        app.NSFODComm = item.nsfod_comm;
                        app.SWComm = item.sw_comm;
                        app.BirthDate = item.birth_date;
                        app.HouseNumber = item.house_number;
                        app.StreetAddress = item.street_address;
                        app.City = item.city;
                        app.State = item.state;
                        app.PostalCode = item.postal_code;
                        app.ClientApplied = (item.client_id == null) ? null : new ClientId(item.client_id);
                        app.ClientName = (item.client_applied_name == null) ? null : item.client_applied_name;
                        app.ReportTypeId = (item.report_type_id == null) ? null : new ReportTypeId(item.report_type_id);
                        app.ReportCommunity = item.report_community;
                        app.ReportManagement = item.report_management;
                        app.UnitNumber = item.unit_number;
                        app.RentAmount = item.rent_amount;
                        app.MoveInDate = item.movein_date;
                        app.ReportSpecialField = item.report_special_field;
                        app.PagesReceived = item.page_received;
                        if (!string.IsNullOrEmpty(item.location_id) && !string.IsNullOrEmpty(item.location_name))
                        {
                            app.Location = new Location(item.location_id, item.location_name);
                        }
                        app.ReceivedDate = item.received_date;
                        app.CompletedDate = item.completed_date;
                        app.Screener = new Screener(item.screener_id, item.screener_name);
                        app.PositionApplied = item.position_applied;
                        app.CompanyApplied = item.company_applied;
                        app.StaffComments = item.staff_comments;
                        app.FinalComments = item.final_comments;
                        if (!string.IsNullOrEmpty(item.credit_info))
                        {
                            app.CreditInfo = XmlSerializationHelper.Deserialize<CreditInfo>(item.credit_info);
                        }
                        if (!string.IsNullOrEmpty(item.credit_refs))
                        {
                            app.CreditRefs = XmlSerializationHelper.Deserialize<List<CreditRef>>(item.credit_refs);
                        }
                        if (!string.IsNullOrEmpty(item.emp_ver))
                        {
                            app.EmpVer = XmlSerializationHelper.Deserialize<EmpVer>(item.emp_ver);
                        }
                        if (!string.IsNullOrEmpty(item.emp_refs))
                        {
                            app.EmpRefs = XmlSerializationHelper.Deserialize<List<EmpRef>>(item.emp_refs);
                        }
                        if (!string.IsNullOrEmpty(item.rental_refs))
                        {
                            app.RentalRefs = XmlSerializationHelper.Deserialize<List<RentalRef>>(item.rental_refs);
                        }
                        if (!string.IsNullOrEmpty(item.charges))
                        {
                            app.Charges = XmlSerializationHelper.Deserialize<List<ChargeRef>>(item.charges);
                        }
                        if (!string.IsNullOrEmpty(item.evictions))
                        {
                            app.Evictions = XmlSerializationHelper.Deserialize<List<EvictionRef>>(item.evictions);
                        }
                        if (!string.IsNullOrEmpty(item.contact_attempt))
                        {
                            app.ContactAttempts = XmlSerializationHelper.Deserialize<List<ContactAttempt>>(item.contact_attempt);
                        }
                        if (!string.IsNullOrEmpty(item.recommendation))
                        {
                            app.Recommendation = XmlSerializationHelper.Deserialize<RecommendationFactInfo>(item.recommendation);
                        }
                        app.Priority = PriorityApp.CreateInstance((int)item.priority);
                        app.InvoiceDivision = item.invoice_division;
                        app.CreditPulled = item.credit_pulled;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return app;
        }

        public List<App> FindAll()
        {
            List<App> lstApp = new List<App>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, client_id, client_applied_name " +
                        ", report_type_id, report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, created_at, updated_at" +
                        " from application ";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var item in result)
                    {
                        if (item != null && !string.IsNullOrEmpty(item.application_id))
                        {
                            AppId appId = new AppId(item.application_id);
                            App app = new App(appId);
                            app.LastName = item.last_name;
                            app.FirstName = item.first_name;
                            app.MiddleName = item.middle_name;
                            app.AppSSN = item.app_ssn;
                            app.Company = item.company;
                            app.Phone = item.phone;
                            app.RegAgent = item.reg_agent;
                            app.StateActive = item.state_active;
                            app.DateActive = item.date_active;
                            app.BankComm = item.bank_comm;
                            app.OpenedComm = item.opened_comm;
                            app.BalanceComm = item.balance_comm;
                            app.AcctComm = item.acct_comm;
                            app.NSFODComm = item.nsfod_comm;
                            app.SWComm = item.sw_comm;
                            app.BirthDate = item.birth_date;
                            app.HouseNumber = item.house_number;
                            app.StreetAddress = item.street_address;
                            app.City = item.city;
                            app.State = item.state;
                            app.PostalCode = item.postal_code;
                            app.ClientApplied = (item.client_id == null) ? null : new ClientId(item.client_id);
                            app.ClientName = (item.client_applied_name == null) ? null : item.client_applied_name;
                            app.ReportTypeId = (item.report_type_id == null) ? null : new ReportTypeId(item.report_type_id);
                            app.ReportCommunity = item.report_community;
                            app.ReportManagement = item.report_management;
                            app.UnitNumber = item.unit_number;
                            app.RentAmount = item.rent_amount;
                            app.MoveInDate = item.movein_date;
                            app.ReportSpecialField = item.report_special_field;
                            app.PagesReceived = item.page_received;
                            if (!string.IsNullOrEmpty(item.location_id) && !string.IsNullOrEmpty(item.location_name))
                            {
                                app.Location = new Location(item.location_id, item.location_name);
                            }
                            app.ReceivedDate = item.received_date;
                            app.CompletedDate = item.completed_date;
                            app.Screener = new Screener(item.screener_id, item.screener_name);
                            app.PositionApplied = item.position_applied;
                            app.CompanyApplied = item.company_applied;
                            if (!string.IsNullOrEmpty(item.credit_info))
                            {
                                app.CreditInfo = XmlSerializationHelper.Deserialize<CreditInfo>(item.credit_info);
                            }
                            if (!string.IsNullOrEmpty(item.credit_refs))
                            {
                                app.CreditRefs = XmlSerializationHelper.Deserialize<List<CreditRef>>(item.credit_refs);
                            }
                            if (!string.IsNullOrEmpty(item.emp_ver))
                            {
                                app.EmpVer = XmlSerializationHelper.Deserialize<EmpVer>(item.emp_ver);
                            }
                            if (!string.IsNullOrEmpty(item.emp_refs))
                            {
                                app.EmpRefs = XmlSerializationHelper.Deserialize<List<EmpRef>>(item.emp_refs);
                            }
                            if (!string.IsNullOrEmpty(item.rental_refs))
                            {
                                app.RentalRefs = XmlSerializationHelper.Deserialize<List<RentalRef>>(item.rental_refs);
                            }
                            if (!string.IsNullOrEmpty(item.charges))
                            {
                                app.Charges = XmlSerializationHelper.Deserialize<List<ChargeRef>>(item.charges);
                            }
                            if (!string.IsNullOrEmpty(item.evictions))
                            {
                                app.Evictions = XmlSerializationHelper.Deserialize<List<EvictionRef>>(item.evictions);
                            }
                            if (!string.IsNullOrEmpty(item.contact_attempt))
                            {
                                app.ContactAttempts = XmlSerializationHelper.Deserialize<List<ContactAttempt>>(item.contact_attempt);
                            }
                            if (!string.IsNullOrEmpty(item.recommendation))
                            {
                                app.Recommendation = XmlSerializationHelper.Deserialize<RecommendationFactInfo>(item.recommendation);
                            }
                            app.Priority = PriorityApp.CreateInstance((int)item.priority);
                            app.InvoiceDivision = item.invoice_division;
                            app.CreditPulled = item.credit_pulled;
                            app.StaffComments = item.staff_comments;
                            app.FinalComments = item.final_comments;

                            lstApp.Add(app);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return lstApp;
        }
    }
}
