using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Data.StandardTemplate
{
    public sealed class RootItemData
    {
        public static readonly RootItemData EMP_REFS_ID = new RootItemData("355689a3-00b5-45f9-a064-439ae7d71f0d");
        public static readonly RootItemData EMP_VERIFS_1_ID = new RootItemData("60bea004-902a-4e15-850b-35b65a68d1b4");
        public static readonly RootItemData EMP_VERIFS_2_ID = new RootItemData("e5891e1c-84db-404d-a533-5ecdaa824e97");
        public static readonly RootItemData RENTAL_REFS_ID = new RootItemData("e94a3c7d-d201-4851-b327-79bf5e147d36");
        public static readonly RootItemData FINAL_CMTS_ID = new RootItemData("fc55eb14-7d67-4800-9e94-55f34e9b8a0e");

        public string Value { get; private set; }

        private RootItemData(string value)
        {
            this.Value = value;
        }
    }
}
