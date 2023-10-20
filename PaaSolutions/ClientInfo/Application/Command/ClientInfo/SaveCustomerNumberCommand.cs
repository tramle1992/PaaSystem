using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Data.ClientInfo;

namespace Core.Application.Command.ClientInfo
{
    public class SaveCustomerNumerCommand    
    {
        public int LastNumber { get; set; }
        public string Letter { get; set; }

        public SaveCustomerNumerCommand(int number)
        {
            this.LastNumber = number;
        }

        public SaveCustomerNumerCommand()
        {            
        }
    }
}
