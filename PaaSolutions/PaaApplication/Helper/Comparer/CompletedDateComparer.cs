using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Helper.Comparer
{
    public class CompletedDateComparer : IComparer
    {
        SortOrder _order;
        public CompletedDateComparer(SortOrder order)
        {
            _order = order;
        }

        public int Compare(object item1, object item2)
        {
            DateTime dt1, dt2;
            if (DateTime.TryParse(((OLVListItem)item1).SubItems[5].Text, out dt1)
                && DateTime.TryParse(((OLVListItem)item2).SubItems[5].Text, out dt2))
            {
                if (_order.Equals(SortOrder.Ascending))
                {
                    return DateTime.Compare(dt1, dt2);
                }
                if (_order.Equals(SortOrder.Descending))
                {
                    return DateTime.Compare(dt2, dt1);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                DateTime dt;
                if (((OLVListItem)item1).SubItems[5].Text.Equals("In-Process") 
                    && !(((OLVListItem)item2).SubItems[5].Text.Equals("In-Process")))
                {
                    dt = DateTime.Parse(((OLVListItem)item2).SubItems[5].Text);
                }
                if (((OLVListItem)item2).SubItems[5].Text.Equals("In-Process") 
                    && !(((OLVListItem)item1).SubItems[5].Text.Equals("In-Process")))
                {
                    dt = DateTime.Parse(((OLVListItem)item1).SubItems[5].Text);
                }
                else
                {
                    dt = DateTime.Today;
                }
                return DateTime.Compare(DateTime.Today, dt); 
            }            
        }
    }
}
