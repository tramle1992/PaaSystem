using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Data.ExploreApps
{
    public class DragDropData
    {
        public class CreditRef
        {
            public List<CreditRefData> list;
            public int currentIndex;
        }

        public class RentalRef
        {
            public List<RentalRefData> list;
            public int currentIndex;
        }

        public class EmpRef
        {
            public List<EmpRefData> list;
            public int currentIndex;
        }

        public class ChargeRef
        {
            public List<ChargeRefData> list;
            public int currentIndex;
        }

        public class EvictionRef
        {
            public List<EvictionRefData> list;
            public int currentIndex;
        }
    }
}
