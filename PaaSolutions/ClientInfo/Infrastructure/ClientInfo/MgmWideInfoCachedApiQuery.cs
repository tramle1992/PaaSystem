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
    public class MgmWideInfoCachedApiQuery
    {
        private MgmWideInfoApiRepository mgmWideInfoRepository = new MgmWideInfoApiRepository();

        public static readonly MgmWideInfoCachedApiQuery instance = new MgmWideInfoCachedApiQuery();

        private const string KEY_ALL_CLIENTS = "ALL_CLIENTS";

        static MgmWideInfoCachedApiQuery()
        {
        }

        public static MgmWideInfoCachedApiQuery Instance
        {
            get { return instance; }
        }

        public void Update(ManagementWideInfoUpdates data)
        {
            mgmWideInfoRepository.Update(data);
            TypedObjectCache<List<ClientData>> cacheList = TypedObjectCache<List<ClientData>>.Instance;
            cacheList.Remove(KEY_ALL_CLIENTS);
        }

        

    }
}
