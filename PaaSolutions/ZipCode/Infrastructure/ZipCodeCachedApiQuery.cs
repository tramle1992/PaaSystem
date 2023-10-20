using Common.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipCodeContext.Application.Data;

namespace ZipCodeContext.Infrastructure
{
    public class ZipCodeCachedApiQuery
    {
         private ZipCodeApiRepository repository = new ZipCodeApiRepository();

        private static readonly ZipCodeCachedApiQuery instance = new ZipCodeCachedApiQuery();

        private const string KEY_ALL_ZIPCODES = "KEY_ALL_ZIPCODES";

        private const string KEY_ALL_ZIPCODES_WITH_COUNTRY = "KEY_ALL_ZIPCODES_WITH_COUNTY";
        private const string KEY_ALL_ZIPCODES_WITH_AREACODE = "KEY_ALL_ZIPCODES_WITH_AREA_CODE";

        public static ZipCodeCachedApiQuery Instance
        {
            get { return instance; }
        }

        static ZipCodeCachedApiQuery()
        {
        }

        public List<ZipCodeData> GetAll()
        {
            TypedObjectCache<List<ZipCodeData>> cacheList = TypedObjectCache<List<ZipCodeData>>.Instance;

            List<ZipCodeData> cacheAppItems = null;

            if (cacheList.TryGet(KEY_ALL_ZIPCODES, out cacheAppItems))
            {
                return cacheAppItems;
            }

            cacheAppItems = repository.FindAll();
            cacheList.Set(KEY_ALL_ZIPCODES, cacheAppItems);
            return cacheAppItems;
        }

        public List<ZipCodeData> GetAllByColumn(string column)
        {
            TypedObjectCache<List<ZipCodeData>> cacheList = TypedObjectCache<List<ZipCodeData>>.Instance;

            List<ZipCodeData> cacheAppItems = null;

            string cacheKey = string.Format("KEY_ALL_ZIPCODES_WITH_{0}", column.ToUpper());
            if (cacheList.TryGet(cacheKey, out cacheAppItems))
            {
                return cacheAppItems;
            }

            cacheAppItems = repository.FindAllByColumn(column);
            cacheList.Set(cacheKey, cacheAppItems);
            return cacheAppItems;
        }
    }
}
