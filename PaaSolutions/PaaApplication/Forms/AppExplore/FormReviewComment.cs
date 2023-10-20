using Common.Infrastructure.OLV;
using Common.Infrastructure.UI;
using Core.Application.Data.ClientInfo;
using Core.Application.Data.ExploreApps;
using Core.Domain.Model.ExploreApps;
using Core.Infrastructure.ClientInfo;
using Core.Infrastructure.ExploreApps;
using FastMember;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.AppExplore
{
    public partial class FormReviewComment : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool hasEditPermission { get; set; }


        public FormReviewComment(string applicantName)
        {
            InitializeComponent();

            lblApplicantName.Text = applicantName;

            List<string> defaultAreas = ReviewComment.GetDefaultAreas();
            foreach (string area in defaultAreas)
            {
                cmbAreas.Items.Add(area);
            }

            InitRichTextBox();
        }

        private void InitRichTextBox()
        {
            rtbComment.BulletIndent = 10;            
        }

        public void UpdateControlFromReviewComment(ReviewComment comment, string applicationName)
        {
            // Check permissions
            if (this.hasEditPermission)
            {
                this.rtbComment.Enabled = true;
                this.cmbAreas.Enabled = true;
                pnlAddArea.Visible = true;
                lblCorrectArea.Visible = false;
            }
            else
            {
                pnlAddArea.Visible = false;
                lblCorrectArea.Location = new Point(12, 56);
                this.rtbComment.Enabled = false;
                this.cmbAreas.Enabled = false;
            }

            lblApplicantName.Text = applicationName;

            if (comment == null)
                return;
            listboxAreas.Items.Clear();



            foreach (string area in comment.Areas)
            {
                listboxAreas.Items.Add(area);
            }

            rtbComment.RichText = comment.Comment;
        }

        public void UpdateReviewCommentFromControls(ReviewComment comment)
        {
            comment.Comment = rtbComment.RichText;
            comment.Areas.Clear();
            foreach (string area in listboxAreas.Items)
            {
                comment.Areas.Add(area);
            }
        }

        private void cmbAreas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listboxAreas.Items.Add(cmbAreas.Text);
            }
        }

        private void listboxAreas_KeyDown(object sender, KeyEventArgs e)
        {
            if (!this.hasEditPermission)
            {
                return;
            }

            ListBox lb = sender as ListBox;
            if (e.KeyCode == Keys.Delete && lb.SelectedIndex >= 0)
            {
                int index = lb.SelectedIndex;
                lb.Items.RemoveAt(index);
                if (index >= lb.Items.Count)
                    index--;
                lb.SelectedIndex = index;
            }
        }
    }
}
