using HiClock.Application.Views;
using HiClock.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.Windows.Input;
using Common.Foundation;
using System.IO;

namespace HiClock.Application.ViewModels
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    internal class SleepViewModel : ViewModel<ISleepView>
    {
        [ImportingConstructor]
        public SleepViewModel(ISleepView aView)
            : base(aView)
        {

        }

        public void Show()
        {
            ViewCore.Show();
        }

        public bool? ShowDialog()
        {
            return ViewCore.ShowDialog();
        }

        public void Close()
        {
            ViewCore.Close();
        }

        private const string C_Prop_Root = "Root";
        private HiClockRoot FRoot;

        public HiClockRoot Root
        {
            get { return FRoot; }
            set
            {
                if (FRoot != value)
                {
                    FRoot = value;
                    RaisePropertyChanged(C_Prop_Root);
                }
            }
        }        

        private const string C_Prop_CloseSleepCommand = "CloseSleepCommand";
        private ICommand FCloseSleepCommand;

        public ICommand CloseSleepCommand
        {
            get { return FCloseSleepCommand; }
            set
            {
                if (FCloseSleepCommand != value)
                {
                    FCloseSleepCommand = value;
                    RaisePropertyChanged(C_Prop_CloseSleepCommand);
                }
            }
        }
    }
}
