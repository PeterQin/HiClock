using HiClock.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiClock.Application
{
    public class Util
    {
        private static readonly Util FInstance = new Util();

        public static Util Instance
        {
            get { return Util.FInstance; }
        } 


        public TimeSpan FormatFrequency(FrequencyDataModel aFrequency)
        {
            switch (aFrequency.TimeIn)
            {
                case TimeInType.InSecond: return new TimeSpan(0, 0, aFrequency.Frequency);
                case TimeInType.InMinute: return new TimeSpan(0, aFrequency.Frequency, 0);
                case TimeInType.InHour: return new TimeSpan(aFrequency.Frequency, 0, 0);
            }
            return TimeSpan.MaxValue;
        }
    }
}
