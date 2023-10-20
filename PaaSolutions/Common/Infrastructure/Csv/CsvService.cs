using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BrightIdeasSoftware;
using CsvHelper;
using System.IO;

namespace Common.Infrastructure.Csv
{
    public class CsvService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);       

        public void WriteObjectListView(string targetPath, ObjectListView olv)
        {
            try 
	        {	        
		        if (string.IsNullOrEmpty(targetPath) || (olv.Columns.Count <= 0))
                   return;

                using (StreamWriter sw = new StreamWriter(targetPath))
                {
                    CsvWriter writer = new CsvWriter(sw);
                    Dictionary<int, int> dictDisplayIndexToIndex = new Dictionary<int,int>();
                    
                    foreach(OLVColumn col in olv.Columns)
                    {
                        dictDisplayIndexToIndex.Add(col.DisplayIndex, col.Index);
                        
                    }
                    // sort the display index
                    List<int> lstSortDisplayIndex = dictDisplayIndexToIndex.Keys.ToList<int>();
                    lstSortDisplayIndex.Sort();

                    foreach (int  displayIndex in lstSortDisplayIndex)
                    {
                        int index = dictDisplayIndexToIndex[displayIndex];
                        OLVColumn col = (OLVColumn)olv.Columns[index];
                        writer.WriteField(col.Text);
                    }
                    writer.NextRecord();
                    foreach(OLVListItem item in olv.Items)
                    {
                        foreach (int displayIndex in lstSortDisplayIndex)
                        {
                            int index = dictDisplayIndexToIndex[displayIndex];
                            OLVListSubItem subItem = (OLVListSubItem)item.SubItems[index];
                            writer.WriteField(subItem.Text);
                        }
                        writer.NextRecord();
                    }                    
                }
	        }
	        catch (Exception ex)
	        {
		        _logger.Error(ex);
		        throw;
	        }
        }
    }
}
