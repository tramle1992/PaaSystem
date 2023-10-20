using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public class DuplicateAppData
    {
        public string ApplicationId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string AppSSN { get; set; }

        public string ClientAppliedName { get; set; }

        public string Company { get; set; }

        public string ReportTypeName { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public string LocationId { get; set; }

    }
}
