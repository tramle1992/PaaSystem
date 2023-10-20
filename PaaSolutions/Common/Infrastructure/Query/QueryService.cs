using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Common.Infrastructure.Query
{
    public abstract class QueryService
    {
        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["PaaSystem"].ConnectionString);
            }
        }
    }
}
