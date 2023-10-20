using Administration.Application.Data.StandardTemplate;
using Administration.Domain.Model.StandardTemplate;
using Administration.Infrastructure.StandardTemplate;
using Common.Infrastructure.ApiClient;
using Common.Infrastructure.ComboBoxCustom;
using Common.Infrastructure.Helper;
using Common.Infrastructure.OLV;
using Common.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.Administration
{
    public partial class FormStandardTemplates : BaseForm
    {
        enum Mode
        {
            Edit,
            AddNew
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private StandardTemplateApiRepository apiRepository = new StandardTemplateApiRepository();
        private StandardTemplateCachedApiQuery cachedApiQuery = StandardTemplateCachedApiQuery.Instance;

        private Mode mode = Mode.Edit;

        //private List<TemplateItem> dataList = null;
        private DataTable dataTable = null;

        private TemplateItem selectedItem = null;
        private TemplateItem currentRootItem = null;

        private const string ROOT_VALUE = "0";
        private const int MAX_CHILD_LEVEL = 2;
        private const RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletType NormalType = RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletType.Normal;
        private const RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletStyle NormalStyle = RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletStyle.NoNumber;
        private const RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletType BulletType = RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletType.Normal;
        private const RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletStyle BulletStyle = RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletStyle.Plain;
        private const RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletType NumberType = RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletType.Number;
        private const RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletStyle NumberStyle = RichTextBoxEx.Controls.RichTextBoxEx.AdvRichTextBulletStyle.Period;
        private const int IndentIncrementFraction = 10;

        public FormStandardTemplates()
        {
            InitializeComponent();
        }

        private void FormStandardTemplate_LoadCompleted(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    InitTreeListView();
                    InitRichTextBox();
                    CreateDataTable();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message);                
            }
        }

        private void InitTreeListView()
        {
            this.tlvStandardTemplates.ShowKeyColumns = false;

            this.tlvStandardTemplates.RowHeight = 35;
        }

        private void InitRichTextBox()
        {
            rtfStandardRefs.BulletIndent = 10;

            rtfFinalComments.BulletIndent = 10;
        }

        private void LoadData()
        {
            List<TemplateItem> dataList = cachedApiQuery.GetAllTemplateItems();
            if (dataList != null && dataList.Count > 0)
            {
                FillDataTable(dataList);
                this.tlvStandardTemplates.SelectedIndex = 0;
                this.tlvStandardTemplates.CollapseAll();
            }
            else
            {
                this.tlvStandardTemplates.ClearObjects();
            }
        }

        private void CreateDataTable()
        {
            if (this.dataTable != null)
            {
                return;
            }

            this.dataTable = new DataTable();
            this.dataTable.Columns.Add("Id", typeof(String));
            this.dataTable.Columns.Add("ParentId", typeof(String));
            this.dataTable.Columns.Add("Name", typeof(String));
            this.dataTable.Columns.Add("Caption", typeof(String));
            this.dataTable.Columns.Add("Index", typeof(Int16));

            this.tlvStandardTemplates.DataSource = this.dataTable;
        }

        private void FillDataTable(List<TemplateItem> templateList)
        {
            this.dataTable.Rows.Clear();

            if (templateList == null || templateList.Count == 0)
            {
                return;
            }

            List<TemplateItem> rootList = templateList.Where(template => template.ParentId.Id.Equals(ROOT_VALUE))
                                            .OrderBy(template => template.Index).ToList<TemplateItem>();

            if (rootList == null || rootList.Count == 0)
            {
                return;
            }

            foreach (TemplateItem root in rootList)
            {
                DataRow dr = this.dataTable.NewRow();
                dr["Id"] = root.TemplateItemId.Id;
                dr["ParentId"] = root.ParentId.Id;
                dr["Name"] = root.Name;
                dr["Caption"] = root.Caption;
                dr["Index"] = root.Index.ToString();
                this.dataTable.Rows.Add(dr);
                FillDataTableRecursive(templateList, root);
            }
        }

        private void FillDataTableRecursive(List<TemplateItem> templateList, TemplateItem parent)
        {
            if (templateList == null || templateList.Count == 0 || parent == null)
            {
                return;
            }

            List<TemplateItem> childrenList = templateList.Where(template => template.ParentId.Id.Equals(parent.TemplateItemId.Id))
                                            .OrderBy(template => template.Index).ToList<TemplateItem>();

            if (childrenList == null || childrenList.Count == 0)
            {
                return;
            }

            foreach (TemplateItem children in childrenList)
            {
                DataRow dr = this.dataTable.NewRow();
                dr["Id"] = children.TemplateItemId.Id;
                dr["ParentId"] = children.ParentId.Id;
                dr["Name"] = children.Name;
                dr["Caption"] = children.Caption;
                dr["Index"] = children.Index.ToString();
                this.dataTable.Rows.Add(dr);
                FillDataTableRecursive(templateList, children);
            }
        }

        private void FillComboTreeBox(List<TemplateItem> templateList)
        {
            ctbParent.Nodes.Clear();

            if (templateList == null || templateList.Count == 0)
            {
                return;
            }

            List<TemplateItem> rootList = new List<TemplateItem>();

            if (this.mode == Mode.AddNew)
            {
                rootList = templateList.FindAll(delegate(TemplateItem item)
                {
                    return item.ParentId.Id.Equals(ROOT_VALUE);
                });
            }
            else if (this.mode == Mode.Edit)
            {
                rootList.Add(this.currentRootItem);
            }

            if (rootList == null || rootList.Count == 0)
            {
                return;
            }

            foreach (TemplateItem root in rootList)
            {
                ComboTreeNode nodeAdded = ctbParent.Nodes.Add(root.TemplateItemId.Id, root.Name);
                int level = 1;
                FillComboTreeBoxRecursive(templateList, nodeAdded, this.selectedItem, ref level);
            }

            if (this.mode == Mode.AddNew)
            {
                ctbParent.SelectedNode = ctbParent.Nodes[0];
                this.currentRootItem = rootList[0];
            }
            else if (this.mode == Mode.Edit && this.selectedItem != null)
            {
                ctbParent.SelectedNode = ctbParent.AllNodes.Where(x => x.Name.Equals(this.selectedItem.ParentId.Id)).FirstOrDefault();
            }
        }

        private void FillComboTreeBoxRecursive(List<TemplateItem> templateList, ComboTreeNode parent,
            TemplateItem selectedItem, ref int level)
        {
            if (templateList == null || templateList.Count == 0 || level == MAX_CHILD_LEVEL)
            {
                return;
            }

            string parentId = parent.Name;
            List<TemplateItem> childrenList = templateList.FindAll(delegate(TemplateItem item)
            {
                return item.ParentId.Id.Equals(parentId);
            });

            if (childrenList == null || childrenList.Count == 0)
            {
                return;
            }

            level += 1;

            foreach (TemplateItem children in childrenList)
            {
                if (selectedItem != null && children.TemplateItemId.Id.Equals(selectedItem.TemplateItemId.Id))
                {
                    continue;
                }
                ComboTreeNode nodeAdded = parent.Nodes.Add(children.TemplateItemId.Id, children.Name);
                FillComboTreeBoxRecursive(templateList, nodeAdded, selectedItem, ref level);
            }
        }

        private void tlvStandardTemplates_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)this.tlvStandardTemplates.SelectedObject;
            List<TemplateItem> dataList = cachedApiQuery.GetAllTemplateItems();
            if (selectedRow == null)
            {
                this.selectedItem = null;
                this.currentRootItem = null;
                if (this.mode == Mode.AddNew)
                {
                    SetEnabledControls(true);
                    ClearControls(dataList);
                    ctbParent.Focus();
                }
                else if (this.mode == Mode.Edit)
                {
                    SetEnabledControls(false);
                }
                return;
            }

            TemplateItem item = ConvertDataRowViewToTemplateItem(selectedRow);
            if (item != null)
            {
                this.mode = Mode.Edit;
                this.selectedItem = item;

                if (this.selectedItem.ParentId.Id.Equals(ROOT_VALUE))
                {
                    this.currentRootItem = this.selectedItem;
                }
                else
                {
                    TemplateItem rootItem = new TemplateItem();
                    GetRootItemTreeListViewRecursive(dataList, this.selectedItem.ParentId.Id, ref rootItem);
                    this.currentRootItem = rootItem;
                }

                lblTemplateType.Text = this.currentRootItem.Name.ToUpper();

                ClearControls(dataList);

                txtName.Text = this.selectedItem.Name;

                if (this.selectedItem.ParentId.Id.Equals(ROOT_VALUE))
                {
                    SetEnabledControls(false);
                    SetVisibleControls(this.selectedItem);
                    return;
                }

                if (!string.IsNullOrEmpty(this.selectedItem.Caption))
                {
                    if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_VERIFS_1_ID.Value))
                    {
                        EmpVerifs1Data data = XmlSerializationHelper.Deserialize<EmpVerifs1Data>(this.selectedItem.Caption);
                        txtSW.Text = data.SW;
                        txtCo.Text = data.Co;
                        txtTele.Text = data.Tele;
                    }
                    else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_VERIFS_2_ID.Value))
                    {
                        EmpVerifs2Data data = XmlSerializationHelper.Deserialize<EmpVerifs2Data>(this.selectedItem.Caption);
                        txtSW.Text = data.SW;
                        txtCo.Text = data.Co;
                        txtTele.Text = data.Tele;
                    }
                    else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value))
                    {
                        EmpRefsData data = XmlSerializationHelper.Deserialize<EmpRefsData>(this.selectedItem.Caption);
                        rtfStandardRefs.Rtf = data.EmpRefs;
                    }
                    else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
                    {
                        RentalRefsData data = XmlSerializationHelper.Deserialize<RentalRefsData>(this.selectedItem.Caption);
                        rtfStandardRefs.Rtf = data.RentalRefs;
                    }
                    else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
                    {
                        FinalCmtsData data = XmlSerializationHelper.Deserialize<FinalCmtsData>(this.selectedItem.Caption);
                        rtfFinalComments.Rtf = data.FinalCmts;
                    }
                }
                txtIndex.Text = this.selectedItem.Index.ToString();

                SetEnabledControls(true);
                SetVisibleControls(this.currentRootItem);
            }
            else
            {
                this.selectedItem = null;
                this.currentRootItem = null;
                SetEnabledControls(false);
            }
        }

        private void ctbParent_SelectedNodeChanged(object sender, EventArgs e)
        {
            ComboTreeNode ctbSelectedItem = ctbParent.SelectedNode;
            if (ctbSelectedItem == null || string.IsNullOrEmpty(ctbSelectedItem.Name) || this.mode == Mode.Edit)
            {
                return;
            }

            List<TemplateItem> dataList = cachedApiQuery.GetAllTemplateItems();
            TemplateItem rootItem = new TemplateItem();
            GetRootItemTreeListViewRecursive(dataList, ctbSelectedItem.Name, ref rootItem);
            this.currentRootItem = rootItem;
            SetVisibleControls(rootItem);
        }

        public void AddNewTemplate()
        {
            this.mode = Mode.AddNew;

            if (this.tlvStandardTemplates.SelectedIndex >= 0)
            {
                this.tlvStandardTemplates.SelectedIndex = -1;
            }
            else
            {
                this.selectedItem = null;
                this.currentRootItem = null;
                SetEnabledControls(true);
                List<TemplateItem> dataList = cachedApiQuery.GetAllTemplateItems();
                ClearControls(dataList);
                ctbParent.Focus();
            }
        }

        public void SaveTemplate()
        {
            if (this.mode == Mode.AddNew)
            {
                string newItemName = txtName.Text;
                if (string.IsNullOrWhiteSpace(newItemName))
                {
                    MessageBox.Show("Name cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newItemIndex = txtIndex.Text;
                if (string.IsNullOrWhiteSpace(newItemIndex))
                {
                    MessageBox.Show("Index cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (short.Parse(newItemIndex) < 0)
                {
                    MessageBox.Show("Index must start from 0!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ComboTreeNode ctbSelectedItem = ctbParent.SelectedNode;
                ComboTreeNode rootItem = new ComboTreeNode();
                GetRootItemComboTreeBoxRecursive(ctbSelectedItem, ref rootItem);

                if (ctbSelectedItem.Depth >= MAX_CHILD_LEVEL)
                {
                    MessageBox.Show("Maximum child level is " + MAX_CHILD_LEVEL + ". Please select different parent with higher level!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    TemplateItem item = apiRepository.FindByParentAndName(ctbSelectedItem.Name, newItemName);
                    if (item != null)
                    {
                        MessageBox.Show("Name already exists in " + ctbSelectedItem.Text + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                TemplateItem newItem = new TemplateItem();
                newItem.ParentId = new TemplateItemId(ctbSelectedItem.Name);
                newItem.Name = newItemName;
                if (rootItem.Name.Equals(RootItemData.EMP_VERIFS_1_ID.Value))
                {
                    if (string.IsNullOrWhiteSpace(txtSW.Text) && string.IsNullOrWhiteSpace(txtCo.Text) && string.IsNullOrWhiteSpace(txtTele.Text))
                    {
                        newItem.Caption = string.Empty;
                    }
                    else
                    {
                        EmpVerifs1Data data = new EmpVerifs1Data();
                        data.SW = txtSW.Text.Trim();
                        data.Co = txtCo.Text.Trim();
                        data.Tele = txtTele.Text.Trim();
                        newItem.Caption = XmlSerializationHelper.Serialize<EmpVerifs1Data>(data);
                    }
                }
                else if (rootItem.Name.Equals(RootItemData.EMP_VERIFS_2_ID.Value))
                {
                    if (string.IsNullOrWhiteSpace(txtSW.Text) && string.IsNullOrWhiteSpace(txtCo.Text) && string.IsNullOrWhiteSpace(txtTele.Text))
                    {
                        newItem.Caption = string.Empty;
                    }
                    else
                    {
                        EmpVerifs2Data data = new EmpVerifs2Data();
                        data.SW = txtSW.Text.Trim();
                        data.Co = txtCo.Text.Trim();
                        data.Tele = txtTele.Text.Trim();
                        newItem.Caption = XmlSerializationHelper.Serialize<EmpVerifs2Data>(data);
                    }
                }
                else if (rootItem.Name.Equals(RootItemData.EMP_REFS_ID.Value))
                {
                    if (string.IsNullOrWhiteSpace(rtfStandardRefs.Text))
                    {
                        newItem.Caption = string.Empty;
                    }
                    else
                    {
                        EmpRefsData data = new EmpRefsData();
                        data.EmpRefs = rtfStandardRefs.Rtf;
                        newItem.Caption = XmlSerializationHelper.Serialize<EmpRefsData>(data);
                    }
                }
                else if (rootItem.Name.Equals(RootItemData.RENTAL_REFS_ID.Value))
                {
                    if (string.IsNullOrWhiteSpace(rtfStandardRefs.Text))
                    {
                        newItem.Caption = string.Empty;
                    }
                    else
                    {
                        RentalRefsData data = new RentalRefsData();
                        data.RentalRefs = rtfStandardRefs.Rtf;
                        newItem.Caption = XmlSerializationHelper.Serialize<RentalRefsData>(data);
                    }
                }
                else if (rootItem.Name.Equals(RootItemData.FINAL_CMTS_ID.Value))
                {
                    if (string.IsNullOrWhiteSpace(rtfFinalComments.Text))
                    {
                        newItem.Caption = string.Empty;
                    }
                    else
                    {
                        FinalCmtsData data = new FinalCmtsData();
                        data.FinalCmts = rtfFinalComments.Rtf;
                        newItem.Caption = XmlSerializationHelper.Serialize<FinalCmtsData>(data);
                    }
                }
                newItem.Index = short.Parse(newItemIndex);

                using (new HourGlass())
                {
                    string newItemId = apiRepository.Add(newItem);
                    if (!string.IsNullOrEmpty(newItemId))
                    {
                        newItem.TemplateItemId = new TemplateItemId(newItemId);
                        NewTemplateItemCompleted(newItem);
                    }
                }
            }
            else if (this.mode == Mode.Edit)
            {
                if (this.selectedItem == null)
                {
                    return;
                }

                if (this.selectedItem.ParentId.Id.Equals(ROOT_VALUE))
                {
                    MessageBox.Show("You cannot edit root item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string editItemName = txtName.Text;
                if (string.IsNullOrWhiteSpace(editItemName))
                {
                    MessageBox.Show("Name cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string editItemIndex = txtIndex.Text;
                if (string.IsNullOrWhiteSpace(editItemIndex))
                {
                    MessageBox.Show("Index cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (short.Parse(editItemIndex) < 0)
                {
                    MessageBox.Show("Index must start from 0!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ComboTreeNode ctbSelectedItem = ctbParent.SelectedNode;
                bool update = false;

                if (ctbSelectedItem.Depth >= MAX_CHILD_LEVEL)
                {
                    MessageBox.Show("Maximum child level is " + MAX_CHILD_LEVEL + ". Please select different parent with higher level!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (!this.selectedItem.Name.Equals(editItemName))
                    {
                        TemplateItem item = apiRepository.FindByParentAndName(ctbSelectedItem.Name, editItemName);
                        if (item != null)
                        {
                            MessageBox.Show("Name already exists in " + ctbSelectedItem.Text + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            this.selectedItem.Name = editItemName;
                            update = true;
                        }
                    }
                }

                if (!this.selectedItem.ParentId.Id.Equals(ctbSelectedItem.Name))
                {
                    this.selectedItem.ParentId.Id = ctbSelectedItem.Name;
                    update = true;
                }

                string editItemCaption = string.Empty;
                if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_VERIFS_1_ID.Value))
                {
                    if (string.IsNullOrWhiteSpace(txtSW.Text) && string.IsNullOrWhiteSpace(txtCo.Text) && string.IsNullOrWhiteSpace(txtTele.Text))
                    {
                        editItemCaption = string.Empty;
                    }
                    else
                    {
                        EmpVerifs1Data data = new EmpVerifs1Data();
                        data.SW = txtSW.Text.Trim();
                        data.Co = txtCo.Text.Trim();
                        data.Tele = txtTele.Text.Trim();
                        editItemCaption = XmlSerializationHelper.Serialize<EmpVerifs1Data>(data);
                    }
                }
                else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_VERIFS_2_ID.Value))
                {
                    if (string.IsNullOrWhiteSpace(txtSW.Text) && string.IsNullOrWhiteSpace(txtCo.Text) && string.IsNullOrWhiteSpace(txtTele.Text))
                    {
                        editItemCaption = string.Empty;
                    }
                    else
                    {
                        EmpVerifs2Data data = new EmpVerifs2Data();
                        data.SW = txtSW.Text.Trim();
                        data.Co = txtCo.Text.Trim();
                        data.Tele = txtTele.Text.Trim();
                        editItemCaption = XmlSerializationHelper.Serialize<EmpVerifs2Data>(data);
                    }
                }
                else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value))
                {
                    if (string.IsNullOrWhiteSpace(rtfStandardRefs.Text))
                    {
                        editItemCaption = string.Empty;
                    }
                    else
                    {
                        EmpRefsData data = new EmpRefsData();
                        data.EmpRefs = rtfStandardRefs.Rtf;
                        editItemCaption = XmlSerializationHelper.Serialize<EmpRefsData>(data);
                    }
                }
                else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
                {
                    if (string.IsNullOrWhiteSpace(rtfStandardRefs.Text))
                    {
                        editItemCaption = string.Empty;
                    }
                    else
                    {
                        RentalRefsData data = new RentalRefsData();
                        data.RentalRefs = rtfStandardRefs.Rtf;
                        editItemCaption = XmlSerializationHelper.Serialize<RentalRefsData>(data);
                    }
                }
                else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
                {
                    if (string.IsNullOrWhiteSpace(rtfFinalComments.Text))
                    {
                        editItemCaption = string.Empty;
                    }
                    else
                    {
                        FinalCmtsData data = new FinalCmtsData();
                        data.FinalCmts = rtfFinalComments.Rtf;
                        editItemCaption = XmlSerializationHelper.Serialize<FinalCmtsData>(data);
                    }
                }
                if (!this.selectedItem.Caption.Equals(editItemCaption))
                {
                    this.selectedItem.Caption = editItemCaption;
                    update = true;
                }

                if (this.selectedItem.Index != short.Parse(editItemIndex))
                {
                    this.selectedItem.Index = short.Parse(editItemIndex);
                    update = true;
                }

                if (update)
                {
                    using (new HourGlass())
                    {
                        apiRepository.Update(this.selectedItem);
                        UpdateTemplateItemCompleted(this.selectedItem);
                    }
                }
            }

            this.mode = Mode.Edit;
        }

        public void DeleteTemplate()
        {
            if (this.selectedItem == null)
            {
                return;
            }

            if (this.selectedItem.ParentId.Id.Equals(ROOT_VALUE))
            {
                MessageBox.Show("You cannot delete root item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<TemplateItem> dataList = cachedApiQuery.GetAllTemplateItems();

            List<TemplateItem> childrenItems = GetChildrenItemsTreeListView(dataList, this.selectedItem.TemplateItemId.Id);
            if (childrenItems != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete \"" + this.selectedItem.Name + "\" item?\n" +
                    "It contains " + childrenItems.Count + " children items. This action will delete all of them!",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    using (new HourGlass())
                    {
                        childrenItems.Add(this.selectedItem);
                        apiRepository.MultiRemove(childrenItems);
                        MultiRemoveTemplateItemCompleted(childrenItems);
                        //ClearControls(dataList);
                    }
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete \"" + this.selectedItem.Name + "\" item?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    using (new HourGlass())
                    {
                        apiRepository.Remove(this.selectedItem);
                        RemoveTemplateItemCompleted(this.selectedItem);
                        //ClearControls(dataList);
                    }
                }
            }
        }

        private List<TemplateItem> GetChildrenItemsTreeListView(List<TemplateItem> templateList, string parentId)
        {
            if (templateList == null || templateList.Count == 0 || string.IsNullOrEmpty(parentId))
            {
                return null;
            }

            List<TemplateItem> result = new List<TemplateItem>();
            GetChildrenItemsTreeListViewRecursive(templateList, parentId, ref result);

            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        private void GetChildrenItemsTreeListViewRecursive(List<TemplateItem> templateList, string parentId,
            ref List<TemplateItem> result)
        {
            if (templateList == null || templateList.Count == 0 || string.IsNullOrEmpty(parentId))
            {
                return;
            }

            List<TemplateItem> childrenList = (from template in templateList
                                               where template.ParentId.Id.Equals(parentId)
                                               select template).ToList<TemplateItem>();

            if (childrenList == null || childrenList.Count == 0)
            {
                return;
            }

            result.AddRange(childrenList);

            foreach (TemplateItem children in childrenList)
            {
                GetChildrenItemsTreeListViewRecursive(templateList, children.TemplateItemId.Id, ref result);
            }
        }

        private void GetRootItemTreeListViewRecursive(List<TemplateItem> templateList, string childrenParentId,
            ref TemplateItem result)
        {
            if (templateList == null || templateList.Count == 0 || string.IsNullOrWhiteSpace(childrenParentId))
            {
                return;
            }

            TemplateItem parent = (from template in templateList
                                   where template.TemplateItemId.Id.Equals(childrenParentId)
                                   select template).FirstOrDefault<TemplateItem>();

            result = parent;

            if (parent == null || parent.ParentId.Id.Equals(ROOT_VALUE))
            {
                return;
            }

            GetRootItemTreeListViewRecursive(templateList, parent.ParentId.Id, ref result);
        }

        private void GetRootItemComboTreeBoxRecursive(ComboTreeNode childrenItem, ref ComboTreeNode result)
        {
            if (childrenItem == null || childrenItem.Depth == 0)
            {
                result = childrenItem;
                return;
            }

            GetRootItemComboTreeBoxRecursive(childrenItem.Parent, ref result);
        }

        private int GetTemplateItemIndexById(List<TemplateItem> templateList, string templateId)
        {
            if (templateList == null || templateList.Count == 0 || string.IsNullOrEmpty(templateId))
            {
                return -1;
            }

            return templateList.FindIndex(
                delegate(TemplateItem item)
                {
                    return item.TemplateItemId.Id.Equals(templateId);
                });
        }

        private TemplateItem GetTemplateItemById(List<TemplateItem> templateList, string templateId)
        {
            if (templateList == null || templateList.Count == 0 || string.IsNullOrEmpty(templateId))
            {
                return null;
            }

            return templateList.Find(
                delegate(TemplateItem item)
                {
                    return item.TemplateItemId.Id.Equals(templateId);
                });
        }

        private TemplateItem ConvertDataRowViewToTemplateItem(DataRowView drv)
        {
            if (drv == null || drv.DataView.Count == 0)
            {
                return null;
            }

            TemplateItem item = new TemplateItem();
            item.TemplateItemId = new TemplateItemId(drv["Id"].ToString());
            item.ParentId = new TemplateItemId(drv["ParentId"].ToString());
            item.Name = drv["Name"].ToString();
            item.Caption = drv["Caption"].ToString();
            item.Index = short.Parse(drv["Index"].ToString());

            return item;
        }

        private void ClearControls(List<TemplateItem> templateList)
        {
            FillComboTreeBox(templateList);
            txtName.Clear();
            txtSW.Clear();
            txtCo.Clear();
            txtTele.Clear();
            rtfStandardRefs.Clear();
            rtfStandardRefs.BulletType = NormalType;
            rtfStandardRefs.BulletStyle = NormalStyle;
            rtfFinalComments.Clear();
            rtfFinalComments.BulletType = NormalType;
            rtfFinalComments.BulletStyle = NormalStyle;
            txtIndex.Text = "1";
        }

        private void SetEnabledControls(bool enabled)
        {
            ctbParent.Enabled = enabled;
            txtName.Enabled = enabled;
            txtSW.Enabled = enabled;
            txtCo.Enabled = enabled;
            txtTele.Enabled = enabled;
            tsToolbar.Enabled = enabled;
            rtfStandardRefs.Enabled = enabled;
            rtfFinalComments.Enabled = enabled;
            txtIndex.Enabled = enabled;
        }

        private void SetVisibleControls(TemplateItem rootItem)
        {
            if (rootItem == null)
            {
                return;
            }

            lblSW.Visible = false;
            txtSW.Visible = false;
            lblCo.Visible = false;
            txtCo.Visible = false;
            lblTele.Visible = false;
            txtTele.Visible = false;
            tsToolbar.Visible = false;
            lblStandardRefs.Visible = false;
            rtfStandardRefs.Visible = false;
            lblFinalComments.Visible = false;
            rtfFinalComments.Visible = false;

            if (rootItem.TemplateItemId.Id.Equals(RootItemData.EMP_VERIFS_1_ID.Value) ||
                rootItem.TemplateItemId.Id.Equals(RootItemData.EMP_VERIFS_2_ID.Value))
            {
                lblSW.Visible = true;
                txtSW.Visible = true;
                lblCo.Visible = true;
                txtCo.Visible = true;
                lblTele.Visible = true;
                txtTele.Visible = true;
            }
            else if (rootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                rootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                tsToolbar.Visible = true;
                lblStandardRefs.Visible = true;
                rtfStandardRefs.Visible = true;
            }
            else if (rootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                tsToolbar.Visible = true;
                lblFinalComments.Visible = true;
                rtfFinalComments.Visible = true;
            }
        }

        private void AdjustDataTableWithNewData(List<TemplateItem> newTemplateList)
        {
            if (newTemplateList == null || newTemplateList.Count == 0)
            {
                this.tlvStandardTemplates.ClearObjects();
                return;
            }

            string[] oldIdArr = this.dataTable.AsEnumerable().Select(row => row.Field<String>("Id")).ToArray();
            string[] newIdArr = newTemplateList.Select(template => template.TemplateItemId.Id).ToArray();

            string[] removeIdArr = oldIdArr.Where(id => !newIdArr.Contains(id)).ToArray();
            string[] addIdArr = newIdArr.Where(id => !oldIdArr.Contains(id)).ToArray();

            List<DataRow> removeRows = this.dataTable.AsEnumerable().Where(row => removeIdArr.Contains(row.Field<String>("Id"))).ToList<DataRow>();
            foreach (DataRow row in removeRows)
            {
                this.dataTable.Rows.Remove(row);
            }

            IEnumerable<TemplateItem> addItems = newTemplateList.Where(template => addIdArr.Contains(template.TemplateItemId.Id));
            foreach (TemplateItem item in addItems)
            {
                DataRow parent = this.dataTable.AsEnumerable().Where(x => x.Field<String>("Id").Equals(item.ParentId.Id)).FirstOrDefault();
                if (parent != null)
                {
                    int parentIndex = this.dataTable.Rows.IndexOf(parent);
                    DataRow dr = this.dataTable.NewRow();
                    dr["Id"] = item.TemplateItemId.Id;
                    dr["ParentId"] = item.ParentId.Id;
                    dr["Name"] = item.Name;
                    dr["Caption"] = item.Caption;
                    dr["Index"] = item.Index;
                    this.dataTable.Rows.InsertAt(dr, parentIndex + 1);
                }
            }
        }

        private void NewTemplateItemCompleted(TemplateItem item)
        {
            if (item == null)
            {
                return;
            }

            // add to local dataTable & focus
            DataRow parent = this.dataTable.AsEnumerable().Where(x => x.Field<String>("Id").Equals(item.ParentId.Id)).FirstOrDefault();
            if (parent != null)
            {
                int parentIndex = this.dataTable.Rows.IndexOf(parent);
                DataRow dr = this.dataTable.NewRow();
                dr["Id"] = item.TemplateItemId.Id;
                dr["ParentId"] = item.ParentId.Id;
                dr["Name"] = item.Name;
                dr["Caption"] = item.Caption;
                dr["Index"] = item.Index;
                this.dataTable.Rows.InsertAt(dr, parentIndex + 1);

                DataRowView drv = this.dataTable.DefaultView[parentIndex + 1];
                this.tlvStandardTemplates.SelectObject(drv, true);
            }

            // remove cache & get new
            cachedApiQuery.RemoveAllTemplateItems();
            List<TemplateItem> dataList = cachedApiQuery.GetAllTemplateItems();

            // adjust dataTable
            AdjustDataTableWithNewData(dataList);
        }

        private void UpdateTemplateItemCompleted(TemplateItem item)
        {
            if (item == null)
            {
                return;
            }

            // update to local dataTable & focus
            DataRow dr = this.dataTable.AsEnumerable().Where(x => x.Field<String>("Id").Equals(item.TemplateItemId.Id)).FirstOrDefault();
            if (dr != null)
            {
                dr["Name"] = item.Name;
                dr["Caption"] = item.Caption;
                dr["Index"] = item.Index;

                DataRowView drv = null;
                if (dr["ParentId"].ToString().Equals(item.ParentId.Id))
                {
                    int index = this.dataTable.Rows.IndexOf(dr);
                    drv = this.dataTable.DefaultView[index];
                }
                else
                {
                    this.dataTable.Rows.Remove(dr);
                    dr["ParentId"] = item.ParentId.Id;
                    DataRow parent = this.dataTable.AsEnumerable().Where(x => x.Field<String>("Id").Equals(item.ParentId.Id)).FirstOrDefault();
                    int parentIndex = this.dataTable.Rows.IndexOf(parent);
                    this.dataTable.Rows.InsertAt(dr, parentIndex + 1);
                    drv = this.dataTable.DefaultView[parentIndex + 1];
                }
                this.tlvStandardTemplates.SelectObject(drv, true);
            }

            // remove cache & get new
            cachedApiQuery.RemoveAllTemplateItems();
            List<TemplateItem> dataList = cachedApiQuery.GetAllTemplateItems();

            // adjust dataTable
            AdjustDataTableWithNewData(dataList);
        }

        private void RemoveTemplateItemCompleted(TemplateItem item)
        {
            if (item == null)
            {
                return;
            }

            // remove local dataTable
            DataRow dr = this.dataTable.AsEnumerable().Where(x => x.Field<String>("Id").Equals(item.TemplateItemId.Id)).FirstOrDefault();
            if (dr != null)
            {
                this.dataTable.Rows.Remove(dr);
            }

            // remove cache & get new
            cachedApiQuery.RemoveAllTemplateItems();
            List<TemplateItem> dataList = cachedApiQuery.GetAllTemplateItems();

            // adjust dataTable
            AdjustDataTableWithNewData(dataList);
        }

        private void MultiRemoveTemplateItemCompleted(List<TemplateItem> itemList)
        {
            if (itemList == null || itemList.Count == 0)
            {
                return;
            }

            // remove local dataTable
            foreach (TemplateItem item in itemList)
            {
                DataRow dr = this.dataTable.AsEnumerable().Where(x => x.Field<String>("Id").Equals(item.TemplateItemId.Id)).FirstOrDefault();
                if (dr != null)
                {
                    this.dataTable.Rows.Remove(dr);
                }
            }

            // remove cache & get new
            cachedApiQuery.RemoveAllTemplateItems();
            List<TemplateItem> dataList = cachedApiQuery.GetAllTemplateItems();

            // adjust dataTable
            AdjustDataTableWithNewData(dataList);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                using (new HourGlass())
                {
                    SaveTemplate();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string strSearch = txtSearch.Text.Trim();
            bool filter = false;

            if (e.KeyCode == Keys.Back && strSearch.Length == 0)
            {
                strSearch = string.Empty;
                new ObjectListViewService().FilterOlv(this.tlvStandardTemplates, strSearch);
                filter = true;
                this.tlvStandardTemplates.CollapseAll();
            }
            else if (e.KeyCode == Keys.Enter && strSearch.Length > 0)
            {
                this.tlvStandardTemplates.ExpandAll();
                new ObjectListViewService().FilterOlv(this.tlvStandardTemplates, strSearch);
                filter = true;
            }

            if (filter)
            {
            }
        }

        private void txtIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            char dot = Convert.ToChar(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
            if (e.KeyChar == dot || (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNewTemplate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTemplate();
        }

        private void tsBtnCut_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.Cut();
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.Cut();
            }
        }

        private void tsBtnCopy_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.Copy();
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.Copy();
            }
        }

        private void tsBtnPaste_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.Paste();
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.Paste();
            }
        }

        private void tsBtnUndo_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.Undo();
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.Undo();
            }
        }

        private void tsBtnRedo_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.Redo();
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.Redo();
            }
        }

        private void tsBtnBold_Click(object sender, EventArgs e)
        {
            RichTextBoxEx.Controls.RichTextBoxEx control;

            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                control = rtfStandardRefs;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                control = rtfFinalComments;
            }
            else
            {
                return;
            }

            if (control.SelectionFont == null)
            {
                return;
            }

            FontStyle fontStyle = control.SelectionFont.Style;

            if (control.SelectionFont.Bold)
            {
                fontStyle &= ~FontStyle.Bold;
            }
            else
            {
                fontStyle |= FontStyle.Bold;

            }

            control.SelectionFont = new Font(control.SelectionFont, fontStyle);
        }

        private void tsBtnItalic_Click(object sender, EventArgs e)
        {
            RichTextBoxEx.Controls.RichTextBoxEx control;

            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                control = rtfStandardRefs;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                control = rtfFinalComments;
            }
            else
            {
                return;
            }

            if (control.SelectionFont == null)
            {
                return;
            }

            FontStyle fontStyle = control.SelectionFont.Style;

            if (control.SelectionFont.Italic)
            {
                fontStyle &= ~FontStyle.Italic;
            }
            else
            {
                fontStyle |= FontStyle.Italic;

            }

            control.SelectionFont = new Font(control.SelectionFont, fontStyle);
        }

        private void tsBtnUnderline_Click(object sender, EventArgs e)
        {
            RichTextBoxEx.Controls.RichTextBoxEx control;

            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                control = rtfStandardRefs;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                control = rtfFinalComments;
            }
            else
            {
                return;
            }

            if (control.SelectionFont == null)
            {
                return;
            }

            FontStyle fontStyle = control.SelectionFont.Style;

            if (control.SelectionFont.Underline)
            {
                fontStyle &= ~FontStyle.Underline;
            }
            else
            {
                fontStyle |= FontStyle.Underline;

            }

            control.SelectionFont = new Font(control.SelectionFont, fontStyle);
        }

        private void tsBtnIncFontSize_Click(object sender, EventArgs e)
        {
            RichTextBoxEx.Controls.RichTextBoxEx control;

            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                control = rtfStandardRefs;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                control = rtfFinalComments;
            }
            else
            {
                return;
            }

            if (control.SelectionFont == null)
            {
                return;
            }

            FontStyle fontStyle = control.SelectionFont.Style;
            float fontSize = control.SelectionFont.SizeInPoints + 1;

            if (fontSize > 72)
            {
                return;
            }

            control.SelectionFont = new Font(control.SelectionFont.FontFamily, fontSize, fontStyle, GraphicsUnit.Point);
        }

        private void tsBtnDecFontSize_Click(object sender, EventArgs e)
        {
            RichTextBoxEx.Controls.RichTextBoxEx control;

            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                control = rtfStandardRefs;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                control = rtfFinalComments;
            }
            else
            {
                return;
            }

            if (control.SelectionFont == null)
            {
                return;
            }

            FontStyle fontStyle = control.SelectionFont.Style;
            float fontSize = control.SelectionFont.SizeInPoints - 1;

            if (fontSize <= 0)
            {
                return;
            }

            control.SelectionFont = new Font(control.SelectionFont.FontFamily, fontSize, fontStyle, GraphicsUnit.Point);
        }

        private void tsBtnBulletList_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.BulletType = BulletType;
                rtfStandardRefs.BulletStyle = BulletStyle;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.BulletType = BulletType;
                rtfFinalComments.BulletStyle = BulletStyle;
            }
        }

        private void tsBtnNumberList_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.BulletType = NumberType;
                rtfStandardRefs.BulletStyle = NumberStyle;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.BulletType = NumberType;
                rtfFinalComments.BulletStyle = NumberStyle;
            }
        }

        private void tsBtnAlignLeft_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.SelectionAlignment = HorizontalAlignment.Left;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        private void tsBtnAlignCenter_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.SelectionAlignment = HorizontalAlignment.Center;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void tsBtnAlignRight_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.SelectionAlignment = HorizontalAlignment.Right;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        private void tsBtnIncIndent_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.SelectionIndent += IndentIncrementFraction;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.SelectionIndent += IndentIncrementFraction;
            }
        }

        private void tsBtnDecIndent_Click(object sender, EventArgs e)
        {
            if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.EMP_REFS_ID.Value) ||
                this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.RENTAL_REFS_ID.Value))
            {
                rtfStandardRefs.SelectionIndent -= IndentIncrementFraction;
            }
            else if (this.currentRootItem.TemplateItemId.Id.Equals(RootItemData.FINAL_CMTS_ID.Value))
            {
                rtfFinalComments.SelectionIndent -= IndentIncrementFraction;
            }
        }

    }
}
