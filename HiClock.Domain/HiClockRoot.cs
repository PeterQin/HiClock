using Common.Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HiClock.Domain
{
    [Serializable]
    public class HiClockRoot : ValidationModel
    {

        public string RootDataFile
        {
            get
            {
                return Path.Combine(Util.GetDataDirectory(), "HiClockRoot.xml");
            }
        }

        private const string C_Prop_AlarmFrequenceList = "AlarmFrequencyList";
        private FrequencyCollection FAlarmFrequencyList;

        public FrequencyCollection AlarmFrequencyList
        {
            get { return FAlarmFrequencyList; }
        }

        private const string C_Prop_DurationList = "DurationList";
        private FrequencyCollection FDurationList;

        public FrequencyCollection DurationList
        {
            get { return FDurationList; }
        }

        public const string C_Prop_SelectedFrequency = "SelectedFrequency";
        private FrequencyDataModel FSelectedFrequency;

        public FrequencyDataModel SelectedFrequency
        {
            get { return FSelectedFrequency; }
            set
            {
                if (FSelectedFrequency != value)
                {
                    FSelectedFrequency = value;
                    RaisePropertyChanged(C_Prop_SelectedFrequency);
                }
            }
        }

        private const string C_Prop_SelectedDuration = "SelectedDuration";
        private FrequencyDataModel FSelectedDuration;

        public FrequencyDataModel SelectedDuration
        {
            get { return FSelectedDuration; }
            set
            {
                if (FSelectedDuration != value)
                {
                    FSelectedDuration = value;
                    RaisePropertyChanged(C_Prop_SelectedDuration);
                }
            }
        }

        private const string C_Prop_TurnOnRadio = "TurnOnRadio";
        private bool FTurnOnRadio = true;

        public bool TurnOnRadio
        {
            get { return FTurnOnRadio; }
            set
            {
                if (FTurnOnRadio != value)
                {
                    FTurnOnRadio = value;
                    RaisePropertyChanged(C_Prop_TurnOnRadio);
                }
            }
        }

        private const string C_Prop_RadioUri = "RadioUri";
        private string FRadioUri;

        public string RadioUri
        {
            get { return FRadioUri; }
            set
            {
                if (FRadioUri != value)
                {
                    FRadioUri = value;
                    RaisePropertyChanged(C_Prop_RadioUri);
                }
            }
        }


        private const string C_Prop_ImageLocation = "ImageLocation";
        private string FImageLocation;

        public string ImageLocation
        {
            get { return FImageLocation; }
            set
            {
                if (FImageLocation != value && Directory.Exists(value))
                {
                    FImageLocation = value;
                    ImportImages(value);
                    RaisePropertyChanged(C_Prop_ImageLocation);                    
                }
            }
        }

        private readonly ImageCollection FImageList;

        [XmlIgnore]
        public ImageCollection ImageList
        {
            get { return FImageList; }
        }        

        private const string C_Prop_CurrentImageIndex = "CurrentImageIndex";
        private int FCurrentImageIndex = -1;

        public int CurrentImageIndex
        {
            get { return FCurrentImageIndex; }
            set
            {
                if (FCurrentImageIndex != value)
                {
                    FCurrentImageIndex = value;
                    RaisePropertyChanged(C_Prop_CurrentImageIndex);
                }
            }
        }

        private const string C_Prop_RefreshFrequencyList = "RefreshFrequencyList";
        private FrequencyCollection FRefreshFrequencyList;

        public FrequencyCollection RefreshFrequencyList
        {
            get { return FRefreshFrequencyList; }
        }


        private const string C_Prop_RefreshScreenFrequency = "RefreshScreenFrequency";
        private FrequencyDataModel FRefreshScreenFrequency;

        public FrequencyDataModel RefreshScreenFrequency
        {
            get { return FRefreshScreenFrequency; }
            set
            {
                if (FRefreshScreenFrequency != value)
                {
                    FRefreshScreenFrequency = value;
                    RaisePropertyChanged(C_Prop_RefreshScreenFrequency);
                }
            }
        }        
        
        private const string C_Prop_IsAutoStart = "IsAutoStart";
        private bool FIsAutoStart;

        public bool IsAutoStart
        {
            get { return FIsAutoStart; }
            set
            {
                if (FIsAutoStart != value)
                {
                    FIsAutoStart = value;
                    RaisePropertyChanged(C_Prop_IsAutoStart);
                }
            }
        }

                                     
        public HiClockRoot()
        {
            FImageList = new ImageCollection();
            FAlarmFrequencyList = new FrequencyCollection();
            FDurationList = new FrequencyCollection();
            FRefreshFrequencyList = new FrequencyCollection();
            ImageLocation = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
        }

        private bool Init()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(HiClockRoot));
                TextReader reader = new StringReader(SettingResource.HiClockRoot);
                try
                {
                    HiClockRoot root = xs.Deserialize(reader) as HiClockRoot;
                    Update(root);
                }
                finally
                {
                    reader.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public void Update(HiClockRoot aRoot)
        {
            if (aRoot != null)
            {
                if (aRoot.AlarmFrequencyList.HasElement())
                {
                    this.AlarmFrequencyList.AddRange(aRoot.AlarmFrequencyList);
                }
                this.SelectedFrequency = aRoot.SelectedFrequency;
                if (aRoot.DurationList.HasElement())
                {
                    this.DurationList.AddRange(aRoot.DurationList);
                }
                this.SelectedDuration = aRoot.SelectedDuration;
                this.TurnOnRadio = aRoot.TurnOnRadio;
                this.RadioUri = aRoot.RadioUri;
                this.ImageLocation = aRoot.ImageLocation;
                this.CurrentImageIndex = aRoot.CurrentImageIndex;
                if (aRoot.RefreshFrequencyList.HasElement())
                {
                    this.RefreshFrequencyList.AddRange(aRoot.RefreshFrequencyList);
                }
                this.RefreshScreenFrequency = aRoot.RefreshScreenFrequency;
                this.IsAutoStart = aRoot.IsAutoStart;                
            }
        }

        public bool Load()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(HiClockRoot));
                if (File.Exists(RootDataFile))
                {
                    Stream stream = new FileStream(RootDataFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    try
                    {
                        HiClockRoot root = xs.Deserialize(stream) as HiClockRoot;
                        Update(root);
                    }
                    finally
                    {
                        stream.Close();
                    }
                }
                else
                {
                    Init();
                }
            }
            catch (Exception)
            {
                return false;
            }                       
            
            return true;
        }

        public bool Save()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(HiClockRoot));
                Stream stream = new FileStream(RootDataFile, FileMode.Create, FileAccess.Write, FileShare.Read);
                try
                {
                    xs.Serialize(stream, this);
                }
                finally
                {
                    stream.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }            
            return true;
        }

        public void ImportImages(string aLocation)
        {
            ImageCollection result = new ImageCollection();
            List<string> images = FileExtension.GetFiles(aLocation, "*.jpg");
            if (images.HasElement())
            {
                foreach (string item in images)
                {
                    if (File.Exists(item))
                    {
                        result.Add(new ImageDataModel() { FullName = item, FileName = Path.GetFileName(item) });
                    }
                }
            }
            FImageList.Clear();
            FImageList.AddRange(result);
            CurrentImageIndex = -1;
        }
    }
}
