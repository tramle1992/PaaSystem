using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Cache;
using Core.Application.Data.ClientInfo;

namespace Core.Infrastructure.ClientInfo
{
    public class ReportTypeCachedApiQuery
    {
        private ReportTypeApiRepository reportTypeApiRepository = new ReportTypeApiRepository();

        private static readonly ReportTypeCachedApiQuery instance = new ReportTypeCachedApiQuery();

        private const string KEY_ALL_REPORT_TYPES = "ALL_REPORT_TYPES";

        static ReportTypeCachedApiQuery()
        {
        }

        public static ReportTypeCachedApiQuery Instance
        {
            get { return instance; }
        }


        public List<ReportTypeData> GetAllReportTypes()
        {
            TypedObjectCache<List<ReportTypeData>> cacheList = TypedObjectCache<List<ReportTypeData>>.Instance;
            TypedObjectCache<ReportTypeData> cacheItems = TypedObjectCache<ReportTypeData>.Instance;
            bool isCacheStale = false;

            List<ReportTypeData> cacheReportTypes = null;
            List<ReportTypeData> resultantReportTypes = new List<ReportTypeData>();

            if (cacheList.TryGet(KEY_ALL_REPORT_TYPES, out cacheReportTypes))
            {
                foreach (ReportTypeData reportType in cacheReportTypes)
                {
                    ReportTypeData reportTypeInCache = null;
                    if (!cacheItems.TryGet(reportType.ReportTypeId, out reportTypeInCache))
                    {
                        isCacheStale = true;
                        break;
                    }
                    else
                    {
                        resultantReportTypes.Add(reportTypeInCache);
                    }
                }
                cacheReportTypes = resultantReportTypes;
            }

            if (isCacheStale || cacheReportTypes == null)
            {
                List<ReportTypeData> reportTypes = reportTypeApiRepository.FindAll();
                foreach (ReportTypeData reportType in reportTypes)
                {
                    cacheItems.Set(reportType.ReportTypeId, reportType);
                }
                cacheList.Set(KEY_ALL_REPORT_TYPES, reportTypes);
                return reportTypes;
            }
            else
            {
                return cacheReportTypes;
            }
        }

        public ReportTypeData GetReportType(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;
            TypedObjectCache<ReportTypeData> cacheItems = TypedObjectCache<ReportTypeData>.Instance;
            ReportTypeData reportType = null;
            if (!cacheItems.TryGet(id, out reportType))
            {
                reportType = reportTypeApiRepository.Find(id);
                cacheItems.Set(id, reportType);
                RemoveAllReportTypes();
            }
            return reportType;
        }

        public void RemoveAllReportTypes()
        {
            TypedObjectCache<List<ReportTypeData>> cacheList = TypedObjectCache<List<ReportTypeData>>.Instance;
            cacheList.Remove(KEY_ALL_REPORT_TYPES);
        }

        public void RemoveReportType(string id)
        {
            TypedObjectCache<ReportTypeData> cacheItems = TypedObjectCache<ReportTypeData>.Instance;
            cacheItems.Remove(id);
        }
    }
}
