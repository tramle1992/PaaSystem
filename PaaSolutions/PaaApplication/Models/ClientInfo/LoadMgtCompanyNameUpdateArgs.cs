using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoResource.Application.Data;
using Core.Application.Data.ClientInfo;


namespace PaaApplication.Models.ClientInfo
{
    public class LoadMgtCompanyNameUpdateArgs : EventArgs
    {
        public ManagementCompanyData ManagementCompanyData { get; set; }

        public LoadMgtCompanyNameUpdateArgs(ManagementCompanyData mgtCompanyData)
        {
            this.ManagementCompanyData = mgtCompanyData;
        }
    }
}
