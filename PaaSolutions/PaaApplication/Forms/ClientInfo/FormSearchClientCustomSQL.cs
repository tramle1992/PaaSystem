using Common.Infrastructure.ApiClient;
using Common.Infrastructure.UI;
using Core.Application.Common.ClientInfo;
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
    public partial class FormSearchClientCustomSQL : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<string> typeNameData = null;
        public List<ClientData> ClientData { get; set; }

        private HttpClient httpClient;

        public event EventHandler<List<string>> OnClickSearchButton;
        public event EventHandler OnClickCancelButton;

        public FormSearchClientCustomSQL()
        {
            InitializeComponent();
            InitializeSettings();
        }

        private void FormSearchClientCustom_LoadCompleted(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    LoadListBoxColumns();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void InitializeSettings()
        {
            string baseAddress = ConfigurationManager.AppSettings["ApiUri"];
            httpClient = ApiClientFactory.GetHttpClient(baseAddress);
        }

        #region Button events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string conditions = txtConditions.Text.Trim();
            List<string> result;

            try
            {
                using (new HourGlass())
                {
                    if (!string.IsNullOrEmpty(conditions))
                    {
                        result = GetClientData.SearchClientCustomSQL(this.ClientData, txtConditions.Text);
                    }
                    else
                    {
                        result = (from client in this.ClientData
                                  select client.ClientId).ToList<string>();
                    }
                    if (this.OnClickSearchButton != null)
                    {
                        this.OnClickSearchButton(this, result);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show("SQL Query incorrect.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConditions.Focus();
                return;
            }

            this.Hide();
            if (this.OnClickCancelButton != null)
            {
                this.OnClickCancelButton(this, null);
            }
        }
        #endregion

        private void lstColumns_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtConditions.AppendText(lstColumns.Text);
            txtConditions.Focus();
        }

        private void LoadListBoxColumns()
        {
            try
            {
                if (typeNameData == null)
                {
                    typeNameData = SearchClientCustomSQL.GetAllTypes();
                }
                lstColumns.Items.Clear();
                foreach (string item in typeNameData)
                {
                    lstColumns.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        private string StandardizedConditions()
        {
            string conditions = txtConditions.Text.Trim();
            if (!string.IsNullOrEmpty(conditions))
            {
                // Replace TypeName To ColumnName
                StringBuilder sb = new StringBuilder();
                foreach (string typeName in typeNameData)
                {
                    int lineIndex = conditions.IndexOf(typeName, 0);
                    while (lineIndex > -1)
                    {
                        string columnName = SearchClientCustomSQL.GetColumnNameByTypeName(typeName);
                        if (columnName.IndexOf('_') == -1)
                        {
                            break;
                        }

                        int markIndex = lineIndex;
                        lineIndex += typeName.Length;
                        while (lineIndex < conditions.Length)
                        {
                            if (conditions[lineIndex].Equals(' '))
                            {
                                lineIndex += 1;
                            }
                            else if (conditions[lineIndex].Equals('='))
                            {
                                sb.Clear();
                                sb.Append(conditions);
                                sb.Replace(typeName, columnName, markIndex, typeName.Length);
                                conditions = sb.ToString();
                                lineIndex = markIndex + columnName.Length;
                                break;
                            }
                            else
                            {
                                lineIndex += typeName.Length;
                                break;
                            }
                        }
                        lineIndex = conditions.IndexOf(typeName, lineIndex);
                    }
                }

                // Escape
                conditions = conditions.Replace("'", "''");
            }
            return conditions;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.O:
                    this.btnSearch_Click(this, null);
                    return true;
                case Keys.Alt | Keys.C:
                    this.btnCancel_Click(this, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

}
