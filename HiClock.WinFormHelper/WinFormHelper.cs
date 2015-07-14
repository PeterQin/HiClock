using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HiClock.WinForm
{
    public class WinFormHelper
    {
        private static readonly WinFormHelper FInstance = new WinFormHelper();

        public static WinFormHelper Instance
        {
            get { return WinFormHelper.FInstance; }
        } 

        private WinFormHelper()
        {
        }

        public double GetScreenWidthSum()
        {
            double result = 0;
            foreach (Screen item in Screen.AllScreens)
            {
                result += item.Bounds.Width;
            }
            return result;
        }

        public double GetMainScreenWidth()
        {
            return Screen.PrimaryScreen.Bounds.Width;
        }

        public double GetScreenMaxHeight()
        {
            double result = 0;
            foreach (Screen item in Screen.AllScreens)
            {
                if (result < item.Bounds.Height)
                {
                    result = item.Bounds.Height;
                }
            }

            return result;
        }

    }
}
