using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSelections
{    
     /// <summary>
     /// Class to produce dates for energy data.
     /// </summary>
    public readonly struct EnergyDate : IEquatable<EnergyDate>, IFormattable
    {
        private static DateTime DateTimeNow => DateTime.Now;
        private static readonly long DateTimeNowTicks = DateTimeNow.Ticks;

        private static DateTime DateTimeTodayMidnight => DateTime.Now.Date;
        private static readonly long DateTimeTodayMidnightTicks = DateTimeTodayMidnight.Ticks;

        private static DateTime DateForYesterDayMidnight => DateTime.Now.Date.AddDays(-1);
        private static readonly long DateForYesterDayMidnightTicks = DateTime.Now.Date.AddDays(-1).Ticks;

        public DateTime Last24HoursFromMidnight => DateTime.Now.Date.AddHours(-24);
        private static readonly long Last24HoursFromMidnightTicks = DateTime.Now.Date.AddHours(-24).Ticks;

        public DateTime Last24HoursFromNow => DateTime.Now.AddHours(-24);
        private static readonly long Last24HoursFromNowTicks = DateTime.Now.AddHours(-24).Ticks;


        /// <summary>
        /// Choose the number of days back in time from today at midnight and prduce a to and from date.
        /// </summary>
        /// <param name="numberOfDays">int</param>
        /// <returns>Tuple<DateTime, DateTime></returns>
        public (DateTime from, DateTime to) NumberOfDaysBackwardsFromMidnight(int numberOfDays)
        {
            return (DateTimeTodayMidnight.AddDays(-numberOfDays), DateTimeTodayMidnight);
        }

        /// <summary>
        /// Choose the number of days back in time from now and prduce a to and from date.
        /// </summary>
        /// <param name="numberOfDays">int</param>
        /// <returns>Tuple<DateTime, DateTime></returns>
        public (DateTime from, DateTime to) NumberOfDaysBackwardsFromNow(int numberOfDays)
        {
            return (DateTimeNow.AddDays(-numberOfDays), DateTimeNow);
        }

        /// <summary>
        /// Midnight to midnight for today. 
        /// </summary>
        /// <returns></returns>
        public (DateTime from, DateTime to) EnergyDayToday()
        {
            return (DateTimeTodayMidnight, DateTimeTodayMidnight.AddDays(1));
        }

        /// <summary>
        /// Midnight to midnight for yesterday. 
        /// </summary>
        /// <returns></returns>
        public (DateTime from, DateTime to) EnergyDayYesterday()
        {
            return (DateTimeTodayMidnight.AddDays(-1), DateTimeTodayMidnight);
        }

        /// <summary>
        /// Midnight to midnight for any chosen day. 
        /// </summary>
        /// <returns></returns>
        public (DateTime from, DateTime to) EnergyDay(DateTime energyDay)
        {
            return (energyDay.Date, energyDay.Date.AddDays(1));
        }


        public bool Equals(EnergyDate other)
        {
            return true;
        }
        public static bool operator ==(EnergyDate a, EnergyDate b)
        {
            return a.Ticks == b.Ticks;
        }

        public static bool operator !=(EnergyDate a, EnergyDate b)
        {
            return !(a == b);
        }

        public static bool operator >()
        {
            return 
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            throw new NotImplementedException();
        }

       

       
    }
}
