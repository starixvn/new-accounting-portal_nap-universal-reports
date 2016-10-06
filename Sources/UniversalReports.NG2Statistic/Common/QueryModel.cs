using System;

namespace UniversalReports.NG2Statistic.Common
{
    public class QueryModel
    {
        public QueryModel()
        {
            SortColumnName = string.Empty;
            SortDirection = string.Empty;
        }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime MoveBetsDay { get; set; }

        public string UserName { get; set; }

        public string BetType { get; set; }

        public short LiveStatus { get; set; } = -1;

        public short Currency { get; set; }

        public bool IsRealTime { get; set; } = true;

        public string Title { get; set; }

        public string SortColumnName { get; set; }

        public string SortDirection { get; set; }
    }
}
