using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PaaApplication.Helper
{
    public static class EventHandlerHelper
    {
        public static void TitleCaseTextBox_KeyPress(Object sender, KeyPressEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            int selectionStart = textbox.SelectionStart;
            if (selectionStart == 0)
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
            else if (selectionStart > 0)
            {
                if (textbox.Text[selectionStart - 1].Equals(' '))
                {
                    e.KeyChar = Char.ToUpper(e.KeyChar);
                }
            }
        }
        
        public static void CheckedListBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            ListBox lst = (ListBox)sender;            

            if (lst.Tag == null)
            {
                GlobalVars.SearchText = string.Empty;
                GlobalVars.TickCount = Environment.TickCount;
            }

            if (Environment.TickCount - GlobalVars.TickCount > 1250)
            {
                GlobalVars.SearchText = string.Empty;
            }       

            //Backspace
            if (e.KeyChar == (char)Keys.Back && GlobalVars.SearchText.Length > 0)
            {
                GlobalVars.SearchText = GlobalVars.SearchText.Substring(0, GlobalVars.SearchText.Length - 1);
            }
            else if (char.IsLetterOrDigit(e.KeyChar))
            {
                GlobalVars.SearchText += e.KeyChar;
                int index = lst.FindString(GlobalVars.SearchText);
                if (index != ListBox.NoMatches)
                {
                    lst.SelectedItems.Clear();
                    lst.SelectedIndex = index;
                }
            }
            GlobalVars.TickCount = Environment.TickCount;
            e.Handled = true;
            if(e.KeyChar == (char)Keys.Escape && GlobalVars.SearchText.Length > 0)
            {
                GlobalVars.SearchText = string.Empty;
            }
            lst.Tag = lst;
        }
    }
}