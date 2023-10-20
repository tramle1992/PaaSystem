using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Data.StandardTemplate
{
    public class EmpRefsData
    {
        public string EmpRefs { get; set; }

        public EmpRefsData()
        {
        }

        public EmpRefsData(string empRefs)
        {
            this.EmpRefs = empRefs;
        }
    }
}
