using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightIdeasSoftware;
using Common.Infrastructure.ApiClient;
using System.Configuration;
using System.Net.Http;
using System.Diagnostics;
using System.Collections;


namespace Common.Infrastructure.OLV
{
    public class ObjectListViewService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ObjectListViewService()
        {
        }

        public void FilterOlv(ObjectListView olv, string txt)
        {
            this.TimedFilter(olv, txt, 0);
        }

        private void TimedFilter(ObjectListView olv, string txt, int matchKind)
        {
            TextMatchFilter filter = null;

            if (!String.IsNullOrEmpty(txt))
            {
                switch (matchKind)
                {
                    case 0:
                    default:
                        filter = TextMatchFilter.Contains(olv, txt);
                        break;
                    case 1:
                        filter = TextMatchFilter.Prefix(olv, txt);
                        break;
                    case 2:
                        filter = TextMatchFilter.Regex(olv, txt);
                        break;
                }
            }

            /*
            if (filter == null)
                olv.DefaultRenderer = null;
            else
            {
                olv.DefaultRenderer = new HighlightTextRenderer(filter);
            }

            HighlightTextRenderer highlightingRenderer = olv.GetColumn(2).Renderer as HighlightTextRenderer;
            if (highlightingRenderer != null)
                highlightingRenderer.Filter = filter;
            */

            olv.AdditionalFilter = filter;
        }

        public DataTable GetDataTableFromOlv(ObjectListView olv)
        {
            DataTable table = new DataTable();
            Dictionary<int, int> dictDisplayIndexToIndex = new Dictionary<int, int>();
            foreach (OLVColumn col in olv.Columns)
            {
                dictDisplayIndexToIndex.Add(col.DisplayIndex, col.Index);

            }
            List<int> lstSortDisplayIndex = dictDisplayIndexToIndex.Keys.ToList<int>();
            lstSortDisplayIndex.Sort();

            foreach (int displayIndex in lstSortDisplayIndex)
            {
                int index = dictDisplayIndexToIndex[displayIndex];
                OLVColumn col = (OLVColumn)olv.Columns[index];
                DataColumn dataCol = new DataColumn(col.Text);
                dataCol.DataType = System.Type.GetType("System.String");
                table.Columns.Add(dataCol);
            }

            foreach (OLVListItem item in olv.Items)
            {
                DataRow row = table.NewRow();
                foreach (int displayIndex in lstSortDisplayIndex)
                {
                    int index = dictDisplayIndexToIndex[displayIndex];
                    OLVListSubItem subItem = (OLVListSubItem)item.SubItems[index];
                    row[displayIndex] = subItem.Text;
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
