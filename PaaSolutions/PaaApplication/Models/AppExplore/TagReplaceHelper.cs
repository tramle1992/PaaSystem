using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;

namespace PaaApplication.Models.AppExplore
{
    public static class TagReplaceHelper
    {
        public static string ReplaceClientInfo(string input, ClientData client)
        {            
            return input.Replace("@@client_name@@", client.ClientName ?? string.Empty);
        }

        public static string ReplaceApplicantName(string input, string applicantName)
        {
            return input.Replace("@@applicant_name@@", applicantName ?? string.Empty);
        }
    }
}