using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Data.StandardTemplate
{
    public class FinalCmtsData
    {
        public string FinalCmts { get; set; }

        public FinalCmtsData()
        {
        }

        public FinalCmtsData(string finalCmts)
        {
            this.FinalCmts = finalCmts;
        }
    }
}
