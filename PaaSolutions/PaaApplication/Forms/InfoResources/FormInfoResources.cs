using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaaApplication.Models;
using BrightIdeasSoftware;
using Common.Infrastructure.ApiClient;
using System.Configuration;
using System.Net.Http;
using InfoResource.Application.Data;
using Newtonsoft.Json;
using PaaApplication.Forms;
using InfoResource.Application.Command;
using System.Diagnostics;
using System.Collections;
using Common.Infrastructure.OLV;
using Common.Infrastructure.Office;
using System.IO;
using Common.Application.DialogMessage;
using System.Text.RegularExpressions;
using Common.Infrastructure.UI;
using PaaApplication.Models.Common;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Infrastructure.Access;
using IdentityAccess.Domain.Model.Access;
using IdentityAccess.Infrastructure.Authorization;
using InfoResource.Infrastructure.InfoResource;
using PaaApplication.Helper;
using Common.Infrastructure.Helper;


namespace PaaApplication
{
    public partial class FormInfoResources : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private InfoResourceApiRepository infoResourceApiRepository = new InfoResourceApiRepository();
        private InfoResourceCachedApiQuery infoResourceCachedApiQuery = InfoResourceCachedApiQuery.Instance;

        private static List<Form> formList = new List<Form>();
        FormMaster formMaster;

        private InfoResourceType _currentType;
        private ObjectListViewService _olvService = new ObjectListViewService();
        private bool currentUserHasPermissionDelete = true;
        private OLVColumn _selectedColumn;

        private List<ResourceData> selectedResources = new List<ResourceData>();

        private Timer timer = new Timer();

        public InfoResourceType CurrentType
        {
            get { return _currentType; }
            set { this._currentType = value; }
        }

        private static Dictionary<InfoResourceType, int> currentTypeIndex = new Dictionary<InfoResourceType, int>();

        public FormInfoResources(FormMaster master)
        {
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            InitializeComponent();
            InitializeSettings();
            this.formMaster = master;
            formList.Add(this);
            this.infoResourcesRibbon.DoclibClick += DoclibClickHandler;
            this.infoResourcesRibbon.CriminalClick += CriminalClickHandler;
            this.infoResourcesRibbon.LandlordContactClick += LandlordContactClickHandler;
            this.infoResourcesRibbon.EmploymentClick += EmploymentClickHandler;
            this.infoResourcesRibbon.RefreshClick += RefreshClickHandler;

            string message = (olvInfoResources.Items.Count > 0) ? string.Format("{0} Resources. In View", olvInfoResources.Items.Count) : string.Empty;
            SetAppCount(message);
        }

        public void InitializeSettings()
        {
            this.olvInfoResources.ShowImagesOnSubItems = true;

            this.olvInfoResources.CellToolTip.Font = new Font("Tahoma", 10);

            this.olvcolBtnRemove.ImageGetter = delegate(object row)
            {
                return 0;
            };

            this.olvcolBtnRemove.AspectGetter = delegate(object row)
            {
                return string.Empty;
            };

            this.olvcolBtnEdit.ImageGetter = delegate(object row)
            {
                return 1;
            };

            this.olvcolBtnEdit.AspectGetter = delegate(object row)
            {
                return string.Empty;
            };
        }

        public void LoadData()
        {
            using (new HourGlass())
            {
                List<ResourceData> resourceData = GetResourceByType(_currentType);
                if (resourceData != null)
                {
                    olvInfoResources.SetObjects(resourceData.OrderBy(a=>a.Name));
                }

                if (resourceData.Count > 0)
                {
                    if (olvInfoResources.SelectedIndex < 0)
                    {
                        olvInfoResources.SelectedIndex = 0;
                    }
                    else
                    {
                        int currentIndex = 0;
                        currentTypeIndex.TryGetValue(_currentType, out currentIndex);                        
                        olvInfoResources.SelectedIndex = currentIndex;                        
                    }
                }
            }
        }

