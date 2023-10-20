using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Application.Data.ExploreApps;
using Administration.Domain.Model.StandardTemplate;
using Administration.Infrastructure.StandardTemplate;
using StandardTemplate = Administration.Application.Data.StandardTemplate;
using Common.Infrastructure.UI;
using Common.Infrastructure.Helper;
using PaaApplication.ExtendControls;
using PaaApplication.Models.AppExplore;

namespace PaaApplication.UserControls.AppExplore.EmpInfo
{
    public partial class EmpTypeTwoControl : UserControl
    {
        public TextBox EmployerControl
        {
            get { return txtEmployer; }
        }

        public RichTextBox CommentControl
        {
            get { return txtComment; }
        }

        public TextBox SWControl
        {
            get { return txtSW; }
        }

        public TextBox PosControl
        {
            get { return txtPos; }
        }

        public TextBox HiredControl
        {
            get { return txtHired; }
        }

        public TextBox TermControl
        {
            get { return txtTerm; }
        }

        public TextBox FTControl
        {
            get { return txtFT; }
        }

        public TextBox MoneyControl
        {
            get { return txtMoney; }
        }

        public TextBox RHControl
        {
            get { return txtRH; }
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<EmpRefData> _empRefs = new List<EmpRefData>();
        private int _currentIndex = -1;
        private string _currentApplicationId = string.Empty;

        private List<TemplateItem> lstTemplateRefs = new List<TemplateItem>();
        private RichTextBoxContextMenu richTextBoxContextMenu;
        public EventHandler<BeforeSetTemplateEventArgs> BeforeSetTemplateRentalRef;

        public EmpTypeTwoControl()
        {
            InitializeComponent();

            this.richTextBoxContextMenu = new RichTextBoxContextMenu(this.txtComment);
        }

        public List<EmpRefData> GetEmpRefs()
        {
            return this._empRefs;
        }

        private void SetEmpRefs(List<EmpRefData> empRefs)
        {
            this._empRefs = empRefs;
        }

        private EmpRefData GetCurrentEmpRef()
        {
            EmpRefData empRef = new EmpRefData();
            empRef.Info = txtEmployer.Text;
            empRef.SW = txtSW.Text;
            empRef.Pos = txtPos.Text;
            empRef.Hired = txtHired.Text;
            empRef.Termination = txtTerm.Text;
            empRef.FullTime = txtFT.Text;
            empRef.Salary = txtMoney.Text;
            empRef.RH = txtRH.Text;
            empRef.Comment = txtComment.Rtf;

            return empRef;
        }

        private void SetCurrentEmpRef(EmpRefData empRef)
        {
            if (empRef == null)
                return;

            txtEmployer.Text = empRef.Info;
            txtSW.Text = empRef.SW;
            txtPos.Text = empRef.Pos;
            txtHired.Text = empRef.Hired;
            txtTerm.Text = empRef.Termination;
            txtFT.Text = empRef.FullTime;
            txtMoney.Text = empRef.Salary;
            txtRH.Text = empRef.RH;
            try
            {
                txtComment.Rtf = empRef.Comment;
            }
            catch
            //if string format is not rtf, it's plaintext.. We must set text with .Text property
            {
                txtComment.Text = empRef.Comment;
            }
        }

        private void ResetEmp()
        {
            txtEmployer.Text = "";
            txtSW.Text = "";
            txtPos.Text = "";
            txtHired.Text = "";
            txtTerm.Text = "";
            txtFT.Text = "";
            txtMoney.Text = "";
            txtRH.Text = "";
            txtComment.Clear();
        }

        public void ResetControls()
        {
            txtEmployer.Text = "";
            txtSW.Text = "";
            txtPos.Text = "";
            txtHired.Text = "";
            txtTerm.Text = "";
            txtFT.Text = "";
            txtMoney.Text = "";
            txtRH.Text = "";
            txtComment.Clear();

            _empRefs = new List<EmpRefData>();
            _currentIndex = -1;
            _currentApplicationId = string.Empty;

        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetEmp();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                _currentApplicationId = string.Empty;
                return;
            }

            FillDataToControlsAtFirst(app);
        }

