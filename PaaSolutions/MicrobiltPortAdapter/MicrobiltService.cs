using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
#if PRODUCTION_DEPLOY
using TuStd = MicrobiltPortAdapter.ProductionTuStd;
#else
using TuStd = MicrobiltPortAdapter.StagingTuStd;
#endif

namespace MicrobiltPortAdapter
{
    /// <summary>
    /// An adapter to integrate the project to the microbilt service
    /// </summary>
    public static class MicrobiltService
    {
        #if PRODUCTION_DEPLOY
        private static string htmlReportUrl = "https://creditserver.microbilt.com/WebServices/gethtml/gethtml.aspx?guid=";
        #else
        private static string htmlReportUrl = "https://sdkstage.microbilt.com/WebServices/gethtml/gethtml.aspx?guid=";
        #endif
        

        public static TuStd.TuStdRs_Type GetReport(TuStd.TuStdRq_Type inquiry)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new TuStd.TuStdWorkflowClient();
            var response = client.GetReport(inquiry);

            return response;
        }

        public static TuStd.TuStdRs_Type GetArchiveReport(string guid)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new TuStd.TuStdWorkflowClient();
            var response = client.GetArchiveReport(guid);

            return response;
        }

        public static byte[] GetHtmlReport(string guid)
        {
            using (var webclient = new WebClient())
            {
                var reportUrl = MicrobiltService.htmlReportUrl + guid;
                return webclient.DownloadData(reportUrl);
            }
        }
    }
}
