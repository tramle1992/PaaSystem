using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDocument.Application.Data
{
    public class UserDisplayInfoData
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public UserDisplayInfoData(string userId, string userName)
        {
            this.UserId = userId;
            this.UserName = userName;
        }
    }
}
