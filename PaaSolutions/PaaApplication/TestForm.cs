using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaaApplication.Forms;
using IdentityAccess.Application.Command.Identity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Configuration;
using Common.Infrastructure.ApiClient;

namespace PaaApplication
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void commonChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCommonChart formCommonChart = new FormCommonChart();
            formCommonChart.Show();
        }

        private void customChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCustomChart formCustomChart = new FormCustomChart();
            formCustomChart.Show();
        }
    }
}
