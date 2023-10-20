using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PaaApplication.Themes
{
    public class BlackSkin : RibbonProfesionalRendererColorTable
    {
        public BlackSkin()
        {
            //#region Fields            

            //Arrow = FromHex("#7C7C7C");
            //ArrowLight = FromHex("#EAF2F9");
            //ArrowDisabled = FromHex("#7C7C7C");
            //Text = FromHex("#000000");

            RibbonBackground = FromHex("#E5E5E5");

            //TabActiveBackbround_2013 = FromHex("#9C9C91");
            //TabSelectedGlow = FromHex("#6D6D66");

            //TabSelectedGlow = FromHex("#757566");
            //PanelDarkBorder = FromHex("#AEB0B4"); 
            //PanelLightBorder = FromHex("#E7E9ED"); 

            //PanelTextBackground = FromHex("#CCCCCC");
            //PanelTextBackgroundSelected = FromHex("#E5E5E5");
            //PanelText = Color.Black;           

            //PanelBackgroundSelected = FromHex("#CCCCCC"); 
            //PanelOverflowBackground = FromHex("#FFFFFF");           

            //#endregion

            OrbDropDownDarkBorder = FromHex("#B1B1B1");
            OrbDropDownLightBorder = FromHex("#FFFFFF");
            OrbDropDownBack = FromHex("#D4D4D4");
            OrbDropDownNorthA = FromHex("#E6E6E6");
            OrbDropDownNorthB = FromHex("#E2E2E2");
            OrbDropDownNorthC = FromHex("#D9D9D9");
            OrbDropDownNorthD = FromHex("#CDCDCD");
            OrbDropDownSouthC = FromHex("#CBCBCB");
            OrbDropDownSouthD = FromHex("#E1E1E1");
            OrbDropDownContentbg = FromHex("#EBEBEB");
            OrbDropDownContentbglight = FromHex("#FAFAFA");

            OrbDropDownSeparatorlight = FromHex("#FAFAFA");
            OrbDropDownSeparatordark = FromHex("#FAFAFA");

            Caption1 = FromHex("#ECECEC");
            Caption2 = FromHex("#EAEAEA");
            Caption3 = FromHex("#E6E6E6");
            Caption4 = FromHex("#E8E8E8");
            Caption5 = FromHex("#DFDFDF");
            Caption6 = FromHex("#F0F0F0");
            Caption7 = FromHex("#D2D2D2");

            RibbonBackground = FromHex("#E5E5E5");

            QuickAccessBorderDark = FromHex("#CBCBCB");
            QuickAccessBorderLight = FromHex("#F6F6F6");
            QuickAccessUpper = FromHex("#ECECEC");
            QuickAccessLower = FromHex("#DADADA");
            OrbOptionBorder = FromHex("#969696");
            OrbOptionBackground = FromHex("#F1F1F1");
            OrbOptionShine = FromHex("#E2E2E2");

            Arrow = FromHex("#7C7C7C");
            ArrowLight = FromHex("#EAF2F9");
            ArrowDisabled = FromHex("#7C7C7C");
            Text = FromHex("#444c70");
            

            TabActiveText = FromHex("#FF6600");
            TabContentNorth = FromHex("#B6BCC6");
            TabContentSouth = FromHex("#E6F0F1");
            TabSelectedGlow = FromHex("#E1D2A5");

            PanelTextBackgroundSelected = FromHex("#b7bdc7");
            //PanelBackgroundSelected = FromHex("#CCCCCC");
            PanelTextBackground = FromHex("#CBCED2");

            ButtonBgOut = FromHex("#B4B9C2");
            ButtonBgCenter = FromHex("#CDD2D8");
            ButtonBorderOut = FromHex("#A9B1B8");
            ButtonBorderIn = FromHex("#DFE2E6");
            ButtonGlossyNorth = FromHex("#DBDFE4");
            ButtonGlossySouth = FromHex("#DFE2E8");
            ButtonDisabledBgOut = FromHex("#E0E4E8");
            ButtonDisabledBgCenter = FromHex("#E8EBEF");
            ButtonDisabledBorderOut = FromHex("#C5D1DE");
            ButtonDisabledBorderIn = FromHex("#F1F3F5");
            ButtonDisabledGlossyNorth = FromHex("#F0F3F6");
            ButtonDisabledGlossySouth = FromHex("#EAEDF1");

            ButtonSelectedBgOut = FromHex("#CCCCCC");
            ButtonSelectedBgCenter = FromHex("#CCCCCC");
            ButtonSelectedBorderOut = FromHex("#CCCCCC");
            ButtonSelectedBorderIn = FromHex("#CCCCCC");
            ButtonSelectedGlossyNorth = FromHex("#CCCCCC");
            ButtonSelectedGlossySouth = FromHex("#CCCCCC");

            ButtonPressedBgOut = FromHex("#F88F2C");
            ButtonPressedBgCenter = FromHex("#FDF1B0");
            ButtonPressedBorderOut = FromHex("#8E8165");
            ButtonPressedBorderIn = FromHex("#F9C65A");
            ButtonPressedGlossyNorth = FromHex("#FDD5A8");
            ButtonPressedGlossySouth = FromHex("#FBB062");
            ButtonCheckedBgOut = FromHex("#F9AA45");
            ButtonCheckedBgCenter = FromHex("#FDEA9D");
            ButtonCheckedBorderOut = FromHex("#8E8165");
            ButtonCheckedBorderIn = FromHex("#F9C65A");
            ButtonCheckedGlossyNorth = FromHex("#F8DBB7");
            ButtonCheckedGlossySouth = FromHex("#FED18E");

            ButtonListBorder = FromHex("#ACACAC");
            ButtonListBg = FromHex("#DAE2E2");
            ButtonListBgSelected = FromHex("#F7F7F7");

            DropDownBg = FromHex("#FAFAFA");
            DropDownImageBg = FromHex("#E9EEEE");
            DropDownImageSeparator = FromHex("#C5C5C5");
            DropDownBorder = FromHex("#868686");
            DropDownGripNorth = FromHex("#FFFFFF");
            DropDownGripSouth = FromHex("#DFE9EF");
            DropDownGripBorder = FromHex("#DDE7EE");
            DropDownGripDark = FromHex("#5574A7");
            DropDownGripLight = FromHex("#FFFFFF");

            ToolTipContentNorth = FromHex("#B6BCC6");
            ToolTipContentSouth = FromHex("#E6F0F1");
            ToolTipDarkBorder = FromHex("#AEB0B4");
            ToolTipLightBorder = FromHex("#E7E9ED");
            ToolStripItemTextPressed = FromHex("#262626");
            ToolStripItemTextSelected = FromHex("#262626");
            ToolStripItemText = FromHex("#FFFFFF");

            clrVerBG_Shadow = FromHex("#FFFFFF");

            ButtonPressed_2013 = FromHex("#FFE2A9");//92C0E0
            ButtonSelected_2013 = FromHex("#CCCCCC");//CDE6F7

            OrbButton_2013 = FromHex("#333333");
            OrbButtonSelected_2013 = FromHex("#2A8AD4");
            OrbButtonPressed_2013 = FromHex("#2A8AD4");

            RibbonBackground_2013 = FromHex("#DEDEDE");

            TabText_2013 = FromHex("#0072C6");
            TabTextSelected_2013 = FromHex("#262626");
            TabCompleteBackground_2013 = FromHex("#F3F3F3");
            TabNormalBackground_2013 = FromHex("#DEDEDE");
            TabActiveBackbround_2013 = FromHex("#F3F3F3");
            TabBorder_2013 = FromHex("#ABABAB");
            TabCompleteBorder_2013 = FromHex("#ABABAB");
            TabActiveBorder_2013 = FromHex("#ABABAB");

            OrbButtonText_2013 = FromHex("#FFFFFF");

            RibbonItemText_2013 = FromHex("#262626");
            ToolTipText_2013 = FromHex("#262626");
            ToolStripItemTextPressed_2013 = FromHex("#262626");
            ToolStripItemTextSelected_2013 = FromHex("#262626");
            ToolStripItemText_2013 = FromHex("#262626");
        }

        public Color FromHex(string hex)
        {
            return FromHexStr(hex);
        }

        static Color FromHexStr(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 6) throw new Exception("Color not valid");

            return Color.FromArgb(
                int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
        }

        public Color ToGray(Color c)
        {
            int m = (c.R + c.G + c.B) / 3;
            return Color.FromArgb(m, m, m);
        }
    }
}