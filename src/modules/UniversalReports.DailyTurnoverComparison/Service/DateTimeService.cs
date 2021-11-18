using System;

namespace UniversalReports.DailyTurnoverComparison.Service
{
    public interface DateTimeService
    {
        DateTime FromDate { get; }

        DateTime ToDate { get; }
    }

    public class DateTimeServiceImp : DateTimeService
    {
        private readonly DBService dBService;
        private const sbyte minusDayNumber = -14;

        public DateTimeServiceImp(DBService dBService)
        {
            this.dBService = dBService;
        }

        public DateTime FromDate
        {
            get
            {
                return ToDate.AddDays(minusDayNumber);
            }
        }

        public DateTime ToDate
        {
            get
            {
                var isReady = dBService.QueryDWStatus().DataIsReady;
                var today = DateTime.Today.AddDays(-1);
                if (!isReady)
                {
                    today = today.AddDays(-1);
                }

                return today;
            }
        }
    }
}