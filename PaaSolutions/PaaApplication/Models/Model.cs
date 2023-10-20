using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Common.Infrastructure.ApiClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Configuration;

namespace PaaApplication.Models
{
    public class Model
    {
        // init service
        // static Service service = new Service();
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Login / Logout
        public bool Login(string userName, string password)
        {
            // return service.Login(userName, password);
            MessageBox.Show("Username: " + userName + ", Password: " + password);
            return true;
        }

        public void Logout()
        {
            // service.Logout();
        }
        #endregion

        #region Timecard
        public List<Timecard> GetAllTimecards()
        {
            List<Timecard> result = new List<Timecard>();
            for (int i = 0; i < 10; i++)
            {
                Timecard item = new Timecard();
                item.Date = new DateTime(2015, 7, 7);
                item.TimeIn = new DateTime(2015, 7, 7);
                item.TimeOut = new DateTime(2015, 7, 7);
                item.Bonus = 10;
                item.Hours = 8;
                item.Type = 1;
                result.Add(item);
            }
            return result;
        }
        #endregion

    }
}
