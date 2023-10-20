using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipCodeContext.Domain.Model
{
    public class ZipCode
    {
        public string ZipCodeId { get;  private set; }

        public string ZipCodeName { get; set; }

        public string ZipCodeType { get; set; }

        public string City { get; set; }

        public string CityType { get; set; }

        public string County { get; set; }

        public string State { get; set; }

        public string StateCode { get; set; }

        public string AreaCode { get; set; }

        /// <summary>
        /// gets or sets Name of Time zone of the city
        /// </summary>
        public string TimezoneName { get; set; }

        /// <summary>
        /// gets or sets GMT Offset of time zone
        /// </summary>
        public int GMTOffset { get; set; }

        public bool DST { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public ZipCode(string zipCodeId)
        {
            this.ZipCodeId = zipCodeId;
        }
    }
}
