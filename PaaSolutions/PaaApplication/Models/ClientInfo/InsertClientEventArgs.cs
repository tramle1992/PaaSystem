using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoResource.Application.Data;
using Core.Application.Data.ClientInfo;


namespace PaaApplication.Models.ClientInfo
{
    public class InsertClientEventArgs : EventArgs
    {
        public string ClientName { get; set; }       

        public string CustomerNumber { get; set; }


        public InsertClientEventArgs(string clientName, string custNo)
        {
            this.ClientName = clientName;
            this.CustomerNumber = custNo;
        }
    }
}
