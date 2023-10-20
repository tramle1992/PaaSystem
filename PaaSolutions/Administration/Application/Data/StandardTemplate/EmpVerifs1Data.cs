using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Data.StandardTemplate
{
    public class EmpVerifs1Data
    {
        public string SW { get; set; }
        public string Co { get; set; }
        public string Tele { get; set; }

        public EmpVerifs1Data()
        {
        }

        public EmpVerifs1Data(string sw, string co, string tele)
        {
            this.SW = sw;
            this.Co = co;
            this.Tele = tele;
        }
    }
}
