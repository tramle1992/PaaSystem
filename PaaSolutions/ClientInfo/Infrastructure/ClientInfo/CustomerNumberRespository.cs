using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Infrastructure.Repository;
using Core.Domain.Model.ClientInfo;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Text.RegularExpressions;

namespace Core.Infrastructure.ClientInfo
{
    public class CustomerNumberRespository : Repository<CustomerNumberSetting, string>
    {        

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CustomerNumberRespository()
        { }

        public override void Add(CustomerNumberSetting item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert customer_number_setting (letter, last_number) values (@letter, @last_number) ";

                    cn.Execute(insertStatement,
                        new {
                            letter = item.Letter,
                            last_number = item.LastNumber
                        });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }        
        
        public override void Update(CustomerNumberSetting item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    var updateStatement = @"update customer_number_setting set last_number = @last_number where letter = @letter";

                    cn.Execute(updateStatement,
                        new
                        {
                            last_number = item.LastNumber,
                            letter = item.Letter                            
                        });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Remove(CustomerNumberSetting item)
        {
            try
            {
                
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

                    cn.Execute(@"delete from customer_number_setting");
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override CustomerNumberSetting Find(string id)
        {
            CustomerNumberSetting data = null;
            try
            {
                
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return data;
        }

        public int GetLastNumber(string letter)
        {
            int result = 0;
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string sqlStatement = "select last_number from customer_number_setting where letter = @letter";

                    dynamic item = cn.Query<dynamic>(sqlStatement, new { letter = letter }).FirstOrDefault();

                    if (item != null)
                    {
                        result = item.last_number;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return result;
        }
        
        public string GenerateNewCustomerNumber(string letter)
        {
            string result = "";
            try
            {
                if (!string.IsNullOrEmpty(letter))
                {
                    int tmpNum;
                    bool isNumeric = int.TryParse(letter, out tmpNum);

                    if (isNumeric || !Regex.IsMatch(letter, "^[a-zA-Z0-9]+$"))
                    {
                        letter = "Z";
                    }

                    int lastNumber = GetLastNumber(letter);

                    int newNumber = ++lastNumber;

                    result = string.Format("{0}{1}", letter, newNumber.ToString("000"));
                }                
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return result;
        }
       
    }
}
