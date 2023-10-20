using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication
{
    public static class GlobalVars
    {
        public static bool IsIgnoreAutoSave { get; set; }
        public static bool IsFormLoaded { get; set; }
        public static string SearchText {get; set;}
        public static int TickCount {get; set;}
    }
}
