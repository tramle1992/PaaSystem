using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDocument.Application.Data
{
    public class PieChartData
    {
        public string Title { get; set; }

        public List<int> Numbers { get; set; }

        public List<string> NameOfXAxisValues { get; set; }

        public PieChartData()
        {
            this.NameOfXAxisValues = new List<string>();
            this.Numbers = new List<int>();
        }

        public PieChartData(string title, List<string> lstName, List<int> lstNum)
        {
            this.Title = title;
            this.NameOfXAxisValues = lstName;
            this.Numbers = lstNum;
        }
    }
}
