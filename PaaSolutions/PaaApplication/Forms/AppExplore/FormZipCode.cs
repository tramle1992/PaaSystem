using Common.Infrastructure.ComboBoxCustom;
using Common.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZipCodeContext.Application.Data;
using ZipCodeContext.Infrastructure;

namespace PaaApplication.Forms.AppExplore
{
    public partial class FormZipCode : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private DataTable _ZipCodesDataTable;
        private DataTable _ZipCodesDataTableByCountry;
        private DataTable _ZipCodesDataTableByAreaCode;      

        public FormZipCode()
        {
            InitializeComponent();
            Initializing();
        }

        private void Initializing()
        {
            //Init DataTable
            _ZipCodesDataTable = new DataTable();
            this._ZipCodesDataTable.Columns.Add("City", typeof(String));
            this._ZipCodesDataTable.Columns.Add("State", typeof(String));
            this._ZipCodesDataTable.Columns.Add("ZipCodeName", typeof(String));
            this._ZipCodesDataTable.Columns.Add("County", typeof(String));
            this._ZipCodesDataTable.Columns.Add("TimeZoneName", typeof(String));
            this._ZipCodesDataTable.Columns.Add("AreaCode", typeof(String));
        }

        private void FormZipCode_LoadCompleted(object sender, EventArgs e)
        {
            try
            {
                List<ZipCodeData> listAllZipCodes = new List<ZipCodeData>();
                using (new HourGlass())
                {
                    ZipCodeCachedApiQuery zipCodeCachedApiQuery = ZipCodeCachedApiQuery.Instance;

                    if (listAllZipCodes == null || listAllZipCodes.Count == 0)
                    {
                        listAllZipCodes = zipCodeCachedApiQuery.GetAll();
                    }
                }
                this.ConvertToDataTable(listAllZipCodes, _ZipCodesDataTable);

                List<string> listStates = new List<string>();
                listStates = GetListStates();

                if (listStates.Count > 0)
                {
                    foreach (var item in listStates.OrderBy(st=>st))
                    {
                        this.cboState.Items.Add(item);
                        this.cboCounty_State.Items.Add(item);
                    }

                    this.cboState.SelectedIndex = 0;
                    this.cboCounty_State.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);                
            }
        }

        private List<string> GetListStates()
        {
            List<string> result = new List<string>();
            try
            {
                if (_ZipCodesDataTable.Rows.Count > 0)
                {
                    DataView view = new DataView(_ZipCodesDataTable);
                    DataTable distinctValues = view.ToTable(true, "State");

                    foreach (DataRow row in distinctValues.Rows)
                    {
                        result.Add(row["State"].ToString());
                    }

                    result.Insert(0, "<All States>");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);                
            }
            return result;
        }