        public void RefreshData()
        {
            int selectedIndex = this.olvInfoResources.SelectedIndex;

            List<ResourceData> listDisplayedItems = this.GetListAllItems();

            InfoResourceCachedApiQuery infoResourceCachedApiQuery = InfoResourceCachedApiQuery.Instance;
            infoResourceCachedApiQuery.RemoveAllInfoResources();
            formMaster.LIST_INFO_RESOURCES = infoResourceCachedApiQuery.GetAllResourceItems();

            List<ResourceData> resourceData = formMaster.LIST_INFO_RESOURCES;

            if (resourceData.Count == 0)
            {
                if (listDisplayedItems.Count > 0)
                {
                    olvInfoResources.Items.Clear();
                }
            }
            else
            {
                if (listDisplayedItems.Count > 0)
                {
                    List<string> itemIds = new List<string>();
                    foreach (var rs in listDisplayedItems)
                    {
                        string id = rs.ResourceId;
                        if (!itemIds.Contains(id))
                        {
                            itemIds.Add(id);
                        }
                    }

                    Dictionary<string, ResourceData> dic = new Dictionary<string, ResourceData>();

                    if (resourceData.Count > 0)
                    {
                        foreach (ResourceData item in resourceData)
                        {
                            dic.Add(item.ResourceId, item);
                        }
                    }

                    // Update displayed apps on App Explore
                    for (int i = 0; i < olvInfoResources.Items.Count; i++)
                    {
                        ResourceData rsData = (ResourceData)olvInfoResources.GetModelObject(i);
                        if (rsData != null)
                        {
                            if (dic.ContainsKey(rsData.ResourceId))
                            {
                                SetPropertiesForItemReference(rsData, dic[rsData.ResourceId]);
                                olvInfoResources.RefreshObject(rsData);
                            }
                            else
                            {
                                olvInfoResources.RemoveObject(rsData);
                            }
                        }
                    }

                    // Add new object that created by other session
                    foreach (var rsId in dic.Keys)
                    {
                        if (!rsId.Contains(rsId))
                        {
                            olvInfoResources.AddObject(dic[rsId]);
                        }
                    }

                    olvInfoResources.SelectedIndex = selectedIndex;
                }
            }
        }

        private void SetPropertiesForItemReference(ResourceData referencedResource, ResourceData updatedResource)
        {
            referencedResource.Comment = updatedResource.Comment;
            referencedResource.Name = updatedResource.Name;
            referencedResource.ResourceId = updatedResource.ResourceId;
            referencedResource.Phone = updatedResource.Phone;
            referencedResource.Email = updatedResource.Email;
            referencedResource.ResourceTypeData.Name = updatedResource.ResourceTypeData.Name;
            referencedResource.ResourceTypeData.ResourceTypeId = updatedResource.ResourceTypeData.ResourceTypeId;

            referencedResource.Target = updatedResource.Target;
        }

        public List<ResourceData> GetListAllItems()
        {
            List<ResourceData> items = new List<ResourceData>();

            if (this.olvInfoResources.Objects == null || this.olvInfoResources.GetItemCount() == 0)
            {
                return items;
            }

            foreach (ResourceData rs in this.olvInfoResources.Objects)
            {
                if (rs != null && !string.IsNullOrEmpty(rs.ResourceId))
                {
                    items.Add(rs);
                }
            }

            return items;
        }

