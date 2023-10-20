using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PaaApplication.ExtendControls
{
    public class WaterMarkTextBox : TextBox
    {
        public string WatermarkText { get; set; }

        public Color WatermarkColor { get; set; }

        private Color TextColor { get; set; }

        private bool isInTransition;

        public WaterMarkTextBox()
        {
            PictureBox pic = new PictureBox();
            pic.Width = 16;
            pic.Height = 16;
            pic.BackgroundImage = PaaApplication.Properties.Resources.search16x16;
            pic.Location = new Point(280, 2);

            this.Controls.Add(pic);
            WatermarkColor = SystemColors.GrayText;
        }

        private bool HasText { get { return string.IsNullOrEmpty(Text); } }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (HasText) return;

            isInTransition = true;
            ForeColor = TextColor;
            isInTransition = false;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            if (!isInTransition) //the change came from outside
                TextColor = ForeColor;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            //if (HasText) return;            
            isInTransition = true;
            ForeColor = WatermarkColor;
            isInTransition = false;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
