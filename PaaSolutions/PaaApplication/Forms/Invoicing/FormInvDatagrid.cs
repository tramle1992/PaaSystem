using Common.Infrastructure.UI;
using Invoice.Application.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.Invoicing
{
    public partial class FormInvDatagrid : BaseForm
    {

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<InvoiceData> invList = null;

        public FormInvDatagrid()
        {
            InitializeComponent();            
        }

        public FormInvDatagrid(List<InvoiceData> invs)
            : this()
        {
            this.invList = invs;
        }

        public void SetInvs(List<InvoiceData> invs)
        {
            using (new HourGlass())
            {
                this.invList = invs;
                Refresh();
            }
        }

        private void Refresh()
        {
            this.invDatagridControl1.Refresh(this.invList);
        }
    }
}
