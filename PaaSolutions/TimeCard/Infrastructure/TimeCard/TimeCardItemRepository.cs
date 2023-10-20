using Common.Infrastructure.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Command;
using TimeCard.Domain.Model;

namespace TimeCard.Infrastructure.TimeCard
{
    public class TimeCardItemRepository : Repository<TimeCardItem, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TimeCardItemRepository()
        { }

        public void AddTimeCardWhenLogin(TimeCardItem tcItem)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert into timecard (timecard_id, timecard_date_id, login_time, logout_time) " +
                        "values (@timecard_id, @timecard_date_id, @login_time, @logout_time)";

                    TimeCardItemId tcItemId = new TimeCardItemId(Guid.NewGuid().ToString());

                    var args = new DynamicParameters();
                    args.Add("timecard_id", tcItemId.Id);
                    args.Add("login_time", tcItem.LoginTime);
                    args.Add("timecard_date_id", tcItem.TimeCardDateId.Id);
                    args.Add("logout_time", null);
                    cn.Execute(insertStatement, args);
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Add(TimeCardItem item)
        {
            throw new NotImplementedException();
        }
        public override void Update(TimeCardItem item)
        {
            throw new NotImplementedException();
        }

        public override void Remove(TimeCardItem item)
        {
            throw new NotImplementedException();
        }

        public List<TimeCardDate> FindTimeCard(FindTimeCardCommand command)
        {
            List<TimeCardDate> listResult = new List<TimeCardDate>();

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select d.timecard_date, t.timecard_id, d.timecard_date_id, t.login_time, t.logout_time, d.user_id, d.last_logout, d.first_login, d.timecard_type, d.bonus " +
                        "from timecard t join timecard_date d on t.timecard_date_id = d.timecard_date_id " +
                        "where d.user_id = @user_id and timecard_date between @fromDate and @toDate order by d.timecard_date";

                    var parameters = new DynamicParameters();
                    parameters.Add("user_id", command.userId);
                    parameters.Add("fromDate", command.fromDate.ToUniversalTime());
                    parameters.Add("toDate", command.toDate.ToUniversalTime());

                    IEnumerable<dynamic> result = cn.Query<dynamic>(findStatement, parameters);

                    foreach (var item in result)
                    {
                        bool hasData = false;
                        if (item != null && !string.IsNullOrEmpty(item.timecard_id))
                        {
                            DateTime date = item.timecard_date;
                            TimeCardItemId tcid = new TimeCardItemId(item.timecard_id);
                            TimeCardItem timecard = new TimeCardItem(tcid);

                            timecard.LoginTime = item.login_time;

                            if (item.logout_time != null)
                            {
                                timecard.LogoutTime = item.logout_time;
                            }

                            foreach (TimeCardDate tcDate in listResult)
                            {
                                if (tcDate.Date == date)
                                {
                                    hasData = true;
                                    tcDate.ListTimeCardItems.Add(timecard);
                                    break;
                                }
                            }

                            if (!hasData)
                            {
                                TimeCardDateId tcDateId = new TimeCardDateId(item.timecard_date_id);
                                TimeCardDate tcDate = new TimeCardDate(tcDateId);
                                tcDate.TimeCardType = TimeCardType.CreateInstance(item.timecard_type);
                                tcDate.UserId = item.user_id;
                                tcDate.Date = item.timecard_date;

                                tcDate.FirstLogin = item.first_login;

                                if (item.last_logout != null)
                                {
                                    tcDate.LastLogout = item.last_logout;
                                }

                                tcDate.Bonus = item.bonus;
                                tcDate.ListTimeCardItems.Add(timecard);
                                listResult.Add(tcDate);

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

            return listResult;
        }

        public override TimeCardItem Find(string id)
        {
            throw new NotImplementedException();
        }
    }
}

