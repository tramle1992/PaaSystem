using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Configuration;
using Common.Infrastructure.ApiClient;
using Core.Application.Data.ClientInfo;
using Common.Infrastructure.UI;

namespace PaaApplication.Forms.ClientInfo
{
    public partial class FormClientDataGrid : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormClientDataGrid()
        {
            InitializeComponent();
            InitializeSettings();
        }

        public FormClientDataGrid(List<string> inclusedFilter)
            : this()
        {
            _lstInclusedFilter = inclusedFilter;
        }

        private HttpClient httpClient;
        private List<ClientGridData> _lstClientGridData;
        private List<string> _lstInclusedFilter;

        public void InitializeSettings()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUri"];
            httpClient = ApiClientFactory.GetHttpClient(baseAddress);
            this.clientDataGridControl.InitializeSettings();
        }

        public void Refresh(List<string> inclusedFilter)
        {
            this.LoadData(inclusedFilter);
            this.clientDataGridControl.Refresh(this._lstClientGridData);
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
                            _lstClientGridData = lstClientGridData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void FormClientDataGrid_LoadCompleted(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    if (_lstInclusedFilter != null)
                    {
                        this.Refresh(_lstInclusedFilter);
                    }
                    else
                    {
                        this.Refresh(new List<string>());
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.ToString());
            }

        }

    }
}
