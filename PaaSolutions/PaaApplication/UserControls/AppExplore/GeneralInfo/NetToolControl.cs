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
using Administration.Domain.Model.InternetTool;
using Administration.Infrastructure.InternetTool;
using System.IO;
using System.Drawing.Imaging;


namespace PaaApplication.UserControls.AppExplore.GeneralInfo
{
    public partial class NetToolControl : UserControl
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public NetToolControl()
        {
            InitializeComponent();
        }

        public void LoadInternetToolData()
        {
            groupBox.Controls.Clear();
            List<InternetItem> internetItems = InternetToolCachedApiQuery.Instance.GetAllInternetItems();
            if (internetItems != null && internetItems.Count > 0)
            {
                for (int i = 0; i < internetItems.Count; i++)
                {
                    string caption = internetItems[i].Caption;
                    string target = internetItems[i].Target;

                    Button btn = new Button();
                    btn.Size = new Size(100, 100);
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.Text = ResizeTextLength(caption);
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.BringToFront();

                    btn.Click += delegate(object sender, EventArgs e)
                    {
                        OpenTarget(target);
                    };

                    ToolTip toolTip = new ToolTip();
                    toolTip.SetToolTip(btn, string.Format("{0}\n{1}", caption, target));

                    using (MemoryStream memoryStream = new MemoryStream(internetItems[i].Image))
                    {
                        btn.Image = Image.FromStream(memoryStream);
                    }

                    btn.Location = new Point(10 + 113 * (i % 5), 25 + 113 * (i / 5));
                    groupBox.Controls.Add(btn);
                }
            }
        }

        private string ResizeTextLength(string originText)
        {
            string result = originText;

            if (result.Length > 20)
            {
                result = result.Substring(0, 20) + "...";
            }

            return result;
        }

        private void OpenTarget(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                MessageBox.Show("Cannot open this item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (target.IndexOf("http://") != 0 && target.IndexOf("https://") != 0)
            {
                target = target.Insert(0, "http://");
            }

            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _logger.Error(ex.ToString());
            }
        }
    }
}
