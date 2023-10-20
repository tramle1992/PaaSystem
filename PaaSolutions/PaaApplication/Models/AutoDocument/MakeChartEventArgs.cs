using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoDocument.Application.Data;

namespace PaaApplication.Models.AutoDocument
{
    public class MakeChartEventArgs : EventArgs
    {
        public ChartFilterData FilterData { get; set; }

        public ChartType ChartType { get; set; }

        public ChartFrom ChartFrom { get; set; }

        public MakeChartEventArgs(ChartType chartType, ChartFrom ChartFrom, ChartFilterData filterData)
        {
            this.ChartType = chartType;
            this.ChartFrom = ChartFrom;
            this.FilterData = filterData;
        }
    }
}
