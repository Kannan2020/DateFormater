using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace DateFormatter
{
    /// <summary>
    /// Formating Date for what ever we want
    /// </summary>
    public static class FormatDate
    {
        /// <summary>
        /// Getting Date List from starting and ending date string in a week
        /// </summary>
        /// <param name="date"></param>
        /// <param name="format"></param>
        /// <param name="weekStartDate"></param>
        /// <returns></returns>
        public static List<string> GetWeeksInMonth(DateTime date,string format,DayOfWeek weekStartDate)
        {
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;
            IEnumerable<int> daysInMonth = Enumerable.Range(1, calendar.GetDaysInMonth(date.Year, date.Month));
            List<Tuple<DateTime, DateTime>> weeks = daysInMonth.Select(day => new DateTime(date.Year, date.Month, day))
                .GroupBy(d => calendar.GetWeekOfYear(d, CalendarWeekRule.FirstFourDayWeek, weekStartDate))
                .Select(g => new Tuple<DateTime, DateTime>(g.First(), g.Last()))
                .ToList();
            List<string> weekDetails = new List<string>();
            weeks.ForEach(x =>        
                weekDetails.Add(string.Format("{0:" + format + "} - {1:" + format + "}", x.Item1, x.Item2.AddDays(-2)))
               );
            return weekDetails;
        }
        
    }
}
