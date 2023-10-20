using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public class SearchKeywordOptionData
    {
        public string Keyword { get; set; }

        public string SearchIn { get; set; }

        public string Criteria { get; set; }

        public SearchKeywordOptionData(string keyword, string searchIn, string criteria)
        {
            Keyword = keyword;
            SearchIn = searchIn;
            Criteria = criteria;
        }
    }
}