        private void SaveCurrentReference()
        {
            try
            {
                EmpRefData empRef = GetCurrentEmpRef();

                if (empRef != null && _empRefs != null)
                {
                    if (_empRefs.ElementAtOrDefault(_currentIndex) != null)
                    {
                        _empRefs[_currentIndex] = empRef;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }

        }

        private void DisableEmpRef()
        {
            txtEmployer.Enabled = false;
            txtSW.Enabled = false;
            txtPos.Enabled = false;
            txtHired.Enabled = false;
            txtTerm.Enabled = false;
            txtFT.Enabled = false;
            txtMoney.Enabled = false;
            txtRH.Enabled = false;
            txtComment.Enabled = false;
        }

        private void EnableEmpRef()
        {
            txtEmployer.Enabled = true;
            txtSW.Enabled = true;
            txtPos.Enabled = true;
            txtHired.Enabled = true;
            txtTerm.Enabled = true;
            txtFT.Enabled = true;
            txtMoney.Enabled = true;
            txtRH.Enabled = true;
            txtComment.Enabled = true;
        }

        private void FillDataToControlsAtFirst(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                _currentApplicationId = string.Empty;
                return;
            }

            try
            {
                if (!app.ApplicationId.Equals(_currentApplicationId) || _currentIndex < 0)
                {
                    _currentIndex = 0;
                }

                if (app.EmpRefs == null)
                {
                    _empRefs = new List<EmpRefData>();
                }
                else
                {
                    _empRefs = app.EmpRefs;
                }

                if (_empRefs.Any())
                {
                    EnableEmpRef();
                    this.SetCurrentEmpRef(_empRefs[_currentIndex]);
                    SetLabel(lblEmployment, _currentIndex + 1, _empRefs.Count);
                }
                else
                {
                    DisableEmpRef();
                    SetLabel(lblEmployment, 0, 0);
                }

                _currentApplicationId = app.ApplicationId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void SetLabel(Label label, int index, int count)
        {
            label.Text = string.Format("{0}/{1}", index, count);
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            SaveCurrentReference();
            app.EmpRefs = GetEmpRefs();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_empRefs != null && _empRefs.Any())
            {
                SaveCurrentReference();
                int preIndex = _currentIndex - 1;

                if (_empRefs.ElementAtOrDefault(preIndex) == null)
                {
                    return;
                }

                if (_empRefs[preIndex] != null)
                {
                    SetLabel(lblEmployment, preIndex + 1, _empRefs.Count);
                    this.SetCurrentEmpRef(_empRefs[preIndex]);
                    _currentIndex = preIndex;
                }
            }
        }

        private void btnAddRef_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            try
            {
                if (_empRefs == null) _empRefs = new List<EmpRefData>();

                EnableEmpRef();
                EmpRefData empRef = new EmpRefData();
                empRef.SW = "N/A";
                empRef.Pos = "N/A";
                empRef.Hired = "N/A";
                empRef.Termination = "N/A";
                empRef.FullTime = "N/A";
                empRef.Salary = "N/A";
                empRef.RH = "N/A";

                _empRefs.Add(empRef);
                SetCurrentEmpRef(empRef);
                _currentIndex = _empRefs.Count - 1;
                SetLabel(lblEmployment, _currentIndex + 1, _empRefs.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
                throw;
            }
        }

        private void btnDelRef_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_empRefs == null || _empRefs.Count == 0) return;

            if (MessageBox.Show("Delete the Credit Reference that is currently being displayed ?", "Delete Credit Reference", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (_empRefs != null && _empRefs.Any())
                {
                    _empRefs.RemoveAt(_currentIndex);

                    if (_empRefs.ElementAtOrDefault(_currentIndex) != null)
                    {
                        EmpRefData empRef = _empRefs[_currentIndex];
                        SetCurrentEmpRef(empRef);
                        SetLabel(lblEmployment, _currentIndex + 1, _empRefs.Count);
                    }
                    else
                    {
                        _currentIndex = _currentIndex - 1;
                        if (_empRefs.ElementAtOrDefault(_currentIndex) != null)
                        {
                            EmpRefData empRef = _empRefs[_currentIndex];
                            SetCurrentEmpRef(empRef);
                            SetLabel(lblEmployment, _currentIndex + 1, _empRefs.Count);
                        }
                        else
                        {
                            SetLabel(lblEmployment, 0, 0);
                            ResetControls();
                            DisableEmpRef();
                        }
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_empRefs != null && _empRefs.Any())
            {
                SaveCurrentReference();
                int nextIndex = _currentIndex + 1;

                if (_empRefs.ElementAtOrDefault(nextIndex) == null) return;

                if (_empRefs[nextIndex] != null)
                {
                    SetLabel(lblEmployment, nextIndex + 1, _empRefs.Count);
                    this.SetCurrentEmpRef(_empRefs[nextIndex]);
                    _currentIndex = nextIndex;
                }
            }
        }

        private void btnRefs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_empRefs == null || _empRefs.Count == 0) return;

            StandardTemplate.RootItemData rootData = StandardTemplate.RootItemData.EMP_REFS_ID;

            contextMenu.Items.Clear();

            using (new HourGlass())
            {
                StandardTemplateApiRepository templateApi = new StandardTemplateApiRepository();
                lstTemplateRefs = templateApi.FindChildren(rootData.Value).ToList();
            }

            if (lstTemplateRefs != null && lstTemplateRefs.Any())
            {
                foreach (TemplateItem item in lstTemplateRefs)
                {
                    if (item.ParentId.Id == rootData.Value)
                    {
                        ToolStripMenuItem submenu = new ToolStripMenuItem();
                        submenu.Text = item.Name;

                        List<TemplateItem> itemChildren = GetChildren(lstTemplateRefs, item.TemplateItemId.Id);
                        if (itemChildren.Count > 0)
                        {
                            ToolStripMenuItem submenu1 = new ToolStripMenuItem();
                            submenu1.Click += submenu_Click;

                            foreach (TemplateItem value in itemChildren)
                            {
                                submenu1.Text = value.Name;
                            }
                            submenu.DropDownItems.Add(submenu1);
                        }
                        contextMenu.Items.Add(submenu);
                    }
                }
            }

            contextMenu.Show(btnRefs, new Point(0, btnRefs.Height));
        }

        private void submenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem subitem = sender as ToolStripMenuItem;

            TemplateItem selectedTemplate = (from t in lstTemplateRefs
                                             where t.Name == subitem.Text
                                             select t).First();

            if (selectedTemplate != null)
            {
                SetTemplateContent(selectedTemplate.Caption);
            }
        }