        private List<string> GetListCitiesByState(string state)
        {
            List<string> result = new List<string>();
            try
            {
                var rowArray = _ZipCodesDataTable.Select(string.Format("State ='{0}'", state), "City ASC");

                if (rowArray.Count() > 0)
                {
                    foreach (DataRow row in rowArray)
                    {
                        string city = row["City"].ToString();
                        if (!result.Contains(city)) result.Add(city);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);                
            }
            return result;
        }

        private List<string> GetListCountyByState(string state)
        {
            List<string> result = new List<string>();
            try
            {
                var rowArray = _ZipCodesDataTable.Select(string.Format("State ='{0}'", state), "County ASC");

                if (rowArray.Count() > 0)
                {
                    foreach (DataRow row in rowArray)
                    {
                        string city = row["County"].ToString();
                        if (!result.Contains(city)) result.Add(city);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);                
            }
            return result;
        }

        private void ConvertToDataTable(List<ZipCodeData> listZipCodes, DataTable db)
        {
            try
            {
                if (listZipCodes != null && listZipCodes.Count > 0)
                {
                    foreach (ZipCodeData data in listZipCodes)
                    {
                        DataRow dr = db.NewRow();
                        dr["City"] = data.City;
                        dr["State"] = data.State;
                        dr["ZipCodeName"] = data.ZipCodeName;
                        dr["County"] = data.County;
                        dr["TimeZoneName"] = data.TimezoneName;
                        dr["AreaCode"] = data.AreaCode;

                        db.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);                
            }
        }

        private void btnFindZipCode_Click(object sender, EventArgs e)
        {
            try
            {
                this.olvZipCode.Items.Clear();
                olvColCounty.IsVisible = false;
                olvColTimeZoneName.IsVisible = false;
                olvColTime.IsVisible = false;
                olvColAreaCode.IsVisible = false;
                olvColZipCodeName.IsVisible = false;

                if (tabSearches.SelectedTab == tabAutoDetect)
                {
                    string searchText = this.txtSearchText.Text;

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        using (new HourGlass())
                        {
                            List<ZipCodeData> result = this.QueryByAllFields(searchText, "ZipCode");

                            if (result != null && result.Count > 0)
                            {
                                olvColZipCodeName.IsVisible = true;
                                this.olvZipCode.SetObjects(result);
                            }
                            else
                            {
                                ShowMessageNoResultFound();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please insert Query Text for querying.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (tabSearches.SelectedTab == tabCityState)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByStateAndCity(true);

                        if (result != null && result.Count > 0)
                        {
                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }
                    }

                    olvColZipCodeName.IsVisible = true;
                }
                else if (tabSearches.SelectedTab == tabCounty)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByStateAndCounty(true);

                        if (result != null && result.Count > 0)
                        {
                            // Set columns visible                           
                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }

                        olvColCounty.IsVisible = true;
                        olvColZipCodeName.IsVisible = true;
                    }
                }
                else if (tabSearches.SelectedTab == tablZipCode)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByZipCode();

                        if (result != null && result.Count > 0)
                        {
                            // Set columns visible

                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }
                    }

                    olvColZipCodeName.IsVisible = true;
                }
                else if (tabSearches.SelectedTab == tabAreaCode)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByAreaCode();

                        if (result != null && result.Count > 0)
                        {
                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }
                    }

                    olvColAreaCode.IsVisible = true;
                    olvColZipCodeName.IsVisible = true;
                }

