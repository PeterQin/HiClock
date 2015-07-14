using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Application.Services
{
    public interface IShellService
    {
        object ShellContent { get; set; }
        object ShellWindow { get; }
        DateTime NextAlarm { get; set; }
        bool IsSleeping { get; set; }
        void ShowMainWindow();
        void CloseMainWindow();
    }
}
