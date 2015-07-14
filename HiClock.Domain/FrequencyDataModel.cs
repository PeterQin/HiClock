using Common.Foundation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HiClock.Domain
{
    [Serializable]
    public class FrequencyDataModel : ValidationModel
    {
        private const string C_Prop_Frequency = "Frequency";
        private int FFrequency;

        public int Frequency
        {
            get { return FFrequency; }
            set
            {
                if (FFrequency != value)
                {
                    FFrequency = value;
                    RaisePropertyChanged(C_Prop_Frequency);
                }
            }
        }

        private const string C_Prop_TimeIn = "TimeIn";
        private TimeInType FTimeIn = TimeInType.InHour;

        public TimeInType TimeIn
        {
            get { return FTimeIn; }
            set
            {
                if (FTimeIn != value)
                {
                    FTimeIn = value;
                    RaisePropertyChanged(C_Prop_TimeIn);
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (this.GetType().Equals(obj.GetType()))
            {
                FrequencyDataModel frequency = obj as FrequencyDataModel;
                if (frequency != null)
                {
                    return this.Frequency.Equals(frequency.Frequency) && this.TimeIn.Equals(frequency.TimeIn);
                }
            }            
            return base.Equals(obj);
        }

    }

    public class FrequencyCollection : ObservableRangeCollection<FrequencyDataModel>
    {

    }
}
