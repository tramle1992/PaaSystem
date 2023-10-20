using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Cache;
using IdentityAccess.Domain.Model.Identity;

namespace IdentityAccess.Infrastructure.Identity
{
    public class UserCachedApiQuery
    {
        private UserApiRepository userApiRepository = new UserApiRepository();

        private static readonly UserCachedApiQuery instance = new UserCachedApiQuery();

        private const string KEY_ALL_USERS = "ALL_USERS";

        static UserCachedApiQuery()
        {
        }

        public static UserCachedApiQuery Instance
        {
            get { return instance; }
        }

        public List<User> GetAllUsers()
        {
            TypedObjectCache<List<User>> cacheList = TypedObjectCache<List<User>>.Instance;
            List<User> cacheUsers = new List<User>();

            if (cacheList.TryGet(KEY_ALL_USERS, out cacheUsers))
            {
                return cacheUsers;
            }

            List<User> users = userApiRepository.FindAll();
            cacheList.Set(KEY_ALL_USERS, users);
            return users;
        }

        public void RemoveAllUsers()
        {
            TypedObjectCache<List<string>> cacheList = TypedObjectCache<List<string>>.Instance;
            cacheList.Remove(KEY_ALL_USERS);
        }

        public List<User> GetActiveUsers()
        {
            TypedObjectCache<List<User>> cacheList = TypedObjectCache<List<User>>.Instance;
            TypedObjectCache<User> cacheItems = TypedObjectCache<User>.Instance;
            bool isCacheStale = false;

            string cacheKey = "ALL_ACTIVE_USERS";

            List<User> cacheUsers = null;
            List<User> resultantUsers = new List<User>();

            this.RemoveAllActiveUsers();

            if (cacheList.TryGet(cacheKey, out cacheUsers))
            {
                foreach (User user in cacheUsers)
                {
                    User userInCache = null;
                    if (!cacheItems.TryGet(user.UserId.Id, out userInCache))
                    {
                        isCacheStale = true;
                        break;
                    }
                    else
                    {
                        resultantUsers.Add(userInCache);
                    }
                }
                cacheUsers = resultantUsers;
            }

            if (isCacheStale || cacheUsers == null)
            {
                List<User> users = userApiRepository.GetActiveUsers();
                foreach (User user in users)
                {
                    cacheItems.Set(user.UserId.Id, user);
                }
                cacheList.Set(cacheKey, users);
                return users;
            }
            else
            {
                return cacheUsers;
            }
        }

        public void RemoveAllActiveUsers()
        {
            TypedObjectCache<List<User>> cacheList = TypedObjectCache<List<User>>.Instance;
            cacheList.Remove("ALL_ACTIVE_USERS");
        }

        public void RefreshCacheActiveUsers()
        {
            TypedObjectCache<List<User>> cacheList = TypedObjectCache<List<User>>.Instance;
            TypedObjectCache<User> cacheItems = TypedObjectCache<User>.Instance;
            bool isCacheStale = false;

            string cacheKey = "ALL_ACTIVE_USERS";

            List<User> cacheUsers = null;
            List<User> resultantUsers = new List<User>();

            this.RemoveAllActiveUsers();

            if (cacheList.TryGet(cacheKey, out cacheUsers))
            {
                foreach (User user in cacheUsers)
                {
                    User userInCache = null;
                    if (!cacheItems.TryGet(user.UserId.Id, out userInCache))
                    {
                        isCacheStale = true;
                        break;
                    }
                    else
                    {
                        resultantUsers.Add(userInCache);
                    }
                }
                cacheUsers = resultantUsers;
            }

            if (isCacheStale || cacheUsers == null)
            {
                List<User> users = userApiRepository.GetActiveUsers();
                foreach (User user in users)
                {
                    cacheItems.Set(user.UserId.Id, user);
                }
                cacheList.Set(cacheKey, users);               
            }            
        }
    }
}
