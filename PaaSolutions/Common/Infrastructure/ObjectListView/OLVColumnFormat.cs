using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightIdeasSoftware;

namespace Common.Infrastructure.OLV
{
    public class OLVColumnFormat
    {
        public void FormatDateString(OLVColumn olvColumn)
        {
            olvColumn.AspectToStringConverter = delegate(object aspect)
            {
                DateTime dateTime2;

                if (aspect != null && DateTime.TryParse(aspect.ToString(), out dateTime2))
                {
                    return dateTime2.ToString("MM / dd / yyyy");
                }
                else
                {
                    return " ";
                }
            };
        }

        public void FormatCompletedDate(OLVColumn olvColumn)
        {
            olvColumn.AspectToStringConverter = delegate(object aspect)
            {
                DateTime? completedDate = aspect as DateTime?;
                return completedDate.HasValue ? completedDate.Value.ToString("MM/dd/yyyy hh:mm tt") : "In-Process";
            };
        }

        public void FormatLongDateString(OLVColumn olvColumn)
        {
            olvColumn.AspectToStringConverter = delegate(object aspect)
            {
                DateTime dateTime2;

                if (aspect != null && DateTime.TryParse(aspect.ToString(), out dateTime2))
                {
                    return dateTime2.ToString("MM/dd/yyyy hh:mm tt");
                }
                else
                {
                    return " ";
                }
            };
        }

        public void FormatMonthString(OLVColumn olvColumn)
        {
            olvColumn.AspectToStringConverter = delegate(object aspect)
            {
                return ((DateTime)aspect).ToString("MM / yyyy");
            };
        }

        public void FormatTimeString(OLVColumn olvColumn)
        {
            olvColumn.AspectToStringConverter = delegate(object aspect)
            {
                return ((DateTime)aspect).ToString("hh:mm tt");
            };
        }

        public void FormatPriceString(OLVColumn olvColumn)
        {
            olvColumn.AspectToStringConverter = delegate(object aspect)
            {
                if (aspect != null)
                {
                    return ((decimal)aspect).ToString("F");
                }
                return Convert.ToString("0");
            };
        }

    }
}
