using Common.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace Main.Application.Services
{
    [Export(typeof(IShellService)),Export, PartCreationPolicy(CreationPolicy.Shared)]
    internal class ShellService : DataModel, IShellService
    {
        [ImportingConstructor]
        public ShellService()
        {
        }

        private const string C_Prop_ShellContent = "ShellContent";
        private object FShellContent;

        public object ShellContent
        {
            get { return FShellContent; }
            set
            {
                if (FShellContent != value)
                {
                    FShellContent = value;
                    RaisePropertyChanged(C_Prop_ShellContent);
                }
            }
        }


        private const string C_Prop_ShellWindow = "ShellWindow";
        private object FShellWindow;

        public object ShellWindow
        {
            get { return FShellWindow; }
            internal set
            {
                if (FShellWindow != value)
                {
                    FShellWindow = value;
                    RaisePropertyChanged(C_Prop_ShellWindow);
                }
            }
        }

        private const string C_Prop_NextAlarm = "NextAlarm";
        private DateTime FNextAlarm;

        public DateTime NextAlarm
        {
            get 
            {
                return FNextAlarm; 
            }
            set
            {
                if (FNextAlarm != value)
                {
                    FNextAlarm = value;
                    RaisePropertyChanged(C_Prop_NextAlarm);
                }
            }
        }

        private const string C_Prop_IsSleeping = "IsSleeping";
        private bool FIsSleeping;

        public bool IsSleeping
        {
            get { return FIsSleeping; }
            set
            {
                if (FIsSleeping != value)
                {
                    FIsSleeping = value;
                    RaisePropertyChanged(C_Prop_IsSleeping);
                }
            }
        }
                
        internal Action FShowMainWindow;

        public void ShowMainWindow()
        {
            if (FShowMainWindow != null)
            {
                FShowMainWindow();
            }
        }

        internal Action FCloseMainWindow;
        public void CloseMainWindow()
        {
            if (FCloseMainWindow != null)
            {
                FCloseMainWindow();
            }
        }
    }
}
