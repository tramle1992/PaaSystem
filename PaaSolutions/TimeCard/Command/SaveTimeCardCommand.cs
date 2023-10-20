using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCard.Domain.Model.TimeCard;

namespace TimeCard.Command
{
    public class SaveTimeCardCommand
    {
        public List<UpdateTimeCardDate> ListTimeCardDateToUpdate { get; set; }

        public SaveTimeCardCommand(List<UpdateTimeCardDate> listTimeCardDate)
        {
            this.ListTimeCardDateToUpdate = listTimeCardDate;
        }
    }
}
