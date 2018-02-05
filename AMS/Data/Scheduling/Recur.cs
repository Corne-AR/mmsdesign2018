using AMS.Data;
using System;

namespace AMS.Data.Scheduling
{
    [Serializable]
    public class Recur
    {
        public bool Active { get; set; }
        public RecurType RecurType { get; set; }

        public DateTime RecurDate { get; set; }
        // public bool HasEndDate { get; set; }
        // public int NrOccurrences { get; set; }

        //nt =  Sets to a nth date of the week and following.. ex: 2nd day of week = 1.Tues,  2.Thur, 3.Sat, 4.Mon, 5.Wed etc

        /// <summary>
        /// Every day, week, month or year based on the current RecurType
        /// </summary>
        public bool Every { get; set; }          

        /// <summary>
        /// Every following nth day, week, month or year based on the current RecurType. ex: every 2nd day
        /// </summary>
        public int EveryFollowingNth { get; set; } 

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        // Constructors

        public Recur()
        {
            RecurType = AMS.Settings.Scheduling.Recur.RecurType;
            Active = AMS.Settings.Scheduling.Recur.Active;
        }

        // Methods

        public DateTime GetNextDate()
        {
            DateTime nextDate = new DateTime();

            switch (RecurType)
            {
                case RecurType.Daily:
                    nextDate = GetNextDaily();
                    break;

                case RecurType.Weekly:
                    nextDate = GetNextWeekly();
                    break;

                case RecurType.Monthly:
                    nextDate = GetNextMonthly();
                    break;

                case Scheduling.RecurType.Yearly:
                    nextDate = GetNextYearly();
                    break;
            }

            return nextDate;
        }

        private DateTime GetNextDaily()
        {
            DateTime nextDate = new DateTime();

            if (Every)
            {
                // return the next week's date
                nextDate = RecurDate.AddDays(1);
            }
            else 
            {
                // return the following nth week's date
                nextDate = RecurDate.AddDays(EveryFollowingNth);
            }

            return nextDate;
        }

        private DateTime GetNextWeekly()
        {
            DateTime nextDate = new DateTime();

            if (Every)
            {
                // return the next week's date
                nextDate = RecurDate.AddDays(7);
            }
            else 
            {
                // return the following nth week's date
                nextDate = RecurDate.AddDays(7 * EveryFollowingNth);
            }

            return nextDate;
        }

        private DateTime GetNextMonthly()
        {
            DateTime nextDate = new DateTime();

            if (Every)
            {
                // return the next week's date
                nextDate = RecurDate.AddMonths(1);
            }
            else
            {
                // return the following nth week's date
                nextDate = RecurDate.AddMonths(EveryFollowingNth);
            }

            return nextDate;
        }

        private DateTime GetNextYearly()
        {
            DateTime nextDate = new DateTime();
            if (Every)
            {
                // return the next week's date
                nextDate = RecurDate.AddYears(1);
            }
            else
            {
                // return the following nth week's date
                nextDate = RecurDate.AddYears(EveryFollowingNth);
            }

            return nextDate;
        }

        public void UpdateRecur()
        {
            RecurDate = GetNextDate();
        }
    }
}