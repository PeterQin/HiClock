using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Waf.Applications;

namespace HiClock.Domain
{
    public class FileDataModel : ValidationModel
    {
        private const string C_Prop_FileName = "FileName";
        private string FFileName;

        public string FileName
        {
            get { return FFileName; }
            set
            {
                if (FFileName != value)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        { throw new ArgumentNullException("value"); }
                    }
                    FFileName = value;
                    RaisePropertyChanged(C_Prop_FileName);
                    RaisePropertyChanged(C_Prop_FileNameWithoutExtention);
                }
            }
        }

        private const string C_Prop_FileNameWithoutExtention = "FileNameWithoutExtention";

        public string FileNameWithoutExtention
        {
            get 
            {
                return Path.GetFileNameWithoutExtension(FileName); 
            }
        }
        
        private const string C_Prop_FullName = "FullName";
        private string FFullName;

        public string FullName
        {
            get { return FFullName; }
            set
            {
                if (FFullName != value)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        { throw new ArgumentNullException("value"); }
                    }
                    FFullName = value;
                    RaisePropertyChanged(C_Prop_FullName);
                }
            }
        }

    }
}
