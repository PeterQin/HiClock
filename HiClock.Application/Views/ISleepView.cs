using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace HiClock.Application.Views
{
    public interface ISleepView : IView
    {
        bool? ShowDialog();
        void Show();
        void Close();
    }
}
