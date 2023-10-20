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
using StandardTemplate = Administration.Application.Data.StandardTemplate;
using Administration.Domain.Model.StandardTemplate;
using Administration.Infrastructure.StandardTemplate;
using Common.Infrastructure.UI;
using Common.Infrastructure.Helper;
using PaaApplication.Models.AppExplore;
using PaaApplication.Helper;

namespace PaaApplication.UserControls.AppExplore.EmpInfo
{
    public partial class EmpTypeOneControl : UserControl
    {
        public TextBox Heading1Control
        {
            get { return txtHeading1; }
        }

        public TextBox Pos1Control
        {
            get { return txtPos1; }
        }

        public TextBox Hire1Control
        {
            get { return txtHire1; }
        }

        public TextBox SW1Control
        {
            get { return txtSW1; }
        }

        public TextBox Money1Control
        {
            get { return txtMoney1; }
        }

        public TextBox Co1Control
        {
            get { return txtCo1; }
        }

        public TextBox FT1Control
        {
            get { return txtFT1; }
        }

        public TextBox Tele1Control
        {
            get { return txtTele1; }
        }

        public TextBox MiscCommentControl
        {
            get { return txtMiscComment; }
        }

        public TextBox Heading2Control
        {
            get { return txtHeading2; }
        }

        public TextBox Pos2Control
        {
            get { return txtPos2; }
        }

        public TextBox Hire2Control
        {
            get { return txtHire2; }
        }

        public TextBox SW2Control
        {
            get { return txtSW2; }
        }

        public TextBox Money2Control
        {
            get { return txtMoney2; }
        }

        public TextBox Co2Control
        {
            get { return txtCo2; }
        }

        public TextBox FT2Control
        {
            get { return txtFT2; }
        }

        public TextBox Tele2Control
        {
            get { return txtTele2; }
        }

        private List<TemplateItem> lstTemplateRefs = new List<TemplateItem>();
        private List<TemplateItem> lstTemplateRefs2 = new List<TemplateItem>();
        public EventHandler<BeforeSetTemplateEventArgs> BeforeSetTemplateRentalRef;

        public EmpTypeOneControl()
        {
            InitializeComponent();
        }

        private void EmpTypeOne_Load(object sender, EventArgs e)
        {
        }

        private void SetEmpVer(EmpVerData empver)
        {
            if (empver == null)
                return;

            txtHeading1.Text = empver.Heading;
            txtPos1.Text = empver.Pos;
            txtHire1.Text = empver.Hire;
            txtSW1.Text = empver.SW;
            txtMoney1.Text = empver.Salary;
            txtCo1.Text = empver.Co;
            txtFT1.Text = empver.FullTime;
            txtTele1.Text = empver.Tele;
            txtMiscComment.Text = empver.MiscComment;
            txtHeading2.Text = empver.Heading2;
            txtPos2.Text = empver.Pos2;
            txtHire2.Text = empver.Hire2;
            txtSW2.Text = empver.SW2;
            txtMoney2.Text = empver.Salary2;
            txtCo2.Text = empver.Co2;
            txtFT2.Text = empver.FullTime2;
            txtTele2.Text = empver.Tele2;
        }

        public EmpVerData GetEmpVer()
        {
            EmpVerData empver = new EmpVerData();
            empver.Heading = txtHeading1.Text;
            empver.Pos = txtPos1.Text;
            empver.Hire = txtHire1.Text;
            empver.SW = txtSW1.Text;
            empver.Salary = txtMoney1.Text;
            empver.Co = txtCo1.Text;
            empver.FullTime = txtFT1.Text;
            empver.Tele = txtTele1.Text;
            empver.MiscComment = txtMiscComment.Text;
            empver.Heading2 = txtHeading2.Text;
            empver.Pos2 = txtPos2.Text;
            empver.Hire2 = txtHire2.Text;
            empver.SW2 = txtSW2.Text;
            empver.Salary2 = txtMoney2.Text;
            empver.Co2 = txtCo2.Text;
            empver.FullTime2 = txtFT2.Text;
            empver.Tele2 = txtTele2.Text;

            return empver;
        }

