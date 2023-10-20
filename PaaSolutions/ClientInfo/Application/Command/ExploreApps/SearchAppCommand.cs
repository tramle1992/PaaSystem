using Core.Application.Data.ExploreApps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Command.ExploreApps
{
    public class SearchAppCommand
    {
        public enum AppStatus
        {
            All,
            Archive,
            InProcess,
            SpecificLocations,
        }

        public List<string> ClientIds { get; set; }

        public List<string> ReportIds { get; set; }

        public List<string> LocationIds { get; set; }

        public DateTime? ReceivedDateFrom { get; set; }

        public DateTime? ReceivedDateTo { get; set; }

        public DateTime? CompletedDateFrom { get; set; }

        public DateTime? CompletedDateTo { get; set; }

        public bool IsFullAppOnly { get; set; }

        public AppStatus Status { get; set; }

        public string ScreenerId { get; set; }

        public List<int> Priorities { get; set; }

        public SearchKeywordOptionData KeywordOption1 { get; set; }

        public SearchKeywordOptionData KeywordOption2 { get; set; }

        public string JoinWithKeywords { get; set; }

        public string JoinBetweenKeywords { get; set; }

        public string CustomCondition { get; set; }

        public SearchAppCommand()
        {
            ClientIds = new List<string>();
            ReportIds = new List<string>();
            LocationIds = new List<string>();
            Priorities = new List<int>();
            IsFullAppOnly = false;
            Status = AppStatus.All;
            JoinWithKeywords = "and";
            JoinBetweenKeywords = "and";
        }

        public SearchAppCommand(List<string> clientIds, List<string> reportIds,
            List<string> locationIds,
            DateTime? receivedDateFrom, DateTime? receivedDateTo,
            DateTime? completedDateFrom, DateTime? completedDateTo,
            SearchKeywordOptionData keywordOption1 = null, SearchKeywordOptionData keywordOption2 = null,
            string joinWithKeywords = "and", string joinBetweenKeywords = "and")
        {
            ClientIds = clientIds;
            ReportIds = reportIds;
            LocationIds = locationIds;
            ReceivedDateFrom = receivedDateFrom;
            ReceivedDateTo = receivedDateTo;
            CompletedDateFrom = completedDateFrom;
            CompletedDateTo = completedDateTo;
            JoinWithKeywords = "And";
            JoinBetweenKeywords = joinBetweenKeywords;
        }
    }
}
