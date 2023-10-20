using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model.ExploreApps
{
    public class ReviewComment
    {
        public string ReviewCommentId { get; set; }

        public List<string> Areas { get; set; }

        public string Comment { get; set; }

        public ReviewComment()
        {
            Areas = new List<string>();
            Comment = "";
        }

        public static List<string> GetDefaultAreas()
        {
            List<string> result = new List<string>();
            result.Add("Verify Reference:");
            result.Add("Check Crimminal:");
            result.Add("Check out Address:");
            result.Add("Spelling:");
            result.Add("Note if Criminal is checked:");
            result.Add("Get Bank Information:");
            return result;
        }
    }
}
