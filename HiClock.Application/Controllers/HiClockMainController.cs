using Common.Application.Services;
using HiClock.Application.Services;
using HiClock.Application.ViewModels;
using HiClock.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.Windows.Threading;
using Common.Foundation;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using Common.Business;

namespace HiClock.Application.Controllers
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    internal class HiClockMainController : Controller
    {
        private readonly CompositionContainer FContainer;
        private readonly Lazy<IShellService> FShellService;
        private Lazy<HiClockMainViewModel> FHiClockMainViewModel;
        private Lazy<AboutViewModel> FAboutViewModel;
        private Lazy<SleepViewModel> FSleepViewModel;
        private HiClockRoot FRoot;

        private readonly DelegateCommand FCloseSleepCommand;
        private readonly DelegateCommand FExitSettingCommand;
        private readonly DelegateCommand FSetAutoStartCommand;

        private DispatcherTimer FAlarmTimer;
        private DispatcherTimer FSleepDurationTimer;

        [ImportingConstructor]
        public HiClockMainController(CompositionContainer aContainer, Lazy<HiClockMainViewModel> aHiClockMainViewModel, SleepService aSleepSvr, Lazy<IShellService> aShellService)
        {
            FContainer = aContainer;
            FHiClockMainViewModel = aHiClockMainViewModel;            
            FShellService = aShellService;
            aSleepSvr.SleepAction = new Action(ShowSleepScreen);
            FAboutViewModel = FContainer.GetExport<AboutViewModel>();

            FCloseSleepCommand = new DelegateCommand(StopSleep);
            FExitSettingCommand = new DelegateCommand(ExitSetting);
            FSetAutoStartCommand = new DelegateCommand(SetAutoStart);

            FAlarmTimer = new DispatcherTimer();
            FAlarmTimer.Tick += FAlarmTimer_Tick;
            FSleepDurationTimer = new DispatcherTimer();
            FSleepDurationTimer.Tick += FSleepDurationTimer_Tick;
        }

        private void SetAutoStart()
        {
            SetAutoStart(FHiClockMainViewModel.Value.IsAutoStart);
        }

        private void SetAutoStart(bool IsCheckedAuto)
        {
            if (IsCheckedAuto)
            {
                ShortcutHelper.Instance.CreateShortcutToStartup();
            }
            else
            {
                ShortcutHelper.Instance.RemoveShortcutFromStartup();
            }           
        }

        private void ExitSetting()
        {
            FShellService.Value.CloseMainWindow();
        }

        public void Initialize(HiClockRoot aRoot)
        {
            FRoot = aRoot;
            this.AddWeakEventListener(FRoot, FRoot_PropChanged);
            FShellService.Value.ShellContent = FHiClockMainViewModel.Value.View;
            FHiClockMainViewModel.Value.AboutView = FAboutViewModel.Value.View;
            FHiClockMainViewModel.Value.ExitSettingCommand = FExitSettingCommand;
            FHiClockMainViewModel.Value.SetAutoStartCommand = FSetAutoStartCommand;
            FHiClockMainViewModel.Value.CurrentVersion = GetVersion();
            FHiClockMainViewModel.Value.Root = aRoot;

            FAboutViewModel.Value.CurrentVersion = GetVersion();            
        }

        private void FRoot_PropChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(HiClockRoot.C_Prop_SelectedFrequency))
            {
                //re-start timer
                StartAlartTimer();
            }
        }

        private string GetVersion()
        {
            Assembly curAssembly = Assembly.GetExecutingAssembly();
            return curAssembly.GetName().Version.ToString();
        }

        private void StartAlartTimer()
        {
            FAlarmTimer.Stop();
            FAlarmTimer.Interval = Util.Instance.FormatFrequency(FRoot.SelectedFrequency);
            FAlarmTimer.Start();
            FShellService.Value.NextAlarm = DateTime.Now.Add(FAlarmTimer.Interval);
            FShellService.Value.IsSleeping = false;
        }        

        public void Run()
        {
            StartAlartTimer(); 
        }

        public void Shutdown()
        {
            StopSleep();

            FContainer.ReleaseExport<HiClockMainViewModel>(FHiClockMainViewModel);
            FHiClockMainViewModel = null;       
        }

        public void ShowSleepScreen()
        {
            if (FSleepViewModel == null)
            {
                FSleepViewModel = FContainer.GetExport<SleepViewModel>();                
            }

            try
            {
                FSleepViewModel.Value.Root = FRoot;
                FSleepViewModel.Value.ShowDialog(); 
            }
            finally
            {
                StopSleep();
            }
           
        }

        public void Sleep()
        {
            FAlarmTimer.Stop();            
            FSleepDurationTimer.Stop();
            FSleepDurationTimer.Interval = Util.Instance.FormatFrequency(FRoot.SelectedDuration);
            FSleepDurationTimer.Start();
            FShellService.Value.IsSleeping = true;

            ShowSleepScreen();     
        }

        public void StopSleep()
        {
            if (FSleepViewModel != null)
            {
                FSleepViewModel.Value.Close();
                FContainer.ReleaseExport<SleepViewModel>(FSleepViewModel);
                FSleepViewModel = null;
            }
            if (FAlarmTimer.IsEnabled == false)
            {
                StartAlartTimer();
            }
        }

        private void FAlarmTimer_Tick(object sender, EventArgs e)
        {
            Sleep();
        }

        private void FSleepDurationTimer_Tick(object sender, EventArgs e)
        {
            StopSleep();
        }
    }
}
