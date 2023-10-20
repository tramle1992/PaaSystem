using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Helper
{
    public class LabelMakerHelper
    {
        public class LabelMaker
        {
            private LabelMakerHelper parent;
            private const int NumberOfItemPerPage = 210;

            public string LabelSize { get; set; }
            public int NumOfItemPerPage { get; set; }
            public Size TextBoxSize { get; set; }
            public int ItemPerRow { get; set; }

            public LabelMaker()
            {
                this.LabelSize = "Small";
                this.TextBoxSize = GetTextBoxSize();
                this.NumOfItemPerPage = NumberOfItemPerPage;
                this.ItemPerRow = 3;
            }

            public LabelMaker(string labelSize)
            {
                this.LabelSize = labelSize;
                this.TextBoxSize = GetTextBoxSize();
                this.NumOfItemPerPage = NumberOfItemPerPage;
                this.ItemPerRow = (labelSize.Equals("Large")) ? 2 : 3;
            }

            public LabelMaker(LabelMakerHelper parent)
            {
                this.parent = parent;
            }

            private Size GetTextBoxSize()
            {
                switch (LabelSize)
                {
                    case "Large":
                        return new System.Drawing.Size(356, 84);
                    default:
                        return new System.Drawing.Size(233, 84);
                }
            }
        }
        
    }
}