        private List<TemplateItem> GetChildren(List<TemplateItem> listAllTemplates, string rootId)
        {
            List<TemplateItem> result = new List<TemplateItem>();
            foreach (TemplateItem item in listAllTemplates)
            {
                if (item.ParentId.Id == rootId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string templateName = e.ClickedItem.Text;

            TemplateItem selectedTemplate = (from t in lstTemplateRefs
                                             where t.Name == templateName
                                             select t).First();

            if (selectedTemplate != null)
            {
                SetTemplateContent(selectedTemplate.Caption);
            }
        }

        private void SetTemplateContent(string content)
        {
            try
            {
                if (string.IsNullOrEmpty(content)) return;

                StandardTemplate.EmpRefsData data = XmlSerializationHelper.Deserialize<StandardTemplate.EmpRefsData>(content);

                if (BeforeSetTemplateRentalRef != null)
                {
                    BeforeSetTemplateEventArgs args = new BeforeSetTemplateEventArgs(data.EmpRefs);
                    BeforeSetTemplateRentalRef(this, args);
                    data.EmpRefs = args.Content;
                }

                try
                {
                    // Check the string contents '\n' and the end or not.. If not, append Line Break for the string..
                   
                    string str = txtComment.Text;

                    var x = str.IndexOf("\n");

                    if (x != str.Length - 1)
                    {
                        txtComment.AppendText("\n");
                    }

                    txtComment.Select(txtComment.TextLength, 0);
                    txtComment.SelectedRtf = data.EmpRefs;

                   
                }
                catch
                //in case string format is not rtf
                {
                    string currentString = this.txtComment.Text;
                    txtComment.Text = currentString + Environment.NewLine + data.EmpRefs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void btnCopy_MouseDown(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            if (_empRefs == null || _empRefs.Count == 0 || _currentIndex < 0)
            {
                return;
            }

            EmpRefData currentData = _empRefs[_currentIndex];
            if (currentData == null)
            {
                return;
            }

            DragDropData.EmpRef data = new DragDropData.EmpRef();
            data.list = AutoMapper.Mapper.Map<List<EmpRefData>, List<EmpRefData>>(_empRefs);
            data.currentIndex = _currentIndex;

            btnCopy.DoDragDrop(data, DragDropEffects.Move);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            EmpRefData currentItem = GetCurrentEmpRef();
            int currentIndex = _currentIndex;

            if (_currentIndex < _empRefs.Count - 1)
            {
                var tmp = _empRefs[currentIndex];
                _empRefs[currentIndex] = _empRefs[currentIndex + 1];
                _empRefs[currentIndex + 1] = tmp;
            }
            else return;

            SetCurrentEmpRef(_empRefs[currentIndex + 1]);

            _currentIndex = currentIndex + 1;

            this.SetLabel(lblEmployment, _currentIndex + 1, _empRefs.Count);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentApplicationId))
                return;

            EmpRefData currentItem = GetCurrentEmpRef();
            int currentIndex = _currentIndex;

            if (_currentIndex > 0)
            {
                var tmp = _empRefs[currentIndex];
                _empRefs[currentIndex] = _empRefs[currentIndex - 1];
                _empRefs[currentIndex - 1] = tmp;
            }
            else return;

            SetCurrentEmpRef(_empRefs[currentIndex - 1]);

            _currentIndex = currentIndex - 1;

            this.SetLabel(lblEmployment, _currentIndex + 1, _empRefs.Count);
        }
    }
}
