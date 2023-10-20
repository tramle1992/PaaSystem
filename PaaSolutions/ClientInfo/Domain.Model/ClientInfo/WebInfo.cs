using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace Core.Domain.Model.ClientInfo
{
    public class WebInfo : ValueObject
    {
        private WebInfo()
        { }

        public WebInfo(string websiteDir, string webPass)
        {
            this.WebsiteDir = websiteDir;
            this.WebPass = webPass;
        }

        public WebInfo(WebInfo webInfo)
            : this(webInfo.WebsiteDir, webInfo.WebPass)
        {
        }

        public string WebsiteDir { get; private set; }

        public string WebPass { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return WebsiteDir;
            yield return WebPass;
        }

        public override string ToString()
        {
            return "WebInfo[websiteDir=" + WebsiteDir +
                ", webPass=" + WebPass + "]";
        }
    }
}
