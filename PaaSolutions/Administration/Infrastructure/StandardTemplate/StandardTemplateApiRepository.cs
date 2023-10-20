using Administration.Application.Command.StandardTemplate;
using Administration.Domain.Model.StandardTemplate;
using Common.Infrastructure.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Infrastructure.StandardTemplate
{
    public class StandardTemplateApiRepository : ApiRepository<TemplateItem, string>
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public StandardTemplateApiRepository()
            : base()
        {
        }

        public override string Add(TemplateItem item)
        {
            string newId = "";
            try
            {
                string url = string.Format("api/standardtemplates");

                NewTemplateItemCommand command = new NewTemplateItemCommand(item.ParentId, item.Name,
                    item.Caption, item.Index);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                newId = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Standard Template Add API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return newId;
        }

        public override void Remove(TemplateItem item)
        {
            try
            {
                string url = string.Format("api/standardtemplates/delete");

                RemoveTemplateItemCommand command = new RemoveTemplateItemCommand(item.TemplateItemId.Id);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Standard Template Remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void MultiRemove(List<TemplateItem> itemList)
        {
            try
            {
                string url = string.Format("api/standardtemplates/deletemulti");

                List<RemoveTemplateItemCommand> commandList = new List<RemoveTemplateItemCommand>(itemList.Count);
                foreach (TemplateItem item in itemList)
                {
                    commandList.Add(new RemoveTemplateItemCommand(item.TemplateItemId.Id));
                }

                string content = JsonConvert.SerializeObject(new RemoveMultiTemplateItemCommand(commandList));
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Standard Template multi-remove API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override void Update(TemplateItem item)
        {
            try
            {
                string url = string.Format("api/standardtemplates");

                SaveTemplateItemCommand command = new SaveTemplateItemCommand(item.TemplateItemId.Id, item.ParentId.Id,
                    item.Name, item.Caption, item.Index);

                string content = JsonConvert.SerializeObject(command);
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error - Standard Template Update API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public override TemplateItem Find(string id)
        {
            TemplateItem item = null;
            try
            {
                string url = string.Format("api/standardtemplates/{0}", id);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<TemplateItem>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Standard Template Find API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return item;
        }

        public IList<TemplateItem> FindAll()
        {
            List<TemplateItem> items = new List<TemplateItem>();
            try
            {
                string url = string.Format("api/standardtemplates");

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<TemplateItem>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Standard Template Find All API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return items;
        }

        public IList<TemplateItem> FindChildren(string rootId)
        {
            List<TemplateItem> items = new List<TemplateItem>();
            try
            {
                string url = string.Format("api/standardtemplates/children/" + rootId);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<TemplateItem>>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Standard Template FindChildren API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return items;
        }

        public TemplateItem FindByParentAndName(string parentId, string name)
        {
            TemplateItem item = null;
            try
            {
                string url = string.Format("api/standardtemplates/{0}/{1}", parentId, name);

                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<TemplateItem>(jsonContent);
                }
                else
                {
                    _logger.Error("Error - Standard Template FindByParentAndName API: " + url);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return item;
        }
    }
}
