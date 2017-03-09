using System;
using System.Globalization;

namespace UniversalReports.PunterAnalysis.Core
{
    public interface DateTimeService
    {
        DateTime GetFirstDateOfWeekISO8601(int year, int weekOfYear);
    }

    public class DateTimeServiceImp : DateTimeService
    {
        public DateTime GetFirstDateOfWeekISO8601(int year, int weekOfYear)
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
    }
}
