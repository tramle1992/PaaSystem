using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Faker.Extensions;

namespace DataMigrationApp
{
    public static class SSNFaker
    {
        private static string GetAreaNumber()
        {
            string areaNumber = "###".Numerify();
            while (areaNumber == "000" ||
                areaNumber == "666" ||
                (int.Parse(areaNumber) >= 900 && int.Parse(areaNumber) <= 999))
            {
                areaNumber = "###".Numerify();
            }
            return areaNumber;
        }

        private static string GetGroupNumber()
        {
            string groupNumber = "##".Numerify();
            while (groupNumber == "00")
            {
                groupNumber = "##".Numerify();
            }
            return groupNumber;
        }

        private static string GetSerialNumber()
        {
            string serialNumber = "####".Numerify();
            while (serialNumber == "0000")
            {
                serialNumber = "####".Numerify();
            }
            return serialNumber;
        }

        public static string GetSSNNumber()
        {
            return GetAreaNumber() + "-" + GetGroupNumber() + "-" + GetSerialNumber();
        }
    }
}
