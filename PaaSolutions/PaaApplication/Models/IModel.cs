using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoResource.Application.Data;

namespace PaaApplication.Models
{
    public interface IModel
    {
        bool Login(string userName, string password);
        void Logout();
        List<Timecard> GetAllTimecards();
    }
}
