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

namespace HiClock.Application.ViewModels
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    internal class HiClockMainViewModel : ViewModel<IHiClockMainView>
    {
        [ImportingConstructor]
        public HiClockMainViewModel(IHiClockMainView aView)
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
        
        private const string C_Prop_CurrentSelectedTabIndex = "CurrentSelectedTabIndex";
        private int FCurrentSelectedTabIndex = 0;

        public int CurrentSelectedTabIndex
        {
            get { return FCurrentSelectedTabIndex; }
            set
            {
                if (FCurrentSelectedTabIndex != value)
                {
                    FCurrentSelectedTabIndex = value;
                    RaisePropertyChanged(C_Prop_CurrentSelectedTabIndex);
                }
            }
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

        private const string C_Prop_HasAlarm = "HasAlarm";

        public bool HasAlarm
        {
            get { return false; }
        }

        public void AlarmCountChanged()
        {
            RaisePropertyChanged(C_Prop_HasAlarm);
        }      
        
        private const string C_Prop_HasImage = "HasImage";

        public bool HasImage
        {
            get { return Root.ImageList.HasElement(); }
        }

        public void ImageCountChanged()
        {
            RaisePropertyChanged(C_Prop_HasImage);
        }

        private const string C_Prop_IsAutoStart = "IsAutoStart";

        public bool IsAutoStart
        {
            get { return Root.IsAutoStart; }
            set
            {
                if (Root.IsAutoStart != value)
                {
                    Root.IsAutoStart = value;
                    RaisePropertyChanged(C_Prop_IsAutoStart);
                }
            }
        }
                                      
        private const string C_Prop_ImageView = "ImageView";
        private object FImageView;

        public object ImageView
        {
            get { return FImageView; }
            set
            {
                if (FImageView != value)
                {
                    FImageView = value;
                    RaisePropertyChanged(C_Prop_ImageView);
                }
            }
        }

        private const string C_Prop_AboutView = "AboutView";
        private object FAboutView;

        public object AboutView
        {
            get { return FAboutView; }
            set
            {
                if (FAboutView != value)
                {
                    FAboutView = value;
                    RaisePropertyChanged(C_Prop_AboutView);
                }
            }
        }

        private const string C_Prop_AddAlarmCommand = "AddAlarmCommand";
        private ICommand FAddAlarmCommand;

        public ICommand AddAlarmCommand
        {
            get { return FAddAlarmCommand; }
            set
            {
                if (FAddAlarmCommand != value)
                {
                    FAddAlarmCommand = value;
                    RaisePropertyChanged(C_Prop_AddAlarmCommand);
                }
            }
        }
        
        private const string C_Prop_BrowseImageCommand = "BrowseImageCommand";
        private ICommand FBrowseImageCommand;

        public ICommand BrowseImageCommand
        {
            get { return FBrowseImageCommand; }
            set
            {
                if (FBrowseImageCommand != value)
                {
                    FBrowseImageCommand = value;
                    RaisePropertyChanged(C_Prop_BrowseImageCommand);
                }
            }
        }
                
        private const string C_Prop_ExitSettingCommand = "ExitSettingCommand";
        private ICommand FExitSettingCommand;

        public ICommand ExitSettingCommand
        {
            get { return FExitSettingCommand; }
            set
            {
                if (FExitSettingCommand != value)
                {
                    FExitSettingCommand = value;
                    RaisePropertyChanged(C_Prop_ExitSettingCommand);
                }
            }
        }

        private const string C_Prop_SetAutoStartCommand = "SetAutoStartCommand";
        private ICommand FSetAutoStartCommand;

        public ICommand SetAutoStartCommand
        {
            get { return FSetAutoStartCommand; }
            set
            {
                if (FSetAutoStartCommand != value)
                {
                    FSetAutoStartCommand = value;
                    RaisePropertyChanged(C_Prop_SetAutoStartCommand);
                }
            }
        }

                    
    }
}
