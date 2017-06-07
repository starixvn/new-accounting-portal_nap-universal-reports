using System;
using System.Globalization;

namespace UniversalReports.PunterAnalysis.Shared
{
    public interface DateTimeService
    {
        DateTime GetFirstDateOfWeekIso8601(int year, int weekOfYear);

        int GetWeekOfYearIso8601(DateTime dateTime);
    }

    public class DateTimeServiceImp : DateTimeService
    {
        public DateTime GetFirstDateOfWeekIso8601(int year, int weekOfYear)
        {
            var january = new DateTime(year, 1, 1);
            var daysOffset = DayOfWeek.Thursday - january.DayOfWeek;

            var firstThursday = january.AddDays(daysOffset);
            var calendar = CultureInfo.CurrentCulture.Calendar;
            var firstWeek = calendar.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = firstWeek <= 1 ? weekOfYear - 1 : weekOfYear;

            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        public int GetWeekOfYearIso8601(DateTime dateTime)
        {
            var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);
            var realDate = day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday
                ? dateTime.AddDays(3)
                : dateTime;

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(realDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
