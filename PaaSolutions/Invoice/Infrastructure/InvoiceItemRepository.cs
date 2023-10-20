using Common.Infrastructure.Repository;
using Core.Domain.Model.ExploreApps;
using Dapper;
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
    public class InvoiceItemRepository : Repository<InvoiceItem, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public InvoiceItemRepository()
        {
        }

        public override void Add(InvoiceItem item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert invoice_item(invoice_item_id, invoice_id, application_id, name, description, unit_price)" +
                        " values (@invoice_item_id, @invoice_id, @application_id, @name, @description, @unit_price)";

                    var args = new DynamicParameters();
                    args.Add("invoice_item_id", item.InvoiceItemId.Id);
                    args.Add("invoice_id", item.InvoiceId.Id);
                    args.Add("application_id", item.ApplicationId.Id);
                    args.Add("name", item.Name);
                    args.Add("description", item.Description);
                    args.Add("unit_price", item.UnitPrice);

                    cn.Execute(insertStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Remove(InvoiceItem item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from invoice_item where invoice_item_id = @invoice_item_id";

                    cn.Execute(deleteStatement, new { invoice_item_id = item.InvoiceItemId.Id });
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

                    string deleteStatement = @"delete from invoice_item where invoice_item_id = @invoice_item_id";

                    cn.Execute(deleteStatement, new { invoice_item_id = id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void RemoveByInvoiceId(string invoiceId)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from invoice_item where invoice_id = @invoice_id";

                    cn.Execute(deleteStatement, new { invoice_id = invoiceId });
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

                    string deleteStatement = @"delete from invoice_item";

                    cn.Execute(deleteStatement);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Update(InvoiceItem item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update invoice_item set invoice_id=@invoice_id" +
                        ", application_id=@application_id, name=@name, description=@description" +
                        ", unit_price=@unit_price where invoice_item_id=@invoice_item_id";

                    var args = new DynamicParameters();
                    args.Add("invoice_item_id", item.InvoiceItemId.Id);
                    args.Add("invoice_id", item.InvoiceId.Id);
                    args.Add("application_id", item.ApplicationId.Id);
                    args.Add("name", item.Name);
                    args.Add("description", item.Description);
                    args.Add("unit_price", item.UnitPrice);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override InvoiceItem Find(string id)
        {
            InvoiceItem invoiceItem = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select invoice_item_id, invoice_id, application_id, name, description" +
                        ", unit_price from invoice_item where invoice_item_id=@invoice_item_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { invoice_item_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.invoice_item_id) &&
                        !string.IsNullOrEmpty(item.invoice_id))
                    {
                        InvoiceItemId invoiceItemId = new InvoiceItemId(item.invoice_item_id);
                        InvoiceId invoiceId = new InvoiceId(item.invoice_id);
                        AppId applicationId = new AppId(item.application_id);
                        invoiceItem = new InvoiceItem(invoiceItemId, invoiceId, applicationId);
                        invoiceItem.Name = item.name;
                        invoiceItem.Description = item.description;
                        invoiceItem.UnitPrice = item.unit_price;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return invoiceItem;
        }

        public List<InvoiceItem> FindByInvoiceId(string invoiceId)
        {
            List<InvoiceItem> invoiceItems = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select i.invoice_item_id, i.invoice_id, i.application_id, name, i.description, a.received_date" +
                        ", i.unit_price from invoice_item i left join application a on i.application_id  = a.application_id " +
                        "where invoice_id=@invoice_id order by a.received_date";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, new { invoice_id = invoiceId });
                    if (result != null)
                    {
                        invoiceItems = new List<InvoiceItem>();
                        foreach (var item in result)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.invoice_item_id) &&
                                !string.IsNullOrEmpty(item.invoice_id))
                            {
                                InvoiceItemId invoiceItemId = new InvoiceItemId(item.invoice_item_id);
                                InvoiceId objInvoiceId = new InvoiceId(item.invoice_id);
                                AppId applicationId = new AppId(item.application_id);
                                InvoiceItem invoiceItem = new InvoiceItem(invoiceItemId, objInvoiceId, applicationId);
                                invoiceItem.Name = item.name;
                                invoiceItem.Description = item.description;
                                invoiceItem.UnitPrice = item.unit_price;
                                invoiceItems.Add(invoiceItem);
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
            return invoiceItems;
        }

        public List<string> FindInvoiceIdByNameDescAndUnitPrice(string value)
        {
            List<string> invoiceIds = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select distinct invoice_id from invoice_item" +
                        " where (name like '%" + value + "%') or (description like '%" + value + "%')";

                    decimal unitPrice;
                    if (decimal.TryParse(value, out unitPrice))
                    {
                        findStatement += " or (unit_price = " + value + ")";
                    }

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    if (result != null)
                    {
                        invoiceIds = new List<string>();
                        foreach (var item in result)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.invoice_id))
                            {
                                string invoiceId = item.invoice_id;
                                invoiceIds.Add(invoiceId);
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
            return invoiceIds;
        }

        public List<InvoiceItem> FindAll()
        {
            List<InvoiceItem> invoiceItems = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select invoice_item_id, invoice_id, application_id, name, description" +
                        ", unit_price from invoice_item";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    if (result != null)
                    {
                        invoiceItems = new List<InvoiceItem>();
                        foreach (var item in result)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.invoice_item_id) &&
                                !string.IsNullOrEmpty(item.invoice_id))
                            {
                                InvoiceItemId invoiceItemId = new InvoiceItemId(item.invoice_item_id);
                                InvoiceId invoiceId = new InvoiceId(item.invoice_id);
                                AppId applicationId = new AppId(item.application_id);
                                InvoiceItem invoiceItem = new InvoiceItem(invoiceItemId, invoiceId, applicationId);
                                invoiceItem.Name = item.name;
                                invoiceItem.Description = item.description;
                                invoiceItem.UnitPrice = item.unit_price;
                                invoiceItems.Add(invoiceItem);
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
            return invoiceItems;
        }
    }
}
