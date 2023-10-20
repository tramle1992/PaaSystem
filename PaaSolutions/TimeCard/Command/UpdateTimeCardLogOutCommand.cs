using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard.Command
{
    public class UpdateTimeCardLogOutCommand
    {        
        public string UserId { get; set; }

        public UpdateTimeCardLogOutCommand(string userId)
        {            
            this.UserId = userId;
        }
    }
}
