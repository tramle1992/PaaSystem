using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDocument.Application.Data
{
    public class LineChartData
    {
        public string Title { get; set; }

        public List<string> SeriesNames { get; set; }

        public List<string> Labels { get; set; }

        public List<List<int>> SeriesYValues { get; set; }

        public LineChartData()
        {
            this.SeriesNames = new List<string>();
            this.Labels = new List<string>();
            this.SeriesYValues = new List<List<int>>();
        }

        public LineChartData(string title, List<string> sericesNames, List<string> labels, List<List<int>> seriesYValues)
        {
            this.Title = title;
            this.SeriesNames = sericesNames;
            this.Labels = labels;
            this.SeriesYValues = seriesYValues;
        }
    }
}
