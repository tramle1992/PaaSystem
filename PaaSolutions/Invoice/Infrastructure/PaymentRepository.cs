using Common.Infrastructure.Repository;
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
    public class PaymentRepository : Repository<Payment, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PaymentRepository()
        {
        }

        public override void Add(Payment item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert payment(payment_id, invoice_id, amount, date, [check])" +
                        " values (@payment_id, @invoice_id, @amount, @date, @check)";

                    var args = new DynamicParameters();
                    args.Add("payment_id", item.PaymentId.Id);
                    args.Add("invoice_id", item.InvoiceId.Id);
                    args.Add("amount", item.Amount);
                    args.Add("date", item.Date);
                    args.Add("check", item.Check);

                    cn.Execute(insertStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Remove(Payment item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from payment where payment_id = @payment_id";

                    cn.Execute(deleteStatement, new { payment_id = item.PaymentId.Id });
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

                    string deleteStatement = @"delete from payment where payment_id = @payment_id";

                    cn.Execute(deleteStatement, new { payment_id = id });
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

                    string deleteStatement = @"delete from payment where invoice_id = @invoice_id";

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

                    string deleteStatement = @"delete from payment";

                    cn.Execute(deleteStatement);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override void Update(Payment item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update payment set invoice_id=@invoice_id" +
                        ", amount=@amount, date=@date, [check]=@check" +
                        " where payment_id=@payment_id";

                    var args = new DynamicParameters();
                    args.Add("payment_id", item.PaymentId.Id);
                    args.Add("invoice_id", item.InvoiceId.Id);
                    args.Add("amount", item.Amount);
                    args.Add("date", item.Date);
                    args.Add("check", item.Check);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public override Payment Find(string id)
        {
            Payment payment = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select payment_id, invoice_id, amount, date, [check]" +
                        " from payment where payment_id=@payment_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { payment_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.payment_id) &&
                        !string.IsNullOrEmpty(item.invoice_id))
                    {
                        PaymentId paymentId = new PaymentId(item.payment_id);
                        InvoiceId invoiceId = new InvoiceId(item.invoice_id);
                        payment = new Payment(paymentId, invoiceId);
                        payment.Amount = item.amount;
                        payment.Date = item.date;
                        payment.Check = item.check;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return payment;
        }

        public List<Payment> FindByInvoiceId(string invoiceId)
        {
            List<Payment> payments = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select payment_id, invoice_id, amount, date, [check]" +
                        " from payment where invoice_id=@invoice_id order by date desc";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, new { invoice_id = invoiceId });
                    if (result != null)
                    {
                        payments = new List<Payment>();
                        foreach (var item in result)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.payment_id) &&
                                !string.IsNullOrEmpty(item.invoice_id))
                            {
                                PaymentId paymentId = new PaymentId(item.payment_id);
                                InvoiceId objInvoiceId = new InvoiceId(item.invoice_id);
                                Payment payment = new Payment(paymentId, objInvoiceId);
                                payment.Amount = item.amount;
                                payment.Date = item.date;
                                payment.Check = item.check;
                                payments.Add(payment);
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
            return payments;
        }

        public List<string> FindInvoiceIdByCheck(string check)
        {
            List<string> invoiceIds = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select distinct invoice_id" +
                        " from payment where [check] like '%" + check + "%'";

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

        public List<Payment> FindAll()
        {
            List<Payment> payments = null;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select payment_id, invoice_id, amount, date, [check]" +
                        " from payment order by date desc";

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement);
                    if (result != null)
                    {
                        payments = new List<Payment>();
                        foreach (var item in result)
                        {
                            if (item != null && !string.IsNullOrEmpty(item.payment_id) &&
                                !string.IsNullOrEmpty(item.invoice_id))
                            {
                                PaymentId paymentId = new PaymentId(item.payment_id);
                                InvoiceId invoiceId = new InvoiceId(item.invoice_id);
                                Payment payment = new Payment(paymentId, invoiceId);
                                payment.Amount = item.amount;
                                payment.Date = item.date;
                                payment.Check = item.check;
                                payments.Add(payment);
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
            return payments;
        }
    }
}
