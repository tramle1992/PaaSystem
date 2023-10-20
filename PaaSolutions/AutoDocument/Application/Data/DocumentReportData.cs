using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AutoDocument.Application.Data
{
    public class DocumentReportData
    {
        public Dictionary<string, string> BookmarkData { get; set; }

        public Dictionary<int, DataTable> TableData { get; set; }

        public DocumentReportData()
        {
            BookmarkData = new Dictionary<string, string>();
            TableData = new Dictionary<int, DataTable>();
        }

        public DocumentReportData(Dictionary<string, string> bookmarkData, Dictionary<int, DataTable> tableData)
        {
            BookmarkData = bookmarkData;
            TableData = tableData;
        }
    }
}
