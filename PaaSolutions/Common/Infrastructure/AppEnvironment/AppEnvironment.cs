using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.AppEnvironment
{
    public class AppEnvironment : Enumeration
    {
        public static readonly AppEnvironment TempFolder = new AppEnvironment(0, Path.GetTempPath());

        public static AppEnvironment CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return AppEnvironment.TempFolder;                
                default:
                    return null;
            }
        }

        public AppEnvironment(int value, string displayName)
            : base(value, displayName)
        { }

    }
}
