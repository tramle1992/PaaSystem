using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard.Command
{
    public class NewTimeCardCommand
    {
        public string UserId { get; set; }


        public NewTimeCardCommand(string userId)
        {            
            this.UserId = userId;
        }
    }
}

