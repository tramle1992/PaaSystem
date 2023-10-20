using Common.Infrastructure.Repository;
using Core.Domain.Model.ExploreApps;
using Dapper;
using Invoice.Application;
using Invoice.Application.Command;
using Invoice.Application.Data;
using Invoice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Infrastructure
{
    public class InvoiceRepository : Repository<Invoice.Domain.Model.Invoice, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private PaymentRepository paymentRepository = new PaymentRepository();
        private InvoiceItemRepository invoiceItemRepository = new InvoiceItemRepository();

        private string operatorAND = " AND ";
        private string operatorOR = " OR ";

        public InvoiceRepository()
            : base()
        {
        }

        public override void Add(Domain.Model.Invoice item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert invoice(invoice_id, client_name, sold_to_client_name, address" +
                        ", invoice_reference, customer_number, invoice_comments, invoice_number, invoice_date" +
                        ", note_to_client, po_number, invoice_division, status, amount, balance, action_status)" +
                        " values (@invoice_id, @client_name, @sold_to_client_name, @address" +
                        ", @invoice_reference, @customer_number, @invoice_comments, @invoice_number, @invoice_date" +
                        ", @note_to_client, @po_number, @invoice_division, @status, @amount, @balance, @action_status)";

                    var args = new DynamicParameters();
                    args.Add("invoice_id", item.InvoiceId.Id);
                    args.Add("client_name", item.ClientName);
                    args.Add("sold_to_client_name", item.SoldToClientName);
                    args.Add("address", item.Address);
                    args.Add("invoice_reference", item.InvoiceReference);
                    args.Add("customer_number", item.CustomerNumber);
                    args.Add("invoice_comments", item.InvoiceComments);
                    args.Add("invoice_number", item.InvoiceNumber);
                    args.Add("invoice_date", item.InvoiceDate);
                    args.Add("note_to_client", item.NoteToClient);
                    args.Add("po_number", item.PONumber);
                    args.Add("invoice_division", item.InvoiceDivision);
                    args.Add("status", byte.Parse(item.Status.Value.ToString()));
                    args.Add("amount", item.Amount);
                    args.Add("balance", item.Balance);
                    args.Add("action_status", byte.Parse(item.ActionStatus.Value.ToString()));

                    cn.Execute(insertStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Remove(Domain.Model.Invoice item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from invoice where invoice_id = @invoice_id";

                    cn.Execute(deleteStatement, new { invoice_id = item.InvoiceId.Id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
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

                    string deleteStatement = @"delete from invoice where invoice_id = @invoice_id";

                    cn.Execute(deleteStatement, new { invoice_id = id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void Remove(List<string> ids)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    int index = 0;
                    int step = 1000;
                    while (index < ids.Count)
                    {
                        List<string> idsToDelete = new List<string>();
                        int limit = (ids.Count - index) > step ? step : ids.Count - index;
                        for (int i = 0; i < limit; i++)
                        {
                            idsToDelete.Add(ids[index + i]);
                        }

                        index += step;
                        string deleteStatement = @"delete from invoice where invoice_id in @invoice_list";
                        cn.Execute(deleteStatement, new { invoice_list = idsToDelete });
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
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

                    string deleteStatement = @"delete from invoice";

                    cn.Execute(deleteStatement);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Update(Domain.Model.Invoice item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update invoice set client_name=@client_name" +
                        ", sold_to_client_name=@sold_to_client_name, address=@address, invoice_reference=@invoice_reference" +
                        ", customer_number=@customer_number, invoice_comments=@invoice_comments, invoice_number=@invoice_number" +
                        ", invoice_date=@invoice_date, note_to_client=@note_to_client, po_number=@po_number, invoice_division=@invoice_division" +
                        ", status=@status, amount=@amount, balance=@balance, action_status=@action_status" +
                        " where invoice_id=@invoice_id";

                    var args = new DynamicParameters();
                    args.Add("invoice_id", item.InvoiceId.Id);
                    args.Add("client_name", item.ClientName);
                    args.Add("sold_to_client_name", item.SoldToClientName);
                    args.Add("address", item.Address);
                    args.Add("invoice_reference", item.InvoiceReference);
                    args.Add("customer_number", item.CustomerNumber);
                    args.Add("invoice_comments", item.InvoiceComments);
                    args.Add("invoice_number", item.InvoiceNumber);
                    args.Add("invoice_date", item.InvoiceDate);
                    args.Add("note_to_client", item.NoteToClient);
                    args.Add("po_number", item.PONumber);
                    args.Add("invoice_division", item.InvoiceDivision);
                    args.Add("status", byte.Parse(item.Status.Value.ToString()));
                    args.Add("amount", item.Amount);
                    args.Add("balance", item.Balance);
                    args.Add("action_status", byte.Parse(item.ActionStatus.Value.ToString()));

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void UpdateActionStatus(string invoiceID, int actionStatus)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update invoice set action_status=@action_status" +
                        " where invoice_id=@invoice_id";

                    var args = new DynamicParameters();
                    args.Add("invoice_id", invoiceID);
                    args.Add("action_status", actionStatus);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override Domain.Model.Invoice Find(string id)
        {
            Domain.Model.Invoice invoice = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select invoice_id, client_name, sold_to_client_name, address" +
                        ", invoice_reference, customer_number, invoice_comments, invoice_number, invoice_date" +
                        ", note_to_client, po_number, invoice_division, status, amount, balance, action_status" +
                        " from invoice where invoice_id=@invoice_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { invoice_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.invoice_id))
                    {
                        Domain.Model.InvoiceId invoiceId = new Domain.Model.InvoiceId(item.invoice_id);
                        invoice = new Domain.Model.Invoice(invoiceId);
                        invoice.ClientName = item.client_name;
                        invoice.SoldToClientName = item.sold_to_client_name;
                        invoice.Address = item.address;
                        invoice.InvoiceReference = item.invoice_reference;
                        invoice.CustomerNumber = item.customer_number;
                        invoice.InvoiceComments = item.invoice_comments;
                        invoice.InvoiceNumber = item.invoice_number;
                        invoice.InvoiceDate = item.invoice_date;
                        invoice.NoteToClient = item.note_to_client;
                        invoice.PONumber = item.po_number;
                        invoice.InvoiceDivision = item.invoice_division;
                        invoice.Status = Status.CreateInstance(item.status);
                        invoice.Amount = item.amount;
                        invoice.Balance = item.balance;
                        invoice.ActionStatus = ActionStatus.CreateInstance(item.action_status);
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return invoice;
        }

        public List<Domain.Model.Invoice> FindAll()
        {
            List<Domain.Model.Invoice> invoices = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select invoice_id, client_name, sold_to_client_name, address" +
                        ", invoice_reference, customer_number, invoice_comments, invoice_number, invoice_date" +
                        ", note_to_client, po_number, invoice_division, status, amount, balance, action_status" +
                        " from invoice";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    if (result != null)
                    {
                        invoices = new List<Domain.Model.Invoice>();
                        foreach (var item in result)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.invoice_id))
                            {
                                Domain.Model.InvoiceId invoiceId = new Domain.Model.InvoiceId(item.invoice_id);
                                Domain.Model.Invoice invoice = new Domain.Model.Invoice(invoiceId);
                                invoice.ClientName = item.client_name;
                                invoice.SoldToClientName = item.sold_to_client_name;
                                invoice.Address = item.address;
                                invoice.InvoiceReference = item.invoice_reference;
                                invoice.CustomerNumber = item.customer_number;
                                invoice.InvoiceComments = item.invoice_comments;
                                invoice.InvoiceNumber = item.invoice_number;
                                invoice.InvoiceDate = item.invoice_date;
                                invoice.NoteToClient = item.note_to_client;
                                invoice.PONumber = item.po_number;
                                invoice.InvoiceDivision = item.invoice_division;
                                invoice.Status = Status.CreateInstance(item.status);
                                invoice.Amount = item.amount;
                                invoice.Balance = item.balance;
                                invoice.ActionStatus = ActionStatus.CreateInstance(item.action_status);
                                invoices.Add(invoice);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return invoices;
        }

        public List<Domain.Model.Invoice> FindByYearAndMonth(int year, int month, string timezone)
        {
            List<Domain.Model.Invoice> invoices = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select invoice_id, client_name, sold_to_client_name, address" +
                        ", invoice_reference, customer_number, invoice_comments, invoice_number, invoice_date" +
                        ", datepart(month, cast(Tzdb.UtcToLocal(invoice_date, @dest_tz) as datetime)) as month" +
                        ", datepart(year, cast(Tzdb.UtcToLocal(invoice_date, @dest_tz) as datetime)) as year" +
                        ", note_to_client, po_number, invoice_division, status, amount, balance, action_status" +
                        " from invoice where datepart(month, cast(Tzdb.UtcToLocal(invoice_date, @dest_tz) as datetime))=@month" +
                        " and datepart(year, cast(Tzdb.UtcToLocal(invoice_date, @dest_tz) as datetime))=@year" +
                        " and year(invoice_date) in @year_list and month(invoice_date) in @month_list ";

                    List<int> monthList = new List<int> { (month + 11) % 12, month, (month + 1) % 12 };
                    List<int> yearList = new List<int> { year - 1, year, year + 1 };

                    var args = new DynamicParameters();
                    args.Add("month", month);
                    args.Add("year", year);
                    args.Add("dest_tz", timezone);
                    args.Add("month_list", monthList);
                    args.Add("year_list", yearList);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, args);
                    if (result != null)
                    {
                        invoices = new List<Domain.Model.Invoice>();
                        foreach (var item in result)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.invoice_id))
                            {
                                Domain.Model.InvoiceId invoiceId = new Domain.Model.InvoiceId(item.invoice_id);
                                Domain.Model.Invoice invoice = new Domain.Model.Invoice(invoiceId);
                                invoice.ClientName = item.client_name;
                                invoice.SoldToClientName = item.sold_to_client_name;
                                invoice.Address = item.address;
                                invoice.InvoiceReference = item.invoice_reference;
                                invoice.CustomerNumber = item.customer_number;
                                invoice.InvoiceComments = item.invoice_comments;
                                invoice.InvoiceNumber = item.invoice_number;
                                invoice.InvoiceDate = item.invoice_date;
                                invoice.NoteToClient = item.note_to_client;
                                invoice.PONumber = item.po_number;
                                invoice.InvoiceDivision = item.invoice_division;
                                invoice.Status = Status.CreateInstance(item.status);
                                invoice.Amount = item.amount;
                                invoice.Balance = item.balance;
                                invoice.ActionStatus = ActionStatus.CreateInstance(item.action_status);
                                invoices.Add(invoice);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return invoices;
        }

        public List<Domain.Model.Invoice> FindByDate(DateTime date)
        {
            List<Domain.Model.Invoice> invoices = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select invoice_id, client_name, sold_to_client_name, address" +
                        ", invoice_reference, customer_number, invoice_comments, invoice_number, invoice_date" +
                        ", note_to_client, po_number, invoice_division, status, amount, balance, action_status" +
                        " from invoice where datediff(DAY, invoice_date, @date) = 0";

                    var args = new DynamicParameters();
                    args.Add("date", date.ToString("yyyy-MM-dd"));

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, args);
                    if (result != null)
                    {
                        invoices = new List<Domain.Model.Invoice>();
                        foreach (var item in result)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.invoice_id))
                            {
                                Domain.Model.InvoiceId invoiceId = new Domain.Model.InvoiceId(item.invoice_id);
                                Domain.Model.Invoice invoice = new Domain.Model.Invoice(invoiceId);
                                invoice.ClientName = item.client_name;
                                invoice.SoldToClientName = item.sold_to_client_name;
                                invoice.Address = item.address;
                                invoice.InvoiceReference = item.invoice_reference;
                                invoice.CustomerNumber = item.customer_number;
                                invoice.InvoiceComments = item.invoice_comments;
                                invoice.InvoiceNumber = item.invoice_number;
                                invoice.InvoiceDate = item.invoice_date;
                                invoice.NoteToClient = item.note_to_client;
                                invoice.PONumber = item.po_number;
                                invoice.InvoiceDivision = item.invoice_division;
                                invoice.Status = Status.CreateInstance(item.status);
                                invoice.Amount = item.amount;
                                invoice.Balance = item.balance;
                                invoice.ActionStatus = ActionStatus.CreateInstance(item.action_status);
                                invoices.Add(invoice);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return invoices;
        }

        public DateTime FindMaxInvoiceDate()
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select MAX(invoice_date) as max_invoice_date from invoice";

                    dynamic item = cn.Query<dynamic>(findStatement).FirstOrDefault();
                    if (item != null && item.max_invoice_date != null)
                    {
                        DateTime maxInvoiceDate = item.max_invoice_date;
                        return maxInvoiceDate;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return DateTime.UtcNow;
        }

        public int FindMaxInvoiceNumberByYearAndMonth(int year, int month, string timezone)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select MAX(invoice_number) as max_invoice_number" +
                        " from invoice where datepart(year, cast(Tzdb.UtcToLocal(invoice_date, @dest_tz) as datetime))=@year " +
                        " and datepart(month, cast(Tzdb.UtcToLocal(invoice_date, @dest_tz) as datetime))=@month" +
                        " and year(invoice_date) in @year_list and month(invoice_date) in @month_list ";

                    List<int> monthList = new List<int> { (month + 11) % 12, month, (month + 1) % 12 };
                    List<int> yearList = new List<int> { year - 1, year, year + 1 };

                    var args = new DynamicParameters();
                    args.Add("month", month);
                    args.Add("year", year);
                    args.Add("dest_tz", timezone);
                    args.Add("month_list", monthList);
                    args.Add("year_list", yearList);

                    dynamic item = cn.Query<dynamic>(findStatement, args).FirstOrDefault();
                    if (item != null && item.max_invoice_number != null)
                    {
                        int maxInvoiceNumber = item.max_invoice_number;
                        return maxInvoiceNumber;
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

        public int FindInvoiceCountByYearAndMonth(int year, int month, string timezone)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select COUNT(invoice_id) as invoice_count, " +
                        " from invoice where datepart(year, cast(Tzdb.UtcToLocal(invoice_date, @dest_tz) as datetime))=@year " +
                        " and datepart(month, cast(Tzdb.UtcToLocal(invoice_date, @dest_tz) as datetime))=@month" +
                        " and year(invoice_date) in @year_list and month(invoice_date) in @month_list ";

                    List<int> monthList = new List<int> { (month + 11) % 12, month, (month + 1) % 12 };
                    List<int> yearList = new List<int> { year - 1, year, year + 1 };

                    var args = new DynamicParameters();
                    args.Add("month", month);
                    args.Add("year", year);
                    args.Add("dest_tz", timezone);
                    args.Add("month_list", monthList);
                    args.Add("year_list", yearList);

                    dynamic item = cn.Query<dynamic>(findStatement, args).FirstOrDefault();
                    if (item != null && item.invoice_count != null)
                    {
                        int invoiceCount = item.invoice_count;
                        return invoiceCount;
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

        public BillingValidationStatsData FindBillingValidationStats(int year, int month, string timezone)
        {
            BillingValidationStatsData data = new BillingValidationStatsData();
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select COUNT(amount) as total_invs" +
                        ", SUM(amount) as total_volumn, MAX(amount) as largest_inv" +
                        ", AVG(amount) as avg_inv_amount, MIN(amount) as smallest_inv" +
                        " from invoice where datepart(year, cast(Tzdb.UtcToLocal(invoice_date, @dest_tz) as datetime))=@year " +
                        " and datepart(month, cast(Tzdb.UtcToLocal(invoice_date, @dest_tz) as datetime))=@month" +
                        " and year(invoice_date) in @year_list and month(invoice_date) in @month_list ";

                    List<int> monthList = new List<int> { (month + 11) % 12, month, (month + 1) % 12 };
                    List<int> yearList = new List<int> { year - 1, year, year + 1 };

                    var args = new DynamicParameters();
                    args.Add("month", month);
                    args.Add("year", year);
                    args.Add("dest_tz", timezone);
                    args.Add("month_list", monthList);
                    args.Add("year_list", yearList);

                    dynamic result = cn.Query<dynamic>(findStatement, args).FirstOrDefault();
                    if (result != null)
                    {
                        data.TotalInvs = result.total_invs;
                        data.TotalVolumn = result.total_volumn;
                        data.LargestInv = result.largest_inv;
                        data.AvgInvAmount = result.avg_inv_amount;
                        data.SmallestInv = result.smallest_inv;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return data;
        }

        public List<Domain.Model.Invoice> SearchInvoice(SearchInvoiceCommand command)
        {
            StringBuilder query = new StringBuilder();
            StringBuilder conditions = new StringBuilder();
            var args = new DynamicParameters();
            bool atLeastOneCondition = false;

            string findStatement = @"select invoice_id, client_name, sold_to_client_name, address" +
                        ", invoice_reference, customer_number, invoice_comments, invoice_number, invoice_date" +
                        ", note_to_client, po_number, invoice_division, status, amount, balance, action_status" +
                        " from invoice";

            query.Append(findStatement);

            if (command.CreatedFrom.HasValue && command.CreatedTo.HasValue)
            {
                conditions.Append("(invoice_date BETWEEN @created_from AND @created_to)");
                args.Add("created_from", command.CreatedFrom.Value);
                args.Add("created_to", command.CreatedTo.Value);
                atLeastOneCondition = true;
            }

            if (command.ClientNames != null && command.ClientNames.Count > 0)
            {
                if (atLeastOneCondition)
                {
                    if (command.ClientsOperator)
                    {
                        conditions.Append(operatorAND);
                    }
                    else
                    {
                        conditions.Append(operatorOR);
                    }
                }

                conditions.Append("(client_name in (select name from tempdb..##t_client))");
                atLeastOneCondition = true;
            }

            if (command.StatusValues != null && command.StatusValues.Count > 0)
            {
                if (atLeastOneCondition)
                {
                    if (command.StatusOperator)
                    {
                        conditions.Append(operatorAND);
                    }
                    else
                    {
                        conditions.Append(operatorOR);
                    }
                }

                conditions.Append("(status in (");
                for (int i = 0; i < command.StatusValues.Count; i++)
                {
                    conditions.Append(command.StatusValues[i]);
                    if (i < command.StatusValues.Count - 1)
                    {
                        conditions.Append(",");
                    }
                }
                conditions.Append("))");
                atLeastOneCondition = true;
            }

            HashSet<string> invoiceIdSet = new HashSet<string>();
            if (!string.IsNullOrEmpty(command.Keyword) && !string.IsNullOrEmpty(command.SearchIn))
            {
                string columnName = SearchInvoiceSearchInData.GetColumnNameByFieldName(command.SearchIn);
                if (!string.IsNullOrEmpty(columnName))
                {
                    string keyword = command.Keyword;
                    if (columnName.Equals("all_fields"))
                    {
                        string statement = SearchInAllFields(keyword, invoiceIdSet);
                        if (!string.IsNullOrEmpty(statement))
                        {
                            if (atLeastOneCondition)
                            {
                                conditions.Append(operatorAND);
                            }
                            conditions.Append("(" + statement + ")");
                            atLeastOneCondition = true;
                        }
                    }
                    else if (columnName.Equals("check_number") || columnName.Equals("invoice_items"))
                    {
                        bool inPayment = columnName.Equals("check_number") ? true : false;
                        List<string> invoiceIdList = SearchInPaymentOrInvoiceItem(inPayment, keyword);
                        if (invoiceIdList != null && invoiceIdList.Count > 0)
                        {
                            invoiceIdSet.UnionWith(invoiceIdList);
                            if (atLeastOneCondition)
                            {
                                conditions.Append(operatorAND);
                            }
                            conditions.Append("(invoice_id in (select id from tempdb..##t_invoice))");
                            atLeastOneCondition = true;
                        }
                    }
                    else if (columnName.Equals("status"))
                    {
                        int status;
                        if (int.TryParse(keyword, out status))
                        {
                            if (atLeastOneCondition)
                            {
                                conditions.Append(operatorAND);
                            }
                            conditions.Append("(status = " + status + ")");
                            atLeastOneCondition = true;
                        }
                    }
                    else
                    {
                        if (atLeastOneCondition)
                        {
                            conditions.Append(operatorAND);
                        }
                        conditions.Append("(" + columnName + " like '%" + keyword + "%')");
                        atLeastOneCondition = true;
                    }
                }
            }

            if (atLeastOneCondition)
            {
                query.Append(" WHERE ");
                query.Append(conditions.ToString());
            }

            List<Domain.Model.Invoice> invoices = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    if (command.ClientNames != null && command.ClientNames.Count > 0)
                    {
                        cn.Execute("IF OBJECT_ID('tempdb..##t_client') IS NOT NULL begin  drop table ##t_client end \n create table ##t_client (name nvarchar(255) not null)");

                        StringBuilder insertStatement = new StringBuilder();
                        int insertCount = (int)Math.Ceiling((double)command.ClientNames.Count / 100);
                        for (int i = 0; i < insertCount; i++)
                        {
                            int fromIndex = i * 100;
                            int toIndex = (fromIndex + 99) > (command.ClientNames.Count - 1) ? (command.ClientNames.Count - 1) : (fromIndex + 99);
                            var clientNamesToInsert = new List<dynamic>();
                            insertStatement.Append("insert ##t_client (name) values (@client_name)");
                            for (int j = fromIndex; j <= toIndex; j++)
                            {
                                dynamic insertItem = new { client_name = command.ClientNames[j] };
                                clientNamesToInsert.Add(insertItem);
                            }
                            cn.Execute(insertStatement.ToString(), clientNamesToInsert);
                        }
                    }

                    if (invoiceIdSet.Count > 0)
                    {
                        cn.Execute("create table ##t_invoice (id varchar(36) not null)");

                        List<string> invoiceIdList = invoiceIdSet.ToList<string>();
                        StringBuilder insertStatement = new StringBuilder();
                        int insertCount = (int)Math.Ceiling((double)invoiceIdList.Count / 1000);
                        for (int i = 0; i < insertCount; i++)
                        {
                            int fromIndex = i * 1000;
                            int toIndex = (fromIndex + 999) > (invoiceIdList.Count - 1) ? (invoiceIdList.Count - 1) : (fromIndex + 999);
                            insertStatement.Append("insert ##t_invoice (id) values");
                            for (int j = fromIndex; j <= toIndex; j++)
                            {
                                insertStatement.Append(" ('" + invoiceIdList[j] + "')");
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
                        invoices = new List<Domain.Model.Invoice>();
                        foreach (var item in result)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.invoice_id))
                            {
                                Domain.Model.InvoiceId invoiceId = new Domain.Model.InvoiceId(item.invoice_id);
                                Domain.Model.Invoice invoice = new Domain.Model.Invoice(invoiceId);
                                invoice.ClientName = item.client_name;
                                invoice.SoldToClientName = item.sold_to_client_name;
                                invoice.Address = item.address;
                                invoice.InvoiceReference = item.invoice_reference;
                                invoice.CustomerNumber = item.customer_number;
                                invoice.InvoiceComments = item.invoice_comments;
                                invoice.InvoiceNumber = item.invoice_number;
                                invoice.InvoiceDate = item.invoice_date;
                                invoice.NoteToClient = item.note_to_client;
                                invoice.PONumber = item.po_number;
                                invoice.InvoiceDivision = item.invoice_division;
                                invoice.Status = Status.CreateInstance(item.status);
                                invoice.Amount = item.amount;
                                invoice.Balance = item.balance;
                                invoice.ActionStatus = ActionStatus.CreateInstance(item.action_status);
                                invoices.Add(invoice);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return invoices;
        }

        private string SearchInAllFields(string keyword, HashSet<string> invoiceIdSet)
        {
            List<string> columnNames = SearchInvoiceSearchInData.GetAllColumnNames();
            if (columnNames == null || columnNames.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder conditions = new StringBuilder();
            bool atLeastOneCondition = false;
            foreach (string columnName in columnNames)
            {
                if (columnName.Equals("all_fields"))
                {
                    continue;
                }
                else if (columnName.Equals("check_number") || columnName.Equals("invoice_items"))
                {
                    bool inPayment = columnName.Equals("check_number") ? true : false;
                    List<string> invoiceIdList = SearchInPaymentOrInvoiceItem(inPayment, keyword);
                    if (invoiceIdList != null && invoiceIdList.Count > 0)
                    {
                        if (invoiceIdSet != null)
                        {
                            invoiceIdSet.UnionWith(invoiceIdList);
                        }
                    }
                }
                else if (columnName.Equals("status"))
                {
                    Status status = null;
                    try
                    {
                        status = Status.FromDisplayName<Status>(keyword);
                    }
                    catch (Exception ex)
                    {
                        status = null;
                    }

                    if (status != null)
                    {
                        if (atLeastOneCondition)
                        {
                            conditions.Append(operatorOR);
                        }
                        conditions.Append("(status = " + status.Value + ")");
                        atLeastOneCondition = true;
                    }
                    else
                    {
                        int statusValue;
                        if (int.TryParse(keyword, out statusValue))
                        {
                            if (atLeastOneCondition)
                            {
                                conditions.Append(operatorOR);
                            }
                            conditions.Append("(status = " + statusValue + ")");
                            atLeastOneCondition = true;
                        }
                    }
                }
                else
                {
                    if (atLeastOneCondition)
                    {
                        conditions.Append(operatorOR);
                    }
                    conditions.Append("(" + columnName + " like '%" + keyword + "%')");
                    atLeastOneCondition = true;
                }
            }

            if (invoiceIdSet != null && invoiceIdSet.Count > 0)
            {
                if (atLeastOneCondition)
                {
                    conditions.Append(operatorOR);
                }
                conditions.Append("(invoice_id in (select id from tempdb..##t_invoice))");
                atLeastOneCondition = true;
            }

            return conditions.ToString();
        }

        private List<string> SearchInPaymentOrInvoiceItem(bool inPayment, string keyword)
        {
            if (inPayment)
            {
                return paymentRepository.FindInvoiceIdByCheck(keyword);
            }
            else
            {
                return invoiceItemRepository.FindInvoiceIdByNameDescAndUnitPrice(keyword);
            }
        }

    }
}
