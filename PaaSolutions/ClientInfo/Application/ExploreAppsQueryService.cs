using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Query;
using Common.Infrastructure.Helper;
using Core.Infrastructure.ClientInfo;
using Core.Infrastructure.ExploreApps;
using Core.Domain.Model.ExploreApps;
using Core.Domain.Model.ClientInfo;
using Core.Application.Data.ExploreApps;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Core.Application.Command.ExploreApps;


namespace Core.Application
{
    public class ExploreAppsQueryService : QueryService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        readonly AppRepository appRepository;
        readonly ClientRepository clientRepository;

        private string operatorAND = " AND ";
        private string operatorOR = " OR ";

        public ExploreAppsQueryService()
        {
            this.appRepository = new AppRepository();
            this.clientRepository = new ClientRepository();
        }

        public AppData GetApp(string id)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, a.phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, a.client_id, a.client_applied_name " +
                        ", client.client_name as client_name, a.report_type_id, report_type.type_name as report_type_name" +
                        ", report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, a.created_at, a.updated_at, a.pdx_ind" +
                        " from application as a left join client on a.client_id = client.client_id" +
                        " left join report_type on a.report_type_id = report_type.report_type_id" +
                        " where application_id=@application_id ";
                    
                    dynamic item = cn.Query<dynamic>(findStatement, new { application_id = id }).FirstOrDefault();
                    return DapperObjectToApp(item);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private AppData DapperObjectToApp(dynamic item)
        {
            AppData app = null;
            if (item != null && !string.IsNullOrEmpty(item.application_id))
            {
                app = new AppData();
                app.ApplicationId = item.application_id;
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
                app.ClientApplied = item.client_id;
                // Don't try to fix the swapping between client_name and client_applied_name
                // Since it's a workaround to make search working
                app.ClientAppliedName = item.client_name;
                app.ClientName = item.client_applied_name;
                app.ReportTypeId = item.report_type_id;
                app.ReportTypeName = item.report_type_name;
                app.ReportCommunity = item.report_community;
                app.ReportManagement = item.report_management;
                app.UnitNumber = item.unit_number;
                app.RentAmount = item.rent_amount;
                app.MoveInDate = item.movein_date;
                app.ReportSpecialField = item.report_special_field;
                app.PagesReceived = item.page_received;
                app.LocationId = item.location_id;
                app.LocationName = item.location_name;

                app.ReceivedDate = item.received_date;
                app.CompletedDate = item.completed_date;
                app.ScreenerId = item.screener_id;
                app.ScreenerName = item.screener_name;
                app.PositionApplied = item.position_applied;
                app.CompanyApplied = item.company_applied;
                app.StaffComments = item.staff_comments;
                app.FinalComments = item.final_comments;

                var isPdx = 0;
                app.PdxIndicator = int.TryParse(item.pdx_ind, out isPdx) && isPdx == 1;

                if (!string.IsNullOrEmpty(item.credit_info))
                {
                    CreditInfo creditInfo = XmlSerializationHelper.Deserialize<CreditInfo>(item.credit_info);
                    app.CreditInfo = AutoMapper.Mapper.Map<CreditInfo, CreditInfoData>(creditInfo);
                }
                if (!string.IsNullOrEmpty(item.credit_refs))
                {
                    List<CreditRef> creditRefs = XmlSerializationHelper.Deserialize<List<CreditRef>>(item.credit_refs);
                    app.CreditRefs = AutoMapper.Mapper.Map<List<CreditRef>, List<CreditRefData>>(creditRefs);
                }
                if (!string.IsNullOrEmpty(item.emp_ver))
                {
                    EmpVer empVer = XmlSerializationHelper.Deserialize<EmpVer>(item.emp_ver);
                    app.EmpVer = AutoMapper.Mapper.Map<EmpVer, EmpVerData>(empVer);
                }
                if (!string.IsNullOrEmpty(item.emp_refs))
                {
                    List<EmpRef> empRefs = XmlSerializationHelper.Deserialize<List<EmpRef>>(item.emp_refs);
                    app.EmpRefs = AutoMapper.Mapper.Map<List<EmpRef>, List<EmpRefData>>(empRefs);
                }
                if (!string.IsNullOrEmpty(item.rental_refs))
                {
                    List<RentalRef> rentalRefs = XmlSerializationHelper.Deserialize<List<RentalRef>>(item.rental_refs);
                    app.RentalRefs = AutoMapper.Mapper.Map<List<RentalRef>, List<RentalRefData>>(rentalRefs);
                }
                if (!string.IsNullOrEmpty(item.charges))
                {
                    List<ChargeRef> charges = XmlSerializationHelper.Deserialize<List<ChargeRef>>(item.charges);
                    app.Charges = AutoMapper.Mapper.Map<List<ChargeRef>, List<ChargeRefData>>(charges);
                }
                if (!string.IsNullOrEmpty(item.evictions))
                {
                    List<EvictionRef> evictions = XmlSerializationHelper.Deserialize<List<EvictionRef>>(item.evictions);
                    app.Evictions = AutoMapper.Mapper.Map<List<EvictionRef>, List<EvictionRefData>>(evictions);
                }
                if (!string.IsNullOrEmpty(item.contact_attempt))
                {
                    List<ContactAttempt> contactAttempts = XmlSerializationHelper.Deserialize<List<ContactAttempt>>(item.contact_attempt);
                    app.ContactAttempts = AutoMapper.Mapper.Map<List<ContactAttempt>, List<ContactAttemptData>>(contactAttempts);
                }
                if (!string.IsNullOrEmpty(item.recommendation))
                {
                    RecommendationFactInfo info = XmlSerializationHelper.Deserialize<RecommendationFactInfo>(item.recommendation);
                    app.Recommendation = AutoMapper.Mapper.Map<RecommendationFactInfo, RecommendationFactInfoData>(info);

                }
                PriorityApp priority = PriorityApp.CreateInstance((int)item.priority);
                app.Priority = AutoMapper.Mapper.Map<PriorityApp, PriorityAppData>(priority);
                app.InvoiceDivision = item.invoice_division;
                app.CreditPulled = item.credit_pulled;
                app.CreatedAt = item.created_at;
                app.UpdatedAt = item.updated_at;
            }

            return app;
        }

