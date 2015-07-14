using HiClock.Application.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace HiClock.Application.ViewModels
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    internal class AboutViewModel : ViewModel<IAboutView>
    {
        [ImportingConstructor]
        public AboutViewModel(IAboutView aView)
            : base(aView)
        {
        }

        private const string C_Prop_CurrentVersion = "CurrentVersion";
        private string FCurrentVersion;

        public string CurrentVersion
        {
            get { return FCurrentVersion; }
            set
            {
                if (FCurrentVersion != value)
                {
                    FCurrentVersion = value;
                    RaisePropertyChanged(C_Prop_CurrentVersion);
                }
            }
        }

    }
}