                this.olvZipCode.RebuildColumns();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);                
            }
        }

        private void btnFindCityStateCounty_Click(object sender, EventArgs e)
        {
            try
            {
                this.olvZipCode.Items.Clear();

                olvColCounty.IsVisible = true;
                olvColTimeZoneName.IsVisible = false;
                olvColTime.IsVisible = false;
                olvColAreaCode.IsVisible = false;
                olvColZipCodeName.IsVisible = false;

                if (tabSearches.SelectedTab == tabAutoDetect)
                {
                    string searchText = this.txtSearchText.Text;

                     if (!string.IsNullOrEmpty(searchText))
                    {
                        using (new HourGlass())
                        {
                            List<ZipCodeData> result = this.QueryByAllFields(searchText, "ALL");

                            if (result != null && result.Count > 0)
                            {
                                olvColCounty.IsVisible = true;
                                this.olvZipCode.SetObjects(result);
                            }
                            else
                            {
                                ShowMessageNoResultFound();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please insert Query Text for querying.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                else if (tabSearches.SelectedTab == tabCityState)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByStateAndCity();

                        if (result != null && result.Count > 0)
                        {
                            // Set columns visible

                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }
                    }
                }
                else if (tabSearches.SelectedTab == tabCounty)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByStateAndCounty();

                        if (result != null && result.Count > 0)
                        {
                            // Set columns visible

                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }
                    }
                    olvColCounty.IsVisible = true;
                }
                else if (tabSearches.SelectedTab == tablZipCode)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByZipCode();

                        if (result != null && result.Count > 0)
                        {
                            // Set columns visible

                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }
                    }
                    olvColZipCodeName.IsVisible = true;
                }
                else if (tabSearches.SelectedTab == tabAreaCode)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByAreaCode();

                        if (result != null && result.Count > 0)
                        {
                            // Set columns visible

                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }
                    }
                    olvColAreaCode.IsVisible = true;
                }
                this.olvZipCode.RebuildColumns();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message); MessageBox.Show(ex.Message);
            }
        }

        private void btnFindTimeOfDay_Click(object sender, EventArgs e)
        {

        }

        private void btnFindAreaCodes_Click(object sender, EventArgs e)
        {
            try
            {
                this.olvZipCode.Items.Clear();

                olvColCounty.IsVisible = false;
                olvColTimeZoneName.IsVisible = false;
                olvColTime.IsVisible = false;
                olvColAreaCode.IsVisible = true;
                olvColZipCodeName.IsVisible = false;

                if (tabSearches.SelectedTab == tabAutoDetect)
                {
                    string searchText = this.txtSearchText.Text;

                    if (!string.IsNullOrEmpty(searchText))
                    {
                        using (new HourGlass())
                        {
                            List<ZipCodeData> result = this.QueryByAllFields(searchText, "Area_Code");

                            if (result != null && result.Count > 0)
                            {
                                olvColCounty.IsVisible = false;
                                this.olvZipCode.SetObjects(result);
                            }
                            else
                            {
                                ShowMessageNoResultFound();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please insert Query Text for querying.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (tabSearches.SelectedTab == tabCityState)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByStateAndCity();

                        if (result != null && result.Count > 0)
                        {
                            // Set columns visible

                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }
                    }
                }
                else if (tabSearches.SelectedTab == tabCounty)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByStateAndCounty();

                        if (result != null && result.Count > 0)
                        {
                            // Set columns visible

                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }
                    }
                    olvColCounty.IsVisible = true;
                }
                else if (tabSearches.SelectedTab == tablZipCode)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByZipCode();

                        if (result != null && result.Count > 0)
                        {
                            // Set columns visible

                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                        }
                    }
                    olvColZipCodeName.IsVisible = true;
                }
                else if (tabSearches.SelectedTab == tabAreaCode)
                {
                    using (new HourGlass())
                    {
                        List<ZipCodeData> result = this.QueryByAreaCode();

                        if (result != null && result.Count > 0)
                        {
                            // Set columns visible

                            this.olvZipCode.SetObjects(result);
                        }
                        else
                        {
                            ShowMessageNoResultFound();
                            olvZipCode.Items.Clear();
                        }
                    }
                    olvColAreaCode.IsVisible = true;
                }

                this.olvZipCode.RebuildColumns();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable GetZipCodesDataTable(string column)
        {
            List<ZipCodeData> listAllZipCodes = new List<ZipCodeData>();
            ZipCodeCachedApiQuery zipCodeCachedApiQuery = ZipCodeCachedApiQuery.Instance;
            if (column.Equals("County"))            
            {
                if (_ZipCodesDataTableByCountry == null)
                {
                    using (new HourGlass())
                    {

                        //Init DataTable
                        _ZipCodesDataTableByCountry = new DataTable();
                        this._ZipCodesDataTableByCountry.Columns.Add("City", typeof(String));
                        this._ZipCodesDataTableByCountry.Columns.Add("State", typeof(String));
                        this._ZipCodesDataTableByCountry.Columns.Add("ZipCodeName", typeof(String));
                        this._ZipCodesDataTableByCountry.Columns.Add("County", typeof(String));
                        this._ZipCodesDataTableByCountry.Columns.Add("TimeZoneName", typeof(String));
                        this._ZipCodesDataTableByCountry.Columns.Add("AreaCode", typeof(String));

                        listAllZipCodes = zipCodeCachedApiQuery.GetAllByColumn(column);
                    }
                    this.ConvertToDataTable(listAllZipCodes, _ZipCodesDataTableByCountry);
                }
                return _ZipCodesDataTableByCountry;
            }
            else if (column.Equals("Area_Code"))
            {
                if (_ZipCodesDataTableByAreaCode == null)
                {
                    using (new HourGlass())
                    {
                        //Init DataTable
                        _ZipCodesDataTableByAreaCode = new DataTable();
                        this._ZipCodesDataTableByAreaCode.Columns.Add("City", typeof(String));
                        this._ZipCodesDataTableByAreaCode.Columns.Add("State", typeof(String));
                        this._ZipCodesDataTableByAreaCode.Columns.Add("ZipCodeName", typeof(String));
                        this._ZipCodesDataTableByAreaCode.Columns.Add("County", typeof(String));
                        this._ZipCodesDataTableByAreaCode.Columns.Add("TimeZoneName", typeof(String));
                        this._ZipCodesDataTableByAreaCode.Columns.Add("AreaCode", typeof(String));

                        listAllZipCodes = zipCodeCachedApiQuery.GetAllByColumn(column);
                    }
                    this.ConvertToDataTable(listAllZipCodes, _ZipCodesDataTableByAreaCode);
                }
                return _ZipCodesDataTableByAreaCode;
            }
            else // search all
            {
                using (new HourGlass())
                {
                    if (_ZipCodesDataTable == null)
                    {
                        //Init DataTable
                        _ZipCodesDataTable = new DataTable();
                        this._ZipCodesDataTable.Columns.Add("City", typeof(String));
                        this._ZipCodesDataTable.Columns.Add("State", typeof(String));
                        this._ZipCodesDataTable.Columns.Add("ZipCodeName", typeof(String));
                        this._ZipCodesDataTable.Columns.Add("County", typeof(String));
                        this._ZipCodesDataTable.Columns.Add("TimeZoneName", typeof(String));
                        this._ZipCodesDataTable.Columns.Add("AreaCode", typeof(String));

                        listAllZipCodes = zipCodeCachedApiQuery.GetAllByColumn(column);
                    }
                    this.ConvertToDataTable(listAllZipCodes, _ZipCodesDataTable);
                }
                   
            }
            return _ZipCodesDataTable;
        }

        private List<ZipCodeData> QueryByAllFields(string searchText, string column)
        {
            List<ZipCodeData> lstResult = new List<ZipCodeData>();
            try
            {
                var dtb = GetZipCodesDataTable(column);
                var rowArray = dtb.Select(string.Format("City like '{0}%' OR ZipCodeName like '{0}%' OR AreaCode like '{0}%'", searchText), "City, State, AreaCode, ZipCodeName, County ASC");
              
                if (rowArray.Count() > 0)
                {
                    foreach (DataRow row in rowArray)
                    {
                        ZipCodeData zc = new ZipCodeData();
                        zc.City = row["City"].ToString();
                        zc.State = row["State"].ToString();
                        zc.ZipCodeName = row["ZipCodeName"].ToString();
                        zc.County = row["County"].ToString();
                        zc.TimezoneName = row["TimeZoneName"].ToString();
                        zc.AreaCode = row["AreaCode"].ToString();

                        lstResult.Add(zc);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);
            }

            return lstResult;
        }

        private List<ZipCodeData> QueryByStateAndCity(bool isNeedZipCodeName = false)
        {
            List<ZipCodeData> result = new List<ZipCodeData>();

            try
            {
                string city = "";

                city = this.cboCity.Text;

                string state = this.cboState.SelectedItem.ToString();

                if (state.Equals("<All States>"))
                {
                    city = cboCity.Text;

                    if (string.IsNullOrEmpty(city))
                    {
                        MessageBox.Show("You must type a City when looking in All States.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return result;
                    }

                    var rowArray = _ZipCodesDataTable.Select(string.Format("City like '{0}%'", city), "City, State, AreaCode, ZipCodeName, County ASC");

                    if (rowArray.Count() > 0)
                    {
                        foreach (DataRow row in rowArray)
                        {
                            ZipCodeData zc = new ZipCodeData();
                            zc.City = row["City"].ToString();
                            zc.State = row["State"].ToString();
                            zc.ZipCodeName = row["ZipCodeName"].ToString();
                            zc.County = row["County"].ToString();
                            zc.TimezoneName = row["TimeZoneName"].ToString();
                            zc.AreaCode = row["AreaCode"].ToString();

                            result.Add(zc);
                        }
                    }
                }
                else
                {
                    var rowArray = _ZipCodesDataTable.Select(string.Format("State = '{0}' AND City like '{1}%'", state, city), "City ASC");

                    if (rowArray.Count() > 0)
                    {
                        foreach (DataRow row in rowArray)
                        {
                            ZipCodeData zc = new ZipCodeData();
                            zc.City = row["City"].ToString();
                            zc.State = row["State"].ToString();
                            if (isNeedZipCodeName)
                            {
                                zc.ZipCodeName = row["ZipCodeName"].ToString();
                            }
                            zc.County = row["County"].ToString();
                            zc.TimezoneName = row["TimeZoneName"].ToString();
                            zc.AreaCode = row["AreaCode"].ToString();

                            if (result != null
                                && !result.Exists(a => a.AreaCode == zc.AreaCode && a.City == zc.City && a.County == zc.County && a.State == zc.State)
                                || isNeedZipCodeName)
                            {
                                result.Add(zc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        private List<ZipCodeData> QueryByStateAndCounty(bool isNeedZipCodeName = false)
        {
            List<ZipCodeData> result = new List<ZipCodeData>();

            try
            {
                string county = "";

                county = this.cboCounty.Text;

                string state = this.cboCounty_State.SelectedItem.ToString();

                if (state.Equals("<All States>"))
                {
                    county = cboCounty.Text;

                    if (string.IsNullOrEmpty(county))
                    {
                        MessageBox.Show("You must type a County when looking in All States.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return result;
                    }

                    var rowArray = _ZipCodesDataTable.Select(string.Format("County like '{0}%'", county), "City, State, AreaCode, ZipCodeName, County ASC");

                    if (rowArray.Count() > 0)
                    {
                        foreach (DataRow row in rowArray)
                        {
                            ZipCodeData zc = new ZipCodeData();
                            zc.City = row["City"].ToString();
                            zc.State = row["State"].ToString();
                            zc.ZipCodeName = row["ZipCodeName"].ToString();
                            zc.County = row["County"].ToString();
                            zc.TimezoneName = row["TimeZoneName"].ToString();
                            zc.AreaCode = row["AreaCode"].ToString();

                            result.Add(zc);
                        }
                    }
                }
                else
                {
                    var rowArray = _ZipCodesDataTable.Select(string.Format("State = '{0}' AND County like '{1}%'", state, county), "City ASC");
                    
                    if (rowArray.Count() > 0)
                    {
                        foreach (DataRow row in rowArray)
                        {
                            ZipCodeData zc = new ZipCodeData();
                            zc.City = row["City"].ToString();
                            zc.State = row["State"].ToString();
                            if (isNeedZipCodeName)
                            {
                                zc.ZipCodeName = row["ZipCodeName"].ToString();
                            }
                            zc.County = row["County"].ToString();
                            zc.TimezoneName = row["TimeZoneName"].ToString();
                            zc.AreaCode = row["AreaCode"].ToString();

                            if (result != null 
                                && !result.Exists(a=>a.AreaCode == zc.AreaCode && a.City == zc.City && a.County == zc.County && a.State == zc.State)
                                || isNeedZipCodeName)
                            {
                                result.Add(zc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        private List<ZipCodeData> QueryByZipCode()
        {
            List<ZipCodeData> results = new List<ZipCodeData>();
            try
            {
                string zipCode = this.txtZipCode.Text;

                if (string.IsNullOrEmpty(zipCode))
                {
                    olvZipCode.Items.Clear();
                    MessageBox.Show("Please insert ZipCode for querying.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return results;
                }

                var rowArray = _ZipCodesDataTable.Select(string.Format("ZipCodeName like '{0}%'", zipCode), "City, State, AreaCode, ZipCodeName, County ASC");

                if (rowArray.Count() > 0)
                {
                    foreach (DataRow row in rowArray)
                    {
                        ZipCodeData zc = new ZipCodeData();
                        zc.City = row["City"].ToString();
                        zc.State = row["State"].ToString();
                        zc.ZipCodeName = row["ZipCodeName"].ToString();
                        zc.County = row["County"].ToString();
                        zc.TimezoneName = row["TimeZoneName"].ToString();
                        zc.AreaCode = row["AreaCode"].ToString();

                        results.Add(zc);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
            return results;
        }

        private List<ZipCodeData> QueryByAreaCode()
        {
            List<ZipCodeData> results = new List<ZipCodeData>();
            try
            {
                string areaCode = this.txtAreaCode.Text;

                if (string.IsNullOrEmpty(areaCode))
                {
                    MessageBox.Show("Please insert Area Code for querying.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return results;
                }

                var rowArray = _ZipCodesDataTable.Select(string.Format("AreaCode like '{0}%'", areaCode), "City, State, AreaCode, ZipCodeName, County ASC");

                if (rowArray.Count() > 0)
                {
                    foreach (DataRow row in rowArray)
                    {
                        ZipCodeData zc = new ZipCodeData();
                        zc.City = row["City"].ToString();
                        zc.State = row["State"].ToString();
                        zc.ZipCodeName = row["ZipCodeName"].ToString();
                        zc.County = row["County"].ToString();
                        zc.TimezoneName = row["TimeZoneName"].ToString();
                        zc.AreaCode = row["AreaCode"].ToString();

                        results.Add(zc);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);
            }
            return results;
        }

        private void ShowMessageNoResultFound()
        {
            this.olvZipCode.Items.Clear();
            MessageBox.Show("No information was found.", "No Result Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = (sender as ComboBox).SelectedItem.ToString();

            cboCity.Items.Clear();
            cboCity.Text = "";

            if (selectedState.Equals("<All States>"))
            {
                return;
            }

            List<string> listCities = this.GetListCitiesByState(selectedState);

            if (listCities.Count > 0)
            {
                foreach (var item in listCities)
                {
                    this.cboCity.Items.Add(item);
                }

                this.cboCity.SelectedIndex = 0;
            }
        }

        private void cboCounty_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = (sender as ComboBox).SelectedItem.ToString();
            cboCounty.Items.Clear();
            cboCounty.Text = "";

            if (selectedState.Equals("<All States>"))
            {
                return;
            }

            List<string> listCounties = this.GetListCountyByState(selectedState);

            if (listCounties.Count > 0)
            {
                foreach (var item in listCounties)
                {
                    this.cboCounty.Items.Add(item);
                }

                this.cboCounty.SelectedIndex = 0;
            }
        }

        void cboState_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            ComboBoxService cbo = new ComboBoxService();
            cbo.AutoComplete(cboState, e, false);
        }

        private void txtSearchText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindCityStateCounty_Click(sender, e);
            }
        }

        private void txtZipCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindZipCode_Click(sender, e);
            }
        }

        private void txtAreaCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindZipCode_Click(sender, e);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.Z:
                    btnFindZipCode_Click(this, null);
                    return true;
                case Keys.Alt | Keys.C:
                    btnFindCityStateCounty_Click(this, null);
                    return true;
                case Keys.Alt | Keys.T:
                    // will implement later
                    return true;
                case Keys.Alt | Keys.A:
                    btnFindAreaCodes_Click(this, null);
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