        public List<AppData> GetAppByReceivedDate(DateTime receivedDate)
        {
            List<AppData> lstApp = new List<AppData>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, a.phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, a.client_id, a.client_applied_name " +
                        ", client.client_name as client_name, a.report_type_id, report_type.type_name as report_type_name" +
                        ", report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, a.created_at, a.updated_at, a.pdx_ind" +
                        " from application as a left join client on a.client_id = client.client_id" +
                        " left join report_type on a.report_type_id = report_type.report_type_id" +
                        " where datediff(yyyy-MM-dd, received_date,@received_date) = 0 ";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, new { received_date = receivedDate });
                    foreach (var item in result)
                    {
                        AppData app = DapperObjectToApp(item);
                        lstApp.Add(app);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return lstApp;
        }

        public List<AppData> GetAppByLocation(string locationId)
        {
            List<AppData> lstApp = new List<AppData>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, a.phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, a.client_id, a.client_applied_name " +
                        ", client.client_name as client_name, a.report_type_id, report_type.type_name as report_type_name" +
                        ", report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, a.created_at, a.updated_at, a.pdx_ind" +
                        " from application as a left join client on a.client_id = client.client_id" +
                        " left join report_type on a.report_type_id = report_type.report_type_id" +
                        " where location_id = @location_id ";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, new { location_id = locationId });
                    foreach (var item in result)
                    {
                        AppData app = DapperObjectToApp(item);
                        lstApp.Add(app);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return lstApp;
        }

        public int CountApp(SearchAppCommand command)
        {
            int count = 0;
            List<AppData> apps = SearchApp(command.ClientIds, command.ReportIds,
                command.LocationIds, command.Status,
                command.ReceivedDateFrom, command.ReceivedDateTo,
                command.CompletedDateFrom, command.CompletedDateTo,
                command.ScreenerId, command.Priorities, command.IsFullAppOnly,
                command.KeywordOption1, command.KeywordOption2,
                command.JoinBetweenKeywords, command.CustomCondition, true, out count);

            return count;
        }


        public List<AppData> GetAppBySSN(List<string> ssnNumbers)
        {
            StringBuilder query = new StringBuilder();
            DynamicParameters parameters = new DynamicParameters();
            string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, a.phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, a.client_id, a.client_applied_name " +
                        ", client.client_name as client_name, a.report_type_id, report_type.type_name as report_type_name" +
                        ", report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, a.created_at, a.updated_at" +
                        " from application as a left join client on a.client_id = client.client_id" +
                        " left join report_type on a.report_type_id = report_type.report_type_id" +
                        " where app_ssn in @app_ssn";

            parameters.Add("app_ssn", ssnNumbers);

            List<AppData> lstApp = new List<AppData>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    if (!string.IsNullOrWhiteSpace(findStatement))
                    {
                        IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);
                        foreach (var item in result)
                        {
                            AppData app = DapperObjectToApp(item);
                            lstApp.Add(app);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw ex;
            }
            return lstApp;
        }

        public List<AppData> SearchApp(SearchAppCommand command)
        {
            int count = 0;
            return SearchApp(command.ClientIds, command.ReportIds,
                command.LocationIds, command.Status,
                command.ReceivedDateFrom, command.ReceivedDateTo,
                command.CompletedDateFrom, command.CompletedDateTo,
                command.ScreenerId, command.Priorities, command.IsFullAppOnly,
                command.KeywordOption1, command.KeywordOption2,
                command.JoinBetweenKeywords, command.CustomCondition, false, out count);
        }

