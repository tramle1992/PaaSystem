using Common.Infrastructure.ApiClient;
using Common.Infrastructure.UI;
using Core.Application.Data.ClientInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.ClientInfo
{
    public partial class FormClientLabel : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormClientLabel()
        {
            InitializeComponent();
            InitializeSettings();
        }

        public FormClientLabel(List<string> inclusedFilter)
            : this()
        {
            _lstInclusedFilter = inclusedFilter;
            try
            {
                using (new HourGlass())
                {
                    if (_lstInclusedFilter != null && _lstInclusedFilter.Count > 0)
                    {
                        this.Refresh(_lstInclusedFilter);
                    }
                    else
                    {
                        this.Refresh(new List<string>());
                    }
                }
                this.Show();

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private HttpClient httpClient;
        private List<ClientGridData> _lstClientGridData;
        private List<string> _lstInclusedFilter;

        public void InitializeSettings()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUri"];
            httpClient = ApiClientFactory.GetHttpClient(baseAddress);
            this.clientLabelControl.InitializeSettings();
        }

        public void Refresh(List<string> inclusedFilter)
        {
            this.LoadData(inclusedFilter);
            this.clientLabelControl.Refresh(this._lstClientGridData);
        }

        private void LoadData(List<string> inclusedFilter)
        {
            try
            {
                string url = "api/datagrid/clients";
                JsonGetApiClient<List<ClientGridData>> client = new JsonGetApiClient<List<ClientGridData>>(httpClient, url);
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = response.Content.ReadAsStringAsync().Result;
                    List<ClientGridData> lstClientGridData = JsonConvert.DeserializeObject<List<ClientGridData>>(jsonContent);
                    if (lstClientGridData != null)
                    {
                        if (inclusedFilter != null && inclusedFilter.Count > 0)
                        {
                            _lstClientGridData = lstClientGridData.Where<ClientGridData>(o => inclusedFilter.Contains(o.ClientId)).ToList();
                        }
                        else
                        {
                            _lstClientGridData = new List<ClientGridData>();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void FormClientLabel_LoadCompleted(object sender, EventArgs e)
        {
        }
    }
}
