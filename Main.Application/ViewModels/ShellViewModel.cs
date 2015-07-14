using Common.Application.Services;
using Main.Application.Properties;
using Main.Application.Services;
using Main.Application.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Waf.Applications;
using System.Windows.Input;

namespace Main.Application.ViewModels
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    internal class ShellViewModel : ViewModel<IShellView>
    {
        private readonly ShellService FShellService;

        public IShellService ShellService
        {
            get { return FShellService; }
        } 


        private const string C_Prop_ShowShellWindowCommand = "ShowShellWindowCommand";
        private ICommand FShowShellWindowCommand;

        public ICommand ShowShellWindowCommand
        {
            get { return FShowShellWindowCommand; }
            set
            {
                if (FShowShellWindowCommand != value)
                {
                    FShowShellWindowCommand = value;
                    RaisePropertyChanged(C_Prop_ShowShellWindowCommand);
                }
            }
        }

        private const string C_Prop_ShowSleepScreenCommmand = "ShowSleepScreenCommmand";
        private ICommand FShowSleepScreenCommmand;

        public ICommand ShowSleepScreenCommmand
        {
            get { return FShowSleepScreenCommmand; }
            set
            {
                if (FShowSleepScreenCommmand != value)
                {
                    FShowSleepScreenCommmand = value;
                    RaisePropertyChanged(C_Prop_ShowSleepScreenCommmand);
                }
            }
        }

        private const string C_Prop_ExitAppCommand = "ExitAppCommand";
        private ICommand FExitAppCommand;

        public ICommand ExitAppCommand
        {
            get { return FExitAppCommand; }
            set
            {
                if (FExitAppCommand != value)
                {
                    FExitAppCommand = value;
                    RaisePropertyChanged(C_Prop_ExitAppCommand);
                }
            }
        }
        
        [ImportingConstructor]
        public ShellViewModel(IShellView aView, ISleepService aSleepService, ShellService aShellService)
            : base(aView)
        {
            FShellService = aShellService;
            FShellService.ShellWindow = ViewCore;
            FShellService.FShowMainWindow = new Action(Show);
            FShellService.FCloseMainWindow = new Action(Close);

            ShowShellWindowCommand = new DelegateCommand(RestoreWindow);
            ExitAppCommand = new DelegateCommand(Exit);
            ShowSleepScreenCommmand = new DelegateCommand(aSleepService.Sleep);

            aView.Closed += ViewClosed;
            aView.Closing += aView_Closing;

            // Restore the window size when the values are valid.
            if (Settings.Default.Left >= 0 && Settings.Default.Top >= 0 
                && Settings.Default.Width > 0 && Settings.Default.Height > 0
                && Settings.Default.Left + Settings.Default.Width <= aView.VirtualScreenWidth
                && Settings.Default.Top + Settings.Default.Height <= aView.VirtualScreenHeight)
            {
                ViewCore.Left = Settings.Default.Left;
                ViewCore.Top = Settings.Default.Top;
                ViewCore.Height = Settings.Default.Height;
                ViewCore.Width = Settings.Default.Width;
            }
            ViewCore.IsMaximized = Settings.Default.IsMaximized;


        }

        void aView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ViewCore.IsVisible == true)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void ViewClosed(object sender, EventArgs e)
        {
            Settings.Default.Left = ViewCore.Left;
            Settings.Default.Top = ViewCore.Top;
            Settings.Default.Height = ViewCore.Height;
            Settings.Default.Width = ViewCore.Width;
            Settings.Default.IsMaximized = ViewCore.IsMaximized;
        }

        public void Show()
        {
            ViewCore.Show();
        }

        public void Exit()
        {
            ViewCore.Exit();
        }

        public void Close()
        {
            ViewCore.Close();
        }

        public void RestoreWindow()
        {
            ViewCore.RestoreWindow();
        }

        public void Hide()
        {
            ViewCore.Hide();
        }
    }
}