        public void ResetControls()
        {
            txtHeading1.Text = "";
            txtPos1.Text = "";
            txtHire1.Text = "";
            txtSW1.Text = "";
            txtMoney1.Text = "";
            txtCo1.Text = "";
            txtFT1.Text = "";
            txtTele1.Text = "";
            txtMiscComment.Text = "";
            txtHeading2.Text = "";
            txtPos2.Text = "";
            txtHire2.Text = "";
            txtSW2.Text = "";
            txtMoney2.Text = "";
            txtCo2.Text = "";
            txtFT2.Text = "";
            txtTele2.Text = "";
        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetControls();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            SetEmpVer(app.EmpVer);
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            EmpVerData empver = GetEmpVer();
            app.EmpVer = empver;
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

        #region Verfs1

        public void btnVerfs1_Click(object sender, EventArgs e)
        {
            StandardTemplate.RootItemData rootData = StandardTemplate.RootItemData.EMP_VERIFS_1_ID;
            contextMenu1.Items.Clear();

            using (new HourGlass())
            {
                StandardTemplateApiRepository templateApi = new StandardTemplateApiRepository();
                lstTemplateRefs = templateApi.FindChildren(rootData.Value).ToList();
            }

            if (lstTemplateRefs != null && lstTemplateRefs.Any())
            {
                foreach (TemplateItem item in lstTemplateRefs)
                {
                    ToolStripMenuItem submenu = new ToolStripMenuItem();
                    submenu.Click += submenu1_Click;

                    if (item.ParentId.Id == rootData.Value)
                    {
                        submenu.Text = item.Name;

                        List<TemplateItem> itemChildren = GetChildren(lstTemplateRefs, item.TemplateItemId.Id);
                        if (itemChildren.Any())
                        {
                            foreach (TemplateItem value in itemChildren)
                            {
                                submenu.DropDownItems.Add(value.Name);
                            }
                            for (int i = 0; i < submenu.DropDownItems.Count; i++)
                            {
                                submenu.DropDownItems[i].Click += dropDownItem1_Click;
                            }
                        }
                        contextMenu1.Items.Add(submenu);
                    }
                }
            }

            contextMenu1.Show(btnVerfs1, new Point(0, btnVerfs1.Height));
        }

        private void dropDownItem1_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            TemplateItem selectedTemplate = (from t in lstTemplateRefs
                                             where t.Name == item.Text
                                             select t).First();

            if (selectedTemplate != null)
            {
                if (!string.IsNullOrEmpty(selectedTemplate.Caption))
                {
                    SetTemplateContent(selectedTemplate.Caption);
                }
                else
                {
                    txtMiscComment.Clear();
                }
            }
        }

        private void SetTemplateContent(string content)
        {
            try
            {
                txtPos1.Text = "N/A";
                txtHire1.Text = "N/A";
                txtMoney1.Text = "N/A";
                txtFT1.Text = "N/A";

                txtSW1.Clear();
                txtCo1.Clear();
                txtTele1.Clear();

                StandardTemplate.EmpVerifs1Data data = XmlSerializationHelper.Deserialize<StandardTemplate.EmpVerifs1Data>(content);

                if (BeforeSetTemplateRentalRef != null)
                {
                    BeforeSetTemplateEventArgs args = new BeforeSetTemplateEventArgs(data.SW);
                    BeforeSetTemplateRentalRef(this, args);
                    data.SW = args.Content;

                    BeforeSetTemplateEventArgs argsCo = new BeforeSetTemplateEventArgs(data.Co);
                    BeforeSetTemplateRentalRef(this, argsCo);
                    data.Co = argsCo.Content;

                    BeforeSetTemplateEventArgs argsTele = new BeforeSetTemplateEventArgs(data.Tele);
                    BeforeSetTemplateRentalRef(this, argsTele);
                    data.Tele = argsTele.Content;
                }

                txtSW1.Text = data.SW;
                txtCo1.Text = data.Co;
                txtTele1.Text = data.Tele;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        #endregion Verfs1

        private void submenu1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem subitem = sender as ToolStripMenuItem;

            TemplateItem selectedTemplate = (from t in lstTemplateRefs
                                             where t.Name == subitem.Text
                                             select t).First();

            if (selectedTemplate != null)
            {
                if (!string.IsNullOrEmpty(selectedTemplate.Caption))
                {
                    SetTemplateContent(selectedTemplate.Caption);
                }
                else
                {
                    txtTele1.Clear();
                    txtCo1.Clear();
                    txtSW1.Clear();
                }
            }
        }

        public void btnVerfs2_Click(object sender, EventArgs e)
        {
            StandardTemplate.RootItemData rootData = StandardTemplate.RootItemData.EMP_VERIFS_2_ID;
            contextMenu2.Items.Clear();

            using (new HourGlass())
            {
                StandardTemplateApiRepository templateApi = new StandardTemplateApiRepository();
                lstTemplateRefs2 = templateApi.FindChildren(rootData.Value).ToList();
            }

            if (lstTemplateRefs2 != null && lstTemplateRefs2.Any())
            {
                foreach (TemplateItem item in lstTemplateRefs2)
                {
                    ToolStripMenuItem submenu = new ToolStripMenuItem();
                    submenu.Click += submenu2_Click;

                    if (item.ParentId.Id == rootData.Value)
                    {
                        submenu.Text = item.Name;

                        List<TemplateItem> itemChildren = GetChildren(lstTemplateRefs2, item.TemplateItemId.Id);
                        if (itemChildren.Any())
                        {
                            foreach (TemplateItem value in itemChildren)
                            {
                                submenu.DropDownItems.Add(value.Name);
                            }
                            for (int i = 0; i < submenu.DropDownItems.Count; i++)
                            {
                                submenu.DropDownItems[i].Click += dropDownItem2_Click;
                            }
                        }
                        contextMenu2.Items.Add(submenu);
                    }
                }
            }

            contextMenu2.Show(btnVerfs2, new Point(0, btnVerfs2.Height));
        }

        private void submenu2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem subitem = sender as ToolStripMenuItem;

            TemplateItem selectedTemplate = (from t in lstTemplateRefs2
                                             where t.Name == subitem.Text
                                             select t).First();

            if (selectedTemplate != null)
            {
                if (!string.IsNullOrEmpty(selectedTemplate.Caption))
                {
                    SetTemplateContent2(selectedTemplate.Caption);
                }
                else
                {
                    txtMiscComment.Clear();
                }
            }
        }

