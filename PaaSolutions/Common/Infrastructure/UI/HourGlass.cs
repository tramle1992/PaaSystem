using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Infrastructure.UI
{
    public class HourGlass : IDisposable 
    {
        public HourGlass()
        {
            Enabled = true;
        }

        public void Dispose()
        {
            Enabled = false;
        }

        public static bool Enabled
        {
            get
            {
                return System.Windows.Forms.Application.UseWaitCursor;
            }
            set
            {
                if (value == System.Windows.Forms.Application.UseWaitCursor)
                    return;
                System.Windows.Forms.Application.UseWaitCursor = value;
                Form f = Form.ActiveForm;
                if (f != null && f.Handle != IntPtr.Zero)
                {
                    SendMessage(f.Handle, 0x20, f.Handle, (IntPtr)1);
                }
                Cursor.Position = Cursor.Position;
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
