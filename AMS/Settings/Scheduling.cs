using AMS.Data.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Settings
{
    public static class Scheduling
    {
        public static bool WeekSelection = false;
        public static TimeSpan ScheduleDuration = new TimeSpan(0, 1, 0, 0);
        public static bool RecurActive = true;

        public static class Recur
        {
            public static bool UseDaily = true;
            public static bool UseWeekly = true;
            public static bool UseMonthly = true;
            public static bool UseYearly = true;
            public static RecurType RecurType = RecurType.Daily;
            public static bool Active = false;
        }

        
    }
}
