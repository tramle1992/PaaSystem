using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Data.StandardTemplate
{
    public class RentalRefsData
    {
        public string RentalRefs { get; set; }

        public RentalRefsData()
        {
        }

        public RentalRefsData(string rentalRefs)
        {
            this.RentalRefs = rentalRefs;
        }
    }
}