        private List<AppData> SearchApp(List<string> clientIds, List<string> reportIds,
            List<string> locationIds, SearchAppCommand.AppStatus status,
            DateTime? receivedDateFrom, DateTime? receivedDateTo,
            DateTime? completedDateFrom, DateTime? completedDateTo,
            string screenerId, List<int> priorities, bool isFullAppOnly,
            SearchKeywordOptionData keywordOption1, SearchKeywordOptionData keywordOption2,
            string joinBetweenKeywords, string customCondition, bool isOnlyCount, out int count)
        {

            string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, a.phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, a.client_id, a.client_applied_name " +
                        ", client.client_name as client_name, a.report_type_id, report_type.type_name as report_type_name" +
                        ", report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, a.created_at, a.updated_at" +
                        " from application as a left join client on a.client_id = client.client_id" +
                        " left join report_type on a.report_type_id = report_type.report_type_id";

            count = 0;
            if (isOnlyCount)
            {
                findStatement = @"select count(*) from application as a left join client on " +
                    " a.client_id = client.client_id left join report_type on a.report_type_id = report_type.report_type_id ";
            }

            var parameters = new DynamicParameters();
            var insertParameters = new DynamicParameters();

            List<string> whereStatements = new List<string>();
            string keywordConditions = "";
            string insertStatements = "";
            bool isAllReport = (reportIds.Count == 0) ? true : false;
            bool isAllClient = (clientIds.Count == 0) ? true : false;

            if (!isAllReport)
            {
                whereStatements.Add(" (a.report_type_id in @report_id_list) ");
                parameters.Add("report_id_list", reportIds);
            }

            if (isFullAppOnly)
            {
                whereStatements.Add(" (a.report_type_id in (select report_type_id from report_type where absolute_type_name in ('Employment', 'Residential', 'Commercial'))) ");
            }

            if (!isAllClient)
            {
                insertStatements += "IF OBJECT_ID('tempdb..##t_client') IS NOT NULL begin  drop table ##t_client end \n";
                insertStatements += " create table ##t_client (id varchar(36) not null) \n";
                whereStatements.Add(" (a.client_id in (select id from tempdb..##t_client)) ");
            }

            if (status != SearchAppCommand.AppStatus.All)
            {
                if (status == SearchAppCommand.AppStatus.Archive)
                {
                    whereStatements.Add(string.Format("(a.location_id = @archive_location_id ) "));
                    parameters.Add("archive_location_id", Location.Archive.LocationId);
                }
                else if (status == SearchAppCommand.AppStatus.InProcess)
                {
                    whereStatements.Add(string.Format("(a.location_id != @archive_location_id )"));
                    parameters.Add("archive_location_id", Location.Archive.LocationId);
                }
                else if (status == SearchAppCommand.AppStatus.SpecificLocations)
                {
                    whereStatements.Add(string.Format("(a.location_id in @location_id_list )"));
                    parameters.Add("location_id_list", locationIds);
                }
            }

            if (receivedDateFrom.HasValue)
            {
                whereStatements.Add(" (a.received_date between @received_from and @received_to) ");
                parameters.Add("received_from", receivedDateFrom.GetValueOrDefault(DateTime.UtcNow));
                if (receivedDateTo.HasValue)
                {
                    parameters.Add("received_to", receivedDateTo.GetValueOrDefault(DateTime.UtcNow));
                }
                else
                {
                    parameters.Add("received_to", DateTime.UtcNow);
                }
            }

            if (completedDateFrom.HasValue)
            {
                whereStatements.Add(" (a.completed_date between @completed_from and @completed_to) ");
                parameters.Add("completed_from", completedDateFrom.GetValueOrDefault(DateTime.UtcNow));
                if (completedDateTo.HasValue)
                {
                    parameters.Add("completed_to", completedDateTo.GetValueOrDefault(DateTime.UtcNow));
                }
                else
                {
                    parameters.Add("completed_to", DateTime.UtcNow);
                }
            }

            if (!string.IsNullOrEmpty(screenerId))
            {
                whereStatements.Add(" (a.screener_id = @screener_id) ");
                parameters.Add("screener_id", screenerId);
            }

            if (priorities.Count > 0)
            {
                whereStatements.Add(string.Format("( a.priority in @priority_list )"));
                parameters.Add("priority_list", priorities);
            }

            if (keywordOption1 != null)
            {
                int index1 = 1;
                string query1 = BuildKeywordQuery(keywordOption1, parameters, index1);
            }

            if (keywordOption2 != null)
            {
                int index2 = 2;
                string query2 = BuildKeywordQuery(keywordOption1, parameters, index2);
            }

            if (keywordOption1 != null && keywordOption2 != null)
            {
                keywordConditions = string.Format(" (({0}) {1} ({2})) ", BuildKeywordQuery(keywordOption1, parameters, 1), joinBetweenKeywords, BuildKeywordQuery(keywordOption2, parameters, 2));
                whereStatements.Add(keywordConditions);
            }
            else if (keywordOption1 != null)
            {
                keywordConditions = string.Format(" ({0}) ", BuildKeywordQuery(keywordOption1, parameters, 1));
                whereStatements.Add(keywordConditions);
            }
            else if (keywordOption2 != null)
            {
                keywordConditions = string.Format(" ({0}) ", BuildKeywordQuery(keywordOption2, parameters, 1));
                whereStatements.Add(keywordConditions);
            }

            if (!string.IsNullOrEmpty(customCondition))
            {
                whereStatements.Add(customCondition);
            }

            if (whereStatements.Count > 0)
            {
                findStatement += " where " + string.Join(operatorAND, whereStatements);
            }

            List<AppData> lstApp = new List<AppData>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    if (!string.IsNullOrWhiteSpace(insertStatements))
                    {
                        cn.Execute(insertStatements);
                        var ids = clientIds.Select(id => new { client_id = id });
                        foreach (var item in ids)
                        {
                            cn.Execute(" insert into ##t_client (id) values (@client_id) ", item);
                        }
                    }

                    if (!isOnlyCount)
                    {
                        // set connectionTimeout each query
                        //IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters, null, true, 60, null);
                        IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                        foreach (var item in result)
                        {
                            AppData app = DapperObjectToApp(item);
                            lstApp.Add(app);
                        }
                        count = lstApp.Count;
                    }
                    else
                    {
                        count = cn.ExecuteScalar<int>(findStatement, parameters);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return lstApp;
        }

        public string BuildKeywordQuery(SearchKeywordOptionData keywordOption, DynamicParameters parameters, int index)
        {
            // assume keyword option is not null
            StringBuilder query = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(keywordOption.Keyword))
            {
                string columnName = SimpleSearchAppData.GetColumnNameByFieldName(keywordOption.SearchIn);
                if (columnName.Equals("all_fields"))
                {
                    query.Append("(" + CustomSearchApp_GetSqlConditionsInAllFields(keywordOption.Keyword, parameters, index) + ")");
                }
                else if (columnName.Equals("priority"))
                {
                    int priority;
                    if (int.TryParse(keywordOption.Keyword, out priority))
                    {
                        query.Append("(priority = '" + priority + "')");
                    }
                }
                else if (columnName.Equals("app_ssn/birth_date"))
                {
                    query.Append("(");
                    query.Append("(app_ssn like '%" + keywordOption.Keyword + "%')");

                    DateTime birthDate;
                    if (DateTime.TryParse(keywordOption.Keyword, out birthDate))
                    {
                        query.Append(" or ");
                        query.Append(string.Format("(birth_date = @birth_date{0})", index));
                        parameters.Add(string.Format("birth_date{0}", index), birthDate);
                    }

                    query.Append(")");
                }
                else
                {
                    string[] columnNameArr = columnName.Split('/');
                    if (columnNameArr.Length > 1)
                    {
                        query.Append("(");
                    }
                    for (int i = 0; i < columnNameArr.Length; i++)
                    {
                        query.Append("(" + columnNameArr[i] + " like '%" + keywordOption.Keyword + "%')");
                        if (i < columnNameArr.Length - 1)
                        {
                            query.Append(" or ");
                        }
                    }
                    if (columnNameArr.Length > 1)
                    {
                        query.Append(")");
                    }
                }
            }
            return query.ToString();
        }

