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
using Common.Infrastructure.Helper;
using Administration.Infrastructure.StandardTemplate;
using Common.Infrastructure.UI;
using PaaApplication.ExtendControls;
using PaaApplication.Models.AppExplore;

namespace PaaApplication.UserControls.AppExplore.GeneralInfo
{
    public partial class FinalInfoControl : UserControl
    {
        public TextBox FinCommentControl
        {
            get { return txtFinComment; }
        }

        public TextBox AppCommentControl
        {
            get { return txtAppComment; }
        }

        public string SpecialCriteriaInfo { get; set; }

        public string ClientAppliedName { get; set; }

        private List<TemplateItem> lstTemplateRefs = new List<TemplateItem>();
        private RichTextBoxContextMenu richTextBoxContextMenu;
        public EventHandler<BeforeSetTemplateEventArgs> BeforeSetTemplateRentalRef;

        private bool ignoreCheckedEvent = false;

        public FinalInfoControl()
        {
            InitializeComponent();
        }

        public void IsResidentialReport(string str)
        {
            if (str == "Residential") grpCheckboxs.Show();

            else grpCheckboxs.Hide();
        }

        public void btnSComments_Click(object sender, EventArgs e)
        {
            StandardTemplate.RootItemData rootData = StandardTemplate.RootItemData.FINAL_CMTS_ID;

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
                    ToolStripMenuItem submenu = new ToolStripMenuItem();
                    submenu.Click += submenu_Click;

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
                                submenu.DropDownItems[i].Click += dropDownItem_Click;
                            }
                        }
                        contextMenu.Items.Add(submenu);
                    }
                }
            }

            contextMenu.Show(btnSComments, new Point(0, btnSComments.Height));
        }

        private RecommendationFactInfoData GetRecommendationFactInfoData()
        {
            RecommendationFactInfoData data = new RecommendationFactInfoData();

            if (chBoxQualifier.Checked == true)
                data.QualifiedRoommate = true;
            else
                data.QualifiedRoommate = false;

            if (chboxCosigner.Checked == true)
                data.Cosigner = true;
            else
                data.Cosigner = false;

            if (chboxFirst.Checked == true)
                data.FirstAndSecurity = true;
            else
                data.FirstAndSecurity = false;

            if (chboxAbs.Checked == true)
                data.AbsPosNO = true;
            else
                data.AbsPosNO = false;

            if (chboxRental.Checked == true)
                data.RentalHistory = true;
            else
                data.RentalHistory = false;

            if (chboxCredit.Checked == true)
                data.CreditHistory = true;
            else
                data.CreditHistory = false;

            if (chboxRent.Checked == true)
                data.RentToIncome = true;
            else
                data.RentToIncome = false;

            if (chboxFalse.Checked == true)
                data.FalseOrDiscrimminationInfo = true;
            else
                data.FalseOrDiscrimminationInfo = false;

            if (chboxShort.Checked == true)
                data.ShortTimeOnTheJob = true;
            else
                data.ShortTimeOnTheJob = false;

            if (chboxLack.Checked == true)
                data.LackOfInformation = true;
            else
                data.LackOfInformation = false;

            if (chboxCriminal.Checked == true)
                data.CrimminalHistory = true;
            else
                data.CrimminalHistory = false;

            return data;
        }

        private void SetRecommendationFactInfoData(RecommendationFactInfoData data)
        {
            if (data == null)
                return;

            chBoxQualifier.Checked = data.QualifiedRoommate;
            chboxCosigner.Checked = data.Cosigner;
            chboxFirst.Checked = data.FirstAndSecurity;
            chboxAbs.Checked = data.AbsPosNO;
            chboxRental.Checked = data.RentalHistory;
            chboxCredit.Checked = data.CreditHistory;
            chboxRent.Checked = data.RentToIncome;
            chboxFalse.Checked = data.FalseOrDiscrimminationInfo;
            chboxShort.Checked = data.ShortTimeOnTheJob;
            chboxLack.Checked = data.LackOfInformation;
            chboxCriminal.Checked = data.CrimminalHistory;
        }

        public string GetFinalComments()
        {  
            return txtFinComment.Text;
        }

        private void SetFinalComments(string finalComments)
        {
            if (string.IsNullOrEmpty(finalComments))
            {
                txtFinComment.Clear();
                return;
            }

            txtFinComment.Text = Helper.Utils.RtfToText(finalComments);
        }

        public string GetStaffComments()
        {
            return txtAppComment.Text;
        }

        private void SetStaffComments(string staffiComments)
        {
            txtAppComment.Text = staffiComments;
        }

        public void ResetControls()
        {
            chBoxQualifier.Checked = false;
            chboxCosigner.Checked = false;
            chboxFirst.Checked = false;
            chboxAbs.Checked = false;
            chboxRental.Checked = false;
            chboxCredit.Checked = false;
            chboxRent.Checked = false;
            chboxFalse.Checked = false;
            chboxShort.Checked = false;
            chboxLack.Checked = false;
            chboxCriminal.Checked = false;

            txtFinComment.Clear();
            txtAppComment.Clear();
        }

        public void UpdateControlsFromApp(AppData app)
        {
            ResetControls();

            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            SetRecommendationFactInfoData(app.Recommendation);
            SetFinalComments(app.FinalComments);
            SetStaffComments(app.StaffComments);
        }

        public void UpdateAppFromControls(AppData app)
        {
            if (app == null || string.IsNullOrEmpty(app.ApplicationId))
            {
                return;
            }

            app.Recommendation = GetRecommendationFactInfoData();
            app.FinalComments = GetFinalComments();
            app.StaffComments = GetStaffComments();
        }

        private void dropDownItem_Click(object sender, EventArgs e)
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

        private void submenu_Click(object sender, EventArgs e)
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
            }
        }

        private void SetTemplateContent(string content)
        {
            try
            {
                if (string.IsNullOrEmpty(content)) return;
                StandardTemplate.FinalCmtsData data = XmlSerializationHelper.Deserialize<StandardTemplate.FinalCmtsData>(content);            

                if (BeforeSetTemplateRentalRef != null)
                {
                    BeforeSetTemplateEventArgs args = new BeforeSetTemplateEventArgs(data.FinalCmts);
                    BeforeSetTemplateRentalRef(this, args);
                    data.FinalCmts = args.Content;
                }

                try
                {
                    // Check the string contents '\n' and the end or not.. If not, append Line Break for the string..

                    string str = txtFinComment.Text;

                    var x = str.LastIndexOf("\n");

                    if (x != -1 && x == str.Length - 1)
                    {
                        txtFinComment.AppendText("\n");
                    }

                    txtFinComment.Select(txtFinComment.TextLength, 0);

                    string currentString = this.txtFinComment.Text;

                    // Always show default format when apend text to rich text box, no longer depend on the fomat from FinalCmts 
                    txtFinComment.Text = currentString + Environment.NewLine + Helper.Utils.RtfToText(data.FinalCmts);                
                }
                catch
                {
                    string currentString = this.txtFinComment.Text;
                    txtFinComment.Text = currentString + Environment.NewLine + data.FinalCmts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }

        public void SetVisibleForButtonCriteria(bool isVisible)
        {
            this.btnCriteria.Visible = isVisible;
        }

        private void btnCriteria_Click(object sender, EventArgs e)
        {
            string messageString = string.Format("The following information should be noted for {0} : \n \n {1}", this.ClientAppliedName, this.SpecialCriteriaInfo);

            MessageBox.Show(messageString, "Special Criteria Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public void OpenSpecialCriteriaInfo()
        {
            if (this.btnCriteria.Visible)
            {
                btnCriteria_Click(this, null);
            }
        }

        #region Check Logic
        
        private void CheckChangedHandler(object sender)
        {
            CheckBox chk = sender as CheckBox;
            if (chk == null)
                return;
            ignoreCheckedEvent = true;

            if (chk == chboxAbs && chk.Checked == true)
            {
                chboxCosigner.Checked = false;
                chboxFirst.Checked = false;
            }
            else if (chk == chboxCosigner && chk.Checked == true)
            {
                chboxAbs.Checked = false;
            }
            else if (chk == chboxFirst && chk.Checked == true)
            {
                chboxAbs.Checked = false;
            }
            ignoreCheckedEvent = false;
        }

        private void chboxCosigner_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreCheckedEvent)
                return;
            CheckChangedHandler(sender);
        }

        private void chboxFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreCheckedEvent)
                return;
            CheckChangedHandler(sender);
        }

        private void chboxAbs_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreCheckedEvent)
                return;
            CheckChangedHandler(sender);
        }
        #endregion        
    }
}
