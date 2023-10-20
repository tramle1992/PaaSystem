using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Data.ClientInfo;

namespace Core.Application.Command.ClientInfo
{
    public class SaveWideMgtInfoCommand    
    {
        public ManagementCompanyData ManagementCompanyData { get; set; }       

        public string SetClause { get; set; }
       
    }
}
