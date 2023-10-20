using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ClientInfo
{
    public class ClientGridData
    {
        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public string BillingAddress { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string ManagementName { get; set; }

        public string BillingInfo { get; set; }

        public string MiscComments { get; set; }

        public ISet<ContactData> Contacts { get; set; }

        public DateTime LastScreening { get; set; }

        public int NumOfScreening { get; set; }

        public ClientGridData()
        {
            this.Contacts = new HashSet<ContactData>();
        }

        public ClientGridData(
            string clientId,
            string clientName,
            string billingAddress,
            string phone,
            string fax,
            string email,
            string managementName,
            string billingInfo,
            string miscComments,
            ISet<ContactData> contacts,
            DateTime lastScreening,
            int numOfScreening
            )
        {
            this.ClientId = clientId;
            this.ClientName = ClientName;
            this.BillingAddress = billingAddress;
            this.Phone = phone;
            this.Fax = fax;
            this.Email = email;
            this.ManagementName = managementName;
            this.BillingInfo = billingInfo;
            this.MiscComments = miscComments;
            this.Contacts = contacts;
            this.LastScreening = lastScreening;
            this.NumOfScreening = numOfScreening;
        }
    }
}
