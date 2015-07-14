using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiClock.Domain
{
    //[Flags]
    //public enum RepeatType
    //{        
    //    Once = 0,
    //    Hour = 1,
    //    Daily = 2,
    //    WorkDay = 3,        
    //}

    //[Flags]
    //public enum ElapsedType
    //{
    //    TwoMinutes = 2,
    //    ThreeMinutes = 3,
    //    FiveMinutes = 5,
    //    TenMinutes = 10,
    //    ThirtyMinutes = 30,
    //    MusicCompleted = 0,
    //}

    public enum TimeInType
    {
        InSecond,
        InMinute,
        InHour,
    }
}
