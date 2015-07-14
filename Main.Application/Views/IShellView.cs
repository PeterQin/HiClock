using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Applications;

namespace Main.Application.Views
{
    public interface IShellView : IView
    {
        double VirtualScreenWidth { get; }

        double VirtualScreenHeight { get; }

        double Left { get; set; }

        double Top { get; set; }

        double Width { get; set; }

        double Height { get; set; }

        bool IsMaximized { get; set; }

        bool IsVisible { get; }


        event EventHandler Closed;
        event CancelEventHandler Closing;

        void Show();

        void Close();

        void RestoreWindow();

        void Hide();

        void Exit();
    }
}
