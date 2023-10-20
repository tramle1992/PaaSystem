using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Cache;
using Core.Application.Data.ClientInfo;
using Core.Domain.Model.ClientInfo;

namespace Core.Infrastructure.ClientInfo
{
    public class ManagementCompanyCachedApiQuery
    {

        public static readonly ManagementCompanyCachedApiQuery instance = new ManagementCompanyCachedApiQuery();

        static ManagementCompanyCachedApiQuery()
        {

        }

        public static ManagementCompanyCachedApiQuery Instance
        {
            get { return instance; }
        }
        private const string KEY_ALL_CLIENTS = "ALL_CLIENTS";
        string KEY_MANAGEMENT_COMPANIES = "ALL_MANAGEMENT_COMPANIES";

        private ManagementCompanyApiRepository repository = new ManagementCompanyApiRepository();

        ManagementCompanyRepository managementCompanyRepository = new ManagementCompanyRepository();

        public List<ManagementCompanyData> GetAllManagementCompanies()
        {
            TypedObjectCache<List<ManagementCompanyData>> cacheList = TypedObjectCache<List<ManagementCompanyData>>.Instance;
            TypedObjectCache<ManagementCompanyData> cacheItems = TypedObjectCache<ManagementCompanyData>.Instance;
            bool isCacheStale = false;           

            List<ManagementCompanyData> cacheManagementCompanies = null;
            List<ManagementCompanyData> resultantManagementCompanies = new List<ManagementCompanyData>();

            if (cacheList.TryGet(KEY_MANAGEMENT_COMPANIES, out cacheManagementCompanies))
            {
                foreach (ManagementCompanyData managementCompany in cacheManagementCompanies)
                {
                    ManagementCompanyData managementCompanyInCache = null;
                    if (!cacheItems.TryGet(managementCompany.ManagementCompanyId, out managementCompanyInCache))
                    {
                        isCacheStale = true;
                        break;
                    }
                    else
                    {
                        resultantManagementCompanies.Add(managementCompanyInCache);
                    }
                }
                cacheManagementCompanies = resultantManagementCompanies;
            }

            if (isCacheStale || cacheManagementCompanies == null)
            {               
                List<ManagementCompanyData> managementCompanies = repository.FindAll();
                foreach (ManagementCompanyData managementCompany in managementCompanies)
                {
                    cacheItems.Set(managementCompany.ManagementCompanyId, managementCompany);
                }
                cacheList.Set(KEY_MANAGEMENT_COMPANIES, managementCompanies);
                return managementCompanies;
            }
            else
            {
                return cacheManagementCompanies;
            }
        }

        public void UpdateManagementCompayName(ManagementCompanyData data)
        {
            repository.Update(data);
            TypedObjectCache<List<ClientData>> cacheList = TypedObjectCache<List<ClientData>>.Instance;
            cacheList.Remove(KEY_ALL_CLIENTS);

            TypedObjectCache<List<ManagementCompanyData>> cacheListMgmCompany = TypedObjectCache<List<ManagementCompanyData>>.Instance;
            cacheListMgmCompany.Remove(KEY_MANAGEMENT_COMPANIES);
        }

        public string AddManagementCompany(ManagementCompanyData data)
        {
            string newId = repository.Add(data);

            TypedObjectCache<List<ManagementCompanyData>> cacheListMgmCompany = TypedObjectCache<List<ManagementCompanyData>>.Instance;
            cacheListMgmCompany.Remove(KEY_MANAGEMENT_COMPANIES);

            return newId;
        }
    }
}