        private void SetTemplateContent2(string content)
        {
            try
            {
                txtPos2.Text = "N/A";
                txtHire2.Text = "N/A";
                txtMoney2.Text = "N/A";
                txtFT2.Text = "N/A";

                txtSW2.Clear();
                txtCo2.Clear();
                txtTele2.Clear();

                StandardTemplate.EmpVerifs2Data data = XmlSerializationHelper.Deserialize<StandardTemplate.EmpVerifs2Data>(content);

                if (BeforeSetTemplateRentalRef != null)
                {
                    BeforeSetTemplateEventArgs args = new BeforeSetTemplateEventArgs(data.SW);
                    BeforeSetTemplateRentalRef(this, args);
                    data.SW = args.Content;

                    BeforeSetTemplateEventArgs argsCo = new BeforeSetTemplateEventArgs(data.Co);
                    BeforeSetTemplateRentalRef(this, argsCo);
                    data.Co = argsCo.Content;

                    BeforeSetTemplateEventArgs argsTele = new BeforeSetTemplateEventArgs(data.Tele);
                    BeforeSetTemplateRentalRef(this, argsTele);
                    data.Tele = argsTele.Content;
                }

                txtSW2.Text = data.SW;
                txtCo2.Text = data.Co;
                txtTele2.Text = data.Tele;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        private void dropDownItem2_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            TemplateItem selectedTemplate = (from t in lstTemplateRefs2
                                             where t.Name == item.Text
                                             select t).First();

            if (selectedTemplate != null)
            {
                if (!string.IsNullOrEmpty(selectedTemplate.Caption))
                {
                    SetTemplateContent2(selectedTemplate.Caption);
                }
                else
                {
                    txtTele2.Clear();
                    txtCo2.Clear();
                    txtSW2.Clear();
                }
            }
        }

        #region txtSW1
        private void txtSW1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtSW1);
        }
        #endregion

        #region txtFT1
        private void txtFT1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtFT1);
        }
        #endregion

        #region txtMoney1
        private void txtMoney1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtMoney1);
        }
        #endregion

        #region txtHire1
        private void txtHire1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtHire1);
        }
        #endregion

        #region txtTele1
        private void txtTele1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtTele1);
        }
        #endregion

        #region txtPos1
        private void txtPos1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtPos1);
        }
        #endregion

        #region txtCo1
        private void txtCo1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtCo1);
        }
        #endregion

        #region txtHeading1
        private void txtHeading1_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtHeading1);
        }
        #endregion

        #region txtSW2
        private void txtSW2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtSW2);
        }
        #endregion

        #region txtFT2
        private void txtFT2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtFT2);
        }
        #endregion

        #region txtMoney2
        private void txtMoney2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtMoney2);
        }
        #endregion

        #region txtHire2
        private void txtHire2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtHire2);
        }
        #endregion

        #region txtTele2
        private void txtTele2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtTele2);
        }
        #endregion

        #region txtPos2
        private void txtPos2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtPos2);
        }
        #endregion

        #region txtCo2
        private void txtCo2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtCo2);
        }
        #endregion

        #region txtHeading2
        private void txtHeading2_MouseClick(object sender, EventArgs e)
        {
            HighlightHelper.Highlight_TextBox(txtHeading2);
        }
        #endregion
    }
}
