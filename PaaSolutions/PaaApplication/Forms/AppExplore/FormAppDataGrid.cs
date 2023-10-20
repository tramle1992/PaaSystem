using Common.Infrastructure.UI;
using Core.Application.Data.ExploreApps;
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
    public partial class FormAppDataGrid : BaseForm
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<AppData> appList = null;

        public FormAppDataGrid()
        {
            InitializeComponent();
        }

        public FormAppDataGrid(List<AppData> apps) : this()
        {
            this.appList = apps;
        }

        private void FormAppDataGrid_LoadCompleted(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                Refresh();
            }
        }

        public void SetApps(List<AppData> apps)
        {
            using (new HourGlass())
            {
                this.appList = apps;
                Refresh();
            }
        }

        private void Refresh()
        {
            this.appDataGridControl1.Refresh(this.appList);
        }
    }
}
