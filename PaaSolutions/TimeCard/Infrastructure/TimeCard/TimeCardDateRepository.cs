using Common.Infrastructure.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Domain.Model;

namespace TimeCard.Infrastructure.TimeCard
{
    public class TimeCardDateRepository : Repository<TimeCardDate, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TimeCardDateRepository()
        { }

        public override void Add(TimeCardDate item)
        {
            try
            {
                item.FirstLogin = DateTime.Now.ToUniversalTime();
                item.Date = DateTime.Now.ToUniversalTime();

                string existedTimeCardItemId = "";

                if (!IsExistTimeCardDate(item, out existedTimeCardItemId))
                {
                    using (IDbConnection cn = Connection)
                    {
                        string insertStatement = @"insert into timecard_date(timecard_date_id, user_id, timecard_date, bonus, first_login, last_logout, timecard_type)" +
                            "values (@timecard_date_id, @user_id, @timecard_date, @bonus, @first_login, @last_logout, @timecard_type)";

                        var args = new DynamicParameters();

                        TimeCardDateId tcDateId = new TimeCardDateId(Guid.NewGuid().ToString());
                        args.Add("timecard_date_id", tcDateId.Id);
                        args.Add("user_id", item.UserId);
                        args.Add("timecard_date", DateTime.Now.ToUniversalTime());
                        args.Add("bonus", item.Bonus);
                        args.Add("first_login", item.FirstLogin);
                        args.Add("last_logout", null);
                        args.Add("timecard_type", TimeCardType.Regular.Value);

                        cn.Execute(insertStatement, args);

                        item.TimeCardDateId = tcDateId;
                    }

                    if (item.ListTimeCardItems.Count > 0)
                    {
                        TimeCardItemRepository tcReposiroty = new TimeCardItemRepository();
                        foreach (TimeCardItem tc in item.ListTimeCardItems)
                        {
                            tc.LoginTime = item.FirstLogin;
                            tc.TimeCardDateId = item.TimeCardDateId;
                            tcReposiroty.AddTimeCardWhenLogin(tc);
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(existedTimeCardItemId))
                    {
                        TimeCardDateId id = new TimeCardDateId(existedTimeCardItemId);
                        item.TimeCardDateId = id;

                        if (item.ListTimeCardItems.Count > 0)
                        {
                            TimeCardItemRepository tcReposiroty = new TimeCardItemRepository();
                            foreach (TimeCardItem tc in item.ListTimeCardItems)
                            {
                                tc.LoginTime = DateTime.Now.ToUniversalTime();
                                tc.TimeCardDateId = item.TimeCardDateId;
                                tcReposiroty.AddTimeCardWhenLogin(tc);
                            }
                        }
                    }
                }

                UpdateNullData(item.UserId, item.FirstLogin);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        private void UpdateNullData(string userId, DateTime currLoginTime)
        {
            /// Get last logout time.. to check if there's null data or not

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select top 1 tc.login_time, tc.logout_time, d.first_login, d.last_logout, tc.timecard_id from timecard tc join timecard_date d on d.timecard_date_id = tc.timecard_date_id where user_id = @user_id and login_time < @current_time order by logout_time";

                    var parameters = new DynamicParameters();
                    parameters.Add("user_id", userId);
                    parameters.Add("current_time", currLoginTime);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    if (result.Count() > 0)
                    {
                        foreach (var i in result)
                        {
                            DateTime logoutTime = new DateTime();
                            string timecardDateId = string.Empty;
                            string timecardId = string.Empty;

                            timecardDateId = i.timecard_date_id;
                            timecardId = i.timecard_id;

                            if (!DateTime.TryParse(i.logout_time, out logoutTime))
                            {
                                // Update timecard_date
                                string updateStatement = @"update timecard_date set last_logout = @current_time where timecard_date_id = @timecard_date_id";

                                var args = new DynamicParameters();
                                args.Add("timecard_date_id", timecardDateId);
                                args.Add("current_time", currLoginTime);

                                cn.Execute(updateStatement, args);

                                // Update timecard table
                                string updateStatement1 = @"update timecard set logout_time = @current_time where timecard_id = @timecard_id";

                                var args1 = new DynamicParameters();
                                args1.Add("timecard_id", timecardId);
                                args1.Add("current_time", currLoginTime);

                                cn.Execute(updateStatement1, args1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

        }

        public void UpdateWhenLogOut(TimeCardDate item)
        {
            try
            {
                string id = "";
                item.Date = DateTime.Now.ToUniversalTime();
                IsExistTimeCardDate(item, out id);
                TimeCardDateId tcId = new TimeCardDateId(id);
                item.LastLogout = DateTime.Now.ToUniversalTime();

                using (IDbConnection cn = Connection)
                {
                    string updateTimcardTable = @"update timecard set logout_time = @logout_time where timecard_date_id = @timecard_date_id and logout_time is null";

                    var args = new DynamicParameters();

                    args.Add("timecard_date_id", tcId.Id);
                    args.Add("logout_time", item.LastLogout);
                    args.Add("user_id", item.UserId);

                    cn.Execute(updateTimcardTable, args);

                    //

                    string updateTimceCardDate = @"update timecard_date set last_logout = @last_logout where timecard_date_id = @timecard_date_id";

                    var args1 = new DynamicParameters();

                    args1.Add("timecard_date_id", tcId.Id);
                    args1.Add("last_logout", item.LastLogout);

                    cn.Execute(updateTimceCardDate, args1);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public bool IsExistTimeCardDate(TimeCardDate item, out string existedTimecardRecordId)
        {
            bool isExist = false;
            try
            {
                existedTimecardRecordId = "";
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select distinct timecard_date, timecard_date_id from timecard_date where user_id = @user_id";

                    var parameters = new DynamicParameters();
                    parameters.Add("user_id", item.UserId);

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    if (result.Count() > 0)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("timecard_date", typeof(DateTime));
                        dt.Columns.Add("timecard_date_id", typeof(string));
                        foreach (var i in result)
                        {
                            DataRow dr = dt.NewRow();
                            dr["timecard_date"] = i.timecard_date;
                            dr["timecard_date_id"] = i.timecard_date_id;
                            dt.Rows.Add(dr);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                DateTime date = Convert.ToDateTime(r["timecard_date"]);
                                if (date.ToLocalTime().Date == item.Date.ToLocalTime().Date)
                                {
                                    isExist = true;
                                    existedTimecardRecordId = r["timecard_date_id"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
            return isExist;
        }

        public override void Update(TimeCardDate item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    string updateStatement = @"update timecard_date set bonus = @bonus, timecard_type = @timecard_type where timecard_date_id = @timecard_date_id";

                    var args = new DynamicParameters();
                    args.Add("timecard_date_id", item.TimeCardDateId.Id);
                    args.Add("bonus", item.Bonus);
                    args.Add("timecard_type", item.TimeCardType.Value);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Remove(TimeCardDate item)
        {
            throw new NotImplementedException();
        }

        public override TimeCardDate Find(string id)
        {
            throw new NotImplementedException();
        }

        public DateTime GetCurrentServertimeInUtc()
        {
            return DateTime.Now.ToUniversalTime();
        }

        public void UpdateLastLoginInTableUser(TimeCardDate item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    string updateStatement = @"update [user] set last_login = @last_login where user_id = @user_id";

                    var args = new DynamicParameters();
                    args.Add("last_login", item.FirstLogin);
                    args.Add("user_id", item.UserId);

                    cn.Execute(updateStatement, args);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

    }
}
