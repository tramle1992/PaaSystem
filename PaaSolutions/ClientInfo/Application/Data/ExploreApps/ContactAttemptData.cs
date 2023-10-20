using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public class ContactAttemptData
    {
        public ContactAttemptTypeData ContactAttemptType { get; set; }

        public bool ReturnedOrResolved { get; set; }

        public string Recipient { get; set; }

        public string PhoneFaxEmail { get; set; }

        public string Note { get; set; }
    }
}
