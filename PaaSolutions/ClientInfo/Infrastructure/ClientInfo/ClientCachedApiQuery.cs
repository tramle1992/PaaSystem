using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Infrastructure.Cache;
using Core.Application.Data.ClientInfo;

namespace Core.Infrastructure.ClientInfo
{
    public class ClientCachedApiQuery
    {
        private ClientApiRepository clientApiRepository = new ClientApiRepository();

        private static readonly ClientCachedApiQuery instance = new ClientCachedApiQuery();

        private const string KEY_ALL_CLIENTS = "ALL_CLIENTS";
        private const string KEY_ALL_CUSTOMER_NUMBERS = "ALL_CUSTOMER_NUMBERS";
        private const string KEY_ALL_INVOICE_DIVISIONS = "ALL_INVOICE_DIVISIONS";

        static ClientCachedApiQuery()
        {
        }

        public static ClientCachedApiQuery Instance
        {
            get { return instance; }
        }

        public List<ClientData> GetAllClients()
        {
            TypedObjectCache<List<ClientData>> cacheList = TypedObjectCache<List<ClientData>>.Instance;
            TypedObjectCache<ClientData> cacheItems = TypedObjectCache<ClientData>.Instance;
            bool isCacheStale = false;

            List<ClientData> cacheClients = null;
            List<ClientData> resultantClients = new List<ClientData>();

            if (cacheList.TryGet(KEY_ALL_CLIENTS, out cacheClients))
            {
                foreach (ClientData client in cacheClients)
                {
                    ClientData clientInCache = null;
                    if (!cacheItems.TryGet(client.ClientId, out clientInCache))
                    {
                        isCacheStale = true;
                        break;
                    }
                    else
                    {
                        resultantClients.Add(clientInCache);
                    }
                }
                cacheClients = resultantClients;
            }

            if (isCacheStale || cacheClients == null)
            {
                List<ClientData> clients = clientApiRepository.FindAll();
                foreach (ClientData client in clients)
                {
                    cacheItems.Set(client.ClientId, client);
                }
                cacheList.Set(KEY_ALL_CLIENTS, clients);
                return clients;
            }
            else
            {
                return cacheClients;
            }
        }

        public void RefreshAllClients()
        {
            TypedObjectCache<List<ClientData>> cacheList = TypedObjectCache<List<ClientData>>.Instance;
            TypedObjectCache<ClientData> cacheItems = TypedObjectCache<ClientData>.Instance;
            bool isCacheStale = false;

            List<ClientData> cacheClients = null;

            if (cacheList.TryGet(KEY_ALL_CLIENTS, out cacheClients))
            {
                foreach (ClientData client in cacheClients)
                {
                    ClientData clientInCache = null;
                    if (!cacheItems.TryGet(client.ClientId, out clientInCache))
                    {
                        isCacheStale = true;
                        break;
                    }
                }
            }

            if (isCacheStale || cacheClients == null)
            {
                List<ClientData> clients = clientApiRepository.FindAll();
                foreach (ClientData client in clients)
                {
                    cacheItems.Set(client.ClientId, client);
                }
                cacheList.Set(KEY_ALL_CLIENTS, clients);
            }
        }

        public ClientData GetClient(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;
            TypedObjectCache<ClientData> cacheItems = TypedObjectCache<ClientData>.Instance;
            ClientData client = null;
            if (!cacheItems.TryGet(id, out client))
            {
                client = clientApiRepository.Find(id);
                cacheItems.Set(id, client);
                RemoveAllClients();
                RemoveAllCustomerNumbers();
                RemoveAllInvoiceDivisions();
            }
            return client;
        }

        public void SetClient(ClientData client)
        {
            TypedObjectCache<ClientData> cacheItems = TypedObjectCache<ClientData>.Instance;
            if (client != null && !string.IsNullOrEmpty(client.ClientId))
            {
                cacheItems.Set(client.ClientId, client);
            }
        }

        public void RemoveAllClients()
        {
            TypedObjectCache<List<ClientData>> cacheList = TypedObjectCache<List<ClientData>>.Instance;
            cacheList.Remove(KEY_ALL_CLIENTS);
        }

        public void RemoveClient(string id)
        {
            TypedObjectCache<ClientData> cacheItems = TypedObjectCache<ClientData>.Instance;
            cacheItems.Remove(id);
            RemoveAllCustomerNumbers();
            RemoveAllInvoiceDivisions();
        }

        public string AddClient(ClientData client)
        {
            RemoveAllClients();
            RemoveAllCustomerNumbers();
            RemoveAllInvoiceDivisions();
            return clientApiRepository.Add(client);
        }

        public void UpdateClient(ClientData client)
        {
            clientApiRepository.Update(client);
            RemoveAllClients();
        }

        public List<string> GetAllCustomerNumbers()
        {
            TypedObjectCache<List<string>> cacheList = TypedObjectCache<List<string>>.Instance;
            List<string> cacheCustomerNumbers = null;

            if (cacheList.TryGet(KEY_ALL_CUSTOMER_NUMBERS, out cacheCustomerNumbers))
            {
                return cacheCustomerNumbers;
            }

            List<string> customerNumbers = clientApiRepository.GetCustomerNumbers();
            cacheList.Set(KEY_ALL_CUSTOMER_NUMBERS, customerNumbers);
            return customerNumbers;
        }

        public void RemoveAllCustomerNumbers()
        {
            TypedObjectCache<List<string>> cacheList = TypedObjectCache<List<string>>.Instance;
            cacheList.Remove(KEY_ALL_CUSTOMER_NUMBERS);
        }

        public List<string> GetAllInvoiceDivisions()
        {
            TypedObjectCache<List<string>> cacheList = TypedObjectCache<List<string>>.Instance;
            List<string> cacheInvoiceDivisions = null;

            if (cacheList.TryGet(KEY_ALL_INVOICE_DIVISIONS, out cacheInvoiceDivisions))
            {
                return cacheInvoiceDivisions;
            }

            List<string> invoiceDivisions = clientApiRepository.GetInvoiceDivisions();
            cacheList.Set(KEY_ALL_INVOICE_DIVISIONS, invoiceDivisions);
            return invoiceDivisions;
        }

        public void RemoveAllInvoiceDivisions()
        {
            TypedObjectCache<List<string>> cacheList = TypedObjectCache<List<string>>.Instance;
            cacheList.Remove(KEY_ALL_INVOICE_DIVISIONS);
        }

    }
}
