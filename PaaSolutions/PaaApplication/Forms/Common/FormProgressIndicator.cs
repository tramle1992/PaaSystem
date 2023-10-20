using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Infrastructure.UI;

namespace PaaApplication.Forms.Common
{
    public partial class FormProgressIndicator : BaseForm
    {

        public int NumberSpoke { get; set; }

        public int SpokeThickness { get; set; }

        public int InnerCircleRadius { get; set; }

        public int OuterCircleRadius { get; set; }

        public int RotationSpeed { get; set; }

        public FormProgressIndicator(string taskName)
        {
            InitializeComponent();

            NumberSpoke = 13;
            SpokeThickness = 2;
            InnerCircleRadius = 10;
            OuterCircleRadius = 20;
            RotationSpeed = 80;
            this.lblTaskName.Text = taskName;
            this.lblProgress.Text = "Progress: 0%";
            this.Refresh();
        }

        public void SetActive(bool active)
        {
            this.loadingCircle.Active = active;
            
        }

        public void Refresh()
        {
            loadingCircle.NumberSpoke = this.NumberSpoke;
            loadingCircle.SpokeThickness = this.SpokeThickness;
            loadingCircle.InnerCircleRadius = InnerCircleRadius;
            loadingCircle.OuterCircleRadius = this.OuterCircleRadius;
            loadingCircle.RotationSpeed = this.RotationSpeed;
        }
    }
}
