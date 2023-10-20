using Core.Application.Data.ExploreApps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.AppExplore
{
    public class BeforeSetTemplateEventArgs
    {
        public string Content { get; set; }

        public BeforeSetTemplateEventArgs(string content)
        {
            this.Content = content;
        }
    }
}
