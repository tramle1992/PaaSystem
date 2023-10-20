using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using NodaTime;

namespace Common.Application.Helper
{
    public static class DateTimeHelper
    {
        public static int GetBusinessDaysDifference(DateTime start, DateTime stop)
        {
            // all in local time
            int days = 0;
            while (start.Date < stop.Date)
            {
                start = start.AddDays(1);
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++days;
                }
            }
            return days;
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek endOfWeek)
        {
            int diff = endOfWeek - dt.DayOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(1 * diff).Date;
        }

        public static DateTime FromWeekYearWeekAndDay(int year, int week)
        {
            LocalDate date = LocalDate.FromWeekYearWeekAndDay(year, week, IsoDayOfWeek.Sunday);
            return new DateTime(date.Year, date.Month, date.Day).AddMinutes(5);
        }
    }
}