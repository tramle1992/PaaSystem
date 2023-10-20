using Administration.Domain.Model.Microbilt;
using Common.Infrastructure.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Infrastructure.Microbilt
{
    /// <summary>
    /// Repository for Microbilt Account - all data should be hard code.
    /// </summary>
    public class AccountInfoRepository
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AccountInfoRepository()
        { }

        public List<AccountInfo> FindAll()
        {
            var result = new List<AccountInfo>();
#if PRODUCTION_DEPLOY
            result.Add(new AccountInfo("698d98e0-e3c4-475b-b029-5af21263bd05", "CCC0091181", "0813101022", "Regular Credit Reports", 0));
            result.Add(new AccountInfo("698d98e0-e3c4-475b-b029-5af21263bd06", "CCC0007544", "1517151523", "Enhance People Search", 1));
            result.Add(new AccountInfo("698d98e0-e3c4-475b-b029-5af21263bd07", "CCC0007544", "1517151523", "No Credit Reports", 2));
            result.Add(new AccountInfo("698d98e0-e3c4-475b-b029-5af21263bd08", "CCC0093582", "0816313128", "Credit & FICO Score", 3));
#else
            result.Add(new AccountInfo("698d98e0-e3c4-475b-b029-5af21263bd05", "CCC0007544", "1517151523", "Regular Credit Reports", 0));
            result.Add(new AccountInfo("698d98e0-e3c4-475b-b029-5af21263bd06", "CCC0007544", "1517151523", "Enhance People Search", 1));
            result.Add(new AccountInfo("698d98e0-e3c4-475b-b029-5af21263bd07", "CCC0007544", "1517151523", "No Credit Reports", 2));
            result.Add(new AccountInfo("698d98e0-e3c4-475b-b029-5af21263bd08", "CCC0007544", "1517151523", "Credit & FICO Score", 3));
#endif
      
            return result;
        }

        public AccountInfo FindByType(int creditType)
        {
            List<AccountInfo> accounts = this.FindAll();
            foreach (var acc in accounts)
            {
                if (acc.CreditType == creditType)
                    return acc;
            }
            return null;
        }
    }
}
