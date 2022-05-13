using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerScore_TEST_GUI
{
    internal static class Tools
    {
        public static void CenterControlInParent(Control control)
        {
            control.Left = (control.Parent.Width - control.Width) / 2;
            control.Top = (control.Parent.Height - control.Height) / 2;
        }
        public static void CenterControlInParentHorizontally(Control control)
        {
            control.Left = (control.Parent.Width - control.Width) / 2;
        }
    }
}