        public string CustomSearchApp_GetSqlConditionsInAllFields(string keyword, DynamicParameters parameters, int index)
        {
            string sqlOperator = " OR ";
            bool statementAdded = false;
            StringBuilder sqlConditions = new StringBuilder();

            foreach (string columnName in SimpleSearchAppData.GetAllColumnNames())
            {
                if (columnName.Equals("all_fields"))
                {
                    continue;
                }
                else if (columnName.Equals("priority"))
                {
                    int priority;
                    if (int.TryParse(keyword, out priority))
                    {
                        sqlConditions.Append("(priority = '" + priority + "')");
                        sqlConditions.Append(sqlOperator);
                        statementAdded = true;
                    }
                }
                else if (columnName.Equals("app_ssn/birth_date"))
                {
                    sqlConditions.Append("(");
                    sqlConditions.Append("(app_ssn like '%" + keyword + "%')");

                    DateTime birthDate;
                    if (DateTime.TryParse(keyword, out birthDate))
                    {
                        sqlConditions.Append(sqlOperator);
                        sqlConditions.Append(string.Format("(birth_date = @birth_date{0})", index));
                        parameters.Add(string.Format("birth_date{0}", index), birthDate);
                    }

                    sqlConditions.Append(")");
                    sqlConditions.Append(sqlOperator);
                    statementAdded = true;
                }
                else
                {
                    string[] columnNameArr = columnName.Split('/');
                    if (columnNameArr.Length > 1)
                    {
                        sqlConditions.Append("(");
                    }
                    for (int i = 0; i < columnNameArr.Length; i++)
                    {
                        sqlConditions.Append("(" + columnNameArr[i] + " like '%" + keyword + "%')");
                        if (i < columnNameArr.Length - 1)
                        {
                            sqlConditions.Append(sqlOperator);
                        }
                    }
                    if (columnNameArr.Length > 1)
                    {
                        sqlConditions.Append(")");
                    }
                    sqlConditions.Append(sqlOperator);
                    statementAdded = true;
                }
            }
            if (statementAdded)
            {
                sqlConditions.Remove(sqlConditions.Length - sqlOperator.Length, sqlOperator.Length);
            }

            return sqlConditions.ToString();
        }

