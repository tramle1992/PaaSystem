using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoResource.Application.Data;
using Core.Application.Data.ClientInfo;


namespace PaaApplication.Models.ClientInfo
{
    public class LoadWideManagementUpdateEventArgs : EventArgs
    {
        public ManagementCompanyData ManagementCompanyData { get; set; }

        public string BillableAddress { get; set; }

        public string DefaultDeliverReportsTo { get; set; }

        public List<string> ListEmails { get; set; }

        public string DefaultDeliverConfirmationsTo { get; set; }

        public string DefaultDeliverInvoicesTo { get; set; }

        public bool DefaultVerifyConfirmDelivery { get; set; }

        public bool DeclinationLetter { get; set; }

        public int InvoicesCopiesNumber { get; set; }

        public bool ConfirmVerification { get; set; }    
    }
}