        public List<ResourceData> GetResourceByType(InfoResourceType resourceType)
        {
            try
            {
                List<ResourceData> resourceList = formMaster.LIST_INFO_RESOURCES;

                List<ResourceData> result = (from resource in resourceList
                                             where resource.ResourceTypeData.Name == resourceType.ToString()
                                             select resource).ToList<ResourceData>();
                if (result != null && result.Count > 0)
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return null;
        }

        public void DeleteResource()
        {
            try
            {
                if (!currentUserHasPermissionDelete) return;
                ResourceData item = olvInfoResources.SelectedObject as ResourceData;
                if (item == null) return;

                DialogMessage msg = DialogMessageFactory.BuildDialogMessage(DialogMessageType.ConfirmationType.Delete);
                if (msg.Show() == System.Windows.Forms.DialogResult.Yes)
                {
                    using (new HourGlass())
                    {
                        int index = this.olvInfoResources.SelectedIndex;
                        infoResourceApiRepository.Remove(item);
                        infoResourceCachedApiQuery.RemoveResourceItem(item.ResourceId);
                        this.olvInfoResources.RemoveObject(item);

                        if (this.olvInfoResources.Items.Count > 0)
                        {
                            index = index.Equals(this.olvInfoResources.Items.Count) ? index - 1 : index;
                            this.olvInfoResources.SelectedIndex = index;
                            this.olvInfoResources.EnsureVisible(index);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Unable to delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Control Events

        private void olvInfoResources_CellClick(object sender, CellClickEventArgs e)
        {
            try
            {
                _selectedColumn = e.Column;

                if (e.Column == olvcolBtnRemove)
                {
                    this.DeleteResource();
                }
                else if (e.Column == olvcolBtnEdit)
                {
                    ResourceData selectedResource = olvInfoResources.SelectedObject as ResourceData;
                    if (selectedResource == null)
                    {
                        return;
                    }
                    FormEditInfoResources form = new FormEditInfoResources();
                    form.ResourceId = selectedResource.ResourceId;
                    form.ResourceName = selectedResource.Name;
                    form.Other = selectedResource.Comment;
                    form.Target = selectedResource.Target;
                    form.Phone = selectedResource.Phone;
                    form.Email = selectedResource.Email;
                    form.ResourceType = selectedResource.ResourceTypeData;
                    form.CurrentType = _currentType;

                    form.StartPosition = FormStartPosition.CenterParent;
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        selectedResource.Name = form.ResourceName;
                        selectedResource.Target = form.Target;
                        selectedResource.Comment = form.Other;
                        selectedResource.Phone = form.Phone;
                        selectedResource.Email = form.Email;
                        this.olvInfoResources.RefreshObject(selectedResource);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormAddNewResource form = new FormAddNewResource();
                form.StartPosition = FormStartPosition.CenterParent;
                form.CurrentType = _currentType;

                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ResourceData data = new ResourceData();
                    data.ResourceId = form.ResourceId;
                    data.Name = form.ResourceName;
                    data.Target = form.Target;
                    data.Comment = form.Other;
                    data.Phone = form.Phone;
                    data.Email = form.Email;
                    data.ResourceTypeData = form.ResourceType;

                    this.olvInfoResources.AddObject(data);
                    this.olvInfoResources.SelectObject(data, true);
                    this.olvInfoResources.EnsureModelVisible(data);
                    if (formMaster.LIST_INFO_RESOURCES != null && !formMaster.LIST_INFO_RESOURCES.Contains(data))
                    {
                        formMaster.LIST_INFO_RESOURCES.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void olvInfoResources_IsHyperlink(object sender, IsHyperlinkEventArgs e)
        {
            if (!IsWebsiteString(e.Text.ToLowerInvariant()))
            {
                e.Url = null; // no hyperlink
            }
            else
            {
                e.Url = e.Text;
            }
        }

        private void olvInfoResources_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ResourceData selectedResource = ((ResourceData)olvInfoResources.SelectedObject);
            var target = selectedResource.Target;

            if (!IsWebsiteString(target))
            {
                if (!string.IsNullOrEmpty(target) &&
                Regex.IsMatch(target,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    OutlookService outlook = new OutlookService();
                    using (new HourGlass())
                    {
                        outlook.SetTo(target);
                        outlook.Display();
                    }
                }
                else if (IsStringFilePath(target))
                {
                    OpenFileFromSource(target);
                }
                else if (IsValidNumberString(target) && !String.IsNullOrEmpty(target) && _currentType != InfoResourceType.Document)
                {
                    OpenTemplate(_currentType, selectedResource);
                }
            }
        }

        private void olvInfoResources_ItemsChanged(object sender, EventArgs arg)
        {
            if (formMaster != null)
            {
                string message = (olvInfoResources.Items.Count > 0) ? string.Format("{0} Resources In View", olvInfoResources.Items.Count) : string.Empty;
                this.SetAppCount(message);
            }
        }

        private void olvInfoResources_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            if (e.Column == olvcolComment)
            {
                ResourceData resource = (ResourceData)e.Model;
                e.Text = string.Format(resource.Comment);
            }
            else if (e.Column == olvcolBtnRemove) e.Text = "Delete Item";

            else if (e.Column == olvcolBtnEdit) e.Text = "View / Edit Item Detail";
        }

        private void olvInfoResources_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                olvInfoResources_MouseDoubleClick(sender, null);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            string strSearch = (sender as TextBox).Text;
            string selectedText = (sender as TextBox).SelectedText;

            if (e.KeyCode == Keys.Back && strSearch.Length <= 1 || (selectedText.Length == strSearch.Length))
            {
                strSearch = string.Empty;
                new ObjectListViewService().FilterOlv(this.olvInfoResources, strSearch);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                new ObjectListViewService().FilterOlv(this.olvInfoResources, strSearch);
            }
        }

        private void FormInfoResources_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                CheckPermission();
                if (this.formMaster != null)
                {
                    string message = (olvInfoResources.Items.Count > 0) ? string.Format("{0} Resources In View", olvInfoResources.Items.Count) : string.Empty;
                    this.SetAppCount(message);
                }
            }
        }

        #endregion

        #region Open file / templates

        private void OpenFileFromSource(string filePath)
        {
            try
            {
                string fileNameNoExtension = Path.GetFileNameWithoutExtension(filePath);
                string fileName = Path.GetFileName(filePath);
                string fileExtension = Path.GetExtension(filePath);

                TemplateHelper templateHelper = new TemplateHelper();
                string newFileName = string.Format("{0}-{1}{2}", fileNameNoExtension, DateTime.UtcNow.ToString("yyyyMMddHHmmssffff"), fileExtension);
                string savePath = string.Format("{0}\\{1}", System.IO.Path.GetTempPath(), newFileName);
                if (!string.IsNullOrEmpty(newFileName))
                {
                    string url = string.Format("api/templates");
                    templateHelper.DownloadTemplate(savePath, fileName);
                }

                if (File.Exists(savePath))
                {
                    if (Path.GetExtension(savePath) == ".dot" || Path.GetExtension(savePath) == ".doc" ||
                        Path.GetExtension(savePath) == ".docx" || Path.GetExtension(savePath) == ".dotx")
                    {
                        string sFileExtension = "docx";
                        string toSaveFileName = Path.GetFileNameWithoutExtension(savePath);
                        WordService word = new WordService(savePath, toSaveFileName, false);
                        string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
                        DocumentCompleteResult documentCompleteResult = new DocumentCompleteResult(tempFilePath, word, string.Empty);
                        FormDocumentComplete formDocumentComplete = new FormDocumentComplete(null, documentCompleteResult);
                        formDocumentComplete.StartPosition = FormStartPosition.CenterParent;
                        formDocumentComplete.ShowDialog();
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(filePath);
                    }
                }
                else
                {
                    MessageBox.Show("Sorry we can not open this file. Please make sure file name or path is correct. ", "Can't open file!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        private void OpenTemplate(InfoResourceType resourceType, ResourceData resource)
        {
            WordDocumentType documentType = WordDocumentType.InfoResourceCourtInfo;
            string templatePath = "";
            WordService word = null;
            try
            {
                switch (resourceType)
                {
                    case InfoResourceType.CourtInfo:
                        documentType = WordDocumentType.InfoResourceCourtInfo;
                        break;
                    case InfoResourceType.Employer:
                        documentType = WordDocumentType.InfoResourceEmployer;
                        break;
                    case InfoResourceType.Landlord:
                        documentType = WordDocumentType.InfoResourceLandlord;
                        break;
                }

                TemplateHelper templateHelper = new TemplateHelper();
                string filename = WordTemplatePathResolver.GetTemplateFileName(documentType);
                if (!string.IsNullOrEmpty(filename))
                {
                    string url = string.Format("api/templates");
                    string savePath = WordTemplatePathResolver.GetWordTemplatePath(documentType);
                    templateHelper.DownloadTemplate(savePath, filename);
                }

                templatePath = WordTemplatePathResolver.GetWordTemplatePath(documentType);

                if (!File.Exists(templatePath))
                {
                    MessageBox.Show(string.Format("File in path {0} doesn't exist. Please check again.", templatePath), "Can't open file!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (resourceType == InfoResourceType.Document)
                    {
                        string toSaveFileName = string.Format("{0} - {1}", Path.GetFileNameWithoutExtension(templatePath), resource.Name ?? string.Empty);
                        string sFileExtension = "docx";
                        word = new WordService(templatePath, toSaveFileName, false);
                        string tempFilePath = FileNameHelper.GetWriteableFilePath(Path.GetTempPath(), toSaveFileName, sFileExtension);
                        DocumentCompleteResult documentCompleteResult = new DocumentCompleteResult(tempFilePath, word, null);
                        FormDocumentComplete formDocumentComplete = new FormDocumentComplete(null, documentCompleteResult);

                        formDocumentComplete.StartPosition = FormStartPosition.CenterParent;
                        formDocumentComplete.ShowDialog();
                    }
                    else
                    {
                        word = new WordService(templatePath, Path.GetFileNameWithoutExtension(templatePath), false);
                        Dictionary<string, string> bookmarkData = new Dictionary<string, string>();

                        if (resource != null && resourceType != InfoResourceType.Document)
                        {
                            string from = "";
                            if (formMaster != null)
                            {
                                if (formMaster.CURRENT_USER != null)
                                {
                                    from = formMaster.CURRENT_USER.UserName;
                                }
                            }

                            bookmarkData.Add("Cover_Recipient", resource.Name);
                            bookmarkData.Add("Cover_Fax", resource.Target);
                            bookmarkData.Add("Cover_From", from);
                            bookmarkData.Add("Cover_Date", DateTime.Now.ToString("MM/dd/yyyy"));
                            bookmarkData.Add("Cover_Time", DateTime.Now.ToString("hh:mm tt"));
                            bookmarkData.Add("Cover_PageNum", "2");
                        }

                        using (new HourGlass())
                        {
                            word.FillBookmark(bookmarkData);
                            word.SetVisible(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (word != null)
                    word.Quit(false);
            }
        }

        #endregion

        #region Check string

        private bool IsStringFilePath(string input)
        {
            try
            {
                if (!string.IsNullOrEmpty(input) &&
                Regex.IsMatch(input,
                @"^.*\.(txt|gif|pdf|doc|docx|xls|xlsx|dot)$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return false;
        }

        private bool IsWebsiteString(string strInput)
        {
            try
            {
                if (!String.IsNullOrEmpty(strInput))
                {
                    if (strInput.StartsWith("www.") || strInput.StartsWith("http:") || strInput.StartsWith("https:"))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            return false;
        }

        private bool IsValidNumberString(string strInput)
        {
            try
            {
                int digitCount = 0;
                char[] charArr = strInput.ToArray();

                if (charArr.Any())
                {
                    foreach (char c in charArr)
                    {
                        if (Char.IsNumber(c)) digitCount++;
                    }
                    if (digitCount >= 7) return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
            return false;
        }

        #endregion

        private void CheckPermission()
        {
            FormMaster formMaster = (FormMaster)this.Owner;
            if (formMaster == null)
            {
                return;
            }

            if (formMaster.CURRENT_USER != null)
            {
                User user = formMaster.CURRENT_USER;
                FeatureAuthorization featureAuth = new FeatureAuthorization();

                Role role = formMaster.CURRENT_ROLE;

                if (role != null)
                {
                    foreach (FeaturePermission item in role.FeaturePermissions)
                    {
                        if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.DeleteResource))
                        {
                            if (!item.IsAllowed)
                            {
                                this.olvcolBtnRemove.IsVisible = false;
                                currentUserHasPermissionDelete = false;
                            }
                            else
                            {
                                this.olvcolBtnRemove.IsVisible = true;
                                currentUserHasPermissionDelete = true;
                            }
                            this.olvInfoResources.RebuildColumns();
                        }
                    }
                }
            }
        }

        private void frmInfoResources_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Hide();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
            }
        }

        public void CopyRecordValueToClipBoard()
        {
            ResourceData rs = olvInfoResources.SelectedObject as ResourceData;

            if (rs != null)
            {
                if (_selectedColumn == olvcolResourceName)
                {
                    System.Windows.Forms.Clipboard.SetText(rs.Name);
                }
                else if (_selectedColumn == olvcolTarget)
                {
                    System.Windows.Forms.Clipboard.SetText(rs.Target);
                }
                else if (_selectedColumn == olvcolComment)
                {
                    System.Windows.Forms.Clipboard.SetText(rs.Comment);
                }
            }
        }


        private void DoclibClickHandler(object sender, EventArgs e)
        {
            OpenInfoResourceForm(InfoResourceType.Document);
        }

        private void CriminalClickHandler(object sender, EventArgs e)
        {
            OpenInfoResourceForm(InfoResourceType.CourtInfo);
        }

        private void LandlordContactClickHandler(object sender, EventArgs e)
        {
            OpenInfoResourceForm(InfoResourceType.Landlord);
        }

        private void EmploymentClickHandler(object sender, EventArgs e)
        {
            OpenInfoResourceForm(InfoResourceType.Employer);
        }

        private void RefreshClickHandler(object sender, EventArgs e)
        {
            FormInfoResources form = (FormInfoResources)formList.Find(a => a.Name == "FormInfoResources");
            form = (form != null) ? form : null;
            using (new HourGlass())
            {
                RefreshData();
                LoadData();
            }
        }
        
        private void OpenInfoResourceForm(InfoResourceType type)
        {
            FormInfoResources form = (FormInfoResources)formList.Find(a => a.Name == "FormInfoResources");
            form = (form != null) ? form : null;

            if (form != null && !form.IsDisposed)
            {
                form.Show();
            }
            else
            {
                form = new FormInfoResources(formMaster);
                formList.Add(form);
            }

            form.CurrentType = type;
            form.LoadData();
            form.BringToFront();
            form.Show();
        }

        private void olvInfoResources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(currentTypeIndex.ContainsKey(_currentType))
            {
                currentTypeIndex.Remove(_currentType);
            }
            currentTypeIndex.Add(_currentType, olvInfoResources.SelectedIndex);
        }

        private void olvInfoResources_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ResourceData selectedResource = this.olvInfoResources.SelectedObject as ResourceData;

                if (selectedResource != null)
                {
                    if (selectedResources.Count > 0)
                        selectedResources.Clear();
                    selectedResources.Add(selectedResource);
                }
                else if (selectedResource == null && olvInfoResources.Items.Count > 0 && olvInfoResources.MultiSelect && olvInfoResources.SelectedObjects.Count > 1)
                {
                    if (selectedResources.Count > 0)
                        selectedResources.Clear();

                    foreach (ResourceData resourceData in olvInfoResources.SelectedObjects)
                    {
                        selectedResources.Add(resourceData);
                    }
                }
                else if (selectedResource == null)
                {
                    if (selectedResources.Count == 1)
                        olvInfoResources.SelectedObject = selectedResources.FirstOrDefault();
                    else if (selectedResources.Count > 1)
                        olvInfoResources.SelectedObjects = selectedResources;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            string date = t.ToLongDateString();
            string time = t.ToLongTimeString();
            sttlblClock.Text = string.Format("{0} | {1}", date, time);
        }

        public void SetAppCount(string message = "")
        {
            if (string.IsNullOrEmpty(message))
            {
                sttlblCount.Text = "No Resources In View";
            }
            else
            {
                sttlblCount.Text = message;
            }
        }

        public void OnOpenWindows(object sender, EventArgs e)
        {
            if(_currentType == InfoResourceType.Document)
            {
                DoclibClickHandler(sender, e);
            }
            else if (_currentType == InfoResourceType.Employer)
            {
                EmploymentClickHandler(sender, e);
            }
            else if (_currentType == InfoResourceType.Landlord)
            {
                LandlordContactClickHandler(sender, e);
            }
            if (_currentType == InfoResourceType.CourtInfo)
            {
                CriminalClickHandler(sender, e);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            #region Info Resource
            switch (keyData)
                {
                    case Keys.Alt | Keys.D:
                        DoclibClickHandler(new object(), new EventArgs());
                        return true;
                    case Keys.Alt | Keys.E:
                        EmploymentClickHandler(new object(), new EventArgs());
                        return true;
                    case Keys.Alt | Keys.C:
                        CriminalClickHandler(new object(), new EventArgs());
                        return true;
                    case Keys.Alt | Keys.L:
                        LandlordContactClickHandler(new object(), new EventArgs());
                        return true;
                    case Keys.Delete:
                        this.DeleteResource();
                        return true;
                    case Keys.F5:
                        using (new HourGlass())
                        {
                            RefreshData();                            
                        }
                        return true;
                    case Keys.Control | Keys.C:
                        this.CopyRecordValueToClipBoard();
                        return true;
            }
            #endregion Info Resource

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