        public int SimpleSearchCountApp(SimpleSearchAppCommand command)
        {
            int count = 0;
            SimpleSearchApp(command, true, out count);
            return count;
        }

        public List<AppData> SimpleSearchApp(SimpleSearchAppCommand command)
        {
            int count = 0;
            return SimpleSearchApp(command, false, out count);
        }

        private List<AppData> SimpleSearchApp(SimpleSearchAppCommand command,
            bool isOnlyCount, out int count)
        {
            StringBuilder query = new StringBuilder();
            DynamicParameters parameters = new DynamicParameters();

            string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, a.phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, a.client_id, a.client_applied_name " +
                        ", client.client_name as client_name, a.report_type_id, report_type.type_name as report_type_name" +
                        ", report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, a.created_at, a.updated_at" +
                        " from application as a left join client on a.client_id = client.client_id" +
                        " left join report_type on a.report_type_id = report_type.report_type_id";

            if (isOnlyCount)
            {
                findStatement = @"select count(*) from application as a left join client on a.client_id = client.client_id" +
                        " left join report_type on a.report_type_id = report_type.report_type_id";
            }

            query.Append(findStatement);
            query.Append(" WHERE ");

            query.Append("(a.received_date BETWEEN @received_from AND @received_to)");
            parameters.Add("received_from", command.ReceivedFrom);
            parameters.Add("received_to", command.ReceivedTo);

            //if ((command.IncludeInProcess && !command.IncludeArchived) ||
            //    (!command.IncludeInProcess && command.IncludeArchived))
            //{
            //    query.Append(operatorAND);
            //    if (command.IncludeInProcess)
            //    {
            //        query.Append("(a.location_id != @archive_location_id)");
            //    }
            //    else
            //    {
            //        query.Append("(a.location_id = @archive_location_id)");
            //    }
            //    parameters.Add("archive_location_id", Location.Archive.LocationId);
            //}

            if (!string.IsNullOrWhiteSpace(command.Keyword))
            {
                string columnName = SimpleSearchAppData.GetColumnNameByFieldName(command.SearchIn);
                if (columnName.Equals("all_fields"))
                {
                    query.Append(operatorAND);
                    query.Append("(" + SimpleSearchApp_GetSqlConditionsInAllFields(command.Keyword, parameters) + ")");
                }
                else if (columnName.Equals("priority"))
                {
                    int priority;
                    if (int.TryParse(command.Keyword, out priority))
                    {
                        query.Append(operatorAND);
                        query.Append("(priority = " + priority + ")");
                    }
                }
                else if (columnName.Equals("app_ssn/birth_date"))
                {
                    query.Append(operatorAND);
                    query.Append("((app_ssn like '%" + command.Keyword + "%')");
                    query.Append(operatorOR);
                    query.Append("(convert(nvarchar, birth_date, 101) like '%" + command.Keyword + "%'))");
                }
                else
                {
                    query.Append(operatorAND);
                    string[] columnNameArr = columnName.Split('/');
                    if (columnNameArr.Length > 1)
                    {
                        query.Append("(");
                    }
                    for (int i = 0; i < columnNameArr.Length; i++)
                    {
                        query.Append("(" + columnNameArr[i] + " like '%" + command.Keyword + "%')");
                        if (i < columnNameArr.Length - 1)
                        {
                            query.Append(operatorOR);
                        }
                    }
                    if (columnNameArr.Length > 1)
                    {
                        query.Append(")");
                    }
                }
            }

            List<AppData> lstApp = new List<AppData>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    if (!isOnlyCount)
                    {
                        IEnumerable<dynamic> result = cn.Query<dynamic>(query.ToString(), parameters);

                        foreach (var item in result)
                        {
                            AppData app = DapperObjectToApp(item);
                            lstApp.Add(app);
                        }
                        count = lstApp.Count;
                    }
                    else
                    {
                        count = cn.ExecuteScalar<int>(query.ToString(), parameters);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return lstApp;
        }

        private string SimpleSearchApp_GetSqlConditionsInAllFields(string keyword, DynamicParameters parameters)
        {
            bool statementAdded = false;
            StringBuilder sqlConditions = new StringBuilder();

            foreach (string columnName in SimpleSearchAppData.GetAllColumnNames())
            {
                if (columnName.Equals("all_fields"))
                {
                    continue;
                }
                else if (columnName.Equals("priority"))
                {
                    PriorityApp priority = null;
                    try
                    {
                        priority = PriorityApp.FromDisplayName<PriorityApp>(keyword);
                    }
                    catch (Exception ex)
                    {
                        priority = null;
                    }

                    if (priority != null)
                    {
                        sqlConditions.Append("(priority = " + priority.Value + ")");
                        sqlConditions.Append(operatorOR);
                        statementAdded = true;
                    }
                    else
                    {
                        int priorityValue;
                        if (int.TryParse(keyword, out priorityValue))
                        {
                            sqlConditions.Append("(priority = " + priorityValue + ")");
                            sqlConditions.Append(operatorOR);
                            statementAdded = true;
                        }
                    }
                }
                else if (columnName.Equals("app_ssn/birth_date"))
                {
                    sqlConditions.Append("((app_ssn like '%" + keyword + "%')");
                    sqlConditions.Append(operatorOR);
                    sqlConditions.Append("(convert(nvarchar, birth_date, 101) like '%" + keyword + "%'))");
                    sqlConditions.Append(operatorOR);
                    statementAdded = true;
                }
                else
                {
                    string[] columnNameArr = columnName.Split('/');
                    if (columnNameArr.Length > 1)
                    {
                        sqlConditions.Append("(");
                    }
                    for (int i = 0; i < columnNameArr.Length; i++)
                    {
                        sqlConditions.Append("(" + columnNameArr[i] + " like '%" + keyword + "%')");
                        if (i < columnNameArr.Length - 1)
                        {
                            sqlConditions.Append(operatorOR);
                        }
                    }
                    if (columnNameArr.Length > 1)
                    {
                        sqlConditions.Append(")");
                    }
                    sqlConditions.Append(operatorOR);
                    statementAdded = true;
                }
            }
            if (statementAdded)
            {
                sqlConditions.Remove(sqlConditions.Length - operatorOR.Length, operatorOR.Length);
            }

            return sqlConditions.ToString();
        }

        public List<AppData> InvSearchApp(InvSearchAppCommand command)
        {
            StringBuilder query = new StringBuilder();
            StringBuilder conditions = new StringBuilder();
            var args = new DynamicParameters();

            string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, a.phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, a.client_id, a.client_applied_name " +
                        ", client.client_name as client_name, a.report_type_id, report_type.type_name as report_type_name" +
                        ", report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, a.created_at, a.updated_at" +
                        " from application as a left join client on a.client_id = client.client_id" +
                        " left join report_type on a.report_type_id = report_type.report_type_id";

            conditions.Append("(a.received_date BETWEEN @received_from AND @received_to)");
            args.Add("received_from", command.ReceivedFrom);
            args.Add("received_to", command.ReceivedTo);

            if (command.ClientNames != null && command.ClientNames.Count > 0)
            {
                if (command.ClientsOperator)
                {
                    conditions.Append(operatorAND);
                }
                else
                {
                    conditions.Append(operatorOR);
                }

                conditions.Append("(client_name in (select name from tempdb..##t_client))");
            }

            if (command.ReportTypeNames != null && command.ReportTypeNames.Count > 0)
            {
                if (command.ReportTypesOperator)
                {
                    conditions.Append(operatorAND);
                }
                else
                {
                    conditions.Append(operatorOR);
                }

                conditions.Append("(report_type.type_name in (select name from tempdb..##t_reporttype))");
            }

            if (!string.IsNullOrWhiteSpace(command.Keyword) && !string.IsNullOrWhiteSpace(command.SearchIn))
            {
                string columnName = InvSearchAppData.GetColumnNameByFieldName(command.SearchIn);
                if (!string.IsNullOrEmpty(columnName))
                {
                    string keyword = command.Keyword;
                    if (columnName.Equals("all_fields"))
                    {
                        conditions.Append(operatorAND);
                        conditions.Append("(" + InvSearchApp_GetSqlConditionsInAllFields(keyword, args) + ")");
                    }
                    else if (columnName.Equals("priority"))
                    {
                        int priority;
                        if (int.TryParse(keyword, out priority))
                        {
                            conditions.Append(operatorAND);
                            conditions.Append("(priority = " + priority + ")");
                        }
                    }
                    else if (columnName.Equals("app_ssn/birth_date"))
                    {
                        conditions.Append(operatorAND);
                        conditions.Append("((app_ssn like '%" + keyword + "%')");
                        conditions.Append(operatorOR);
                        conditions.Append("(convert(nvarchar, birth_date, 101) like '%" + keyword + "%'))");
                    }
                    else
                    {
                        conditions.Append(operatorAND);
                        string[] columnNameArr = columnName.Split('/');
                        if (columnNameArr.Length > 1)
                        {
                            conditions.Append("(");
                        }
                        for (int i = 0; i < columnNameArr.Length; i++)
                        {
                            conditions.Append("(" + columnNameArr[i] + " like '%" + keyword + "%')");
                            if (i < columnNameArr.Length - 1)
                            {
                                conditions.Append(operatorOR);
                            }
                        }
                        if (columnNameArr.Length > 1)
                        {
                            conditions.Append(")");
                        }
                    }
                }
            }

            query.Append(findStatement);
            query.Append(" WHERE ");
            query.Append(conditions.ToString());

            List<AppData> apps = new List<AppData>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    if (command.ClientNames != null && command.ClientNames.Count > 0)
                    {
                        cn.Execute("create table ##t_client (name nvarchar(255) not null)");

                        StringBuilder insertStatement = new StringBuilder();
                        int insertCount = (int)Math.Ceiling((double)command.ClientNames.Count / 1000);
                        for (int i = 0; i < insertCount; i++)
                        {
                            int fromIndex = i * 1000;
                            int toIndex = (fromIndex + 999) > (command.ClientNames.Count - 1) ? (command.ClientNames.Count - 1) : (fromIndex + 999);
                            insertStatement.Append("insert ##t_client (name) values");
                            for (int j = fromIndex; j <= toIndex; j++)
                            {
                                insertStatement.Append(" ('" + command.ClientNames[j] + "')");
                                if (j < toIndex)
                                {
                                    insertStatement.Append(",");
                                }
                            }
                        }
                        cn.Execute(insertStatement.ToString());
                    }

                    if (command.ReportTypeNames != null && command.ReportTypeNames.Count > 0)
                    {
                        cn.Execute("create table ##t_reporttype (name nvarchar(50) not null)");

                        StringBuilder insertStatement = new StringBuilder();
                        int insertCount = (int)Math.Ceiling((double)command.ReportTypeNames.Count / 1000);
                        for (int i = 0; i < insertCount; i++)
                        {
                            int fromIndex = i * 1000;
                            int toIndex = (fromIndex + 999) > (command.ReportTypeNames.Count - 1) ? (command.ReportTypeNames.Count - 1) : (fromIndex + 999);
                            insertStatement.Append("insert ##t_reporttype (name) values");
                            for (int j = fromIndex; j <= toIndex; j++)
                            {
                                insertStatement.Append(" ('" + command.ReportTypeNames[j] + "')");
                                if (j < toIndex)
                                {
                                    insertStatement.Append(",");
                                }
                            }
                        }
                        cn.Execute(insertStatement.ToString());
                    }

                    IEnumerable<dynamic> result = cn.Query<dynamic>(query.ToString(), args);
                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            AppData app = DapperObjectToApp(item);
                            apps.Add(app);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return apps;
        }

        private string InvSearchApp_GetSqlConditionsInAllFields(string keyword, DynamicParameters parameters)
        {
            StringBuilder conditions = new StringBuilder();
            bool atLeastOneCondition = false;

            foreach (string columnName in InvSearchAppData.GetAllColumnNames())
            {
                if (columnName.Equals("all_fields"))
                {
                    continue;
                }
                else if (columnName.Equals("priority"))
                {
                    PriorityApp priority = null;
                    try
                    {
                        priority = PriorityApp.FromDisplayName<PriorityApp>(keyword);
                    }
                    catch (Exception ex)
                    {
                        priority = null;
                    }

                    if (priority != null)
                    {
                        if (atLeastOneCondition)
                        {
                            conditions.Append(operatorOR);
                        }
                        conditions.Append("(priority = " + priority.Value + ")");
                        atLeastOneCondition = true;
                    }
                    else
                    {
                        int priorityValue;
                        if (int.TryParse(keyword, out priorityValue))
                        {
                            if (atLeastOneCondition)
                            {
                                conditions.Append(operatorOR);
                            }
                            conditions.Append("(priority = " + priorityValue + ")");
                            atLeastOneCondition = true;
                        }
                    }
                }
                else if (columnName.Equals("app_ssn/birth_date"))
                {
                    if (atLeastOneCondition)
                    {
                        conditions.Append(operatorOR);
                    }
                    conditions.Append("((app_ssn like '%" + keyword + "%')");
                    conditions.Append(operatorOR);
                    conditions.Append("(convert(nvarchar, birth_date, 101) like '%" + keyword + "%'))");
                    atLeastOneCondition = true;
                }
                else
                {
                    if (atLeastOneCondition)
                    {
                        conditions.Append(operatorOR);
                    }
                    string[] columnNameArr = columnName.Split('/');
                    if (columnNameArr.Length > 1)
                    {
                        conditions.Append("(");
                    }
                    for (int i = 0; i < columnNameArr.Length; i++)
                    {
                        conditions.Append("(" + columnNameArr[i] + " like '%" + keyword + "%')");
                        if (i < columnNameArr.Length - 1)
                        {
                            conditions.Append(operatorOR);
                        }
                    }
                    if (columnNameArr.Length > 1)
                    {
                        conditions.Append(")");
                    }
                    atLeastOneCondition = true;
                }
            }

            return conditions.ToString();
        }

        public List<AppData> InvGetAvailApp(InvGetAvailAppCommand command)
        {
            StringBuilder query = new StringBuilder();
            StringBuilder conditions = new StringBuilder();
            var args = new DynamicParameters();

            string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, a.phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, a.client_id , a.client_applied_name" +
                        ", client.client_name as client_name, a.report_type_id, report_type.type_name as report_type_name" +
                        ", report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, a.created_at, a.updated_at" +
                        " from application as a left join client on a.client_id = client.client_id" +
                        " left join report_type on a.report_type_id = report_type.report_type_id";

            conditions.Append("(a.received_date BETWEEN @received_from AND @received_to)");
            args.Add("received_from", command.ReceivedFrom);
            args.Add("received_to", command.ReceivedTo);

            if (!string.IsNullOrEmpty(command.ClientAppliedName))
            {
                conditions.Append(operatorAND);
                conditions.Append("(client_name = '" + command.ClientAppliedName + "')");
            }

            if (command.InvoiceDivision != null)
            {
                conditions.Append(operatorAND);
                conditions.Append("(invoice_division = '" + command.InvoiceDivision + "')");
            }

            conditions.Append(" order by ");
            if (command.OrderByName)
            {
                conditions.Append("last_name");
            }
            else
            {
                conditions.Append("received_date");
            }

            query.Append(findStatement);
            query.Append(" WHERE ");
            query.Append(conditions.ToString());

            List<AppData> apps = new List<AppData>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    IEnumerable<dynamic> result = cn.Query<dynamic>(query.ToString(), args);
                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            AppData app = DapperObjectToApp(item);
                            apps.Add(app);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return apps;
        }

        public int InvCountAppByReceivedDate(DateTime receivedFrom, DateTime receivedTo)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select COUNT(last_name) as app_count from application" +
                        " where received_date BETWEEN @received_from AND @received_to";

                    var args = new DynamicParameters();
                    args.Add("received_from", receivedFrom);
                    args.Add("received_to", receivedTo);

                    dynamic item = cn.Query<dynamic>(findStatement, args).FirstOrDefault();
                    if (item != null && item.app_count != null)
                    {
                        int appCount = item.app_count;
                        return appCount;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return -1; // error code
        }

        public List<AppData> GetAppByIds(List<string> ids)
        {
            List<AppData> apps = new List<AppData>();

            if (ids == null || ids.Count == 0)
            {
                return apps;
            }

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, a.phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, a.client_id, a.client_applied_name " +
                        ", client.client_name as client_name, a.report_type_id, report_type.type_name as report_type_name" +
                        ", report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, a.created_at, a.updated_at" +
                        " from application as a left join client on a.client_id = client.client_id" +
                        " left join report_type on a.report_type_id = report_type.report_type_id" +
                        " where application_id in (select id from tempdb..##t_application)";

                    cn.Execute("create table ##t_application (id varchar(36) not null)");

                    StringBuilder insertStatement = new StringBuilder();
                    int insertCount = (int)Math.Ceiling((double)ids.Count / 1000);
                    for (int i = 0; i < insertCount; i++)
                    {
                        int fromIndex = i * 1000;
                        int toIndex = (fromIndex + 999) > (ids.Count - 1) ? (ids.Count - 1) : (fromIndex + 999);
                        insertStatement.Append("insert ##t_application (id) values");
                        for (int j = fromIndex; j <= toIndex; j++)
                        {
                            insertStatement.Append(" ('" + ids[j] + "')");
                            if (j < toIndex)
                            {
                                insertStatement.Append(",");
                            }
                        }
                    }
                    cn.Execute(insertStatement.ToString());

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    foreach (var item in result)
                    {
                        AppData app = DapperObjectToApp(item);
                        apps.Add(app);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return apps;
        }

        public List<App> FindAllAppHasNullClientId()
        {
            List<App> lstApp = new List<App>();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select application_id, last_name, first_name, middle_name " +
                        ", company, phone, reg_agent, state_active, date_active " +
                        ", app_ssn, birth_date, house_number, street_address, city, state, postal_code, client_id " +
                        ", report_type_id, report_community, report_management, unit_number " +
                        ", rent_amount, movein_date, report_special_field, page_received " +
                        ", location_id, location_name, received_date, completed_date, screener_id, screener_name" +
                        ", bank_comm, opened_comm, balance_comm, acct_comm, nsfod_comm, sw_comm" +
                        ", position_applied, company_applied, credit_info, credit_refs, emp_ver, emp_refs" +
                        ", rental_refs, charges, evictions, staff_comments, final_comments, recommendation" +
                        ", priority, contact_attempt, invoice_division, credit_pulled, created_at, updated_at" +
                        " from application where client_id is null";

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
