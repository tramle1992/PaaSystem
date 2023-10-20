using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.AppExplore
{
    public class EditAppsEventArgs
    {
        public List<string> ApplicationIds { get; set; }

        public EditAppsEventArgs(List<string> applicationIds)
        {
            ApplicationIds = applicationIds;
        }
    }
}
